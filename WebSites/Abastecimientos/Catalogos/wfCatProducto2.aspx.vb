Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Catalogos_wfCatProducto2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Me.ddlSUMINISTROS1.RecuperarListaFiltrada(1, 1)
            Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
            Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.ddlSUMINISTROS1.Enabled = False
        Me.ddlGRUPOS1.Enabled = False
        Me.ddlSUBGRUPOS1.Enabled = False

        Dim cs As New cSUMINISTROS
        Dim cg As New cGRUPOS
        Dim cgs As New cSUBGRUPOS

        Me.Panel1.Visible = True
        Me.Label5.Text = cs.DevolverCorrSuministro(Me.ddlSUMINISTROS1.SelectedValue) & cg.DevolverCORRgRUPO(Me.ddlGRUPOS1.SelectedValue) & cgs.DevolverCORRSUBGRUPO(ddlSUBGRUPOS1.SelectedValue)
        If Me.ddlSUMINISTROS1.SelectedValue = "1" Then
            Session("Sololetras") = True
        Else
            Session("Sololetras") = False
        End If

        Me.ddlUNIDADMEDIDAS1.RecuperarPorSuministro(Me.ddlSUMINISTROS1.SelectedValue)

        Me.Panel1.Visible = True

        Dim cC As New cCATALOGOPRODUCTOS

        Dim num As Integer
        Try
            num = Right(cC.ObtenerProximoCorrProducto(Me.ddlSUBGRUPOS1.SelectedValue), 3) + 1
            Me.Label5.Visible = True
            Me.RequiredFieldValidator1.Visible = True

            Me.TextBox7.Visible = False
            Me.RequiredFieldValidator6.Visible = False

            If Me.Label5.Text.Length = 4 Then
                If Len(CStr(num)) = 2 Then
                    Me.NumericBox1.Text = "00" & CStr(num)
                ElseIf Len(CStr(num)) = 3 Then
                    Me.NumericBox1.Text = "0" & CStr(num)
                ElseIf Len(CStr(num)) = 1 Then
                    Me.NumericBox1.Text = "000" & CStr(num)
                End If
            Else
                If Len(CStr(num)) = 2 Then
                    Me.NumericBox1.Text = "0" & CStr(num)
                ElseIf Len(CStr(num)) = 3 Then
                    Me.NumericBox1.Text = CStr(num)
                ElseIf Len(CStr(num)) = 1 Then
                    Me.NumericBox1.Text = "00" & CStr(num)
                End If
            End If
        Catch ex As Exception
            Me.Label5.Visible = False
            Me.NumericBox1.Visible = False
            Me.TextBox7.Visible = True
            Me.RequiredFieldValidator6.Visible = True
            Me.RequiredFieldValidator1.Visible = False
        End Try

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim cCP As New cCATALOGOPRODUCTOS
        Dim CP As New CATALOGOPRODUCTOS

        If cCP.ExisteCodigo(Me.TextBox7.Text) Then
            Me.MsgBox1.ShowAlert("Este código ya existe para un producto.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Try

            If Me.Label5.Visible = True Then
                CP.CODIGO = Me.Label5.Text & CStr(Me.NumericBox1.Text)
            Else
                CP.CODIGO = Me.TextBox7.Text
            End If

            Dim cs As New cSUBGRUPOS
            CP.IDTIPOPRODUCTO = Me.ddlSUBGRUPOS1.SelectedValue
            CP.IDUNIDADMEDIDA = Me.ddlUNIDADMEDIDAS1.SelectedValue
            CP.NOMBRE = Me.txtNOMBRE.Text
            CP.NIVELUSO = 7
            CP.CONCENTRACION = ""
            CP.FORMAFARMACEUTICA = ""
            CP.PRESENTACION = ""
            CP.PRIORIDAD = 1
            CP.PRECIOACTUAL = CDec(Me.nbPRECIOACTUAL.Text)
            CP.APLICALOTE = IIf(cbAPLICALOTE.Checked, 1, 0)
            CP.EXISTENCIAACTUAL = 0
            CP.PERTENECELISTADOOFICIAL = 1
            CP.ESTADOPRODUCTO = IIf(Me.cbESTADOPRODUCTO.Checked, 1, 0)

            CP.OBSERVACION = Me.txtOBSERVACION.Text

            cCP.ActualizarCATALOGOPRODUCTOS(CP)

            Me.MsgBox1.ShowAlert("El producto ha sido agregado al catálogo de productos del sistema.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        Catch ex As Exception
            Me.MsgBox1.ShowAlert(ex.Message, "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        End Try

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Panel1.Visible = False
        Me.Label5.Text = ""
        Me.NumericBox1.Text = ""
        Me.ddlSUBGRUPOS1.SelectedIndex = -1
        Me.ddlUNIDADMEDIDAS1.SelectedIndex = -1
        Me.txtNOMBRE.Text = ""
        Me.nbPRECIOACTUAL.Text = ""
        Me.txtOBSERVACION.Text = ""
        Me.cbAPLICALOTE.Checked = False
        Me.cbESTADOPRODUCTO.Checked = False

        Me.ddlSUMINISTROS1.Enabled = True
        Me.ddlGRUPOS1.Enabled = True
        Me.ddlSUBGRUPOS1.Enabled = True
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "A" Then
            Button3_Click(sender, e)
            Response.Redirect("~/Catalogos/wfManCatProductos2.aspx")
        End If
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Response.Redirect("~/Catalogos/wfManCatProductos2.aspx")
    End Sub

End Class