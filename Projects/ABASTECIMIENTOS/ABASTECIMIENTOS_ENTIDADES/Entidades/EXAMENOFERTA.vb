''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.EXAMENOFERTA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSEXAMENOFERTA en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	28/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class EXAMENOFERTA
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

    Private _IDPROCESOCOMPRA As Int64
    Public Property IDPROCESOCOMPRA() As Int64
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Int64)
            _IDPROCESOCOMPRA = value
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

    Private _INDICESOLVENCIA As Decimal
    Public Property INDICESOLVENCIA() As Decimal
        Get
            Return _INDICESOLVENCIA
        End Get
        Set(ByVal value As Decimal)
            _INDICESOLVENCIA = value
        End Set
    End Property

    Private _PONDERACIONSOLVENCIA As Decimal
    Public Property PONDERACIONSOLVENCIA() As Decimal
        Get
            Return _PONDERACIONSOLVENCIA
        End Get
        Set(ByVal value As Decimal)
            _PONDERACIONSOLVENCIA = value
        End Set
    End Property

    Private _CAPITALTRABAJO As Decimal
    Public Property CAPITALTRABAJO() As Decimal
        Get
            Return _CAPITALTRABAJO
        End Get
        Set(ByVal value As Decimal)
            _CAPITALTRABAJO = value
        End Set
    End Property

    Private _PONDERACIONCAPITAL As Decimal
    Public Property PONDERACIONCAPITAL() As Decimal
        Get
            Return _PONDERACIONCAPITAL
        End Get
        Set(ByVal value As Decimal)
            _PONDERACIONCAPITAL = value
        End Set
    End Property

    Private _INDICEENDEUDAMIENTO As Decimal
    Public Property INDICEENDEUDAMIENTO() As Decimal
        Get
            Return _INDICEENDEUDAMIENTO
        End Get
        Set(ByVal value As Decimal)
            _INDICEENDEUDAMIENTO = value
        End Set
    End Property

    Private _PONDERACIONENDEUDAMIENTO As Decimal
    Public Property PONDERACIONENDEUDAMIENTO() As Decimal
        Get
            Return _PONDERACIONENDEUDAMIENTO
        End Get
        Set(ByVal value As Decimal)
            _PONDERACIONENDEUDAMIENTO = value
        End Set
    End Property

    Private _REFERENCIABANCARIA As Byte
    Public Property REFERENCIABANCARIA() As Byte
        Get
            Return _REFERENCIABANCARIA
        End Get
        Set(ByVal value As Byte)
            _REFERENCIABANCARIA = value
        End Set
    End Property

    Private _PONDERACIONREFERENCIA As Decimal
    Public Property PONDERACIONREFERENCIA() As Decimal
        Get
            Return _PONDERACIONREFERENCIA
        End Get
        Set(ByVal value As Decimal)
            _PONDERACIONREFERENCIA = value
        End Set
    End Property

    Private _OBSERVACION As String
    Public Property OBSERVACION() As String
        Get
            Return _OBSERVACION
        End Get
        Set(ByVal value As String)
            _OBSERVACION = value
        End Set
    End Property

    Private _NUMEROEXAMEN As Byte
    Public Property NUMEROEXAMEN() As Byte
        Get
            Return _NUMEROEXAMEN
        End Get
        Set(ByVal value As Byte)
            _NUMEROEXAMEN = value
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
