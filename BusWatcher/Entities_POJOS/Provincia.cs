using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Provincia :BaseEntity
    {
        public int idProvincia { get; set; }
        public string nombreProvincia { get; set; }
        public string estado { get; set; }
        public Provincia() { }
    }
}
