using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class DetalleOferta
    {
        public static IQueryable<SAB_UACI_DETALLEOFERTA> ObtenerTodos(SinabEntities db, int idEstablecimiento,
            int idProcesoCompra, int idProveedor)
        {
            return
                db.SAB_UACI_DETALLEOFERTA.Where(
                    d =>
                        d.IDESTABLECIMIENTO == idEstablecimiento && d.IDPROCESOCOMPRA == idProcesoCompra &&
                        d.IDPROVEEDOR == idProveedor);
        }

        public static IQueryable<SAB_UACI_DETALLEOFERTA> ObtenerTodos(int idEstablecimiento,
            int idProcesoCompra, int idProveedor)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodos(db, idEstablecimiento, idProcesoCompra, idProveedor);
            }

        }
    }
}
