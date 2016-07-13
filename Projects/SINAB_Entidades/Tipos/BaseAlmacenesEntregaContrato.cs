using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseAlmacenesEntregaContrato
    {
        public int IdEstablecimiento { get; set; }
        public int IdProveedor { get; set; }
        public long IdContrato { get; set; }
       
        
        
        public decimal Cantidad { get; set; }
        
        public decimal CantidadPendiente { get; set; }
        public decimal PorcentajeEntregado { get; set; }
        public decimal PorcentajePendiente { get; set; }
        public int IdAlmacenEntrega { get; set; }
        public string Almacen { get; set; }
        public long Renglon { get; set; }
        public string Producto { get; set; }
        public string UM { get; set; }
        public decimal PrecioUnitario { get; set; }
        public long Entregas { get; set; }
        public string DescripcionProveedor { get; set; }
        public string CorrProducto { get; set; }
        public short PlazoEntrega { get; set; }
        public DateTime FechaDistribucion { get; set; }
        public decimal PrecioTotal
        {
            get { return Cantidad * PrecioUnitario; }
        }
        public string FechaEntrega
        {
            get { return FechaDistribucion.AddDays(PlazoEntrega).ToShortDateString(); }
        }
    }

    public class BaseAlmacenesEntregaContratoDetalle : BaseAlmacenesEntregaContrato
    {
        public long DetalleMovimiento { get; set; }
        public DateTime? FechaMovimiento { get; set; }
        public int NumeroActa { get; set; }
        public short Anio { get; set; }
        public string Acta {
            get { return NumeroActa + "/" + Anio; }
        }
        
    }
}
