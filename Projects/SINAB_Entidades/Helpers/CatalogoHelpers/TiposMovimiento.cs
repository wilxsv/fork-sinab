using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public class TiposMovimiento
    {
        public IQueryable<SAB_CAT_TIPOMOVIMIENTOS> ObtenerPorTipoTransaccion(SinabEntities db, int idTipoTransaccion)
        {
            return db.SAB_CAT_TIPOMOVIMIENTOS.Where(tm => tm.IDTIPOTRANSACCION == idTipoTransaccion);
        }

        public static void CargarPorTipoTransaccionALista(SinabEntities db, int idTipoTransaccion, ref DropDownList lista)
        {
            lista.DataSource = db.SAB_CAT_TIPOMOVIMIENTOS.Where(tm => tm.IDTIPOTRANSACCION == idTipoTransaccion).ToList();
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDTIPOMOVIMIENTO";
            lista.DataBind();
        }
    }
}
