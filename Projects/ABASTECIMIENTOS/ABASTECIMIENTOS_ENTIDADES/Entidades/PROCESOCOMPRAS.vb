''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_EL
''' Class	 : EL.PROCESOCOMPRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que permite tener un registro de la tabla ABASTECIMIENTOSPROCESOCOMPRAS en memoria
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	10/06/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class PROCESOCOMPRAS
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

    Private _IDTITULAR As Int32
    Public Property IDTITULAR() As Int32
        Get
            Return _IDTITULAR
        End Get
        Set(ByVal value As Int32)
            _IDTITULAR = value
        End Set
    End Property

    Private _IDENTIDADSOLICITA As Int32
    Public Property IDENTIDADSOLICITA() As Int32
        Get
            Return _IDENTIDADSOLICITA
        End Get
        Set(ByVal value As Int32)
            _IDENTIDADSOLICITA = value
        End Set
    End Property

    Private _FECHAENVIONOTA As DateTime
    Public Property FECHAENVIONOTA() As DateTime
        Get
            Return _FECHAENVIONOTA
        End Get
        Set(ByVal value As DateTime)
            _FECHAENVIONOTA = value
        End Set
    End Property

    Private _COSTOBASE As Decimal
    Public Property COSTOBASE() As Decimal
        Get
            Return _COSTOBASE
        End Get
        Set(ByVal value As Decimal)
            _COSTOBASE = value
        End Set
    End Property

    Private _LUGARAPERTURABASE As String
    Public Property LUGARAPERTURABASE() As String
        Get
            Return _LUGARAPERTURABASE
        End Get
        Set(ByVal value As String)
            _LUGARAPERTURABASE = value
        End Set
    End Property

    Private _DIRECCIONAPERTURABASE As String
    Public Property DIRECCIONAPERTURABASE() As String
        Get
            Return _DIRECCIONAPERTURABASE
        End Get
        Set(ByVal value As String)
            _DIRECCIONAPERTURABASE = value
        End Set
    End Property

    Private _IDMUNICIPIOAPERTURA As Int16
    Public Property IDMUNICIPIOAPERTURA() As Int16
        Get
            Return _IDMUNICIPIOAPERTURA
        End Get
        Set(ByVal value As Int16)
            _IDMUNICIPIOAPERTURA = value
        End Set
    End Property

    Private _FECHAHORAINICIOAPERTURA As DateTime
    Public Property FECHAHORAINICIOAPERTURA() As DateTime
        Get
            Return _FECHAHORAINICIOAPERTURA
        End Get
        Set(ByVal value As DateTime)
            _FECHAHORAINICIOAPERTURA = value
        End Set
    End Property

    Private _FECHAHORAFINAPERTURA As DateTime
    Public Property FECHAHORAFINAPERTURA() As DateTime
        Get
            Return _FECHAHORAFINAPERTURA
        End Get
        Set(ByVal value As DateTime)
            _FECHAHORAFINAPERTURA = value
        End Set
    End Property

    Private _FECHAREALIZADAAPERTURA As DateTime
    Public Property FECHAREALIZADAAPERTURA() As DateTime
        Get
            Return _FECHAREALIZADAAPERTURA
        End Get
        Set(ByVal value As DateTime)
            _FECHAREALIZADAAPERTURA = value
        End Set
    End Property

    Private _FECHAPUBLICACION As DateTime
    Public Property FECHAPUBLICACION() As DateTime
        Get
            Return _FECHAPUBLICACION
        End Get
        Set(ByVal value As DateTime)
            _FECHAPUBLICACION = value
        End Set
    End Property

    Private _LUGARRETIROBASE As String
    Public Property LUGARRETIROBASE() As String
        Get
            Return _LUGARRETIROBASE
        End Get
        Set(ByVal value As String)
            _LUGARRETIROBASE = value
        End Set
    End Property

    Private _FECHAHORAINICIORETIRO As DateTime
    Public Property FECHAHORAINICIORETIRO() As DateTime
        Get
            Return _FECHAHORAINICIORETIRO
        End Get
        Set(ByVal value As DateTime)
            _FECHAHORAINICIORETIRO = value
        End Set
    End Property

    Private _FECHAHORAFINRETIRO As DateTime
    Public Property FECHAHORAFINRETIRO() As DateTime
        Get
            Return _FECHAHORAFINRETIRO
        End Get
        Set(ByVal value As DateTime)
            _FECHAHORAFINRETIRO = value
        End Set
    End Property

    Private _LUGARRECEPCIONOFERTA As String
    Public Property LUGARRECEPCIONOFERTA() As String
        Get
            Return _LUGARRECEPCIONOFERTA
        End Get
        Set(ByVal value As String)
            _LUGARRECEPCIONOFERTA = value
        End Set
    End Property

    Private _DIRECCIONRECEPCIONOFERTA As String
    Public Property DIRECCIONRECEPCIONOFERTA() As String
        Get
            Return _DIRECCIONRECEPCIONOFERTA
        End Get
        Set(ByVal value As String)
            _DIRECCIONRECEPCIONOFERTA = value
        End Set
    End Property

    Private _IDMUNICIPIORECEPCION As Int16
    Public Property IDMUNICIPIORECEPCION() As Int16
        Get
            Return _IDMUNICIPIORECEPCION
        End Get
        Set(ByVal value As Int16)
            _IDMUNICIPIORECEPCION = value
        End Set
    End Property

    Private _FECHAHORAINICIORECEPCION As DateTime
    Public Property FECHAHORAINICIORECEPCION() As DateTime
        Get
            Return _FECHAHORAINICIORECEPCION
        End Get
        Set(ByVal value As DateTime)
            _FECHAHORAINICIORECEPCION = value
        End Set
    End Property

    Private _FECHAHORAFINRECEPCION As DateTime
    Public Property FECHAHORAFINRECEPCION() As DateTime
        Get
            Return _FECHAHORAFINRECEPCION
        End Get
        Set(ByVal value As DateTime)
            _FECHAHORAFINRECEPCION = value
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

    Private _TITULOLICITACION As String
    Public Property TITULOLICITACION() As String
        Get
            Return _TITULOLICITACION
        End Get
        Set(ByVal value As String)
            _TITULOLICITACION = value
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

    Private _IDTIPOCOMPRASUGERIDO As Int32
    Public Property IDTIPOCOMPRASUGERIDO() As Int32
        Get
            Return _IDTIPOCOMPRASUGERIDO
        End Get
        Set(ByVal value As Int32)
            _IDTIPOCOMPRASUGERIDO = value
        End Set
    End Property

    Private _IDTIPOCOMPRAEJECUTAR As Int32
    Public Property IDTIPOCOMPRAEJECUTAR() As Int32
        Get
            Return _IDTIPOCOMPRAEJECUTAR
        End Get
        Set(ByVal value As Int32)
            _IDTIPOCOMPRAEJECUTAR = value
        End Set
    End Property

    Private _IDESTADOPROCESOCOMPRA As Int32
    Public Property IDESTADOPROCESOCOMPRA() As Int32
        Get
            Return _IDESTADOPROCESOCOMPRA
        End Get
        Set(ByVal value As Int32)
            _IDESTADOPROCESOCOMPRA = value
        End Set
    End Property

    Private _IDENCARGADO As Int32
    Public Property IDENCARGADO() As Int32
        Get
            Return _IDENCARGADO
        End Get
        Set(ByVal value As Int32)
            _IDENCARGADO = value
        End Set
    End Property

    Private _IDJEFEUACI As Int32
    Public Property IDJEFEUACI() As Int32
        Get
            Return _IDJEFEUACI
        End Get
        Set(ByVal value As Int32)
            _IDJEFEUACI = value
        End Set
    End Property

    Private _FECHAINICIOPROCESOCOMPRA As DateTime
    Public Property FECHAINICIOPROCESOCOMPRA() As DateTime
        Get
            Return _FECHAINICIOPROCESOCOMPRA
        End Get
        Set(ByVal value As DateTime)
            _FECHAINICIOPROCESOCOMPRA = value
        End Set
    End Property

    Private _FECHAELABORACIONBASE As DateTime
    Public Property FECHAELABORACIONBASE() As DateTime
        Get
            Return _FECHAELABORACIONBASE
        End Get
        Set(ByVal value As DateTime)
            _FECHAELABORACIONBASE = value
        End Set
    End Property

    Private _FECHAAPROBACIONBASE As DateTime
    Public Property FECHAAPROBACIONBASE() As DateTime
        Get
            Return _FECHAAPROBACIONBASE
        End Get
        Set(ByVal value As DateTime)
            _FECHAAPROBACIONBASE = value
        End Set
    End Property

    Private _FECHAINICIOACLARACIONES As DateTime
    Public Property FECHAINICIOACLARACIONES() As DateTime
        Get
            Return _FECHAINICIOACLARACIONES
        End Get
        Set(ByVal value As DateTime)
            _FECHAINICIOACLARACIONES = value
        End Set
    End Property

    Private _FECHAFINACLARACIONES As DateTime
    Public Property FECHAFINACLARACIONES() As DateTime
        Get
            Return _FECHAFINACLARACIONES
        End Get
        Set(ByVal value As DateTime)
            _FECHAFINACLARACIONES = value
        End Set
    End Property

    Private _FECHAINICIOCONSULTA As DateTime
    Public Property FECHAINICIOCONSULTA() As DateTime
        Get
            Return _FECHAINICIOCONSULTA
        End Get
        Set(ByVal value As DateTime)
            _FECHAINICIOCONSULTA = value
        End Set
    End Property

    Private _FECHAFINCONSULTA As DateTime
    Public Property FECHAFINCONSULTA() As DateTime
        Get
            Return _FECHAFINCONSULTA
        End Get
        Set(ByVal value As DateTime)
            _FECHAFINCONSULTA = value
        End Set
    End Property

    Private _PORCENTAJEFINANCIERO As Decimal
    Public Property PORCENTAJEFINANCIERO() As Decimal
        Get
            Return _PORCENTAJEFINANCIERO
        End Get
        Set(ByVal value As Decimal)
            _PORCENTAJEFINANCIERO = value
        End Set
    End Property

    Private _PORCENTAJEINDICESOLVENCIA As Decimal
    Public Property PORCENTAJEINDICESOLVENCIA() As Decimal
        Get
            Return _PORCENTAJEINDICESOLVENCIA
        End Get
        Set(ByVal value As Decimal)
            _PORCENTAJEINDICESOLVENCIA = value
        End Set
    End Property

    Private _PORCENTAJECAPITALTRABAJO As Decimal
    Public Property PORCENTAJECAPITALTRABAJO() As Decimal
        Get
            Return _PORCENTAJECAPITALTRABAJO
        End Get
        Set(ByVal value As Decimal)
            _PORCENTAJECAPITALTRABAJO = value
        End Set
    End Property

    Private _PORCENTAJEENDEUDAMIENTO As Decimal
    Public Property PORCENTAJEENDEUDAMIENTO() As Decimal
        Get
            Return _PORCENTAJEENDEUDAMIENTO
        End Get
        Set(ByVal value As Decimal)
            _PORCENTAJEENDEUDAMIENTO = value
        End Set
    End Property

    Private _PORCENTAJEREFERENCIASBANC As Decimal
    Public Property PORCENTAJEREFERENCIASBANC() As Decimal
        Get
            Return _PORCENTAJEREFERENCIASBANC
        End Get
        Set(ByVal value As Decimal)
            _PORCENTAJEREFERENCIASBANC = value
        End Set
    End Property

    Private _GARANTIAMTTOENTREGA As Int16
    Public Property GARANTIAMTTOENTREGA() As Int16
        Get
            Return _GARANTIAMTTOENTREGA
        End Get
        Set(ByVal value As Int16)
            _GARANTIAMTTOENTREGA = value
        End Set
    End Property

    Private _GARANTIAMTTOVIGENCIA As Int16
    Public Property GARANTIAMTTOVIGENCIA() As Int16
        Get
            Return _GARANTIAMTTOVIGENCIA
        End Get
        Set(ByVal value As Int16)
            _GARANTIAMTTOVIGENCIA = value
        End Set
    End Property

    Private _LUGARMTTO As String
    Public Property LUGARMTTO() As String
        Get
            Return _LUGARMTTO
        End Get
        Set(ByVal value As String)
            _LUGARMTTO = value
        End Set
    End Property

    Private _GARANTIACUMPLIMIENTOVALOR As Decimal
    Public Property GARANTIACUMPLIMIENTOVALOR() As Decimal
        Get
            Return _GARANTIACUMPLIMIENTOVALOR
        End Get
        Set(ByVal value As Decimal)
            _GARANTIACUMPLIMIENTOVALOR = value
        End Set
    End Property

    Private _GARANTIACUMPLIMIENTOENTREGA As Int16
    Public Property GARANTIACUMPLIMIENTOENTREGA() As Int16
        Get
            Return _GARANTIACUMPLIMIENTOENTREGA
        End Get
        Set(ByVal value As Int16)
            _GARANTIACUMPLIMIENTOENTREGA = value
        End Set
    End Property

    Private _GARANTIACUMPLIMIENTOVIGENCIA As Int16
    Public Property GARANTIACUMPLIMIENTOVIGENCIA() As Int16
        Get
            Return _GARANTIACUMPLIMIENTOVIGENCIA
        End Get
        Set(ByVal value As Int16)
            _GARANTIACUMPLIMIENTOVIGENCIA = value
        End Set
    End Property

    Private _LUGARCUMPLIMIENTO As String
    Public Property LUGARCUMPLIMIENTO() As String
        Get
            Return _LUGARCUMPLIMIENTO
        End Get
        Set(ByVal value As String)
            _LUGARCUMPLIMIENTO = value
        End Set
    End Property

    Private _GARANTIACALIDADVALOR As Decimal
    Public Property GARANTIACALIDADVALOR() As Decimal
        Get
            Return _GARANTIACALIDADVALOR
        End Get
        Set(ByVal value As Decimal)
            _GARANTIACALIDADVALOR = value
        End Set
    End Property

    Private _GARANTIACALIDADENTREGA As Int16
    Public Property GARANTIACALIDADENTREGA() As Int16
        Get
            Return _GARANTIACALIDADENTREGA
        End Get
        Set(ByVal value As Int16)
            _GARANTIACALIDADENTREGA = value
        End Set
    End Property

    Private _GARANTIACALIDADVIGENCIA As Int16
    Public Property GARANTIACALIDADVIGENCIA() As Int16
        Get
            Return _GARANTIACALIDADVIGENCIA
        End Get
        Set(ByVal value As Int16)
            _GARANTIACALIDADVIGENCIA = value
        End Set
    End Property

    Private _LUGARCALIDAD As String
    Public Property LUGARCALIDAD() As String
        Get
            Return _LUGARCALIDAD
        End Get
        Set(ByVal value As String)
            _LUGARCALIDAD = value
        End Set
    End Property

    Private _FECHAINICIOANALISIS As DateTime
    Public Property FECHAINICIOANALISIS() As DateTime
        Get
            Return _FECHAINICIOANALISIS
        End Get
        Set(ByVal value As DateTime)
            _FECHAINICIOANALISIS = value
        End Set
    End Property

    Private _FECHAFINANALISIS As DateTime
    Public Property FECHAFINANALISIS() As DateTime
        Get
            Return _FECHAFINANALISIS
        End Get
        Set(ByVal value As DateTime)
            _FECHAFINANALISIS = value
        End Set
    End Property

    Private _FECHAFIRMARESOLUCION As DateTime
    Public Property FECHAFIRMARESOLUCION() As DateTime
        Get
            Return _FECHAFIRMARESOLUCION
        End Get
        Set(ByVal value As DateTime)
            _FECHAFIRMARESOLUCION = value
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

    Private _FECHALIMITEACEPTACION As DateTime
    Public Property FECHALIMITEACEPTACION() As DateTime
        Get
            Return _FECHALIMITEACEPTACION
        End Get
        Set(ByVal value As DateTime)
            _FECHALIMITEACEPTACION = value
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

    Private _FECHAPUBLICACIONRESOLUCION As DateTime
    Public Property FECHAPUBLICACIONRESOLUCION() As DateTime
        Get
            Return _FECHAPUBLICACIONRESOLUCION
        End Get
        Set(ByVal value As DateTime)
            _FECHAPUBLICACIONRESOLUCION = value
        End Set
    End Property

    Private _MEDIOSDIVULGACION As String
    Public Property MEDIOSDIVULGACION() As String
        Get
            Return _MEDIOSDIVULGACION
        End Get
        Set(ByVal value As String)
            _MEDIOSDIVULGACION = value
        End Set
    End Property

    Private _FECHAFIRMAACEPTACION As DateTime
    Public Property FECHAFIRMAACEPTACION() As DateTime
        Get
            Return _FECHAFIRMAACEPTACION
        End Get
        Set(ByVal value As DateTime)
            _FECHAFIRMAACEPTACION = value
        End Set
    End Property

    Private _VIGENCIACOTIZACION As Int16
    Public Property VIGENCIACOTIZACION() As Int16
        Get
            Return _VIGENCIACOTIZACION
        End Get
        Set(ByVal value As Int16)
            _VIGENCIACOTIZACION = value
        End Set
    End Property

    Private _GARANTIACUMPLIMIENTOORDENCOMPRA As Decimal
    Public Property GARANTIACUMPLIMIENTOORDENCOMPRA() As Decimal
        Get
            Return _GARANTIACUMPLIMIENTOORDENCOMPRA
        End Get
        Set(ByVal value As Decimal)
            _GARANTIACUMPLIMIENTOORDENCOMPRA = value
        End Set
    End Property

    Private _TIEMPOENTREGA As Int16
    Public Property TIEMPOENTREGA() As Int16
        Get
            Return _TIEMPOENTREGA
        End Get
        Set(ByVal value As Int16)
            _TIEMPOENTREGA = value
        End Set
    End Property

    Private _FECHAFINRECOMENDACION As DateTime
    Public Property FECHAFINRECOMENDACION() As DateTime
        Get
            Return _FECHAFINRECOMENDACION
        End Get
        Set(ByVal value As DateTime)
            _FECHAFINRECOMENDACION = value
        End Set
    End Property

    Private _FECHAFINEXAMEN As DateTime
    Public Property FECHAFINEXAMEN() As DateTime
        Get
            Return _FECHAFINEXAMEN
        End Get
        Set(ByVal value As DateTime)
            _FECHAFINEXAMEN = value
        End Set
    End Property

    Private _IDTITULARADJUDICACION As Int32
    Public Property IDTITULARADJUDICACION() As Int32
        Get
            Return _IDTITULARADJUDICACION
        End Get
        Set(ByVal value As Int32)
            _IDTITULARADJUDICACION = value
        End Set
    End Property

    Private _ACTAAPERTURA As String
    Public Property ACTAAPERTURA() As String
        Get
            Return _ACTAAPERTURA
        End Get
        Set(ByVal value As String)
            _ACTAAPERTURA = value
        End Set
    End Property

    Private _OBSERVACIONESACTA As String
    Public Property OBSERVACIONESACTA() As String
        Get
            Return _OBSERVACIONESACTA
        End Get
        Set(ByVal value As String)
            _OBSERVACIONESACTA = value
        End Set
    End Property

    Private _GARANTIAANTICIPOVALOR As Decimal
    Public Property GARANTIAANTICIPOVALOR() As Decimal
        Get
            Return _GARANTIAANTICIPOVALOR
        End Get
        Set(ByVal value As Decimal)
            _GARANTIAANTICIPOVALOR = value
        End Set
    End Property

    Private _GARANTIAANTICIPOENTREGAS As Int16
    Public Property GARANTIAANTICIPOENTREGAS() As Int16
        Get
            Return _GARANTIAANTICIPOENTREGAS
        End Get
        Set(ByVal value As Int16)
            _GARANTIAANTICIPOENTREGAS = value
        End Set
    End Property

    Private _GARANTIAANTICIPOVIGENCIA As Int16
    Public Property GARANTIAANTICIPOVIGENCIA() As Int16
        Get
            Return _GARANTIAANTICIPOVIGENCIA
        End Get
        Set(ByVal value As Int16)
            _GARANTIAANTICIPOVIGENCIA = value
        End Set
    End Property

    Private _LUGARANTICIPO As String
    Public Property LUGARANTICIPO() As String
        Get
            Return _LUGARANTICIPO
        End Get
        Set(ByVal value As String)
            _LUGARANTICIPO = value
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
