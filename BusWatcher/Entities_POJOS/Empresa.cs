using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJOS
{
    public class Empresa:BaseEntity
    {
        public string cedulaJuridica { get; set; }
        public string nombreComercial { get; set; }
        public string nombreLegal { get; set; }
        public string paginaWeb { get; set; }
        public int telefono { get; set; }
        public string estadoEmpresa { get; set; }
        public Empresa() { }

    }
}
