using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Text;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class DocumentosProcesoCompra
    {
        public static List<BasePlantillaDocumentoProcesoCompra> ObtenerTodos(int idEstablecimiento, int idProcesoCompra,
            int idTipoDocumentoBase)
        {
            using (var db = new SinabEntities())
            {
                return (from dpc in db.SAB_UACI_DOCUMENTOSPROCESOSCOMPRA
                        join ddb in db.SAB_CAT_DOCUMENTOSBASE on
                        dpc.IDDOCUMENTOBASE equals ddb.IDDOCUMENTOBASE
                        where
                        (dpc.IDESTABLECIMIENTO == idEstablecimiento)
                        && (dpc.IDPROCESOCOMPRA == idProcesoCompra)
                        && (ddb.IDTIPODOCUMENTOBASE == idTipoDocumentoBase)
                        select new BasePlantillaDocumentoProcesoCompra()
                        {
                            IdDocumentoBase = dpc.IDDOCUMENTOBASE,
                            IdTipoDocumentoBase = ddb.IDTIPODOCUMENTOBASE,
                            Descripcion = ddb.DESCRIPCION,
                            IdEstablecimiento = dpc.IDESTABLECIMIENTO,
                            IdProcesoCompra = dpc.IDPROCESOCOMPRA,

                        }).ToList();
            }
        }

       

        public static SAB_UACI_DOCUMENTOSPROCESOSCOMPRA Obtener(decimal idEstablecimiento, decimal idProcesoCompra, decimal idDocumentoBase)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idEstablecimiento, idProcesoCompra, idDocumentoBase);
            }
        }

        public static SAB_UACI_DOCUMENTOSPROCESOSCOMPRA Obtener(SinabEntities db, decimal idEstablecimiento, decimal idProcesoCompra, decimal idDocumentoBase)
        {
           
                return
                    db.SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.FirstOrDefault(
                        dpc =>
                            dpc.IDESTABLECIMIENTO == idEstablecimiento && dpc.IDPROCESOCOMPRA == idProcesoCompra &&
                            dpc.IDDOCUMENTOBASE == idDocumentoBase);
            
        }

        public static bool Existe(decimal idEstablecimiento, decimal idProcesoCompra, decimal idDocumentoBase)
        {
            using (var db = new SinabEntities())
            {
                return
                    db.SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.Any(
                        dpc =>
                            dpc.IDESTABLECIMIENTO == idEstablecimiento && dpc.IDPROCESOCOMPRA == idProcesoCompra &&
                            dpc.IDDOCUMENTOBASE == idDocumentoBase);
            }
        }

        public static void Eliminar(SAB_UACI_DOCUMENTOSPROCESOSCOMPRA doc)
        {
            using (var db = new SinabEntities())
            {
                Eliminar(db, doc);
            }
        }

        public static void Eliminar(SinabEntities db, SAB_UACI_DOCUMENTOSPROCESOSCOMPRA doc)
        {
                var obj = Obtener(db, doc.IDESTABLECIMIENTO, doc.IDPROCESOCOMPRA, doc.IDDOCUMENTOBASE);
                if (obj == null) return;
                db.SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.DeleteObject(obj);
                db.SaveChanges();
        }

        public static void Agregar(SAB_UACI_DOCUMENTOSPROCESOSCOMPRA doc)
        {
            using (var db = new SinabEntities())
            {
               Agregar(db, doc);
            }
        }

        public static void Agregar(SinabEntities db, SAB_UACI_DOCUMENTOSPROCESOSCOMPRA doc)
        {
                db.SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.AddObject(doc);
                db.SaveChanges();
        }

        public static void Actualizar(SAB_UACI_DOCUMENTOSPROCESOSCOMPRA doc)
        {
            using (var db = new SinabEntities())
            {
                var obj = Obtener(db, doc.IDESTABLECIMIENTO, doc.IDPROCESOCOMPRA, doc.IDDOCUMENTOBASE);
                if (obj != null)
                {
                   Eliminar(db, obj);
                    Agregar(db, doc);
                        
                }
                else
                {
                    Agregar(db, doc);
                }
            }
            //Using db As New SinabEntities
            //        Dim ds = DocumentosProcesoCompra.Obtener(db, IdEstablecimiento, IdProcesoCompra, idDocumentoBase)
            //        If Not IsNothing(ds) Then
            //            db.SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.DeleteObject(ds)
            //            db.SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.AddObject(lEntidad)
            //        Else
            //            db.SAB_UACI_DOCUMENTOSPROCESOSCOMPRA.AddObject(lEntidad)

            //        End If
            //        db.SaveChanges()
            //    End Using
        }

    }
}
