using Domen;
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

    }

    public class LoggerWrapper
    {

    }

    public interface ILoggable
    {

    }
}
