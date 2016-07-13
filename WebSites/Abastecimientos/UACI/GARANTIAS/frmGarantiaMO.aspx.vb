Imports ABASTECIMIENTOS.NEGOCIO

Partial Class UACI_GARANTIAS_frmGarantiaMO
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
            Select Case Request.QueryString("idtg")
                Case Is = 1
                    Me.Label1.Text = "Mantenimiento de Oferta"
                    Me.Label2.Text = "MANTENIMIENTO DE OFERTA"
                Case Is = 2
                    Me.Label1.Text = "Buena Inversión de Anticipo"
                    Me.Label2.Text = "BUENA INVERSIÓN DE ANTICIPO"
                Case Is = 3
                    Me.Label1.Text = "Cumplimiento de Contrato"
                    Me.Label2.Text = "CUMPLIMIENTO DE CONTRATO"
                Case Is = 4
                    Me.Label1.Text = "Buena Obra"
                    Me.Label2.Text = "BUENA OBRA"
                Case Is = 5
                    Me.Label1.Text = "Buen servicio, Funcionamiento y Calidad de los Bienes"
                    Me.Label2.Text = "BUEN SERVICIO, FUNCIONAMIENTO Y CALIDAD DE LOS BIENES"
            End Select
            cargarDatos()
        Else
            If Not Me.ViewState("id") Is Nothing Then Me.ide = Me.ViewState("id")
            'If Not Me.ViewState("idTipoG") Is Nothing Then Me.idTipoG = Me.ViewState("idTipoG")
        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Public Sub cargarDatos()
        Dim cx As New cREGISTROGARANTIAS
        Me.GridView1.DataSource = cx.ObtenerDataSetGarantias(Session("IdEstablecimiento"), Request.QueryString("idtg"))
        If Request.QueryString("idtg") = 1 Then
            Me.GridView1.Columns(6).HeaderText = "Fecha de Apertura de Oferta"
            Me.GridView1.Columns(3).Visible = False
        ElseIf Request.QueryString("idtg") = 2 Then
            Me.GridView1.Columns(7).HeaderText = "Fecha de Ejecución del 100% Anticipo"
        ElseIf Request.QueryString("idtg") = 3 Then
            Me.GridView1.Columns(6).HeaderText = "Fecha de Inicio de Vigencia de la Garantía"
        End If
        Me.GridView1.DataBind()
    End Sub
    Protected Sub BtnViewDetails2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnDetails As LinkButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        ide = Me.GridView1.DataKeys(row.RowIndex).Values(0)
        'idTipoG = Me.GridView1.DataKeys(row.RowIndex).Values(1)

        Me.Modalpopupextender1.Show()
    End Sub
    Protected Sub BtnSave2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim cx As New cREGISTROGARANTIAS
        cx.EliminarREGISTROGARANTIAS(ide, Session("IdEstablecimiento"))
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

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Modificar una solicitud de compra
        Dim btnDetails As LinkButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        'If Me.dgLista.DataKeys(row.RowIndex).Values(0) = "Individual" Then
        Response.Redirect("~/UACI/GARANTIAS/wfRegistroNuevaGarantia.aspx?idtg=" & Request.QueryString("idtg") & "&id=" & Me.GridView1.DataKeys(row.RowIndex).Values(0))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("~/UACI/GARANTIAS/wfRegistroNuevaGarantia.aspx?idtg=" & Request.QueryString("idtg"))
    End Sub
End Class
