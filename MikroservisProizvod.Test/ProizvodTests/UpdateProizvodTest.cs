using AutoMapper;
using Data;
using Domen;
using FluentValidation;
using FluentValidation.Results;
using MikroServisProizvod.Application.IServices;
using MikroServisProizvod.Application.IServices.Commands.Models;
using MikroServisProizvod.Implementation.CommandImplementations.Proizvod.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroservisProizvod.Test.ProizvodTests
{
    public class UpdateProizvodTest
    {
        private Mock<IGenericRepository<Proizvod>> _mockGenericRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<IValidator<ProizvodDto>> _mockValidator;
        private IUpdateProizvodCommand _updateProizvodCommand;
        //private ProizvodDto proizvodToUpdate;
        private Proizvod mappedProizvod;
        private Proizvod proizvodFromDatabase;

        [SetUp]
        public void Setup()
        {
            _mockGenericRepository = new Mock<IGenericRepository<Proizvod>>();
            _mockMapper = new Mock<IMapper>();
            _mockValidator = new Mock<IValidator<ProizvodDto>>();

            _updateProizvodCommand = new UpdateProizvodCommand(_mockGenericRepository.Object, _mockMapper.Object, _mockValidator.Object);
          
            mappedProizvod = new Proizvod
            {
                Id = 0,
                Naziv = "Proizvod 1 update",
                Cena = 11.1,
                Pdv = 0.11,
                JedinicaMere = new JedinicaMere
                {
                    Id = 1,
                    Naziv = "Jedinica mere 1"
                },
                TipProizvoda = new TipProizvoda
                {
                    Id = 1,
                    Naziv = "Tip proizvoda 1"
                },
                Dobavljaci = new List<ProizvodDobavljac>
                {
                    new ProizvodDobavljac{
                        Dobavljac = new Dobavljac
                        {
                            Id = 1,
                            PIB = "123",
                            Napomena = "Napomena",
                            Naziv = "Dobavljac 1"
                        }
                    }
                }
            };

            proizvodFromDatabase = new Proizvod
            {
                Id = 1,
                Naziv = "Proizvod 1",
                Cena = 11.1,
                Pdv = 0.11,
            };
        }

        [Test]
        public void UpdateProizvod()
        {
            // priprema

            ProizvodDto proizvodToUpdate = new ProizvodDto
            {
                Id = 1,
                Naziv = "Proizvod 1 update",
                Cena = 11.1,
                Pdv = 0.11,
                JedinicaMereId = 1,
                TipProizvodaId = 1,
                Dobavljaci = new List<long> { 1 }
            };

            _mockGenericRepository.Setup(gr => gr.FirstOrDefault(p => p.Id == proizvodToUpdate.Id, ""))
                .Returns(proizvodFromDatabase);

            _mockGenericRepository.Setup(gr => gr.Update(mappedProizvod))
                .Callback(() => { mappedProizvod.Naziv = "Proizvod 1 update"; });

            _mockValidator.Setup(validator => validator.Validate(proizvodToUpdate))
                .Returns(new ValidationResult());

            _mockMapper.Setup(m => m.Map<Proizvod>(proizvodToUpdate))
                .Returns(mappedProizvod);

            // izvrsenje
            var result = _updateProizvodCommand.Execute(proizvodToUpdate);

            // provera
            _mockGenericRepository.Verify(gr => gr.Update(mappedProizvod), Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Naziv, proizvodToUpdate.Naziv);

        }

        [Test]
        public void UpdateProizvod_NotExist()
        {
            // priprema
            ProizvodDto proizvodToUpdate = new ProizvodDto
            {
                Id = 1,
                Naziv = "Proizvod 1 update",
                Cena = 11.1,
                Pdv = 0.11,
                JedinicaMereId = 1,
                TipProizvodaId = 1,
                Dobavljaci = new List<long> { 1 }
            };

            _mockGenericRepository.Setup(gr => gr.FirstOrDefault(p => p.Id == proizvodToUpdate.Id, ""))
                .Returns((Proizvod)null);

            // izvrsenje i provera
            Exception ex = Assert.Throws<ValidationException>(delegate { _updateProizvodCommand.Execute(proizvodToUpdate); });
            Assert.That(ex.Message, Is.EqualTo("Nepostojeci proizvod poslat na azuriranje."));

        }
    }
}
