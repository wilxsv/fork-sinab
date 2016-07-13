using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using SINAB_Entidades.Helpers.AlmacenHelpers;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class AlmacenesEntregaContrato
    {
        /// <summary>
        /// Devuelve el cuadro de distribución por proceso de compra
        /// </summary>
        /// <param name="idEstablecimiento">El establecimiento</param>
        /// <param name="idProcesoCompra">El proceso de compra</param>
        /// <returns></returns>
        public static List<BaseEntregaContratos> ObtenerTodos(int idEstablecimiento, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                return( from aec in db.SAB_UACI_ALMACENESENTREGACONTRATOS
                    let pc = aec.SAB_UACI_ENTREGACONTRATO.SAB_UACI_PRODUCTOSCONTRATO

                    join cpc in db.SAB_UACI_CONTRATOSPROCESOCOMPRA on
                        new {aec.IDESTABLECIMIENTO, aec.IDPROVEEDOR, aec.IDCONTRATO} equals
                        new {cpc.IDESTABLECIMIENTO, cpc.IDPROVEEDOR, cpc.IDCONTRATO}
                    join ff in db.SAB_CAT_FUENTEFINANCIAMIENTOS on aec.IDFUENTEFINANCIAMIENTO equals
                        ff.IDFUENTEFINANCIAMIENTO
                    join cp in db.vv_CATALOGOPRODUCTOS on pc.IDPRODUCTO equals cp.IDPRODUCTO

                    where
                        aec.IDESTABLECIMIENTO == idEstablecimiento && cpc.IDPROCESOCOMPRA == idProcesoCompra
                    select new BaseEntregaContratos
                    {
                        CodigoLicitacion = cpc.SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION,
                        DescripcionLicitacion = cpc.SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION,
                        Proveedor = pc.SAB_UACI_CONTRATOS.SAB_CAT_PROVEEDORES.NOMBRE,
                        NumeroContrato = pc.SAB_UACI_CONTRATOS.NUMEROCONTRATO,
                        Renglon = aec.RENGLON,
                        CodigoProducto = cp.CORRPRODUCTO,
                        Nombre = cp.DESCLARGO,
                        UnidadMedida = cp.DESCRIPCION,
                        Cantidad = aec.CANTIDAD,
                        CantidadEntregada = aec.CANTIDADENTREGADA,
                        Almacen = aec.SAB_CAT_ALMACENES.NOMBRE,
                        NombreFuenteFinanciamiento = ff.NOMBRE
                    }).ToList();
            }
        }

        public static List<BaseEntregaContratos> ObtenerTodos(int idEstablecimiento, int idAlmacen, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                return (from aec in db.SAB_UACI_ALMACENESENTREGACONTRATOS
                        let pc = aec.SAB_UACI_ENTREGACONTRATO.SAB_UACI_PRODUCTOSCONTRATO

                        join cpc in db.SAB_UACI_CONTRATOSPROCESOCOMPRA on
                            new { aec.IDESTABLECIMIENTO, aec.IDPROVEEDOR, aec.IDCONTRATO } equals
                            new { cpc.IDESTABLECIMIENTO, cpc.IDPROVEEDOR, cpc.IDCONTRATO }
                        join ff in db.SAB_CAT_FUENTEFINANCIAMIENTOS on aec.IDFUENTEFINANCIAMIENTO equals
                            ff.IDFUENTEFINANCIAMIENTO
                        join cp in db.vv_CATALOGOPRODUCTOS on pc.IDPRODUCTO equals cp.IDPRODUCTO

                        where
                            aec.IDESTABLECIMIENTO == idEstablecimiento && cpc.IDPROCESOCOMPRA == idProcesoCompra  &&
                            aec.IDALMACENENTREGA == idAlmacen
                        select new BaseEntregaContratos
                        {
                            CodigoLicitacion = cpc.SAB_UACI_PROCESOCOMPRAS.CODIGOLICITACION,
                            DescripcionLicitacion = cpc.SAB_UACI_PROCESOCOMPRAS.DESCRIPCIONLICITACION,
                            Proveedor = pc.SAB_UACI_CONTRATOS.SAB_CAT_PROVEEDORES.NOMBRE,
                            NumeroContrato = pc.SAB_UACI_CONTRATOS.NUMEROCONTRATO,
                            Renglon = aec.RENGLON,
                            CodigoProducto = cp.CORRPRODUCTO,
                            Nombre = cp.DESCLARGO,
                            UnidadMedida = cp.DESCRIPCION,
                            Cantidad = aec.CANTIDAD,
                            CantidadEntregada = aec.CANTIDADENTREGADA,
                            Almacen = aec.SAB_CAT_ALMACENES.NOMBRE,
                            NombreFuenteFinanciamiento = ff.NOMBRE
                        }).ToList();
            }
        }

        /// <summary>
        /// Devuelve la lista de renglones por contrato de tipo BaseAlmacenesEntregaContrato
        /// </summary>
        /// <param name="idEstablecimiento"></param>
        /// <param name="idProveedor"></param>
        /// <param name="idContrato"></param>
        /// <param name="idAlmacenEntrega"></param>
        /// <returns></returns>
        public static List<BaseAlmacenesEntregaContrato> ObtenerTodosRenglones(int idEstablecimiento, int idProveedor, long idContrato, int idAlmacenEntrega)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodosRenglones(db, idEstablecimiento, idProveedor, idContrato, idAlmacenEntrega);
            }
        }
        public static List<BaseAlmacenesEntregaContrato> ObtenerTodosRenglones( SinabEntities db, int idEstablecimiento, int idProveedor, long idContrato, int idAlmacenEntrega)
        {
            
                var res =
                    from aec in db.SAB_UACI_ALMACENESENTREGACONTRATOS
                    where aec.IDESTABLECIMIENTO == idEstablecimiento
                          && aec.IDPROVEEDOR == idProveedor
                          && aec.IDCONTRATO == idContrato
                          && (aec.IDALMACENENTREGA == idAlmacenEntrega || idAlmacenEntrega == 0)

                    let pc = aec.SAB_UACI_ENTREGACONTRATO.SAB_UACI_PRODUCTOSCONTRATO
                    join cp in db.vv_CATALOGOPRODUCTOS on pc.IDPRODUCTO equals cp.IDPRODUCTO
                    group aec by new
                    {
                        aec.IDESTABLECIMIENTO,
                        aec.IDPROVEEDOR,
                        aec.IDCONTRATO,
                        aec.RENGLON,
                        cp.DESCLARGO,
                        cp.DESCRIPCION,
                        pc.PRECIOUNITARIO,
                        pc.DESCRIPCIONPROVEEDOR,
                        cp.CORRPRODUCTO
                    }
                        into g
                        let cnt = g.Sum(ob => ob.CANTIDAD)
                        let cnte = g.Sum(ob => ob.CANTIDADENTREGADA)
                        select new BaseAlmacenesEntregaContrato()
                        {
                            IdEstablecimiento = g.Key.IDESTABLECIMIENTO,
                            IdProveedor = g.Key.IDPROVEEDOR,
                            IdContrato = g.Key.IDCONTRATO,
                            Renglon = g.Key.RENGLON,
                            Producto = g.Key.DESCLARGO,
                            UM = g.Key.DESCRIPCION,
                            Cantidad = cnt,
                            PrecioUnitario = g.Key.PRECIOUNITARIO ?? 0,
                            Entregas = g.Max(ob => ob.IDDETALLE),
                            DescripcionProveedor = g.Key.DESCRIPCIONPROVEEDOR,
                            CorrProducto = g.Key.CORRPRODUCTO,
                            CantidadPendiente = cnt - cnte,
                            PorcentajeEntregado = (cnte * 100) / cnt,
                            PorcentajePendiente = 100 - (cnte * 100 / cnt),

                        };

                return res.ToList(); //.OrderBy(obj => obj.Renglon).ToList();
            

        }

        /// <summary>
        /// Devuelve la lista de entregas por renglon de tipo BaseAlmacenesEntregaContrato
        /// </summary>
        /// <param name="idEstablecimiento"></param>
        /// <param name="idProveedor"></param>
        /// <param name="idContrato"></param>
        /// <param name="renglon"></param>
        /// <returns></returns>
        public static List<BaseAlmacenesEntregaContrato> ObtenerTodosEntregas(int idEstablecimiento, int idProveedor, long idContrato, long renglon, int idAlmacenEntrega)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodosEntregas(db, idEstablecimiento, idProveedor, idContrato, renglon, idAlmacenEntrega);
            }
        }
        public static List<BaseAlmacenesEntregaContrato> ObtenerTodosEntregas(SinabEntities db, int idEstablecimiento, int idProveedor, long idContrato, long renglon, int idAlmacenEntrega)
        {
           
            var res = (from aec in db.SAB_UACI_ALMACENESENTREGACONTRATOS
                       where aec.IDESTABLECIMIENTO == idEstablecimiento &&
                      aec.IDPROVEEDOR == idProveedor &&
                      aec.IDCONTRATO == idContrato &&
                      (aec.RENGLON == renglon || renglon == 0) &&
                      (aec.IDALMACENENTREGA == idAlmacenEntrega || idAlmacenEntrega == 0)

                let pc = aec.SAB_UACI_ENTREGACONTRATO.SAB_UACI_PRODUCTOSCONTRATO
                join cp in db.vv_CATALOGOPRODUCTOS on pc.IDPRODUCTO equals cp.IDPRODUCTO
                join al in db.SAB_CAT_ALMACENES on aec.IDALMACENENTREGA equals al.IDALMACEN
                select new BaseAlmacenesEntregaContrato()
                {
                    IdEstablecimiento = aec.IDESTABLECIMIENTO,
                    IdProveedor = aec.IDPROVEEDOR,
                    IdContrato = aec.IDCONTRATO,
                    Renglon = aec.RENGLON,
                    IdAlmacenEntrega = aec.IDALMACENENTREGA,
                    Almacen = al.NOMBRE,
                    Entregas = aec.SAB_UACI_ENTREGACONTRATO.ENTREGA,
                    Cantidad = aec.CANTIDAD,
                    UM = cp.DESCRIPCION,
                    PorcentajeEntregado = aec.SAB_UACI_ENTREGACONTRATO.PORCENTAJEENTREGA,
                    PrecioUnitario = pc.PRECIOUNITARIO ?? 0,
                    PlazoEntrega = aec.SAB_UACI_ENTREGACONTRATO.PLAZOENTREGA,
                    FechaDistribucion = pc.SAB_UACI_CONTRATOS.FECHADISTRIBUCION.Value

                }).ToList();
            return res ;

           
        }

        /// <summary>
        /// Lista el detalle de las entregas por entrega de tipo BaseAlmacenesEntregaContratoDetalle
        /// </summary>
        /// <param name="idEstablecimiento"></param>
        /// <param name="idProveedor"></param>
        /// <param name="idContrato"></param>
        /// <param name="idAlmacen"></param>
        /// <param name="renglon"></param>
        /// <returns>Lista de BaseAlmacenesEntregaContratoDetalle</returns>
        public static List<BaseAlmacenesEntregaContratoDetalle> ObtenerTodosDetalles(int idEstablecimiento, int idProveedor, long idContrato, int idAlmacenEntrega, int renglon)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodosDetalles(db, idEstablecimiento, idProveedor, idContrato, idAlmacenEntrega, renglon);
            }
        }
        public static List<BaseAlmacenesEntregaContratoDetalle> ObtenerTodosDetalles(SinabEntities db, int idEstablecimiento, int idProveedor, long idContrato, int idAlmacenEntrega, int renglon)
        {
           
                var t = from aec in db.SAB_UACI_ALMACENESENTREGACONTRATOS
                        where aec.IDESTABLECIMIENTO == idEstablecimiento &&
                              aec.IDPROVEEDOR == idProveedor &&
                              aec.IDCONTRATO == idContrato &&
                              (aec.IDALMACENENTREGA == idAlmacenEntrega || idAlmacenEntrega == 0)
                        group aec by new
                        {
                            almacen = aec
                        }
                            into g
                            let a = g.Key.almacen
                            select new
                            {
                                a.IDESTABLECIMIENTO,
                                a.IDPROVEEDOR,
                                a.IDCONTRATO,
                                a.IDALMACENENTREGA,
                                a.RENGLON,
                                Cantidad = g.Sum(obj => obj.CANTIDAD)
                            };

                if (!t.Any()) return null;


                var res = from rr in db.SAB_ALM_RECIBOSRECEPCION
                          join mv in db.SAB_ALM_MOVIMIENTOS
                              on new
                              {
                                  rr.IDALMACEN,
                                  rr.ANIO,
                                  rr.IDRECIBO
                              }
                              equals
                              new
                              {
                                  IDALMACEN = (int)mv.IDALMACEN,
                                  ANIO = (Int16)mv.ANIO,
                                  IDRECIBO = (int)mv.IDDOCUMENTO
                              }

                          join dmv in db.SAB_ALM_DETALLEMOVIMIENTOS
                              on new
                              {
                                  mv.IDESTABLECIMIENTO,
                                  mv.IDTIPOTRANSACCION,
                                  mv.IDMOVIMIENTO
                              }
                              equals new
                              {
                                  dmv.IDESTABLECIMIENTO,
                                  dmv.IDTIPOTRANSACCION,
                                  dmv.IDMOVIMIENTO
                              }

                          join aec in t
                              on new
                              {
                                  IDESTABLECIMIENTO = (int)rr.IDESTABLECIMIENTO,
                                  IDPROVEEDOR = (int)rr.IDPROVEEDOR,
                                  IDCONTRATO = rr.IDCONTRATO ?? 0,
                                  rr.IDALMACEN,
                                  RENGLON = dmv.RENGLON ?? 0
                              } equals new
                              {
                                  aec.IDESTABLECIMIENTO,
                                  aec.IDPROVEEDOR,
                                  aec.IDCONTRATO,
                                  IDALMACEN = aec.IDALMACENENTREGA,
                                  aec.RENGLON
                              }

                          join al in db.SAB_CAT_ALMACENES
                              on rr.IDALMACEN equals al.IDALMACEN

                          where rr.IDESTABLECIMIENTO == idEstablecimiento &&
                                rr.IDPROVEEDOR == idProveedor &&
                                rr.IDCONTRATO == idContrato &&
                                (rr.IDALMACEN == idAlmacenEntrega || idAlmacenEntrega == 0) &&
                                mv.IDTIPOTRANSACCION == 8 && //TODO:??
                                mv.IDESTADO == 2 && //TODO:??
                                (dmv.RENGLON == renglon || renglon == 0)

                          select new BaseAlmacenesEntregaContratoDetalle()
                          {
                              IdEstablecimiento = (int)rr.IDESTABLECIMIENTO,
                              IdProveedor = (int)rr.IDPROVEEDOR,
                              IdContrato = (long)rr.IDCONTRATO,
                              IdAlmacenEntrega = rr.IDALMACEN,
                              DetalleMovimiento = dmv.IDDETALLEMOVIMIENTO,
                              Renglon = (long)dmv.RENGLON,
                              Cantidad = dmv.CANTIDAD,
                              FechaMovimiento = mv.FECHAMOVIMIENTO,
                              NumeroActa = rr.NUMEROACTA,
                              Anio = rr.ANIO
                          };


                return res.ToList();
           
        }
        

        public static List<SAB_UACI_ALMACENESENTREGACONTRATOS> Obtener(SAB_UACI_CONTRATOS contrato, long renglon, int idFuenteFinanciamiento = -1)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_UACI_ALMACENESENTREGACONTRATOS.Where(aec =>
                                                         aec.IDCONTRATO == contrato.IDCONTRATO &&
                                                         aec.IDESTABLECIMIENTO == contrato.IDESTABLECIMIENTO &&
                                                         aec.IDPROVEEDOR == contrato.IDPROVEEDOR &&
                                                         aec.RENGLON == renglon &&
                                                         aec.IDALMACENENTREGA == contrato.IdAlmacen &&
                                                         aec.IDFUENTEFINANCIAMIENTO == idFuenteFinanciamiento).ToList();

            }
        }

        public static void Guardar(List<SAB_UACI_ALMACENESENTREGACONTRATOS> entregas )
        {
            using (var db = new SinabEntities())
            {
                entregas.ForEach(en => db.SAB_UACI_ALMACENESENTREGACONTRATOS.AddObject(en));
                db.SaveChanges();
            }
        }

        public static void Guardar(List<SAB_UACI_ALMACENESENTREGACONTRATOS> entregas, SinabEntities db)
        {
           
                entregas.ForEach(en => db.SAB_UACI_ALMACENESENTREGACONTRATOS.AddObject(en));
                db.SaveChanges();
           
        }

        public static void ActualizarAlmacenEntregaContrato(SAB_UACI_ALMACENESENTREGACONTRATOS almacenesentregacontratos)
        {
            using (var db = new SinabEntities())
            {
                var rec = db.SAB_UACI_ALMACENESENTREGACONTRATOS.FirstOrDefault(aec =>
                    aec.IDESTABLECIMIENTO == almacenesentregacontratos.IDESTABLECIMIENTO &&
                    aec.IDPROVEEDOR == almacenesentregacontratos.IDPROVEEDOR &&
                    aec.IDCONTRATO == almacenesentregacontratos.IDCONTRATO &&
                    aec.RENGLON == almacenesentregacontratos.RENGLON &&
                    aec.IDDETALLE == almacenesentregacontratos.IDDETALLE &&
                    aec.IDALMACENENTREGA == almacenesentregacontratos.IDALMACENENTREGA &&
                    aec.IDFUENTEFINANCIAMIENTO == almacenesentregacontratos.IDFUENTEFINANCIAMIENTO
                    );
                if (rec == null) return;

                rec.CANTIDADENTREGADA = almacenesentregacontratos.CANTIDADENTREGADA;
                rec.AUUSUARIOMODIFICACION = almacenesentregacontratos.AUUSUARIOMODIFICACION;
                rec.AUFECHAMODIFICACION = almacenesentregacontratos.AUFECHAMODIFICACION;
                db.SaveChanges();
            }
        }

        public static void Actualizar(List<SAB_UACI_ALMACENESENTREGACONTRATOS> lista)
        {
            using (var db = new SinabEntities())
            {
                foreach (var almacenesentregacontratos in lista)
                {
                    var rec = db.SAB_UACI_ALMACENESENTREGACONTRATOS.FirstOrDefault(aec =>
                        aec.IDESTABLECIMIENTO == almacenesentregacontratos.IDESTABLECIMIENTO &&
                        aec.IDPROVEEDOR == almacenesentregacontratos.IDPROVEEDOR &&
                        aec.IDCONTRATO == almacenesentregacontratos.IDCONTRATO &&
                        aec.RENGLON == almacenesentregacontratos.RENGLON &&
                        aec.IDDETALLE == almacenesentregacontratos.IDDETALLE &&
                        aec.IDALMACENENTREGA == almacenesentregacontratos.IDALMACENENTREGA &&
                        aec.IDFUENTEFINANCIAMIENTO == almacenesentregacontratos.IDFUENTEFINANCIAMIENTO
                        );

                    if (rec == null) continue;
                    rec.CANTIDADENTREGADA = almacenesentregacontratos.CANTIDADENTREGADA;
                    rec.AUUSUARIOMODIFICACION = almacenesentregacontratos.AUUSUARIOMODIFICACION;
                    rec.AUFECHAMODIFICACION = almacenesentregacontratos.AUFECHAMODIFICACION;
                    db.SaveChanges();
                }
            }
        }

        public static void Actualizar(List<SAB_UACI_ALMACENESENTREGACONTRATOS> lista, SinabEntities db)
        {

            foreach (var almacenesentregacontratos in lista)
            {
                var rec = db.SAB_UACI_ALMACENESENTREGACONTRATOS.FirstOrDefault(aec =>
                    aec.IDESTABLECIMIENTO == almacenesentregacontratos.IDESTABLECIMIENTO &&
                    aec.IDPROVEEDOR == almacenesentregacontratos.IDPROVEEDOR &&
                    aec.IDCONTRATO == almacenesentregacontratos.IDCONTRATO &&
                    aec.RENGLON == almacenesentregacontratos.RENGLON &&
                    aec.IDDETALLE == almacenesentregacontratos.IDDETALLE &&
                    aec.IDALMACENENTREGA == almacenesentregacontratos.IDALMACENENTREGA &&
                    aec.IDFUENTEFINANCIAMIENTO == almacenesentregacontratos.IDFUENTEFINANCIAMIENTO
                    );

                if (rec == null) continue;
                rec.CANTIDADENTREGADA = almacenesentregacontratos.CANTIDADENTREGADA;
                rec.AUUSUARIOMODIFICACION = almacenesentregacontratos.AUUSUARIOMODIFICACION;
                rec.AUFECHAMODIFICACION = almacenesentregacontratos.AUFECHAMODIFICACION;
                db.SaveChanges();
            }

        }

        public static List<entregasProcesoCompra_Result> ObtenerEntregasProcesoCompra(int idEstablecimiento, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerEntregasProcesoCompra(db, idEstablecimiento, idProcesoCompra);
            }
        }

        public static List<entregasProcesoCompra_Result> ObtenerEntregasProcesoCompra(SinabEntities db, int idEstablecimiento, int idProcesoCompra)
        {
            return db.entregasProcesoCompra(idEstablecimiento, idProcesoCompra).ToList();
        }

        public static void CargarAListaProveedoresAlmacenesEntregaContrato(ref DropDownList lista, int idAlmacen)
        {
           
            List<GenericObjectList> recs;
            using (var db = new SinabEntities())
            {
                recs = (from aec in db.SAB_UACI_ALMACENESENTREGACONTRATOS
                    join c in db.SAB_UACI_CONTRATOS
                        on new {aec.IDESTABLECIMIENTO, aec.IDPROVEEDOR, aec.IDCONTRATO} equals
                        new {c.IDESTABLECIMIENTO, c.IDPROVEEDOR, c.IDCONTRATO}
                    join p in db.SAB_CAT_PROVEEDORES
                        on aec.IDPROVEEDOR equals p.IDPROVEEDOR
                    where aec.IDALMACENENTREGA == idAlmacen
                        select new GenericObjectList()
                    {
                       Identifier = aec.IDPROVEEDOR,
                       Description = p.NOMBRE
                    }).Distinct().OrderBy(gol => gol.Description).ToList();



            }
            lista.DataSource = recs;
            lista.DataTextField = "Description";
            lista.DataValueField = "Identifier";
            lista.DataBind();
        }


        
    }

}
