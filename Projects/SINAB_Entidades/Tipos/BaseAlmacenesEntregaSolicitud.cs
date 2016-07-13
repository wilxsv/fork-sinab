using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    [Serializable()]
    public class BaseAlmacenesEntregaSolicitud
    {
        public int IdEstablecimiento { get; set; }
        public long IdSolicitud { get; set; }
        public int Renglon { get; set; }
        public long IdProducto { get; set; }
        public string CorrProducto { get; set; }
        public string DescLargo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int IdFuenteFinanciamiento { get; set; }
        public string FuenteFinanciamiento { get; set; }
        public string CodigoEstablecimiento { get; set; }
        public string Almacen { get; set; }
        public string CodigoNacionesUnidas { get; set; }
        public byte NumeroEntregas { get; set; }
    }

    public class AlmacenesEntregaSolicitudDetalle : BaseAlmacenesEntregaSolicitud
    {
       
        public decimal NecesidadFinal { get; set; }
        public string Descripcion { get; set; }
        public int IdEstablecimientoNecesidad { get; set; }
        public string Nombre { get; set; }
        public int CorrelativoRenglon { get; set; }
        public int CodigoNumerico
        {
            get
            {
                return Convert.ToInt32(CorrProducto);
            }
        }
    }

    public class ConsolidadoAlmacenEntregaSolicitud : BaseAlmacenesEntregaSolicitud
    {
        public string UnidadMedida { get; set; }
        public string Establecimiento { get; set; }
        public decimal Cantidad { get; set; }
        public byte NumeroEntrega { get; set; }
        public int IdEstablecimientoNececidad { get; set; }
        public short DiasEntrega { get; set; }
        public decimal PorcentajeEntrega { get; set; }
    }

}
