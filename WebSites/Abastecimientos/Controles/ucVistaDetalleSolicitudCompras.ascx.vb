'INGRESO DE SOLICITUD DE COMPRAS
'CU-ESTA0001
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario para el encabezado de la solicitud de compras
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports Cooperator.Framework.Web.Controls
Imports System.Data

Partial Class Controles_ucVistaDetalleSolicitudCompras
    Inherits System.Web.UI.UserControl

    'declarar e inicializar variables
    Private _IDSOLICITUD As Int64
    Private _IDESTADO As Int32
    Private _MONTO As Double
    Private _Enabled As Boolean = True
    Private _EnabledConjunta As Boolean = True
    Private _Autoriza As Boolean = False
    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cSOLICITUDES
    Private mEntidad As New SOLICITUDES
    Private mEntEmpleado As New EMPLEADOS
    Private mEntCargo As New CARGOS
    Private mEntAlmacen As New ALMACENES
    Private mCompAlmacen As New cALMACENES




    Private mcompEmpleado As New cEMPLEADOS
    Private mCompCargo As New cCARGOS
    Private mCompTipoProducto As New cSUMINISTROS
    Private mEntTipoProducto As New SUMINISTROS
    Private mEntHistoricoEstados As New HISTORICOESTADOSSOLICITUDES
    Private mCompHistoricoEstados As New cHISTORICOESTADOSSOLICITUDES
    Private mCompEntregas As New cENTREGASOLICITUDES

    Dim entregas As Integer
    Dim DetalleEntrega As DataSet

    Public Event ErrorEvent(ByVal errorMessage As String)
    Public Event NumeroSolicitud(ByVal NumSolicitud As String, ByVal suministro As String)
    Public Event esconjunta(ByVal edicion As Boolean)

    Dim EstadoTemporal As Integer
    Dim hoy As Date
    Dim correlt As String

    Public ReadOnly Property sError() As String 'error
        Get
            Return _sError
        End Get
    End Property

    Public Sub IMPRIMIRPROGRAMA(ByVal edicion As Boolean)
        Me.BttImprimirPrograma.Visible = edicion
    End Sub

    Public Property IDSOLICITUD() As Int64 'identificador de solicitud
        Get
            Return Me._IDSOLICITUD
        End Get
        Set(ByVal Value As Int64)
            Me._IDSOLICITUD = Value

            CargarDDLs()

            If Me._IDSOLICITUD > 0 Then
                HabilitarSolicitud(True)
                HabilitarCertificacionFondos(False)
                HabilitarCambiarEstado(False)
                Me.ddlTIPOCOMPRAS2.Enabled = False
                Me.CargarDatos()
                BttImprimirPrograma.Visible = True
            Else
                Me.Nuevo()
                HabilitarSolicitud(True)
                HabilitarCertificacionFondos(False)
                HabilitarCambiarEstado(False)
                HabilitarSuministro(True)
                Me.ddlTIPOCOMPRAS2.Enabled = False
                Me.ddlDEPENDENCIAESTABLECIMIENTOS1.SelectedValue = Session.Item("IdDependencia")
                mEntidad.IDESTABLECIMIENTO = CInt(Session.Item("IdEstablecimiento"))
                Me.txtCORRELATIVO.Text = Me.mComponente.Correlativo_Solicitud(mEntidad)
                correlt = Me.txtCORRELATIVO.Text & "/" & DateTime.Now.ToString("yyyy")
                Session.Item("num") = CInt(Me.txtCORRELATIVO.Text)
                Me.txtCORRELATIVO.Text = correlt
                Me.TxtCompraConjunta.Text = 0
                Me.BttImprimirPrograma.Visible = False
                Me.ddlEMPLEADOS1.SelectedValue = Session.Item("IdEmpleado")
                Me.ddlEMPLEADOS2.SelectedValue = Session.Item("IdEmpleado")
                Me.ddlEMPLEADOS3.SelectedValue = Session.Item("IdEmpleado")
                Me.ddlEMPLEADOS4.SelectedValue = Session.Item("IdEmpleado")
            End If
        End Set
    End Property

    Public Property IDESTADO() As Int32 'identificador de estado
        Get
            Return Me._IDESTADO
        End Get
        Set(ByVal Value As Int32)
            Me._IDESTADO = Value
        End Set
    End Property

    Public Property MontoSolicitud() As Double 'monto de la solicitud
        Get
            Return Me._MONTO
        End Get
        Set(ByVal Value As Double)
            Me._MONTO = Value
        End Set
    End Property

    Public Property Enabled() As Boolean 'habilitar edicion
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Public Property Autoriza() As Boolean 'si se ingresa para autorizar solicitud
        Get
            Return Me._Autoriza
        End Get
        Set(ByVal Value As Boolean)
            Me._Autoriza = Value
            Me.HabilitarCertificacionFondos(Me._Autoriza)
            HabilitarSolicitud(False)
            HabilitarCambiarEstado(False)
        End Set
    End Property

    Public Property Conjunta() As Boolean 'si se ingresa como conjunta
        Get
            Return Me._EnabledConjunta
        End Get
        Set(ByVal Value As Boolean)
            Me._EnabledConjunta = Value

            HabilitarSolicitud(True)
            HabilitarCambiarEstado(False)
            HabilitarSuministro(Me._EnabledConjunta)
            Me.HabilitarConjunta(Me._EnabledConjunta)

            RaiseEvent esconjunta(Me._EnabledConjunta)

        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al carga la pagina
        deshabilitarDobleClickBotones()

        hoy = DateTime.Now.Date

        If Me.txtMONTOAUTORIZADO.Text = "" Then Me.txtMONTOAUTORIZADO.Text = 0
        If Me.txtMONTODISPONIBLE.Text = "" Then Me.txtMONTODISPONIBLE.Text = 0
        If Me.txtMONTOSOLICITADO.Text = "" Then Me.txtMONTOSOLICITADO.Text = 0
        If Me.txtRESERVAFONDO.Text = "" Then Me.txtRESERVAFONDO.Text = 0

        Me.txtMONTOSOLICITADO.AutoFormatCurrency = False
        Me.txtMONTODISPONIBLE.AutoFormatCurrency = False
        Me.txtMONTOAUTORIZADO.AutoFormatCurrency = False
        Me.txtRESERVAFONDO.AutoFormatCurrency = False

        If Not IsPostBack Then 'la primera vez

            Me.CalendarFechaSolicitud1.Visible = True

            cargaInicial()

            Session.Item("CambioEstado") = False
            Me.txtMONTOSOLICITADO.AutoFormatCurrency = True
            Me.txtMONTODISPONIBLE.AutoFormatCurrency = True
            Me.txtMONTOAUTORIZADO.AutoFormatCurrency = True
            Me.txtRESERVAFONDO.AutoFormatCurrency = True

            Me.LabelEstablecimientoSolicita.Text = Session.Item("UsuarioEstablecimiento")

        End If

        If Not Me.ViewState("nuevo") Is Nothing Then
            Me._nuevo = Me.ViewState("nuevo")
        End If

    End Sub

    Public Sub CargarArbolEntregas() 'llena el treeviw de entreegas
        Me.TvEntregas.Nodes.Clear()
        Me.TvEntregas.ShowLines = True
        Me.TvEntregas.Nodes.Add(BuildNode("Entregas Definidas"))
        Dim parent As TreeNode
        Dim r As DataRow

        entregas = mCompEntregas.ObtenerNumeroEntregas(Me.txtIDSOLICITUD.Text, Session.Item("IdEstablecimiento"))
        If entregas >= 1 Then
            Me.BttFormasEntrega.Enabled = False
            Me.TvEntregas.ExpandAll()
        End If

        Dim i As Integer

        For i = 0 To entregas
            If i <> entregas Then
                Me.TvEntregas.Nodes(0).ChildNodes.Add(BuildNode("Entrega " & i + 1))
                DetalleEntrega = mCompEntregas.ObtenerDetalleEntrega(Me.txtIDSOLICITUD.Text, Session.Item("IdEstablecimiento"), i + 1)
                parent = TvEntregas.Nodes(0).ChildNodes(i)
                For Each r In DetalleEntrega.Tables(0).Rows
                    Dim Nombre As String = r("DIAS") & " Dias / " & r("PORCENTAJE") & " % / " & r("DESCRIPCION")
                    parent.ChildNodes.Add(BuildNode(Nombre))
                Next r
            End If
        Next i
    End Sub

    Private Function BuildNode(ByVal strTextAndValue As String, Optional ByVal strURL As String = "javascript:void(0)") As TreeNode
        ' Crea a TreeNode y asigna
        ' el texto y el valor 
        Dim node As New TreeNode
        node.Text = strTextAndValue
        node.Value = strTextAndValue
        node.NavigateUrl = strURL
        node.SelectAction = TreeNodeSelectAction.None

        Return node
    End Function

    Private Sub CargarDatos()
        'si existe la solicitud de compras carga la data existente

        mEntidad = New SOLICITUDES
        mEntidad.IDSOLICITUD = IDSOLICITUD
        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

        If mComponente.ObtenerSOLICITUDES(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener Registro.")
            MsgBox1.ShowAlert("Error al obtener registro", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else

            If mEntidad.COMPRACONJUNTA = 1 Then
                Me.ddlALMACENES1.Visible = False
                Me.TxtDireccion.Visible = False
                Me.LblIDALMACEN.Visible = False
                Me.lblDireccion.Visible = False
                Me.lblDireccionA.Visible = False
            Else
                Try
                    Me.ddlALMACENES1.SelectedValue = mEntidad.IDALMACENENTREGA
                    cargaAlmacen()
                Catch ex As Exception
                    RaiseEvent ErrorEvent("Error al obtener almacen, el almacen ha sido eliminado o ya no esta relacionado a este establecimiento, corriga el problema o seleccione otro.")
                End Try
            End If

            Try
                Me.txtIDSOLICITUD.Text = mEntidad.IDSOLICITUD
                Me.txtCORRELATIVO.Text = mEntidad.CORRELATIVO
                Session.Item("num") = mEntidad.NUMCORR
                Me.CalendarFechaSolicitud1.SelectedDate = IIf(Not mEntidad.FECHASOLICITUD = Nothing, Format(mEntidad.FECHASOLICITUD, "dd/MM/yyyy"), Now.Date)
                Me.ddlPlazoentrega.SelectedValue = mEntidad.PLAZOENTREGA

                Me.ddlSUMINISTROS1.SelectedValue = mEntidad.IDCLASESUMINISTRO
                Me.ddlPeriodoUtilizacion.SelectedValue = mEntidad.PERIODOUTILIZACION
                Me.txtMONTOSOLICITADO.Text = mEntidad.MONTOSOLICITADO
                Me.txtMONTODISPONIBLE.Text = mEntidad.MONTODISPONIBLE
                Me.txtOBSERVACION.Text = mEntidad.OBSERVACION
                Me.txtCIFRADOPRESUPUESTARIO.Text = mEntidad.CIFRADOPRESUPUESTARIO
                Me.txtRESERVAFONDO.Text = mEntidad.RESERVAFONDO
                Me.CalendarFechaAut1.SelectedDate = IIf(Not mEntidad.FECHAAUTORIZACION = Nothing, Format(mEntidad.FECHAAUTORIZACION, "dd/MM/yyyy"), Now.Date)
                Me.txtMONTOAUTORIZADO.Text = mEntidad.MONTOAUTORIZADO
                Me.txtCODRESERVAFONDO.Text = mEntidad.CODRESERVAFONDO
                Me.ddlESTADOS1.SelectedValue = mEntidad.IDESTADO
                EstadoTemporal = mEntidad.IDESTADO
                Me.ddlDEPENDENCIAESTABLECIMIENTOS1.SelectedValue = mEntidad.IDDEPENDENCIASOLICITANTE
            Catch ex As Exception
                RaiseEvent ErrorEvent("Error al obtener datos")
            End Try

            Try
                Me.ddlEMPLEADOS1.SelectedValue = mEntidad.IDSOLICITANTE
                Me.ddlEMPLEADOS2.SelectedValue = mEntidad.IDAREATECNICA
                Me.ddlEMPLEADOS4.SelectedValue = mEntidad.IDCERTIFICA
                Me.ddlEMPLEADOS3.SelectedValue = mEntidad.IDAUTORIZA
            Catch ex As Exception
                RaiseEvent ErrorEvent("Error al obtener empleados, algun empleado ha sido eliminado o ya no esta relacionado a este establecimiento.")
            End Try

            Try
                Me.ddlTIPOCOMPRAS1.SelectedValue = mEntidad.IDTIPOCOMPRASOLICITADO
            Catch ex As Exception
                Me.ddlTIPOCOMPRAS1.SelectedValue = 5
                RaiseEvent ErrorEvent("deberá reasignar nuevamente el tipo de compra solicitado, segun ley LACAP")
            End Try
            Try
                If Me.txtMONTOSOLICITADO.Text > 0 Then
                    Me.ddlTIPOCOMPRAS2.SelectedValue = mEntidad.IDTIPOCOMPRASUGERIDO
                Else
                    Me.ddlTIPOCOMPRAS2.SelectedValue = 5
                End If
            Catch ex As Exception
                Me.ddlTIPOCOMPRAS2.SelectedValue = 5
            End Try

            Try
                Me.ddlTIPOCOMPRAS3.SelectedValue = mEntidad.IDTIPOCOMPRAEJECUTAR
            Catch ex As Exception
                Me.ddlTIPOCOMPRAS3.SelectedValue = 5
                RaiseEvent ErrorEvent("deberá reasignar nuevamente el tipo de compra solicitado, segun ley LACAP")
            End Try

            Me.TxtCompraConjunta.Text = mEntidad.COMPRACONJUNTA
            Datos()
            CargarArbolEntregas()
        End If

    End Sub

    Private Sub HabilitarConjunta(ByVal edicion As Boolean)
        'habilit campos para la conjunta
        Me.BttFormasEntrega.Enabled = edicion
        Me.ddlTIPOCOMPRAS1.Enabled = edicion
        Me.ddlTIPOCOMPRAS2.Enabled = False
        Me.ddlTIPOCOMPRAS3.Enabled = edicion
        Me.ddlALMACENES1.Visible = edicion
        Me.LblIDALMACEN.Visible = edicion
        Me.lblDireccion.Visible = edicion
        Me.lblDireccionA.Visible = edicion
        Me.ddlPeriodoUtilizacion.Enabled = edicion
        Me.ddlPlazoentrega.Enabled = edicion
    End Sub

    Private Sub HabilitarCertificacionFondos(ByVal edicion As Boolean)
        'habilita campos para la certificacion de fondos
        Me.txtCIFRADOPRESUPUESTARIO.Visible = edicion
        lblCIFRADOPRESUPUESTARIO.Visible = edicion
        lblIDCERTIFICA.Visible = edicion
        lblFECHAAUTORIZACION.Visible = edicion
        Me.ddlEMPLEADOS4.Visible = edicion
        Me.TxtCargoEmpleadoCertifica.Visible = edicion
        Me.CalendarFechaAut1.Visible = edicion
        Me.lblCertificacion.Visible = edicion
    End Sub

    Public Sub MostrarCamposCertificacionFondosConsulta(ByVal edicion As Boolean)
        'habilita campos para la certificacion de fondos
        Me.txtCIFRADOPRESUPUESTARIO.Visible = edicion
        lblCIFRADOPRESUPUESTARIO.Visible = edicion
        lblIDCERTIFICA.Visible = edicion
        lblFECHAAUTORIZACION.Visible = edicion
        Me.ddlEMPLEADOS4.Visible = edicion
        Me.TxtCargoEmpleadoCertifica.Visible = edicion
        Me.CalendarFechaAut1.Visible = edicion
        Me.lblCertificacion.Visible = edicion

        Me.txtCIFRADOPRESUPUESTARIO.Enabled = False
        lblCIFRADOPRESUPUESTARIO.Enabled = False
        lblIDCERTIFICA.Enabled = False
        lblFECHAAUTORIZACION.Enabled = False
        Me.ddlEMPLEADOS4.Enabled = False
        Me.TxtCargoEmpleadoCertifica.Enabled = False
        Me.CalendarFechaAut1.Enabled = False

    End Sub

    Private Sub HabilitarCambiarEstado(ByVal edicion As Boolean)
        'habilita campos para cambiar de estado
        Me.ddlESTADOS1.Enabled = edicion
    End Sub

    Public Sub HabilitarSuministro(ByVal edicion As Boolean)
        'habilita el campo de suministro
        Me.ddlSUMINISTROS1.Enabled = edicion
    End Sub

    Private Sub HabilitarSolicitud(ByVal edicion As Boolean)
        'habilita los otros campos de la solicitud de compra encabeado
        Me.txtCORRELATIVO.Enabled = edicion
        Me.CalendarFechaSolicitud1.Enabled = edicion
        Me.txtOBSERVACION.Enabled = edicion
        Me.ddlEMPLEADOS1.Enabled = edicion
        Me.ddlEMPLEADOS2.Enabled = edicion
        Me.TxtCargoEmpleadoSolicita.Enabled = edicion
        Me.TxtCargoEmpleadoAreaTec.Enabled = edicion
        Me.ddlEMPLEADOS3.Enabled = edicion
        Me.TxtCargoEmpleadoAutoriza.Enabled = edicion
        Me.LblFormasEntrega.Enabled = edicion
        Me.ddlTIPOCOMPRAS1.Enabled = edicion
        Me.ddlTIPOCOMPRAS2.Enabled = False
        Me.ddlTIPOCOMPRAS3.Enabled = edicion
        Me.BttFormasEntrega.Enabled = edicion
        Me.ddlPeriodoUtilizacion.Enabled = edicion
        Me.ddlPlazoentrega.Enabled = edicion
        Me.ddlALMACENES1.Enabled = edicion
        Me.TxtDireccion.Enabled = edicion
    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'habilita la edicion
        HabilitarSolicitud(edicion)
    End Sub

    Private Sub Grabado() 'solicitud grabada
        Me._nuevo = False
        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

    End Sub

    Private Sub Nuevo() 'solicitud nueva
        Me._nuevo = True
        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If
    End Sub

    Public Function Actualizar() As String

        'actualiza los campos del encabezado de solicitud de compra
        mEntidad = New SOLICITUDES

        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

        If Me._nuevo Then 'si es nuevo
            mEntidad.IDSOLICITUD = mComponente.id_Solicitud(mEntidad)
            Session.Item("idDoc") = mEntidad.IDSOLICITUD
            Me.txtIDSOLICITUD.Text = mEntidad.IDSOLICITUD
            mEntidad.NUMCORR = Session.Item("num")
        Else 'si existe
            mEntidad.IDSOLICITUD = CInt(Me.txtIDSOLICITUD.Text)
            correlt = Me.txtCORRELATIVO.Text
            mEntidad.NUMCORR = Session.Item("num")
        End If

        Me.txtMONTOSOLICITADO.AutoFormatCurrency = False
        Me.txtMONTODISPONIBLE.AutoFormatCurrency = False
        Me.txtMONTOAUTORIZADO.AutoFormatCurrency = False
        Me.txtRESERVAFONDO.AutoFormatCurrency = False

        'campos comunes de la solicitud nueva e existente
        mEntidad.CORRELATIVO = Me.txtCORRELATIVO.Text
        mEntidad.FECHASOLICITUD = Me.CalendarFechaSolicitud1.SelectedDate
        mEntidad.PLAZOENTREGA = Val(Me.ddlPlazoentrega.SelectedValue)

        If Me.ddlALMACENES1.SelectedValue = Nothing Or Me.ddlALMACENES1.SelectedValue Is DBNull.Value Then
            MsgBox1.ShowAlert("No se puede completar operacion porque no existe almacenes de entrega asociado a este establecimiento", "errorAlmacen", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            mEntidad.IDALMACENENTREGA = Me.ddlALMACENES1.SelectedValue
        End If

        mEntidad.IDCLASESUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue
        mEntidad.PERIODOUTILIZACION = Val(Me.ddlPeriodoUtilizacion.SelectedValue)
        mEntidad.MONTOSOLICITADO = Me.txtMONTOSOLICITADO.Text
        mEntidad.MONTODISPONIBLE = Me.txtMONTODISPONIBLE.Text
        mEntidad.OBSERVACION = Me.txtOBSERVACION.Text
        mEntidad.IDSOLICITANTE = Me.ddlEMPLEADOS1.SelectedValue
        mEntidad.IDAREATECNICA = Me.ddlEMPLEADOS2.SelectedValue

        mEntidad.IDAUTORIZA = Me.ddlEMPLEADOS3.SelectedValue
        mEntidad.IDESTADO = Me.ddlESTADOS1.SelectedValue

        If Me.ddlESTADOS1.SelectedValue = "5" Then 'auorizar UFI
            mEntidad.CIFRADOPRESUPUESTARIO = Me.txtCIFRADOPRESUPUESTARIO.Text
            mEntidad.RESERVAFONDO = Me.txtRESERVAFONDO.Text
            mEntidad.FECHAAUTORIZACION = Me.CalendarFechaAut1.SelectedDate
            mEntidad.MONTOAUTORIZADO = Me.txtMONTOAUTORIZADO.Text
            mEntidad.CODRESERVAFONDO = Me.txtCODRESERVAFONDO.Text
            mEntidad.IDCERTIFICA = Me.ddlEMPLEADOS4.SelectedValue
        Else
            mEntidad.CIFRADOPRESUPUESTARIO = ""
            mEntidad.RESERVAFONDO = 0
            mEntidad.MONTOAUTORIZADO = 0
            mEntidad.CODRESERVAFONDO = ""
            mEntidad.FECHAAUTORIZACION = Nothing
            mEntidad.IDCERTIFICA = Me.ddlEMPLEADOS4.SelectedValue
        End If

        mEntidad.IDDEPENDENCIASOLICITANTE = Me.ddlDEPENDENCIAESTABLECIMIENTOS1.SelectedValue
        mEntidad.IDTIPOCOMPRASOLICITADO = Me.ddlTIPOCOMPRAS1.SelectedValue
        mEntidad.IDTIPOCOMPRASUGERIDO = Me.ddlTIPOCOMPRAS2.SelectedValue
        mEntidad.IDTIPOCOMPRAEJECUTAR = Me.ddlTIPOCOMPRAS3.SelectedValue

        mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHACREACION = Now()
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0
        mEntidad.COMPRACONJUNTA = Me.TxtCompraConjunta.Text

        Me.txtMONTOSOLICITADO.AutoFormatCurrency = True
        Me.txtMONTODISPONIBLE.AutoFormatCurrency = True
        Me.txtMONTOAUTORIZADO.AutoFormatCurrency = True
        Me.txtRESERVAFONDO.AutoFormatCurrency = True

        If EstadoTemporal = Val(Me.ddlESTADOS1.SelectedItem.Value) Then
            HistoricoSolicitudes()
        End If

        'al momeno de actualizar la slicitud de compra
        If Me.CalendarFechaSolicitud1.SelectedDate <= hoy Then 'verifica que fecha no sea mayor a la actual

            If mComponente.ValidarCorrelativoSolicitud(Me.txtIDSOLICITUD.Text, Me.txtCORRELATIVO.Text, Session.Item("IdEstablecimiento")) Then
                'ya existe ese numero de correlativo
                MsgBox1.ShowAlert("Numero de correlativo ya existe", "errorCorrelativo", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Return "Error al Guardar registro."
                Me.BttFormasEntrega.Visible = True
            Else

                If Me.ddlALMACENES1.SelectedValue = Nothing Or Me.ddlALMACENES1.SelectedValue Is DBNull.Value Then
                    'almacen no asignado al establecimiento
                Else

                    If validarempleadosSolicitud() Then
                        If validarLongitudCertificacion() Then
                            If Me._nuevo Then
                                If mComponente.AgregarSOLICITUDES(mEntidad) <> 1 Then
                                    Return "Error al Guardar registro."
                                Else
                                    Me.Grabado()
                                    RaiseEvent NumeroSolicitud(Session.Item("idDoc"), Me.ddlSUMINISTROS1.SelectedValue)

                                    Me.ddlSUMINISTROS1.Enabled = False
                                    Return ""
                                End If
                            Else
                                If mComponente.ActualizarSOLICITUDES(mEntidad) <> 1 Then
                                    Return "Error al Guardar registro."
                                Else
                                    RaiseEvent NumeroSolicitud(Me.txtIDSOLICITUD.Text, Me.ddlSUMINISTROS1.SelectedValue)
                                    CargarArbolEntregas()
                                    Return ""
                                End If
                            End If
                        Else
                            MsgBox1.ShowAlert("Verificar que certificacion de fondos no sobrepase los 50 caracteres", "error11", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                            Return "Error al Guardar registro."

                        End If
                    Else
                        MsgBox1.ShowAlert("Verificar que no sea el mismo empleado el que solicita, area tecnica o autoriza", "error10", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                        Return "Error al Guardar registro."
                    End If
                End If
            End If
        Else
            MsgBox1.ShowAlert("Fecha no debe ser mayor a la fecha actual", "error4", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return "Error al Guardar registro."
        End If

    End Function

    Private Function validarempleadosSolicitud() As Boolean
        'valida que no sean los mismos empleados los que solicitan, autoriza, tecnico o certifica 
        If (Me.ddlEMPLEADOS1.SelectedValue = Me.ddlEMPLEADOS2.SelectedValue) Then Return False
        If (Me.ddlEMPLEADOS1.SelectedValue = Me.ddlEMPLEADOS3.SelectedValue) Then Return False
        If (Me.ddlEMPLEADOS2.SelectedValue = Me.ddlEMPLEADOS3.SelectedValue) Then Return False

        If Me.ddlESTADOS1.SelectedValue = "5" Or Me.ddlESTADOS1.SelectedValue = "6" Then 'enviada UFI o aprobada UFI
            If (Me.ddlEMPLEADOS1.SelectedValue = Me.ddlEMPLEADOS4.SelectedValue) Then Return False
            If (Me.ddlEMPLEADOS2.SelectedValue = Me.ddlEMPLEADOS4.SelectedValue) Then Return False
            If (Me.ddlEMPLEADOS3.SelectedValue = Me.ddlEMPLEADOS4.SelectedValue) Then Return False
        End If
        Return True
    End Function

    Private Function validarLongitudCertificacion() As Boolean
        Dim longitud As Integer
        longitud = Len(Trim(Me.txtCIFRADOPRESUPUESTARIO.Text))
        If Me.ddlESTADOS1.SelectedValue = "5" Or Me.ddlESTADOS1.SelectedValue = "6" Then 'enviada UFI o aprobada UFI
            If longitud > 50 Then Return False
        End If
        Return True
    End Function

    Private Sub Datos() 'carga los datos de los cargos de los empleados cuando existe la solicitud
        mEntEmpleado.IDEMPLEADO = mEntidad.IDSOLICITANTE
        mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)
        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        mCompCargo.ObtenerCARGOS(mEntCargo)
        TxtCargoEmpleadoSolicita.Text = mEntCargo.DESCRIPCION

        mEntEmpleado.IDEMPLEADO = mEntidad.IDAREATECNICA
        mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)
        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        mCompCargo.ObtenerCARGOS(mEntCargo)
        TxtCargoEmpleadoAreaTec.Text = mEntCargo.DESCRIPCION

        mEntEmpleado.IDEMPLEADO = mEntidad.IDAUTORIZA
        mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)
        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        mCompCargo.ObtenerCARGOS(mEntCargo)
        TxtCargoEmpleadoAutoriza.Text = mEntCargo.DESCRIPCION

        mEntEmpleado.IDEMPLEADO = mEntidad.IDCERTIFICA
        mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)
        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        mCompCargo.ObtenerCARGOS(mEntCargo)
        Me.TxtCargoEmpleadoCertifica.Text = mEntCargo.DESCRIPCION

        mEntTipoProducto.IDSUMINISTRO = mEntidad.IDCLASESUMINISTRO
        mCompTipoProducto.ObtenerSUMINISTROS(mEntTipoProducto)
        Me.txtMONTODISPONIBLE.Text = mEntTipoProducto.MONTODISPONIBLE

    End Sub

    Private Sub cargaAlmacen() 'carga los datos del almacen
        mEntAlmacen.IDALMACEN = mEntidad.IDALMACENENTREGA
        mCompAlmacen.ObtenerALMACENES(mEntAlmacen)
        Me.TxtDireccion.Text = mEntAlmacen.DIRECCION
    End Sub

    Private Sub cargaInicial() 'carga los datos de los cargos de los empleados y almacen la primera vez
        mEntEmpleado.IDEMPLEADO = Me.ddlEMPLEADOS1.SelectedValue
        mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)
        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        mCompCargo.ObtenerCARGOS(mEntCargo)
        TxtCargoEmpleadoSolicita.Text = mEntCargo.DESCRIPCION

        mEntEmpleado.IDEMPLEADO = Me.ddlEMPLEADOS2.SelectedValue
        mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)
        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        mCompCargo.ObtenerCARGOS(mEntCargo)
        TxtCargoEmpleadoAreaTec.Text = mEntCargo.DESCRIPCION

        mEntEmpleado.IDEMPLEADO = Me.ddlEMPLEADOS4.SelectedValue
        mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)
        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        mCompCargo.ObtenerCARGOS(mEntCargo)
        TxtCargoEmpleadoAutoriza.Text = mEntCargo.DESCRIPCION

        mEntEmpleado.IDEMPLEADO = Me.ddlEMPLEADOS3.SelectedValue
        mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)
        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        mCompCargo.ObtenerCARGOS(mEntCargo)
        Me.TxtCargoEmpleadoCertifica.Text = mEntCargo.DESCRIPCION

        mEntTipoProducto.IDSUMINISTRO = ddlSUMINISTROS1.SelectedValue
        mCompTipoProducto.ObtenerSUMINISTROS(mEntTipoProducto)
        Me.txtMONTODISPONIBLE.Text = mEntTipoProducto.MONTODISPONIBLE

        If Me.ddlALMACENES1.SelectedValue = Nothing Or Me.ddlALMACENES1.SelectedValue Is DBNull.Value Then
            'no hay almacenes para este establecimiento
        Else
            mEntAlmacen.IDALMACEN = Me.ddlALMACENES1.SelectedValue
            mCompAlmacen.ObtenerALMACENES(mEntAlmacen)
            Me.TxtDireccion.Text = mEntAlmacen.DIRECCION
            Me.lblDireccionA.Text = mEntAlmacen.DIRECCION
        End If

    End Sub

    Private Sub cargarCargo(ByVal opc As Integer)
        'al haber un evento de cargar cargo
        Select Case opc
            Case Is = 1 ' Solicitada
                mEntEmpleado.IDEMPLEADO = Me.ddlEMPLEADOS1.SelectedValue
            Case Is = 2 ' Area tecnica
                mEntEmpleado.IDEMPLEADO = Me.ddlEMPLEADOS2.SelectedValue
            Case Is = 3 ' Autoriza
                mEntEmpleado.IDEMPLEADO = Me.ddlEMPLEADOS3.SelectedValue
            Case Is = 4 ' Certifica
                mEntEmpleado.IDEMPLEADO = Me.ddlEMPLEADOS4.SelectedValue

        End Select

        Me.mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)
        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        Me.mCompCargo.ObtenerCARGOS(mEntCargo)

        Select Case opc
            Case Is = 1 ' Solicitada
                TxtCargoEmpleadoSolicita.Text = mEntCargo.DESCRIPCION
            Case Is = 2 ' Area tecnica
                TxtCargoEmpleadoAreaTec.Text = mEntCargo.DESCRIPCION
            Case Is = 3 ' Autoriza
                TxtCargoEmpleadoAutoriza.Text = mEntCargo.DESCRIPCION
            Case Is = 4 ' Certifica
                Me.TxtCargoEmpleadoCertifica.Text = mEntCargo.DESCRIPCION

        End Select

    End Sub

    Private Sub HistoricoSolicitudes()
        'actualiza historico de solicitudes
        mEntHistoricoEstados.IDDETALLE = mCompHistoricoEstados.id_HISTORICOESTADOSSOLICITUDES(mEntHistoricoEstados)
        If IDSOLICITUD > 0 Then
            mEntHistoricoEstados.IDSOLICITUD = IDSOLICITUD
        Else
            mEntHistoricoEstados.IDSOLICITUD = mComponente.id_Solicitud(mEntidad)
        End If
        mEntHistoricoEstados.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntHistoricoEstados.IDESTADO = 2
        mEntHistoricoEstados.FECHA = Now()
        mEntHistoricoEstados.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntHistoricoEstados.AUFECHACREACION = Now()
        mEntHistoricoEstados.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntHistoricoEstados.AUFECHAMODIFICACION = Now()
        mEntHistoricoEstados.ESTASINCRONIZADA = 0

        mCompHistoricoEstados.AgregarHISTORICOESTADOSSOLICITUDES(mEntHistoricoEstados)
    End Sub

    Protected Sub DdlEMPLEADOS1_ErrorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEMPLEADOS1.ErrorEvent
        'evento error
        MsgBox1.ShowAlert("No hay empleados asignados para este establecimiento", "error5", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub DdlEMPLEADOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEMPLEADOS1.SelectedIndexChanged
        'al cambiar de empleado solicita
        cargarCargo(1) 'solicitada
    End Sub

    Protected Sub DdlEMPLEADOS2_ErrorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEMPLEADOS2.ErrorEvent
        'error al cargar empleado
        MsgBox1.ShowAlert("No hay empleados asignados para este establecimiento", "error6", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub DdlEMPLEADOS2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEMPLEADOS2.SelectedIndexChanged
        'al cambiar empleado tecnico
        cargarCargo(2) 'area tecnica
    End Sub

    Protected Sub DdlEMPLEADOS3_ErrorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEMPLEADOS3.ErrorEvent
        'error al cargar empleado
        MsgBox1.ShowAlert("No hay empleados asignados para este establecimiento", "error7", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub DdlEMPLEADOS3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEMPLEADOS3.SelectedIndexChanged
        'al cambiar de empleado autoriza
        cargarCargo(3) 'autoriza
    End Sub

    Protected Sub DdlEMPLEADOS4_ErrorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEMPLEADOS4.ErrorEvent
        'error al cargar empleado
        MsgBox1.ShowAlert("No hay empleados asignados para este establecimiento", "error8", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub DdlEMPLEADOS4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEMPLEADOS4.SelectedIndexChanged
        'al cambiar empleado certifica
        cargarCargo(4) 'certifica
    End Sub

    Protected Sub DdlALMACENES1_ErrorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlALMACENES1.ErrorEvent
        'error al cambiar empleado
        MsgBox1.ShowAlert("No hay almacenes asignados para este establecimiento", "error9", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub DdlALMACENES1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlALMACENES1.SelectedIndexChanged
        'al cambiar almacen de entrega
        mEntAlmacen.IDALMACEN = Me.ddlALMACENES1.SelectedValue
        mCompAlmacen.ObtenerALMACENES(mEntAlmacen)
        Me.TxtDireccion.Text = mEntAlmacen.DIRECCION
        Me.lblDireccionA.Text = mEntAlmacen.DIRECCION
    End Sub

    Protected Sub BttFormasEntrega_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttFormasEntrega.Click
        'al precionar boton de asignar entregas
        If Actualizar() <> "Error al Guardar registro." Then
            Session.Item("idDoc") = Me.txtIDSOLICITUD.Text
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/ESTABLECIMIENTOS/frmPlazoEntregaSolicitud.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 600 ,height= 600 '); </script>")
            Me.BttFormasEntrega.Enabled = False
            Me.BttFormasEntrega.Text = "Entregas definidas"
        Else
            'error
        End If
    End Sub

    Public Sub AsignarMontoSolicitud(ByVal Monto As Double)
        'asigna el monto calculado de la solicitud en su encabezado
        mEntidad = New SOLICITUDES

        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntidad.IDSOLICITUD = CInt(Me.txtIDSOLICITUD.Text)

        mComponente.ObtenerSOLICITUDES(mEntidad)
        mEntidad.MONTOSOLICITADO = Monto
        Me.txtMONTOSOLICITADO.Text = Monto

        Me.ddlTIPOCOMPRAS1.RecuperarXmonto(Monto)
        Me.ddlTIPOCOMPRAS2.RecuperarXmonto(Monto)
        Me.ddlTIPOCOMPRAS3.RecuperarXmonto(Monto)

        If mEntidad.COMPRACONJUNTA = 1 Then
            If Me.ddlESTADOS1.SelectedValue = 1 Then
                'ya esta grabado no cambia
            Else
                Try
                    mEntidad.IDTIPOCOMPRASOLICITADO = CInt(Me.ddlTIPOCOMPRAS1.SelectedValue)
                    mEntidad.IDTIPOCOMPRASUGERIDO = CInt(Me.ddlTIPOCOMPRAS2.SelectedValue)
                    mEntidad.IDTIPOCOMPRAEJECUTAR = CInt(Me.ddlTIPOCOMPRAS3.SelectedValue)
                Catch ex As Exception

                End Try
            End If
        Else
            mEntidad.IDTIPOCOMPRASUGERIDO = CInt(Me.ddlTIPOCOMPRAS2.SelectedValue)
        End If

        If mEntidad.AUUSUARIOCREACION = Nothing Then
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntidad.AUFECHACREACION = Nothing Then
            mEntidad.AUFECHACREACION = Now()
        End If

        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0
        mComponente.ActualizarSOLICITUDES(mEntidad)

        If Me.ddlESTADOS1.SelectedValue = 1 Then 'carga nuevamente si ya esta grabada la solicitud
            IDSOLICITUD = CInt(Me.txtIDSOLICITUD.Text)
            CargarDatos()
        End If

    End Sub

    Protected Sub DdlTIPOCOMPRAS1_ErrorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTIPOCOMPRAS1.ErrorEvent
        'error al seleccionar tipo de compras solicitado
        MsgBox1.ShowAlert("Tiene un valor de en tipo de compra solicitado no permitido para esta solicitud", "errorcompra1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub DdlTIPOCOMPRAS2_ErrorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTIPOCOMPRAS2.ErrorEvent
        'eroor al seleccionar un valor de tipo de compra no permitido para la solicitud
        MsgBox1.ShowAlert("Tiene un valor de en tipo de compra sugerido no permitido para esta solicitud", "errorcompra2", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub DdlTIPOCOMPRAS3_ErrorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTIPOCOMPRAS3.ErrorEvent
        'error al sellecionar un tipo de compra a ejecutar
        MsgBox1.ShowAlert("Tiene un valor de en tipo de compra a ejecutar no permitido para esta solicitud", "errorcompra3", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub deshabilitarDobleClickBotones()
        'deshabilitar doble click dl boton
        BttFormasEntrega.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(BttFormasEntrega, Nothing) + ";"
    End Sub

    Protected Sub BttImprimirPrograma_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttImprimirPrograma.Click
        If Me.TxtCompraConjunta.Text <> "1" Or Me.TxtCompraConjunta.Text = Nothing Then 'no conjunta
            Session.Item("RptDependencia") = Me.ddlDEPENDENCIAESTABLECIMIENTOS1.SelectedItem.Text
            Session.Item("RptEstablecimiento") = Session.Item("UsuarioEstablecimiento")
            Session.Item("RptCompra") = Me.ddlSUMINISTROS1.SelectedItem.Text
            Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptConsolidadoDistribucionSolicitud.aspx?id=" + Me.txtIDSOLICITUD.Text + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        Else 'conjunta
            Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptConsolidadoDistribucion0.aspx?id=" + Me.txtIDSOLICITUD.Text + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        End If
    End Sub

    Private Sub CargarDDLs()
        Me.ddlTIPOCOMPRAS1.Recuperar()
        Me.ddlTIPOCOMPRAS2.Recuperar()
        Me.ddlTIPOCOMPRAS3.Recuperar()
        Me.ddlALMACENES1.RecuperarAlmacenEstablecimiento(Session.Item("IdEstablecimiento"))
        Me.ddlSUMINISTROS1.Recuperar()
        Me.ddlDEPENDENCIAESTABLECIMIENTOS1.ObtenerDependenciaEstablecimiento(Session.Item("IdEstablecimiento"))

        Me.ddlESTADOS1.Recuperar()
        Me.ddlEMPLEADOS1.RecuperarNombreCompletoXEstablecimiento(CInt(Session.Item("IdEstablecimiento")))
        Me.ddlEMPLEADOS2.RecuperarNombreCompletoXEstablecimiento(CInt(Session.Item("IdEstablecimiento")))
        Me.ddlEMPLEADOS3.RecuperarNombreCompletoXEstablecimiento(CInt(Session.Item("IdEstablecimiento")))
        Me.ddlEMPLEADOS4.RecuperarNombreCompletoXEstablecimiento(CInt(Session.Item("IdEstablecimiento")))
    End Sub

End Class
