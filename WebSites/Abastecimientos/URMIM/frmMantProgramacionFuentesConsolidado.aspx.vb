Imports ABASTECIMIENTOS.NEGOCIO

Partial Class URMIM_frmMantProgramacionFuentesConsolidado
    Inherits System.Web.UI.Page

    Private _IDGRUPO As Integer

    Public Property IDGRUPOX() As Integer 'identificador de programacion
        Get
            Return Me._IDGRUPO
        End Get
        Set(ByVal Value As Integer)
            Me._IDGRUPO = Value

            If Not Me.ViewState("IDGRUPO") Is Nothing Then Me.ViewState.Remove("IDGRUPO")
            Me.ViewState.Add("IDGRUPO", Value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'Navegacion

            If Request.QueryString("id") Is Nothing Then Response.Redirect("~/URMIM/frmMantProgramacionConsolidado.aspx", False)
            If Not IsNumeric(Request.QueryString("id")) Then Response.Redirect("~/URMIM/frmMantProgramacionConsolidado.aspx", False)

            IDGRUPOX = Request.QueryString("id")

            Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMACION
            Dim estado As Integer = cEntidad.obtenerEstadoGrupo(IDGRUPOX)

            If estado >= 2 Then
                Me.gvLista.Enabled = False
                Me.btn2.Enabled = False
            End If

            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False

            CargarDatosDisponibles()

        End If

    End Sub

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/URMIM/frmMantProgramacionConsolidado.aspx", False)
    End Sub

    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar

        Dim cEntidad As New cPROGRAMACION
        Dim arr As New ArrayList
        'Dim bl As Boolean = False

        For Each row As GridViewRow In gvLista.Rows


            Dim dd As DropDownList

            dd = row.FindControl("dd2")

            Dim s(2) As Integer

            s(0) = Me.gvLista.DataKeys(row.RowIndex).Values(0)
            s(1) = Me.gvLista.DataKeys(row.RowIndex).Values(1)
            s(2) = -1

            If dd.SelectedIndex > 0 Then
                s(2) = dd.SelectedItem.Value
            End If

            'For i As Integer = 0 To arr.Count - 1
            '    Dim s2(2) As Integer
            '    s2 = arr.Item(i)
            '    If s2(2) = s(2) And s(2) <> -1 Then
            '        bl = True
            '    End If
            'Next

            arr.Add(s)

        Next

        'If bl = True Then
        '    Me.MsgBox1.ShowAlert("Debe seleccionar fuentes diferentes para cada programación", "Mensaje", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        '    Exit Sub
        'End If

        If cEntidad.actualizarFuentesProgramacion(arr, HttpContext.Current.User.Identity.Name) = 1 Then
            Me.MsgBox1.ShowAlert("Datos almacenados", "Mensaje", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            CargarDatosDisponibles()
        Else
            Me.MsgBox1.ShowAlert("Error al almacenar las fuentes", "Mensaje", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Private Sub CargarDatosDisponibles() 'carga los datos y los muestra en el gridview

        Dim mComponente As New cPROGRAMACION

        Me.gvLista.DataSource = mComponente.obtenerProgramacionesGrupoDs(Me.ViewState("IDGRUPO"))

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'evento al presionar link menu
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        Dim cEntidad As New cGRUPOSFUENTEFINANCIAMIENTO

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim dd1 As DropDownList

            dd1 = e.Row.FindControl("dd1")

            dd1.Items.Clear()
            dd1.Items.Add("[Seleccione un Grupo]")

            dd1.DataSource = cEntidad.ObtenerDataSetPorId
            dd1.DataTextField = "descripcion"
            dd1.DataValueField = "idGrupo"

            dd1.DataBind()

            'Existen dos opciones. Fuente definida, o fuente no definida
            Dim fuente As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Values(2)
            Dim grupo As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Values(3)

            Dim dd2 As DropDownList
            dd2 = e.Row.FindControl("dd2")

            'Cuando existe fuente, llenamos el segundo combo para asignarle la fuente
            If fuente > -1 Then

                For i As Integer = 1 To dd1.Items.Count - 1
                    If dd1.Items(i).Value = grupo Then
                        dd1.SelectedIndex = i
                        Exit For
                    End If
                Next

                llenarFuentes(grupo, dd2)

                For i As Integer = 1 To dd2.Items.Count - 1
                    If dd2.Items(i).Value = fuente Then
                        dd2.SelectedIndex = i
                        Exit For
                    End If
                Next

            Else

                dd2.Items.Clear()
                dd2.Items.Add("[Seleccione una fuente]")
            End If

        End If

    End Sub

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim row As GridViewRow = sender.parent.parent

        Dim dd2 As DropDownList
        Dim dd1 As DropDownList

        Dim grupo As Integer = -1

        dd1 = row.FindControl("dd1")
        dd2 = row.FindControl("dd2")

        dd2.Items.Clear()
        dd2.Items.Add("[Seleccione una Fuente]")

        If dd1.SelectedIndex > 0 Then
            grupo = dd1.SelectedItem.Value
        End If

        llenarFuentes(grupo, dd2)

    End Sub

    Private Sub llenarFuentes(ByVal idGrupo As Integer, ByRef dd As DropDownList)

        Dim cEntidad As New cFUENTEFINANCIAMIENTOS

        dd.DataSource = cEntidad.RecuperarPorGrupo(idGrupo)
        dd.DataTextField = "nombre"
        dd.DataValueField = "idFuenteFinanciamiento"
        dd.DataBind()

    End Sub

    Protected Sub btn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn1.Click
        Dim alerta As String

        alerta = CType(("/Reportes/frmRptProgramacionFuente.aspx?idGrupo=" & Me.ViewState("IDGRUPO")), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    Protected Sub btn2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn2.Click

        Dim xidGrupo As Integer
        Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMACION
        xidGrupo = Me.ViewState("IDGRUPO")

        If cEntidad.verificarCierreGrupo(xidGrupo) <> 0 Then
            Me.MsgBox1.ShowAlert("Debe definir fuentes para cada programación, así como lugares de entrega para cada establecimiento", "Mensaje", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        If cEntidad.actualizarGrupo(xidGrupo, 2, HttpContext.Current.User.Identity.Name) = -1 Then
            Me.MsgBox1.ShowAlert("Imposible cerrar consolidado", "Mensaje", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            Me.MsgBox1.ShowAlert("Consolidado actualizado", "Mensaje", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Me.gvLista.Enabled = False
            Me.btn2.Enabled = False
            Exit Sub
        End If

    End Sub
End Class
