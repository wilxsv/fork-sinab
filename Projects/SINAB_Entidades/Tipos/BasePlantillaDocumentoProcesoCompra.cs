using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BasePlantillaDocumentoProcesoCompra
    {
        public int IdDocumentoBase { get; set; }
        public int IdTipoDocumentoBase { get; set; }
        public string Descripcion { get; set; }
        public int IdEstablecimiento { get; set; }
        public long IdProcesoCompra { get; set; }
    }
}
