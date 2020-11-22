using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Canton :BaseEntity
    {
        public int idCanton { get; set; }
        public string nombreCanton { get; set; }
        public int idProvincia { get; set; }
        public string estado { get; set; }
        public Canton() { }
    }
}
