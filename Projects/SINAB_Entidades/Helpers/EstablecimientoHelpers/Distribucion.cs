using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Transactions;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class Distribucion
    {
        /// <summary>
        /// Obtiene distribución por establecimiento e id conocido
        /// </summary>
        /// <param name="idDistribucion"></param>
        /// <param name="idEstablecimiento"></param>
        /// <returns>la distribución que concuerda con los parametros pedidos</returns>
        public static SAB_EST_DISTRIBUCION Obtener(int idDistribucion, int  idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return
                    db.SAB_EST_DISTRIBUCION.
                    Include(d => d.SAB_CAT_ALMACENES).
                    Include(d => d.SAB_CAT_SUMINISTROS).
                    FirstOrDefault( d => 
                        d.IDDISTRIBUCION == idDistribucion && 
                        d.IDESTABLECIMIENTO == idEstablecimiento);
            }
        }

        public static SAB_EST_DISTRIBUCION Obtener(SAB_EST_DISTRIBUCION distribucion)
        {
            using (var db = new SinabEntities())
            {
                return Obtener(db, distribucion);
            }
        }

        public static SAB_EST_DISTRIBUCION Obtener(SinabEntities db, SAB_EST_DISTRIBUCION distribucion)
        {
                return
                    db.SAB_EST_DISTRIBUCION.
                    Include(d => d.SAB_CAT_ALMACENES).
                    Include(d => d.SAB_CAT_SUMINISTROS).
                    FirstOrDefault(d =>
                        d.IDDISTRIBUCION == distribucion.IDDISTRIBUCION &&
                        d.IDESTABLECIMIENTO == distribucion.IDESTABLECIMIENTO);
        }

        public static SAB_EST_DISTRIBUCION ObtenerCerrados(int idDistribucion, int idEstablecimientoDistribucion)
        {
            using (var db = new SinabEntities())
            {
                return (from d in db.SAB_EST_DISTRIBUCION

                        join de in db.SAB_EST_DISTRIBUCIONESTABLECIMIENTO on new { d.IDDISTRIBUCION, d.IDESTABLECIMIENTO } equals
                        new { de.IDDISTRIBUCION, de.IDESTABLECIMIENTO }

                        join dc in db.SAB_EST_DISTRIBUCIONESCERRADAS on new { d.IDDISTRIBUCION, d.IDESTABLECIMIENTO } equals
                        new { IDDISTRIBUCION = (Int32)dc.IDDISTRIBUCION, IDESTABLECIMIENTO = (Int32)dc.IDESTABLECIMIENTO }

                        where (d.ESTADO == 2 || d.ESTADO == 3) && d.IDDISTRIBUCION == idDistribucion && de.IDESTABLECIMIENTODISTRIBUCION == idEstablecimientoDistribucion
                        select d).FirstOrDefault();
            }
        }

        /// <summary>
        /// Recupera el mayor id actual de distribuciones y le suma 1 para calcular el nuevo maximo
        /// </summary>i
        /// <returns>retorna el maximo id calculado en ese momento</returns>
        public static long ObtenerMaxId(int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerMaxId(db, idEstablecimiento);
            }
        }
        public static int ObtenerMaxId(SinabEntities db, int idEstablecimeinto)
        {
                var rec = db.SAB_EST_DISTRIBUCION.Where(d => d.IDESTABLECIMIENTO == idEstablecimeinto).Max(l => l.IDDISTRIBUCION);
                return rec + 1;
        }

       
        /// <summary>
        /// Modifica una distribución existente
        /// </summary>
        /// <param name="distribucion">objeto con el que actualizará la distribución</param>
        /// <param name="db">contexto</param>
        public static void Modificar(SAB_EST_DISTRIBUCION distribucion, SinabEntities db)
        {
            var d = Obtener(db, distribucion);
            if (d == null) throw (new Exception("Error, no se encontro la distribución a actualizar"));
            d.IDALMACEN = distribucion.IDALMACEN;
            d.DESCRIPCION = distribucion.DESCRIPCION;
            d.FECHACORTE = distribucion.FECHACORTE;
            d.MESESCPM = distribucion.MESESCPM;
            d.MESESADMINISTRACION = distribucion.MESESADMINISTRACION;
            d.MESESSEGURIDAD = distribucion.MESESSEGURIDAD;
            d.MESESDISTRIBUCION = distribucion.MESESDISTRIBUCION;
            d.AUUSUARIOMODIFICACION = distribucion.AUUSUARIOMODIFICACION;
            d.AUFECHAMODIFICACION = distribucion.AUFECHAMODIFICACION;
            db.SaveChanges();
        }
        public static void Modificar(SAB_EST_DISTRIBUCION distribucion)
        {
            using (var db = new SinabEntities())
            {
                Modificar(distribucion, db);
            }
        }

        /// <summary>
        /// Crea una nueva distribucion
        /// </summary>
        /// <param name="distribucion">Objeto a crear</param>
        /// <param name="listado">listado de indice de productos</param>
        public static void Crear(SAB_EST_DISTRIBUCION distribucion, List<int> listado = null)
        {
            using (var ts = new TransactionScope())
            {
                try
                {
                    using (var db = new SinabEntities())
                    {
                        distribucion.IDDISTRIBUCION = ObtenerMaxId(db, distribucion.IDESTABLECIMIENTO);
                        db.SAB_EST_DISTRIBUCION.AddObject(distribucion);
                        db.SaveChanges();

                        DistribucionProductos.AgregarVarios(db, distribucion, listado);
                        DistribucionProductosLote.AgregarVarios(db, distribucion, listado);
                        DistribucionEstablecimiento.Agregar(db, distribucion);
                    }
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Obtiene todas las distribuciones del usuario parametrizado
        /// </summary>
        /// <param name="idEstablecimiento"></param>
        /// <param name="usr"></param>
        /// <returns>Lista de distribuciones</returns>
        public static List<SAB_EST_DISTRIBUCION> ObtenerTodos(int idEstablecimiento, string usr)
        {
            using (var db = new SinabEntities())
            {
                return (from d in db.SAB_EST_DISTRIBUCION
                            .Include(b=> b.SAB_CAT_SUMINISTROS)
                            .Include(b=> b.SAB_CAT_ALMACENES)
                    where
                        d.IDESTABLECIMIENTO == idEstablecimiento &&
                        (d.AUUSUARIOCREACION == usr || d.AUUSUARIOMODIFICACION == usr)
                        select d).OrderByDescending(d => d.IDDISTRIBUCION).ToList();
            }
        }


        public static List<SAB_EST_DISTRIBUCION> ObtenerTodosCerrados(int idEstablecimientoDistribucion, int anio)
        {
            using (var db = new SinabEntities())
            {
                return (from d in db.SAB_EST_DISTRIBUCION

                    join de in db.SAB_EST_DISTRIBUCIONESTABLECIMIENTO on new {d.IDDISTRIBUCION, d.IDESTABLECIMIENTO}
                        equals
                        new {de.IDDISTRIBUCION, de.IDESTABLECIMIENTO}

                    join dc in db.SAB_EST_DISTRIBUCIONESCERRADAS on new {d.IDDISTRIBUCION, d.IDESTABLECIMIENTO} equals
                        new
                        {
                            IDDISTRIBUCION = (Int32) dc.IDDISTRIBUCION,
                            IDESTABLECIMIENTO = (Int32) dc.IDESTABLECIMIENTO
                        }
                    where (d.ESTADO == 2 || d.ESTADO == 3) &&
                          de.IDESTABLECIMIENTODISTRIBUCION == idEstablecimientoDistribucion &&
                          d.FECHADISTRIBUCION.Year == anio
                    select d).Distinct().OrderByDescending(d => d.FECHADISTRIBUCION).ToList();

            }
        }

        public static void CargarCerradosALista(ref DropDownList lista,
            int idEstablecimientoDistribucion, int anio)
        {
            lista.DataSource = ObtenerTodosCerrados(idEstablecimientoDistribucion, anio)
                .ToDictionary(d => d.IDDISTRIBUCION, d => d.IDDISTRIBUCION +" - "+ d.DESCRIPCION);
            lista.DataTextField = "Value";
            lista.DataValueField = "Key";
            lista.DataBind();
        }

        public static void CargarCerradosTodosALista(ref DropDownList lista, int idEstablecimiento, int anio)
        {
            anio --;
            using (var db = new SinabEntities())
            {
                var res = db.SAB_EST_DISTRIBUCION
                    .Where(
                        d =>
                            d.IDESTABLECIMIENTO == idEstablecimiento && d.FECHADISTRIBUCION.Year >= anio &&
                            (d.ESTADO == 2 || d.ESTADO == 3))
                    .Distinct().OrderByDescending(d => d.FECHADISTRIBUCION)
                    .Select(d => d).ToDictionary(d => d.IDDISTRIBUCION, d => d.IDDISTRIBUCION + " - " + d.DESCRIPCION);


                lista.DataSource = res;
                lista.DataTextField = "Value";
                lista.DataValueField = "Key";
                lista.DataBind();

            }
        }

        //public static List<SAB_EST_DISTRIBUCION> ObtenerReporte(int idDistribucion, int idEstablecimiento,
        //    int idEstablecimientoDistribucion, int idProducto)
        //{
        //    using (var db = new SinabEntities())
        //    {
        //        var res = from d in db.SAB_EST_DISTRIBUCION
        //                  where d.IDDISTRIBUCION == idDistribucion
        //                  && d.ides
        //    }
        //}
    }
}
