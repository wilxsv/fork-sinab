''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.NOTASACEPTACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSNOTASACEPTACION en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	24/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class NOTASACEPTACION
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

    Private _FECHARECEPCION As DateTime
    Public Property FECHARECEPCION() As DateTime
        Get
            Return _FECHARECEPCION
        End Get
        Set(ByVal value As DateTime)
            _FECHARECEPCION = value
        End Set
    End Property

    Private _NOMBREPERSONAFIRMA As String
    Public Property NOMBREPERSONAFIRMA() As String
        Get
            Return _NOMBREPERSONAFIRMA
        End Get
        Set(ByVal value As String)
            _NOMBREPERSONAFIRMA = value
        End Set
    End Property

    Private _DUIPERSONAFIRMA As String
    Public Property DUIPERSONAFIRMA() As String
        Get
            Return _DUIPERSONAFIRMA
        End Get
        Set(ByVal value As String)
            _DUIPERSONAFIRMA = value
        End Set
    End Property

    Private _AFPCONFIARECEPCION As DateTime
    Public Property AFPCONFIARECEPCION() As DateTime
        Get
            Return _AFPCONFIARECEPCION
        End Get
        Set(ByVal value As DateTime)
            _AFPCONFIARECEPCION = value
        End Set
    End Property

    Private _AFPCONFIAVIGENCIA As DateTime
    Public Property AFPCONFIAVIGENCIA() As DateTime
        Get
            Return _AFPCONFIAVIGENCIA
        End Get
        Set(ByVal value As DateTime)
            _AFPCONFIAVIGENCIA = value
        End Set
    End Property

    Private _AFPCRECERRECEPCION As DateTime
    Public Property AFPCRECERRECEPCION() As DateTime
        Get
            Return _AFPCRECERRECEPCION
        End Get
        Set(ByVal value As DateTime)
            _AFPCRECERRECEPCION = value
        End Set
    End Property

    Private _AFPCRECERVIGENCIA As DateTime
    Public Property AFPCRECERVIGENCIA() As DateTime
        Get
            Return _AFPCRECERVIGENCIA
        End Get
        Set(ByVal value As DateTime)
            _AFPCRECERVIGENCIA = value
        End Set
    End Property

    Private _IPFARECEPCION As DateTime
    Public Property IPFARECEPCION() As DateTime
        Get
            Return _IPFARECEPCION
        End Get
        Set(ByVal value As DateTime)
            _IPFARECEPCION = value
        End Set
    End Property

    Private _IPFAVIGENCIA As DateTime
    Public Property IPFAVIGENCIA() As DateTime
        Get
            Return _IPFAVIGENCIA
        End Get
        Set(ByVal value As DateTime)
            _IPFAVIGENCIA = value
        End Set
    End Property

    Private _SSRECEPCION As DateTime
    Public Property SSRECEPCION() As DateTime
        Get
            Return _SSRECEPCION
        End Get
        Set(ByVal value As DateTime)
            _SSRECEPCION = value
        End Set
    End Property

    Private _SSVIGENCIA As DateTime
    Public Property SSVIGENCIA() As DateTime
        Get
            Return _SSVIGENCIA
        End Get
        Set(ByVal value As DateTime)
            _SSVIGENCIA = value
        End Set
    End Property

    Private _ISSSRECEPCION As DateTime
    Public Property ISSSRECEPCION() As DateTime
        Get
            Return _ISSSRECEPCION
        End Get
        Set(ByVal value As DateTime)
            _ISSSRECEPCION = value
        End Set
    End Property

    Private _ISSSVIGENCIA As DateTime
    Public Property ISSSVIGENCIA() As DateTime
        Get
            Return _ISSSVIGENCIA
        End Get
        Set(ByVal value As DateTime)
            _ISSSVIGENCIA = value
        End Set
    End Property

    Private _IMPUESTOSRECEPCION As DateTime
    Public Property IMPUESTOSRECEPCION() As DateTime
        Get
            Return _IMPUESTOSRECEPCION
        End Get
        Set(ByVal value As DateTime)
            _IMPUESTOSRECEPCION = value
        End Set
    End Property

    Private _IMPUESTOSVIGENCIA As DateTime
    Public Property IMPUESTOSVIGENCIA() As DateTime
        Get
            Return _IMPUESTOSVIGENCIA
        End Get
        Set(ByVal value As DateTime)
            _IMPUESTOSVIGENCIA = value
        End Set
    End Property

    Private _ALCALDIARECEPCION As DateTime
    Public Property ALCALDIARECEPCION() As DateTime
        Get
            Return _ALCALDIARECEPCION
        End Get
        Set(ByVal value As DateTime)
            _ALCALDIARECEPCION = value
        End Set
    End Property

    Private _ALCALDIAVIGENCIA As DateTime
    Public Property ALCALDIAVIGENCIA() As DateTime
        Get
            Return _ALCALDIAVIGENCIA
        End Get
        Set(ByVal value As DateTime)
            _ALCALDIAVIGENCIA = value
        End Set
    End Property

    Private _PRESENTANOTA As Byte
    Public Property PRESENTANOTA() As Byte
        Get
            Return _PRESENTANOTA
        End Get
        Set(ByVal value As Byte)
            _PRESENTANOTA = value
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
