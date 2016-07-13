Imports ABASTECIMIENTOS.NEGOCIO

Partial Class URMIM_frmMantProgramacionConsolidado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página
            'ocultar menu
            Me.Master.ControlMenu.Visible = False

            'Me.ucBarraNavegacion1.Visible = False
            'Me.ucBarraNavegacion1.Navegacion = False
            'Me.ucBarraNavegacion1.PermitirEditar = False
            'Me.ucBarraNavegacion1.PermitirGuardar = False
            'Me.ucBarraNavegacion1.PermitirConsultar = False
            'Me.ucBarraNavegacion1.PermitirImprimir = False

            CargarDatosDisponibles()
            CargarConsolidados()

        End If

    End Sub

    Private Sub CargarConsolidados() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACION

        ds = mComponente.obtenerGrupos

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Private Sub CargarDatosDisponibles() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACION

        ds = mComponente.obtenerDsProgramacionDisponibles()

        Me.gvLista2.DataSource = ds

        Try
            Me.gvLista2.DataBind()
        Catch ex As Exception
            gvLista2.PageIndex = 0

            Me.gvLista2.DataBind()
        End Try

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'evento al presionar link menu
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub

    'Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

    '    Me.gvLista.PageIndex = e.NewPageIndex
    '    CargarDatos()

    'End Sub

    Protected Sub btnIniciar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIniciar.Click

        Dim texto As String = ""
        Dim idSum As Integer = 0
        Dim inconsistencia As Integer = 0
        Dim idS As Integer

        'Revisamos si seleccionamos por lo menos una programacion
        For Each row As GridViewRow In gvLista2.Rows

            Dim idProgramacion As Integer = Me.gvLista2.DataKeys(row.RowIndex).Values(0)
            Dim idSuministro As Integer = Me.gvLista2.DataKeys(row.RowIndex).Values(1)
            idS = idSuministro

            If idSum = 0 Then
                idSum = idSuministro
            End If

            Dim chkB As CheckBox

            chkB = row.FindControl("chkPrg")

            If chkB.Checked = True Then

                If texto = "" Then
                    texto = "" & idProgramacion
                Else
                    texto = texto & "," & idProgramacion
                End If

                'If idSum <> idSuministro Then
                '    inconsistencia = 1
                'End If

            End If

        Next

        If texto = "" Then
            Me.MsgBox1.ShowAlert("Debe seleccionar al menos una programación.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        'If inconsistencia = 1 Then
        '    Me.MsgBox1.ShowAlert("No puede seleccionar tipos de suministros diferentes para consolidarlos", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        '    Exit Sub
        'End If

        Response.Redirect("./frmMantProgramacionCrearConsolidado.aspx?id=" & texto & "&s=" & idS, False) 'redirecciona a la pagina principal

    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim ck As CheckBox = e.Row.FindControl("chkSelect")

            If Me.gvLista.DataKeys(e.Row.RowIndex).Values(1) > 2 Then
                ck.Enabled = False
            Else
                ck.Enabled = True
            End If

            Dim btn As BulletedList
            Dim grupo As Integer = Me.gvLista.DataKeys(e.Row.RowIndex).Values(0)

            Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMACION
            Dim arr As ArrayList = cEntidad.obtenerProgramacionesGrupo(grupo)

            btn = e.Row.FindControl("lstItems")

            For i As Integer = 0 To arr.Count - 1
                btn.Items.Add(arr(i))
            Next

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim i As Integer = 0
        Dim grupo As Integer

        For Each row As GridViewRow In gvLista.Rows

            Dim ck As CheckBox = row.FindControl("chkSelect")

            If ck.Checked = True Then

                grupo = Me.gvLista.DataKeys(row.RowIndex).Values(0)
                i += 1

            End If

        Next

        If i <> 1 Then
            Me.MsgBox1.ShowAlert("Debe seleccionar un grupo a enviar.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            'Aquí se manda a la uaci CargarSolicitudesURMIM.aspx

            Response.Redirect("~/uaci/CargarSolicitudesURMIM.aspx") '?id=" & texto & "&s=" & idS, False) 'redirecciona a la pagina principal


        End If

    End Sub

    Protected Sub gvLista_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvLista.PageIndexChanged

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        gvLista.PageIndex = e.NewPageIndex
        CargarConsolidados()

    End Sub
End Class
