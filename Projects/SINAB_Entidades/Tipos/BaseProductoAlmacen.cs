using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    public class BaseProductoAlmacen
    {
        public string Almacen { get; set; }
        public int CuadroBasico { get; set; }
        public int Desabastecido { get; set; }
        public int Abastecido { get; set; }
    }

    public class BaseProductoAlmacenDetalle : BaseProductoAlmacen
    {
        public string Correlativo { get; set; }
        public string Descripcion { get; set; }
        public string Clasificacion { get; set; }
    }

    public class BaseProductoDesabastecido : BaseProductoAlmacenDetalle
    {
        public int IdAlmacen { get; set; }
        public long IdProducto { get; set; }
        public int IdUnidadMedida { get; set; }
        public string UnidadMedida { get; set; }
        public int IdSuministro { get; set; }
        public string Suministro { get; set; }
        public short Exitencias { get; set; }
        public int Id { get; set; }
    }

    public class BaseProductoSinExistenciaReporte
    {
        public int Correlativo { get; set; }
        public string CorrProducto { get; set; }
        public string DescLargo { get; set; }

    }

}
