using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.CertificacionHelpers
{
    public static class Listas
    {
        public static List<BaseLista> ObtenerTodos()
        {
            using (var db = new SinabEntities())
            {
                return (from l in db.SAB_CP_CAT_LISTA
                    join s in db.SAB_CAT_SUMINISTROS on l.IdSuministro equals s.IDSUMINISTRO
                    select new BaseLista
                    {
                        Id = l.Id,
                        IdSuministro = l.IdSuministro,
                        Nombre = l.Nombre,
                        Suministro = s.DESCRIPCION
                    }).ToList();
            }
        }

        public static void CargarALista(ref DropDownList lista)
        {
            var recs = ObtenerTodos();

            lista.DataSource = recs;
            lista.DataTextField = "Nombre";
            lista.DataValueField = "Id";
            lista.DataBind();
        }

        public static void Agregar(SAB_CP_CAT_LISTA lista)
        {
            using (var db = new SinabEntities())
            {
                db.SAB_CP_CAT_LISTA.AddObject(lista);
                db.SaveChanges();
            }
        }

        public static void Actualizar(SAB_CP_CAT_LISTA lista)
        {
            using (var db = new SinabEntities())
            {
                var l = Obtener(db, lista.Id);
                if (l == null) return;
                l.Nombre = lista.Nombre;
                db.SaveChanges();
            }

        }

        public static void Borrar(int idLista)
        {
            using (var db = new SinabEntities())
            {
                var l = Obtener(db, idLista);
                if(l == null) throw new Exception("No se pudo encontrar la lista a Borrar, la operación se ha detenido");
                db.SAB_CP_CAT_LISTA.DeleteObject(l);
                db.SaveChanges();
            }
        }

        #region Obtener
        public static SAB_CP_CAT_LISTA Obtener(SinabEntities db, int idLista)
        {
            return db.SAB_CP_CAT_LISTA.FirstOrDefault(l => l.Id == idLista);
        }

        public static SAB_CP_CAT_LISTA Obtener(int idLista)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idLista);
            }
        }

        public static SAB_CP_CAT_LISTA Obtener(int idProducto, int idTipoProducto)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idProducto, idTipoProducto);
            }
        }

        public static SAB_CP_CAT_LISTA Obtener(SinabEntities db, int idProducto, int idTipoProducto)
        {
            return (from g in db.SAB_UACI_GRUPOREQTEC_PRODUCTOS
                where g.IDPRODUCTO == idProducto
                join l in db.SAB_CP_CAT_LISTA on new
                {
                    IdLista = g.IDGRUPOREQ,
                    IdSuministro = idTipoProducto
                } equals new
                {
                    IdLista = l.Id,
                    IdSuministro = l.IdSuministro ?? 0
                }
                select l).FirstOrDefault();
        }
        #endregion Obtener
    }
}
