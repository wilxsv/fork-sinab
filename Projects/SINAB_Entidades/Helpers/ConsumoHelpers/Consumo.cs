using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Helpers.ConsumoHelpers
{
    public static class Consumo
    {
        public static List<ObtenerEcosValorizados_Result> ObtenerEcosValorizados(int idregion, int mes, int anio)
        {
            using (var db = new SinabEntities())
            {
                return db.ObtenerEcosValorizados(idregion, mes, anio).ToList();
            }
        }
    }
}
