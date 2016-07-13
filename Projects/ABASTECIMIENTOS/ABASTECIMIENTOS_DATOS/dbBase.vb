Imports System.Configuration.ConfigurationSettings

Public MustInherit Class dbBase

#Region " Protegidas "
    Protected _sError As String
    Protected _sql As SqlHelper
    Protected _cnnStr As String = AppSettings("cnnString")
    Protected _cnnStrSeg As String = AppSettings("cnnStringSeg")

    ' todo : cambiar la ip de la cadena de conexion SIAP
    Protected _cnnStrSiap As String = AppSettings("cnnStringSiap")
#End Region

#Region " Propiedades "

    Protected Overridable Property sql() As SqlHelper
        Get
            Return Me._sql
        End Get
        Set(ByVal Value As SqlHelper)
            Me._sql = Value
        End Set
    End Property

    Protected Overridable Property sError() As String
        Get
            Return Me._sError
        End Get
        Set(ByVal Value As String)
            Me._sError = Value
        End Set
    End Property

    Protected Overridable Property cnnStr() As String
        Get
            Return Me._cnnStr
        End Get
        Set(ByVal Value As String)
            Me._cnnStr = Value
        End Set
    End Property

    Protected Overridable Property cnnStrSeg() As String
        Get
            Return Me._cnnStrSeg
        End Get
        Set(ByVal Value As String)
            Me._cnnStrSeg = Value
        End Set
    End Property

    Protected Overridable Property cnnStrSiap() As String
        Get
            Return Me._cnnStrSiap
        End Get
        Set(ByVal Value As String)
            Me._cnnStrSiap = Value
        End Set
    End Property

#End Region

#Region " Métodos Públicos "

    Public MustOverride Function Actualizar(ByVal aEntidad As entidadBase) As Integer
    'Funcion que se encarga de Actualizar los datos de la Entidad

    Public MustOverride Function Agregar(ByVal aEntidad As entidadBase) As Integer
    'Funcion que se encarga de Insertar los datos de la Entidad

    Public MustOverride Function Eliminar(ByVal aEntidad As entidadBase) As Integer
    'Funcion que se encarga de Eliminar los datos de la Entidad

    Public MustOverride Function Recuperar(ByVal aEntidad As entidadBase) As Integer
    'Funcion que se encarga de Recuperar los datos de la Entidad

    Public MustOverride Function ObtenerID(ByVal aEntidad As entidadBase) As String
    'Funcion que se encarga de Obtener el Maximo ID de la Entidad.

#End Region

End Class
