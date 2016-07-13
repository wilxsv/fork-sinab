Partial Public Class ddlSUMINISTROS

    Private miComponente As New cSUMINISTROS

#Region " Metodos Agregados "

    Public Sub RecuperarListaFiltrada(ByVal IDTIPOSUMINISTRO As Int32, Optional ByVal NM As Integer = 0)
        Me.DataSource = miComponente.ObtenerListaPorIDtipo(IDTIPOSUMINISTRO, NM)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDSUMINISTRO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaFiltrada2(ByVal IDTIPO As Int32)
        Me.DataSource = miComponente.ObtenerListaPorIDtipo(IDTIPO)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDSUMINISTRO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarOrdenada()
        Me.DataSource = miComponente.RecuperarOrdenada
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDSUMINISTRO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarOrdenadaPorCorrelativo()
        Me.DataSource = miComponente.RecuperarOrdenadaPorCorrelativo
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDSUMINISTRO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarPorUnidadTecnica(ByVal idUT As Integer)
        Me.DataSource = miComponente.obtenerSuministroPorUT(idUT)
        Me.DataTextField = "DESCSUMINISTRO"
        Me.DataValueField = "IDSUMINISTRO"
        Me.DataBind()
    End Sub

   

    Public Sub RecuperarListaFiltrada3()
        Me.DataSource = miComponente.ObtenerListaPorIDtipo2()
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDSUMINISTRO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarParaCargaInicial(ByVal IDALMACEN As Int32)
        Me.DataSource = miComponente.RecuperarParaCargaInicial(IDALMACEN)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDSUMINISTRO"
        Me.DataBind()
    End Sub

#End Region

End Class
