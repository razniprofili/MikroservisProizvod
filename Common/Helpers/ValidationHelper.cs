using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class ValidationHelper
    {
        public static void ValidateNotNull<T>(T entity) where T : class
        {
            if (entity == null)
                throw new ValidationException($"{typeof(T).Name} not exist!");
        }


        public static void ValidateEntityExists<T>(T entity) where T : class
        {
            if (entity != null)
                throw new ValidationException($"{typeof(T).Name} currently exists!");
        }
    }
}
