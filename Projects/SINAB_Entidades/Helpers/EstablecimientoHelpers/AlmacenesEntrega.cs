using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public class AlmacenesEntrega
    {
        /// <summary>
        /// Obtiene los almacenes de entrega que perteneces a la solicitud
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="idSolicitud">Id de Solicitud</param>
        /// <param name="idEstablecimiento">Establecimiento de Solicitud</param>
        /// <returns>Diccionario: Key=IdAlmacen, Value = Nombre(de Almacen) </returns>
        public static Dictionary<int, string> Obtener(long idSolicitud, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_EST_ALMACENESENTREGA.Where(
                    ae => ae.IDESTABLECIMIENTO == idEstablecimiento && ae.IDSOLICITUD == idSolicitud)
                    .Select(ae => new {ae.IDALMACEN, ae.SAB_CAT_ALMACENES.NOMBRE}).ToDictionary(rec => rec.IDALMACEN,
                                                                                                rec => rec.NOMBRE);
            }
        }

        public static Dictionary<int, string> Obtener(SinabEntities db, long idSolicitud, int idEstablecimiento)
        {
           
                return db.SAB_EST_ALMACENESENTREGA.Where(
                    ae => ae.IDESTABLECIMIENTO == idEstablecimiento && ae.IDSOLICITUD == idSolicitud)
                    .Select(ae => new { ae.IDALMACEN, ae.SAB_CAT_ALMACENES.NOMBRE }).ToDictionary(rec => rec.IDALMACEN,
                                                                                                rec => rec.NOMBRE);
           
        }

        public static Dictionary<int, string> ObtenerTodos(long idSolicitud, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idSolicitud, idEstablecimiento);
            }
        }

        public static void CargarALista(ref DropDownList lista, SAB_EST_SOLICITUDES solicitud)
        {
            using (var db = new SinabEntities())
            {
                var recs = Obtener(db, solicitud.IDSOLICITUD, solicitud.IDESTABLECIMIENTO);
                lista.DataSource = recs.OrderBy(ff => ff.Value);
                lista.DataTextField = "Value";
                lista.DataValueField = "Key";
                lista.DataBind();
            }
        }

        /// <summary>
        /// Agrega un objeto tipo SAB_EST_ALMACENESENTREGA a la colección actual
        /// </summary>
        /// <param name="almacenEntrega">objeto que se agregara a la tabla SAB_EST_ALMACENESENTREGA</param>
        public static void Agregar(SAB_EST_ALMACENESENTREGA almacenEntrega)
        {
            using (var db = new SinabEntities())
            {
                db.SAB_EST_ALMACENESENTREGA.AddObject(almacenEntrega);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Elimina el registro de la tabla ALMACENESENTREGA que cumpla con la condición.
        /// Este método no guarda en la DB, debe usarse "db.savechanges" fuera del método.
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="idSolicitud">Id de Solicitud</param>
        /// <param name="idEstablecimiento">Establecimiento de Solicitud</param>
        /// <param name="idAlmacen">Id del Almacen a borrar</param>
        public static void Eliminar(SinabEntities db, long idSolicitud, int idEstablecimiento, int idAlmacen)
        {
            var rec = db.SAB_EST_ALMACENESENTREGA.FirstOrDefault(a => a.IDSOLICITUD == idSolicitud &&
                                                                      a.IDESTABLECIMIENTO == idEstablecimiento &&
                                                                      a.IDALMACEN == idAlmacen);
            if (rec == null) return;
            db.SAB_EST_ALMACENESENTREGA.DeleteObject(rec);
        }
    }
}
