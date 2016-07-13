using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseEstadoProducto
    {
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public int IdProductoProveedor { get; set; }
        public int Id { get; set; }
    }
}
