using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseProveedorAdjudicado
    {
        public int IdProveedor { get; set; }
        public long IdContrato { get; set; }
        public int IdEstablecimiento { get; set; }
        public string Nombre { get; set; }
        public string NumeroContrato { get; set; }

        public string IdProveedorIdContrato
        {
            get { return string.Format("{0},{1}", IdProveedor, IdContrato); }
        }

        public string ProveedorContrato
        {
            get { return string.Format("{0} | {1}", Nombre, NumeroContrato); }
        }
    }
}
