using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public class FuentesFinanciamiento
    {
        public IQueryable<SAB_CAT_FUENTEFINANCIAMIENTOS> ObtenerFuentesFinanciamientos()
        {
            try
            {
                using (var db = new SinabEntities())
                {
                    return db.SAB_CAT_FUENTEFINANCIAMIENTOS;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void CargarPorMaestroALista(ref DropDownList lista)
        {
            List<SAB_CAT_GRUPOSFUENTEFINANCIAMIENTO> recs;
            using (var db = new SinabEntities())
            {
                recs =
                    db.SAB_CAT_GRUPOSFUENTEFINANCIAMIENTO.ToList();


                lista.DataSource = recs;
                lista.DataTextField = "DESCRIPCION";
                lista.DataValueField = "IDGRUPO";
                lista.DataBind();
            }
        }

        public static void CargarPorGrupoALista(ref DropDownList lista, int idGrupo = 0)
        {
            List<SAB_CAT_FUENTEFINANCIAMIENTOS> recs;
            using (var db = new SinabEntities())
            {
                recs =
                    db.SAB_CAT_FUENTEFINANCIAMIENTOS.Where(ff => ff.IDGRUPO == idGrupo && ff.HABILITADO == 1).ToList();


                lista.DataSource = recs.OrderBy(ff => ff.NombreOrden);
                lista.DataTextField = "GrupoYFuente";
                lista.DataValueField = "IDFUENTEFINANCIAMIENTO";
                lista.DataBind();
            }
        }

        /// <summary>
        /// Lista de almacenes por orden alfabetico
        /// </summary>
        /// <param name="lista">listado de almacen asociado a lista</param>
        /// <param name="sortDesc">ordenar decendente?</param>
        public static void CargarPorSolicitudALista(ref DropDownList lista, SAB_EST_SOLICITUDES solicitud)
        {
            Dictionary<int, string> recs;
            using (var db = new SinabEntities())
            {
                recs = db.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES
                    .Include("SAB_CAT_FUENTEFINANCIAMIENTOS")
                    .Include("SAB_CAT_FUENTEFINANCIAMIENTOS.SAB_CAT_GRUPOSFUENTEFINANCIAMIENTO")
                    .Where(s => s.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO
                                && s.IDSOLICITUD == solicitud.IDSOLICITUD)
                    .Select(ff => new
                    {
                        ff.IDFUENTEFINANCIAMIENTO,
                        nombre =
                            ff.SAB_CAT_FUENTEFINANCIAMIENTOS.SAB_CAT_GRUPOSFUENTEFINANCIAMIENTO.DESCRIPCION +
                            "/" + ff.SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE
                    }).ToDictionary(rec => rec.IDFUENTEFINANCIAMIENTO, rec => rec.nombre);
                ;
            }
            lista.DataSource = recs.OrderBy(a => a.Value);
            lista.DataTextField = "Value";
            lista.DataValueField = "Key";
            lista.DataBind();

        }
    }
}
