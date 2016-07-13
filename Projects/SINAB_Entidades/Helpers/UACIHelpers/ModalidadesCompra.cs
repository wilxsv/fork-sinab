using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class ModalidadesCompra
    {
        public static void CargarALista(ref DropDownList lista, SinabEntities db)
        {
            lista.DataSource = db.SAB_CAT_MODALIDADESCOMPRA.ToList();
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDMODALIDADCOMPRA";
            lista.DataBind();

        }

        public static void CargarALista(ref DropDownList lista)
        {
            List<SAB_CAT_MODALIDADESCOMPRA> l;
            using (var db = new SinabEntities())
            {
                l = db.SAB_CAT_MODALIDADESCOMPRA.ToList();
            }
            lista.DataSource = l;
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDMODALIDADCOMPRA";
            lista.DataBind();

        }
    }
}
