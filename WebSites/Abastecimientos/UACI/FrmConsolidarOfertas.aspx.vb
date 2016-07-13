Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils.MessageBox

Partial Class FrmConsolidarOfertas
    Inherits System.Web.UI.Page

    Private mComponente As New cDETALLEPROCESOCOMPRA

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.UcVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
            Me.UcVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            Me.UcVistaDetalleSolicProcesCompra1.Consultar()
            Me.UcVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False

            Dim cpc As New cPROCESOCOMPRAS
            Dim dso As New Data.DataSet
            cpc.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), dso)
            Me.Label3.Text = dso.Tables(0).Rows(0).Item(1)
            Me.Label4.Text = Date.Now.ToString("dd/MM/yyyy")

            Button3.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptHojaAnalisis.aspx?idProc=" + Request.QueryString("idProc") + "&opc=1&ord=0")
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptHojaAnalisis.aspx?idProc=" + Request.QueryString("idProc") + "&opc=1&ord=0', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); return;"
            Button2.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptHojaAnalisis.aspx?idProc=" + Request.QueryString("idProc") + "&opc=1&ord=1")
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptHojaAnalisis.aspx?idProc=" + Request.QueryString("idProc") + "&opc=1&ord=1', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); return;"

            CargarDatos()

        End If

    End Sub

    Private Sub CargarDatos()
        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDataSetEncabezado(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        Me.gvRenglones.SelectedIndex = -1

        Me.gvRenglones.DataSource = ds

        Try
            Me.gvRenglones.DataBind()
        Catch ex As Exception
            Me.gvRenglones.PageIndex = 0
            Me.gvRenglones.DataBind()
        End Try

        Me.gvOfertas.SelectedIndex = -1
        Me.gvOfertas.DataSource = Nothing
        Me.gvOfertas.DataBind()

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarObservacion.Click

        If Me.txtObservaciones.Text.Trim = String.Empty Then
            Alert("Ingrese una observación antes de guardar.", "Aviso")
            'Me.MsgBox1.ShowAlert("Ingrese una observación antes de guardar.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Dim eDPC As New DETALLEPROCESOCOMPRA
        eDPC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        eDPC.IDPROCESOCOMPRA = Request.QueryString("idProc")
        eDPC.IDPRODUCTO = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Values.Item("IDPRODUCTO")
        eDPC.IDDETALLE = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Values.Item("IDDETALLE")
        eDPC.OBSERVACION = Me.txtObservaciones.Text
        eDPC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eDPC.AUFECHAMODIFICACION = Now
        eDPC.ESTASINCRONIZADA = 0

        mComponente.AgregarObservacion(eDPC)
        Alert("La observación ha sido almacenada satisfactoriamente.", "Guardado")
        'Me.MsgBox1.ShowAlert("La observación ha sido almacenada satisfactoriamente.", "C", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub gvRenglones_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRenglones.PageIndexChanging
        Me.lblObservaciones.Visible = False
        Me.txtObservaciones.Text = String.Empty
        Me.txtObservaciones.Visible = False
        Me.btnGuardarObservacion.Visible = False

        Me.gvRenglones.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub gvRenglones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvRenglones.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim RENGLON As Integer = sender.DataKeys(e.Row.RowIndex).Values.Item("RENGLON")

            Dim lbl As Label = CType(e.Row.FindControl("lblEntregas"), Label)
            lbl.Text = mComponente.ObtenerDataSetEncabezadoPorRenglon(Session("IdEstablecimiento"), Request.QueryString("idProc"), RENGLON).Replace(Environment.NewLine, "<br/>")

        End If

    End Sub

    Protected Sub gvRenglones_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvRenglones.SelectedIndexChanging

        Dim mcomponente2 As New cDETALLEOFERTA

        Dim ds As New Data.DataSet
        mcomponente2.ObtenerDetalleConsolidacionOferta(Request.QueryString("idProc"), Session("IdEstablecimiento"), Me.gvRenglones.Rows(e.NewSelectedIndex).Cells(1).Text, ds)

        Me.gvOfertas.DataSource = ds.Tables(0)
        Me.gvOfertas.DataBind()

        Me.Label7.Visible = True
        Me.lblObservaciones.Visible = True

        Me.btnGuardarObservacion.Visible = True
        Me.btnGuardarObservacion.Enabled = True

        'ocultar boton impresion por renglon a peticion de usuario
        Me.btnImpresionPorRenglon.Visible = False

        Me.Button3.Visible = True

        Me.txtObservaciones.Text = mComponente.ObtenerObservacionConsolidacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.gvRenglones.DataKeys(e.NewSelectedIndex).Values(0), Me.gvRenglones.DataKeys(e.NewSelectedIndex).Values(1))
        Me.txtObservaciones.Visible = True

        Dim cad = "/Reportes/frmRptHojaAnalisisXRenglon.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idP=" + Request.QueryString("idProc").ToString + "&renglon=" + Me.gvRenglones.Rows(e.NewSelectedIndex).Cells(1).Text
        btnImpresionPorRenglon.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
        '"window.open('" + Request.ApplicationPath + "/Reportes/frmRptHojaAnalisisXRenglon.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idP=" + Request.QueryString("idProc").ToString + "&renglon=" + Me.gvRenglones.Rows(e.NewSelectedIndex).Cells(1).Text + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return;"

    End Sub

    'Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

    '    Dim cPC As New cPROCESOCOMPRAS
    '    Dim ePC As New PROCESOCOMPRAS

    '    ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINAR
    '    ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")
    '    ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
    '    ePC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '    ePC.AUFECHAMODIFICACION = Now
    '    ePC.ESTASINCRONIZADA = 0

    '    cPC.ActualizarEstado(ePC, 0)

    '    If e.Key = "B" Then
    '        Response.Redirect("~/FrmPrincipal.aspx", False)
    '    ElseIf e.Key = "C" Then
    '        Me.btnGuardarObservacion.Enabled = False
    '    End If

    'End Sub


End Class
