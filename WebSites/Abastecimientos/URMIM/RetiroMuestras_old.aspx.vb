
Partial Class RetiroMuestras_old
    Inherits System.Web.UI.Page

    Private _IDPROCESOCOMPRA As Integer
    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _RENGLON As Integer

    Public Property IDPROCESOCOMPRA() As Integer
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDPROCESOCOMPRA = value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IDPROCESOCOMPRA", value)
        End Set
    End Property
    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
        End Set
    End Property
    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            _IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property
    Public Property IDCONTRATO() As Integer
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDCONTRATO = value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", value)
        End Set
    End Property
    Public Property RENGLON() As Integer
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Integer)
            _RENGLON = value
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.ViewState.Remove("RENGLON")
            Me.ViewState.Add("RENGLON", value)
        End Set
    End Property

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Dim dPC As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS
            Me.gvPC.DataSource = dPC.ObtenerProcesoCompraAdjudicados()
            Me.gvPC.DataBind()

            Me.ddlEMPLEADOS1.RecuperarEmpleadosPorDependenciaInspector(Session("IdEstablecimiento"))
            If Me.ddlEMPLEADOS1.Items.Count <> 0 Then
                Me.ddlEMPLEADOS1.SelectedIndex = 0
            End If
        Else
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.IDCONTRATO = Me.ViewState("IDCONTRATO")
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.RENGLON = Me.ViewState("RENGLON")

        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvPC.SelectedIndexChanging
        Me.pnProveedores.Visible = True
        Me.gvP.Visible = True
        Dim cP As New ABASTECIMIENTOS.NEGOCIO.cPROVEEDORES
        IDPROCESOCOMPRA = Me.gvPC.DataKeys(e.NewSelectedIndex).Values(1)
        IDESTABLECIMIENTO = Me.gvPC.DataKeys(e.NewSelectedIndex).Values(0)


        Me.gvP.DataSource = cP.obtenerProveedoresAdj(IDESTABLECIMIENTO, IDPROCESOCOMPRA, True, Session.Item("IdEmpleado"))
        Me.gvP.DataBind()
        Me.gvP.SelectedIndex = -1

        Me.pnMan.Visible = False
        Me.gvRenglones.DataSource = Nothing

    End Sub

    Protected Sub gvP_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvP.SelectedIndexChanging
        Dim cA As New ABASTECIMIENTOS.NEGOCIO.cADJUDICACION
        IDPROVEEDOR = Me.gvP.DataKeys(e.NewSelectedIndex).Values(0)
        IDCONTRATO = Me.gvP.DataKeys(e.NewSelectedIndex).Values(1)

        Me.pnMan.Visible = True

        Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        Me.gvRenglones.DataSource = cIM.ObtenerLotesNotificadosRetiro(IDESTABLECIMIENTO, IDPROVEEDOR, Session.Item("IdEmpleado"), IDPROCESOCOMPRA, IDCONTRATO)
        Me.gvRenglones.DataBind()

    End Sub

    'Protected Sub gvRenglones_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvRenglones.RowDeleting
    '    Dim IDINFORME As Integer = Me.gvRenglones.DataKeys(e.RowIndex).Values(0)

    '    Dim CIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
    '    Try
    '        CIM.EliminarINFORMEMUESTRAS(IDESTABLECIMIENTO, IDINFORME)
    '    Catch ex As Exception

    '    End Try
    '    Me.gvRenglones.DataSource = Nothing
    '    Me.gvRenglones.SelectedIndex = -1
    '    Me.gvRenglones.DataBind()

    'End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.gvRenglones.Rows.Count <> 0 Then
            ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptRetiroMuestrasAnalisis.aspx?IdPC=" & IDPROCESOCOMPRA & "&idE=" & IDESTABLECIMIENTO & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');</script>")
        Else
            Me.MsgBox1.ShowAlert("No existen lotes registrados.", "d", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        For Each gvr As GridViewRow In Me.gvRenglones.Rows
            Dim chk As New CheckBox
            chk = CType(gvr.Cells(4).Controls(1), CheckBox)
            chk.Checked = True
        Next
    End Sub

    Protected Sub ddlEMPLEADOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEMPLEADOS1.SelectedIndexChanged
        Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        Me.gvRenglones.DataSource = cIM.ObtenerLotesNotificadosXInspector(IDESTABLECIMIENTO, IDPROVEEDOR, Me.ddlEMPLEADOS1.SelectedValue, IDPROCESOCOMPRA, IDCONTRATO)
        Me.gvRenglones.DataBind()
    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If Me.gvRenglones.Rows.Count <> 0 Then
    '        Try
    '            For Each gvr As GridViewRow In Me.gvRenglones.Rows
    '                Dim chk As New CheckBox
    '                chk = CType(gvr.Cells(4).Controls(1), CheckBox)
    '                Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
    '                If chk.Checked Then
    '                    cIM.ActualizarInspector(Session("IdEstablecimiento"), gvRenglones.DataKeys(gvr.DataItemIndex).Values(0), Me.ddlEMPLEADOS1.SelectedValue, User.Identity.Name)
    '                Else
    '                    cIM.ActualizarInspector(Session("IdEstablecimiento"), gvRenglones.DataKeys(gvr.DataItemIndex).Values(0), 0, User.Identity.Name)
    '                End If
    '            Next
    '            Me.MsgBox1.ShowAlert("La asignación de lotes se realizó satisfactoriamente", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        Catch ex As Exception
    '            Me.MsgBox1.ShowAlert("Ocurrió un error al asignar los lotes.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        End Try
    '    End If
    'End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        For Each gvr As GridViewRow In Me.gvRenglones.Rows
            Dim chk As New CheckBox
            chk = CType(gvr.Cells(4).Controls(1), CheckBox)
            chk.Checked = False
        Next
    End Sub
End Class
