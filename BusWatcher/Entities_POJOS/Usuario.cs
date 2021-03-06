﻿
using System;

namespace Entities_POJOS
{
    public class Usuario : BaseEntity
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public DateTime dob { get; set; }
        public string correoUsuario { get; set; }
        public int telefono { get; set; }
        public string estadoUsuario { get; set; }
        public string contrasena { get; set; }
        public int idRol { get; set; }
        public Usuario() { }
    }
}
