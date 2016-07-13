using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection.Emit;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public static class ProductoSinExistencia
    {
        public static List<BaseProductoSinExistenciaReporte> ReporteDesabastecidos(int idAlmacen, int idSuministro, int year, int week)
        {
            using (var db = new SinabEntities())
            {
                var res = (from pse in db.SAB_ALM_PRODUCTOSSINEXISTENCIA
                    join vv in db.vv_CATALOGOPRODUCTOS on pse.IDPRODUCTO equals vv.IDPRODUCTO

                    where
                        pse.IDALMACEN == idAlmacen && pse.IDSUMINISTRO == idSuministro &&
                        pse.ANIO == year && pse.IDSEMANA == week && pse.EXISTENCIAFARMACIA == 0
                    select new BaseProductoSinExistenciaReporte
                    {
                        Correlativo = 0,
                        CorrProducto = vv.CORRPRODUCTO,
                        DescLargo = vv.DESCLARGO
                    }).OrderBy(i => i.CorrProducto).ToList();

                var indx = 1;
                foreach (var itm in res)
                {
                    itm.Correlativo = indx;
                    indx++;
                }
                
                return res.ToList();
            }
        }

        public static List<BaseProductoDesabastecido> ObtenerTodos(int idAlmacen, int idSuministro, int year, int week)
        {

            using (var db = new SinabEntities())
            {
                var res = (from pse in db.SAB_ALM_PRODUCTOSSINEXISTENCIA
                          join vv in db.vv_CATALOGOPRODUCTOS on pse.IDPRODUCTO equals vv.IDPRODUCTO
                          let al = pse.SAB_CAT_ALMACENES
                          where
                             pse.IDALMACEN == idAlmacen && pse.IDSUMINISTRO == idSuministro &&
                              pse.ANIO == year && pse.IDSEMANA == week
                          select new BaseProductoDesabastecido
                          {
                              Id = pse.Id,
                              IdAlmacen = pse.IDALMACEN,
                              Almacen = pse.SAB_CAT_ALMACENES.NOMBRE,
                              IdProducto = pse.IDPRODUCTO,
                              Correlativo = vv.CORRPRODUCTO,
                              Descripcion = vv.DESCLARGO,
                              IdUnidadMedida = vv.IDUNIDADMEDIDA,
                              UnidadMedida = vv.DESCRIPCION,
                              IdSuministro = vv.IDSUMINISTRO,
                              Suministro = vv.DESCSUMINISTRO,
                              Exitencias = pse.EXISTENCIAFARMACIA ?? 0
                          }).OrderBy(i => i.Correlativo);
                return res.ToList();



            }
        }

        public static List<BaseProductoAlmacenDetalle> ObtenerTodos(int semana, int anio, bool existenciaFarmacia)
        {
            var existencia = Convert.ToByte(existenciaFarmacia);
            using (var db = new SinabEntities())
            {
                return (from pe in db.SAB_ALM_PRODUCTOSSINEXISTENCIA
                        where pe.ANIO == anio && pe.IDSEMANA == semana
                              && pe.IDSUMINISTRO == 1 //todo: ??
                              && pe.EXISTENCIAFARMACIA == existencia

                        //join al in db.SAB_CAT_ALMACENES on pe.IDALMACEN equals al.IDALMACEN
                        join cp in db.vv_CATALOGOPRODUCTOS on pe.IDPRODUCTO equals cp.IDPRODUCTO

                        select new BaseProductoAlmacenDetalle()
                    {
                        Almacen = pe.SAB_CAT_ALMACENES.NOMBRE,
                        Correlativo = cp.CORRPRODUCTO,
                        Descripcion = cp.DESCLARGO,
                        Clasificacion = cp.CLASIFICACION
                    }).OrderBy(ob => ob.Almacen).ThenBy(ob => ob.Correlativo).ToList();
            }
        }

        public static List<prc_ProductosSinExistenciaLocal_Result> ObtenerTodos(int idAlmacen, int idSuministro)
        {
            using (var db = new SinabEntities())
            {
                return db.prc_ProductosSinExistenciaLocal(idAlmacen, idSuministro).ToList();
            }
        }

        public static List<SAB_ALM_PRODUCTOSSINEXISTENCIA> ObtenerTodos(SinabEntities db, int idAlmacen,
              int idSuministro, int idSemana)
        {
            return
                db.SAB_ALM_PRODUCTOSSINEXISTENCIA.Where(
                    p => p.IDALMACEN == idAlmacen && p.IDSUMINISTRO == idSuministro && p.IDSEMANA == idSemana).ToList();
        }

        


        public static void AgregarTodos(List<SAB_ALM_PRODUCTOSSINEXISTENCIA> listado)
        {
            using (var db = new SinabEntities())
            {
                listado.ForEach(pse => db.SAB_ALM_PRODUCTOSSINEXISTENCIA.AddObject(pse));
                db.SaveChanges();
            }
        }

        public static void EliminarTodos(int idAlmacen, int idSuministro, int idSemana)
        {
            using (var db = new SinabEntities())
            {
                var todos = ObtenerTodos(db, idAlmacen, idSuministro, idSemana);
                todos.ForEach(p => db.SAB_ALM_PRODUCTOSSINEXISTENCIA.DeleteObject(p));
                db.SaveChanges();
            }
        }

        

        public static SAB_ALM_PRODUCTOSSINEXISTENCIA Obtener(SinabEntities db, int id)
        {
            return db.SAB_ALM_PRODUCTOSSINEXISTENCIA.FirstOrDefault(i => i.Id == id);
        }
    }
}
