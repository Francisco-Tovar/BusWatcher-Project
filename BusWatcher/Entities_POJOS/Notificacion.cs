using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Notificacion :BaseEntity
    {
        public string idNotificacion { get; set; }
        public string miembroId { get; set; }
        public string estado { get; set; }
        public Notificacion() { }
    }
}
