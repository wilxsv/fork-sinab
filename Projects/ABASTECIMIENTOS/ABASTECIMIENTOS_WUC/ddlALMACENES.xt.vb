Partial Public Class ddlALMACENES

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Sub RecuperarAlmacenEstablecimiento(ByVal IDESTABLECIMIENTO As Int32)

        Dim miComponente As New cALMACENESESTABLECIMIENTOS
        Me.DataSource = miComponente.ObtenerTodosAlmacenEstablecimiento(IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDALMACEN"
        Me.DataBind()

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <remarks></remarks>
    Public Sub RecuperarFarmaciasEstablecimiento(ByVal IDESTABLECIMIENTO As Int32)

        Dim miComponente As New cALMACENESESTABLECIMIENTOS

        Me.DataSource = miComponente.ObtenerTodosFarmaciasEstablecimiento(IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDALMACEN"
        Me.DataBind()

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tipo"></param>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Sub RecuperarListaOrdenada(Optional ByVal tipo As Integer = 0)

        Dim miComponente As New cALMACENES

        Me.DataSource = miComponente.ObtenerListaOrden(tipo)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDALMACEN"
        Me.DataBind()
    End Sub
    Public Sub RecuperarListaOrdenada2(Optional ByVal tipo As Integer = 0)

        Dim miComponente As New cALMACENES

        Me.DataSource = miComponente.ObtenerListaOrden2(tipo)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDALMACEN"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaAlmacenEstablecimiento(ByVal IDESTABLECIMIENTO As Int32)

        Dim miComponente As New cALMACENES
        Me.DataSource = miComponente.ObtenerListaAlmacenes(IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDALMACEN"
        Me.DataBind()

    End Sub
End Class
