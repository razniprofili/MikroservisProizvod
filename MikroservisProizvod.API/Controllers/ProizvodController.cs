using AutoMapper;
using Common;
using Microsoft.AspNetCore.Mvc;
using MikroservisProizvod.API.ApiCore;
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
        private readonly LoggerMediator _loggerMediator; 
        public ProizvodController(LoggerMediator loggerMediator)
        {
            _loggerMediator = loggerMediator;
        }

        [HttpGet]
        public IActionResult SearchProizvod([FromQuery] ProizvodSearch search, [FromServices] ISearchProizvodsCommand command)
        {
            return Ok(_loggerMediator.HandleProccessExecution(command,search));
        }

        [HttpGet("{id:long}")]
        public IActionResult FindProizvod(long id, [FromServices] IFindProizvodCommand command)
        {
            return Ok(_loggerMediator.HandleProccessExecution(command, id));
        }

        [HttpPut("{id:long}")]
        public IActionResult UpdateProizvod(long id, [FromBody] ProizvodDto dto, [FromServices] IUpdateProizvodCommand command)
        {
            dto.Id = id;
            return Ok(_loggerMediator.HandleProccessExecution(command, dto));
        }

        [HttpPost]
        public IActionResult AddProizvod([FromBody] ProizvodDto dto, [FromServices] IAddProzivodCommand command)
        {
            return Ok(_loggerMediator.HandleProccessExecution(command,dto));
        }

        [HttpDelete("{id:long}")]
        public IActionResult DeleteProizvod(long id, [FromServices] IDeleteProizvodCommand command)
        {
            _loggerMediator.HandleProccessExecution(command, id);

            return Ok();
        }
    }
}
