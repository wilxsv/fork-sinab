
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data

Partial Class FrmAutorizarSolicitudes
    Inherits System.Web.UI.Page

    Private mComponente As New cSOLICITUDES
    Private mEntidad As New SOLICITUDES

    Dim FechaCol As New BoundField
    Private _filtro1 As String
    Private _filtro2 As Integer
    Public Property filtro1() As String
        Get
            Return Me._filtro1
        End Get
        Set(ByVal value As String)
            Me._filtro1 = value
            If Not Me.ViewState("filtro1") Is Nothing Then Me.ViewState.Remove("filtro1")
            Me.ViewState.Add("filtro1", value)
        End Set
    End Property
    Public Property filtro2() As Integer
        Get
            Return Me._filtro2
        End Get
        Set(ByVal value As Integer)
            Me._filtro2 = value
            If Not Me.ViewState("filtro2") Is Nothing Then Me.ViewState.Remove("filtro2")
            Me.ViewState.Add("filtro2", value)
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina
        If Not Page.IsPostBack Then 'al cargar la primera vez
            Me.Master.ControlMenu.Visible = False 'oculta menu
            'Dim lId As Integer = Request.QueryString("id") 'identificador de proceso de compra
            'If lId >= 1 Then
            '    filtro2 = 1
            'Else
            '    filtro2 = 0
            'End If
            'filtro1 = "!"
            'If Session("IdDependencia") <> 2 Then
            '    CargarDatos(filtro1, filtro2, Session("IdDependencia"))
            'Else
            CargarDatos()
            'End If
            Me.dgLista.Visible = True
        Else
            If Not Me.ViewState("filtro1") Is Nothing Then Me.filtro1 = Me.ViewState("filtro1")
            If Not Me.ViewState("filtro2") Is Nothing Then Me.filtro2 = Me.ViewState("filtro2")
        End If
    End Sub

    Private Sub CargarDatos()



        Dim x As New cSOLICITUDES
        'Me.dgLista.DataSource = x.ObtenerSolicitudesEstablecimientos(filtro1, filtro2, Session("IdDependencia"))
        Me.dgLista.DataSource = x.ObtenerSolicitudesEstablecimientosAutorizacion(Session("IdDependencia"))
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.PageIndex = 0
            Me.dgLista.DataBind()
        End Try

    End Sub


    'Protected Sub dgLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles dgLista.RowDeleting
    '    'al eliminar una solicitud
    '    Dim IDSOLICITUD As Integer = dgLista.DataKeys(e.RowIndex).Values.Item("IDSOLICITUD")



    '    If Me.mComponente.EliminarSOLICITUDES(Session("IdEstablecimiento"), IDSOLICITUD) = 0 Then
    '        'Si se cometio un error
    '    Else
    '        Me.CargarDatos(filtro1, filtro2)
    '    End If
    'End Sub

    'Protected Sub dgLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dgLista.PageIndexChanging
    '    'al cambiar el indice de pagina del grid de solicitudes
    '    Me.dgLista.PageIndex = e.NewPageIndex
    '    Me.CargarDatos(filtro1, filtro2)
    'End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'redirecciona a la pagina principal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If Me.DropDownList1.SelectedIndex = 1 Then
            Me.TextBox2.Visible = True
            Me.TextBox2.Text = ""
            Me.DropDownList2.Visible = False
            Me.BttRestarurar.Visible = True
        End If
        If Me.DropDownList1.SelectedIndex = 2 Then
            Me.TextBox2.Visible = False
            Me.DropDownList2.Visible = True
            Me.BttRestarurar.Visible = True
        End If
        If Me.DropDownList1.SelectedIndex = 0 Then
            Me.TextBox2.Visible = True
            Me.DropDownList2.Visible = False
            Me.BttRestarurar.Visible = False
        End If
    End Sub

    Protected Sub BttRestarurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttRestarurar.Click
        Dim x As New cSOLICITUDES
        If Me.TextBox2.Visible = True Then
            filtro1 = Me.TextBox2.Text
            filtro2 = 1
            Me.dgLista.DataSource = x.ObtenerSolicitudesEstablecimientos(filtro1, filtro2)
        ElseIf Me.DropDownList2.Visible = True Then
            filtro1 = Me.DropDownList2.SelectedValue
            filtro2 = 2
            Me.dgLista.DataSource = x.ObtenerSolicitudesEstablecimientos(filtro1, filtro2)
        Else
            filtro1 = "!"
            filtro2 = 1
            Me.dgLista.DataSource = x.ObtenerSolicitudesEstablecimientos(filtro1, filtro2)
        End If
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.PageIndex = 0
            Me.dgLista.DataBind()
        End Try
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'rechazar una solicitud
        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim cs As New cSOLICITUDES
        Dim s As New SOLICITUDES
        s.IDSOLICITUD = Me.dgLista.DataKeys(row.RowIndex).Values(0)
        s.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        s.IDESTADO = 1 ' rechazada area tecnica
        s.AUUSUARIOCREACION = User.Identity.Name
        s.AUUSUARIOMODIFICACION = User.Identity.Name
        s.AUFECHACREACION = DateTime.Now
        s.AUFECHAMODIFICACION = DateTime.Now
        cs.ActualizarEstado(s)
        'cs.EliminarTodaLaSOLICITUD(Session("IdEstablecimiento"), Me.dgLista.DataKeys(row.RowIndex).Values(0))
        ' ACTUALIZAR EL ESTADO DE LA SOLICITUD

        Response.Redirect("~/ESTABLECIMIENTOS/FrmAutorizarSolicitudes.aspx")
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'consultar solicitud

        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim t As String
        t = Me.dgLista.DataKeys(row.RowIndex).Values(2)

        Dim alerta As String = CType(("/ESTABLECIMIENTOS/FrmFiltroEspecificacion.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "&t=" & t), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)

        'Mostrar el reporte
    End Sub

    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'consultar cuadro de distribucion

        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        'Mostrar el reporte
        Dim alerta As String = CType(("/Reportes/FrmRptConsolidadoDistribucion1.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0)), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)

    End Sub

    'Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    'Modificar una solicitud de compra
    '    Dim btnDetails As ImageButton = sender
    '    Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
    '    Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompra.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0))
    'End Sub


    Protected Sub ImageButton5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'enviar una solicitud
        Dim cs As New cSOLICITUDES
        Dim s As New SOLICITUDES
        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        s.IDSOLICITUD = Me.dgLista.DataKeys(row.RowIndex).Values(0)
        s.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        s.IDESTADO = 7 ' envio UACI
        s.AUUSUARIOCREACION = User.Identity.Name
        s.AUUSUARIOMODIFICACION = User.Identity.Name
        s.AUFECHACREACION = DateTime.Now
        s.AUFECHAMODIFICACION = DateTime.Now
        cs.ActualizarEstado(s)

        Response.Redirect("~/ESTABLECIMIENTOS/FrmAutorizarSolicitudes.aspx")

    End Sub

    Protected Sub ImageButton1_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        ImageButton1_Click(sender, e)
    End Sub

    Protected Sub dgLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim X, Y As String
            X = Me.dgLista.DataKeys(e.Row.RowIndex).Values(1)

            If X > 2 Then
                Dim b, c As New ImageButton
                b = e.Row.FindControl("ImageButton5")
                b.Visible = False
                c = e.Row.FindControl("ImageButton1")
                c.Visible = False
            End If

        End If
    End Sub
End Class
