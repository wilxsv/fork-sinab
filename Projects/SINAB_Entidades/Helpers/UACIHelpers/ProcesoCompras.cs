using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class ProcesoCompras
    {
        public static List<BaseProcesoCompra> ObtenerTodosFrm(decimal idEstablecimiento, decimal idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                var res = (from pc in db.SAB_UACI_PROCESOCOMPRAS
                           join dc in db.SAB_UACI_DOCUMENTOSPROCESOSCOMPRA on
                           new { pc.IDESTABLECIMIENTO, pc.IDPROCESOCOMPRA } equals
                           new { dc.IDESTABLECIMIENTO, dc.IDPROCESOCOMPRA }

                           join sp in db.SAB_EST_SOLICITUDESPROCESOCOMPRAS on
                           new { pc.IDPROCESOCOMPRA, pc.IDESTABLECIMIENTO } equals
                           new { sp.IDPROCESOCOMPRA, sp.IDESTABLECIMIENTO }

                           join em in db.SAB_CAT_EMPLEADOS on
                           pc.IDTITULAR equals em.IDEMPLEADO

                           where pc.IDESTABLECIMIENTO == idEstablecimiento && pc.IDPROCESOCOMPRA == idProcesoCompra

                           select new BaseProcesoCompra()
                           {

                               IdEstablecimiento = pc.IDESTABLECIMIENTO,
                               IdProcesoCompra = pc.IDPROCESOCOMPRA,
                               CodigoLicitacion = pc.CODIGOLICITACION,
                               TituloLicitacion = pc.TITULOLICITACION,
                               DescripcionLicitacion = pc.DESCRIPCIONLICITACION,

                               NTitular = em.NOMBRE,
                               ATitular = em.APELLIDO,
                               CargoTitular = em.SAB_CAT_CARGOS.DESCRIPCION,

                               LugarRecepcionOferta = pc.LUGARRECEPCIONOFERTA,
                               DireccionRecepcionOferta = pc.DIRECCIONRECEPCIONOFERTA,
                               FechaHoraInicioRecepcion = pc.FECHAHORAINICIORECEPCION != null ? pc.FECHAHORAINICIORECEPCION.Value : DateTime.MinValue,
                               FechaHoraFinRecepcion = pc.FECHAHORAFINRECEPCION != null ? pc.FECHAHORAFINRECEPCION.Value : DateTime.MinValue,
                               LugarAperturaBase = pc.LUGARAPERTURABASE,
                               DireccionAperturaBase = pc.DIRECCIONAPERTURABASE,
                               FechaHoraInicioApertura = pc.FECHAHORAINICIOAPERTURA != null ? pc.FECHAHORAINICIOAPERTURA.Value : DateTime.MinValue,
                               FechaHoraFinApertura = pc.FECHAHORAFINAPERTURA != null ? pc.FECHAHORAFINAPERTURA.Value : DateTime.MinValue,
                               FechaInicioAclaraciones = pc.FECHAINICIOACLARACIONES != null ? pc.FECHAINICIOACLARACIONES.Value : DateTime.MinValue,
                               FechaFinAclaraciones = pc.FECHAINICIOACLARACIONES != null ? pc.FECHAFINACLARACIONES.Value : DateTime.MinValue,
                               PorcentajeIndiceSolvencia = pc.PORCENTAJEINDICESOLVENCIA ?? 0,
                               PorcentajeCapitalTrabajo = pc.PORCENTAJECAPITALTRABAJO ?? 0,
                               PorcentajeEndeudamiento = pc.PORCENTAJEENDEUDAMIENTO ?? 0,
                               PorcentajeReferenciasBanc = pc.PORCENTAJEREFERENCIASBANC ?? 0,
                               GarantiaMantenimientoOferta = pc.GARANTIAMTTOVIGENCIA ?? 0,
                               GarantiaMttoVigencia = pc.GARANTIAMTTOVIGENCIA ?? 0,
                               LugarMtto = pc.LUGARMTTO,
                               GarantiaCumplimientoValor = pc.GARANTIACUMPLIMIENTOVALOR ?? 0,
                               GarantiaCumplimientoEntrega = pc.GARANTIACUMPLIMIENTOENTREGA ?? 0,
                               GarantiaCumplimientoVigencia = pc.GARANTIACUMPLIMIENTOVIGENCIA ?? 0,
                               LugarCumplimiento = pc.LUGARCUMPLIMIENTO,
                               GarantiaCalidadValor = pc.GARANTIACALIDADVALOR ?? 0,
                               GarantiaCalidadEntrega = pc.GARANTIACALIDADENTREGA ?? 0,
                               GarantiaCalidadVigencia = pc.GARANTIACALIDADVIGENCIA ?? 0,
                               LugarCalidad = pc.LUGARCALIDAD,
                               GarantiaAnticipoValor = pc.GARANTIAANTICIPOVALOR ?? 0,
                               GarantiaAnticipoEntregas = pc.GARANTIAANTICIPOENTREGAS ?? 0,
                               GarantiaAnticipoVigencia = pc.GARANTIAANTICIPOVIGENCIA ?? 0,
                               LugarAnticipo = pc.LUGARANTICIPO,
                               FechaAprobacionBase = pc.FECHAAPROBACIONBASE != null ? pc.FECHAAPROBACIONBASE.Value : DateTime.MinValue,
                               DocumentoBase = dc.SAB_CAT_DOCUMENTOSBASE.DESCRIPCION,
                               TipoDocumento = dc.SAB_CAT_DOCUMENTOSBASE.SAB_CAT_TIPODOCUMENTOBASE.DESCRIPCION
                           });

                var res2 = res.Distinct().ToList();
                foreach (var d in res2)
                {
                    var nombres = from spc in db.SAB_EST_SOLICITUDESPROCESOCOMPRAS
                                  where spc.IDPROCESOCOMPRA == d.IdProcesoCompra && spc.IDESTABLECIMIENTO == d.IdEstablecimiento
                                  orderby spc.IDESTABLECIMIENTO
                                  select spc.SAB_EST_SOLICITUDES.SAB_CAT_DEPENDENCIAS.NOMBRE;

                    d.Dependencia = string.Join(", ", nombres.ToList());
                }

                return res2;
            }
        }


        public static List<BaseProcesoCompra> ObtenerTodosFrm()
        {
            using (var db = new SinabEntities())
            {
                var res = from pc in db.SAB_UACI_PROCESOCOMPRAS
                          join es in db.SAB_CAT_ESTABLECIMIENTOS on pc.IDESTABLECIMIENTO equals es.IDESTABLECIMIENTO
                          where pc.IDESTABLECIMIENTO != 661 && pc.IDESTADOPROCESOCOMPRA == (int)EnumHelpers.EstadosProcesoCompra.GenerarContratos
                          //todo: 661? ask for it!
                          select new BaseProcesoCompra()
                          {
                              IdEstablecimiento = pc.IDESTABLECIMIENTO,
                              IdProcesoCompra = pc.IDPROCESOCOMPRA,
                              Establecimiento = es.NOMBRE,
                              Descripcion = pc.SAB_CAT_TIPOCOMPRAS.DESCRIPCION,
                              CodigoLicitacion = pc.CODIGOLICITACION,
                              TituloLicitacion = pc.TITULOLICITACION,
                              DescripcionLicitacion = pc.DESCRIPCIONLICITACION,
                              NumeroResolucion = pc.NUMERORESOLUCION,
                              FechaCreacion = pc.AUFECHACREACION != null ? pc.AUFECHACREACION.Value : DateTime.MinValue,
                          };
                return res.OrderByDescending(pc => pc.IdProcesoCompra).ToList();

            }

        }

        public static List<prcObtenerProcesosCompra_Result> ObtenerTodosPrc(int idEstablecimiento, int idAlmacen)
        {
            List<prcObtenerProcesosCompra_Result> recs;
            using (var db = new SinabEntities())
            {
                recs = db.prcObtenerProcesosCompra(idEstablecimiento, idAlmacen).ToList();
            }
            return recs;

        }

        public static List<SAB_UACI_PROCESOCOMPRAS> ObtenerTodosEstablecimiento(int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_UACI_PROCESOCOMPRAS.Where(pc => pc.IDESTABLECIMIENTO == idEstablecimiento)
                    .OrderByDescending(pc => pc.FECHAPUBLICACION)
                    .ToList();
            }
        }



        public static List<SAB_UACI_PROCESOCOMPRAS> ObtenerTodos(int idEstablecimiento, int estatus)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodos(db, idEstablecimiento, estatus);
            }
        }

        public static List<SAB_UACI_PROCESOCOMPRAS> ObtenerTodos(SinabEntities db, int idEstablecimiento, int estatus)
        {
            return db.SAB_UACI_PROCESOCOMPRAS.Where(pc => pc.IDESTABLECIMIENTO == idEstablecimiento && pc.IDESTADOPROCESOCOMPRA == estatus)
                    .OrderByDescending(pc => pc.FECHAPUBLICACION)
                    .ToList();
        }



        public static List<SAB_UACI_PROCESOCOMPRAS> ObtenerTodos(int status)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_UACI_PROCESOCOMPRAS.Where(pc => pc.IDESTADOPROCESOCOMPRA == status)
                    .OrderByDescending(pc => pc.FECHAPUBLICACION)
                    .ToList();
            }
        }

        public static void CargarAdjudicadosALista(ref DropDownList lista)
        {
            using (var db = new SinabEntities())
            {
                var res = (from pc in db.SAB_UACI_PROCESOCOMPRAS
                           join ad in db.SAB_UACI_ADJUDICACION
                               on new { pc.IDESTABLECIMIENTO, pc.IDPROCESOCOMPRA } equals
                               new { ad.IDESTABLECIMIENTO, ad.IDPROCESOCOMPRA }
                           join spc in db.SAB_EST_SOLICITUDESPROCESOCOMPRAS
                               on new { pc.IDESTABLECIMIENTO, pc.IDPROCESOCOMPRA } equals
                               new { spc.IDESTABLECIMIENTO, spc.IDPROCESOCOMPRA }
                           join es in db.SAB_CAT_ESTABLECIMIENTOS on pc.IDESTABLECIMIENTO equals es.IDESTABLECIMIENTO
                           where ad.CANTIDADFIRME > 0 && spc.SAB_EST_SOLICITUDES.IDCLASESUMINISTRO == 1
                           orderby pc.AUFECHACREACION descending
                           select new BaseProcesoCompra()
                           {
                               IdEstablecimiento = pc.IDESTABLECIMIENTO,
                               IdProcesoCompra = pc.IDPROCESOCOMPRA,
                               // = pc.IDPROCESOCOMPRA,
                               CodigoLicitacion = pc.CODIGOLICITACION,
                               TituloLicitacion = pc.DESCRIPCIONLICITACION
                               //  identidad
                           }).Distinct();
                lista.DataSource = res;
                lista.DataTextField = "DescripcionProcesoCompra";
                lista.DataValueField = "IdEstablecimientoIdProcesoCompra";


                lista.DataBind();
            }
        }

        public static void CargarProcesosCompraALista(int idEstablecimiento, int estado, ref DropDownList lista)
        {

            var res = idEstablecimiento > 0 ? ObtenerTodos(idEstablecimiento, estado) : ObtenerTodos(estado);
            lista.DataSource = res;
            lista.DataTextField = "DescripcionProcesoCompra";
            lista.DataValueField = "IDPROCESOCOMPRA";
            lista.DataBind();
        }

        public static List<SAB_UACI_PROCESOCOMPRAS> ObtenerTodos(EncabezadoProcesoCompra entidad,
            bool evalFechaRet, bool evalFechaRec, List<int> estados, int? idUsuarioComision, int? idEncargado)
        {
            using (var db = new SinabEntities())
            {
                var res = db.SAB_UACI_PROCESOCOMPRAS
                    .Include(pc => pc.SAB_CAT_ESTADOPROCESOSCOMPRAS)
                    .Include(pc => pc.SAB_CAT_EMPLEADOS)
                    .Include(pc => pc.SAB_UACI_OBSERVACIONPROCESOSCOMPRAS)
                    .Include(pc => pc.SAB_EST_SOLICITUDESPROCESOCOMPRAS)
                    .Include(pc => pc.SAB_EST_SOLICITUDESPROCESOCOMPRAS.Select(spc => spc.SAB_EST_SOLICITUDES)).Where(pc => pc.IDESTABLECIMIENTO == entidad.IdEstablecimiento);

                if (estados == null)
                {
                    res = entidad.IdEstadoProcesoCompra > 0
                        ? res.Where(pc => pc.IDESTADOPROCESOCOMPRA == entidad.IdEstadoProcesoCompra)
                        : res.Where(pc => pc.IDESTADOPROCESOCOMPRA != entidad.IdEstadoProcesoCompra);
                }
                else
                {
                    res = res.Where(pc => estados.Contains((int)pc.IDESTADOPROCESOCOMPRA));
                }

                if (evalFechaRet)
                {
                    res = res.Where(pc =>
                        pc.FECHAHORAINICIORETIRO <= DateTime.Now &&
                        pc.FECHAHORAINICIOAPERTURA >= DateTime.Now);
                }

                if (evalFechaRec)
                {
                    res = res.Where(pc =>
                        pc.FECHAHORAINICIORECEPCION <= DateTime.Now &&
                        pc.FECHAHORAFINRECEPCION >= DateTime.Now);
                }

                if (idUsuarioComision != null && idUsuarioComision > 0)
                {
                    if (entidad.IdEncargado > 0)
                    {
                        res = res.Where(pc =>
                            pc.IDENCARGADO == entidad.IdEncargado ||
                            pc.IDJEFEUACI == entidad.IdEncargado ||
                            pc.SAB_UACI_COMISIONPROCESOCOMPRA.Any(
                                cpc =>
                                    cpc.SAB_UACI_COMISIONESEVALUADORAS.ESTADO == 1 &&
                                    cpc.SAB_UACI_COMISIONESEVALUADORAS.ESALTONIVEL == 1));
                    }
                    else
                    {
                        res = res.Where(pc => pc.SAB_UACI_COMISIONPROCESOCOMPRA.Any(
                        cpc =>
                            cpc.SAB_UACI_COMISIONESEVALUADORAS.ESTADO == 1 &&
                            cpc.SAB_UACI_COMISIONESEVALUADORAS.ESALTONIVEL == 1));
                    }

                }
                else if (idEncargado > 0)
                {
                    res = res.Where(pc => pc.IDENCARGADO == idEncargado || pc.IDJEFEUACI == idEncargado);
                }
                //order  by FECHAINICIOPROCESOCOMPRA desc 
                var objres = res.OrderByDescending(r => r.FECHAINICIOPROCESOCOMPRA).ToList();

                return objres;
            }
        }

        public static string ObtenerContratos(SAB_UACI_CONTRATOS contrato)
        {
            var recs = new StringBuilder();
            if (!contrato.SAB_UACI_CONTRATOSPROCESOCOMPRA.Any()) return "--";

            contrato.SAB_UACI_CONTRATOSPROCESOCOMPRA.ToList()
                .ForEach(rdc => recs.Append(rdc.SAB_UACI_PROCESOCOMPRAS.NUMERORESOLUCION + ", "));

            var res = recs.ToString();
            res = res.Remove(res.Length - 2);
            return res;
        }

        public static SAB_UACI_PROCESOCOMPRAS Obtener(SAB_UACI_PROCESOCOMPRAS proceso)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, proceso);

            }
        }

        public static SAB_UACI_PROCESOCOMPRAS Obtener(SinabEntities db, SAB_UACI_PROCESOCOMPRAS proceso)
        {
            return db.SAB_UACI_PROCESOCOMPRAS.Include(pc => pc.SAB_CAT_ESTABLECIMIENTOS).FirstOrDefault(
                        pc =>
                            pc.IDPROCESOCOMPRA == proceso.IDPROCESOCOMPRA &&
                            pc.IDESTABLECIMIENTO == proceso.IDESTABLECIMIENTO);
        }

        public static SAB_UACI_PROCESOCOMPRAS Obtener(int idEstablecimiento, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idEstablecimiento, idProcesoCompra);
            }
        }

        public static SAB_UACI_PROCESOCOMPRAS Obtener(SinabEntities db, int idEstablecimiento, int idProcesoCompra)
        {
            return db.SAB_UACI_PROCESOCOMPRAS.Include(pc => pc.SAB_CAT_ESTABLECIMIENTOS).FirstOrDefault(
                        pc =>
                            pc.IDPROCESOCOMPRA == idProcesoCompra &&
                            pc.IDESTABLECIMIENTO == idEstablecimiento);
        }

        public static BaseProcesoCompra ObtenerBase(int idEstablecimiento, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                return (from pc in db.SAB_UACI_PROCESOCOMPRAS
                        join es in db.SAB_CAT_ESTABLECIMIENTOS on pc.IDESTABLECIMIENTO equals es.IDESTABLECIMIENTO
                        where pc.IDESTABLECIMIENTO == idEstablecimiento && pc.IDPROCESOCOMPRA == idProcesoCompra

                        select new BaseProcesoCompra()
                        {
                            IdEstablecimiento = pc.IDESTABLECIMIENTO,
                            IdProcesoCompra = pc.IDPROCESOCOMPRA,
                            Establecimiento = es.NOMBRE,
                            Descripcion = pc.SAB_CAT_TIPOCOMPRAS.DESCRIPCION,
                            CodigoLicitacion = pc.CODIGOLICITACION,
                            TituloLicitacion = pc.TITULOLICITACION,
                            DescripcionLicitacion = pc.DESCRIPCIONLICITACION,
                            NumeroResolucion = pc.NUMERORESOLUCION,
                            FechaCreacion = pc.AUFECHACREACION != null ? pc.AUFECHACREACION.Value : DateTime.Now,
                            FechaHoraInicioRecepcion = pc.FECHAHORAINICIORECEPCION.Value,
                            FechaHoraFinRecepcion = pc.FECHAHORAFINRECEPCION.Value

                        }).FirstOrDefault();
            }
        }


        public static BaseProcesoCompra ObtenerTipoCompra(int idEstablecimiento, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                return (from pc in db.SAB_UACI_PROCESOCOMPRAS
                        join tp in db.SAB_CAT_TIPOCOMPRAS
                            on new { idTipoCompra = pc.IDTIPOCOMPRAEJECUTAR ?? 0 } equals new { idTipoCompra = tp.IDTIPOCOMPRA }
                        where pc.IDESTABLECIMIENTO == idEstablecimiento && pc.IDPROCESOCOMPRA == idProcesoCompra
                        select new BaseProcesoCompra()
                        {
                            Descripcion = tp.DESCRIPCION,
                            CodigoLicitacion = pc.CODIGOLICITACION,
                            IdProcesoCompra = pc.IDPROCESOCOMPRA,
                            TituloLicitacion = pc.TITULOLICITACION,
                            DescripcionLicitacion = pc.DESCRIPCIONLICITACION,
                            IdModalidadCompra = tp.IDMODALIDADCOMPRA
                        }).FirstOrDefault();
            }
        }


        public static void Actualizar(SAB_UACI_PROCESOCOMPRAS proceso)
        {
            try
            {
                using (var db = new SinabEntities())
                {
                    //si no existe el proceso compra
                    Actualizar(db, proceso);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Actualizar(SinabEntities db, SAB_UACI_PROCESOCOMPRAS proceso)
        {
            if (proceso.IDPROCESOCOMPRA == 0)
            {
                Agregar(db, proceso);
            }
            else
            {
                //si ya existe
                var existente =
                    db.SAB_UACI_PROCESOCOMPRAS.FirstOrDefault(
                        pc =>
                            pc.IDPROCESOCOMPRA == proceso.IDPROCESOCOMPRA &&
                            pc.IDESTABLECIMIENTO == proceso.IDESTABLECIMIENTO);
                if (existente == null) throw new Exception("No se pudo encontrar el proceso de compra requerido");

                existente.IDTITULAR = proceso.IDTITULAR;
                existente.IDENTIDADSOLICITA = proceso.IDENTIDADSOLICITA;
                existente.FECHAENVIONOTA = proceso.FECHAENVIONOTA;
                existente.COSTOBASE = proceso.COSTOBASE;
                existente.LUGARAPERTURABASE = proceso.LUGARAPERTURABASE;
                existente.DIRECCIONAPERTURABASE = proceso.DIRECCIONAPERTURABASE;
                existente.IDMUNICIPIOAPERTURA = proceso.IDMUNICIPIOAPERTURA;
                existente.FECHAHORAINICIOAPERTURA = proceso.FECHAHORAINICIOAPERTURA;
                existente.FECHAHORAFINAPERTURA = proceso.FECHAHORAFINAPERTURA;
                existente.FECHAREALIZADAAPERTURA = proceso.FECHAREALIZADAAPERTURA;
                existente.FECHAPUBLICACION = proceso.FECHAPUBLICACION;
                existente.LUGARRETIROBASE = proceso.LUGARRETIROBASE;
                existente.FECHAHORAINICIORETIRO = proceso.FECHAHORAINICIORETIRO;
                existente.FECHAHORAFINRETIRO = proceso.FECHAHORAFINRETIRO;
                existente.LUGARRECEPCIONOFERTA = proceso.LUGARRECEPCIONOFERTA;
                existente.DIRECCIONRECEPCIONOFERTA = proceso.DIRECCIONRECEPCIONOFERTA;
                existente.IDMUNICIPIORECEPCION = proceso.IDMUNICIPIORECEPCION;
                existente.FECHAHORAINICIORECEPCION = proceso.FECHAHORAINICIORECEPCION;
                existente.FECHAHORAFINRECEPCION = proceso.FECHAHORAFINRECEPCION;
                existente.CODIGOLICITACION = proceso.CODIGOLICITACION;
                existente.TITULOLICITACION = proceso.TITULOLICITACION;
                existente.DESCRIPCIONLICITACION = proceso.DESCRIPCIONLICITACION;
                existente.IDTIPOCOMPRASUGERIDO = proceso.IDTIPOCOMPRASUGERIDO;
                existente.IDTIPOCOMPRAEJECUTAR = proceso.IDTIPOCOMPRAEJECUTAR;
                existente.IDESTADOPROCESOCOMPRA = proceso.IDESTADOPROCESOCOMPRA;
                existente.IDENCARGADO = proceso.IDENCARGADO;
                existente.IDJEFEUACI = proceso.IDJEFEUACI;
                existente.FECHAINICIOPROCESOCOMPRA = proceso.FECHAINICIOPROCESOCOMPRA;
                existente.FECHAELABORACIONBASE = proceso.FECHAELABORACIONBASE;
                existente.FECHAAPROBACIONBASE = proceso.FECHAAPROBACIONBASE;
                existente.FECHAINICIOACLARACIONES = proceso.FECHAINICIOACLARACIONES;
                existente.FECHAFINACLARACIONES = proceso.FECHAFINACLARACIONES;
                existente.FECHAINICIOCONSULTA = proceso.FECHAINICIOCONSULTA;
                existente.FECHAFINCONSULTA = proceso.FECHAFINCONSULTA;
                existente.PORCENTAJEFINANCIERO = proceso.PORCENTAJEFINANCIERO;
                existente.PORCENTAJEINDICESOLVENCIA = proceso.PORCENTAJEINDICESOLVENCIA;
                existente.PORCENTAJECAPITALTRABAJO = proceso.PORCENTAJECAPITALTRABAJO;
                existente.PORCENTAJEENDEUDAMIENTO = proceso.PORCENTAJEENDEUDAMIENTO;
                existente.PORCENTAJEREFERENCIASBANC = proceso.PORCENTAJEREFERENCIASBANC;
                existente.GARANTIAMTTOENTREGA = proceso.GARANTIAMTTOENTREGA;
                existente.GARANTIAMTTOVIGENCIA = proceso.GARANTIAMTTOVIGENCIA;
                existente.LUGARMTTO = proceso.LUGARMTTO;
                existente.GARANTIACUMPLIMIENTOVALOR = proceso.GARANTIACUMPLIMIENTOVALOR;
                existente.GARANTIACUMPLIMIENTOENTREGA = proceso.GARANTIACUMPLIMIENTOENTREGA;
                existente.GARANTIACUMPLIMIENTOVIGENCIA = proceso.GARANTIACUMPLIMIENTOVIGENCIA;
                existente.LUGARCUMPLIMIENTO = proceso.LUGARCUMPLIMIENTO;
                existente.GARANTIACALIDADVALOR = proceso.GARANTIACALIDADVALOR;
                existente.GARANTIACALIDADENTREGA = proceso.GARANTIACALIDADENTREGA;
                existente.GARANTIACALIDADVIGENCIA = proceso.GARANTIACALIDADVIGENCIA;
                existente.LUGARCALIDAD = proceso.LUGARCALIDAD;
                existente.FECHAINICIOANALISIS = proceso.FECHAINICIOANALISIS;
                existente.FECHAFINANALISIS = proceso.FECHAFINANALISIS;
                existente.FECHAFIRMARESOLUCION = proceso.FECHAFIRMARESOLUCION;
                existente.NUMERORESOLUCION = proceso.NUMERORESOLUCION;
                existente.FECHALIMITEACEPTACION = proceso.FECHALIMITEACEPTACION;
                existente.FECHANOTIFICACION = proceso.FECHANOTIFICACION;
                existente.FECHAPUBLICACIONRESOLUCION = proceso.FECHAPUBLICACIONRESOLUCION;
                existente.MEDIOSDIVULGACION = proceso.MEDIOSDIVULGACION;
                existente.FECHAFIRMAACEPTACION = proceso.FECHAFIRMAACEPTACION;
                existente.VIGENCIACOTIZACION = proceso.VIGENCIACOTIZACION;
                existente.GARANTIACUMPLIMIENTOORDENCOMPRA = proceso.GARANTIACUMPLIMIENTOORDENCOMPRA;
                existente.TIEMPOENTREGA = proceso.TIEMPOENTREGA;
                existente.FECHAFINRECOMENDACION = proceso.FECHAFINRECOMENDACION;
                existente.FECHAFINEXAMEN = proceso.FECHAFINEXAMEN;
                existente.IDTITULARADJUDICACION = proceso.IDTITULARADJUDICACION;
                existente.ACTAAPERTURA = proceso.ACTAAPERTURA;
                existente.OBSERVACIONESACTA = proceso.OBSERVACIONESACTA;
                existente.GARANTIAANTICIPOVALOR = proceso.GARANTIAANTICIPOVALOR;
                existente.GARANTIAANTICIPOENTREGAS = proceso.GARANTIAANTICIPOENTREGAS;
                existente.GARANTIAANTICIPOVIGENCIA = proceso.GARANTIAANTICIPOVIGENCIA;
                existente.LUGARANTICIPO = proceso.LUGARANTICIPO;
                existente.AUUSUARIOCREACION = proceso.AUUSUARIOCREACION;
                existente.AUFECHACREACION = proceso.AUFECHACREACION;
                existente.AUUSUARIOMODIFICACION = proceso.AUUSUARIOMODIFICACION;
                existente.AUFECHAMODIFICACION = proceso.AUFECHAMODIFICACION;
                existente.ESTASINCRONIZADA = proceso.ESTASINCRONIZADA;
                db.SaveChanges();
            }

        }

        public static void Agregar(SinabEntities db, SAB_UACI_PROCESOCOMPRAS proceso)
        {
            var idMax =
                    db.SAB_UACI_PROCESOCOMPRAS.Where(pc => pc.IDESTABLECIMIENTO == proceso.IDESTABLECIMIENTO)
                        .DefaultIfEmpty()
                        .Max(s => s == null ? 0 : s.IDPROCESOCOMPRA);

            proceso.IDPROCESOCOMPRA = idMax + 1;
            try
            {
                db.SAB_UACI_PROCESOCOMPRAS.AddObject(proceso);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int? ObtenerTipoSuministro(int idProcesocompra, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTipoSuministro(db, idProcesocompra, idEstablecimiento);
            }
        }

        public static int? ObtenerTipoSuministro(SinabEntities db, int idProcesocompra, int idEstablecimiento)
        {
            return (from pc in db.SAB_UACI_PROCESOCOMPRAS
                    join spc in db.SAB_EST_SOLICITUDESPROCESOCOMPRAS on new { pc.IDPROCESOCOMPRA, pc.IDESTABLECIMIENTO }
                        equals new { spc.IDPROCESOCOMPRA, spc.IDESTABLECIMIENTO }
                    where pc.IDESTADOPROCESOCOMPRA == idProcesocompra && pc.IDESTABLECIMIENTO == idEstablecimiento
                    select spc.SAB_EST_SOLICITUDES.IDCLASESUMINISTRO).FirstOrDefault();
        }

        public static decimal ObtenerMontoTotal(int idEstablecimiento, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                    return (from pc in db.SAB_UACI_PROCESOCOMPRAS
                        where pc.IDPROCESOCOMPRA == idProcesoCompra && pc.IDESTABLECIMIENTO == idEstablecimiento
                        join spc in db.SAB_EST_SOLICITUDESPROCESOCOMPRAS
                            on new {pc.IDPROCESOCOMPRA, pc.IDESTABLECIMIENTO}
                            equals new {spc.IDPROCESOCOMPRA, spc.IDESTABLECIMIENTO}
                        join s in db.SAB_EST_SOLICITUDES
                            on new {spc.IDSOLICITUD, IdEstablecimiento = spc.IDESTABLECIMIENTOSOLICITUD}
                            equals new {s.IDSOLICITUD, IdEstablecimiento = s.IDESTABLECIMIENTO}
                        select s.MONTOSOLICITADO).Sum()??0;
            }
        }

        public static List<SAB_UACI_PROCESOCOMPRAS> ObtenerTodosConsolidados(int idestablecimiento, int idprocesocompra)
        {
            using (var db = new SinabEntities())
            {
                return
                    db.SAB_UACI_PROCESOCOMPRAS.Where(
                        pc => pc.IDESTABLECIMIENTO == idestablecimiento && pc.IDPROCESOCOMPRA == idprocesocompra)
                        .ToList();
            }
        }
    }
}
