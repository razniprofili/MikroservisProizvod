using MikroServisProizvod.Application.BaseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Application.SeparatedModels
{
    public abstract class SeparatedModelDto : BaseDto
    {
        public string Naziv { get; set; }
    }
}
