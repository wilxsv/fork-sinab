Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class Controles_ucDefinicionPlazoEntregaCompra
    Inherits System.Web.UI.UserControl
    Private _IDSOLICITUD As Int64
    Private _IDDETALLE As Int16
    Private _IDENTREGA As Int16
    Private _IDCALCULO As Int16
    Private _PORCENTAJE As Decimal
    Private _DIAS As Decimal
    Private _ERRORES As String
    Private mComponente As New cENTREGAPROCESOCOMPRA
    Private mCompDetalleEntregas As New cDETALLEENTREGASPROCESOCOMPRA
    Private mEntidad As ENTREGAPROCESOCOMPRA
    Private mEntDetalleEntregas As DETALLEENTREGASPROCESOCOMPRA

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
        If Me.TxtDias.Text = "" Or IsNumeric(Me.TxtDias.Text) = False Then
            Return 1
        End If
        If Me.TxtPorcentaje.Text = "" Or IsNumeric(Me.TxtPorcentaje.Text) = False Then
            Return 2
        End If
        Return 0
    End Function

    Public Function RecuperarPorcentaje() As Int16
        Me.PORCENTAJE = Me.TxtPorcentaje.Text
        Me.DIAS = Me.TxtDias.Text
        Return -1
    End Function

    Public Function Actualizar(ByVal BENCABEZADO As Int16) As String
        
        
        mEntidad = New ENTREGAPROCESOCOMPRA
        mEntDetalleEntregas = New DETALLEENTREGASPROCESOCOMPRA

        mEntidad.IDPROCESOCOMPRA = Val(Me.LblIDSolicitud.Text)
        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntidad.IDENTREGA = Me.IDENTREGA
        If mEntidad.AUUSUARIOCREACION = Nothing Then
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntidad.AUFECHACREACION = Nothing Then
            mEntidad.AUFECHACREACION = Now()
        End If
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0

        If BENCABEZADO = 0 Then
            If mComponente.ValidarIDENTREGA(Me.IDSOLICITUD, Session.Item("IdEstablecimiento"), Me.IDENTREGA) = False Then
                If mComponente.AgregarENTREGAPROCESOCOMPRA(mEntidad) <> 1 Then
                    ' MsgBox("Error al Guardar registro.")
                Else
                    '   MsgBox("Correcto")
                End If
            Else
                'Response.Write("<script language='javascript'>window.alert('Este plazo de entrega ya esta definido');</script>")
            End If
        End If
        If mCompDetalleEntregas.ValidarIDDETALLEENTREGA(Val(Me.LblIDSolicitud.Text), Session.Item("IdEstablecimiento"), Val(Me.LblIDEntrega.Text), CInt(Me.TxtIdDetalle.Text)) = False Then
            mEntDetalleEntregas.IDPROCESOCOMPRA = Val(Me.LblIDSolicitud.Text)
            mEntDetalleEntregas.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntDetalleEntregas.IDENTREGA = Val(Me.LblIDEntrega.Text)
            mEntDetalleEntregas.IDDETALLE = CInt(Me.TxtIdDetalle.Text)
            mEntDetalleEntregas.DIAS = CInt(Me.TxtDias.Text)
            mEntDetalleEntregas.PORCENTAJE = CInt(Me.TxtPorcentaje.Text)
            mEntDetalleEntregas.TIPOCONTEO = Me.DdlTipoConteo.SelectedItem.Value
            mEntDetalleEntregas.IDFECHACONTEO = Me.DdlFechaConteo.SelectedItem.Value
            If mEntDetalleEntregas.AUUSUARIOCREACION = Nothing Then
                mEntDetalleEntregas.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntDetalleEntregas.AUFECHACREACION = Nothing Then
                mEntDetalleEntregas.AUFECHACREACION = Now()
            End If
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
End Class