using System;
using System.Linq;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public class Movimientos
    {
        /// <summary>
        /// Guardar una instancia de movimiento en la base de datos
        /// </summary>
        /// <param name="movimiento">Instancia a agregar</param>
        /// <param name="db">Datacontext</param>
        public static void Guardar(SinabEntities db, SAB_ALM_MOVIMIENTOS movimiento)
        {
            /*
             *  lastId = db.SAB_ALM_VALESSALIDA.Where(vs => vs.IDALMACEN == vale.IDALMACEN && vs.ANIO == vale.ANIO).DefaultIfEmpty().Max(vs => vs == null ?0: vs.IDVALE);
             */
            var lastId = ObtenerUltimoId(db, movimiento);

            movimiento.IDMOVIMIENTO = lastId + 1;
            db.SAB_ALM_MOVIMIENTOS.AddObject(movimiento);
            db.SaveChanges();
        }

        public static long ObtenerUltimoId(SinabEntities db, SAB_ALM_MOVIMIENTOS movimiento)
        {
            return db.SAB_ALM_MOVIMIENTOS.Where(mv => mv.IDESTABLECIMIENTO == movimiento.IDESTABLECIMIENTO
                                                      && mv.IDTIPOTRANSACCION == movimiento.IDTIPOTRANSACCION)
                .DefaultIfEmpty()
                .Max(mv => mv ==null?0: mv.IDMOVIMIENTO);
        }

        /// <summary>
        /// Prepara la datacontext para eliminar el movimiento seleccionado
        /// Esta funcion no guarda el resultado en la db
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="movimiento">Movimiento a borrar</param>
        public static void Eliminar(SinabEntities db, SAB_ALM_MOVIMIENTOS movimiento)
        {
            var mv = db.SAB_ALM_MOVIMIENTOS.FirstOrDefault(m => m.IDMOVIMIENTO == movimiento.IDMOVIMIENTO
                                                                && m.IDTIPOTRANSACCION == movimiento.IDTIPOTRANSACCION
                                                                && m.IDESTABLECIMIENTO == movimiento.IDESTABLECIMIENTO);
            if (mv != null) db.SAB_ALM_MOVIMIENTOS.DeleteObject(mv);
        }

        public static void Anular(SinabEntities db, SAB_ALM_MOVIMIENTOS movimiento)
        {
            var mv = db.SAB_ALM_MOVIMIENTOS.FirstOrDefault(m => m.IDMOVIMIENTO == movimiento.IDMOVIMIENTO
                                                               && m.IDTIPOTRANSACCION == movimiento.IDTIPOTRANSACCION
                                                               && m.IDESTABLECIMIENTO == movimiento.IDESTABLECIMIENTO);
            if(mv == null) return;
            mv.ANULADO = true;
            mv.IDESTADO = 3; //anulado
            mv.AUUSUARIOMODIFICACION = Membresia.ObtenerUsuario().USUARIO;
            mv.AUFECHAMODIFICACION = DateTime.Now;
            db.SaveChanges();
        }

        #region Obtener Movimientos
        /// <summary>
        /// Obtiene el movimiento comparando
        /// </summary>
        /// <param name="idMovimiento">Identificador de movimiento</param>
        /// <param name="tipoTransaccion">Tipo de transaccion</param>
        /// <param name="idEstablecimiento">Identificador de establecimiento</param>
        /// <returns>El movimiento que cumple las condiciones</returns>
        /// <remarks>MINSAL_DEV 21/05/2013</remarks>
        public static SAB_ALM_MOVIMIENTOS Obtener(int idMovimiento, int tipoTransaccion, int idEstablecimiento)
        {
            try
            {
                using (var db = new SinabEntities())
                {
                    return db.SAB_ALM_MOVIMIENTOS.Include(m => m.SAB_ALM_DETALLEMOVIMIENTOS).FirstOrDefault(mv => mv.IDMOVIMIENTO == idMovimiento
                            && mv.IDTIPOTRANSACCION == tipoTransaccion
                            && mv.IDESTABLECIMIENTO == idEstablecimiento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene el movimiento comparando
        /// </summary>
        /// <param name="movimiento">Entidad a comparar</param>
        /// <returns>El movimiento que cumple las condiciones</returns>
        /// <remarks>MINSAL_DEV 21/05/2013</remarks>
        public static SAB_ALM_MOVIMIENTOS Obtener(SAB_ALM_MOVIMIENTOS movimiento)
        {
            try
            {
                using (var db = new SinabEntities())
                {
                    return db.SAB_ALM_MOVIMIENTOS.FirstOrDefault(mv => mv.IDMOVIMIENTO == movimiento.IDMOVIMIENTO
                        && mv.IDTIPOTRANSACCION == movimiento.IDTIPOTRANSACCION
                        && mv.IDESTABLECIMIENTO == movimiento.IDESTABLECIMIENTO);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SAB_ALM_MOVIMIENTOS Obtener(SAB_ALM_MOVIMIENTOS movimiento, SinabEntities db)
        {
            
                    return db.SAB_ALM_MOVIMIENTOS.FirstOrDefault(mv => mv.IDMOVIMIENTO == movimiento.IDMOVIMIENTO
                        && mv.IDTIPOTRANSACCION == movimiento.IDTIPOTRANSACCION
                        && mv.IDESTABLECIMIENTO == movimiento.IDESTABLECIMIENTO);
            
        }

        public static SAB_ALM_MOVIMIENTOS Obtener(SinabEntities db, long idMovimiento, int idEstablecimiento, int idTipoTransaccion)
        {

            return db.SAB_ALM_MOVIMIENTOS.Include(m => m.SAB_ALM_DETALLEMOVIMIENTOS.Select(dm => dm.SAB_ALM_DETALLEMOVIMIENTOLOTES)).FirstOrDefault(mv => mv.IDMOVIMIENTO == idMovimiento
                && mv.IDTIPOTRANSACCION == idTipoTransaccion
                && mv.IDESTABLECIMIENTO == idEstablecimiento);

        }

        #endregion
        
        /// <summary>
        /// Actualiza o crea un movimiento
        /// </summary>
        /// <param name="movimiento">Entidad tipo MOVIMIENTO fuente de datos</param>
        /// <remarks>MINSAL_DEV 21/05/2013</remarks>
        public static void Actualizar(SAB_ALM_MOVIMIENTOS movimiento) {
            using (var db = new SinabEntities())
            {

                var currentMove = Obtener(movimiento, db);
                    if (currentMove != null) //si ya existe
                    {
                        currentMove.IDTIPODOCREF = movimiento.IDTIPODOCREF;
                        currentMove.NUMERODOCREF = movimiento.NUMERODOCREF;
                        if(movimiento.IDALMACEN != null || movimiento.IDALMACEN > 0 )
                            currentMove.IDALMACEN = movimiento.IDALMACEN;
                        currentMove.ANIO = movimiento.ANIO;
                        currentMove.IDDOCUMENTO = movimiento.IDDOCUMENTO;
                        currentMove.IDESTADO = movimiento.IDESTADO;
                        currentMove.IDUNIDADSOLICITA = movimiento.IDUNIDADSOLICITA;
                        currentMove.TOTALMOVIMIENTO = movimiento.TOTALMOVIMIENTO;
                        currentMove.IDEMPLEADOSOLICITA = movimiento.IDEMPLEADOSOLICITA;
                        currentMove.IDEMPLEADOAUTORIZA = movimiento.IDEMPLEADOAUTORIZA;
                        currentMove.IDEMPLEADOALMACEN = movimiento.IDEMPLEADOALMACEN;
                        currentMove.IDEMPLEADODESPACHA = movimiento.IDEMPLEADODESPACHA;
                        currentMove.IDEMPLEADORECIBE = movimiento.IDEMPLEADORECIBE;
                        currentMove.IDEMPLEADOPREPARA = movimiento.IDEMPLEADOPREPARA;
                        currentMove.IDEMPLEADOENVIADO = movimiento.IDEMPLEADOENVIADO;
                        currentMove.CLASIFICACIONMOVIMIENTO = movimiento.CLASIFICACIONMOVIMIENTO;
                        currentMove.SUBCLASIFICACIONMOVIMIENTO = movimiento.SUBCLASIFICACIONMOVIMIENTO;
                        currentMove.RESPONSABLEDISTRIBUCION = movimiento.RESPONSABLEDISTRIBUCION;
                        currentMove.MOTIVO = movimiento.MOTIVO;
                        currentMove.ESTASINCRONIZADA = movimiento.ESTASINCRONIZADA;
                        currentMove.FECHAMOVIMIENTO = movimiento.FECHAMOVIMIENTO;
                        currentMove.IDESTABLECIMIENTODESTINO = movimiento.IDESTABLECIMIENTODESTINO;
                        currentMove.IDALMACENDESTINO = movimiento.IDALMACENDESTINO == 0?null:movimiento.IDALMACENDESTINO;
                        currentMove.ID_LUGAR_ENTREGA_HOSPITAL = movimiento.ID_LUGAR_ENTREGA_HOSPITAL;
                        currentMove.AUUSUARIOMODIFICACION = movimiento.AUUSUARIOMODIFICACION;
                        currentMove.AUFECHAMODIFICACION = movimiento.AUFECHAMODIFICACION;
                        currentMove.EMPLEADOALMACEN = movimiento.EMPLEADOALMACEN;
                        currentMove.EMPLEADOPREPARA = movimiento.EMPLEADOPREPARA;

                        db.SaveChanges();
                    }
                    else // si no existe se crea
                    {
                        Guardar(db, movimiento);
                    }
               
            }
        }

   
    }
}
