using AutoMapper;
using Common;
using Microsoft.AspNetCore.Mvc;
using MikroservisProizvod.API.Helpers;
using MikroServisProizvod.Application.IServices;
using MikroServisProizvod.Application.IServices.ProizvodServices.Models;
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

        [HttpGet]
        public IActionResult SearchProizvod([FromQuery] ProizvodSearch search, [FromServices] ISearchProizvodsService service)
        {
            return Ok(service.Search(search));
        }

        [HttpGet("{id:long}")]
        public IActionResult FindProizvod(long id, [FromServices] IFindProizvodService service)
        {
            return Ok(service.Find(id));
        }

        [HttpPut("{id:long}")]
        public IActionResult UpdateProizvod(long id,[FromBody] ProizvodDto dto, [FromServices] IUpdateProizvodService service)
        {
            dto.Id = id;
            return Ok(service.Update(dto));
        }

        [HttpPost]
        public IActionResult AddProizvod([FromBody] ProizvodDto dto, [FromServices] IAddProzivodService service)
        {
            return Ok(service.Add(dto));
        }

        [HttpDelete("{id:long}")]
        public IActionResult DeleteProizvod(long id, [FromServices] IDeleteProizvodService service)
        {
            service.Delete(id);

            return Ok();
        }
    }
}
