using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseContratos : SAB_UACI_CONTRATOS
    {
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set;}
        public DateTime? FechaDocumento { get; set; }
        public string TipoCompra { get; set; }
        public string NumeroCompra { get; set; }
        public string Proveedor { get; set; }
        public decimal CantidadEntregada { get; set; }
        public decimal Cantidad { get; set; }
        public IEnumerable<string> Suministros { get; set; }
        public IEnumerable<string> FuentesFinanciamiento { get; set; }
    }
}
