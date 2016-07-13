Public Class INCUMPLIMIENTOCONTRATO

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

    Private _IDNOTA As Int32
    Public Property IDNOTA() As Int32
        Get
            Return _IDNOTA
        End Get
        Set(ByVal value As Int32)
            _IDNOTA = value
        End Set
    End Property

    Private _NOMBREDIRIGIDO As String
    Public Property NOMBREDIRIGIDO() As String
        Get
            Return _NOMBREDIRIGIDO
        End Get
        Set(ByVal value As String)
            _NOMBREDIRIGIDO = value
        End Set
    End Property

    Private _CARGODIRIGIDO As String
    Public Property CARGODIRIGIDO() As String
        Get
            Return _CARGODIRIGIDO
        End Get
        Set(ByVal value As String)
            _CARGODIRIGIDO = value
        End Set
    End Property

    Private _NOMBREENVIA As String
    Public Property NOMBREENVIA() As String
        Get
            Return _NOMBREENVIA
        End Get
        Set(ByVal value As String)
            _NOMBREENVIA = value
        End Set
    End Property
    Private _CARGOENVIA As String
    Public Property CARGOENVIA() As String
        Get
            Return _CARGOENVIA
        End Get
        Set(ByVal value As String)
            _CARGOENVIA = value
        End Set
    End Property

    Private _TITULONOTA As String
    Public Property TITULONOTA() As String
        Get
            Return _TITULONOTA
        End Get
        Set(ByVal value As String)
            _TITULONOTA = value
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

    Private _IDRENGLON As Int32
    Public Property IDRENGLON() As Int32
        Get
            Return _IDRENGLON
        End Get
        Set(ByVal value As Int32)
            _IDRENGLON = value
        End Set
    End Property

    Private _IDPROCESO As Int32
    Public Property IDPROCESO() As Int32
        Get
            Return _IDPROCESO
        End Get
        Set(ByVal value As Int32)
            _IDPROCESO = value
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

    Private _TIPOLICITACION As String
    Public Property TIPOLICITACION() As String
        Get
            Return _TIPOLICITACION
        End Get
        Set(ByVal value As String)
            _TIPOLICITACION = value
        End Set
    End Property

    Private _MONTOCONTRATO As Double
    Public Property MONTOCONTRATO() As Double
        Get
            Return _MONTOCONTRATO
        End Get
        Set(ByVal value As Double)
            _MONTOCONTRATO = value
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

    Private _DESCRIPCIONLICITACION As String
    Public Property DESCRIPCIONLICITACION() As String
        Get
            Return _DESCRIPCIONLICITACION
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONLICITACION = value
        End Set
    End Property

    Private _PROVEEDOR As String
    Public Property PROVEEDOR() As String
        Get
            Return _PROVEEDOR
        End Get
        Set(ByVal value As String)
            _PROVEEDOR = value
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

    Private _ALMACEN As String
    Public Property ALMACEN() As String
        Get
            Return _ALMACEN
        End Get
        Set(ByVal value As String)
            _ALMACEN = value
        End Set
    End Property

    Private _CANTIDADNOENTREGADA As Decimal
    Public Property CANTIDADNOENTREGADA() As Decimal
        Get
            Return _CANTIDADNOENTREGADA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADNOENTREGADA = value
        End Set
    End Property

    Private _CANTIDADCONATRASO As Decimal
    Public Property CANTIDADCONATRASO() As Decimal
        Get
            Return _CANTIDADCONATRASO
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADCONATRASO = value
        End Set
    End Property

    Private _DIASATRASO As Int16
    Public Property DIASATRASO() As Int16
        Get
            Return _DIASATRASO
        End Get
        Set(ByVal value As Int16)
            _DIASATRASO = value
        End Set
    End Property

    Private _IDPRODUCTO As Int32
    Public Property IDPRODUCTO() As Int32
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Int32)
            _IDPRODUCTO = value
        End Set
    End Property

    Private _CODIGOPRODUCTO As String
    Public Property CODIGOPRODUCTO() As String
        Get
            Return _CODIGOPRODUCTO
        End Get
        Set(ByVal value As String)
            _CODIGOPRODUCTO = value
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

    Private _EXPIRA As DateTime
    Public Property EXPIRA() As DateTime
        Get
            Return _EXPIRA
        End Get
        Set(ByVal value As DateTime)
            _EXPIRA = value
        End Set
    End Property

    Private _PRECIO As Double
    Public Property PRECIO() As Double
        Get
            Return _PRECIO
        End Get
        Set(ByVal value As Double)
            _PRECIO = value
        End Set
    End Property

    Private _MONTONOENTREGADO As Double
    Public Property MONTONOENTREGADO() As Double
        Get
            Return _MONTONOENTREGADO
        End Get
        Set(ByVal value As Double)
            _MONTONOENTREGADO = value
        End Set
    End Property

    Private _MONTOCONATRASO As Double
    Public Property MONTOCONATRASO() As Double
        Get
            Return _MONTOCONATRASO
        End Get
        Set(ByVal value As Double)
            _MONTOCONATRASO = value
        End Set
    End Property

End Class
