using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class UnidadTransporte :BaseEntity
    {
        public int idUnidadTransporte { get; set; }
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int capacidad { get; set; }
        public int idEmpresa { get; set; }
        public int idRuta { get; set; }
        public string estado { get; set; }
        public UnidadTransporte() { }
    }
}
