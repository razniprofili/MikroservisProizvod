using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.BaseDtos
{
    public abstract class BaseDto : ITrackableObject
    {
        public long Id { get; set; }
    }
}
