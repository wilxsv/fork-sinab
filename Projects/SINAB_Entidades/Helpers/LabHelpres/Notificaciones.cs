using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Security.Cryptography;
using System.Transactions;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.LabHelpres
{
    public static class Notificaciones
    {
        public static int ObtenerCountNotificacion(int idProveedor, int idProcesoCompra, int idEstablecimiento,
            int idContrato, int estado)
        {
            using (var db = new SinabEntities())
            {
                var rec = db.SAB_LAB_INFORMEMUESTRAS.Count(im => im.IDPROVEEDOR == idProveedor &&
                                                                 im.IDPROCESOCOMPRA == idProcesoCompra &&
                                                                 im.IDESTABLECIMIENTOCONTRATO == idEstablecimiento &&
                                                                 im.IDCONTRATO == idContrato &&
                                                                 im.IDESTADO == estado);
                return rec;
            }
        }

        public static int ObtenerCountNotificacion(int idProveedor, int idProcesoCompra, int idEstablecimiento,
            int idContrato, int numeroNotificacion, int estado)
        {
            using (var db = new SinabEntities())
            {
                var rec = db.SAB_LAB_INFORMEMUESTRAS.Count(im => im.IDPROVEEDOR == idProveedor &&
                                                                 im.IDPROCESOCOMPRA == idProcesoCompra &&
                                                                 im.IDESTABLECIMIENTOCONTRATO == idEstablecimiento &&
                                                                 im.IDCONTRATO == idContrato &&
                                                                 im.IDESTADO == estado &&
                                                                 im.NUMERONOTIFICACION == numeroNotificacion);
                return rec;
            }
        }


        public static int ObtenerMaxGrupo(int idEstablecimiento, int idProveedor, int idContrato, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                try
                {
                    var rec =
                        db.SAB_LAB_INFORMEMUESTRAS.Where(
                            im =>
                                im.IDPROCESOCOMPRA == idProcesoCompra && im.IDCONTRATO == idContrato &&
                                im.IDPROVEEDOR == idProveedor && im.IDESTABLECIMIENTOCONTRATO == idEstablecimiento)
                            .DefaultIfEmpty()
                            .Max(im => im.IDINFORME);
                    return rec + 1;
                }
                catch
                {
                    return 1;
                }

            }
        }

        public static int ObtenerMaxNotificcion(decimal idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                var rec =
                    db.SAB_LAB_INFORMEMUESTRAS.Where(im => im.IDESTABLECIMIENTOCONTRATO == idEstablecimiento)
                        .DefaultIfEmpty()
                        .Max(im => im.IDINFORME);
                return rec + 1;
            }
        }

        public static void Agregar(SAB_LAB_INFORMEMUESTRAS notificacion)
        {
            using (var db = new SinabEntities())
            {
                Agregar(db, notificacion);
            }
        }

        public static void Agregar(SinabEntities db, SAB_LAB_INFORMEMUESTRAS notificacion)
        {
            db.SAB_LAB_INFORMEMUESTRAS.AddObject(notificacion);
            db.SaveChanges();
        }

        public static List<BaseInformeMuestra> ObtenerTodos(int idProveedor, int idProcesoCompra, int idEstablecimiento,
            int idContrato, decimal idEstado)
        {
            using (var db = new SinabEntities())
            {
                return (from im in db.SAB_LAB_INFORMEMUESTRAS
                        join cp in db.vv_CATALOGOPRODUCTOS on im.IDPRODUCTO equals cp.IDPRODUCTO
                        where im.IDPROVEEDOR == idProveedor &&
                              im.IDESTABLECIMIENTO == idEstablecimiento &&
                              im.IDPROCESOCOMPRA == idProcesoCompra &&
                              im.IDCONTRATO == idContrato &&
                            // im.NUMERONOTIFICACION == numeroNotificacion &&
                              im.IDESTADO == idEstado
                        select new BaseInformeMuestra
                        {
                            Idinforme = im.IDINFORME,
                            Numeronotificacion = im.NUMERONOTIFICACION ?? 0,
                            IdProducto = im.IDPRODUCTO ?? 0,
                            Lote = im.LOTE,
                            Renglon = im.RENGLON,
                            NombreComercial = im.NOMBRECOMERCIAL,
                            LaboratorioFabricante = im.LABORATORIOFABRICANTE,
                            NumeroUnidades = im.NUMEROUNIDADES ?? 0,
                            FechaFabricacion = im.FECHAFABRICACION,
                            FechaVencimiento = im.FECHAVENCIMIENTO,
                            FechaNotificacion = im.FECHANOTIFICACION,
                            CantidadAEntregar = im.CANTIDADAENTREGAR ?? 0,
                            UnidadMedida = cp.DESCRIPCION,
                            CorrProducto = cp.CORRPRODUCTO,
                            IdInspector = im.IDINSPECTOR ?? 0,
                            ObservacionNotificacion = im.OBSERVACION,
                            ObservacionAsignacion = im.OBSERVACIONASIGNACION,
                            FechaAsignacion = im.FECHAASIGNACION
                        }).ToList();
            }
        }
        public static List<rptLabRetiroMuestras_Result> ObtenerReporteRetiroMuestras(int iDestablecimientocontrato, int iDprocesocompra, int iDproveedor, int iDinspector, int ni)
        {
            using (var db = new SinabEntities())
            {
                var rec = db.rptLabRetiroMuestras(iDestablecimientocontrato, iDprocesocompra, iDproveedor, iDinspector, ni);

                return rec.ToList();
            }
        }



        public static List<BaseInformeMuestraReporte> ObtenerTodosReporte(int idProveedor, int idProcesoCompra, int idEstablecimiento,
            int idContrato, decimal idEstado)
        {
            using (var db = new SinabEntities())
            {
                return (from im in db.SAB_LAB_INFORMEMUESTRAS
                        join cp in db.vv_CATALOGOPRODUCTOS on im.IDPRODUCTO equals cp.IDPRODUCTO
                        where im.IDPROVEEDOR == idProveedor &&
                              im.IDESTABLECIMIENTO == idEstablecimiento &&
                              im.IDPROCESOCOMPRA == idProcesoCompra &&
                              im.IDCONTRATO == idContrato &&
                            // im.NUMERONOTIFICACION == numeroNotificacion &&
                              im.IDESTADO == idEstado
                        select new BaseInformeMuestraReporte
                        {
                            Idinforme = im.IDINFORME,
                            Numeronotificacion = im.NUMERONOTIFICACION ?? 0,
                            IdProducto = im.IDPRODUCTO ?? 0,
                            Lote = im.LOTE,
                            Renglon = im.RENGLON,
                            NombreComercial = im.NOMBRECOMERCIAL,
                            LaboratorioFabricante = im.LABORATORIOFABRICANTE,
                            NumeroUnidades = im.NUMEROUNIDADES ?? 0,
                            FechaFabricacion = im.FECHAFABRICACION ?? DateTime.MinValue,
                            FechaVencimiento = im.FECHAVENCIMIENTO ?? DateTime.MinValue,
                            FechaNotificacion = im.FECHANOTIFICACION ?? DateTime.MinValue,
                            CantidadAEntregar = im.CANTIDADAENTREGAR ?? 0,
                            UnidadMedida = cp.DESCRIPCION,
                            CorrProducto = cp.CORRPRODUCTO,
                            IdInspector = im.IDINSPECTOR ?? 0,
                            ObservacionNotificacion = im.OBSERVACION,
                            ObservacionAsignacion = im.OBSERVACIONASIGNACION,
                            FechaAsignacion = im.FECHAASIGNACION ?? DateTime.MinValue
                        }).ToList();
            }
        }

        public static List<BaseInformeMuestra> ObtenerTodos(int idProveedor, int idProcesoCompra, int idEstablecimiento,
           int idContrato, int numeroNotificacion, decimal idEstado)
        {
            using (var db = new SinabEntities())
            {
                return (from im in db.SAB_LAB_INFORMEMUESTRAS
                        join cp in db.vv_CATALOGOPRODUCTOS on im.IDPRODUCTO equals cp.IDPRODUCTO
                        where im.IDPROVEEDOR == idProveedor &&
                              im.IDESTABLECIMIENTO == idEstablecimiento &&
                              im.IDPROCESOCOMPRA == idProcesoCompra &&
                              im.IDCONTRATO == idContrato &&
                              im.NUMERONOTIFICACION == numeroNotificacion &&
                              im.IDESTADO == idEstado
                        select new BaseInformeMuestra
                        {
                            Idinforme = im.IDINFORME,
                            Numeronotificacion = im.NUMERONOTIFICACION ?? 0,
                            IdProducto = im.IDPRODUCTO ?? 0,
                            Lote = im.LOTE,
                            Renglon = im.RENGLON,
                            NombreComercial = im.NOMBRECOMERCIAL,
                            LaboratorioFabricante = im.LABORATORIOFABRICANTE,
                            NumeroUnidades = im.NUMEROUNIDADES ?? 0,
                            FechaFabricacion = im.FECHAFABRICACION,
                            FechaVencimiento = im.FECHAVENCIMIENTO,
                            FechaNotificacion = im.FECHANOTIFICACION,
                            CantidadAEntregar = im.CANTIDADAENTREGAR ?? 0,
                            CantidadRemitida = im.CANTIDADREMITIDA ?? 0,
                            UnidadMedida = cp.DESCRIPCION,
                            CorrProducto = cp.CORRPRODUCTO,
                            IdInspector = im.IDINSPECTOR ?? 0,
                            ObservacionNotificacion = im.OBSERVACION,
                            ObservacionCoordinador = im.OBSERVACIONCOORDINADOR,
                            ObservacionAsignacion = im.OBSERVACIONASIGNACION,
                            FechaAsignacion = im.FECHAASIGNACION
                        }).ToList();
            }
        }

        public static List<BaseInformeMuestra> ObtenerTodos(int idProveedor, int idProcesoCompra, int idEstablecimiento,
          int idContrato, int numeroNotificacion, decimal idEstado, int idInspector)
        {
            using (var db = new SinabEntities())
            {
                return (from im in db.SAB_LAB_INFORMEMUESTRAS
                        join cp in db.vv_CATALOGOPRODUCTOS on im.IDPRODUCTO equals cp.IDPRODUCTO
                        where im.IDPROVEEDOR == idProveedor &&
                              im.IDESTABLECIMIENTO == idEstablecimiento &&
                              im.IDPROCESOCOMPRA == idProcesoCompra &&
                              im.IDCONTRATO == idContrato &&
                              im.NUMERONOTIFICACION == numeroNotificacion &&
                              im.IDESTADO == idEstado &&
                              im.IDINSPECTOR == idInspector
                        select new BaseInformeMuestra
                        {
                            Idinforme = im.IDINFORME,
                            Numeronotificacion = im.NUMERONOTIFICACION ?? 0,
                            IdProducto = im.IDPRODUCTO ?? 0,
                            Lote = im.LOTE,
                            Renglon = im.RENGLON,
                            NombreComercial = im.NOMBRECOMERCIAL,
                            LaboratorioFabricante = im.LABORATORIOFABRICANTE,
                            NumeroUnidades = im.NUMEROUNIDADES ?? 0,
                            FechaFabricacion = im.FECHAFABRICACION,
                            FechaVencimiento = im.FECHAVENCIMIENTO,
                            FechaNotificacion = im.FECHANOTIFICACION,
                            CantidadAEntregar = im.CANTIDADAENTREGAR ?? 0,
                            CantidadRemitida = im.CANTIDADREMITIDA ?? 0,
                            UnidadMedida = cp.DESCRIPCION,
                            CorrProducto = cp.CORRPRODUCTO,
                            IdInspector = im.IDINSPECTOR ?? 0,
                            ObservacionNotificacion = im.OBSERVACION,
                            ObservacionCoordinador = im.OBSERVACIONCOORDINADOR,
                            ObservacionAsignacion = im.OBSERVACIONASIGNACION,
                            Observacion = im.OBSERVACION,
                            FechaAsignacion = im.FECHAASIGNACION
                        }).ToList();
            }
        }

        public static List<rptInformeMuestras_Result> ObtenerTodos(int idInforme, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return db.rptInformeMuestras(idInforme, idEstablecimiento).ToList();
            }
        }

        public static void ActualizarTodos(int idProveedor, int idProcesoCompra, int idEstablecimiento,
            int idContrato, int idEstado)
        {
            using (var t = new TransactionScope())
            {
                try
                {
                    using (var db = new SinabEntities())
                    {
                        db.SAB_LAB_INFORMEMUESTRAS.
                            Where(itm => itm.IDPROVEEDOR == idProveedor &&
                                         itm.IDPROCESOCOMPRA == idProcesoCompra &&
                                         itm.IDESTABLECIMIENTO == idEstablecimiento &&
                                         itm.IDCONTRATO == idContrato).
                            ToList().
                            ForEach(itm => itm.IDESTADO = idEstado);
                        db.SaveChanges();
                    }
                    t.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void ActualizarTodos(int idProveedor, int idProcesoCompra, int idEstablecimiento,
            int idContrato, int numeroNotificacion, int idEstado)
        {
            using (var t = new TransactionScope())
            {
                try
                {
                    using (var db = new SinabEntities())
                    {
                        db.SAB_LAB_INFORMEMUESTRAS.
                            Where(itm => itm.IDPROVEEDOR == idProveedor &&
                                         itm.IDPROCESOCOMPRA == idProcesoCompra &&
                                         itm.IDESTABLECIMIENTO == idEstablecimiento &&
                                         itm.IDCONTRATO == idContrato &&
                                         itm.NUMERONOTIFICACION == numeroNotificacion).
                            ToList().
                            ForEach(itm => itm.IDESTADO = idEstado);
                        db.SaveChanges();
                    }
                    t.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void BorrarTodos(int idProveedor, int idProcesoCompra, int idEstablecimiento,
            int idContrato, decimal idEstado)
        {
            using (var db = new SinabEntities())
            {
                db.SAB_LAB_INFORMEMUESTRAS.
                    Where(itm => itm.IDPROVEEDOR == idProveedor &&
                                 itm.IDPROCESOCOMPRA == idProcesoCompra &&
                                 itm.IDESTABLECIMIENTO == idEstablecimiento &&
                                 itm.IDCONTRATO == idContrato &&
                                 itm.IDESTADO == idEstado).
                    ToList().
                    ForEach(itm => db.SAB_LAB_INFORMEMUESTRAS.DeleteObject(itm));
                db.SaveChanges();
            }
        }



        public static SAB_LAB_INFORMEMUESTRAS Obtener(int idInforme, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idInforme, idEstablecimiento);
            }
        }

        public static SAB_LAB_INFORMEMUESTRAS Obtener(SinabEntities db, int idInforme, int idEstablecimiento)
        {
            return
                db.SAB_LAB_INFORMEMUESTRAS.FirstOrDefault(
                    n => n.IDINFORME == idInforme && n.IDESTABLECIMIENTO == idEstablecimiento);
        }


        public static void ActualizarPaso1(SinabEntities db, SAB_LAB_INFORMEMUESTRAS notificacion)
        {
            try
            {
                var rec = Obtener(db, notificacion.IDINFORME, notificacion.IDESTABLECIMIENTO);
                if (rec == null) return;
                rec.IDPRODUCTO = notificacion.IDPRODUCTO;
                rec.RENGLON = notificacion.RENGLON;
                rec.NOMBREMEDICAMENTO = notificacion.NOMBREMEDICAMENTO;
                rec.NOMBRECOMERCIAL = notificacion.NOMBRECOMERCIAL;
                rec.LABORATORIOFABRICANTE = notificacion.LABORATORIOFABRICANTE;
                rec.LOTE = notificacion.LOTE;
                rec.NUMEROUNIDADES = notificacion.NUMEROUNIDADES;
                rec.FECHAFABRICACION = notificacion.FECHAFABRICACION;
                rec.FECHAVENCIMIENTO = notificacion.FECHAVENCIMIENTO;
                rec.CANTIDADAENTREGAR = notificacion.CANTIDADAENTREGAR;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }


        public static void Actualizar(int idInforme, int idEstablecimiento, int estado)
        {
            try
            {
                using (var db = new SinabEntities())
                {
                    var obj = Obtener(db, idInforme, idEstablecimiento);
                    if (obj == null) throw new ArgumentNullException("No se encontró la notificación con id: " + idInforme);
                    obj.IDESTADO = estado;
                    obj.AUUSUARIOMODIFICACION = Membresia.ObtenerUsuario().NombreUsuario;
                    obj.AUFECHAMODIFICACION = DateTime.Now;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public static void Borrar(int idEstablecimiento, int idInforme)
        {
            try
            {
                using (var db = new SinabEntities())
                {
                    var rec = Obtener(db, idInforme, idEstablecimiento);
                    if (rec == null) throw new ArgumentNullException("No se encontró la notificación con id: " + idInforme);
                    db.SAB_LAB_INFORMEMUESTRAS.DeleteObject(rec);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public static bool ExisteNumeroInforme(int idInforme, int idestablecimiento, string noInforme)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_LAB_INFORMEMUESTRAS.Any(im => im.NUMEROINFORME == noInforme && im.IDINFORME != idInforme && im.IDESTABLECIMIENTO != idestablecimiento);
            }
        }

        public static string ObtenerModificativas(int idEstablecimiento, int idInforme)
        {
            using (var db = new SinabEntities())
            {
                try
                {
                    return (from im in db.SAB_LAB_INFORMEMUESTRAS
                            where im.IDESTABLECIMIENTO == idEstablecimiento && im.IDINFORME == idInforme
                            join mcp in db.SAB_UACI_MODIFICATIVASCONTRATOPRODUCTO on
                                new
                                {
                                    idEstablecimiento = (int)im.IDESTABLECIMIENTOCONTRATO,
                                    idProveedor = im.IDPROVEEDOR ?? 0,
                                    idContrato = im.IDCONTRATO ?? 0,
                                    renglon = im.RENGLON
                                } equals
                                new
                                {
                                    idEstablecimiento = mcp.IDESTABLECIMIENTO,
                                    idProveedor = mcp.IDPROVEEDOR,
                                    idContrato = mcp.IDCONTRATO,
                                    renglon = (int)mcp.RENGLON
                                }
                            select mcp.SAB_UACI_MODIFICATIVASCONTRATO.NUMEROMODIFICATIVA).FirstOrDefault();
                }
                catch
                {
                    return string.Empty;
                }
            }
        }


    }


}
