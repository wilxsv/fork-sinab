using System;

namespace SINAB_Entidades.Tipos
{
    [Serializable]
    public class OperacionesLotes
    {
        public int CantidadVencida { get; set; }
        public int CantidadDisponible { get; set; }
        public int CantidadNoDisponible { get; set; }
        public int CantidadTemporal { get; set; }
        public int CantidadReservada { get; set; }
    }
}