using AutoMapper;
using Common.Helpers;
using Data;
using Domen;
using MikroServisProizvod.Application.IServices;
using MikroServisProizvod.Application.IServices.ProizvodServices.Models;
using MikroServisProizvod.Application.SeparatedModels;
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
    public class SearchProizvodTest
    {
        private Mock<IGenericRepository<Proizvod>> _mockGenericRepository;
        private Mock<IMapper> _mockMapper;
        private ISearchProizvodsService _searchProizvodService;
        private List<Proizvod> proizvodi;
        private List<ProizvodDto> proizvodiDto;

        [SetUp]
        public void Setup()
        {
            _mockGenericRepository = new Mock<IGenericRepository<Proizvod>>();
            _mockMapper = new Mock<IMapper>();

            _searchProizvodService = new SearchProizvodsService(_mockGenericRepository.Object, _mockMapper.Object);

            proizvodi = new List<Proizvod>
            {
                new Proizvod
                {
                    Id = 1,
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
                    Dobavljaci = new List<Dobavljac>
                    {
                        new Dobavljac{Id = 1, Naziv = "Dobavljac1"}
                    }
                },
                new Proizvod
                {
                    Id = 2,
                    Naziv = "Proizvod 2",
                    Cena = 22.2,
                    Pdv = 0.22,
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
                    Dobavljaci = new List<Dobavljac>
                    {
                        new Dobavljac{Id = 1, Naziv = "Dobavljac1"}
                    }
                }
            };

            proizvodiDto = new List<ProizvodDto>
            {
                new ProizvodDto
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
                },
                new ProizvodDto
                {
                    Id = 2,
                    Naziv = "Proizvod 2",
                    Cena = 22.2,
                    Pdv = 0.22,
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
                }
            };
        }

        [Test]
        public void SearchProizvod()
        {
            // priprema
            ProizvodSearch search = new ProizvodSearch { IsPagedResponse = false, Keyword = "" };

            _mockGenericRepository.Setup(gr => gr.Search(p => true, "JedinicaMere,TipProizvoda,Dobavljaci"))
                .Returns(proizvodi.AsQueryable());

            _mockMapper.Setup(m => m.Map<IEnumerable<ProizvodDto>>(proizvodi))
                .Returns(proizvodiDto);

            // izvrsenje
            var res = _searchProizvodService.Search(search) as List<ProizvodDto>;

            // provera
            Assert.IsNotNull(res);
            Assert.AreEqual(proizvodiDto.Count, res.Count);

        }

        [Test]
        public void PagedSearchProizvod()
        {
            // priprema
            ProizvodSearch search = new ProizvodSearch { IsPagedResponse = true, Keyword = "", PageSize = 2, PageNumber = 1 };

            _mockGenericRepository.Setup(gr => gr.Search(p => true, "JedinicaMere,TipProizvoda,Dobavljaci"))
                .Returns(proizvodi.AsQueryable());

            _mockMapper.Setup(m => m.Map<IEnumerable<ProizvodDto>>(proizvodi))
                .Returns(proizvodiDto);

            // izvrsenje
            var res = _searchProizvodService.Search(search) as PagedResponse<ProizvodDto>;

            // provera
            Assert.IsNotNull(res);
            Assert.AreEqual(proizvodiDto.Count, res.Data.Count());
            Assert.AreEqual(false, res.HasNext);
            Assert.AreEqual(false, res.HasPrevious);
            Assert.AreEqual(2, res.PageSize);
            Assert.AreEqual(proizvodiDto.Count, res.TotalCount);
            Assert.AreEqual(1, res.TotalPages);            
        }

    }
}
