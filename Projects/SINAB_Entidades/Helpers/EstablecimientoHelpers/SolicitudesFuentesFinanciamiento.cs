using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public class SolicitudesFuentesFinanciamiento
    {

        public static SAB_EST_SOLICITUDES Agregar(SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES fuentefinanciamiento)
        {
            try
            {
                using (var db = new SinabEntities())
                {
                    var s = Solicitudes.Obtener(db, fuentefinanciamiento.IDESTABLECIMIENTO, (int)fuentefinanciamiento.IDSOLICITUD);

                    s.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.Add(fuentefinanciamiento);

                    db.SaveChanges();
                    return s;
                }
            }
            catch (UpdateException ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Eliminar(SinabEntities db, long idSolicitud, int idEstablecimiento, int idFuente)
        {
            var rec = db.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.FirstOrDefault(ff => ff.IDSOLICITUD == idSolicitud &&
                                                                              ff.IDESTABLECIMIENTO == idEstablecimiento &&
                                                                              ff.IDFUENTEFINANCIAMIENTO == idFuente);
            if (rec == null) return;
            db.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.DeleteObject(rec);
            
        }

        public static Dictionary<int, string> Obtener(SAB_EST_SOLICITUDES solicitud)
        {
           return solicitud.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.Select(ff => new
                                                                               {
                                                                                   ff.IDFUENTEFINANCIAMIENTO,
                                                                                   nombre = ff.SAB_CAT_FUENTEFINANCIAMIENTOS.SAB_CAT_GRUPOSFUENTEFINANCIAMIENTO.DESCRIPCION +"/" +ff.SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE
                                                                               })
                .ToDictionary(rec => rec.IDFUENTEFINANCIAMIENTO, rec => rec.nombre);
            
        }

        public static Dictionary<int, string> Obtener(SinabEntities db, SAB_EST_SOLICITUDES solicitud)
        {
           
                return db.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES
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
                    })
                    .ToDictionary(rec => rec.IDFUENTEFINANCIAMIENTO, rec => rec.nombre);


           
        }

        public static Dictionary<int, string> ObtenerTodos(SAB_EST_SOLICITUDES solicitud)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, solicitud);
            }
        }

        public static void Actualizar(SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES fuente)
        {
            using (var db = new SinabEntities())
            {
                var ffs = db.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.FirstOrDefault(
                    ff =>
                    ff.IDSOLICITUD == fuente.IDSOLICITUD &&
                    ff.IDESTABLECIMIENTO == fuente.IDESTABLECIMIENTO &&
                    ff.IDFUENTEFINANCIAMIENTO == fuente.IDFUENTEFINANCIAMIENTO);
                if(ffs == null) return;
                ffs.MONTOPARTICIPACION = fuente.MONTOPARTICIPACION;
                ffs.PORCENTAJEPARTICIPACION = fuente.PORCENTAJEPARTICIPACION;
               
                db.SaveChanges();
            }
          
        }
    }
}
