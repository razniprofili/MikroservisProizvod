using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class JedinicaMere : BaseEntity
    {
        [Required]
        public string Naziv { get; set; }
    }
}
