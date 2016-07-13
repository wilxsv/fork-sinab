using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINAB_Entidades.Tipos;

namespace SINAB_Entidades.Helpers.EstablecimientoHelpers
{
    public static class AdministradoresContrato
    {
        public static void Eliminar(int idAdministrador, int idSolicitud, int idEstablecimiento)
        {
            using (var db = new SinabEntities())
            {
                var obj =
                    db.SAB_EST_ADMINISTRADORESCONTRATO.FirstOrDefault(
                        adm =>
                            adm.IdAdministrador == idAdministrador && adm.IdSolicitud == idSolicitud &&
                            adm.IdEstablecimiento == idEstablecimiento);
                if (obj == null) return;
                db.SAB_EST_ADMINISTRADORESCONTRATO.DeleteObject(obj);
                db.SaveChanges();
            }
        }

        public static void Agregar(SAB_EST_ADMINISTRADORESCONTRATO administrador)

        {
            using (var db = new SinabEntities())
            {
                db.SAB_EST_ADMINISTRADORESCONTRATO.AddObject(administrador);
                db.SaveChanges();
            }
        }

        public static List<BaseAdministradores> ObtenerTodos(int idsolicitud, int idestablecimiento)
        {
            using (var db = new SinabEntities())
            {
                return
                    db.SAB_EST_ADMINISTRADORESCONTRATO.Where(
                        ac => ac.IdSolicitud == idsolicitud && ac.IdEstablecimiento == idestablecimiento)
                        .Select(ac => new BaseAdministradores()
                        {
                            IdSolicitud =  (int) ac.IdSolicitud,
                            IdEstablecimiento = (int) ac.IdEstablecimiento,
                            Administrador = ac.Administrador,
                            Cargo = ac.Cargo,
                            Email = ac.Email,
                            Telefono = ac.Telefono

                        }).ToList();
            }
        }
    }
}
