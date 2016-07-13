using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseProductosProveedores
    {
        public string CorrProducto { get; set; }
        public string DescLargo { get; set; }
        public string Pais { get; set; }
        public int Estado { get; set; }
        public string Certificado { get; set; }
        public int IdTipoProducto { get; set; }
        public string Nit { get; set; }
        public string Proveedor { get; set; }
        public string TipoProducto { get; set; }
        public int IdProveedor {
            get { return IdProveedorProceso; }
        }

        public string Codigo
        {
            get { return CorrProducto; }
        }

        public string Producto
        {
            get { return DescLargo; }
        }


        public string NumProceso {
            get { return NumeroProceso; }
        }
        public string NumeroProceso { get; set; }
        public int IdProceso { get; set; }
        public int IdProveedorProceso { get; set; }
        public int IdProducto { get; set; }
        public int IdLista { get; set; }
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Aspecto { get; set; }
        public string Comentario2 { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVto { get; set; }
        public EnumHelpers.EstadoAspectos NumEstadoAspecto { get; set; }
        public string EstadoAspecto {
            get { return NumEstadoAspecto.ToString(); }
        }

        public string EstadoProducto
        {
            get { return ((EnumHelpers.EstadoProductoProveedor) Estado).ToString(); }
        }

        public int Correlativo { get; set; }
        public string Comentario { get; set; }
        public string NumeroCSSP { get; set; }
        public string NombreComercial { get; set; }
        public DateTime FechaEstado { get; set; }
        public string ComentarioEstado { get; set; }
    }
}
