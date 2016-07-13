Partial Public Class ddlEMPLEADOS

    Private miComponente As New cEMPLEADOS
    Private lista As listaEMPLEADOS

#Region " Metodos agregados "

    Public Sub Recuperar2()
        Me.DataSource = miComponente.ObtenerLista()
        Me.DataTextField = "NOMBRECORTO"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarNombreCompleto()
        Me.DataSource = miComponente.ObtenerNombreCompleto()
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarNombreCompleto(ByVal TITULAR As Integer)
        Me.DataSource = miComponente.ObtenerNombreCompleto(TITULAR)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarNombre(ByVal IDESTABLECIMIENTO As Integer, ByVal TITULAR As Integer)
        Me.DataSource = miComponente.ObtenerNombreCompleto(IDESTABLECIMIENTO, TITULAR)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarNombreCompletoXEstablecimiento(ByVal IDESTABLECIMIENTO As Int64)
        Me.DataSource = miComponente.ObtenerEmpleadoXEstablecimientoNombreCompleto(IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarNombreCompletoEmpleadosSinUsuario(Optional ByVal IDUSUARIO As Int32 = 0)
        Me.DataSource = miComponente.ObtenerNombreCompletoEmpleadosSinUsuario(IDUSUARIO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarEmpleadosPorDependencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDECIA As Integer, Optional ByVal IDEMPLEADO As Integer = 0)
        Me.DataSource = miComponente.ObtenerListaEmpladosPorDependencia(IDESTABLECIMIENTO, IDDEPENDECIA, IDEMPLEADO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarEmpleadosPorDependenciaInspector(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal IDDEPENDECIA As Integer = 0, Optional ByVal IDEMPLEADO As Integer = 0)
        Me.DataSource = miComponente.ObtenerListaEmpladosPorDependenciaInspector(IDESTABLECIMIENTO, IDDEPENDECIA, IDEMPLEADO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarEmpleadosPorDependenciaCoordinador(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDECIA As Integer, Optional ByVal IDEMPLEADO As Integer = 0)
        Me.DataSource = miComponente.ObtenerListaEmpladosPorDependenciaCoordinador(IDESTABLECIMIENTO, IDDEPENDECIA, IDEMPLEADO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarEmpleadosPorDependenciaII(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDECIA As Integer)
        Me.DataSource = miComponente.ObtenerEmpleadosPorDependencia(IDESTABLECIMIENTO, IDDEPENDECIA)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    ''' <summary>
    ''' Devuelve los empleados titulares del establecimiento y de la dependencia
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la dependencia.  Opcional.</param>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Sub RecuperarTitulares(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal IDDEPENDENCIA As Integer = 0)
        Me.DataSource = miComponente.ObtenerTitulares(IDESTABLECIMIENTO, IDDEPENDENCIA)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarCodigo()
        Me.DataSource = miComponente.ObtenerDataSetCodigoEmpleado()
        Me.DataTextField = "EMPLEADO"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarCodigoNombreXEstablecimiento(ByVal IDESTABLECIMIENTO As Int64)
        Me.DataSource = miComponente.ObtenerEmpleadoXEstblecimientoCodigoNombre(IDESTABLECIMIENTO)
        Me.DataTextField = "CODIGONOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarEmpleadosComision()
        Me.DataSource = miComponente.ObtenerListaEmpleadosNA
        Me.DataValueField = "IDEMPLEADO"
        Me.DataTextField = "NOMBRE"
        Me.DataBind()
    End Sub

    Public Sub RecuperarEmpleadosPorDependenciaAnalistaJuridico(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDECIA As Integer, Optional ByVal IDEMPLEADO As Integer = 0)
        Me.DataSource = miComponente.RecuperarEmpleadosPorDependenciaAnalistaJuridico(IDESTABLECIMIENTO, IDDEPENDECIA, IDEMPLEADO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDEMPLEADO"
        Me.DataBind()
    End Sub

#End Region

End Class
