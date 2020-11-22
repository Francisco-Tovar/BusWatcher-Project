using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Pago :BaseEntity
    {
        public int idPago { get; set; }
        public DateTime fechaPago { get; set; }
        public int idUsuarioRolMembresia { get; set; }
        public string cuenta { get; set; }
        public Pago() { }
    }
}
