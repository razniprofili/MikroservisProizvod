﻿using Common.Logger;
using Domen;
using MikroServisProizvod.Application.BaseCommands;
using MikroServisProizvod.Application.BaseDtos;
using MikroServisProizvod.Application.BaseModels;
using MikroServisProizvod.Application.DefaultServices;
using MikroServisProizvod.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroservisProizvod.API.ApiCore
{
    public class LoggerMediator
    {
        private readonly ITextFileAccessor _fileAccessor;
        private readonly TextObjectAdapter _textObjectAdapter;
        public LoggerMediator(ITextFileAccessor textFileAccessor, TextObjectAdapter textAdapter)
        {
            _fileAccessor = textFileAccessor;
            _textObjectAdapter = textAdapter;
        }
        public TRes HandleProccessExecution<TReq,TRes>(ICommand<TReq, TRes> command, TReq req)
        {
            _fileAccessor.WriteNewLine(GetRequestText(command, req));

            var result = command.Execute(req);

            _fileAccessor.WriteNewLine(GetResultText(command, result));

            return result;
        }

        public string GetRequestText<TReq, TRes>(ICommand<TReq, TRes> command, TReq req) => $"{DateTime.Now} : Korisnik izvrsava komandu {command.GetType().Name} sa podacima: {_textObjectAdapter.GenerateString(req)};";
        public string GetResultText<TReq, TRes>(ICommand<TReq, TRes> command, TRes result) => $"{DateTime.Now} : Korisnik je izvrsio komandu {command.GetType().Name}, server je odgovorio: {_textObjectAdapter.GenerateString(result)};";
    }
}
