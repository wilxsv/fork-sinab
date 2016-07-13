Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports Cooperator.Framework.Web.Controls

Partial Class Controles_ucConsultarEstimacionNecesidades
    Inherits System.Web.UI.UserControl
    Private mComponente As New cNECESIDADESTABLECIMIENTOS
    Private mCompEstablecimientos As New cESTABLECIMIENTOS
    Private mCompDetalleNecesidad As New cDETALLENECESIDADESTABLECIMIENTOS
    Private mCompAlma As New cALMACENES
    Private mCompProductosPrograma As New cPRODUCTOSPROGRAMAS

    Private Sub Limpiar()
        Me.BtnIniciar.Visible = False
        Me.BtnValidarAnio.Visible = True
        Me.txtAnnio.Enabled = True
        Me.txtAnnio.Text = Year(Now)
        Me.DdlPROPUESTASDISPONIBLES1.Enabled = True
        Me.DdlSUMINISTROS1.Enabled = True
        Me.DdlPROPUESTASDISPONIBLES1.Enabled = True
        Me.ddlTipoListado.Visible = False
        Me.PnlNecesidades.Visible = False
        Me.PnlListadoFiltrosProductos.Visible = False
        Me.PnlDetalleNecesidad.Visible = False
        Me.PnlConsolidadoSibasi.Visible = False
        Me.PnlListadoProductos.Visible = False
        Me.ddlTipoListado.SelectedIndex = -1
        Me.dgListadoNecesidades.SelectedIndex = -1
        Me.dgConsolidadoPorSibasi.SelectedIndex = -1

    End Sub

    Protected Sub ddlTipoListado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoListado.SelectedIndexChanged

        If IsNumeric(Me.txtAnnio.Text) And Val(Me.txtAnnio.Text) > 0 Then
            Me.dgDetalleProductos.CurrentPageIndex = 0
            cargarDatos(Me.ddlTipoListado.SelectedValue)
        Else
            MsgBox1.ShowAlert("El año de la estimación de necesidades es incorrecto favor verificarlo", "A", AlertOption.NoAction, AlertType.Information)
            Me.txtAnnio.Focus()

        End If
    End Sub

    Private Sub cargarDatos(ByVal tipo As Integer)
        Dim lEntidad As New NECESIDADESTABLECIMIENTOS
        Dim idTipoEstablecimiento As Int64

        If tipo = 1 Then
            'Muestra el consolidado de estimaciones de necesidades a nivel de sibasi
            idTipoEstablecimiento = 2

            Me.PnlNecesidades.Visible = False
            Me.PnlConsolidadoSibasi.Visible = True
            Me.PnlDetalleNecesidad.Visible = False
            Me.PnlListadoProductos.Visible = False

            Me.dgConsolidadoPorSibasi.DataSource = mComponente.obtenerDsConsultaEstimacionNecesidadesPorSibasi(Me.txtAnnio.Text, Me.DdlPROPUESTASDISPONIBLES1.SelectedValue)
            Try
                Me.dgConsolidadoPorSibasi.DataBind()
            Catch ex As Exception
                Me.dgConsolidadoPorSibasi.CurrentPageIndex = 0
                Me.dgConsolidadoPorSibasi.DataBind()
            End Try

        ElseIf tipo = 2 Then
            'Muestra la lista de necesidades por establecimiento
            idTipoEstablecimiento = 3
            Me.PnlNecesidades.Visible = True
            Me.PnlConsolidadoSibasi.Visible = False
            Me.PnlDetalleNecesidad.Visible = False
            Me.PnlListadoProductos.Visible = False

            Me.dgListadoNecesidades.DataSource = mComponente.obtenerDsConsultaEstimacionNecesidad(idTipoEstablecimiento, Me.txtAnnio.Text, Me.DdlPROPUESTASDISPONIBLES1.SelectedValue)
            Try
                Me.dgListadoNecesidades.DataBind()
            Catch ex As Exception
                Me.dgListadoNecesidades.CurrentPageIndex = 0
                Me.dgListadoNecesidades.DataBind()
            End Try

        ElseIf tipo = 3 Then
            'Muestra el consolidado de estimacion de necesidades a nivel nacional
            idTipoEstablecimiento = 0
            Me.PnlNecesidades.Visible = False
            Me.PnlConsolidadoSibasi.Visible = False
            Me.PnlDetalleNecesidad.Visible = False
            Me.PnlListadoProductos.Visible = True

            Me.dgDetalleProductos.DataSource = mCompDetalleNecesidad.ObtenerDsDetalleNecesidadPorPropuesta(Me.txtAnnio.Text, Me.DdlPROPUESTASDISPONIBLES1.SelectedValue)
            Try
                Me.dgDetalleProductos.DataBind()
            Catch ex As Exception
                Me.dgDetalleProductos.CurrentPageIndex = 0
                Me.dgDetalleProductos.DataBind()
            End Try

            Dim dsPresupuestos As Data.DataSet
            dsPresupuestos = mComponente.ConsultaPresupuestosDS(Me.txtAnnio.Text, Me.DdlPROPUESTASDISPONIBLES1.SelectedValue)

            Me.LblPresupuestoAsignado.Text = IIf(IsDBNull(dsPresupuestos.Tables(0).Rows(0).Item("PRESUPUESTOASIGNADO")), 0, dsPresupuestos.Tables(0).Rows(0).Item("PRESUPUESTOASIGNADO"))
            Session.Item("Asignado") = Me.LblPresupuestoAsignado.Text
            Me.LblPresupuestoRealTotal.Text = IIf(IsDBNull(dsPresupuestos.Tables(0).Rows(0).Item("MONTONECESIDADREAL")), 0, dsPresupuestos.Tables(0).Rows(0).Item("MONTONECESIDADREAL"))
            Session.Item("Real") = Me.LblPresupuestoRealTotal.Text
            Me.LblPresupuestoAjustadoTotal.Text = IIf(IsDBNull(dsPresupuestos.Tables(0).Rows(0).Item("MONTONECESIDADAJUSTADA")), 0, dsPresupuestos.Tables(0).Rows(0).Item("MONTONECESIDADAJUSTADA"))
            Session.Item("Ajustado") = Me.LblPresupuestoAjustadoTotal.Text
            Me.LblPresupuestoFinalTotal.Text = IIf(IsDBNull(dsPresupuestos.Tables(0).Rows(0).Item("MONTONECESIDADFINAL")), 0, dsPresupuestos.Tables(0).Rows(0).Item("MONTONECESIDADFINAL"))
            Session.Item("Final") = Me.LblPresupuestoFinalTotal.Text

        End If

    End Sub

    Protected Sub dgListadoNecesidades_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgListadoNecesidades.PageIndexChanged
        Me.dgListadoNecesidades.CurrentPageIndex = e.NewPageIndex
        cargarDatos(Me.ddlTipoListado.SelectedValue)
    End Sub

    Protected Sub dgListadoNecesidades_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgListadoNecesidades.SelectedIndexChanged
        CargarDetalleProductosNecesidad()
    End Sub

    Private Function CargarDetalleProductosNecesidad() As Int16
        Dim idEstablecimiento As Int64
        Dim idNecesidad As Int64
        Dim dsNecesidades As Data.DataSet
        Dim dsAlmacenes As Data.DataSet

        idEstablecimiento = Me.dgListadoNecesidades.SelectedItem.Cells(5).Text
        idNecesidad = Me.dgListadoNecesidades.SelectedItem.Cells(6).Text

        'Recuperando la informacion de la solicitud
        dsNecesidades = mComponente.ObtenerNecesidadPorID(idEstablecimiento, idNecesidad)

        Me.DdlESTADOSNECESIDADES1.Recuperar()
        Me.DdlESTADOSNECESIDADES1.SelectedValue = IIf(IsDBNull(dsNecesidades.Tables(0).Rows(0).Item("IdEstado")), 2, dsNecesidades.Tables(0).Rows(0).Item("IdEstado"))
        Me.LblEstado.Text = Me.DdlESTADOSNECESIDADES1.SelectedItem.Text
        Me.lblFechaEnvio.Text = IIf(IsDBNull(dsNecesidades.Tables(0).Rows(0).Item("FECHAELABORACION")), "", dsNecesidades.Tables(0).Rows(0).Item("FECHAELABORACION"))

        Me.LblPresupuestoAsignado.Text = IIf(IsDBNull(dsNecesidades.Tables(0).Rows(0).Item("PRESUPUESTOASIGNADO")), 0, dsNecesidades.Tables(0).Rows(0).Item("PRESUPUESTOASIGNADO"))
        Session.Item("Asignado") = Me.LblPresupuestoAsignado.Text
        Me.LblPresupuestoRealTotal.Text = IIf(IsDBNull(dsNecesidades.Tables(0).Rows(0).Item("MONTONECESIDADREAL")), 0, dsNecesidades.Tables(0).Rows(0).Item("MONTONECESIDADREAL"))
        Session.Item("Real") = Me.LblPresupuestoRealTotal.Text
        Me.LblPresupuestoAjustadoTotal.Text = IIf(IsDBNull(dsNecesidades.Tables(0).Rows(0).Item("MONTONECESIDADAJUSTADA")), 0, dsNecesidades.Tables(0).Rows(0).Item("MONTONECESIDADAJUSTADA"))
        Session.Item("Ajustado") = Me.LblPresupuestoAjustadoTotal.Text
        Me.LblPresupuestoFinalTotal.Text = IIf(IsDBNull(dsNecesidades.Tables(0).Rows(0).Item("MONTONECESIDADFINAL")), 0, dsNecesidades.Tables(0).Rows(0).Item("MONTONECESIDADFINAL"))
        Session.Item("Final") = Me.LblPresupuestoFinalTotal.Text

        Me.DdlESTABLECIMIENTOS1.Recuperar()
        Me.DdlESTABLECIMIENTOS1.SelectedValue = idEstablecimiento
        Me.lblEstablecimiento.Text = DdlESTABLECIMIENTOS1.SelectedItem.Text

        dsAlmacenes = mCompAlma.FiltroAlmacenPorId(dsNecesidades.Tables(0).Rows(0).Item("IDALMACENENTREGA"))
        Me.lblLugarEntrega.Text = IIf(IsDBNull(dsAlmacenes.Tables(0).Rows(0).Item("NOMBRE")), "", dsAlmacenes.Tables(0).Rows(0).Item("NOMBRE"))
        Me.lblDireccionAlmacen.Text = IIf(IsDBNull(dsAlmacenes.Tables(0).Rows(0).Item("DIRECCION")), "", dsAlmacenes.Tables(0).Rows(0).Item("DIRECCION"))
        Me.lblObservaciones.Text = IIf(IsDBNull(dsNecesidades.Tables(0).Rows(0).Item("OBSERVACION")), "", dsNecesidades.Tables(0).Rows(0).Item("OBSERVACION"))

        Me.PnlListadoProductos.Visible = True
        Me.PnlDetalleNecesidad.Visible = True

        ObtenerDetalleNecesidad(idEstablecimiento, idNecesidad)

    End Function

    Private Sub ObtenerDetalleNecesidad(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64)
        Me.dgDetalleProductos.DataSource = mCompDetalleNecesidad.ObtenerDsDetalleNecesidadPorId(Me.DdlESTABLECIMIENTOS1.SelectedValue, Me.dgListadoNecesidades.SelectedItem.Cells(6).Text, Me.DdlSUMINISTROS1.SelectedValue)
        Try
            Me.dgDetalleProductos.DataBind()
        Catch ex As Exception
            Me.dgDetalleProductos.CurrentPageIndex = 0
            Me.dgDetalleProductos.DataBind()
        End Try

    End Sub

    Protected Sub dgDetalleProductos_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgDetalleProductos.PageIndexChanged
        Select Case Me.ddlTipoListado.SelectedValue
            Case Is = 1
                Me.dgDetalleProductos.CurrentPageIndex = e.NewPageIndex
                CargarDetalleProductosRegion()
            Case Is = 2
                Me.dgDetalleProductos.CurrentPageIndex = e.NewPageIndex
                CargarDetalleProductosNecesidad()
            Case Is = 3
                Me.dgDetalleProductos.CurrentPageIndex = e.NewPageIndex
                cargarDatos(Me.ddlTipoListado.SelectedValue)
        End Select

    End Sub

    Protected Sub BtnValidarAnio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnValidarAnio.Click
        Dim mComponenteValidarAnio As New cNECESIDADESTABLECIMIENTOS
        Dim dsValidarAnio As Data.DataSet
        If Me.RgvValidacionAño.IsValid = False Then
            MsgBox1.ShowAlert("Introduzca el año de la consulta", "A", AlertOption.NoAction, AlertType.Information)
        Else
            dsValidarAnio = mComponenteValidarAnio.ObtenerPeriodos(Me.txtAnnio.Text)

            If dsValidarAnio.Tables(0).Rows.Count = 0 Then
                MsgBox1.ShowAlert("No se encontro ningun documento relacionado al año seleccionado", "A", AlertOption.NoAction, AlertType.Information)
                'Me.txtAnnio.Text = Year(Now)
            Else
                Me.Label10.Visible = True
                Me.ddlTipoListado.Visible = True
                Me.BtnIniciar.Visible = True
                Me.BtnValidarAnio.Visible = False

                Me.txtAnnio.Enabled = False
                Me.DdlSUMINISTROS1.Enabled = False
                Me.DdlPROPUESTASDISPONIBLES1.Enabled = False
            End If
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.DdlSUMINISTROS1.RecuperarListaFiltrada(1)
            Me.txtAnnio.Text = Year(Now)
        End If
    End Sub

    Protected Sub BtnAsesoria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAsesoria.Click
        Response.Redirect("~/URMIM/FrmAsesoriasNecesidadesEstablecimientos.aspx?IdE=" & Me.DdlESTABLECIMIENTOS1.SelectedValue & "&IdN=" & Me.dgListadoNecesidades.SelectedItem.Cells(6).Text & "&Pr=" & Me.DdlPROPUESTASDISPONIBLES1.SelectedItem.Text & "&Su=" & Me.DdlSUMINISTROS1.SelectedItem.Text & "&Anio=" & Me.txtAnnio.Text)
    End Sub

    Protected Sub BtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Select Case Me.ddlTipoListado.SelectedValue
            Case Is = 1
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRevisionNecesidades.aspx?idPropuesta=" & Me.DdlPROPUESTASDISPONIBLES1.SelectedValue & "&idAnio=" & Me.txtAnnio.Text & "&idTipo=" & Me.ddlTipoListado.SelectedValue & "&idEsta=" & Me.dgConsolidadoPorSibasi.SelectedItem.Cells(4).Text & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
                Session("Suministro") = Me.DdlSUMINISTROS1.SelectedValue
                Session("NombreEsta") = Me.dgConsolidadoPorSibasi.SelectedItem.Cells("1").Text
            Case Is = 2
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRevisionNecesidades.aspx?idPropuesta=" & Me.DdlPROPUESTASDISPONIBLES1.SelectedValue & "&idAnio=" & Me.txtAnnio.Text & "&idTipo=" & Me.ddlTipoListado.SelectedValue & "&idEsta=" & Me.dgListadoNecesidades.SelectedItem.Cells(5).Text & "&idNecesidad=" & Me.dgListadoNecesidades.SelectedItem.Cells(6).Text & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
                Session("Suministro") = Me.DdlSUMINISTROS1.SelectedValue
                Session("NombreEsta") = Me.dgListadoNecesidades.SelectedItem.Cells("1").Text
            Case Is = 3
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRevisionNecesidades.aspx?idPropuesta=" & Me.DdlPROPUESTASDISPONIBLES1.SelectedValue & "&idAnio=" & Me.txtAnnio.Text & "&idTipo=" & Me.ddlTipoListado.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        End Select
    End Sub

    Protected Sub dgConsolidadoPorSibasi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgConsolidadoPorSibasi.SelectedIndexChanged
        CargarDetalleProductosRegion()
    End Sub

    Private Function CargarDetalleProductosRegion() As Int16
        '***********************************************************************************************************************
        Dim IDSIBASI As Int32
        Dim dsConsolidadoPorSibasi As Data.DataSet

        IDSIBASI = Me.dgConsolidadoPorSibasi.SelectedItem.Cells(4).Text

        'Recupernado la informacion de la solicitud
        dsConsolidadoPorSibasi = mComponente.ObtenerDsDetalleEstimacionNecesidadesPorSibasi(Me.txtAnnio.Text, Me.DdlPROPUESTASDISPONIBLES1.SelectedValue, IDSIBASI, 0, "")

        Dim dsPresupuestosSibasi As Data.DataSet
        dsPresupuestosSibasi = mComponente.ConsultaPresupuestosPorSibasiDS(Me.txtAnnio.Text, Me.DdlPROPUESTASDISPONIBLES1.SelectedValue, IDSIBASI)

        Me.LblPresupuestoAsignado.Text = IIf(IsDBNull(dsPresupuestosSibasi.Tables(0).Rows(0).Item("PRESUPUESTOASIGNADO")), 0, dsPresupuestosSibasi.Tables(0).Rows(0).Item("PRESUPUESTOASIGNADO"))
        Session.Item("Asignado") = Me.LblPresupuestoAsignado.Text
        Me.LblPresupuestoRealTotal.Text = IIf(IsDBNull(dsPresupuestosSibasi.Tables(0).Rows(0).Item("MONTONECESIDADREAL")), 0, dsPresupuestosSibasi.Tables(0).Rows(0).Item("MONTONECESIDADREAL"))
        Session.Item("Real") = Me.LblPresupuestoRealTotal.Text
        Me.LblPresupuestoAjustadoTotal.Text = IIf(IsDBNull(dsPresupuestosSibasi.Tables(0).Rows(0).Item("MONTONECESIDADAJUSTADA")), 0, dsPresupuestosSibasi.Tables(0).Rows(0).Item("MONTONECESIDADAJUSTADA"))
        Session.Item("Ajustado") = Me.LblPresupuestoAjustadoTotal.Text
        Me.LblPresupuestoFinalTotal.Text = IIf(IsDBNull(dsPresupuestosSibasi.Tables(0).Rows(0).Item("MONTONECESIDADFINAL")), 0, dsPresupuestosSibasi.Tables(0).Rows(0).Item("MONTONECESIDADFINAL"))
        Session.Item("Final") = Me.LblPresupuestoFinalTotal.Text

        Me.dgDetalleProductos.DataSource = dsConsolidadoPorSibasi
        Try
            Me.dgDetalleProductos.DataBind()
        Catch ex As Exception
            Me.dgDetalleProductos.CurrentPageIndex = 0
            Me.dgDetalleProductos.DataBind()
        End Try


        Me.PnlListadoProductos.Visible = True

    End Function

    Protected Sub DdlPresentacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlPresentacion.SelectedIndexChanged
        Me.TxtBuscar.Text = ""
        Select Case DdlPresentacion.SelectedValue
            Case Is = 1
                Me.DdlGRUPOS1.Visible = True
                Me.DdlSUBGRUPOS1.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BtnFiltrar.Visible = True

            Case Is = 2
                Me.DdlGRUPOS1.Visible = False
                Me.DdlGRUPOS2.Visible = True
                Me.DdlSUBGRUPOS1.Visible = True
                Me.TxtBuscar.Visible = False
                Me.BtnFiltrar.Visible = True

            Case Is = 3
                Me.DdlGRUPOS1.Visible = False
                Me.DdlGRUPOS2.Visible = False
                Me.DdlSUBGRUPOS1.Visible = False
                Me.TxtBuscar.Visible = True
                Me.BtnFiltrar.Visible = True

        End Select
    End Sub

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Dim mControl As New cCATALOGOPRODUCTOS
        Dim sTextoBusqueda As String
        Dim iTipoFiltro As Int16
        sTextoBusqueda = ""

        Select Case Me.DdlPresentacion.SelectedValue
            Case Is = 1
                iTipoFiltro = 1
                sTextoBusqueda = Me.DdlGRUPOS1.SelectedValue
            Case Is = 2
                iTipoFiltro = 2
                sTextoBusqueda = Me.DdlSUBGRUPOS1.SelectedValue
            Case Is = 3
                iTipoFiltro = 3
                sTextoBusqueda = Me.TxtBuscar.Text
        End Select

        If sTextoBusqueda = "" Then
            MsgBox1.ShowAlert("Defina el filtro de busqueda para poder continuar.", "A", AlertOption.NoAction, AlertType.Information)
        Else
            Select Case Me.ddlTipoListado.SelectedValue
                Case Is = 1
                    CargarDetalleSibasiFiltrado(iTipoFiltro, sTextoBusqueda)
                Case Is = 2
                    CargarDetalleNecesidadFiltrado(iTipoFiltro, sTextoBusqueda)
                Case Is = 3
                    CargarDetalleConsolidadoFiltrado(iTipoFiltro, sTextoBusqueda)
            End Select

        End If
    End Sub

    Protected Sub BtnImprimirReporteDeficit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimirReporteDeficit.Click
        Select Case Me.ddlTipoListado.SelectedValue
            Case Is = 1
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptConsolidadoDeficit.aspx?idPropuesta=" & Me.DdlPROPUESTASDISPONIBLES1.SelectedValue & "&idAnio=" & Me.txtAnnio.Text & "&idTipo=" & Me.ddlTipoListado.SelectedValue & "&idEsta=" & Me.dgConsolidadoPorSibasi.SelectedItem.Cells(4).Text & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
                Session("Suministro") = Me.DdlSUMINISTROS1.SelectedValue
                Session("NombreEsta") = Me.dgConsolidadoPorSibasi.SelectedItem.Cells("1").Text
            Case Is = 2
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptConsolidadoDeficit.aspx?idPropuesta=" & Me.DdlPROPUESTASDISPONIBLES1.SelectedValue & "&idAnio=" & Me.txtAnnio.Text & "&idTipo=" & Me.ddlTipoListado.SelectedValue & "&idEsta=" & Me.dgListadoNecesidades.SelectedItem.Cells(5).Text & "&idNecesidad=" & Me.dgListadoNecesidades.SelectedItem.Cells(6).Text & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
                Session("Suministro") = Me.DdlSUMINISTROS1.SelectedValue
                Session("NombreEsta") = Me.dgListadoNecesidades.SelectedItem.Cells("1").Text
            Case Is = 3
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptConsolidadoDeficit.aspx?idPropuesta=" & Me.DdlPROPUESTASDISPONIBLES1.SelectedValue & "&idAnio=" & Me.txtAnnio.Text & "&idTipo=" & Me.ddlTipoListado.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        End Select

    End Sub

    Protected Sub BtnIrconsultasinventario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnIrconsultasinventario.Click
        Response.Redirect("~/URMIM/FrmConsultaInventario.aspx")
    End Sub

    Private Sub CargarDetalleConsolidadoFiltrado(ByVal IDTIPOFILTRO As Int16, ByVal CRITERIO As String)

        Me.dgDetalleProductos.DataSource = mCompDetalleNecesidad.ObtenerDsDetalleNecesidadPorPropuestaFiltrada(Me.txtAnnio.Text, Me.DdlPROPUESTASDISPONIBLES1.SelectedValue, IDTIPOFILTRO, CRITERIO)
        Try
            Me.dgDetalleProductos.DataBind()
        Catch ex As Exception
            Me.dgDetalleProductos.CurrentPageIndex = 0
            Me.dgDetalleProductos.DataBind()
        End Try
    End Sub

    Private Sub CargarDetalleNecesidadFiltrado(ByVal IDTIPOFILTRO As Int16, ByVal CRITERIO As String)
        Me.dgDetalleProductos.DataSource = mCompDetalleNecesidad.ObtenerDsDetalleNecesidadPorIdFiltrado(Me.DdlESTABLECIMIENTOS1.SelectedValue, Me.dgListadoNecesidades.SelectedItem.Cells(6).Text, Me.DdlSUMINISTROS1.SelectedValue, IDTIPOFILTRO, CRITERIO)
        Try
            Me.dgDetalleProductos.DataBind()
        Catch ex As Exception
            Me.dgDetalleProductos.CurrentPageIndex = 0
            Me.dgDetalleProductos.DataBind()
        End Try
    End Sub
    Private Sub CargarDetalleSibasiFiltrado(ByVal IDTIPOFILTRO As Int16, ByVal CRITERIO As String)
        Dim IDSIBASI As Int32
        Dim dsConsolidadoPorSibasi As Data.DataSet

        IDSIBASI = Me.dgConsolidadoPorSibasi.SelectedItem.Cells(4).Text

        'Recupernado la informacion de la solicitud
        dsConsolidadoPorSibasi = mComponente.ObtenerDsDetalleEstimacionNecesidadesPorSibasi(Me.txtAnnio.Text, Me.DdlPROPUESTASDISPONIBLES1.SelectedValue, IDSIBASI, IDTIPOFILTRO, CRITERIO)

        Me.dgDetalleProductos.DataSource = dsConsolidadoPorSibasi
        Try
            Me.dgDetalleProductos.DataBind()
        Catch ex As Exception
            Me.dgDetalleProductos.CurrentPageIndex = 0
            Me.dgDetalleProductos.DataBind()
        End Try

    End Sub

    Protected Sub BtnMostrarFiltro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnMostrarFiltro.Click
        Me.PnlListadoFiltrosProductos.Visible = True
        Me.DdlPresentacion.SelectedValue = 1
        Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.DdlSUMINISTROS1.SelectedValue)
        Me.DdlGRUPOS2.RecuperarListaFiltrada(Me.DdlSUMINISTROS1.SelectedValue)
        'Me.DdlSUBGRUPOS1.RecuperarListaFiltrada(Me.DdlGRUPOS2.SelectedValue)
    End Sub

    Protected Sub BtnRestaurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRestaurar.Click
        Me.PnlListadoFiltrosProductos.Visible = False
    End Sub

    Protected Sub DdlGRUPOS2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlGRUPOS2.SelectedIndexChanged
        Me.DdlSUBGRUPOS1.RecuperarListaFiltrada(Me.DdlGRUPOS2.SelectedValue)
    End Sub


    Protected Sub BtnIniciar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnIniciar.Click
        Limpiar()
    End Sub

    Public Sub MostrarAyudaExterna(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim b As LinkButton
        b = sender

        Dim dsProgramas As Data.DataSet
        dsProgramas = mCompProductosPrograma.ObtenerProgramasPorProducto(b.CommandName)

        If dsProgramas.Tables(0).Rows.Count = 0 Then
            MsgBox1.ShowAlert("Este producto no recibe ningún tipo de ayuda por algún programa externo.", "A", AlertOption.NoAction, AlertType.Information)
        Else
            Dim strMsg As New Text.StringBuilder
            Dim iFila As Int32
            strMsg.Append("Ayuda externa para el producto: " + dsProgramas.Tables(0).Rows(0).Item("DESCLARGO"))
            For iFila = 0 To dsProgramas.Tables(0).Rows.Count - 1
                strMsg.AppendLine(" - " + dsProgramas.Tables(0).Rows(iFila).Item("PROGRAMA") + ": " + b.CommandArgument.ToString)
            Next
            MsgBox1.ShowAlert(strMsg.ToString, "A", AlertOption.NoAction, AlertType.Information)
        End If

    End Sub
End Class
