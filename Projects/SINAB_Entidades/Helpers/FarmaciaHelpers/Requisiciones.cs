using System;
using System.Linq;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.FarmaciaHelpers
{
    public class Requisiciones
    {
        public Requisicion Obtener(SinabEntities db, string codigo)
        {
            var idalmacen = Membresia.ObtenerUsuario().Almacen.IDALMACEN;
            var reqs = db.SAB_FARM_REQUISICION.Include("SAB_FARM_DETALLEREQUISICION")
                .Where(r => r.CodigoRequisicion == codigo && r.IdAlmacen == idalmacen);

            var requisicion = new Requisicion(db, reqs.FirstOrDefault());

            foreach (var r in reqs)
            {
                requisicion.DetallesRequisicion.AddRange(r.SAB_FARM_DETALLEREQUISICION.Where(dr => dr.Procesado == false));
            }
            return requisicion;
        }

        
        public void AsignarValeyProcesar(Requisicion requisicion)
        {
            var codVale = string.Format("{0}/{1}", requisicion.ValeSalida.IDVALE, requisicion.ValeSalida.ANIO);
            using (var db = new SinabEntities())
            {
                var res =
                    db.SAB_FARM_REQUISICION.Where(
                        r =>
                        r.CodigoRequisicion == requisicion.CodigoRequisicion &&
                        r.IdAlmacen == requisicion.Almacen.IDALMACEN);

                foreach (var r in res)
                {
                    r.IdMovimiento = (int?)requisicion.Movimiento.IDMOVIMIENTO;
                    r.Estado = ((char)EnumHelpers.RequisicionEstados.Procesado).ToString();
                    r.IdVale = codVale;
                }

                db.SaveChanges();
            }
        }

        public void AsignarEstado(Requisicion requisicion, char estado)
        {
            var codVale = string.Format("{0}/{1}", requisicion.ValeSalida.IDVALE, requisicion.ValeSalida.ANIO);

            using (var db = new SinabEntities())
            {
                var res =
                    db.SAB_FARM_REQUISICION.Where(
                        r =>
                        r.CodigoRequisicion == requisicion.CodigoRequisicion &&
                        r.IdAlmacen == requisicion.Almacen.IDALMACEN);
                foreach (var r in res)
                {
                    r.IdMovimiento = (int?)requisicion.Movimiento.IDMOVIMIENTO;
                    r.IdVale = codVale;
                    r.Estado = estado.ToString();
                }

                db.SaveChanges();
            }
        }

        public void AsignarVale(Requisicion requisicion)
        {
            using (var db = new SinabEntities())
            {
                var codVale = string.Format("{0}/{1}", requisicion.ValeSalida.IDVALE, requisicion.ValeSalida.ANIO);

                var res =
                    db.SAB_FARM_REQUISICION.Where(
                        r =>
                        r.CodigoRequisicion == requisicion.CodigoRequisicion &&
                        r.IdAlmacen == requisicion.Almacen.IDALMACEN);
                foreach (var r in res)
                {
                    r.IdVale = codVale;
                    r.IdMovimiento = (int?)requisicion.Movimiento.IDMOVIMIENTO;
                    r.IdVale = codVale;
                }

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Agrega la cantidad de un detallemovimiento al detalle requisicion
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="requisicion">Requisición</param>
        /// <param name="dm">Detalle del movimiento</param>
        /// <remarks>
        /// Si cantidad calculada > cantidad pedida : excepcion (no puede ser mayor)
        /// Si cantidad = cantidad despachada: procesado = true
        /// </remarks>
        public void AgregarDetalle(Requisicion requisicion, SAB_ALM_DETALLEMOVIMIENTOS dm)
        {
            try
            {
                using (var db = new SinabEntities())
                {
                    var prod = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(vv => vv.IDPRODUCTO == dm.IDPRODUCTO);
                    var dr =
                        db.SAB_FARM_DETALLEREQUISICION.FirstOrDefault(
                            d => d.IdRequisicion == requisicion.IdRequisicion && d.Codigo == prod.CORRPRODUCTO);


                    if (dr == null) return;
                    var despacha = dr.CantidadDespachada += dm.CANTIDAD;

                    if (dr.Cantidad == despacha) dr.Procesado = true;
                    else if (despacha > dr.Cantidad) throw new Exception("Cantidad a despachar no puede ser mayor a la cantidad solicitada. Producto: " + dr.Codigo + " - " + prod.NOMBRECORTO);
                    else dr.CantidadDespachada = despacha;

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Agrega la cantidad de un detallemovimiento al detalle requisicion.
        /// Esta funcion no guarda en la base de datos, se debe actualizar fuera del lazo try-catch que la contenga (db.savechanges()).
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="requisicion">Requisición</param>
        /// <param name="dm">Detalle del movimiento</param>
        /// <remarks>
        /// Si cantidad calculada > cantidad pedida : excepcion (no puede ser mayor)
        /// Si cantidad = cantidad despachada: procesado = true
        /// </remarks>
        public void AgregarDetalle(SinabEntities db, Requisicion requisicion, SAB_ALM_DETALLEMOVIMIENTOS dm)
        {

            var prod = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(vv => vv.IDPRODUCTO == dm.IDPRODUCTO);
            var dr =
                db.SAB_FARM_DETALLEREQUISICION.FirstOrDefault(
                    d => d.IdRequisicion == requisicion.IdRequisicion && d.Codigo == prod.CORRPRODUCTO);


            if (dr == null) return;
            var despacha = dr.CantidadDespachada += dm.CANTIDAD;

            if (dr.Cantidad == despacha) dr.Procesado = true;
            else if (despacha > dr.Cantidad)
                throw new Exception("Cantidad a despachar no puede ser mayor a la cantidad solicitada. Producto: " +
                                    dr.Codigo + " - " + prod.NOMBRECORTO);
            else dr.CantidadDespachada = despacha;

            //db.SaveChanges();

        }

        /// <summary>
        /// Resta la cantidad de un detalle de movimiento al detalle de requisicion.
        /// Esta funcion no guarda en la base de datos, se debe actualizar fuera del lazo try-catch que la contenga (db.savechanges()).
        /// </summary>
        /// <param name="db">Datacontext</param>
        /// <param name="requisicion">Requisición</param>
        /// <param name="dm">Detalle del movimiento</param>
        /// <remarks>
        /// Si cantidad menor que 0: cantidad = 0
        /// Si procesado: !procesado
        /// </remarks>
        public void RestarDetalle(SinabEntities db, Requisicion requisicion, SAB_ALM_DETALLEMOVIMIENTOS dm)
        {
            var prod = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(vv => vv.IDPRODUCTO == dm.IDPRODUCTO);
            var dr =
                db.SAB_FARM_DETALLEREQUISICION.FirstOrDefault(
                    d => d.IdRequisicion == requisicion.IdRequisicion && d.Codigo == prod.CORRPRODUCTO);
            if (dr == null) return; //throw??
            dr.CantidadDespachada = dr.CantidadDespachada -= dm.CANTIDAD;
            if (dr.CantidadDespachada < 0) dr.CantidadDespachada = 0;
            if (dr.Procesado) dr.Procesado = false;
            //db.SaveChanges(); la base de datos se actualiza fuera de esta funcion
        }
    }
}
