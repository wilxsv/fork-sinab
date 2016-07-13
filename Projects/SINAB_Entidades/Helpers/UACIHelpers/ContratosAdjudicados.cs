using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class ContratosAdjudicados
    {
        public static List<BaseContratoAdjudicado> ObtenerTodos(int idEstado, string usr)
        {
            using (var t = new TransactionScope())
            {
                try
                {
                    using (var db = new SinabEntities())
                    {
                        var rec = (from a in db.SAB_UACI_ADJUDICACION

                            join im in db.SAB_LAB_INFORMEMUESTRAS
                                on
                                new
                                {
                                    IdProveedor = a.IDPROVEEDOR,
                                    IdEstablecimiento = a.IDESTABLECIMIENTO,
                                    IdProcesoCompra = a.IDPROCESOCOMPRA
                                }
                                equals
                                new
                                {
                                    IdProveedor = im.IDPROVEEDOR ?? 0,
                                    IdEstablecimiento = im.IDESTABLECIMIENTOCONTRATO ?? 0,
                                    IdProcesoCompra = im.IDPROCESOCOMPRA ?? 0
                                }

                            join c in db.SAB_UACI_CONTRATOS
                                on
                                new
                                {
                                    im.IDESTABLECIMIENTO,
                                    IDPROVEEDOR = (int) im.IDPROVEEDOR,
                                    IDCONTRATO = (long) im.IDCONTRATO
                                }
                                equals new {c.IDESTABLECIMIENTO, c.IDPROVEEDOR, c.IDCONTRATO}

                            join cpc in db.SAB_UACI_CONTRATOSPROCESOCOMPRA
                                on new {a.IDESTABLECIMIENTO, a.IDPROCESOCOMPRA}
                                equals new {cpc.IDESTABLECIMIENTO, cpc.IDPROCESOCOMPRA}


                            join p in db.SAB_CAT_PROVEEDORES
                                on a.IDPROVEEDOR equals p.IDPROVEEDOR

                            where
                                a.CANTIDADFIRME > 0 && im.IDESTADO == idEstado
                                && (im.AUUSUARIOCREACION == usr || usr == "")

                            let pc = cpc.SAB_UACI_PROCESOCOMPRAS

                            select new
                            {
                                IdInforme = im.IDINFORME,
                                IdProcesoCompra = a.IDPROCESOCOMPRA,
                                IdProveedor = a.IDPROVEEDOR,
                                Idcontrato = c.IDCONTRATO,
                                IdEstablecimiento = a.IDESTABLECIMIENTO,
                                NumeroNotificacion = im.NUMERONOTIFICACION ?? 0,
                                Renglon = im.RENGLON,
                                FechaNotificacion = (DateTime) im.FECHANOTIFICACION,
                                Nombre = p.NOMBRE,
                                NumeroContrato = c.NUMEROCONTRATO,
                                ProcesoCompra = pc.CODIGOLICITACION + " - " + pc.TITULOLICITACION,
                            }).GroupBy(itm => new
                            {
                                itm.IdProcesoCompra,
                                itm.IdProveedor,
                                itm.Idcontrato,
                                itm.IdEstablecimiento,
                                itm.Nombre,
                                itm.NumeroContrato,
                                itm.ProcesoCompra,
                                itm.NumeroNotificacion

                            }).Select(grp => new BaseContratoAdjudicado()
                            {
                                IdInforme = grp.Max(k => k.IdInforme),
                                IdProcesoCompra = grp.Key.IdProcesoCompra,
                                IdProveedor = grp.Key.IdProveedor,
                                Idcontrato = grp.Key.Idcontrato,
                                IdEstablecimiento = grp.Key.IdEstablecimiento,
                                Items = grp.Select(k => k.Renglon).Distinct().Count(),
                                NumeroNotificacion = grp.Key.NumeroNotificacion,
                                FechaNotificacion = grp.Max(k => k.FechaNotificacion),
                                Nombre = grp.Key.Nombre,
                                NumeroContrato = grp.Key.NumeroContrato,
                                ProcesoCompra = grp.Key.ProcesoCompra,
                            }).OrderByDescending(obj => obj.FechaNotificacion).ToList();
                        t.Complete();
                        return rec;
                    }
                    
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        throw new Exception(
                            "Error al mostrar el resultado de la consulta, verifique su conexión o intente cargar nuevemente este formulatio. Error: " +
                            ex.InnerException.Message);
                    }
                    throw new Exception(
                        "Error al mostrar el resultado de la consulta, verifique su conexión o intente cargar nuevemente este formulatio. Error: " +
                        ex.Message);
                }
            }

        }

        public static List<BaseContratoAdjudicado> ObtenerTodos(int idEstado, int idUsr)
        {
            try
            {
                using (var db = new SinabEntities())
                {
                    var rec = (from a in db.SAB_UACI_ADJUDICACION

                               join im in db.SAB_LAB_INFORMEMUESTRAS
                                   on
                                   new
                                   {
                                       IdProveedor = a.IDPROVEEDOR,
                                       IdEstablecimiento = a.IDESTABLECIMIENTO,
                                       IdProcesoCompra = a.IDPROCESOCOMPRA
                                   }
                                   equals
                                   new
                                   {
                                       IdProveedor = im.IDPROVEEDOR ?? 0,
                                       IdEstablecimiento = im.IDESTABLECIMIENTOCONTRATO ?? 0,
                                       IdProcesoCompra = im.IDPROCESOCOMPRA ?? 0
                                   }

                               join c in db.SAB_UACI_CONTRATOS
                                   on
                                   new
                                   {
                                       im.IDESTABLECIMIENTO,
                                       IDPROVEEDOR = (int)im.IDPROVEEDOR,
                                       IDCONTRATO = (long)im.IDCONTRATO
                                   }
                                   equals new { c.IDESTABLECIMIENTO, c.IDPROVEEDOR, c.IDCONTRATO }

                               join cpc in db.SAB_UACI_CONTRATOSPROCESOCOMPRA
                                   on new { a.IDESTABLECIMIENTO, a.IDPROCESOCOMPRA }
                                   equals new { cpc.IDESTABLECIMIENTO, cpc.IDPROCESOCOMPRA }


                               join p in db.SAB_CAT_PROVEEDORES
                                   on a.IDPROVEEDOR equals p.IDPROVEEDOR

                               where
                                   a.CANTIDADFIRME > 0 && im.NUMEROINFORME == null && im.IDESTADO == idEstado
                                   && ((im.IDINSPECTOR == idUsr && idUsr > 0) || (im.IDINSPECTOR == null && idUsr == 0))

                               let pc = cpc.SAB_UACI_PROCESOCOMPRAS

                               select new
                               {
                                   IdInforme = im.IDINFORME,
                                   IdProcesoCompra = a.IDPROCESOCOMPRA,
                                   IdProveedor = a.IDPROVEEDOR,
                                   Idcontrato = c.IDCONTRATO,
                                   IdEstablecimiento = a.IDESTABLECIMIENTO,
                                   NumeroNotificacion = im.NUMERONOTIFICACION ?? 0,
                                   Renglon = im.RENGLON,
                                   FechaNotificacion = (DateTime)im.FECHANOTIFICACION,
                                   Nombre = p.NOMBRE,
                                   NumeroContrato = c.NUMEROCONTRATO,
                                   ProcesoCompra = pc.CODIGOLICITACION + " - " + pc.TITULOLICITACION,
                                   ObservacionAsignacion = im.OBSERVACIONASIGNACION,
                                   FechaAsignacion = (DateTime)im.FECHAASIGNACION
                               }).GroupBy(itm => new
                               {
                                   itm.IdProcesoCompra,
                                   itm.IdProveedor,
                                   itm.Idcontrato,
                                   itm.IdEstablecimiento,
                                   itm.Nombre,
                                   itm.NumeroContrato,
                                   itm.ProcesoCompra,
                                   itm.NumeroNotificacion,
                               }).Select(grp => new BaseContratoAdjudicado()
                               {

                                   IdInforme = grp.Max(k => k.IdInforme),
                                   IdProcesoCompra = grp.Key.IdProcesoCompra,
                                   IdProveedor = grp.Key.IdProveedor,
                                   Idcontrato = grp.Key.Idcontrato,
                                   IdEstablecimiento = grp.Key.IdEstablecimiento,
                                   NumeroNotificacion = grp.Key.NumeroNotificacion,
                                   Items = grp.Select(k => k.Renglon).Distinct().Count(),
                                   FechaNotificacion = grp.Max(k => k.FechaNotificacion),
                                   Nombre = grp.Key.Nombre,
                                   ObservacionAsignacion = grp.FirstOrDefault().ObservacionAsignacion,
                                   FechaAsignacion = grp.FirstOrDefault().FechaAsignacion,
                                   NumeroContrato = grp.Key.NumeroContrato,
                                   ProcesoCompra = grp.Key.ProcesoCompra,
                               }).OrderByDescending(obj => obj.FechaNotificacion).ToList();
                    return rec;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar el resultado de la consulta, verifique su conexión o intente cargar nuevemente este formulatio. Error: " + ex.Message);
            }
            
        }

     
    }
}
