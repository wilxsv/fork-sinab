''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.INFORMEMUESTRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSINFORMEMUESTRAS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	04/04/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class INFORMEMUESTRAS
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

    Private _IDTIPOINFORME As Int16
    Public Property IDTIPOINFORME() As Int16
        Get
            Return _IDTIPOINFORME
        End Get
        Set(ByVal value As Int16)
            _IDTIPOINFORME = value
        End Set
    End Property

    Private _NUMEROINFORME As String
    Public Property NUMEROINFORME() As String
        Get
            Return _NUMEROINFORME
        End Get
        Set(ByVal value As String)
            _NUMEROINFORME = value
        End Set
    End Property

    Private _IDESTADO As Int32
    Public Property IDESTADO() As Int32
        Get
            Return _IDESTADO
        End Get
        Set(ByVal value As Int32)
            _IDESTADO = value
        End Set
    End Property

    Private _IDESTABLECIMIENTOCONTRATO As Int32
    Public Property IDESTABLECIMIENTOCONTRATO() As Int32
        Get
            Return _IDESTABLECIMIENTOCONTRATO
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTOCONTRATO = value
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

    Private _RENGLON As Int32
    Public Property RENGLON() As Int32
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Int32)
            _RENGLON = value
        End Set
    End Property

    Private _NOMBREMEDICAMENTO As String
    Public Property NOMBREMEDICAMENTO() As String
        Get
            Return _NOMBREMEDICAMENTO
        End Get
        Set(ByVal value As String)
            _NOMBREMEDICAMENTO = value
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

    Private _PROVEEDOR As String
    Public Property PROVEEDOR() As String
        Get
            Return _PROVEEDOR
        End Get
        Set(ByVal value As String)
            _PROVEEDOR = value
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

    Private _NUMEROUNIDADES As Decimal
    Public Property NUMEROUNIDADES() As Decimal
        Get
            Return _NUMEROUNIDADES
        End Get
        Set(ByVal value As Decimal)
            _NUMEROUNIDADES = value
        End Set
    End Property

    Private _CANTIDADREMITIDA As Decimal
    Public Property CANTIDADREMITIDA() As Decimal
        Get
            Return _CANTIDADREMITIDA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADREMITIDA = value
        End Set
    End Property

    Private _ESTABLECIMIENTOREMITE As String
    Public Property ESTABLECIMIENTOREMITE() As String
        Get
            Return _ESTABLECIMIENTOREMITE
        End Get
        Set(ByVal value As String)
            _ESTABLECIMIENTOREMITE = value
        End Set
    End Property

    Private _NUMERORECEPCION As String
    Public Property NUMERORECEPCION() As String
        Get
            Return _NUMERORECEPCION
        End Get
        Set(ByVal value As String)
            _NUMERORECEPCION = value
        End Set
    End Property

    Private _GUIAAEREA As String
    Public Property GUIAAEREA() As String
        Get
            Return _GUIAAEREA
        End Get
        Set(ByVal value As String)
            _GUIAAEREA = value
        End Set
    End Property

    Private _DESCRIPCIONEMPAQUE As String
    Public Property DESCRIPCIONEMPAQUE() As String
        Get
            Return _DESCRIPCIONEMPAQUE
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONEMPAQUE = value
        End Set
    End Property

    Private _LEYENDAREQUERIDA As Byte
    Public Property LEYENDAREQUERIDA() As Byte
        Get
            Return _LEYENDAREQUERIDA
        End Get
        Set(ByVal value As Byte)
            _LEYENDAREQUERIDA = value
        End Set
    End Property

    Private _NUMEROREGISTRO As Byte
    Public Property NUMEROREGISTRO() As Byte
        Get
            Return _NUMEROREGISTRO
        End Get
        Set(ByVal value As Byte)
            _NUMEROREGISTRO = value
        End Set
    End Property

    Private _VIAADMINISTRACION As Byte
    Public Property VIAADMINISTRACION() As Byte
        Get
            Return _VIAADMINISTRACION
        End Get
        Set(ByVal value As Byte)
            _VIAADMINISTRACION = value
        End Set
    End Property

    Private _FORMADISOLUCION As Byte
    Public Property FORMADISOLUCION() As Byte
        Get
            Return _FORMADISOLUCION
        End Get
        Set(ByVal value As Byte)
            _FORMADISOLUCION = value
        End Set
    End Property

    Private _CONDICIONESALMACENAMIENTO As Byte
    Public Property CONDICIONESALMACENAMIENTO() As Byte
        Get
            Return _CONDICIONESALMACENAMIENTO
        End Get
        Set(ByVal value As Byte)
            _CONDICIONESALMACENAMIENTO = value
        End Set
    End Property

    Private _NUMEROLOTE As Byte
    Public Property NUMEROLOTE() As Byte
        Get
            Return _NUMEROLOTE
        End Get
        Set(ByVal value As Byte)
            _NUMEROLOTE = value
        End Set
    End Property

    Private _FECHAEXPIRACION As Byte
    Public Property FECHAEXPIRACION() As Byte
        Get
            Return _FECHAEXPIRACION
        End Get
        Set(ByVal value As Byte)
            _FECHAEXPIRACION = value
        End Set
    End Property

    Private _OTROSEMPAQUES As Byte
    Public Property OTROSEMPAQUES() As Byte
        Get
            Return _OTROSEMPAQUES
        End Get
        Set(ByVal value As Byte)
            _OTROSEMPAQUES = value
        End Set
    End Property

    Private _DESCRIPCIONOTROSEMPAQUES As String
    Public Property DESCRIPCIONOTROSEMPAQUES() As String
        Get
            Return _DESCRIPCIONOTROSEMPAQUES
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONOTROSEMPAQUES = value
        End Set
    End Property

    Private _DESCRIPCIONPRODUCTO As String
    Public Property DESCRIPCIONPRODUCTO() As String
        Get
            Return _DESCRIPCIONPRODUCTO
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONPRODUCTO = value
        End Set
    End Property

    Private _CANTIDADFISICOQUIMICO As Decimal
    Public Property CANTIDADFISICOQUIMICO() As Decimal
        Get
            Return _CANTIDADFISICOQUIMICO
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADFISICOQUIMICO = value
        End Set
    End Property

    Private _CANTIDADMICROBIOLOGIA As Decimal
    Public Property CANTIDADMICROBIOLOGIA() As Decimal
        Get
            Return _CANTIDADMICROBIOLOGIA
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADMICROBIOLOGIA = value
        End Set
    End Property

    Private _CANTIDADRETENCION As Decimal
    Public Property CANTIDADRETENCION() As Decimal
        Get
            Return _CANTIDADRETENCION
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADRETENCION = value
        End Set
    End Property

    Private _DESCRIPCIONCONDICIONESALMACENAMIENTO As String
    Public Property DESCRIPCIONCONDICIONESALMACENAMIENTO() As String
        Get
            Return _DESCRIPCIONCONDICIONESALMACENAMIENTO
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONCONDICIONESALMACENAMIENTO = value
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

    Private _IDINSPECTOR As Int32
    Public Property IDINSPECTOR() As Int32
        Get
            Return _IDINSPECTOR
        End Get
        Set(ByVal value As Int32)
            _IDINSPECTOR = value
        End Set
    End Property

    Private _FECHAELABORACIONINFORME As DateTime
    Public Property FECHAELABORACIONINFORME() As DateTime
        Get
            Return _FECHAELABORACIONINFORME
        End Get
        Set(ByVal value As DateTime)
            _FECHAELABORACIONINFORME = value
        End Set
    End Property

    Private _IDCOORDINADOR As Int32
    Public Property IDCOORDINADOR() As Int32
        Get
            Return _IDCOORDINADOR
        End Get
        Set(ByVal value As Int32)
            _IDCOORDINADOR = value
        End Set
    End Property

    Private _MOTIVOSNOINSPECCION As String
    Public Property MOTIVOSNOINSPECCION() As String
        Get
            Return _MOTIVOSNOINSPECCION
        End Get
        Set(ByVal value As String)
            _MOTIVOSNOINSPECCION = value
        End Set
    End Property

    Private _FECHACERTIFICACION As DateTime
    Public Property FECHACERTIFICACION() As DateTime
        Get
            Return _FECHACERTIFICACION
        End Get
        Set(ByVal value As DateTime)
            _FECHACERTIFICACION = value
        End Set
    End Property

    Private _FECHASOLICITUDINSPECCION As DateTime
    Public Property FECHASOLICITUDINSPECCION() As DateTime
        Get
            Return _FECHASOLICITUDINSPECCION
        End Get
        Set(ByVal value As DateTime)
            _FECHASOLICITUDINSPECCION = value
        End Set
    End Property

    Private _FECHARECOLECCIONMUESTRA As DateTime
    Public Property FECHARECOLECCIONMUESTRA() As DateTime
        Get
            Return _FECHARECOLECCIONMUESTRA
        End Get
        Set(ByVal value As DateTime)
            _FECHARECOLECCIONMUESTRA = value
        End Set
    End Property

    Private _OBSERVACIONCERTIFICACION As String
    Public Property OBSERVACIONCERTIFICACION() As String
        Get
            Return _OBSERVACIONCERTIFICACION
        End Get
        Set(ByVal value As String)
            _OBSERVACIONCERTIFICACION = value
        End Set
    End Property

    Private _IDJEFELABORATORIO As Int32
    Public Property IDJEFELABORATORIO() As Int32
        Get
            Return _IDJEFELABORATORIO
        End Get
        Set(ByVal value As Int32)
            _IDJEFELABORATORIO = value
        End Set
    End Property

    Private _REPRESENTANTEPROVEEDOR As String
    Public Property REPRESENTANTEPROVEEDOR() As String
        Get
            Return _REPRESENTANTEPROVEEDOR
        End Get
        Set(ByVal value As String)
            _REPRESENTANTEPROVEEDOR = value
        End Set
    End Property

    Private _RESULTADOINSPECCION As Byte
    Public Property RESULTADOINSPECCION() As Byte
        Get
            Return _RESULTADOINSPECCION
        End Get
        Set(ByVal value As Byte)
            _RESULTADOINSPECCION = value
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

    Private _COMPROBANTECREDITOFISCAL As String
    Public Property COMPROBANTECREDITOFISCAL() As String
        Get
            Return _COMPROBANTECREDITOFISCAL
        End Get
        Set(ByVal value As String)
            _COMPROBANTECREDITOFISCAL = value
        End Set
    End Property

    Private _NUMEROEMPAQUEPRIMARIO As String
    Public Property NUMEROEMPAQUEPRIMARIO() As String
        Get
            Return _NUMEROEMPAQUEPRIMARIO
        End Get
        Set(ByVal value As String)
            _NUMEROEMPAQUEPRIMARIO = value
        End Set
    End Property

    Private _NUMEROEMPAQUESECUNDARIO As String
    Public Property NUMEROEMPAQUESECUNDARIO() As String
        Get
            Return _NUMEROEMPAQUESECUNDARIO
        End Get
        Set(ByVal value As String)
            _NUMEROEMPAQUESECUNDARIO = value
        End Set
    End Property

    Private _DESCRIPCIONEMPAQUESECUNDARIO As String
    Public Property DESCRIPCIONEMPAQUESECUNDARIO() As String
        Get
            Return _DESCRIPCIONEMPAQUESECUNDARIO
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONEMPAQUESECUNDARIO = value
        End Set
    End Property

    Private _NUMEROEMPAQUECOLECTIVO As String
    Public Property NUMEROEMPAQUECOLECTIVO() As String
        Get
            Return _NUMEROEMPAQUECOLECTIVO
        End Get
        Set(ByVal value As String)
            _NUMEROEMPAQUECOLECTIVO = value
        End Set
    End Property

    Private _DESCRIPCIONEMPAQUECOLECTIVO As String
    Public Property DESCRIPCIONEMPAQUECOLECTIVO() As String
        Get
            Return _DESCRIPCIONEMPAQUECOLECTIVO
        End Get
        Set(ByVal value As String)
            _DESCRIPCIONEMPAQUECOLECTIVO = value
        End Set
    End Property

    Private _CONDICIONESALMACENAMIENTORECOMENDADAS As String
    Public Property CONDICIONESALMACENAMIENTORECOMENDADAS() As String
        Get
            Return _CONDICIONESALMACENAMIENTORECOMENDADAS
        End Get
        Set(ByVal value As String)
            _CONDICIONESALMACENAMIENTORECOMENDADAS = value
        End Set
    End Property

    Private _NIVELINSPECCIONUTILIZABLE As Integer
    Public Property NIVELINSPECCIONUTILIZABLE() As Integer
        Get
            Return _NIVELINSPECCIONUTILIZABLE
        End Get
        Set(ByVal value As Integer)
            _NIVELINSPECCIONUTILIZABLE = value
        End Set
    End Property

    Private _NUMEROUNIDADESAMUESTREAR As Integer
    Public Property NUMEROUNIDADESAMUESTREAR() As Integer
        Get
            Return _NUMEROUNIDADESAMUESTREAR
        End Get
        Set(ByVal value As Integer)
            _NUMEROUNIDADESAMUESTREAR = value
        End Set
    End Property

    Private _NIVELCALIDADACEPTABLE As String
    Public Property NIVELCALIDADACEPTABLE() As String
        Get
            Return _NIVELCALIDADACEPTABLE
        End Get
        Set(ByVal value As String)
            _NIVELCALIDADACEPTABLE = value
        End Set
    End Property

    Private _RANGOACEPTACIONRECHAZO As String
    Public Property RANGOACEPTACIONRECHAZO() As String
        Get
            Return _RANGOACEPTACIONRECHAZO
        End Get
        Set(ByVal value As String)
            _RANGOACEPTACIONRECHAZO = value
        End Set
    End Property

    Private _CALCULOS As String
    Public Property CALCULOS() As String
        Get
            Return _CALCULOS
        End Get
        Set(ByVal value As String)
            _CALCULOS = value
        End Set
    End Property
    Private _OBSERVACIONASIGNACION As String
    Public Property OBSERVACIONASIGNACION() As String
        Get
            Return _OBSERVACIONASIGNACION
        End Get
        Set(ByVal value As String)
            _OBSERVACIONASIGNACION = value
        End Set
    End Property
    Private _FECHAASIGNACION As DateTime
    Public Property FECHAASIGNACION() As DateTime
        Get
            Return _FECHAASIGNACION
        End Get
        Set(ByVal value As DateTime)
            _FECHAASIGNACION = value
        End Set
    End Property

    Private _NOMBREINSPECCION As String
    Public Property NOMBREINSPECCION() As String
        Get
            Return _NOMBREINSPECCION
        End Get
        Set(ByVal value As String)
            _NOMBREINSPECCION = value
        End Set
    End Property


#End Region

End Class
