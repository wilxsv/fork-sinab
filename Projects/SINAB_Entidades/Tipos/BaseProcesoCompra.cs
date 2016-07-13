using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseProcesoCompra 
    {
        public string NTitular { get; set; }
        public string ATitular { get; set; }
        public string CargoTitular { get; set; }
        public short GarantiaMantenimientoOferta { get; set; }
        public string DocumentoBase { get; set; }
        public string TipoDocumento { get; set; }
        public string Dependencia { get; set; }
        public string CodigoLicitacion { get; set; }
        public string TituloLicitacion { get; set; }
        public string DescripcionLicitacion { get; set; }
        public string LugarRecepcionOferta { get; set; }
        public string DireccionRecepcionOferta { get; set; }
        public DateTime FechaHoraInicioRecepcion { get; set; }
        public DateTime FechaHoraFinRecepcion { get; set; }
        public string LugarAperturaBase { get; set; }
        public string DireccionAperturaBase { get; set; }
        public DateTime FechaHoraInicioApertura { get; set; }
        public DateTime FechaHoraFinApertura { get; set; }
        public DateTime FechaInicioAclaraciones { get; set; }
        public DateTime FechaFinAclaraciones { get; set; }
        public decimal PorcentajeIndiceSolvencia { get; set; }
        public decimal PorcentajeCapitalTrabajo { get; set; }
        public decimal PorcentajeEndeudamiento { get; set; }
        public decimal PorcentajeReferenciasBanc { get; set; }
        public string LugarMtto { get; set; }
        public decimal GarantiaCumplimientoValor { get; set; }
        public short GarantiaCumplimientoEntrega { get; set; }
        public short GarantiaCumplimientoVigencia { get; set; }
        public string LugarCumplimiento { get; set; }
        public decimal GarantiaCalidadValor { get; set; }
        public short GarantiaCalidadEntrega { get; set; }
        public short GarantiaCalidadVigencia { get; set; }
        public string LugarCalidad { get; set; }
        public decimal GarantiaAnticipoValor { get; set; }
        public short GarantiaAnticipoEntregas { get; set; }
        public short GarantiaAnticipoVigencia { get; set; }
        public string LugarAnticipo { get; set; }
        public DateTime FechaAprobacionBase { get; set; }
        public long IdProcesoCompra { get; set; }
        public int IdEstablecimiento { get; set; }
        public short GarantiaMttoVigencia { get; set; }
        public string Establecimiento { get; set; }
        public string Descripcion { get; set; }
        public string NumeroResolucion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Modalidad {
            get { return Descripcion; }
        }

        public string DescripcionProcesoCompra
        {
            get { return string.Format("{0} | {1}", CodigoLicitacion, TituloLicitacion); }
        }

        public string IdEstablecimientoIdProcesoCompra
        {
            get { return string.Format("{0},{1}", IdEstablecimiento, IdProcesoCompra); }
        }

        public byte IdModalidadCompra { get; set; }
    }
}
