Public Class HISTORICONOTIFICACION
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

    Private _IDINFORME As Int32
    Public Property IDINFORME() As Int32
        Get
            Return _IDINFORME
        End Get
        Set(ByVal value As Int32)
            _IDINFORME = value
        End Set
    End Property

    Private _NOMBRECOMERCIAL As String
    Public Property NOMBRECOMERCIAL() As String
        Get
            Return _NOMBRECOMERCIAL
        End Get
        Set(ByVal value As String)
            _NOMBRECOMERCIAL = value
        End Set
    End Property
    Private _LABORATORIOFABRICANTE As String
    Public Property LABORATORIOFABRICANTE() As String
        Get
            Return _LABORATORIOFABRICANTE
        End Get
        Set(ByVal value As String)
            _LABORATORIOFABRICANTE = value
        End Set
    End Property
    Private _LOTE As String
    Public Property LOTE() As String
        Get
            Return _LOTE
        End Get
        Set(ByVal value As String)
            _LOTE = value
        End Set
    End Property
    Private _NUMEROUNIDADES As Decimal
    Public Property NUMEROUNIDADES() As Decimal
        Get
            Return _NUMEROUNIDADES
        End Get
        Set(ByVal value As Decimal)
            _NUMEROUNIDADES = value
        End Set
    End Property
    Private _FECHAFABRICACION As DateTime
    Public Property FECHAFABRICACION() As DateTime
        Get
            Return _FECHAFABRICACION
        End Get
        Set(ByVal value As DateTime)
            _FECHAFABRICACION = value
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
    Private _CANTIDADAENTREGAR As Decimal
    Public Property CANTIDADAENTREGAR() As Decimal
        Get
            Return _CANTIDADAENTREGAR
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADAENTREGAR = value
        End Set
    End Property
#End Region

End Class
