'INGRESO DE SOLICITUD DE COMPRAS
'CU-ESTA0001
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la creacion y mantenimiento de solicitudes de compra
'permite la consulta de las solicitudes de compras conjuntas
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class FrmMantSolicitudCompra
    Inherits System.Web.UI.Page

    'declarar e inicializar variables
    Private mComponente As New cSOLICITUDES
    Private mEntidad As New SOLICITUDES


    'Private mEntDetalleSolicitud As New cDETALLESOLICITUDES

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina

        If Not Page.IsPostBack Then
            'al cargar la primera vez

            Me.Master.ControlMenu.Visible = False 'oculta menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Restaurar()
            CargarDatos()
            Me.DdlCriterio.Visible = True
            Me.DdlCriterio.Enabled = True
            Me.BttRestarurar.Enabled = False

        End If

    End Sub

    Private Sub CargarDatos()
        'carga los datos en el grid
        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerSolicitudesPorDependencia(Session.Item("IdEstablecimiento").ToString, Session.Item("IdDependencia").ToString)
        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        'al momento de cambiar indice de pagina del grid
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvLista_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvLista.RowEditing

        Dim eHES As New HISTORICOESTADOSSOLICITUDES
        Dim cHES As New cHISTORICOESTADOSSOLICITUDES

        'al enviar solicitud
        mEntidad.IDSOLICITUD = Me.gvLista.DataKeys(e.NewEditIndex).Values.Item("IDSOLICITUD")
        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

        Me.mComponente.ObtenerSOLICITUDES(mEntidad)

        mEntidad.IDESTADO = 2 'enviado
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mComponente.ActualizarSOLICITUDES(mEntidad)

        eHES.IDESTABLECIMIENTO = mEntidad.IDESTABLECIMIENTO
        eHES.IDDETALLE = cHES.id_HISTORICOESTADOSSOLICITUDES(eHES)
        eHES.IDSOLICITUD = mEntidad.IDSOLICITUD

        'actualiza historico de estado solicitud
        cHES.ObtenerHISTORICOESTADOSSOLICITUDES(eHES)

        eHES.IDESTADO = 2 'enviado 
        eHES.FECHA = Now()
        eHES.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eHES.AUFECHACREACION = Now()
        eHES.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eHES.AUFECHAMODIFICACION = Now()
        eHES.ESTASINCRONIZADA = 0

        cHES.AgregarHISTORICOESTADOSSOLICITUDES(eHES)

        Me.CargarDatos()

        MsgBox1.ShowAlert("Su solicitud fue enviada", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        'al cargar los registros del grid
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim SITUACION As String = Me.gvLista.DataKeys(e.Row.RowIndex).Values.Item("SITUACION")
            CType(e.Row.FindControl("lblObservacion"), Label).Text = SITUACION

            'Dim porcentajereal As Double
            'Dim montoreal As Double
            'Dim montoSolicitud As Double

            'montoreal = Me.mCompFuenteFinancSol.CalcularMontoTotalFuenteSolicitud(IDSOLICITUD, Session.Item("IdEstablecimiento"))
            'porcentajereal = Me.mCompFuenteFinancSol.CalcularPorcentajeTotalFuenteSolicitud(IDSOLICITUD, Session.Item("IdEstablecimiento"))
            'montoSolicitud = Me.mComponente.ObtenerMontoSolicitud(IDSOLICITUD, Session.Item("IdEstablecimiento"))

            ''Mostra envio y eliminacion
            ''valida existencia de entregas
            'If mCompEntregas.ValidarExistenciaEntregasSolicitud(IDSOLICITUD, Session.Item("IdEstablecimiento")) Then
            '    'validar que tenga detalle de productos la solicitud
            '    If mCompDetalleSolicitud.ExisteSolicitudesAsociadasSolicitud(IDSOLICITUD, Session.Item("IdEstablecimiento")) Then
            '        'valida que exista fuentes de financiamiento asociada a la solicitud
            '        If mCompFuenteFinancSol.ExisteFuentesAsociadasSolicitud(IDSOLICITUD, Session.Item("IdEstablecimiento")) Then
            '            'Valida que el monto asignado de la fuente de financiamiento no difiera del monto de las solicitudes
            '            If montoreal = montoSolicitud Then
            '                'valida que el porcentaje total de fuente de financimientos solicitudes difiera del 100%
            '                If porcentajereal = 100 Then
            '                    CType(e.Row.FindControl("lblObservacion"), Label).Text = "COMPLETA"
            '                Else
            '                    CType(e.Row.FindControl("lblObservacion"), Label).Text = "INCOMPLETA"
            '                End If
            '            Else
            '                CType(e.Row.FindControl("lblObservacion"), Label).Text = "INCOMPLETA"
            '            End If
            '        Else
            '            CType(e.Row.FindControl("lblObservacion"), Label).Text = "INCOMPLETA"
            '        End If
            '    Else
            '        CType(e.Row.FindControl("lblObservacion"), Label).Text = "INCOMPLETA"
            '    End If
            'Else
            '    CType(e.Row.FindControl("lblObservacion"), Label).Text = "INCOMPLETA"
            'End If

            'si esta grabada y completa
            Dim IDESTADO As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Values.Item("IDESTADO")
            Dim IDDEPENDENCIASOLICITANTE As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Values.Item("IDDEPENDENCIASOLICITANTE")

            If IDESTADO = 1 And SITUACION = "COMPLETA" Then

                'si es diferente dependencia a la del usuario
                If IDDEPENDENCIASOLICITANTE <> Session.Item("IdDependencia") Then
                    CType(e.Row.FindControl("LinkButton1"), ImageButton).Visible = False 'eliminar
                    CType(e.Row.FindControl("LinkButton2"), ImageButton).Visible = False 'enviar
                Else
                    CType(e.Row.FindControl("LinkButton1"), ImageButton).Visible = True 'eliminar
                    CType(e.Row.FindControl("LinkButton2"), ImageButton).Visible = True 'enviar
                End If

                CType(e.Row.FindControl("lblObservacion"), Label).Visible = False
            End If

            'si esta grabada e incompleta 
            If IDESTADO = eESTADOSSOLICITUD.Grabada And SITUACION = "INCOMPLETA" Then

                'si es diferente dependencia a la del usuario
                If IDDEPENDENCIASOLICITANTE <> Session.Item("IdDependencia") Then
                    CType(e.Row.FindControl("LinkButton1"), ImageButton).Visible = False 'eliminar
                    CType(e.Row.FindControl("LinkButton2"), ImageButton).Visible = False 'enviar
                Else
                    CType(e.Row.FindControl("LinkButton1"), ImageButton).Visible = True 'eliminar
                    CType(e.Row.FindControl("LinkButton2"), ImageButton).Visible = False 'enviar
                End If

                CType(e.Row.FindControl("lblObservacion"), Label).Visible = True
            End If

            'si el estado es diferente de grabado y esta completa
            If IDESTADO > 1 And SITUACION = "COMPLETA" Then
                CType(e.Row.FindControl("LinkButton1"), ImageButton).Visible = False 'eliminar
                CType(e.Row.FindControl("LinkButton2"), ImageButton).Visible = False 'enviar

                'si esta en estado Rechazada UACI(3) o Rechazada UFI (4)
                If IDESTADO = eESTADOSSOLICITUD.RechazadaUACI Or IDESTADO = eESTADOSSOLICITUD.RechazadaUFI Then
                    If IDDEPENDENCIASOLICITANTE <> Session.Item("IdDependencia") Then
                        CType(e.Row.FindControl("LinkButton2"), ImageButton).Visible = False 'enviar
                    Else
                        CType(e.Row.FindControl("LinkButton2"), ImageButton).Visible = True 'enviar
                    End If

                Else
                    CType(e.Row.FindControl("LinkButton2"), ImageButton).Visible = False 'enviar
                End If

                CType(e.Row.FindControl("lblObservacion"), Label).Visible = False
            End If

            'si el estado es diferente de grabado y esta incompleta

            If IDESTADO > 1 And SITUACION = "INCOMPLETA" Then
                CType(e.Row.FindControl("LinkButton1"), ImageButton).Visible = False 'eliminar
                CType(e.Row.FindControl("LinkButton2"), ImageButton).Visible = False 'enviar
            End If

            '-----
            'carga estados solicitud

            'carga plazos de entrega

            'carga de Empleados

            'carga si es compra conjunta

        End If
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting
        'al momento de eliminar un registro del grid de solicitudes

        Dim IDESTADO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDESTADO")
        Dim IDSOLICITUD As Integer = Me.gvLista.DataKeys(e.RowIndex).Values.Item("IDSOLICITUD")

        If IDESTADO = 1 Then 'grabado
            'elimina detalle de entregas
            Dim mCompDetalleEntregas As New cDETALLEENTREGAS
            mCompDetalleEntregas.EliminarDETALLEENTREGASxSolicitud(IDSOLICITUD, Session("IdEstablecimiento"))

            'elimina entregas
            Dim mCompEntregas As New cENTREGASOLICITUDES
            mCompEntregas.EliminarENTREGASXSolicitud(IDSOLICITUD, Session("IdEstablecimiento"))

            'elimina fuente de financiamiento
            Dim mCompFuenteFinancSol As New cFUENTEFINANCIAMIENTOSOLICITUDES
            mCompFuenteFinancSol.EliminarFUENTESSOLICITUD(IDSOLICITUD, Session("IdEstablecimiento"))

            'elimina detalle de solicitudes
            Dim mCompDetalleSolicitud As New cDETALLESOLICITUDES
            mCompDetalleSolicitud.EliminarDetallesSolicitud(IDSOLICITUD, Session("IdEstablecimiento"))

            'elimina de necesidades solicitud para compra conjunta
            Dim mCompNecesidadesSolicitud As New cNECESIDADESSOLICITUD
            mCompNecesidadesSolicitud.EliminarSolicitud(IDSOLICITUD, Session("IdEstablecimiento"))

            'elimina solicitud
            Me.mComponente.EliminarSOLICITUDES(Session("IdEstablecimiento"), IDSOLICITUD)

            Me.CargarDatos()
            MsgBox1.ShowAlert("Su solicitud fue eliminada", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            Response.Write("<script language='JavaScript'>alert('No se puede eliminar solicitud porque ya esta enviada')</script>")
        End If

    End Sub

    Private Sub BarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        'al momento de agregar nueva solicitud
        Response.Redirect("~/ESTABLECIMIENTOS/FrmDetaMantSolicitudCompra.aspx?id=0")
    End Sub

    Protected Sub BttBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttFiltrar.Click
        'al seleccionar buscar al momento de filtrar solicitud
        Dim textoBusqueda As String
        Dim criterioBusqueda As String
        Dim operadorBusqueda As String
        Dim FechaInicio As Date
        Dim FechaFin As Date

        'por correlativo
        If Me.DdlCriterio.SelectedItem.Value = "CORRELATIVO" Then
            textoBusqueda = Me.TxtBuscar.Text
            criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
            If Me.DdlOperadorBusqueda.SelectedItem.Value <> Nothing Then
                operadorBusqueda = Me.DdlOperadorBusqueda.SelectedItem.Value
            Else
                operadorBusqueda = "="
            End If

            Me.gvLista.DataSource = mComponente.Filtrar(textoBusqueda, criterioBusqueda, operadorBusqueda, CInt(Session.Item("IdEstablecimiento")))

            Try
                Me.gvLista.DataBind()
            Catch ex As Exception
                Me.gvLista.PageIndex = 0
                Me.gvLista.DataBind()
            End Try

        End If

        'POR FECHA DE SOLICITUD

        If Me.DdlCriterio.SelectedItem.Value = "FECHASOLICITUD" Then
            FechaInicio = CalendarFechaInicio.SelectedDate
            FechaFin = CalendarFechaFin.SelectedDate
            criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
            Me.gvLista.DataSource = mComponente.FiltrarRangosFecha(FechaInicio, FechaFin, criterioBusqueda, Session.Item("IdEstablecimiento").ToString)
            Try
                Me.gvLista.DataBind()
            Catch ex As Exception
                Me.gvLista.PageIndex = 0
                Me.gvLista.DataBind()
            End Try

        End If

        'POR PLAZO DE ENTREGA
        If Me.DdlCriterio.SelectedItem.Value = "PLAZOENTREGA" Then
            textoBusqueda = Me.DdlPlazoentrega.SelectedItem.Value
            criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
            If Me.DdlOperadorBusqueda.SelectedItem.Value <> Nothing Then
                operadorBusqueda = Me.DdlOperadorBusqueda.SelectedItem.Value
            Else
                operadorBusqueda = "="
            End If

            Me.gvLista.DataSource = mComponente.Filtrar(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento").ToString)
            Try
                Me.gvLista.DataBind()
            Catch ex As Exception
                Me.gvLista.PageIndex = 0
                Me.gvLista.DataBind()
            End Try
        End If

        'POR ESTADO
        If Me.DdlCriterio.SelectedItem.Value = "IDESTADO" Then
            textoBusqueda = Me.ddlEstado.SelectedItem.Value
            criterioBusqueda = "S." + Me.DdlCriterio.SelectedItem.Value
            operadorBusqueda = "="
            Me.gvLista.DataSource = mComponente.Filtrar2(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento").ToString)
            Try
                Me.gvLista.DataBind()
            Catch ex As Exception
                Me.gvLista.PageIndex = 0
                Me.gvLista.DataBind()
            End Try

        End If

        'POR DEPENDENCIA SOLICITANTE
        If Me.DdlCriterio.SelectedItem.Value = "IDDEPENDENCIASOLICITANTE" Then
            textoBusqueda = Me.ddlDependencias.SelectedItem.Value
            criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
            operadorBusqueda = "="
            Dim ds As Data.DataSet
            ds = mComponente.Filtrar(textoBusqueda, criterioBusqueda, operadorBusqueda, Session("IDEMPLEADO"), Session.Item("IdEstablecimiento").ToString)
            Me.gvLista.DataSource = ds
            Try
                Me.gvLista.DataBind()
            Catch ex As Exception
                Me.gvLista.PageIndex = 0
                Me.gvLista.DataBind()
            End Try
        End If

        Restaurar()

    End Sub

    Protected Sub DdlCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCriterio.SelectedIndexChanged
        'AL SELECCIONAR CRITERIO DE FILTRO DE SOLICITUD
        Dim criterioBusqueda As String
        criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
        Me.DdlPlazoentrega.SelectedItem.Value = "0"
        Me.BttRestarurar.Visible = True
        Me.TxtBuscar.Text = ""
        Me.BttRestarurar.Enabled = False
        Me.CargarDatos()

        If Me.DdlCriterio.SelectedItem.Value = "0" Then
            Me.BttFiltrar.Enabled = False
        Else
            Me.BttFiltrar.Enabled = True
        End If

        Select Case criterioBusqueda
            Case Is = "0" 'SIN SELECCIONAR
                Me.DdlOperadorBusqueda.Visible = False
                Me.DdlPlazoentrega.Visible = False
                Me.ddlDependencias.Visible = False
                Me.CalendarFechaInicio.Visible = False
                Me.CalendarFechaFin.Visible = False
                Me.LblFechaInicio.Visible = False
                Me.LblFechaFin.Visible = False
                Me.ddlEstado.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = False
                Me.CargarDatos()

            Case Is = "CORRELATIVO" 'CORRELATIVO
                Me.DdlOperadorBusqueda.Visible = True
                Me.ddlDependencias.Visible = False
                Me.DdlPlazoentrega.Visible = False
                Me.CalendarFechaInicio.Visible = False
                Me.CalendarFechaFin.Visible = False
                Me.LblFechaInicio.Visible = False
                Me.LblFechaFin.Visible = False
                Me.ddlEstado.Visible = False
                Me.TxtBuscar.Visible = True
                Me.BttFiltrar.Enabled = True
                Me.BttRestarurar.Enabled = True

            Case Is = "FECHASOLICITUD" 'FECHA DE LA SOLICITUD
                Me.DdlOperadorBusqueda.Visible = False
                Me.ddlDependencias.Visible = False
                Me.DdlPlazoentrega.Visible = False
                Me.LblFechaInicio.Visible = True
                Me.LblFechaFin.Visible = True
                Me.ddlEstado.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = True
                Me.BttRestarurar.Enabled = True

            Case Is = "IDDEPENDENCIASOLICITANTE" 'DEPENDENCIA
                Me.DdlOperadorBusqueda.Visible = False
                Me.ddlDependencias.Visible = True
                Me.DdlPlazoentrega.Visible = False
                Me.CalendarFechaInicio.Visible = False
                Me.CalendarFechaFin.Visible = False
                Me.LblFechaInicio.Visible = False
                Me.LblFechaFin.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = True
                Me.BttRestarurar.Enabled = True

            Case Is = "PLAZOENTREGA" 'PLAZO DE ENTREGA
                Me.DdlOperadorBusqueda.Visible = True
                Me.ddlDependencias.Visible = False
                Me.DdlPlazoentrega.Visible = True
                Me.CalendarFechaInicio.Visible = False
                Me.CalendarFechaFin.Visible = False
                Me.LblFechaInicio.Visible = False
                Me.LblFechaFin.Visible = False
                Me.ddlEstado.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = True
                Me.BttRestarurar.Enabled = True

            Case Is = "IDESTADO" 'ESTADO SOLICITUD
                Me.DdlOperadorBusqueda.Visible = False
                Me.ddlDependencias.Visible = False
                Me.DdlPlazoentrega.Visible = False
                Me.ddlEstado.Visible = True
                Me.CalendarFechaInicio.Visible = False
                Me.CalendarFechaFin.Visible = False
                Me.LblFechaInicio.Visible = False
                Me.LblFechaFin.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = True
                Me.BttRestarurar.Enabled = True
        End Select

    End Sub

    Protected Sub DdlOperadorBusqueda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlOperadorBusqueda.SelectedIndexChanged
        'AL SELECCIONAR OPERADOR DE BUSQUEDA
        Me.TxtBuscar.Text = ""
        Me.BttRestarurar.Visible = True
        If Me.DdlCriterio.SelectedItem.Value = "0" Then
            Me.BttFiltrar.Enabled = False
        Else
            Me.BttFiltrar.Enabled = True
        End If
    End Sub

    Private Sub CargarEstados()
        'CARGA LISTA DE ESTADOS
        Me.ddlEstado.Recuperar()

        Dim item As New ListItem
        item.Text = "Estado"
        item.Value = 0
        item.Selected = True
        Me.ddlEstado.Items.Insert(0, item)
    End Sub

    Private Sub CargarDependencias()
        'CARGA LISTA DE DEPEDENCIAS
        Me.ddlDependencias.Recuperar()

        Dim item As New ListItem
        item.Text = "Dependencias"
        item.Value = 0
        item.Selected = True
        Me.ddlDependencias.Items.Insert(0, item)
    End Sub

    Private Sub Restaurar()
        'RESTAURA FILTRO DE SOLICITUD
        Me.DdlCriterio.Visible = True
        Me.DdlCriterio.ClearSelection()
        Me.DdlCriterio.Enabled = False
        Me.DdlOperadorBusqueda.Visible = False
        Me.DdlOperadorBusqueda.ClearSelection()
        Me.DdlPlazoentrega.Visible = False
        Me.DdlPlazoentrega.ClearSelection()
        Me.ddlEstado.Visible = False
        Me.ddlEstado.ClearSelection()
        Me.ddlDependencias.Visible = False
        Me.ddlDependencias.ClearSelection()
        Me.CalendarFechaInicio.Visible = False
        Me.CalendarFechaFin.Visible = False
        Me.LblFechaInicio.Visible = False
        Me.LblFechaFin.Visible = False
        Me.TxtBuscar.Visible = False
        Me.BttFiltrar.Enabled = False
        Me.BttRestarurar.Visible = True
        Me.BttRestarurar.Enabled = True

        CargarDependencias()
        CargarEstados()
    End Sub

    Protected Sub BttRestarurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttRestarurar.Click
        'RECUPERA Y CARGA NUEVAMENTE TODAS LAS SOLICITUDES
        Restaurar()
        CargarDatos()
        Me.DdlCriterio.Visible = True
        Me.DdlCriterio.Enabled = True
        Me.BttRestarurar.Enabled = False
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'REDIRECCIONAR A LA PAGINA PRINCIPAL
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
