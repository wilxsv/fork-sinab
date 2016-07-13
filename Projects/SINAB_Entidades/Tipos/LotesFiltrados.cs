using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class LotesFiltrados
    {
        public long IDLOTE { get; set; }

        public string CODIGOLOTE{
            get
            {
                if (String.IsNullOrEmpty(CODIGO))
                {
                    return string.IsNullOrEmpty(DETALLE) ? "(N/A)" : DETALLE;
                }
                return string.IsNullOrEmpty(DETALLE) ? CODIGO : string.Format("{0} {1}", CODIGO, DETALLE);
            }
            
        }

        public string CODIGO { get; set; }

        public long IDPRODUCTO { get; set; }

        public string CORRPRODUCTO { get; set; }

        public string DESCLARGO { get; set; }

        public string FUENTEFINANCIAMIENTO { get; set; }

        public decimal CANTIDAD {
            get
            {
                switch (FILTRO)
                {
                    case 1:
                        return CANTIDADDISPONIBLE;
                    case 2:
                        return CANTIDADNODISPONIBLE;
                    case 3:
                        return CANTIDADVENCIDA;
                    case 4:
                        return CANTIDADRESERVADA;
                    case 5:
                        return CANTIDADVENCIDA;
                    case 6:
                        if (CANTIDADDISPONIBLE > 0) return CANTIDADDISPONIBLE;
                        return CANTIDADVENCIDA > 0 ? CANTIDADVENCIDA : 0;
                }
                return 0;
            }
        }

        public string UNIDADMEDIDA { get; set; }

        public decimal PRECIOLOTE { get; set; }

        public string UBICACION { get; set; }

        public string CODIGODETALLE {
            get
            {
                if (string.IsNullOrEmpty(CODIGO) || CODIGO == "(N/A)")
                {
                    return string.IsNullOrEmpty(DETALLE) ? "(N/A)" : DETALLE;
                }
                return string.IsNullOrEmpty(DETALLE) ? CODIGO : CODIGO + DETALLE;
            }
        }

        public string FECHAVENCIMIENTOMMAAAA {
            get
            {
               
                    return FECHAVENCIMIENTO == DateTime.MinValue
                        ? "(N/A)"
                        : string.Format("{0:MM/yyyy}", FECHAVENCIMIENTO);
                
            }
        }

        public byte CANTIDADDECIMAL { get; set; }

        public int FILTRO { get; set; }

        public decimal CANTIDADDISPONIBLE { get; set; }

        public decimal CANTIDADVENCIDA { get; set; }

        public decimal CANTIDADRESERVADA { get; set; }

        public decimal CANTIDADNODISPONIBLE { get; set; }

        public string DETALLE { get; set; }

        public DateTime FECHAVENCIMIENTO { get; set; }

        public string NOMBRE { get; set; }
        public string NOMBREALMACEN {
            get { return NOMBRE; }
        }
        public int IDGRUPO { get; set; }
        public string CORRGRUPO { get; set; }
        public string DESCGRUPO { get; set; }
        public string NOMBRERESPONSABLE { get; set; }
        public string NOMBRECORTORESPONSABLE { get; set; }
        public string NOMBREFUENTE { get; set; }
        public decimal MONTODISPONIBLE { get; set; }
        public decimal MONTONODISPONIBLE { get; set; }
        public decimal MONTOVENCIDA { get; set; }
        public decimal MONTORESERVADA { get; set; }
        public int IDALMACEN { get; set; }
        public int IDSUMINISTROS { get; set; }
        public int IDFUENTEFINANCIAMIENTO { get; set; }
        public int IDRESPONSABLEDISTRIBUCION { get; set; }

        public short IDGRUPOFUENTEFINANCIAMIENTO { get; set; }

        public short IDESPECIFICOGASTO { get; set; }

        public int IDESTABLECIMIENTO { get; set; }

        public decimal CANTIDADTEMPORAL { get; set; }

        public byte ESTADISPONIBLE { get; set; }
    }
}
