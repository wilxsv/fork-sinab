Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils

Partial Class URMIM_frmMantProgramacionCrearConsolidado
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'Navegacion
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

    Private Sub CargarDatosDisponibles() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACION

        Dim arr As New ArrayList
        Dim strB As New StringBuilder

        If Request.QueryString("id") Is Nothing Or Request.QueryString("s") Is Nothing Then Response.Redirect("./frmMantProgramacionConsolidado.aspx", False) 'redirecciona a la pagina principal

        If Not IsNumeric(Request.QueryString("s")) Then Response.Redirect("./frmMantProgramacionConsolidado.aspx", False) 'redirecciona a la pagina principal

        Dim texto As String = Request.QueryString("id")
        Dim texto2() As String = texto.Split(",")
        Dim idSumin As Integer = Request.QueryString("s")

        If texto2.Length = 0 Then
            Response.Redirect("./frmMantProgramacionConsolidado.aspx", False) 'redirecciona a la pagina principal
        End If

        Dim programaciones As New ArrayList

        Dim precios As New ArrayList
        Dim entregas As New ArrayList
        Dim errPrg As Boolean = False

        For k As Integer = 0 To UBound(texto2)
            If Not IsNumeric(texto2(k)) Then
                errPrg = True
                Exit For
            End If
            programaciones.Add(texto2(k))
        Next

        If errPrg = True Then
            Response.Redirect("./frmMantProgramacionConsolidado.aspx", False) 'redirecciona a la pagina principal
        End If

        Dim datos() As String = {"", "", "", "", "", ""}
        Dim inconsistencias() As Boolean = {False, False, False, False, False, False}

        ds = mComponente.obtenerDsProgramacionListaID(texto)

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        'Revisamos por inconsistencias en las programaciones. Fecha creacion, fecha ultimo  programa, fecha corte, meses cpm, meses planeacion, indice inflacionario
        For Each row As GridViewRow In gvLista.Rows

            If datos(0) = "" Then
                For i As Integer = 0 To 5
                    datos(i) = Me.gvLista.DataKeys(row.RowIndex).Values(i)
                Next
            End If

            'Verifiquemos
            For i As Integer = 0 To 5
                If datos(i) <> Me.gvLista.DataKeys(row.RowIndex).Values(i) Then inconsistencias(i) = True
            Next

        Next

        If inconsistencias(0) = True Then arr.Add("Fechas de creación")
        If inconsistencias(1) = True Then arr.Add("Fechas de finalización de último programa de compras")
        If inconsistencias(2) = True Then arr.Add("Fechas de corte de consumos y existencias")
        If inconsistencias(3) = True Then arr.Add("Meses para el cálculo del CPM")
        If inconsistencias(4) = True Then arr.Add("Horizonte de planeación")
        If inconsistencias(5) = True Then arr.Add("Indice inflacionario en el precio")

        If arr.Count <> 0 Then

            strB.Append("Se encontraron inconsistencias en: <br>" & vbNewLine)

            strB.Append("<ul>" & vbNewLine)

            For j As Integer = 0 To arr.Count - 1

                strB.Append("<li>" & arr.Item(j) & vbNewLine)

            Next

            strB.Append("</ul>" & vbNewLine)

        Else
            strB.Append("No existen advertencias")
        End If

        Me.dvAdvertencia.InnerHtml = strB.ToString

        mComponente.obtenerListaInconsistenciasProgramacion(idSumin, programaciones, precios, entregas)

        If precios.Count = 0 And entregas.Count = 0 Then
            Me.dvErrores.InnerHtml = ("No se detectaron errores")
        Else

            strB = New StringBuilder

            If precios.Count > 0 Then

                strB.Append("<br>Se encontraron diferencias de <font color='red'>precios</font> para los siguientes códigos de producto: <br><br>" & vbNewLine)

                For k As Integer = 0 To precios.Count - 1
                    If k = 0 Then
                        strB.Append(precios(k) & "")
                    Else
                        strB.Append(", " & precios(k) & "")
                    End If
                Next

                strB.Append("<br>" & vbNewLine)

            End If

            If entregas.Count > 0 Then

                strB.Append("<br>Se encontraron diferencias de <font color='red'>entregas</font> para los siguientes productos: <br><br>" & vbNewLine)

                For k As Integer = 0 To entregas.Count - 1
                    If k = 0 Then
                        strB.Append(entregas(k) & "")
                    Else
                        strB.Append(", " & entregas(k) & "")
                    End If
                Next

                strB.Append("<br>" & vbNewLine)

            End If

            Me.dvErrores.InnerHtml = strB.ToString

        End If

        'Inconsistencias en las tablas de entregas
        Dim errTabla As Boolean = False

        mComponente.obtenerListaInconsistenciasEntregasProgramacion(programaciones, errTabla)

        If errTabla = True Then
            Me.dvTabla.InnerHtml = "<br>Existen inconsistencias en los <font color='red'>dias/porcentajes de entrega</font> de las programaciones"
        End If

        If precios.Count > 0 Or entregas.Count > 0 Or errTabla = True Then
            Me.btnIniciar.Enabled = False
        Else
            Me.btnIniciar.Enabled = True
        End If

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

        Dim arr As New ArrayList
        Dim dbEntidad As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMACION

        For Each row As GridViewRow In gvLista.Rows
            arr.Add(Me.gvLista.DataKeys(row.RowIndex).Values(6))
        Next

        If dbEntidad.insertarGrupoProgramacion(arr, HttpContext.Current.User.Identity.Name) = -1 Then
            MessageBox.Alert("Error al consolidar programaciones.", "Error")
            ' Me.MsgBox1.ShowAlert("Error al consolidar programaciones.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            Response.Redirect("./frmMantProgramacionConsolidado.aspx", False) 'redirecciona a la pagina principal
        End If

    End Sub
End Class
