Imports ABASTECIMIENTOS.NEGOCIO

Partial Class UACI_RenglonesXOferta
    Inherits System.Web.UI.Page

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Dim mComponente As New cRECEPCIONOFERTAS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim ds As Data.DataSet
            ds = mComponente.ObtenerDataSet_OfertasRecibidas(Request.QueryString("idProc"), Session("IDEstablecimiento"))

            Me.dgOfertaPresentada.DataSource = ds
            Me.dgOfertaPresentada.DataBind()
        End If

    End Sub

    Protected Sub dgOfertaPresentada_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgOfertaPresentada.PageIndexChanging
        Me.dgOfertaPresentada.PageIndex = e.NewPageIndex
        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDataSet_OfertasRecibidas(Request.QueryString("idProc"), Session("IDEstablecimiento"))
        Me.dgOfertaPresentada.DataSource = ds
        Me.dgOfertaPresentada.DataBind()
    End Sub

    Protected Sub dgOfertaPresentada_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles dgOfertaPresentada.SelectedIndexChanging
        Dim idproveedor As Integer

        idproveedor = Me.dgOfertaPresentada.DataKeys(e.NewSelectedIndex).Item("IDPROVEEDOR")

        ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptHojaAnalisisXProveedor.aspx?idP=" & idproveedor & "&id=" & Request.QueryString("idProc") & "&opc=1" & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")

    End Sub

End Class
