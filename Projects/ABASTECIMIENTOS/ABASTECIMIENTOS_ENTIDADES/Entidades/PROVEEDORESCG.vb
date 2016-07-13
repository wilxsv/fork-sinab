
Public Class PROVEEDORESCG
    Inherits entidadBase

#Region " Propiedades "

    Private _IDPROVEEDOR As Int32
    Public Property IDPROVEEDOR() As Int32
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Int32)
            _IDPROVEEDOR = value
        End Set
    End Property

    Private _NOMBRE As String
    Public Property NOMBRE() As String
        Get
            Return _NOMBRE
        End Get
        Set(ByVal value As String)
            _NOMBRE = value
        End Set
    End Property

    Private _NIT As String
    Public Property NIT() As String
        Get
            Return _NIT
        End Get
        Set(ByVal value As String)
            _NIT = value
        End Set
    End Property

    Private _IDESTABLECIMIENTO As Int32
    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTO = value
        End Set
    End Property

    Private _NOMBREABR As String
    Public Property NOMBREABR() As String
        Get
            Return _NOMBREABR
        End Get
        Set(ByVal value As String)
            _NOMBREABR = value
        End Set
    End Property
#End Region

End Class
