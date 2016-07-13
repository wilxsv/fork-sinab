
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.CertificacionHelpers


Partial Class frmCatAspectos
    Inherits System.Web.UI.Page


    Public Property IdAspecto() As Integer
        Get
            Return CType(ViewState("id"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("id") = value
        End Set
    End Property

    Public Property IdLista() As Integer
        Get
            Return CType(ViewState("idLista"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("idLista") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            cargarDatos()
        Else
            If Not Me.ViewState("id") Is Nothing Then Me.IdAspecto = Me.ViewState("id")
            If Not Me.ViewState("idLista") Is Nothing Then Me.IdLista = Me.ViewState("idLista")
        End If
    End Sub
    Public Sub cargarDatos()

        Me.GridView1.DataSource = Aspectos.ObtenerTodos()
        Me.GridView1.DataBind()

        Listas.CargarALista(DropDownList1)

    End Sub



    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' aqui es el boton OK del agregar/editar

        If Me.TextBox1.Text = "" Then
            Exit Sub
        Else

            Dim x = New SAB_CP_CAT_ASPECTOS With {
                .Id = IdAspecto,
                .IdLista = CType(DropDownList1.SelectedValue, Integer),
                .nombre = TextBox1.Text,
                .orden = CType(tbOrden.Text, Integer?)
                }

            If IdAspecto = 0 Then
                Aspectos.Agregar(x)
            Else
                Aspectos.Actualizar(x)
            End If

            IdAspecto = 0
            IdLista = 0
        End If
        cargarDatos()
        Me.mdlPopup.Hide()
    End Sub
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)
        'boton cancelar del agregar/editar
        Me.mdlPopup.Hide()

    End Sub


    
    Protected Sub lnkEdit_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnDetails = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        IdAspecto = CType(Me.GridView1.DataKeys(row.RowIndex).Values(0), Integer)
        IdLista = CType(Me.GridView1.DataKeys(row.RowIndex).Values(1), Integer)

        Dim ds As SAB_CP_CAT_ASPECTOS = Aspectos.Obtener(IdLista, IdAspecto)
        If Not IsNothing(ds) Then
            IdLista = ds.IdLista
            IdAspecto = ds.Id
            TextBox1.Text = ds.nombre
            tbOrden.Text = ds.orden.ToString()
            Me.DropDownList1.SelectedValue = ds.IdLista.ToString()
            Me.mdlPopup.Show()
        End If
        'Me.updPnlCustomerDetail.Update()

    End Sub

    Protected Sub lnkDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnDetails = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        IdAspecto = CType(Me.GridView1.DataKeys(row.RowIndex).Values(0), Integer)
        IdLista = CType(Me.GridView1.DataKeys(row.RowIndex).Values(1), Integer)

        Aspectos.Eliminar(IdLista, IdAspecto)
        IdAspecto = 0
        IdLista = 0
        cargarDatos()
    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.updPnlCustomerDetail.Update()

      
        Me.TextBox1.Text = ""
        Me.mdlPopup.Show()
    End Sub
End Class
