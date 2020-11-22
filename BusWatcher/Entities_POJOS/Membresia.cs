using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Membresia :BaseEntity
    {
        public int idMembresia { get; set; }
        public double periodicidad { get; set; }
        public double montoMembresia { get; set; }
        public int idRol { get; set; }
        public string estadoMembresia { get; set; }
        public Membresia() { }
    }
}
