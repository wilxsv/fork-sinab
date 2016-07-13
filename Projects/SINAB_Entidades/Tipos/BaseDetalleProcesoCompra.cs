using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseDetalleProcesoCompra
    {
        public int Renglon { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Cantidad { get; set; }
        public byte Entregas { get; set; }
        public long IdProducto { get; set; }
        public decimal Monto { get; set; }
        public decimal GarantiaMontoValor { get; set; }
        public int IdEstablecimiento { get; set; }
        public long IdSolicitud { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    public class DetalleProcesoCompraAdjudicada : BaseDetalleProcesoCompra
    {
        public long IdProcesoCompra { get; set; }
        public int IdProveedor { get; set; }
        public int OrdenLlegada { get; set; }
        public decimal CantidadAdjudicada { get; set; }
        public string Proveedor { get; set; }
    }
}
