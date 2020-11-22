using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Distrito :BaseEntity
    {
        public int idDistrito { get; set; }
        public string nombreDistrito { get; set; }
        public int idProvincia { get; set; }
        public int idCanton { get; set; }
        public string estado { get; set; }
        public Distrito() { }
    }
}
