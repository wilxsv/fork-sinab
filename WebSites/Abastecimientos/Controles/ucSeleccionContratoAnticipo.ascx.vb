Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Controles_ucSeleccionContratoAnticipo
    Inherits System.Web.UI.UserControl

    Dim cCon As New cCONTRATOS
    Public Event btnNumContrato_Click()
    Public Event gvDoc_SelectedIndexChanged()
    Private _idContrato As Integer
    Private _idalmacen As Integer
    Private _idproveedor As Integer
    Private _idestablecimiento As Integer

    Public Property IdContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Public Property IdProveedor() As Integer
        Get
            Return _idproveedor
        End Get
        Set(ByVal value As Integer)
            _idproveedor = value
        End Set
    End Property
    Public Property IdAlmacen() As Integer
        Get
            Return _idalmacen
        End Get
        Set(ByVal value As Integer)
            _idalmacen = value
            If Not Me.ViewState("IdAlmacen") Is Nothing Then Me.ViewState.Remove("IdAlmacen")
            Me.ViewState.Add("IdAlmacen", value)
        End Set
    End Property
    Public Property IdEstablecimiento() As Integer
        Get
            Return _idestablecimiento
        End Get
        Set(ByVal value As Integer)
            _idestablecimiento = value
            If Not Me.ViewState("IdEstablecimiento") Is Nothing Then Me.ViewState.Remove("IdEstablecimiento")
            Me.ViewState.Add("IdEstablecimiento", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If _idestablecimiento <> 620 Then
                Me.panel1.Visible = False
                Me.panel2.Visible = True
                Me.gvListaProveedores.DataSource = cCon.ObtenerProveedoresAnticiposPendiente(Session.Item("IdAlmacen"))
                Me.gvListaProveedores.DataBind()
            End If
        Else
            If Not Me.ViewState("IdEstablecimiento") Is Nothing Then Me.IdEstablecimiento = Me.ViewState("IdEstablecimiento")
            If Not Me.ViewState("IdAlmacen") Is Nothing Then Me.IdAlmacen = Me.ViewState("IdAlmacen")
        End If
    End Sub

    Sub invisible()
        Me.pnDoc.Visible = False
        Me.Label3.Visible = False

        Try
            Me.gvListaProveedores.SelectedIndex = -1
        Catch ex As Exception

        End Try

        Try
            Me.gvDoc.SelectedIndex = -1
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GvListaProveedores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListaProveedores.SelectedIndexChanged

        IdProveedor = Me.gvListaProveedores.DataKeys(Me.gvListaProveedores.SelectedIndex).Values.Item("IDPROVEEDOR")

        Me.pnDoc.Visible = True
        Me.Label3.Visible = True

        Me.gvDoc.DataSource = cCon.ObtenerAnticiposPendientesPorProveedorDS(Session.Item("IdAlmacen"), IdProveedor)
        Me.gvDoc.DataBind()

    End Sub


    Protected Sub gvDoc_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDoc.SelectedIndexChanged
        IdContrato = Me.gvDoc.DataKeys(Me.gvDoc.SelectedIndex).Values.Item("IDCONTRATO")
        IdAlmacen = Session.Item("IdAlmacen")
        IdEstablecimiento = Me.gvDoc.DataKeys(Me.gvDoc.SelectedIndex).Values.Item("IDESTABLECIMIENTO")
        IdProveedor = Me.gvDoc.DataKeys(Me.gvDoc.SelectedIndex).Values.Item("IDPROVEEDOR")
        RaiseEvent gvDoc_SelectedIndexChanged()
    End Sub


    Protected Sub dpAlmancenes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dpAlmancenes.SelectedIndexChanged
        If Me.dpAlmancenes.SelectedIndex <> 0 Then
            Me.panel2.Visible = True
            Me.pnDoc.Visible = False
            Me.gvListaProveedores.DataSource = cCon.ObtenerProveedoresEntregasPendiente(CInt(Me.dpAlmancenes.SelectedValue))
            Me.gvListaProveedores.DataBind()
        End If
    End Sub

End Class
