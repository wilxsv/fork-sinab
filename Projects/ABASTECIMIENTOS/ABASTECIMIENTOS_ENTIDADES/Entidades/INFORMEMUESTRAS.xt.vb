Partial Public Class INFORMEMUESTRAS

#Region " Propiedades Agregadas "

    Private _ESTABLECIMIENTOCONTRATO As String
    Public Property ESTABLECIMIENTOCONTRATO() As String
        Get
            Return _ESTABLECIMIENTOCONTRATO
        End Get
        Set(ByVal value As String)
            _ESTABLECIMIENTOCONTRATO = value
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

    Private _FECHADISTRIBUCION As DateTime
    Public Property FECHADISTRIBUCION() As DateTime
        Get
            Return _FECHADISTRIBUCION
        End Get
        Set(ByVal value As DateTime)
            _FECHADISTRIBUCION = value
        End Set
    End Property

    Private _CANTIDADCONTRATADA As Decimal
    Public Property CANTIDADCONTRATADA() As Decimal
        Get
            Return _CANTIDADCONTRATADA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADCONTRATADA = value
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

    Private _UNIDADMEDIDA As String
    Public Property UNIDADMEDIDA() As String
        Get
            Return _UNIDADMEDIDA
        End Get
        Set(ByVal value As String)
            _UNIDADMEDIDA = value
        End Set
    End Property

    Private _DESCRIPCIONCP As String
    Public Property DESCRIPCIONCP() As String
        Get
            Return _DESCRIPCIONCP
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONCP = value
        End Set
    End Property

    Private _DESCRIPCIONPROVEEDOR As String
    Public Property DESCRIPCIONPROVEEDOR() As String
        Get
            Return _DESCRIPCIONPROVEEDOR
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONPROVEEDOR = value
        End Set
    End Property

    Private _INSPECTOR As String
    Public Property INSPECTOR() As String
        Get
            Return _INSPECTOR
        End Get
        Set(ByVal value As String)
            _INSPECTOR = value
        End Set
    End Property

    Private _CODIGOINSPECTOR As String
    Public Property CODIGOINSPECTOR() As String
        Get
            Return _CODIGOINSPECTOR
        End Get
        Set(ByVal value As String)
            _CODIGOINSPECTOR = value
        End Set
    End Property

    Private _COORDINADOR As String
    Public Property COORDINADOR() As String
        Get
            Return _COORDINADOR
        End Get
        Set(ByVal value As String)
            _COORDINADOR = value
        End Set
    End Property

    Private _CODIGOCOORDINADOR As String
    Public Property CODIGOCOORDINADOR() As String
        Get
            Return _CODIGOCOORDINADOR
        End Get
        Set(ByVal value As String)
            _CODIGOCOORDINADOR = value
        End Set
    End Property

    Private _JEFELABORATORIO As String
    Public Property JEFELABORATORIO() As String
        Get
            Return _JEFELABORATORIO
        End Get
        Set(ByVal value As String)
            _JEFELABORATORIO = value
        End Set
    End Property

    Private _CODIGOJEFELABORATORIO As String
    Public Property CODIGOJEFELABORATORIO() As String
        Get
            Return _CODIGOJEFELABORATORIO
        End Get
        Set(ByVal value As String)
            _CODIGOJEFELABORATORIO = value
        End Set
    End Property

    Private _MODALIDADCOMPRA As String
    Public Property MODALIDADCOMPRA() As String
        Get
            Return _MODALIDADCOMPRA
        End Get
        Set(ByVal value As String)
            _MODALIDADCOMPRA = value
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

    Private _NUMERORESOLUCION As String
    Public Property NUMERORESOLUCION() As String
        Get
            Return _NUMERORESOLUCION
        End Get
        Set(ByVal value As String)
            _NUMERORESOLUCION = value
        End Set
    End Property
    Private _ORIGENPRODUCTO As Integer
    Public Property ORIGENPRODUCTO() As Integer
        Get
            Return _ORIGENPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _ORIGENPRODUCTO = value
        End Set
    End Property
    Private _TIPOPRODUCTO As Integer
    Public Property TIPOPRODUCTO() As Integer
        Get
            Return _TIPOPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _TIPOPRODUCTO = value
        End Set
    End Property
    Private _MOTIVONOACEPTACION As String
    Public Property MOTIVONOACEPTACION() As String
        Get
            Return _MOTIVONOACEPTACION
        End Get
        Set(ByVal value As String)
            _MOTIVONOACEPTACION = value
        End Set
    End Property
    Private _DESCRIPCIONDISOLUCION As String
    Public Property DESCRIPCIONDISOLUCION() As String
        Get
            Return _DESCRIPCIONDISOLUCION
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONDISOLUCION = value
        End Set
    End Property
    Private _FECHANOTIFICACION As DateTime
    Public Property FECHANOTIFICACION() As DateTime
        Get
            Return _FECHANOTIFICACION
        End Get
        Set(ByVal value As DateTime)
            _FECHANOTIFICACION = value
        End Set
    End Property
    Private _NUMERONOTIFICACION As String
    Public Property NUMERONOTIFICACION() As String
        Get
            Return _NUMERONOTIFICACION
        End Get
        Set(ByVal value As String)
            _NUMERONOTIFICACION = value
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
    Private _IDPROCESOCOMPRA As Integer
    Public Property IDPROCESOCOMPRA() As Integer
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDPROCESOCOMPRA = value
        End Set
    End Property
    Private _IDPRODUCTO As Integer
    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _IDPRODUCTO = value
        End Set
    End Property
    Private _OBSERVACIONLEYENDA As String
    Public Property OBSERVACIONLEYENDA() As String
        Get
            Return _OBSERVACIONLEYENDA
        End Get
        Set(ByVal value As String)
            _OBSERVACIONLEYENDA = value
        End Set
    End Property
    Private _OBSERVACIONNREGISTRO As String
    Public Property OBSERVACIONNREGISTRO() As String
        Get
            Return _OBSERVACIONNREGISTRO
        End Get
        Set(ByVal value As String)
            _OBSERVACIONNREGISTRO = value
        End Set
    End Property
    Private _OBSERVACIONVIAADMON As String
    Public Property OBSERVACIONVIAADMON() As String
        Get
            Return _OBSERVACIONVIAADMON
        End Get
        Set(ByVal value As String)
            _OBSERVACIONVIAADMON = value
        End Set
    End Property
    Private _OBSERVACIONCONDIALMAC As String
    Public Property OBSERVACIONCONDIALMA() As String
        Get
            Return _OBSERVACIONCONDIALMAC
        End Get
        Set(ByVal value As String)
            _OBSERVACIONCONDIALMAC = value
        End Set
    End Property
    Private _OBSERVACIONNLOTE As String
    Public Property OBSERVACIONNLOTE() As String
        Get
            Return _OBSERVACIONNLOTE
        End Get
        Set(ByVal value As String)
            _OBSERVACIONNLOTE = value
        End Set
    End Property
    Private _OBSERVACIONFECHAEXP As String
    Public Property OBSERVACIONFECHAEXP() As String
        Get
            Return _OBSERVACIONFECHAEXP
        End Get
        Set(ByVal value As String)
            _OBSERVACIONFECHAEXP = value
        End Set
    End Property
    Private _LUGARINSPECCION As String
    Public Property LUGARINSPECCION() As String
        Get
            Return _LUGARINSPECCION
        End Get
        Set(ByVal value As String)
            _LUGARINSPECCION = value
        End Set
    End Property
    Private _PAGOANALISIS As String
    Public Property PAGOANALISIS() As String
        Get
            Return _PAGOANALISIS
        End Get
        Set(ByVal value As String)
            _PAGOANALISIS = value
        End Set
    End Property
    Private _OBSERVACIONCOORDINADOR As String
    Public Property OBSERVACIONCOORDINADOR() As String
        Get
            Return _OBSERVACIONCOORDINADOR
        End Get
        Set(ByVal value As String)
            _OBSERVACIONCOORDINADOR = value
        End Set
    End Property
#End Region

End Class
