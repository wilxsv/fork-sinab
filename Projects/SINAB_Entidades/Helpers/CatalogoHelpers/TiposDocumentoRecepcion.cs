using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class TiposDocumentoRecepcion
    {
        public static void CargarALista(ref DropDownList lista)
        {
            List<SAB_CAT_TIPODOCUMENTORECEPCION> list;
            using (var db = new SinabEntities())
            {
                list = db.SAB_CAT_TIPODOCUMENTORECEPCION.ToList();
            }
            lista.DataSource = list;
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDTIPODOCUMENTORECEPCION";
            lista.DataBind();

        }
    }
}
