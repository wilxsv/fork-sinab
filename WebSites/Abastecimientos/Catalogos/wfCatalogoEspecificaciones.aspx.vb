Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class wfCatalogoEspecificaciones
    Inherits System.Web.UI.Page

    Private _joker As Int64
    Private _sError As String


    Private mComponente As New cCATALOGOPRODUCTOS
    Private mEntidad As CATALOGOPRODUCTOS

    Public Event ErrorEvent(ByVal errorMessage As String)

#Region " Propiedades "

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property joker() As Int64
        Get
            Return Me._joker
        End Get
        Set(ByVal value As Int64)
            Me._joker = value
            If Not Me.ViewState("joker") Is Nothing Then Me.ViewState.Remove("joker")
            Me.ViewState.Add("joker", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Me.Label1.Text = Session("NomDependencia")
            CargarDDLs()
        Else
            If Not Me.ViewState("joker") Is Nothing Then Me._joker = Me.ViewState("joker")
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Private Sub CargarDDLs()
        
        Me.ddlSUMINISTROS1.RecuperarPorUnidadTecnica(Session("IdDependencia"))
        Me.ddlSUMINISTROS1.SelectedIndex = 0
        Me.ddlGRUPOS1.RecuperarListaFiltradaPorUT(Me.ddlSUMINISTROS1.SelectedValue, Session("IdDependencia"))
        Me.ddlGRUPOS1.SelectedIndex = 0
        Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, Session("IdDependencia"))
        Me.ddlSUBGRUPOS1.SelectedIndex = 0

        CargarProductos()
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        Me.ddlGRUPOS1.RecuperarListaFiltradaPorUT(Me.ddlSUMINISTROS1.SelectedValue, Session("IdDependencia"))
        Me.ddlGRUPOS1.SelectedIndex = 0
        Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, Session("IdDependencia"))
        Me.ddlSUBGRUPOS1.SelectedIndex = 0
        CargarProductos()
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        Me.ddlSUBGRUPOS1.RecuperarListaFiltradaUT(Me.ddlGRUPOS1.SelectedValue, Session("IdDependencia"))
        Me.ddlSUBGRUPOS1.SelectedIndex = 0
        CargarProductos()
    End Sub

    Protected Sub ddlSUBGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUBGRUPOS1.SelectedIndexChanged
        CargarProductos()
    End Sub

    Private Sub CargarProductos()

        Dim IDSUBGRUPO As Integer = IIf(Me.ddlSUBGRUPOS1.Items.Count = 0, 0, Me.ddlSUBGRUPOS1.SelectedValue)

        Dim cCP As New cCATALOGOPRODUCTOS
        Me.gvLista.DataSource = cCP.ObtenerCatalogoProductosPorUT2(IDSUBGRUPO, Session("IdDependencia"))
        Me.gvLista.DataBind()

        Me.Panel2.Visible = False
        Me.Panel3.Visible = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.TextBox2.Text = ""
        Me.NumericBox2.Text = ""
        Me.TextBox1.Text = ""
        Me.Panel2.Visible = True
        joker = 1
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = sender

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim cc As New cCATALOGOPRODUCTOS
        Me.Label6.Text = cc.DevolverCodigoProducto(Me.gvLista.DataKeys(row.RowIndex).Values(0))
        Me.Label7.Text = cc.DevolverNombreProducto(Me.gvLista.DataKeys(row.RowIndex).Values(0))
        Me.Label8.Text = cc.DevolverUMProducto(Me.gvLista.DataKeys(row.RowIndex).Values(0))
        Me.Label11.Text = Me.gvLista.DataKeys(row.RowIndex).Values(0)
        Me.GridView1.DataSource = cc.ObtenerEspecificacionesTecnicas(Me.gvLista.DataKeys(row.RowIndex).Values(0))
        Me.GridView1.DataBind()

        Me.Panel3.Visible = True
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Or Me.NumericBox2.Text = "" Then
            Me.MsgBox1.ShowAlert("Faltan datos por completar.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Dim c As New cCATALOGOPRODUCTOS
        Dim ES As New ESPECIFICACION
        If joker = 1 Then
            ES.IDPRODUCTO = Me.Label11.Text
            ES.IDESPECIFICACION = c.ObtenerIDEspecificacionesTecnicas(Me.Label11.Text)
            ES.NOMBREESPECIFICACION = Me.TextBox2.Text
            ES.ESPECIFICACION = Me.TextBox1.Text
            ES.FECHAACTUALIZACION = DateTime.Now
            ES.PRECIO = Me.NumericBox2.Text
            ES.IDESTABLECIMIENTO = Session("IdEstablecimiento")

            If c.AgregarEspecificacionesTecnicas(ES) = 0 Then
                Me.MsgBox1.ShowAlert("Error al insertar la especificación.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Exit Sub
            Else
                Me.MsgBox1.ShowAlert("La especificación ha sido guardada satisfactoriamente.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.Panel2.Visible = False
                Me.GridView1.DataSource = c.ObtenerEspecificacionesTecnicas(Me.Label11.Text)
                Me.GridView1.DataBind()
            End If
        ElseIf joker = 2 Then
            ES.IDPRODUCTO = Me.Label11.Text
            ES.IDESPECIFICACION = Me.Label13.Text
            ES.NOMBREESPECIFICACION = Me.TextBox2.Text
            ES.ESPECIFICACION = Me.TextBox1.Text
            ES.FECHAACTUALIZACION = DateTime.Now
            ES.PRECIO = Me.NumericBox2.Text

            If c.ActualizarEspecificacionesTecnicas(ES) = 0 Then
                Me.MsgBox1.ShowAlert("Error al actualizar la especificación.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Exit Sub
            Else
                Me.MsgBox1.ShowAlert("La especificación ha sido guardada satisfactoriamente.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.Panel2.Visible = False
                Me.GridView1.DataSource = c.ObtenerEspecificacionesTecnicas(Me.Label11.Text)
                Me.GridView1.DataBind()
            End If
        End If
        

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Panel2.Visible = False
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim nb As LinkButton
            nb = e.Row.FindControl("LinkButton1")
            nb.Text = GridView1.DataKeys(e.Row.RowIndex).Values(2)

        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = sender

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim cc As New cCATALOGOPRODUCTOS
        Me.TextBox2.Text = Me.GridView1.DataKeys(row.RowIndex).Values(2)
        Me.NumericBox2.Text = Me.GridView1.DataKeys(row.RowIndex).Values(3)
        Me.TextBox1.Text = cc.DevolverTextoEspecificacion(Me.GridView1.DataKeys(row.RowIndex).Values(0), Me.GridView1.DataKeys(row.RowIndex).Values(1))
        Me.Label11.Text = Me.GridView1.DataKeys(row.RowIndex).Values(0)
        Me.Label13.Text = Me.GridView1.DataKeys(row.RowIndex).Values(1)

        Me.Panel2.Visible = True
        joker = 2
    End Sub
End Class
