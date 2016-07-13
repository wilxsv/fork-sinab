using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Security;
using Microsoft.CSharp;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class DetalleProcesoCompras
    {
        public static void Agregar(int idEstablecimeinto,
            long idProcesoCompra,
            byte idEstadoClasificacion,List<SAB_EST_DETALLESOLICITUDES> detalles)
        {
            var count = 1;
            foreach (var d in detalles)
            {
                var dpc = new SAB_UACI_DETALLEPROCESOCOMPRA()
                {
                    CANTIDAD = d.CANTIDAD ?? 0,
                    IDDETALLE = 0,
                    IDESTABLECIMIENTO = idEstablecimeinto,
                    IDPROCESOCOMPRA = idProcesoCompra,
                    IDPRODUCTO = d.IDPRODUCTO ?? 0,
                    NUMEROENTREGAS = d.NUMEROENTREGAS,
                    IDUNIDADMEDIDA = d.IDUNIDADMEDIDA??0,
                    IDESTADOCALIFICACION = idEstadoClasificacion,
                    RENGLON = count,
                    ESTASINCRONIZADA = 1
                };
                count++;
            }
        }


        public static void ActualizarVarios(List<SAB_UACI_DETALLEPROCESOCOMPRA> detalles)
        {
            using (var db = new SinabEntities())
            {
                detalles.ForEach(d => Actualizar(db, d));
                db.SaveChanges();
            }
        }

        public static void ActualizarVarios(SinabEntities db,
            List<SAB_UACI_DETALLEPROCESOCOMPRA> detalles)
        {
           
                detalles.ForEach(d => Actualizar(db, d));
                db.SaveChanges();
            
        }

        /// <summary>
        /// Asigna los valores por parametros de los detalles que son mandados cuando se inicia el proceso de compra.
        /// Una vez asignados los guarda en la bas de datos.
        /// </summary>
        /// <param name="db">Contexto</param>
        /// <param name="idEstablecimiento">Establecimiento</param>
        /// <param name="idProcesoCompra">Proceso de Compra</param>
        /// <param name="estadoClacificacion">Estado del proceso</param>
        /// <param name="detalles">Listado de los detalles incluidos en el proceso de compra</param>
        public static void AsignaryActualizarVarios(SinabEntities db, 
            int idEstablecimiento, 
            long idProcesoCompra,  
            byte estadoClacificacion, 
            List<SAB_UACI_DETALLEPROCESOCOMPRA> detalles)
        {
            var listaOrdenada = (from d in detalles
                join cp in db.vv_CATALOGOPRODUCTOS on d.IDPRODUCTO equals cp.IDPRODUCTO
                group d by new
                {
                    correlativo = cp.CORRPRODUCTO,
                    detalle = d
                }
                into g
                select new
                {
                    g.Key.correlativo,
                    g.Key.detalle
                }
                ).AsEnumerable()
                .Select(
                    obj => new Tuple<int, SAB_UACI_DETALLEPROCESOCOMPRA>(Convert.ToInt32(obj.correlativo), obj.detalle))
                .OrderBy(obj => obj.Item1).ToList();
            
            var i = 1;
            foreach (var detalle in listaOrdenada.Select(d => d.Item2))
            {
                detalle.IDDETALLE = 0;
                detalle.IDESTABLECIMIENTO = idEstablecimiento;
                detalle.IDPROCESOCOMPRA = idProcesoCompra;
                detalle.IDESTADOCALIFICACION = estadoClacificacion;
                detalle.ESTASINCRONIZADA = 1;
                detalle.RENGLON = i;
                Actualizar(db, detalle);
                i++;
            }
        }
        public static void Actualizar(SinabEntities db, SAB_UACI_DETALLEPROCESOCOMPRA detalle)
        {
            if (detalle.IDDETALLE == 0)
            {
                var idMax =
                    db.SAB_UACI_DETALLEPROCESOCOMPRA.Where(dpc =>
                        dpc.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                        dpc.IDPROCESOCOMPRA == detalle.IDPROCESOCOMPRA &&
                        dpc.IDPRODUCTO == detalle.IDPRODUCTO)
                        .DefaultIfEmpty()
                        .Max(s => s == null ? 0 : s.IDDETALLE);

                detalle.IDDETALLE = idMax + 1;
               db.SAB_UACI_DETALLEPROCESOCOMPRA.AddObject(detalle);
               db.SaveChanges();
            }
            else
            {

                var existente = db.SAB_UACI_DETALLEPROCESOCOMPRA.FirstOrDefault(dpc =>
                    dpc.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                    dpc.IDPROCESOCOMPRA == detalle.IDPROCESOCOMPRA &&
                    dpc.IDDETALLE == detalle.IDDETALLE &&
                    dpc.IDPRODUCTO == detalle.IDPRODUCTO);
                if (existente == null)
                    throw new Exception("No se pudo encontrar el detalle del proceso de compra requerido");

                existente.RENGLON = detalle.RENGLON;
                existente.CANTIDAD = detalle.CANTIDAD;
                existente.NUMEROENTREGAS = detalle.NUMEROENTREGAS;
                existente.IDUNIDADMEDIDA = detalle.IDUNIDADMEDIDA;
                existente.GARANTIAMTTOVALOR = detalle.GARANTIAMTTOVALOR;
                existente.IDESTADOCALIFICACION = detalle.IDESTADOCALIFICACION;
                existente.OBSERVACION = detalle.OBSERVACION;
                existente.OBSERVACIONRECOMENDACION = detalle.OBSERVACIONRECOMENDACION;
                existente.OBSERVACIONADJUDICADA = detalle.OBSERVACIONADJUDICADA;
                existente.OBSERVACIONFIRME = detalle.OBSERVACIONFIRME;
                existente.AUUSUARIOCREACION = detalle.AUUSUARIOCREACION;
                existente.AUFECHACREACION = detalle.AUFECHACREACION;
                existente.AUUSUARIOMODIFICACION = detalle.AUUSUARIOMODIFICACION;
                existente.AUFECHAMODIFICACION = detalle.AUFECHAMODIFICACION;
                existente.ESTASINCRONIZADA = detalle.ESTASINCRONIZADA;
                db.SaveChanges();
            }
            //db.SaveChanges();
        }

        public static void ActualizarGarantia(SinabEntities db, SAB_UACI_DETALLEPROCESOCOMPRA detalle)
        {
            var existente = db.SAB_UACI_DETALLEPROCESOCOMPRA.FirstOrDefault(dpc =>
                dpc.IDESTABLECIMIENTO == detalle.IDESTABLECIMIENTO &&
                dpc.IDPROCESOCOMPRA == detalle.IDPROCESOCOMPRA &&
                dpc.IDPRODUCTO == detalle.IDPRODUCTO);
            if (existente == null)
                throw new Exception("No se pudo encontrar el detalle del proceso de compra requerido");
            existente.GARANTIAMTTOVALOR = detalle.GARANTIAMTTOVALOR;
            existente.AUFECHAMODIFICACION = detalle.AUFECHAMODIFICACION;
            existente.AUUSUARIOMODIFICACION = detalle.AUUSUARIOMODIFICACION;
            db.SaveChanges();
        }

        /// <summary>
        /// Devuelve los elementos para construir el CARTEL DE LICITACION
        /// </summary>
        /// <param name="idestablecimiento"></param>
        /// <param name="idProcesoCompra"></param>
        /// <returns>Lista de tipo BaseDetalleProcesoCompra</returns>
        public static List<BaseDetalleProcesoCompra> Obtener(int idestablecimiento, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                return (from d in db.SAB_UACI_DETALLEPROCESOCOMPRA
                    where d.IDESTABLECIMIENTO == idestablecimiento && d.IDPROCESOCOMPRA == idProcesoCompra
                    join cp in db.vv_CATALOGOPRODUCTOS on d.IDPRODUCTO equals cp.IDPRODUCTO
                    
                    join spc in db.SAB_EST_SOLICITUDESPROCESOCOMPRAS on new{d.IDPROCESOCOMPRA, d.IDESTABLECIMIENTO} equals new{spc.IDPROCESOCOMPRA, spc.IDESTABLECIMIENTO}
                    join ds in db.SAB_EST_DETALLESOLICITUDES on new{IDESTABLECIMIENTO=spc.IDESTABLECIMIENTOSOLICITUD, spc.IDSOLICITUD, d.IDPRODUCTO} equals new{ds.IDESTABLECIMIENTO, ds.IDSOLICITUD, IDPRODUCTO = (long) ds.IDPRODUCTO}
                    select new BaseDetalleProcesoCompra
                    {
                        IdEstablecimiento = d.IDESTABLECIMIENTO,
                        //IdSolicitud = spc.IDSOLICITUD, este campo repite la cantidad de solicitudes que tengan al producto
                        IdProducto = d.IDPRODUCTO,
                        Renglon = d.RENGLON,
                        Codigo = cp.CORRPRODUCTO,
                        Descripcion = cp.DESCLARGO,
                        UnidadMedida = cp.UNIDADMEDIDA,
                        Cantidad = d.CANTIDAD,
                        PrecioUnitario = ds.PRESUPUESTOUNITARIO??0,
                        Entregas = d.NUMEROENTREGAS??0,
                        GarantiaMontoValor = d.GARANTIAMTTOVALOR??0,
                        Monto = (ds.PRESUPUESTOUNITARIO * d.CANTIDAD)??0
                        
                    }).Distinct().OrderBy(ob=>ob.Renglon).ToList();
            }
        }

        public static List<DetalleProcesoCompraAdjudicada> ObtenerSubReporte(decimal idestablecimiento, decimal idprocesocompra)
        {
            using (var db = new SinabEntities())
            {
                var res = (from dof in db.SAB_UACI_DETALLEOFERTA
                    where dof.IDESTABLECIMIENTO == idestablecimiento && dof.IDPROCESOCOMPRA == idprocesocompra
                    let opc = dof.SAB_UACI_OFERTAPROCESOCOMPRA
                    join ca in db.SAB_UACI_ADJUDICACION on
                        new {dof.IDPROCESOCOMPRA, dof.IDESTABLECIMIENTO, dof.IDPROVEEDOR, dof.IDDETALLE} equals
                        new {ca.IDPROCESOCOMPRA, ca.IDESTABLECIMIENTO, ca.IDPROVEEDOR, ca.IDDETALLE}
                    join prv in db.SAB_CAT_PROVEEDORES on opc.IDPROVEEDOR equals prv.IDPROVEEDOR
                    select new DetalleProcesoCompraAdjudicada()
                    {
                        IdEstablecimiento = opc.IDESTABLECIMIENTO,
                        IdProcesoCompra = opc.IDPROCESOCOMPRA,
                        IdProveedor = opc.IDPROVEEDOR,
                        Renglon = dof.RENGLON,
                        PrecioUnitario = dof.PRECIOUNITARIO,
                        OrdenLlegada = opc.SAB_UACI_RECEPCIONOFERTAS.ORDENLLEGADA,
                        CantidadAdjudicada = ca.CANTIDADADJUDICADA ?? 0,
                        Proveedor = prv.NOMBRE
                    }).OrderBy(i => i.OrdenLlegada).ThenBy(i => i.Renglon).ToList();
                return res;
            }

        }
    }

    
}
