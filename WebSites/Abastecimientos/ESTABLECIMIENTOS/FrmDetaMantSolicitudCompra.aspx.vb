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

Partial Class FrmDetaMantSolicitudCompra
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

        If Not Page.IsPostBack Then 'la primera vez que carga

            Me.Master.ControlMenu.Visible = False 'oculta menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = True

            lId = Request.QueryString("id") 'identificador de solicitud
            lestado = Request.QueryString("estado") 'identificador de estado
            lconjunta = Request.QueryString("conjunta") ''si es conjunta
            flag = Request.QueryString("flag") ' bandera para la autorizacion de solicitudes o consulta de UACI
            lsuministro = Request.QueryString("suministro") 'identificador de suministro
            ldependencia = Request.QueryString("dependencia") 'identificador de dependencia
            Me.UcSolicitudCompra1.CODIGOENCABEZADODOCUMENTO = lId
            Me.LblDoc.Text = lId

            If flag = "consulta" Then 'consulta de la UACI
                Consulta = False
                Session.Item("opc") = "1"
            End If

            If flag = "autorizar" Then 'Autorizacion de la UFI
                Autorizar = True
                Session.Item("opc") = "2"
            End If

            If flag = Nothing Then  'consulta de solicitud
                Session.Item("opc") = "3"

                If lestado > 1 Then ' diferente de grabado se deshabilita la solicitud
                    ConsultaNoUaci = False
                End If

                If lestado = 1 And lconjunta = 0 Then  'Grabada  normal
                    Me.UcSolicitudCompra1.conjunta = False
                    grabado = True
                End If
                If lestado = 1 And lconjunta = 1 Then  'Grabada conjunta
                    grabado = True
                    Me.UcSolicitudCompra1.conjunta = True
                End If

                If lestado = 3 And lconjunta = 0 Then  'Rechazada UACI normal
                    Me.UcSolicitudCompra1.conjunta = False
                    grabado = True
                End If

                If lestado = 3 And lconjunta = 1 Then  'Rechazada UACI conjunta
                    grabado = True
                    Me.UcSolicitudCompra1.conjunta = True
                End If

                If lestado = 4 And lconjunta = 0 Then 'Rechazada UFI normal
                    Me.UcSolicitudCompra1.conjunta = False
                    grabado = True
                End If

                If lestado = 4 And lconjunta = 1 Then  'Rechazada UFI conjunta
                    grabado = True
                    Me.UcSolicitudCompra1.conjunta = True
                End If

                If lestado = Nothing Then 'es nueva
                    Me.UcSolicitudCompra1.conjunta = False
                    nuevo = True
                End If

            End If

            If ldependencia <> Nothing Then
                If ldependencia <> Session.Item("IdDependencia") Then 'si dependencia es diferene a la de usuario que consulta
                    ConsultaNoUaci = False
                End If
            End If

        End If
    End Sub

    Public Property nuevo() As Boolean
        'solicitud nueva
        Get
            Return Me._Nuevo
        End Get
        Set(ByVal Value As Boolean)
            Me._Nuevo = Value
            Me.HabilitarNuevo(_Nuevo)
            Me.ucBarraNavegacion1.PermitirEditar = Value
            Me.ucBarraNavegacion1.PermitirGuardar = Value
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.lblRuta.Text = "Establecimientos -> Solicitud de compras"
        End Set
    End Property

    Public Property grabado() As Boolean
        'solicitud grabada
        Get
            Return Me._Grabado
        End Get
        Set(ByVal Value As Boolean)
            Me._Grabado = Value
            Me.HabilitarGrabado(_Grabado)
            Me.ucBarraNavegacion1.PermitirEditar = Value
            Me.ucBarraNavegacion1.PermitirGuardar = Value
            Me.ucBarraNavegacion1.PermitirImprimir = True
            Me.lblRuta.Text = "Establecimientos -> Solicitud de compras"
        End Set
    End Property

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
            Me.lblRuta.Text = "UACI -> Consultar Solicitud de compras"
        End Set
    End Property

    Public Property ConsultaNoUaci() As Boolean
        'consulta de solicitud 
        Get
            Return Me._Consulta
        End Get
        Set(ByVal Value As Boolean)

            Me._ConsultaNoUaci = Value
            Me.HabilitarConsulta(_ConsultaNoUaci)
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirImprimir = True
            Me.lblRuta.Text = "Establecimientos -> Solicitud de compras"
        End Set
    End Property

    Public Property Autorizar() As Boolean
        'Autoriza solicitud UFI
        Get
            Return Me._autorizar
        End Get
        Set(ByVal Value As Boolean)
            Me._autorizar = Value
            Me.HabilitarAutorizacion(_autorizar)
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirGuardar = True
            Me.ucBarraNavegacion1.PermitirImprimir = True
            Me.lblRuta.Text = "UFI -> Reserva de fondos"
        End Set
    End Property

    Private Sub BarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'al momento de cancelar
        MsgBox1.ShowConfirm("Con esta operacion, si no ha guardado los cambios realizados, los perdera, desea seguir con la operación ?", "C", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_CallBackOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Private Sub BarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        'al momento de guardar
        evaluaciones()
    End Sub

    Private Sub evaluacionesDetalle()

        'evaluaciones realizadas al agregar un producto en el detalle de la solicitud
        Dim sError As String
        Dim porcentajereal As Double
        Dim montoreal As Double

        montoreal = Me.mCompFuentes.CalcularMontoTotalFuenteSolicitud(CInt(Me.LblDoc.Text), Session.Item("IdEstablecimiento"))
        porcentajereal = Me.mCompFuentes.CalcularPorcentajeTotalFuenteSolicitud(CInt(Me.LblDoc.Text), Session.Item("IdEstablecimiento"))

        'valida existencia de entregas
        If Me.mCompEntregas.ValidarExistenciaEntregasSolicitud(CInt(Me.LblDoc.Text), CInt(Session.Item("IdEstablecimiento"))) Then
            'valida si existen productos para la solicitud
            If Me.mCompDetalle.ExisteSolicitudesAsociadasSolicitud(CInt(Me.LblDoc.Text), CInt(Session.Item("IdEstablecimiento"))) Then
                'valida si existe fuente de dinanciamiento
                If Me.mCompFuentes.ExisteFuentesAsociadasSolicitud(CInt(Me.LblDoc.Text), CInt(Session.Item("IdEstablecimiento"))) Then
                    'valida que el porcentaje no supere el 100%

                    If porcentajereal < 100 Then
                        MsgBox1.ShowAlert("La suma de los porcentajes de fuentes de financiamiento debe ser 100%", "error4", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Else

                        If porcentajereal > 100 Then
                            MsgBox1.ShowAlert("La suma de los porcentajes de fuentes de financiamiento debe ser 100%", "error5", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                        Else
                            'verifica que el monto de la participacion no difiera del monto total 
                            If montoreal = Me.LblMonto.Text Then
                                sError = Me.UcSolicitudCompra1.Actualizar()
                                If sError <> "" Then
                                    MsgBox1.ShowAlert("Error al intentar guardar la solicitud", "error2", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                                    Return
                                Else
                                    'grabacion exitosa
                                End If
                            Else
                                'error
                                MsgBox1.ShowAlert("El monto de participacion difiere del monto total de la solicitud de compras", "error5", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                            End If
                        End If
                    End If
                Else
                    MsgBox1.ShowAlert("Debe agregar fuente de financiamiento a la solicitud", "error3", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                End If

            Else
                MsgBox1.ShowAlert("Debe agregar productos a la solicitud", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If
        Else
            MsgBox1.ShowAlert("Debe detallar entregas y plazos de entregas", "error6", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Private Sub evaluaciones()
        'evaluaciones a realizar al grabar encabezado de solicitud
        Dim sError As String
        Dim porcentajereal As Double
        Dim montoreal As Double

        montoreal = Me.mCompFuentes.CalcularMontoTotalFuenteSolicitud(CInt(Me.LblDoc.Text), Session.Item("IdEstablecimiento"))
        porcentajereal = Me.mCompFuentes.CalcularPorcentajeTotalFuenteSolicitud(CInt(Me.LblDoc.Text), Session.Item("IdEstablecimiento"))

        'validar existan entregas
        If Me.mCompEntregas.ValidarExistenciaEntregasSolicitud(CInt(Me.LblDoc.Text), CInt(Session.Item("IdEstablecimiento"))) Then
            'validar que existan productos para la solicitud
            If Me.mCompDetalle.ExisteSolicitudesAsociadasSolicitud(CInt(Me.LblDoc.Text), CInt(Session.Item("IdEstablecimiento"))) Then
                'validar que existan fuentes para la solicitud
                If Me.mCompFuentes.ExisteFuentesAsociadasSolicitud(CInt(Me.LblDoc.Text), CInt(Session.Item("IdEstablecimiento"))) Then

                    'validar que no supere el 100% del porcentaje de las fuentes de la solicitud
                    If porcentajereal < 100 Then
                        MsgBox1.ShowAlert("La suma de los porcentajes de fuentes de financiamiento debe ser 100%", "error4", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Else
                        If porcentajereal > 100 Then
                            MsgBox1.ShowAlert("La suma de los porcentajes de fuentes de financiamiento debe ser 100%", "error5", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                        Else
                            'validar el monto de participacion sea igual al monto total de la solicitud
                            If montoreal = Me.LblMonto.Text Then
                                sError = Me.UcSolicitudCompra1.Actualizar()
                                If sError <> "" Then
                                    MsgBox1.ShowAlert("Error al intentar guardar la solicitud", "error2", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                                    Return
                                Else
                                    MsgBox1.ShowAlert("Los cambios a la solicitud de compra han sido guardado satisfactoriamente", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction, AlertType.Exclamation)
                                End If
                            Else
                                'error
                                MsgBox1.ShowAlert("El monto de participacion difiere del monto total de la solicitud de compras", "error5", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                            End If
                        End If
                    End If
                Else
                    MsgBox1.ShowAlert("Debe agregar fuente de financiamiento a la solicitud", "error3", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                End If

            Else
                MsgBox1.ShowAlert("Debe agregar productos a la solicitud", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If
        Else
            MsgBox1.ShowAlert("Debe detallar entregas y plazos de entregas", "error6", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Private Sub HabilitarConsulta(ByVal edicion As Boolean)
        'habilita los campos para la consulta de la UACI
        Me.UcSolicitudCompra1.Consulta = edicion
    End Sub

    Private Sub HabilitarAutorizacion(ByVal edicion As Boolean)
        'habilita los campos para la autorizacion de UFI
        Me.UcSolicitudCompra1.Autoriza = edicion
    End Sub

    Private Sub HabilitarNuevo(ByVal edicion As Boolean)
        'habilita par una nueva solicitud
        Me.UcSolicitudCompra1.Nuevo = edicion
    End Sub

    Private Sub HabilitarGrabado(ByVal edicion As Boolean)
        'habilita para una solicitud grabada
        Me.UcSolicitudCompra1.grabado = edicion
        If edicion Then
            Me.UcSolicitudCompra1.SUMINISTRO = lsuministro
        End If
    End Sub

    Protected Sub BarraNavegacion1_Imprimir(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Imprimir
        'al momento de seleccionar imprimir
        Session.Item("idDocRep") = Me.LblDoc.Text
        Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptSolicitudCompra.aspx?id=" & Me.LblDoc.Text & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub UcSolicitudCompra1_EliminoDetalle() Handles UcSolicitudCompra1.EliminoDetalle
        'al momento de eliminar u producto del detalle
        evaluacionesDetalle()
    End Sub

    Protected Sub UcSolicitudCompra1_EliminoFuente() Handles UcSolicitudCompra1.EliminoFuente
        'al momento de eliminar una fuente del detalle
        evaluacionesDetalle()
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
            Select Case Session.Item("opc").ToString
                Case Is = "1" 'consulta UACI
                    Response.Redirect("~/UACI/FrmConsultarSolicitudUaci.aspx")
                Case Is = "2" 'Autorizacion UFI
                    Response.Redirect("~/UACI/FrmAutorizarSolicitudesCompra.aspx")
                Case Is = "3" 'Solicitud
                    Response.Redirect("~/ESTABLECIMIENTOS/FrmMantSolicitudCompra.aspx")
            End Select
        End If

        If e.Key = "C" Then
            Select Case Session.Item("opc").ToString
                Case Is = "1" 'consulta UACI
                    Response.Redirect("~/UACI/FrmConsultarSolicitudUaci.aspx")
                Case Is = "2" 'Autorizacion UFI
                    Response.Redirect("~/UACI/FrmAutorizarSolicitudesCompra.aspx")
                Case Is = "3" 'Solicitud
                    Response.Redirect("~/ESTABLECIMIENTOS/FrmMantSolicitudCompra.aspx")
            End Select
        End If
    End Sub

    Protected Sub UcSolicitudCompra1_GuardoDetalle() Handles UcSolicitudCompra1.GuardoDetalle
        'al momento de guardar cambios al detalle de productos de la solicitud
        evaluacionesDetalle()
    End Sub

    Protected Sub UcSolicitudCompra1_GuardoFuente() Handles UcSolicitudCompra1.GuardoFuente
        'al momento de guardar fuente de financiamiento
        evaluacionesDetalle()
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
