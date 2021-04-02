using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.BaseDtos
{
    public abstract class BaseDto : ILoggableObject
    {
        public long Id { get; set; }
    }
}
