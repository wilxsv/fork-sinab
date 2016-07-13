using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using SINAB_Entidades.Helpers.AlmacenHelpers;

namespace SINAB_Entidades.Tipos
{
    public class Documento
    {
        
        #region PROPIEDADES PUBLICAS

        public int IdEstablecimientoDestino { get; set; }
        public int IdAlmacen { get; set; }
        public int Anio { get; set; }
        public int IdVale { get; set; }
        public int IdEstablecimiento { get; set; }
        public int IdDocumento { get; set; }//mismo q idvale??
        public long IdMovimiento { get; set; }
        public string NumeroVale { get { return IdVale + "/" + ValeAnio; } }
        public int ValeAnio { set; get; }
        public DateTime FechaMovimiento { get; set; }
        public string EstablecimientoDestino { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; } //em.descripcion
        public int Renglones { get; set; } //conteo de dm
        
       // public List<SAB_ALM_DETALLEMOVIMIENTOS> Detallemovimientos { set; get; }
        public decimal Total {
            get; set;
        } //dm.cantidad * l.preciolote
        public SAB_ALM_MOVIMIENTOS Movimiento { get; set; }
        public bool DeRequisicion { get; set; } //si el movimiento se originó por requisicion;
        public string CodigoRequisicion { get; set; }

        #endregion
    }
}