using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseContratoAdjudicado
    {
        public int NumeroNotificacion { get; set; }
        public DateTime FechaNotificacion { get; set; }
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string NumeroContrato { get; set; }
        public long Idcontrato { get; set; }
        public int IdEstablecimiento { get; set; }
        public string ProcesoCompra { get; set; }
        public long IdProcesoCompra { get; set; }
        public string CodigoLicitacion { get; set; }
        public int IdInforme { get; set; }
        public string ObservacionAsignacion { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public int Items { get; set; }
    }
}
