Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucContratosProcesoCompra
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROCESOCOMPRA As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer

    Private _NumRegistros As Integer = 0

    Public Event SelectedIndexChanged()

#Region " Propiedades "

    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Integer)
            Me._IDESTABLECIMIENTO = Value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", Value)
        End Set
    End Property

    Public Property IDPROCESOCOMPRA() As Integer
        Get
            Return Me._IDPROCESOCOMPRA
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROCESOCOMPRA = Value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IdProcesoCompra", Value)
        End Set
    End Property

    Public Property IDPROVEEDOR() As Integer
        Get
            Return Me._IDPROVEEDOR
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROVEEDOR = Value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", Value)
        End Set
    End Property

    Public Property IDCONTRATO() As Integer
        Get
            Return Me._IDCONTRATO
        End Get
        Set(ByVal Value As Integer)
            Me._IDCONTRATO = Value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", Value)
        End Set
    End Property

    Public Property NumRegistros() As Integer
        Get
            Return Me._NumRegistros
        End Get
        Set(ByVal Value As Integer)
            Me._NumRegistros = Value
            If Not Me.ViewState("NumRegistros") Is Nothing Then Me.ViewState.Remove("NumRegistros")
            Me.ViewState.Add("NumRegistros", Value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me._IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me._IDCONTRATO = Me.ViewState("IDCONTRATO")

            If Not Me.ViewState("NumRegistros") Is Nothing Then Me._NumRegistros = Me.ViewState("NumRegistros")
        End If

    End Sub

    Public Sub CargarDatos()

        Dim cC As New cCONTRATOS
        Dim ds As Data.DataSet

        ds = cC.ObtenerContratosProcesoCompra(Me.IDPROCESOCOMPRA, Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO, 3)
        gvContratos.DataSource = ds

        If NumRegistros = 0 Then
            NumRegistros = ds.Tables(0).Rows.Count
        End If

        Me.gvContratos.SelectedIndex = -1

        Try
            Me.gvContratos.DataBind()
        Catch ex As Exception
            gvContratos.PageIndex = 0
            Me.gvContratos.DataBind()
        End Try

        If Me.gvContratos.Rows.Count = 0 Then
            Me.lblSeleccioneUnContrato.Visible = False
        Else
            Me.lblSeleccioneUnContrato.Visible = True
        End If

    End Sub

    Protected Sub gvContratos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvContratos.PageIndexChanging
        Me.gvContratos.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvContratos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvContratos.SelectedIndexChanged

        Select Case gvContratos.Rows.Count

            Case Is = 1

                If NumRegistros = 1 Then
                    If Me.IDCONTRATO = 0 Then
                        Me.IDPROVEEDOR = Me.gvContratos.DataKeys(gvContratos.SelectedIndex).Values(1)
                        Me.IDCONTRATO = Me.gvContratos.DataKeys(gvContratos.SelectedIndex).Values(2)
                    Else
                        LimpiarContratos()
                    End If
                Else
                    LimpiarContratos()
                End If

            Case Is > 1

                Me.IDPROVEEDOR = Me.gvContratos.DataKeys(gvContratos.SelectedIndex).Values(1)
                Me.IDCONTRATO = Me.gvContratos.DataKeys(gvContratos.SelectedIndex).Values(2)

        End Select

        RaiseEvent SelectedIndexChanged()

    End Sub

    Public Sub LimpiarContratos()
        NumRegistros = 0
        gvContratos.PageIndex = 0
        Me.IDPROVEEDOR = 0
        Me.IDCONTRATO = 0
    End Sub

End Class
