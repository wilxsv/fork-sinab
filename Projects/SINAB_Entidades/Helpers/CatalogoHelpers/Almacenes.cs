using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class Almacenes
    {
        public static SAB_CAT_ALMACENES Obtener(SinabEntities db, int idAlmacen)
        {
            return db.SAB_CAT_ALMACENES.FirstOrDefault(a => a.IDALMACEN == idAlmacen);
        }

        /// <summary>
        /// Lista de almacenes por Establecimiento
        /// </summary>
        /// <param name="idEstablecimiento">Identificador de establecimiento</param>
        /// <returns>listado de establecimientos con su almacen asociado</returns>
        public static IQueryable<SAB_CAT_ALMACENES> ObtenerAlmacenesEstablecimientos(int idEstablecimiento)
        {
            var db = new SinabEntities();
            
                return
                    db.SAB_CAT_ALMACENESESTABLECIMIENTOS.Include("SAB_CAT_ALMACENES").Where(
                        ae => ae.IDESTABLECIMIENTO == idEstablecimiento).Select(ae => ae.SAB_CAT_ALMACENES);
            
        }

        /// <summary>
        /// Lista de almacenes por Establecimiento
        /// </summary>
        /// <param name="idEstablecimiento">Identificador de establecimiento</param>
        /// <param name="lista">listado de establecimientos con su almacen asociado a lista</param>
        public static void CargarAlmacenesEstablecimientosALista(int idEstablecimiento, ref DropDownList lista)
        {
            List<SAB_CAT_ALMACENES> recs;
            using (var db = new SinabEntities())
            {
                recs = db.SAB_CAT_ALMACENESESTABLECIMIENTOS.Where(ae => 
                    ae.IDESTABLECIMIENTO == idEstablecimiento &&
                    ae.SAB_CAT_ALMACENES.ESTADOALMACEN == 1).
                Select(ae => 
                    ae.SAB_CAT_ALMACENES).
                OrderBy(ae => 
                    ae.NOMBRE).ToList();
            }

            lista.DataSource = recs;
            lista.DataTextField = "NOMBRE";
            lista.DataValueField = "IDALMACEN";
            lista.DataBind();
        }


        /// <summary>
        /// Lista de almacenes por Establecimiento
        /// </summary>
        /// <param name="idEstablecimiento">Identificador de establecimiento</param>
        /// <param name="lista">listado de establecimientos con su almacen asociado a lista</param>
        /// <param name="esFarmacia">Si el almacen pertenece a farmacia o no (traduce 1:true, 0:false)</param>
        public static void CargarAlmacenesPorEstablecimientosALista(int idEstablecimiento, bool esFarmacia, ref DropDownList lista)
        {
            var enFarmacia = esFarmacia ? 1 : 0;
            List<SAB_CAT_ALMACENES> recs;
            using (var db = new SinabEntities())
            {
                recs = db.SAB_CAT_ALMACENESESTABLECIMIENTOS.Where(ae =>
                    ae.IDESTABLECIMIENTO == idEstablecimiento &&
                    ae.SAB_CAT_ALMACENES.ESTADOALMACEN == 1 &&
                    ae.SAB_CAT_ALMACENES.ESFARMACIA == enFarmacia).
                Select(ae =>
                    ae.SAB_CAT_ALMACENES).
                OrderBy(ae =>
                    ae.NOMBRE).ToList();
            }

            lista.DataSource = recs;
            lista.DataTextField = "NOMBRE";
            lista.DataValueField = "IDALMACEN";
            lista.DataBind();
        }

        public static Dictionary<int, string> ObtenerTodos()
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_CAT_ALMACENES.Where(a => a.ESTADOALMACEN == 1 && a.ESFARMACIA == 0)
                    .Select(ae => new { ae.IDALMACEN, ae.NOMBRE }).ToDictionary(rec => rec.IDALMACEN, rec => rec.NOMBRE);
            }
        }

        /// <summary>
        /// Lista de almacenes por orden alfabetico
        /// </summary>
        /// <param name="lista">listado de almacen asociado a lista</param>
        /// <param name="sortDesc">ordenar decendente?</param>
        public static void CargarALista(ref DropDownList lista, bool sortDesc)
        {
            List<SAB_CAT_ALMACENES> recs;
            using (var db = new SinabEntities())
            {
                recs = db.SAB_CAT_ALMACENES.Where(a => a.ESTADOALMACEN == 1 && a.ESFARMACIA == 0).ToList();
            }
            lista.DataSource = sortDesc ? recs.OrderByDescending(a => a.NOMBRE) : recs.OrderBy(a => a.NOMBRE);
            lista.DataTextField = "NOMBRE";
            lista.DataValueField = "IDALMACEN";
            lista.DataBind();
        }

        public static void CargarALista(SinabEntities db, ref DropDownList lista, bool sortDesc)
        {
            var recs = db.SAB_CAT_ALMACENES.Where(a => !a.NOMBRE.StartsWith("U")).ToList();
           
            lista.DataSource = sortDesc ? recs.OrderByDescending(a => a.NOMBRE) : recs.OrderBy(a => a.NOMBRE);
            lista.DataTextField = "NOMBRE";
            lista.DataValueField = "IDALMACEN";
            lista.DataBind();
        }
    }
}
