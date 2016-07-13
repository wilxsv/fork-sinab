using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class ResponsablesDistribucion
    {
        public static void ObtenerListado(ref DropDownList lista)
        {
            using(var db = new SinabEntities())
            {
                lista.DataSource = db.SAB_CAT_RESPONSABLEDISTRIBUCION.ToList();
                lista.DataTextField = "NOMBRECORTO";
                lista.DataValueField = "IDRESPONSABLEDISTRIBUCION";
                lista.DataBind();
            }
            
           

        }
    }
}
