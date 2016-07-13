using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SINAB_Entidades.Helpers.CertificacionHelpers
{
    public class ProcesosCertificacion
    {
        #region Eliminar

        public static void Eliminar(SAB_CP_PC proceso)
        {
            try
            {
                using (var db = new SinabEntities())
                {
                    Eliminar(db, proceso);
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }

        public static void Eliminar(SinabEntities db, SAB_CP_PC proceso)
        {
            
            var obj = Obtener(db, proceso);
            if (obj == null) return;
            db.SAB_CP_PC.DeleteObject(obj);
            db.SaveChanges();
        }

       
        #endregion Eliminar

        #region Obtener

        public static SAB_CP_PC Obtener()
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_CP_PC.OrderByDescending(obj => obj.Id).FirstOrDefault();
            }
        }

        public static SAB_CP_PC Obtener(SAB_CP_PC proceso)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, proceso);
            }
        }

        public static SAB_CP_PC Obtener(SinabEntities db, SAB_CP_PC proceso)
        {
            return db.SAB_CP_PC.FirstOrDefault(cp => cp.Id == proceso.Id);
        }

        #endregion Obtener

        #region Agregar
        public static void Agregar(SAB_CP_PC proceso)
        {
            using (var db = new SinabEntities())
            {
                Agregar(db, proceso);
            }
        }

        public static void Agregar(SinabEntities db, SAB_CP_PC proceso)
        {
            db.SAB_CP_PC.AddObject(proceso);
            db.SaveChanges();
        }

        #endregion Agregar

        #region ObtenerTodos
      

        public static List<SAB_CP_PC> ObtenerTodos(int idProductoProveedor)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodos(db, idProductoProveedor);
            }
        }

        public static List<SAB_CP_PC> ObtenerTodos(SinabEntities db,  int idProductoProveedor)
        {
            return db.SAB_CP_PC.Where(cp => cp.IdProductoProveedor == idProductoProveedor).ToList();
        }
        #endregion ObtenerTodos

        

    }
}
