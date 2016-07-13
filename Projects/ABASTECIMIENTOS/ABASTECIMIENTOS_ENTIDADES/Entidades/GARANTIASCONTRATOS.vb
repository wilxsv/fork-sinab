''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.GARANTIASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSGARANTIASCONTRATOS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	10/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class GARANTIASCONTRATOS
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

    Private _IDCONTRATO As Int64
    Public Property IDCONTRATO() As Int64
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Int64)
            _IDCONTRATO = value
        End Set
    End Property

    Private _IDTIPOGARANTIA As Int16
    Public Property IDTIPOGARANTIA() As Int16
        Get
            Return _IDTIPOGARANTIA
        End Get
        Set(ByVal value As Int16)
            _IDTIPOGARANTIA = value
        End Set
    End Property

    Private _IDGARANTIACONTRATO As Int32
    Public Property IDGARANTIACONTRATO() As Int32
        Get
            Return _IDGARANTIACONTRATO
        End Get
        Set(ByVal value As Int32)
            _IDGARANTIACONTRATO = value
        End Set
    End Property

    Private _IDMODIFICATIVA As Int64
    Public Property IDMODIFICATIVA() As Int64
        Get
            Return _IDMODIFICATIVA
        End Get
        Set(ByVal value As Int64)
            _IDMODIFICATIVA = value
        End Set
    End Property

    Private _NUMEROGARANTIA As String
    Public Property NUMEROGARANTIA() As String
        Get
            Return _NUMEROGARANTIA
        End Get
        Set(ByVal value As String)
            _NUMEROGARANTIA = value
        End Set
    End Property

    Private _IDESTADOGARANTIA As Int16
    Public Property IDESTADOGARANTIA() As Int16
        Get
            Return _IDESTADOGARANTIA
        End Get
        Set(ByVal value As Int16)
            _IDESTADOGARANTIA = value
        End Set
    End Property

    Private _FECHAENTREGA As DateTime
    Public Property FECHAENTREGA() As DateTime
        Get
            Return _FECHAENTREGA
        End Get
        Set(ByVal value As DateTime)
            _FECHAENTREGA = value
        End Set
    End Property

    Private _FECHARECEPCION As DateTime
    Public Property FECHARECEPCION() As DateTime
        Get
            Return _FECHARECEPCION
        End Get
        Set(ByVal value As DateTime)
            _FECHARECEPCION = value
        End Set
    End Property

    Private _MONTO As Decimal
    Public Property MONTO() As Decimal
        Get
            Return _MONTO
        End Get
        Set(ByVal value As Decimal)
            _MONTO = value
        End Set
    End Property

    Private _VIGENCIA As Int16
    Public Property VIGENCIA() As Int16
        Get
            Return _VIGENCIA
        End Get
        Set(ByVal value As Int16)
            _VIGENCIA = value
        End Set
    End Property

    Private _FECHAVENCIMIENTO As DateTime
    Public Property FECHAVENCIMIENTO() As DateTime
        Get
            Return _FECHAVENCIMIENTO
        End Get
        Set(ByVal value As DateTime)
            _FECHAVENCIMIENTO = value
        End Set
    End Property

    Private _ASEGURADORA As String
    Public Property ASEGURADORA() As String
        Get
            Return _ASEGURADORA
        End Get
        Set(ByVal value As String)
            _ASEGURADORA = value
        End Set
    End Property

    Private _FECHAEFECTIVA As DateTime
    Public Property FECHAEFECTIVA() As DateTime
        Get
            Return _FECHAEFECTIVA
        End Get
        Set(ByVal value As DateTime)
            _FECHAEFECTIVA = value
        End Set
    End Property

    Private _JUSTIFICACIONEFECTIVA As String
    Public Property JUSTIFICACIONEFECTIVA() As String
        Get
            Return _JUSTIFICACIONEFECTIVA
        End Get
        Set(ByVal value As String)
            _JUSTIFICACIONEFECTIVA = value
        End Set
    End Property

    Private _FECHADEVOLUCION As DateTime
    Public Property FECHADEVOLUCION() As DateTime
        Get
            Return _FECHADEVOLUCION
        End Get
        Set(ByVal value As DateTime)
            _FECHADEVOLUCION = value
        End Set
    End Property

    Private _JUSTIFICACIONDEVOLUCION As String
    Public Property JUSTIFICACIONDEVOLUCION() As String
        Get
            Return _JUSTIFICACIONDEVOLUCION
        End Get
        Set(ByVal value As String)
            _JUSTIFICACIONDEVOLUCION = value
        End Set
    End Property

    Private _CLASEGARANTIA As String
    Public Property CLASEGARANTIA() As String
        Get
            Return _CLASEGARANTIA
        End Get
        Set(ByVal value As String)
            _CLASEGARANTIA = value
        End Set
    End Property

    Private _PORCENTAJE As Decimal
    Public Property PORCENTAJE() As Decimal
        Get
            Return _PORCENTAJE
        End Get
        Set(ByVal value As Decimal)
            _PORCENTAJE = value
        End Set
    End Property

    Private _ENTREGA As Int16
    Public Property ENTREGA() As Int16
        Get
            Return _ENTREGA
        End Get
        Set(ByVal value As Int16)
            _ENTREGA = value
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

#End Region

End Class

