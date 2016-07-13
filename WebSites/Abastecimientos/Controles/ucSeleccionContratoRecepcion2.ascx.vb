Imports ABASTECIMIENTOS.NEGOCIO
Partial Class Controles_ucSeleccionContratoRecepcion2
    Inherits System.Web.UI.UserControl

    Dim cPro As New cPROVEEDORES
    Public Event btnNumContrato_Click()
    Public Event gvDoc_SelectedIndexChanged()
    Private _idProceso As Integer
    Private _idalmacen As Integer
    Private _idproveedor As Integer
    Private _idestablecimiento As Integer


    Public Property IdProceso() As Integer
        Get
            Return _idProceso
        End Get
        Set(ByVal value As Integer)
            _idProceso = value
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
        End Set
    End Property
    Public Property IdEstablecimiento() As Integer
        Get
            Return _idestablecimiento
        End Get
        Set(ByVal value As Integer)
            _idestablecimiento = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If _idestablecimiento <> 620 Then
                Me.panel1.Visible = False
                Me.panel2.Visible = True
                Me.gvListaProveedores.DataSource = cPro.obtenerProveedoresAdjudicadosEnAlmacen(Session.Item("IdAlmacen"))
                Me.gvListaProveedores.DataBind()
            End If

        End If
    End Sub

    Protected Sub GvListaProveedores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvListaProveedores.SelectedIndexChanged

        IdProveedor = Me.gvListaProveedores.DataKeys(Me.gvListaProveedores.SelectedIndex).Values.Item("IDPROVEEDOR")

        Me.pnDoc.Visible = True
        Me.Label3.Visible = True

        Me.gvDoc.DataSource = cPro.obtenerModalidadesCompraEnAlmacen(Session.Item("IdAlmacen"), IdProveedor)
        Me.gvDoc.DataBind()

    End Sub


    Protected Sub gvDoc_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDoc.SelectedIndexChanged
        IdProceso = Me.gvDoc.DataKeys(Me.gvDoc.SelectedIndex).Values.Item("IdProcesoCompra")
        IdAlmacen = Session.Item("IdAlmacen")
        IdEstablecimiento = Me.gvDoc.DataKeys(Me.gvDoc.SelectedIndex).Values.Item("IDESTABLECIMIENTO")
        IdProveedor = Me.gvDoc.DataKeys(Me.gvDoc.SelectedIndex).Values.Item("IDPROVEEDOR")
        RaiseEvent gvDoc_SelectedIndexChanged()
    End Sub
    Protected Sub dpAlmancenes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dpAlmancenes.SelectedIndexChanged
        If Me.dpAlmancenes.SelectedIndex <> 0 Then
            Me.panel2.Visible = True
            Me.pnDoc.Visible = False
            Me.gvListaProveedores.DataSource = cPro.obtenerProveedoresAdjudicadosEnAlmacen(CInt(Me.dpAlmancenes.SelectedValue))
            Me.gvListaProveedores.DataBind()
        End If
    End Sub

End Class
