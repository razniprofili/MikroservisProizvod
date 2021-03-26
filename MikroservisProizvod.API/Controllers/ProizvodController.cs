using Microsoft.AspNetCore.Mvc;
using MikroservisProizvod.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroservisProizvod.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Proizvod")]
    public class ProizvodController : Controller
    {
        public ProizvodController()
        {

        }

        [HttpGet("{id}")]
        public ProizvodModel PrikaziProizvod(long id)
        {
            return new ProizvodModel { };
        }

        [HttpGet]
        public List<ProizvodModel> PretraziProizvode([FromQuery] ResourceParameters parameters)
        {
            return new List<ProizvodModel>();
        }
    }
}
