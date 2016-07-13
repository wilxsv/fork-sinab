Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucSeleccionContratoRecepcion
    Inherits System.Web.UI.UserControl

    Dim cC As New cCONTRATOS

    Public Event SeleccionarContrato()

    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _IDALMACEN As Integer

#Region "Propiedades"

    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
        End Set
    End Property

    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            _IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property

    Public Property IDCONTRATO() As Integer
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDCONTRATO = value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", value)
        End Set
    End Property

    Public Property IDALMACEN() As Integer
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Integer)
            _IDALMACEN = value
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.ViewState.Remove("IDALMACEN")
            Me.ViewState.Add("IDALMACEN", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.IDALMACEN = Session.Item("IdAlmacen")
            ddlALMACENESESTABLECIMIENTOS1.RecuperarListaSubAlmacenes(Session.Item("IdEstablecimiento"))

            If ddlALMACENESESTABLECIMIENTOS1.Items.Count > 1 Then
                Me.plAlmacen.Visible = True
                ddlALMACENESESTABLECIMIENTOS1.SelectedValue = Me.IDALMACEN
            Else
                Me.plAlmacen.Visible = False
            End If

            CargarProveedores()

        Else
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.IDCONTRATO = Me.ViewState("IDCONTRATO")
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.IDALMACEN = Me.ViewState("IDALMACEN")
        End If

    End Sub

    Protected Sub gvProveedores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProveedores.SelectedIndexChanged
        Me.IDPROVEEDOR = Me.gvProveedores.DataKeys(Me.gvProveedores.SelectedIndex).Values.Item("IDPROVEEDOR")
        Dim lnk = CType(gvProveedores.SelectedRow.FindControl("LinkButton1"), LinkButton)
        lblSelected.Text = "Proveedor seleccionado: " + lnk.Text
        CargarContratos()
    End Sub

    Protected Sub gvContratos_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvContratos.SelectedIndexChanged
        Me.IDESTABLECIMIENTO = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values.Item("IDESTABLECIMIENTO")
        Me.IDPROVEEDOR = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values.Item("IDPROVEEDOR")
        Me.IDCONTRATO = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values.Item("IDCONTRATO")

        RaiseEvent SeleccionarContrato()
    End Sub

    Protected Sub ddlALMACENESESTABLECIMIENTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlALMACENESESTABLECIMIENTOS1.SelectedIndexChanged
        Me.IDALMACEN = Me.ddlALMACENESESTABLECIMIENTOS1.SelectedValue
        CargarProveedores()
    End Sub

    Public Sub CargarContratos()
        Me.plSeleccionarContrato.Visible = True

        Me.gvContratos.DataSource = cC.ObtenerDocumentosPendientesPorProveedorDS(Me.IDALMACEN, Me.IDPROVEEDOR)
        Me.gvContratos.DataBind()


    End Sub

    Public Sub CargarProveedores()
        Limpiar()

        Me.gvProveedores.DataSource = cC.ObtenerProveedoresEntregasPendiente(Me.IDALMACEN)
        Me.gvProveedores.DataBind()

        Me.plSeleccionarProveedor.Visible = True

    End Sub

    Sub Limpiar()
        Me.plSeleccionarContrato.Visible = False

        Me.gvProveedores.DataSource = Nothing
        Me.gvProveedores.DataBind()
        Me.gvProveedores.SelectedIndex = -1

        Me.gvContratos.DataSource = Nothing
        Me.gvContratos.DataBind()
        Me.gvContratos.SelectedIndex = -1
    End Sub

   
   
End Class
