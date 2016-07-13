'CU-UACI001 CONSULTAR SOLICITUDES DE COMPRA UACI
'Ing. Yessenia Pennelope Henriquez Duran
'permite la consulta de las solicitudes por la UACI
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Imports System.Linq
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Clases
Imports System.Collections.Generic
Imports Solicitudes = SINAB_Entidades.Helpers.EstablecimientoHelpers.Solicitudes

Partial Class FrmConsultarSolicitudUaci
    Inherits System.Web.UI.Page






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


            Restaurar()


            Me.DdlCriterio.Visible = True
            Me.DdlCriterio.Enabled = True
            Me.BttRestarurar.Enabled = False

            CargarDatos()
            Dim lIde As Int64 = Request.QueryString("ide") 'identificador de establecimiento
            Dim lId As Int64 = Request.QueryString("id") 'identificador de proceso de compra
            If lId >= 1 Then


                Me.DdlCriterio.Visible = True
                Me.DdlCriterio.Enabled = True
                Me.BttRestarurar.Enabled = False

                CargarDatosProcesoCompraSolicitud(lId, lIde)
            Else
                CargarDatos()
            End If
            Me.ViewState("Consulta") = True
        End If
    End Sub

    Private Sub CargarDatos()
        Dim idEstablecimeinto As Integer = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        'filtra que el estado sea enviado UACI
        Registros = Solicitudes.ObtenerTodas(6, idEstablecimeinto)
        Me.dgLista.DataSource = Registros ' Me.mComponente.Filtrar2("6", "IDESTADO", "=", Session.Item("IdEstablecimiento"))


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
        Me.dgLista.DataSource = mCompProcesoSolicitud.ObtenerSolicitudesProcesoCompra(idProceso, idESTABLECIMIENTO)
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.PageIndex = 0
            Me.dgLista.DataBind()
        End Try

    End Sub

    'Protected Sub dgLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgLista.RowDataBound

    '    'al cargar grid de solicitudes
    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        'carga los estados de la solicitud
    '        CType(e.Row.FindControl("ddlEstado"), DropDownList).DataTextField = "DESCRIPCION"
    '        CType(e.Row.FindControl("ddlEstado"), DropDownList).DataValueField = "IDESTADO"
    '        CType(e.Row.FindControl("ddlEstado"), DropDownList).DataSource = (New cESTADOS).ObtenerLista()
    '        CType(e.Row.FindControl("ddlEstado"), DropDownList).DataBind()
    '        CType(e.Row.FindControl("ddlEstado"), DropDownList).SelectedValue = CLng(CType(e.Row.FindControl("Label_IdEstado"), Label).Text)
    '        CType(e.Row.FindControl("TxtEstado"), Label).Text = CType(e.Row.FindControl("ddlEstado"), DropDownList).SelectedItem.Text
    '        'carga los plazos de entrega
    '        ''OJO CType(e.Row.FindControl("DdlPlazoentrega"), DropDownList).SelectedValue = CLng(CType(e.Row.FindControl("Label_IdPlazoEntrega"), Label).Text)
    '        CType(e.Row.FindControl("TxtPlazoEntrega"), Label).Text = CType(e.Row.FindControl("DdlPlazoentrega"), DropDownList).SelectedItem.Text
    '    End If
    'End Sub





    Protected Sub dgLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgLista.PageIndexChanging
        'al cambiar el indice de pagina del grid de solicitudes
        Me.dgLista.PageIndex = e.NewPageIndex

        Me.CargarDatos()
    End Sub

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
                    dgLista.DataSource = Solicitudes.ObtenerTodas(6, idEstablecimeinto, TxtBuscar.Text, operadorBusqueda)
                    dgLista.DataBind()
                Catch ex As Exception
                    dgLista.PageIndex = 0
                    dgLista.DataBind()
                End Try
                ' dependencia

            Case "IDDEPENDENCIASOLICITANTE"
                Try
                    dgLista.DataSource = Solicitudes.ObtenerTodas(6, idEstablecimeinto, CType(DdlProcedencia.SelectedItem.Value, Integer)) 'mControl.Filtrar2(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento"))
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

        If Me.DdlOperadorBusqueda.SelectedItem.Value = "0" Or Me.DdlCriterio.SelectedItem.Value = "0" Then
            Me.BttFiltrar.Enabled = False
        Else
            Me.BttFiltrar.Enabled = True
        End If

        Select Case criterioBusqueda
            Case Is = "0"
                Me.DdlOperadorBusqueda.Visible = False
                Me.DdlProcedencia.Visible = False
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = False


            Case Is = "CORRELATIVO"
                Me.DdlOperadorBusqueda.Visible = True
                Me.DdlProcedencia.Visible = False
                Me.TxtBuscar.Visible = True
                Me.BttFiltrar.Enabled = True

            Case Is = "IDDEPENDENCIASOLICITANTE"
                Me.DdlOperadorBusqueda.Visible = False
                Me.DdlProcedencia.Visible = True
                Me.TxtBuscar.Visible = False
                Me.BttFiltrar.Enabled = True


        End Select
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
        Me.TxtBuscar.Visible = False
        Me.BttFiltrar.Enabled = False
        Me.BttRestarurar.Visible = True
        Me.BttRestarurar.Enabled = True
        CargarProcedencia()
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        'redirecciona a la pagina principal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub



End Class
