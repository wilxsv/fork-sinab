using System.Linq;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public static class UbicacionesProductos
    {
        public static void AgregarUbicacionProducto(SAB_ALM_UBICACIONESPRODUCTOS ubicacion)
        {
            using (var db = new SinabEntities())
            {
                var lastId = db.SAB_ALM_UBICACIONESPRODUCTOS.Where(up =>
                    up.IDALMACEN == ubicacion.IDALMACEN &&
                    up.IDPRODUCTO == ubicacion.IDPRODUCTO).Max(up => up.IDPRODUCTO);

                ubicacion.IDUBICACION = (int) (lastId + 1);
                db.SAB_ALM_UBICACIONESPRODUCTOS.AddObject(ubicacion);
                db.SaveChanges();
               
            }
        }

        public static void AgregarUbicacionProducto(SAB_ALM_UBICACIONESPRODUCTOS ubicacion, SinabEntities db)
        {
            
                var lastId = db.SAB_ALM_UBICACIONESPRODUCTOS.Where(up =>
                    up.IDALMACEN == ubicacion.IDALMACEN &&
                    up.IDPRODUCTO == ubicacion.IDPRODUCTO).Max(up => up.IDPRODUCTO);

                ubicacion.IDUBICACION = (int)(lastId + 1);
                db.SAB_ALM_UBICACIONESPRODUCTOS.AddObject(ubicacion);
                db.SaveChanges();

           
        }
    }
}
