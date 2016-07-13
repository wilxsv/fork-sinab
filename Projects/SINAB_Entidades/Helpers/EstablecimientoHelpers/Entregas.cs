using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SINAB_Utils;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class Entregas
    {

        #region ENTREGAS

        public static long ObtenerTotalEntregas(SAB_EST_SOLICITUDES solicitud)
        {
            try
            {
                using (var db = new SinabEntities())
                {
                    var rec = db.SAB_EST_ENTREGASOLICITUDES.Where(
                        s => s.IDSOLICITUD == solicitud.IDSOLICITUD
                             && s.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO).Max(s => s.IDENTREGA);
                    return rec;
                }
            }
            catch { return 0; }

        }

        public static void ActualizarEntregas(List<SAB_EST_ENTREGAS> entrega, SAB_EST_SOLICITUDES solicitud)
        {
            var identrega = entrega.FirstOrDefault().IDENTREGA;
            using (var db = new SinabEntities())
            {
                var entregaOriginal =
                    db.SAB_EST_ENTREGAS.Where(
                        en =>
                            en.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO &&
                            en.IDSOLICITUD == solicitud.IDSOLICITUD && en.IDENTREGA == identrega);
                if (entregaOriginal.Any())
                {
                    entregaOriginal.ToList().ForEach(db.SAB_EST_ENTREGAS.DeleteObject);
                }
                entrega.ForEach(en => db.SAB_EST_ENTREGAS.AddObject(en));
                db.SaveChanges();

            }
        }

        public static SAB_EST_ENTREGAS ObtenerEntrega(SAB_EST_SOLICITUDES solicitud, int entrega)
        {
            using (var db = new SinabEntities())
            {

                return db.SAB_EST_ENTREGAS.FirstOrDefault(
                    en =>
                        en.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO &&
                        en.IDSOLICITUD == solicitud.IDSOLICITUD &&
                        en.IDENTREGA == entrega);
            }

        }

        public static SAB_EST_ENTREGAS ObtenerEntrega(int idEstablecimiento, int idSolicitud, int entrega)
        {
            using (var db = new SinabEntities())
            {

                return db.SAB_EST_ENTREGAS.FirstOrDefault(
                    en =>
                        en.IDESTABLECIMIENTO == idEstablecimiento &&
                        en.IDSOLICITUD == idSolicitud &&
                        en.IDENTREGA == entrega);
            }

        }

        public static List<SAB_EST_ENTREGAS> ObtenerEntregas(SAB_EST_SOLICITUDES solicitud, int entrega)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_EST_ENTREGAS.Where(
                   en =>
                       en.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO &&
                       en.IDSOLICITUD == solicitud.IDSOLICITUD &&
                       en.IDENTREGA == entrega).ToList();
            }
        }

        public static bool TieneEntrega(SAB_EST_SOLICITUDES solicitud, int entrega)
        {
            using (var db = new SinabEntities())
            {

                return db.SAB_EST_ENTREGAS.Any(
                    en =>
                        en.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO &&
                        en.IDSOLICITUD == solicitud.IDSOLICITUD &&
                        en.IDENTREGA == entrega
                        );
            }
        }

        public static List<SAB_EST_ENTREGAS> GenerarEntregas(SAB_EST_SOLICITUDES solicitud, int entrega)
        {
            var entregas = new List<SAB_EST_ENTREGAS>();
            var count = 0;
            var porcentajes = Utils.DistribuirPorcentajes(entrega);
            using (var db = new SinabEntities())
            {
                short? diasMax = 0;
                try
                {

                    diasMax =
                        db.SAB_EST_ENTREGAS.Where(
                            en =>
                                en.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO &&
                                en.IDSOLICITUD == solicitud.IDSOLICITUD)
                            .OrderByDescending(en => en.DIASENTREGA).Select(en => en.DIASENTREGA).FirstOrDefault();
                }
                catch
                {
                    diasMax = 30;
                }

                var dias = Utils.DistribuirDias((Int32)diasMax, entrega);
                foreach (var p in porcentajes)
                {
                    var nuevaEntrega = new SAB_EST_ENTREGAS
                    {
                        IDSOLICITUD = solicitud.IDSOLICITUD,
                        IDESTABLECIMIENTO =
                            Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO,
                        IDENTREGA = (short)Convert.ToDecimal(entrega),
                        NUMEROENTREGA = (short)Convert.ToDecimal(count + 1),
                        PORCENTAJEENTREGA = (decimal?)p,
                        DIASENTREGA = (short?)Convert.ToDecimal(dias[count]),
                        AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name,
                        AUFECHACREACION = DateTime.Now
                    };
                    entregas.Add(nuevaEntrega);
                    count++;
                }
            }
            return entregas;

        }

        #endregion ENTREGAS
       
    }
}
