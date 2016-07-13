'CONTROL DE USUARIO PARA AGREGAR FUENTES DE FINANCIAMIENTO A LA SOLICITUD DE COMPRAS
'UTILIZADO EN CU-ESTA001
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario que forma parte de la solicitud de productos de los establecimientos
'el cual permite agregar fuente de financiamiento a la solicitud
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data

Partial Class ucAgregarFuente
    Inherits System.Web.UI.UserControl

    'INICIALIZACION DE VARIABLES
    Private _IDFUENTEFINANCIAMIENTO As Int32
    Private _Enabled As Boolean = True
    Private _sError As String
    Private _nuevo As Boolean = False
    Public Event Cancelar As EventHandler
    Public Event Agregar As EventHandler
    Protected WithEvents dsDatos As System.Data.DataSet
    Private mCompFuenteSolicitud As New cFUENTEFINANCIAMIENTOSOLICITUDES
    Private mEntFuenteSolicitud As New FUENTEFINANCIAMIENTOSOLICITUDES
    Private mCompDetalleSolicitud As New cDETALLESOLICITUDES
    Public Event ErrorEvent(ByVal errorMessage As String)

    Dim MEntFuenteFinancSolic As New FUENTEFINANCIAMIENTOSOLICITUDES

    Dim MontoActual As Double
    Dim MontoReal As Double

    'INICIALIZACION DE PROPIEDADES
    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDFUENTEFINANCIAMIENTO() As Int32
        Get
            Return Me._IDFUENTEFINANCIAMIENTO
        End Get
        Set(ByVal Value As Int32)
            Me._IDFUENTEFINANCIAMIENTO = Value
            Me.Nuevo()
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'EVENTO AL CARGAR PAGINA

        If Not IsPostBack Then 'LA PRIMERA VEZ
            Me.DdlFUENTEFINANCIAMIENTOS1.Recuperar()
            Me.txtPORCENTAJEPARTICIPACION.Text = 100

            RecalcularPorcentaje()
            Me.txtMONTOPARTICIPACION.Text = Me.LblMonto.Text - MontoReal
        End If

        If Not Me.ViewState("nuevo") Is Nothing Then 'VERIFICA SI ES NUEVO
            Me._nuevo = Me.ViewState("nuevo")
        End If

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'HABILITA LA EDCION DE LOS OBJETOS DEL CONTROL

        Me.DdlFUENTEFINANCIAMIENTOS1.Enabled = edicion
        Me.txtMONTOPARTICIPACION.Enabled = edicion
    End Sub

    Public Sub ObtenerMonto(ByVal monto As Double)
        'obtien el suministro del encabezado y verifico el tipo de suministro al que pertenece
        Me.LblMonto.Text = monto
    End Sub

    Private Sub Nuevo()
        'HABILITA SI ES NUEVO
        Me._nuevo = True
        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If
    End Sub

    Public Sub Actualizar()

        'FUNCION PARA ACTUALIZAR LOS DATOS EN LA BASE DE DATOS
        mEntFuenteSolicitud.IDSOLICITUD = Session.Item("IdEncabezado")
        mEntFuenteSolicitud.IDFUENTEFINANCIAMIENTO = Me.DdlFUENTEFINANCIAMIENTOS1.SelectedValue
        mEntFuenteSolicitud.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntFuenteSolicitud.MONTOPARTICIPACION = Me.txtMONTOPARTICIPACION.Text
        Me.txtMONTOPARTICIPACION.AutoFormatCurrency = True
        mEntFuenteSolicitud.PORCENTAJEPARTICIPACION = Me.txtPORCENTAJEPARTICIPACION.Text

        If mEntFuenteSolicitud.AUUSUARIOCREACION = Nothing Then
            mEntFuenteSolicitud.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntFuenteSolicitud.AUFECHACREACION = Nothing Then
            mEntFuenteSolicitud.AUFECHACREACION = Now()
        End If

        mEntFuenteSolicitud.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntFuenteSolicitud.AUFECHAMODIFICACION = Now()
        mEntFuenteSolicitud.ESTASINCRONIZADA = 0

        mCompFuenteSolicitud.AgregarFUENTEFINANCIAMIENTOSOLICITUDES(mEntFuenteSolicitud)

    End Sub

    Protected Sub ImgbGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar.Click
        'EVENTO AL PRESIONAR LA IMAGEN DE GUARDAR Y VERIFICACION DE DATOS

        Me.txtMONTOPARTICIPACION.AutoFormatCurrency = False
        Me.txtPORCENTAJEPARTICIPACION.Text = (Me.txtMONTOPARTICIPACION.Text / Me.LblMonto.Text) * 100

        MontoReal = Me.mCompFuenteSolicitud.CalcularMontoTotalFuenteSolicitud(Session.Item("IdEncabezado"), Session.Item("IdEstablecimiento"))
        MontoActual = MontoReal + Me.txtMONTOPARTICIPACION.Text

        If Me.mCompFuenteSolicitud.FuenteSolicitudExiste(Session.Item("IdEncabezado"), Session.Item("IdEstablecimiento"), Me.DdlFUENTEFINANCIAMIENTOS1.SelectedValue) Then
            RaiseEvent ErrorEvent("Esta fuente ya fue agregada")
        Else

            If Val(Me.txtMONTOPARTICIPACION.Text) > 0 Then

                If Val(Me.txtPORCENTAJEPARTICIPACION.Text) > 0 Then

                    If MontoActual > Me.LblMonto.Text Then
                        RaiseEvent ErrorEvent("El monto de participacion supera el monto total de la solicitud")
                        MontoReal = Me.mCompFuenteSolicitud.CalcularMontoTotalFuenteSolicitud(Session.Item("IdEncabezado"), Session.Item("IdEstablecimiento"))
                        Me.txtMONTOPARTICIPACION.Text = Me.LblMonto.Text - MontoReal
                    Else
                        Actualizar()
                        MontoReal = Me.mCompFuenteSolicitud.CalcularMontoTotalFuenteSolicitud(Session.Item("IdEncabezado"), Session.Item("IdEstablecimiento"))
                        Me.txtMONTOPARTICIPACION.Text = Me.LblMonto.Text - MontoReal
                        Me.txtPORCENTAJEPARTICIPACION.Text = 0
                        RaiseEvent Agregar(sender, e)
                    End If
                    'End If
                Else
                    'error
                    RaiseEvent ErrorEvent("El porcentaje no puede ser 0")
                End If
            Else
                'error
                RaiseEvent ErrorEvent("El monto no puede ser 0")
            End If
        End If
    End Sub

    Protected Sub ImgbCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCancelar.Click
        'EVENTO AL PRESIONAR IMAGEN DE CANCELAR 
        MontoReal = Me.mCompFuenteSolicitud.CalcularMontoTotalFuenteSolicitud(Session.Item("IdEncabezado"), Session.Item("IdEstablecimiento"))
        Me.txtMONTOPARTICIPACION.Text = Me.LblMonto.Text - MontoReal
        Me.txtPORCENTAJEPARTICIPACION.Text = 0
        RaiseEvent Cancelar(sender, e)
    End Sub

    Public Sub asignarmonto(ByVal monto As Double)
        MontoReal = Me.mCompFuenteSolicitud.CalcularMontoTotalFuenteSolicitud(Session.Item("IdEncabezado"), Session.Item("IdEstablecimiento"))
        Me.LblMonto.Text = monto
        Me.txtMONTOPARTICIPACION.Text = Me.LblMonto.Text - MontoReal
    End Sub

    Public Sub RecalcularPorcentaje()
        If mCompFuenteSolicitud.ExisteFuentesAsociadasSolicitud(Session.Item("IdEncabezado"), Session.Item("IdEstablecimiento")) Then

            Me.LblMonto.Text = mCompDetalleSolicitud.CalcularMontoTotalSolicitud(Session.Item("IdEncabezado"), Session.Item("IdEstablecimiento"))
            MontoReal = Me.mCompFuenteSolicitud.CalcularMontoTotalFuenteSolicitud(Session.Item("IdEncabezado"), Session.Item("IdEstablecimiento"))

            Dim ds As DataSet
            ds = mCompFuenteSolicitud.ObtenerDatasetFuentesPorSolicitud(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"))

            For Each r As DataRow In ds.Tables(0).Rows
                MEntFuenteFinancSolic.IDSOLICITUD = (Session.Item("IdEncabezado"))
                MEntFuenteFinancSolic.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                MEntFuenteFinancSolic.IDFUENTEFINANCIAMIENTO = r("IDFUENTEFINANCIAMIENTO")
                mCompFuenteSolicitud.ObtenerFUENTEFINANCIAMIENTOSOLICITUDES(MEntFuenteFinancSolic)
                MEntFuenteFinancSolic.PORCENTAJEPARTICIPACION = (MEntFuenteFinancSolic.MONTOPARTICIPACION / Me.LblMonto.Text) * 100
                MEntFuenteFinancSolic.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                MEntFuenteFinancSolic.AUFECHAMODIFICACION = Now()
                MEntFuenteFinancSolic.ESTASINCRONIZADA = 0
                mCompFuenteSolicitud.ActualizarFUENTEFINANCIAMIENTOSOLICITUDES(MEntFuenteFinancSolic)
            Next r
        End If
    End Sub

End Class
