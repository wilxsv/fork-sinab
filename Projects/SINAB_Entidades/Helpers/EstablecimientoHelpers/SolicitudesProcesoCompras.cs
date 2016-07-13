using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Common.CommandTrees;
using System.Linq;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class SolicitudesProcesoCompras
    {
        /// <summary>
        /// Agrega solicitud a la tabla de SolicitudesProcesoCompras
        /// </summary>
        /// <param name="solicitudPC"> solicitud a agregar</param>
        public static void Agregar(SAB_EST_SOLICITUDESPROCESOCOMPRAS solicitudPC)
        {
            using (var db = new SinabEntities())
            {
                Agregar(db, solicitudPC);
            }
        }

        public static void Agregar(SinabEntities db, SAB_EST_SOLICITUDESPROCESOCOMPRAS solicitudPC)
        {
            db.SAB_EST_SOLICITUDESPROCESOCOMPRAS.AddObject(solicitudPC);
            db.SaveChanges();
        }

        public static List<SAB_EST_SOLICITUDESPROCESOCOMPRAS> ObtenerTodos(SinabEntities db, int idestablecimiento,
            int idProcesoCompra)
        {
            return
                   db.SAB_EST_SOLICITUDESPROCESOCOMPRAS.Include(spc => spc.SAB_EST_SOLICITUDES).Where(
                       s => s.IDPROCESOCOMPRA == idProcesoCompra && s.IDESTABLECIMIENTO == idestablecimiento).ToList();
        }

        public static List<SAB_EST_SOLICITUDESPROCESOCOMPRAS> ObtenerTodos(int idestablecimiento, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodos(db, idestablecimiento, idProcesoCompra);
            }
        }

        public static List<AlmacenesEntregaSolicitudDetalle> ObtenerTodos(int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                var res = from spc in db.SAB_EST_SOLICITUDESPROCESOCOMPRAS
                          join dpc in db.SAB_UACI_DETALLEPROCESOCOMPRA on spc.IDPROCESOCOMPRA equals  dpc.IDPROCESOCOMPRA
                          
                          join ds in db.SAB_EST_DETALLESOLICITUDES on new
                          {
                              spc.SAB_EST_SOLICITUDES.IDSOLICITUD,
                              spc.SAB_EST_SOLICITUDES.IDESTABLECIMIENTO, 
                              IDPRODUCTO = (long?) dpc.IDPRODUCTO
                          } equals new
                          {
                              ds.IDSOLICITUD,
                              ds.IDESTABLECIMIENTO,
                              ds.IDPRODUCTO
                          }

                          join aes in db.SAB_EST_ALMACENESENTREGASOLICITUD on new
                          {
                              ds.IDESTABLECIMIENTO,
                              ds.IDSOLICITUD,
                              ds.IDPRODUCTO
                          } equals new
                          {
                              aes.IDESTABLECIMIENTO,
                              aes.IDSOLICITUD, 
                              IDPRODUCTO = (long?) aes.IDPRODUCTO
                          }
                          join cp in db.vv_CATALOGOPRODUCTOS on aes.IDPRODUCTO equals cp.IDPRODUCTO
                          join a in db.SAB_CAT_ALMACENES on aes.IDALMACENENTREGA equals a.IDALMACEN
                          join est in db.SAB_CAT_ESTABLECIMIENTOS on aes.SAB_EST_ENTREGASOLICITUDES.IDESTABLECIMIENTO equals est.IDESTABLECIMIENTO
                          join f in db.SAB_CAT_FUENTEFINANCIAMIENTOS on aes.IDFUENTEFINANCIAMIENTO equals f.IDFUENTEFINANCIAMIENTO
                    where spc.IDPROCESOCOMPRA == idProcesoCompra
                          select new AlmacenesEntregaSolicitudDetalle()
                    {
                        Renglon = dpc.RENGLON,                        
                        IdEstablecimiento =aes.IDESTABLECIMIENTO,
                        IdSolicitud = aes.IDSOLICITUD,
                        IdProducto = aes.IDPRODUCTO,
                        NecesidadFinal = aes.CANTIDAD,
                        PrecioUnitario = aes.PRECIOUNITARIO,
                        IdFuenteFinanciamiento = aes.IDFUENTEFINANCIAMIENTO,
                        FuenteFinanciamiento = f.NOMBRE,
                        CorrProducto = cp.CORRPRODUCTO,
                        DescLargo = cp.DESCLARGO,
                        Descripcion = cp.DESCRIPCION,
                        CodigoNacionesUnidas = cp.CODIGONACIONESUNIDAS,
                        NumeroEntregas = ds.NUMEROENTREGAS??0,
                        IdEstablecimientoNecesidad = est.IDESTABLECIMIENTO,
                        Nombre = est.NOMBRE,
                        CodigoEstablecimiento = est.CODIGOESTABLECIMIENTO,
                        Almacen = a.NOMBRE,
                        
                    };
                return res.ToList();
            }
        }
    }
}
