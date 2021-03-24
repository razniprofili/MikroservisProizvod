using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class TipProizvoda
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Naziv { get; set; }
    }
}
