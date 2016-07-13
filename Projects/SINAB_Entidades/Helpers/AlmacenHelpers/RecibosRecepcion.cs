using System;
using System.Collections.Generic;
using System.Linq;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public static class RecibosRecepcion
    {
        public static List<prcDetalleRecepcion_Result> ObtenerDetalle(int idalmacen, int? idrecibo, short? anio, int tipoTransaccion)
        {
            using (var db = new SinabEntities())
            {
                return db.prcDetalleRecepcion(idalmacen, anio, idrecibo, tipoTransaccion).ToList();
            }
        }
        
        public static void ActualizarReciboRecepcion(SAB_ALM_RECIBOSRECEPCION recibo)
        {
            using (var db = new SinabEntities())
            {
                if (recibo.IDRECIBO == 0)
                {
                    AgregarReciboRecepcion(recibo, db);
                }
                else
                {
                    var rec = ObtenerReciboRecepcion(recibo, db);

                    if (rec != null)
                    {
                        var acs = recibo.SAB_EST_ADMINISTRADORESCONTRATO;
                        //limpia los administradores de contrato antes de guardar
                        rec.SAB_EST_ADMINISTRADORESCONTRATO.ToList().ForEach(db.DeleteObject);

                        rec.IDESTABLECIMIENTO = recibo.IDESTABLECIMIENTO;
                        rec.IDPROVEEDOR = recibo.IDPROVEEDOR;
                        rec.IDCONTRATO = recibo.IDCONTRATO;
                        rec.RESPONSABLEPROVEEDOR = recibo.RESPONSABLEPROVEEDOR;
                        rec.NUMEROACTA = recibo.NUMEROACTA;
                        rec.OBSERVACION = recibo.OBSERVACION;
                        rec.AUFECHAMODIFICACION = recibo.AUFECHAMODIFICACION;
                        rec.AUUSUARIOMODIFICACION = recibo.AUUSUARIOMODIFICACION;
                        rec.ESTASINCRONIZADA = recibo.ESTASINCRONIZADA;
                        rec.IDALMACENVALE = recibo.IDALMACENVALE;
                        rec.ANIOVALE = recibo.ANIOVALE;
                        rec.IDVALE = recibo.IDVALE;
                        rec.NUMEROVALE = recibo.NUMEROVALE;
                        rec.IDESTABLECIMIENTODEVOLUCION = recibo.IDESTABLECIMIENTODEVOLUCION;
                        rec.ADMCONTRATO = recibo.ADMCONTRATO;
                        if (acs.Any()) acs.ToList().ForEach(ac => rec.SAB_EST_ADMINISTRADORESCONTRATO.Add(ac));
                    }
                }
                db.SaveChanges();

            }
        }

        public static void ActualizarReciboRecepcion(SAB_ALM_RECIBOSRECEPCION recibo, SinabEntities db)
        {
            
                if (recibo.IDRECIBO == 0)
                {
                    AgregarReciboRecepcion(recibo, db);
                }
                else
                {
                    var rec = ObtenerReciboRecepcion(recibo, db);

                    if (rec != null)
                    {
                        var acs = recibo.SAB_EST_ADMINISTRADORESCONTRATO;
                        //limpia los administradores de contrato antes de guardar
                        rec.SAB_EST_ADMINISTRADORESCONTRATO.ToList().ForEach(db.DeleteObject);

                        rec.IDESTABLECIMIENTO = recibo.IDESTABLECIMIENTO;
                        rec.IDPROVEEDOR = recibo.IDPROVEEDOR;
                        rec.IDCONTRATO = recibo.IDCONTRATO;
                        rec.RESPONSABLEPROVEEDOR = recibo.RESPONSABLEPROVEEDOR;
                        rec.NUMEROACTA = recibo.NUMEROACTA;
                        rec.OBSERVACION = recibo.OBSERVACION;
                        rec.AUFECHAMODIFICACION = recibo.AUFECHAMODIFICACION;
                        rec.AUUSUARIOMODIFICACION = recibo.AUUSUARIOMODIFICACION;
                        rec.ESTASINCRONIZADA = recibo.ESTASINCRONIZADA;
                        rec.IDALMACENVALE = recibo.IDALMACENVALE;
                        rec.ANIOVALE = recibo.ANIOVALE;
                        rec.IDVALE = recibo.IDVALE;
                        rec.NUMEROVALE = recibo.NUMEROVALE;
                        rec.IDESTABLECIMIENTODEVOLUCION = recibo.IDESTABLECIMIENTODEVOLUCION;
                        rec.ADMCONTRATO = recibo.ADMCONTRATO;
                        if (acs.Any()) acs.ToList().ForEach(ac => rec.SAB_EST_ADMINISTRADORESCONTRATO.Add(ac));
                    }
               
                db.SaveChanges();

            }
        }

        public static SAB_ALM_RECIBOSRECEPCION ObtenerReciboRecepcion(SAB_ALM_RECIBOSRECEPCION recibo, SinabEntities db)
        {
            var rec = db.SAB_ALM_RECIBOSRECEPCION.FirstOrDefault(rr =>
                rr.IDALMACEN == recibo.IDALMACEN &&
                rr.IDRECIBO == recibo.IDRECIBO &&
                rr.ANIO == recibo.ANIO);
            return rec;
        }
        public static SAB_ALM_RECIBOSRECEPCION ObtenerReciboRecepcion(SAB_ALM_RECIBOSRECEPCION recibo)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerReciboRecepcion(recibo, db);
            }
        }

        public static List<BaseRecibosRecepcion> ObtenerTodos(int idAlmacen, int idEstablecimiento, int idProveedor, DateTime? fechaDesde, DateTime? fechaHasta, int idGrupoFuenteFinanciamiento, int idFuenteFinanciamiento, int idResponsableDistribucion, int idEstado, int numeroRecibo, int numeroActa, int idSumininstro)
        {
            if (fechaDesde == DateTime.MinValue) fechaDesde = null;
            if (fechaHasta == DateTime.MinValue) fechaHasta = null;

            using (var db = new SinabEntities())
            {
                return db.ObtenerTodosReciboRecepcionReporte(idAlmacen, idEstablecimiento, idProveedor, fechaDesde,
                    fechaHasta, idGrupoFuenteFinanciamiento, idFuenteFinanciamiento, idResponsableDistribucion, idEstado,
                    numeroRecibo, numeroActa, idSumininstro).ToList();
            }
        }

        public static void AgregarReciboRecepcion(SAB_ALM_RECIBOSRECEPCION recibo, SinabEntities db)
        {
            var lastId = db.SAB_ALM_RECIBOSRECEPCION.Where(rr =>
                rr.IDALMACEN == recibo.IDALMACEN &&
                rr.ANIO == recibo.ANIO).
                Max(rr => rr.IDRECIBO);

            recibo.IDRECIBO = lastId + 1;
            db.SAB_ALM_RECIBOSRECEPCION.AddObject(recibo);
        }
    }

 
}
