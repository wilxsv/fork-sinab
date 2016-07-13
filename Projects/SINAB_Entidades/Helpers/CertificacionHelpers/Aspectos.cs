using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.CertificacionHelpers
{
    public static class Aspectos
    {
        public static List<BaseAspecto> ObtenerTodos()
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodos(db);
            }

        }

        public static List<BaseAspecto> ObtenerTodos(SAB_CP_PRODUCTOSPROVEEDORES productoProveedores)
        {

            using (var db = new SinabEntities())
            {
                var res = db.SAB_CP_CAT_ASPECTOS.Select(a => new BaseAspecto()
                {
                    Id = a.Id,
                    Orden = a.orden ?? 0,
                    Nombre = a.nombre,
                    Estado = EnumHelpers.EstadoAspectos.NoAplica,
                    IdLista = a.IdLista,
                    IdProductoProveedor =  0
                }).ToList();

                var listAP =
                    db.SAB_CP_ASPECTOSPRODUCTOS.Where(ap => ap.IdProductoProveedores == productoProveedores.Id)
                        .Select(ap => new BaseAspecto()
                        {
                            Id = ap.SAB_CP_CAT_ASPECTOS.Id,
                            Orden = ap.SAB_CP_CAT_ASPECTOS.orden ?? 0,
                            Nombre = ap.SAB_CP_CAT_ASPECTOS.nombre,
                            Estado = (EnumHelpers.EstadoAspectos) ap.estado,
                            IdLista = ap.SAB_CP_CAT_ASPECTOS.IdLista,
                            IdProductoProveedor = ap.IdProductoProveedores
                        }).ToList();


                foreach (var itm in listAP)
                {
                    var obj = res.FirstOrDefault(it => it.Id == itm.Id && it.IdLista == itm.IdLista);
                    res.Remove(obj);
                    res.Add(itm);
                }
                
                
                //si son requerimientos generales filtra por lista
                if (productoProveedores.IdLista == 1)
                {
                    return res.Where(obj => obj.IdLista == productoProveedores.IdLista)
                        .OrderBy(obj => obj.IdLista)
                        .ThenBy(obj => obj.Orden)
                        .ToList();
                }
                //sino no filtra
                return res.OrderBy(obj => obj.IdLista)
                    .ThenBy(obj => obj.Orden)
                    .ToList();
            }
        }

        public static List<BaseAspecto> ObtenerTodos(SinabEntities db)
        {
            return (from a in db.SAB_CP_CAT_ASPECTOS
                select new BaseAspecto
                {
                    IdLista = a.IdLista,
                    
                    Id= a.Id,
                    Nombre = a.nombre,
                    Lista = a.SAB_CP_CAT_LISTA.Nombre,
                    Orden = a.orden??0
                }).OrderBy(obj => obj.IdLista).ThenBy(obj => obj.Orden).ToList();
        }

        public static SAB_CP_CAT_ASPECTOS Obtener(decimal idLista, decimal idAspecto)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idLista, idAspecto);
            }
        }

        public static SAB_CP_CAT_ASPECTOS Obtener(SinabEntities db, decimal idLista, decimal idAspecto)
        {
            return db.SAB_CP_CAT_ASPECTOS.FirstOrDefault(a => a.IdLista == idLista && a.Id == idAspecto);
        }

        public static SAB_CP_CAT_ASPECTOS Obtener(SinabEntities db, int idLista)
        {
            return db.SAB_CP_CAT_ASPECTOS.FirstOrDefault(a => a.IdLista == idLista);
        }

        public static void Agregar(SAB_CP_CAT_ASPECTOS aspecto)
        {
            using (var db = new SinabEntities())
            {
                Agregar(db, aspecto);
            }
        }

        public static void Agregar(SinabEntities db, SAB_CP_CAT_ASPECTOS aspecto)
        {
            try
            {
                
                db.SAB_CP_CAT_ASPECTOS.AddObject(aspecto);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Actualizar(SAB_CP_CAT_ASPECTOS aspecto)
        {
            using (var db = new SinabEntities())
            {
                Actualizar(db, aspecto);
            }
        }

        public static void Actualizar(SinabEntities db, SAB_CP_CAT_ASPECTOS aspecto)
        {
            var obj = Obtener(db, aspecto.IdLista, aspecto.Id);
            if (obj == null) return;
            obj.IdLista = aspecto.IdLista;
            obj.nombre = aspecto.nombre;
            obj.orden = aspecto.orden;
            db.SaveChanges();
        }

        public static void Eliminar(decimal idLista, decimal idAspecto)
        {
            using (var db = new SinabEntities())
            {
                Eliminar(db, idLista, idAspecto);
            }
        }

        public static void Eliminar(SinabEntities db, decimal idLista, decimal idAspecto)
        {
            var obj = Obtener(db, idLista, idAspecto);
            if (obj == null) return;
            db.SAB_CP_CAT_ASPECTOS.DeleteObject(obj);
            db.SaveChanges();
        }

       
        
    }
}
