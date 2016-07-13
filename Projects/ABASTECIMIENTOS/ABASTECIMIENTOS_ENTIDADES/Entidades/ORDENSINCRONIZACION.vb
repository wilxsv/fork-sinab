''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.ORDENSINCRONIZACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSORDENSINCRONIZACION en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class ORDENSINCRONIZACION
    Inherits entidadBase

#Region " Propiedades "

    Private _ORDEN As Int16
    Public Property ORDEN() As Int16
        Get
            Return _ORDEN
        End Get
        Set(ByVal value As Int16)
            _ORDEN = value
        End Set
    End Property

    Private _TABLA As String
    Public Property TABLA() As String
        Get
            Return _TABLA
        End Get
        Set(ByVal value As String)
            _TABLA = value
        End Set
    End Property

    Private _HABILITADA As Byte
    Public Property HABILITADA() As Byte
        Get
            Return _HABILITADA
        End Get
        Set(ByVal value As Byte)
            _HABILITADA = value
        End Set
    End Property

#End Region

End Class
