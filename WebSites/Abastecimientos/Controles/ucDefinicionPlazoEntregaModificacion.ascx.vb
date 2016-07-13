'MODIFICACION DE DETALLE DE ENTREGAS DE SOLICITUD DE COMPRAS
'CU-ESTA0001
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario para la modificacion de detalle de entregas de solicitud de compras

Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Controles_ucDefinicionPlazoEntregaModificacion
    Inherits System.Web.UI.UserControl
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
    'declaracon de propiedades
    Public ReadOnly Property TXDIAS() As TextBox
        Get
            Return Me.TxtDias
        End Get
    End Property
    Public ReadOnly Property TXPORCENTAJE() As TextBox
        Get
            Return Me.TxtPorcentaje
        End Get
    End Property
    Public ReadOnly Property DLTIPOCONTEO() As DropDownList
        Get
            Return Me.DdlTipoConteo
        End Get
    End Property

    Public ReadOnly Property DLFECHACONTEO() As DropDownList
        Get
            Return Me.DdlFechaConteo
        End Get
    End Property
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
    'calculo de porcentaje segun entrega
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
    'valida que no hayan campos vacios en el formulario
    Public Function ValidaFormulario() As Int16
        If Me.TxtDias.Text = "" Or Me.TxtPorcentaje.Text = "" Then
            Return 1
        Else
            Return 0
        End If
        
    End Function

    Public Function RecuperarPorcentaje() As Int16
        Me.PORCENTAJE = Me.TxtPorcentaje.Text
        Me.DIAS = Val(Me.TxtDias.Text)
        Return -1
    End Function

    Public Function Actualizar(ByVal BENCABEZADO As Int16) As String
        mEntDetalleEntregas = New DETALLEENTREGAS

        If mCompDetalleEntregas.ValidarIDDETALLEENTREGA(Val(Me.LblIDSolicitud.Text), Session.Item("IdEstablecimiento"), Val(Me.LblIDEntrega.Text), CInt(Me.TxtIdDetalle.Text)) = True Then
            mEntDetalleEntregas.IDSOLICITUD = Val(Me.LblIDSolicitud.Text)
            mEntDetalleEntregas.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntDetalleEntregas.IDENTREGA = Val(Me.LblIDEntrega.Text)
            mEntDetalleEntregas.IDDETALLE = CInt(Me.TxtIdDetalle.Text)
            mEntDetalleEntregas.DIAS = CInt(Me.TxtDias.Text)
            mEntDetalleEntregas.PORCENTAJE = CInt(Me.TxtPorcentaje.Text)
            mEntDetalleEntregas.TIPOCONTEO = Me.DdlTipoConteo.SelectedItem.Value
            mEntDetalleEntregas.FECHACONTEO = Me.DdlFechaConteo.SelectedItem.Value
            If mEntDetalleEntregas.AUUSUARIOCREACION = Nothing Then
                mEntDetalleEntregas.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            End If
            If mEntDetalleEntregas.AUFECHACREACION = Nothing Then
                mEntDetalleEntregas.AUFECHACREACION = Now()
            End If
            mEntDetalleEntregas.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntDetalleEntregas.AUFECHAMODIFICACION = Now()
            mEntDetalleEntregas.ESTASINCRONIZADA = 0
            If mCompDetalleEntregas.ActualizarDETALLEENTREGAS(mEntDetalleEntregas) <> 1 Then
                Return "Error al guardar registro."
            End If
        End If
        Return ""
    End Function
End Class