using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects.DataClasses;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Web;
using SINAB_Entidades.Clases;
using SINAB_Entidades.Tipos;
using SINAB_Utils;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class Solicitud
    {


        public static Dictionary<int, string> FuentesFinanciamiento { get; private set; }

        public static Dictionary<int, string> AlmacenesEntregas { get; private set; }


        public static void ActualizarDatosGenerales(SAB_EST_SOLICITUDES solicitud)
        {
            using (var db = new SinabEntities())
            {
                ActualizarDatosGenerales(db, solicitud);
            }
        }

        public static void ActualizarDatosGenerales(SinabEntities db, SAB_EST_SOLICITUDES solicitud)
        {

            var res = Solicitudes.Obtener(db, solicitud);
            if (res == null) return;
            res.IDESTADO = solicitud.IDESTADO;
            res.AUUSUARIOCREACION = solicitud.AUUSUARIOCREACION;
            res.AUFECHACREACION = solicitud.AUFECHACREACION;
            res.AUUSUARIOMODIFICACION = solicitud.AUUSUARIOMODIFICACION;
            res.AUFECHAMODIFICACION = solicitud.AUFECHAMODIFICACION;
            res.ESTASINCRONIZADA = solicitud.ESTASINCRONIZADA;
            db.SaveChanges();

        }

        public static void Actualizar(ref SAB_EST_SOLICITUDES solicitud)
        {
            var db = new SinabEntities();
            var Base = Solicitudes.Obtener(db, solicitud);
            if (Base == null) return;
            Base.FECHASOLICITUD = solicitud.FECHASOLICITUD;
            Base.PERIODOUTILIZACION = solicitud.PERIODOUTILIZACION;
            Base.EMPLEADOSOLICITANTE = solicitud.EMPLEADOSOLICITANTE;
            Base.CARGOSOLICITANTE = solicitud.CARGOSOLICITANTE;
            Base.OBSERVACION = solicitud.OBSERVACION;
            Base.IDDEPENDENCIASOLICITANTE = solicitud.IDDEPENDENCIASOLICITANTE;
            Base.COMPRACONJUNTA = 0;
            Base.IDTIPOCOMPRAEJECUTAR = 0;
            db.SaveChanges();
            solicitud = Base;

        }

        public static void ModificarDatosGenerales(ref SAB_EST_SOLICITUDES solicitud)
        {
            var db = new SinabEntities();
            var Base = Solicitudes.Obtener(db, solicitud);
            if (Base == null) return;
            Base.FECHASOLICITUD = solicitud.FECHASOLICITUD;
            // Base.PERIODOUTILIZACION = solicitud.PERIODOUTILIZACION;
            Base.EMPLEADOSOLICITANTE = solicitud.EMPLEADOSOLICITANTE;
            Base.CARGOSOLICITANTE = solicitud.CARGOSOLICITANTE;
            Base.OBSERVACION = solicitud.OBSERVACION;
            Base.IDDEPENDENCIASOLICITANTE = solicitud.IDDEPENDENCIASOLICITANTE;
            Base.COMPRACONJUNTA = 0;
            Base.MONTOAUTORIZADO = solicitud.MONTOAUTORIZADO;
            Base.IDTIPOCOMPRAEJECUTAR = 0;
            Base.IDUNIDADTECNICA = solicitud.IDUNIDADTECNICA;

            Base.FondosCargo = solicitud.FondosCargo;
            Base.FondosNombre = solicitud.FondosNombre;

            Base.EMPLEADOAUTORIZA = solicitud.EMPLEADOAUTORIZA;
            Base.AutorizaCargo = solicitud.AutorizaCargo;

            //   Base.CIFRADOPRESUPUESTARIO = solicitud.CIFRADOPRESUPUESTARIO;

            Base.EMPLEADOAREATECNICA = solicitud.EMPLEADOAREATECNICA;
            Base.AreaTecnicaCargo = solicitud.AreaTecnicaCargo;


            db.SaveChanges();
            solicitud = Base;
        }

        public static int? ObtenerClaseSuministro(SAB_EST_SOLICITUDES solicitud)
        {
            var prods = ObtenerProductos((int)solicitud.IDSOLICITUD, solicitud.IDESTABLECIMIENTO);

            var idsuministro = prods.GroupBy(p => p.IdSuministro).OrderByDescending(gp => gp.Count()).Take(1).Select(g => g.Key).FirstOrDefault();
            return idsuministro;
        }

        public static void Modificar(ref SAB_EST_SOLICITUDES solicitud)
        {
            var db = new SinabEntities();

            var Base = Solicitudes.Obtener(db, solicitud.IDESTABLECIMIENTO, (int)solicitud.IDSOLICITUD);
            Base.ENTREGAS = solicitud.ENTREGAS;
            Base.PLAZOENTREGA = solicitud.PLAZOENTREGA;
            Base.AUUSUARIOMODIFICACION = solicitud.AUUSUARIOMODIFICACION;
            Base.AUFECHAMODIFICACION = solicitud.AUFECHAMODIFICACION;
            Base.MONTOSOLICITADO = solicitud.MONTOSOLICITADO;
            Base.IDCLASESUMINISTRO = solicitud.IDCLASESUMINISTRO;
            Base.EntregaUniforme = solicitud.EntregaUniforme;

            if (solicitud.EntregaUniforme)
            {
                Base.SAB_EST_ENTREGAS.ToList().ForEach(en => db.SAB_EST_ENTREGAS.DeleteObject(en));
                var entregas = solicitud.SAB_EST_ENTREGAS.ToList().Select(en => new SAB_EST_ENTREGAS
                                                                                {
                                                                                    IDENTREGA = en.IDENTREGA,
                                                                                    IDESTABLECIMIENTO =
                                                                                        en.IDESTABLECIMIENTO,
                                                                                    IDSOLICITUD = en.IDSOLICITUD,
                                                                                    NUMEROENTREGA = en.NUMEROENTREGA,
                                                                                    PORCENTAJEENTREGA =
                                                                                        en.PORCENTAJEENTREGA,
                                                                                    DIASENTREGA = en.DIASENTREGA,
                                                                                    AUFECHACREACION = en.AUFECHACREACION,
                                                                                    AUUSUARIOCREACION =
                                                                                        en.AUUSUARIOCREACION,
                                                                                    AUFECHAMODIFICACION =
                                                                                        en.AUFECHAMODIFICACION,
                                                                                    AUUSUARIOMODIFICACION =
                                                                                        en.AUUSUARIOMODIFICACION
                                                                                }).ToList();
                entregas.ForEach(en => db.SAB_EST_ENTREGAS.AddObject(en));
            }

            db.SaveChanges();
            solicitud = Base;
        }

        public static void OrdenarFinalizar(ref SAB_EST_SOLICITUDES solicitud)
        {
            var db = new SinabEntities();

            var Base = Solicitudes.Obtener(db, solicitud.IDESTABLECIMIENTO, (int)solicitud.IDSOLICITUD);
            Base.ENTREGAS = solicitud.ENTREGAS;
            Base.PLAZOENTREGA = solicitud.PLAZOENTREGA;
            Base.AUUSUARIOMODIFICACION = solicitud.AUUSUARIOMODIFICACION;
            Base.AUFECHAMODIFICACION = solicitud.AUFECHAMODIFICACION;
            Base.MONTOSOLICITADO = solicitud.MONTOSOLICITADO;
            Base.IDCLASESUMINISTRO = solicitud.IDCLASESUMINISTRO;
            Base.EntregaUniforme = solicitud.EntregaUniforme;

            OrdernarAlmacenesEntregas(db, Base);

            if (solicitud.EntregaUniforme)
            {
                Base.SAB_EST_ENTREGAS.ToList().ForEach(en => db.SAB_EST_ENTREGAS.DeleteObject(en));
                var entregas = solicitud.SAB_EST_ENTREGAS.ToList().Select(en => new SAB_EST_ENTREGAS
                {
                    IDENTREGA = en.IDENTREGA,
                    IDESTABLECIMIENTO =
                        en.IDESTABLECIMIENTO,
                    IDSOLICITUD = en.IDSOLICITUD,
                    NUMEROENTREGA = en.NUMEROENTREGA,
                    PORCENTAJEENTREGA =
                        en.PORCENTAJEENTREGA,
                    DIASENTREGA = en.DIASENTREGA,
                    AUFECHACREACION = en.AUFECHACREACION,
                    AUUSUARIOCREACION =
                        en.AUUSUARIOCREACION,
                    AUFECHAMODIFICACION =
                        en.AUFECHAMODIFICACION,
                    AUUSUARIOMODIFICACION =
                        en.AUUSUARIOMODIFICACION
                }).ToList();
                entregas.ForEach(en => db.SAB_EST_ENTREGAS.AddObject(en));
            }

            db.SaveChanges();
            solicitud = Base;
        }

        private static void OrdernarAlmacenesEntregas(SinabEntities db, SAB_EST_SOLICITUDES solicitud)
        {
            var Ae = AlmacenesEntregaSolicitud.ObtenerTodos(db, solicitud);
            var lista = Ae.ToList().OrderBy(r => r.CodigoNumerico).ToList();
            var count = 1;
            foreach (var o in lista)
            {
                o.CorrelativoRenglon = count;
                //var aes = db.SAB_EST_ALMACENESENTREGASOLICITUD.Where()
            }
        }



        #region PRODUCTOS

        public static bool AgregarProducto(SAB_EST_PRODUCTOSSOLICITUD productoSolicitud)
        {
            using (var db = new SinabEntities())
            {

                var etIsNull = string.IsNullOrEmpty(productoSolicitud.ESPECIFICACIONTECNICA);
                var lastRenglon = 0;
                var res = db.SAB_EST_PRODUCTOSSOLICITUD.Where(
                        ps =>
                        ps.IDESTABLECIMIENTO == productoSolicitud.IDESTABLECIMIENTO &&
                        ps.IDSOLICITUD == productoSolicitud.IDSOLICITUD &&
                        ps.IDDEPENDENCIA == productoSolicitud.IDDEPENDENCIA);
                if (res.Any()) lastRenglon = res.Max(ps => ps.RENGLON);

                var existe =
                    db.SAB_EST_PRODUCTOSSOLICITUD.Any(ps => ps.IDPRODUCTO == productoSolicitud.IDPRODUCTO &&
                                                                       ps.IDESTABLECIMIENTO ==
                                                                       productoSolicitud.IDESTABLECIMIENTO &&
                                                                       ps.IDSOLICITUD == productoSolicitud.IDSOLICITUD &&
                                                                       etIsNull ? ps.ESPECIFICACIONTECNICA == null : ps.ESPECIFICACIONTECNICA == productoSolicitud.ESPECIFICACIONTECNICA);

                if (existe) return false;

                productoSolicitud.Correlativo = productoSolicitud.RENGLON = lastRenglon + 1;

                //todo: productoSolicitud.IDESPECIFICACION = 0;  valor temporal

                db.SAB_EST_PRODUCTOSSOLICITUD.AddObject(productoSolicitud);
                db.SaveChanges();
                return true;
            }

        }

        public static List<ProductoSolicitudVistaProductos> ObtenerProductos(int idSolicitud, int idEstablecimiento)
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
                                                CorrProducto = inf.CORRPRODUCTO,
                                                Renglon = (long)obj.RENGLON,
                                                DescTemp = inf.DESCLARGO,
                                                RutaEspecificacion = obj.ESPECIFICACIONTECNICA,
                                                UnidadMedida = inf.UNIDADMEDIDA,
                                                Entrega = obj.IDENTREGA,
                                                IdUnidadMedida = inf.IDUNIDADMEDIDA,
                                                Cantidad = (decimal)obj.CANTIDAD,
                                                PrecioActual = obj.preciounitario ?? (inf.PRECIOACTUAL ?? 0),
                                                IdEstablecimiento = obj.IDESTABLECIMIENTO,
                                                IdSolicitud = obj.IDSOLICITUD,
                                                IdSuministro = inf.IDSUMINISTRO,
                                                Correlativo = obj.Correlativo,
                                            })
                    .Where(objinfo => objinfo.IdEstablecimiento == idEstablecimiento &&
                                      objinfo.IdSolicitud == idSolicitud)
                    .OrderBy(objinfo => objinfo.Correlativo).ThenBy(objinfo => objinfo.CorrProducto).ToList();

            }
            /*
             CASE WHEN PS.PRECIOUNITARIO IS NULL 
                       THEN CP.PRECIOACTUAL ELSE PS.PRECIOUNITARIO END AS PRECIOACTUAL
             */
        }







        public static void OrdenarProductos(SinabEntities db, IQueryable<SAB_EST_PRODUCTOSSOLICITUD> productos)
        {
            var correlativo = 1;
            foreach (var p in productos)
            {
                p.RENGLON = correlativo;
                correlativo++;
            }
            db.SaveChanges();
        }

        public static void ActualizarProductos(List<BaseProductoSolicitud> productos)
        {
            using (var db = new SinabEntities())
            {

                var countorder = 1;
                foreach (var bp in productos.OrderBy(i => i.Codigo))
                {
                    var p = bp.Productossolicitud;
                    //actualiza el registro de la tabla PRODUCTOSSOLICITUD
                    var etIsNull = string.IsNullOrEmpty(p.ESPECIFICACIONTECNICA);
                    var ps = ProductoSolicitud.Obtener(db, p, etIsNull);

                    if (ps != null)
                    {

                        ps.preciounitario = p.preciounitario;
                        ps.Correlativo = countorder;
                        p.Correlativo = countorder;
                        countorder++;

                    }

                    //si ya esta procesada la solicitud
                    //actualiza el registro de la tabla DETALLESOLICITUDES


                    var ds = DetalleSolicitudes.Obtener(db, p.IDESTABLECIMIENTO, (int)p.IDSOLICITUD, (int)p.IDPRODUCTO,
                        p.RENGLON, etIsNull, p.ESPECIFICACIONTECNICA);
                    if (ds == null) continue;
                    ds.PRESUPUESTOUNITARIO = p.preciounitario;
                    ds.PRESUPUESTOTOTAL = p.preciounitario * ds.CANTIDAD;
                    ds.AUUSUARIOMODIFICACION = p.AUUSUARIOMODIFICACION;
                    ds.AUFECHAMODIFICACION = p.AUFECHAMODIFICACION;
                    ds.Correlativo = p.Correlativo;


                    //actualiza el registro de la tabla SAB_EST_ENTREGASOLICITUDES
                    var es = ds.SAB_EST_ENTREGASOLICITUDES.FirstOrDefault();
                    if (es == null) continue;
                    es.AUFECHAMODIFICACION = p.AUFECHAMODIFICACION;
                    es.AUFECHAMODIFICACION = p.AUFECHAMODIFICACION;


                    //actualiza el registro de la tabla ALMACENESENTREGASOLICITUD
                    var aes = es.SAB_EST_ALMACENESENTREGASOLICITUD.FirstOrDefault();
                    if (aes == null) continue;
                    aes.PRECIOUNITARIO = p.preciounitario ?? 0;
                    aes.AUFECHAMODIFICACION = p.AUFECHAMODIFICACION;
                    aes.AUFECHAMODIFICACION = p.AUFECHAMODIFICACION;

                }
                //guarda la actualizacion en db
                db.SaveChanges();
            }
        }

        public static void ActualizarProducto(SAB_EST_DETALLESOLICITUDES detalle)
        {
            using (var db = new SinabEntities())
            {
                var productInfo = ProductoSolicitud.Obtener(db, detalle.IDESTABLECIMIENTO, (int)detalle.IDSOLICITUD,
                      (int)detalle.RENGLON, (int)(detalle.IDPRODUCTO ?? 0));
                if (productInfo == null) return;
                productInfo.RENGLON = (int)detalle.RENGLON;
                db.SaveChanges();
            }

        }

        public static void AgregarEspecificacionTecnica(SAB_EST_DETALLESOLICITUDES detalle)
        {
            using (var db = new SinabEntities())
            {
                var productInfo = ProductoSolicitud.Obtener(db, detalle.IDESTABLECIMIENTO, (int)detalle.IDSOLICITUD,
                     (int)detalle.RENGLON, (int)(detalle.IDPRODUCTO ?? 0));
                if (productInfo == null) return;
                productInfo.ESPECIFICACIONTECNICA = detalle.ESPECIFICACIONTECNICA;
                db.SaveChanges();
            }
        }

        public static void
            EliminarProducto(SAB_EST_PRODUCTOSSOLICITUD prod)
        {
            using (var db = new SinabEntities())
            {
                //borra el producto de las solicitudes


                if (prod != null)
                {
                    db.SAB_EST_PRODUCTOSSOLICITUD.DeleteObject(prod);
                    BorrarDetalle(db, prod);
                    db.SaveChanges();
                }


                //actualiza los renglones de los productos y sus detalles
                var prods = db.SAB_EST_PRODUCTOSSOLICITUD.Where(ps => ps.IDSOLICITUD == prod.IDSOLICITUD &&
                                                                      ps.IDESTABLECIMIENTO ==
                                                                      prod.IDESTABLECIMIENTO &&
                                                                      ps.RENGLON > prod.RENGLON).OrderBy(ps => ps.RENGLON).ToList();
                if (prods.Any())
                {
                    foreach (var p in prods)
                    {
                        var nuevoRenglon = (long)(p.RENGLON - 1);
                        var etIsNull = string.IsNullOrEmpty(p.ESPECIFICACIONTECNICA);

                        var det = db.SAB_EST_DETALLESOLICITUDES
                            .FirstOrDefault(
                                eds =>
                                eds.IDSOLICITUD == p.IDSOLICITUD &&
                                eds.IDESTABLECIMIENTO == p.IDESTABLECIMIENTO &&
                                eds.IDPRODUCTO == p.IDPRODUCTO &&
                                eds.RENGLON == p.RENGLON &&
                                etIsNull ? eds.ESPECIFICACIONTECNICA == null : eds.ESPECIFICACIONTECNICA == p.ESPECIFICACIONTECNICA
                            );

                        if (det == null) continue;
                        //si encuentra detalle actualiza
                        var almacenes = det.SAB_EST_ENTREGASOLICITUDES.Select(listado => listado.SAB_EST_ALMACENESENTREGASOLICITUD.ToList()).ToList();

                        var entregas = det.SAB_EST_ENTREGASOLICITUDES.ToList();

                        BorrarDetalle(db, p);
                        db.SaveChanges();

                        p.RENGLON = (int)nuevoRenglon;

                        foreach (var almacen in almacenes)
                        {
                            almacen.ForEach(aes => aes.RENGLON = nuevoRenglon);
                            almacen.ForEach(aes => db.SAB_EST_ALMACENESENTREGASOLICITUD.AddObject(aes));
                        }

                        entregas.ForEach(es => es.RENGLON = nuevoRenglon);
                        entregas.ForEach(es => db.SAB_EST_ENTREGASOLICITUDES.AddObject(es));

                        det.IDPRODUCTO = p.IDPRODUCTO;
                        det.AUUSUARIOMODIFICACION = p.AUUSUARIOMODIFICACION;

                        det.RENGLON = nuevoRenglon;
                        db.SAB_EST_DETALLESOLICITUDES.AddObject(det);
                    }
                }

                db.SaveChanges();
            }
        }

        public static void EliminarProducto(SAB_EST_SOLICITUDES solicitud, int idProducto, string especificacion)
        {
            using (var db = new SinabEntities())
            {
                //borra el producto de las solicitudes

                var etIsNull = string.IsNullOrEmpty(especificacion);
                var prod = db.SAB_EST_PRODUCTOSSOLICITUD.FirstOrDefault(ps => ps.IDSOLICITUD == solicitud.IDSOLICITUD &&
                                                                              ps.IDESTABLECIMIENTO ==
                                                                              solicitud.IDESTABLECIMIENTO &&
                                                                              ps.IDPRODUCTO == idProducto &&
                                                                              etIsNull ? ps.ESPECIFICACIONTECNICA == null : ps.ESPECIFICACIONTECNICA == especificacion
                    //object.Equals(ps.ESPECIFICACIONTECNICA, especificacion)
                                                                              );

                if (prod != null)
                {


                    db.SAB_EST_PRODUCTOSSOLICITUD.DeleteObject(prod);
                    db.ObjectStateManager.ChangeObjectState(prod, EntityState.Deleted);
                    DetalleSolicitudes.Borrar(db, solicitud, prod.RENGLON, prod.IDPRODUCTO, prod.ESPECIFICACIONTECNICA);
                    db.SaveChanges();



                    //actualiza los renglones de los productos y sus detalles
                    /*var prods = db.SAB_EST_PRODUCTOSSOLICITUD.Where(ps =>
                                                                          ps.IDSOLICITUD == solicitud.IDSOLICITUD &&
                                                                          ps.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO &&
                                                                          ps.RENGLON > prod.RENGLON).ToList();
                    if (prods.Any())
                    {
                        foreach (var p in prods)
                        {
                            var nuevoRenglon = (long)(p.RENGLON - 1);

                            // .Include(es => es.SAB_EST_ENTREGASOLICITUDES)
                            // .Include("SAB_EST_ENTREGASOLICITUDES.SAB_EST_ALMACENESENTREGASOLICITUD")

                            var det = db.SAB_EST_DETALLESOLICITUDES
                                .FirstOrDefault(
                                    eds =>
                                    eds.IDSOLICITUD == solicitud.IDSOLICITUD &&
                                    eds.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO &&
                                    eds.IDPRODUCTO == p.IDPRODUCTO &&
                                    eds.RENGLON == p.RENGLON &&
                                    etIsNull ? eds.ESPECIFICACIONTECNICA == null : eds.ESPECIFICACIONTECNICA == especificacion
                                //object.Equals(eds.ESPECIFICACIONTECNICA, especificacion)
                                );

                            if (det == null) continue;
                            //si encuentra detalle actualiza
                            var almacenes = det.SAB_EST_ENTREGASOLICITUDES.Select(listado => listado.SAB_EST_ALMACENESENTREGASOLICITUD.ToList()).ToList();

                            var entregas = det.SAB_EST_ENTREGASOLICITUDES.ToList();

                            DetalleSolicitudes.Borrar(db, solicitud, p.RENGLON, p.IDPRODUCTO, p.ESPECIFICACIONTECNICA);
                            db.SaveChanges();

                            p.RENGLON = (int)nuevoRenglon;

                            foreach (var almacen in almacenes)
                            {
                                almacen.ForEach(aes => aes.RENGLON = nuevoRenglon);
                                almacen.ForEach(aes => db.SAB_EST_ALMACENESENTREGASOLICITUD.AddObject(aes));
                            }

                            entregas.ForEach(es => es.RENGLON = nuevoRenglon);
                            entregas.ForEach(es => db.SAB_EST_ENTREGASOLICITUDES.AddObject(es));

                            det.IDPRODUCTO = p.IDPRODUCTO;
                            det.AUUSUARIOMODIFICACION = p.AUUSUARIOMODIFICACION;

                            det.RENGLON = nuevoRenglon;
                            db.SAB_EST_DETALLESOLICITUDES.AddObject(det);
                        }
                    }*/

                    // db.SaveChanges();

                    //borra el archivo d especificacion
                    if (etIsNull) return;
                    var filePath = HttpContext.Current.Server.MapPath("~" + especificacion);
                    if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                }
                else throw new Exception("No se encontro el producto buscado");
            }
        }

        #endregion PRODUCTOS



        #region DETALLE SOLICITUD



        /// <summary>
        /// Crea la sucesion de objetos padre-hijo de DetalleSolicitud -> EntregaSolicitud -> AlmacenEntregaSolicitud
        /// y los almacena en la base de datos
        /// </summary>
        /// <param name="detalle">el detalle del producto</param>
        /// <param name="enEntrega">el numero de la entrega</param>
        /// <param name="distribucion">el detalle de la entrega</param>
        public static void AgregarDetalleSolicitud(SAB_EST_DETALLESOLICITUDES detalle, int enEntrega, List<BaseProductos> distribucion)
        {
            using (var db = new SinabEntities())
            {

                var etIsNull = string.IsNullOrEmpty(detalle.ESPECIFICACIONTECNICA);
                //obtiene el producto
                var producto = db.SAB_EST_PRODUCTOSSOLICITUD.FirstOrDefault(obj =>
                                    obj.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                                    obj.IDSOLICITUD == detalle.IDSOLICITUD &&
                                    obj.IDPRODUCTO == detalle.IDPRODUCTO &&
                                    etIsNull ? obj.ESPECIFICACIONTECNICA == null : obj.ESPECIFICACIONTECNICA == detalle.ESPECIFICACIONTECNICA);
                var productInfo = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(info => info.IDPRODUCTO == producto.IDPRODUCTO);

                //si no existe el producto sale del metodo
                if (producto == null || productInfo == null) return;
                //actualiza la entrega y la cantidad a entregar en la tabla productosolicitud
                producto.CANTIDAD = distribucion.Sum(en => en.Cantidad);
                producto.IDENTREGA = (short?)enEntrega;
                //obtiene la informacion complementaria del detalle


                detalle.CANTIDAD = producto.CANTIDAD;
                detalle.PRESUPUESTOTOTAL = producto.CANTIDAD * producto.preciounitario;
                detalle.IDUNIDADMEDIDA = productInfo.IDUNIDADMEDIDA;
                detalle.PRESUPUESTOUNITARIO = producto.preciounitario;
                detalle.NUMEROENTREGAS = (byte?)enEntrega;

                //crea nuevo objeto entrega
                var entregaSolicitud = new SAB_EST_ENTREGASOLICITUDES()
                                           {
                                               IDESTABLECIMIENTO = detalle.IDESTABLECIMIENTO,
                                               IDSOLICITUD = detalle.IDSOLICITUD,
                                               RENGLON = detalle.RENGLON,
                                               IDPRODUCTO = detalle.IDPRODUCTO ?? 0,
                                               IDENTREGA = enEntrega,
                                               AUUSUARIOCREACION = detalle.AUUSUARIOCREACION,
                                               AUFECHACREACION = detalle.AUFECHACREACION,
                                               ESTASINCRONIZADA = detalle.ESTASINCRONIZADA
                                           };

                //agrega el detalle a la coleccion
                db.SAB_EST_DETALLESOLICITUDES.AddObject(detalle);

                //agrega la entrega a la coleccion
                db.SAB_EST_ENTREGASOLICITUDES.AddObject(entregaSolicitud);

                foreach (var almacenEntregaSolicitud in distribucion.Select(ent => new SAB_EST_ALMACENESENTREGASOLICITUD()
                                                                                   {
                                                                                       IDESTABLECIMIENTO = detalle.IDESTABLECIMIENTO,
                                                                                       IDSOLICITUD = detalle.IDSOLICITUD,
                                                                                       IDENTREGA = enEntrega,
                                                                                       NUMEROENTREGA = enEntrega,
                                                                                       RENGLON = detalle.RENGLON,
                                                                                       IDPRODUCTO = detalle.IDPRODUCTO ?? 0,
                                                                                       IDALMACENENTREGA = (int)ent.IdAlmacen,
                                                                                       IDFUENTEFINANCIAMIENTO = ent.IdFuenteFinanciamiento,
                                                                                       CANTIDAD = ent.Cantidad,
                                                                                       IDUNIDADMEDIDA = (int)detalle.IDUNIDADMEDIDA,
                                                                                       PRECIOUNITARIO = detalle.PRESUPUESTOUNITARIO ?? 0,
                                                                                       AUUSUARIOCREACION = detalle.AUUSUARIOCREACION,
                                                                                       AUFECHACREACION = detalle.AUFECHACREACION,
                                                                                       ESTASINCRONIZADO = detalle.ESTASINCRONIZADA,
                                                                                       ESPECIFICACIONTECNICA = detalle.ESPECIFICACIONTECNICA
                                                                                   }))
                {
                    //agrega el almacenentrega a la coleccion
                    db.SAB_EST_ALMACENESENTREGASOLICITUD.AddObject(almacenEntregaSolicitud);
                }

                //guarda los datos en la db
                db.SaveChanges();
            }
        }
        public static void AgregarDetalleSolicitud(SinabEntities db, SAB_EST_DETALLESOLICITUDES detalle, int enEntrega, List<BaseProductos> entregas)
        {
            //obtiene el producto
            var etIsNull = string.IsNullOrEmpty(detalle.ESPECIFICACIONTECNICA);
            var producto = db.SAB_EST_PRODUCTOSSOLICITUD.FirstOrDefault(obj =>
                                obj.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                                obj.IDSOLICITUD == detalle.IDSOLICITUD &&
                                obj.IDPRODUCTO == detalle.IDPRODUCTO &&
                                 etIsNull ? obj.ESPECIFICACIONTECNICA == null : obj.ESPECIFICACIONTECNICA == detalle.ESPECIFICACIONTECNICA);
            var productInfo = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(info => info.IDPRODUCTO == producto.IDPRODUCTO);

            //si no existe el producto sale del metodo
            if (producto == null || productInfo == null) return;
            //actualiza la entrega y la cantidad a entregar en la tabla productosolicitud
            producto.CANTIDAD = entregas.Sum(en => en.Cantidad);
            producto.IDENTREGA = (short?)enEntrega;
            //obtiene la informacion complementaria del detalle

            //obtiene la entrega
            //var entrega = solicitud.SAB_EST_ENTREGAS.FirstOrDefault(en => en.IDENTREGA == productInfo.Entrega);

            detalle.IDUNIDADMEDIDA = productInfo.IDUNIDADMEDIDA;
            detalle.PRESUPUESTOUNITARIO = producto.preciounitario;
            detalle.NUMEROENTREGAS = (byte?)enEntrega;

            //crea nuevo objeto entrega
            var entregaSolicitud = new SAB_EST_ENTREGASOLICITUDES()
            {
                IDESTABLECIMIENTO = detalle.IDESTABLECIMIENTO,
                IDSOLICITUD = detalle.IDSOLICITUD,
                RENGLON = detalle.RENGLON,
                IDPRODUCTO = detalle.IDPRODUCTO ?? 0,
                IDENTREGA = enEntrega,
                AUUSUARIOCREACION = detalle.AUUSUARIOCREACION,
                AUFECHACREACION = detalle.AUFECHACREACION,
                ESTASINCRONIZADA = detalle.ESTASINCRONIZADA
            };

            //agrega el detalle a la coleccion
            db.SAB_EST_DETALLESOLICITUDES.AddObject(detalle);

            //agrega la entrega a la coleccion
            db.SAB_EST_ENTREGASOLICITUDES.AddObject(entregaSolicitud);

            foreach (var almacenEntregaSolicitud in entregas.Select(ent => new SAB_EST_ALMACENESENTREGASOLICITUD()
            {
                IDESTABLECIMIENTO = detalle.IDESTABLECIMIENTO,
                IDSOLICITUD = detalle.IDSOLICITUD,
                IDENTREGA = enEntrega,
                NUMEROENTREGA = enEntrega,
                RENGLON = detalle.RENGLON,
                IDPRODUCTO = detalle.IDPRODUCTO ?? 0,
                IDALMACENENTREGA = ent.IdAlmacen,
                IDFUENTEFINANCIAMIENTO = ent.IdFuenteFinanciamiento,
                CANTIDAD = ent.Cantidad,
                IDUNIDADMEDIDA = (int)detalle.IDUNIDADMEDIDA,
                PRECIOUNITARIO = detalle.PRESUPUESTOUNITARIO ?? 0,
                AUUSUARIOCREACION = detalle.AUUSUARIOCREACION,
                AUFECHACREACION = detalle.AUFECHACREACION,
                ESTASINCRONIZADO = detalle.ESTASINCRONIZADA,
                ESPECIFICACIONTECNICA = detalle.ESPECIFICACIONTECNICA
            }))
            {
                //agrega el almacenentrega a la coleccion
                db.SAB_EST_ALMACENESENTREGASOLICITUD.AddObject(almacenEntregaSolicitud);
            }

            //guarda los datos en la db

        }

        public static void AgregarDetalleSolicitud(SinabEntities db, SAB_EST_SOLICITUDES solicitud,
            SAB_EST_DETALLESOLICITUDES detalle, List<SAB_EST_ENTREGAS> infoEntregas,
            List<ProductosSolicitudCorrelativo> distribucion)
        {

            var enEntrega = infoEntregas.Count;
            var etIsNull = string.IsNullOrEmpty(detalle.ESPECIFICACIONTECNICA);
            //obtiene el producto
            var producto = db.SAB_EST_PRODUCTOSSOLICITUD.FirstOrDefault(obj =>
                obj.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                obj.IDSOLICITUD == detalle.IDSOLICITUD &&
                obj.IDPRODUCTO == detalle.IDPRODUCTO &&
                obj.RENGLON == detalle.RENGLON &&
                etIsNull
                    ? obj.ESPECIFICACIONTECNICA == null
                    : obj.ESPECIFICACIONTECNICA == detalle.ESPECIFICACIONTECNICA
                // object.Equals(obj.ESPECIFICACIONTECNICA, detalle.ESPECIFICACIONTECNICA)
                );
            var productInfo = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(info => info.IDPRODUCTO == producto.IDPRODUCTO);



            if (producto == null || productInfo == null) return;


            //actualiza la entrega y la cantidad a entregar en la tabla productosolicitud
            producto.CANTIDAD = distribucion.Sum(en => en.Cantidad);
            producto.IDENTREGA = (short?)enEntrega;

            //obtiene la informacion complementaria del detalle
            detalle.CANTIDAD = producto.CANTIDAD;
            detalle.PRESUPUESTOTOTAL = producto.CANTIDAD * producto.preciounitario;
            detalle.IDUNIDADMEDIDA = productInfo.IDUNIDADMEDIDA;
            detalle.PRESUPUESTOUNITARIO = producto.preciounitario;
            detalle.NUMEROENTREGAS = (byte?)enEntrega;
            //agrega el detalle a la coleccion
            db.SAB_EST_DETALLESOLICITUDES.AddObject(detalle);

            db.SaveChanges();

            var pd =
                distribucion.FirstOrDefault(
                    ci =>
                        ci.IdEstablecimiento == producto.IDESTABLECIMIENTO && ci.IdSolicitud == producto.IDSOLICITUD &&
                        ci.IdProducto == producto.IDPRODUCTO);


            if (pd != null)
            {
                producto.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.Clear();
                db.SaveChanges();
                // pd.Cifrados.ToList().ForEach(c => producto.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.Add(c));

            }
            //crea nuevo objeto entrega
            var entregaSolicitud = new SAB_EST_ENTREGASOLICITUDES()
            {
                IDESTABLECIMIENTO = detalle.IDESTABLECIMIENTO,
                IDSOLICITUD = detalle.IDSOLICITUD,
                RENGLON = detalle.RENGLON,
                IDPRODUCTO = detalle.IDPRODUCTO ?? 0,
                IDENTREGA = enEntrega,
                AUUSUARIOCREACION = detalle.AUUSUARIOCREACION,
                AUFECHACREACION = detalle.AUFECHACREACION,
                ESTASINCRONIZADA = detalle.ESTASINCRONIZADA
            };

            //agrega la entrega a la coleccion
            db.SAB_EST_ENTREGASOLICITUDES.AddObject(entregaSolicitud);


            var lAE = distribucion.SelectMany(d => infoEntregas.Select(en => new SAB_EST_ALMACENESENTREGASOLICITUD()
            {
                IDESTABLECIMIENTO = detalle.IDESTABLECIMIENTO,
                IDSOLICITUD = detalle.IDSOLICITUD,
                IDENTREGA = en.IDENTREGA,
                NUMEROENTREGA = en.NUMEROENTREGA,
                RENGLON = detalle.RENGLON,
                IDPRODUCTO = detalle.IDPRODUCTO ?? 0,
                IDALMACENENTREGA = d.IdAlmacen,
                IDFUENTEFINANCIAMIENTO = d.IdFuenteFinanciamiento,
                CANTIDAD = Utils.DistribuirCantidad(d.Cantidad, en.PORCENTAJEENTREGA ?? 0),
                IDUNIDADMEDIDA = (int)detalle.IDUNIDADMEDIDA,
                PRECIOUNITARIO = detalle.PRESUPUESTOUNITARIO ?? 0,
                AUUSUARIOCREACION = detalle.AUUSUARIOCREACION,
                AUFECHACREACION = detalle.AUFECHACREACION,
                ESTASINCRONIZADO = detalle.ESTASINCRONIZADA,
                ESPECIFICACIONTECNICA = detalle.ESPECIFICACIONTECNICA
            })).ToList();


            if (detalle.NUMEROENTREGAS == 1 && lAE.Count() == 1)
            {
                var rec = lAE.FirstOrDefault();
                lAE.Remove(rec);
                if (rec != null) rec.CANTIDAD = (decimal)detalle.CANTIDAD;
                lAE.Add(rec);
            }
            else
            {
                //prorratea
                var suma = lAE.Sum(ae => ae.CANTIDAD);
                if (suma > detalle.CANTIDAD)
                {
                    var dif = suma - detalle.CANTIDAD;
                    var max = lAE.OrderByDescending(ae => ae.CANTIDAD).Take(1).FirstOrDefault();
                    if (max != null && max.CANTIDAD > dif)
                    {
                        lAE.Remove(max);
                        max.CANTIDAD = (decimal)dif;
                        lAE.Add(max);
                    }
                    else
                    {
                        throw new Exception(
                            "Esta distribución no puede procesarse, por favor redistribuya porcentajes o cantidades.");
                    }
                }
            }

            lAE.ForEach(ae => db.SAB_EST_ALMACENESENTREGASOLICITUD.AddObject(ae));

            db.SaveChanges();

        }
        public static void AgregarDetalleSolicitud(SAB_EST_SOLICITUDES solicitud, SAB_EST_DETALLESOLICITUDES detalle, List<SAB_EST_ENTREGAS> infoEntregas, List<ProductosSolicitudCorrelativo> distribucion)
        {
            using (var db = new SinabEntities())
            {
                AgregarDetalleSolicitud(db, solicitud, detalle, infoEntregas, distribucion);
            }
        }

        /// <summary>
        /// Borra por completo el detalle de la solicitud de un producto
        /// </summary>
        /// <param name="solicitud">solicitud de referencia</param>
        /// <param name="idProducto">producto del cual se borrara la informacion</param>
        /// <param name="idEspecificacion">especificacion del producto</param>
        //public static void EliminarDetalleSolicitud(SAB_EST_SOLICITUDES solicitud, int idProducto, string Especificacion)
        //{
        //    var etIsNull = string.IsNullOrEmpty(Especificacion);
        //    using (var db = new SinabEntities())
        //    {
        //        var prod = db.SAB_EST_PRODUCTOSSOLICITUD.FirstOrDefault(ps => ps.IDSOLICITUD == solicitud.IDSOLICITUD &&
        //                                                                      ps.IDESTABLECIMIENTO ==
        //                                                                      solicitud.IDESTABLECIMIENTO &&
        //                                                                      ps.IDPRODUCTO == idProducto &&
        //                                                                      etIsNull ? ps.ESPECIFICACIONTECNICA == null : ps.ESPECIFICACIONTECNICA == Especificacion);

        //        if (prod == null) return;
        //        DetalleSolicitudes.Borrar(db, solicitud, prod.IDPRODUCTO, prod.ESPECIFICACIONTECNICA);
        //        prod.CANTIDAD = 0;
        //        prod.IDENTREGA = null;
        //        db.SaveChanges();
        //    }
        //}

        #endregion DETALLE SOLICITUD

        #region ALMACENES ENTREGA
        public static Dictionary<int, string> ObtenerAlmacenesEntrega(SAB_EST_SOLICITUDES solicitud)
        {
            using (var db = new SinabEntities())
            {
                var Base = Solicitudes.Obtener(db, solicitud);
                return
                    Base.SAB_EST_ALMACENESENTREGA.Select(ae => new { ae.IDALMACEN, ae.SAB_CAT_ALMACENES.NOMBRE }).
                        ToDictionary(rec => rec.IDALMACEN,
                                     rec => rec.NOMBRE);
            }

        }

        public static void EliminarAlmacenEntrega(int idAlmacen, SAB_EST_SOLICITUDES solicitud)
        {
            using (var db = new SinabEntities())
            {
                var Base = Solicitudes.Obtener(db, solicitud);
                var almacen = Base.SAB_EST_ALMACENESENTREGA.FirstOrDefault(a => a.IDALMACEN == idAlmacen);
                if (almacen != null)
                {
                    db.SAB_EST_ALMACENESENTREGA.DeleteObject(almacen);
                    db.SaveChanges();
                }

                var recs = db.SAB_EST_ALMACENESENTREGASOLICITUD.Where(p =>
                                                                      p.IDALMACENENTREGA == idAlmacen &&
                                                                      p.IDSOLICITUD == Base.IDSOLICITUD &&
                                                                      p.IDESTABLECIMIENTO == Base.IDESTABLECIMIENTO
                    ).ToList();

                if (!recs.Any()) return;
                BorrarDetalle(db, recs);
                db.SaveChanges();

            }
        }
        #endregion ALMACENES ENTREGA

        #region ALMACEN ENTREGA SOLICITUD
        public static void EliminarAlmacenEntregaSolicitud(SAB_EST_DETALLESOLICITUDES detalle, int lugar, int fuente)
        {
            var etIsNull = string.IsNullOrEmpty(detalle.ESPECIFICACIONTECNICA);
            using (var db = new SinabEntities())
            {
                var rec = db.SAB_EST_ALMACENESENTREGASOLICITUD.FirstOrDefault(aes =>
                                                                                aes.IDSOLICITUD == detalle.IDSOLICITUD &&
                                                                                aes.IDESTABLECIMIENTO ==
                                                                                detalle.IDESTABLECIMIENTO &&
                                                                                aes.IDPRODUCTO == detalle.IDPRODUCTO &&
                                                                                aes.IDALMACENENTREGA == lugar &&
                                                                                aes.IDFUENTEFINANCIAMIENTO == fuente);

                var producto = db.SAB_EST_PRODUCTOSSOLICITUD.FirstOrDefault(obj =>
                                    obj.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                                    obj.IDSOLICITUD == detalle.IDSOLICITUD &&
                                    obj.IDPRODUCTO == detalle.IDPRODUCTO &&
                                    etIsNull ? obj.ESPECIFICACIONTECNICA == null : obj.ESPECIFICACIONTECNICA == detalle.ESPECIFICACIONTECNICA);


                producto.CANTIDAD -= rec.CANTIDAD;
                db.SAB_EST_ALMACENESENTREGASOLICITUD.DeleteObject(rec);
                db.SaveChanges();
            }
        }

        public static void AgregarAlmacenEntregaSolicitud(SAB_EST_DETALLESOLICITUDES detalle, int lugar, int fuente)
        {
            var etIsNull = string.IsNullOrEmpty(detalle.ESPECIFICACIONTECNICA);
            using (var db = new SinabEntities())
            {
                var rec = db.SAB_EST_ALMACENESENTREGASOLICITUD.FirstOrDefault(aes =>
                                                                                aes.IDSOLICITUD == detalle.IDSOLICITUD &&
                                                                                aes.IDESTABLECIMIENTO ==
                                                                                detalle.IDESTABLECIMIENTO &&
                                                                                aes.IDPRODUCTO == detalle.IDPRODUCTO &&
                                                                                aes.IDALMACENENTREGA == lugar &&
                                                                                aes.IDFUENTEFINANCIAMIENTO == fuente);

                var producto = db.SAB_EST_PRODUCTOSSOLICITUD.FirstOrDefault(obj =>
                                    obj.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                                    obj.IDSOLICITUD == detalle.IDSOLICITUD &&
                                    obj.IDPRODUCTO == detalle.IDPRODUCTO &&
                                    etIsNull ? obj.ESPECIFICACIONTECNICA == null : obj.ESPECIFICACIONTECNICA == detalle.ESPECIFICACIONTECNICA);


                producto.CANTIDAD -= rec.CANTIDAD;
                db.SAB_EST_ALMACENESENTREGASOLICITUD.DeleteObject(rec);
                db.SaveChanges();
            }
        }
        #endregion ALMACEN ENTREGA SOLICITUD



        #region FUENTES FINANCIAMIENTO
        public static void CargarFuentesFinanciamientoAlmacenes(SAB_EST_SOLICITUDES solicitud)
        {
            using (var db = new SinabEntities())
            {
                FuentesFinanciamiento = SolicitudesFuentesFinanciamiento.Obtener(db, solicitud);
                AlmacenesEntregas = AlmacenesEntrega.Obtener(db, solicitud.IDSOLICITUD, solicitud.IDESTABLECIMIENTO);
            }
        }

        public static decimal ObtenerMonto(SAB_EST_SOLICITUDES solicitud)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_EST_DETALLESOLICITUDES.
                                    Where(ds =>
                                          ds.IDSOLICITUD == solicitud.IDSOLICITUD &&
                                          ds.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO).
                                    Sum(ds => ds.PRESUPUESTOTOTAL) ?? 0;
            }
        }

        public static List<BasePar> ObtenerMontosPorFuente(SAB_EST_SOLICITUDES solicitud)
        {
            /*
             *  SET @MONTO = ( select sum(presupuestototal) From sab_est_detallesolicitudes 
             *  where idsolicitud=@IDSOLICITUD and idestablecimiento=@IDESTABLECIMIENTOSOLICITUD )
             *  
             * SELECT @IDESTABLECIMIENTOSOLICITUD,@IDSOLICITUD,IDFUENTEFINANCIAMIENTO,
             * SUM(CANTIDAD*PRECIOUNITARIO) AS MONTOF, 
             * (sum(cantidad*preciounitario) * 100)/@MONTO as PORCENTAJE,@USUARIOCREACION,getdate(),NULL,NULL,0  
             * FROM SAB_EST_ALMACENESENTREGASOLICITUD 
             * WHERE IDESTABLECIMIENTO=@IDESTABLECIMIENTOSOLICITUD AND IDSOLICITUD=@IDSOLICITUD
             * GROUP BY IDFUENTEFINANCIAMIENTO
            */

            List<BasePar> lista;

            using (var db = new SinabEntities())
            {
                var sumatoria = db.SAB_EST_DETALLESOLICITUDES.
                                    Where(ds =>
                                          ds.IDSOLICITUD == solicitud.IDSOLICITUD &&
                                          ds.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO).
                                    Sum(ds => ds.PRESUPUESTOTOTAL) ?? 0;

                lista = db.SAB_EST_ALMACENESENTREGASOLICITUD.
                    GroupBy(aes => new { aes.IDFUENTEFINANCIAMIENTO, aes.IDSOLICITUD, aes.IDESTABLECIMIENTO }).
                    Where(aes =>
                          aes.Key.IDSOLICITUD == solicitud.IDSOLICITUD &&
                          aes.Key.IDESTABLECIMIENTO == solicitud.IDESTABLECIMIENTO).
                    Select(aes =>
                           new BasePar
                           {
                               IdSolicitud = aes.Key.IDSOLICITUD,
                               IdFuente = aes.Key.IDFUENTEFINANCIAMIENTO,
                               Monto = aes.Sum(rec => rec.CANTIDAD * rec.PRECIOUNITARIO),
                               Porcentaje = ((aes.Sum(rec => rec.CANTIDAD * rec.PRECIOUNITARIO) * 100) / sumatoria)
                           }
                               ).ToList();

            }
            return lista;

        }

        public static Dictionary<int, string> ObtenerFuentesFinanciamiento(SAB_EST_SOLICITUDES solicitud)
        {
            using (var db = new SinabEntities())
            {
                var Base = Solicitudes.Obtener(db, solicitud);
                return Base.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.Select(ff => new
                                                                                     {
                                                                                         ff.IDFUENTEFINANCIAMIENTO,
                                                                                         nombre =
                                                                                     ff.SAB_CAT_FUENTEFINANCIAMIENTOS.
                                                                                         SAB_CAT_GRUPOSFUENTEFINANCIAMIENTO
                                                                                         .DESCRIPCION + "/" +
                                                                                     ff.SAB_CAT_FUENTEFINANCIAMIENTOS.
                                                                                         NOMBRE
                                                                                     })
                    .ToDictionary(rec => rec.IDFUENTEFINANCIAMIENTO, rec => rec.nombre);
            }
        }

        public static void ActualizarFuenteFinanciamiento(SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES fuente)
        {

            SolicitudesFuentesFinanciamiento.Actualizar(fuente);
        }

        public static void EliminarFuenteFinanciamiento(int idFuente, SAB_EST_SOLICITUDES solicitud)
        {
            using (var db = new SinabEntities())
            {
                var Base = Solicitudes.Obtener(db, solicitud);
                var fuente =
                    Base.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.FirstOrDefault(
                        a => a.IDFUENTEFINANCIAMIENTO == idFuente);
                if (fuente != null)
                {
                    //Base.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.Remove(fuente);
                    db.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.DeleteObject(fuente);
                    db.SaveChanges();
                }

                var recs = db.SAB_EST_ALMACENESENTREGASOLICITUD.Where(p =>
                                                                      p.IDFUENTEFINANCIAMIENTO == idFuente &&
                                                                      p.IDSOLICITUD == Base.IDSOLICITUD &&
                                                                      p.IDESTABLECIMIENTO == Base.IDESTABLECIMIENTO
                    ).ToList();

                if (!recs.Any()) return;
                BorrarDetalle(db, recs);
                db.SaveChanges();


            }
        }
        #endregion FUENTES FINANCIAMIENTO

        #region Metodos privados
        private static void BorrarDetalle(SinabEntities db, IEnumerable<SAB_EST_ALMACENESENTREGASOLICITUD> recs)
        {
            foreach (var rec in recs)
            {
                var etIsNull = string.IsNullOrEmpty(rec.ESPECIFICACIONTECNICA);
                var es = rec.SAB_EST_ENTREGASOLICITUDES;
                var conteo = es.SAB_EST_ALMACENESENTREGASOLICITUD.Count;
                if (conteo == 1)
                {
                    var ds = es.SAB_EST_DETALLESOLICITUDES;

                    //sino borra en cascada
                    db.SAB_EST_ALMACENESENTREGASOLICITUD.DeleteObject(rec);
                    db.SAB_EST_ENTREGASOLICITUDES.DeleteObject(es);
                    db.SAB_EST_DETALLESOLICITUDES.DeleteObject(ds);

                }
                else
                {
                    db.SAB_EST_ALMACENESENTREGASOLICITUD.DeleteObject(rec);
                }

                var prod = db.SAB_EST_PRODUCTOSSOLICITUD.FirstOrDefault(p =>
                                                                        p.IDPRODUCTO == rec.IDPRODUCTO &&
                                                                        p.IDSOLICITUD == rec.IDSOLICITUD &&
                                                                        p.IDESTABLECIMIENTO == rec.IDESTABLECIMIENTO &&
                                                                        etIsNull ? p.ESPECIFICACIONTECNICA == null : p.ESPECIFICACIONTECNICA == rec.ESPECIFICACIONTECNICA);
                if (prod != null)
                {
                    prod.CANTIDAD -= rec.CANTIDAD;
                }
            }
        }

        private static void BorrarDetalle(SinabEntities db, SAB_EST_PRODUCTOSSOLICITUD prod)
        {
            var etIsNull = string.IsNullOrEmpty(prod.ESPECIFICACIONTECNICA);
            //borra las tablas de detalle (ultimas en llenarse)
            var rec = db.SAB_EST_DETALLESOLICITUDES

                .FirstOrDefault(
                    eds =>
                    eds.IDSOLICITUD == prod.IDSOLICITUD &&
                    eds.IDESTABLECIMIENTO == prod.IDESTABLECIMIENTO &&
                    eds.IDPRODUCTO == prod.IDPRODUCTO &&
                    etIsNull ? eds.ESPECIFICACIONTECNICA == null : eds.ESPECIFICACIONTECNICA == prod.ESPECIFICACIONTECNICA
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
        }


        #endregion Metodos privados
    }

    public class BasePar
    {
        public int IdFuente { get; set; }
        public long IdSolicitud { get; set; }
        public decimal Monto { get; set; }
        public decimal Porcentaje { get; set; }


    }

}
