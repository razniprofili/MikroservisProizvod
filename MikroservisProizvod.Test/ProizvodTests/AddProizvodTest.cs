using AutoMapper;
using Data;
using Domen;
using FluentValidation;
using FluentValidation.Results;
using MikroServisProizvod.Application.ICommands;
using MikroServisProizvod.Application.ICommands.Commands.Models;
using MikroServisProizvod.Implementation.CommandImplementations.Proizvod.Commands;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MikroservisProizvod.Test.ProizvodTests
{
    public class AddProizvodTest
    {
        private Mock<IGenericRepository<Proizvod>> _mockGenericRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<IValidator<ProizvodDto>> _mockValidator;       
        private IAddProzivodCommand _addProizvodCommand;
        private ProizvodDto proizvodToAdd;
        private Proizvod mappedProizvod;

        [SetUp]
        public void Setup()
        {
            _mockGenericRepository = new Mock<IGenericRepository<Proizvod>>();
            _mockMapper = new Mock<IMapper>();
            _mockValidator = new Mock<IValidator<ProizvodDto>>();
            
            _addProizvodCommand = new AddProizvodCommand(_mockGenericRepository.Object, _mockMapper.Object, _mockValidator.Object);

            proizvodToAdd = new ProizvodDto
            {
                Id = 0, // korisnik ne salje id pri dodavanju proizvoda
                Naziv = "Proizvod 1",
                Cena = 11.1,
                Pdv = 0.11,
                JedinicaMereId = 1,
                TipProizvodaId = 1,
                Dobavljaci = new List<long> { 1 }
            };

            mappedProizvod = new Proizvod
            {
                Id = 0,
                Naziv = "Proizvod 1",
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
        }

        [Test]
        public void AddProizvod()
        {
            // priprema

            _mockValidator.Setup(validator => validator.Validate(proizvodToAdd))
                .Returns(new ValidationResult());

            _mockMapper.Setup(m => m.Map<Proizvod>(proizvodToAdd))
                .Returns(mappedProizvod);

            _mockGenericRepository.Setup(gr => gr.Add(mappedProizvod))
                .Callback(() => { mappedProizvod.Id = 11; });

            // izvrsenje
            var result = _addProizvodCommand.Execute(proizvodToAdd);

            // provera
            _mockGenericRepository.Verify(gr => gr.Add(mappedProizvod), Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual(11, result.Id);

        }

    }
}
