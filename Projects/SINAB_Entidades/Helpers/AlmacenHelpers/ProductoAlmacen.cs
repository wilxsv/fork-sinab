using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Net.Sockets;
using System.Security;
using System.Text;
using Microsoft.CSharp;
using SINAB_Entidades.Tipos;
using SINAB_Utils;

namespace SINAB_Entidades.Helpers.AlmacenHelpers
{
    public static class ProductoAlmacen
    {
       

        public static List<BaseProductoAlmacen> ObtenerDetalleAbastecimiento(int idAlmacen, int semana, int anio)
        {
            using (var db  = new SinabEntities())
            {
                List<prc_ProductosDesabastecidos_Result> pd;
                List<prc_ProductosAbastecidos_Result> pa;

                var inicioSemana =  Semana.FechaInicio(anio, semana);
                var cb = CuadroBasico.Obtener(db, idAlmacen);

                //EN ESTE SELECT SE OBTIENEN LOS PRODUCTOS SIN EXISTENCIAS EN LA SEMANA Y AÑO  DETALLADO
                if (inicioSemana >= cb.FechaInicio)
                {
                    pd = db.prc_ProductosDesabastecidos(semana, anio, idAlmacen).ToList();
                    pa = db.prc_ProductosAbastecidos(semana, anio, idAlmacen).ToList();
                }
                else
                {
                    pd = db.prc_ProductosDesabastecidosPasado(semana, anio, inicioSemana, idAlmacen).ToList();
                    pa = db.prc_ProductosAbastecidosPasado(semana, anio,inicioSemana, idAlmacen).ToList();
                }
               
               
                return (from d in pd
                    join a in pa on new {d.nombre, d.cb} equals new {a.nombre, a.cb}
                           select new BaseProductoAlmacen
                    {
                        Almacen = a.nombre,
                        CuadroBasico = a.cb,
                        Desabastecido = d.se,
                        Abastecido = a.ce
                    }).ToList();

            }
        }

        public static List<BaseProductoAlmacenDetalle> ObtenerReporteDetallado()
        {
            using (var db = new SinabEntities())
                return (from pa in db.SAB_ALM_PRODUCTOSALMACEN
                    join al in db.SAB_CAT_ALMACENES on pa.IdHospital equals al.IDALMACEN
                    join cp in db.vv_CATALOGOPRODUCTOS on new {pa.IdProducto, pa.IdSuministro}
                        equals new {IdProducto =  cp.IDPRODUCTO, IdSuministro = cp.IDSUMINISTRO}
                    select new BaseProductoAlmacenDetalle()
                    {
                        Almacen = al.NOMBRE,
                        Correlativo = cp.CORRPRODUCTO,
                        Descripcion = cp.DESCLARGO,
                        Clasificacion = cp.CLASIFICACION
                    }).OrderBy(ob => ob.Almacen).ThenBy(ob => ob.Correlativo).ToList();
        }


        public static List<prc_DesabastecimientoLocal_Result> ObtenerDesabastecimiento(int idSuministro, int semana, int year)
        {
            using (var db = new SinabEntities()){
                
                return db.prc_DesabastecimientoLocal(semana, year, idSuministro).ToList();
            }
        }

        public static List<prc_DesabastecimientoAlmacenLocal_Result> ObtenerDesabastecimiento(int idAlmacen, int idSuministro, int semana, DateTime inicioSemana,  int year)
        {
            using (var db = new SinabEntities())
            {
                var cb = CuadroBasico.Obtener(db, idAlmacen);
                return inicioSemana >= cb.FechaInicio ? db.prc_DesabastecimientoAlmacenLocal(semana, year, idSuministro, idAlmacen).ToList() : db.prc_DesabastecimientoAlmacenLocalPasado(semana, inicioSemana, year, idSuministro, idAlmacen).ToList();
            }
        }

        public static List<prc_DesabastecimientoAlmacenLocal_Result> ObtenerDesabastecimiento(int idAlmacen,
            int idSuministro, int idPrograma, int semana, DateTime inicioSemana, int year)
        {
            using (var db = new SinabEntities())
            {
                var cb = CuadroBasico.Obtener(db, idAlmacen);
                return inicioSemana >= cb.FechaInicio ? db.prc_DesabastecimientoAlmacenLocalPorPrograma(semana, year, idSuministro, idAlmacen, idPrograma).ToList() : 
                    db.prc_DesabastecimientoAlmacenLocalPasadoPorPrograma(semana, inicioSemana, year, idSuministro, idAlmacen, idPrograma).ToList();
            }
        }


    }

    
}
