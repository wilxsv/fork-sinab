using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Helpers.LabHelpres
{
    public static class HistoricoNotificacion
    {
        public static void Agregar(SAB_LAB_HISTORICONOTIFICACION historico)
        {
            using (var db = new SinabEntities())
            {
                Agregar(db, historico);
            }
        }

        public static void Agregar(SinabEntities db, SAB_LAB_HISTORICONOTIFICACION historico)
        {
            db.SAB_LAB_HISTORICONOTIFICACION.AddObject(historico);
            db.SaveChanges();
        }
    }
}
