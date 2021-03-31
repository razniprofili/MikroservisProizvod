using AutoMapper;
using Data;
using Domen;
using FluentValidation;
using MikroServisProizvod.Application.DefaultServices;
using MikroServisProizvod.Application.IServices;
using MikroServisProizvod.Application.IServices.ProizvodServices.Models;
using MikroServisProizvod.Application.SeparatedModels;
using MikroServisProizvod.Implementation.ServiceImplementations;
using MikroServisProizvod.Implementation.ServiceImplementations.Proizvod.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroservisProizvod.Test.ProizvodTests
{
    public class FindProizvodTest
    {
        private Mock<IGenericRepository<Proizvod>> _mockGenericRepository;
        private Mock<IMapper> _mockMapper;
        //private IFindService<ProizvodDto> _findService;
        private IFindProizvodService _findProizvodService;
        private Proizvod proizvod;
        private ProizvodDto proizvodDto;

        [SetUp]
        public void Setup()
        {
            _mockGenericRepository = new Mock<IGenericRepository<Proizvod>>();
            _mockMapper = new Mock<IMapper>();

            //_findService = new BaseFindService<Proizvod, ProizvodDto>(_mockGenericRepository.Object, _mockMapper.Object);
            _findProizvodService = new FindProizvodService(_mockGenericRepository.Object, _mockMapper.Object);

            proizvod = new Proizvod
            {
                Id = 1,
                Naziv = "Proizvod 1",
                Cena = 11.1,
                Pdv = 0.11,
                JedinicaMere = new JedinicaMere
                {
                    Id= 1,
                    Naziv = "Jedinica mere 1"
                },
                TipProizvoda = new TipProizvoda
                {
                    Id =1,
                    Naziv = "Tip proizvoda 1"
                }, 
                Dobavljaci =  new List<Dobavljac>
                {
                    new Dobavljac{Id = 1, Naziv = "Dobavljac1"}
                }
            };

            proizvodDto = new ProizvodDto
            {
                Id = 1,
                Naziv = "Proizvod 1",
                Cena = 11.1,
                Pdv = 0.11,
                JedinicaMere = new JedinicaMereDto
                {
                    Id = 1,
                    Naziv = "Jedinica mere 1"
                },
                TipProizvoda = new TipProizvodaDto
                {
                    Id = 1,
                    Naziv = "Tip proizvoda 1"
                },
                Dobavljaci = new List<DobavljacDto>
                {
                    new DobavljacDto{Id = 1, Naziv = "Dobavljac1"}
                }
            };
        }

        [Test]
        public void FindProizvod()
        {
            // priprema
            long id = 1;

            _mockGenericRepository.Setup(gr => gr.FirstOrDefault(p => p.Id == id, "JedinicaMere,TipProizvoda,Dobavljaci"))
                .Returns(proizvod);
            _mockMapper.Setup(m => m.Map<ProizvodDto>(proizvod))
                .Returns(proizvodDto);

            // izvrsenje
            var res = _findProizvodService.Find(id);

            // provera
            Assert.IsNotNull(res);
        }

        [Test]
        public void FindProizvod_NotExist()
        {
            long id = 11;

            _mockGenericRepository.Setup(gr => gr.FirstOrDefault(p => p.Id == id, "JedinicaMere,TipProizvoda,Dobavljaci"))
                .Returns((Proizvod)null);

            Exception ex = Assert.Throws<ValidationException>(delegate { _findProizvodService.Find(id); });
            Assert.That(ex.Message, Is.EqualTo("Nepostojeci proizvod."));
        }
    }
}
