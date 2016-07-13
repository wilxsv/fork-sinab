using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class FuentesFinanciamiento
    {
        public static List<SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS> Obtener(SAB_UACI_CONTRATOS contrato)
        {
            using (var db = new SinabEntities())
            {
                var rec = Contratos.Obtener(contrato, db);

                return rec.SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.
                OrderBy(ffc => ffc.Nombre).ToList();
            }
        }

        public static string ObtenerNombres(SAB_UACI_CONTRATOS contrato)
        {
            var recs = new StringBuilder();
            if (!contrato.SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.Any()) return string.Empty;


            contrato.SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.ToList()
                .ForEach(ffc => recs.Append(ffc.SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE + ", "));

            var res = recs.ToString();
            res = res.Remove(res.Length - 2);
            return res;
        }

        public static void CargarALista(ref DropDownList lista, SAB_UACI_CONTRATOS contrato)
        {
            var list = contrato.SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.OrderBy(ffc => ffc.Nombre).ToList();
           
            lista.DataSource = list;
            lista.DataTextField = "Nombre";
            lista.DataValueField = "IDFUENTEFINANCIAMIENTO";
            lista.DataBind();
        }

        public static void Agregar(SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS fuenteFinanciamiento)
        {
            using (var db = new SinabEntities())
            {
                db.SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.AddObject(fuenteFinanciamiento);
                db.SaveChanges();
            }
        }

        public static void Eliminar(SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS fuente)
        {
            using (var db = new SinabEntities())
            {
                var rec = db.SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.FirstOrDefault(ffc =>
                                                                                    ffc.IDFUENTEFINANCIAMIENTO ==
                                                                                    fuente.IDFUENTEFINANCIAMIENTO &&
                                                                                    ffc.IDCONTRATO ==
                                                                                    fuente.IDCONTRATO &&
                                                                                    ffc.IDESTABLECIMIENTO ==
                                                                                    fuente.IDESTABLECIMIENTO &&
                                                                                    ffc.IDPROVEEDOR ==
                                                                                    fuente.IDPROVEEDOR);
                if (rec == null) return;
                db.SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.DeleteObject(rec);
                db.SaveChanges();
            }
        }
    }
}
