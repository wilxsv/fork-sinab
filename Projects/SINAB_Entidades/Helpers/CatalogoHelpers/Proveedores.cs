using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class Proveedores
    {
        public static void CargarALista(ref DropDownList lista, int tipo = 1)
        {
            List<SAB_CAT_PROVEEDORES> list;
            using (var db = new SinabEntities())
            {
                list = db.SAB_CAT_PROVEEDORES.ToList();
            }

            lista.DataSource = tipo == 1 ? list.OrderBy(p => p.NOMBRE) : list.OrderByDescending(p => p.NOMBRE);

            lista.DataTextField = "NOMBRE";
            lista.DataValueField = "IDPROVEEDOR";
            lista.DataBind();

        }

        public static void CargarALista(ref DropDownList lista, SinabEntities db, int tipo = 1)
        {
            lista.DataSource = tipo == 1 ? db.SAB_CAT_PROVEEDORES.OrderBy(p => p.NOMBRE) : db.SAB_CAT_PROVEEDORES.OrderByDescending(p => p.NOMBRE);
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDTIPODOCUMENTO";
            lista.DataBind();

        }

        public static SAB_CAT_PROVEEDORES Proveedor(int idProveedor)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idProveedor);
            }
        }

        public static bool Existe(int idProveedor)
        {
            using (var db = new SinabEntities())
            {
                return Existe(db, idProveedor);
            }
        }

        public static bool Existe(SinabEntities db, int idProveedor)
        {
            return db.SAB_CAT_PROVEEDORES.Any(p => p.IDPROVEEDOR == idProveedor);
        }

        public static List<ProveedorFiltrado> ObtenerTodos(string param)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_CAT_PROVEEDORES.
                    Where(p => p.NOMBRE.Contains(param) || p.NIT.Contains(param)).
                    Select(p => new ProveedorFiltrado()
                    {
                        Id = p.IDPROVEEDOR,
                        Nombre = p.NOMBRE,
                        Nit = p.NIT
                    }).Take(20).ToList();
            }
        }

        public static ProveedorFiltrado Obtener(string param)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_CAT_PROVEEDORES.
                    Where(p => p.NOMBRE.Contains(param) || p.NIT.Contains(param)).
                    Select(p => new ProveedorFiltrado()
                    {
                        Id = p.IDPROVEEDOR,
                        Nombre = p.NOMBRE,
                        Nit = p.NIT
                    }).FirstOrDefault();
            }
        }

        public static ProveedorFiltrado Obtener(SinabEntities db, string param)
        {

            return db.SAB_CAT_PROVEEDORES.
                Where(p => p.NOMBRE.Contains(param) || p.NIT.Contains(param)).
                Select(p => new ProveedorFiltrado()
                {
                    Id = p.IDPROVEEDOR,
                    Nombre = p.NOMBRE,
                    Nit = p.NIT
                }).FirstOrDefault();

        }
        public static SAB_CAT_PROVEEDORES Obtener(int idProveedor)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idProveedor);
            }
        }

        public static SAB_CAT_PROVEEDORES Obtener(SinabEntities db, int idProveedor)
        {
            return db.SAB_CAT_PROVEEDORES.FirstOrDefault(p => p.IDPROVEEDOR == idProveedor);
        }

        public static SAB_CAT_PROVEEDORES Obtener(decimal idProceso, decimal idTipoProducto, decimal idProveedor)
        {
            using (var db = new SinabEntities())
            {
                return (from pp in db.SAB_CP_PROVEEDORESPROCESO
                        join p in db.SAB_CAT_PROVEEDORES on
                            pp.Id equals p.IDPROVEEDOR
                        where
                            pp.IdTipoProducto == idTipoProducto && pp.IdProceso == idProceso &&
                            pp.Id == idProveedor
                        select p).FirstOrDefault();
            }
        }

    }

    public class ProveedorFiltrado
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }


    }
}
