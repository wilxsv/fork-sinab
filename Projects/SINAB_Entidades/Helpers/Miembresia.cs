using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers
{
    public static class Membresia
    {
        private static Usuario UsuarioGlobal
        {
            get { return (Usuario) (HttpContext.Current.Session["usuario"]); }
            set { HttpContext.Current.Session["usuario"] = value; }
        }

        public static Usuario ObtenerUsuario()
        {
            if (UsuarioGlobal == null) ObtenerUsuario(HttpContext.Current.User.Identity.Name);
            return UsuarioGlobal;
        }

        public static bool ValidarUsuario(string nombre, string clave, bool esComision)
        {
            return !esComision ? VerificarUsuario(nombre, clave) : VerificarUsuarioComision(nombre, clave);
        }

        public static Usuario ObtenerUsuario(string usuario)
        {
            using (var db = new segabasEntities())
            {
                var usr =
                    db.SEGUSUARIOS.FirstOrDefault(u => u.USUARIO == usuario && u.ESTAHABILITADO == 1);
                if (usr != null) RecuperarUsuario(usr, db);
                return ObtenerUsuario();
            }
        }

        public static bool CambiarClave(int idUsuario, string claveNueva)
        {
            using (var db = new segabasEntities())
            {
                var usr = db.SEGUSUARIOS.FirstOrDefault(u => u.IDUSUARIO == idUsuario);
                if (usr == null) return false;
                usr.CLAVE = claveNueva;
                db.SaveChanges();
                return true;
            }
        }

        public static bool CambiarClave(string claveNueva)
        {
            using (var db = new segabasEntities())
            {
                var usr = db.SEGUSUARIOS.FirstOrDefault(u => u.IDUSUARIO == UsuarioGlobal.IDUSUARIO);
                if (usr == null) return false;
                usr.CLAVE = claveNueva;
                db.SaveChanges();
                return true;
            }
        }

        public static List<SEGROLE> ObtenerRolesPorUsuario()
        {
            try
            {
                using (var db = new segabasEntities())
                {
                    return UsuarioGlobal.RolesUsuario.Select(ur => db.SEGROLES.FirstOrDefault(r => r.IDROL == ur.IDROL)).ToList();
                   
                }
            }
            catch
            {
                return null;
            }
        }

        public static string[] ObtenerRoles()
        {
            try
            {
                using (var db = new segabasEntities())
                {
                    var roles = UsuarioGlobal.RolesUsuario.Select(ur => db.SEGROLES.FirstOrDefault(r => r.IDROL == ur.IDROL).NOMBRE);
                    return roles.ToArray();
                }
            }
            catch
            {
                return new[] { "-" };
            }
        }

        public static bool EsUsuarioRol(string nombreRol)
        {
            try
            {
                using (var db = new segabasEntities())
                {
                    if(UsuarioGlobal == null) UsuarioGlobal = ObtenerUsuario();

                    var roles = UsuarioGlobal.RolesUsuario.Select(ur => db.SEGROLES.FirstOrDefault(r => r.IDROL == ur.IDROL)).ToList();
                    if (!roles.Any()) return false;

                    var rol = roles.FirstOrDefault(r => r.NOMBRE == nombreRol);
                    return rol != null;
                }
            }
            catch
            {
                
                return false;
            }
        }

        private static bool VerificarUsuario(string nombre, string clave)
        {
            using (var db = new segabasEntities())
            {
                var usr =
                    db.SEGUSUARIOS.FirstOrDefault(u => u.USUARIO == nombre && u.CLAVE == clave && u.ESTAHABILITADO == 1);

                if (usr == null) return false;
                RecuperarUsuario(usr, db);
                return true;
            }
        }

        private static bool VerificarUsuarioComision(string nombre, string clave)
        {
            using (var db = new SinabEntities())
            {
                var usr =
                    db.SAB_UACI_COMISIONPROCESOCOMPRA.FirstOrDefault(
                        u => u.USUARIOCOMISION == nombre && u.CLAVE == clave && u.ESTAHABILITADO == 1);
                if (usr == null) return false;
                //si no tiene un Establecimiento asociado
                if (usr.IDESTABLECIMIENTO <= 0) throw new AuthenticationException("El usuario no se encuentra asociado a un establecimiento. Acceso denegado.");

                UsuarioGlobal = new Usuario()
                {
                    EsComision = true,
                    USUARIO = usr.USUARIOCOMISION,
                    CLAVE = usr.CLAVE,
                    ESTAHABILITADO = usr.ESTAHABILITADO,
                    AUUSUARIOCREACION = usr.AUUSUARIOCREACION,
                    AUFECHACREACION = usr.AUFECHACREACION,
                    AUUSUARIOMODIFICACION = usr.AUUSUARIOMODIFICACION,
                    AUFECHAMODIFICACION = usr.AUFECHAMODIFICACION,
                    ESTASINCRONIZADA = usr.ESTASINCRONIZADA,
                    Establecimiento = db.SAB_CAT_ESTABLECIMIENTOS.FirstOrDefault(es => es.IDESTABLECIMIENTO == usr.IDESTABLECIMIENTO),
                    IdProcesoCompra = usr.IDPROCESOCOMPRA,
                    IdComision = usr.IDCOMISION
                };
                RegistrarAcceso(nombre, new segabasEntities());
                return true;
                //return UsuarioComision != null;

            }
        }

        private static void RegistrarAcceso(string nombre, segabasEntities db)
        {
            try
            {
                var sacceso = new SEGACCESO()
                                 {
                                     USUARIO = nombre,
                                     DIRECCIONIP = HttpContext.Current.Request.UserHostAddress,
                                     AUFECHACREACION = DateTime.Now,
                                     ESTASINCRONIZADA = 0
                                 };
                db.SEGACCESOS.AddObject(sacceso);
                db.SaveChanges();
            }
            
            catch (UpdateException ex)
            {
                throw new Exception(ex.Message);

                //todo: save to log 22-06-40-00
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
                //todo: save to log;
            }
        }

        private static void RecuperarUsuario(SEGUSUARIO usr, segabasEntities db)
        {
            UsuarioGlobal = new Usuario()
            {
                IDUSUARIO = usr.IDUSUARIO,
                USUARIO = usr.USUARIO,
                CLAVE = usr.CLAVE,
                IDEMPLEADO = usr.IDEMPLEADO,
                ESTAHABILITADO = usr.ESTAHABILITADO,
                ESTAELIMINADO = usr.ESTAELIMINADO,
                AUUSUARIOCREACION = usr.AUUSUARIOCREACION,
                AUFECHACREACION = usr.AUFECHACREACION,
                AUUSUARIOMODIFICACION = usr.AUUSUARIOMODIFICACION,
                AUFECHAMODIFICACION = usr.AUFECHAMODIFICACION,
                AUUSUARIOELIMINACION = usr.AUUSUARIOELIMINACION,
                AUFECHAELIMINACION = usr.AUFECHAELIMINACION,
                ESTASINCRONIZADA = usr.ESTASINCRONIZADA,
                RolesUsuario = db.SEGROLESUSUARIOS.Where(su => su.IDUSUARIO == usr.IDUSUARIO).ToList(),
                Menu = db.vv_OPCIONESUSUARIOSROL.Where(vv => vv.IDUSUARIO == usr.IDUSUARIO).Distinct().OrderBy(vv => vv.ORDEN).ToList()
                
            };

            using (var dbs = new SinabEntities())
            {
                var emp = dbs.SAB_CAT_EMPLEADOS
                    .Include("SAB_CAT_CARGOS")
                    .Include("SAB_CAT_DEPENDENCIAS")
                    .Include("SAB_CAT_ESTABLECIMIENTOS")
                    .Include("SAB_CAT_ESTABLECIMIENTOS.SAB_CAT_ZONAS")
                    .Include("SAB_CAT_ESTABLECIMIENTOS.SAB_CAT_TIPOESTABLECIMIENTOS")
                    .Include("SAB_CAT_EMPLEADOSALMACEN.SAB_CAT_ALMACENES")
                    .FirstOrDefault(em => em.IDEMPLEADO == UsuarioGlobal.IDEMPLEADO);

                if (emp != null)
                {
                    UsuarioGlobal.Empleado = emp;
                    UsuarioGlobal.Cargo = UsuarioGlobal.Empleado.SAB_CAT_CARGOS;
                    UsuarioGlobal.Dependencia = UsuarioGlobal.Empleado.SAB_CAT_DEPENDENCIAS;
                    UsuarioGlobal.Establecimiento = UsuarioGlobal.Empleado.SAB_CAT_ESTABLECIMIENTOS;
                    UsuarioGlobal.Zona = UsuarioGlobal.Establecimiento.SAB_CAT_ZONAS;
                    UsuarioGlobal.TipoEstablecimiento = UsuarioGlobal.Establecimiento.SAB_CAT_TIPOESTABLECIMIENTOS;
                    UsuarioGlobal.EmpleadoAlmacenes = UsuarioGlobal.Empleado.SAB_CAT_EMPLEADOSALMACEN.ToList();
                    //todo:suministros pueden ser varios
                    if (UsuarioGlobal.EmpleadoAlmacenes != null)
                    {
                        var almacenes = UsuarioGlobal.EmpleadoAlmacenes.Select(al => al.SAB_CAT_ALMACENES).ToList();
                        UsuarioGlobal.Almacenes = almacenes;

                        var sabCatEmpleadosalmacen = UsuarioGlobal.EmpleadoAlmacenes.FirstOrDefault();
                        if (sabCatEmpleadosalmacen != null)
                        {
                            var idsuministro = sabCatEmpleadosalmacen.IDSUMINISTRO;
                            var suministro =  dbs.SAB_CAT_SUMINISTROS.FirstOrDefault(
                                sm => sm.IDSUMINISTRO == idsuministro);

                            UsuarioGlobal.Suministro = suministro;
                        }
                    }
                }
            }

            RegistrarAcceso(usr.USUARIO, db);
        }


       

    }
}
