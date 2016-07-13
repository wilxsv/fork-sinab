using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class DocumentoBase
    {
        public static List<SAB_CAT_DOCUMENTOSBASE> ObtenerTodos(int tipoDocumentoBase)
        {
            using (var db = new SinabEntities())
            {
                return
                    db.SAB_CAT_DOCUMENTOSBASE.Where(
                        d => d.IDTIPODOCUMENTOBASE == tipoDocumentoBase && d.IDDOCUMENTOBASE > 9997).ToList();
            }
        }

       

        public static List<SAB_CAT_DOCUMENTOSBASE> ObtenerTodos()
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_CAT_DOCUMENTOSBASE.Include(doc => doc.SAB_CAT_TIPODOCUMENTOBASE).ToList();
            }
        }

        #region eliminar
        public static void Eliminar(SAB_CAT_DOCUMENTOSBASE documentosbase)
        {
            using (var db = new SinabEntities())
            {
                Eliminar(db, documentosbase.IDDOCUMENTOBASE);
            }
        }

        public static void Eliminar( int idDocumentoBase)
        {
            using (var db = new SinabEntities())
            {
                Eliminar(db, idDocumentoBase);
            }
        }

        public static void Eliminar(SinabEntities db, int idDocumentoBase)
        {
            var obj = db.SAB_CAT_DOCUMENTOSBASE.FirstOrDefault(doc => doc.IDDOCUMENTOBASE == idDocumentoBase);
            if (obj == null) return;
            db.SAB_CAT_DOCUMENTOSBASE.DeleteObject(obj);
            db.SaveChanges();
        }
        #endregion eliminar

        

    }
}
