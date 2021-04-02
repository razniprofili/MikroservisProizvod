using Common.Logger;
using Domen;
using MikroServisProizvod.Application.BaseCommands;
using MikroServisProizvod.Application.BaseDtos;
using MikroServisProizvod.Application.BaseModels;
using MikroServisProizvod.Application.DefaultServices;
using MikroServisProizvod.Application.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroservisProizvod.API.ApiCore
{
    public class LoggerMediator
    {
        private readonly ITextFileAccessor _fileAccessor;
        public LoggerMediator(ITextFileAccessor textFileAccessor)
        {
            _fileAccessor = textFileAccessor;
        }
        public TRes HandleProccessExecution<TReq,TRes>(ICommand<TReq, TRes> command, TReq req)
        {
            _fileAccessor.WriteNewLine(GetRequestText(command, req));

            var result = command.Execute(req);

            _fileAccessor.WriteNewLine(GetResultText(command, result));

            return result;
        }

        public string GetRequestText<TReq, TRes>(ICommand<TReq, TRes> command, TReq req) => $"{DateTime.Now} : Korisnik izvrsava komandu {command.GetType().Name} sa podacima: {JsonConvert.SerializeObject(req)};";
        public string GetResultText<TReq, TRes>(ICommand<TReq, TRes> command, TRes result) => $"{DateTime.Now} : Korisnik je izvrsio komandu {command.GetType().Name}, server je odgovorio: {JsonConvert.SerializeObject(result)};";
    }
}
