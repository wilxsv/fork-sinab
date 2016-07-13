using System.Collections.Generic;
using System.Linq;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class DistribucionProductos
    {
        public static List<ProductoSolicitudVistaProductos> ObtenerTodos(int idSolicitud, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_EST_PRODUCTOSSOLICITUD
                    .Join(db.vv_CATALOGOPRODUCTOS,
                          obj => obj.IDPRODUCTO,
                          inf => inf.IDPRODUCTO,
                          (obj, inf) => new ProductoSolicitudVistaProductos
                          {
                              IdProducto = obj.IDPRODUCTO,
                              Renglon = (long)obj.RENGLON,
                              CorrProducto = inf.CORRPRODUCTO,
                              DescTemp = inf.DESCLARGO,
                              RutaEspecificacion = obj.ESPECIFICACIONTECNICA,
                              UnidadMedida = inf.UNIDADMEDIDA,
                              Entrega = obj.IDENTREGA,
                              Capturado = 0,
                              IdUnidadMedida = inf.IDUNIDADMEDIDA,
                              Cantidad = obj.CANTIDAD ?? 0,
                              PrecioActual = obj.preciounitario??0,
                              IdEstablecimiento = obj.IDESTABLECIMIENTO,
                              IdSolicitud = obj.IDSOLICITUD
                          })
                    .Where(objinfo => objinfo.IdEstablecimiento == idEstablecimiento &&
                                      objinfo.IdSolicitud == idSolicitud)
                    .OrderBy(objinfo => objinfo.Renglon).ToList();

            }
        }

        

        public static List<DistribucionProducto> Obtener(int idDistribucion, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return (db.SAB_EST_DISTRIBUCIONPRODUCTO.
                    Join(db.vv_CATALOGOPRODUCTOS,
                        dp => dp.IDPRODUCTO,
                        vv => vv.IDPRODUCTO,
                        (dp, vv) => new DistribucionProducto()
                                    {
                                        IdDistribucion = dp.IDDISTRIBUCION,
                                        IdEstablecimiento = dp.IDESTABLECIMIENTO,
                                        IdProducto = dp.IDPRODUCTO,
                                        DescLargo = vv.DESCLARGO,
                                        CorrProducto = vv.CORRPRODUCTO,
                                        UnidadMedida = vv.DESCRIPCION,
                                        CantidadAlmacen = dp.SAB_EST_DISTRIBUCIONPRODUCTOLOTE.Any() ?
                                            dp.SAB_EST_DISTRIBUCIONPRODUCTOLOTE.Sum(dpl => dpl.SAB_ALM_LOTES.CANTIDADDISPONIBLE):0,
                                        CantidadReal = dp.SAB_EST_DISTRIBUCIONDETALLE.Any() ? dp.SAB_EST_DISTRIBUCIONDETALLE.Sum(dd => dd.CANTIDADREAL):0
                                    }).Where(g => g.IdDistribucion == idDistribucion && g.IdEstablecimiento == idEstablecimiento)).ToList();

            }
        }

        public static void AgregarVarios(SinabEntities db, SAB_EST_DISTRIBUCION distribucion, IEnumerable<int> idProductos)
        {
            foreach (var p in idProductos.Select(n => new SAB_EST_DISTRIBUCIONPRODUCTO()
            {
                IDDISTRIBUCION = distribucion.IDDISTRIBUCION,
                IDESTABLECIMIENTO = distribucion.IDESTABLECIMIENTO,
                IDPRODUCTO = n,
                AUUSUARIOCREACION = distribucion.AUUSUARIOCREACION,
                AUFECHACREACION = distribucion.AUFECHACREACION
            }))
            {
                db.SAB_EST_DISTRIBUCIONPRODUCTO.AddObject(p);
            }
            db.SaveChanges();
        }
    }
}

 
