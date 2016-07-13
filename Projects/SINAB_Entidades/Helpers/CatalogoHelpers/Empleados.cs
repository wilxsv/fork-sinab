using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public static class Empleados
    {
        public static SAB_CAT_EMPLEADOS ObtenerJefeUFI(int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return ObtenerJefeUFI(db, idEstablecimiento);
            }
        }

        public static SAB_CAT_EMPLEADOS ObtenerJefeUFI(SinabEntities db, int idEstablecimiento)
        {
            return
                   db.SAB_CAT_EMPLEADOS.Include(em => em.SAB_CAT_CARGOS).FirstOrDefault(
                       em => em.IDCARGO == 162 && em.IDESTABLECIMIENTO == idEstablecimiento);
        }


        public static SAB_CAT_EMPLEADOS ObtenerMinistro()
        {
            using (var db = new SinabEntities())
            {
                return ObtenerMinistro(db);
            }
        }

        public static SAB_CAT_EMPLEADOS ObtenerMinistro(SinabEntities db)
        {
            return db.SAB_CAT_EMPLEADOS.Include(em => em.SAB_CAT_CARGOS).FirstOrDefault(em => em.IDCARGO == 190);
        }


        public static SAB_CAT_EMPLEADOS Obtener(SinabEntities db, int idEmpleado)
        {
            return db.SAB_CAT_EMPLEADOS.FirstOrDefault(em => em.IDEMPLEADO == idEmpleado);
        }

        public static void CargarInspectoresALista(ref DropDownList lista, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                CargarInspectoresALista(ref lista, db, idEstablecimiento);
            }
        }

        public static void CargarInspectoresALista(ref DropDownList lista, SinabEntities db, int idEstablecimiento)
        {
            /*
             select ce.* from SAB_CAT_EMPLEADOS ")
        strSQL.Append(" ce  inner join segabas.dbo.segusuarios u on u.idempleado = ce.idempleado ")
        strSQL.Append("WHERE ce.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND (ce.IDDEPENDENCIA = @IDDEPENDENCIA OR @IDDEPENDENCIA = 0) ")
        strSQL.Append("AND ce.IDEMPLEADO <> @IDEMPLEADO ")
        strSQL.Append("AND ce.IDCARGO = 130  and u.estahabilitado=1
             */
            //List<int> segusr;
            //using (var seg = new segabasEntities())
            //{
            //    segusr = seg.SEGUSUARIOS.Where(usr => usr.ESTAHABILITADO == 1).Select(usr=> usr.IDUSUARIO).ToList();
            //}

            //var res = db.SAB_CAT_EMPLEADOS.Where(em =>  segusr.Contains(em.IDEMPLEADO) && em.IDESTABLECIMIENTO == idEstablecimiento &&
            //              em.IDCARGO == 130 ).ToList();
            var res = db.prc_Inspectores(idEstablecimiento);
                lista.DataSource = res;
                lista.DataTextField = "NombreCompleto";
                lista.DataValueField = "IDEMPLEADO";
                lista.DataBind();
         

        }
    }
}
