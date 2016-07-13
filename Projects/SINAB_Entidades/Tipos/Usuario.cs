using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Linq;

namespace SINAB_Entidades.Tipos
{
    public class Usuario:SEGUSUARIO
    {
        public List<SEGROLESUSUARIO> RolesUsuario { get; set; }
        public SAB_CAT_EMPLEADOS Empleado { get; set; }
        public SAB_CAT_CARGOS Cargo { get; set; } //sinab : sab_cat_cargos
        public SAB_CAT_DEPENDENCIAS Dependencia { get; set; } //sinab : sab_cat_dependencias
        public SAB_CAT_ESTABLECIMIENTOS Establecimiento { get; set; } //sinab : sab_cat_establecimientos
        public SAB_CAT_ZONAS Zona { get; set; }
        public SAB_CAT_TIPOESTABLECIMIENTOS TipoEstablecimiento { get; set; }
        public List<SAB_CAT_EMPLEADOSALMACEN> EmpleadoAlmacenes { get; set; }
        public List<SAB_CAT_ALMACENES> Almacenes { get; set; }
        public List<vv_OPCIONESUSUARIOSROL> Menu { get; set; }
        public SAB_CAT_SUMINISTROS Suministro { get; set; }

        //campo para difereciar tipo de usuario
        public bool EsComision { get; set; }
        //campos especificos de usuario de alto nivel
        public long IdProcesoCompra { get; set; }
        public long IdComision { get; set; }
        public string ComisionUsuario { get; set; }
        public string NombreUsuario
        {
            get { return base.USUARIO; }
        }

        public string Clave
        {
            get { return base.CLAVE; }
        }

        public SAB_CAT_ALMACENES Almacen
        {
            get
            {
                return Almacenes.Any() ? Almacenes.FirstOrDefault(al => al.ESFARMACIA == 0) : null;
            }
        }

        public SAB_CAT_ALMACENES Farmacia
        {
            get { return Almacenes.Any() ? Almacenes.FirstOrDefault(al => al.ESFARMACIA == 1) : null; }
        }

       

    }
}