using System;

namespace SINAB_Entidades.Tipos
{
    /*
         case when s.idestado=1 then 'Grabada'  when s.idestado=2 then 'Enviada 햞ea T.'  when s.idestado=3 then 'Autorizada' 
        when s.idestado=4 then 'Rechazada 햞ea T.' 
             * when s.idestado=5 then 'RECHAZADO Proceso Compra' when s.idestado=6 then 'Aprobado Proceso Compra' 
             * else '-' end as Estado
         */
    public class ConsultaSolicitudes
    {
        public long Id { get; set; }
        public string Correlativo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Suministros { get; set; }
        public int Entregas { get; set; }
        public string EntregasCad
        {
            get { return Entregas > 0 ? string.Format("{0:0.00}", Entregas) : "-"; }
        }
        public decimal MontoSolicitado { get; set; }
        public string MontoSolicitadoCad
        {
            get { return MontoSolicitado > 0 ? string.Format("{0:0.00}", MontoSolicitado) : "-"; }
        }
        public string Solicitante { get; set; }
        public string Tipo { get; set; }
        public int? IdEstado { get; set; }
        public string UnidadTecnica { get; set; }
        public string DependenciaSolicitante { get { return UnidadTecnica; } }
        

        public string Estado
        {
            get
            {
                switch (IdEstado)
                {
                    case 1:
                        return "Grabada";
                    case 2:
                        return "Enviada 햞ea T.";
                    case 3:
                        return "Autorizada";
                    case 4:
                        return "Rechazada 햞ea T.";
                    case 5:
                        return "RECHAZADO Proceso Compra";
                    case 6:
                        return "Aprobado Proceso Compra";
                    default:
                        return "-";
                }
            }
        }
        
        /*
         DependenciaSolicitante = s.SAB_CAT_DEPENDENCIAS.NOMBRE
         */
    }
}