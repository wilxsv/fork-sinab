
Public Enum eESTADOPROCESOSCOMPRAS
    PROCESODECOMPRAINICIADO = 1
    BASEGENERADA = 2
    BASEPUBLICADA = 3
    APERTURADEOFERTA = 4
    CONSOLIDACIONDEOFERTAS = 5
    EXAMENPRELIMINAR = 6
    EXAMENPRELIMINARFINALIZADO = 7
    COMISIONDEEVALUACIONINGRESADA = 8
    GENERARRECOMENDACIONDECOMPRA = 9
    ESPERARRECURSOSDEREVISION = 10
    PROCESODECOMPRAANULADO = 11
    GENERARRESOLUCIONDEADJUDICACION = 12
    COMISIONDEALTONIVELINGRESADA = 13
    RESOLUCIONDEADJUDICACIONGENERADA = 14
    GENERARCONTRATOS = 15
    DISTRIBUIRCONTRATOS = 16
    CONTRATOSDISTRIBUIDOS = 17
    RECEPCIONOFERTAS = 18
    INCUMPLIRRECEPCIONES = 19
End Enum

Public Enum eESTADOCALIFICACION
    NOCALIFICADO = 1
    CALIFICADO = 2
    NOREQUIERECALIFICACION = 3
    RECOMENDADO = 4
    NORECOMENDADO = 5
    ADJUDICADO = 6
    NOADJUDICADO = 7
    DESIERTO = 8
End Enum

Public Enum eTIPOINFORME
    ACEPTACION = 1
    RECHAZO = 2
    NOINSPECCION = 3
End Enum

Public Enum eTIPOPLANTILLA
    RECOMENDACION = 1
    ADJUDICACION = 2
    ADJUDICACIONFIRME = 3
End Enum



Public Enum eTIPODOCUMENTOREFERENCIAS
    Requisicion = 1
    Vale_salida = 2
    Recibo_de_productos = 3
    Contrato = 4
    Inventario_Fisico = 5
    Consumo_SIM = 6
End Enum

Public Enum eESTADOSMOVIMIENTOS
    Grabado = 1
    Cerrado = 2
    Anulado = 3
    EnviadoAlmacen = 4
    En_proceso = 5
    Despachado = 6
    Enviado_a_la_unidad = 7
End Enum

Public Enum eESTADOSSOLICITUD
    Grabada = 1
    EnviadaUACI = 2
    RechazadaUACI = 3
    RechazadaUFI = 4
    EnviadaUFI = 5
    AprobadaUFI = 6
End Enum

Public Enum eAGRUPAR
    Fecha = 1
    Grupo = 2
    Producto = 3
End Enum

Public Enum eTIPOESTABLECIMIENTOS
    UnidadSalud = 1
    SIBASI = 2
    Hospital = 3
    CasaDeSalud = 4
    CentroRuralDeNutricion = 5
    ClinicaDeEmpleados = 6
    SecretariaDeEstadoMSPAS = 7
    HospitalesDe3erNivel = 8
    EstablecimientosEspeciales = 9
    Region = 10
End Enum
Public Enum eTIPOTRANSACCION
    RequisicionProductos = 1
    Salida = 2
    DEVOLUCION_PRODUCTOS = 3
    ActualizacionExistenciaMas = 4
    ActualizacionExistenciaMenos = 5
    ActualizarExistenciaNoDisponible = 6
    EXISTENCIA_INICIAL = 7
    RecepcionProductos = 8
    AjusteInventarioMas = 9
    AjusteInventarioMenos = 10
    InformeNoAceptacion = 11
    RecepcionInterna = 12
    CONSUMO_SIM = 13
    CargaExistenciaInicial = 14
    ActualizacionLote = 15
    RecepcionPorTransferencia = 16
    RecepcionPorDevolucion = 17
End Enum