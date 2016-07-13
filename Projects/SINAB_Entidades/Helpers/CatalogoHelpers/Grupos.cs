using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class Grupos
    {
        public static void CargarALista(ref DropDownList lista, int idSuministro)
        {
            List<SAB_CAT_GRUPOS> listado;

            using (var db = new SinabEntities())
            {
                listado = db.SAB_CAT_GRUPOS.Where(g => g.IDSUMINISTRO == idSuministro).OrderBy(s => s.CORRELATIVO).ToList();
            }

            lista.DataSource = listado;
            lista.DataTextField = "DescripcionCompleta";
            lista.DataValueField = "IDGRUPO";
            lista.DataBind();
        }
    }
}
