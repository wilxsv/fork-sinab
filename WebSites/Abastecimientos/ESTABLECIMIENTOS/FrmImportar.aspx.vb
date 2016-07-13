'INGRESO DE CONSUMO, DEMANDA INSATISFECHA Y CONSUMO
'CU-ESTA0002
'Ing. Yessenia Pennelope Henriquez Duran
'establecimientos del nivel 2 y 3 consumo es diario y se realiza por medio de interfaz SIM
'la existencia no es ingresada para estos establecimientos
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.IO
Imports System.Data
Imports Cooperator.Framework.Web.Controls

Partial Class FrmImportar
    Inherits System.Web.UI.Page
    'declaracion e inicalizacion de variables
    'Private mEntidad As New RECETAS
    'Private mComponente As New cRECETAS
    'Private mEntDetalle As New DETALLERECETA
    'Private mCompDetalle As New cDETALLERECETA
    'Private mEntServicios As New SERVICIOSHOSPITALARIOS
    'Private mCompServicios As New cSERVICIOSHOSPITALARIOS
    'Private mEntSimServicios As New SIMSERVICIOS
    'Private mCompSimServicios As New cSIMSERVICIOS
    'Private mEntCargaDatos As New CARGADATOSSIM
    'Private mCompCargaDatos As New cCARGADATOSSIM
    'Private mEntConsumo As New CONSUMOS
    'Private mCompConsumo As New cCONSUMOS
    'Private mEntDetalleConsumo As New DETALLECONSUMOS
    'Private mCompDetalleConsumo As New cDETALLECONSUMOS
    'Private _fechatrabajo As Date
    'Private _idConsumo As Integer

    'Dim carga As Integer
    'Dim ds, dss, dsr, dsdr, dsdc As DataSet
    'Dim cantSAB As Double

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    'al momento de presionar boton de importar llama a formulariio SIM creado en publicacion de interfaz SIM
    '    Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.showModalDialog('SIM.aspx'); </script>")
    'End Sub

    'Protected Sub Wizard1_ActiveStepChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Wizard1.ActiveStepChanged
    '    'al realizar un cambio de paso en el wizard de importacion de datos

    '    If (Wizard1.ActiveStepIndex = 0) Then
    '        Wizard1.DisplayCancelButton = True
    '    End If
    '    If (Wizard1.ActiveStepIndex = 1) Then 'llamada a aplicacion interfasz SIM
    '        carga = mCompCargaDatos.ObtenerCargaSIM(Session.Item("IdEstablecimiento"))
    '        If carga = 0 Then 'verifica si ha carga pendiente de completar
    '            MsgBox1.ShowAlert("Necesita realizar la carga desde el SIM para continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '            Wizard1.MoveTo(Me.WizardStep0)
    '        Else
    '            Me.lblCarga.Text = carga
    '            Wizard1.DisplayCancelButton = True
    '            CargarDatos()
    '        End If
    '    End If
    '    If (Wizard1.ActiveStepIndex = 2) Then
    '        Wizard1.DisplayCancelButton = True
    '    End If
    'End Sub

    'Sub CargarDatos()
    '    'realiza la garga de datos a mostrar en el wizard

    '    mEntCargaDatos.IDCARGA = CInt(Me.lblCarga.Text)
    '    mEntCargaDatos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '    mCompCargaDatos.ObtenerCARGADATOSSIM(mEntCargaDatos)
    '    Me.DdlESTABLECIMIENTOS1.Recuperar()
    '    Me.DdlESTABLECIMIENTOS1.SelectedValue = mEntCargaDatos.IDESTABLECIMIENTO
    '    Me.lblEstablecimiento.Text = Me.DdlESTABLECIMIENTOS1.SelectedItem.Text
    '    Me.lblfechaCarga.Text = mEntCargaDatos.FECHACARGA.ToString("dd / MM / yyyy")
    '    Me.lblFechafinal.Text = mEntCargaDatos.FECHAINICIAL.ToString("dd / MM / yyyy")
    '    Me.lblfechainicial.Text = mEntCargaDatos.FECHAFINAL.ToString("dd / MM / yyyy")
    '    Me._fechatrabajo = mEntCargaDatos.FECHAINICIAL
    '    Me.calfecha.SelectedDate = mEntCargaDatos.FECHAINICIAL
    '    Me.lblncarga.Text = mEntCargaDatos.IDCARGA
    '    Me.DdlEMPLEADOS1.RecuperarNombreCompleto()
    '    Me.DdlEMPLEADOS1.SelectedValue = mEntCargaDatos.IDEMPLEADO
    '    Me.lblOperador.Text = Me.DdlEMPLEADOS1.SelectedItem.Text
    '    Me.lblTotalmedicamentos.Text = mComponente.ObtenerCantidadReceta(Session.Item("IdEstablecimiento"))
    '    Me.lbltotalrecetas.Text = mComponente.ObtenerCantidadDetalleReceta(Session.Item("IdEstablecimiento"))

    '    'obtiene dataset con la informacion que importo al sistema la aplicacion interfaz SIM
    '    ds = mComponente.DDataSetImportacionSIM(Session.Item("IdEstablecimiento"))
    '    Me.dgLista.DataSource = ds
    '    'carga lista
    '    Try
    '        Me.dgLista.DataBind()
    '    Catch ex As Exception 'error de pagineo
    '        Me.dgLista.CurrentPageIndex = 0
    '        Me.dgLista.DataBind()
    '    End Try

    'End Sub

    'Protected Sub dgLista_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
    'End Sub

    'Private Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista.PageIndexChanged
    '    'al cambiar el numero de indice de pagina del grid
    '    Me.dgLista.CurrentPageIndex = e.NewPageIndex
    '    Me.CargarDatos()
    'End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'al cargar la pagina
    '    deshabilitarDobleClickBotones()
    '    If Not Page.IsPostBack Then 'al cargar la primera vez
    '        Wizard1.ActiveStepIndex = 0
    '        Wizard1.DisplaySideBar = False
    '        Wizard1.DisplayCancelButton = True
    '    End If
    'End Sub

    'Protected Sub Wizard1_CancelButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Wizard1.CancelButtonClick
    '    'al presionar cancelar en el wizard
    '    MsgBox1.ShowConfirm("Con esta operacion perdera los datos de la importacion, desea seguir con la operación ?", "C", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    'End Sub

    'Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
    '    'al seleccionar yes en mensjes desplegaods
    '    If e.Key = "C" Then
    '        carga = mCompCargaDatos.ObtenerCargaSIM(Session.Item("IdEstablecimiento"))
    '        If carga > 0 Then
    '            mCompCargaDatos.EliminarCARGADATOSSIM(Session.Item("IdEstablecimiento"), carga)
    '        End If
    '        Response.Redirect("~/ESTABLECIMIENTOS/FrmMantConsumos.aspx")
    '    End If
    'End Sub

    'Protected Sub Wizard1_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick
    '    'al seleccionar finalizar en wizard
    '    'crea nuevo consumo
    '    mEntCargaDatos.IDCARGA = CInt(Me.lblCarga.Text)
    '    mEntCargaDatos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '    mCompCargaDatos.ObtenerCARGADATOSSIM(mEntCargaDatos)
    '    mEntCargaDatos.ESTASINCRONIZADA = 0
    '    mCompCargaDatos.ActualizarCARGADATOSSIM(mEntCargaDatos)
    '    ActualizarServicios()
    '    ActualizarRecetas()
    '    ActualizarDetalleRecetas()
    '    CrearConsumo()

    '    'hace llamada a formulario de mantenimiento de consumo 
    '    Response.Redirect("~/ESTABLECIMIENTOS/FrmDetaMantConsumos.aspx?id= " + Me.lblConsumo.Text & "&estado=1")

    'End Sub

    'Sub ActualizarServicios()
    '    'actualizacion de la tabla de servicios hospitalarios
    '    'verifica si existen con anterioridad
    '    If mCompServicios.ExistenServiciosHospitalariosEstablecimiento(Session.Item("IdEstablecimiento")) Then

    '        'no realiza la operacion unicamente la primera vez
    '    Else
    '        dss = mComponente.DDataSetServiciosSIM(Session.Item("IdEstablecimiento"))

    '        Dim r As DataRow

    '        For Each r In dss.Tables(0).Rows

    '            mEntServicios.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '            mEntServicios.IDSERVICIOHOSPITALARIO = 0
    '            mEntServicios.CODIGOSERVICIO = r("CODDEP")
    '            mEntServicios.NOMBRESERVICIO = r("NOMDEP")
    '            mEntServicios.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '            mEntServicios.AUFECHACREACION = Now
    '            mEntServicios.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '            mEntServicios.AUFECHAMODIFICACION = Now
    '            mEntServicios.ESTASINCRONIZADA = 0
    '            mCompServicios.ActualizarSERVICIOSHOSPITALARIOS(mEntServicios)

    '        Next r
    '    End If

    'End Sub

    'Sub ActualizarRecetas()
    '    'recorre las recetas importadas del SIM agrega a la tabla de recetas del establecimiento
    '    dsr = mComponente.DDataSetRecetasSIM(Session.Item("IdEstablecimiento"), CInt(Me.lblCarga.Text))

    '    Dim r As DataRow
    '    For Each r In dsr.Tables(0).Rows
    '        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '        mEntidad.IDCARGA = r("IDCARGA")
    '        mEntidad.IDRECETA = 0
    '        mEntidad.NUMERORECETA = r("NUMRE")
    '        mEntidad.IDSERVICIOHOSPITALARIO = r("IDSERVICIOHOSPITALARIO")
    '        mEntidad.FECHARECETA = r("FECHA")
    '        mEntidad.MEDICO = r("MEDICO")
    '        mEntidad.DESPACHADO = 1
    '        mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '        mEntidad.AUFECHACREACION = Now
    '        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '        mEntidad.AUFECHAMODIFICACION = Now
    '        mEntidad.ESTASINCRONIZADA = 0
    '        mComponente.ActualizarRECETAS(mEntidad)

    '    Next r
    'End Sub

    'Sub ActualizarDetalleRecetas()
    '    'recorre el detalle de recetas importadas del SIM agrega a la tabla de detalle de recetas del establecimiento
    '    dsdr = mComponente.DDataSetDetalleRecetasSIM(Session.Item("IdEstablecimiento"), CInt(Me.lblCarga.Text))
    '    Dim r As DataRow
    '    For Each r In dsdr.Tables(0).Rows
    '        mEntDetalle.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '        mEntDetalle.IDCARGA = r("IDCARGA")
    '        mEntDetalle.IDRECETA = r("IDRECETA")
    '        mEntDetalle.IDDETALLE = 0
    '        mEntDetalle.IDPRODUCTO = r("IDPRODUCTO")
    '        mEntDetalle.CANTIDAD = r("DIVISION")
    '        mEntDetalle.IDUNIDADMEDIDA = r("IDUNIDADMEDIDA")
    '        mEntDetalle.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '        mEntDetalle.AUFECHACREACION = Now
    '        mEntDetalle.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '        mEntDetalle.AUFECHAMODIFICACION = Now
    '        mEntDetalle.ESTASINCRONIZADA = 0
    '        mCompDetalle.ActualizarDETALLERECETA(mEntDetalle)
    '    Next r
    'End Sub


    'Sub CrearConsumo()
    '    ' crear encabezado de consumo nuevo diario del establecimiento con la informacion de la
    '    'importcion del SIM

    '    mEntConsumo.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '    Me._idConsumo = mCompConsumo.id_Consumos(mEntConsumo)
    '    Me.lblConsumo.Text = Me._idConsumo
    '    mEntConsumo.IDCONSUMO = Me._idConsumo
    '    mEntConsumo.FECHAINGRESO = Now
    '    mEntConsumo.MESCONSUMO = Me.calfecha.SelectedDate.ToString("MM")
    '    mEntConsumo.ANIOCONSUMO = Me.calfecha.SelectedDate.ToString("yyyy")
    '    mEntConsumo.DIACONSUMO = Me.calfecha.SelectedDate.ToString("dd")
    '    mEntConsumo.IDEMPLEADO = Session.Item("IdEmpleado")
    '    mEntConsumo.IDESTADO = 1
    '    mEntConsumo.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '    mEntConsumo.AUFECHACREACION = Now
    '    mEntConsumo.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '    mEntConsumo.AUFECHAMODIFICACION = Now
    '    mEntConsumo.ESTASINCRONIZADA = 0
    '    mCompConsumo.AgregarConsumos(mEntConsumo)

    '    ' crear detalle de consumo diario del establecimiento con la informacion de la 
    '    'importacion del SIM

    '    dsdc = mComponente.DDataSetDetalleConsumo(Session.Item("IdEstablecimiento"))
    '    Dim r As DataRow
    '    For Each r In dsdc.Tables(0).Rows
    '        mEntDetalleConsumo.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
    '        mEntDetalleConsumo.IDCONSUMO = Me.lblConsumo.Text
    '        mEntDetalleConsumo.IDDETALLE = 0
    '        mEntDetalleConsumo.IDPRODUCTO = r("IDPRODUCTO")
    '        mEntDetalleConsumo.CANTIDADCONSUMIDA = r("DIVISION")
    '        mEntDetalleConsumo.IDUNIDADMEDIDA = r("IDUNIDADMEDIDA")
    '        mEntDetalleConsumo.DEMANDAINSATISFECHA = 0
    '        mEntDetalleConsumo.EXISTENCIAACTUAL = 0
    '        mEntDetalleConsumo.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '        mEntDetalleConsumo.AUFECHACREACION = Now
    '        mEntDetalleConsumo.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '        mEntDetalleConsumo.AUFECHAMODIFICACION = Now
    '        mEntDetalleConsumo.ESTASINCRONIZADA = 0
    '        mCompDetalleConsumo.ActualizarDETALLECONSUMOS(mEntDetalleConsumo)
    '    Next r
    'End Sub

    'Protected Sub deshabilitarDobleClickBotones()
    '    Button1.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(Button1, Nothing) + ";"
    'End Sub

End Class
