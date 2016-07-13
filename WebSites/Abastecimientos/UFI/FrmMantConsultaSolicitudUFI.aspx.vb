'INGRESO DE SOLICITUD DE COMPRAS
'CU-ESTA0001
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la consulta de solicitudes de compra por la UFI
'permite la consulta de las solicitudes de compras conjuntas
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class FrmMantConsultaSolicitudUFI
    Inherits System.Web.UI.Page

    'declarar e inicializar variables
    Private mComponente As New cSOLICITUDES
    Private mEntidad As New SOLICITUDES
    Private mEntHistoricoEstados As New HISTORICOESTADOSSOLICITUDES
    Private mCompHistoricoEstados As New cHISTORICOESTADOSSOLICITUDES
    Private mCompDetalleSolicitud As New cDETALLESOLICITUDES
    Private mEntDetalleSolicitud As New cDETALLESOLICITUDES
    Private mCompEntregas As New cENTREGASOLICITUDES
    Private mCompDetalleEntregas As New cDETALLEENTREGAS
    Private mCompEstados As New cESTADOS
    Private mCompDependencia As New cDEPENDENCIAS
    Private mCompNecesidadesSolicitud As New cNECESIDADESSOLICITUD
    Private mCompFuenteFinancSol As New cFUENTEFINANCIAMIENTOSOLICITUDES

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina

        If Not Page.IsPostBack Then
            'al cargar la primera vez

            Me.Master.ControlMenu.Visible = False 'oculta menu

            Restaurar()
            CargarDatos()
            Me.DdlCriterio.Visible = True
            Me.DdlCriterio.Enabled = True
            Me.BttRestarurar.Enabled = False

        End If

    End Sub

    Private Sub CargarDatos()
        'carga el grid de solicitudes en estado y aprovadas por la UFI
        Dim textoBusqueda As String
        Dim criterioBusqueda As String
        Dim operadorBusqueda As String

        Dim lSOLICITUDES As listaSOLICITUDES

        textoBusqueda = "4" 'enviado UFI
        criterioBusqueda = "IDESTADO"
        operadorBusqueda = ">="

        lSOLICITUDES = Me.mComponente.Filtrar(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento"))
        Me.dgLista.DataSource = lSOLICITUDES

        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.CurrentPageIndex = 0
            Me.dgLista.DataBind()
        End Try

    End Sub


    Private Sub dgLista_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        'al cargar los registros del grid

        If e.Item.ItemType = ListItemType.AlternatingItem Or _
           e.Item.ItemType = ListItemType.Item Then

            '-----
            'carga estados solicitud

            CType(e.Item.FindControl("ddlEstado"), DropDownList).DataTextField = "DESCRIPCION"
            CType(e.Item.FindControl("ddlEstado"), DropDownList).DataValueField = "IDESTADO"
            CType(e.Item.FindControl("ddlEstado"), DropDownList).DataSource = (New cESTADOS).ObtenerLista()
            CType(e.Item.FindControl("ddlEstado"), DropDownList).DataBind()
            CType(e.Item.FindControl("ddlEstado"), DropDownList).SelectedValue = CInt(CType(e.Item.FindControl("Label_IdEstado"), Label).Text)
            CType(e.Item.FindControl("TxtEstado"), TextBox).Text = CType(e.Item.FindControl("ddlEstado"), DropDownList).SelectedItem.Text

            'carga plazos de entrega
            CType(e.Item.FindControl("DdlPlazoentrega"), DropDownList).SelectedValue = (CType(e.Item.FindControl("Label_IdPlazoEntrega"), Label).Text)
            CType(e.Item.FindControl("TxtPlazoEntrega"), TextBox).Text = CType(e.Item.FindControl("DdlPlazoentrega"), DropDownList).SelectedItem.Text

            'carga de Empleados
            CType(e.Item.FindControl("DdlEMPLEADOS1"), DropDownList).DataTextField = "NOMBRE"
            CType(e.Item.FindControl("DdlEMPLEADOS1"), DropDownList).DataValueField = "IDEMPLEADO"
            CType(e.Item.FindControl("DdlEMPLEADOS1"), DropDownList).DataSource = (New cEMPLEADOS).ObtenerNombreCompleto()
            CType(e.Item.FindControl("DdlEMPLEADOS1"), DropDownList).DataBind()
            CType(e.Item.FindControl("DdlEMPLEADOS1"), DropDownList).SelectedValue = CInt(CType(e.Item.FindControl("idrep"), Label).Text)
            CType(e.Item.FindControl("LblResp"), Label).Text = CType(e.Item.FindControl("DdlEMPLEADOS1"), DropDownList).SelectedItem.Text

            'carga si es compra conjunta
            If CType(e.Item.FindControl("lblcj"), Label).Text = "1" Then CType(e.Item.FindControl("ChkCompraConjunta"), CheckBox).Checked = True
            If CType(e.Item.FindControl("lblcj"), Label).Text = "0" Then CType(e.Item.FindControl("ChkCompraConjunta"), CheckBox).Checked = False

        End If
    End Sub

    Private Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista.PageIndexChanged
        'al momento de cambiar indice de pagina del grid
        Me.dgLista.CurrentPageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub BttBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttFiltrar.Click
        'al seleccionar buscar  al momento de filtrar solicitud
        Dim mControl As New cSOLICITUDES
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

            Me.dgLista.DataSource = mControl.Filtrar(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento"))

            Try
                Me.dgLista.DataBind()
            Catch ex As Exception
                Me.dgLista.CurrentPageIndex = 0
                Me.dgLista.DataBind()
            End Try

        End If

        'POR FECHA DE SOLICITUD

        If Me.DdlCriterio.SelectedItem.Value = "FECHASOLICITUD" Then
            FechaInicio = CalendarFechaInicio.SelectedDate
            FechaFin = CalendarFechaFin.SelectedDate
            criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
            Me.dgLista.DataSource = mControl.FiltrarRangosFecha(FechaInicio, FechaFin, criterioBusqueda, Session.Item("IdEstablecimiento"))
            Try
                Me.dgLista.DataBind()
            Catch ex As Exception
                Me.dgLista.CurrentPageIndex = 0
                Me.dgLista.DataBind()
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

            Me.dgLista.DataSource = mControl.Filtrar(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento"))
            Try
                Me.dgLista.DataBind()
            Catch ex As Exception
                Me.dgLista.CurrentPageIndex = 0
                Me.dgLista.DataBind()
            End Try
        End If

        'POR ESTADO

        If Me.DdlCriterio.SelectedItem.Value = "IDESTADO" Then
            textoBusqueda = Me.DdlEstado.SelectedItem.Value
            criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
            operadorBusqueda = "="
            Me.dgLista.DataSource = mControl.Filtrar(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento"))
            Try
                Me.dgLista.DataBind()
            Catch ex As Exception
                Me.dgLista.CurrentPageIndex = 0
                Me.dgLista.DataBind()
            End Try

        End If
        'POR DEPENDENCIA SOLICITANTE
        If Me.DdlCriterio.SelectedItem.Value = "IDDEPENDENCIASOLICITANTE" Then
            textoBusqueda = Me.DdlDependencias.SelectedItem.Value
            criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
            operadorBusqueda = "="
            Me.dgLista.DataSource = mControl.Filtrar(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento"))
            Try
                Me.dgLista.DataBind()
            Catch ex As Exception
                Me.dgLista.CurrentPageIndex = 0
                Me.dgLista.DataBind()
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
                Me.DdlDependencias.Visible = False
                Me.CalendarFechaInicio.Visible = False
                Me.CalendarFechaFin.Visible = False
                Me.LblFechaInicio.Visible = False
                Me.lblinicio.Visible = False
                Me.LblFechaFin.Visible = False
                Me.lblFin.Visible = False
                Me.bttCal1.Visible = False
                Me.bttCal2.Visible = False
                Me.DdlEstado.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = False
                Me.CargarDatos()

            Case Is = "CORRELATIVO" 'CORRELATIVO
                Me.DdlOperadorBusqueda.Visible = True
                Me.DdlDependencias.Visible = False
                Me.DdlPlazoentrega.Visible = False
                Me.CalendarFechaInicio.Visible = False
                Me.CalendarFechaFin.Visible = False
                Me.LblFechaInicio.Visible = False
                Me.LblFechaFin.Visible = False
                Me.DdlEstado.Visible = False
                Me.TxtBuscar.Visible = True
                Me.BttFiltrar.Enabled = True
                Me.BttRestarurar.Enabled = True

            Case Is = "FECHASOLICITUD" 'FECHA DE LA SOLICITUD
                Me.DdlOperadorBusqueda.Visible = False
                Me.DdlDependencias.Visible = False
                Me.DdlPlazoentrega.Visible = False
                Me.lblinicio.Visible = True
                Me.bttCal1.Visible = True
                Me.lblFin.Visible = True
                Me.bttCal2.Visible = True
                Me.LblFechaInicio.Visible = True
                Me.LblFechaFin.Visible = True
                Me.DdlEstado.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = True
                Me.BttRestarurar.Enabled = True

            Case Is = "IDDEPENDENCIASOLICITANTE" 'DEPENDENCIA
                Me.DdlOperadorBusqueda.Visible = False
                Me.DdlDependencias.Visible = True
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
                Me.DdlDependencias.Visible = False
                Me.DdlPlazoentrega.Visible = True
                Me.CalendarFechaInicio.Visible = False
                Me.CalendarFechaFin.Visible = False
                Me.LblFechaInicio.Visible = False
                Me.LblFechaFin.Visible = False
                Me.DdlEstado.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = True
                Me.BttRestarurar.Enabled = True

            Case Is = "IDESTADO" 'ESTADO SOLICITUD
                Me.DdlOperadorBusqueda.Visible = False
                Me.DdlDependencias.Visible = False
                Me.DdlPlazoentrega.Visible = False
                Me.DdlEstado.Visible = True
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
    End Sub

    Private Sub CargarDependencias()
        'CARGA LISTA DE DEPEDENCIAS
        Dim lDependencias As listaDEPENDENCIAS

        lDependencias = Me.mCompDependencia.ObtenerListaOrden(1)
        Me.DdlDependencias.DataValueField = "IDDEPENDENCIA"
        Me.DdlDependencias.DataTextField = "NOMBRE"
        Me.DdlDependencias.DataSource = lDependencias
        Me.DdlDependencias.DataBind()
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
        Me.DdlEstado.Visible = False
        Me.DdlEstado.ClearSelection()
        Me.DdlDependencias.Visible = False
        Me.DdlDependencias.ClearSelection()
        Me.CalendarFechaInicio.Visible = False
        Me.lblinicio.Visible = False
        Me.lblFin.Visible = False
        Me.CalendarFechaFin.Visible = False
        Me.bttCal1.Visible = False
        Me.bttCal2.Visible = False
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

    Protected Sub bttCal1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttCal1.Click
        'AL SELECCIONAR MOSTRAR FECHA INICIO
        CalendarFechaInicio.Visible = True
    End Sub

    Protected Sub bttCal2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttCal2.Click
        'AL SELECCIONAR MOSTRAR FECHA FIN
        CalendarFechaFin.Visible = True
    End Sub

    Protected Sub CalendarFechaInicio_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CalendarFechaInicio.SelectionChanged
        'AL SELECIONAR FECHA INICIAL
        Me.lblinicio.Text = Me.CalendarFechaInicio.SelectedDate
        Me.CalendarFechaInicio.Visible = False
    End Sub

    Protected Sub CalendarFechaFin_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CalendarFechaFin.SelectionChanged
        'AL SELECCIONAR FECHA FIN
        Me.lblFin.Text = Me.CalendarFechaFin.SelectedDate
        Me.CalendarFechaFin.Visible = False
    End Sub

End Class
