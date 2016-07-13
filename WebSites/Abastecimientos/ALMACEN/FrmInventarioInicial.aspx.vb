Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmInventarioInicial
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            If Session.Item("IDALMACEN") > 0 Then
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

        Dim cII As New cINVENTARIOINICIAL
        Me.gvInventarios.DataSource = cII.ObtenerInventariosPorAlmacen(Session.Item("IDALMACEN"), 0)

        Try
            Me.gvInventarios.DataBind()
        Catch ex As Exception
            Me.gvInventarios.PageIndex = 0
            Me.gvInventarios.DataBind()
        End Try

    End Sub

    Protected Sub gvInventarios_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvInventarios.RowDeleting

        Dim IDALMACEN, IDINVENTARIO As Integer
        IDALMACEN = Session.Item("IDALMACEN")
        IDINVENTARIO = Me.gvInventarios.DataKeys(e.RowIndex).Values.Item("IDINVENTARIO")

        Dim cII As New cINVENTARIOINICIAL
        If cII.EliminarInventarioDetalle(IDALMACEN, IDINVENTARIO) = 1 Then
            CargarDatos()
        Else
            MsgBox1.ShowAlert("Error al Eliminar Registro", "error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            e.Cancel = True
        End If

    End Sub

    Private Sub ucBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        Response.Redirect("~/ALMACEN/FrmDetalleInventarioInicial.aspx?id=0", False)
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
