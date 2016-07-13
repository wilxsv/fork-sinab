using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public class LugaresEntrega
    {
        /// <summary>
        /// Lista de lugares a entregar en Hospital
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="idAlmacen">Identificador del almacen</param>
        /// <param name="lista">Listado de lugares asignado a un tipo DropDownList</param>
        public static void CargarLugaresEntregaHospitalALista(SinabEntities db, int idAlmacen, ref DropDownList lista)
        {
            lista.DataSource = db.SAB_CAT_LUGARES_ENTREGA_HOSPITALES.
                Select(le => new
                                 {
                                     le.IDALMACEN,
                                     le.ID_LUGAR_ENTREGA_HOSPITAL,
                                     NOMBRE = SqlFunctions.StringConvert((double)le.ID_LUGAR_ENTREGA_HOSPITAL) + " - " + le.NOMBRE_LUGAR_ENTREGA_HOSPITAL
                                 }).
                Where(le => le.IDALMACEN == idAlmacen);
            lista.DataTextField = "NOMBRE";
            lista.DataValueField = "ID_LUGAR_ENTREGA_HOSPITAL";
            lista.DataBind();
        }

       }
}
