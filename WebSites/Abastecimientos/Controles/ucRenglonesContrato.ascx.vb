Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucRenglonesContrato
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROCESOCOMPRA As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _RENGLON As Integer
    Private _IDPRODUCTO As Integer
    Private _ESTAHABILITADO As Integer
    Private _IDCANCELACION As Integer

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

    Public Property RENGLON() As Integer
        Get
            Return _RENGLON
        End Get
        Set(ByVal Value As Integer)
            _RENGLON = Value
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.ViewState.Remove("RENGLON")
            Me.ViewState.Add("RENGLON", Value)
        End Set
    End Property

    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal Value As Integer)
            _IDPRODUCTO = Value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", Value)
        End Set
    End Property

    Public Property ESTAHABILITADO() As Integer
        Get
            Return _ESTAHABILITADO
        End Get
        Set(ByVal Value As Integer)
            _ESTAHABILITADO = Value
            If Not Me.ViewState("ESTAHABILITADO") Is Nothing Then Me.ViewState.Remove("ESTAHABILITADO")
            Me.ViewState.Add("ESTAHABILITADO", Value)
        End Set
    End Property

    Public Property IDCANCELACION() As Integer
        Get
            Return _IDCANCELACION
        End Get
        Set(ByVal Value As Integer)
            _IDCANCELACION = Value
            If Not Me.ViewState("IDCANCELACION") Is Nothing Then Me.ViewState.Remove("IDCANCELACION")
            Me.ViewState.Add("IDCANCELACION", Value)
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
            If Not Me.ViewState("RENGLON") Is Nothing Then Me._RENGLON = Me.ViewState("RENGLON")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("ESTAHABILITADO") Is Nothing Then Me._ESTAHABILITADO = Me.ViewState("ESTAHABILITADO")
            If Not Me.ViewState("IDCANCELACION") Is Nothing Then Me._IDCANCELACION = Me.ViewState("IDCANCELACION")

            If Not Me.ViewState("NumRegistros") Is Nothing Then Me._NumRegistros = Me.ViewState("NumRegistros")
        End If

    End Sub

    Public Sub CargarDatos()

        Dim cPC As New cPRODUCTOSCONTRATO
        Dim ds As Data.DataSet

        ds = cPC.ObtenerRenglonesContratoConEntregas(Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO, Me.RENGLON)
        gvRenglones.DataSource = ds

        If NumRegistros = 0 Then
            NumRegistros = ds.Tables(0).Rows.Count
        End If

        Me.gvRenglones.SelectedIndex = -1

        Try
            Me.gvRenglones.DataBind()
        Catch ex As Exception
            gvRenglones.PageIndex = 0
            Me.gvRenglones.DataBind()
        End Try

        If Me.gvRenglones.Rows.Count = 0 Then
            Me.lblSeleccioneUnRenglon.Visible = False
        Else
            Me.lblSeleccioneUnRenglon.Visible = True
        End If

    End Sub

    Protected Sub gvRenglones_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRenglones.PageIndexChanging
        Me.gvRenglones.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvRenglones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvRenglones.SelectedIndexChanged

        Select Case gvRenglones.Rows.Count

            Case Is = 1

                If NumRegistros = 1 Then
                    If Me.RENGLON = 0 Then
                        Me.RENGLON = Me.gvRenglones.SelectedRow.Cells(1).Text
                        Me.IDPRODUCTO = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(3)
                        Me.ESTAHABILITADO = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(4)
                        Me.IDCANCELACION = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(5)
                    Else
                        LimpiarRenglones()
                    End If
                Else
                    LimpiarRenglones()
                End If

            Case Is > 1

                Me.RENGLON = Me.gvRenglones.SelectedRow.Cells(1).Text
                Me.IDPRODUCTO = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(3)
                Me.ESTAHABILITADO = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(4)
                Me.IDCANCELACION = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(5)

        End Select

        RaiseEvent SelectedIndexChanged()

    End Sub

    Public Sub LimpiarRenglones()
        NumRegistros = 0
        gvRenglones.PageIndex = 0
        Me.RENGLON = 0
        Me.IDPRODUCTO = 0
        Me.ESTAHABILITADO = 0
        Me.IDCANCELACION = 0
    End Sub

End Class
