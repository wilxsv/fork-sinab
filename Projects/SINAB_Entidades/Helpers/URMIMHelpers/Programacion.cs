using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.URMIMHelpers
{
    public static class Programacion
    {
        public static void CargarProgramacionesALista(ref DropDownList lista)
        {
            List<SAB_URMIM_PROGRAMACION> recs;
            using (var db = new SinabEntities())
            {
                recs = db.SAB_URMIM_PROGRAMACION.Where(p =>
                    p.ESTADO == 4).OrderByDescending(ae => ae.FECHAPROGRAMACION).ToList();
            }

            lista.DataSource = recs;
            lista.DataTextField = "DESCRIPCION";
            lista.DataValueField = "IDPROGRAMACION";
            lista.DataBind();
        }


        
    }
}
