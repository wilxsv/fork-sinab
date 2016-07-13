Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Controles_ucAmpliacionPlazoEntrega
    Inherits System.Web.UI.UserControl
    Private _IDSOLICITUD As Int64
    Private _IDDETALLE As Int16
    Private _IDENTREGA As Int16
    Private _IDCALCULO As Int16
    Private _PORCENTAJE As Decimal
    Private _DIAS As Int16
    Private _ERRORES As String
    Private mComponente As New cENTREGACONTRATO
    Private mComAlmacenEntregaContrato As New cALMACENESENTREGACONTRATOS
    Private lEntAlmEntCon As New ALMACENESENTREGACONTRATOS

    Private mCompDetalleEntregas As New cDETALLEENTREGAS
    Private mEntidad As ENTREGACONTRATO
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


        mEntidad = New ENTREGACONTRATO
        mEntDetalleEntregas = New DETALLEENTREGAS

        mEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mEntidad.IDPROVEEDOR = Request.QueryString("IdProv")
        mEntidad.IDCONTRATO = Request.QueryString("IdCont")
        mEntidad.RENGLON = Request.QueryString("idRenglon")
        mEntidad.ENTREGA = Me.IDENTREGA
        mEntidad.PLAZOENTREGA = CInt(Me.TxtDias.Text)
        mEntidad.PORCENTAJEENTREGA = CInt(Me.TxtPorcentaje.Text)
        mEntidad.FECHACONTEO = Me.DdlFechaConteo.SelectedItem.Value
        mEntidad.IDMODIFICATIVA = 0
        mEntidad.ESTAHABILITADA = 1
        mEntidad.ESTASINCRONIZADA = 1 'Aqui debo poner el ID de la Ampliacion
        mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHACREACION = Date.Now
        Dim IDDETALLE As Integer
        'If BENCABEZADO = 0 Then
        If mComponente.ValidarEntrega(Session.Item("IdEstablecimiento"), Request.QueryString("IdProv"), Request.QueryString("IdCont"), Request.QueryString("idRenglon"), Me.IDENTREGA) = False Then
            IDDETALLE = mComponente.ActualizarAmpliacion(mEntidad)
            'If IDDETALLE <> 0 Then
            '    ' MsgBox("Error al Guardar registro.")

            '    lEntAlmEntCon.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            '    lEntAlmEntCon.IDPROVEEDOR = Request.QueryString("IdProv")
            '    lEntAlmEntCon.IDCONTRATO = Request.QueryString("IdCont")
            '    lEntAlmEntCon.RENGLON = Request.QueryString("idRenglon")
            '    lEntAlmEntCon.IDDETALLE = IDDETALLE
            '    lEntAlmEntCon.CANTIDAD = CDec(Request.QueryString("CantidadAmpliada")) * (CDec(Me.TxtPorcentaje.Text) / 100)
            '    lEntAlmEntCon.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            '    lEntAlmEntCon.AUFECHACREACION = Date.Now
            '    lEntAlmEntCon.ESTASINCRONIZADA = 0

            '    If mComAlmacenEntregaContrato.AgregarALMACENESENTREGACONTRATOS(lEntAlmEntCon) <> 1 Then
            '        Return "Error al guardar registro."
            '    End If
            'Else
            '    '   MsgBox("Correcto")
            'End If
        Else
            'Response.Write("<script language='javascript'>window.alert('Este plazo de entrega ya esta definido');</script>")
        End If
        'End If

        Return ""
    End Function
End Class