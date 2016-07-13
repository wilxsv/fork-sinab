'Notificar incumplimientos de documentacion
'CU-UACI011
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario con la informacion de la nota para cada ofertante que indica la documentadion que no presento
'o que estaba incorrecta y el plazo dispuesto para subsanar

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Imports SINAB_Utils.MessageBox


Partial Class FrmNotaIncumplimiento
    Inherits System.Web.UI.Page

    'Declaracion e inicializacion de variables
    Private _IDESTABLECIMIENTO As Int32
    Private _IDPROCESOCOMPRA As Int32
    Private _IDPROVEEDOR As Int32
    Private _IDOFERTA As Integer
    Private mComponente As New cNOTASINCUMPLIMIENTO
    Private mEntidad As New NOTASINCUMPLIMIENTO
    Private mEntEmpleado As New EMPLEADOS
    Private mcompEmpleado As New cEMPLEADOS
    Private mEntCargo As New CARGOS
    Private mCompCargo As New cCARGOS
    Private mCompProceso As New cPROCESOCOMPRAS
    Private mEntProceso As New PROCESOCOMPRAS
    Public Event grabadaNotificacion As EventHandler
    Dim opc As Integer
    Dim Ds1 As DataSet
    Dim Ds2 As DataSet
    'propiedades
    Public Property IDESTABLECIMIENTO() As Int32 'identificador del establecimiento
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Int32)
            Me._IDESTABLECIMIENTO = Value
        End Set
    End Property
    Public Property IDPROCESOCOMPRA() As Int32 'identificador del proceso de compra
        Get
            Return Me._IDPROCESOCOMPRA
        End Get
        Set(ByVal Value As Int32)
            Me._IDPROCESOCOMPRA = Value
        End Set
    End Property

    Public Property IDPROVEEDOR() As Int32 'identificador del proveedor
        Get
            Return Me._IDPROVEEDOR
        End Get
        Set(ByVal Value As Int32)
            Me._IDPROVEEDOR = Value
        End Set
    End Property
    Public Property IDOFERTA() As Integer 'identificador de la oferta
        Get
            Return Me._IDOFERTA
        End Get
        Set(ByVal Value As Integer)
            Me._IDOFERTA = Value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then 'al momento de carga la pagina la primera vez
            Dim rectec As New ABASTECIMIENTOS.NEGOCIO.cGRUPOSREQTECNICOS
            ddlIDRECTEC.DataSource = rectec.ObtenerDataSetGRUPOSREQTECNICOS
            ddlIDRECTEC.DataTextField = "NOMBRE"
            ddlIDRECTEC.DataValueField = "IDGRUPOREQ"
            ddlIDRECTEC.SelectedValue = 0
            ddlIDRECTEC.DataBind()
            CargaInicial()
        Else
            Select Case ConfirmTarget
                Case "Error"
                    ProcesarError()
                Case "Guardado"
                    ProcesarGuardado()
                Case "Continuar"
                    ProcesarContinuar()
                Case "Salir"
                    ProcesarSalir()
            End Select
        End If
    End Sub

    Private Sub ProcesarSalir()
        Response.Redirect("~/UACI/FrmGenerarNotaIncumplimientoPaso2.aspx?id= " + Me.TxtProceso.Text)
    End Sub

    Private Sub ProcesarContinuar()
        Response.Redirect("~/UACI/FrmGenerarNotaIncumplimientoPaso2.aspx?id= " + Me.TxtProceso.Text)
    End Sub

    Private Sub ProcesarGuardado()
        Confirm("desea salir de la opción?", "Salir", OptionPostBack.YesPostBack)
    End Sub

    Private Sub ProcesarError()
        Confirm("desea salir de la opción?", "Salir", OptionPostBack.YesPostBack)
    End Sub

    'Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
    '    'al escoger ok en mensage sesplegados
    '    If e.Key = "Error" Then
    '        MsgBox1.ShowConfirm("desea salir de la opción?", "D", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    '    End If

    '    If e.Key = "B" Then
    '        MsgBox1.ShowConfirm("desea salir de la opción?", "D", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    '    End If
    'End Sub

    'Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
    '    'al seleccionar yes en mensajes desplegados
    '    If e.Key = "C" Then
    '        Response.Redirect("~/UACI/FrmGenerarNotaIncumplimientoPaso2.aspx?id= " + Me.TxtProceso.Text)
    '    End If

    '    If e.Key = "D" Then
    '        Response.Redirect("~/UACI/FrmGenerarNotaIncumplimientoPaso2.aspx?id= " + Me.TxtProceso.Text)
    '    End If

    'End Sub

    Public Sub cargo()
        'obtiene los cargos de los empleados y los muestra
        mEntEmpleado.IDEMPLEADO = DdlEMPLEADOS1.SelectedValue
        mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)
        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        mCompCargo.ObtenerCARGOS(mEntCargo)
        Me.LblEmpleado.Text = Me.DdlEMPLEADOS1.SelectedItem.Text
        Me.LblCargo.Text = mEntCargo.DESCRIPCION
    End Sub

    Public Sub CargaInicial()
        'funcion de carga inicial
        Me.DdlPROVEEDORES1.RecuperarNombre()
        'muestra y oculta aspectos de barra de navegacion

        Me.UcBarraNavegacion1.Navegacion = False
        Me.UcBarraNavegacion1.PermitirAgregar = False
        Me.UcBarraNavegacion1.PermitirEditar = True
        Me.UcBarraNavegacion1.PermitirConsultar = False
        Me.UcBarraNavegacion1.HabilitarEdicion(True)
        Me.UcBarraNavegacion1.PermitirImprimir = False
        Me.lblerror.Visible = False
        Dim mCom As New cEMPLEADOS
        Dim dsj As Data.DataSet
        'asigna valores a las propiedades con informacion de la pagina que realizo la llamada
        IDPROVEEDOR = Request.QueryString("idproveedor")
        IDPROCESOCOMPRA = Request.QueryString("idproceso")
        IDESTABLECIMIENTO = Request.QueryString("idestablecimiento")
        IDOFERTA = Request.QueryString("idoferta")
        'Me.DdlEMPLEADOS1.RecuperarNombreCompleto()
        Me.DdlEMPLEADOS1.RecuperarEmpleadosPorDependencia(IDESTABLECIMIENTO, 2)
        dsj = mCom.ObtenerJefeUACI(IDESTABLECIMIENTO)
        Me.DdlEMPLEADOS1.SelectedValue = dsj.Tables(0).Rows(0).Item(0)
        cargo() 'obtien cargo
        'obtien datos del proceso de compra y lo muestra
        mEntProceso.IDPROCESOCOMPRA = IDPROCESOCOMPRA
        mEntProceso.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mCompProceso.ObtenerPROCESOCOMPRAS(mEntProceso)
        Me.lblLicitacion.Text = mEntProceso.CODIGOLICITACION & " " & mEntProceso.TITULOLICITACION

        Me.TxtProceso.Text = IDPROCESOCOMPRA
        Me.LblOferta.Text = IDOFERTA
        Me.DdlPROVEEDORES1.SelectedValue = IDPROVEEDOR
        Me.LblProveedor.Text = Me.DdlPROVEEDORES1.SelectedItem.Text

        'validar existencia de nota para mostrar o ocultar botones de impresion
        If mComponente.ValidarExistenciaNota(Session.Item("IdEstablecimiento"), Me.TxtProceso.Text, Me.DdlPROVEEDORES1.SelectedValue) Then
            CargarDatos()
            opc = 2 'actualizar
            Me.ImageButton1.Visible = True 'boton de impresion de documentos faltantes ofertante
            Me.ImageButton2.Visible = True 'boton de impresion de documentos faltantes renglones
        Else
            opc = 1 'agregar
            Me.ImageButton1.Visible = False 'boton de impresion de documentos faltantes ofertante
            Me.ImageButton2.Visible = False 'boton de impresion de documentos faltantes renglones
        End If

        'obtencion de los documentos faltantes
        'ofertante
        Ds1 = mCompProceso.ObtenerDocumentosFaltantesOferta(Session.Item("IdEstablecimiento"), Me.TxtProceso.Text, Me.DdlPROVEEDORES1.SelectedValue)
        'renglon
        Ds2 = mCompProceso.ObtenerDocumentosFaltantesRenglon(Session.Item("IdEstablecimiento"), Me.TxtProceso.Text, Me.ddlPROVEEDORES1.SelectedValue, ddlIDRECTEC.SelectedValue)

        If Ds1.Tables(0).Rows.Count > 0 Then 'ofertante
            Me.dgdocumentacionofertante.DataSource = Ds1
            Me.dgdocumentacionofertante.DataBind()
        Else
            Me.dgdocumentacionofertante.Visible = False
            Me.ImageButton1.Visible = False 'boton de impresion de documentos faltantes ofertante
        End If

        If Ds2.Tables(0).Rows.Count > 0 Then 'renglon
            Me.DgDocumentacionRenglon.DataSource = Ds2
            Me.DgDocumentacionRenglon.DataBind()
        Else
            Me.DgDocumentacionRenglon.Visible = False
            Me.ImageButton2.Visible = False 'boton de impresion de documentos faltantes renglones
        End If
        'obtener fecha del examen preliminar
        Dim fecharef As Date
        fecharef = Me.mComponente.ObtenerFechaExamenPreliminar(Me.TxtProceso.Text, Session.Item("IdEstablecimiento"), Me.DdlPROVEEDORES1.SelectedValue)
        If fecharef <> Nothing Then
            Me.calFechaExamen.Text = fecharef
        End If
    End Sub

    Public Sub CargarDatos()
        'carga de datos necesarios para la generacion de la nota


        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntidad.IDPROCESOCOMPRA = Me.TxtProceso.Text
        mEntidad.IDPROVEEDOR = Me.DdlPROVEEDORES1.SelectedValue
        mComponente.ObtenerNOTASINCUMPLIMIENTO(mEntidad)

        Me.CalendarFechaLimite.SelectedDate = mEntidad.FECHALIMITE
        Me.TxtOficio.Text = mEntidad.NUMEROOFICIO
        Me.DdlEMPLEADOS1.SelectedValue = mEntidad.IDEMPLEADOEMITE

        cargo()
        Me.TxtObservaciones.Text = mEntidad.OBSERVACION
    End Sub

    Public Sub Agregar()
        'funcion guardar informacion de la nota de incumplimiento
        mEntidad = New NOTASINCUMPLIMIENTO

        mEntidad.IDESTABLECIMIENTO = CInt(Session.Item("IdEstablecimiento"))
        mEntidad.IDPROCESOCOMPRA = Val(Me.TxtProceso.Text)
        mEntidad.IDPROVEEDOR = CInt(Me.DdlPROVEEDORES1.SelectedValue)

        mEntidad.FECHALIMITE = Me.CalendarFechaLimite.SelectedDate & " " & Me.TimeHoraLimite.SelectedTime.TimeOfDay.ToString

        mEntidad.NUMEROOFICIO = Me.TxtOficio.Text
        mEntidad.IDEMPLEADOEMITE = Me.DdlEMPLEADOS1.SelectedValue
        mEntidad.OBSERVACION = Me.TxtObservaciones.Text
        If mEntidad.AUUSUARIOCREACION = Nothing Then
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntidad.AUFECHACREACION = Nothing Then
            mEntidad.AUFECHACREACION = Now()
        End If
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0

        If Me.TxtOficio.Text = "" Then
            Me.lblerror.Visible = True
        Else
            If mComponente.ValidarNumeroOficio(CInt(Me.DdlPROVEEDORES1.SelectedValue), Me.TxtOficio.Text, CInt(Session.Item("IdEstablecimiento"))) Then
                'MsgBox1.ShowAlert("Ya existe el número de oficio ingresado, favor corregir", "x", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                AlertSubmit("Ya existe el número de oficio ingresado, favor corregir", "x")
            Else
                If Me.calFechaExamen.Text <> Nothing Then
                    If CDate(Me.calFechaExamen.Text) < Me.CalendarFechaLimite.SelectedDate Then
                        Select Case opc
                            Case Is = 1 'nuevo
                                If mComponente.AgregarNOTASINCUMPLIMIENTO(mEntidad) <> 1 Then
                                    AlertSubmit("Error al Guardar registro.", "Error")
                                    'MsgBox1.ShowAlert("Error al Guardar registro.", "Error", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                                Else
                                    AlertSubmit("La nota de incumplimiento ha sido creada", "Error")
                                    'MsgBox1.ShowAlert("La nota de incumplimiento ha sido creada", "Error", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                                End If
                            Case Is = 2 'existe
                                If mComponente.ActualizarNOTASINCUMPLIMIENTO(mEntidad) <> 1 Then
                                    AlertSubmit("Error al Guardar registro.", "Error")
                                    'MsgBox1.ShowAlert("Error al Guardar registro.", "Error", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                                Else
                                    AlertSubmit("Los cambios a la nota de incumplimiento han sido guardado satisfactoriamente", "Guardado")
                                    'MsgBox1.ShowAlert("Los cambios a la nota de incumplimiento han sido guardado satisfactoriamente", "B", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                                    Me.ImageButton1.Visible = True 'boton de impresion de documentos faltantes ofertante
                                    Me.ImageButton2.Visible = True 'boton de impresion de documentos faltantes renglones
                                End If
                        End Select
                    Else
                        AlertSubmit("La fecha de la nota de incumplimiento no puede ser menor a la del examen preiliminar", "y")
                        'MsgBox1.ShowAlert("La fecha de la nota de incumplimiento no puede ser menor a la del examen preiliminar", "y", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                    End If
                Else
                    AlertSubmit("La fecha del examen preliminar no fue asignada, favor de verificar", "z")
                    'MsgBox1.ShowAlert("La fecha del examen preliminar no fue asignada, favor de verificar", "z", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                End If
            End If
        End If
    End Sub

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar

        Confirm("Con esta operacion, si no ha guardado los cambios realizados, los perdera, desea seguir con la operación ?", "Continuar", OptionPostBack.YesPostBack)
        'MsgBox1.ShowConfirm("Con esta operacion, si no ha guardado los cambios realizados, los perdera, desea seguir con la operación ?", "C", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)

    End Sub

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar
        'evento guardar de la barra de navegacion

        If mComponente.ValidarExistenciaNota(Session.Item("IdEstablecimiento"), Me.TxtProceso.Text, Me.DdlPROVEEDORES1.SelectedValue) Then
            opc = 2 'actualizar
        Else
            opc = 1 'agregar
        End If
        Agregar()

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        'evento al seleccionar imprimir documentacion faltante ofertante

        'definicion de variables de sesion para reporte
        Session.Item("id") = Me.TxtProceso.Text
        Session.Item("idprov") = Me.ddlPROVEEDORES1.SelectedValue

        'llamada al reporte
        ' Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptDocumentacionFaltanteOfertante.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        SINAB_Utils.Utils.MostrarVentana("/Reportes/FrmRptDocumentacionFaltanteOfertante.aspx")
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        'evento al seleccionar imprimir documentacion faltante del renglon

        Session.Item("id") = Me.TxtProceso.Text
        Session.Item("idprov") = Me.DdlPROVEEDORES1.SelectedValue

        'llamada al reporte
        ' Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptDocumentacionFaltanteRenglon.aspx?IDRECTEC=" & ddlIDRECTEC.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        SINAB_Utils.Utils.MostrarVentana("/Reportes/FrmRptDocumentacionFaltanteRenglon.aspx?IDRECTEC=" & ddlIDRECTEC.SelectedValue)
    End Sub

    

    Protected Sub DdlEMPLEADOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlEMPLEADOS1.SelectedIndexChanged
        cargo()
    End Sub

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        CargaInicial()
    End Sub
End Class
