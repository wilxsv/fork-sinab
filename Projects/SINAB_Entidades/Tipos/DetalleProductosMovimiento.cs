using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class DetalleProductosMovimiento
    {
        public int Secuencia { get; set; }
        public decimal Cantidad { get; set; }
        public string Codigo { get; set; }
        public string Desclargo { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string FuenteFinanciamiento { get; set; }
        public string UnidadMedida { get; set; }
        public decimal? PrecioLote { get; set; }
        public string Ubicacion { get; set; }
        public string CodigoLote { get; set; }
        public string DetalleLote { get; set; }
        public decimal Total {
            get { return (decimal) (Cantidad*PrecioLote); }
        }

        public string CodigoDetalleFecha
        {
            get
            {
                var res = "";
                if (string.IsNullOrEmpty(CodigoLote) && string.IsNullOrEmpty(DetalleLote))
                {
                    res = "(N/A)";
                }else
                if (string.IsNullOrEmpty(CodigoLote))
                {
                    res = DetalleLote;
                }
                else
                if (string.IsNullOrEmpty(DetalleLote))
                {
                    res = CodigoLote;
                }
                else res = CodigoLote + DetalleLote;

                return FechaVencimiento != null 
                    ? string.Format("{0} - {1:##}/{2}", res, FechaVencimiento.Value.Month, FechaVencimiento.Value.Year) 
                    : res;
            }
        }

        public long IdLote { get; set; }
        public int IdAlmacen { get; set; }
        public bool IdEstado { get; set; }
        public long IdDetalleMovimiento { get; set; }
        public long IdProducto { get; set; }
        public int IdEstablecimiento { get; set; }
        public int IdTipoTransaccion { get; set; }
    }
}
