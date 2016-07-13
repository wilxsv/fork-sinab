using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CertificacionHelpers
{
    public static class Paises
    {
        public static SAB_CP_CAT_PAIS Obtener(decimal idPais)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_CP_CAT_PAIS.FirstOrDefault(p => p.IdPais == idPais);
            }
        }

        public static List<SAB_CP_CAT_PAIS> ObtenerTodos()
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_CP_CAT_PAIS.OrderBy(p=>p.Nombre).ToList();
            }
        }

        public static void CargarALista(ref DropDownList lista)
        {
            var recs = ObtenerTodos();

            lista.DataSource = recs;
            lista.DataTextField = "Nombre";
            lista.DataValueField = "IdPais";
            lista.DataBind();
        }
    }
}
