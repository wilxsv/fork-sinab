Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Clases
Imports SINAB_Entidades.Tipos
Imports SINAB_Entidades.Clases.UACI
Imports SINAB_Utils.MessageBox

Partial Class ucDetResDistribucionContrato
    Inherits System.Web.UI.UserControl

    Private _Consulta As Boolean = False
    Private _IDPROVEEDOR As Int64
    Private _IDCONTRATO As Int64

#Region " Propiedades "

    Public Property Consulta() As Boolean
        Get
            Return _Consulta
        End Get
        Set(ByVal value As Boolean)
            _Consulta = value
            If value = True Then
                Me.btnAgregarResponsable.Enabled = False
            Else
                Me.btnAgregarResponsable.Enabled = True
            End If
            If Not Me.ViewState("Consulta") Is Nothing Then Me.ViewState.Remove("Consulta")
            Me.ViewState.Add("Consulta", value)
        End Set
    End Property

    Public Property IDPROVEEDOR() As Int64
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal Value As Int64)
            _IDPROVEEDOR = Value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", Value)
        End Set
    End Property

    Public Property IDCONTRATO() As Int64
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal Value As Int64)
            _IDCONTRATO = Value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", Value)
        End Set
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return Me.gvLista.Rows.Count
        End Get
    End Property

#End Region

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        AgregarResponsable(True)
    End Sub

    Public Sub CargarDatos()
        Dim base = New SAB_UACI_CONTRATOS
        With base
            .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDPROVEEDOR = CType(IDPROVEEDOR, Integer)
            .IDCONTRATO = IDCONTRATO
        End With
        Me.gvLista.DataSource = UACIHelpers.ResponsablesDistribucion.Obtener(base)   ' mComponente.ObtenerResponsablesPorContratoDS(Session.Item("IdEstablecimiento"), Me.IDPROVEEDOR, Me.IDCONTRATO)
        Me.gvLista.DataBind()
        AgregarResponsable(Not gvLista.Rows.Count = 0)
    End Sub

    Private Sub Actualizar()

        Dim rdc As New SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO
        With rdc
            .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDPROVEEDOR = CType(IDPROVEEDOR, Integer)
            .IDCONTRATO = IDCONTRATO
            .IDRESPONSABLEDISTRIBUCION = CType(Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue, Integer)
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .AUFECHACREACION = Now()
        End With
        Try
            UACIHelpers.ResponsablesDistribucion.Agregar(rdc)
            CargarDatos()
        Catch ex As Exception
            Alert("Error al agergar Administrador de contrato. El administrador no puede estar repetido. Error: " + ex.Message)
        End Try

    End Sub

    Protected Sub btnAgregarResponsable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarResponsable.Click
        AgregarResponsable(False)
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Actualizar()
        AgregarResponsable(True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ResponsablesDistribucion.ObtenerListado(ddlRESPONSABLEDISTRIBUCION1)

        Else
            If Not Me.ViewState("Consulta") Is Nothing Then Me._Consulta = Me.ViewState("Consulta")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me._IDCONTRATO = Me.ViewState("IDCONTRATO")
        End If
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting
        Dim base = New SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO
        With base
            .IDRESPONSABLEDISTRIBUCION = CType(gvLista.DataKeys(e.RowIndex).Values.Item("IDRESPONSABLEDISTRIBUCION"), Integer)
            .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDPROVEEDOR = CType(IDPROVEEDOR, Integer)
            .IDCONTRATO = IDCONTRATO
        End With

        UACIHelpers.ResponsablesDistribucion.Eliminar(base)

        CargarDatos()
    End Sub

    Private Sub AgregarResponsable(Optional ByVal Mostrar As Boolean = True)
        If Mostrar Then
            mvAgregar.ActiveViewIndex = 0
        Else
            mvAgregar.ActiveViewIndex = 1
        End If
    End Sub

End Class
