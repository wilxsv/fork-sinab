using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Helpers.CatalogoHelpers
{
    public  class GuardaAlmacen
    {
        public GuardaAlmacenInfo Obtener(int idAlmacen)
        {
            using (var db = new SinabEntities())
            {
                var galmacen = db.SAB_CAT_EMPLEADOS.Join(db.SAB_CAT_EMPLEADOSALMACEN,
                                                         e => e.IDEMPLEADO,
                                                         ea => ea.IDEMPLEADO,
                                                         (e, ea) => new GuardaAlmacenInfo
                                                                        {
                                                                            Nombre = e.NOMBRE + " " + e.APELLIDO, 
                                                                            IdEmpleado = e.IDEMPLEADO, 
                                                                            IdAlmacen = ea.IDALMACEN, 
                                                                            EsGuardaAlmacen = ea.ESGUARDAALMACEN
                                                                        }).Where(
                                                             guarda =>
                                                             guarda.IdAlmacen == idAlmacen &&
                                                             guarda.EsGuardaAlmacen == 1);
                return galmacen.FirstOrDefault();
            }
        } 
    }
}

public class GuardaAlmacenInfo
{
    public string Nombre { get; set; }
    public int IdEmpleado { get; set; }
    public int IdAlmacen { get; set; }
    public byte EsGuardaAlmacen { get; set; }
}

