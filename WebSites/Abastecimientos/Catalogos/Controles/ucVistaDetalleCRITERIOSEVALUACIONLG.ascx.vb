Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleCRITERIOSEVALUACIONLG
    Inherits System.Web.UI.UserControl

    Private _IDCRITERIOEVALUACION As Int16
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cCRITERIOSEVALUACION
    Private mEntidad As CRITERIOSEVALUACION

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

    Public Property IDCRITERIOEVALUACION() As Int16
        Get
            Return _IDCRITERIOEVALUACION
        End Get
        Set(ByVal value As Int16)
            Me._IDCRITERIOEVALUACION = value
            CargarDDLs()
            If Me._IDCRITERIOEVALUACION > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDCRITERIOEVALUACION") Is Nothing Then Me.ViewState.Remove("IDCRITERIOEVALUACION")
            Me.ViewState.Add("IDCRITERIOEVALUACION", value)
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
            If Not Me.ViewState("IDCRITERIOEVALUACION") Is Nothing Then Me._IDCRITERIOEVALUACION = Me.ViewState("IDCRITERIOEVALUACION")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New CRITERIOSEVALUACION

        mEntidad.IDCRITERIOEVALUACION = IDCRITERIOEVALUACION

        If mComponente.ObtenerCRITERIOSEVALUACION(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.ddlTIPOCRITERIO1.SelectedValue = 3
        Me.txtDESCRIPCION.Text = mEntidad.DESCRIPCION
        Me.nbPorcentaje.Text = mEntidad.PORCENTAJE
        Me.cbESGLOBAL.Checked = IIf(mEntidad.ESGLOBAL = 1, True, False)
        If mEntidad.PORCENTAJE = Nothing Then Me.nbPorcentaje.Text = "" Else Me.nbPorcentaje.Text = mEntidad.PORCENTAJE

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.ddlTIPOCRITERIO1.Enabled = False
        Me.txtDESCRIPCION.Enabled = edicion
        Me.nbPorcentaje.Enabled = edicion
        Me.cbESGLOBAL.Enabled = edicion
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

        If Val(Me.nbPorcentaje.Text) > 100 Then
            Return "El porcentaje no puede ser mayor a 100%"
        End If

        mEntidad = New CRITERIOSEVALUACION

        If Me._nuevo Then
            mEntidad.IDCRITERIOEVALUACION = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDCRITERIOEVALUACION = Me.IDCRITERIOEVALUACION
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.IDTIPOCRITERIO = Me.ddlTIPOCRITERIO1.SelectedValue
        mEntidad.DESCRIPCION = Me.txtDESCRIPCION.Text
        mEntidad.PORCENTAJE = Val(Me.nbPorcentaje.Text)
        mEntidad.ESGLOBAL = IIf(Me.cbESGLOBAL.Checked, 1, 0)
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarCRITERIOSEVALUACION(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Private Sub CargarDDLs()
        Me.ddlTIPOCRITERIO1.Recuperar()
        Me.ddlTIPOCRITERIO1.SelectedValue = 3
    End Sub

End Class
