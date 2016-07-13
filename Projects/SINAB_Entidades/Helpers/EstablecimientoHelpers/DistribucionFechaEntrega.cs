using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class DistribucionFechaEntrega
    {
        public static DateTime? ObtenerFecha(decimal idDistribucion, decimal idEstablecimiento,
            decimal idEstablecimientoDistribucion)
        {
            using (var db = new SinabEntities())
            {
                var res = db.SAB_EST_DISTRIBUCIONFECHAENTREGA.Where(d => d.IDDISTRIBUCION == idDistribucion &&
                                                                         d.IDESTABLECIMIENTO == idEstablecimiento &&
                                                                         d.IDESTABLECIMIENTODISTRIBUCION ==
                                                                         idEstablecimientoDistribucion
                    ).OrderByDescending(d => d.idfechaentrega).FirstOrDefault();

                return res != null ? res.fechaentrega : null;
                //select TOP 1 convert(varchar,fechaentrega,103) fechaentrega from SAB_EST_DISTRIBUCIONFECHAENTREGA where IDDISTRIBUCION=" & iddistribucion & " and idestablecimiento=" & idestablecimiento & " and idestablecimientodistribucion=" & idestablecimientodistribucion & " ORDER BY IDFECHAENTREGA DESC
            }
        }
    }
}
