using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class ProizvodDobavljac
    {
        public long ProizvodId { get; set; }
        public long DobavljacId { get; set; }
        public Proizvod Proizvod { get; set; }
        public Dobavljac Dobavljac { get; set; }
    }
}
