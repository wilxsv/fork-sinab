using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINAB_Entidades.Helpers.UACIHelpers;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class ProductoSolicitud
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
                              PrecioActual = obj.preciounitario ?? 0,
                              IdEstablecimiento = obj.IDESTABLECIMIENTO,
                              IdSolicitud = obj.IDSOLICITUD,
                              Correlativo = obj.Correlativo
                          })
                    .Where(objinfo => objinfo.IdEstablecimiento == idEstablecimiento &&
                                      objinfo.IdSolicitud == idSolicitud)
                    .OrderBy(objinfo => objinfo.Correlativo).ToList();

            }
        }

        public static ProductosSolicitudCorrelativo Obtener(int idSolicitud, int idEstablecimiento, int renglon, int idProducto)
        {
            using (var db = new SinabEntities())
            {
                var ps = Obtener(db, idEstablecimiento, idSolicitud, renglon, idProducto);
                var inf = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(vv => vv.IDPRODUCTO == ps.IDPRODUCTO);

                return new ProductosSolicitudCorrelativo()
                {
                    IdProducto = ps.IDPRODUCTO,
                    Renglon = ps.RENGLON,
                    CorrProducto = inf != null ?inf.CORRPRODUCTO:"",
                    RutaEspecificacion = ps.ESPECIFICACIONTECNICA,
                    UnidadMedida = inf !=null?inf.UNIDADMEDIDA:"",
                    NumeroEntrega = ps.IDENTREGA ?? 0,
                    Cantidad = ps.CANTIDAD ?? 0,
                    PrecioActual = ps.preciounitario ?? 0,
                    IdEstablecimiento = ps.IDESTABLECIMIENTO,
                    IdSolicitud = ps.IDSOLICITUD,
                    Descripcion = inf!=null?inf.DESCRIPCION:"",
                    DescLargo = inf!=null?inf.DESCLARGO:"",
                    Correlativo = ps.Correlativo,
                    Cifrados = CifradoProductoSolicitud.ObtenerTodos(db, idSolicitud, idEstablecimiento, idProducto, renglon)
                };
            }
        }

        public static ProductosSolicitudCorrelativo ObtenerConCifrados(SinabEntities db, int idSolicitud, int idEstablecimiento, int renglon, int idProducto)
        {
            
                var ps = Obtener(db, idEstablecimiento, idSolicitud, renglon, idProducto);
                var inf = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(vv => vv.IDPRODUCTO == ps.IDPRODUCTO);

            return new ProductosSolicitudCorrelativo()
            {
                IdProducto = ps.IDPRODUCTO,
                Renglon = ps.RENGLON,
                CorrProducto = inf != null ? inf.CORRPRODUCTO : "",
                RutaEspecificacion = ps.ESPECIFICACIONTECNICA,
                UnidadMedida = inf != null ? inf.UNIDADMEDIDA : "",
                NumeroEntrega = ps.IDENTREGA ?? 0,
                Cantidad = ps.CANTIDAD ?? 0,
                PrecioActual = ps.preciounitario ?? 0,
                IdEstablecimiento = ps.IDESTABLECIMIENTO,
                IdSolicitud = ps.IDSOLICITUD,
                Descripcion = inf != null ? inf.DESCRIPCION : "",
                DescLargo = inf != null ? inf.DESCLARGO : "",
                Correlativo = ps.Correlativo,
                Cifrados =
                    CifradoProductoSolicitud.ObtenerTodos(db, idSolicitud, idEstablecimiento, idProducto, renglon)

            };
        }
        public static SAB_EST_PRODUCTOSSOLICITUD Obtener(SinabEntities db, SAB_EST_PRODUCTOSSOLICITUD p, bool especificacion)
        {
            return Obtener(db, p.IDESTABLECIMIENTO, (int) p.IDSOLICITUD,(int) p.RENGLON, (int) p.IDPRODUCTO, p.IDDEPENDENCIA, especificacion,
                p.ESPECIFICACIONTECNICA);
        }

        public static SAB_EST_PRODUCTOSSOLICITUD Obtener(SinabEntities db, int idEstablecimiento, int idSolicitud, int renglon, int idProducto, int idDependencia, bool tieneEspecificacion, string especificacion)
        {
            return db.SAB_EST_PRODUCTOSSOLICITUD
                       .FirstOrDefault(rps => rps.IDESTABLECIMIENTO == idEstablecimiento &&
                                              rps.RENGLON == renglon &&
                                              rps.IDPRODUCTO == idProducto &&
                                              rps.IDSOLICITUD == idSolicitud &&
                                              rps.IDDEPENDENCIA == idDependencia &&
                                              tieneEspecificacion ? rps.ESPECIFICACIONTECNICA == null : rps.ESPECIFICACIONTECNICA == especificacion
                                              );
        }

        public static SAB_EST_PRODUCTOSSOLICITUD Obtener(SinabEntities db, int idEstablecimiento, long idSolicitud, int renglon,  int idProducto)
        {
            return db.SAB_EST_PRODUCTOSSOLICITUD.Include(i => i.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES)
                       .FirstOrDefault(rps => rps.IDESTABLECIMIENTO == idEstablecimiento &&
                                              rps.RENGLON == renglon &&  
                                              rps.IDPRODUCTO == idProducto &&
                                              rps.IDSOLICITUD == idSolicitud
                                              );
        }

        public static List<ProductoCifradoPresupuestario> ObtenerReproteCertificacion(long idSolicitud, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return (from ps in db.SAB_EST_PRODUCTOSSOLICITUD 
                          where ps.IDSOLICITUD == idSolicitud && ps.IDESTABLECIMIENTO == idEstablecimiento
                          join vv in db.vv_CATALOGOPRODUCTOS on ps.IDPRODUCTO equals vv.IDPRODUCTO

                        join cps in db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES on
                              new { IdSolicitud = ps.IDSOLICITUD, IdEstablecimiento = ps.IDESTABLECIMIENTO, Renglon = (long)ps.RENGLON} equals
                              new { cps.IdSolicitud, cps.IdEstablecimiento, cps.Renglon }
                          into gj2
                          
                          from j in gj2.DefaultIfEmpty()
                        select new ProductoCifradoPresupuestario()
                        {
                            Renglon = (ps.Correlativo == 0 || ps.Correlativo == null) ? ps.RENGLON : ps.Correlativo ?? 0,
                            CorrProducto = vv.CORRPRODUCTO,
                            UnidadMedida = vv.UNIDADMEDIDA,
                            Cantidad = j != null ? j.Cantidad : 0,
                            PrecioUnitario = ps.preciounitario ?? 0,
                            Cifrado = (j != null ? j.Anio + "-" + j.CodigoInstitucion + "-" + j.AreaGestion + "-" + j.UnidadPresupuestaria + "-" + j.LineaTrabajo + "-" + j.ClasificadorGastos + "-" + j.FuenteFinanciamiento + "-" + j.ObjetoEspecificoGastos : ""),
                            CifradoCantidad = j != null ? j.Cantidad : 0,
                            CifradoMonto = j != null ? j.Monto : 0,
                            DescLargo = vv.DESCLARGO
                        }).OrderBy(i => i.Renglon).ToList();
            }
        }
    }
}
