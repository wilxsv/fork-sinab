using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class ResponsablesDistribucion
    {
        public static List<SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO> Obtener(SAB_UACI_CONTRATOS contrato)
        {
            using (var db = new SinabEntities())
            {
                var rec = Contratos.Obtener(contrato, db);
                return rec.SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO.OrderBy(rdc => rdc.Nombre).ToList();
            }
        }

        public static string ObtenerNombres(SAB_UACI_CONTRATOS contrato)
        {
            var recs = new StringBuilder();
            if (!contrato.SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO.Any()) return string.Empty;

            contrato.SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO.ToList()
                .ForEach(rdc => recs.Append(rdc.SAB_CAT_RESPONSABLEDISTRIBUCION.NOMBRE + ", "));

            var res = recs.ToString();
            res = res.Remove(res.Length - 2);
            return res;
        }

        public static void CargarALista(ref DropDownList lista, SAB_UACI_CONTRATOS contrato)
        {
            var list = contrato.SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO.OrderBy(rdc => rdc.Nombre).ToList();

            lista.DataSource = list;
            lista.DataTextField = "Nombre";
            lista.DataValueField = "IDRESPONSABLEDISTRIBUCION";
            lista.DataBind();

        }

        public static void Agregar(SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO responsable)
        {
            using (var db = new SinabEntities())
            {
                db.SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO.AddObject(responsable);
                db.SaveChanges();
            }
        }

        public static void Eliminar(SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO responsable)
        {
            using (var db = new SinabEntities())
            {
                var rec = db.SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO.FirstOrDefault(r =>
                                                                                     r.IDRESPONSABLEDISTRIBUCION == responsable.IDRESPONSABLEDISTRIBUCION &&
                                                                                     r.IDESTABLECIMIENTO == responsable.IDESTABLECIMIENTO &&
                                                                                     r.IDPROVEEDOR == responsable.IDPROVEEDOR &&
                                                                                     r.IDCONTRATO == responsable.IDCONTRATO);
                if (rec == null) return;
                db.SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO.DeleteObject(rec);
                db.SaveChanges();
            }
        }
    }
}
