using Domen;
using MikroServisProizvod.Application.BaseCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroservisProizvod.API.ApiCore
{
    public class LoggerMediator
    {
        private readonly Context _context;
        public LoggerMediator(Context context)
        {
            _context = context;
        }
        public TRes HandleProccessExecution<TReq,TRes>(ICommand<TReq, TRes> command, TReq req)
        {
            //writingHandling

            var result = command.Execute(req);

            //writingExec

            return result;
        }
    }

    public class LoggerWrapper
    {

    }

    public interface ILoggable
    {

    }
}
