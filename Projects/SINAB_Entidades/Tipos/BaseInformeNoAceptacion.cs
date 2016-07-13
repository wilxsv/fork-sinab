using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    [Serializable()]
    public class BaseInformeNoAceptacion
    {
        public int IdInforme { get; set; }
        public int IdAlmacen { get; set; }
        public int IdEstablecimientoMovimiento { get; set; }
        public long IdMovimiento { set; get; }

        public string NumeroInforme
        {
            get
            {
// NumeroInforme = ina.IDINFORME.ToString()+"/"+ ina.ANIO.ToString(),
                return string.Format("{0}/{1}", IdDocumento, Anio);

            }
        }

        public DateTime DateMovimiento { get; set; }
        public string FechaMovimiento {
            get { return DateMovimiento.ToShortDateString(); }
        }
        public string TipoNumeroDocumento{ get; set; }
        public string Proveedor { get; set; }
        public string Estado { get; set; }
        public short Anio { get; set; }
        public int IdEstablecimiento { get; set; }
        public int IdProveedor { get; set; }
        public long IdContrato { get; set; }
        public int IdDocumento { get; set; }
    }
}
