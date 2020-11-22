using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Documento : BaseEntity
    {
        public int idDocumento { get; set; }
        public string descripcion { get; set; }
        public string rutaDocumento { get; set; }
        public int idEmpresa { get; set; }
        public int idUsuario { get; set; }
        public int idUnidadTransporte { get; set; }
        public string estadoDocumento { get; set; }
        public Documento() { }
    }
}
