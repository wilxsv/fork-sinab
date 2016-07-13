using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseProductoSolicitud
    {
        public BaseProductoSolicitud()
        {
            Productossolicitud = new SAB_EST_PRODUCTOSSOLICITUD();
        }

        public SAB_EST_PRODUCTOSSOLICITUD Productossolicitud { get; set; }

        public string Codigo { get; set; }
    }
}
