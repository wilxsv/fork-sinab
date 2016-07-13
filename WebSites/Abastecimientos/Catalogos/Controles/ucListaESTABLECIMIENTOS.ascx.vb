Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucListaESTABLECIMIENTOS
    Inherits System.Web.UI.UserControl

    Private mComponente As New cESTABLECIMIENTOS

    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerdsEstablecimiento()

        If ucFiltrarDatos1.CampoFiltro <> "" And ucFiltrarDatos1.ValorFiltro <> "" Then
            Try
                Select Case ds.Tables(0).Columns(ucFiltrarDatos1.CampoFiltro).DataType.Name
                    Case "String"
                        ds.Tables(0).DefaultView.RowFilter = ucFiltrarDatos1.CampoFiltro & " LIKE '%" & ucFiltrarDatos1.ValorFiltro & "%'"
                    Case "DateTime"
                        ds.Tables(0).DefaultView.RowFilter = ucFiltrarDatos1.CampoFiltro & " = '" & ucFiltrarDatos1.ValorFiltro & "'"
                    Case Else
                        ds.Tables(0).DefaultView.RowFilter = ucFiltrarDatos1.CampoFiltro & " = " & ucFiltrarDatos1.ValorFiltro
                End Select
            Catch ex As Exception
            End Try
        End If

        Me.gvLista.DataSource = ds.Tables(0).DefaultView

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        If Not Page.IsPostBack Then
            ucFiltrarDatos1.AddColumnasExcluidas("Fax")
            ucFiltrarDatos1.AddColumnasExcluidas("Teléfono")
            ucFiltrarDatos1.ValorColumnas = gvLista.Columns
        End If

        Return 1

        '    Me.ucBarraNavegacion1.ibtnImprimirOnClientClick = ReporteEmpleados(ucListaESTABLECIMIENTOS1.CampoFiltro, ucListaESTABLECIMIENTOS1.ValorFiltro)
        'Private Function ReporteEmpleados(Optional ByVal CampoFiltro As String = "", Optional ByVal ValorFiltro As String = "") As String

        '    Dim s As New StringBuilder
        '    s.Append("window.open('")
        '    s.Append(Request.ApplicationPath)
        '    s.Append("/Reportes/FrmRptEstablecimientos.aspx")

        '    If Not String.IsNullOrEmpty(CampoFiltro) Then
        '        s.Append("?cf=")
        '        s.Append(Server.HtmlEncode(CampoFiltro))
        '        s.Append("&vf=")
        '        s.Append(Server.HtmlEncode(ValorFiltro))
        '    End If

        '    s.Append("', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")

        '    Return s.ToString

        'End Function

    End Function

    Private Sub gvLista_RowDeleting(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDESTABLECIMIENTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)

        If Me.mComponente.EliminarESTABLECIMIENTOS(IDESTABLECIMIENTO) <> 1 Then
            'Si se cometio un error
            MsgBox1.ShowAlert("Error al Eliminar Registro", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            e.Cancel = True
        Else
            If Me.CargarDatos() <> 1 Then
                MsgBox1.ShowAlert("Error al Recuperar Lista", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If
        End If

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub LnkbPrimero_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.gvLista.PageIndex = 0
        Me.CargarDatos()
    End Sub

    Protected Sub LnkbUltimo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.gvLista.PageIndex = Me.gvLista.PageCount
        Me.CargarDatos()
    End Sub

    Protected Sub LnkbAnterior_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.gvLista.PageIndex > 0 Then
            Me.gvLista.PageIndex = Me.gvLista.PageIndex - 1
            Me.CargarDatos()
        End If
    End Sub

    Protected Sub LnkbSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.gvLista.PageIndex < Me.gvLista.PageCount Then
            Me.gvLista.PageIndex = Me.gvLista.PageIndex + 1
            Me.CargarDatos()
        End If
    End Sub

    Protected Sub ucFiltrarDatos1_Buscar() Handles ucFiltrarDatos1.Buscar
        CargarDatos()
    End Sub

End Class
