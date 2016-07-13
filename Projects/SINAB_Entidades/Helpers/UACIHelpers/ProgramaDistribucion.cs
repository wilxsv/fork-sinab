using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SINAB_Entidades.Helpers;

namespace SINAB_Entidades.Clases.UACI
{
    public static class ProgramaDistribucion
    {
        public static void Agregar(SinabEntities db, int idEstablecimiento, int idProcesoCompra, bool unaSolicitud)
        {
            var existe = db.SAB_UACI_PROGRAMADISTRIBUCION.FirstOrDefault(pd =>
                pd.IDESTABLECIMIENTO == idEstablecimiento &&
                pd.IDPROCESOCOMPRA == idProcesoCompra);

            if (existe != null)
            {
                db.SAB_UACI_PROGRAMADISTRIBUCION.DeleteObject(existe);
            }
            //llamar a la funcion
            if (unaSolicitud)
            {
                db.prc_LlenarProgramaDistribucionUna(idProcesoCompra, idEstablecimiento,
                    Membresia.ObtenerUsuario().NombreUsuario);
            }
            else
            {
                db.prc_LlenarProgramaDistribucion(idProcesoCompra, idEstablecimiento,
                    Membresia.ObtenerUsuario().NombreUsuario);
            }
            //var res = (from aes in db.SAB_EST_ALMACENESENTREGASOLICITUD
            //    join spc in db.SAB_EST_SOLICITUDESPROCESOCOMPRAS on new {aes.IDESTABLECIMIENTO, aes.IDSOLICITUD} equals new {spc.IDESTABLECIMIENTO, spc.IDSOLICITUD}
            //    join ae in db.SAB_CAT_ALMACENESESTABLECIMIENTOS on aes.IDESTABLECIMIENTO equals ae.IDESTABLECIMIENTO
            //    where spc.IDPROCESOCOMPRA == idProcesoCompra &&
            //          aes.IDESTABLECIMIENTO == idEstablecimiento
            //    group aes by new
            //                 {
            //                     aes.IDESTABLECIMIENTO,
            //                     spc.IDPROCESOCOMPRA,
            //                     IdEstablecimientoSolicita = ae.IDESTABLECIMIENTO,
            //                     aes.IDSOLICITUD,
            //                     aes.RENGLON,
            //                     aes.IDALMACENENTREGA,
            //                     aes.IDFUENTEFINANCIAMIENTO
            //                 }
            //    into grupo
            //    select new 
            //           {
            //               grupo.Key.IDESTABLECIMIENTO,
            //               grupo.Key.IDPROCESOCOMPRA,
            //               IDESTABLECIMIENTOSOLICITA = grupo.Key.IDESTABLECIMIENTO,
            //               grupo.Key.IDSOLICITUD,
            //               RENGLON = (int) grupo.Key.RENGLON,
            //               IDALMACEN = grupo.Key.IDALMACENENTREGA,
            //               CANTIDADSOLICITADA = grupo.Sum(g => g.CANTIDAD),
            //               grupo.Key.IDFUENTEFINANCIAMIENTO
            //           }).ToList();

            //if (!res.Any()) return;
            //foreach (var obj in res.Select(pd => new SAB_UACI_PROGRAMADISTRIBUCION()
            //{
            //    IDESTABLECIMIENTO = pd.IDESTABLECIMIENTO,
            //    IDPROCESOCOMPRA = pd.IDPROCESOCOMPRA,
            //    IDESTABLECIMIENTOSOLICITA = pd.IDESTABLECIMIENTO,
            //    IDSOLICITUD = pd.IDSOLICITUD,
            //    RENGLON = pd.RENGLON,
            //    IDALMACEN = pd.IDALMACEN,
            //    CANTIDADSOLICITADA = pd.CANTIDADSOLICITADA,
            //    CANTIDADADJUDICADA = 0,
            //    CANTIDADENTREGADA = 0,
            //    AUUSUARIOCREACION = Membresia.ObtenerUsuario().NombreUsuario,
            //    AUFECHACREACION = DateTime.Now,
            //    ESTASINCRONIZADA = 0,
            //    IDFUENTEFINANCIAMIENTO = pd.IDFUENTEFINANCIAMIENTO
            //}))
            //{
            //    db.SAB_UACI_PROGRAMADISTRIBUCION.AddObject(obj);
            //    db.SaveChanges();
            //}

        }

        
    }
}
