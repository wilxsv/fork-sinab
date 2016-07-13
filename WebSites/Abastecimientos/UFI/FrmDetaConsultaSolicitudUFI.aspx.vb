'CU-ESTA0001 INGRESO DE SOLICITUD DE COMPRAS
'CU-UFI0001 AUTORIZAR SOLICITUDES DE COMPRA UFI
'CU-UACI001 CONSULTAR SOLICITUDES DE COMPRA UACI
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la creacion y mantenimiento de solicitudes de compra
'permite la consulta de las solicitudes de compras conjuntas
'permite la consulta de las solicitudes por la UACI
'permite la autorizacion de la UFI
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports Cooperator.Framework.Web.Controls

Partial Class FrmDetaConsultaSolicitudUFI
    Inherits System.Web.UI.Page
    'declarar e inicializar variables
    Private mComponente As New cSOLICITUDES
    Private mCompDetalle As New cDETALLESOLICITUDES
    Private mCompFuentes As New cFUENTEFINANCIAMIENTOSOLICITUDES
    Private mCompDetalleEntregas As New cDETALLEENTREGAS
    Private mCompEntregas As New cENTREGASOLICITUDES
    Private mCompNecesidadesSolicitud As New cNECESIDADESSOLICITUD
    Private _Consulta As Boolean = False
    Private _ConsultaNoUaci As Boolean = False
    Private _Nuevo As Boolean = False
    Private _Grabado As Boolean = False
    Private _autorizar As Boolean = False
    Dim lId As Int64
    Dim lestado As Int32
    Dim lconjunta As Int32
    Dim flag As String
    Dim lsuministro As Int32
    Dim ldependencia As Int32
    Dim estado As Int32

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al momento de cargar la pagina
        Me.Master.ControlMenu.Visible = False 'oculta menu
        If Not Page.IsPostBack Then 'la primera vez que carga
            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = True

            lId = Request.QueryString("id") 'identificador de solicitud
            lestado = Request.QueryString("estado") 'identificador de estado
            lconjunta = Request.QueryString("conjunta") ''si es conjunta

            Me.UcSolicitudCompra1.CODIGOENCABEZADODOCUMENTO = lId
            Me.LblDoc.Text = lId
            Consulta = False
        End If

    End Sub

    Public Property Consulta() As Boolean
        'consulta de solicitud UACI
        Get
            Return Me._Consulta
        End Get
        Set(ByVal Value As Boolean)
            Me._Consulta = Value
            Me.HabilitarConsulta(_Consulta)
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirImprimir = True
        End Set
    End Property
    Private Sub BarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'al momento de cancelar
        MsgBox1.ShowConfirm("Con esta operacion, si no ha guardado los cambios realizados, los perdera, desea seguir con la operación ?", "C", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_CallBackOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Private Sub HabilitarConsulta(ByVal edicion As Boolean)
        'habilita los campos para la consulta de la UACI
        Me.UcSolicitudCompra1.Consulta = edicion
        Me.UcSolicitudCompra1.MostrarCamposCertificacionFondosConsulta(True)
    End Sub

    Protected Sub BarraNavegacion1_Imprimir(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Imprimir
        'al momento de seleccionar imprimir
        Session.Item("idDocRep") = Me.LblDoc.Text
        Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptSolicitudCompra.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub UcSolicitudCompra1_ErrorEvent(ByVal errorMessage As String) Handles UcSolicitudCompra1.ErrorEvent
        'evento de error
        MsgBox1.ShowAlert("errorMessage", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        'al seleccionar ok en los mensajes desplegados
        If e.Key = "B" Then
            MsgBox1.ShowConfirm("desea salir de la opción?", "D", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        'al seleccionar yes en los mensajes desplegados
        If e.Key = "D" Then
            Response.Redirect("~/UFI/FrmMantConsultaSolicitudUFI.aspx")
        End If
        If e.Key = "C" Then
            Response.Redirect("~/UFI/FrmMantConsultaSolicitudUFI.aspx")
        End If
    End Sub

    Protected Sub UcSolicitudCompra1_MontoSolicitud(ByVal MontoSolicitud As Double) Handles UcSolicitudCompra1.MontoSolicitud
        'al momento de calcular monto de la solicitud
        Me.LblMonto.Text = MontoSolicitud
    End Sub

    Protected Sub UcSolicitudCompra1_NumeroSolicitud(ByVal NumSolicitud As String) Handles UcSolicitudCompra1.NumeroSolicitud
        'evento de numero de solicitud asignado
        Me.LblDoc.Text = NumSolicitud
    End Sub
End Class
