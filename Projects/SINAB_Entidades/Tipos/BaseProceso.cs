using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINAB_Entidades.Helpers.CertificacionHelpers;

namespace SINAB_Entidades.Tipos
{
    public class BaseProceso
    {
        public int IdProceso { get; set; }
        public string NumeroProceso { get; set; }
        public int IdTipoProducto { get; set; }
        public EnumHelpers.EstadoProceso Estado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Descripcion { get; set; }
        public string TipoProducto { get; set; }
        public string Nit { get; set; }
        public int IdProveedor { get; set; }
        public string Proveedor { get; set; }
        

        public int ProductosC
        {
            get
            {
                return ProveedoresProceso.ObtenerConteoProductosCertificados(IdProceso, IdProveedor);
            }

        }
        public int ProductosN {
            get
            {
                var cont = ProveedoresProceso.ObtenerConteoProductos(IdProceso, IdProveedor);
                return cont - ProductosC;
            }
        }
    }
}
