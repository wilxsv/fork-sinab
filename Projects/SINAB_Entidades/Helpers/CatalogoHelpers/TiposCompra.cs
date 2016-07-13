using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class TiposCompra
    {
        public static SAB_CAT_TIPOCOMPRAS Obtener(SAB_CAT_TIPOCOMPRAS tipo)
        {
            using (var db = new SinabEntities())
            {
               return Obtener(db, tipo);
            }
        }

        public static SAB_CAT_TIPOCOMPRAS Obtener(SinabEntities db, SAB_CAT_TIPOCOMPRAS tipo)
        {
            return db.SAB_CAT_TIPOCOMPRAS.FirstOrDefault(tc => tc.IDTIPOCOMPRA == tipo.IDTIPOCOMPRA);
        }

        public static SAB_CAT_TIPOCOMPRAS Obtener(int idTipo)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idTipo);
            }
        }

        public static SAB_CAT_TIPOCOMPRAS Obtener(SinabEntities db, int idTipo)
        {
            return db.SAB_CAT_TIPOCOMPRAS.FirstOrDefault(tc => tc.IDTIPOCOMPRA == idTipo);
        }


          public static void CargarALista(ref DropDownList lista, bool ordenar = false)
        {
           
            List<SAB_CAT_TIPOCOMPRAS> listado;

            using (var db = new SinabEntities())
            {
                listado = db.SAB_CAT_TIPOCOMPRAS.ToList();
            }

            lista.DataSource = !ordenar ? listado : listado.OrderBy(s => s.DESCRIPCION).ToList();
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDTIPOCOMPRA";
            lista.DataBind();
        }
      
        
    }
}
