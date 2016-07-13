namespace SINAB_Entidades.Helpers.UACIHelpers
{
    public static class ObservacionProcesoCompras
    {
        public static void Agregar(SAB_UACI_OBSERVACIONPROCESOSCOMPRAS observacion)
        {
            using (var db = new SinabEntities())
            {
                db.SAB_UACI_OBSERVACIONPROCESOSCOMPRAS.AddObject(observacion);
                db.SaveChanges();
            }
        }
    }
}
