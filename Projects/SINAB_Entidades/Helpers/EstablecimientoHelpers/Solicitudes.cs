﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class Solicitudes
    {


        /// <summary>
        /// Obtiene todas las solicitudes que aun no han pasado a la UACI
        /// </summary>
        /// <returns>Listado de solicitudes pendientes de proceso de compra</returns>
        public static IQueryable<ConsultaSolicitudes> Consultar()
        {
            using (var db = new SinabEntities())
            {
                return
                    db.SAB_EST_SOLICITUDES.Select(
                        s =>
                        new ConsultaSolicitudes
                        {
                            Id = s.IDSOLICITUD,
                            Correlativo = s.CORRELATIVO,
                            Fecha = s.FECHASOLICITUD,
                            Suministros = s.SAB_CAT_SUMINISTROS.DESCRIPCION,
                            Entregas = s.ENTREGAS ?? 0,
                            MontoSolicitado = s.MONTOSOLICITADO ?? 0,
                            Solicitante = s.EMPLEADOSOLICITANTE,
                            Tipo = s.COMPRACONJUNTA == 0 ? "Individual" : "Conjunta",
                            IdEstado = s.IDESTADO,
                            UnidadTecnica = s.SAB_CAT_DEPENDENCIAS.NOMBRE
                        });
            }

        }

        /*
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
         */

        
        public static List<BaseDetalleSolicitud> ObtenerReporte(int idSolicitud, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                var res = (from ds in db.SAB_EST_DETALLESOLICITUDES
                           let entrega = ds.SAB_EST_SOLICITUDES.SAB_EST_ENTREGAS.FirstOrDefault(en => en.NUMEROENTREGA == ds.NUMEROENTREGAS)
                           join vv in db.vv_CATALOGOPRODUCTOS on ds.IDPRODUCTO equals vv.IDPRODUCTO
                           where ds.IDSOLICITUD == idSolicitud && ds.IDESTABLECIMIENTO == idEstablecimiento
                           select new BaseDetalleSolicitud()
                           {
                               Solicitud = ds.SAB_EST_SOLICITUDES.IDSOLICITUD,
                               IdEstablecimiento = ds.SAB_EST_SOLICITUDES.IDESTABLECIMIENTO,
                               Codigo = ds.SAB_EST_SOLICITUDES.CORRELATIVO,
                               Fecha = (DateTime)ds.SAB_EST_SOLICITUDES.FECHASOLICITUD,
                               Plazo = ds.SAB_EST_SOLICITUDES.PLAZOENTREGA ?? 0,
                               PeriodoUtilizacion = ds.SAB_EST_SOLICITUDES.PERIODOUTILIZACION ?? 0,
                               MontoSolicitado = ds.SAB_EST_SOLICITUDES.MONTOSOLICITADO ?? 0,
                               MontoDisponible = ds.SAB_EST_SOLICITUDES.MONTODISPONIBLE ?? 0,
                               Observacion = ds.SAB_EST_SOLICITUDES.OBSERVACION,
                               CompraConjunta = ds.SAB_EST_SOLICITUDES.COMPRACONJUNTA ?? 0,

                               NombreSolicita = ds.SAB_EST_SOLICITUDES.EMPLEADOSOLICITANTE,
                               CargoSolicita = ds.SAB_EST_SOLICITUDES.CARGOSOLICITANTE,

                               NombreTecnica = ds.SAB_EST_SOLICITUDES.EMPLEADOAREATECNICA ?? string.Empty,
                               CargoTecnica = ds.SAB_EST_SOLICITUDES.AreaTecnicaCargo ?? string.Empty,

                               NombreAutoriza = ds.SAB_EST_SOLICITUDES.EMPLEADOAUTORIZA ?? string.Empty,
                               CargoAutoriza = ds.SAB_EST_SOLICITUDES.AutorizaCargo,

                               NombreCertifica = ds.SAB_EST_SOLICITUDES.FondosNombre,
                               CargoCertifica = ds.SAB_EST_SOLICITUDES.FondosCargo,
                               CifradoPresupuestario = ds.SAB_EST_SOLICITUDES.CIFRADOPRESUPUESTARIO,
                               CorrelativoUFI = ds.SAB_EST_SOLICITUDES.CorrelativoGeneral,
                               Estado = ds.SAB_EST_SOLICITUDES.IDESTADO ?? 0,
                               UnidadTecnica =
                                   db.SAB_CAT_DEPENDENCIAS.FirstOrDefault(
                                       d => d.IDDEPENDENCIA == ds.SAB_EST_SOLICITUDES.IDUNIDADTECNICA).NOMBRE,

                               Establecimiento = ds.SAB_EST_SOLICITUDES.SAB_CAT_ESTABLECIMIENTOS.NOMBRE,
                               Suministro = vv.DESCSUMINISTRO,
                               //Suminitro2 = ds.SAB_EST_SOLICITUDES.SAB_CAT_SUMINISTROS.DESCRIPCION,
                               Dependencia = ds.SAB_EST_SOLICITUDES.SAB_CAT_DEPENDENCIAS.NOMBRE,
                               Renglon = (ds.Correlativo == 0 || ds.Correlativo == null)?ds.RENGLON:ds.Correlativo??0,
                               IdProducto = ds.IDPRODUCTO ?? 0,
                               Cantidad = ds.CANTIDAD ?? 0,
                               EspecificacionesTecnicas = ds.ESPECIFICACIONTECNICA ?? string.Empty,
                               PresupuestoUnitario = ds.PRESUPUESTOUNITARIO ?? 0,
                               PresupuestoTotal = ds.PRESUPUESTOTOTAL ?? 0,
                               NumeroEntregas = (byte) (entrega!= null? entrega.NUMEROENTREGA : 0),
                               DiasEntregas =entrega != null? entrega.DIASENTREGA??0:0,
                               // DiasEntregas = ds.SAB_EST_SOLICITUDES.SAB_EST_ENTREGAS.FirstOrDefault(en)
                               FuenteFinanciamiento =
                                   ds.SAB_EST_SOLICITUDES.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.FirstOrDefault()
                                       .SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE,
                               Unidad = vv.DESCRIPCION,
                               CodigoProducto = vv.CORRPRODUCTO,
                               Producto = vv.DESCLARGO,
                               CodigoNacionesUnidas = vv.CODIGONACIONESUNIDAS ?? string.Empty,




                           }).OrderBy(i => i.Renglon).ToList();

                return res;
            }

        }

        



        #region SOLICITUD
        /// <summary>
        /// Obtiene el objecto SOLICITUD
        /// </summary>
        /// <param name="db">contexto</param>
        /// <param name="idEstablecimiento">establecimiento de solicitud</param>
        /// <param name="idSolicitud">identificador de solicitud</param>
        /// <returns>solicitud requerida</returns>
        public static SAB_EST_SOLICITUDES Obtener(SinabEntities db, int idEstablecimiento, long idSolicitud)
        {
            return db.SAB_EST_SOLICITUDES

                .FirstOrDefault(s => s.IDESTABLECIMIENTO == idEstablecimiento
                                                                   && s.IDSOLICITUD == idSolicitud);

        }
        public static SAB_EST_SOLICITUDES Obtener(int idEstablecimiento, long idSolicitud)
        {
            var db = new SinabEntities();
            return db.SAB_EST_SOLICITUDES
                .Include(s => s.SAB_EST_DETALLESOLICITUDES)
                .Include(s => s.SAB_EST_ADMINISTRADORESCONTRATO)
                .Include(s => s.SAB_EST_PRODUCTOSSOLICITUD)
                .FirstOrDefault(s => s.IDESTABLECIMIENTO == idEstablecimiento
                                                              && s.IDSOLICITUD == idSolicitud);

        }

        public static SAB_EST_SOLICITUDES Obtener(int idEstablecimiento, long idSolicitud, string usr)
        {
            using (var db = new SinabEntities())
            {
                return
                    db.SAB_EST_SOLICITUDES.Include(s => s.SAB_EST_DETALLESOLICITUDES).Include(s => s.SAB_EST_ADMINISTRADORESCONTRATO).Include(s => s.SAB_EST_ENTREGAS)
                        .FirstOrDefault(
                            s =>
                                s.IDESTABLECIMIENTO == idEstablecimiento && s.IDSOLICITUD == idSolicitud &&
                                s.AUUSUARIOCREACION == usr);
            }
        }

        public static SAB_EST_SOLICITUDES Obtener(SinabEntities db, SAB_EST_SOLICITUDES solicitud)
        {
            return Obtener(db, solicitud.IDESTABLECIMIENTO, solicitud.IDSOLICITUD);
        }



        #endregion SOLICITUD

        /// <summary>
        /// Obtiene el Maximo Id de la tabla solicitues filtrado por establecimiento
        /// </summary>
        /// <param name="idEstablecimiento">filtro</param>
        /// <returns>long: Maximo Id</returns>
        public static long ObtenerMaximoId(int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerMaximoId(db, idEstablecimiento);
            }
        }

        public static long ObtenerMaximoId(SinabEntities db, int idEstablecimiento)
        {
            return (db.SAB_EST_SOLICITUDES.Where(
                    s => s.IDESTABLECIMIENTO == idEstablecimiento).DefaultIfEmpty().Max(s => s == null ? 0 : s.IDSOLICITUD));
        }

        /// <summary>
        /// retorna el correlativo general anual de las solicitudes + 1, si no existe entonces retorna 1
        /// </summary>
        /// <returns></returns>
        public static long ObtenerCorrelativoAnual()
        {
            using (var db = new SinabEntities())
            {
                return ObtenerCorrelativoAnual(db);
            }
        }

        public static long ObtenerCorrelativoAnual(SinabEntities db)
        {

            var solyear =
                db.SAB_EST_SOLICITUDES.Where(s => s.FECHASOLICITUD.HasValue && s.FECHASOLICITUD.Value.Year == DateTime.Now.Year)
                    .OrderByDescending(s => s.FECHASOLICITUD);

            var maxsol = solyear.FirstOrDefault();
            if (maxsol == null || maxsol.CorrelativoGeneral == 0)
            {
                return (solyear.Count() + 1);
            }
            return (maxsol.CorrelativoGeneral + 1);

        }

        /// <summary>
        /// Agrega solicitud a la base de datos
        /// </summary>
        /// <param name="solicitud">Solicitud a agregar</param>
        public static void Agregar(SAB_EST_SOLICITUDES solicitud)
        {
            using (var db = new SinabEntities())
            {
                solicitud.CorrelativoGeneral = ObtenerCorrelativoAnual();
                db.SAB_EST_SOLICITUDES.AddObject(solicitud);
                db.ObjectStateManager.ChangeObjectState(solicitud, EntityState.Added);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Eliminar solicitud
        /// </summary>
        /// <param name="idEstablecimiento"></param>
        /// <param name="idSolicitud"></param>
        public static void Eliminar(int idEstablecimiento, long idSolicitud)
        {
            using (var t = new TransactionScope())
            {
                try
                {
                    using (var db = new SinabEntities())
                    {
                        var rec = Obtener(db, idEstablecimiento, idSolicitud);
                        if (rec == null) return;

                        //borra hijos directos
                        rec.SAB_EST_ADMINISTRADORESCONTRATO.ToList().ForEach(adm => db.SAB_EST_ADMINISTRADORESCONTRATO.DeleteObject(adm));
                        rec.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.ToList().ForEach(ffs => db.SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.DeleteObject(ffs));
                        rec.SAB_EST_ALMACENESENTREGA.ToList().ForEach(ae => db.SAB_EST_ALMACENESENTREGA.DeleteObject(ae));
                        rec.SAB_EST_ENTREGAS.ToList().ForEach(a => db.SAB_EST_ENTREGAS.DeleteObject(a));
                        rec.SAB_EST_PRODUCTOSSOLICITUD.ToList().ForEach(ps => db.SAB_EST_PRODUCTOSSOLICITUD.DeleteObject(ps));
                        //borra el detalle de solicitud e hijos
                        if (rec.SAB_EST_DETALLESOLICITUDES.Any())
                        {
                            var les = rec.SAB_EST_DETALLESOLICITUDES.SelectMany(ds => ds.SAB_EST_ENTREGASOLICITUDES).ToList();
                            foreach (var es in les)
                            {
                                es.SAB_EST_ALMACENESENTREGASOLICITUD.ToList().ForEach(
                                    aes => db.SAB_EST_ALMACENESENTREGASOLICITUD.DeleteObject(aes));
                            }
                            les.ToList().ForEach(es => db.SAB_EST_ENTREGASOLICITUDES.DeleteObject(es));
                            rec.SAB_EST_DETALLESOLICITUDES.ToList().ForEach(ds => db.SAB_EST_DETALLESOLICITUDES.DeleteObject(ds));
                        }
                        //borra la solicitud
                        db.SAB_EST_SOLICITUDES.DeleteObject(rec);

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

        public static List<SAB_UACI_DETALLEPROCESOCOMPRA> GenerarDetallesPC(
            List<SAB_EST_SOLICITUDES> solicitudes)
        {
            var sinorden = solicitudes.SelectMany(s => s.SAB_EST_DETALLESOLICITUDES).ToList();
          //  sinorden = sinorden.OrderBy(ds => ds.RENGLON).ToList();
            return (from d in sinorden
                    group d by d.IDPRODUCTO
                        into grupo
                let sed = sinorden.FirstOrDefault(s => s.IDPRODUCTO == grupo.Key)
                select new SAB_UACI_DETALLEPROCESOCOMPRA()
                               {
                                   CANTIDAD = (decimal)grupo.Sum(g => g.CANTIDAD),
                                   NUMEROENTREGAS = grupo.Max(g => g.NUMEROENTREGAS),
                                   IDPRODUCTO = (long)(grupo.Key),
                                   IDUNIDADMEDIDA = (int)(sed.IDUNIDADMEDIDA)
                               }).ToList();
        }

        #region LICITACIONES


        public static List<SAB_EST_SOLICITUDES> Licitaciones(long idEstablecimiento)
        {
            var db = new SinabEntities();

            return db.SAB_EST_SOLICITUDES.
                Where(s =>
                      s.IDESTADO == 6 &&
                      !(db.SAB_EST_SOLICITUDESPROCESOCOMPRAS.Where(spc =>
                                                                   spc.IDESTABLECIMIENTO == idEstablecimiento &&
                                                                   spc.SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA != 6).
                                                                   Select(spc => spc.IDSOLICITUD)).
                                                                   Contains(s.IDSOLICITUD)
                ).OrderByDescending(s => s.FECHASOLICITUD).ThenBy(s => s.IDSOLICITUD).ToList();
        }

        public static List<SAB_EST_SOLICITUDES> ObtenerTodas(int idEstado, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_EST_SOLICITUDES.Include(b => b.SAB_CAT_DEPENDENCIAS).Where(s =>
                    s.IDESTADO == idEstado &&
                  //  s.IDESTABLECIMIENTO == idEstablecimiento &&
                    s.CORRELATIVO != "").OrderByDescending(s => s.FECHASOLICITUD).ToList();
            }

        }

        public static List<SAB_EST_SOLICITUDES> ObtenerTodas(int idEstado, int idEstablecimiento, int idDependencia)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_EST_SOLICITUDES.Include(b => b.SAB_CAT_DEPENDENCIAS).
                    Where(s =>
                          s.IDESTADO == idEstado &&
                          s.IDESTABLECIMIENTO == idEstablecimiento &&
                          s.IDDEPENDENCIASOLICITANTE == idDependencia &&
                          s.CORRELATIVO != "").
                    OrderByDescending(s => s.FECHASOLICITUD).ToList();
            }
        }

        /// <summary>
        /// Devuelve informacion de la solicitud
        /// </summary>
        /// <param name="valor">identificador del valor</param>
        /// <param name="filtro">identificador del tipob</param>
        /// <param name="idDependecia">identificador de dependencia (opcional)</param>
        /// <returns>Listado con informacion de la solicitud</returns>
        public static List<SAB_EST_SOLICITUDES> ObtenerTodas(string valor, int filtro, int idDependecia = 0)
        {

            using (var db = new SinabEntities())
            {
                IQueryable<SAB_EST_SOLICITUDES> recs = db.SAB_EST_SOLICITUDES
                    .Include(b => b.SAB_CAT_DEPENDENCIAS).Where(b => b.IDUNIDADTECNICA != null);

                if (idDependecia > 0) recs = recs.Where(s => s.IDESTADO != 6 && s.IDDEPENDENCIASOLICITANTE == idDependecia && s.COMPRACONJUNTA != 2);

                if (filtro == 1)
                {
                    if (valor != "!") recs = recs.Where(s => s.CORRELATIVO.Contains(valor));
                }
                else
                {
                    if (valor == "!") return recs.OrderByDescending(s => s.FECHASOLICITUD).ToList();
                    var val = Convert.ToInt32(valor);
                    recs = recs.Where(s => s.IDESTADO == val);
                }

                return recs.OrderByDescending(s => s.FECHASOLICITUD).ToList();
            }

        }

        public static List<SAB_EST_SOLICITUDES> ObtenerTodas(string valor, int filtro, string usuariocreacion, int idDependecia = 0)
        {


            using (var db = new SinabEntities())
            {
                var recs = db.SAB_EST_SOLICITUDES
                    .Include(b => b.SAB_CAT_DEPENDENCIAS).Where(b => b.IDUNIDADTECNICA != null)
                    .Where(s => s.AUUSUARIOCREACION == usuariocreacion);

                //todo: Eliminar IDDEPENDENCIASOLICITANTE del or del where.
                if (idDependecia > 0) recs = recs.Where(s => s.IDESTADO != 6 
                    && (s.IdDependenciaCrea == idDependecia) 
                    && s.COMPRACONJUNTA != 2);

                if (filtro == 1)
                {
                    if (valor != "!") recs = recs.Where(s => s.CORRELATIVO.Contains(valor));
                }
                else
                {
                    if (valor == "!") return recs.OrderByDescending(s => s.FECHASOLICITUD).ToList();
                    var val = Convert.ToInt32(valor);
                    recs = recs.Where(s => s.IDESTADO == val);
                }

                return recs.OrderByDescending(s => s.FECHASOLICITUD).ToList();
            }

        }

        public static List<SAB_EST_SOLICITUDES> ObtenerTodas(int idEstado, int idEstablecimiento, string busqueda, string operador)
        {
            List<SAB_EST_SOLICITUDES> recs;
            using (var db = new SinabEntities())
            {
                switch (operador)
                {
                    case "=":
                        recs = db.SAB_EST_SOLICITUDES.Include(b => b.SAB_CAT_DEPENDENCIAS).Where(s =>
                            s.IDESTADO == idEstado &&
                            s.IDESTABLECIMIENTO == idEstablecimiento &&
                            s.CORRELATIVO == busqueda &&
                          s.CORRELATIVO != "").OrderByDescending(s => s.FECHASOLICITUD).ToList();
                        break;

                    case "<>":
                        recs = db.SAB_EST_SOLICITUDES.Include(b => b.SAB_CAT_DEPENDENCIAS).Where(s =>
                            s.IDESTADO == idEstado &&
                            s.IDESTABLECIMIENTO == idEstablecimiento &&
                            s.CORRELATIVO != busqueda &&
                          s.CORRELATIVO != "").OrderByDescending(s => s.FECHASOLICITUD).ToList();
                        break;
                    default:
                        recs = db.SAB_EST_SOLICITUDES.Include(b => b.SAB_CAT_DEPENDENCIAS).Where(s =>
                            s.IDESTADO == idEstado &&
                            s.IDESTABLECIMIENTO == idEstablecimiento &&
                            s.CORRELATIVO.Contains(busqueda) &&
                          s.CORRELATIVO != "").OrderByDescending(s => s.FECHASOLICITUD).ToList();
                        break;
                }

            }
            return recs;
        }


        //LIBRE GESTION


        public static List<SAB_EST_SOLICITUDES> LicitacionesLG(long idEstablecimiento)
        {
            var db = new SinabEntities();

            return db.SAB_EST_SOLICITUDES.
                Where(s =>
                      s.IDESTADO == 6 &&
                      !(db.SAB_EST_SOLICITUDESPROCESOCOMPRAS.Where(spc =>
                                                                   spc.IDESTABLECIMIENTO == idEstablecimiento &&
                                                                   spc.SAB_UACI_PROCESOCOMPRAS.IDPROCESOCOMPRA != 7).
                                                                   Select(spc => spc.IDSOLICITUD)).
                                                                   Contains(s.IDSOLICITUD)
                ).OrderByDescending(s => s.FECHASOLICITUD).ThenBy(s => s.IDSOLICITUD).ToList();
        }

        public static List<SAB_EST_SOLICITUDES> ObtenerTodasLG(int idEstado, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_EST_SOLICITUDES.Include(b => b.SAB_CAT_DEPENDENCIAS).Where(s =>
                    s.IDESTADO == idEstado &&
                        //  s.IDESTABLECIMIENTO == idEstablecimiento &&
                    s.CORRELATIVO != "").OrderByDescending(s => s.FECHASOLICITUD).ToList();
            }

        }

        public static List<SAB_EST_SOLICITUDES> ObtenerTodasLG(int idEstado, int idEstablecimiento, int idDependencia)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_EST_SOLICITUDES.Include(b => b.SAB_CAT_DEPENDENCIAS).
                    Where(s =>
                          s.IDESTADO == idEstado &&
                          s.IDESTABLECIMIENTO == idEstablecimiento &&
                          s.IDDEPENDENCIASOLICITANTE == idDependencia &&
                          s.CORRELATIVO != "").
                    OrderByDescending(s => s.FECHASOLICITUD).ToList();
            }
        }

        /// <summary>
        /// Devuelve informacion de la solicitud
        /// </summary>
        /// <param name="valor">identificador del valor</param>
        /// <param name="filtro">identificador del tipob</param>
        /// <param name="idDependecia">identificador de dependencia (opcional)</param>
        /// <returns>Listado con informacion de la solicitud</returns>
        public static List<SAB_EST_SOLICITUDES> ObtenerTodasLG(string valor, int filtro, int idDependecia = 0)
        {

            using (var db = new SinabEntities())
            {
                IQueryable<SAB_EST_SOLICITUDES> recsLG = db.SAB_EST_SOLICITUDES
                    .Include(b => b.SAB_CAT_DEPENDENCIAS).Where(b => b.IDUNIDADTECNICA != null);

                if (idDependecia > 0) recsLG = recsLG.Where(s => s.IDESTADO != 7 && s.IDDEPENDENCIASOLICITANTE == idDependecia && s.COMPRACONJUNTA != 2);

                if (filtro == 1)
                {
                    if (valor != "!") recsLG = recsLG.Where(s => s.CORRELATIVO.Contains(valor));
                }
                else
                {
                    if (valor == "!") return recsLG.OrderByDescending(s => s.FECHASOLICITUD).ToList();
                    var val = Convert.ToInt32(valor);
                    recsLG = recsLG.Where(s => s.IDESTADO == val);
                }

                return recsLG.OrderByDescending(s => s.FECHASOLICITUD).ToList();
            }

        }

        public static List<SAB_EST_SOLICITUDES> ObtenerTodasLG(string valor, int filtro, string usuariocreacion, int idDependecia = 0)
        {


            using (var db = new SinabEntities())
            {
                var recsLG = db.SAB_EST_SOLICITUDES
                    .Include(b => b.SAB_CAT_DEPENDENCIAS).Where(b => b.IDUNIDADTECNICA != null)
                    .Where(s => s.AUUSUARIOCREACION == usuariocreacion);

                //todo: Eliminar IDDEPENDENCIASOLICITANTE del or del where.
                if (idDependecia > 0) recsLG = recsLG.Where(s => s.IDESTADO != 7
                    && (s.IdDependenciaCrea == idDependecia)
                    && s.COMPRACONJUNTA != 2);

                if (filtro == 1)
                {
                    if (valor != "!") recsLG = recsLG.Where(s => s.CORRELATIVO.Contains(valor));
                }
                else
                {
                    if (valor == "!") return recsLG.OrderByDescending(s => s.FECHASOLICITUD).ToList();
                    var val = Convert.ToInt32(valor);
                    recsLG = recsLG.Where(s => s.IDESTADO == val);
                }

                return recsLG.OrderByDescending(s => s.FECHASOLICITUD).ToList();
            }

        }

        public static List<SAB_EST_SOLICITUDES> ObtenerTodasLG(int idEstado, int idEstablecimiento, string busqueda, string operador)
        {
            List<SAB_EST_SOLICITUDES> recsLG;
            using (var db = new SinabEntities())
            {
                switch (operador)
                {
                    case "=":
                        recsLG = db.SAB_EST_SOLICITUDES.Include(b => b.SAB_CAT_DEPENDENCIAS).Where(s =>
                            s.IDESTADO == idEstado &&
                            s.IDESTABLECIMIENTO == idEstablecimiento &&
                            s.CORRELATIVO == busqueda &&
                          s.CORRELATIVO != "").OrderByDescending(s => s.FECHASOLICITUD).ToList();
                        break;

                    case "<>":
                        recsLG = db.SAB_EST_SOLICITUDES.Include(b => b.SAB_CAT_DEPENDENCIAS).Where(s =>
                            s.IDESTADO == idEstado &&
                            s.IDESTABLECIMIENTO == idEstablecimiento &&
                            s.CORRELATIVO != busqueda &&
                          s.CORRELATIVO != "").OrderByDescending(s => s.FECHASOLICITUD).ToList();
                        break;
                    default:
                        recsLG = db.SAB_EST_SOLICITUDES.Include(b => b.SAB_CAT_DEPENDENCIAS).Where(s =>
                            s.IDESTADO == idEstado &&
                            s.IDESTABLECIMIENTO == idEstablecimiento &&
                            s.CORRELATIVO.Contains(busqueda) &&
                          s.CORRELATIVO != "").OrderByDescending(s => s.FECHASOLICITUD).ToList();
                        break;
                }

            }
            return recsLG;
        }


        

        #endregion LICITACIONES
    }
}
