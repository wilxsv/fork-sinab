using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public class Suministros
    {
        //public ObjectSet<SAB_CAT_SUMINISTROS> Obtener(SinabEntities db) {
        //            return db.SAB_CAT_SUMINISTROS;
        //}

        public static SAB_CAT_SUMINISTROS Obtener(int id)
        {
            using (var db = new SinabEntities())
            {
               return db.SAB_CAT_SUMINISTROS.FirstOrDefault(i => i.IDSUMINISTRO == id);
            }
        }

        public static void CargarAListavv(DropDownList lista)
        {
            using (var db = new SinabEntities())
            {
                var recs = db.vv_CATALOGOPRODUCTOS.Where(vv => vv.PERTENECELISTADOOFICIAL == 1 && vv.ESTADOPRODUCTO == 1)
                    .Select(vv => new
                                      {
                                          DESCSUMINISTRO = "(" + vv.CORRSUMINISTRO + ") " + vv.DESCSUMINISTRO,
                                          vv.IDSUMINISTRO,
                                          vv.CORRSUMINISTRO
                                      }).Distinct().OrderBy(vv => vv.CORRSUMINISTRO);
                lista.DataSource = recs;
                lista.DataTextField = "DESCSUMINISTRO";
                lista.DataValueField = "IDSUMINISTRO";
                lista.DataBind();
                lista.Items.Insert(0, new ListItem("[SELECCIONE SUMINISTRO]", string.Empty));
            }
        }

        public static void CargarALista(SinabEntities db, ref DropDownList lista)
        {
            lista.DataSource = db.SAB_CAT_SUMINISTROS.ToList();
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDSUMINISTRO";
            lista.DataBind();
        }

        public static void CargarALista(ref DropDownList lista, bool ordenar = false)
        {
            List<SAB_CAT_SUMINISTROS> listado;

            using (var db = new SinabEntities())
            {
                listado = db.SAB_CAT_SUMINISTROS.ToList();
            }

            lista.DataSource = !ordenar ? listado : listado.OrderBy(s => s.CORRELATIVO).ToList();
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDSUMINISTRO";
            lista.DataBind();
        }

       public static void CargarALista(SinabEntities db, ref DropDownList lista, bool ordenar)
        {
            var listado = db.SAB_CAT_SUMINISTROS.ToList();
            
            lista.DataSource = !ordenar ? listado : listado.OrderBy(s => s.CORRELATIVO).ToList();
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDSUMINISTRO";
            lista.DataBind();
        }

        public static void CargarSubGruposALista(int idGrupo,  DropDownList lista)
        {
            using (var db = new SinabEntities())
            {
                var recs = db.vv_CATALOGOPRODUCTOS.Where(vv => vv.IDGRUPO == idGrupo && vv.PERTENECELISTADOOFICIAL == 1 && vv.ESTADOPRODUCTO == 1 )
                    .Select(vv => new
                                      {
                                          vv.IDSUBGRUPO,
                                          DESCSUBGRUPO = "(" + vv.CORRSUBGRUPO + ") " + vv.DESCSUBGRUPO,
                                          vv.CORRSUBGRUPO
                                      }).Distinct()
                    .OrderBy(vv => vv.CORRSUBGRUPO);
                lista.DataSource = recs;
                lista.DataTextField = "DESCSUBGRUPO";
                lista.DataValueField = "IDSUBGRUPO";
                lista.DataBind();
                lista.Items.Insert(0, new ListItem("[SELECCIONE SUBGRUPO]", string.Empty));
            }
        }

        public static void CargarProductosALista(int idSubGrupo,  DropDownList lista)
        {
            using (var db = new SinabEntities())
            {
                var recs = db.vv_CATALOGOPRODUCTOS.Where(vv => vv.IDSUBGRUPO == idSubGrupo && vv.PERTENECELISTADOOFICIAL == 1 && vv.ESTADOPRODUCTO == 1)
                    .Select(vv => new
                    {
                        vv.IDPRODUCTO,
                        DESCLARGO = vv.CORRPRODUCTO + " - " + vv.DESCLARGO,
                        vv.CORRPRODUCTO
                    }).Distinct()
                    .OrderBy(vv => vv.CORRPRODUCTO);
                lista.DataSource = recs;
                lista.DataTextField = "DESCLARGO";
                lista.DataValueField = "IDPRODUCTO";
                lista.DataBind();
                lista.Items.Insert(0, new ListItem("[SELECCIONE PRODUCTO]", string.Empty));
            }
        }

        public static void CargarGruposALista(int idSuministro,  DropDownList lista)
        {
            using (var db = new SinabEntities())
            {
                var recs = db.vv_CATALOGOPRODUCTOS.Where(vv => vv.IDSUMINISTRO == idSuministro && vv.PERTENECELISTADOOFICIAL == 1 && vv.ESTADOPRODUCTO == 1)
                    .Select(vv => new
                                      {
                                          vv.IDGRUPO,
                                          DESCGRUPO = "(" + vv.CORRGRUPO + ") " + vv.DESCGRUPO,
                                          vv.CORRGRUPO
                                      }).Distinct()
                    .OrderBy(vv => vv.CORRGRUPO);

                lista.DataSource = recs;
                lista.DataTextField = "DESCGRUPO";
                lista.DataValueField = "IDGRUPO";
                lista.DataBind();
                lista.Items.Insert(0, new ListItem("[SELECCIONE GRUPO]", string.Empty));
            }
           
        }

        public int ObtenerPorMovimiento(int idEstablecimiento, int idTipoTransaccion, int idMovimiento )
        {
            var db = new SinabEntities();
            var res = db.SAB_ALM_DETALLEMOVIMIENTOS.
                Where(dm => dm.IDESTABLECIMIENTO == idEstablecimiento && dm.IDTIPOTRANSACCION == idTipoTransaccion && dm.IDMOVIMIENTO == idMovimiento).
                GroupJoin(db.vv_CATALOGOPRODUCTOS, dm => dm.IDPRODUCTO, vvp => vvp.IDPRODUCTO, (dm, vvp) => new {dm, vvp}).
                SelectMany(grupo => grupo.vvp.DefaultIfEmpty(), (g, vvp) => new
                                                                                 {
                                                                                     g.dm.IDESTABLECIMIENTO,
                                                                                     g.dm.IDTIPOTRANSACCION,
                                                                                     g.dm.IDMOVIMIENTO,
                                                                                     g.vvp.FirstOrDefault().IDSUMINISTRO,
                                                                                     Cantidad = g.vvp.Count(v => v.IDPRODUCTO == g.dm.IDPRODUCTO)
                                                                                 }).
               
                OrderBy(g => g.IDESTABLECIMIENTO).
                ThenBy(g => g.IDTIPOTRANSACCION).
                ThenBy(g => g.IDMOVIMIENTO).
                ThenBy(g => g.IDSUMINISTRO).
                ThenByDescending(u => u.Cantidad);
                
            return res.Select(p => p.IDSUMINISTRO).FirstOrDefault();
            /*
              var db = new SinabEntities();
            var res = (from dm in db.SAB_ALM_DETALLEMOVIMIENTOS
                       where dm.IDESTABLECIMIENTO == idEstablecimiento && dm.IDTIPOTRANSACCION == idTipoTransaccion && dm.IDMOVIMIENTO == idMovimiento
                      join cp in db.vv_CATALOGOPRODUCTOS on dm.IDPRODUCTO equals  cp.IDPRODUCTO
                      select  new
                              {
                                   dm.IDESTABLECIMIENTO,
                                   dm.IDTIPOTRANSACCION,
                                   dm.IDMOVIMIENTO,
                                   cp.IDSUMINISTRO
                              }).
                OrderBy(g => g.IDESTABLECIMIENTO).
                ThenBy(g => g.IDTIPOTRANSACCION).
                ThenBy(g => g.IDMOVIMIENTO).
                ThenBy(g => g.IDSUMINISTRO);
                
            return res.Select(p => p.IDSUMINISTRO).FirstOrDefault();
             */
        }

    }
}
