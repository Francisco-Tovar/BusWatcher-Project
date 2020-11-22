using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class UbicacionExacta :BaseEntity
    {
        public int idUbicacionExacta { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string senas { get; set; }
        public string idProvincia { get; set; }
        public string idCanton { get; set; }
        public string idDistrito { get; set; }
        public int idRuta { get; set; }
        public int idEmpresa { get; set; }
        public int idUsuarioRol { get; set; }
        public string estadoUbicacion { get; set; }
        public UbicacionExacta() { }
    }
}
