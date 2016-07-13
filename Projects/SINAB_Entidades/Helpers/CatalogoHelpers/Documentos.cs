using System;
using System.Collections.Generic;
using System.Linq;
using SINAB_Entidades.Tipos;
using SINAB_Utils;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public class Documentos
    {

        //idalmacen = 21
        //idestado = 1


        public static List<DetalleProductosEnDocumento_Result> ObtenerDetalleProductos(int idEstablecimiento, int idMovimiento, int idTipoTransaccion)
        {
            var db = new SinabEntities();
            var ds = db.DetalleProductosEnDocumento(idEstablecimiento, idMovimiento, idTipoTransaccion);
            return ds.ToList();
        }

        public static List<DetalleProductosMovimiento> ObtenerDetalleProductos(List<SAB_ALM_DETALLEMOVIMIENTOS> lista)
        {
            var listado = new List<DetalleProductosMovimiento>();
            var db = new SinabEntities();
            var c = 1;
            /*
             isnull(L.CODIGO, '(N/A)') CODIGO, 
        case when L.CODIGO is null then
		 case when L.DETALLE is null then '(N/A)' else L.DETALLE end 
		else L.CODIGO + isnull(L.DETALLE, '') 
		end CODIGODETALLE, 
             */
            foreach (var fusion in lista.Select(itm => (from l in db.SAB_ALM_LOTES
                join vv in db.vv_CATALOGOPRODUCTOS on l.IDPRODUCTO equals vv.IDPRODUCTO
                join ff in db.SAB_CAT_FUENTEFINANCIAMIENTOS on l.IDFUENTEFINANCIAMIENTO equals ff.IDFUENTEFINANCIAMIENTO
                join ub in db.SAB_ALM_UBICACIONESPRODUCTOS on new
                {
                    l.IDALMACEN, l.IDLOTE, l.IDPRODUCTO
                } equals new
                {
                    ub.IDALMACEN, IDLOTE = ub.IDLOTE??0, ub.IDPRODUCTO
                }
                where l.IDALMACEN == itm.IDALMACEN && l.IDLOTE == itm.IDLOTE
                select new  DetalleProductosMovimiento()
                {
                    IdEstablecimiento = itm.IDESTABLECIMIENTO,
                    IdTipoTransaccion = itm.IDTIPOTRANSACCION,
                    IdProducto = l.IDPRODUCTO,
                    IdLote =l.IDLOTE,
                    IdAlmacen = l.IDALMACEN,
                    Secuencia = c,
                    Cantidad = itm.CANTIDAD,
                    Codigo = vv.CORRPRODUCTO,
                    Desclargo = vv.DESCLARGO,
                    FechaVencimiento = l.FECHAVENCIMIENTO,
                    FuenteFinanciamiento = ff.NOMBRE,
                    UnidadMedida = vv.UNIDADMEDIDA,
                    PrecioLote = l.PRECIOLOTE,
                    Ubicacion = ub.UBICACION,
                    CodigoLote = l.CODIGO,
                    DetalleLote = l.DETALLE,
                    IdDetalleMovimiento = itm.IDDETALLEMOVIMIENTO,
                    IdEstado = true //todo:cambiar dependiendo si existe movimiento o no
                }).FirstOrDefault()))
            {
                listado.Add(fusion);
                c++;
            }
            return listado;
        }

        public static List<Documento> Obtener(int idAlmacen, int grabado, int procesado)
        {
            var error = string.Empty;
            try
            {
                using (var db = new SinabEntities())
                {
                    //var docs = new List<Documento>();
                    var ds = db.SAB_ALM_MOVIMIENTOS.Where(m =>
                        m.IDALMACEN == idAlmacen && 
                        (m.IDESTADO == grabado || m.IDESTADO == procesado) &&
                        m.IDTIPOTRANSACCION == 2 
                        
                        ) 
                        
                        .Select(m => new Documento
                                     {
                                         Movimiento = m,
                                         IdAlmacen = m.IDALMACEN ?? 0,
                                         Anio = m.ANIO ?? 0,
                                         IdVale = m.SAB_ALM_VALESSALIDA.IDVALE,
                                         IdEstablecimiento = m.IDESTABLECIMIENTO,
                                         IdDocumento = m.IDDOCUMENTO ?? 0,
                                         IdMovimiento = m.IDMOVIMIENTO,
                                         ValeAnio = m.SAB_ALM_VALESSALIDA.ANIO,
                                         FechaMovimiento = m.FECHAMOVIMIENTO ?? DateTime.Now,
                                         IdEstado = m.IDESTADO,
                                         Estado = m.SAB_CAT_ESTADOSMOVIMIENTOS.DESCRIPCION,
                                        Renglones = m.SAB_ALM_DETALLEMOVIMIENTOS.Count,
                                         IdEstablecimientoDestino = m.IDESTABLECIMIENTODESTINO?? 0,
                                         Total = (decimal) (m.SAB_ALM_DETALLEMOVIMIENTOS.Any() ? m.SAB_ALM_DETALLEMOVIMIENTOS.Sum(d => d.SAB_ALM_LOTES != null ? d.CANTIDAD*d.SAB_ALM_LOTES.PRECIOLOTE : 0) : 0)
                                        // Detallemovimientos = m.SAB_ALM_DETALLEMOVIMIENTOS.ToList(),
                                        

                                     }).OrderByDescending(d => d.IdDocumento).ThenByDescending(d => d.FechaMovimiento).ToList(); 

                    foreach (var d in ds)
                    {
                        d.EstablecimientoDestino = SetEstablecimiento(db, d.Movimiento);
                        d.DeRequisicion = TieneRequisicion(db, d.IdVale, d.ValeAnio, d.IdAlmacen);
                        d.CodigoRequisicion = ObtenerCodigoRequisicion(db, d.IdVale, d.ValeAnio, d.IdAlmacen);
                    }
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string SetEstablecimiento( SinabEntities db, SAB_ALM_MOVIMIENTOS m)
        {
            var res = string.Empty;
            if (m.ID_LUGAR_ENTREGA_HOSPITAL == null && m.IDALMACENDESTINO == null)
            {
                var dato =  db.SAB_CAT_ESTABLECIMIENTOS.FirstOrDefault(mov => mov.IDESTABLECIMIENTO == m.IDESTABLECIMIENTODESTINO);
                if (dato != null) return dato.NOMBRE;

            }else if (m.IDALMACENDESTINO == null)
            {
                return m.SAB_CAT_LUGARES_ENTREGA_HOSPITALES.NOMBRE_LUGAR_ENTREGA_HOSPITAL;
            }
            else
            {
                var dato2 = db.SAB_CAT_ALMACENES.FirstOrDefault(al => al.IDALMACEN == m.IDALMACENDESTINO);
                if(dato2 != null) return dato2.NOMBRE;
            }

            return res;
        }

        private static bool TieneRequisicion(SinabEntities db, int idvale, int anio, int idalmacen)
        {
            var code = string.Format("{0}/{1}", idvale, anio);
            return db.SAB_FARM_REQUISICION.Any(r => r.IdVale == code && r.IdAlmacen == idalmacen);
        }

        private static string ObtenerCodigoRequisicion(SinabEntities db, int idvale, int anio, int idalmacen)
        {
            var code = string.Format("{0}/{1}", idvale, anio);
            try
            {
                return db.SAB_FARM_REQUISICION.FirstOrDefault(r => r.IdVale == code && r.IdAlmacen == idalmacen).CodigoRequisicion;
            }
            catch (Exception)
            {

                return string.Empty;
            }
            
        }

        public string ObtenerDocumentosAceptados(int idAlmacen, int procesado)
        {
            var db = new SinabEntities();
            
            var counter = 0;

            var ds = db.SAB_ALM_MOVIMIENTOS.Where(m =>
                    m.IDALMACEN == idAlmacen && m.IDESTADO == procesado &&
                    m.IDTIPOTRANSACCION == 2).ToList();

           
            foreach (var mov in ds.Where(m => m.IDESTADO == (int)EnumHelpers.EstadosMovimiento.EnProceso))
            {
                try
                {
                    var idvale = mov.SAB_ALM_VALESSALIDA.IDVALE;
                    var nuevoestado = db.SAB_FARM_TRANSACION.FirstOrDefault(t => t.IdVale == idvale);

                    if (nuevoestado == null) continue;
                    if (nuevoestado.IdEstado != ((char)EnumHelpers.RequisicionEstados.Aceptado).ToString()) continue;

                    mov.IDESTADO = (int)EnumHelpers.EstadosMovimiento.AceptadoPorDependecia;
                    //db.SaveChanges();

                    counter += 1;

                }
                catch (Exception ex)
                {
                    string msj;
                    if (counter > 0) msj = string.Format("Alerta: {0} Vales de Salida autorizados para cierre desde dependencias. No fue posible actualizar todos los datos desde dependencia. Excepción: {1}", counter, ex.Message);
                    msj = string.Format("Error: No fue posible actualizar los datos de Vales de Salida desde dependencia. Excepción: {0}", ex.Message);

                    return msj;
                }
            }
            return counter > 0 ? string.Format("{0} Vales de Salida autorizados para cierre desde dependencias", counter) : string.Empty;
        }

    }
}
