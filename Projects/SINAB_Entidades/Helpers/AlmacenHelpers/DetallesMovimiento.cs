using System;
using System.Collections.Generic;
using System.Linq;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public static class DetallesMovimiento
    {
        /// <summary>
        /// Elimina el detalle de las tablas de DetalleMovimiento si se encuenta en la db.
        /// Esta funcion no guarda en la base de datos, se debe actualizar fuera del lazo try-catch que la contenga (db.savechanges()).
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="detalle">Detalle a borrar</param>
        /// <history> SINAB_DEV 02/07/2013</history>
        /// <history> SINAB_DEV 22/07/2013: cambio a static</history>
        public static void Eliminar(SinabEntities db, SAB_ALM_DETALLEMOVIMIENTOS detalle)
        {
            var res =
                db.SAB_ALM_DETALLEMOVIMIENTOS.FirstOrDefault(
                    d =>
                        d.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                        d.IDTIPOTRANSACCION == detalle.IDTIPOTRANSACCION &&
                        d.IDMOVIMIENTO == detalle.IDMOVIMIENTO && d.IDDETALLEMOVIMIENTO == detalle.IDDETALLEMOVIMIENTO);

            db.SAB_ALM_DETALLEMOVIMIENTOS.DeleteObject(res);
            db.SaveChanges();
        }

        /// <summary>
        /// Anula el detalle seleccionado cambiando su cantidad a 0 y guardandola en el campo CANTIDAD ANULADA.
        /// Se prevee cambiarle también el valor a IDTIPOTRANSACCION
        /// </summary>
        /// <param name="db">contexto de la base de datos</param>
        /// <param name="detalle">detalle fuera de contexto</param>
        /// <remarks> Autor: Farid Antonio Pérez Aldana. Fecha Creación: 14/06/2016</remarks>
        public static void Anular(SinabEntities db, SAB_ALM_DETALLEMOVIMIENTOS detalle)
        {
            var res =
                db.SAB_ALM_DETALLEMOVIMIENTOS.FirstOrDefault(
                    d =>
                        d.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                        d.IDTIPOTRANSACCION == detalle.IDTIPOTRANSACCION &&
                        d.IDMOVIMIENTO == detalle.IDMOVIMIENTO && d.IDDETALLEMOVIMIENTO == detalle.IDDETALLEMOVIMIENTO);
            if(res == null) return;
            res.CANTIDADANULADA = res.CANTIDAD;
            res.ANULADO = true;
            res.CANTIDAD = 0;
            res.AUUSUARIOMODIFICACION = Membresia.ObtenerUsuario().USUARIO;
            res.AUFECHAMODIFICACION = DateTime.Now;
            var anular = res.SAB_ALM_DETALLEMOVIMIENTOLOTES.ToList();
            foreach (var r in anular)
            {
                db.SAB_ALM_DETALLEMOVIMIENTOLOTES.DeleteObject(r);
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Elimina todo detalle de las tablas de DetalleMovimiento que concuerden con el movimiento parametrizado.
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="movimiento">Movimiento del cual se borraran los detales</param>
        /// /// <history> SINAB_DEV 22/07/2013</history>
        public static void EliminarTodos(SinabEntities db, SAB_ALM_MOVIMIENTOS movimiento)
        {
            var res = db.SAB_ALM_DETALLEMOVIMIENTOS.Where(d => d.IDESTABLECIMIENTO == movimiento.IDESTABLECIMIENTO
                                                               && d.IDTIPOTRANSACCION == movimiento.IDTIPOTRANSACCION
                                                               && d.IDMOVIMIENTO == movimiento.IDMOVIMIENTO);
            if (!res.Any()) return;
            foreach (var dm in res)
            {
                db.SAB_ALM_DETALLEMOVIMIENTOS.DeleteObject(dm);
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Elimina el detalle de las tablas de DetalleMovimiento si se encuenta en la db.
        /// </summary>
        /// <param name="detalle">Detalle a borrar</param>
        /// <history> SINAB_DEV 02/07/2013</history>
        public static void Eliminar(SAB_ALM_DETALLEMOVIMIENTOS detalle)
        {
            using (var db = new SinabEntities())
            {
                var res =
                    db.SAB_ALM_DETALLEMOVIMIENTOS.FirstOrDefault(
                        d =>
                            d.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                            d.IDTIPOTRANSACCION == detalle.IDTIPOTRANSACCION &&
                            d.IDMOVIMIENTO == detalle.IDMOVIMIENTO &&
                            d.IDDETALLEMOVIMIENTO == detalle.IDDETALLEMOVIMIENTO);

                db.SAB_ALM_DETALLEMOVIMIENTOS.DeleteObject(res);
                db.SaveChanges();
            }

        }

        /// <summary>
        /// Agrega el detalle a la tabla DetalleMovimiento.
        /// Esta funcion no guarda en la base de datos, se debe actualizar fuera del lazo try-catch que la contenga (db.savechanges()).
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="detalle">Detalle a agregar</param>
        /// <history> SINAB_DEV 02/07/2013</history>
        public static void Agregar(SAB_ALM_DETALLEMOVIMIENTOS detalle, SinabEntities db)
        {
            var dms = db.SAB_ALM_DETALLEMOVIMIENTOS.Where(
                dm => dm.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO
                      && dm.IDMOVIMIENTO == detalle.IDMOVIMIENTO
                      && dm.IDTIPOTRANSACCION == detalle.IDTIPOTRANSACCION);
            long lastIdDm = 0;
            if (dms.Any()) lastIdDm = dms.DefaultIfEmpty().Max(dm => dm == null ? 0 : dm.IDDETALLEMOVIMIENTO);
            detalle.IDDETALLEMOVIMIENTO = lastIdDm + 1;
            detalle.INSERTAR = false;
            db.SAB_ALM_DETALLEMOVIMIENTOS.AddObject(detalle);
            db.SaveChanges();
        }

        /// <summary>
        /// Agrega el detalle a la tabla DetalleMovimiento.
        /// </summary>
        /// <param name="detalle">Detalle a agregar</param>
        /// <history> SINAB_DEV 02/07/2013</history>
        public static void Agregar(SAB_ALM_DETALLEMOVIMIENTOS detalle)
        {
            using (var db = new SinabEntities())
            {
                var dms = db.SAB_ALM_DETALLEMOVIMIENTOS.Where(dm =>
                    dm.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                    dm.IDMOVIMIENTO == detalle.IDMOVIMIENTO &&
                    dm.IDTIPOTRANSACCION == detalle.IDTIPOTRANSACCION)
                    .DefaultIfEmpty()
                    .Max(dm => dm == null ? 0 : dm.IDDETALLEMOVIMIENTO);

                detalle.IDDETALLEMOVIMIENTO = dms + 1;

                db.SAB_ALM_DETALLEMOVIMIENTOS.AddObject(detalle);

                db.SaveChanges();
            }
        }


        public static List<ActaRecepcion> ObtenerActaPorAlmacen(SinabEntities db, int idEstablecimiento, DateTime fechaIni,
            DateTime fechaFin, int idAlmacen = 0)
        {
            return db.SAB_ALM_DETALLEMOVIMIENTOS.
                    Where(m => m.IDESTABLECIMIENTO == idEstablecimiento && (idAlmacen == 0 || m.IDALMACEN == idAlmacen)
                               && m.SAB_ALM_MOVIMIENTOS.SAB_ALM_RECIBOSRECEPCION.SAB_UACI_CONTRATOS != null &&
                               m.SAB_ALM_LOTES != null &&
                               m.SAB_ALM_MOVIMIENTOS.FECHAMOVIMIENTO >= fechaIni &&
                               m.SAB_ALM_MOVIMIENTOS.FECHAMOVIMIENTO <= fechaFin && m.NUMEROFACTURA != null).
                    Select(ar => new ActaRecepcion()
                    {
                        Fecha = ar.SAB_ALM_MOVIMIENTOS.FECHAMOVIMIENTO.Value,
                        NumActa = ar.SAB_ALM_MOVIMIENTOS.SAB_ALM_RECIBOSRECEPCION.NUMEROACTA,
                        NumContrato =
                            ar.SAB_ALM_MOVIMIENTOS.SAB_ALM_RECIBOSRECEPCION.SAB_UACI_CONTRATOS
                            .NUMEROCONTRATO,
                        NumResolucion =
                            ar.SAB_ALM_MOVIMIENTOS.SAB_ALM_RECIBOSRECEPCION.SAB_UACI_CONTRATOS.RESOLUCION,
                        Proveedor =
                            ar.SAB_ALM_MOVIMIENTOS.SAB_ALM_RECIBOSRECEPCION.SAB_UACI_CONTRATOS
                            .SAB_CAT_PROVEEDORES.NOMBRE,
                        IdDocumento = ar.NUMEROFACTURA,
                        Cantidad = ar.CANTIDAD,
                        PrecioUnitario = (Decimal)ar.SAB_ALM_LOTES.PRECIOLOTE,
                        Monto = ar.CANTIDAD * (Decimal)ar.SAB_ALM_LOTES.PRECIOLOTE,
                        FechaInicial = fechaIni,
                        FechaFinal = fechaFin
                    }).ToList();
        }

        public static List<ActaRecepcion> ObtenerActaPorAlmacen(int idEstablecimiento, DateTime fechaIni, DateTime fechaFin, int idAlmacen = 0)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerActaPorAlmacen(db, idEstablecimiento, fechaIni, fechaFin, idAlmacen);
            }
        }
    }
}
