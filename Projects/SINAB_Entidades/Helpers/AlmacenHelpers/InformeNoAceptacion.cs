using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public static class InformeNoAceptacion
    {
        public static List<BaseInformeNoAceptacion> ObtenerTodos(int idAlmacen, int idEstablecimiento, int idProveedor, DateTime fechaDesde, DateTime fechaHasta, int idFuenteFinanciamiento, int idResponsableDistribucion, int idEstado, int numeroInforme)
        {
            using (var db = new SinabEntities())
            {

                var res = from ina in db.SAB_ALM_INFORMESNOACEPTACION
                    let l =
                        ina.SAB_ALM_MOVIMIENTOS.FirstOrDefault()
                            .SAB_ALM_DETALLEMOVIMIENTOS.FirstOrDefault()
                            .SAB_ALM_LOTES
                    join p in db.SAB_CAT_PROVEEDORES on ina.IDPROVEEDOR equals p.IDPROVEEDOR
                          join m in db.SAB_ALM_MOVIMIENTOS
                          on new
                          {
                              ina.IDALMACEN,
                              ina.IDESTABLECIMIENTO
                          } equals new { IDALMACEN = m.IDALMACEN??0, m.IDESTABLECIMIENTO }

                    where (ina.IDALMACEN == idAlmacen || idAlmacen == 0) &&
                          (ina.IDPROVEEDOR == idProveedor || idProveedor == 0) &&
                          (m.FECHAMOVIMIENTO >= fechaDesde && m.FECHAMOVIMIENTO <= fechaHasta) &&
                          (l.IDFUENTEFINANCIAMIENTO == idFuenteFinanciamiento || idFuenteFinanciamiento == 0) &&
                          (l.IDRESPONSABLEDISTRIBUCION == idResponsableDistribucion || idResponsableDistribucion == 0) &&
                          (m.IDESTADO == idEstado || idEstado == 0) &&
                          (ina.IDINFORME == numeroInforme || numeroInforme == 0) &&
                          (m.IDESTABLECIMIENTO == idEstablecimiento || idEstablecimiento == 0) &&
                          m.IDTIPOTRANSACCION == 11
                    orderby ina.ANIO descending, ina.IDINFORME descending
                    select new BaseInformeNoAceptacion()
                    {
                        IdDocumento = m.IDDOCUMENTO??0,
                        IdAlmacen = ina.IDALMACEN,
                        Anio = ina.ANIO,
                        IdInforme = ina.IDINFORME,
                        IdEstablecimientoMovimiento = m.IDESTABLECIMIENTO,
                        IdMovimiento = m.IDMOVIMIENTO,
                        IdEstablecimiento = ina.IDESTABLECIMIENTO,
                        IdProveedor = ina.IDPROVEEDOR,
                        IdContrato = ina.IDCONTRATO,
                        DateMovimiento = m.FECHAMOVIMIENTO.Value,
                        TipoNumeroDocumento =
                            ina.SAB_UACI_CONTRATOS.SAB_CAT_TIPODOCUMENTOCONTRATO.DESCRIPCION + " " +
                            ina.SAB_UACI_CONTRATOS.NUMEROCONTRATO,
                        Proveedor = p.NOMBRE,
                        Estado = m.SAB_CAT_ESTADOSMOVIMIENTOS.DESCRIPCION

                    };
                
                

                return res.ToList();
            }
        }
    }
}
