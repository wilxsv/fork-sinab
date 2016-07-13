using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.CertificacionHelpers
{
    public static class Procesos
    {

        public static void CargarALista(ref DropDownList lista, int idsuministro)
        {
            List<SAB_CP_PROCESO> listado;

            using (var db = new SinabEntities())
            {
                listado = db.SAB_CP_PROCESO.Where(p => p.IdTipoProducto == idsuministro).ToList();
            }

            lista.DataSource = listado;
            lista.DataTextField = "NumProceso";
            lista.DataValueField = "IdProceso";
            lista.DataBind();
        }

        public static List<BaseProceso> ObtenerTodos()
        {
            using (var db = new SinabEntities())
            {
                return
                    (from cp in db.SAB_CP_PROCESO
                        join s in db.SAB_CAT_SUMINISTROS on cp.IdTipoProducto equals s.IDSUMINISTRO
                        select new BaseProceso
                        {
                            IdProceso = cp.IdProceso,
                            NumeroProceso = cp.numproceso,
                            IdTipoProducto = cp.IdTipoProducto,
                            Estado = (EnumHelpers.EstadoProceso) cp.estado,
                            FechaInicio = cp.fechainicio,
                            FechaFin = cp.fechafin,
                            Descripcion = s.DESCRIPCION,

                        }
                    ).OrderBy(cp => cp.Estado).ToList();

            }
        }

        /*
         SELECT A.IDPROCESO, A.NUMPROCESO, A.IDTIPOPRODUCTO, CASE WHEN A.ESTADO=0 THEN 'ABIERTO' ELSE 'CERRADO' END AS ESTADO, A.FECHAINICIO, A.FECHAFIN, L.DESCRIPCION AS TIPOPRODUCTO ")
        strSQL.Append(" FROM SAB_CP_PROCESO A INNER JOIN SAB_CAT_SUMINISTROS  L ")
        strSQL.Append(" ON A.IDTIPOPRODUCTO=L.IDSUMINISTRO  ")
        strSQL.Append(" WHERE A.IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " and A.IDPROCESO=" & IDPROCESO
         */

        public static BaseProceso Obtener(decimal idProceso, decimal idTipoProducto)
        {
            using (var db = new SinabEntities())
            {
                return (from p in db.SAB_CP_PROCESO
                    join s in db.SAB_CAT_SUMINISTROS on p.IdTipoProducto equals s.IDSUMINISTRO
                    select new BaseProceso()
                    {
                        IdProceso = p.IdProceso,
                        NumeroProceso = p.numproceso,
                        IdTipoProducto = p.IdTipoProducto,
                        Estado = (EnumHelpers.EstadoProceso) p.estado,
                        FechaFin = p.fechafin,
                        FechaInicio = p.fechainicio,
                        TipoProducto = s.DESCRIPCION
                    }
                    ).FirstOrDefault(cp => cp.IdProceso == idProceso && cp.IdTipoProducto == idTipoProducto);
            }
        }
    }
}
