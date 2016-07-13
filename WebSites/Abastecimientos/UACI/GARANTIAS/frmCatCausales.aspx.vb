Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class frmCatCausales
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
    Private _idTipoG As Integer
    Public Property idTipoG() As Integer
        Get
            Return Me._idTipoG
        End Get
        Set(ByVal value As Integer)
            Me._idTipoG = value
            If Not Me.ViewState("idTipoG") Is Nothing Then Me.ViewState.Remove("idTipoG")
            Me.ViewState.Add("idTipoG", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            cargarDatos()
        Else
            If Not Me.ViewState("id") Is Nothing Then Me.ide = Me.ViewState("id")
            If Not Me.ViewState("idTipoG") Is Nothing Then Me.idTipoG = Me.ViewState("idTipoG")
        End If
    End Sub
    Public Sub cargarDatos()
        Dim cx As New cCAUSALESCG
        Me.GridView1.DataSource = cx.ObtenerCausales()
        Me.GridView1.DataBind()

        Me.DropDownList1.DataSource = cx.ObtenerTiposGarantias()
        Me.DropDownList1.DataTextField = "NOMBRE"
        Me.DropDownList1.DataValueField = "IDTIPOGARANTIA"
        Me.DropDownList1.DataBind()
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' aqui es el boton OK del agregar/editar

        If Me.TextBox1.Text = "" Then
            Exit Sub
        Else
            Dim cx As New cCAUSALESCG
            Dim x As New CAUSALESCG
            x.IDCAUSAL = ide
            x.IDTIPOGARANTIA = Me.DropDownList1.SelectedValue
            x.NOMBRE = Me.TextBox1.Text
            cx.ActualizarCAUSALES(x)
            ide = 0
            idTipoG = 0
        End If
        cargarDatos()
        Me.mdlPopup.Hide()
    End Sub
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)
        'boton cancelar del agregar/editar
        Me.mdlPopup.Hide()

    End Sub



    Protected Sub BtnSave2_Click(ByVal sender As Object, ByVal e As EventArgs)


        Dim cx As New cCAUSALESCG
        cx.EliminarCAUSALES(ide, idtipog)
        ide = 0
        idTipoG = 0
        cargarDatos()
        ' aqui es el boton OK del eliminar
        Me.Modalpopupextender1.Hide()

    End Sub
    Protected Sub BtnClose2_Click(ByVal sender As Object, ByVal e As EventArgs)
        'boton cancelar del eliminar
        ide = 0
        idTipoG = 0
        Me.Modalpopupextender1.Hide()

    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim cx As New cCAUSALESCG
        Dim ds As New Data.DataSet
        ds = cx.ObtenerDataSetPorId2(Me.GridView1.DataKeys(row.RowIndex).Values(0).ToString, Me.GridView1.DataKeys(row.RowIndex).Values(1).ToString)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.Label1.Text = ds.Tables(0).Rows(0).Item(0)
            ide = ds.Tables(0).Rows(0).Item(0)
            Me.DropDownList1.SelectedValue = ds.Tables(0).Rows(0).Item(1)
            idTipoG = ds.Tables(0).Rows(0).Item(1)
            Me.TextBox1.Text = ds.Tables(0).Rows(0).Item(2)
            Me.mdlPopup.Show()
        End If

        'Me.updPnlCustomerDetail.Update()

    End Sub

    Protected Sub BtnViewDetails2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        ide = Me.GridView1.DataKeys(row.RowIndex).Values(0)
        idTipoG = Me.GridView1.DataKeys(row.RowIndex).Values(1)

        Me.Modalpopupextender1.Show()
    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.updPnlCustomerDetail.Update()

        Dim cx As New cCAUSALESCG
        Dim id As Integer
        id = cx.ObtenerID2(idTipoG)
        Me.Label1.Text = id
        Me.TextBox1.Text = ""
        Me.mdlPopup.Show()
    End Sub
End Class
