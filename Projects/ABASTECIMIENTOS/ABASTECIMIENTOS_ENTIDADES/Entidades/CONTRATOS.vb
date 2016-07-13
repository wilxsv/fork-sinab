''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.CONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSCONTRATOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class CONTRATOS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDESTABLECIMIENTO As Int32
    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTO = value
        End Set
    End Property

    Private _IDPROVEEDOR As Int32
    Public Property IDPROVEEDOR() As Int32
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Int32)
            _IDPROVEEDOR = value
        End Set
    End Property

    Private _NOMBREPROVEEDOR As String
    Public Property NOMBREPROVEEDOR() As String
        Get
            Return _NOMBREPROVEEDOR
        End Get
        Set(ByVal value As String)
            _NOMBREPROVEEDOR = value
        End Set
    End Property

    Private _IDCONTRATO As Int64
    Public Property IDCONTRATO() As Int64
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Int64)
            _IDCONTRATO = value
        End Set
    End Property

    Private _NUMEROCONTRATO As String
    Public Property NUMEROCONTRATO() As String
        Get
            Return _NUMEROCONTRATO
        End Get
        Set(ByVal value As String)
            _NUMEROCONTRATO = value
        End Set
    End Property

    Private _IDTIPODOCUMENTO As Int16
    Public Property IDTIPODOCUMENTO() As Int16
        Get
            Return _IDTIPODOCUMENTO
        End Get
        Set(ByVal value As Int16)
            _IDTIPODOCUMENTO = value
        End Set
    End Property

    Private _IDPLANTILLA As Int32
    Public Property IDPLANTILLA() As Int32
        Get
            Return _IDPLANTILLA
        End Get
        Set(ByVal value As Int32)
            _IDPLANTILLA = value
        End Set
    End Property

    Private _TIPOPERSONA As String
    Public Property TIPOPERSONA() As String
        Get
            Return _TIPOPERSONA
        End Get
        Set(ByVal value As String)
            _TIPOPERSONA = value
        End Set
    End Property

    Private _REPRESENTANTELEGAL As String
    Public Property REPRESENTANTELEGAL() As String
        Get
            Return _REPRESENTANTELEGAL
        End Get
        Set(ByVal value As String)
            _REPRESENTANTELEGAL = value
        End Set
    End Property

    Private _PERSONERIAJURIDICA As String
    Public Property PERSONERIAJURIDICA() As String
        Get
            Return _PERSONERIAJURIDICA
        End Get
        Set(ByVal value As String)
            _PERSONERIAJURIDICA = value
        End Set
    End Property

    Private _FECHAGENERACION As DateTime
    Public Property FECHAGENERACION() As DateTime
        Get
            Return _FECHAGENERACION
        End Get
        Set(ByVal value As DateTime)
            _FECHAGENERACION = value
        End Set
    End Property

    Private _FECHAAPROBACION As DateTime
    Public Property FECHAAPROBACION() As DateTime
        Get
            Return _FECHAAPROBACION
        End Get
        Set(ByVal value As DateTime)
            _FECHAAPROBACION = value
        End Set
    End Property

    Private _FECHADISTRIBUCION As DateTime
    Public Property FECHADISTRIBUCION() As DateTime
        Get
            Return _FECHADISTRIBUCION
        End Get
        Set(ByVal value As DateTime)
            _FECHADISTRIBUCION = value
        End Set
    End Property

    Private _CODIGOLICITACION As String
    Public Property CODIGOLICITACION() As String
        Get
            Return _CODIGOLICITACION
        End Get
        Set(ByVal value As String)
            _CODIGOLICITACION = value
        End Set
    End Property

    Private _FECHAINICIOENTREGA As DateTime
    Public Property FECHAINICIOENTREGA() As DateTime
        Get
            Return _FECHAINICIOENTREGA
        End Get
        Set(ByVal value As DateTime)
            _FECHAINICIOENTREGA = value
        End Set
    End Property

    Private _IDESTADOCONTRATO As Int16
    Public Property IDESTADOCONTRATO() As Int16
        Get
            Return _IDESTADOCONTRATO
        End Get
        Set(ByVal value As Int16)
            _IDESTADOCONTRATO = value
        End Set
    End Property

    Private _IDCALIFICACIONCUMPLIMIENTO As Int16
    Public Property IDCALIFICACIONCUMPLIMIENTO() As Int16
        Get
            Return _IDCALIFICACIONCUMPLIMIENTO
        End Get
        Set(ByVal value As Int16)
            _IDCALIFICACIONCUMPLIMIENTO = value
        End Set
    End Property

    Private _IDCALIFICACIONCALIDAD As Int16
    Public Property IDCALIFICACIONCALIDAD() As Int16
        Get
            Return _IDCALIFICACIONCALIDAD
        End Get
        Set(ByVal value As Int16)
            _IDCALIFICACIONCALIDAD = value
        End Set
    End Property

    Private _IDMODALIDADCOMPRA As Byte
    Public Property IDMODALIDADCOMPRA() As Byte
        Get
            Return _IDMODALIDADCOMPRA
        End Get
        Set(ByVal value As Byte)
            _IDMODALIDADCOMPRA = value
        End Set
    End Property

    Private _DESCRIPCIONMODALIDADCOMPRA As String
    Public Property DESCRIPCIONMODALIDADCOMPRA() As String
        Get
            Return _DESCRIPCIONMODALIDADCOMPRA
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONMODALIDADCOMPRA = value
        End Set
    End Property

    Private _NUMEROMODALIDADCOMPRA As String
    Public Property NUMEROMODALIDADCOMPRA() As String
        Get
            Return _NUMEROMODALIDADCOMPRA
        End Get
        Set(ByVal value As String)
            _NUMEROMODALIDADCOMPRA = value
        End Set
    End Property

    Private _FUENTESFINANCIAMIENTO As String
    Public Property FUENTESFINANCIAMIENTO() As String
        Get
            Return _FUENTESFINANCIAMIENTO
        End Get
        Set(ByVal value As String)
            _FUENTESFINANCIAMIENTO = value
        End Set
    End Property

    Private _RESPONSABLEDISTRIBUCION As String
    Public Property RESPONSABLEDISTRIBUCION() As String
        Get
            Return _RESPONSABLEDISTRIBUCION
        End Get
        Set(ByVal value As String)
            _RESPONSABLEDISTRIBUCION = value
        End Set
    End Property

    Private _RESOLUCIONADJUDICACION As String
    Public Property RESOLUCIONADJUDICACION() As String
        Get
            Return _RESOLUCIONADJUDICACION
        End Get
        Set(ByVal value As String)
            _RESOLUCIONADJUDICACION = value
        End Set
    End Property

    Private _MODIFICATIVASCONTRATO As String
    Public Property MODIFICATIVASCONTRATO() As String
        Get
            Return _MODIFICATIVASCONTRATO
        End Get
        Set(ByVal value As String)
            _MODIFICATIVASCONTRATO = value
        End Set
    End Property

    Private _TIPODOCUMENTO As String
    Public Property TIPODOCUMENTO() As String
        Get
            Return _TIPODOCUMENTO
        End Get
        Set(ByVal value As String)
            _TIPODOCUMENTO = value
        End Set
    End Property

    Private _MONTOCONTRATO As Decimal
    Public Property MONTOCONTRATO() As Decimal
        Get
            Return _MONTOCONTRATO
        End Get
        Set(ByVal value As Decimal)
            _MONTOCONTRATO = value
        End Set
    End Property

    Private _AUUSUARIOCREACION As String
    Public Property AUUSUARIOCREACION() As String
        Get
            Return _AUUSUARIOCREACION
        End Get
        Set(ByVal value As String)
            _AUUSUARIOCREACION = value
        End Set
    End Property

    Private _AUFECHACREACION As DateTime
    Public Property AUFECHACREACION() As DateTime
        Get
            Return _AUFECHACREACION
        End Get
        Set(ByVal value As DateTime)
            _AUFECHACREACION = value
        End Set
    End Property

    Private _AUUSUARIOMODIFICACION As String
    Public Property AUUSUARIOMODIFICACION() As String
        Get
            Return _AUUSUARIOMODIFICACION
        End Get
        Set(ByVal value As String)
            _AUUSUARIOMODIFICACION = value
        End Set
    End Property

    Private _AUFECHAMODIFICACION As DateTime
    Public Property AUFECHAMODIFICACION() As DateTime
        Get
            Return _AUFECHAMODIFICACION
        End Get
        Set(ByVal value As DateTime)
            _AUFECHAMODIFICACION = value
        End Set
    End Property

    Private _ESTASINCRONIZADA As Int16
    Public Property ESTASINCRONIZADA() As Int16
        Get
            Return _ESTASINCRONIZADA
        End Get
        Set(ByVal value As Int16)
            _ESTASINCRONIZADA = value
        End Set
    End Property

    Private _ACTANOTARIAL As String
    Public Property ACTANOTARIAL() As String
        Get
            Return _ACTANOTARIAL
        End Get
        Set(ByVal value As String)
            _ACTANOTARIAL = value
        End Set
    End Property

    Private _RESOLUCION As String
    Public Property RESOLUCION() As String
        Get
            Return _RESOLUCION
        End Get
        Set(ByVal value As String)
            _RESOLUCION = value
        End Set
    End Property

    Private _MODIFICATIVA As String
    Public Property MODIFICATIVA() As String
        Get
            Return _MODIFICATIVA
        End Get
        Set(ByVal value As String)
            _MODIFICATIVA = value
        End Set
    End Property

#End Region

End Class
