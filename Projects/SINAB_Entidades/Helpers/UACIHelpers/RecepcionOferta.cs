using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class RecepcionOferta
    {
        public static DateTime ObtenerMaxFechaRecepcion(int idEstablecimiento, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerMaxFechaRecepcion(db, idEstablecimiento, idProcesoCompra);
            }
        }

        public static DateTime ObtenerMaxFechaRecepcion(SinabEntities db, int idEstablecimiento, int idProcesoCompra)
        {
            return
                db.SAB_UACI_RECEPCIONOFERTAS.Where(
                    ro => ro.IDESTABLECIMIENTO == idEstablecimiento && ro.IDPROCESOCOMPRA == idProcesoCompra)
                    .Select(ro =>ro.FECHAENTREGA).DefaultIfEmpty().Max() ;
        }

        public static void Agregar(SinabEntities db, SAB_UACI_RECEPCIONOFERTAS recepcionofertas)
        {
            db.SAB_UACI_RECEPCIONOFERTAS.AddObject(recepcionofertas);
            db.SaveChanges();
        }

        #region Obtener
        public static SAB_UACI_RECEPCIONOFERTAS Obtener(int idEstablecimiento, long idProcesoCompra, int idProveedor)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idEstablecimiento, idProcesoCompra, idProveedor);
            }
        }

        public static SAB_UACI_RECEPCIONOFERTAS Obtener( SinabEntities db, int idEstablecimiento, long idProcesoCompra, int idProveedor)
        {
             return db.SAB_UACI_RECEPCIONOFERTAS.FirstOrDefault(ro => ro.IDESTABLECIMIENTO == idEstablecimiento &&
                                                                         ro.IDPROCESOCOMPRA == idProcesoCompra &&
                                                                         ro.IDPROVEEDOR == idProveedor);
            
        }
        #endregion Obtener

        public static void Actualizar(SAB_UACI_RECEPCIONOFERTAS recepcion)
        {
            using (var db = new SinabEntities())
            {
                var ro = Obtener(db, recepcion.IDESTABLECIMIENTO, recepcion.IDPROCESOCOMPRA, recepcion.IDPROVEEDOR);
                if (ro == null) return;
                ro.PERSONAENTREGA = recepcion.PERSONAENTREGA;
                ro.FECHAENTREGA = recepcion.FECHAENTREGA;
                ro.DUIENTREGA = recepcion.DUIENTREGA;
                ro.ORDENLLEGADA = recepcion.ORDENLLEGADA;
                db.SaveChanges();
            }
        }

        #region Existe
        public static bool Existe(SinabEntities db, int idEstablecimiento, long idProcesoCompra, int idProveedor)
        {

            return db.SAB_UACI_RECEPCIONOFERTAS.Any(ro => ro.IDESTABLECIMIENTO == idEstablecimiento &&
                                                          ro.IDPROCESOCOMPRA == idProcesoCompra &&
                                                          ro.IDPROVEEDOR == idProveedor);

        }

        public static bool Existe(int idEstablecimiento, long idProcesoCompra, int idProveedor)
        {
            using (var db = new SinabEntities())
            {
                return Existe(db, idEstablecimiento, idProcesoCompra, idProveedor);
            }
        }

        public static bool Existe(SAB_UACI_RECEPCIONOFERTAS recepcion)
        {
            using (var db = new SinabEntities())
            {
                return Existe(db, recepcion.IDESTABLECIMIENTO, recepcion.IDPROCESOCOMPRA, recepcion.IDPROVEEDOR);
            }
        }
        #endregion Existe

        public static List<BaseRecepcionOferta>ObtenerTodos(int idEstablecimiento, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodos(db, idEstablecimiento, idProcesoCompra);
            }
        }
        
        public static List<BaseRecepcionOferta> ObtenerTodos(SinabEntities db, int idEstablecimiento, int idProcesoCompra)
        {
            var ds = (from ro in db.SAB_UACI_RECEPCIONOFERTAS
                    let opc = ro.SAB_UACI_OFERTAPROCESOCOMPRA
                join p in db.SAB_CAT_PROVEEDORES on ro.IDPROVEEDOR equals p.IDPROVEEDOR
                where ro.IDPROCESOCOMPRA == idProcesoCompra && ro.IDESTABLECIMIENTO == idEstablecimiento
                select new BaseRecepcionOferta
                {
                    IdProveedor = ro.IDPROVEEDOR,
                    IdProcesoCompra = ro.IDPROCESOCOMPRA,
                    IdEstablecimiento = ro.IDESTABLECIMIENTO,
                    Nombre = p.NOMBRE??"",
                    OrdenLlegada = ro.ORDENLLEGADA,
                    FechaEntrega = ro.FECHAENTREGA,
                    PersonaEntrega = ro.PERSONAENTREGA??"",
                    DuiEntrega = ro.DUIENTREGA??"",
                    MontoOferta =opc != null? opc.MONTOOFERTA : 0,
                    MontoGarantia = opc !=null ?opc.MONTOGARANTIA:0,
                    NombreRepresentante = opc!= null?opc.NOMBREREPRESENTANTE:"",
                    EstaHabilitado = (byte) (opc!=null?opc.ESTAHABILITADO??0:0),
                    Observacion = opc!=null? !string.IsNullOrEmpty(opc.OBSERVACION)?opc.OBSERVACION:"" :""
                }).OrderBy(ro => ro.OrdenLlegada).ToList();
            return ds;
        }

        
    }

    
}
