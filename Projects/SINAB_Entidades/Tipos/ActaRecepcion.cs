using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class ActaRecepcion
    {

        public DateTime Fecha { get; set; }

        public int NumActa { get; set; }

        public string NumContrato { get; set; }

        public string NumResolucion { get; set; }

        public string Proveedor { get; set; }

        public string IdDocumento { get; set; }

        public Decimal Cantidad { get; set; }

        public Decimal PrecioUnitario { get; set; }

        public Decimal Monto { get; set; }


        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }
    }
}
