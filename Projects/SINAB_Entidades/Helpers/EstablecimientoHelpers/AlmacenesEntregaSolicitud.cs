using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class AlmacenesEntregaSolicitud
    {
        public static IQueryable<AlmacenesEntregaSolicitudDetalle> ObtenerTodos(SinabEntities db,
            SAB_EST_SOLICITUDES solicitud)
        {
            return from aes in db.SAB_EST_ALMACENESENTREGASOLICITUD 
                   join cp in db.vv_CATALOGOPRODUCTOS on aes.IDPRODUCTO equals cp.IDPRODUCTO
                   where aes.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO && aes.IDSOLICITUD == solicitud.IDSOLICITUD
                   select new AlmacenesEntregaSolicitudDetalle
                       {
                           CorrProducto = cp.CORRPRODUCTO,
                           IdProducto = aes.IDPRODUCTO,
                           IdEstablecimiento = aes.IDESTABLECIMIENTO,
                           IdSolicitud = aes.IDSOLICITUD,
                           Renglon = (int) aes.RENGLON,
                           CorrelativoRenglon = aes.CorrelativoRenglon??0
                       };
        }

        public static List<ProductosSolicitudCorrelativo> ObtenerProductosDistribucion(long idSolicitud, int idEstablecimiento, long renglon, int idProducto)
        {
            using (var db = new SinabEntities())
            {
                // db.ProductosSolicitudDistribucion(idSolicitud, idEstablecimiento, idproducto, renglon).ToList();
                return db.SAB_EST_ALMACENESENTREGASOLICITUD
                     .Where(ads => ads.IDSOLICITUD == idSolicitud &&
                                  ads.IDESTABLECIMIENTO == idEstablecimiento &&
                                  ads.IDPRODUCTO == idProducto &&
                                  ads.RENGLON == renglon)
                    //.Include(es => es.SAB_EST_ENTREGASOLICITUDES)
                    //.Include(es => es.SAB_EST_ENTREGASOLICITUDES.SAB_EST_DETALLESOLICITUDES)
                   
                    .GroupBy(
                        ads => new
                        {
                            ads.IDFUENTEFINANCIAMIENTO,
                            ads.IDALMACENENTREGA,
                            ads.IDESTABLECIMIENTO,
                            ads.IDSOLICITUD,
                            ads.RENGLON,
                            ads.IDPRODUCTO,
                            ads.PRECIOUNITARIO,
                            ads.SAB_EST_ENTREGASOLICITUDES.SAB_EST_DETALLESOLICITUDES.Correlativo
                           // cifrado = ads.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES
                        })
                    .Select(ads => new ProductosSolicitudCorrelativo
                    {
                        IdFuenteFinanciamiento = ads.Key.IDFUENTEFINANCIAMIENTO,
                        IdAlmacen = ads.Key.IDALMACENENTREGA,
                        IdEstablecimiento = ads.Key.IDESTABLECIMIENTO,
                        IdSolicitud = ads.Key.IDSOLICITUD,
                        Renglon = ads.Key.RENGLON,
                        IdProducto = ads.Key.IDPRODUCTO,
                        Cantidad = ads.Sum(obj => obj.CANTIDAD),
                        PrecioUnitario = ads.Key.PRECIOUNITARIO,
                        Correlativo = ads.Key.Correlativo
                      
                    }).ToList();

            }
        }
        
        /// <summary>
        /// Listado que sirve de insumo para el reporte de Cuadro de Distribucion por establecimiento
        /// </summary>
        /// <param name="idProceso">Proceso de Compra</param>
        /// <param name="idEstablecimiento">Establecimiento</param>
        /// <returns>Listado de ConsolidadoAlmacenEntregaSolicitud</returns>
        /*
        public static List<ConsolidadoAlmacenEntregaSolicitud> ObtenerReporte(long idProceso, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                //esconsolidado indica si este proceso de compra se genera a partir de una consolidacion o a partir de una sola solicitud de compra.
                //true : a partir de consolidacion
                //false : a partir de una solicitud
                var esconsolidado =
                    db.SAB_EST_SOLICITUDESPROCESOCOMPRAS.Count(
                        spc => spc.IDESTABLECIMIENTO == idEstablecimiento && spc.IDPROCESOCOMPRA == idProceso) > 1;

                var res = (from d in db.SAB_UACI_DETALLEPROCESOCOMPRA
                    where d.IDESTABLECIMIENTO == idEstablecimiento && d.IDPROCESOCOMPRA == idProceso

                    join spc in db.SAB_EST_SOLICITUDESPROCESOCOMPRAS on new {d.IDESTABLECIMIENTO, d.IDPROCESOCOMPRA}
                        equals new {spc.IDESTABLECIMIENTO, spc.IDPROCESOCOMPRA}
                          join aes in db.SAB_EST_ALMACENESENTREGASOLICITUD on new { d.IDESTABLECIMIENTO, spc.IDSOLICITUD, d.IDPRODUCTO }
                        equals new {aes.IDESTABLECIMIENTO, aes.IDSOLICITUD, aes.IDPRODUCTO}

                    join cp in db.vv_CATALOGOPRODUCTOS on aes.IDPRODUCTO equals cp.IDPRODUCTO
                    join a in db.SAB_CAT_ALMACENES on aes.IDALMACENENTREGA equals a.IDALMACEN
                    join f in db.SAB_CAT_FUENTEFINANCIAMIENTOS on aes.IDFUENTEFINANCIAMIENTO equals f.IDFUENTEFINANCIAMIENTO
                    join ae in db.SAB_CAT_ALMACENESESTABLECIMIENTOS on aes.IDALMACENENTREGA equals ae.IDALMACEN

                    join e in db.SAB_CAT_ESTABLECIMIENTOS on ae.IDESTABLECIMIENTO equals e.IDESTABLECIMIENTO

                    let ds = aes.SAB_EST_ENTREGASOLICITUDES.SAB_EST_DETALLESOLICITUDES

                    
                    select new ConsolidadoAlmacenEntregaSolicitud()
                    {

                        IdEstablecimiento = d.IDESTABLECIMIENTO,
                        IdSolicitud =spc.IDSOLICITUD,
                        IdProducto = d.IDPRODUCTO,
                        IdFuenteFinanciamiento = aes.IDFUENTEFINANCIAMIENTO,
                        PrecioUnitario =aes.PRECIOUNITARIO,
                        Renglon = d.RENGLON,
                        CorrProducto = cp.CORRPRODUCTO,
                        DescLargo = cp.DESCLARGO,
                        UnidadMedida = cp.DESCRIPCION,
                        CodigoNacionesUnidas =cp.CODIGONACIONESUNIDAS,
                        Almacen = a.NOMBRE,
                        IdEstablecimientoNececidad = e.IDESTABLECIMIENTO,
                        Establecimiento = e.NOMBRE,
                        CodigoEstablecimiento = e.CODIGOESTABLECIMIENTO,
                        FuenteFinanciamiento = f.NOMBRE,
                        Cantidad = esconsolidado? aes.CANTIDAD:(ds.CANTIDAD??0),
                        NumeroEntrega = ds.NUMEROENTREGAS ?? 0,
                    }).Distinct().ToList();

                return res.OrderBy(ob => ob.Renglon).ToList();
            }
        }
        */
        public static List<ConsolidadoAlmacenEntregaSolicitud> ObtenerReporteConsolidado(long idProceso, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                //esconsolidado indica si este proceso de compra se genera a partir de una consolidacion o a partir de una sola solicitud de compra.
                //true : a partir de consolidacion
                //false : a partir de una solicitud

               // var suma = 0;
                var res = (from d in db.SAB_UACI_DETALLEPROCESOCOMPRA
                    where d.IDESTABLECIMIENTO == idEstablecimiento && d.IDPROCESOCOMPRA == idProceso

                    join spc in db.SAB_EST_SOLICITUDESPROCESOCOMPRAS on new {d.IDESTABLECIMIENTO, d.IDPROCESOCOMPRA}
                        equals new {spc.IDESTABLECIMIENTO, spc.IDPROCESOCOMPRA}
                    join aes in db.SAB_EST_ALMACENESENTREGASOLICITUD on
                        new {IDESTABLECIMIENTO = spc.IDESTABLECIMIENTOSOLICITUD, spc.IDSOLICITUD, d.IDPRODUCTO}
                        equals new {aes.IDESTABLECIMIENTO, aes.IDSOLICITUD, aes.IDPRODUCTO}

                    join cp in db.vv_CATALOGOPRODUCTOS on aes.IDPRODUCTO equals cp.IDPRODUCTO
                    join a in db.SAB_CAT_ALMACENES on aes.IDALMACENENTREGA equals a.IDALMACEN
                    join f in db.SAB_CAT_FUENTEFINANCIAMIENTOS on aes.IDFUENTEFINANCIAMIENTO equals
                        f.IDFUENTEFINANCIAMIENTO
                    join ae in db.SAB_CAT_ALMACENESESTABLECIMIENTOS on aes.IDALMACENENTREGA equals ae.IDALMACEN

                    join e in db.SAB_CAT_ESTABLECIMIENTOS on ae.IDESTABLECIMIENTO equals e.IDESTABLECIMIENTO

                    let ds = aes.SAB_EST_ENTREGASOLICITUDES.SAB_EST_DETALLESOLICITUDES
                    select new
                    {

                        IdEstablecimiento = d.IDESTABLECIMIENTO,
                        IdSolicitud = spc.IDSOLICITUD,
                        IdProducto = d.IDPRODUCTO,
                        IdFuenteFinanciamiento = aes.IDFUENTEFINANCIAMIENTO,
                        IdEstablecimientoNececidad = e.IDESTABLECIMIENTO,
                        PrecioUnitario = aes.PRECIOUNITARIO,
                        Renglon = d.RENGLON,
                        CorrProducto = cp.CORRPRODUCTO,
                        DescLargo = cp.DESCLARGO,
                        UnidadMedida = cp.DESCRIPCION,
                        CodigoNacionesUnidas = cp.CODIGONACIONESUNIDAS,
                        Almacen = a.NOMBRE,
                        Establecimiento = e.NOMBRE,
                        CodigoEstablecimiento = e.CODIGOESTABLECIMIENTO,
                        FuenteFinanciamiento = f.NOMBRE,
                        Cantidad = aes.CANTIDAD,
                        NumeroEntrega = ds.NUMEROENTREGAS ?? 0,
                    }).OrderBy(r => r.Renglon
                    ).GroupBy(r => new
                    {
                        r.IdEstablecimiento,
                        r.IdSolicitud,
                        r.IdProducto,
                        r.IdFuenteFinanciamiento,
                        r.IdEstablecimientoNececidad,
                    }).Select(g => new
                    {
                        Cantidad = g.Sum(x => x.Cantidad),
                        Keys = g.Key,
                        Vals = g.FirstOrDefault()

                    }).Select(g => new ConsolidadoAlmacenEntregaSolicitud
                    {
                        IdEstablecimiento = g.Keys.IdEstablecimiento,
                        IdSolicitud = g.Keys.IdSolicitud,
                        IdProducto = g.Keys.IdProducto,
                        IdFuenteFinanciamiento = g.Keys.IdFuenteFinanciamiento,
                        IdEstablecimientoNececidad = g.Keys.IdEstablecimientoNececidad,
                        Cantidad = g.Cantidad,

                        PrecioUnitario = g.Vals.PrecioUnitario,
                        Renglon = g.Vals.Renglon,
                        CorrProducto = g.Vals.CorrProducto,
                        DescLargo = g.Vals.DescLargo,
                        UnidadMedida = g.Vals.UnidadMedida,
                        CodigoNacionesUnidas = g.Vals.CodigoNacionesUnidas,
                        Almacen = g.Vals.Almacen,
                        Establecimiento = g.Vals.Establecimiento,
                        CodigoEstablecimiento = g.Vals.CodigoEstablecimiento,
                        FuenteFinanciamiento = g.Vals.FuenteFinanciamiento,
                        NumeroEntrega = g.Vals.NumeroEntrega,
                    }).ToList();
                
                return res.OrderBy(ob => ob.Renglon).ToList();
            }
        }


        

        public static List<ConsolidadoAlmacenEntregaSolicitud> ObtenerReporteNoConsolidado(long idSolicitud, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {

                var res = from aes in db.SAB_EST_ALMACENESENTREGASOLICITUD
                          join cp in db.vv_CATALOGOPRODUCTOS on aes.IDPRODUCTO equals cp.IDPRODUCTO
                          join a in db.SAB_CAT_ALMACENES on aes.IDALMACENENTREGA equals a.IDALMACEN
                          join f in db.SAB_CAT_FUENTEFINANCIAMIENTOS on aes.IDFUENTEFINANCIAMIENTO equals
                              f.IDFUENTEFINANCIAMIENTO
                          join ae in db.SAB_CAT_ALMACENESESTABLECIMIENTOS on aes.IDALMACENENTREGA equals ae.IDALMACEN

                          join e in db.SAB_CAT_ESTABLECIMIENTOS on ae.IDESTABLECIMIENTO equals e.IDESTABLECIMIENTO
                          where aes.IDESTABLECIMIENTO == idEstablecimiento && aes.IDSOLICITUD == idSolicitud
                          let ds = aes.SAB_EST_ENTREGASOLICITUDES.SAB_EST_DETALLESOLICITUDES

                          group aes by new
                          {
                              aes.IDSOLICITUD,
                              aes.IDESTABLECIMIENTO,
                              aes.IDPRODUCTO,
                              aes.IDFUENTEFINANCIAMIENTO,
                              aes.PRECIOUNITARIO,
                              ds.Correlativo,
                              cp.CORRPRODUCTO,
                              cp.DESCLARGO,
                              cp.DESCRIPCION,
                              cp.CODIGONACIONESUNIDAS,
                              Almacen = a.NOMBRE,
                              Establecimiento = e.NOMBRE,
                              IdEstablecimientoNececidad = e.IDESTABLECIMIENTO,
                              e.CODIGOESTABLECIMIENTO,
                              FuenteFinanciamiento = f.NOMBRE,
                              ds.NUMEROENTREGAS
                          }
                              into data
                              select new ConsolidadoAlmacenEntregaSolicitud()
                              {

                                  IdEstablecimiento = data.Key.IDESTABLECIMIENTO,
                                  IdSolicitud = data.Key.IDSOLICITUD,
                                  IdProducto = data.Key.IDPRODUCTO,
                                  IdFuenteFinanciamiento = data.Key.IDFUENTEFINANCIAMIENTO,
                                  PrecioUnitario = data.Key.PRECIOUNITARIO,
                                  Renglon = (data.Key.Correlativo??0),
                                  CorrProducto = data.Key.CORRPRODUCTO,
                                  DescLargo = data.Key.DESCLARGO,
                                  UnidadMedida = data.Key.DESCRIPCION,
                                  CodigoNacionesUnidas = data.Key.CODIGONACIONESUNIDAS,
                                  Almacen = data.Key.Almacen,
                                  IdEstablecimientoNececidad = data.Key.IdEstablecimientoNececidad,
                                  Establecimiento = data.Key.Establecimiento,
                                  CodigoEstablecimiento = data.Key.CODIGOESTABLECIMIENTO,
                                  FuenteFinanciamiento = data.Key.FuenteFinanciamiento,
                                  Cantidad = data.Sum(d => d.CANTIDAD),
                                  NumeroEntrega = data.Key.NUMEROENTREGAS ?? 0,
                              };

                var res2 = res.OrderBy(i => i.Renglon).ToList();
                var res3 = new List<ConsolidadoAlmacenEntregaSolicitud>();
                
                foreach (var r in res2)
                {
                    var entrega = Entregas.ObtenerEntrega(r.IdEstablecimiento, (int) r.IdSolicitud, r.NumeroEntrega);
                    if (entrega != null)
                    {
                        r.DiasEntrega = entrega.DIASENTREGA ?? 0;
                        r.PorcentajeEntrega = entrega.PORCENTAJEENTREGA ?? 0;
                    }
                    res3.Add(r);
                }
                return res3;

            }
        }

        /// <summary>
        /// Método que valida la existencia de valores en la distribución de entregas de los productos en una solicitud
        /// </summary>
        /// <param name="detalle">el detale de la solicitud</param>
        /// <returns>Un valor (bool) que indica si existe o no</returns>
        public static bool ExisteDistribucion(SAB_EST_DETALLESOLICITUDES detalle)
        {
            using (var db = new SinabEntities())
            {
                return ExisteDistribucion(db, detalle);
            }
        }
        public static bool ExisteDistribucion(SinabEntities db, SAB_EST_DETALLESOLICITUDES detalle)
        {
            return db.SAB_EST_ALMACENESENTREGASOLICITUD.Any(aes => aes.IDSOLICITUD == detalle.IDSOLICITUD &&
                                                                       aes.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                                                                       aes.IDPRODUCTO == detalle.IDPRODUCTO &&
                                                                       aes.RENGLON == detalle.RENGLON);
        }
    }
}
