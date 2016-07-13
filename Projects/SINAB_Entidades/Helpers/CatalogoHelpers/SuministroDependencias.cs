using System.Linq;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public class SuministroDependencias
    {
        public static SAB_CAT_SUMINISTRODEPENDENCIAS Obtener(int idDependencia)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_CAT_SUMINISTRODEPENDENCIAS.FirstOrDefault(sm => sm.IDDEPENDENCIA == idDependencia);
            }
        }
    }
}
