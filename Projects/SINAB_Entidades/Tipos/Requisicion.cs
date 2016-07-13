using System;
using System.Collections.Generic;
using System.Linq;

namespace SINAB_Entidades.Tipos
{
    [Serializable]
    public class Requisicion
    {
        public Requisicion(SinabEntities db, SAB_FARM_REQUISICION r)
        {
            DetallesRequisicion = new List<SAB_FARM_DETALLEREQUISICION>();
            CodigoEstablecimiento = r.CodigoEstablecimiento;
            CodigoRequisicion = r.CodigoRequisicion;
            CodigoVale = r.IdVale;
            DireccionIp = r.DireccionIp;
            Estado = Convert.ToChar(r.Estado);
            FechaHoraReg = r.FechaHoraReg;
            FechaRequisicion = r.FechaRequisicion;
            IdModalidad = r.IdModalidad;
            IdRequisicion = r.IdRequisicion;
            Almacen = db.SAB_CAT_ALMACENES.FirstOrDefault(a => a.IDALMACEN == r.IdAlmacen);
            Establecimiento = db.SAB_CAT_ESTABLECIMIENTOS.FirstOrDefault(es => es.CODIGOESTABLECIMIENTO == r.CodigoEstablecimiento);
            LugarEntrega =
                db.SAB_CAT_LUGARES_ENTREGA_HOSPITALES.FirstOrDefault(
                    le =>
                    le.IDALMACEN == Almacen.IDALMACEN && le.NOMBRE_LUGAR_ENTREGA_HOSPITAL.ToLower().Contains("farmacia"));

            if (!string.IsNullOrEmpty(CodigoVale))
            {
                var tempvale = r.IdVale.Split('/');
                var idvale = Convert.ToInt32(tempvale[0]);
                var aniovale = Convert.ToInt32(tempvale[1]);
                Movimiento =
                    db.SAB_ALM_MOVIMIENTOS.FirstOrDefault(
                        m =>
                        m.IDMOVIMIENTO == r.IdMovimiento && m.IDESTABLECIMIENTO == Establecimiento.IDESTABLECIMIENTO);
                ValeSalida =
                    db.SAB_ALM_VALESSALIDA.FirstOrDefault(
                        v => v.IDVALE == idvale && v.IDALMACEN == Almacen.IDALMACEN && v.ANIO == aniovale);
            }
        }
        public List<SAB_FARM_DETALLEREQUISICION> DetallesRequisicion { get; set; }
        public string CodigoVale { get; set; }
        public int IdRequisicion { get; private set; }
        public int IdModalidad { get; private set; }
        public DateTime FechaRequisicion { get; private set; }
        public DateTime FechaHoraReg { get; private set; }
        public string DireccionIp { get; private set; }
        public char Estado { get; private set; }
        public string CodigoEstablecimiento { get; private set; }
        public string CodigoRequisicion { get; private set; }
        public SAB_CAT_ALMACENES Almacen { get; private set; }
        public SAB_CAT_ESTABLECIMIENTOS Establecimiento { get; private set; }
        public SAB_ALM_VALESSALIDA ValeSalida { get; set; }
        public SAB_ALM_MOVIMIENTOS Movimiento { get; set; }
        public SAB_CAT_LUGARES_ENTREGA_HOSPITALES LugarEntrega { get; set; }

        public void RestarDetalle(string codigoProducto, decimal cantidad)
        {
            using (var db = new SinabEntities())
            {
                var dr =
                    db.SAB_FARM_DETALLEREQUISICION.FirstOrDefault(
                        d => d.IdRequisicion == IdRequisicion && d.Codigo == codigoProducto);
                if (dr == null) return; //throw??
                dr.CantidadDespachada = dr.CantidadDespachada -= cantidad;
                if (dr.Procesado) dr.Procesado = false;
                db.SaveChanges();
            }
        }

        public List<RequisicionItem> ObtenerDetalle()
        {
            var db = new SinabEntities();
            var dt = new List<RequisicionItem>();
            dt.AddRange(DetallesRequisicion.Where(d=>d.Procesado == false)
                .Select(d=> ObtenerProducto(db, d))
            );
            return dt;
        }

        private static RequisicionItem ObtenerProducto(SinabEntities db, SAB_FARM_DETALLEREQUISICION detalle)
        {
            var producto = db.vv_CATALOGOPRODUCTOS.FirstOrDefault(p => p.CORRPRODUCTO == detalle.Codigo);

            return new RequisicionItem()
                       {
                           Id = (int) producto.IDPRODUCTO,
                           Codigo = producto.CORRPRODUCTO,
                           Nombre = producto.DESCLARGO,
                           Cantidad = (decimal) (detalle.Cantidad - detalle.CantidadDespachada)
                       };
        }
    }
}