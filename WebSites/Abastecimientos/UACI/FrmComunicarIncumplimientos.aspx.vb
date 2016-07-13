'Comunicar incumplimientos de contrato
'CU-UACI023
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario con los procesos de compra en estado contratos distribuidos(17)
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data

Partial Class FrmComunicarIncumplimientos
    Inherits System.Web.UI.Page
    'declarar e inicializar variables
    Private mCompProceso As New cPROCESOCOMPRAS
    Private mEntidad As New PROCESOCOMPRAS
    Private mCompEstados As New cESTADOS
    Private mCompContratos As New cCONTRATOS
    Private mComponente As New cNOTASINCUMPLIMIENTOCONTRATO
    Dim idp As Int32 = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar pagina

        If Not Page.IsPostBack Then 'al cargar la primera vez
            Me.Master.ControlMenu.Visible = False 'oculta menu

            Me.TxtProveedor.Visible = False
            Me.dgLista1.Visible = True
            Me.dglista2.Visible = False
            Me.lblmensaje1.Visible = True
            CargarDatosProcesoCompra()
            habilitarBusquedacontratos(False)
            HabilitarFiltroProceso(False)
        End If
    End Sub

    Private Sub CargarDatosProcesoCompra()
        'al cargar el grid con los procesos de compra en estado de contratos distribuidos

        Dim ds As DataSet
        ds = Me.mCompProceso.ObtenerDataSetEstado(Session.Item("IdEstablecimiento"), 17) 'contratos distribuidos(17)

        If ds.Tables(0).Rows.Count > 0 Then
            Me.dgLista1.DataSource = ds

            Try
                Me.dgLista1.DataBind()
            Catch ex As Exception
                Me.dgLista1.CurrentPageIndex = 0
                Me.dgLista1.DataBind()
            End Try

            HabilitarFiltroProceso(True)
        Else
            Me.dgLista1.Visible = False
            Me.lblmensaje1.Text = "No hay procesos de compra en el estado seleccionado"
            HabilitarFiltroProceso(False)
        End If
    End Sub

    Private Sub CargarContratos(ByVal idProceso As Int32)
        'al cargar los contratos de un proceso de compra seleccionado

        Dim ds2 As DataSet
        ds2 = Me.mCompContratos.obtenerContratosOfertaXProcesoCompra(idProceso, Session.Item("IdEstablecimiento"))

        If ds2.Tables(0).Rows.Count > 0 Then
            Me.dglista2.DataSource = ds2

            Try
                Me.dglista2.DataBind()
            Catch ex As Exception
                Me.dglista2.CurrentPageIndex = 0
                Me.dglista2.DataBind()
            End Try

            habilitarBusquedacontratos(True)
        Else
            Me.dglista2.Visible = False
            Me.lblContrato.Text = "No hay contratos para este proceso de compra"
            habilitarBusquedacontratos(False)
        End If
    End Sub

    Protected Sub HabilitarFiltroProceso(ByVal edicion As Boolean)
        'habilita campos de filtro del proceso de compra
        Me.labelfiltro.Visible = edicion
        Me.TxtBusquedaProceso.Visible = edicion
        Me.ButtFiltrarProceso.Visible = edicion
        Me.ButtMostrarProcesos.Visible = edicion
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        'redirecciona a la pagina principal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub dgLista1_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista1.EditCommand
        'al seleccionar proceso de compra
        idp = CType(e.Item.FindControl("lblid"), Label).Text 'identificador de proceso de compra
        CargarContratos(idp)
        Me.dglista2.Visible = True
    End Sub

    Protected Sub dgLista1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista1.PageIndexChanged
        'al cambiar el numero de indice de pagina del grid de procesos de compra
        Me.dgLista1.CurrentPageIndex = e.NewPageIndex
        Me.CargarDatosProcesoCompra()
    End Sub

    Protected Sub dglista2_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dglista2.EditCommand
        'al seleccionar un contrato del grid de contratos por proceso de compra
        Dim lbldgproveedor As Label = CType(dglista2.Items(e.Item.ItemIndex).FindControl("lblidproveedor"), Label)
        Dim lbldgidproceso As Label = CType(dglista2.Items(e.Item.ItemIndex).FindControl("lblid"), Label)
        Dim lbldgcontrato As Label = CType(dglista2.Items(e.Item.ItemIndex).FindControl("lblidcontrato"), Label)

        Response.Redirect("~/UACI/FrmComunicarIncumplimientos2.aspx?id= " + lbldgidproceso.Text & "&proveedor= " + lbldgproveedor.Text & "&contrato= " + lbldgcontrato.Text)
    End Sub

    Protected Sub dglista2_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dglista2.ItemDataBound
        'al cargar los registros del grid de contratos

        If e.Item.ItemType = ListItemType.AlternatingItem Or _
          e.Item.ItemType = ListItemType.Item Then
            Dim a As ImageButton = CType(e.Item.FindControl("LinkButton1"), ImageButton) 'crea o cunsulta nota
            'valida si existe la nota de incumplimiento
            If mComponente.ValidarExistenciaNotaContrato(Session.Item("IdEstablecimiento"), Val(CType(e.Item.FindControl("lblidcontrato"), Label).Text), Val(CType(e.Item.FindControl("lblidproveedor"), Label).Text)) Then
                a.ToolTip = "Consultar nota"
                a.ImageUrl = "~/Imagenes/consulta.gif"
            Else
                a.Attributes.Add("onclick", "if(!window.confirm('¿Desea generar nota de incumplimiento de contrato?')){return false;}")
                a.ToolTip = "Generar nota"
                a.ImageUrl = "~/Imagenes/generar.gif"
            End If
        End If
    End Sub

    Protected Sub dglista2_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dglista2.PageIndexChanged
        'al cambiar numero de indice de pagina del grid de contratos
        Me.dglista2.CurrentPageIndex = e.NewPageIndex
        CargarContratos(idp)
    End Sub

    Protected Sub ButtFiltrarProceso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtFiltrarProceso.Click
        'al seleccionar filtrar los procesos de compra
        If Me.TxtBusquedaProceso.Text <> "" Then
            Me.dgLista1.DataSource = Me.mCompProceso.ObtenerDataSetEstadoXCodigo(Session.Item("IdEstablecimiento"), 14, Me.TxtBusquedaProceso.Text)
            Me.dgLista1.DataBind()
            Me.TxtBusquedaProceso.Text = ""
        Else
            'no puede estar vacio
        End If
    End Sub

    Protected Sub ButtMostrarProcesos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtMostrarProcesos.Click
        'al seleccionar mostrar todos los procesos
        CargarDatosProcesoCompra()
    End Sub

    Protected Sub Ddlcriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ddlcriterio.SelectedIndexChanged
        'al seleccionar criterio de busqueda de contratos
        Dim criterioBusqueda As String
        criterioBusqueda = Me.Ddlcriterio.SelectedItem.Value
        Select Case criterioBusqueda
            Case Is = "contrato"
                Me.TxtCodigo.Visible = True
                Me.TxtProveedor.Visible = False
            Case Is = "proveedor"
                Me.TxtCodigo.Visible = False
                Me.TxtProveedor.Visible = True
        End Select

    End Sub

    Private Sub habilitarBusquedacontratos(ByVal edicion As Boolean)
        'habilita campos de busqueda de contratos
        Me.Ddlcriterio.Visible = edicion
        Me.LblTitulo.Visible = edicion
        Me.TxtCodigo.Visible = edicion
        Me.TxtProveedor.Visible = False
        Me.ButtFiltrarContratos.Visible = edicion
        Me.ButtMostrarContratos.Visible = edicion
        Me.lblmensaje2.Visible = edicion
        Me.lblContrato.Visible = edicion
    End Sub

    Protected Sub ButtFiltrarContratos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtFiltrarContratos.Click
        'al seleccionar filtrar contratos

        If Me.TxtCodigo.Text <> "" And Me.Ddlcriterio.SelectedItem.Value = "contrato" Then
            Me.dglista2.DataSource = Me.mCompContratos.obtenerContratosOfertaXProcesoCompraXNumeroContrato(1, Session.Item("IdEstablecimiento"), Me.TxtCodigo.Text)

            Try
                Me.dglista2.DataBind()
            Catch ex As Exception
                Me.dglista2.CurrentPageIndex = 0
                Me.dglista2.DataBind()
            End Try

            Me.TxtCodigo.Text = ""
        End If

        If Me.TxtProveedor.Text <> "" And Me.Ddlcriterio.SelectedItem.Value = "proveedor" Then
            Me.dglista2.DataSource = Me.mCompContratos.obtenerContratosOfertaXProcesoCompraXProveedor(1, Session.Item("IdEstablecimiento"), Me.TxtProveedor.Text)

            Try
                Me.dglista2.DataBind()
            Catch ex As Exception
                Me.dglista2.CurrentPageIndex = 0
                Me.dglista2.DataBind()
            End Try

            Me.TxtProveedor.Text = ""
        End If
    End Sub

    Protected Sub ButtMostrarContratos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtMostrarContratos.Click
        'al selecionar mostrar todos los contratos
        CargarContratos(idp)
    End Sub

End Class
