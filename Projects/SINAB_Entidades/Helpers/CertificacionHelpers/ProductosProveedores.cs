using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Transactions;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.CertificacionHelpers
{
    public static class ProductosProveedores
    {
        #region ObtenerTodos
        public static List<BaseProductosProveedores> ObtenerTodos(decimal idProveedoresProceso, decimal idProceso)
        {
            using (var db = new SinabEntities())
            {
                var res = (from pp in db.SAB_CP_PRODUCTOSPROVEEDORES
                           where pp.IdProveedorProceso == idProveedoresProceso && pp.IdProceso == idProceso
                    join vv in db.vv_CATALOGOPRODUCTOS on pp.IdProducto equals vv.IDPRODUCTO
                    join pa in db.SAB_CP_CAT_PAIS on pp.IdPais equals pa.IdPais into grp
                    from itm in grp.DefaultIfEmpty() 
                           select new BaseProductosProveedores
                    {
                        
                        IdProducto =  pp.IdProducto,
                        Id = pp.Id,
                        CorrProducto = vv.CORRPRODUCTO,
                        DescLargo = vv.DESCLARGO,
                        Marca = pp.Marca,
                        Pais = itm != null ? itm.Nombre : ""
                    }).ToList();

                foreach (var itm in res)
                {
                    //obtiene el último estado
                    var es =EstadoProductos.Obtener(db, itm.Id);
                    if (es != null)
                    {
                        itm.Estado = es.estado ?? 1;
                        itm.Certificado = es.estado == 0 ? "Certificado" : "No Certificado";
                    }
                    else
                    {
                        itm.Estado = 1;
                        itm.Certificado = "No Certificado";
                    }
                }

                return res;

            }
        }

        public static List<BaseProductosProveedores> ObtenerTodosPorCodigo(decimal idProveedoresProceso, decimal idProceso, string text)
        {
            using (var db = new SinabEntities())
            {

                var res = (from pp in db.SAB_CP_PRODUCTOSPROVEEDORES
                           where pp.IdProveedorProceso == idProveedoresProceso && pp.IdProceso == idProceso
                    join vv in db.vv_CATALOGOPRODUCTOS on pp.IdProducto equals vv.IDPRODUCTO
                    join pa in db.SAB_CP_CAT_PAIS on pp.IdPais equals pa.IdPais into grp
                    from itm in grp.DefaultIfEmpty()
                    where vv.CORRPRODUCTO.Contains(text)
                    select new BaseProductosProveedores
                    {
                        IdProducto = pp.IdProducto,
                        Id = pp.Id,
                        CorrProducto = vv.CORRPRODUCTO,
                        DescLargo = vv.DESCLARGO,
                        Marca = pp.Marca,
                        Pais = itm != null ? itm.Nombre : ""
                    }).ToList();

                foreach (var itm in res)
                {
                    //obtiene el último estado
                    var es = EstadoProductos.Obtener(db, itm.Id);
                    if (es != null)
                    {
                        itm.Estado = es.estado ?? 1;
                        itm.Certificado = es.estado == 0 ? "Certificado" : "No Certificado";
                    }
                    else
                    {
                        itm.Estado = 1;
                        itm.Certificado = "No Certificado";
                    }
                }

                return res;
            }
        }

        public static List<BaseProductosProveedores> ObtenerTodosPorDesc(int idProveedoresProceso, decimal idProceso, string text)
        {
            using (var db = new SinabEntities())
            {
                var res = (from pp in db.SAB_CP_PRODUCTOSPROVEEDORES
                           where pp.IdProveedorProceso == idProveedoresProceso && pp.IdProceso == idProceso
                    join vv in db.vv_CATALOGOPRODUCTOS on pp.IdProducto equals vv.IDPRODUCTO
                    join pa in db.SAB_CP_CAT_PAIS on pp.IdPais equals pa.IdPais into grp
                    from itm in grp.DefaultIfEmpty()
                    where vv.DESCLARGO.Contains(text)
                    select new BaseProductosProveedores
                    {
                        IdProducto = pp.IdProducto,
                        Id = pp.Id,
                        CorrProducto = vv.CORRPRODUCTO,
                        DescLargo = vv.DESCLARGO,
                        Marca = pp.Marca,
                        Pais = itm != null ? itm.Nombre : ""
                    }).ToList();

                foreach (var itm in res)
                {
                    //obtiene el último estado
                    var es = EstadoProductos.Obtener(db, itm.Id);
                    if (es != null)
                    {
                        itm.Estado = es.estado ?? 1;
                        itm.Certificado = es.estado == 0 ? "Certificado" : "No Certificado";
                    }
                    else
                    {
                        itm.Estado = 1;
                        itm.Certificado = "No Certificado";
                    }
                }

                return res;
            }

        }
#endregion ObtenerTodos

        #region Obtener
        public static SAB_CP_PRODUCTOSPROVEEDORES Obtener(int id)
        {
            using (var db = new SinabEntities())
            {
                var res =
                    db.SAB_CP_PRODUCTOSPROVEEDORES.Include(pp => pp.SAB_CP_PC).Include(pp => pp.SAB_CP_PROVEEDORESPROCESO).FirstOrDefault(cp => cp.Id == id );
                return res;
            }
        }

        public static SAB_CP_PRODUCTOSPROVEEDORES Obtener(SinabEntities db, SAB_CP_PRODUCTOSPROVEEDORES producto)
        {
            return Obtener(db, producto.Id);

        }

        public static SAB_CP_PRODUCTOSPROVEEDORES Obtener(SinabEntities db, int id)
        {
            return db.SAB_CP_PRODUCTOSPROVEEDORES.FirstOrDefault(pp => pp.Id == id);
        }
        #endregion Obtener

        public static void Eliminar(SAB_CP_PRODUCTOSPROVEEDORES producto)
        {
           
                    using (var db = new SinabEntities())
                    {
                        Eliminar(db, producto);

                   
                   
            }
        }

        public static void Eliminar(SinabEntities db, SAB_CP_PRODUCTOSPROVEEDORES producto)
        {
            
                var obj = Obtener(db, producto);
                if (obj == null) return; // throw new Exception("No se encotnro el ProductoProveedores a Eliminar");
                db.SAB_CP_PRODUCTOSPROVEEDORES.DeleteObject(obj);
                db.SaveChanges();
           
        }

        public static void Agregar(SAB_CP_PRODUCTOSPROVEEDORES producto)
        {
            using (var trans = new TransactionScope())
            {
                try
                {
                    using (var db = new SinabEntities())
                    {
                        

                        //Guarda el productoProceso
                        Agregar(db, producto);
                        
                       //guarda su estado inicial
                        var estado = new SAB_CP_ESTADOSPRODUCTOS()
                        {
                            IdProductoProveedor = producto.Id,
                            estado = 1,
                            Fecha = DateTime.Now,
                            Comentario = "Estado Inicial",
                            usuario = Membresia.ObtenerUsuario().NombreUsuario
                        };
                        EstadoProductos.Agregar(db, estado);

                        //actualiza contador de productos no certificados
                        
                        ProveedoresProceso.Actualizar(db, producto.SAB_CP_PROVEEDORESPROCESO);
                    }

                    trans.Complete();
                }
                catch (Exception ex)
                {
                    
                    throw new Exception(ex.Message);
                }
                
            }
        }

        private static void Agregar(SinabEntities db, SAB_CP_PRODUCTOSPROVEEDORES producto)
        {

           
            db.SAB_CP_PRODUCTOSPROVEEDORES.AddObject(producto);
            db.SaveChanges();
        }
        
        public static void Actualizar(SAB_CP_PRODUCTOSPROVEEDORES producto)
        {
            using (var db = new SinabEntities())
            {
                var obj = Obtener(db, producto);
                /*NOMBRECOMERCIAL = '" & NombreComercial & "', NumeroCSSP='" & CSSP & "', CPFOMS='" & CPF & "',
                 * Marca='" & Marca & "', IdPais=" & IdPaisOrigen & ", NombreFab='" & Nombrefab & "', COMENTARIOS='" & comentario & "'")*/
                obj.NombreComercial = producto.NombreComercial;
                obj.NumeroCSSP = producto.NumeroCSSP;
                obj.CPFOMS = producto.CPFOMS;
                obj.Marca = producto.Marca;
                obj.IdPais = producto.IdPais;
                obj.NombreFab = producto.NombreFab;
                obj.Comentarios = producto.Comentarios;
                db.SaveChanges();

            }
        }

        #region Reportes
        public static List<BaseProductosProveedores> ObtenerReporte(decimal idProceso, decimal idTipoProducto, string nit, int estado)
        {
            using (var db = new SinabEntities())
            {
                var res = ObtenerListadoBaseReportes(idProceso, idTipoProducto, db);

                if (!string.IsNullOrEmpty(nit)) res = res.Where(itm => itm.Nit.Contains(nit)).ToList();
               
                //todo??
                
                if (estado < 2) res = res.Where(itm => itm.Estado == estado).ToList();

                return res.OrderBy(itm => itm.Codigo).ToList();
            }
        }
        

        public static List<BaseProductosProveedores> ObtenerReporte(decimal idProceso, decimal idTipoProducto, string nit, string producto, int estado)
        {
            using (var db = new SinabEntities())
            {
                var res = ObtenerListadoBaseReportes(idProceso, idTipoProducto, db);

                if (!string.IsNullOrEmpty(nit)) res = res.Where(itm => itm.Nit.Contains(nit)).ToList();
                if (!string.IsNullOrEmpty(producto))
                    res =
                        res.Where(itm => itm.DescLargo.Contains(producto) || itm.CorrProducto.Contains(producto))
                            .ToList();
                    //todo??
                if (estado < 2) res = res.Where(itm => itm.Estado == estado).ToList();

                return res.OrderBy(itm => itm.Codigo).ToList();
            }
        }
        

        public static List<BaseProductosProveedores> ObtenerReporte(decimal idProceso, decimal idTipoProducto, string nit, string proveedor, string producto, int estado)
        {
            using (var db = new SinabEntities())
            {
                var res = ObtenerListadoBaseReportes(idProceso, idTipoProducto, db);

                if (!string.IsNullOrEmpty(nit)) res = res.Where(itm => itm.Nit.Contains(nit)).ToList();
                if (!string.IsNullOrEmpty(producto)) res = res.Where(itm => itm.DescLargo.Contains(producto) || itm.CorrProducto.Contains(producto)).ToList();
                if (!string.IsNullOrEmpty(proveedor)) res = res.Where(itm => itm.Proveedor.Contains(proveedor)).ToList();
                if (estado < 2) res = res.Where(itm => itm.Estado == estado).ToList();
         
                return res.OrderBy(itm => itm.Codigo).ToList();
            }
        }
        /*
         * SELECT top 1 
         case when ep.estado=0 THEN 'Certificado' ELSE 'No Certificado' END as estado,ep.fecha,ep.comentario 
         FROM sAB_CP_ESTADOSPRODUCTOS EP 
         inner join vv_catalogoproductos v on v.idproducto=ep.idproducto  
         inner join sab_cat_proveedores prov on prov.idproveedor=ep.idproveedor  
         WHERE ep.idproceso= idproceso  and ep.idtipoproducto= idtipoproducto
         and ep.idproveedor= idproveedor  and ep.idproducto= idproducto        
                 and PROV.nit=NIT        
                 and pp.idproveedor= idproveedor        
         ORDER BY EP.FECHA DESC 
         */

       

        public static List<BaseProductosProveedores> ObtenerReporteDetalle(decimal idProceso, decimal idTipoProducto,decimal idProveedor, decimal idPp)
        {
            using (var db = new SinabEntities())
            {
                var res = (from pp in db.SAB_CP_PRODUCTOSPROVEEDORES
                           where pp.IdProceso == idProceso && pp.IdProveedorProceso == idProveedor 
                           && pp.SAB_CP_PROVEEDORESPROCESO.IdTipoProducto == idTipoProducto
                           && pp.Id == idPp
                           let est = pp.SAB_CP_ESTADOSPRODUCTOS.OrderByDescending(ep => ep.Fecha).FirstOrDefault()
                           
                           join p in db.SAB_CP_CAT_PAIS on pp.IdPais equals p.IdPais
                           join vv in db.vv_CATALOGOPRODUCTOS on pp.IdProducto equals vv.IDPRODUCTO
                           join prv in db.SAB_CAT_PROVEEDORES on pp.IdProveedorProceso equals prv.IDPROVEEDOR
                           join su in db.SAB_CAT_SUMINISTROS on pp.SAB_CP_PROVEEDORESPROCESO.IdTipoProducto equals su.IDSUMINISTRO

                           join ap in db.SAB_CP_ASPECTOSPRODUCTOS on pp.Id equals ap.IdProductoProveedores
                           into grp
                           from itm in grp.DefaultIfEmpty()
                           //where ap.estado != 2 //no aplica
                           select new BaseProductosProveedores()
                           {
                               IdProceso = pp.IdProceso,
                               IdTipoProducto = pp.SAB_CP_PROVEEDORESPROCESO.IdTipoProducto,
                               IdProveedorProceso = pp.IdProveedorProceso,
                               IdProducto = pp.IdProducto,
                               IdLista = pp.IdLista??0,
                               Id = pp.Id,
                               Nit = prv.NIT,
                               Proveedor = prv.NOMBRE,
                               TipoProducto = su.DESCRIPCION,
                               CorrProducto = vv.CORRPRODUCTO,
                               DescLargo = vv.DESCLARGO,
                               Marca = pp.Marca,
                               Pais = p.Nombre,
                               Estado = est.estado ?? 1,
                               Certificado = (est.estado ?? 1) == 0 ? "Calificado" : "No Calificado",
                               NumeroProceso = pp.SAB_CP_PROVEEDORESPROCESO.SAB_CP_PROCESO.numproceso,
                               Aspecto = itm != null ? itm.SAB_CP_CAT_ASPECTOS.nombre:"",
                               Correlativo = itm != null ?itm.SAB_CP_CAT_ASPECTOS.orden??1:1,
                               Comentario2 = itm != null ?itm.Comentario:"No Considerado",
                               FechaEmision = itm != null? itm.fechaemision.HasValue ? (DateTime) itm.fechaemision: DateTime.MinValue: DateTime.Now,
                               FechaVto = itm != null? itm.fechavto.HasValue ? (DateTime)itm.fechavto : DateTime.MinValue : DateTime.Now,
                               NumEstadoAspecto = itm != null? ((EnumHelpers.EstadoAspectos)itm.estado): EnumHelpers.EstadoAspectos.NoConsiderado,
                               NombreComercial = pp.NombreComercial,
                               NumeroCSSP = pp.NumeroCSSP

                           }).OrderBy(obj => obj.Correlativo).ToList();
                return res;
            }
        }

        private static List<BaseProductosProveedores> ObtenerListadoBaseReportes(decimal idProceso, decimal idTipoProducto, SinabEntities db)
        {
            var res = (from pp in db.SAB_CP_PRODUCTOSPROVEEDORES
                       where pp.IdProceso == idProceso && pp.SAB_CP_PROVEEDORESPROCESO.IdTipoProducto == idTipoProducto
                       join p in db.SAB_CP_CAT_PAIS on pp.IdPais equals p.IdPais
                       join vv in db.vv_CATALOGOPRODUCTOS on pp.IdProducto equals vv.IDPRODUCTO
                       join prv in db.SAB_CAT_PROVEEDORES on pp.IdProveedorProceso equals prv.IDPROVEEDOR
                       join su in db.SAB_CAT_SUMINISTROS on pp.SAB_CP_PROVEEDORESPROCESO.IdTipoProducto equals
                           su.IDSUMINISTRO
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
                           Estado = est.estado ?? 1,
                           Certificado = (est.estado ?? 1) == 0 ? "Calificado" : "No Calificado",
                           NumeroProceso = pp.SAB_CP_PROVEEDORESPROCESO.SAB_CP_PROCESO.numproceso,
                           Comentario = pp.Comentarios,
                           NumeroCSSP = pp.NumeroCSSP,
                           NombreComercial = pp.NombreComercial,
                           FechaEstado = est.Fecha != null ? (DateTime)est.Fecha : DateTime.MinValue,
                           ComentarioEstado = est.Comentario
                       }).ToList();
            return res;
        }
        #endregion Reportes

    }
}
