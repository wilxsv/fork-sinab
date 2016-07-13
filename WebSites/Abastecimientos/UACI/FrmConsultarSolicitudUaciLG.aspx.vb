'CU-UACI001 CONSULTAR SOLICITUDES DE COMPRA UACI
'Ing. Yessenia Pennelope Henriquez Duran
'permite la consulta de las solicitudes por la UACI
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data

Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Clases
Imports System.Collections.Generic
Imports Solicitudes = SINAB_Entidades.Helpers.EstablecimientoHelpers.Solicitudes



Partial Class FrmConsultarSolicitudUaciLG
    Inherits System.Web.UI.Page

    Private mComponente As New cSOLICITUDES
    '    Private mEntidad As New SOLICITUDES

    Dim FechaCol As New BoundField
    Dim lIde As Integer
    ''ojojojo

    Public Property Registros() As List(Of SAB_EST_SOLICITUDES)
        Get
            Return CType(ViewState("Registros"), List(Of SAB_EST_SOLICITUDES))
        End Get
        Set(value As List(Of SAB_EST_SOLICITUDES))
            ViewState("Registros") = value
        End Set
    End Property



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina

        If Not Page.IsPostBack Then 'al cargar la primera vez
            Me.Master.ControlMenu.Visible = False 'oculta menu
            'ojojojo
            'Me.ucBarraNavegacion1.Navegacion = False
            'Me.ucBarraNavegacion1.PermitirEditar = False
            'Me.ucBarraNavegacion1.PermitirGuardar = False
            'Me.ucBarraNavegacion1.PermitirConsultar = False
            'Me.ucBarraNavegacion1.PermitirAgregar = False
            'Me.ucBarraNavegacion1.PermitirImprimir = False
            Restaurar()

            Me.dgLista2.Visible = False
            Me.dgLista.Visible = True
            Me.DdlCriterio.Visible = True
            Me.DdlCriterio.Enabled = True
            Me.BttRestarurar.Enabled = False

            CargarDatos()

            Dim lIde As Int64 = Request.QueryString("ide") 'identificador de Establecimiento
            Dim lId As Int64 = Request.QueryString("id") 'identificador de proceso de compra
            If lId >= 1 Then


                Me.dgLista2.Visible = False
                Me.dgLista.Visible = True
                Me.DdlCriterio.Visible = True
                Me.DdlCriterio.Enabled = True
                Me.BttRestarurar.Enabled = False

                ' CargarDatosProcesoCompraSolicitud(lId, Session.Item("IdEstablecimiento"))
                CargarDatosProcesoCompraSolicitud(lId, lIde)
            Else
                CargarDatos()
            End If
            Me.ViewState("Consulta") = True
        End If
    End Sub

    Private Sub CargarDatos()
        Dim idEstablecimeinto As Integer = Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO
        'filtra que el estado sea enviado UACI
        ' Me.dgLista.DataSource = Me.mComponente.Filtrar2("7", "IDESTADO", "=", Session.Item("IdEstablecimiento"))
        ''Me.dgLista.DataSource = Me.mComponente.Filtrar2("7", "IDESTADO", "=", lIde)

        Registros = Solicitudes.ObtenerTodas(7, idEstablecimeinto)
        Me.dgLista.DataSource = Registros ' Me.mComponente.Filtrar2("6", "IDESTADO", "=", Session.Item("IdEstablecimiento"))

        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.PageIndex = 0
            Me.dgLista.DataBind()
        End Try

    End Sub

    'Private Sub CargarDatosProcesoCompra()
    '    'carga datos de procesos de compra
    '    Dim mCompProceso As New cPROCESOCOMPRAS
    '    Dim lPROCESOCOMPRAS As listaPROCESOCOMPRAS

    '    lPROCESOCOMPRAS = mCompProceso.ObtenerLista(Session.Item("IdEstablecimiento"))
    '    Me.dgLista2.DataSource = lPROCESOCOMPRAS

    '    Try
    '        Me.dgLista2.DataBind()
    '    Catch ex As Exception
    '        Me.dgLista2.PageIndex = 0
    '        Me.dgLista2.DataBind()
    '    End Try

    'End Sub


    Private Sub CargarDatosProcesoCompra(ByVal idProceso As Int32, ByVal idESTABLECIMIENTO As Int32)
        'carga las solicitudes asociadas a un proceso de compra
        Dim mCompProcesoSolicitud As New cSOLICITUDESPROCESOCOMPRAS
        Me.dgLista.DataSource = mCompProcesoSolicitud.ObtenerSolicitudesProcesoCompra(idProceso, idESTABLECIMIENTO)
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.PageIndex = 0
            Me.dgLista.DataBind()
        End Try

    End Sub

    Private Sub CargarDatosProcesoCompraSolicitud(ByVal idProceso As Int32, ByVal idESTABLECIMIENTO As Int32)
        'carga las solicitudes asociadas a un proceso de compra
        Dim mCompProcesoSolicitud As New cSOLICITUDESPROCESOCOMPRAS
        'Me.dgLista.DataSource = mCompProcesoSolicitud.ObtenerSolicitudesProcesoCompra(idProceso, idESTABLECIMIENTO)
        Me.dgLista.DataSource = mCompProcesoSolicitud.ObtenerSolicitudesProcesoCompra(idProceso, lIde)
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.PageIndex = 0
            Me.dgLista.DataBind()
        End Try

    End Sub

    Protected Sub dgLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgLista.RowDataBound

        'al cargar grid de solicitudes
        If e.Row.RowType = DataControlRowType.DataRow Then

            'carga los estados de la solicitud
            CType(e.Row.FindControl("ddlEstado"), DropDownList).DataTextField = "DESCRIPCION"
            CType(e.Row.FindControl("ddlEstado"), DropDownList).DataValueField = "IDESTADO"
            CType(e.Row.FindControl("ddlEstado"), DropDownList).DataSource = (New cESTADOS).ObtenerLista()
            CType(e.Row.FindControl("ddlEstado"), DropDownList).DataBind()
            CType(e.Row.FindControl("ddlEstado"), DropDownList).SelectedValue = CLng(CType(e.Row.FindControl("Label_IdEstado"), Label).Text)
            CType(e.Row.FindControl("TxtEstado"), Label).Text = CType(e.Row.FindControl("ddlEstado"), DropDownList).SelectedItem.Text
            'carga los plazos de entrega
            ''OJO CType(e.Row.FindControl("DdlPlazoentrega"), DropDownList).SelectedValue = CLng(CType(e.Row.FindControl("Label_IdPlazoEntrega"), Label).Text)
            CType(e.Row.FindControl("TxtPlazoEntrega"), Label).Text = CType(e.Row.FindControl("DdlPlazoentrega"), DropDownList).SelectedItem.Text
        End If
    End Sub

    Protected Sub dgLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles dgLista.RowDeleting
        'al eliminar una solicitud
        Dim IDSOLICITUD As Integer = dgLista.DataKeys(e.RowIndex).Values.Item("IDSOLICITUD")

        If Me.mComponente.EliminarSOLICITUDES(Session("IdEstablecimiento"), IDSOLICITUD) = 0 Then
            'Si se cometio un error
        Else
            Me.CargarDatos()
        End If
    End Sub

    Private Sub BarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        'al agregar una solicitud
        Response.Redirect("~/ESTABLECIMIENTOS/FrmDetaMantSolicitudCompra.aspx?id=0", False)
    End Sub

    Protected Sub dgLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgLista.PageIndexChanging
        'al cambiar el indice de pagina del grid de solicitudes
        Me.dgLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    'Protected Sub BttBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttFiltrar.Click
    '    'al presionar buscar una solicitud
    '    Dim mControl As New cSOLICITUDES
    '    Dim textoBusqueda As String
    '    Dim criterioBusqueda As String
    '    Dim operadorBusqueda As String

    '    ' correlativo
    '    If Me.DdlCriterio.SelectedItem.Value = "CORRELATIVO" Then
    '        Me.dgLista2.Visible = False
    '        Me.dgLista.Visible = True
    '        textoBusqueda = Me.TxtBuscar.Text
    '        criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
    '        If Me.DdlOperadorBusqueda.SelectedItem.Value <> Nothing Then
    '            operadorBusqueda = Me.DdlOperadorBusqueda.SelectedItem.Value
    '        Else
    '            operadorBusqueda = "="
    '        End If

    '        Me.dgLista.DataSource = mControl.Filtrar2(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento"))

    '        Try
    '            Me.dgLista.DataBind()
    '        Catch ex As Exception
    '            Me.dgLista.PageIndex = 0
    '            Me.dgLista.DataBind()
    '        End Try

    '    End If

    '    ' proceso compra
    '    If Me.DdlCriterio.SelectedItem.Value = "Proceso Compra" Then
    '        Me.dgLista.Visible = False
    '        Me.dgLista2.Visible = True
    '        CargarDatosProcesoCompra()
    '    End If

    '    ' estado
    '    If Me.DdlCriterio.SelectedItem.Value = "IDESTADO" Then
    '        Me.dgLista2.Visible = False
    '        Me.dgLista.Visible = True
    '        textoBusqueda = Me.DdlEstado.SelectedItem.Value
    '        criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
    '        operadorBusqueda = "="

    '        Me.dgLista.DataSource = mControl.Filtrar2(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento"))

    '        Try
    '            Me.dgLista.DataBind()
    '        Catch ex As Exception
    '            Me.dgLista.PageIndex = 0
    '            Me.dgLista.DataBind()
    '        End Try

    '    End If

    '    If Me.DdlCriterio.SelectedItem.Value = "Proceso Compra" Then
    '        Me.dgLista2.Visible = True
    '        Me.dgLista.Visible = False
    '        CargarDatosProcesoCompra()
    '    End If

    '    ' orden llegada
    '    If Me.DdlCriterio.SelectedItem.Value = "Orden Llegada" Then
    '        Me.dgLista2.Visible = False
    '        Me.dgLista.Visible = True
    '        textoBusqueda = 2
    '        criterioBusqueda = "IDESTADO"
    '        operadorBusqueda = "="
    '        FechaCol.DataField = "FECHA"
    '        FechaCol.HeaderText = "Fecha Envio"
    '        FechaCol.DataFormatString = "{0:d}"
    '        Me.dgLista.Columns.Add(FechaCol)

    '        Me.dgLista.DataSource = mControl.ObtenerFechaEstados(2, Session.Item("IdEstablecimiento"))

    '        Try
    '            Me.dgLista.DataBind()
    '        Catch ex As Exception
    '            Me.dgLista.PageIndex = 0
    '            Me.dgLista.DataBind()
    '        End Try

    '    End If

    '    ' dependencia
    '    If Me.DdlCriterio.SelectedItem.Value = "IDDEPENDENCIASOLICITANTE" Then
    '        Me.dgLista2.Visible = False
    '        Me.dgLista.Visible = True
    '        textoBusqueda = Me.DdlProcedencia.SelectedItem.Value
    '        criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
    '        operadorBusqueda = "="

    '        Me.dgLista.DataSource = mControl.Filtrar2(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento"))

    '        Try
    '            Me.dgLista.DataBind()
    '        Catch ex As Exception
    '            Me.dgLista.PageIndex = 0
    '            Me.dgLista.DataBind()
    '        End Try

    '    End If

    '    Restaurar()
    'End Sub

    Protected Sub BttBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttFiltrar.Click
        'al presionar buscar una solicitud

        Dim operadorBusqueda As String
        Dim idEstablecimeinto As Integer = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO


        Select Case DdlCriterio.SelectedItem.Value
            ' correlativo
            Case "CORRELATIVO"
                If DdlOperadorBusqueda.SelectedItem.Value <> Nothing Then
                    operadorBusqueda = DdlOperadorBusqueda.SelectedItem.Value
                Else
                    operadorBusqueda = "="
                End If

                Try
                    dgLista.DataSource = Solicitudes.ObtenerTodas(7, idEstablecimeinto, TxtBuscar.Text, operadorBusqueda)
                    dgLista.DataBind()
                Catch ex As Exception
                    dgLista.PageIndex = 0
                    dgLista.DataBind()
                End Try
                ' dependencia

            Case "IDDEPENDENCIASOLICITANTE"
                Try
                    dgLista.DataSource = Solicitudes.ObtenerTodas(7, idEstablecimeinto, CType(DdlProcedencia.SelectedItem.Value, Integer)) 'mControl.Filtrar2(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento"))
                    dgLista.DataBind()
                Catch ex As Exception
                    dgLista.PageIndex = 0
                    dgLista.DataBind()
                End Try

        End Select


        Restaurar()
    End Sub



    Protected Sub DdlCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCriterio.SelectedIndexChanged
        'al seleccionar criterio de busqueda de la solicitud
        Dim criterioBusqueda As String
        criterioBusqueda = Me.DdlCriterio.SelectedItem.Value
        Me.BttRestarurar.Visible = True
        Me.BttRestarurar.Enabled = False
        Me.TxtBuscar.Text = ""
        Me.CargarDatos()

        If Me.DdlOperadorBusqueda.SelectedItem.Value = "0" Or Me.DdlCriterio.SelectedItem.Value = "0" Then
            Me.BttFiltrar.Enabled = False
        Else
            Me.BttFiltrar.Enabled = True
        End If

        Select Case criterioBusqueda
            Case Is = "0"
                Me.DdlOperadorBusqueda.Visible = False
                Me.DdlProcedencia.Visible = False
                Me.DdlEstado.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = False
                Me.CargarDatos()

            Case Is = "CORRELATIVO"
                Me.DdlOperadorBusqueda.Visible = True
                Me.DdlProcedencia.Visible = False
                Me.DdlEstado.Visible = False
                Me.TxtBuscar.Visible = True
                Me.BttFiltrar.Enabled = True

            Case Is = "IDDEPENDENCIASOLICITANTE"
                Me.DdlOperadorBusqueda.Visible = False
                Me.DdlProcedencia.Visible = True
                Me.DdlEstado.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = True

            Case Is = "IDESTADO"
                Me.DdlOperadorBusqueda.Visible = False
                Me.DdlProcedencia.Visible = False
                Me.DdlEstado.Visible = True
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = True
        End Select
    End Sub

    Protected Sub DdlOperadorBusqueda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlOperadorBusqueda.SelectedIndexChanged
        'al cambiar seleccion del criterio de busqueda
        Me.TxtBuscar.Text = ""
        Me.BttRestarurar.Visible = True
        If Me.DdlCriterio.SelectedItem.Value = "0" Or Me.DdlOperadorBusqueda.SelectedItem.Value = "0" Then
            Me.BttFiltrar.Enabled = False
        Else
            Me.BttFiltrar.Enabled = True
        End If
    End Sub

    Private Sub CargarEstados()
        'carga lista de estados
        Dim mCompEstados As New cESTADOS
        Dim lEstados As DataSet
        lEstados = mCompEstados.ObtenerDataSetEstados(">", 1)
        Me.DdlEstado.DataValueField = "IDESTADO"
        Me.DdlEstado.DataTextField = "DESCRIPCION"
        Me.DdlEstado.DataSource = lEstados
        Me.DdlEstado.DataBind()
    End Sub

    Private Sub CargarProcedencia()
        'carga lista de dependencias
        Dim mCompDependencia As New cDEPENDENCIAS
        Dim lDependencias As listaDEPENDENCIAS

        lDependencias = mCompDependencia.ObtenerListaOrden(1)
        Me.DdlProcedencia.DataValueField = "IDDEPENDENCIA"
        Me.DdlProcedencia.DataTextField = "NOMBRE"
        Me.DdlProcedencia.DataSource = lDependencias
        Me.DdlProcedencia.DataBind()
    End Sub

    Protected Sub BttRestarurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttRestarurar.Click
        'restaura el listado de solicitudes
        Restaurar()
        CargarDatos()
        'Me.dgLista.Columns.Remove(FechaCol)
        Me.DdlCriterio.Visible = True
        Me.DdlCriterio.Enabled = True
        Me.BttRestarurar.Enabled = False
    End Sub

    Private Sub Restaurar()
        'restaura los controles del filtro
        Me.DdlCriterio.Visible = True
        Me.DdlCriterio.Enabled = False
        Me.DdlCriterio.ClearSelection()
        Me.DdlOperadorBusqueda.Visible = False
        Me.DdlOperadorBusqueda.ClearSelection()
        Me.DdlProcedencia.Visible = False
        Me.DdlProcedencia.ClearSelection()
        Me.DdlEstado.Visible = False
        Me.DdlEstado.ClearSelection()
        Me.TxtBuscar.Visible = False
        Me.BttFiltrar.Enabled = False
        Me.BttRestarurar.Visible = True
        Me.BttRestarurar.Enabled = True
        CargarProcedencia()
        CargarEstados()
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        'redirecciona a la pagina principal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub dgLista2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgLista2.PageIndexChanging
        'al cambiar el indice de pagina del grid de procesos de compra
        Me.dgLista2.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

End Class
