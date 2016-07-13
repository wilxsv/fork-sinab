using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class Establecimientos
    {
        public static List<SAB_CAT_ESTABLECIMIENTOS> Obtener()
        {
            using (var db = new SinabEntities())
            {
                //solo hospitales y regiones
                return db.SAB_CAT_ESTABLECIMIENTOS.Where(es => es.NIVEL == 2 && (es.IDTIPOESTABLECIMIENTO == 3 || es.IDTIPOESTABLECIMIENTO == 10)).ToList();
            }
            
        }
        public static List<SAB_CAT_ESTABLECIMIENTOS> Obtener(int idAlmacen)
        {
           
            var estList = new List<SAB_CAT_ESTABLECIMIENTOS>();
            using (var db = new SinabEntities())
            {
                var rec = Almacenes.Obtener(db, idAlmacen);
                rec.SAB_CAT_ALMACENESESTABLECIMIENTOS.ToList().ForEach(ae => estList.Add(ae.SAB_CAT_ESTABLECIMIENTOS));
                return estList;
            }
        }

        public static List<SAB_CAT_ESTABLECIMIENTOS> Obtener(int idAlmacen, SinabEntities db)
        {
          

            var rec = Almacenes.Obtener(db, idAlmacen);
                var estList = new List<SAB_CAT_ESTABLECIMIENTOS>();
                rec.SAB_CAT_ALMACENESESTABLECIMIENTOS.ToList().ForEach(ae => estList.Add(ae.SAB_CAT_ESTABLECIMIENTOS));
                return estList;
            
        }

        /// <summary>
        /// Lista de establecimientos por lamacen
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="idAlmacen">Identificador del almacen</param>
        /// <param name="lista">Listado de establecimientos asignado a un tipo DropDownList</param>
        public static void CargarPorZonaAlmacenALista(SinabEntities db, int idAlmacen, bool verTodo, ref DropDownList lista)
        {
            var res = db.SAB_CAT_ESTABLECIMIENTOS.
                GroupJoin(db.SAB_CAT_ZONAS, e => e.IDZONA, z => z.IDZONA, (e, z) => new { e, z }).SelectMany(e => e.z.DefaultIfEmpty(), (e, z) => new { e.e, z }).
                GroupJoin(db.SAB_CAT_ALMACENESESTABLECIMIENTOS, ez => ez.e.IDESTABLECIMIENTO, a => a.IDESTABLECIMIENTO, (ez, a) => new { ez, a }).
                SelectMany(eza => eza.a.DefaultIfEmpty(), (eza, o) => new { o.IDALMACEN, eza.ez.e.IDZONA }
                ).Where(g => g.IDALMACEN == idAlmacen || g.IDALMACEN == 512).Select(g => g.IDZONA);

            var recs =
                db.SAB_CAT_ESTABLECIMIENTOS.Where(
                    es => (res.Contains(es.IDZONA) && es.NIVEL == 1 && new[] { 1, 2 }.Contains(es.IDTIPOESTABLECIMIENTO)) || verTodo).
                    Select(es => new
                    {
                        es.IDESTABLECIMIENTO,
                        NOMBRE = es.NOMBRE,//es.CODIGOESTABLECIMIENTO + " - " + 
                        es.NIVEL,
                        es.IDTIPOESTABLECIMIENTO,
                        es.CODIGOESTABLECIMIENTO
                    }).OrderBy(es => es.NIVEL).ThenBy(es => es.IDTIPOESTABLECIMIENTO).ThenBy(es => es.NOMBRE);

            lista.DataSource = recs;
            lista.DataTextField = "NOMBRE";
            lista.DataValueField = "IDESTABLECIMIENTO";
            lista.DataBind();
        }


        /// <summary>
        /// Carga solo los establecimientos que correspondan a Regiones y Hospitales y que no incluyan al establecimiento con id 656??
        /// </summary>
        /// <param name="db">datacotext</param>
        /// <param name="lista">lista que se llenara con el Id y el Nombre de los establecimientos</param>
        public static void CargarHospitalesYRegionesALista(SinabEntities db, ref DropDownList lista)
        {
            var recs = db.SAB_CAT_ESTABLECIMIENTOS.Where(es => (es.CODIGOESTABLECIMIENTO.EndsWith("R") || es.CODIGOESTABLECIMIENTO.EndsWith("h")) &&
                                                                es.IDESTABLECIMIENTO != 656).
                                                   Select(es => new
                                                   {
                                                       NOMBRE = es.CODIGOESTABLECIMIENTO + " - " + es.NOMBRE,
                                                       rnombre = es.NOMBRE,
                                                       es.IDESTABLECIMIENTO
                                                   }).OrderBy(es => es.rnombre);
            if (!recs.Any()) return;
            lista.DataSource = recs;
            lista.DataTextField = "NOMBRE";
            lista.DataValueField = "IDESTABLECIMIENTO";
            lista.DataBind();
        }
        public static void CargarHospitalesYRegionesALista(ref DropDownList lista)
        {
            using (var db = new SinabEntities())
            {
                CargarHospitalesYRegionesALista(db, ref lista);
            }
            
        }
        

        public static void CargarALista(int idAlmacen, ref DropDownList lista)
        {
            var estList = new List<SAB_CAT_ESTABLECIMIENTOS>();
            using (var db = new SinabEntities())
            {
               estList = Obtener(idAlmacen, db);
            }
            lista.DataSource = estList.OrderBy(e => e.NOMBRE);
            lista.DataTextField = "NOMBRE";
            lista.DataValueField = "IDESTABLECIMIENTO";
            lista.DataBind();
        }

        public static void CargarALista(ref DropDownList lista)
        {
            List<SAB_CAT_ESTABLECIMIENTOS> estList = Obtener();
            
            lista.DataSource = estList.OrderBy(e => e.NOMBRE);
            lista.DataTextField = "NOMBRE";
            lista.DataValueField = "IDESTABLECIMIENTO";
            lista.DataBind();
        }
    }
}
