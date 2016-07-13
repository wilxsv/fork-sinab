Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetalleSUBGRUPOS
    Inherits System.Web.UI.UserControl

    Private _IDSUBGRUPO As Int32
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime
    Private _IDSUMINISTRO As Int32


    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cSUBGRUPOS
    Private mEntidad As SUBGRUPOS
    Private mComponente1 As New cGRUPOS
    Private mEntidad1 As GRUPOS



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

    Public Property IDSUBGRUPO() As Int32
        Get
            Return _IDSUBGRUPO
        End Get
        Set(ByVal value As Int32)
            Me._IDSUBGRUPO = value
            Me.CargarDDLs()
            If Me._IDSUBGRUPO > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDSUBGRUPO") Is Nothing Then Me.ViewState.Remove("IDSUBGRUPO")
            Me.ViewState.Add("IDSUBGRUPO", value)
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
            If Not Me.ViewState("SUBGRUPOS") Is Nothing Then Me._IDSUBGRUPO = Me.ViewState("SUBGRUPOS")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New SUBGRUPOS
        mEntidad1 = New GRUPOS

        mEntidad.IDSUBGRUPO = IDSUBGRUPO


        'Me.ddlSUMINISTROS1.SelectedValue = mEntidad1.IDSUMINISTRO


        If mComponente.ObtenerSUBGRUPOS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.txtCORRELATIVO.Text = mEntidad.CORRELATIVO
        Me.ddlGRUPOS1.SelectedValue = mEntidad.IDGRUPO
        Me.txtDESCRIPCION.Text = mEntidad.DESCRIPCION

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'Me.ddlSUMINISTROS1.Enabled = edicion
        Me.txtCORRELATIVO.Enabled = edicion
        Me.ddlGRUPOS1.Enabled = edicion
        Me.txtDESCRIPCION.Enabled = edicion
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

        mEntidad = New SUBGRUPOS

        If Me._nuevo Then
            mEntidad.IDSUBGRUPO = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDSUBGRUPO = ViewState("IDSUBGRUPO")
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.CORRELATIVO = Me.txtCORRELATIVO.Text
        mEntidad.IDGRUPO = Me.ddlGRUPOS1.SelectedValue
        mEntidad.DESCRIPCION = Me.txtDESCRIPCION.Text
        mEntidad.ESTASINCRONIZADA = 0
        'mEntidad.IDSUBGRUPO = Me.IDSUBGRUPO

        If mComponente.ActualizarSUBGRUPOS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Private Sub CargarDDLs()
        Me.ddlGRUPOS1.Recuperar()

    End Sub

End Class
