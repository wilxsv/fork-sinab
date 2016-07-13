using System;
using System.Web.Caching;

namespace SINAB_Entidades.Tipos
{
    public class BaseDetalleSolicitud
    {
        public long Solicitud { get; set; }

        public int IdEstablecimiento { get; set; }

        public string Codigo { get; set; }

        

        public DateTime Fecha { get; set; }

        public int Plazo { get; set; }

        public short PeriodoUtilizacion { get; set; }

        public decimal MontoSolicitado { get; set; }

        public decimal MontoDisponible { get; set; }

        public string NombreSolicita { get; set; }

        public string Observacion { get; set; }

        public string CargoSolicita { get; set; }

        public byte CompraConjunta { get; set; }

        public string NombreTecnica { get; set; }

        public string NombreAutoriza { get; set; }

        public int Estado { get; set; }

        public string UnidadTecnica { get; set; }

        public string Establecimiento { get; set; }

        public string Suministro { get; set; }

        public string Suminitro2 { get; set; }

        public string Dependencia { get; set; }

        public long Renglon { get; set; }

        public long IdProducto { get; set; }

        public decimal Cantidad { get; set; }

        public string EspecificacionesTecnicas { get; set; }

        public decimal PresupuestoUnitario { get; set; }

        public decimal PresupuestoTotal { get; set; }

        public byte NumeroEntregas { get; set; }

        public string Unidad { get; set; }

        public string CodigoProducto { get; set; }

        public string Producto { get; set; }

        public string CodigoNacionesUnidas { get; set; }

        public string FuenteFinanciamiento { get; set; }
       
        public string CargoTecnica { get; set; }

        public string CargoAutoriza { get; set; }
        public string NombreCertifica { get; set; }
        public string CargoCertifica { get; set; }
        public string CifradoPresupuestario { get; set; }

        public long CorrelativoUFI { get; set; }

        public int CodigoNumerico {
            get
            {
                return Convert.ToInt32(CodigoProducto);
            }
        }

        public int DiasEntregas { get; set; }
    }
}
