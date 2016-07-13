'Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class URMIM_frmListaModificacionDistribucion
    Inherits System.Web.UI.Page
    Private cPC As New cPROCESOCOMPRAS
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LlenaGrid()
        End If
    End Sub
    Private Sub LlenaGrid()
        Try
            gvListaModificar.DataSource = cPC.ObtenerDataSetPorHabilitaModDistr(Session("IDEstablecimiento")).Tables(0)
            gvListaModificar.DataBind()
        Catch ex As Exception
            Response.Write("Mensaje:" & ex.Message)
        End Try
    End Sub
    Protected Sub gvListaModificar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvListaModificar.RowCommand
        If e.CommandName = "Finalizar" Then
            lblHideIndexGV.Text = e.CommandArgument
            Me.MsgBox1.ShowConfirm("Confirmar Finalizar Modificaciones", "B", Cooperator.Framework.Web.Controls.ConfirmOption.CallBackOnYes_PostBackOnNo)
            ' Response.Write("argumentos: " & lblHideIndexGV.Text)
            '    Response.Write("Source: " & e.CommandSource.ToString)



        End If
    End Sub

  

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        
    End Sub

    Protected Sub gvListaModificar_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvListaModificar.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim linkBtn As LinkButton = CType(e.Row.FindControl("LinkButton1"), LinkButton)
            linkBtn.OnClientClick = "return confirm('Are you sure you want to delete this entry?');"
        End If
    End Sub

    Protected Sub gvListaModificar_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvListaModificar.RowDeleting
        Dim index As Integer
        Dim IDProcesoCompra As Int64
        Dim IDEstablecimiento As Integer
        index = e.RowIndex
        IDProcesoCompra = gvListaModificar.Rows(index).Cells(1).Text
        IDEstablecimiento = Session("IDEstablecimiento")
        cPC.ActualizarPROCESOCOMPRASMODIFICACIONDISTRIBUCION(IDEstablecimiento, IDProcesoCompra, False)
        Dim script As String = "<script type='text/javascript'>alert('Registro Actualizado satisfactoriamente');</script>"
        Response.Write(script)
        LlenaGrid()
    End Sub
End Class
