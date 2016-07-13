
Partial Class Controles_ucConsultarProcesoCompra
    Inherits System.Web.UI.UserControl

    Public Sub CargarProcesosCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDESTADO As Integer, ByVal idEmpleado As Integer, ByVal Todos As Boolean)
        Dim ProcesoCompra As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS
        Me.gvProcesosCompra.DataSource = ProcesoCompra.ObtenerProcesoCompraAnalista(IDESTABLECIMIENTO, IDESTADO, idEmpleado, Todos)
        Me.gvProcesosCompra.DataBind()
        ProcesoCompra = Nothing
    End Sub

    Public Sub CargarEstados()
        Dim Estado As New ABASTECIMIENTOS.NEGOCIO.cESTADOPROCESOSCOMPRAS
        Me.ddlEstado.DataSource = Estado.ObtenerDataSetPorId.Tables(0)
        Me.ddlEstado.DataTextField = "DESCRIPCION"
        Me.ddlEstado.DataValueField = "IDESTADOPROCESOCOMPRA"
        Me.ddlEstado.DataBind()
        Estado = Nothing
    End Sub

    Public Sub CargarAnalistas(ByVal idEstablecimiento As Int32, ByVal idDependencia As Int32)
        Dim Analista As New ABASTECIMIENTOS.NEGOCIO.cEMPLEADOS
        Me.ddlAnalista.DataSource = Analista.ObtenerDataSetporEstablecimientoDependencia(idEstablecimiento, idDependencia)
        Me.ddlAnalista.DataTextField = "EMPLEADO"
        Me.ddlAnalista.DataValueField = "IDEMPLEADO"
        Me.ddlAnalista.DataBind()
        Analista = Nothing
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.CargarProcesosCompra(Session("idEstablecimiento"), Me.ddlEstado.SelectedValue, Me.ddlAnalista.SelectedValue, Me.cbTodos.Checked)
    End Sub

    Protected Sub dgProcesosCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProcesosCompra.PageIndexChanging
        Me.gvProcesosCompra.PageIndex = e.NewPageIndex
        Me.CargarProcesosCompra(Session("idEstablecimiento"), Me.ddlEstado.SelectedValue, Me.ddlAnalista.SelectedValue, Me.cbTodos.Checked)
    End Sub

End Class
