using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public class TiposIdentificacion
    {
        public static void CargarALista(SinabEntities db, ref DropDownList lista)
        {
            lista.DataSource = db.SAB_CAT_TIPOIDENTIFICACION;
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDTIPOIDENTIFICACION";
            lista.DataBind();
        }
    }
}
