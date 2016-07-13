using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
   public class BaseInformeMuestraReporte
    {
       public string UnidadMedida { get; set; }
       public string CorrProducto { get; set; }
       public int Idinforme { get; set; }
       public int Numeronotificacion { get; set; }
       public long IdProducto { get; set; }
       public string Lote { get; set; }
       public int Renglon { get; set; }
       public string NombreComercial { get; set; }
       public string LaboratorioFabricante { get; set; }
       public decimal NumeroUnidades { get; set; }
       public DateTime FechaFabricacion { get; set; }
       public DateTime FechaVencimiento { get; set; }
       public decimal CantidadAEntregar { get; set; }
       public DateTime FechaNotificacion { get; set; }
       public int IdInspector { get; set; }
       public string ObservacionNotificacion { get; set; }
       public DateTime FechaAsignacion { get; set; }
       public string ObservacionAsignacion { get; set; }
       public string ObservacionCoordinador { get; set; }
       public string Observacion { get; set; }
    }

   public class BaseInformeMuestra : BaseInformeMuestraReporte
   {
       public new DateTime? FechaFabricacion { get; set; }
       public new DateTime? FechaVencimiento { get; set; }
       public new DateTime? FechaNotificacion { get; set; }
       public new DateTime? FechaAsignacion { get; set; }
       public decimal CantidadRemitida { get; set; }
       
   }
}
