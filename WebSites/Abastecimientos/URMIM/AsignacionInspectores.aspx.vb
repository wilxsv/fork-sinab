Imports System.Linq
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.LabHelpres
Imports SINAB_Utils
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Tipos

Partial Class AsignacionInspectores
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

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            CargarGvLotes()
        End If
    End Sub

    Private Sub CargarGvLotes()
        Try
            gvEncabezado.SelectedIndex = -1
            Me.gvEncabezado.DataSource = UACIHelpers.ContratosAdjudicados.ObtenerTodos(EnumHelpers.EstadoNotificacion.Asignacion, "")
            Me.gvEncabezado.DataBind()
        Catch ex As Exception
            MessageBox.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptCuadroAsignacionInspectores.aspx?IdPC=" & IdProcesoCompra & "&idE=" & IdEstablecimiento & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');</script>")
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
            Me.lblFechaNotificacion.Text = Server.HtmlDecode(selectedRow.Cells(1).Text)

        Catch ex As Exception
            MessageBox.Alert("No se pudo cargar la información de la notificación. Error:" + ex.Message)
        End Try
    End Sub

    Public Sub eventoGvEncabezado(ByVal src As Object, ByVal e As GridViewCommandEventArgs)

        Select Case e.CommandName
            Case Is = "Editar"
                Editar()
            Case Is = "Cancelar"
                Cancelar()
            Case Is = "Cerrar"
                Cerrar()
        End Select

    End Sub

    Private Sub Cerrar()
        ' Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        Dim ds = Notificaciones.ObtenerTodos(IdProveedor, IdProcesoCompra, IdEstablecimiento, IdContrato, Grupo, EnumHelpers.EstadoNotificacion.Asignacion)

        'verifica que todos los lotes tengan inspector
        Dim noExiste As Boolean
        For Each itm In From itm1 In ds Where itm1.IdInspector <= 0
            noExiste = True
        Next

        If noExiste Then
            MessageBox.Alert("Esta notificación no puede cerrarse, ya que aún no ha sido asignada a ningún inspector.", "Error")
        Else
            Dim correcto = False
            Try
                Notificaciones.ActualizarTodos(IdProveedor, IdProcesoCompra, IdEstablecimiento, IdContrato, Grupo, EnumHelpers.EstadoNotificacion.Revision)

                MessageBox.Alert("La notificación ha sido cerrada.", "Cerrada")
                correcto = True

            Catch ex As Exception
                correcto = False
                MessageBox.Alert("La notificación no ha sido cerrada. Error: " + ex.Message, "Error")
            End Try
            If correcto Then
                Try
                    CargarGvLotes()
                    pnlForm.Visible = False
                Catch ex As Exception
                    MessageBox.Alert(ex.Message)
                End Try
            End If

        End If
    End Sub

    Private Sub Cancelar()
        Dim correcto = False
        Try
            Notificaciones.ActualizarTodos(IdProveedor, IdProcesoCompra, IdEstablecimiento, IdContrato, Grupo, EnumHelpers.EstadoNotificacion.Creada)
            MessageBox.Alert("La notificación ha sido rechazada", "Rechazada")
            correcto = True
        Catch ex As Exception
            correcto = False
            MessageBox.Alert("la notificación no ha sido rechazada. Error: " + ex.Message)
        End Try

        If correcto Then
            Try
                CargarGvLotes()
                pnlForm.Visible = False
            Catch ex As Exception
                MessageBox.Alert(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Editar()
        CargarInspectores(ddlInspectores)
        ddlInspectores.Items.Insert(0, New ListItem("Seleccione un inspector...", "0"))
        ddlInspectores.SelectedIndex = 0
        Dim ds = Notificaciones.ObtenerTodos(IdProveedor, IdProcesoCompra, IdEstablecimiento, IdContrato, Grupo, EnumHelpers.EstadoNotificacion.Asignacion)
        Dim obj = ds.FirstOrDefault()

        If obj.IdInspector > 0 Then
            Me.tbObservacion.Text = obj.ObservacionAsignacion
            If Not IsNothing(obj.FechaAsignacion) Then
                tbFechaAsignacion.Text = obj.FechaAsignacion.Value.ToShortDateString()
            Else
                tbFechaAsignacion.Text = ""
            End If


            'verifica si es el mismo inspector o no
            Dim esIgual = Not ds.Any(Function(res) res.IdInspector <> obj.IdInspector)

            Me.gvLotes.DataSource = ds
            Me.gvLotes.DataBind()

            If esIgual Then
                Me.ddlInspectores.SelectedValue = CType(obj.IdInspector, String)
                Me.chbVarios.Checked = False
                Me.ddlInspectores.Enabled = True
                Me.gvLotes.Columns(8).Visible = False
            Else
                Me.ddlInspectores.Enabled = False
                Me.chbVarios.Checked = True
                Me.ddlInspectores.SelectedIndex = -1
                Me.gvLotes.Columns(8).Visible = True
            End If

            'Dim i = 0
            'For Each ddle In From row As GridViewRow In Me.gvLotes.Rows Select CType(row.Cells(8).Controls(1), DropDownList)
            '    ddle.SelectedValue = CType(ds(i).IdInspector, String)
            '    i+=1
            'Next

        Else
            Me.tbObservacion.Text = ""
            tbFechaAsignacion.Text = DateTime.Now.ToShortDateString()
            Me.gvLotes.DataSource = ds
            Me.gvLotes.DataBind()
        End If

        Me.pnlForm.Visible = True
    End Sub

    Protected Sub GridView4_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLotes.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ddl = CType(e.Row.FindControl("ddlEmpleadosGv"), DropDownList)
            CargarInspectores(ddl)
            Dim ins = gvLotes.DataKeys(e.Row.RowIndex).Values(5)
            If ins > 0 Then ddl.SelectedValue = CType(ins, String)
        End If

    End Sub

    Private Sub CargarInspectores(ByVal ddl As DropDownList)

        Dim usr = Membresia.ObtenerUsuario()
        CatalogoHelpers.Empleados.CargarInspectoresALista(ddl, usr.Establecimiento.IDESTABLECIMIENTO)
        'Me.ddlInspectores.RecuperarEmpleadosPorDependenciaInspector(usr.Establecimiento.IDESTABLECIMIENTO)



        ltNotificacion.Text = CargarConteoNotificaciones().ToString()
    End Sub

    Private Function CargarConteoNotificaciones() As Integer
        Dim nunot = Notificaciones.ObtenerCountNotificacion(IdProveedor, IdProcesoCompra, IdEstablecimiento, IdContrato, Grupo, 2)

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

    Protected Sub chbVarios_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbVarios.CheckedChanged
        If Me.chbVarios.Checked Then
            Me.gvLotes.Columns(8).Visible = True
            Me.ddlInspectores.Enabled = False
        Else
            Me.gvLotes.Columns(8).Visible = False
            Me.ddlInspectores.Enabled = True
        End If
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        ' Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        Dim usrname = Membresia.ObtenerUsuario().NombreUsuario
        Try
            If Not Me.chbVarios.Checked Then
                If Me.ddlInspectores.SelectedValue = 0 Then Throw New Exception("Debe seleccionar un Inspector.")

                Using db As New SinabEntities
                    For Each row As GridViewRow In Me.gvLotes.Rows
                        Actualizar(db, usrname, row, CType(ddlInspectores.SelectedValue, Integer?))
                    Next
                End Using
            Else

                For Each ddle In From row As GridViewRow In Me.gvLotes.Rows Select ddle1 = CType(row.FindControl("ddlEmpleadosGv"), DropDownList) Where ddle1.SelectedValue = 0
                    Throw New Exception("Debe seleccionar un Inspector para cada lote.")
                    Exit Sub
                Next

                Using db As New SinabEntities
                    For Each row As GridViewRow In Me.gvLotes.Rows
                        Dim lista As DropDownList = CType(row.FindControl("ddlEmpleadosGv"), DropDownList)
                        Actualizar(db, usrname, row, CType(lista.SelectedValue, Integer?))
                    Next
                End Using
            End If

            MessageBox.Alert("La asignación se realizó satisfactoriamente.", "Exito")
            CargarGvLotes()
            pnlForm.Visible = False
        Catch ex As Exception
            MessageBox.Alert("Error al asignar inspector." + ex.Message, "Error")
        End Try
    End Sub

    Private Sub Actualizar(ByVal db As SinabEntities, ByVal usrname As String, ByVal row As GridViewRow, ByVal idInspector As Integer?)
        Dim idInforme = CType(Me.gvLotes.DataKeys(row.RowIndex).Values(0), Integer)
        Dim im = Notificaciones.Obtener(db, idInforme, IdEstablecimiento)
        With im
            .IDINSPECTOR = idInspector
            .AUUSUARIOMODIFICACION = usrname
            .OBSERVACIONASIGNACION = tbObservacion.Text
            .FECHAASIGNACION = CDate(tbFechaAsignacion.Text)
        End With
        db.SaveChanges()

    End Sub

    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.pnlForm.Visible = False
        Me.gvEncabezado.SelectedIndex = -1
    End Sub





End Class
