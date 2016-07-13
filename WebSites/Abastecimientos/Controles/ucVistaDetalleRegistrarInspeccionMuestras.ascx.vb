Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucVistaDetalleRegistrarInspeccionMuestras
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Integer
    Private _IDINFORME As Integer

    Private _IDESTABLECIMIENTOCONTRATO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _RENGLON As Integer
    Private _IDINSPECTOR As Integer
    Private _IDESTADO As Integer
    Private _IDTIPOINFORME As Integer
    Private _IDJEFELABORATORIO As Integer

    Private _Certificacion As Boolean
    Private _Correccion As Boolean

    Private _EmptyData As Boolean = False
    Private _VerTodos As Boolean = False

    Private _sError As String
    Private _nuevo As Boolean = False
    Private mComponente As New cINFORMEMUESTRAS
    Private mEntidad As INFORMEMUESTRAS

    Private cC As New cCONTRATOS
    Private ds As Data.DataSet

    Dim dtMotivosNoAceptacion As Data.DataTable

    Public Event ErrorEvent(ByVal errorMessage As String)

    Public Event Guardar(ByVal errorMessage As String)
    Public Event Cancelar()

#Region " Propiedades "

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Int32)
            Me._IDESTABLECIMIENTO = Value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", Value)
        End Set
    End Property

    Public Property IDINFORME() As Int32
        Get
            Return _IDINFORME
        End Get
        Set(ByVal Value As Int32)

            If Request.AppRelativeCurrentExecutionFilePath = "~/FrmDetaMantGenerarCertificadoControlCalidad.aspx" Then
                Certificacion = True
            Else
                Certificacion = False
            End If

            Me._IDINFORME = Value

            CargarDDLs()

            If Me._IDINFORME > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If

            ObtenerModificativas()

            If Not Me.ViewState("IDINFORME") Is Nothing Then Me.ViewState.Remove("IDINFORME")
            Me.ViewState.Add("IDINFORME", Value)
        End Set
    End Property

    Public Property IDESTABLECIMIENTOCONTRATO() As Integer
        Get
            Return _IDESTABLECIMIENTOCONTRATO
        End Get
        Set(ByVal Value As Integer)
            Me._IDESTABLECIMIENTOCONTRATO = Value
            If Not Me.ViewState("IDESTABLECIMIENTOCONTRATO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTOCONTRATO")
            Me.ViewState.Add("IDESTABLECIMIENTOCONTRATO", Value)
        End Set
    End Property

    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROVEEDOR = Value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", Value)
        End Set
    End Property

    Public Property IDCONTRATO() As Integer
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal Value As Integer)
            Me._IDCONTRATO = Value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", Value)
        End Set
    End Property

    Public Property RENGLON() As Integer
        Get
            Return _RENGLON
        End Get
        Set(ByVal Value As Integer)
            Me._RENGLON = Value
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.ViewState.Remove("RENGLON")
            Me.ViewState.Add("RENGLON", Value)
        End Set
    End Property

    Public Property IDINSPECTOR() As Integer
        Get
            Return _IDINSPECTOR
        End Get
        Set(ByVal Value As Integer)
            Me._IDINSPECTOR = Value
            If Not Me.ViewState("IDINSPECTOR") Is Nothing Then Me.ViewState.Remove("IDINSPECTOR")
            Me.ViewState.Add("IDINSPECTOR", Value)
        End Set
    End Property

    Public Property IDESTADO() As Integer
        Get
            Return _IDESTADO
        End Get
        Set(ByVal Value As Integer)
            Me._IDESTADO = Value
            If Not Me.ViewState("IDESTADO") Is Nothing Then Me.ViewState.Remove("IDESTADO")
            Me.ViewState.Add("IDESTADO", Value)
        End Set
    End Property

    Public Property IDJEFELABORATORIO() As Integer
        Get
            Return _IDJEFELABORATORIO
        End Get
        Set(ByVal Value As Integer)
            Me._IDJEFELABORATORIO = Value
            If Not Me.ViewState("IDJEFELABORATORIO") Is Nothing Then Me.ViewState.Remove("IDJEFELABORATORIO")
            Me.ViewState.Add("IDJEFELABORATORIO", Value)
        End Set
    End Property

    Public Property IDTIPOINFORME() As Integer
        Get
            Return _IDTIPOINFORME
        End Get
        Set(ByVal Value As Integer)
            Me._IDTIPOINFORME = Value
            If Not Me.ViewState("IDTIPOINFORME") Is Nothing Then Me.ViewState.Remove("IDTIPOINFORME")
            Me.ViewState.Add("IDTIPOINFORME", Value)
        End Set
    End Property

    Public Property Certificacion() As Boolean
        Get
            Return _Certificacion
        End Get
        Set(ByVal Value As Boolean)
            Me._Certificacion = Value
            If Not Me.ViewState("Certificacion") Is Nothing Then Me.ViewState.Remove("Certificacion")
            Me.ViewState.Add("Certificacion", Value)
        End Set
    End Property

    Public Property Correccion() As Boolean
        Get
            Return _Correccion
        End Get
        Set(ByVal Value As Boolean)
            Me._Correccion = Value
            If Not Me.ViewState("Correccion") Is Nothing Then Me.ViewState.Remove("Correccion")
            Me.ViewState.Add("Correccion", Value)
        End Set
    End Property

    Public Property EmptyData() As Boolean
        Get
            Return Me._EmptyData
        End Get
        Set(ByVal value As Boolean)
            Me._EmptyData = value
            If Not Me.ViewState("EmptyData") Is Nothing Then Me.ViewState.Remove("EmptyData")
            Me.ViewState.Add("EmptyData", value)
        End Set
    End Property

    Public Property VerTodos() As Boolean
        Get
            Return Me._VerTodos
        End Get
        Set(ByVal value As Boolean)
            Me._VerTodos = value
            If Not Me.ViewState("VerTodos") Is Nothing Then Me.ViewState.Remove("VerTodos")
            Me.ViewState.Add("VerTodos", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            cvFECHASOLICITUDINSPECCION1.ValueToCompare = Now.Date
            cvFECHAELABORACIONINFORME2.ValueToCompare = Now.Date
            cvFECHACERTIFICACION2.ValueToCompare = Now.Date
        Else
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDINFORME") Is Nothing Then Me._IDINFORME = Me.ViewState("IDINFORME")
            If Not Me.ViewState("IDESTABLECIMIENTOCONTRATO") Is Nothing Then Me._IDESTABLECIMIENTOCONTRATO = Me.ViewState("IDESTABLECIMIENTOCONTRATO")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me._IDCONTRATO = Me.ViewState("IDCONTRATO")
            If Not Me.ViewState("RENGLON") Is Nothing Then Me._RENGLON = Me.ViewState("RENGLON")
            If Not Me.ViewState("IDINSPECTOR") Is Nothing Then Me._IDINSPECTOR = Me.ViewState("IDINSPECTOR")
            If Not Me.ViewState("IDESTADO") Is Nothing Then Me._IDESTADO = Me.ViewState("IDESTADO")
            If Not Me.ViewState("IDJEFELABORATORIO") Is Nothing Then Me._IDJEFELABORATORIO = Me.ViewState("IDJEFELABORATORIO")
            If Not Me.ViewState("IDTIPOINFORME") Is Nothing Then Me._IDTIPOINFORME = Me.ViewState("IDTIPOINFORME")

            If Not Me.ViewState("Certificacion") Is Nothing Then Me._Certificacion = Me.ViewState("Certificacion")
            If Not Me.ViewState("Correccion") Is Nothing Then Me._Correccion = Me.ViewState("Correccion")

            If Not Me.ViewState("EmptyData") Is Nothing Then Me._EmptyData = Me.ViewState("EmptyData")
            If Not Me.ViewState("VerTodos") Is Nothing Then Me._VerTodos = Me.ViewState("VerTodos")

            If Not Me.ViewState("dtMotivosNoAceptacion") Is Nothing Then Me.dtMotivosNoAceptacion = Me.ViewState("dtMotivosNoAceptacion")
        End If

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)

        Me.txtRESOLUCION.Enabled = edicion
        Me.txtNUMERORECEPCION.Enabled = edicion
        Me.txtGUIAAEREA.Enabled = edicion

        Me.cpFECHASOLICITUDINSPECCION.Enabled = edicion
        Me.rfvFECHASOLICITUDINSPECCION.Visible = edicion
        'Me.cvFECHASOLICITUDINSPECCION.Visible = edicion
        Me.cvFECHASOLICITUDINSPECCION1.Visible = edicion

        Me.cpFECHARECOLECCIONMUESTRA.Enabled = False
        Me.rfvFECHARECOLECCIONMUESTRA.Visible = False
        'Me.cvFECHARECOLECCIONMUESTRA.Enabled = False

        Me.txtNUMEROINFORME.Enabled = edicion
        Me.txtNUMEROINFORME.Font.Bold = edicion
        'Me.rfvNUMEROINFORME.Visible = edicion
        Me.revNUMEROINFORME.Visible = edicion

        'Me.txtNOMBREMEDICAMENTO.Enabled = edicion
        'Me.rfvNOMBREMEDICAMENTO.Visible = edicion

        Me.TextBox1.Enabled = edicion
        'Me.TextBox1.Visible = edicion

        Me.txtLABORATORIOFABRICANTE.Enabled = edicion
        Me.rfvLABORATORIOFABRICANTE.Visible = edicion

        'Me.txtPROVEEDOR.Enabled = edicion
        'Me.rfvPROVEEDOR.Visible = edicion

        Me.txtLOTE.Enabled = edicion
        Me.rfvLOTE.Visible = edicion

        Me.DropDownList1.Enabled = edicion
        Me.DropDownList2.Enabled = edicion

        Me.DropDownList3.Enabled = edicion
        Me.DropDownList4.Enabled = edicion

        Me.RadioButtonList1.Enabled = edicion
        Me.DropDownList5.Enabled = edicion
        Me.nbNUMEROUNIDADES.Enabled = edicion
        Me.rfvNUMEROUNIDADES.Visible = edicion

        Me.nbCANTIDADREMITIDA.Enabled = edicion
        Me.rfvCANTIDADREMITIDA.Visible = edicion

        Me.cvNUMEROUNIDADES.Visible = edicion

        Me.cvCANTIDADREMITIDA.Visible = edicion
        Me.cvCANTIDADREMITIDA1.Visible = edicion

        Me.txtESTABLECIMIENTOREMITE.Enabled = edicion
        Me.rfvESTABLECIMIENTOREMITE.Visible = edicion

        Me.txtDESCRIPCIONEMPAQUE.Enabled = edicion
        Me.rfvDESCRIPCIONEMPAQUE.Visible = edicion

        Me.cbLEYENDAREQUERIDA.Enabled = edicion
        Me.cbNUMEROREGISTRO.Enabled = edicion
        Me.cbVIAADMINISTRACION.Enabled = edicion
        Me.cbFORMADISOLUCION.Enabled = edicion
        Me.cbCONDICIONESALMACENAMIENTO.Enabled = edicion
        Me.cbNUMEROLOTE.Enabled = edicion
        Me.cbFECHAEXPIRACION.Enabled = edicion
        Me.cbOTROSEMPAQUES.Enabled = edicion
        Me.txtDESCRIPCIONOTROSEMPAQUES.Enabled = edicion
        Me.txtDescripcionDilucion.Enabled = edicion

        Me.txtDESCRIPCIONPRODUCTO.Enabled = edicion
        Me.rfvDESCRIPCIONPRODUCTO.Visible = edicion

        Me.nbCANTIDADFISICOQUIMICO.Enabled = edicion
        Me.rfvCANTIDADFISICOQUIMICO.Visible = edicion

        Me.nbCANTIDADMICROBIOLOGIA.Enabled = edicion
        Me.rfvCANTIDADMICROBIOLOGIA.Visible = edicion

        Me.nbCANTIDADRETENCION.Enabled = edicion
        Me.rfvCANTIDADRETENCION.Visible = edicion

        Me.txtDESCRIPCIONCONDICIONESALMACENAMIENTO.Enabled = edicion

        Me.txtMOTIVOSNOINSPECCION.Enabled = edicion
        Me.rfvMOTIVOSNOINSPECCION.Visible = edicion

        Me.txtMotivoNoAceptacion.Enabled = edicion
        Me.rfvMotivosNoAceptacion.Enabled = edicion

        Me.txtREPRESENTANTEPROVEEDOR.Enabled = edicion
        Me.rfvREPRESENTANTEPROVEEDOR.Visible = edicion

        Me.txtOBSERVACION.Enabled = edicion

        Me.cpFECHAELABORACIONINFORME.Enabled = edicion
        Me.rfvFECHAELABORACIONINFORME.Visible = edicion
        'Me.cvFECHAELABORACIONINFORME1.Visible = edicion
        Me.cvFECHAELABORACIONINFORME2.Visible = edicion

        Me.ddlCOORDINADORCC.Enabled = edicion

        Me.txtCCF.Enabled = edicion
        Me.TextBox6.Enabled = edicion
        Me.TextBox5.Enabled = edicion
        Me.TextBox4.Enabled = edicion
        Me.TextBox3.Enabled = edicion
        Me.TextBox2.Enabled = edicion
        Me.TextBox7.Enabled = edicion
        Me.TextBox8.Enabled = edicion
        Me.TextBox9.Enabled = edicion
        Me.TextBox10.Enabled = edicion
        Me.TextBox11.Enabled = edicion
        Me.CheckBoxList1.Enabled = edicion
        Me.RequiredFieldValidator6.Enabled = edicion




    End Sub

    Private Sub HabilitarEdicionCertificacion(ByVal edicion As Boolean)
        Me.txtOBSERVACIONCERTIFICACION2.Enabled = edicion

        Me.cpFECHACERTIFICACION.Enabled = edicion
        Me.rfvFECHACERTIFICACION.Visible = edicion
        Me.cvFECHACERTIFICACION1.Visible = edicion
        Me.cvFECHACERTIFICACION2.Visible = edicion

        Me.ddlResultadoInspeccion.Enabled = edicion
    End Sub

    Private Sub CargarDatos()

        mEntidad = New INFORMEMUESTRAS

        mEntidad.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
        mEntidad.IDINFORME = Me.IDINFORME

        If mComponente.ObtenerInformeMuestrasContrato(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener registro.")
            Return
        End If

        Me.IDESTADO = mEntidad.IDESTADO
        Me.IDTIPOINFORME = mEntidad.IDTIPOINFORME
        Dim cad = "/Reportes/FrmRptInformeMuestras.aspx?idE=" + Me.IDESTABLECIMIENTO.ToString + "&idI=" + Me.IDINFORME.ToString + "&idTI=" + Me.IDTIPOINFORME.ToString + "&C=" + Certificacion.ToString.ToLower
        Me.btnImprimir.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
        '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptInformeMuestras.aspx?idE=" + Me.IDESTABLECIMIENTO.ToString + "&idI=" + Me.IDINFORME.ToString + "&idTI=" + Me.IDTIPOINFORME.ToString + "&C=" + Certificacion.ToString.ToLower + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"

        Me.btnImprimir.Visible = True

        TipoInforme(mEntidad.IDTIPOINFORME)

        Me.txtNUMEROINFORME.Enabled = False

        Dim IDEMPLEADO As Integer = Session.Item("IdEmpleado")
        If mEntidad.IDINSPECTOR = IDEMPLEADO Then
            Me.ddlCOORDINADORCC.Items.Remove(Me.ddlCOORDINADORCC.Items.FindByValue(IDEMPLEADO))
            Me.ddlCOORDINADORCC.Visible = True
            Me.txtCOORDINADORCC.Visible = False
            btnCerrar.Visible = False
            Me.txtNUMEROINFORME.Enabled = True
            'PermitirAgregarEliminarMotivos()
        Else
            Me.ddlCOORDINADORCC.Visible = False
            Me.txtCOORDINADORCC.Visible = True
            btnCerrar.Visible = True
            Me.txtNUMEROINFORME.Enabled = True
        End If

        If mEntidad.IDCOORDINADOR = IDEMPLEADO Then
            btnCerrar.Visible = True
        End If

        If Certificacion Then
            HabilitarEdicion(False)
            Me.plCertificacion.Visible = True
            Me.btnCorregir.Visible = True
            Me.btnCerrar.Visible = True
            Me.btnGuardar.Visible = False
            Me.btnCerrar.Text = "Generar Certificado"
        Else
            Me.btnCorregir.Visible = False
            Me.btnGuardar.Visible = True
            If mEntidad.IDJEFELABORATORIO = Nothing Then
                Correccion = False
                Me.plCertificacion.Visible = False
            Else
                Correccion = True
                Me.plCertificacion.Visible = True
                HabilitarEdicionCertificacion(False)
            End If

            Select Case mEntidad.IDESTADO
                Case 1

                Case 2
                    HabilitarEdicion(False)
            End Select
            Me.btnCorregir.Visible = False
        End If

        Me.txtPROVEEDOR1.Text = mEntidad.NOMBREPROVEEDOR
        Me.txtCONTRATO.Text = mEntidad.NUMEROCONTRATO
        Me.txtFECHADISTRIBUCIONCONTRATO.Text = String.Format("{0:dd/MM/yyyy}", mEntidad.FECHADISTRIBUCION)
        Me.cvFECHASOLICITUDINSPECCION.ValueToCompare = mEntidad.FECHADISTRIBUCION
        Me.txtESTABLECIMIENTO.Text = mEntidad.ESTABLECIMIENTOCONTRATO
        Me.txtRENGLON.Text = mEntidad.RENGLON
        Me.txtESPECIFICACIONES.Text = mEntidad.DESCRIPCIONPRODUCTO
        Me.txtCANTIDADCONTRATADA.Text = mEntidad.CANTIDADCONTRATADA
        Me.txtUM1.Text = mEntidad.UNIDADMEDIDA
        Me.txtUM2.Text = mEntidad.UNIDADMEDIDA
        Me.txtUM3.Text = mEntidad.UNIDADMEDIDA
        Me.txtUM4.Text = mEntidad.UNIDADMEDIDA
        Me.txtUM5.Text = mEntidad.UNIDADMEDIDA
        Me.txtUM6.Text = mEntidad.UNIDADMEDIDA

        Me.txtRESOLUCION.Text = mEntidad.NUMERORESOLUCION
        Me.lblMODALIDADCOMPRA.Text = mEntidad.MODALIDADCOMPRA
        Me.txtNUMEROMODALIDADCOMPRA.Text = mEntidad.NUMEROMODALIDADCOMPRA

        Me.txtNUMERORECEPCION.Text = mEntidad.NUMERORECEPCION
        Me.txtGUIAAEREA.Text = mEntidad.GUIAAEREA

        Me.ddlTIPOINFORMES1.SelectedValue = mEntidad.IDTIPOINFORME
        Me.txtTIPOINFORME1.Text = Me.ddlTIPOINFORMES1.SelectedItem.Text
        Me.lblTIPOINFORME1.Visible = True
        Me.txtTIPOINFORME1.Visible = True

        Me.cpFECHASOLICITUDINSPECCION.SelectedDate = mEntidad.FECHASOLICITUDINSPECCION
        Me.cpFECHARECOLECCIONMUESTRA.SelectedDate = mEntidad.FECHARECOLECCIONMUESTRA

        Me.txtNUMEROINFORME.Text = mEntidad.NUMEROINFORME

        Me.IDESTABLECIMIENTOCONTRATO = mEntidad.IDESTABLECIMIENTOCONTRATO
        Me.IDCONTRATO = mEntidad.IDCONTRATO
        Me.IDPROVEEDOR = mEntidad.IDPROVEEDOR
        Me.RENGLON = mEntidad.RENGLON

        Me.RadioButtonList1.SelectedValue = mEntidad.ORIGENPRODUCTO
        Me.DropDownList5.SelectedValue = mEntidad.TIPOPRODUCTO
        Me.txtNOMBREMEDICAMENTO.Text = mEntidad.NOMBREMEDICAMENTO
        Me.TextBox1.Text = mEntidad.NOMBRECOMERCIAL
        Me.txtLABORATORIOFABRICANTE.Text = mEntidad.LABORATORIOFABRICANTE
        Me.txtPROVEEDOR.Text = mEntidad.PROVEEDOR
        Me.txtLOTE.Text = mEntidad.LOTE

        Me.DropDownList1.SelectedValue = mEntidad.FECHAFABRICACION.Day & "/" & mEntidad.FECHAFABRICACION.Month
        Me.DropDownList2.SelectedValue = "/" & mEntidad.FECHAFABRICACION.Year

        'Me.cpFECHAFABRICACION.SelectedDate = mEntidad.FECHAFABRICACION

        Me.DropDownList3.SelectedValue = mEntidad.FECHAVENCIMIENTO.Day & "/" & mEntidad.FECHAVENCIMIENTO.Month
        Me.DropDownList4.SelectedValue = "/" & mEntidad.FECHAVENCIMIENTO.Year

        ' Me.cpFECHAVENCIMIENTO.SelectedDate = mEntidad.FECHAVENCIMIENTO
        Me.nbNUMEROUNIDADES.Text = mEntidad.NUMEROUNIDADES
        Me.nbCANTIDADREMITIDA.Text = mEntidad.CANTIDADREMITIDA
        Me.txtESTABLECIMIENTOREMITE.Text = mEntidad.ESTABLECIMIENTOREMITE

        Me.txtNUMERORECEPCION.Text = mEntidad.NUMERORECEPCION
        Me.txtGUIAAEREA.Text = mEntidad.GUIAAEREA

        Me.txtDESCRIPCIONEMPAQUE.Text = mEntidad.DESCRIPCIONEMPAQUE

        Me.cbLEYENDAREQUERIDA.Checked = IIf(mEntidad.LEYENDAREQUERIDA = 1, True, False)
        Me.cbNUMEROREGISTRO.Checked = IIf(mEntidad.NUMEROREGISTRO = 1, True, False)
        Me.cbVIAADMINISTRACION.Checked = IIf(mEntidad.VIAADMINISTRACION = 1, True, False)
        Me.cbFORMADISOLUCION.Checked = IIf(mEntidad.FORMADISOLUCION = 1, True, False)
        Me.cbCONDICIONESALMACENAMIENTO.Checked = IIf(mEntidad.CONDICIONESALMACENAMIENTO = 1, True, False)
        Me.cbNUMEROLOTE.Checked = IIf(mEntidad.NUMEROLOTE = 1, True, False)
        Me.cbFECHAEXPIRACION.Checked = IIf(mEntidad.FECHAEXPIRACION = 1, True, False)
        Me.cbOTROSEMPAQUES.Checked = IIf(mEntidad.OTROSEMPAQUES = 1, True, False)
        Me.txtDESCRIPCIONOTROSEMPAQUES.Text = mEntidad.DESCRIPCIONOTROSEMPAQUES
        Me.txtDescripcionDilucion.Text = mEntidad.DESCRIPCIONDISOLUCION

        Me.txtDESCRIPCIONPRODUCTO.Text = mEntidad.DESCRIPCIONPRODUCTO

        Me.nbCANTIDADFISICOQUIMICO.Text = mEntidad.CANTIDADFISICOQUIMICO
        Me.nbCANTIDADMICROBIOLOGIA.Text = mEntidad.CANTIDADMICROBIOLOGIA
        Me.nbCANTIDADRETENCION.Text = mEntidad.CANTIDADRETENCION

        Me.txtDESCRIPCIONCONDICIONESALMACENAMIENTO.Text = mEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO
        Me.txtOBSERVACION.Text = mEntidad.OBSERVACION

        Me.txtMotivoNoAceptacion.Text = mEntidad.MOTIVONOACEPTACION
        Me.txtMOTIVOSNOINSPECCION.Text = mEntidad.MOTIVOSNOINSPECCION

        Me.txtREPRESENTANTEPROVEEDOR.Text = mEntidad.REPRESENTANTEPROVEEDOR

        Me.IDINSPECTOR = mEntidad.IDINSPECTOR
        Me.txtINSPECTOR.Text = mEntidad.INSPECTOR
        Me.txtCODIGOINSPECTOR.Text = mEntidad.CODIGOINSPECTOR
        Me.ddlCOORDINADORCC.SelectedValue = mEntidad.IDCOORDINADOR
        Me.txtCOORDINADORCC.Text = mEntidad.COORDINADOR
        Me.txtCODIGOCOORDINADORCC.Text = mEntidad.CODIGOCOORDINADOR

        If Certificacion And mEntidad.IDJEFELABORATORIO = Nothing Then
            Me.txtJEFELABORATORIO.Text = Session("NombreUsuario")
            Me.txtCODIGOJEFELABORATORIO.Text = Session.Item("CodigoEmpleado")
        Else
            Me.txtJEFELABORATORIO.Text = mEntidad.JEFELABORATORIO
            Me.txtCODIGOJEFELABORATORIO.Text = mEntidad.CODIGOJEFELABORATORIO
        End If

        Me.cpFECHAELABORACIONINFORME.SelectedDate = mEntidad.FECHAELABORACIONINFORME

        Me.IDJEFELABORATORIO = mEntidad.IDJEFELABORATORIO

        Me.txtOBSERVACIONCERTIFICACION2.Text = mEntidad.OBSERVACIONCERTIFICACION
        Me.txtOBSERVACIONCERTIFICACION2.Text = Me.txtOBSERVACIONCERTIFICACION2.Text.Replace(Me.txtOBSERVACIONCERTIFICACION1.Text + " ", "")
        Me.cpFECHACERTIFICACION.SelectedDate = mEntidad.FECHACERTIFICACION

        Me.ddlResultadoInspeccion.SelectedValue = mEntidad.RESULTADOINSPECCION

        If Certificacion Then
            Me.ddlResultadoInspeccion.Visible = True
        Else
            Me.lblResultadoInspeccion.Visible = False
            Me.ddlResultadoInspeccion.Visible = False
        End If


        Me.txtCCF.Text = mEntidad.COMPROBANTECREDITOFISCAL
        Me.TextBox6.Text = mEntidad.DESCRIPCIONEMPAQUECOLECTIVO
        Me.TextBox5.Text = mEntidad.NUMEROEMPAQUECOLECTIVO
        Me.TextBox4.Text = mEntidad.DESCRIPCIONEMPAQUESECUNDARIO
        Me.TextBox3.Text = mEntidad.NUMEROEMPAQUESECUNDARIO
        Me.TextBox2.Text = mEntidad.NUMEROEMPAQUEPRIMARIO
        Me.TextBox7.Text = mEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS
        Me.TextBox8.Text = mEntidad.NUMEROUNIDADESAMUESTREAR
        Me.TextBox9.Text = mEntidad.NIVELCALIDADACEPTABLE
        Me.TextBox10.Text = mEntidad.RANGOACEPTACIONRECHAZO
        Me.TextBox11.Text = mEntidad.CALCULOS
        Me.RadioButtonList1.SelectedValue = mEntidad.NIVELINSPECCIONUTILIZABLE
        'If mEntidad.IDTIPOINFORME = eTIPOINFORME.RECHAZO Then
        '    Dim cMNAI As New cMOTIVOSNOACEPTACIONINFORME
        '    ds = cMNAI.ObtenerMOTIVOSNOACEPTACIONINFORME(mEntidad.IDESTABLECIMIENTO, mEntidad.IDINFORME)

        '    '   CrearTablaMotivosNoAceptacion(ds.Tables(0))
        'End If

    End Sub

    Private Sub Nuevo()
        Me._nuevo = True
        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

        Me.plSeleccionarRenglon.Visible = True

        OcultarPanelesDetalle()

        ObtenerProveedores()

        Me.txtINSPECTOR.Text = Session("NombreUsuario")
        Me.txtCODIGOINSPECTOR.Text = Session.Item("CodigoEmpleado")

        Dim IDEMPLEADO As Integer = Session.Item("IdEmpleado")
        Me.ddlCOORDINADORCC.Items.Remove(Me.ddlCOORDINADORCC.Items.FindByValue(IDEMPLEADO))

        Me.IDESTADO = 1

        Me.btnImprimir.Visible = False

    End Sub

    Public Function Actualizar() As String

        If Me.IDTIPOINFORME = eTIPOINFORME.ACEPTACION Or Me.IDTIPOINFORME = eTIPOINFORME.RECHAZO Then
            If cbOTROSEMPAQUES.Checked Then
                If Trim(txtDESCRIPCIONOTROSEMPAQUES.Text) = "" Then
                    Return "Debe ingresar la descripción de los otros empaques."
                End If
            End If

            If (CDec(nbCANTIDADFISICOQUIMICO.Text) + CDec(nbCANTIDADMICROBIOLOGIA.Text) + CDec(nbCANTIDADRETENCION.Text)) > CDec(nbCANTIDADREMITIDA.Text) Then
                Return "La suma de las cantidades distribuidas no puede superar el total remitido."
            End If
            If Not Me.cbFORMADISOLUCION.Checked Then
                If Trim(Me.txtDescripcionDilucion.Text) = "" Then
                    Return "Debe ingresar una observacion a la forma de disolución."
                End If
            End If
        End If

        'If Me.IDTIPOINFORME = eTIPOINFORME.RECHAZO Then
        '    Dim emptyRow As Data.DataRow = dtMotivosNoAceptacion.Rows.Find(0)
        '    If Not IsNothing(emptyRow) And dtMotivosNoAceptacion.Rows.Count = 1 Then
        '        Return "Debe ingresar al menos un motivo de rechazo."
        '    End If
        'End If

        mEntidad = New INFORMEMUESTRAS
        ' Dim lista As New listaMOTIVOSNOACEPTACIONINFORME

        mEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        If Me._nuevo Then
            mEntidad.IDINFORME = 0
            mEntidad.IDINSPECTOR = Session("IdEmpleado")
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now
        Else
            mEntidad.IDINFORME = IDINFORME
            mEntidad.IDINSPECTOR = IDINSPECTOR
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now
        End If

        If Me.IDTIPOINFORME = eTIPOINFORME.ACEPTACION Or Me.IDTIPOINFORME = eTIPOINFORME.RECHAZO Or eTIPOINFORME.NOINSPECCION Then
            If mComponente.VerificarNumeroInforme(Me.txtNUMEROINFORME.Text, mEntidad.IDESTABLECIMIENTO, mEntidad.IDINFORME) > 0 Then
                Return "El número de informe ya existe.  Por favor verifíquelo."
            End If
        End If

        mEntidad.FECHASOLICITUDINSPECCION = Me.cpFECHASOLICITUDINSPECCION.SelectedDate
        'mEntidad.FECHARECOLECCIONMUESTRA = Me.cpFECHARECOLECCIONMUESTRA.SelectedDate
        mEntidad.FECHARECOLECCIONMUESTRA = Me.cpFECHAELABORACIONINFORME.SelectedDate

        mEntidad.IDESTADO = Me.IDESTADO

        mEntidad.IDTIPOINFORME = Me.ddlTIPOINFORMES1.SelectedValue

        mEntidad.IDESTABLECIMIENTOCONTRATO = Me.IDESTABLECIMIENTOCONTRATO
        mEntidad.IDPROVEEDOR = Me.IDPROVEEDOR
        mEntidad.IDCONTRATO = Me.IDCONTRATO
        mEntidad.RENGLON = Me.RENGLON

        mEntidad.NUMEROINFORME = Me.txtNUMEROINFORME.Text

        mEntidad.ORIGENPRODUCTO = Me.RadioButtonList1.SelectedValue
        mEntidad.TIPOPRODUCTO = Me.DropDownList5.SelectedValue

        mEntidad.NOMBREMEDICAMENTO = Me.txtNOMBREMEDICAMENTO.Text
        mEntidad.NOMBRECOMERCIAL = Me.TextBox1.Text
        mEntidad.LABORATORIOFABRICANTE = Me.txtLABORATORIOFABRICANTE.Text
        mEntidad.PROVEEDOR = Me.txtPROVEEDOR.Text
        mEntidad.LOTE = Me.txtLOTE.Text

        mEntidad.FECHAFABRICACION = Me.DropDownList1.SelectedValue & Me.DropDownList2.SelectedValue
        mEntidad.FECHAVENCIMIENTO = Me.DropDownList3.SelectedValue & Me.DropDownList4.SelectedValue

        mEntidad.NUMEROUNIDADES = Me.nbNUMEROUNIDADES.Text
        mEntidad.CANTIDADREMITIDA = Me.nbCANTIDADREMITIDA.Text
        mEntidad.ESTABLECIMIENTOREMITE = Me.txtESTABLECIMIENTOREMITE.Text

        Select Case mEntidad.IDTIPOINFORME

            Case eTIPOINFORME.ACEPTACION

                mEntidad.NUMERORECEPCION = Me.txtNUMERORECEPCION.Text
                mEntidad.GUIAAEREA = Me.txtGUIAAEREA.Text

                mEntidad.DESCRIPCIONEMPAQUE = Me.txtDESCRIPCIONEMPAQUE.Text

                mEntidad.LEYENDAREQUERIDA = IIf(Me.cbLEYENDAREQUERIDA.Checked, 1, 0)
                mEntidad.NUMEROREGISTRO = IIf(Me.cbNUMEROREGISTRO.Checked, 1, 0)
                mEntidad.VIAADMINISTRACION = IIf(Me.cbVIAADMINISTRACION.Checked, 1, 0)
                mEntidad.FORMADISOLUCION = IIf(Me.cbFORMADISOLUCION.Checked, 1, 0)
                mEntidad.CONDICIONESALMACENAMIENTO = IIf(Me.cbCONDICIONESALMACENAMIENTO.Checked, 1, 0)
                mEntidad.NUMEROLOTE = IIf(Me.cbNUMEROLOTE.Checked, 1, 0)
                mEntidad.FECHAEXPIRACION = IIf(Me.cbFECHAEXPIRACION.Checked, 1, 0)
                mEntidad.OTROSEMPAQUES = IIf(Me.cbOTROSEMPAQUES.Checked, 1, 0)
                mEntidad.DESCRIPCIONOTROSEMPAQUES = Me.txtDESCRIPCIONOTROSEMPAQUES.Text
                mEntidad.descripciondisolucion = Me.txtDescripcionDilucion.Text
                mEntidad.DESCRIPCIONPRODUCTO = Me.txtDESCRIPCIONPRODUCTO.Text
                mEntidad.CANTIDADFISICOQUIMICO = Me.nbCANTIDADFISICOQUIMICO.Text
                mEntidad.CANTIDADMICROBIOLOGIA = Me.nbCANTIDADMICROBIOLOGIA.Text
                mEntidad.CANTIDADRETENCION = Me.nbCANTIDADRETENCION.Text

                mEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO = Me.txtDESCRIPCIONCONDICIONESALMACENAMIENTO.Text

                mEntidad.COMPROBANTECREDITOFISCAL = Me.txtCCF.Text
                mEntidad.DESCRIPCIONEMPAQUECOLECTIVO = Me.TextBox6.Text
                mEntidad.NUMEROEMPAQUECOLECTIVO = Me.TextBox5.Text
                mEntidad.DESCRIPCIONEMPAQUESECUNDARIO = Me.TextBox4.Text
                mEntidad.NUMEROEMPAQUESECUNDARIO = Me.TextBox3.Text
                mEntidad.NUMEROEMPAQUEPRIMARIO = Me.TextBox2.Text
                mEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS = Me.TextBox7.Text
                mEntidad.NIVELINSPECCIONUTILIZABLE = Me.CheckBoxList1.SelectedValue
                mEntidad.NUMEROUNIDADESAMUESTREAR = Me.TextBox8.Text
                mEntidad.NIVELCALIDADACEPTABLE = Me.TextBox9.Text
                mEntidad.RANGOACEPTACIONRECHAZO = Me.TextBox10.Text
                mEntidad.CALCULOS = Me.TextBox11.Text

            Case eTIPOINFORME.RECHAZO

                mEntidad.NUMERORECEPCION = Me.txtNUMERORECEPCION.Text
                mEntidad.GUIAAEREA = Me.txtGUIAAEREA.Text

                mEntidad.DESCRIPCIONEMPAQUE = Me.txtDESCRIPCIONEMPAQUE.Text

                mEntidad.LEYENDAREQUERIDA = IIf(Me.cbLEYENDAREQUERIDA.Checked, 1, 0)
                mEntidad.NUMEROREGISTRO = IIf(Me.cbNUMEROREGISTRO.Checked, 1, 0)
                mEntidad.VIAADMINISTRACION = IIf(Me.cbVIAADMINISTRACION.Checked, 1, 0)
                mEntidad.FORMADISOLUCION = IIf(Me.cbFORMADISOLUCION.Checked, 1, 0)
                mEntidad.CONDICIONESALMACENAMIENTO = IIf(Me.cbCONDICIONESALMACENAMIENTO.Checked, 1, 0)
                mEntidad.NUMEROLOTE = IIf(Me.cbNUMEROLOTE.Checked, 1, 0)
                mEntidad.FECHAEXPIRACION = IIf(Me.cbFECHAEXPIRACION.Checked, 1, 0)
                mEntidad.OTROSEMPAQUES = IIf(Me.cbOTROSEMPAQUES.Checked, 1, 0)
                mEntidad.DESCRIPCIONOTROSEMPAQUES = Me.txtDESCRIPCIONOTROSEMPAQUES.Text
                mEntidad.DESCRIPCIONDISOLUCION = Me.txtDescripcionDilucion.Text
                mEntidad.DESCRIPCIONPRODUCTO = Me.txtDESCRIPCIONPRODUCTO.Text
                mEntidad.CANTIDADFISICOQUIMICO = Me.nbCANTIDADFISICOQUIMICO.Text
                mEntidad.CANTIDADMICROBIOLOGIA = Me.nbCANTIDADMICROBIOLOGIA.Text
                mEntidad.CANTIDADRETENCION = Me.nbCANTIDADRETENCION.Text

                mEntidad.COMPROBANTECREDITOFISCAL = Me.txtCCF.Text
                mEntidad.DESCRIPCIONEMPAQUECOLECTIVO = Me.TextBox6.Text
                mEntidad.NUMEROEMPAQUECOLECTIVO = Me.TextBox5.Text
                mEntidad.DESCRIPCIONEMPAQUESECUNDARIO = Me.TextBox4.Text
                mEntidad.NUMEROEMPAQUESECUNDARIO = Me.TextBox3.Text
                mEntidad.NUMEROEMPAQUEPRIMARIO = Me.TextBox2.Text
                mEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS = Me.TextBox7.Text
                mEntidad.NIVELINSPECCIONUTILIZABLE = Me.CheckBoxList1.SelectedValue
                mEntidad.NUMEROUNIDADESAMUESTREAR = Me.TextBox8.Text
                mEntidad.NIVELCALIDADACEPTABLE = Me.TextBox9.Text
                mEntidad.RANGOACEPTACIONRECHAZO = Me.TextBox10.Text
                mEntidad.CALCULOS = Me.TextBox11.Text

                mEntidad.DESCRIPCIONCONDICIONESALMACENAMIENTO = Me.txtDESCRIPCIONCONDICIONESALMACENAMIENTO.Text

                mEntidad.MOTIVONOACEPTACION = Me.txtMotivoNoAceptacion.Text
                'For Each row As Data.DataRow In dtMotivosNoAceptacion.Rows
                '    Dim eMNAI As New MOTIVOSNOACEPTACIONINFORME
                '    eMNAI.IDMOTIVONOACEPTACION = row("IDMOTIVONOACEPTACION")
                '    If Not IsDBNull(eMNAI.IDMOTIVONOACEPTACION) Then
                '        eMNAI.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                '        eMNAI.AUFECHACREACION = Now
                '        lista.Add(eMNAI)
                '    End If
                'Next

                mEntidad.REPRESENTANTEPROVEEDOR = "" 'Me.txtREPRESENTANTEPROVEEDOR.Text
                mEntidad.COMPROBANTECREDITOFISCAL = Me.txtCCF.Text
                mEntidad.DESCRIPCIONEMPAQUECOLECTIVO = Me.TextBox6.Text
                mEntidad.NUMEROEMPAQUECOLECTIVO = Me.TextBox5.Text
                mEntidad.DESCRIPCIONEMPAQUESECUNDARIO = Me.TextBox4.Text
                mEntidad.NUMEROEMPAQUESECUNDARIO = Me.TextBox3.Text
                mEntidad.NUMEROEMPAQUEPRIMARIO = Me.TextBox2.Text
                mEntidad.CONDICIONESALMACENAMIENTORECOMENDADAS = Me.TextBox7.Text
                mEntidad.NIVELINSPECCIONUTILIZABLE = Me.CheckBoxList1.SelectedValue
                mEntidad.NUMEROUNIDADESAMUESTREAR = Me.TextBox8.Text
                mEntidad.NIVELCALIDADACEPTABLE = Me.TextBox9.Text
                mEntidad.RANGOACEPTACIONRECHAZO = Me.TextBox10.Text
                mEntidad.CALCULOS = Me.TextBox11.Text

            Case eTIPOINFORME.NOINSPECCION

                ' mEntidad.NUMEROINFORME = Nothing

                mEntidad.MOTIVOSNOINSPECCION = Me.txtMOTIVOSNOINSPECCION.Text
                mEntidad.REPRESENTANTEPROVEEDOR = "" 'Me.txtREPRESENTANTEPROVEEDOR.Text

        End Select

        mEntidad.OBSERVACION = Me.txtOBSERVACION.Text
        mEntidad.IDCOORDINADOR = Me.ddlCOORDINADORCC.SelectedValue
        mEntidad.FECHAELABORACIONINFORME = Me.cpFECHAELABORACIONINFORME.SelectedDate

        If Certificacion Then
            mEntidad.IDJEFELABORATORIO = Session("IdEmpleado")
        Else
            If Correccion Then
                mEntidad.IDJEFELABORATORIO = Me.IDJEFELABORATORIO
            Else
                mEntidad.IDJEFELABORATORIO = Nothing
            End If
        End If

        mEntidad.OBSERVACIONCERTIFICACION = Me.txtOBSERVACIONCERTIFICACION1.Text + " " + Me.txtOBSERVACIONCERTIFICACION2.Text
        mEntidad.FECHACERTIFICACION = Me.cpFECHACERTIFICACION.SelectedDate

        If Me.IDESTADO = 3 Then
            mEntidad.RESULTADOINSPECCION = Me.ddlResultadoInspeccion.SelectedValue
        Else
            mEntidad.RESULTADOINSPECCION = Nothing
        End If

        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarINFORMEMUESTRAS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Protected Sub gvProveedores_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProveedores.PageIndexChanging

        gvProveedores.PageIndex = e.NewPageIndex

        CambiarProveedor()
        ObtenerProveedores()
    End Sub

    Protected Sub gvProveedores_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvProveedores.SelectedIndexChanging
        CambiarProveedor()

        Me.IDPROVEEDOR = Me.gvProveedores.DataKeys(e.NewSelectedIndex).Values(0)
        ObtenerContratos(Me.IDPROVEEDOR)
    End Sub

    Protected Sub gvContratos_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvContratos.SelectedIndexChanging

        OcultarPanelesDetalle()
        MostrarSeleccionarTipoInforme(False)

        gvRenglones.SelectedIndex = -1
        gvRenglones.DataSource = Nothing
        gvRenglones.DataBind()
        gvRenglones.Visible = False

        Me.IDESTABLECIMIENTOCONTRATO = Me.gvContratos.DataKeys(e.NewSelectedIndex).Values(0)
        Me.IDPROVEEDOR = Me.gvContratos.DataKeys(e.NewSelectedIndex).Values(1)
        Me.IDCONTRATO = Me.gvContratos.DataKeys(e.NewSelectedIndex).Values(2)

        ObtenerRenglones(IDESTABLECIMIENTOCONTRATO, IDPROVEEDOR, IDCONTRATO)
        Me.UcFiltrarDatos2.Visible = True
    End Sub

    Protected Sub gvRenglones_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRenglones.PageIndexChanging
        Me.gvRenglones.PageIndex = e.NewPageIndex
        Me.IDESTABLECIMIENTO = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values(0)
        Me.IDPROVEEDOR = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values(1)
        Me.IDCONTRATO = Me.gvContratos.DataKeys(Me.gvContratos.SelectedIndex).Values(2)
        ObtenerRenglones(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
    End Sub

    Protected Sub gvRenglones_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvRenglones.SelectedIndexChanging

        Me.RENGLON = Me.gvRenglones.DataKeys(e.NewSelectedIndex).Values(3)

        OcultarPanelesDetalle()
        MostrarSeleccionarTipoInforme(True)
    End Sub

    Private Sub ObtenerProveedores()

        gvProveedores.SelectedIndex = -1

        ds = cC.ObtenerProveedoresEntregasPendiente(IIf(VerTodos, 1, 0))

        Dim dsVista As New System.Data.DataView(ds.Tables(0))

        If UcFiltrarDatos1.CampoFiltro <> "" And UcFiltrarDatos1.ValorFiltro <> "" Then
            Select Case dsVista.Table.Columns(UcFiltrarDatos1.CampoFiltro).DataType.Name
                Case "String"
                    dsVista.RowFilter = UcFiltrarDatos1.CampoFiltro & " LIKE '%" & UcFiltrarDatos1.ValorFiltro & "%'"
            End Select
        End If

        gvProveedores.DataSource = dsVista

        Try
            gvProveedores.DataBind()
        Catch ex As Exception
            gvProveedores.PageIndex = 0
            gvProveedores.DataBind()
        End Try

        If Not Page.IsPostBack Then
            UcFiltrarDatos1.AddColumnasExcluidas(gvProveedores.Columns(0).HeaderText)
            UcFiltrarDatos1.ValorColumnas = gvProveedores.Columns
        End If

        Select Case gvProveedores.Rows.Count
            Case Is = 0

            Case Else
                gvProveedores.Enabled = True
                gvProveedores.Visible = True
        End Select

    End Sub

    Protected Sub UcFiltrarDatos1_Buscar() Handles UcFiltrarDatos1.Buscar
        ObtenerProveedores()
    End Sub

    Private Sub ObtenerContratos(ByVal IDPROVEEDOR As Integer)

        ds = cC.ObtenerDocumentosPendientesPorProveedor(IDPROVEEDOR, IIf(VerTodos, 1, 0))

        gvContratos.DataSource = ds

        Try
            gvContratos.DataBind()
        Catch ex As Exception
            gvContratos.PageIndex = 0
            gvContratos.DataBind()
        End Try

        Select Case gvContratos.Rows.Count
            Case Is = 0
                gvContratos.Visible = True
                gvRenglones.Visible = False

            Case Else
                gvContratos.Enabled = True
                gvContratos.Visible = True
                gvRenglones.Visible = False
        End Select

    End Sub

    Private Sub ObtenerRenglones(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer)

        Me.gvRenglones.SelectedIndex = -1

        ds = cC.ObtenerRenglonesPendientesTotales(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IIf(VerTodos, 1, 0))

        Dim dsVista As New System.Data.DataView(ds.Tables(0))

        If UcFiltrarDatos2.CampoFiltro <> "" And UcFiltrarDatos2.ValorFiltro <> "" Then
            Select Case dsVista.Table.Columns(UcFiltrarDatos2.CampoFiltro).DataType.Name
                Case "Int64"
                    dsVista.RowFilter = UcFiltrarDatos2.CampoFiltro & " =" & UcFiltrarDatos2.ValorFiltro & ""
            End Select
        End If

        gvRenglones.DataSource = dsVista

        Try
            gvRenglones.DataBind()
        Catch ex As Exception
            gvRenglones.PageIndex = 0
            gvRenglones.DataBind()
        End Try
        If Page.IsPostBack Then
            UcFiltrarDatos2.AddColumnasExcluidas(gvRenglones.Columns(0).HeaderText)
            UcFiltrarDatos2.AddColumnasExcluidas(gvRenglones.Columns(2).HeaderText)
            UcFiltrarDatos2.AddColumnasExcluidas(gvRenglones.Columns(3).HeaderText)
            UcFiltrarDatos2.AddColumnasExcluidas(gvRenglones.Columns(4).HeaderText)
            UcFiltrarDatos2.AddColumnasExcluidas(gvRenglones.Columns(5).HeaderText)
            UcFiltrarDatos2.ValorColumnas = gvRenglones.Columns
        End If
        Select Case gvRenglones.Rows.Count
            Case Is = 0
                gvRenglones.Visible = True
                MostrarSeleccionarTipoInforme(False)

            Case Else
                gvRenglones.Enabled = True
                gvRenglones.Visible = True

                MostrarSeleccionarTipoInforme(False)
        End Select

    End Sub
    Protected Sub UcFiltrarDatos2_Buscar() Handles UcFiltrarDatos2.Buscar
        ObtenerRenglones(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
    End Sub
    Private Sub OcultarPanelesDetalle()
        Me.plDatosContrato.Visible = False
        Me.plDatosAdicionalesContrato.Visible = False
        Me.plSolicitudRecoleccion.Visible = False
        Me.plTituloInforme.Visible = False
        Me.plInforme.Visible = False
        Me.plNumeroInforme.Visible = False
        Me.plAceptacion.Visible = False
        Me.plRechazo.Visible = False
        Me.plNoInspeccion.Visible = False
        Me.plRepresentanteProveedor.Visible = False
        Me.plDatosFinales.Visible = False
        Me.plCertificacion.Visible = False
        Me.plBotones.Visible = False
    End Sub

    Private Sub MostrarSeleccionarTipoInforme(ByVal Value As Boolean)
        Me.lblTIPOINFORME.Visible = Value
        Me.ddlTIPOINFORMES1.Visible = Value
        Me.btnAceptar.Visible = Value
    End Sub

    Private Sub TipoInforme(ByVal TIPOINFORME As Integer)

        Me.plSeleccionarRenglon.Visible = False

        Select Case TIPOINFORME

            Case eTIPOINFORME.ACEPTACION
                Me.plDatosContrato.Visible = True
                Me.plDatosAdicionalesContrato.Visible = True
                Me.plSolicitudRecoleccion.Visible = True
                Me.plTituloInforme.Visible = True
                Me.plInforme.Visible = True
                Me.plNumeroInforme.Visible = True
                Me.plAceptacion.Visible = True
                Me.plRechazo.Visible = False
                Me.plNoInspeccion.Visible = False
                Me.plRepresentanteProveedor.Visible = False
                Me.plDatosFinales.Visible = True
                Me.plCertificacion.Visible = False
                Me.plBotones.Visible = True
                If Me.ViewState("nuevo") Then
                    HabilitarEdicion(True)
                End If

            Case eTIPOINFORME.RECHAZO
                Me.plDatosContrato.Visible = True
                Me.plDatosAdicionalesContrato.Visible = True
                Me.plSolicitudRecoleccion.Visible = True
                Me.plTituloInforme.Visible = True
                Me.plInforme.Visible = True
                Me.plNumeroInforme.Visible = True
                Me.plAceptacion.Visible = True
                Me.plRechazo.Visible = True
                Me.plNoInspeccion.Visible = False
                Me.plRepresentanteProveedor.Visible = True
                Me.plDatosFinales.Visible = True
                Me.plCertificacion.Visible = False
                Me.plBotones.Visible = True

            Case eTIPOINFORME.NOINSPECCION
                Me.plDatosContrato.Visible = True
                Me.plDatosAdicionalesContrato.Visible = False
                Me.plSolicitudRecoleccion.Visible = True
                Me.plTituloInforme.Visible = True
                Me.plInforme.Visible = True
                Me.plNumeroInforme.Visible = True
                Me.plAceptacion.Visible = False
                Me.plRechazo.Visible = False
                Me.plNoInspeccion.Visible = True
                Me.plRepresentanteProveedor.Visible = True
                Me.plDatosFinales.Visible = True
                Me.plCertificacion.Visible = False
                Me.plBotones.Visible = True

            Case Else
                'error
        End Select

    End Sub

    Private Sub CambiarProveedor()
        OcultarPanelesDetalle()
        MostrarSeleccionarTipoInforme(False)

        gvContratos.SelectedIndex = -1
        gvContratos.DataSource = Nothing
        gvContratos.DataBind()
        gvContratos.Visible = False

        gvRenglones.SelectedIndex = -1
        gvRenglones.DataSource = Nothing
        gvRenglones.DataBind()
        gvRenglones.Visible = False
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Me.txtPROVEEDOR1.Text = Server.HtmlDecode(Me.gvProveedores.SelectedRow.Cells(1).Text)
        Me.txtPROVEEDOR.Text = Me.txtPROVEEDOR1.Text

        Me.txtCONTRATO.Text = Me.gvContratos.SelectedRow.Cells(2).Text
        Me.txtESTABLECIMIENTO.Text = Server.HtmlDecode(Me.gvContratos.SelectedRow.Cells(3).Text)

        Me.lblMODALIDADCOMPRA.Text = String.Concat(Me.gvContratos.DataKeys(gvContratos.SelectedIndex).Values(3), ":")
        Me.txtNUMEROMODALIDADCOMPRA.Text = Me.gvContratos.DataKeys(gvContratos.SelectedIndex).Values(4)
        Me.txtFECHADISTRIBUCIONCONTRATO.Text = Me.gvContratos.DataKeys(gvContratos.SelectedIndex).Values(5)
        Me.cvFECHASOLICITUDINSPECCION.ValueToCompare = Me.gvContratos.DataKeys(gvContratos.SelectedIndex).Values(5)
        Me.txtRESOLUCION.Text = Me.gvContratos.DataKeys(gvContratos.SelectedIndex).Values(6)

        Me.txtRENGLON.Text = Me.gvRenglones.SelectedRow.Cells(1).Text
        Me.txtNOMBREMEDICAMENTO.Text = Server.HtmlDecode(Me.gvRenglones.SelectedRow.Cells(2).Text)

        Me.TextBox1.Text = Server.HtmlDecode(Me.gvRenglones.SelectedRow.Cells(3).Text)
        Me.txtESPECIFICACIONES.Text = Server.HtmlDecode(Me.gvRenglones.SelectedRow.Cells(3).Text)
        Me.txtCANTIDADCONTRATADA.Text = Me.gvRenglones.SelectedRow.Cells(4).Text
        Me.txtUM1.Text = Me.gvRenglones.SelectedRow.Cells(5).Text
        Me.txtUM2.Text = Me.txtUM1.Text
        Me.txtUM3.Text = Me.txtUM1.Text
        Me.txtUM4.Text = Me.txtUM1.Text
        Me.txtUM5.Text = Me.txtUM1.Text
        Me.txtUM6.Text = Me.txtUM1.Text

        Me.IDTIPOINFORME = Me.ddlTIPOINFORMES1.SelectedValue
        Me.txtTIPOINFORME1.Text = Me.ddlTIPOINFORMES1.SelectedItem.Text
        Me.lblTIPOINFORME1.Visible = True
        Me.txtTIPOINFORME1.Visible = True

        TipoInforme(ddlTIPOINFORMES1.SelectedValue)

        Me.btnCerrar.Visible = False
        Me.btnCorregir.Visible = False

    End Sub

    Private Sub CargarDDLs()
        Me.ddlTIPOINFORMES1.Recuperar()
        Me.ddlCOORDINADORCC.RecuperarEmpleadosPorDependenciaCoordinador(Session("IdEstablecimiento"), Session("IdDependencia"))
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        RaiseEvent Cancelar()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        MsgBox1.ShowConfirm("Una vez enviado el informe, ya no podrá ser modificado.  ¿Confirma que desea enviarlo?", "Cerrar", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
    End Sub

    Protected Sub btnCorregir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCorregir.Click
        Correccion = True
        MsgBox1.ShowConfirm("¿Confirma que solicita la corrección del informe?", "Corregir", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If Page.IsValid Then
            Dim sError As String
            sError = Actualizar() 'Grabado

            RaiseEvent Guardar(sError)
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

        Dim sError As String

        Select Case e.Key
            Case "Cerrar"
                If Certificacion Then
                    Me.IDESTADO = 3
                Else
                    Me.IDESTADO = 2
                End If

            Case "Corregir"
                Me.IDESTADO = 1
        End Select

        sError = Actualizar()

        RaiseEvent Guardar(sError)

    End Sub

    Private Sub ObtenerModificativas()
        'Carga de modificativas para el contrato seleccionado
        Dim cMC As New cMODIFICATIVASCONTRATO
        Dim ds As Data.DataSet
        ds = cMC.ObtenerDataSetPorId(Me.IDESTABLECIMIENTOCONTRATO, Me.IDPROVEEDOR, Me.IDCONTRATO)
        gvModificativas.DataSource = ds
        gvModificativas.DataBind()

        If ds.Tables(0).Rows.Count = 0 Then
            Me.lblModificativas.Visible = True
        End If
    End Sub

    Protected Sub lbVerTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbVerTodos.Click

        VerTodos = Not VerTodos

        If VerTodos Then
            Me.lbVerTodos.Text = "<< Ver sólo entregas pendientes"
        Else
            Me.lbVerTodos.Text = "Ver todos"
        End If

        CambiarProveedor()
        ObtenerProveedores()

    End Sub

 
    Protected Sub cbFORMADISOLUCION_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Me.cbFORMADISOLUCION.Checked Then
            Me.txtDescripcionDilucion.Visible = True
        Else
            Me.txtDescripcionDilucion.Visible = False
        End If
    End Sub

    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

    End Sub
End Class
