using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseRecepcionOferta
    {
        public int IdProveedor { get; set; }
        public long IdProcesoCompra { get; set; }
        public int IdEstablecimiento { get; set; }
        public string Nombre { get; set; }
        public int OrdenLlegada { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string PersonaEntrega { get; set; }
        public string DuiEntrega { get; set; }
        public decimal MontoOferta { get; set; }
        public decimal MontoGarantia { get; set; }
        public string NombreRepresentante { get; set; }
        public byte EstaHabilitado { get; set; }
        public string Observacion { get; set; }
        public string Representante {
            get { return string.IsNullOrEmpty(NombreRepresentante) ? PersonaEntrega : NombreRepresentante; }
        }

        public string FechaCortaRecepcion {
            get { return FechaEntrega.ToShortDateString(); }
        }

        public string HoraCortaRecepcion
        {
            get { return FechaEntrega.ToShortTimeString(); }
        }

    }
}
