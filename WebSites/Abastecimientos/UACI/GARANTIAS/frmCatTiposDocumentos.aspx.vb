Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class frmCatTiposDocumentos
    Inherits System.Web.UI.Page
    Private _id As Integer
    Public Property ide() As Integer
        Get
            Return Me._id
        End Get
        Set(ByVal value As Integer)
            Me._id = value
            If Not Me.ViewState("id") Is Nothing Then Me.ViewState.Remove("id")
            Me.ViewState.Add("id", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            cargarDatos()
        Else
            If Not Me.ViewState("id") Is Nothing Then Me.ide = Me.ViewState("id")
        End If
    End Sub
    Public Sub cargarDatos()
        Dim cx As New cTIPOSDOCUMENTOSCG
        Me.GridView1.DataSource = cx.ObtenerDataSetPorId()
        Me.GridView1.DataBind()
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' aqui es el boton OK del agregar/editar

        If Me.TextBox1.Text = "" Then
            Exit Sub
        Else
            Dim cx As New cTIPOSDOCUMENTOSCG
            Dim x As New TIPOSDOCUMENTOCG
            x.IDTIPODOCUMENTO = ide
            x.NOMBRE = Me.TextBox1.Text
            cx.ActualizarTIPOsDOCUMENTOs(x)
            ide = 0
        End If
        cargarDatos()
        Me.mdlPopup.Hide()
    End Sub
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)
        'boton cancelar del agregar/editar
        Me.mdlPopup.Hide()

    End Sub



    Protected Sub BtnSave2_Click(ByVal sender As Object, ByVal e As EventArgs)


        Dim cx As New cTIPOSDOCUMENTOSCG
        cx.EliminarTIPOsDOCUMENTOs(ide)
        ide = 0
        cargarDatos()
        ' aqui es el boton OK del eliminar
        Me.Modalpopupextender1.Hide()

    End Sub
    Protected Sub BtnClose2_Click(ByVal sender As Object, ByVal e As EventArgs)
        'boton cancelar del eliminar
        ide = 0
        Me.Modalpopupextender1.Hide()

    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim cx As New cTIPOSDOCUMENTOSCG
        Dim ds As New Data.DataSet
        ds = cx.ObtenerDataSetPorId2(Me.GridView1.DataKeys(row.RowIndex).Values(0).ToString)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.Label1.Text = ds.Tables(0).Rows(0).Item(0)
            ide = ds.Tables(0).Rows(0).Item(0)
            Me.TextBox1.Text = ds.Tables(0).Rows(0).Item(1)
            Me.mdlPopup.Show()
        End If

        'Me.updPnlCustomerDetail.Update()

    End Sub

    Protected Sub BtnViewDetails2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        ide = Me.GridView1.DataKeys(row.RowIndex).Values(0)

        Me.Modalpopupextender1.Show()
    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.updPnlCustomerDetail.Update()

        Dim cx As New cTIPOSDOCUMENTOSCG
        Dim id As Integer
        id = cx.ObtenerID2
        Me.Label1.Text = id
        Me.TextBox1.Text = ""
        Me.mdlPopup.Show()
    End Sub
End Class
