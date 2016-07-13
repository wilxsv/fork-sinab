using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web.UI.WebControls.WebParts;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers
{
    public class Productos
    {


        public static List<ProductoFiltrado> Obtener()
        {
            using (var db = new SinabEntities())
            {
                return db.vv_CATALOGOPRODUCTOS.Where(vv => vv.PERTENECELISTADOOFICIAL == 1 && vv.ESTADOPRODUCTO == 1)
                    .Select(vv => new ProductoFiltrado()
                    {
                        Id = vv.IDPRODUCTO,
                        Descripcion = vv.CORRPRODUCTO + " - " + vv.DESCLARGO,
                        Correlativo = vv.CORRPRODUCTO
                    }).Distinct()
                    .OrderBy(vv => vv.Correlativo).ToList();


            }

        }

        public static List<DistribucionProducto> Obtener(int idAlmacen, int idTipoSuministro, int? idGrupo = null,
            int? idSubGrupo = null)
        {
            using (var db = new SinabEntities())
            {
                var list = db.vv_CATALOGOPRODUCTOS.Join(db.vv_EXISTENCIASALMACENES,
                    cp => cp.IDPRODUCTO, ea => ea.IDPRODUCTO,
                    (cp, ea) => new DistribucionProducto
                    {
                        IdProducto = cp.IDPRODUCTO,
                        CorrProducto = cp.CORRPRODUCTO,
                        DescProducto = cp.DESCPRODUCTO,
                        DescLargo = cp.DESCLARGO,
                        Descripcion = cp.DESCRIPCION,
                        CorrelativoDescripcion = "(" + cp.CORRPRODUCTO + ") " + cp.DESCLARGO,
                        ExistenciaActual = cp.EXISTENCIAACTUAL ?? 0,
                        CantidadDisponible = ea.CANTIDADDISPONIBLE ?? 0,
                        CantidadNoDisponible = ea.CANTIDADNODISPONIBLE ?? 0,
                        CantidadReservada = ea.CANTIDADRESERVADA ?? 0,
                        CantidadTemporal = ea.CANTIDADTEMPORAL ?? 0,
                        CantidadVencida = ea.CANTIDADVENCIDA,
                        IdAlmacen = ea.IDALMACEN,
                        IdSuministro = cp.IDSUMINISTRO,
                        CorrSuministro = cp.CORRSUMINISTRO,
                        DescSuministro = cp.DESCSUMINISTRO,
                        IdGrupo = cp.IDGRUPO,
                        CorrGrupo = cp.CORRGRUPO,
                        DescGrupo = cp.DESCGRUPO,
                        IdSubGrupo = cp.IDSUBGRUPO,
                        CorrSubGrupo = cp.CORRSUBGRUPO,
                        DescSubGrupo = cp.DESCSUBGRUPO,
                        NombreCorto = cp.NOMBRECORTO,
                        PrecioActual = cp.PRECIOACTUAL ?? 0,
                    }).Where(g =>
                        g.IdAlmacen == idAlmacen &&
                        g.IdSuministro == idTipoSuministro &&
                        g.CantidadDisponible > 0
                    ).ToList();

                if (idGrupo == null) return list;

                list = list.Where(p => p.IdGrupo == idGrupo).ToList();
                if (idSubGrupo != null)
                {
                    list = list.Where(p => p.IdSubGrupo == idSubGrupo).ToList();
                }
                return list;
            }
        }

        public static List<ProductoFiltrado> ObtenerPorSuministro(int idAlmacen, int idTipoSuministro)
        {
            using (var db = new SinabEntities())
            {
                var list = db.vv_CATALOGOPRODUCTOS.Join(db.vv_EXISTENCIASALMACENES,
                    cp => cp.IDPRODUCTO, ea => ea.IDPRODUCTO,
                    (cp, ea) => new ProductoFiltrado
                    {
                        Id = cp.IDPRODUCTO,
                        Correlativo = cp.CORRPRODUCTO,
                        Descripcion = "(" + cp.CORRPRODUCTO + ") " + cp.DESCLARGO,

                        IdAlmacen = ea.IDALMACEN,
                        IdSuministro = cp.IDSUMINISTRO,

                    }).Where(g =>
                        g.IdAlmacen == idAlmacen &&
                        g.IdSuministro == idTipoSuministro

                    ).ToList();


                return list;
            }
        }

        public static List<rpt_ProductosContratadosProgramacion_Result> ObtenerPorProgramacion(int idProgramacionCompra,
            bool esCantidadAjustada)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerPorProgramacion(db, idProgramacionCompra, esCantidadAjustada);
            }

        }

        public static List<rpt_ProductosContratadosProgramacion_Result> ObtenerPorProgramacion(SinabEntities db,
            int idProgramacionCompra, bool esCantidadAjustada)
        {
            return db.rpt_ProductosContratadosProgramacion(idProgramacionCompra, esCantidadAjustada).ToList();
        }

        public static vv_CATALOGOPRODUCTOS Buscar(long idProducto, int tipoConsulta = 0, int suministro = 0)
        {
            var db = new SinabEntities();

            if (tipoConsulta <= 0)
            {
                return db.vv_CATALOGOPRODUCTOS.FirstOrDefault(p =>
                    p.IDPRODUCTO == idProducto &&
                    (p.IDSUMINISTRO == suministro || suministro == 0));
            }

            var grupos = new List<Int32> {104, 106, 193, 57, 191, 194, 195, 197, 198};
            return db.vv_CATALOGOPRODUCTOS.FirstOrDefault(p =>
                p.IDPRODUCTO == idProducto &&
                (p.PERTENECELISTADOOFICIAL == 1 ||
                 grupos.Contains(p.IDGRUPO)) &&
                (p.IDSUMINISTRO == suministro || suministro == 0));
        }

        public static vv_CATALOGOPRODUCTOS Obtener(int idProducto)
        {
            using (var db = new SinabEntities())
            {
                return db.vv_CATALOGOPRODUCTOS.FirstOrDefault(vvp => vvp.IDPRODUCTO == idProducto);
            }
        }

        public static BaseProductos ObtenerPorProveedor(decimal idProductoProveedor)
        {
            using (var db = new SinabEntities())
            {
                var res = from vv in db.vv_CATALOGOPRODUCTOS
                          join pp in db.SAB_CP_PRODUCTOSPROVEEDORES on vv.IDPRODUCTO equals pp.IdProducto
                          join cp in db.SAB_CP_CAT_PAIS on pp.IdPais equals cp.IdPais into grp
                          from obj in grp.DefaultIfEmpty()
                          where pp.Id == idProductoProveedor
                          select new BaseProductos()
                          {
                              IdProducto = vv.IDPRODUCTO,
                              CorrProducto = vv.CORRPRODUCTO,
                              DescLargo = vv.DESCLARGO,
                              Nombre = obj != null ? obj.Nombre : " -- "
                          };
                return res.FirstOrDefault();
            }
        }
    }

    public class ProductoFiltrado
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string Correlativo { get; set; }

        public int IdAlmacen { get; set; }

        public int IdSuministro { get; set; }
    }

}
