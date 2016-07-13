Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Controles_ucDefinicionPlazoEntrega
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Int32
    Private _IDSOLICITUD As Int64
    Private _IDDETALLE As Int16
    Private _IDENTREGA As Int16
    Private _IDCALCULO As Int16
    Private _PORCENTAJE As Decimal
    Private _DIAS As Int16
    Private _ERRORES As String
    Private mComponente As New cENTREGASOLICITUDES
    Private mCompDetalleEntregas As New cDETALLEENTREGAS
    Private mEntidad As ENTREGASOLICITUDES
    Private mEntDetalleEntregas As DETALLEENTREGAS

    Public Property PORCENTAJE() As Decimal
        Get
            Return Me._PORCENTAJE
        End Get
        Set(ByVal Value As Decimal)
            Me._PORCENTAJE = Value
        End Set
    End Property

    Public Property DIAS() As Decimal
        Get
            Return Me._DIAS
        End Get
        Set(ByVal Value As Decimal)
            Me._DIAS = Value
        End Set
    End Property

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

    Public Property IDSOLICITUD() As Int64
        Get
            Return Me._IDSOLICITUD
        End Get
        Set(ByVal Value As Int64)
            Me._IDSOLICITUD = Value
            Me.LblIDSolicitud.Text = Value
        End Set
    End Property

    Public Property ERRORES() As String
        Get
            Return Me._ERRORES
        End Get
        Set(ByVal Value As String)
            Me.LblError.Visible = True
            Me._ERRORES = Value
            Me.LblError.Text = Value
        End Set
    End Property

    Public Property IDDETALLE() As Int16
        Get
            Return Me._IDDETALLE
        End Get
        Set(ByVal Value As Int16)
            Me._IDDETALLE = Value
            Me.TxtIdDetalle.Text = Value
        End Set
    End Property

    Public Property IDENTREGA() As Int16
        Get
            Return Me._IDENTREGA
        End Get
        Set(ByVal Value As Int16)
            Me._IDENTREGA = Value
            Me.LblIDEntrega.Text = Value
        End Set
    End Property

    Public Property IDCALCULO() As Int16
        Get
            Return Me._IDCALCULO
        End Get
        Set(ByVal Value As Int16)
            Me._IDCALCULO = Value
            Select Case Value
                Case Is = 1
                    Me.PORCENTAJE = 100
                    Me.TxtPorcentaje.Text = Me.PORCENTAJE
                Case Is = 2
                    Me.PORCENTAJE = 100 / 2
                    Me.TxtPorcentaje.Text = Me.PORCENTAJE
                Case Is = 3
                    Me.PORCENTAJE = 100 / 3
                    Me.TxtPorcentaje.Text = Me.PORCENTAJE
                Case Is = 4
                    Me.PORCENTAJE = 100 / 4
                    Me.TxtPorcentaje.Text = Me.PORCENTAJE
                Case Is = 5
                    Me.PORCENTAJE = 100 / 5
                    Me.TxtPorcentaje.Text = Me.PORCENTAJE
            End Select
        End Set
    End Property

    Public Function ValidaFormulario() As Int16
        If Me.TxtDias.Text = "" Then
            Return 1
        Else
            Return 0
        End If
        'If Me.TxtPorcentaje.Text = "" Then
        'Return 2
        'End If
        '        Return 0
    End Function

    Public Function RecuperarPorcentaje() As Int16
        Me.PORCENTAJE = Me.TxtPorcentaje.Text
        Me.DIAS = Val(Me.TxtDias.Text)
        Return -1
    End Function

    Public Function Actualizar(ByVal BENCABEZADO As Int16) As String
        
        
        mEntidad = New ENTREGASOLICITUDES
        mEntDetalleEntregas = New DETALLEENTREGAS

        mEntidad.IDSOLICITUD = Val(Me.LblIDSolicitud.Text)
        mEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        '  mEntidad.IDENTREGA = Me.IDENTREGA

        mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHACREACION = Now()
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0

        If BENCABEZADO = 0 Then
            If mComponente.ValidarIDENTREGA(Me.IDSOLICITUD, Session("IdEstablecimiento"), Me.IDENTREGA) = False Then
                If mComponente.AgregarENTREGASOLICITUDES(mEntidad) <> 1 Then
                    ' MsgBox("Error al Guardar registro.")
                Else
                    '   MsgBox("Correcto")
                End If
            Else
                'Response.Write("<script language='javascript'>window.alert('Este plazo de entrega ya esta definido');</script>")
            End If
        End If

        If mCompDetalleEntregas.ValidarIDDETALLEENTREGA(Val(Me.LblIDSolicitud.Text), Session("IdEstablecimiento"), Val(Me.LblIDEntrega.Text), CInt(Me.TxtIdDetalle.Text)) = False Then
            mEntDetalleEntregas.IDSOLICITUD = Val(Me.LblIDSolicitud.Text)
            mEntDetalleEntregas.IDESTABLECIMIENTO = Session("IdEstablecimiento") 'Me.IDESTABLECIMIENTO
            mEntDetalleEntregas.IDENTREGA = Val(Me.LblIDEntrega.Text)
            mEntDetalleEntregas.IDDETALLE = CInt(Me.TxtIdDetalle.Text)
            mEntDetalleEntregas.DIAS = CInt(Me.TxtDias.Text)
            mEntDetalleEntregas.PORCENTAJE = CInt(Me.TxtPorcentaje.Text)
            mEntDetalleEntregas.TIPOCONTEO = Me.DdlTipoConteo.SelectedItem.Value
            mEntDetalleEntregas.FECHACONTEO = Me.DdlFechaConteo.SelectedItem.Value
            mEntDetalleEntregas.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntDetalleEntregas.AUFECHACREACION = Now()
            mEntDetalleEntregas.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntDetalleEntregas.AUFECHAMODIFICACION = Now()
            mEntDetalleEntregas.ESTASINCRONIZADA = 0
            If mCompDetalleEntregas.AgregarDETALLEENTREGA(mEntDetalleEntregas) <> 1 Then
                Return "Error al guardar registro."
            End If
        Else
            'Response.Write("<script language='javascript'>window.alert('Este plazo de entrega ya esta definido');</scrip>")
        End If
        Return ""
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then _IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
        End If
    End Sub

End Class