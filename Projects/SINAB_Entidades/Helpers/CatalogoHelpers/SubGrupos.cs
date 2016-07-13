using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class SubGrupos
    {
        public static void CargarALista(ref DropDownList lista, int idGrupo)
        {
            List<SAB_CAT_SUBGRUPOS> listado;

            using (var db = new SinabEntities())
            {
                listado = db.SAB_CAT_SUBGRUPOS.Where(g => g.IDGRUPO == idGrupo).OrderBy(s => s.CORRELATIVO).ToList();
            }

            lista.DataSource = listado;
            lista.DataTextField = "DescripcionCompleta";
            lista.DataValueField = "IDSUBGRUPO";
            lista.DataBind();
        }
    }
}
