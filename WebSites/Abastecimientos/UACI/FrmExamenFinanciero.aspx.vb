Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class frmExamenFinanciero
    Inherits System.Web.UI.Page

    Private _NRevisionFinanciera As Integer

    Public Property NRevisionFinanciera() As Integer
        Get
            Return Me._NRevisionFinanciera
        End Get
        Set(ByVal value As Integer)
            Me._NRevisionFinanciera = value
            If Not Me.ViewState("NRevisionFinanciera") Is Nothing Then Me.ViewState.Remove("NRevisionFinanciera")
            Me.ViewState.Add("NRevisionFinanciera", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Dim cPC As New cPROCESOCOMPRAS
            Dim dss As New Data.DataSet
            cPC.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), dss)

            Me.Label37.Text = dss.Tables(0).Rows(0).Item(0)
            Me.Label45.Text = dss.Tables(0).Rows(0).Item(1)
            Me.Label4.Text = dss.Tables(0).Rows(0).Item(3)
            Me.Label5.Text = dss.Tables(0).Rows(0).Item(4)

        Else
            If Not Me.ViewState("NRevisionFinanciera") Is Nothing Then Me._NRevisionFinanciera = Me.ViewState("NRevisionFinanciera")
        End If

        Me.UcAnalisisOFertas1.CargarAnalisisFinanciero()

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub UcAnalisisOFertas1_SelectedIndexChanged() Handles UcAnalisisOFertas1.SelectedIndexChanged
        Dim idproveedor As Integer
        idproveedor = UcAnalisisOFertas1.IDPROVEEDOR
        Me.Label7.Text = Me.UcAnalisisOFertas1.IDPROVEEDOR
        Me.Panel1.Visible = True
        Me.Label10.Text = "OFerta # " & UcAnalisisOFertas1.ORDENLLEGADA & " "

        Dim cEO As New cEXAMENOFERTA
        Dim EO As Data.DataSet
        EO = cEO.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.UcAnalisisOFertas1.IDPROVEEDOR)

        If EO.Tables(0).Rows.Count = 0 Then

            Dim mComponente As New cOFERTAPROCESOCOMPRA
            Dim ds As Data.DataSet
            ds = mComponente.ObtenerInfoFinanciera(Session("IdEstablecimiento"), Request.QueryString("idProc"), UcAnalisisOFertas1.IDPROVEEDOR)

            If IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                Me.Label8.Visible = True
                Me.Panel1.Visible = False
            Else
                Me.Label8.Visible = False
                'DATOS FINANCIEROS

                Me.NumericBox5.Text = ds.Tables(0).Rows(0).Item(0)
                Me.NumericBox3.Text = ds.Tables(0).Rows(0).Item(1)
                Me.NumericBox2.Text = ds.Tables(0).Rows(0).Item(2)
                Me.NumericBox4.Text = ds.Tables(0).Rows(0).Item(3)

                Me.NumericBox5.Enabled = True
                Me.NumericBox3.Enabled = True
                Me.NumericBox2.Enabled = True
                Me.NumericBox4.Enabled = True

                'REFERENCIAS BANCARIAS NO=0 y SI=1
                If ds.Tables(0).Rows(0).Item(4) = 0 Then
                    Me.RadioButtonList2.SelectedValue = 0
                    Me.Label30.Text = 0
                    Me.RadioButtonList2.Enabled = True
                Else
                    Me.RadioButtonList2.SelectedValue = 1
                    Me.RadioButtonList2.Enabled = True
                End If
                NRevisionFinanciera = 0
                CalculosIndices(Me.NumericBox5.Text, Me.NumericBox2.Text, Me.NumericBox3.Text, Me.NumericBox4.Text)
            End If

        Else
            Me.Label8.Visible = False
            Dim cOPC As New cOFERTAPROCESOCOMPRA
            Dim OPC As Data.DataSet
            OPC = cOPC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.UcAnalisisOFertas1.IDPROVEEDOR)
            Me.NumericBox5.Text = OPC.Tables(0).Rows(0).Item(8)
            Me.NumericBox2.Text = OPC.Tables(0).Rows(0).Item(10)
            Me.NumericBox3.Text = OPC.Tables(0).Rows(0).Item(9)
            Me.NumericBox4.Text = OPC.Tables(0).Rows(0).Item(11)
            Me.Button3.Enabled = True

            If EO.Tables(0).Rows(0).Item(9) = 0 Then
                Me.RadioButtonList2.SelectedValue = 0
                Me.Label30.Text = 0
            Else
                Me.RadioButtonList2.SelectedValue = 1

            End If
            CalculosIndices(Me.NumericBox5.Text, Me.NumericBox2.Text, Me.NumericBox3.Text, Me.NumericBox4.Text)
            NRevisionFinanciera = 1
            If IsDBNull(EO.Tables(0).Rows(0).Item(11)) Then
                Me.TextBox1.Text = ""
            Else
                Me.TextBox1.Text = EO.Tables(0).Rows(0).Item(11)
            End If

        End If

    End Sub

    Public Sub CalculosIndices(ByVal AC As Decimal, ByVal AT As Decimal, ByVal PC As Decimal, ByVal PT As Decimal)

        'PORCENTAJES
        Dim cmPC As New cPROCESOCOMPRAS
        Dim PrC As New PROCESOCOMPRAS
        PrC = cmPC.ObtenerPROCESOCOMPRAS(Session("IdEstablecimiento"), Request.QueryString("idProc"))
        Dim r1 As String
        If PC = 0 Then
            r1 = 0
            Me.Label23.Text = FormatNumber(0, 2)
            Me.Label24.Text = 0
        Else
            If AC / PC < 1 Then
                r1 = AC / PC
                Me.Label23.Text = FormatNumber(AC / PC, 2)
                Me.Label24.Text = 0
            Else
                Me.Label23.Text = FormatNumber(AC / PC, 2)
                Me.Label24.Text = PrC.PORCENTAJEINDICESOLVENCIA
            End If
        End If

        ' 10% DEL MONTO OFERTADO
        Dim cDO As New cDETALLEOFERTA
        Dim monto As Decimal
        monto = cDO.ObtenerMontoOfertado(Request.QueryString("idProc"), Session("IdEstablecimiento"), Me.Label7.Text)

        If (AC - PC) < 10 Then

            ''ok (((AC - PC) / monto) * 100) < 10 Then

            '((AC - PC)) * 100 / monto < 10 Then
            'Me.Label25.Text = FormatNumber(((AC - PC) * 100) / monto, 2)
            ''Me.Label25.Text = FormatNumber((((AC - PC) / monto) * 100), 2)
            Me.Label25.Text = FormatNumber((AC - PC), 2)
            Me.Label26.Text = 0
        Else
            ''OK Me.Label25.Text = FormatNumber((((AC - PC) / monto) * 100), 2)
            Me.Label25.Text = FormatNumber((AC - PC), 2)
            Me.Label26.Text = PrC.PORCENTAJECAPITALTRABAJO
        End If
        If AT = 0 Then
            Me.Label27.Text = FormatNumber(0, 2)
            Me.Label28.Text = 0
        Else
            If PT / AT > 1 Then
                Me.Label27.Text = FormatNumber(PT / AT, 2)
                Me.Label28.Text = 0
            Else
                Me.Label27.Text = FormatNumber(PT / AT, 2)
                Me.Label28.Text = PrC.PORCENTAJEENDEUDAMIENTO
            End If
            'se adiciona cuando sea igual a 1
            If PT / AT = 1 Then
               
                Me.Label27.Text = FormatNumber(PT / AT, 2)
                Me.Label28.Text = PrC.PORCENTAJEENDEUDAMIENTO
            End If

        End If

        'If Me.RadioButtonList2.SelectedValue = 1 Then (Eduardo cambio de 1 x 0 15/08/07)
        If Me.RadioButtonList2.SelectedValue = 0 Then
            Me.Label30.Text = 0
        Else
            Me.Label30.Text = PrC.PORCENTAJEREFERENCIASBANC
        End If

        Me.Label31.Text = CDec(Me.Label24.Text) + CDec(Me.Label26.Text) + CDec(Me.Label28.Text) + CDec(Me.Label30.Text)


    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        CalculosIndices(Me.NumericBox5.Text, Me.NumericBox2.Text, Me.NumericBox3.Text, Me.NumericBox4.Text)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'If Me.NumericBox5.Text = "" Or Me.NumericBox2.Text = "" Or Me.NumericBox3.Text = "" Or Me.NumericBox4.Text = "" Or Me.TextBox1.Text = "" Then
        '    Me.MsgBox1.ShowAlert("Hay información pendiente de completar para guardar el análisis financiero.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        '    Exit Sub
        'End If

        Dim examenoferta As New EXAMENOFERTA
        Dim mEO As New cEXAMENOFERTA
        examenoferta.INDICESOLVENCIA = CDec(Me.Label23.Text)
        examenoferta.PONDERACIONSOLVENCIA = CDec(Me.Label24.Text)
        examenoferta.CAPITALTRABAJO = CDec(Me.Label25.Text)
        examenoferta.PONDERACIONCAPITAL = CDec(Me.Label26.Text)
        examenoferta.INDICEENDEUDAMIENTO = CDec(Me.Label27.Text)
        examenoferta.PONDERACIONENDEUDAMIENTO = CDec(Me.Label28.Text)
        examenoferta.REFERENCIABANCARIA = Me.RadioButtonList2.SelectedValue
        examenoferta.PONDERACIONREFERENCIA = CDec(Me.Label30.Text)
        'If NRevisionFinanciera = 0 Then
        examenoferta.NUMEROEXAMEN = 1
        If NRevisionFinanciera = 1 Then
            examenoferta.NUMEROEXAMEN = 2
        End If

        examenoferta.ESTASINCRONIZADA = 0

        examenoferta.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        examenoferta.IDPROCESOCOMPRA = Request.QueryString("idProc")
        examenoferta.IDPROVEEDOR = Me.Label7.Text
        examenoferta.OBSERVACION = Me.TextBox1.Text

        If NRevisionFinanciera = 0 Then
            mEO.AgregarEXAMENOFERTA(examenoferta)
        ElseIf NRevisionFinanciera = 1 Then
            mEO.ActualizarEXAMENOFERTA(examenoferta)
        End If


        Dim cOPC As New cOFERTAPROCESOCOMPRA
        Dim OPC As New OFERTAPROCESOCOMPRA
        OPC.ACTIVOCIRCULANTE = Me.NumericBox5.Text
        OPC.PASIVOCIRCULANTE = Me.NumericBox3.Text
        OPC.ACTIVOTOTAL = Me.NumericBox2.Text
        OPC.PASIVOTOTAL = Me.NumericBox4.Text
        OPC.FECHAEXAMEN = DateTime.Now

        OPC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        OPC.IDPROCESOCOMPRA = Request.QueryString("idProc")
        OPC.IDPROVEEDOR = Me.Label7.Text

        cOPC.ActualizarInfoFinanciera(OPC)

        Me.TextBox1.Text = ""
        Me.TextBox1.Enabled = True

        Me.MsgBox1.ShowAlert("Análisis Financiero guardado satisfactoriamente.", "B", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "A" Then
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
        If e.Key = "B" Then
            Me.Panel1.Visible = False
            Me.UcAnalisisOFertas1.CargarAnalisisFinanciero()
            Me.UcAnalisisOFertas1.Deseleccionar()
        End If
    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        SINAB_Utils.Utils.MostrarVentana("/Reportes/frmrptExamenEvalFinanciero.aspx?id=" & Request.QueryString("idProc"))

        'Response.Write("<script language=javascript>")
        'Response.Write("window.open('" + Request.ApplicationPath + "/Reportes/frmrptExamenEvalFinanciero.aspx?id=" & Request.QueryString("idProc") & "');")
        'Response.Write("</script>")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim NOfertas As Integer = Me.UcAnalisisOFertas1.NumProveedores()

        Dim cEO As New cEXAMENOFERTA
        Dim dsEO As Data.DataSet
        dsEO = cEO.ObtenerProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        If Not NOfertas = dsEO.Tables(0).Rows(0).Item(0) Then
            '    Me.MsgBox1.ShowConfirm("Atención! Si finaliza la evaluación en este momento, ya no podrá modificar los resultados del análisis legal.  Confirma que desea finalizar esta evaluación? ", "Z", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
            'Else
            Me.MsgBox2.ShowAlert("Existen Ofertas que no han sido evaluadas todavía.", "V", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            Exit Sub
        End If

        '-----CHEQUEAR ESTADO PROCESO COMPRA
        Dim cPC As New cPROCESOCOMPRAS
        Dim pc As New PROCESOCOMPRAS
        Dim Estado As Integer
        Estado = cPC.ChequearEstadosPC(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        'Dim NOfertas As Integer = Me.UcAnalisisOFertas1.NumProveedores()

        'analisis financiero
        Dim cEO1 As New cEXAMENOFERTA
        Dim dsFinanciero As Data.DataSet
        dsFinanciero = cEO1.ObtenerProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        'analisis legal
        Dim cDO As New cDOCUMENTOSOFERTA
        Dim dsLegal As Data.DataSet
        dsLegal = cDO.ObtenerProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        'analisis tecnico
        Dim mC As New cOFERTAPROCESOCOMPRA
        Dim dste As Data.DataSet
        dste = mC.ObtenerOrdenLLegada(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        Dim drTe As Data.DataRow = dste.Tables(0).NewRow
        Dim cDOR As New cEXAMENRENGLON
        Dim Resultado As Boolean
        Dim dsTecnico As Integer = 0
        For Each drTe In dste.Tables(0).Rows
            Resultado = cDOR.ChequeoAnalisisCompletoXProveedor(Session("IdEstablecimiento"), Request.QueryString("idProc"), drTe(1))
            If Resultado = True Then
                'YA ESTA ANALIZADO EL PROVEEDOR
                dsTecnico += 1
            End If
        Next


        If NOfertas = dsFinanciero.Tables(0).Rows(0).Item(0) And _
           NOfertas = dsLegal.Tables(0).Rows(0).Item(0) And _
           NOfertas = dsTecnico Then
            'TODOS LOS EXAMENES ESTAN COMPLETOS
            Me.MsgBox1.ShowConfirm("Atención! Si finaliza la evaluación en este momento, ya no podrá modificar este análisis.  Confirma que desea finalizar esta evaluación? ", "Z", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        Else
            'ALGUN EXAMEN FALTA = NO SE HACE NADA
            Me.MsgBox1.ShowAlert("El análisis financiero ha finalizado satisfactoriamente, pero aún esta pendiente de finalización los análisis legal y/o Técnico.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        End If



    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

        If e.Key = "Z" Then
            '-----CHEQUEAR ESTADO PROCESO COMPRA
            Dim cPC As New cPROCESOCOMPRAS
            Dim pc As New PROCESOCOMPRAS
            Dim Estado As Integer
            Estado = cPC.ChequearEstadosPC(Request.QueryString("idProc"), Session("IdEstablecimiento"))

            If Estado = eESTADOPROCESOSCOMPRAS.COMISIONDEEVALUACIONINGRESADA Then
                'TODOS LOS EXAMENES ESTAN COMPLETOS + YA ESTA LA COMISION INGRESADA = CAMBIO DE ESTADO A REC.COMPRA
                pc.IDPROCESOCOMPRA = Request.QueryString("idProc")
                pc.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                pc.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA
                pc.FECHAFINEXAMEN = DateTime.Now
                cPC.ActualizarEstado(pc, 0)
                Me.MsgBox1.ShowAlert("Análisis Financiero finalizado satisfactoriamente. Todos los análisis para este proceso de compras han sido finalizados.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            Else
                'NO SE HA INGRESADO A LA COMISION TODAVIA = cambia estado exam. finalizado
                pc.IDPROCESOCOMPRA = Request.QueryString("idProc")
                pc.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                pc.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINARFINALIZADO
                pc.FECHAFINEXAMEN = DateTime.Now
                cPC.ActualizarEstado(pc, 0)
                Me.MsgBox1.ShowAlert("Análisis Financiero finalizado satisfactoriamente. Todos los análisis para este proceso de compras han sido finalizados.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            End If
        End If

    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Response.Write("<script language=javascript>")
        'Response.Write("window.open('" + Request.ApplicationPath + "/Reportes/frmrptExamenFinanciero.aspx?id=" & Request.QueryString("idProc") & "');")
        'Response.Write("</script>")
        SINAB_Utils.Utils.MostrarVentana("/Reportes/frmrptExamenFinanciero.aspx?id=" & Request.QueryString("idProc"))
    End Sub

End Class
