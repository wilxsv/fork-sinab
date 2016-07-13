using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using SINAB_Entidades.Helpers.UACIHelpers;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public class Lotes
    {
        /// <summary>
        /// Actualiza las cantidades de los lotes dependiendo del tipo de operacion a realizar. 
        /// Esta funcion no guarda en la base de datos, se debe actualizar fuera del lazo try-catch que la contenga (db.savechanges()).
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="detalle">Detalle del movimiento</param>
        /// <param name="operacion">Contiene las operaciones a relizar sobre los lotes</param>
        public static void Actualizar(SinabEntities db, SAB_ALM_DETALLEMOVIMIENTOS detalle, OperacionesLotes operacion)
        {
            var cantidad = detalle.CANTIDAD;

            var lote =
                db.SAB_ALM_LOTES.FirstOrDefault(l => l.IDALMACEN == detalle.IDALMACEN && l.IDLOTE == detalle.IDLOTE
                                                     &&
                                                     ((l.CANTIDADDISPONIBLE >= cantidad && operacion.CantidadDisponible == 2) ||
                                                      operacion.CantidadDisponible <= 1)
                                                     &&
                                                     ((l.CANTIDADNODISPONIBLE >= cantidad && operacion.CantidadNoDisponible == 2) ||
                                                      operacion.CantidadNoDisponible <= 1)
                                                     &&
                                                     ((l.CANTIDADRESERVADA >= cantidad && operacion.CantidadReservada == 2) ||
                                                      operacion.CantidadReservada <= 1)
                                                     &&
                                                     ((l.CANTIDADVENCIDA >= cantidad && operacion.CantidadVencida == 2) ||
                                                      operacion.CantidadVencida <= 1)
                                                     &&
                                                     ((l.CANTIDADTEMPORAL >= cantidad && operacion.CantidadTemporal == 2) ||
                                                      operacion.CantidadTemporal <= 1)
                    );

            if (lote == null) return;
            //evalua cantidad disponible
            lote.CANTIDADDISPONIBLE = EvaluarCantidades(cantidad, operacion.CantidadDisponible, lote.CANTIDADDISPONIBLE);

            //evalua cantidad no disponible
            lote.CANTIDADNODISPONIBLE = EvaluarCantidades(cantidad, operacion.CantidadNoDisponible,
                                                          lote.CANTIDADNODISPONIBLE);

            //evalua cantidad reservada
            lote.CANTIDADRESERVADA = EvaluarCantidades(cantidad, operacion.CantidadReservada, lote.CANTIDADRESERVADA);

            //evalua cantidad vencida
            lote.CANTIDADVENCIDA = EvaluarCantidades(cantidad, operacion.CantidadVencida, lote.CANTIDADVENCIDA);

            //evalua cantidad temporal
            lote.CANTIDADTEMPORAL = EvaluarCantidades(cantidad, operacion.CantidadTemporal, lote.CANTIDADTEMPORAL);

            //la db se debe actualizar fuera de esta funcion
        }
       


        /// <summary>
        /// Actualiza las cantidades de los lotes dependiendo del tipo de operacion a realizar. 
        /// Esta funcion no guarda en la base de datos, se debe actualizar fuera del lazo try-catch que la contenga (db.savechanges()).
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="detalle">Detalle del movimiento. Contiene las operaciones a relizar sobre los lotes (suma:1, resta:2)</param>
        public static void Actualizar(SinabEntities db, SAB_ALM_DETALLEMOVIMIENTOS detalle)
        {
            var cantidad = detalle.CANTIDAD;
            var operacion = detalle.SAB_ALM_DETALLEMOVIMIENTOLOTES.FirstOrDefault();
            if (operacion == null)
            {
                return;
            }

            var lote =
                db.SAB_ALM_LOTES.FirstOrDefault(l => l.IDALMACEN == detalle.IDALMACEN && l.IDLOTE == detalle.IDLOTE
                                                     &&
                                                     ((l.CANTIDADDISPONIBLE >= cantidad && operacion.DISPONIBLE == 2) ||
                                                      operacion.DISPONIBLE <= 1)
                                                     &&
                                                     ((l.CANTIDADNODISPONIBLE >= cantidad && operacion.NODISPONIBLE == 2) ||
                                                      operacion.NODISPONIBLE <= 1)
                                                     &&
                                                     ((l.CANTIDADRESERVADA >= cantidad && operacion.RESERVADA == 2) ||
                                                      operacion.RESERVADA <= 1)
                                                     &&
                                                     ((l.CANTIDADVENCIDA >= cantidad && operacion.VENCIDA == 2) ||
                                                      operacion.VENCIDA <= 1)
                                                     &&
                                                     ((l.CANTIDADTEMPORAL >= cantidad && operacion.TEMPORAL == 2) ||
                                                      operacion.TEMPORAL <= 1)
                    );

            if (lote == null)
            {
                throw new Exception("Error: La cantidad Requerida para un producto no puede ser mayor que la cantidad disponible en el lote." +
                                    "Por favor verifique las existencias en el Lote, esta operación no puede continuar" +
                                    "No. del renglón: "+detalle.RENGLON+", cantidad: "+detalle.CANTIDAD.ToString());
            }
            //evalua cantidad disponible
            lote.CANTIDADDISPONIBLE = EvaluarCantidades(cantidad, operacion.DISPONIBLE, lote.CANTIDADDISPONIBLE);

            //evalua cantidad no disponible
            lote.CANTIDADNODISPONIBLE = EvaluarCantidades(cantidad, operacion.NODISPONIBLE,
                                                          lote.CANTIDADNODISPONIBLE);

            //evalua cantidad reservada
            lote.CANTIDADRESERVADA = EvaluarCantidades(cantidad, operacion.RESERVADA, lote.CANTIDADRESERVADA);

            //evalua cantidad vencida
            lote.CANTIDADVENCIDA = EvaluarCantidades(cantidad, operacion.VENCIDA, lote.CANTIDADVENCIDA);

            //evalua cantidad temporal
            lote.CANTIDADTEMPORAL = EvaluarCantidades(cantidad, operacion.TEMPORAL, lote.CANTIDADTEMPORAL);
            lote.AUUSUARIOMODIFICACION = Membresia.ObtenerUsuario().USUARIO;
            lote.AUFECHAMODIFICACION = DateTime.Now;
            db.SaveChanges();
        }

        /// <summary>
        /// Devuelve el listado de lotes filtrado por los parametros de la funcion 
        /// </summary>
        /// <param name="idAlmacen">Id de almacen</param>
        /// <param name="idSuministro">Id de suministro</param>
        /// <param name="idProducto">Id de producto</param>
        /// <param name="corrProducto">Código de producto</param>
        /// <param name="tipoFiltro">Tipo de filtro</param>
        /// <returns></returns>
        public static List<FiltrarLotes_Result> ObtenerLotesFiltrados(int idAlmacen, int idSuministro, int idProducto, string corrProducto, int tipoFiltro)
        {

            var res = new List<FiltrarLotes_Result>();
            using (var db = new SinabEntities())
            {
               
                var producto = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(p => (p.CORRPRODUCTO == corrProducto || p.IDPRODUCTO == idProducto)
                                                                           && (p.IDSUMINISTRO == idSuministro || p.IDSUMINISTRO == 0));
                if (producto != null)
                    res = db.FiltrarLotes(tipoFiltro, idProducto, corrProducto, idAlmacen, idSuministro).ToList();
            }
            return res;
        }

        public static List<LotesFiltrados> ObtenerLotesFiltrados(int idAlmacen, int idSuministro, int idProducto, DateTime fechaMovimiento, int filtro)
        {
            var res = new List<LotesFiltrados>();
            using (var db = new SinabEntities())
            {
                //id de transacciones que afectan inventario
                var trans = new List<int> {8, 14, 16, 17};

                //obtenemos el producto
                var producto = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(p => (p.IDPRODUCTO == idProducto)
                                                                           && (p.IDSUMINISTRO == idSuministro || p.IDSUMINISTRO == 0));
                if (producto == null) return res;

                res = (from l in db.SAB_ALM_LOTES
                    join dm in db.SAB_ALM_DETALLEMOVIMIENTOS on new {l.IDLOTE, l.IDPRODUCTO} equals
                        new {IDLOTE = dm.IDLOTE.Value, dm.IDPRODUCTO}
                    join up in db.SAB_ALM_UBICACIONESPRODUCTOS on new {l.IDLOTE, l.IDPRODUCTO, l.IDALMACEN} equals
                        new {IDLOTE = up.IDLOTE.Value, up.IDPRODUCTO, up.IDALMACEN}
                    where l.IDPRODUCTO == producto.IDPRODUCTO && l.IDALMACEN == idAlmacen && l.ESTADISPONIBLE == 1 &&
                    (((filtro == 1 && l.CANTIDADDISPONIBLE > 0) || (filtro == 2 && l.CANTIDADNODISPONIBLE > 0) ||
                    (filtro ==3 && l.CANTIDADVENCIDA > 0) || (filtro == 4 && l.CANTIDADRESERVADA > 0) ||
                    (filtro == 5 && l.CANTIDADTEMPORAL > 0) || (filtro == 6 && (l.CANTIDADDISPONIBLE>0 || l.CANTIDADVENCIDA >0 )))
                    ||
                    (filtro == 0 
                    && (l.CANTIDADDISPONIBLE > 0 || l.CANTIDADNODISPONIBLE > 0 || l.CANTIDADVENCIDA >0 || l.CANTIDADRESERVADA >0 || l.CANTIDADTEMPORAL > 0))) 
                    && dm.SAB_ALM_MOVIMIENTOS.FECHAMOVIMIENTO <= fechaMovimiento && trans.Contains(dm.IDTIPOTRANSACCION)
                       select new LotesFiltrados()
                           {
                               IDLOTE = l.IDLOTE,
                               CODIGO = l.CODIGO ,
                               IDPRODUCTO = l.IDPRODUCTO,
                               CORRPRODUCTO = producto.CORRPRODUCTO,
                               DESCLARGO = producto.DESCLARGO,
                               FUENTEFINANCIAMIENTO = l.SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE,
                               FILTRO = filtro,
                               CANTIDADDISPONIBLE = l.CANTIDADDISPONIBLE,
                               CANTIDADVENCIDA = l.CANTIDADVENCIDA,
                               CANTIDADRESERVADA = l.CANTIDADRESERVADA,
                               CANTIDADNODISPONIBLE = l.CANTIDADNODISPONIBLE,
                               DETALLE = l.DETALLE,
                               UNIDADMEDIDA = producto.DESCRIPCION,
                               PRECIOLOTE = (decimal) l.PRECIOLOTE,
                               UBICACION = up.UBICACION,
                               FECHAVENCIMIENTO = (DateTime) (l.FECHAVENCIMIENTO??DateTime.MinValue),
                               CANTIDADDECIMAL = producto.CANTIDADDECIMAL
                           }).Distinct().ToList().OrderBy(o => o.FECHAVENCIMIENTO).ToList();
                //case when L.CODIGO is null then case when L.DETALLE is null then '(N/A)' else L.DETALLE end else L.CODIGO + isnull(L.DETALLE, '') end CODIGODETALLE, 


            }
            return res;
        }


        public static List<LotesFiltrados> ObtenerLotesFiltrados(int idEstablecimiento, int idAlmacen, int idSuministro,
            int idEspecificoGastos, int idGrupo, int idFuenteFinanciamiento,
            int idGrupoFuenteFinanciamiento, int idResponsableDistribucion)
        {
            using (var db = new SinabEntities())
            {

                var res = (from l in db.SAB_ALM_LOTES
                    join cp in db.vv_CATALOGOPRODUCTOS
                        on l.IDPRODUCTO equals cp.IDPRODUCTO
                    join ae in db.SAB_CAT_ALMACENESESTABLECIMIENTOS
                        on l.IDALMACEN equals ae.IDALMACEN
                    join up in db.SAB_ALM_UBICACIONESPRODUCTOS
                        on new {l.IDALMACEN, IDLOTE = (long?) l.IDLOTE} equals new {up.IDALMACEN, up.IDLOTE} into superg

                    from g in superg.DefaultIfEmpty()
                    where (idSuministro == 0 || cp.IDSUMINISTRO == idSuministro) &&
                          (idEspecificoGastos == 0 || cp.IDESPECIFICOGASTO == idEspecificoGastos) &&
                          (idGrupo == 0 || cp.IDGRUPO == idGrupo) &&
                          (idEstablecimiento == 0 || ae.IDESTABLECIMIENTO == idEstablecimiento) &&
                          (idAlmacen == 0 || l.IDALMACEN == idAlmacen) &&
                          (idFuenteFinanciamiento == 0 || l.IDFUENTEFINANCIAMIENTO == idFuenteFinanciamiento) &&
                          (idResponsableDistribucion == 0 || l.IDRESPONSABLEDISTRIBUCION == idResponsableDistribucion) &&
                          (idGrupoFuenteFinanciamiento == 0 ||
                           l.SAB_CAT_FUENTEFINANCIAMIENTOS.IDGRUPO == idGrupoFuenteFinanciamiento) &&
                          (l.CANTIDADDISPONIBLE > 0 || l.CANTIDADNODISPONIBLE > 0 || l.CANTIDADVENCIDA > 0 ||
                           l.CANTIDADRESERVADA > 0 || l.CANTIDADTEMPORAL > 0) &&
                          l.ESTADISPONIBLE == 1 
                          orderby g.IDPRODUCTO
                    select new LotesFiltrados()
                           {
                               IDESTABLECIMIENTO = (Int32) ae.IDESTABLECIMIENTO,
                               IDALMACEN = l.IDALMACEN,
                               IDSUMINISTROS = cp.IDSUMINISTRO,
                               IDGRUPOFUENTEFINANCIAMIENTO = (short) (l.SAB_CAT_FUENTEFINANCIAMIENTOS.IDGRUPO??0),
                               IDPRODUCTO = l.IDPRODUCTO,
                               IDGRUPO = cp.IDGRUPO,
                               IDESPECIFICOGASTO = (short) (cp.IDESPECIFICOGASTO??0),
                               IDFUENTEFINANCIAMIENTO = l.IDFUENTEFINANCIAMIENTO,
                               IDRESPONSABLEDISTRIBUCION = l.IDRESPONSABLEDISTRIBUCION,
                               ESTADISPONIBLE = l.ESTADISPONIBLE,
                               CODIGO = l.CODIGO,
                               DETALLE = l.DETALLE,
                               FECHAVENCIMIENTO = (DateTime) (l.FECHAVENCIMIENTO ?? DateTime.MinValue),
                               NOMBRE = l.SAB_CAT_ALMACENES.NOMBRE,
                               CORRPRODUCTO = cp.CORRPRODUCTO,
                               DESCLARGO = cp.DESCLARGO,
                               UNIDADMEDIDA = SqlFunctions.StringConvert((double) cp.IDUNIDADMEDIDA),
                               CORRGRUPO = cp.CORRGRUPO,
                               DESCGRUPO = cp.DESCGRUPO,
                               PRECIOLOTE = (decimal) l.PRECIOLOTE,
                               NOMBRERESPONSABLE = l.SAB_CAT_RESPONSABLEDISTRIBUCION.NOMBRE,
                               NOMBRECORTORESPONSABLE = l.SAB_CAT_RESPONSABLEDISTRIBUCION.NOMBRECORTO,
                               NOMBREFUENTE = l.SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE,
                               CANTIDADDISPONIBLE = l.CANTIDADDISPONIBLE,
                               MONTODISPONIBLE = (decimal) (l.CANTIDADDISPONIBLE*l.PRECIOLOTE),
                               CANTIDADNODISPONIBLE = l.CANTIDADNODISPONIBLE,
                               MONTONODISPONIBLE = (decimal) (l.CANTIDADNODISPONIBLE*l.PRECIOLOTE),
                               CANTIDADVENCIDA = l.CANTIDADVENCIDA,
                               MONTOVENCIDA = (decimal) (l.CANTIDADVENCIDA*l.PRECIOLOTE),
                               CANTIDADRESERVADA = l.CANTIDADRESERVADA,
                               MONTORESERVADA = (decimal) (l.CANTIDADRESERVADA*l.PRECIOLOTE),
                               CANTIDADTEMPORAL = l.CANTIDADTEMPORAL,
                               UBICACION = (g.UBICACION == null || g.UBICACION == "") ? "" : g.UBICACION
                           }).OrderBy(g => g.IDALMACEN).ThenBy(g => g.CORRPRODUCTO).ThenBy(g => g.FECHAVENCIMIENTO).ThenBy(g => g.CANTIDADDISPONIBLE).ThenBy(g => g.CANTIDADVENCIDA).ThenBy(g => g.CANTIDADNODISPONIBLE);
                        

                return res.ToList();
            }
        }



        public static List<FiltrarLotes_Result> ObtenerLotesFiltrados(int idAlmacen, int idSuministro, int idProducto, int tipoFiltro)
        {
            var res = new List<FiltrarLotes_Result>();
            using (var db = new SinabEntities())
            {

                var producto = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(p => (p.IDPRODUCTO == idProducto)
                                                                           && (p.IDSUMINISTRO == idSuministro || p.IDSUMINISTRO == 0));
                if (producto != null)
                    res = db.FiltrarLotes(tipoFiltro, idProducto, producto.CORRPRODUCTO, idAlmacen, idSuministro).ToList();
            }
            return res;
        }

        /// <summary>
        /// Agrega un nuevo lote a la db
        /// </summary>
        /// <param name="lote">entidad lote a agregar a la db</param>
        /// <remarks> sobrecarga de método con datacontext db</remarks>
        public static void AgregraLote(SAB_ALM_LOTES lote)
        {
            using (var db = new SinabEntities())
            {
               db.SAB_ALM_LOTES.AddObject(lote);
                db.SaveChanges();
            }
        }
        public static void AgregraLote(SAB_ALM_LOTES lote, SinabEntities db)
        {
                db.SAB_ALM_LOTES.AddObject(lote);
                db.SaveChanges();
        }


        /// <summary>
        /// Obtiene el siguiente Máximo id por idAlmacen del nuevo lote a guardar
        /// </summary>
        /// <param name="idAlmacen">identificador de almacen para encontrar el máximo idLote</param>
        /// <returns>Long que representa el nuevo máximo idLote</returns>
        public static long ObtenerMaxIdLote(int idAlmacen)
        {
            using (var db = new SinabEntities())
            {
                var rec = db.SAB_ALM_LOTES.Where(l => l.IDALMACEN == idAlmacen).Max(l => l.IDLOTE);
                return rec + 1;
            }
        }
        public static long ObtenerMaxIdLote(int idAlmacen, SinabEntities db)
        {
            var rec = db.SAB_ALM_LOTES.Where(l => l.IDALMACEN == idAlmacen).Max(l => l.IDLOTE);
            return rec + 1;
        }


        /// <summary>
        /// Compara la operacion a realizar y suma o resta dependiendo de la operacion
        /// </summary>
        /// <param name="cantidad">Cantidad a sumar o restar</param>
        /// <param name="operacion">Operacion (suma:1, resta:2)</param>
        /// <param name="loteCantidad">Cantidad a la cual se sumará o restará</param>
        /// <returns></returns>
        private static decimal EvaluarCantidades(decimal cantidad, int operacion, decimal loteCantidad)
        {
            switch (operacion)
            {
                case 1:
                    loteCantidad += cantidad;
                    break;
                case 2:
                    loteCantidad -= cantidad;
                    break;
            }

            return loteCantidad;
        }
    }

}
