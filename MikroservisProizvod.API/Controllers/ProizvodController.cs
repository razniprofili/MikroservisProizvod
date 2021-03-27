using AutoMapper;
using Common;
using Data.Uow;
using Microsoft.AspNetCore.Mvc;
using MikroservisProizvod.API.Helpers;
using MikroservisProizvod.API.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroservisProizvod.API.Controllers
{
    [ValidateModel]
    [Produces("application/json")]
    [Route("api/Proizvod")]
    public class ProizvodController : Controller
    {
        private IProizvodService _proizvodService;
        private IMapper _mapper;

        public ProizvodController(IProizvodService proizvodService, IMapper mapper)
        {
            _proizvodService = proizvodService;
            _mapper = mapper;
        }

        [HttpGet("{id:long}")]
        public ProizvodModel PrikaziProizvod(long id)
        {
            var proizvod = _proizvodService.Get(id);

            return _mapper.Map<ProizvodModel>(proizvod);
        }

        [HttpGet]
        public List<ProizvodModel> PretraziProizvode([FromQuery] ResourceParameters parameters)
        {
            return new List<ProizvodModel>();
        }
    }
}
