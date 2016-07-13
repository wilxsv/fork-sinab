using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class OfertaProcesoCompra
    {

        public static IQueryable<SAB_UACI_OFERTAPROCESOCOMPRA> ObtenerTodos(int idEstablecimiento, int idProcesoCompra, int idProveedor)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodos(db, idEstablecimiento, idProcesoCompra, idProveedor);
            }
        }


        public static IQueryable<SAB_UACI_OFERTAPROCESOCOMPRA> ObtenerTodos(SinabEntities db, int idEstablecimiento, int idProcesoCompra, int idProveedor)
        {
            return db.SAB_UACI_OFERTAPROCESOCOMPRA.Where(op => op.IDPROCESOCOMPRA == idProcesoCompra && op.IDESTABLECIMIENTO == idEstablecimiento && op.IDPROVEEDOR == idProveedor);
        }

        
    }
}
