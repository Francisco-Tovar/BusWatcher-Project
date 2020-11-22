using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Rol:BaseEntity
    { 
        public string nombreRol { get; set; }
        public string estadoRol { get; set; }
        public Rol() { }
    }
}
