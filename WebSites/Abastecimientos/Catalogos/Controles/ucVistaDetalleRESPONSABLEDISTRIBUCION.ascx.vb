Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleRESPONSABLEDISTRIBUCION
    Inherits System.Web.UI.UserControl

    Private _IDRESPONSABLEDISTRIBUCION As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cRESPONSABLEDISTRIBUCION
    Private mEntidad As RESPONSABLEDISTRIBUCION

    Public Event ErrorEvent(ByVal errorMessage As String)

#Region " Propiedades "

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal value As Boolean)
            Me.HabilitarEdicion(value)
        End Set
    End Property

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDRESPONSABLEDISTRIBUCION() As Int32
        Get
            Return _IDRESPONSABLEDISTRIBUCION
        End Get
        Set(ByVal value As Int32)
            Me._IDRESPONSABLEDISTRIBUCION = value
            CargarDDLs()
            If Me._IDRESPONSABLEDISTRIBUCION > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDRESPONSABLEDISTRIBUCION") Is Nothing Then Me.ViewState.Remove("IDRESPONSABLEDISTRIBUCION")
            Me.ViewState.Add("IDRESPONSABLEDISTRIBUCION", value)
        End Set
    End Property

    Public Property AUUSUARIOCREACION() As String
        Get
            Return Me._AUUSUARIOCREACION
        End Get
        Set(ByVal value As String)
            Me._AUUSUARIOCREACION = value
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me.ViewState.Remove("AUUSUARIOCREACION")
            Me.ViewState.Add("AUUSUARIOCREACION", value)
        End Set
    End Property

    Public Property AUFECHACREACION() As DateTime
        Get
            Return Me._AUFECHACREACION
        End Get
        Set(ByVal value As DateTime)
            Me._AUFECHACREACION = value
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me.ViewState.Remove("AUFECHACREACION")
            Me.ViewState.Add("AUFECHACREACION", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDRESPONSABLEDISTRIBUCION") Is Nothing Then Me._IDRESPONSABLEDISTRIBUCION = Me.ViewState("IDRESPONSABLEDISTRIBUCION")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New RESPONSABLEDISTRIBUCION

        mEntidad.IDRESPONSABLEDISTRIBUCION = IDRESPONSABLEDISTRIBUCION

        If mComponente.ObtenerRESPONSABLEDISTRIBUCION(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtNOMBRE.Text = mEntidad.NOMBRE
        Me.txtNOMBRECORTO.Text = mEntidad.NOMBRECORTO

        If Not mEntidad.IDESTABLECIMIENTO = Nothing Then
            Me.ddlESTABLECIMIENTOS1.SelectedValue = mEntidad.IDESTABLECIMIENTO
            Me.ddlDEPENDENCIAESTABLECIMIENTOS1.ObtenerDependenciaEstablecimiento(Me.ddlESTABLECIMIENTOS1.SelectedValue)
            Me.ddlDEPENDENCIAESTABLECIMIENTOS1.SelectedValue = mEntidad.IDDEPENDENCIA
            Me.cbExterno.Checked = False
        Else
            Me.cbExterno.Checked = True
            Me.lblIDESTABLECIMIENTO.Visible = False
            Me.ddlESTABLECIMIENTOS1.Visible = False
            Me.lblIDDEPENDENCIA.Visible = False
            Me.ddlDEPENDENCIAESTABLECIMIENTOS1.Visible = False
        End If

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.cbExterno.Enabled = edicion
        Me.ddlESTABLECIMIENTOS1.Enabled = edicion
        Me.ddlDEPENDENCIAESTABLECIMIENTOS1.Enabled = edicion
        Me.txtNOMBRE.Enabled = edicion
        Me.txtNOMBRECORTO.Enabled = edicion
    End Sub

    Private Sub Nuevo()

        Me._nuevo = True

        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

    End Sub

    Public Function Actualizar() As String

        If Me.ddlDEPENDENCIAESTABLECIMIENTOS1.SelectedValue = "" Then
            Return "No se puede agregar porque falta la dependencia."
        End If

        If mComponente.BuscarEstablecimientoDependencia(Me.ddlESTABLECIMIENTOS1.SelectedValue, Me.ddlDEPENDENCIAESTABLECIMIENTOS1.SelectedValue) Then
            Return "La dependencia para este establecimiento ya existe."
        End If

        mEntidad = New RESPONSABLEDISTRIBUCION

        If Me._nuevo Then
            mEntidad.IDRESPONSABLEDISTRIBUCION = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDRESPONSABLEDISTRIBUCION = Me.IDRESPONSABLEDISTRIBUCION
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.IDESTABLECIMIENTO = IIf(cbExterno.Checked, Nothing, Me.ddlESTABLECIMIENTOS1.SelectedValue)
        mEntidad.IDDEPENDENCIA = IIf(cbExterno.Checked, Nothing, Me.ddlDEPENDENCIAESTABLECIMIENTOS1.SelectedValue)
        mEntidad.NOMBRE = Me.txtNOMBRE.Text
        mEntidad.NOMBRECORTO = Me.txtNOMBRECORTO.Text
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarRESPONSABLEDISTRIBUCION(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Protected Sub ddlESTABLECIMIENTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlESTABLECIMIENTOS1.SelectedIndexChanged
        Me.ddlDEPENDENCIAESTABLECIMIENTOS1.ObtenerDependenciaEstablecimiento(Me.ddlESTABLECIMIENTOS1.SelectedValue)
    End Sub

    Private Sub CargarDDLs()
        Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
        Me.ddlDEPENDENCIAESTABLECIMIENTOS1.ObtenerDependenciaEstablecimiento(Me.ddlESTABLECIMIENTOS1.SelectedValue)
    End Sub

    Protected Sub cbExterno_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbExterno.CheckedChanged
        Me.lblIDESTABLECIMIENTO.Visible = Not cbExterno.Checked
        Me.ddlESTABLECIMIENTOS1.Visible = Not cbExterno.Checked
        Me.lblIDDEPENDENCIA.Visible = Not cbExterno.Checked
        Me.ddlDEPENDENCIAESTABLECIMIENTOS1.Visible = Not cbExterno.Checked
    End Sub

End Class
