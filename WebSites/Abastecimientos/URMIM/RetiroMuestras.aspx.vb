
Imports System.Linq
Imports SINAB_Entidades.Helpers.LabHelpres
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Tipos

Partial Class RetiroMuestras
    Inherits System.Web.UI.Page


    Public Property Idprocesocompra() As Integer
        Get
            Return CType(ViewState("IdProcesoCompra"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("IdProcesoCompra") = value
        End Set
    End Property
    Public Property Idestablecimiento() As Integer
        Get
            Return CType(ViewState("ide"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("ide") = value
        End Set
    End Property
    Public Property Idproveedor() As Integer
        Get
            Return CType(ViewState("idp"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("idp") = value
        End Set
    End Property
    Public Property Idcontrato() As Integer
        Get
            Return CType(ViewState("idc"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("idc") = value
        End Set
    End Property

    Public Property Renglon() As Integer
        Get
            Return CType(ViewState("r"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("r") = value
        End Set
    End Property
    Public Property Idinforme() As Integer
        Get
            Return CType(ViewState("in"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("in") = value
        End Set
    End Property
    Public Property NumeroNoti() As Integer
        Get
            Return CType(ViewState("nn"), Integer)
        End Get
        Set(value As Integer)
            ViewState("nn") = value
        End Set
    End Property

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Dim usr = Membresia.ObtenerUsuario()
            'Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
            Me.gvEncabezado.DataSource = UACIHelpers.ContratosAdjudicados.ObtenerTodos(3, usr.IDEMPLEADO)
            'cIM.ObtenerNotificacionesCapturadas(3, usr.IDEMPLEADO)
            Me.gvEncabezado.DataBind()

           

        End If
    End Sub


    Private Function CargarConteoNotificaciones(ByVal nunot As Integer) As Integer

        If nunot > 1 Then
            ltPreNotificacion.Text = " Notificaciones"
        Else
            If nunot = 0 Then
                ltPreNotificacion.Text = ": No hay notificaciones"
            Else
                ltPreNotificacion.Text = " Notificación"
            End If
        End If
        Return nunot
    End Function

    Private Sub CargarInspectores(ByVal ddl As DropDownList)

        Dim usr = Membresia.ObtenerUsuario()
        CatalogoHelpers.Empleados.CargarInspectoresALista(ddl, usr.Establecimiento.IDESTABLECIMIENTO)
        'Me.ddlInspectores.RecuperarEmpleadosPorDependenciaInspector(usr.Establecimiento.IDESTABLECIMIENTO)


        ddlEMPLEADOS1.Items.Insert(0, New ListItem("Seleccione un inspector...", "0"))
        ddlEMPLEADOS1.SelectedIndex = 0

    End Sub

    Protected Sub gvEncabezado_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvEncabezado.RowCommand

        Try
            Dim index As Integer = CType(e.CommandArgument, Integer)
            Dim selectedRow As GridViewRow = gvEncabezado.Rows(index)

            Idestablecimiento = CType(Me.gvEncabezado.DataKeys(index).Values(0), Integer)
            Idprocesocompra = CType(Me.gvEncabezado.DataKeys(index).Values(1), Integer)
            Idproveedor = CType(Me.gvEncabezado.DataKeys(index).Values(2), Integer)
            Idcontrato = CType(Me.gvEncabezado.DataKeys(index).Values(3), Integer)
            NumeroNoti = CType(gvEncabezado.DataKeys(index).Values(5), Integer)
            'NumeroNoti = CType(gvEncabezado.DataKeys(index).Values(6), Integer)
            Me.lblEstablecimiento.Text = CType(Me.gvEncabezado.DataKeys(index).Values(4), String)
            Me.lblNumNotificacion.Text = CType(CargarConteoNotificaciones(CType(NumeroNoti, Integer)), String)

            Me.lblPC.Text = Server.HtmlDecode(selectedRow.Cells(4).Text)
            Me.lblProveedor.Text = Server.HtmlDecode(selectedRow.Cells(2).Text)
            Me.lblNoDoc.Text = Server.HtmlDecode(selectedRow.Cells(3).Text)
            Me.lblFechaNotificacion.Text = Server.HtmlDecode(selectedRow.Cells(1).Text)
            Me.lblFechaAsignacion.Text = Server.HtmlDecode(selectedRow.Cells(5).Text)
            ' Me.Label2.Text = Server.HtmlDecode(selectedRow.Cells(6).Text)

        Catch ex As Exception

        End Try
    End Sub



    Public Sub EventoGvEncabezado(ByVal src As Object, ByVal e As GridViewCommandEventArgs)

        Select Case e.CommandName
            Case Is = "Editar"
                CargarInspectores(ddlEMPLEADOS1)

                Dim ds = Notificaciones.ObtenerTodos(Idproveedor, Idprocesocompra, Idestablecimiento, Idcontrato, NumeroNoti, 3)
                Dim obj = ds.FirstOrDefault()

                If obj.IdInspector > 0 Then
                    Me.lblObservacion.Text = obj.ObservacionAsignacion
                    If Not IsNothing(obj.FechaAsignacion) Then
                        lblFechaAsignacion.Text = obj.FechaAsignacion.Value.ToShortDateString()
                    Else
                        lblFechaAsignacion.Text = ""
                    End If

                    'verifica si es el mismo inspector o no
                    Dim esIgual As Boolean
                    For Each r As BaseInformeMuestra In ds
                        If r.IdInspector = obj.IdInspector Then
                            esIgual = True
                        Else
                            esIgual = False
                        End If
                    Next

                    Me.chbVarios.Visible = False
                    Me.gvAsignacion.DataSource = ds
                    Me.gvAsignacion.DataBind()
                    Me.pnlAsignacion.Visible = True
                    If esIgual Then
                        Me.ddlEMPLEADOS1.SelectedValue = CType(obj.IdInspector, String)
                        Me.chbVarios.Checked = False
                        Me.gvAsignacion.Columns(8).Visible = False
                    Else
                       
                        Me.chbVarios.Checked = True
                        Me.ddlEMPLEADOS1.SelectedIndex = -1
                        Me.gvAsignacion.Columns(8).Visible = True
                    End If
                     Me.ddlEMPLEADOS1.Enabled = False
                    For Each ddle In From row As GridViewRow In Me.gvAsignacion.Rows Select CType(row.Cells(8).Controls(1), DropDownList)
                        ddle.SelectedValue = CType(obj.IdInspector, String)
                    Next

                Else
                    Me.lblObservacion.Text = ""
                    lblFechaAsignacion.Text = DateTime.Now.ToShortDateString()
                    Me.gvAsignacion.DataSource = ds
                    Me.gvAsignacion.DataBind()
                End If
            Case Is = "Reporte"
                SINAB_Utils.Utils.MostrarVentana("~/Reportes/frmRptRetiroMuestrasAnalisis.aspx?IdPC=" & Idprocesocompra & "&idE=" & Idestablecimiento & "&idP=" & Idproveedor & "&NI=" & Me.lblNumNotificacion.Text)

                'Case Is = "3"
                '    Me.MsgBox1.ShowConfirm("Al cerrar esta notificación, ya no podrá ser editada. Desea cerrar esta notificación?", "p", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
        End Select

    End Sub

    Protected Sub gvAsignacion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvAsignacion.RowCommand
        Dim index As Integer = CType(e.CommandArgument, Integer)

        Idinforme = CType(Me.gvAsignacion.DataKeys(index).Values.Item("IDINFORME"), Integer)
        gvAsignacion.SelectedIndex = index
    End Sub

    Public Sub eventoGv4(ByVal src As Object, ByVal e As GridViewCommandEventArgs)
        Select Case e.CommandName
            Case Is = "Reporte"
                SINAB_Utils.Utils.MostrarVentana(CType(("~/Reportes/frmRptHojaCalculo.aspx?IdE=" & Session("IdEstablecimiento") & "&idI=" & Idinforme & "&Prov=" & Me.lblProveedor.Text & "&Contrato=" & Me.lblNoDoc.Text & "&PC=" & Me.lblPC.Text & "&E=" & Me.lblEstablecimiento.Text), String))
        End Select
    End Sub

End Class
