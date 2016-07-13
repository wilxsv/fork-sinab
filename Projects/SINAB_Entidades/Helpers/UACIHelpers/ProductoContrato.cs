using System.Collections.Generic;
using System.Linq;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class ProductosContrato
    {

        public static SAB_UACI_PRODUCTOSCONTRATO Obtener(SAB_UACI_PRODUCTOSCONTRATO prdc)
        {
            using (var db = new SinabEntities())
            {
                return
                    db.SAB_UACI_PRODUCTOSCONTRATO.FirstOrDefault(pc => pc.IDESTABLECIMIENTO == prdc.IDESTABLECIMIENTO &&
                                                                       pc.IDPROVEEDOR == prdc.IDPROVEEDOR &&
                                                                       pc.IDCONTRATO == prdc.IDCONTRATO &&
                                                                       pc.RENGLON == prdc.RENGLON);
            }
        }

        public static List<BaseProductos> Obtener(SAB_UACI_CONTRATOS contrato)
        {
            using (var db = new SinabEntities())
            {
                var rec = Contratos.Obtener(contrato, db);
                return rec.SAB_UACI_PRODUCTOSCONTRATO
                    .Join(db.vv_CATALOGOPRODUCTOS,
                          obj => obj.IDPRODUCTO,
                          inf => inf.IDPRODUCTO,
                          (obj, inf) => new BaseProductos
                                            {
                                                IdEstablecimiento = obj.IDESTABLECIMIENTO,
                                                IdProducto = obj.IDPRODUCTO,
                                                IdProveedor = obj.IDPROVEEDOR,
                                                IdContrato = obj.IDCONTRATO,
                                                PrecioUnitario = obj.PRECIOUNITARIO??0,
                                                CorrProducto = inf.CORRPRODUCTO,
                                                Renglon = obj.RENGLON,
                                                DescLargo = inf.DESCLARGO,
                                                UnidadMedida = inf.UNIDADMEDIDA,
                                                DescripcionProveedor = obj.DESCRIPCIONPROVEEDOR,
                                                EstaHabilitado = obj.ESTAHABILITADO,
                                                FechaDeshabilitacion = obj.FECHADESHABILITACION,
                                                Observacion = obj.OBSERVACION,
                                                Descripcion = inf.DESCRIPCION,
                                                Cantidad = obj.CANTIDAD,
                                                Total = obj.PRECIOUNITARIO*obj.CANTIDAD,
                                            })

                    .OrderBy(objinfo => objinfo.Renglon).ToList();

            }
        }

        public static List<SAB_UACI_PRODUCTOSCONTRATO> ObtenerInmediatos(SAB_UACI_CONTRATOS contrato)
        {
            using (var db = new SinabEntities())
            {
                var cont = Contratos.Obtener(contrato, db);
                return cont.SAB_UACI_PRODUCTOSCONTRATO.ToList();
            }
        }

        public static void AgregarProducto(SAB_UACI_PRODUCTOSCONTRATO producto)
        {
            using (var db = new SinabEntities())
            {
                db.SAB_UACI_PRODUCTOSCONTRATO.AddObject(producto);
                db.SaveChanges();
            }
        }

        public static bool ExisteProducto(SAB_UACI_PRODUCTOSCONTRATO producto)
        {
            var baseContrato = new SAB_UACI_CONTRATOS()
            {
                IDCONTRATO = producto.IDCONTRATO,
                IDESTABLECIMIENTO = producto.IDESTABLECIMIENTO,
                IDPROVEEDOR = producto.IDPROVEEDOR
            };

            using (var db = new SinabEntities())
            {
                var rec = Contratos.Obtener(baseContrato, db);
                return rec.SAB_UACI_PRODUCTOSCONTRATO.Any(pc => pc.RENGLON == producto.RENGLON);
            }
        }

        public static bool ExisteProducto(SAB_UACI_CONTRATOS contrato, long renglon)
        {
            using (var db = new SinabEntities())
            {

                var rec = Contratos.Obtener(contrato, db);
                return rec.SAB_UACI_PRODUCTOSCONTRATO.Any(pc => pc.RENGLON == renglon);
            }
        }

        public static void EliminarProducto(SAB_UACI_CONTRATOS contrato, long renglon)
        {
            using (var db = new SinabEntities())
            {
                var cont = Contratos.Obtener(contrato, db);
                var prod = cont.SAB_UACI_PRODUCTOSCONTRATO.FirstOrDefault(pc => pc.RENGLON == renglon);
                if (prod == null) return;
                //borra primero las entregas
                db.SAB_UACI_ENTREGACONTRATO.Where(ec =>
                                                         ec.IDESTABLECIMIENTO == contrato.IDESTABLECIMIENTO &&
                                                         ec.IDPROVEEDOR == contrato.IDPROVEEDOR &&
                                                         ec.IDCONTRATO == contrato.IDCONTRATO &&
                                                         ec.RENGLON == renglon).ToList().ForEach(db.DeleteObject);
                //borra el registro
                db.SAB_UACI_PRODUCTOSCONTRATO.DeleteObject(prod);

                //registra la operacion
                db.SaveChanges();    
            }
        }

        public static bool ExisteRenglon(SAB_UACI_CONTRATOS contrato, int renglon)
        {
            using (var db = new SinabEntities())
            {
                var rec = Contratos.Obtener(contrato, db);
                return rec.SAB_UACI_PRODUCTOSCONTRATO.Any(pc => pc.RENGLON == renglon);
            }
        }

        public static bool ExisteRenglon(SAB_UACI_PRODUCTOSCONTRATO producto)
        {
            var baseContrato = new SAB_UACI_CONTRATOS()
                       {
                           IDCONTRATO = producto.IDCONTRATO,
                           IDESTABLECIMIENTO = producto.IDESTABLECIMIENTO,
                           IDPROVEEDOR = producto.IDPROVEEDOR
                       };
            using (var db = new SinabEntities())
            {
                var rec = Contratos.Obtener(baseContrato, db);
                return rec.SAB_UACI_PRODUCTOSCONTRATO.Any(pc => pc.RENGLON == producto.RENGLON);
            }
        }

        public static long ObtenerSiguienteRenglon(SAB_UACI_CONTRATOS contrato)
        {
            using (var db = new SinabEntities())
            {
                var rec = Contratos.Obtener(contrato, db);
                var list = rec.SAB_UACI_PRODUCTOSCONTRATO.ToList();
                if (!list.Any()) return 1;
                var reng = list.Max(pc => pc.RENGLON);
                return reng + 1;
            }
        }

        
    }
}
