using System;

namespace SINAB_Entidades.Tipos
{
    public class BaseAspectoProducto
    {
        public int Estado { get; set; }
        public EnumHelpers.EstadoAspectos NumEstadoAspecto { get; set; }
        public string EstadoAspecto
        {
            get { return NumEstadoAspecto.ToString(); }
        }
        public int Correlativo { get; set; }
        public string Aspecto { get; set; }
        public DateTime FechaVto { get; set; }
        public DateTime FechaEmision { get; set; }
        public int IdProductoProveedor { get; set; }
    }
}