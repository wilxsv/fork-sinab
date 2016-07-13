using System.Collections.Generic;
using System.Linq;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class EntregasProcesoCompra
    {

        public static void AgregarVarios(SinabEntities db, List<SAB_UACI_ENTREGAPROCESOCOMPRA> entregas)
        {
            entregas.ForEach(en => db.SAB_UACI_ENTREGAPROCESOCOMPRA.AddObject(en));
            db.SaveChanges();
        }

        public static void AgregarVarios(
            SinabEntities db,
            List<SAB_EST_SOLICITUDES> detalle, int idEstablecimiento, int idProcesoCompra)
        {
            var listaEntregas = new List<short>();
            foreach (var lista in detalle.Select(s => 
                db.SAB_EST_ENTREGAS.Where(en => en.IDSOLICITUD == s.IDSOLICITUD && en.IDESTABLECIMIENTO == s.IDESTABLECIMIENTO)
                .GroupBy(en => en.IDENTREGA).Select(en => en.FirstOrDefault().IDENTREGA).ToList())
                .Select(grupo => grupo.ToList()).Where(lista => lista.Any()))
            {
                listaEntregas.AddRange(lista);
            }
            var filtrada = listaEntregas.Distinct().ToList();
            var entregasPc = filtrada.Select(se => new SAB_UACI_ENTREGAPROCESOCOMPRA()
                                                   {
                                                       IDENTREGA = (byte) se, 
                                                       IDESTABLECIMIENTO = idEstablecimiento, 
                                                       IDPROCESOCOMPRA = idProcesoCompra,
                                                   }).ToList();


            AgregarVarios(db, entregasPc);
            
        }
    }
}
