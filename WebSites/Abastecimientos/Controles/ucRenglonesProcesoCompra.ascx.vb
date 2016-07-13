Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucRenglonesProcesoCompra
    Inherits System.Web.UI.UserControl

    Private _IDDETALLE As Int64
    Private _IDPRODUCTO As Int64
    Private _IDPROCESOCOMPRA As Int64
    Private _IDESTABLECIMIENTO As Int32
    Private _IDESTADO() As Byte
    Private _RENGLON As Int32

    Private _CantidadSolicitada As Decimal
    Private _UnidadMedida As String

    Private _Obtener As Boolean = True
    Private _ObtenerTodos As Boolean = True

    Private _NumRegistros As Integer = 0

    Public Event SelectedIndexChanged()

#Region " Propiedades "

    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Int32)
            Me._IDESTABLECIMIENTO = Value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", Value)
        End Set
    End Property

    Public Property IDPROCESOCOMPRA() As Int64
        Get
            Return Me._IDPROCESOCOMPRA
        End Get
        Set(ByVal Value As Int64)
            Me._IDPROCESOCOMPRA = Value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IdProcesoCompra", Value)
        End Set
    End Property

    Public Property RENGLON() As Int32
        Get
            Return Me._RENGLON
        End Get
        Set(ByVal Value As Int32)
            Me._RENGLON = Value
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.ViewState.Remove("RENGLON")
            Me.ViewState.Add("RENGLON", Value)
        End Set
    End Property

    Public Property IDPRODUCTO() As Int64
        Get
            Return Me._IDPRODUCTO
        End Get
        Set(ByVal Value As Int64)
            Me._IDPRODUCTO = Value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", Value)
        End Set
    End Property

    Public Property IDDETALLE() As Int64
        Get
            Return Me._IDDETALLE
        End Get
        Set(ByVal Value As Int64)
            Me._IDDETALLE = Value
            If Not Me.ViewState("IDDETALLE") Is Nothing Then Me.ViewState.Remove("IDDETALLE")
            Me.ViewState.Add("IDDETALLE", Value)
        End Set
    End Property

    Public Property IDESTADO() As Byte()
        Get
            Return Me._IDESTADO
        End Get
        Set(ByVal Value As Byte())
            Array.Resize(Me._IDESTADO, Value.Length)
            Me._IDESTADO = Value
            If Not Me.ViewState("IDESTADO") Is Nothing Then Me.ViewState.Remove("IDESTADO")
            Me.ViewState.Add("IDESTADO", Value)
        End Set
    End Property

    Public Property CantidadSolicitada() As Decimal
        Get
            Return Me._CantidadSolicitada
        End Get
        Set(ByVal Value As Decimal)
            Me._CantidadSolicitada = Value
            If Not Me.ViewState("CantidadSolicitada") Is Nothing Then Me.ViewState.Remove("CantidadSolicitada")
            Me.ViewState.Add("CantidadSolicitada", Value)
        End Set
    End Property

    Public Property UnidadMedida() As String
        Get
            Return Me._UnidadMedida
        End Get
        Set(ByVal Value As String)
            Me._UnidadMedida = Value
            If Not Me.ViewState("UnidadMedida") Is Nothing Then Me.ViewState.Remove("UnidadMedida")
            Me.ViewState.Add("UnidadMedida", Value)
        End Set
    End Property

    Public Property Obtener() As Boolean
        Get
            Return Me._Obtener
        End Get
        Set(ByVal Value As Boolean)
            Me._Obtener = Value
            If Not Me.ViewState("Obtener") Is Nothing Then Me.ViewState.Remove("Obtener")
            Me.ViewState.Add("Obtener", Value)
        End Set
    End Property

    Public Property ObtenerTodos() As Boolean
        Get
            Return Me._ObtenerTodos
        End Get
        Set(ByVal Value As Boolean)
            Me._ObtenerTodos = Value
            If Not Me.ViewState("ObtenerTodos") Is Nothing Then Me.ViewState.Remove("ObtenerTodos")
            Me.ViewState.Add("ObtenerTodos", Value)
        End Set
    End Property

    Public Property NumRegistros() As Integer
        Get
            Return _NumRegistros
        End Get
        Set(ByVal Value As Integer)
            _NumRegistros = Value
            If Not Me.ViewState("NumRegistros") Is Nothing Then Me.ViewState.Remove("NumRegistros")
            Me.ViewState.Add("NumRegistros", Value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me._IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("RENGLON") Is Nothing Then Me._RENGLON = Me.ViewState("RENGLON")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("IDDETALLE") Is Nothing Then Me._IDDETALLE = Me.ViewState("IDDETALLE")
            If Not Me.ViewState("IDESTADO") Is Nothing Then Me._IDESTADO = Me.ViewState("IDESTADO")
            If Not Me.ViewState("UnidadMedida") Is Nothing Then Me._UnidadMedida = Me.ViewState("UnidadMedida")
            If Not Me.ViewState("CantidadSolicitada") Is Nothing Then Me._CantidadSolicitada = Me.ViewState("CantidadSolicitada")
            If Not Me.ViewState("Obtener") Is Nothing Then Me._Obtener = Me.ViewState("Obtener")
            If Not Me.ViewState("ObtenerTodos") Is Nothing Then Me._ObtenerTodos = Me.ViewState("ObtenerTodos")

            If Not Me.ViewState("NumRegistros") Is Nothing Then Me._NumRegistros = Me.ViewState("NumRegistros")
        End If

    End Sub

    Public Sub CargarDatos()

        Dim cDPC As New cDETALLEPROCESOCOMPRA
        Dim ds As Data.DataSet = Nothing

        If Obtener Then
            If ObtenerTodos Then
                ds = cDPC.ObtenerRenglonesProcesoCompra(Me.IDESTABLECIMIENTO, Me.IDPROCESOCOMPRA, Me.RENGLON, Me.IDESTADO)
            Else
                ds = cDPC.ObtenerRenglonesSinNotasAceptacion(Me.IDESTABLECIMIENTO, Me.IDPROCESOCOMPRA, Me.RENGLON)
            End If
        End If

        gvRenglones.DataSource = ds

        Try
            Me.gvRenglones.DataBind()
        Catch ex As Exception
            gvRenglones.PageIndex = 0
            Me.gvRenglones.DataBind()
        End Try

        If NumRegistros = 0 Then
            NumRegistros = Me.gvRenglones.Rows.Count
        End If

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
        Try

            Select Case gvRenglones.Rows.Count
                Case Is = 1
                    If gvRenglones.PageIndex > 0 Then
                        Me.IDPRODUCTO = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(0)
                        Me.IDDETALLE = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(1)
                        Me.RENGLON = Me.gvRenglones.SelectedRow.Cells(1).Text
                        Me.UnidadMedida = Me.gvRenglones.SelectedRow.Cells(4).Text
                        Me.CantidadSolicitada = Me.gvRenglones.SelectedRow.Cells(6).Text
                        Me.gvRenglones.SelectedIndex = 1
                    Else
                        If NumRegistros = 1 Then
                            If Me.RENGLON = 0 Then
                                Me.IDPRODUCTO = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(0)
                                Me.IDDETALLE = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(1)
                                Me.RENGLON = Me.gvRenglones.SelectedRow.Cells(1).Text
                                Me.UnidadMedida = Me.gvRenglones.SelectedRow.Cells(4).Text
                                Me.CantidadSolicitada = Me.gvRenglones.SelectedRow.Cells(6).Text
                                Me.gvRenglones.SelectedIndex = 1
                            Else
                                LimpiarRenglones()
                                Me.gvRenglones.SelectedIndex = -1
                            End If
                        Else
                            LimpiarRenglones()
                            Me.gvRenglones.SelectedIndex = -1
                        End If
                    End If


                Case Is > 1
                    Me.IDPRODUCTO = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(0)
                    Me.IDDETALLE = Me.gvRenglones.DataKeys(gvRenglones.SelectedIndex).Values(1)
                    Me.RENGLON = Me.gvRenglones.SelectedRow.Cells(1).Text
                    Me.UnidadMedida = Me.gvRenglones.SelectedRow.Cells(4).Text
                    Me.CantidadSolicitada = Me.gvRenglones.SelectedRow.Cells(6).Text
                    Me.gvRenglones.SelectedIndex = 1
            End Select

            RaiseEvent SelectedIndexChanged()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub LimpiarRenglones()
        NumRegistros = 0
        gvRenglones.PageIndex = 0
        Me.IDPRODUCTO = 0
        Me.IDDETALLE = 0
        Me.RENGLON = 0
    End Sub

    Public Function ObtenerObservacionRecomendacion() As String
        Dim cDPC As New cDETALLEPROCESOCOMPRA
        Return cDPC.ObtenerObservacionRecomendacion(Me.IDESTABLECIMIENTO, Me.IDPROCESOCOMPRA, Me.IDPRODUCTO, Me.IDDETALLE)
    End Function

    Public Function ObtenerObservacionAdjudicacion() As String
        Dim cDPC As New cDETALLEPROCESOCOMPRA
        Return cDPC.ObtenerObservacionAdjudicacion(Me.IDESTABLECIMIENTO, Me.IDPROCESOCOMPRA, Me.IDPRODUCTO, Me.IDDETALLE)
    End Function

    Public Function ObtenerObservacionAdjudicacionEnFirme() As String
        Dim cDPC As New cDETALLEPROCESOCOMPRA
        Return cDPC.ObtenerObservacionAdjudicacionEnFirme(Me.IDESTABLECIMIENTO, Me.IDPROCESOCOMPRA, Me.IDPRODUCTO, Me.IDDETALLE)
    End Function

    Public Function ObtenerEstadoRenglon() As String
        Return Me.gvRenglones.Rows(0).Cells(8).Text
    End Function

End Class
