using System.Collections.Generic;
using System.Linq;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class DetalleEntregasProcesoCompra
    {
        public static void AgregarVarios(SinabEntities db, List<SAB_UACI_DETALLEENTREGASPROCESOCOMPRA> detalles)
        {
            detalles.ForEach(en => db.SAB_UACI_DETALLEENTREGASPROCESOCOMPRA.AddObject(en));
            db.SaveChanges();
        }

        public static void AgregarVarios(SinabEntities db, List<SAB_EST_SOLICITUDES> detalle, int idEstablecimiento, int idProcesoCompra)
        {
            var detalleEntregasPc = new List<SAB_UACI_DETALLEENTREGASPROCESOCOMPRA>();
            
            foreach (var entregasDetalle in detalle.Select(sol => db.SAB_EST_ENTREGAS
                .Where(en => en.IDSOLICITUD == sol.IDSOLICITUD && en.IDESTABLECIMIENTO == sol.IDESTABLECIMIENTO).ToList())
                .Where(entregasDetalle => entregasDetalle.Any()))
            {
                detalleEntregasPc.AddRange(entregasDetalle.Select(d => new SAB_UACI_DETALLEENTREGASPROCESOCOMPRA()
                                                                       {
                                                                           DIAS = d.DIASENTREGA??0,
                                                                           IDFECHACONTEO = 1,
                                                                           IDENTREGA = (byte) d.IDENTREGA,
                                                                           IDESTABLECIMIENTO = idEstablecimiento,
                                                                           IDPROCESOCOMPRA = (long)idProcesoCompra,
                                                                           PORCENTAJE = d.PORCENTAJEENTREGA??0,
                                                                           TIPOCONTEO = 1,
                                                                           IDDETALLE = (byte) d.NUMEROENTREGA,
                                                                           NUMEROENTREGA = d.NUMEROENTREGA
                                                                           
                                                                       })
                    );
            }
            var detalleFiltrado =
                detalleEntregasPc.GroupBy(i => new {i.IDESTABLECIMIENTO, i.IDPROCESOCOMPRA, i.IDENTREGA, i.IDDETALLE})
                    .Select(group => group.First())
                    .ToList();
            AgregarVarios(db, detalleFiltrado);
        }
    }
}
