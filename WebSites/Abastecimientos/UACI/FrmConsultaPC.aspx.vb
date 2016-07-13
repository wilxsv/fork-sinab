
Partial Class UACI_FrmConsultaPC
    Inherits System.Web.UI.Page

    Dim cPC As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            cargardatos(0)
        End If
    End Sub

    Public Sub cargardatos(ByVal flag As Integer)
        Select Case flag
            Case Is = 0
                Me.GridView1.DataSource = cPC.ObtenerPC_Solicitud(Session("IdEstablecimiento"), 0, "")
            Case Is = 1
                Me.GridView1.DataSource = cPC.ObtenerPC_Solicitud(Session("IdEstablecimiento"), 1, Me.TextBox1.Text)
            Case Is = 2
                Me.GridView1.DataSource = cPC.ObtenerPC_Solicitud(Session("IdEstablecimiento"), 2, Me.TextBox1.Text)
            Case Is = 3
                Me.GridView1.DataSource = cPC.ObtenerPC_Solicitud(Session("IdEstablecimiento"), 3, Me.TextBox1.Text)
            Case Is = 4
                Me.GridView1.DataSource = cPC.ObtenerPC_Solicitud(Session("IdEstablecimiento"), 4, Me.TextBox1.Text)
        End Select
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        Me.cargardatos(Me.DropDownList1.SelectedValue)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IdSolicitud As Integer = Me.GridView1.DataKeys(e.Row.RowIndex).Values.Item("IDSOLICITUD")

            Dim gv As GridView = CType(e.Row.FindControl("GridView2"), GridView)

            gv.DataSource = cPC.ObtenerFF_Solicitud(Session("IdEstablecimiento"), IdSolicitud)
            gv.DataBind()
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.TextBox1.Text = "" And Me.DropDownList1.SelectedValue > 0 Then
            Exit Sub
        End If
        cargardatos(Me.DropDownList1.SelectedValue)
    End Sub

End Class
