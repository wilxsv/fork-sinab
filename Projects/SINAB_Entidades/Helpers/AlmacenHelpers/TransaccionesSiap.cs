using System;
using System.Linq;
using System.Transactions;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public static class TransaccionesSiap
    {
        public static void AgregarTransaccion(SAB_ALM_MOVIMIENTOS movimiento, bool esFarmacia) {

            using (var db = new SinabEntities())
            {
                using (var ts = new TransactionScope())
                {
                    try
                    {
                        var dsDetallesMovientoVale = db.DetalleMovimientosValeSalida(
                                movimiento.IDESTABLECIMIENTO,
                                Convert.ToInt32(movimiento.IDMOVIMIENTO), 
                                movimiento.IDTIPOTRANSACCION, 
                                esFarmacia
                               ).ToList();

                        var primerDetalle = dsDetallesMovientoVale.FirstOrDefault();

                        var usuarioRegistra =
                            db.SAB_CAT_EMPLEADOS.FirstOrDefault(ur => ur.NOMBRECORTO == movimiento.AUUSUARIOCREACION);
                        var usuarioModifica =
                            db.SAB_CAT_EMPLEADOS.FirstOrDefault(ur => ur.NOMBRECORTO == movimiento.AUUSUARIOMODIFICACION);

                        var empleado = Membresia.ObtenerUsuario();

                        if (primerDetalle.IDSUMINISTRO != 1 || !esFarmacia) return;


                        var transaccion = new SAB_FARM_TRANSACION()
                                          {
                                              NumeroVale = primerDetalle.NUMEROVALE,
                                              IdEstablecimiento =
                                                  usuarioRegistra != null
                                                      ? usuarioRegistra.IDESTABLECIMIENTO ?? 0
                                                      : empleado.Establecimiento.IDESTABLECIMIENTO,
                                              IdEstado =
                                                  Convert.ToChar(EnumHelpers.RequisicionEstados.Enviado).ToString(),
                                              IdUsuarioReg =
                                                  usuarioRegistra != null
                                                      ? usuarioRegistra.IDEMPLEADO
                                                      : empleado.IDEMPLEADO,
                                              IdUsuarioMod =
                                                  usuarioModifica != null
                                                      ? usuarioModifica.IDEMPLEADO
                                                      : empleado.IDEMPLEADO,
                                              FechaHoraMod = primerDetalle.AUFECHAMODIFICACION ?? DateTime.Now,
                                              FechaHoraReg = primerDetalle.AUFECHACREACION.Value,
                                          };

                        db.SAB_FARM_TRANSACION.AddObject(transaccion);
                        db.SaveChanges();

                        foreach (var newex in dsDetallesMovientoVale.Select(t => new SAB_FARM_EXISTENCIA()
                                                                                 {
                                                                                     IdTrans = transaccion.IdTrans,
                                                                                     Codigo = t.Codigo,
                                                                                     Cantidad =
                                                                                         (double) (t.Cantidad ?? 0),
                                                                                     Lote = t.Lote,
                                                                                     Precio = (double) (t.Precio ?? 0),
                                                                                     FechaVencimiento =
                                                                                         t.FECHAVENCIMIENTO,
                                                                                     FuenteFinanciamiento =
                                                                                         t.FuenteFinanciamiento,
                                                                                     FechaHoraReg =
                                                                                         t.AUFECHACREACION.Value,
                                                                                     FechaHoraMod =
                                                                                         t.AUFECHAMODIFICACION,
                                                                                     IdUsuarioMod =
                                                                                         usuarioModifica.IDEMPLEADO,
                                                                                     IdUsuarioReg =
                                                                                         usuarioRegistra.IDEMPLEADO
                                                                                 }))
                        {
                            db.SAB_FARM_EXISTENCIA.AddObject(newex);
                        }
                        db.SaveChanges();
                        ts.Complete();
                     }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
    }
}
