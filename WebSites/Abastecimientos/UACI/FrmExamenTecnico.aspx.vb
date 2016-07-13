Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmExamenTecnico
    Inherits System.Web.UI.Page

    Private mComponente As New cEXAMENRENGLON

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
            Dim cTDB As New cTIPODOCUMENTOBASE
            Dim dss As New Data.DataSet
            cPC.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), dss)

            Dim IDTIPODOCUMENTOBASE As Integer() = {3}
            Me.ddlTIPODOCUMENTOBASE1.RecuperarListaPorProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDTIPODOCUMENTOBASE)
            ddlRecTec.DataSource = cTDB.RecuperarListaPorProcesoCompraRecTec(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDTIPODOCUMENTOBASE)
            ddlRecTec.DataTextField = "NOMBRE"
            ddlRecTec.DataValueField = "IDGRUPOREQ"
            ddlRecTec.DataBind()
            ddlRecTec.SelectedValue = 0
            Me.Label37.Text = dss.Tables(0).Rows(0).Item(0)
            Me.Label45.Text = dss.Tables(0).Rows(0).Item(1)
            Me.Label4.Text = dss.Tables(0).Rows(0).Item(3)
            Me.Label5.Text = dss.Tables(0).Rows(0).Item(4)
        Else
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
        End If

        Me.ucAnalisisOfertas1.CargarAnalisisTecnico()

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub UcAnalisisOFertas1_SelectedIndexChanged() Handles ucAnalisisOfertas1.SelectedIndexChanged

        IDPROVEEDOR = ucAnalisisOfertas1.IDPROVEEDOR

        cbVerTodos.Checked = False

        Me.pnTecnico.Visible = True

        Me.Label10.Text = "Oferta # " & ucAnalisisOfertas1.ORDENLLEGADA & " "
        Me.btnPreciosHistoricos.Visible = True

        Me.ddlDETALLEOFERTA1.ObtenerRenglon(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDPROVEEDOR)




        'btnImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; "

        Me.lblNumOferta.Text = " 1 "
        Me.lblTotalOfertas.Text = " " & Me.ddlDETALLEOFERTA1.Items.Count & " "
        Me.lblRenglon.Text = "RENGLON # " & Me.ddlDETALLEOFERTA1.Items(0).Text
        Me.lbAnterior.Visible = False

        CargarDatos()

        Me.pnRenglones.Visible = True

        ''mostrando precios historicos
        Me.btnPreciosHistoricos.Attributes.Add("onclick", SINAB_Utils.Utils.ReferirVentana("/uaci/frmConsultaPrecio.aspx"))
        '"window.open('" + Request.ApplicationPath + "/uaci/frmConsultaPrecio.aspx ','popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")


        Me.lbAnterior.Visible = False
        If Me.ddlDETALLEOFERTA1.Items.Count <> 1 Then
            Me.lbSiguiente.Visible = True
        Else
            Me.lbSiguiente.Visible = False
        End If

    End Sub

    Protected Sub lbSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSiguiente.Click

        Siguiente()

    End Sub

    Protected Sub lbAnterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAnterior.Click

        Me.lbSiguiente.Visible = True
        Me.ddlDETALLEOFERTA1.SelectedIndex -= 1

        'btnImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; "
        Me.lblNumOferta.Text = " " & (Me.ddlDETALLEOFERTA1.SelectedIndex + 1).ToString & " "
        If Me.lblNumOferta.Text = 1 Then Me.lbAnterior.Visible = False
        Me.lblRenglon.Text = "RENGLON # " & Me.ddlDETALLEOFERTA1.SelectedItem.Text

        Me.cbVerTodos.Checked = False

        CargarDatos()

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        For Each row As GridViewRow In GridView1.Rows

            Dim IDDOCUMENTOBASE As Integer = Me.GridView1.DataKeys(row.RowIndex).Values.Item("IDDOCUMENTOBASE")
            Dim ENTREGADO1 As Integer = CType(row.FindControl("DropDownList4"), DropDownList).SelectedValue

            Dim eER As New EXAMENRENGLON

            eER.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            eER.IDPROCESOCOMPRA = Request.QueryString("idProc")
            eER.IDPROVEEDOR = Me.IDPROVEEDOR
            eER.IDDOCUMENTOBASE = IDDOCUMENTOBASE
            eER.IDDETALLE = Me.ddlDETALLEOFERTA1.SelectedValue
            eER.ENTREGADO1 = ENTREGADO1

            If CType(row.FindControl("ImageButton1"), ImageButton).Visible Then
                eER.AUUSUARIOMODIFICACION = User.Identity.Name
                eER.AUFECHAMODIFICACION = Now
                mComponente.Actualizar2Entrega(eER)
            Else
                eER.AUUSUARIOCREACION = User.Identity.Name
                eER.AUFECHACREACION = Now
                mComponente.AgregarEXAMENRENGLON(eER)
            End If

        Next

        Dim cDO As New cDETALLEOFERTA
        Dim eDO As New DETALLEOFERTA

        eDO.IDPROVEEDOR = Me.IDPROVEEDOR
        eDO.IDPROCESOCOMPRA = Request.QueryString("idProc")
        eDO.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        eDO.IDDETALLE = Me.ddlDETALLEOFERTA1.SelectedValue
        eDO.OBSERVACIONDOCUMENTO = Me.txtObservaciones.Text
        eDO.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eDO.AUFECHAMODIFICACION = Now

        cDO.ActualizarObservacionDocumento(eDO)

        If Me.lbSiguiente.Visible Then
            Siguiente()
        Else
            Me.pnTecnico.Visible = False
            Me.ucAnalisisOfertas1.CargarAnalisisTecnico()
            Me.ucAnalisisOfertas1.Deseleccionar()
        End If

        Me.MsgBox3.ShowAlert("Análisis Técnico guardado satisfactoriamente.", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

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

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Response.Write("<script language=javascript>")
    '    Response.Write("window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenTodosRenglon.aspx?id=" & Request.QueryString("idProc") & "');")
    '    Response.Write("</script>")
    'End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "A" Then
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "Z" Then
            '-----CHEQUEAR ESTADO PROCESO COMPRA
            Dim cPC As New cPROCESOCOMPRAS
            Dim ePC As New PROCESOCOMPRAS
            Dim Estado As Integer
            Estado = cPC.ChequearEstadosPC(Request.QueryString("idProc"), Session("IdEstablecimiento"))

            ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")
            ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")

            If Estado = eESTADOPROCESOSCOMPRAS.COMISIONDEEVALUACIONINGRESADA Then
                'TODOS LOS EXAMENES ESTAN COMPLETOS + YA ESTA LA COMISION INGRESADA = CAMBIO DE ESTADO A REC.COMPRA
                ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA
            Else
                'NO SE HA INGRESADO A LA COMISION TODAVIA = cambia estado exam. finalizado
                ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINARFINALIZADO
            End If

            ePC.FECHAFINEXAMEN = Now
            ePC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            ePC.AUFECHAMODIFICACION = Now
            ePC.ESTASINCRONIZADA = 0

            cPC.ActualizarEstado(ePC, 0)
            Me.MsgBox1.ShowAlert("Análisis Técnico finalizado satisfactoriamente. Todos los análisis para este proceso de compras han sido finalizados.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

        End If

    End Sub

    Protected Sub cbVerTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodos.CheckedChanged
        Me.txtObservaciones.ReadOnly = Not cbVerTodos.Checked
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        Dim cPC As New cPROCESOCOMPRAS
        Dim ds2 As New Data.DataSet
        ds2 = cPC.ObtenerTipoSuministro(Request.QueryString("idProc"), Session("IdEstablecimiento"))
        Dim IDRODUCTO As String = String.Empty
        'If ds2.Tables(0).Rows(0).Item(0) = 1 Then
        '    Dim cDB As New cDOCUMENTOSBASE

        '    Dim ENTREGADO1 As Integer = IIf(cbVerTodos.Checked, 0, 2)

        '    'obteniendo renglon y idproducto

        '    Dim cdof As New cDETALLEOFERTA
        '    Dim dsren As New Data.DataSet
        '    dsren = cdof.ObtenerRenglon2(Request.QueryString("idProc"), Session("IdEstablecimiento"), Me.IDPROVEEDOR)
        '    Dim row As Data.DataRow
        '    Dim renglon As Integer
        '    For Each row In dsren.Tables(0).Rows
        '        If row(1) = Me.ddlDETALLEOFERTA1.SelectedValue Then
        '            renglon = row(0)
        '            Exit For
        '        End If
        '    Next

        '    Dim cdp As New cDETALLEPROCESOCOMPRA
        '    Dim dsprod As New Data.DataSet
        '    dsprod = cdp.obtenerDSRenglonProducto(Request.QueryString("idProc"), Session("IdEstablecimiento"), renglon)


        ' Dim ds As Data.DataSet = cDB.ObtenerDocumentosProcesoCompraRenglonM(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.IDPROVEEDOR, Me.ddlDETALLEOFERTA1.SelectedValue, ddlTIPODOCUMENTOBASE1.SelectedValue, ENTREGADO1, dsprod.Tables(0).Rows(0).Item(6), ddlRecTec.SelectedValue)
        '    Me.GridView1.DataSource = ds
        '    Me.GridView1.DataBind()

        'Dim cDO As New cDETALLEOFERTA
        'IDRODUCTO = dsprod.Tables(0).Rows(0).Item(6)
        'Me.txtObservaciones.Text = cDO.ObtenerObservacionDocumento(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDPROVEEDOR, Me.ddlDETALLEOFERTA1.SelectedValue)

        '    If ds.Tables(0).Rows.Count = 0 Then
        '        Me.btnGuardar.Visible = False
        '        Me.btnCumplenTodos.Visible = False
        '        Me.btnNoCumplenTodos.Visible = False
        '        Me.txtObservaciones.ReadOnly = True
        '        Me.btnNoaplicanTodos.Visible = False
        '    Else
        '        Me.btnGuardar.Visible = True
        '        Me.btnCumplenTodos.Visible = True
        '        Me.btnNoCumplenTodos.Visible = True
        '        Me.txtObservaciones.ReadOnly = False
        '        Me.btnNoaplicanTodos.Visible = True
        '    End If

        'Else
        Dim cDB As New cDOCUMENTOSBASE

        Dim ENTREGADO1 As Integer = IIf(cbVerTodos.Checked, 0, 2)

        Dim ds As Data.DataSet = cDB.ObtenerDocumentosProcesoCompraRenglon(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.IDPROVEEDOR, Me.ddlDETALLEOFERTA1.SelectedValue, ddlTIPODOCUMENTOBASE1.SelectedValue, ENTREGADO1)
        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()

        Dim cDO As New cDETALLEOFERTA
        Me.txtObservaciones.Text = cDO.ObtenerObservacionDocumento(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDPROVEEDOR, Me.ddlDETALLEOFERTA1.SelectedValue)

        If ds.Tables(0).Rows.Count = 0 Then
            Me.btnGuardar.Visible = False
            Me.btnCumplenTodos.Visible = False
            Me.btnNoCumplenTodos.Visible = False
            Me.txtObservaciones.ReadOnly = True
            Me.btnNoaplicanTodos.Visible = False
        Else
            Me.btnGuardar.Visible = True
            Me.btnCumplenTodos.Visible = True
            Me.btnNoCumplenTodos.Visible = True
            Me.txtObservaciones.ReadOnly = False
            Me.btnNoaplicanTodos.Visible = True
        End If
        'End If
        Dim cad = "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "&IDP= " & IDRODUCTO
        btnImprimir.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
        ' "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "&IDP= " & IDRODUCTO & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; "
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        Dim IDDETALLE As Integer = Me.ddlDETALLEOFERTA1.SelectedValue
        Dim IDDOCUMENTOBASE As Integer = Me.GridView1.DataKeys(e.RowIndex).Values.Item("IDDOCUMENTOBASE")

        mComponente.EliminarEXAMENRENGLON(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.IDPROVEEDOR, IDDETALLE, IDDOCUMENTOBASE)

        CargarDatos()
    End Sub

    Private Sub Siguiente()
        Me.lbAnterior.Visible = True
        Me.ddlDETALLEOFERTA1.SelectedIndex += 1

        'btnImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; "
        Me.lblNumOferta.Text = " " & (Me.ddlDETALLEOFERTA1.SelectedIndex + 1).ToString & " "
        If Me.lblNumOferta.Text = Me.lblTotalOfertas.Text Then Me.lbSiguiente.Visible = False
        Me.lblRenglon.Text = "RENGLON # " & Me.ddlDETALLEOFERTA1.SelectedItem.Text

        Me.cbVerTodos.Checked = False

        CargarDatos()
    End Sub

    'Boton que permite cambiar a "no aplican todos" el criterio de evaluacion
    'Mayra Martínez 180210
    Protected Sub btnNoaplicanTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoaplicanTodos.Click
        For i As Integer = 0 To Me.GridView1.Rows.Count - 1
            CType(Me.GridView1.Rows(i).FindControl("DropDownList4"), DropDownList).SelectedValue = 3
        Next
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        IrRenglon()
        Me.TextBox1.Text = ""
    End Sub
    Private Sub IrRenglon()
        'Me.lbAnterior.Visible = True
        Try
            Dim item As New ListItem
            Dim iddet As Integer = 0
            For Each item In Me.ddlDETALLEOFERTA1.Items
                If item.Text = Me.TextBox1.Text & " - 1" Then
                    iddet = item.Value
                    Exit For
                End If
            Next
            'Me.ddlDETALLEOFERTA1.SelectedItem.Text = Me.TextBox1.Text & " - 1"
            If iddet = 0 Then
                Me.Label1.Visible = True
                Exit Sub
            Else
                Me.Label1.Visible = False
            End If
            Me.ddlDETALLEOFERTA1.SelectedValue = iddet
            '            btnImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; "
            Me.lblNumOferta.Text = " " & (Me.ddlDETALLEOFERTA1.SelectedIndex + 1).ToString & " "
            If Me.lblNumOferta.Text = Me.lblTotalOfertas.Text Then Me.lbSiguiente.Visible = False
            Me.lbAnterior.Visible = True
            Me.lblRenglon.Text = "RENGLON # " & Me.ddlDETALLEOFERTA1.SelectedItem.Text

            Me.cbVerTodos.Checked = False

            CargarDatos()
        Catch ex As Exception
            
        End Try
    End Sub

   


    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'Response.Write("<script language='javascript'>window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; </script>")
        'Response.End()

        'btnImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; "
        'btnImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; "
        'btnImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; "
        'btnImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; "
        'btnImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptExamenRenglon.aspx?id=" & Request.QueryString("idProc") & "&Pr=" & Me.IDPROVEEDOR.ToString & "&Idd=" & Me.ddlDETALLEOFERTA1.SelectedValue & "&IDRECTEC=" & ddlRecTec.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return; "
    End Sub

    Protected Sub ddlRecTec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRecTec.SelectedIndexChanged
        Me.txtObservaciones.ReadOnly = Not cbVerTodos.Checked
        CargarDatos()

    End Sub
End Class
