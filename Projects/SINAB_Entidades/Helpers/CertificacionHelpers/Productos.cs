using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.CertificacionHelpers
{
    public static class Productos
    {

        //SELECT G.IDGRUPOREQ, L.NOMBRE FROM SAB_UACI_GRUPOREQTEC_PRODUCTOS G INNER 
        //JOIN SAB_CP_CAT_LISTA L ON G.IDGRUPOREQ=L.IDLISTA AND L.IDSUMINISTRO=" & IDSUMINISTRO & " 
        //WHERE G.IDPRODUCTO=" & idproducto
        public static BaseProductos ObtenerPorLista(int idSuministro, int idProducto)
        {
            using (var db = new SinabEntities())
            {
                var res = (from g in db.SAB_UACI_GRUPOREQTEC_PRODUCTOS
                    join l in db.SAB_CP_CAT_LISTA
                        on new
                        {
                            id = g.IDGRUPOREQ,
                            idSuministro
                        } equals new
                        {
                            id = l.Id,
                            idSuministro = l.IdSuministro ?? 0
                        }
                        where g.IDPRODUCTO == idProducto
                    select new BaseProductos()
                    {
                        IdGrupoReq = g.IDGRUPOREQ,
                        Nombre = l.Nombre,
                    }).FirstOrDefault();
                return res;
            }
        }

        public static BaseProductos ObneterPorCodigo(string CorrProducto)
        {
            using (var db = new SinabEntities())
            {
                var res = (from cp in db.vv_CATALOGOPRODUCTOS
                    join gp in db.SAB_UACI_GRUPOREQTEC_PRODUCTOS on cp.IDPRODUCTO equals gp.IDPRODUCTO
                    where cp.PERTENECELISTADOOFICIAL == 1 && cp.CORRPRODUCTO.Contains(CorrProducto)
                    select new BaseProductos()
                    {
                        IdProducto = cp.IDPRODUCTO,
                        CorrProducto = cp.CORRPRODUCTO,
                        DescLargo = cp.DESCLARGO,
                        UnidadMedida = cp.UNIDADMEDIDA
                    }).FirstOrDefault();
                return res;

            }
        }

        public static BaseProductos ObneterPorDesc(string descripcion)
        {
            using (var db = new SinabEntities())
            {
                var res = (from cp in db.vv_CATALOGOPRODUCTOS
                    join gp in db.SAB_UACI_GRUPOREQTEC_PRODUCTOS on cp.IDPRODUCTO equals gp.IDPRODUCTO
                    where cp.PERTENECELISTADOOFICIAL == 1 && cp.DESCLARGO.Contains(descripcion)
                    select new BaseProductos()
                    {
                        IdProducto = cp.IDPRODUCTO,
                        CorrProducto = cp.CORRPRODUCTO,
                        DescLargo = cp.DESCLARGO,
                        UnidadMedida = cp.UNIDADMEDIDA
                    }).FirstOrDefault();
                return res;

            }

        }

        public static List<BaseProductos> ObneterTodosPorCodigo(string CorrProducto)
        {
            using (var db = new SinabEntities())
            {
                var res = (from cp in db.vv_CATALOGOPRODUCTOS
                    join gp in db.SAB_UACI_GRUPOREQTEC_PRODUCTOS on cp.IDPRODUCTO equals gp.IDPRODUCTO
                    where cp.PERTENECELISTADOOFICIAL == 1 && cp.CORRPRODUCTO.Contains(CorrProducto)
                    select new BaseProductos()
                    {
                        IdProducto = cp.IDPRODUCTO,
                        CorrProducto = cp.CORRPRODUCTO,
                        DescLargo = cp.DESCLARGO,
                        UnidadMedida = cp.UNIDADMEDIDA
                    });
                return res.ToList();

            }
        }

        public static List<BaseProductos> ObneterTodosPorDesc(string descripcion)
        {
            using (var db = new SinabEntities())
            {
                var res = (from cp in db.vv_CATALOGOPRODUCTOS
                    join gp in db.SAB_UACI_GRUPOREQTEC_PRODUCTOS on cp.IDPRODUCTO equals gp.IDPRODUCTO
                    where cp.PERTENECELISTADOOFICIAL == 1 && cp.DESCLARGO.Contains(descripcion)
                    select new BaseProductos()
                    {
                        IdProducto = cp.IDPRODUCTO,
                        CorrProducto = cp.CORRPRODUCTO,
                        DescLargo = cp.DESCLARGO,
                        UnidadMedida = cp.UNIDADMEDIDA
                    });
                return res.ToList();

            }

        }
    }
}

