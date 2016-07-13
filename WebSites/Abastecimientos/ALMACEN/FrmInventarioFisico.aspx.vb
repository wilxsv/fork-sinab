'INVENTARIO FISICO
'CU-ALMACEN012
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para EL MANTENIMIENTO DEL INVENTARIO FISICO DEL ESTABLECIMIENTO
'Consiste en recuiento de las existencias de productos dentro del almacen para la comparacion 
'de los valores realies y fisicos
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmInventarioFisico
    Inherits System.Web.UI.Page

    'declaracion e inicializacion de variables
    Private mComponente As New cINVENTARIO

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'al momento de cargar pagina
        If Not Page.IsPostBack Then 'la primera vez que se carga pagina

            Me.Master.ControlMenu.Visible = False 'ocultar menu

            If Session.Item("IdAlmacen") > 0 Then
                Me.ucBarraNavegacion1.Navegacion = False
                Me.ucBarraNavegacion1.PermitirEditar = False
                Me.ucBarraNavegacion1.PermitirGuardar = False
                Me.ucBarraNavegacion1.PermitirImprimir = False
                Me.ucBarraNavegacion1.PermitirConsultar = False
                CargarDatos()
            Else
                Me.ucBarraNavegacion1.Navegacion = False
                Me.ucBarraNavegacion1.PermitirEditar = False
                Me.ucBarraNavegacion1.PermitirGuardar = False
                Me.ucBarraNavegacion1.PermitirImprimir = False
                Me.ucBarraNavegacion1.PermitirConsultar = False
                Me.ucBarraNavegacion1.PermitirAgregar = False
                MsgBox1.ShowAlert("El usuario debe estar asignado a un almacén o farmacia del establecimiento para continuar con el proceso", "x", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If

        End If
    End Sub

    Private Sub CargarDatos()
        'al cargar los datos del grid
        Me.dgLista.DataSource = Me.mComponente.ObtenerDataSetPorId2(Session.Item("IdAlmacen"))

        Try
            Me.dgLista.DataBind()
        Catch ex As Exception 'si ocurre un error en pagineo
            Me.dgLista.PageIndex = 0
            Me.dgLista.DataBind()
        End Try

    End Sub

    'Private Sub dgLista_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
    '    ' al momento de cargar los registros del grid

    '    If e.Item.ItemType = ListItemType.AlternatingItem Or _
    '       e.Item.ItemType = ListItemType.Item Then

    '        'inventario con ajustes no poder eliminarlo 
    '        If mCompAjuste.ValidarExistenciaAjuste(Session.Item("IdAlmacen"), CLng(CType(e.Item.FindControl("lblid"), Label).Text)) Then
    '            CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = False 'eliminar
    '        End If
    '    End If
    'End Sub

    Protected Sub dgLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles dgLista.RowDeleting
        'al momento de eliminar un registro del grid
        Dim IDALMACEN, IDINVENTARIO As Integer
        IDALMACEN = Session.Item("IdAlmacen")
        IDINVENTARIO = Me.dgLista.DataKeys(e.RowIndex).Values.Item("IDINVENTARIO")

        Dim mCompDetalle As New cDETALLEINVENTARIO
        mCompDetalle.EliminarInventarioDetalle(IDALMACEN, IDINVENTARIO)

        If Me.mComponente.EliminarINVENTARIO(IDALMACEN, IDINVENTARIO) = 0 Then
            'Si se cometio un error
            MsgBox1.ShowAlert("Error al Eliminar Registro", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            e.Cancel = True
        Else
            Me.CargarDatos() 'carga grid
        End If
    End Sub

    Private Sub ucBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        'al momento de agregar un nuevo inventario
        Response.Redirect("~/ALMACEN/FrmDetaMantInventario.aspx?id=0&estado=3", False)
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'envia a la pagina principakl del sistema
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
