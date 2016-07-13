using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class EntregaBases
    {
        public static void Agregar(SAB_UACI_ENTREGABASES entrega)
        {
            using (var db = new SinabEntities())
            {
                Agregar(db, entrega);
                db.SaveChanges();
            }
            
        }

        public static void Agregar(SinabEntities db, SAB_UACI_ENTREGABASES entrega)
        {
            
            db.SAB_UACI_ENTREGABASES.AddObject(entrega);
        }

        public static int ObtenerMaxOrden( SAB_UACI_ENTREGABASES entrega)
        {
            using (var db = new SinabEntities())
            {

                return

                    db.SAB_UACI_ENTREGABASES.Where(en =>
                        en.IDESTABLECIMIENTO == entrega.IDESTABLECIMIENTO &&
                        en.IDPROCESOCOMPRA == entrega.IDPROCESOCOMPRA).DefaultIfEmpty()
                        .Max(s => s == null ? 0 : s.ORDEN);
            }

        }

        public static bool Existe(int idEstablecimiento, long idProcesoCompra, int idProveedor)
        {
            using (var db = new SinabEntities())
            {
                return db.SAB_UACI_ENTREGABASES.Any(eb => eb.IDESTABLECIMIENTO == idEstablecimiento &&
                                                          eb.IDPROCESOCOMPRA == idProcesoCompra &&
                                                          eb.IDPROVEEDOR == idProveedor);
            }
        }

        public static bool Existe(SAB_UACI_ENTREGABASES entrega)
        {
            return Existe(entrega.IDESTABLECIMIENTO, entrega.IDPROCESOCOMPRA, entrega.IDPROVEEDOR);
        }

        public static List<SAB_UACI_ENTREGABASES> ObtenerTodos(int idEstablecimiento, int idProcesoCompra)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerTodos(db, idEstablecimiento, idProcesoCompra);
            }
        }

        public static List<SAB_UACI_ENTREGABASES> ObtenerTodos(SinabEntities db, int idEstablecimiento, int idProcesoCompra)
        {
            return
                db.SAB_UACI_ENTREGABASES.Include(d => d.SAB_CAT_PROVEEDORES).Where(
                    eb => eb.IDESTABLECIMIENTO == idEstablecimiento && eb.IDPROCESOCOMPRA == idProcesoCompra).ToList();
        }


        public static void Actualizar(SAB_UACI_ENTREGABASES entrega)
        {
            using (var db = new SinabEntities())
            {
                var eb = Obtener(db, entrega);
                if (eb == null) return;
                eb.PERSONARECIBE = entrega.PERSONARECIBE;
                db.SaveChanges();
            }
            
        }


        #region Obtener
        
        public static SAB_UACI_ENTREGABASES Obtener(SAB_UACI_ENTREGABASES entrega)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, entrega);
            }
        }

        private static SAB_UACI_ENTREGABASES Obtener(SinabEntities db, SAB_UACI_ENTREGABASES entrega)
        {
            return Obtener(db, entrega.IDESTABLECIMIENTO, entrega.IDPROCESOCOMPRA, entrega.IDPROVEEDOR);
        }

        public static SAB_UACI_ENTREGABASES Obtener(int idEstablecimiento, long idProcesoCompra, int idProveedor)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, idEstablecimiento, idProcesoCompra, idProveedor);
            }
        }

        private static SAB_UACI_ENTREGABASES Obtener(SinabEntities db, int idEstablecimiento, long idProcesoCompra, int idProveedor)
        {
            return db.SAB_UACI_ENTREGABASES.FirstOrDefault(eb => eb.IDESTABLECIMIENTO == idEstablecimiento &&
                                                                 eb.IDPROCESOCOMPRA == idProcesoCompra &&
                                                                 eb.IDPROVEEDOR == idProveedor);
        }

        #endregion Obtener
    }
}
