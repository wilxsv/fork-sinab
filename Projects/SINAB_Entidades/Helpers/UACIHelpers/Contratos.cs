using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.CSharp;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class Contratos
    {
        public static List<SAB_UACI_CONTRATOS> ObtenerTodos(int idEstablecimiento, int idEstadoContrato)
        {
            var db = new SinabEntities();

            return db.SAB_UACI_CONTRATOS.
                Where(c =>
                      c.IDESTABLECIMIENTO == idEstablecimiento &&
                      c.IDESTADOCONTRATO == idEstadoContrato).OrderByDescending(c => c.FECHAGENERACION).ToList();
        }
        public static List<SAB_UACI_CONTRATOS> ObtenerTodos(int idEstablecimiento, int idEstadoContrato, string usuarioCreacion)
        {
            var db = new SinabEntities();

            return db.SAB_UACI_CONTRATOS.
                Where(c =>
                      c.IDESTABLECIMIENTO == idEstablecimiento &&
                      c.AUUSUARIOCREACION.Contains(usuarioCreacion) &&
                      c.IDESTADOCONTRATO == idEstadoContrato
                      ).OrderByDescending(c => c.FECHAGENERACION).ToList();
        }


        public static List<BaseContratos> ObtenerTodos(decimal idEstablecimiento, decimal idAlmacen, decimal idTipoDocumento, decimal idModalidad, decimal idProveedor, int entrega, string producto)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodos(db, idEstablecimiento, idAlmacen, idTipoDocumento, idModalidad, idProveedor, entrega,
                    producto);

            }
        }
        public static List<BaseContratos> ObtenerTodos(SinabEntities db, decimal idEstablecimiento, decimal idAlmacen, decimal idTipoDocumento, decimal idModalidad, decimal idProveedor, int entrega, string producto)
        {

            var res = (from c in db.SAB_UACI_CONTRATOS
                       join aec in db.SAB_UACI_ALMACENESENTREGACONTRATOS on new
                       {
                           c.IDESTABLECIMIENTO,
                           c.IDPROVEEDOR,
                           c.IDCONTRATO
                       } equals new
                       {
                           aec.IDESTABLECIMIENTO,
                           aec.IDPROVEEDOR,
                           aec.IDCONTRATO
                       }

                       join pc in db.SAB_UACI_PRODUCTOSCONTRATO on new
                       {
                           aec.IDESTABLECIMIENTO,
                           c.IDPROVEEDOR,
                           c.IDCONTRATO,
                           aec.SAB_UACI_ENTREGACONTRATO.RENGLON
                       } equals new
                       {
                           pc.IDESTABLECIMIENTO,
                           pc.IDPROVEEDOR,
                           pc.IDCONTRATO,
                           pc.RENGLON
                       }

                       join cp in db.vv_CATALOGOPRODUCTOS on pc.IDPRODUCTO equals cp.IDPRODUCTO
                       where
                           (c.IDESTABLECIMIENTO == idEstablecimiento || idEstablecimiento == 0) &&
                           (c.IDTIPODOCUMENTO == idTipoDocumento || idTipoDocumento == 0) &&
                           (c.IDMODALIDADCOMPRA == idModalidad || idModalidad == 0) &&
                           (c.IDPROVEEDOR == idProveedor || idProveedor == 0) &&
                           (aec.IDALMACENENTREGA == idAlmacen || idAlmacen == 0) &&
                           (cp.CORRPRODUCTO == producto || producto == "")
                       group aec by new
                       {
                           Suministro = cp.DESCSUMINISTRO,
                           contrato = c
                       }
                           into s

                           let ct = s.Key.contrato
                           select new BaseContratos()
                           {
                               IDESTABLECIMIENTO = ct.IDESTABLECIMIENTO,
                               IDPROVEEDOR = ct.IDPROVEEDOR,
                               IDCONTRATO = ct.IDCONTRATO,
                               TipoDocumento = ct.SAB_CAT_TIPODOCUMENTOCONTRATO.DESCRIPCION,
                               NumeroDocumento = ct.NUMEROCONTRATO,
                               FechaDocumento = ct.FECHADISTRIBUCION,
                               TipoCompra = ct.SAB_CAT_MODALIDADESCOMPRA.DESCRIPCION,
                               NumeroCompra = ct.NUMEROMODALIDADCOMPRA,
                               Proveedor = ct.SAB_CAT_PROVEEDORES.NOMBRE,
                               MONTOCONTRATO = ct.MONTOCONTRATO,
                               CantidadEntregada = s.Sum(c => c.CANTIDADENTREGADA),
                               Cantidad = s.Sum(c => c.CANTIDAD),
                               Suministros = (from pct in ct.SAB_UACI_PRODUCTOSCONTRATO
                                              join vv in db.vv_CATALOGOPRODUCTOS on pct.IDPRODUCTO
                                                  equals vv.IDPRODUCTO
                                              group pct by new { vv.CORRSUMINISTRO, vv.DESCSUMINISTRO }
                                                  into gr
                                                  select gr.Key.DESCSUMINISTRO),
                               FuentesFinanciamiento =
                                       ct.SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.Select(
                                           ffc => ffc.SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE)

                           });

            switch (entrega)
            {
                case 1:
                    res = res.Where(c => c.CantidadEntregada == 0);
                    break;
                case 2:
                    res = res.Where(c => c.CantidadEntregada < c.Cantidad);
                    break;
                case 3:
                    res = res.Where(c => c.CantidadEntregada == c.Cantidad);
                    break;
            }
            var list = res.ToList().OrderByDescending(c => c.FechaDocumento).ToList();


            return list;


        }

        #region OPERACIONES SOBRE CONTRATO
        public static SAB_UACI_CONTRATOS Obtener(SAB_UACI_CONTRATOS contrato)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(contrato, db);
            }
        }

        public static void Guardar(SAB_UACI_CONTRATOS contrato)
        {
            using (var db = new SinabEntities())
            {
                if (contrato.IDCONTRATO == 0)
                {
                    var recs = db.SAB_UACI_CONTRATOS.Where(c =>
                                                           c.IDESTABLECIMIENTO == contrato.IDESTABLECIMIENTO &&
                                                           c.IDPROVEEDOR == contrato.IDPROVEEDOR);
                    long lastId = 1;
                    if (recs.Any()) lastId = recs.Max(c => c.IDCONTRATO) + 1;
                    contrato.IDCONTRATO = lastId;

                    db.SAB_UACI_CONTRATOS.AddObject(contrato);
                }
                else
                {
                    var rec =
                        Obtener(
                            new SAB_UACI_CONTRATOS()
                            {
                                IDCONTRATO = contrato.IDCONTRATO,
                                IDESTABLECIMIENTO = contrato.IDESTABLECIMIENTO,
                                IDPROVEEDOR = contrato.IDPROVEEDOR
                            }, db);
                    if (rec != null)
                    {
                        rec.NUMEROCONTRATO = contrato.NUMEROCONTRATO;
                        rec.IDTIPODOCUMENTO = contrato.IDTIPODOCUMENTO;
                        rec.IDPLANTILLA = contrato.IDPLANTILLA;
                        rec.TIPOPERSONA = contrato.TIPOPERSONA;
                        rec.REPRESENTANTELEGAL = contrato.REPRESENTANTELEGAL;
                        rec.PERSONERIAJURIDICA = contrato.PERSONERIAJURIDICA;
                        rec.FECHAGENERACION = contrato.FECHAGENERACION;
                        rec.FECHAAPROBACION = contrato.FECHAAPROBACION;
                        rec.FECHADISTRIBUCION = contrato.FECHADISTRIBUCION;
                        rec.CODIGOLICITACION = contrato.CODIGOLICITACION;
                        rec.FECHAINICIOENTREGA = contrato.FECHAINICIOENTREGA;
                        rec.IDESTADOCONTRATO = contrato.IDESTADOCONTRATO;
                        rec.IDCALIFICACIONCUMPLIMIENTO = contrato.IDCALIFICACIONCUMPLIMIENTO;
                        rec.IDCALIFICACIONCALIDAD = contrato.IDCALIFICACIONCALIDAD;
                        rec.IDMODALIDADCOMPRA = contrato.IDMODALIDADCOMPRA;
                        rec.NUMEROMODALIDADCOMPRA = contrato.NUMEROMODALIDADCOMPRA;
                        rec.MONTOCONTRATO = contrato.MONTOCONTRATO;
                        rec.AUUSUARIOCREACION = contrato.AUUSUARIOCREACION;
                        rec.AUFECHACREACION = contrato.AUFECHACREACION;
                        rec.AUUSUARIOMODIFICACION = contrato.AUUSUARIOMODIFICACION;
                        rec.AUFECHAMODIFICACION = contrato.AUFECHAMODIFICACION;
                        rec.ESTASINCRONIZADA = contrato.ESTASINCRONIZADA;
                        rec.ACTANOTARIAL = contrato.ACTANOTARIAL;
                        rec.RESOLUCION = contrato.RESOLUCION;
                        rec.MODIFICATIVA = contrato.MODIFICATIVA;
                    }
                }
                db.SaveChanges();
            }
        }

        public static SAB_UACI_CONTRATOS Guardar(SAB_UACI_CONTRATOS contrato, SinabEntities db)
        {
            if (contrato.IDCONTRATO == 0)
            {
                var recs = db.SAB_UACI_CONTRATOS.Where(c =>
                                                       c.IDESTABLECIMIENTO == contrato.IDESTABLECIMIENTO &&
                                                       c.IDPROVEEDOR == contrato.IDPROVEEDOR);
                long lastId = 1;
                if (recs.Any()) lastId = recs.Max(c => c.IDCONTRATO) + 1;
                contrato.IDCONTRATO = lastId;

                db.SAB_UACI_CONTRATOS.AddObject(contrato);
                db.SaveChanges();
                return contrato;
            }

            var rec =
                Obtener(
                    new SAB_UACI_CONTRATOS()
                    {
                        IDCONTRATO = contrato.IDCONTRATO,
                        IDESTABLECIMIENTO = contrato.IDESTABLECIMIENTO,
                        IDPROVEEDOR = contrato.IDPROVEEDOR
                    }, db);
            if (rec != null)
            {
                rec.NUMEROCONTRATO = contrato.NUMEROCONTRATO;
                rec.IDTIPODOCUMENTO = contrato.IDTIPODOCUMENTO;
                rec.IDPLANTILLA = contrato.IDPLANTILLA;
                rec.TIPOPERSONA = contrato.TIPOPERSONA;
                rec.REPRESENTANTELEGAL = contrato.REPRESENTANTELEGAL;
                rec.PERSONERIAJURIDICA = contrato.PERSONERIAJURIDICA;
                rec.FECHAGENERACION = contrato.FECHAGENERACION;
                rec.FECHAAPROBACION = contrato.FECHAAPROBACION;
                rec.FECHADISTRIBUCION = contrato.FECHADISTRIBUCION;
                rec.CODIGOLICITACION = contrato.CODIGOLICITACION;
                rec.FECHAINICIOENTREGA = contrato.FECHAINICIOENTREGA;
                rec.IDESTADOCONTRATO = contrato.IDESTADOCONTRATO;
                rec.IDCALIFICACIONCUMPLIMIENTO = contrato.IDCALIFICACIONCUMPLIMIENTO;
                rec.IDCALIFICACIONCALIDAD = contrato.IDCALIFICACIONCALIDAD;
                rec.IDMODALIDADCOMPRA = contrato.IDMODALIDADCOMPRA;
                rec.NUMEROMODALIDADCOMPRA = contrato.NUMEROMODALIDADCOMPRA;
                rec.MONTOCONTRATO = contrato.MONTOCONTRATO;
                rec.AUUSUARIOCREACION = contrato.AUUSUARIOCREACION;
                rec.AUFECHACREACION = contrato.AUFECHACREACION;
                rec.AUUSUARIOMODIFICACION = contrato.AUUSUARIOMODIFICACION;
                rec.AUFECHAMODIFICACION = contrato.AUFECHAMODIFICACION;
                rec.ESTASINCRONIZADA = contrato.ESTASINCRONIZADA;
                rec.ACTANOTARIAL = contrato.ACTANOTARIAL;
                rec.RESOLUCION = contrato.RESOLUCION;
                rec.MODIFICATIVA = contrato.MODIFICATIVA;
            }

            db.SaveChanges();
            return rec;
        }

        public static void Borrar(SAB_UACI_CONTRATOS contrato)
        {
            //asegurando RollBack
            using (var db = new SinabEntities())
            {
                var rec = Obtener(contrato, db);


                if (rec == null) return;
                //Verificar antes de borrar
                if (rec.SAB_ALM_RECIBOSRECEPCION.Any())
                    throw new Exception("Contrato no puede ser borrado despues de recibido");

                //Borra los responsables
                foreach (var rdc in rec.SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO.ToList())
                {
                    db.SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO.DeleteObject(rdc);
                }

                //borra las fuentes de financiamiento
                foreach (var ffc in rec.SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.ToList())
                {
                    db.SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS.DeleteObject(ffc);
                }

                //Borrar productos contrato
                foreach (var ec in rec.SAB_UACI_PRODUCTOSCONTRATO.SelectMany(pc => pc.SAB_UACI_ENTREGACONTRATO).ToList())
                {
                    db.SAB_UACI_ENTREGACONTRATO.DeleteObject(ec);
                }

                foreach (var pc in rec.SAB_UACI_PRODUCTOSCONTRATO.ToList())
                {
                    db.SAB_UACI_PRODUCTOSCONTRATO.DeleteObject(pc);
                }

                //borra el contrato
                db.SAB_UACI_CONTRATOS.DeleteObject(rec);
                db.SaveChanges();

            }
        }

        public static SAB_UACI_CONTRATOS Obtener(SAB_UACI_CONTRATOS contrato, SinabEntities db)
        {
            var rec = db.SAB_UACI_CONTRATOS.FirstOrDefault(c =>
                                                           c.IDCONTRATO == contrato.IDCONTRATO &&
                                                           c.IDESTABLECIMIENTO == contrato.IDESTABLECIMIENTO &&
                                                           c.IDPROVEEDOR == contrato.IDPROVEEDOR);
            return rec;
        }

        public static SAB_UACI_CONTRATOS Obtener(int idContrato, int idEstablecimiento, int idProveedor, SinabEntities db)
        {
            var rec = db.SAB_UACI_CONTRATOS.FirstOrDefault(c =>
                                                           c.IDCONTRATO == idContrato &&
                                                           c.IDESTABLECIMIENTO == idEstablecimiento &&
                                                           c.IDPROVEEDOR == idProveedor);
            return rec;
        }
        #endregion OPERACIONES SOBRE CONTRATO
    }
}
