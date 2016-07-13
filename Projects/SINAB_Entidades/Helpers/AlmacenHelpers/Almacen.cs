using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public static class Almacen
    {
        public static List<BaseAlmacen> ObtenerTodosConCuandroBasico(SinabEntities db)
        {
            return db.SAB_CAT_ALMACENES.Where(al => al.SAB_CAT_CuadroBasico.Any()).Select(al => new BaseAlmacen()
            {
                Nombre = al.SAB_CAT_ALMACENESESTABLECIMIENTOS.FirstOrDefault().SAB_CAT_ESTABLECIMIENTOS.NOMBRE,
                IdAlmacen = al.IDALMACEN
            }).OrderBy(al => al.Nombre).ToList();
        }

        public static List<BaseAlmacen> ObtenerTodosConCuandroBasico()
        {
            using(var db = new SinabEntities())
            {
                return ObtenerTodosConCuandroBasico(db);
            }
        }
    }
}
