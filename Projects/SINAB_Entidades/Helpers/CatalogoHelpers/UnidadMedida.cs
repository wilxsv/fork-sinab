using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class UnidadMedida
    {
        public static bool EsDecimal(string medida)
        {
            using (var db = new SinabEntities())
            {
                var res = db.SAB_CAT_UNIDADMEDIDAS.FirstOrDefault(um => um.DESCRIPCION == medida);
                if (res == null) return false;
                return res.CANTIDADDECIMAL != null;
            }
        }
    }
}
