Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleFUENTEFINANCIAMIENTOS
    Inherits System.Web.UI.UserControl

    Private _IDFUENTEFINANCIAMIENTO As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cFUENTEFINANCIAMIENTOS
    Private mEntidad As FUENTEFINANCIAMIENTOS

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

    Public Property IDFUENTEFINANCIAMIENTO() As Int32
        Get
            Return _IDFUENTEFINANCIAMIENTO
        End Get
        Set(ByVal value As Int32)
            Me._IDFUENTEFINANCIAMIENTO = value
            CargarDDLs()
            If Me._IDFUENTEFINANCIAMIENTO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDFUENTEFINANCIAMIENTO") Is Nothing Then Me.ViewState.Remove("IDFUENTEFINANCIAMIENTO")
            Me.ViewState.Add("IDFUENTEFINANCIAMIENTO", value)
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
            If Not Me.ViewState("IDFUENTEFINANCIAMIENTO") Is Nothing Then Me._IDFUENTEFINANCIAMIENTO = Me.ViewState("IDFUENTEFINANCIAMIENTO")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New FUENTEFINANCIAMIENTOS

        mEntidad.IDFUENTEFINANCIAMIENTO = IDFUENTEFINANCIAMIENTO

        If mComponente.ObtenerFUENTEFINANCIAMIENTOS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtNOMBRE.Text = mEntidad.NOMBRE
        Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue = mEntidad.IDGRUPO

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.txtNOMBRE.Enabled = edicion
        Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Enabled = edicion
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

        If Me.mComponente.ValidarNombreGrupo(Me.txtNOMBRE.Text, Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue, Me.IDFUENTEFINANCIAMIENTO) > 0 Then
            Return "La fuente de financiamiento ya existe."
        End If

        mEntidad = New FUENTEFINANCIAMIENTOS

        If Me._nuevo Then
            mEntidad.IDFUENTEFINANCIAMIENTO = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDFUENTEFINANCIAMIENTO = Me.IDFUENTEFINANCIAMIENTO
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.NOMBRE = Me.txtNOMBRE.Text
        mEntidad.IDGRUPO = Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue

        If mComponente.ActualizarFUENTEFINANCIAMIENTOS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Private Sub CargarDDLs()
        Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Recuperar()
    End Sub

End Class
