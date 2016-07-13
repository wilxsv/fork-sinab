using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseAdministradores
    {
        public int IdSolicitud { get; set; }
        public int IdEstablecimiento { get; set; }
        public string Administrador { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
