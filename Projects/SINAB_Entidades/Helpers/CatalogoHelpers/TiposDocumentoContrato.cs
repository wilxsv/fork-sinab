using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class TiposDocumentoContrato
    {
        public static void CargarALista( ref DropDownList lista, int clasificacion)
        {
            List<SAB_CAT_TIPODOCUMENTOCONTRATO> list;
            using (var db = new SinabEntities())
            {
                list = db.SAB_CAT_TIPODOCUMENTOCONTRATO.Where(tdc => tdc.APLICASOLOALMACEN == clasificacion).ToList();
            }
            lista.DataSource = list;
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDTIPODOCUMENTO";
            lista.DataBind();
           
        }

        public static void CargarALista(ref DropDownList lista, int clasificacion, SinabEntities db)
        {
            lista.DataSource = db.SAB_CAT_TIPODOCUMENTOCONTRATO.Where(tdc => tdc.APLICASOLOALMACEN == clasificacion).ToList();
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDTIPODOCUMENTO";
            lista.DataBind();

        }

        public static void CargarALista(ref DropDownList lista, bool ordenar = false)
        {
            List<SAB_CAT_TIPODOCUMENTOCONTRATO> listado;
            using (var db = new SinabEntities())
            {
              listado = db.SAB_CAT_TIPODOCUMENTOCONTRATO.ToList();

            }
            lista.DataSource = !ordenar ? listado : listado.OrderBy(s => s.DESCRIPCION).ToList();
            lista.DataTextField = "DescripcionCompleta";
            lista.DataValueField = "IDTIPODOCUMENTO";
            lista.DataBind();
        }
    }
}
