using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Transactions;
using SINAB_Entidades.Helpers.AlmacenHelpers;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.CertificacionHelpers
{
    public static class AspectosProductos
    {
        public static SAB_CP_ASPECTOSPRODUCTOS Obtener(int idAspectos, int idProductoProveedor)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idAspectos, idProductoProveedor);
            }
        }

        private static SAB_CP_ASPECTOSPRODUCTOS Obtener(SinabEntities db, int idAspectos, int idProductoProveedor)
        {
            return db.SAB_CP_ASPECTOSPRODUCTOS.Include(ap => ap.SAB_CP_CAT_ASPECTOS).FirstOrDefault(ap => ap.IdAspectos == idAspectos && ap.IdProductoProveedores == idProductoProveedor);
        }


        public static int ObtenerMaxId(SinabEntities db)
        {
            var rec = db.SAB_CP_ASPECTOSPRODUCTOS.Max(ap => ap.IdAspectos);
            return rec + 1;
        }

        public static void Agregar(SAB_CP_ASPECTOSPRODUCTOS aspecto)
        {
            using (var db = new SinabEntities())
            {
                Agregar(db, aspecto);
            }
        }

        public static void Agregar(SinabEntities db, SAB_CP_ASPECTOSPRODUCTOS aspecto)
        {
            try
            {

                db.SAB_CP_ASPECTOSPRODUCTOS.AddObject(aspecto);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Eliminar(SinabEntities db, int idaspectos)
        {
            db.SAB_CP_ASPECTOSPRODUCTOS.Where(a => a.IdAspectos == idaspectos).ToList().ForEach(a => db.SAB_CP_ASPECTOSPRODUCTOS.DeleteObject(a));
            db.SaveChanges();
        }




        public static void Actualizar(SAB_CP_ASPECTOSPRODUCTOS aspecto)
        {
            using (var db = new SinabEntities())
            {
                var a = Obtener(db, aspecto.IdAspectos, aspecto.IdProductoProveedores);
                if (a == null) throw new Exception("No se pudo encontrar el aspecto a actualizar");
                a.fechaemision = aspecto.fechaemision;
                a.fechavto = aspecto.fechavto;
                a.Comentario = aspecto.Comentario;
                a.estado = aspecto.estado;
                db.SaveChanges();
            }
        }


        public static List<BaseProductosProveedores> ObtenerReporte(decimal idProceso, decimal idTipoProducto,
            string nit, DateTime fechaLimite)
        {
            var fechaminima = new DateTime(1990, 1, 1);
            using (var db = new SinabEntities())
            {
                var res = (from ap in db.SAB_CP_ASPECTOSPRODUCTOS
                           join pp in db.SAB_CP_PRODUCTOSPROVEEDORES on ap.IdProductoProveedores equals pp.Id
                           join p in db.SAB_CP_CAT_PAIS on pp.IdPais equals p.IdPais
                           join vv in db.vv_CATALOGOPRODUCTOS on pp.IdProducto equals vv.IDPRODUCTO
                           join prv in db.SAB_CAT_PROVEEDORES on pp.IdProveedorProceso equals prv.IDPROVEEDOR
                           join su in db.SAB_CAT_SUMINISTROS on pp.SAB_CP_PROVEEDORESPROCESO.IdTipoProducto equals
                               su.IDSUMINISTRO
                           where
                               pp.IdProceso == idProceso && pp.SAB_CP_PROVEEDORESPROCESO.IdTipoProducto == idTipoProducto
                               && ap.fechavto.Value != null && (ap.fechavto > fechaminima && ap.fechavto <= fechaLimite)
                           orderby ap.fechavto
                           let est = pp.SAB_CP_ESTADOSPRODUCTOS.OrderByDescending(ep => ep.Fecha).FirstOrDefault()
                           select new BaseProductosProveedores()
                           {
                               IdProceso = pp.IdProceso,
                               IdTipoProducto = pp.SAB_CP_PROVEEDORESPROCESO.IdTipoProducto,
                               IdProveedorProceso = pp.IdProveedorProceso,
                               IdProducto = pp.IdProducto,
                               IdLista = pp.IdLista ?? 0,
                               Id = pp.Id,
                               Nit = prv.NIT,
                               Proveedor = prv.NOMBRE,
                               TipoProducto = su.DESCRIPCION,
                               CorrProducto = vv.CORRPRODUCTO,
                               DescLargo = vv.DESCLARGO,
                               Marca = pp.Marca,
                               Pais = p.Nombre,
                               NumEstadoAspecto = (EnumHelpers.EstadoAspectos)ap.estado,
                               NumeroProceso = pp.SAB_CP_PROVEEDORESPROCESO.SAB_CP_PROCESO.numproceso,
                               Correlativo = (int)ap.SAB_CP_CAT_ASPECTOS.orden,
                               Aspecto = ap.SAB_CP_CAT_ASPECTOS.nombre,
                               FechaVto = (DateTime)ap.fechavto,
                               FechaEmision = (DateTime)ap.fechaemision,
                               NombreComercial = pp.NombreComercial,
                               NumeroCSSP = pp.NumeroCSSP
                           }).ToList();

                if (!string.IsNullOrEmpty(nit)) res = res.Where(itm => itm.Nit.Contains(nit)).ToList();

                res = res.OrderBy(itm => itm.FechaVto).ThenBy(itm => itm.Correlativo).ToList();
                return res;
            }
        }

        public static List<BaseProductosProveedores> ObtenerReporte(decimal idProceso, decimal idTipoProducto,
           string nit)
        {

            using (var db = new SinabEntities())
            {
                var res = (from ap in db.SAB_CP_ASPECTOSPRODUCTOS
                           join pp in db.SAB_CP_PRODUCTOSPROVEEDORES on ap.IdProductoProveedores equals pp.Id
                           join p in db.SAB_CP_CAT_PAIS on pp.IdPais equals p.IdPais
                           join vv in db.vv_CATALOGOPRODUCTOS on pp.IdProducto equals vv.IDPRODUCTO
                           join prv in db.SAB_CAT_PROVEEDORES on pp.IdProveedorProceso equals prv.IDPROVEEDOR
                           join su in db.SAB_CAT_SUMINISTROS on pp.SAB_CP_PROVEEDORESPROCESO.IdTipoProducto equals
                               su.IDSUMINISTRO
                           where
                               pp.IdProceso == idProceso && pp.SAB_CP_PROVEEDORESPROCESO.IdTipoProducto == idTipoProducto

                           let est = pp.SAB_CP_ESTADOSPRODUCTOS.OrderByDescending(ep => ep.Fecha).FirstOrDefault()
                           select new BaseProductosProveedores()
                           {
                               IdProceso = pp.IdProceso,
                               IdTipoProducto = pp.SAB_CP_PROVEEDORESPROCESO.IdTipoProducto,
                               IdProveedorProceso = pp.IdProveedorProceso,
                               IdProducto = pp.IdProducto,
                               IdLista = pp.IdLista ?? 0,
                               Id = pp.Id,
                               Nit = prv.NIT,
                               Proveedor = prv.NOMBRE,
                               TipoProducto = su.DESCRIPCION,
                               CorrProducto = vv.CORRPRODUCTO,
                               DescLargo = vv.DESCLARGO,
                               Marca = pp.Marca,
                               Pais = p.Nombre,
                               NumEstadoAspecto = (EnumHelpers.EstadoAspectos)ap.estado,
                               NumeroProceso = pp.SAB_CP_PROVEEDORESPROCESO.SAB_CP_PROCESO.numproceso,
                               Correlativo = (int)ap.SAB_CP_CAT_ASPECTOS.orden,
                               Aspecto = ap.SAB_CP_CAT_ASPECTOS.nombre,
                               FechaVto = ap.fechavto != null ? (DateTime)ap.fechavto : DateTime.MinValue,
                               FechaEmision = ap.fechaemision != null ? (DateTime)ap.fechaemision : DateTime.MinValue
                           }).ToList();

                if (!string.IsNullOrEmpty(nit)) res = res.Where(itm => itm.Nit.Contains(nit)).ToList();

                res = res.OrderBy(itm => itm.FechaVto).ThenBy(itm => itm.Correlativo).ToList();
                return res;
            }
        }

        public static List<BaseAspectoProducto> ObtenerTodos(SinabEntities db, int idpp)
        {
            return
                db.SAB_CP_ASPECTOSPRODUCTOS.Where(ap => ap.IdProductoProveedores == idpp)
                    .Select(ap => new BaseAspectoProducto()
                    {
                        IdProductoProveedor = ap.IdProductoProveedores,
                        Correlativo = ap.SAB_CP_CAT_ASPECTOS.orden ?? 0,
                        Estado = ap.estado ?? 0,
                        NumEstadoAspecto = (EnumHelpers.EstadoAspectos)ap.estado,
                        Aspecto = ap.SAB_CP_CAT_ASPECTOS.nombre,
                        FechaVto = ap.fechavto != null ? (DateTime)ap.fechavto : DateTime.MinValue,
                        FechaEmision = ap.fechaemision != null ? (DateTime)ap.fechaemision : DateTime.MinValue
                    })
                    .ToList();
        }

        public static List<BaseAspectoProducto> ObtenerTodos(SinabEntities db, int idpp,
            int estado)
        {
            return
                db.SAB_CP_ASPECTOSPRODUCTOS.Where(ap => ap.IdProductoProveedores == idpp && ap.estado == estado)
                    .Select(ap => new BaseAspectoProducto()
                    {
                        IdProductoProveedor = ap.IdProductoProveedores,
                        Correlativo = ap.SAB_CP_CAT_ASPECTOS.orden ?? 0,
                        Estado = ap.estado ?? 0,
                        NumEstadoAspecto = (EnumHelpers.EstadoAspectos)ap.estado,
                        Aspecto = ap.SAB_CP_CAT_ASPECTOS.nombre,
                        FechaVto = ap.fechavto != null ? (DateTime)ap.fechavto : DateTime.MinValue,
                        FechaEmision = ap.fechaemision != null ? (DateTime)ap.fechaemision : DateTime.MinValue
                    })
                    .ToList();
        }
    }
}
