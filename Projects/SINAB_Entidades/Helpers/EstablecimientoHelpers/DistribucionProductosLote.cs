using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class DistribucionProductosLote
    {
        public static void AgregarVarios(SinabEntities db, SAB_EST_DISTRIBUCION distribucion, IEnumerable<int> idProductos)
        {
            foreach (var n in idProductos)
            {
                (from dp in db.SAB_EST_DISTRIBUCIONPRODUCTO
                 join l in db.SAB_ALM_LOTES on dp.IDPRODUCTO equals l.IDPRODUCTO
                 where
                     dp.IDDISTRIBUCION == distribucion.IDDISTRIBUCION &&
                     dp.IDESTABLECIMIENTO == distribucion.IDESTABLECIMIENTO &&
                     l.IDALMACEN == distribucion.IDALMACEN &&
                     l.IDPRODUCTO == n
                 select new SAB_EST_DISTRIBUCIONPRODUCTOLOTE()
                 {
                     IDDISTRIBUCION = dp.IDDISTRIBUCION,
                     IDESTABLECIMIENTO = dp.IDESTABLECIMIENTO,
                     IDPRODUCTO = dp.IDPRODUCTO,
                     IDALMACEN = l.IDALMACEN,
                     IDLOTE = l.IDLOTE,
                     AUUSUARIOCREACION = distribucion.AUUSUARIOCREACION,
                     AUFECHACREACION = distribucion.AUFECHACREACION
                 }).ToList().ForEach(p => db.SAB_EST_DISTRIBUCIONPRODUCTOLOTE.AddObject(p));
            }
            db.SaveChanges();
        }

         
    }
}
