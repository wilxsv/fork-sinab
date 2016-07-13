using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using SINAB_Entidades.Helpers.CatalogoHelpers;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class CifradoProductoSolicitud
    {

        public static bool Existe(long idSolicitud, int idEstablecimiento, int idProducto, long renglon)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.Any(
                    cp =>
                        cp.IdSolicitud == idSolicitud && cp.IdEstablecimiento == idEstablecimiento &&
                        cp.IdProducto == idProducto && cp.Renglon == renglon);
            }
        }

        public static List<SAB_EST_CIFRADOPRODUCTOSSOLICITUDES> ObtenerTodos(long idSolicitud, int idEstablecimiento, int idProducto, long renglon)
        {
            using (var db = new SinabEntities())
            {
                return
                    ObtenerTodos(db, idSolicitud, idEstablecimiento, idProducto, renglon);
            }
        }

        public static List<SAB_EST_CIFRADOPRODUCTOSSOLICITUDES> ObtenerTodos(SinabEntities db, long idSolicitud, int idEstablecimiento, int idProducto, long renglon)
        {
            
                   return db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.Where(
                        cp =>
                            cp.IdSolicitud == idSolicitud && cp.IdEstablecimiento == idEstablecimiento &&
                            cp.IdProducto == idProducto && cp.Renglon == renglon).ToList();
            
        }

        //public static List<BaseCifrados> ObtenerTodosConsolidados(int idEstablecimiento, int idSolicitud)
        //{
        //    using (var db = new SinabEntities())
        //    {
        //        var res = from cp in db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES
        //            where cp.IdSolicitud == idSolicitud && cp.IdEstablecimiento == idEstablecimiento
                   
        //            select new BaseCifrados()
        //            {
        //                IdSolicitud =cp.IdSolicitud,
        //                IdEstablecimiento = cp.IdEstablecimiento,
        //                IdProducto = cp.IdProducto,
        //                Renglon = cp.Renglon,
                       
        //                FuenteFinanciamiento = cp.FuenteFinanciamiento,
        //            };

        //        return res.ToList();
        //    }
        //}


        public static List<SAB_EST_CIFRADOPRODUCTOSSOLICITUDES> ObtenerTodos(SinabEntities db, long idSolicitud, int idEstablecimiento, long idProducto, long renglon, int idFuenteFinanciamiento, int idAlmacenEntrega)
        {
            return
                db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.Where(
                    cp => cp.IdSolicitud == idSolicitud && cp.IdEstablecimiento == idEstablecimiento &&
                          cp.IdProducto == idProducto && cp.Renglon == renglon).Distinct().ToList();
        }


        public static List<SAB_EST_CIFRADOPRODUCTOSSOLICITUDES> ObtenerTodos( long idSolicitud, int idEstablecimiento, long idProducto, long renglon, int idFuenteFinanciamiento, int idAlmacenEntrega)
        {
            using (var db = new SinabEntities())
            {
                var rec = ObtenerTodos(db, idSolicitud, idEstablecimiento, idProducto, renglon, idFuenteFinanciamiento,
                    idAlmacenEntrega);
                return rec ?? new List<SAB_EST_CIFRADOPRODUCTOSSOLICITUDES>();
            }
        }

        public static void Eliminar(int id, int idSolicitud, int indEstablecimiento, int idProducto)
        {
            using (var db = new SinabEntities())
            {
                var cp = Obtener(db, id);
                if (cp == null) return;
                db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.DeleteObject(cp);
                db.SaveChanges();
            }
        }

        public static SAB_EST_CIFRADOPRODUCTOSSOLICITUDES Obtener(SinabEntities db, int id)
        {
            var cp = db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.FirstOrDefault(c => c.Id == id);
            return cp;
        }

        public static SAB_EST_CIFRADOPRODUCTOSSOLICITUDES Obtener(int id)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, id);
            }
        }

        public static void Eliminar(SinabEntities db, SAB_EST_CIFRADOPRODUCTOSSOLICITUDES cifrado)
        {
            var itm = Obtener(db, cifrado.Id);
            db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.DeleteObject(itm);
            db.SaveChanges();
        }

        public static void Eliminar(SAB_EST_CIFRADOPRODUCTOSSOLICITUDES cifrado)
        {
            using (var db = new SinabEntities())
            {
                Eliminar(db, cifrado);
            }
        }

        public static void EliminarTodos(int idSolicitud, int indEstablecimiento, int idProducto)
        {
            using (var db = new SinabEntities())
            {
                var res = db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.Where(c =>
                    c.IdSolicitud == idSolicitud &&
                    c.IdEstablecimiento == indEstablecimiento &&
                    c.IdProducto == idProducto).ToList();

                res.ForEach(c => db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.DeleteObject(c));
                db.SaveChanges();
            }
        }

        public static void AgregarVarios(List<SAB_EST_CIFRADOPRODUCTOSSOLICITUDES> listado)
        {
            using (var db = new SinabEntities())
            {
                foreach (var cp  in listado)
                {
                    db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.AddObject(cp);
                }
                db.SaveChanges();
            }
        }

        public static void Agregar(SinabEntities db, SAB_EST_CIFRADOPRODUCTOSSOLICITUDES cifrado)
        {
            db.SAB_EST_CIFRADOPRODUCTOSSOLICITUDES.AddObject(cifrado);
            db.SaveChanges();
        }

        public static void Agregar(SAB_EST_CIFRADOPRODUCTOSSOLICITUDES cifrado)
        {
            using(var db = new SinabEntities())
            {
                Agregar(db, cifrado);
            }
        }


       

    }
}
