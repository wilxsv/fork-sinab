using System;
using System.Collections.Generic;
using System.Linq;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class EntregasContrato
    {
        public static List<SAB_UACI_ENTREGACONTRATO> Obtener(SAB_UACI_CONTRATOS contrato, long renglon)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_UACI_ENTREGACONTRATO.Where(ec =>
                                                         ec.IDCONTRATO == contrato.IDCONTRATO &&
                                                         ec.IDESTABLECIMIENTO == contrato.IDESTABLECIMIENTO &&
                                                         ec.IDPROVEEDOR == contrato.IDPROVEEDOR &&
                                                         ec.RENGLON == renglon).ToList();

            }
        }

        public static List<prcRenglonesPendientesTotales_Result> ObtenerRenglonesPendientes(SAB_UACI_CONTRATOS baseContrato, int renglon, int idsuministro)
        {

            using (var db = new SinabEntities())
            {

                return
                    db.prcRenglonesPendientesTotales(
                        baseContrato.IDESTABLECIMIENTO,
                        baseContrato.IdAlmacen,
                        baseContrato.IDPROVEEDOR,
                        baseContrato.IDCONTRATO,
                        renglon,
                        idsuministro).ToList();
            }
        }

        

        public static void GuardarEntrega(SAB_UACI_ENTREGACONTRATO entrega)
        {
            using (var db = new SinabEntities())
            {
                if (entrega.IDDETALLE == 0)
                {
                    long maxentrega;
                    try
                    {
                        maxentrega = db.SAB_UACI_ENTREGACONTRATO.Where(ec =>
                                                                     ec.IDCONTRATO == entrega.IDCONTRATO &&
                                                                     ec.IDESTABLECIMIENTO == entrega.IDESTABLECIMIENTO &&
                                                                     ec.IDPROVEEDOR == entrega.IDPROVEEDOR &&
                                                                     ec.RENGLON == entrega.RENGLON).Max(ec => ec.IDDETALLE);

                    }
                    catch (Exception)
                    {
                        maxentrega = 0;
                    }

                    entrega.IDDETALLE = maxentrega + 1;
                    db.SAB_UACI_ENTREGACONTRATO.AddObject(entrega);
                }
                else
                {
                    var rec = ObtenerEntrega(entrega, db);

                    if (rec != null)
                    {
                        rec.ENTREGA = entrega.ENTREGA;
                        rec.PLAZOENTREGA = entrega.PLAZOENTREGA;
                        rec.PORCENTAJEENTREGA = entrega.PORCENTAJEENTREGA;
                        rec.FECHACONTEO = entrega.FECHACONTEO;
                        rec.IDMODIFICATIVA = entrega.IDMODIFICATIVA;
                        rec.ESTAHABILITADA = entrega.ESTAHABILITADA;
                        rec.AUUSUARIOMODIFICACION = entrega.AUUSUARIOMODIFICACION;
                        rec.AUFECHAMODIFICACION = entrega.AUFECHAMODIFICACION;
                        rec.ESTASINCRONIZADA = entrega.ESTASINCRONIZADA;
                    }
                }
                db.SaveChanges();
            }
        }

        public static SAB_UACI_ENTREGACONTRATO ObtenerEntrega(SAB_UACI_ENTREGACONTRATO entrega, SinabEntities db)
        {
            return db.SAB_UACI_ENTREGACONTRATO.FirstOrDefault(ec =>
                                                                   ec.IDCONTRATO == entrega.IDCONTRATO &&
                                                                   ec.IDESTABLECIMIENTO == entrega.IDESTABLECIMIENTO &&
                                                                   ec.IDPROVEEDOR == entrega.IDPROVEEDOR &&
                                                                   ec.RENGLON == entrega.RENGLON &&
                                                                   ec.IDDETALLE == entrega.IDDETALLE);
        }

        public static SAB_UACI_ENTREGACONTRATO ObtenerEntrega(SAB_UACI_ENTREGACONTRATO entrega)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_UACI_ENTREGACONTRATO.FirstOrDefault(ec =>
                                                                  ec.IDCONTRATO == entrega.IDCONTRATO &&
                                                                  ec.IDESTABLECIMIENTO == entrega.IDESTABLECIMIENTO &&
                                                                  ec.IDPROVEEDOR == entrega.IDPROVEEDOR &&
                                                                  ec.RENGLON == entrega.RENGLON &&
                                                                  ec.IDDETALLE == entrega.IDDETALLE);
            }
        }

       
    }
}
