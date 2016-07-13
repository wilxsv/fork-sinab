using System;
using System.Collections.Generic;
using System.Linq;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.CertificacionHelpers
{
    public static class EstadoProductos
    {
        #region Agregar
        public static void Agregar(SAB_CP_ESTADOSPRODUCTOS estado)
        {
            using (var db = new SinabEntities())
            {
                Agregar(db, estado);
            }
        }

        public static void Agregar(SinabEntities db, SAB_CP_ESTADOSPRODUCTOS estado)
        {
            db.SAB_CP_ESTADOSPRODUCTOS.AddObject(estado);
            db.SaveChanges();
        }
        #endregion Agregar

        #region ObtenerTodos
        public static List<SAB_CP_ESTADOSPRODUCTOS> ObtenerTodos(decimal idproductoproveedor)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodos(db, idproductoproveedor);
            }
        }

        public static List<SAB_CP_ESTADOSPRODUCTOS> ObtenerTodos(SinabEntities db, decimal idproductoproveedor)
        {
                var res = (db.SAB_CP_ESTADOSPRODUCTOS.Where(ep =>
                    ep.IdProductoProveedor == idproductoproveedor)).OrderByDescending(obj => obj.Fecha);
                return res.ToList();
           
        }
        #endregion ObtenerTodos

        #region Obtener
        public static SAB_CP_ESTADOSPRODUCTOS Obtener(decimal idproductoproveedor)
        {
            return ObtenerTodos(idproductoproveedor).FirstOrDefault();
        }

        public static SAB_CP_ESTADOSPRODUCTOS Obtener(SinabEntities db, decimal idproductoproveedor)
        {
            return ObtenerTodos(db, idproductoproveedor).FirstOrDefault();
        }

        public static SAB_CP_ESTADOSPRODUCTOS ObtenerUltimoEstado(SinabEntities db, decimal idproductoproveedor)
        {
            return (db.SAB_CP_ESTADOSPRODUCTOS.Where(ep =>
                ep.IdProductoProveedor == idproductoproveedor)).OrderByDescending(obj => obj.Fecha).FirstOrDefault();

            
        }
        #endregion Obtener

        internal static void Eliminar(SinabEntities db, decimal idProductoProveedor)
        {
            db.SAB_CP_ESTADOSPRODUCTOS.Where(ep => ep.IdProductoProveedor == idProductoProveedor).ToList().ForEach(ep => db.SAB_CP_ESTADOSPRODUCTOS.DeleteObject(ep));

            db.SaveChanges();
        }

        public static List<BaseEstadoProducto> ObtenerSubReporte(decimal idProductoProveedor)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_CP_ESTADOSPRODUCTOS.Where(ep => ep.IdProductoProveedor == idProductoProveedor)
                    .Select(ep => new BaseEstadoProducto()
                    {
                        Id = ep.Id,
                        IdProductoProveedor = ep.IdProductoProveedor,
                        Estado = ep.estado == 0 ? "Calificado" : "No Calificado",
                        Fecha = (DateTime) ep.Fecha,
                        Comentario = ep.Comentario,
                        
                    }).ToList();
            }
        }
    }
}
