Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Linq
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Utils


Partial Class ucListaDOCUMENTOSBASE
    Inherits System.Web.UI.UserControl

    Private mComponente As New cDOCUMENTOSBASE


    Public WriteOnly Property PermitirEliminar() As Boolean
        Set(ByVal value As Boolean)
            Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = value
        End Set
    End Property

    Public Function CargarDatos() As Integer

        Dim ds = DocumentoBase.ObtenerTodos()

      

        If ucFiltrarDatos1.CampoFiltro <> "" And ucFiltrarDatos1.ValorFiltro <> "" Then
            Try
                
                If ucFiltrarDatos1.CampoFiltro = "TIPODOCUMENTO" Then
                    ds = ds.Where(Function(doc) doc.SAB_CAT_TIPODOCUMENTOBASE.DESCRIPCION.Contains(ucFiltrarDatos1.ValorFiltro)).ToList()
                Else
                    If ucFiltrarDatos1.CampoFiltro = "DESCRIPCION" Then
                        ds = ds.Where(Function(doc) doc.DESCRIPCION.Contains(ucFiltrarDatos1.ValorFiltro)).ToList()
                    End If
                End If

            Catch ex As Exception
            End Try
        End If

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        If Not Page.IsPostBack Then ucFiltrarDatos1.ValorColumnas = gvLista.Columns

        Return 1

    End Function

    Private Sub gvLista_RowDeleting(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDDOCUMENTOSBASE As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)

        Try
            DocumentoBase.Eliminar(IDDOCUMENTOSBASE)
            CargarDatos()
            SINAB_Utils.MessageBox.Alert("el item se ha borrado con exito")
        Catch ex As Exception
            If Not IsNothing(ex.InnerException) Then
                SINAB_Utils.MessageBox.Alert("Error al eliminar item, es probable que este asociado a un documento. Error: " & ex.InnerException.Message)
            Else
                SINAB_Utils.MessageBox.Alert("Error al eliminar item. Error: " & ex.Message)
            End If

        End Try
        'If Me.mComponente.EliminarDOCUMENTOSBASE(IDDOCUMENTOSBASE) <> 1 Then
        '    'Si se cometio un error
        '    MsgBox1.ShowAlert("Error al Eliminar Registro", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        '    e.Cancel = True
        'Else
        '    If Me.CargarDatos() <> 1 Then
        '        MsgBox1.ShowAlert("Error al Recuperar Lista", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        '    End If
        'End If

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub ucFiltrarDatos1_Buscar() Handles ucFiltrarDatos1.Buscar
        CargarDatos()
    End Sub

End Class
