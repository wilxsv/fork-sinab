using System.Linq;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public class EntregaSolicitudes
    {
        /// <summary>
        /// Elimina los registros de ENTREGASOLICITUDES que cumplan con la condición.
        /// Este método no guarda en la DB, debe usarse "db.savechanges" fuera del método.
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="idSolicitud">Id de la Solicitud</param>
        /// <param name="idEstablecimiento">Id del Establecimiento</param>
        public static void Eliminar(SinabEntities db, long idSolicitud, int idEstablecimiento)
        {
            var recs = db.SAB_EST_ENTREGASOLICITUDES.Where(es => es.IDSOLICITUD == idSolicitud &&
                                                                 es.IDESTABLECIMIENTO == idEstablecimiento).ToList();
            if (!recs.Any()) return;

            foreach (var rec in recs)
           { 
                if (rec.SAB_EST_ALMACENESENTREGASOLICITUD.Any())
                {
                    foreach (var subrec in rec.SAB_EST_ALMACENESENTREGASOLICITUD)
                    {
                        db.SAB_EST_ALMACENESENTREGASOLICITUD.DeleteObject(subrec);
                    }
                }
                db.SAB_EST_ENTREGASOLICITUDES.DeleteObject(rec);
            }
        }


    }
}

