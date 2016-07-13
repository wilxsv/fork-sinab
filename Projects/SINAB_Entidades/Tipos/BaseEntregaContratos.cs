using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseEntregaContratos
    {
        public string CodigoLicitacion { get; set; }
        public string DescripcionLicitacion { get; set; }
        public string Proveedor { get; set; }
        public string NumeroContrato { get; set; }
        public long Renglon { get; set; }
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CantidadEntregada { get; set; }
        public string Almacen { get; set; }
        public string NombreFuenteFinanciamiento { get; set; }
        public decimal Pendiente {
            get { return Cantidad - CantidadEntregada; }
        }
    }
}
