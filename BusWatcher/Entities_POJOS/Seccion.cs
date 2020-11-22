using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Seccion :BaseEntity
    {
        public int idSeccion { get; set; }
        public string nombreSeccion { get; set; }
        public string estado { get; set; }
        public Seccion() { }
    }
}
