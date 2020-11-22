using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Nivel :BaseEntity
    {
        public int idNivel { get; set; }
        public string nombreNivel { get; set; }
        public string estado { get; set; }
        public Nivel() { }
    }
}
