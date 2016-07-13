using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class ContratosProcesoCompra
    {
        public static List<BaseProductos> ObtenerRenglonesAdjudicados(decimal idProveedor, decimal idEstablecimiento, decimal idProcesoCompra, decimal idContrato)
        {
            var fijos = new List<int>{114, 116, 499};
            var fuentes = new List<int> {76, 30};
            using (var db = new SinabEntities())
            {
                var rec = (from cpc in db.SAB_UACI_CONTRATOSPROCESOCOMPRA
                    where cpc.IDPROVEEDOR == idProveedor &&
                          cpc.IDESTABLECIMIENTO == idEstablecimiento &&
                          cpc.IDPROCESOCOMPRA == idProcesoCompra &&
                          cpc.IDCONTRATO == idContrato

                    join pc in db.SAB_UACI_PRODUCTOSCONTRATO
                        on new {cpc.IDESTABLECIMIENTO, cpc.IDPROVEEDOR, cpc.IDCONTRATO}
                        equals new {pc.IDESTABLECIMIENTO, pc.IDPROVEEDOR, pc.IDCONTRATO}

                    join aec in db.SAB_UACI_ALMACENESENTREGACONTRATOS
                        on new {cpc.IDESTABLECIMIENTO, cpc.IDPROVEEDOR, cpc.IDCONTRATO}
                        equals new {aec.IDESTABLECIMIENTO, aec.IDPROVEEDOR, aec.IDCONTRATO}

                    join dof in db.SAB_UACI_DETALLEOFERTA
                        on new {cpc.IDESTABLECIMIENTO, cpc.IDPROCESOCOMPRA, cpc.IDPROVEEDOR, pc.RENGLON}
                        equals
                        new {dof.IDESTABLECIMIENTO, dof.IDPROCESOCOMPRA, dof.IDPROVEEDOR, RENGLON = (long) dof.RENGLON}

                    join adj in db.SAB_UACI_ADJUDICACION
                        on new {cpc.IDESTABLECIMIENTO, cpc.IDPROCESOCOMPRA, cpc.IDPROVEEDOR}
                        equals new {adj.IDESTABLECIMIENTO, adj.IDPROCESOCOMPRA, adj.IDPROVEEDOR}

                    join cp in db.vv_CATALOGOPRODUCTOS
                        on pc.IDPRODUCTO equals cp.IDPRODUCTO

                    where
                        adj.CANTIDADADJUDICADA > 0 && !fijos.Contains(aec.IDALMACENENTREGA) &&
                        !fuentes.Contains(aec.IDFUENTEFINANCIAMIENTO)

                    select new BaseProductos
                    {
                        IdProducto = pc.IDPRODUCTO,
                        Renglon = pc.RENGLON,
                        CorrProducto = cp.CORRPRODUCTO,
                        DescLargo = cp.DESCLARGO
                    }).ToList();

                return rec;

            }
        }
    }
}
