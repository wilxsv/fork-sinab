'ELABORAR QUEDAN
'CU-UACI030
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario con la informacion de los programas de compras que cumplan con el estado de contratos distribuidos
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data

Partial Class FrmElaborarQuedan
    Inherits System.Web.UI.Page
    'declaracion e inicializacion de variables

    Private mCompProceso As New cPROCESOCOMPRAS
    Private mEntidad As New PROCESOCOMPRAS
    Private mCompEstados As New cESTADOS
    Private mCompContratos As New cCONTRATOS
    Dim idp As Int32 = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al momento de cargar formulario

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
        'carga el grid con los procesos de compras en estado contratos distribuidos

        Dim ds As DataSet
        ds = Me.mCompProceso.ObtenerDataSetEstado(Session.Item("IdEstablecimiento"), 17) 'contratos distribuidos(17)

        'carga lista
        If ds.Tables(0).Rows.Count > 0 Then
            Me.dgLista1.DataSource = ds

            Try
                Me.dgLista1.DataBind()
            Catch ex As Exception 'al momento de error en pagineo
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

    Protected Sub HabilitarFiltroProceso(ByVal edicion As Boolean)
        'habilita los campos para el filtro de proceso de compras
        Me.labelfiltro.Visible = edicion
        Me.TxtBusquedaProceso.Visible = edicion
        Me.ButtFiltrarProceso.Visible = edicion
        Me.ButtMostrarProcesos.Visible = edicion
    End Sub

    Private Sub CargarContratos(ByVal idProceso As Int32)
        'carga los contratos asociados al proceso de compra

        Dim ds2 As DataSet
        ds2 = Me.mCompContratos.obtenerContratosOfertaXProcesoCompra(idProceso, Session.Item("IdEstablecimiento"))

        'carga datos
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.dglista2.DataSource = ds2

            Try
                Me.dglista2.DataBind()
            Catch ex As Exception ' al momento de error en pagineo
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

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'redirecciona a la pagina prinicpal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub dgLista1_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista1.EditCommand
        'al momento de seleccionar un proceso de compras
        idp = CType(e.Item.FindControl("lblid"), Label).Text ' asignar identificador de proceso de compras
        CargarContratos(idp) 'carga contratos paa el proceso
        Me.dglista2.Visible = True 'muestra grid
    End Sub

    Protected Sub dgLista1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista1.PageIndexChanged
        'al momento de cambiar indice de pagina de grid de procesos de compra
        Me.dgLista1.CurrentPageIndex = e.NewPageIndex
        Me.CargarDatosProcesoCompra()
    End Sub

    Protected Sub dglista2_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dglista2.PageIndexChanged
        'al momento de cambiar indice de pagina del grid de contratos
        Me.dglista2.CurrentPageIndex = e.NewPageIndex
        CargarContratos(idp)
    End Sub

    Protected Sub ButtFiltrarProceso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtFiltrarProceso.Click
        'al momento de filtrar un proceso de compras

        If Me.TxtBusquedaProceso.Text <> "" Then
            Me.dgLista1.DataSource = Me.mCompProceso.ObtenerDataSetEstadoXCodigo(Session.Item("IdEstablecimiento"), 14, Me.TxtBusquedaProceso.Text)

            Try
                Me.dgLista1.DataBind()
            Catch ex As Exception
                Me.dgLista1.CurrentPageIndex = 0
                Me.dgLista1.DataBind()
            End Try


            Me.TxtBusquedaProceso.Text = ""
        Else
            'no puede estar vacio
        End If
    End Sub

    Protected Sub ButtMostrarProcesos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtMostrarProcesos.Click
        'al seleccionar mostrar todos los registros
        CargarDatosProcesoCompra()
    End Sub

    Protected Sub Ddlcriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ddlcriterio.SelectedIndexChanged
        'al seleccionar criterio de filtro

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
        'habilita los campos de la busqueda de contratos
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
        'al selecionar filtrar contratos

        'por codigo de contrato
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

        'por proveedor
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
        'al seleccionar mostrar todos los contratos
        CargarContratos(idp)
    End Sub
End Class
