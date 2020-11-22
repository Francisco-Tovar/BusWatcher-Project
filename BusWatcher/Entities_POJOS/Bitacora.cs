using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Bitacora : BaseEntity
    {
        public int idBitacora { get; set; }
        public DateTime fechaAccion { get; set; }
        public string accion { get; set; }
        public int idUsuario { get; set; }
        public Bitacora() { }
    }
}
