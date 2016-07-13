using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SINAB_Entidades.Helpers.UACIHelpers;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class DetalleSolicitudes
    {
        public static bool ExisteDetalle(SinabEntities db, SAB_EST_SOLICITUDES solicitud, SAB_EST_DETALLESOLICITUDES detalle)
        {
            var etIsNull = string.IsNullOrEmpty(detalle.ESPECIFICACIONTECNICA);
            return db.SAB_EST_DETALLESOLICITUDES.Any(
                    eds =>
                    eds.IDSOLICITUD == solicitud.IDSOLICITUD &&
                    eds.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO &&
                    eds.IDPRODUCTO == detalle.IDPRODUCTO &&
                    etIsNull ? eds.ESPECIFICACIONTECNICA == null : eds.ESPECIFICACIONTECNICA == detalle.ESPECIFICACIONTECNICA
                //object.Equals(eds.ESPECIFICACIONTECNICA, detalle.ESPECIFICACIONTECNICA)
                );
        }

        public static SAB_EST_DETALLESOLICITUDES Obtener(SinabEntities db, int idEstablecimiento, int idSolicitud, int idProducto, int renglon, bool conEspecificacion, string especificacion)
        {
            var ds = db.SAB_EST_DETALLESOLICITUDES.FirstOrDefault(
                       rds => rds.IDESTABLECIMIENTO == idEstablecimiento &&
                              rds.IDSOLICITUD == idSolicitud &&
                              rds.IDPRODUCTO == idProducto &&
                              rds.RENGLON == renglon &&
                              conEspecificacion ? rds.ESPECIFICACIONTECNICA == null : rds.ESPECIFICACIONTECNICA == especificacion
                // object.Equals(rds.ESPECIFICACIONTECNICA, p.ESPECIFICACIONTECNICA)
                       );

            return ds;
        }

        public static void Borrar( SinabEntities db, SAB_EST_SOLICITUDES solicitud, int renglon, long idProducto, string especificacion)
        {

            //borra las tablas de detalle (ultimas en llenarse)
            var etIsNull = string.IsNullOrEmpty(especificacion);
            var rec = db.SAB_EST_DETALLESOLICITUDES

                .FirstOrDefault(
                    eds =>
                    eds.IDSOLICITUD == solicitud.IDSOLICITUD &&
                    eds.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO &&
                    eds.IDPRODUCTO == idProducto &&
                    eds.RENGLON == renglon && 
                    etIsNull ? eds.ESPECIFICACIONTECNICA == null : eds.ESPECIFICACIONTECNICA == especificacion
                // object.Equals(eds.ESPECIFICACIONTECNICA, especificacion)
                );

            if (rec == null) return;
            //sino borra en cascada
            foreach (var es in rec.SAB_EST_ENTREGASOLICITUDES)
            {
                es.SAB_EST_ALMACENESENTREGASOLICITUD.ToList().ForEach(
                    aes => db.SAB_EST_ALMACENESENTREGASOLICITUD.DeleteObject(aes));
            }
            rec.SAB_EST_ENTREGASOLICITUDES.ToList().ForEach(es => db.SAB_EST_ENTREGASOLICITUDES.DeleteObject(es));

            db.SAB_EST_DETALLESOLICITUDES.DeleteObject(rec);

            db.SaveChanges();
        }

        public static List<ProductosSolicitudCorrelativo> ObtenerTodos(long idSolicitud, int idEstablecimiento, long renglon, int idProducto)
        {
            using (var db = new SinabEntities())
            {
                return (from d in db.SAB_EST_DETALLESOLICITUDES
                    join aes in db.SAB_EST_ALMACENESENTREGASOLICITUD on
                        new {d.IDESTABLECIMIENTO, d.IDSOLICITUD, d.RENGLON, IDPRODUCTO = (long) d.IDPRODUCTO} equals
                        new {aes.IDESTABLECIMIENTO, aes.IDSOLICITUD, aes.RENGLON, aes.IDPRODUCTO}
                        into grp
                    from i in grp.DefaultIfEmpty()
                    group i by new
                    {
                        i.RENGLON,
                        i.CorrelativoRenglon
                    }
                    into agrp
                    select new ProductosSolicitudCorrelativo
                    {
                        Renglon = renglon,
                        IdProducto = idProducto,
                        IdSolicitud = idSolicitud,
                        IdEstablecimiento = idEstablecimiento,
                        PrecioUnitario = agrp.FirstOrDefault().PRECIOUNITARIO,
                        Correlativo = agrp.Key.CorrelativoRenglon,
                        Cantidad = agrp.Sum(obj => obj.CANTIDAD)
                    }).ToList();

            }
        }
    }
}
