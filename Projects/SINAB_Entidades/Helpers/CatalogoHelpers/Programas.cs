using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class Programas
    {
        public static void CargarALista(SinabEntities db, ref DropDownList lista)
        {
            var recs = db.SAB_CAT_PROGRAMAS.OrderBy(es => es.NOMBRE);
            if (!recs.Any()) return;
            lista.DataSource = recs;
            lista.DataTextField = "NOMBRE";
            lista.DataValueField = "IDPROGRAMA";
            lista.DataBind();
        }
    }
}
