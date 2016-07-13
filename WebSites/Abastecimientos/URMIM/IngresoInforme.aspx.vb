Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.LabHelpres
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils
Imports SINAB_Utils.MessageBox
Imports SINAB_Utils.Utils
Partial Class IngresoInforme
    Inherits System.Web.UI.Page



    Public Property IdProcesoCompra() As Integer
        Get
            Return CType(ViewState("IdProcesoCompra"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("IdProcesoCompra") = value
        End Set
    End Property
    Public Property IdEstablecimiento() As Integer
        Get
            Return CType(ViewState("IDESTABLECIMIENTO"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("IDESTABLECIMIENTO") = value
        End Set
    End Property
    Public Property IdProveedor() As Integer
        Get
            Return CType(ViewState("IDPROVEEDOR"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("IDPROVEEDOR") = value
        End Set
    End Property
    Public Property IdContrato() As Integer
        Get
            Return CType(ViewState("IDCONTRATO"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("IDCONTRATO") = value
        End Set
    End Property
    Public Property Grupo() As Integer
        Get
            Return CType(ViewState("grp"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("grp") = value
        End Set
    End Property
    Public Property IdInforme() As Integer
        Get
            Return CType(ViewState("inf"), Integer)
        End Get
        Set(value As Integer)
            ViewState("inf") = value
        End Set
    End Property

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False
            CargarEncabezados()
            Dim usr = Membresia.ObtenerUsuario()
            ltInspector.Text = usr.Empleado.NombreCompleto

        Else
            If ConfirmTarget = "Close" Then CerrarNotificacion()
        End If
    End Sub

    Private Sub CargarEncabezados()
       Try
            Me.gvEncabezado.DataSource = UACIHelpers.ContratosAdjudicados.ObtenerTodos(EnumHelpers.EstadoNotificacion.Revision, Membresia.ObtenerUsuario().IDEMPLEADO)
        Me.gvEncabezado.DataBind()
       Catch ex As Exception
            MessageBox.Alert(ex.Message)
       End Try
       
    End Sub

    Protected Sub gvEncabezado_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEncabezado.RowCommand
        Try
            Dim index As Integer = CType(e.CommandArgument, Integer)
            Me.gvEncabezado.SelectedIndex = index
            Dim selectedRow As GridViewRow = gvEncabezado.Rows(index)

            IdEstablecimiento = CType(gvEncabezado.DataKeys(index).Values(0), Integer)
            IdProcesoCompra = CType(gvEncabezado.DataKeys(index).Values(1), Integer)
            IdProveedor = CType(gvEncabezado.DataKeys(index).Values(2), Integer)
            IdContrato = CType(gvEncabezado.DataKeys(index).Values(3), Integer)
            Grupo = CType(gvEncabezado.DataKeys(index).Values(5), Integer)

            Me.lblPC.Text = Server.HtmlDecode(selectedRow.Cells(4).Text)
            Me.lblProveedor.Text = Server.HtmlDecode(selectedRow.Cells(2).Text)
            Me.lblNoDoc.Text = Server.HtmlDecode(selectedRow.Cells(3).Text)
            Me.lblFechaNotificacion.Text = CDate(Server.HtmlDecode(selectedRow.Cells(1).Text)).ToShortDateString()

            Me.Label1.Text = CDate(Server.HtmlDecode(selectedRow.Cells(5).Text)).ToShortDateString()
            Me.Label2.Text = Server.HtmlDecode(selectedRow.Cells(6).Text)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub EventoGvEncabezado(ByVal src As Object, ByVal e As GridViewCommandEventArgs)
        Select Case e.CommandName
            Case Is = "Editar"
                CargarLotes()
                Me.pnlForm.Visible = True
        End Select
    End Sub

    Private Sub CargarLotes()

        Dim ds = Notificaciones.ObtenerTodos(IdProveedor, IdProcesoCompra, IdEstablecimiento, IdContrato, Grupo, EnumHelpers.EstadoNotificacion.Revision, Membresia.ObtenerUsuario().IDEMPLEADO)
        CargarConteoNotificaciones(ds.Count())
        Me.gvLotes.DataSource = ds
        Me.gvLotes.DataBind()
    End Sub

    Private Sub CargarConteoNotificaciones(ByVal nunot As Integer)
        If nunot > 1 Then
            ltPreNotificacion.Text = " Notificaciones"
        Else
            If nunot = 0 Then
                ltPreNotificacion.Text = ": No hay notificaciones"
            Else
                ltPreNotificacion.Text = " Notificación"
            End If
        End If
        ltNotificacion.Text = nunot.ToString()
    End Sub

    Public Sub EventoGvLote(ByVal src As Object, ByVal e As GridViewCommandEventArgs) Handles gvLotes.RowCommand

        Dim index = CType(e.CommandArgument, Integer)

        Me.gvLotes.SelectedIndex = index
        IdInforme = CType(Me.gvLotes.DataKeys(index).Values(0), Integer)

        Select Case e.CommandName
            Case Is = "Editar"
                Response.Redirect(String.Format("~/urmim/editardatosnotificacionlotes.aspx?im={0}&ide={1}", IdInforme, IdEstablecimiento))
            Case Is = "Reporte"
                SINAB_Utils.Utils.MostrarVentana("~/Reportes/FrmRptVerInformeMuestras.aspx?idI=" & IdInforme & "&idE=" & IdEstablecimiento & "&idT=0")
            Case Is = "Cerrar"
                Confirm("Al cerrar este informe, ya no podrá ser editado. Desea cerrar este informe?", "Close", OptionPostBack.YesPostBack)
        End Select
    End Sub


    Private Sub CerrarNotificacion()
        dim correcto = False
        Try
            Notificaciones.Actualizar(IdInforme, IdEstablecimiento, EnumHelpers.EstadoNotificacion.Distribucion)
            MessageBox.Alert("La notificación ha sido cerrada con exito", "Cerrada")
            correcto = true
            
        Catch ex As Exception
            correcto = false
            MessageBox.Alert("La notificacion no ha sido cerrada. Error: " + ex.Message)
        End Try

        If correcto
            Try
                 Me.pnlForm.Visible = False
            CargarLotes()
            CargarEncabezados()
            Catch ex As Exception
                MessageBox.Alert(ex.Message)
            End Try
           
        End If
    End Sub
End Class
