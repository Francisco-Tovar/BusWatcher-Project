using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Recibo :BaseEntity
    {
        public string idRecibo { get; set; }
        public DateTime fecha { get; set; }
        public string miembroId { get; set; }
        public Recibo() { }
    }
}
