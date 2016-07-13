using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    [Serializable()]
    public class BaseProductos
    {
        public long IdProducto { get; set; }

        #region FK

        public int IdFuenteFinanciamiento { get; set; }
        public int IdAlmacen { get; set; }
        public int IdProveedor { get; set; }
        public long IdContrato { get; set; }
        public long IdSolicitud { get; set; }
        public int IdEstablecimiento { get; set; }

        #endregion FK

        
        public string CorrProducto { get; set; }
        public long Renglon { get; set; }
        public virtual string DescLargo { get; set; }
        public string UnidadMedida { get; set; }
        public string DescripcionProveedor { get; set; }
        public byte EstaHabilitado { get; set; }
        public DateTime? FechaDeshabilitacion { get; set; }
        public string Observacion { get; set; }
        public string Descripcion { get; set; }
        
        
        public long Precio { get; set; }
        public decimal PrecioActual { get; set; }
        public decimal PrecioUnitario { get; set; }


        public decimal Cantidad { get; set; }
        public decimal? Total { get; set; }
        public short NumeroEntrega { get; set; }

        public string RutaEspecificacion { get; set; }
        public string FuenteFinanciamiento { get; set; }
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        public bool Lleno { get; set; }

        public string CodigoONU { get; set; }

        public string Almacen { get; set; }

        public List<SAB_EST_CIFRADOPRODUCTOSSOLICITUDES> Cifrados { get; set; }
        public string Establecimiento { get; set; }
        public string CodigoEstablecimiento { get; set; }
        public int IdGrupoReq { get; set; }

        public string DescripcionCompleta
        {
            get { return string.Format("{0} | {1} - {2}", Renglon, CorrProducto, DescLargo); }
        }

        public string CasaRepresentada { get; set; }
        
    }
    [Serializable]
    public class ProductosSolicitudCorrelativo : BaseProductos
    {
        public int? Correlativo { get; set; }
        public new string DescripcionCompleta
        {
            get { return string.Format("{0} | {1} - {2}", Correlativo, CorrProducto, DescLargo); }
        }
    }


    public class ProductoCifradoPresupuestario 
    {

        public string Cifrado { get; set; }
        public long CifradoCantidad { get; set; }
        public double CifradoMonto { get; set; }
        public int Renglon { get; set; }
        public string CorrProducto { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Cantidad { get; set; }
        public string DescLargo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Monto {
            get { return Cantidad*PrecioUnitario; }
        }
    }

    public class ProductoSolicitudVistaProductos : BaseProductos
    {
        public int IdSuministro { get; set; }
        public int IdUnidadMedida { get; set; }

        public string DescTemp { get; set; }
        
        public short? Entrega { get; set; }
        public int Capturado { get; set; }
        
        public decimal MontoRenglon
        {
            get { return (Cantidad) * (PrecioActual); }
        }
        
        public override string DescLargo
        {
            get { return DescTemp; }
        }

        public int? Correlativo { get; set; }
    }

    public class DistribucionProducto : BaseProductos
    {
        public int IdSuministro { get; set; }

        public int IdDistribucion { get; set; }

        public decimal CantidadAlmacen { get; set; }

        public decimal CantidadReal { get; set; }

        public decimal CantidadDisponible { get; set; }

        public int IdGrupo { get; set; }

        public string CorrGrupo { get; set; }

        public string DescGrupo { get; set; }

        public int IdSubGrupo { get; set; }

        public string CorrSubGrupo { get; set; }

        public string DescSubGrupo { get; set; }

        public string CorrSuministro { get; set; }

        public string DescSuministro { get; set; }


        public string DescProducto { get; set; }

        public string CorrelativoDescripcion { get; set; }

        public decimal ExistenciaActual { get; set; }

        public string NombreCorto { get; set; }

        public decimal CantidadNoDisponible { get; set; }

        public decimal CantidadReservada { get; set; }

        public decimal CantidadTemporal { get; set; }

        public decimal? CantidadVencida { get; set; }
    }

    public class ProductoDetalleSolicitud : BaseProductos
    {
        public int? IdEspecificacion { get; set; }
        public int? IdUnidadMedida { get; set; }
        public decimal? PresupuestoUnitario { get; set; }
        public decimal? PresupuestoTotal { get; set; }
        public new decimal? Cantidad { get; set; }
        public decimal? NumeroEntregas { get; set; }
        public long IdEntrega { get; set; }
        public decimal CantidadEntrega { get; set; }
        public string EspecificacionEntrega { get; set; }
    }
}
