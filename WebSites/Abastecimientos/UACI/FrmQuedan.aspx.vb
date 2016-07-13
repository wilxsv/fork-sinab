'ELABORAR QUEDAN
'CU-UACI030
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario con la informacion del quedan generado
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Imports Cooperator.Framework.Web.Controls

Partial Class FrmQuedan
    Inherits System.Web.UI.Page

    ' INICIALIZAR VARIABLES
    Private mEntidadQuedan As New QUEDANS
    Private mCompQuedan As New cQUEDANS
    Private mEntGarantia As New GARANTIASCONTRATOS
    Private mCompGarantia As New cGARANTIASCONTRATOS
    Private mCompProceso As New cPROCESOCOMPRAS
    Private mEntProceso As New PROCESOCOMPRAS

    Private _IDESTABLECIMIENTO As Int32
    Private _IDTIPOGARANTIA As Int32
    Private _IDPROVEEDOR As Int32
    Private _IDPROCESO As Int32
    Private _IDOFERTA As Int32
    Private _IDCONTRATO As Integer
    Private _IDGARANTIACONTRATO As Integer
    Private mComponente As New cQUEDANS
    Private mEntidad As New QUEDANS

    Public Event grabadaQuedan As EventHandler
    Dim opc As Integer
    Dim ds, ds2 As DataSet

    'INICIALIZAR PROPIEDADES
