Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Catalogos_wfCatProducto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Me.DdlSUMINISTROS1.RecuperarListaFiltrada(1)
            Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.DdlSUMINISTROS1.SelectedValue)
            Me.DdlSUBGRUPOS1.RecuperarListaFiltrada(Me.DdlGRUPOS1.SelectedValue)
        End If
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Protected Sub DdlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlSUMINISTROS1.SelectedIndexChanged
        Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.DdlSUMINISTROS1.SelectedValue)
        Me.DdlSUBGRUPOS1.RecuperarListaFiltrada(Me.DdlGRUPOS1.SelectedValue)
    End Sub

    Protected Sub DdlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlGRUPOS1.SelectedIndexChanged
        Me.DdlSUBGRUPOS1.RecuperarListaFiltrada(Me.DdlGRUPOS1.SelectedValue)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DdlSUMINISTROS1.Enabled = False
        Me.DdlGRUPOS1.Enabled = False
        Me.DdlSUBGRUPOS1.Enabled = False

        Dim cs As New cSUMINISTROS
        Dim cg As New cGRUPOS
        Dim cgs As New cSUBGRUPOS

        Me.Panel1.Visible = True
        Me.Label5.Text = CS.DevolverCORRSuministro(Me.DdlSUMINISTROS1.SelectedValue) & cg.DevolverCorrgRUPO(Me.DdlGRUPOS1.SelectedValue) & cgs.DevolverCORRSUBGRUPO(DdlSUBGRUPOS1.SelectedValue)
        If Me.DdlSUMINISTROS1.SelectedValue = "1" Then
            Session("Sololetras") = True
        Else
            Session("Sololetras") = False
        End If
        Me.DropDownList1.DataBind()

        Me.DdlUNIDADMEDIDAS1.RecuperarPorSuministro(Me.DdlSUMINISTROS1.SelectedValue)

        Me.Panel1.Visible = True

        Dim cC As New cCATALOGOPRODUCTOS

        Dim num As Integer
        num = Right(cC.ObtenerProximoCorrProducto(Me.DdlSUBGRUPOS1.SelectedValue), 3) + 1

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

        'Me.NumericBox1.Text = Right(cC.ObtenerProximoCorrProducto(CSUB.DevolverIdSUBGRUPO(Me.DdlSUBGRUPOS1.SelectedValue)), 3)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cCP As New cCATALOGOPRODUCTOS
        Dim CP As New CATALOGOPRODUCTOS
        Try
            'CP.IDPRODUCTO = Me.Label5.Text & Me.NumericBox1.Text
            CP.CODIGO = Me.Label5.Text & CStr(Me.NumericBox1.Text)
            Dim cs As New cSUBGRUPOS
            CP.IDTIPOPRODUCTO = Me.DdlSUBGRUPOS1.SelectedValue
            CP.IDUNIDADMEDIDA = Me.DdlUNIDADMEDIDAS1.SelectedValue
            CP.NOMBRE = Me.TextBox1.Text
            CP.NIVELUSO = Me.DropDownList1.SelectedValue
            CP.CONCENTRACION = Me.TextBox2.Text
            CP.FORMAFARMACEUTICA = Me.TextBox3.Text
            CP.PRESENTACION = Me.TextBox4.Text
            CP.PRIORIDAD = Me.DropDownList3.SelectedValue
            CP.PRECIOACTUAL = CDec(Me.NumericBox3.Text)
            CP.APLICALOTE = Me.DropDownList2.SelectedValue
            CP.EXISTENCIAACTUAL = 0
            CP.CODIGONACIONESUNIDAS = Me.TextBox5.Text
            If Me.CheckBox1.Checked Then
                CP.PERTENECELISTADOOFICIAL = 1
            Else
                CP.PERTENECELISTADOOFICIAL = 0
            End If

            If Me.CheckBox2.Checked Then
                CP.ESTADOPRODUCTO = 1
            Else
                CP.ESTADOPRODUCTO = 0
            End If

            CP.OBSERVACION = Me.TextBox6.Text

            cCP.ActualizarCATALOGOPRODUCTOS(CP)

            If Me.CheckBox2.Checked Then
                Dim IDproducto As Integer
                IDproducto = cCP.ObtenerIDPRODUCTO

                Dim cNE As New cNIVELESUSOESTABLECIMIENTOS
                Dim dsE As Data.DataSet

                dsE = cNE.DevolverEstablecimientos(Me.DropDownList1.SelectedValue)

                Dim cPE As New cPRODUCTOSESTABLECIMIENTOS
                Dim pe As New PRODUCTOSESTABLECIMIENTOS

                Dim dr As Data.DataRow = dsE.Tables(0).NewRow
                'por cada establecimiento en nivelesdeusoestablecimientos, hace la insercion en productosestablecimientos
                For Each dr In dsE.Tables(0).Rows
                    pe.IDESTABLECIMIENTO = dr(0)
                    pe.OBSERVACION = "Producto creado"
                    pe.FECHA = Today
                    pe.ESTAHABILITADO = 1
                    pe.IDPRODUCTO = IDproducto
                    cPE.AgregarPRODUCTOSESTABLECIMIENTOS(pe)
                Next
            End If

            Me.MsgBox1.ShowAlert("El producto ha sido agregado al catálogo de productos del sistema.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        Catch ex As Exception
            Me.MsgBox1.ShowAlert("" & ex.Message & "", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        End Try
        


    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Panel1.Visible = False
        Me.Label5.Text = ""
        Me.NumericBox1.Text = ""
        Me.DdlSUBGRUPOS1.SelectedIndex = -1
        Me.DdlUNIDADMEDIDAS1.SelectedIndex = -1
        Me.TextBox1.Text = ""
        Me.DropDownList1.SelectedIndex = -1
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""
        Me.TextBox4.Text = ""
        'Me.NumericBox2.Text = ""
        Me.NumericBox3.Text = ""
        Me.DropDownList2.SelectedIndex = -1
        Me.NumericBox4.Text = ""
        Me.TextBox5.Text = ""
        Me.TextBox6.Text = ""
        Me.CheckBox1.Checked = False
        Me.CheckBox2.Checked = False

        Me.DdlSUMINISTROS1.Enabled = True
        Me.DdlGRUPOS1.Enabled = True
        Me.DdlSUBGRUPOS1.Enabled = True
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "A" Then
            Button3_Click(sender, e)
            Response.Redirect("~/Catalogos/wfManCatProductos.aspx")
        End If
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Response.Redirect("~/Catalogos/wfManCatProductos.aspx")
    End Sub
End Class