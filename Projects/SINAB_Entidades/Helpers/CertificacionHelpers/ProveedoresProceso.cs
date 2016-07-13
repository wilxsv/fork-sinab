using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.CertificacionHelpers
{
    public static class ProveedoresProceso
    {
        /*
         * Request.QueryString("idp"), Request.QueryString("idtp"), Request.QueryString("idprov"), "C", "+"
         * SET PRODUCTOS" & FLAG & "=PRODUCTOS" & FLAG & " " & OPERADOR & " 1
         * SET PRODUCTOSC=PRODUCTOSC + 1 
         */
        #region Actualizar
        
        public static void Actualizar(decimal id, decimal estado)
        {
            using (var db = new SinabEntities())
            {
                Actualizar(db, id, estado);
            }
        }

        public static void Actualizar(SinabEntities db, decimal id, decimal estado)
        {
            var obj = db.SAB_CP_PROVEEDORESPROCESO.FirstOrDefault(pp =>
                   pp.Id == id);
            if (obj == null) return;

            var contC = obj.ProductosC ?? 0;
            var contN = obj.ProductosN ?? 0;

            if (estado > 0)
            {
                contC -= 1;
                contN += 1;
            }
            else
            {
                contC += 1;
                contN -= 1;
            }
            obj.ProductosC = contC < 0 ? 0 : contC;
            obj.ProductosN = contN < 0 ? 0 : contN;
            db.SaveChanges();
        }

        public static void ActualizarPorBorrado(SinabEntities db, decimal id, decimal estado)
        {
            var obj = db.SAB_CP_PROVEEDORESPROCESO.FirstOrDefault(pp =>
                   pp.Id == id);
            if (obj == null) return;

            var contC = obj.ProductosC ?? 0;
            var contN = obj.ProductosN ?? 0;

            //si no certificado
            if (estado > 0)
            {
                contN -= 1;
            }
            else
            {
                contC -= 1;
            }

            obj.ProductosC = contC < 0 ? 0 : contC;
            obj.ProductosN = contN < 0 ? 0 : contN;
            db.SaveChanges();
        }

        public static void Actualizar(SinabEntities db, SAB_CP_PROVEEDORESPROCESO proveedorProceso)
        {

            proveedorProceso.ProductosN += 1;
            db.SaveChanges();
        }
        #endregion Actualizar


        public static void CargarALista(decimal idProceso, decimal idTipoProducto, ref DropDownList lista)
        {
            var recs = ObtenerTodos(idProceso, idTipoProducto);

            lista.DataSource = recs;
            lista.DataTextField = "Proveedor";
            lista.DataValueField = "Proveedor";
            lista.DataBind();
        }

        #region ObtenerTodos

        public static int ObtenerConteoProductosCertificados(decimal idProceso, decimal id)
        {
            using (var db = new SinabEntities())
            {
                var obj = Obtener(db, idProceso, id);
                if (obj == null) return 0;
                return obj.SAB_CP_PRODUCTOSPROVEEDORES.Count(
                        itm =>
                        {
                            var cert = itm.SAB_CP_ESTADOSPRODUCTOS.OrderByDescending(es => es.Fecha).FirstOrDefault();
                            return cert != null && cert.estado == 0;
                        });
            }
        }

        public static int ObtenerConteoProductos(decimal idProceso, decimal id)
        {
            using (var db = new SinabEntities())
            {
                var obj = Obtener(db, idProceso, id);
                return obj == null ? 0 : obj.SAB_CP_PRODUCTOSPROVEEDORES.Count;
            }
        }

        private static SAB_CP_PROVEEDORESPROCESO Obtener(SinabEntities db, decimal idProceso, decimal id)
        {
            return db.SAB_CP_PROVEEDORESPROCESO.FirstOrDefault(obj => obj.IdProceso == idProceso && obj.Id == id);
        }


        public static List<BaseProceso> ObtenerTodos(decimal idProceso, decimal idTipoProducto)
        {
            using (var db = new SinabEntities())
            {
                var res = from pp in db.SAB_CP_PROVEEDORESPROCESO
                    where pp.IdProceso == idProceso && pp.IdTipoProducto == idTipoProducto
                    join p in db.SAB_CAT_PROVEEDORES
                        on pp.Id equals p.IDPROVEEDOR
                    select new BaseProceso
                    {
                        Nit = p.NIT,
                        Proveedor = p.NOMBRE,
                        IdProceso = pp.IdProceso,
                        IdTipoProducto = pp.IdTipoProducto,
                        IdProveedor = pp.Id
                    };
                return res.ToList();

            }
        }

        public static List<BaseProceso> ObtenerTodosPorNit(decimal idProceso, decimal idTipoProducto, string text)
        {
            using (var db = new SinabEntities())
            {
                return (from pp in db.SAB_CP_PROVEEDORESPROCESO
                          where pp.IdProceso == idProceso && pp.IdTipoProducto == idTipoProducto
                          join p in db.SAB_CAT_PROVEEDORES
                              on pp.Id equals p.IDPROVEEDOR
                          select new BaseProceso
                          {
                              Nit = p.NIT,
                              Proveedor = p.NOMBRE,
                              IdProceso = pp.IdProceso,
                              IdTipoProducto = pp.IdTipoProducto,
                              IdProveedor = pp.Id
                          }).Where(bp =>bp.Nit.Contains(text)).ToList();

            }
        }

        public static List<BaseProceso> ObtenerTodosPorNombre(decimal idProceso, decimal idTipoProducto, string text)
        {
            using (var db = new SinabEntities())
            {
                return (from pp in db.SAB_CP_PROVEEDORESPROCESO
                          where pp.IdProceso == idProceso && pp.IdTipoProducto == idTipoProducto
                          join p in db.SAB_CAT_PROVEEDORES
                              on pp.Id equals p.IDPROVEEDOR
                          select new BaseProceso
                          {
                              Nit = p.NIT,
                              Proveedor = p.NOMBRE,
                              IdProceso = pp.IdProceso,
                              IdTipoProducto = pp.IdTipoProducto,
                              IdProveedor = pp.Id
                          }).Where(bp => bp.Proveedor.Contains(text)).ToList();

            }
        }
        #endregion ObtenerTodos

        public static void Agregar(SAB_CP_PROVEEDORESPROCESO proveedorproceso)
        {
            using (var db = new SinabEntities())
            {
                db.SAB_CP_PROVEEDORESPROCESO.AddObject(proveedorproceso);
                db.SaveChanges();
            }
        }

        public static void Eliminar(decimal idProveedorProceso)
        {
            using (var db = new SinabEntities())
            {
                var obj = db.SAB_CP_PROVEEDORESPROCESO.FirstOrDefault(pp => pp.Id == idProveedorProceso);
                if(obj == null) throw new Exception("Proveedor no encontrado, No se pudo eliminar el proveedor");
                db.SAB_CP_PROVEEDORESPROCESO.DeleteObject(obj);
                db.SaveChanges();
            }
        }
    }
}
