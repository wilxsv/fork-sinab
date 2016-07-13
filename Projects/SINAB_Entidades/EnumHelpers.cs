using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SINAB_Entidades
{
    public static class EnumHelpers
    {
        /// <summary>
        /// Devuelve la propiedad "DescriptionAttribute" del valor de un enum parametrizado
        /// </summary>
        /// <param name="value">valor del enum</param>
        /// <returns>string correspondiente a "DescriptionAttribute"</returns>
        public static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }


        public enum LotesPorCantidad
        {
            Disponible = 1,
            NoDisponible = 2,
            Vencida = 3,
            Temporal = 5,
            DisponibleVencida = 6
        }


        public enum RequisicionEstados
        {
            Procesado = 'P',
            Enviado ='E', 
            Rechazado = 'R', //  --> modificar vale en el sinab
            Aceptado = 'A', //   --> vale a cerrar en el sinab
        }

        public enum EstadosMovimiento
        {
            Grabado = 1,
            Cerrado = 2,
            Anulado = 3,
            EnviadoAlmacen = 4,
            EnProceso = 5,
            Despachado = 6,
            EnviadoAUnidad = 7,
            AceptadoPorDependecia = 8,
        }
        
        public enum TiposTransaccion
        {
            RequisicionProductos = 1,
            Salida = 2,
            DevolucionProductos = 3,
            ActualizacionExistenciaMas = 4,
            ActualizacionExistenciaMenos = 5,
            ActualizarExistenciaNoDisponible = 6,
            ExistenciaInicial = 7,
            RecepcionProductos = 8,
            AjusteInventarioMas = 9,
            AjusteInventarioMenos = 10,
            InformeNoAceptacion = 11,
            RecepcionInterna = 12,
            ConsumoSIM = 13,
            CargaExistenciaInicial = 14,
            ActualizacionLote = 15,
            RecepcionPorTransferencia = 16,
            RecepcionPorDevolucion = 17
        }

        public enum EstadosProcesoCompra
        {
            [Description("Proceso de compra iniciado")] ProcesoCompraIniciado = 1,
            [Description("Base Generada")] BaseGenerada = 2,
            [Description("Base publicada")] BasePublicada = 3,
            [Description("Apertura de oferta")] AperturaOferta = 4,
            [Description("Consolidación de ofertas")] ConsolidacionOfertas = 5,
            [Description("Examen preliminar")] ExamenPreliminar = 6,
            [Description("Examen preliminar finalizado")] ExamenPreliminarFinalizado = 7,
            [Description("Comisión de evaluación ingresada")] ComisionEvaluacionIngresada = 8,
            [Description("Generar recomendación de compra")] GenerarRecomendacionCompra = 9,
            [Description("Esperar recursos de revisión")] EsperarRecursosRevision = 10,
            [Description("Proceso de compra anulado")] ProcesoCompraAnulado = 11,
            [Description("Generar resolución de adjudicación")] GenerarResolucionAdjudicacion = 12,
            [Description("Comisión de alto nivel ingresada")] ComisionAltoNivelIngresada = 13,
            [Description("Resolución de adjudicación generada")] ResolucionAdjudicacionGenerada = 14,
            [Description("Generar contratos")] GenerarContratos = 15,
            [Description("Distribuir contratos")] DistribuirContratos = 16,
            [Description("Contratos distribuidos")] ContratoDistribuidos = 17,
            [Description("Recepción de Ofertas")] RecepcionOfertas = 18,
        }

        public enum EstadosSolicitud
        {
            Grabada,
            Autorizada,
            [Description("Enviada a UACI")] EnviadaUACI,
            [Description("Rechazada por UACI")] RechazadaUACI,
            [Description("Aprobado proceso compra")] AprobadoProcesoCompra,
            [Description("Rechazado proceso compra")] RechazadoProcesoCompra
        }

        public enum TipoCompra
        {
            Individual,
            Conjunta
        }

        public enum TipoDocumentoBase
        {
            LegalPersonaJuridicaNacional = 1,
            LegalPersonaNaturalNacional = 2,
            DocumentosTecnicos = 3,
            Contrato = 4,
            OriginalesDocumentos = 7,
            LegalPersonaJuridicaExtranjera = 8,
            LegalPersonaNaturalExtrajera = 9
        }

        public enum EstadoProceso
        {
            Abierto = 0,
            Cerrado = 1,
        }

        public enum EstadoProductoProveedor
        {
            Certificado = 0,
            [Description("No Calificado")]
            NoCertificado = 1
        }

        public enum EstadoAspectos
        {
            Cumple = 0,
            [Description("No Cumple")] NoCumple = 1,
            [Description("No Aplica")] NoAplica = 2,
            [Description("No Considerado")] NoConsiderado =3
        }
        
        public enum TipoInformes 
        {
            Aceptacion = 1,
            Rechazo = 2,
            NoInspeccion = 3
        }

        public enum EstadoNotificacion
        {
            [Description("Creada por digitador")] Creada = 1,
            [Description("Asignar Inspector")] Asignacion = 2,
            [Description("Revisar por Inspector")] Revision =3,
            [Description("Asignacir Informe y distribución")] Distribucion = 4,
            [Description("Generacar certificado y observación")] Certificacion = 5,
            [Description("Aprobada y cerrada")] Cerrada = 6
        }

    }
}