#Region " Propiedades "

    Public Property IDPROCESO() As Int32 'identificador de proceso de compras 
        Get
            Return Me._IDPROCESO
        End Get
        Set(ByVal Value As Int32)
            Me._IDPROCESO = Value
            Me.idproces.Text = Value
        End Set
    End Property

    Public Property IDOFERTA() As Int32 'identificador de numero de oferta
        Get
            Return Me._IDOFERTA
        End Get
        Set(ByVal Value As Int32)
            Me._IDOFERTA = Value
            Me.idofert.Text = Value
        End Set
    End Property

    Public Property IDESTABLECIMIENTO() As Int32 'identificador de estblecimiento
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Int32)
            Me._IDESTABLECIMIENTO = Value
        End Set
    End Property

    Public Property IDTIPOGARANTIA() As Int32 'identificador de tipo de garantia
        Get
            Return Me._IDTIPOGARANTIA
        End Get
        Set(ByVal Value As Int32)
            Me._IDTIPOGARANTIA = Value
            Me.idtipogarant.Text = Value
        End Set
    End Property

    Public Property IDPROVEEDOR() As Int32 'identificador de proveedor
        Get
            Return Me._IDPROVEEDOR
        End Get
        Set(ByVal Value As Int32)
            Me._IDPROVEEDOR = Value
            Me.idprov.Text = Value
        End Set
    End Property

    Public Property IDCONTRATO() As Integer 'identificador de contrato
        Get
            Return Me._IDCONTRATO
        End Get
        Set(ByVal Value As Integer)
            Me._IDCONTRATO = Value
            Me.idcontrat.Text = Value
        End Set
    End Property

    Public Property IDGARANTIASCONTRATO() As Integer 'identificador de contrato
        Get
            Return Me._IDGARANTIACONTRATO
        End Get
        Set(ByVal Value As Integer)
            Me._IDGARANTIACONTRATO = Value
            Me.idgarcon.Text = Value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'EVENTO AL CARGAR PAGINA

        If Not Page.IsPostBack Then
            CargaInicial() 'realiza carga inicial

            'Validar existencia de quedan

            If mComponente.ValidarExistenciaQuedan(Session.Item("IdEstablecimiento"), Me.idcontrat.Text, Me.idprov.Text, Me.idtipogarant.Text, Me.idgarcon.Text) Then
                CargarDatosQuedan() 'existe quedan
                Me.UcBarraNavegacion1.PermitirImprimir = True
            Else
                mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento") 'no existe es nuevo
                Me.LblQuedan.Text = mComponente.ObtenerIdQuedan(mEntidad) 'obtiene el correlativo
            End If
        End If
    End Sub

    Public Sub CargaInicial()
        'CARGA INICIAL DE DATOS

        'oculta o muestra aspectos de la barra de navegacion
        Me.UcBarraNavegacion1.Navegacion = False
        Me.UcBarraNavegacion1.PermitirAgregar = False
        Me.UcBarraNavegacion1.PermitirEditar = True
        Me.UcBarraNavegacion1.PermitirConsultar = False
        Me.UcBarraNavegacion1.HabilitarEdicion(True)
        Me.UcBarraNavegacion1.PermitirImprimir = False

        'asigna valores a los identificadores enviados de la pagina que hiso la llamada
        IDPROVEEDOR = Request.QueryString("idproveedor")
        IDESTABLECIMIENTO = Request.QueryString("idestablecimiento")
        IDCONTRATO = Request.QueryString("idcontrato")
        IDTIPOGARANTIA = Request.QueryString("idtipogarantia")
        IDOFERTA = Request.QueryString("idoferta")
        IDPROCESO = Request.QueryString("idproceso")
        IDGARANTIASCONTRATO = Request.QueryString("idgarantiacontrato")

        'recuperacion de la informacion necesaria para la creacion del quedan proveneinte de contrato

        ds = mComponente.DatasetContratoQuedan(CInt(Session.Item("IdEstablecimiento")), Me.idcontrat.Text, Me.idtipogarant.Text, Me.idprov.Text, Me.idgarcon.Text)

        Me.LblFecha.Text = Now.ToString("dd/MM/yyyy")
        Dim r As DataRow

        For Each r In ds.Tables(0).Rows 'muestr la informacion en pantalla de los datos del proceso de compra
            Me.LblProveedor.Text = r("NOMBREPROVEEDOR")
            If r("TELEFONO") Is DBNull.Value Then Me.LblTelefono.Text = "" Else Me.LblTelefono.Text = r("TELEFONO")
            If r("CODIGOLICITACION") Is DBNull.Value Then Me.LblProcesoCompra.Text = "" Else Me.LblProcesoCompra.Text = r("CODIGOLICITACION")

            Me.lblLicitacion.Text = r("TITULOLICITACION")
            If r("DESCRIPCIONLICITACION") Is DBNull.Value Then Me.lblLicitacion.Text = Me.lblLicitacion.Text Else Me.lblLicitacion.Text = Me.lblLicitacion.Text & " / " & r("DESCRIPCIONLICITACION")

            If r("NUMEROCONTRATO") Is DBNull.Value Then Me.LblContrato.Text = "" Else Me.LblContrato.Text = r("NUMEROCONTRATO")
            If r("MONTOCONTRATO") Is DBNull.Value Then Me.Txtmonto.Text = "" Else Me.Txtmonto.Text = r("MONTOCONTRATO")
            If r("NUMERORESOLUCION") Is DBNull.Value Then Me.LblResolucion.Text = "" Else Me.LblResolucion.Text = r("NUMERORESOLUCION")
            If r("TIPOGARANTIA") Is DBNull.Value Then Me.LblTipoGarantia.Text = "" Else Me.LblTipoGarantia.Text = r("TIPOGARANTIA")
            If r("CLASEGARANTIA") Is DBNull.Value Then Me.LblClaseGarantia.Text = "" Else Me.LblClaseGarantia.Text = r("CLASEGARANTIA")
            If r("NUMEROGARANTIA") Is DBNull.Value Then Me.LblNumeroGarantia.Text = "" Else Me.LblNumeroGarantia.Text = r("NUMEROGARANTIA")
            If r("FECHARECEPCION") Is DBNull.Value Then Me.LblFechaIngresoGarantia.Text = "" Else Me.LblFechaIngresoGarantia.Text = r("FECHARECEPCION")
            If r("VENCIMIENTOGARANTIA") Is DBNull.Value Then Me.LblFechaVencimientoGarantia.Text = "" Else Me.LblFechaVencimientoGarantia.Text = r("VENCIMIENTOGARANTIA")
            If r("MONTO") Is DBNull.Value Then Me.TxtMontoGarantia.Text = "" Else Me.TxtMontoGarantia.Text = r("MONTO")

        Next r
    End Sub

    Public Sub CargarDatosQuedan()
        'CARGA DE LOS DATOS DE QUEDAN, CUANDO YA EXISTE
        mEntidad.IDESTABLECIMIENTO = CInt(Session.Item("IdEstablecimiento"))
        mEntidad.IDPROVEEDOR = Me.idprov.Text
        mEntidad.IDCONTRATO = Me.idcontrat.Text
        mEntidad.IDTIPOGARANTIA = Me.idtipogarant.Text
        mEntidad.IDGARANTIACONTRATO = Me.idgarcon.Text

        mComponente.ObtenerInformacionQuedan(mEntidad) 'llamada al metodo obtener informacion de quedan
        'recupera y mestr informacion de quedan existente
        Me.LblQuedan.Text = mEntidad.IDQUEDAN
        Me.LblFecha.Text = mEntidad.FECHAINGRESO
        Me.TxtObservaciones.Text = mEntidad.DESCRIPCION

    End Sub

    Public Sub Agregar()

        'AGREGA UN NUEVO DOCUMENTO DE QUEDAN SI NO EXISTE, DE LO CONTRARIO LO ACTUALIZA
        mEntidad = New QUEDANS

        mEntidad.IDESTABLECIMIENTO = CInt(Session.Item("IdEstablecimiento"))
        mEntidad.IDPROVEEDOR = Me.idprov.Text
        mEntidad.IDCONTRATO = Me.idcontrat.Text
        mEntidad.IDTIPOGARANTIA = Me.idtipogarant.Text
        mEntidad.IDGARANTIACONTRATO = Me.idgarcon.Text
        mEntidad.IDQUEDAN = Me.LblQuedan.Text
        mEntidad.FECHAINGRESO = Me.LblFecha.Text

        If Me.LblFechaVencimientoGarantia.Text = "" Then mEntidad.FECHAVENCIMIENTO = Nothing Else mEntidad.FECHAVENCIMIENTO = Me.LblFechaVencimientoGarantia.Text

        mEntidad.DESCRIPCION = Me.TxtObservaciones.Text

        mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHACREACION = Now()
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0

        'Agrega o actualiza el quedan en la base de datos
        If Me.LblProcesoCompra.Text = "" Or Me.LblContrato.Text = "" Or Me.Txtmonto.Text = "" Or Me.LblTipoGarantia.Text = "" Or Me.LblNumeroGarantia.Text = "" Or Me.LblResolucion.Text = "" Or Me.LblFechaIngresoGarantia.Text = "" Or Me.LblFechaVencimientoGarantia.Text = "" Then
            MsgBox1.ShowAlert("Verifique la informacion proveniente de garantias y contratos, esta incompleta antes de guardar modificación", "C", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, AlertType.Exclamation)
        Else
            Select Case opc
                Case Is = 1 'nuevo
                    If mComponente.AgregarQUEDANS(mEntidad) <> 1 Then
                        MsgBox1.ShowAlert("Error al Guardar registro.", "C", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, AlertType.Exclamation)
                    Else
                        MsgBox1.ShowAlert("El quedan ha sido creado", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, AlertType.Exclamation)
                        Me.UcBarraNavegacion1.PermitirImprimir = True
                    End If
                Case Is = 2 'existente
                    If mComponente.ActualizarQUEDANS(mEntidad) <> 1 Then
                        MsgBox1.ShowAlert("Error al Guardar registro.", "C", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, AlertType.Exclamation)
                    Else
                        MsgBox1.ShowAlert("Los cambios al quedan han sido guardados satisfactoriamente", "B", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, AlertType.Exclamation)
                    End If
            End Select

        End If

    End Sub

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar
        'EVENTO CANCELAR DE LA BARRA DE NAVEGACION
        MsgBox1.ShowConfirm("Con esta operacion, si no ha guardado los cambios realizados, los perdera, desea seguir con la operación ?", "C", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar
        'EVENTO GUARDAR DE LA BARRA DE NAVEGACION
        If mComponente.ValidarExistenciaQuedan(Session.Item("IdEstablecimiento"), Me.idcontrat.Text, Me.idprov.Text, Me.idtipogarant.Text, Me.idgarcon.Text) Then
            opc = 2 'actualizar
        Else
            opc = 1 'agregar
        End If
        Agregar()
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        'MENSAGE A MOSTRAR AL PRESIONAR OK
        If e.Key = "A" Then
            MsgBox1.ShowConfirm("desea salir de la opción?", "D", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        End If

        If e.Key = "B" Then
            MsgBox1.ShowConfirm("desea salir de la opción?", "D", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        'MENSAGES A MOSTRAR AL PRESIONAR YES

        If e.Key = "C" Then
            Response.Redirect("~/UACI/FrmElaborarQuedan2.aspx?proveedor= " + Me.idprov.Text & "&oferta= " + Me.idofert.Text & "&contrato= " + Me.idcontrat.Text & "&id= " + Me.idproces.Text)
        End If

        If e.Key = "D" Then
            Response.Redirect("~/UACI/FrmElaborarQuedan2.aspx?proveedor= " + Me.idprov.Text & "&oferta= " + Me.idofert.Text & "&contrato= " + Me.idcontrat.Text & "&id= " + Me.idproces.Text)
        End If

    End Sub


    Protected Sub UcBarraNavegacion1_Imprimir(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Imprimir
        'EVENTO IMPRIMIR DE LA BARRA DE NAVEGACION

        mEntProceso.IDPROCESOCOMPRA = Me.idproces.Text
        mEntProceso.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mCompProceso.ObtenerPROCESOCOMPRAS(mEntProceso)

        'parametros del reporte
        Session.Item("idtipocompra") = mEntProceso.IDTIPOCOMPRAEJECUTAR
        Session.Item("idContRep") = Me.idcontrat.Text
        Session.Item("idProvRep") = Me.idprov.Text
        Session.Item("idGarantRep") = Me.idtipogarant.Text
        Session.Item("idQuedanRep") = Me.LblQuedan.Text
        Session.Item("idGarantiaContrato") = Me.idgarcon.Text

        'Llamada de la pagina de reporte

        Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptQuedan.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

End Class
