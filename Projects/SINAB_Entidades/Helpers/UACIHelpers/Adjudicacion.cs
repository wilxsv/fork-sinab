using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class Adjudicacion
    {
        public static void CargarProveedoresAdjudicadosALista(int idEstablecimiento, int idProcesoCompra,ref DropDownList lista)
        {
            using (var db = new SinabEntities())
            {
                var res = (from ad in db.SAB_UACI_ADJUDICACION
                    join prv in db.SAB_CAT_PROVEEDORES on ad.IDPROVEEDOR equals prv.IDPROVEEDOR
                    join cpc in db.SAB_UACI_CONTRATOSPROCESOCOMPRA
                        on new {ad.IDESTABLECIMIENTO, ad.IDPROCESOCOMPRA, ad.IDPROVEEDOR}
                        equals new {cpc.IDESTABLECIMIENTO, cpc.IDPROCESOCOMPRA, cpc.IDPROVEEDOR}
                        into grp
                    from itm in grp.DefaultIfEmpty()
                    where ad.CANTIDADFIRME > 0 && 
                    ad.IDESTABLECIMIENTO == idEstablecimiento && 
                    ad.IDPROCESOCOMPRA == idProcesoCompra
                           select new BaseProveedorAdjudicado
                    {
                        IdProveedor =ad.IDPROVEEDOR,
                        IdContrato = itm != null ? itm.SAB_UACI_CONTRATOS.IDCONTRATO : 0,
                        IdEstablecimiento = ad.IDESTABLECIMIENTO,
                        Nombre = prv.NOMBRE,
                        NumeroContrato = itm != null ? itm.SAB_UACI_CONTRATOS.NUMEROCONTRATO : "Pendiente"
                    }).Distinct();

                lista.DataSource = res;
                lista.DataTextField = "ProveedorContrato";
                lista.DataValueField = "IdProveedorIdContrato";
                lista.DataBind();

            }
        }
    }
}
