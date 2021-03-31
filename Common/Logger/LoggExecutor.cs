using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logger
{
    public class LoggExecutor : ILoggExecutor
    {
        public LoggExecutor()
        {

        }

        public void SaveInputData(object data)
        {
            throw new NotImplementedException();
        }

        public void SaveOutputData(object data)
        {
            throw new NotImplementedException();
        }
    }

    public interface ILoggExecutor
    {
        void SaveInputData(object data);
        void SaveOutputData(object data);
    }
}
