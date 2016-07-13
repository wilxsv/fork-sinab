Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Clases
Imports SINAB_Utils.MessageBox
Imports SINAB_Entidades.Tipos
Imports SINAB_Entidades.Clases.UACI

Partial Class ucDetFuenteFinanciamientoContratos
    Inherits System.Web.UI.UserControl

    'Private mCompFuenteContrato As New cFUENTEFINANCIAMIENTOSCONTRATOS

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
                btnAgregarFuente.Enabled = False
            Else
                btnAgregarFuente.Enabled = True
            End If
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

    Public ReadOnly Property Count() As Integer
        Get
            Return Me.gvLista.Rows.Count
        End Get
    End Property
    Public ReadOnly Property IdfuenteFinanciamiento() As Integer
        Get
            Return Me.gvLista.DataKeys(0).Values.Item("IDFUENTEFINANCIAMIENTO")
        End Get
    End Property

#End Region

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        MostrarOcultarAgregarFuente(True)
    End Sub

    Public Sub CargarDatos()
        Dim base = New SAB_UACI_CONTRATOS
        With base
            .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDCONTRATO = IDCONTRATO
        End With

        Me.gvLista.DataSource = UACIHelpers.FuentesFinanciamiento.Obtener(base)
        Me.gvLista.DataBind()

        Me.TxtMontoContratado.Text = 0.ToString()

        MostrarOcultarAgregarFuente(gvLista.Rows.Count > 0)
    End Sub

    Private Sub Actualizar()
        Dim base = New SAB_UACI_CONTRATOS
        With base
            .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDCONTRATO = IDCONTRATO
        End With

        Dim ffc As New SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS
        With ffc
            .IDESTABLECIMIENTO = base.IDESTABLECIMIENTO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDCONTRATO = IDCONTRATO
            .IDFUENTEFINANCIAMIENTO = CType(Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue, Integer)
            .MONTOCONTRATADO = CType(Val(Me.TxtMontoContratado.Text), Decimal?)
            .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            .AUFECHACREACION = Now()
            .ESTASINCRONIZADA = 0
        End With
        Try
            UACIHelpers.FuentesFinanciamiento.Agregar(ffc)

            Me.gvLista.DataSource = UACIHelpers.FuentesFinanciamiento.Obtener(base)
            Me.gvLista.DataBind()
            ' AgregarFuente(gvLista.Rows.Count = 0)
            MostrarOcultarAgregarFuente(True)

        Catch ex As Exception
            Alert("Error al agergar fuente de financiamiento, no se permiten fuentes de financiamiento repetidas. Mensaje:" + ex.Message)
        End Try

    End Sub

    Protected Sub btnAgregarFuente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarFuente.Click

        MostrarOcultarAgregarFuente(False)
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Me.TxtMontoContratado.Text = "" Then
            Alert("Especifique el monto contratado", "Alerta")
        Else
            Actualizar()
            MostrarOcultarAgregarFuente(True)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FuentesFinanciamiento.CargarPorGrupoALista(ddlFUENTEFINANCIAMIENTOS1, CType(RadioButtonList1.SelectedValue, Integer))
            mvFuentes.ActiveViewIndex = 0
        Else
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me._IDCONTRATO = Me.ViewState("IDCONTRATO")
        End If
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim base = New SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS()
        With base
            .IDFUENTEFINANCIAMIENTO = CType(gvLista.DataKeys(e.RowIndex).Values.Item("IDFUENTEFINANCIAMIENTO"), Integer)
            .IDCONTRATO = IDCONTRATO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        End With

        UACIHelpers.FuentesFinanciamiento.Eliminar(base)

        CargarDatos()


    End Sub

    Private Sub MostrarOcultarAgregarFuente(mostrar As Boolean)
        TxtMontoContratado.Text = 0
        If mostrar Then
            mvFuentes.ActiveViewIndex = 0
        Else
            mvFuentes.ActiveViewIndex = 1
        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        FuentesFinanciamiento.CargarPorGrupoALista(ddlFUENTEFINANCIAMIENTOS1, CType(RadioButtonList1.SelectedValue, Integer))
    End Sub
End Class
