using System;
using System.Linq;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public static class ValesSalida
    {
        public static void Eliminar(SinabEntities db, SAB_ALM_VALESSALIDA vale)
        {
            var v = db.SAB_ALM_VALESSALIDA.FirstOrDefault(vs => vs.IDVALE == vale.IDVALE && vs.IDALMACEN == vale.IDALMACEN && vs.ANIO == vale.ANIO);
            if (v != null) db.SAB_ALM_VALESSALIDA.DeleteObject(v);
        }

        public static void Anular(SinabEntities db, SAB_ALM_VALESSALIDA vale)
        {
            var v =
                db.SAB_ALM_VALESSALIDA.FirstOrDefault(
                    vs => vs.IDVALE == vale.IDVALE && vs.IDALMACEN == vale.IDALMACEN && vs.ANIO == vale.ANIO);
            if (v == null) return;
            v.ANULADO = true;
            v.OBSERVACION = vale.OBSERVACION;
            v.AUUSUARIOMODIFICACION = Membresia.ObtenerUsuario().USUARIO;
            v.AUFECHAMODIFICACION = DateTime.Now;
            db.SaveChanges();
        }

        public static SAB_ALM_VALESSALIDA Obtener(int idVale, int idAlmacen, int anio)
        {
            using (var db = new SinabEntities())
            {
                try
                {
                    return Obtener(db, idVale, idAlmacen, anio);
                }
                catch (Exception ex) { throw ex; }
            }
        }

        public static SAB_ALM_VALESSALIDA Obtener(SinabEntities db, int idVale, int idAlmacen, int anio)
        {
            return db.SAB_ALM_VALESSALIDA.FirstOrDefault(vs => vs.IDVALE == idVale && vs.IDALMACEN == idAlmacen && vs.ANIO == anio);
        }

        public static SAB_ALM_VALESSALIDA Obtener(SAB_ALM_VALESSALIDA vale)
        {
            using (var db = new SinabEntities())
            {
                try
                {
                    return db.SAB_ALM_VALESSALIDA.FirstOrDefault(vs => vs.IDVALE == vale.IDVALE && vs.IDALMACEN == vale.IDALMACEN && vs.ANIO == vale.ANIO);
                }
                catch (Exception ex) { throw ex; }
            }
        }

        public static SAB_ALM_VALESSALIDA Obtener(SAB_ALM_MOVIMIENTOS movimiento)
        {
            using (var db = new SinabEntities())
            {
                try
                {
                    return db.SAB_ALM_VALESSALIDA.FirstOrDefault(vs => vs.IDVALE == movimiento.IDDOCUMENTO && vs.IDALMACEN == movimiento.IDALMACEN && vs.ANIO == movimiento.ANIO);
                }
                catch (Exception ex) { throw ex; }
            }
        }


        public static void Actualizar(SAB_ALM_VALESSALIDA vale)
        {
            using (var db = new SinabEntities())
            {
                try
                {
                    var currentVale = db.SAB_ALM_VALESSALIDA.FirstOrDefault(vs => vs.IDVALE == vale.IDVALE && vs.IDALMACEN == vale.IDALMACEN && vs.ANIO == vale.ANIO);

                    if (currentVale != null) //si ya existe el vale
                    {
                        currentVale.TRANSPORTISTA = vale.TRANSPORTISTA;
                        currentVale.MATRICULAVEHICULO = vale.MATRICULAVEHICULO;
                        currentVale.PERSONARECIBE = vale.PERSONARECIBE;
                        currentVale.IDTIPOIDENTIFICACION = vale.IDTIPOIDENTIFICACION;
                        currentVale.NUMEROIDENTIFICACION = vale.NUMEROIDENTIFICACION;
                        currentVale.OBSERVACION = vale.OBSERVACION;
                        currentVale.AUUSUARIOMODIFICACION = vale.AUUSUARIOMODIFICACION;
                        currentVale.AUFECHAMODIFICACION = vale.AUFECHAMODIFICACION;
                        currentVale.ESTASINCRONIZADA = vale.ESTASINCRONIZADA;
                        db.SaveChanges();
                    }
                    else // si no existe se crea
                    {//p == null ? 0 : p.X
                        var lastId = ObtenerUltimoId(db, vale);
                        vale.IDVALE = lastId + 1;
                        db.SAB_ALM_VALESSALIDA.AddObject(vale);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex) { throw ex; }
            }

        }

        public static void Guardar(SinabEntities db, SAB_ALM_VALESSALIDA vale)
        {
            var lastId = ObtenerUltimoId(db, vale);
            vale.IDVALE = lastId + 1;
            db.SAB_ALM_VALESSALIDA.AddObject(vale);
            db.SaveChanges();
        }

        public static void Guardar(SinabEntities db, SAB_ALM_VALESSALIDA vale, bool id)
        {
            db.SAB_ALM_VALESSALIDA.AddObject(vale);
            db.SaveChanges();
        }


        public static int ObtenerUltimoId(SinabEntities db, SAB_ALM_VALESSALIDA vale)
        {
            return db.SAB_ALM_VALESSALIDA.Where(vs => vs.IDALMACEN == vale.IDALMACEN && vs.ANIO == vale.ANIO).DefaultIfEmpty().Max(vs => vs == null ? 0 : vs.IDVALE);
        }
    }
}
