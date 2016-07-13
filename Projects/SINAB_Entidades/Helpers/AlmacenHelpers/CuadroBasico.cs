using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    //a pesar que cuadro basico esta con prefijo CAT_ en realidad pertenece a ALM_ y asi deberia ser reflejado en la base de datos.
    public static class CuadroBasico
    {
        public static SAB_CAT_CuadroBasico Obtener(decimal idalmacen)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idalmacen);
            }
        }

        public static SAB_CAT_CuadroBasico Obtener(SinabEntities db, decimal idalmacen)
        {
            return db.SAB_CAT_CuadroBasico.FirstOrDefault(cb => cb.Vigente == true && cb.IdAlmacen == idalmacen);
        }
    }
}
