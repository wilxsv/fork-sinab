Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmExamenLegal
    Inherits System.Web.UI.Page

    Private mComponente As New cDOCUMENTOSOFERTA

    Private _IDPROVEEDOR As Integer
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim cPC As New cPROCESOCOMPRAS
            Dim dss As New Data.DataSet
            cPC.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), dss)

            Dim IDTIPODOCUMENTOBASE As Integer() = {1, 2, 8, 9}
            Me.ddlTIPODOCUMENTOBASE1.RecuperarListaPorProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDTIPODOCUMENTOBASE)

            Me.Label37.Text = dss.Tables(0).Rows(0).Item(0)
            Me.Label45.Text = dss.Tables(0).Rows(0).Item(1)
            Me.Label4.Text = dss.Tables(0).Rows(0).Item(3)
            Me.Label5.Text = dss.Tables(0).Rows(0).Item(4)
        Else
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
        End If

        Me.UcAnalisisOFertas1.CargarAnalisisLegal()

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub UcAnalisisOFertas1_SelectedIndexChanged() Handles UcAnalisisOFertas1.SelectedIndexChanged

        IDPROVEEDOR = UcAnalisisOFertas1.IDPROVEEDOR
        Dim cad = "/Reportes/frmrptDocumentosOferta.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString
        btnImprimirAnalisisLegal.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
        '"window.open('" + Request.ApplicationPath + "/Reportes/frmrptDocumentosOferta.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; "
        cbVerTodos.Checked = False

        Me.pnLegal.Visible = True

        Me.Label10.Text = "Oferta # " & UcAnalisisOFertas1.ORDENLLEGADA & " "

        CargarDatos()

    End Sub

    Protected Sub btnCumplenTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCumplenTodos.Click
        For i As Integer = 0 To Me.GridView1.Rows.Count - 1
            CType(Me.GridView1.Rows(i).FindControl("DropDownList4"), DropDownList).SelectedValue = 1
        Next
    End Sub

    Protected Sub btnNoCumplenTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoCumplenTodos.Click
        For i As Integer = 0 To Me.GridView1.Rows.Count - 1
            CType(Me.GridView1.Rows(i).FindControl("DropDownList4"), DropDownList).SelectedValue = 2
        Next
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        For Each row As GridViewRow In GridView1.Rows

            Dim IDDOCUMENTOBASE As Integer = Me.GridView1.DataKeys(row.RowIndex).Values.Item("IDDOCUMENTOBASE")
            Dim ENTREGADO1 As Integer = CType(row.FindControl("DropDownList4"), DropDownList).SelectedValue

            Dim eDO As New DOCUMENTOSOFERTA

            eDO.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            eDO.IDPROCESOCOMPRA = Request.QueryString("idProc")
            eDO.IDPROVEEDOR = Me.IDPROVEEDOR
            eDO.IDDOCUMENTOBASE = IDDOCUMENTOBASE
            eDO.ENTREGADO1 = ENTREGADO1

            If CType(row.FindControl("ImageButton1"), ImageButton).Visible Then
                eDO.AUUSUARIOMODIFICACION = User.Identity.Name
                eDO.AUFECHAMODIFICACION = Now
                mComponente.Actualizar2Entrega(eDO)
            Else
                eDO.AUUSUARIOCREACION = User.Identity.Name
                eDO.AUFECHACREACION = Now
                mComponente.AgregarDOCUMENTOSOFERTA(eDO)
            End If

        Next

        Dim cOPC As New cOFERTAPROCESOCOMPRA
        Dim eOPC As New OFERTAPROCESOCOMPRA

        eOPC.IDPROVEEDOR = Me.IDPROVEEDOR
        eOPC.IDPROCESOCOMPRA = Request.QueryString("idProc")
        eOPC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        eOPC.OBSERVACIONDOCUMENTO = Me.txtObservaciones.Text
        eOPC.FECHAEXAMEN = Now
        eOPC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eOPC.AUFECHAMODIFICACION = Now

        cOPC.ActualizarObservacionDocumento(eOPC)

        Me.cbVerTodos.Checked = False

        CargarDatos()

        Me.pnLegal.Visible = False
        Me.UcAnalisisOFertas1.CargarAnalisisLegal()
        Me.UcAnalisisOFertas1.Deseleccionar()

        Me.MsgBox2.ShowAlert("Análisis guardado satisfactoriamente.", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim NOfertas As Integer = Me.UcAnalisisOFertas1.NumProveedores()

        Dim dsdo As Data.DataSet
        dsdo = mComponente.ObtenerProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        If Not NOfertas = dsdo.Tables(0).Rows(0).Item(0) Then
            '    Me.MsgBox1.ShowConfirm("Atención! Si finaliza la evaluación en este momento, ya no podrá modificar los resultados del análisis legal.  Confirma que desea finalizar esta evaluación? ", "Z", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
            'Else
            Me.MsgBox1.ShowAlert("Existen Ofertas que no han sido evaluadas todavía.", "V", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            Exit Sub
        End If

        '-----CHEQUEAR ESTADO PROCESO COMPRA
        Dim cPC As New cPROCESOCOMPRAS
        Dim pc As New PROCESOCOMPRAS
        Dim Estado As Integer
        Estado = cPC.ChequearEstadosPC(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        'Dim NOfertas As Integer = Me.UcAnalisisOFertas1.NumProveedores()

        'analisis financiero
        Dim cEO As New cEXAMENOFERTA
        Dim dsFinanciero As Data.DataSet
        dsFinanciero = cEO.ObtenerProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        'analisis legal

        Dim dsLegal As Data.DataSet
        dsLegal = mComponente.ObtenerProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))

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
            Me.MsgBox1.ShowConfirm("Atención! Si finaliza la evaluación en este momento, ya no podrá modificar los resultados del análisis legal.  Confirma que desea finalizar esta evaluación? ", "Z", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        Else
            'ALGUN EXAMEN FALTA = NO SE HACE NADA
            Me.MsgBox1.ShowAlert("El análisis legal ha finalizado satisfactoriamente, pero aún esta pendiente de finalización los análisis financiero y/o Técnico.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        End If

    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "A" Then
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "Z" Then
            '-----CHEQUEAR ESTADO PROCESO COMPRA
            Dim cPC As New cPROCESOCOMPRAS
            Dim pc As New PROCESOCOMPRAS
            Dim Estado As Integer
            Estado = cPC.ChequearEstadosPC(Request.QueryString("idProc"), Session("IdEstablecimiento"))

            pc.IDPROCESOCOMPRA = Request.QueryString("idProc")
            pc.IDESTABLECIMIENTO = Session("IdEstablecimiento")

            If Estado = eESTADOPROCESOSCOMPRAS.COMISIONDEEVALUACIONINGRESADA Then
                'TODOS LOS EXAMENES ESTAN COMPLETOS + YA ESTA LA COMISION INGRESADA = CAMBIO DE ESTADO A REC.COMPRA
                pc.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA
            Else
                'NO SE HA INGRESADO A LA COMISION TODAVIA = cambia estado exam. finalizado
                pc.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINARFINALIZADO
            End If

            pc.FECHAFINEXAMEN = Now
            pc.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            pc.AUFECHAMODIFICACION = Now
            pc.ESTASINCRONIZADA = 0

            cPC.ActualizarEstado(pc, 0)
            Me.MsgBox1.ShowAlert("Análisis legal finalizado satisfactoriamente. Todos los análisis para este proceso de compras han sido finalizados.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

        End If

    End Sub

    Protected Sub ddlTIPODOCUMENTOBASE1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTIPODOCUMENTOBASE1.SelectedIndexChanged
        CargarDatos()
    End Sub

    Protected Sub cbVerTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodos.CheckedChanged
        Me.txtObservaciones.ReadOnly = Not cbVerTodos.Checked
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        Dim cDB As New cDOCUMENTOSBASE

        Dim ENTREGADO1 As Integer = IIf(cbVerTodos.Checked, 0, 2)

        Dim ds As Data.DataSet = cDB.ObtenerDocumentosProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.IDPROVEEDOR, ddlTIPODOCUMENTOBASE1.SelectedValue, ENTREGADO1)
        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()

        Dim cOPC As New cOFERTAPROCESOCOMPRA
        Me.txtObservaciones.Text = cOPC.ObtenerObservacionDocumento(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDPROVEEDOR)

        ' condicion que muestra o no los botones si el dataset de documentosproceso tieno o no datos
        'el boton guardar siempre sera visible y la observación siempre modificable  segun petición de UACI (Nestor Mejía 160409)
        If ds.Tables(0).Rows.Count = 0 Then
            Me.btnGuardar.Visible = True
            Me.btnCumplenTodos.Visible = False
            Me.btnNoCumplenTodos.Visible = False
            Me.txtObservaciones.ReadOnly = False

        Else
            Me.btnGuardar.Visible = True
            Me.btnCumplenTodos.Visible = True
            Me.btnNoCumplenTodos.Visible = True
            Me.txtObservaciones.ReadOnly = False
        End If


    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        Dim IDDOCUMENTOBASE As Integer = Me.GridView1.DataKeys(e.RowIndex).Values.Item("IDDOCUMENTOBASE")

        mComponente.EliminarDOCUMENTOSOFERTA(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.IDPROVEEDOR, IDDOCUMENTOBASE)

        CargarDatos()
    End Sub

 
End Class
