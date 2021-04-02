using AutoMapper;
using Data;
using Domen;
using FluentValidation;
using MikroServisProizvod.Application.ICommands;
using MikroServisProizvod.Application.ICommands.Commands.Models;
using MikroServisProizvod.Implementation.CommandImplementations.Proizvod.Commands;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MikroservisProizvod.Test.ProizvodTests
{
    public class FindProizvodTest
    {
        private Mock<IGenericRepository<Proizvod>> _mockGenericRepository;
        private Mock<IMapper> _mockMapper;
        private IFindProizvodCommand _findProizvodService;
        private Proizvod proizvod;
        private ReadProizvodDto proizvodDto;

        [SetUp]
        public void Setup()
        {
            _mockGenericRepository = new Mock<IGenericRepository<Proizvod>>();
            _mockMapper = new Mock<IMapper>();
            _findProizvodService = new FindProizvodCommand(_mockGenericRepository.Object, _mockMapper.Object);

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
                Dobavljaci = new List<ProizvodDobavljac>()
                {
                    new ProizvodDobavljac{
                        Dobavljac = new Dobavljac
                        {
                            Id = 1,
                            Naziv = "Dobavljac 1",
                            PIB = "1234",
                            Napomena = "Napomena"
                        }
                    }
                }
            };

            proizvodDto = new ReadProizvodDto
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
                        new DobavljacDto
                        {
                            Id = 1,
                            Naziv = "Dobavljac 1"
                        }
                    }
            };
        }

        [Test]
        public void FindProizvod()
        {
            // priprema
            long id = 1;

            _mockGenericRepository.Setup(gr => gr.FirstOrDefault(p => p.Id == id, "JedinicaMere,TipProizvoda,Dobavljaci.Dobavljac"))
                .Returns(proizvod);
            _mockMapper.Setup(m => m.Map<ReadProizvodDto>(proizvod))
                .Returns(proizvodDto);

            // izvrsenje
            var res = _findProizvodService.Execute(id);

            // provera
            Assert.IsNotNull(res);
        }

        [Test]
        public void FindProizvod_NotExist()
        {
            long id = 11;

            _mockGenericRepository.Setup(gr => gr.FirstOrDefault(p => p.Id == id, "JedinicaMere,TipProizvoda,Dobavljaci.Dobavljac"))
                .Returns((Proizvod)null);

            Exception ex = Assert.Throws<ValidationException>(delegate { _findProizvodService.Execute(id); });
            Assert.That(ex.Message, Is.EqualTo("Nepostojeci proizvod."));
        }
    }
}
