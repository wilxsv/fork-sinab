using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Caching;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class DistribucionEstablecimiento
    {
        public static void Agregar(SinabEntities db,   SAB_EST_DISTRIBUCION distribucion)
        {
            if (distribucion.idTipoEstablecimiento == 10)
            {
                var sc = new sceEntities();
                (from es in db.SAB_CAT_ESTABLECIMIENTOS
                    join vv in sc.vv_EstablecimientoRegion on es.CODIGOESTABLECIMIENTO equals vv.CodigoEstablecimiento
                    where vv.idEstablecimientoAbas == distribucion.IDESTABLECIMIENTO
                    select new SAB_EST_DISTRIBUCIONESTABLECIMIENTO()
                           {
                               IDDISTRIBUCION = distribucion.IDDISTRIBUCION,
                               IDESTABLECIMIENTO = distribucion.IDESTABLECIMIENTO,
                               IDESTABLECIMIENTODISTRIBUCION = vv.IdEstablecimiento,
                               AUUSUARIOCREACION = distribucion.AUUSUARIOCREACION,
                               AUFECHACREACION = distribucion.AUFECHACREACION
                           }).ToList().ForEach(de => db.SAB_EST_DISTRIBUCIONESTABLECIMIENTO.AddObject(de));
                db.SaveChanges();
                sc.Dispose();
            }
            else
            {
                var rec = db.SAB_CAT_ESTABLECIMIENTOS.
                    Where(es => (es.IDTIPOESTABLECIMIENTO == 3 ||
                                 es.IDTIPOESTABLECIMIENTO == 8 ||
                                 es.IDTIPOESTABLECIMIENTO == 10) &&
                                (es.IDESTABLECIMIENTO != 506 && es.IDESTABLECIMIENTO != 656)).
                    Select(es => new SAB_EST_DISTRIBUCIONESTABLECIMIENTO()
                                 {
                                     IDDISTRIBUCION = distribucion.IDDISTRIBUCION,
                                     IDESTABLECIMIENTO = distribucion.IDESTABLECIMIENTO,
                                     IDESTABLECIMIENTODISTRIBUCION = es.IDESTABLECIMIENTO,
                                     AUUSUARIOCREACION = distribucion.AUUSUARIOCREACION,
                                     AUFECHACREACION = distribucion.AUFECHACREACION
                                 }).ToList();
                rec.ForEach(de => db.SAB_EST_DISTRIBUCIONESTABLECIMIENTO.AddObject(de));
            }
        }

    }
}
