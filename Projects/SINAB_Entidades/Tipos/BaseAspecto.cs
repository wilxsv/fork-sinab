using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseAspecto
    {
        public int IdLista { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Lista { get; set; }
        public int Orden { get; set; }
        public EnumHelpers.EstadoAspectos Estado { get; set; }
        public string Comentario { get; set; }
        public DateTime? FechaVto { get; set; }
        public DateTime? FechaEmision { get; set; }
        public string Pc { get; set; }
        public int IdProductoProveedor { get; set; }
    }


}
