Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.CertificacionHelpers
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Utils

Partial Class frmCatLista
    Inherits System.Web.UI.Page


    Public Property IdLista() As Integer
        Get
            Return CType(ViewState("id"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("id") = value
        End Set
    End Property

  

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            cargarDatos()

        End If
    End Sub
    Public Sub cargarDatos()

        Me.GridView1.DataSource = Listas.ObtenerTodos()
        Me.GridView1.DataBind()

        Suministros.CargarALista(DropDownList1, True)

    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' aqui es el boton OK del agregar/editar

        If Me.TextBox1.Text = "" Then
            Exit Sub
        Else
            Dim lista = New SAB_CP_CAT_LISTA With {
            .IdSuministro = CType(Me.DropDownList1.SelectedValue, Integer?),
            .Nombre = Me.TextBox1.Text
            }

            If IdLista = 0 Then
                Listas.Agregar(lista)
            Else
                lista.Id = IdLista
                Listas.Actualizar(lista)
            End If

            IdLista = 0
        End If
        cargarDatos()
        Me.mdlPopup.Hide()
    End Sub
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)
        'boton cancelar del agregar/editar
        Me.mdlPopup.Hide()

    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        IdLista = 0
        Me.TextBox1.Text = ""
        Me.mdlPopup.Show()
    End Sub

    Protected Sub lnkEdit_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        
        Dim lista = Listas.Obtener(CType(Me.GridView1.DataKeys(row.RowIndex).Values(0).ToString, Integer))
        If Not IsNothing(lista) Then
            IdLista = lista.Id
            Me.DropDownList1.SelectedValue = CType(lista.IdSuministro, String)
            Me.TextBox1.Text = lista.Nombre
            Me.mdlPopup.Show()
        End If
    End Sub

    Protected Sub lnkBorrar_OnClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnDetails As LinkButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        IdLista = CType(Me.GridView1.DataKeys(row.RowIndex).Values(0), Integer)
        Try
            Listas.Borrar(IdLista)
            IdLista = 0
            cargarDatos()
        Catch ex As Exception
            MessageBox.Alert("Error : " & ex.Message)
        End Try
        
    End Sub
End Class
