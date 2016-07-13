
Public Class REGISTROGARANTIAS
    Inherits entidadBase

#Region " Propiedades "

    Private _IDGARANTIA As Int32
    Public Property IDGARANTIA() As Int32
        Get
            Return _IDGARANTIA
        End Get
        Set(ByVal value As Int32)
            _IDGARANTIA = value
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

    Private _IDTIPOGARANTIA As Int32
    Public Property IDTIPOGARANTIA() As Int32
        Get
            Return _IDTIPOGARANTIA
        End Get
        Set(ByVal value As Int32)
            _IDTIPOGARANTIA = value
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

    Private _IDTIPODOCUMENTO As Int32
    Public Property IDTIPODOCUMENTO() As Int32
        Get
            Return _IDTIPODOCUMENTO
        End Get
        Set(ByVal value As Int32)
            _IDTIPODOCUMENTO = value
        End Set
    End Property

    Private _IDMODALIDADCOMPRA As Int32
    Public Property IDMODALIDADCOMPRA() As Int32
        Get
            Return _IDMODALIDADCOMPRA
        End Get
        Set(ByVal value As Int32)
            _IDMODALIDADCOMPRA = value
        End Set
    End Property

    Private _NUMPROCESO As String
    Public Property NUMPROCESO() As String
        Get
            Return _NUMPROCESO
        End Get
        Set(ByVal value As String)
            _NUMPROCESO = value
        End Set
    End Property

    Private _NUMCONTRATO As String
    Public Property NUMCONTRATO() As String
        Get
            Return _NUMCONTRATO
        End Get
        Set(ByVal value As String)
            _NUMCONTRATO = value
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

    Private _IDENTIDAD As Int32
    Public Property IDENTIDAD() As Int32
        Get
            Return _IDENTIDAD
        End Get
        Set(ByVal value As Int32)
            _IDENTIDAD = value
        End Set
    End Property

    Private _NUMGARANTIA As String
    Public Property NUMGARANTIA() As String
        Get
            Return _NUMGARANTIA
        End Get
        Set(ByVal value As String)
            _NUMGARANTIA = value
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

    Private _FECHAEMISION As DateTime
    Public Property FECHAEMISION() As DateTime
        Get
            Return _FECHAEMISION
        End Get
        Set(ByVal value As DateTime)
            _FECHAEMISION = value
        End Set
    End Property

    Private _TOTALDIAS As Int32
    Public Property TOTALDIAS() As Int32
        Get
            Return _TOTALDIAS
        End Get
        Set(ByVal value As Int32)
            _TOTALDIAS = value
        End Set
    End Property

    Private _FECHAVTO As DateTime
    Public Property FECHAVTO() As DateTime
        Get
            Return _FECHAVTO
        End Get
        Set(ByVal value As DateTime)
            _FECHAVTO = value
        End Set
    End Property

    Private _FECHASOLDEVGTIA As DateTime
    Public Property FECHASOLDEVGTIA() As DateTime
        Get
            Return _FECHASOLDEVGTIA
        End Get
        Set(ByVal value As DateTime)
            _FECHASOLDEVGTIA = value
        End Set
    End Property

    Private _FECHARESFIRME As DateTime
    Public Property FECHARESFIRME() As DateTime
        Get
            Return _FECHARESFIRME
        End Get
        Set(ByVal value As DateTime)
            _FECHARESFIRME = value
        End Set
    End Property

    Private _FECHADEVGTIA As DateTime
    Public Property FECHADEVGTIA() As DateTime
        Get
            Return _FECHADEVGTIA
        End Get
        Set(ByVal value As DateTime)
            _FECHADEVGTIA = value
        End Set
    End Property

    Private _FECHAEFEGTIA As DateTime
    Public Property FECHAEFEGTIA() As DateTime
        Get
            Return _FECHAEFEGTIA
        End Get
        Set(ByVal value As DateTime)
            _FECHAEFEGTIA = value
        End Set
    End Property

    Private _FECHAAPRPLANUTIANT As DateTime
    Public Property FECHAAPRPLANUTIANT() As DateTime
        Get
            Return _FECHAAPRPLANUTIANT
        End Get
        Set(ByVal value As DateTime)
            _FECHAAPRPLANUTIANT = value
        End Set
    End Property

    Private _FECHAUTIPLANAVFI As DateTime
    Public Property FECHAUTIPLANAVFI() As DateTime
        Get
            Return _FECHAUTIPLANAVFI
        End Get
        Set(ByVal value As DateTime)
            _FECHAUTIPLANAVFI = value
        End Set
    End Property

    Private _FECHAACEPGTIACUMCON As DateTime
    Public Property FECHAACEPGTIACUMCON() As DateTime
        Get
            Return _FECHAACEPGTIACUMCON
        End Get
        Set(ByVal value As DateTime)
            _FECHAACEPGTIACUMCON = value
        End Set
    End Property

    Private _FECHAACEPGTIA As DateTime
    Public Property FECHAACEPGTIA() As DateTime
        Get
            Return _FECHAACEPGTIA
        End Get
        Set(ByVal value As DateTime)
            _FECHAACEPGTIA = value
        End Set
    End Property

    Private _FECHAENVIOUFI As DateTime
    Public Property FECHAENVIOUFI() As DateTime
        Get
            Return _FECHAENVIOUFI
        End Get
        Set(ByVal value As DateTime)
            _FECHAENVIOUFI = value
        End Set
    End Property

    Private _FECHARECUFI As DateTime
    Public Property FECHARECUFI() As DateTime
        Get
            Return _FECHARECUFI
        End Get
        Set(ByVal value As DateTime)
            _FECHARECUFI = value
        End Set
    End Property

    Private _FECHAEJEANT As DateTime
    Public Property FECHAEJEANT() As DateTime
        Get
            Return _FECHAEJEANT
        End Get
        Set(ByVal value As DateTime)
            _FECHAEJEANT = value
        End Set
    End Property

    Private _FECHAACGTIABVEOB As DateTime
    Public Property FECHAACGTIABVEOB() As DateTime
        Get
            Return _FECHAACGTIABVEOB
        End Get
        Set(ByVal value As DateTime)
            _FECHAACGTIABVEOB = value
        End Set
    End Property

    Private _FECHAACEPFIABUECAL As DateTime
    Public Property FECHAACEPFIABUECAL() As DateTime
        Get
            Return _FECHAACEPFIABUECAL
        End Get
        Set(ByVal value As DateTime)
            _FECHAACEPFIABUECAL = value
        End Set
    End Property

    Private _FECHAACTAREL As DateTime
    Public Property FECHAACTAREL() As DateTime
        Get
            Return _FECHAACTAREL
        End Get
        Set(ByVal value As DateTime)
            _FECHAACTAREL = value
        End Set
    End Property

    Private _FECHALIQUIDACION As DateTime
    Public Property FECHALIQUIDACION() As DateTime
        Get
            Return _FECHALIQUIDACION
        End Get
        Set(ByVal value As DateTime)
            _FECHALIQUIDACION = value
        End Set
    End Property

    Private _FECHARECBOS As DateTime
    Public Property FECHARECBOS() As DateTime
        Get
            Return _FECHARECBOS
        End Get
        Set(ByVal value As DateTime)
            _FECHARECBOS = value
        End Set
    End Property

    Private _IDFECHA As Int32
    Public Property IDFECHA() As Int32
        Get
            Return _IDFECHA
        End Get
        Set(ByVal value As Int32)
            _IDFECHA = value
        End Set
    End Property

    Private _IDCAUSAL As Int32
    Public Property IDCAUSAL() As Int32
        Get
            Return _IDCAUSAL
        End Get
        Set(ByVal value As Int32)
            _IDCAUSAL = value
        End Set
    End Property

    Private _OBSERVACIONES As String
    Public Property OBSERVACIONES() As String
        Get
            Return _OBSERVACIONES
        End Get
        Set(ByVal value As String)
            _OBSERVACIONES = value
        End Set
    End Property

    Private _USUARIO As String
    Public Property USUARIO() As String
        Get
            Return _USUARIO
        End Get
        Set(ByVal value As String)
            _USUARIO = value
        End Set
    End Property

    Private _FECHA As DateTime
    Public Property FECHA() As DateTime
        Get
            Return _FECHA
        End Get
        Set(ByVal value As DateTime)
            _FECHA = value
        End Set
    End Property
    Private _VALORCUANTIA As Decimal
    Public Property VALORCUANTIA() As Decimal
        Get
            Return _VALORCUANTIA
        End Get
        Set(ByVal value As Decimal)
            _VALORCUANTIA = value
        End Set
    End Property
#End Region

End Class
