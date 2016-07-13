'CALCULO DE NECESIDADES ESTABLECIMIENTO
'CU-ESTA0003
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la creacion y mantenimiento de programas de compra
'la region o sibasi realiza progrma de compras pára establecimientos del nivel 1
'estabglecimientos hospitales nivel 2 y 3 hacen programa de compras
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports Cooperator.Framework.Web.Controls

Partial Class FrmDetaMantNecesidadEstablecimiento
    Inherits System.Web.UI.Page
    'DECLARAR E INICIALIZAR VARIABLES
    Private _Consulta As Boolean = False
    Private _Nuevo As Boolean = False
    Private _Grabado As Boolean = False
    Private mComponente As New cNECESIDADESTABLECIMIENTOS
    Private mCompDetalle As New cDETALLENECESIDADESTABLECIMIENTOS
    Private mCompDetalleNecesidad As New cDETALLENECESIDADESTABLECIMIENTOS
    Private mCompObservaciones As New cOBSERVACIONDETALLENECESIDAD

    Dim lestado As Int32

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'AL INICIALIZAR PAGINA

        Me.Master.ControlMenu.Visible = False 'oculta menu

        If Not Page.IsPostBack Then 'la primer vez que carga
            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Dim lId As Int32 = Request.QueryString("id") 'identificador del programa de compra
            Me.LblDoc.Text = lId
            Me.UcNecesidadesEstablecimientos1.CODIGOENCABEZADODOCUMENTO = lId
            lestado = Request.QueryString("estado")
            Me.IbttObservaciones.Visible = False

            If lestado > 1 Then 'diferente de grabado
                If lestado = 3 Then 'Revisado
                    grabado(True, 3) = True
                    If mCompObservaciones.ExistenObservacionesNecesidad(Session.Item("IdEstablecimiento"), Me.LblDoc.Text) Then
                        Me.IbttObservaciones.Visible = True
                    Else
                        Me.IbttObservaciones.Visible = False
                    End If
                Else
                    grabado(False, lestado) = False
                    Consulta = False
                End If
            End If

            If lestado = 1 Then 'grbado
                grabado(False, 1) = True
            End If

            If lestado = Nothing Then 'es nuevo
                nuevo = True
            End If
        End If
    End Sub

    Public Property nuevo() As Boolean
        'nuevo programa de compras
        Get
            Return Me._Nuevo
        End Get
        Set(ByVal Value As Boolean)

            Me._Nuevo = Value
            Me.HabilitarNuevo(_Nuevo)
            Me.ucBarraNavegacion1.PermitirEditar = Value
            Me.ucBarraNavegacion1.PermitirGuardar = Value
            Me.ucBarraNavegacion1.PermitirImprimir = False

        End Set
    End Property
    Public Property grabado(ByVal permitirVerObservaciones As Boolean, Optional ByVal idestado As Int32 = 0) As Boolean
        'programa de compras grabado
        Get
            Return Me._Grabado
        End Get
        Set(ByVal Value As Boolean)

            Me._Grabado = Value
            Me.HabilitarGrabado(_Grabado, permitirVerObservaciones, idestado)
            Me.ucBarraNavegacion1.PermitirEditar = Value
            Me.ucBarraNavegacion1.PermitirGuardar = Value
            Me.ucBarraNavegacion1.PermitirImprimir = True

        End Set
    End Property
    Public Property Consulta() As Boolean
        'consulta de programas de compras
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
        ' al cancelar
        MsgBox1.ShowConfirm("Con esta operacion, si no ha guardado los cambios realizados, los perdera, desea seguir con la operación ?", "C", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Private Sub BarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
        'al guardar
        evaluaciones()
    End Sub

    Private Sub evaluacionesDetalle()
        'evaluaciones al agregar producto al detalle
        Dim sError As String
        'Dim montoAjustado, PresupuestoAsignado As Double
        If Validaciones() Then
            sError = Me.UcNecesidadesEstablecimientos1.Actualizar()

            If sError <> "" Then
                Return
            Else
                'grabado exitoso
            End If
        End If
    End Sub

    Private Sub evaluaciones()
        'evaluaciones al guardar encabezado de programa de compras
        Dim sError As String
        If Validaciones() Then
            sError = Me.UcNecesidadesEstablecimientos1.Actualizar()
            If sError <> "" Then
                Return
            Else
                MsgBox1.ShowAlert("Los cambios al programa de compra han sido guardado satisfactoriamente", "B", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, AlertType.Exclamation)
            End If
        End If
    End Sub

    Private Function Validaciones() As Boolean
        'verificar que tenga productos en el detalle
        If Me.mCompDetalle.ExisteProductosAsociadosNecesidad(CInt(Me.LblDoc.Text), CInt(Session.Item("IdEstablecimiento"))) Then
            Return True
        Else
            MsgBox1.ShowAlert("Debe agregar productos al programa de compras", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return False
        End If
    End Function

    Private Sub HabilitarConsulta(ByVal edicion As Boolean)
        'habilita programa para consulta
        Me.UcNecesidadesEstablecimientos1.Consulta = edicion
    End Sub

    Private Sub HabilitarNuevo(ByVal edicion As Boolean)
        'habilita programa para nuevo
        Me.UcNecesidadesEstablecimientos1.Nuevo = edicion
    End Sub

    Private Sub HabilitarGrabado(ByVal edicion As Boolean, ByVal permitirVerObservaciones As Boolean, Optional ByVal idestado As Int32 = 0)
        'habilita el programa para grabado
        Me.UcNecesidadesEstablecimientos1.grabado(permitirVerObservaciones, idestado) = edicion
    End Sub

    Protected Sub BarraNavegacion1_Imprimir(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Imprimir
        'al momento de imprimir programa
        Session.Item("idDocRep") = Me.LblDoc.Text
        Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptNecesidades.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        'al seleccionar ok en mensajes desplegados
        If e.Key = "B" Then
            ' MsgBox1.ShowConfirm("desea salir de la opción?", "D", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        End If

        If e.Key = "error5" Then
            Response.Redirect("~/ESTABLECIMIENTOS/FrmMantNecesidadesEstablecimientos.aspx")
        End If

    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        'al seleccionar yes en mensajes desplegaods
        If e.Key = "D" Then
            Response.Redirect("~/ESTABLECIMIENTOS/FrmMantNecesidadesEstablecimientos.aspx")
        End If
        If e.Key = "C" Then
            Response.Redirect("~/ESTABLECIMIENTOS/FrmMantNecesidadesEstablecimientos.aspx")
        End If
    End Sub

    Protected Sub UcNecesidadesEstablecimientos1_EliminoDetalle() Handles UcNecesidadesEstablecimientos1.EliminoDetalle
        'al eliminar producto del detalle
        evaluacionesDetalle()
    End Sub

    Protected Sub UcNecesidadesEstablecimientos1_ErrorEvent(ByVal errorMessage As String) Handles UcNecesidadesEstablecimientos1.ErrorEvent
        'evento error
        MsgBox1.ShowAlert(errorMessage, "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub

    Protected Sub UcNecesidadesEstablecimientos1_GuardoDetalle() Handles UcNecesidadesEstablecimientos1.GuardoDetalle
        'al guardar detalle
        evaluacionesDetalle()
    End Sub

    Protected Sub UcNecesidadesEstablecimientos1_MontoSolicitud1(ByVal MontoSolicitud As Double, ByVal PresupuestoSolicitud As Double) Handles UcNecesidadesEstablecimientos1.MontoSolicitud
        'al calcular monto de la solicitud
        Me.LblMonto.Text = MontoSolicitud
        Me.LblPresupuesto.Text = PresupuestoSolicitud
    End Sub

    Protected Sub UcNecesidadesEstablecimientos1_NumeroSolicitud(ByVal NumSolicitud As String, ByVal Presupuesto As Double, ByVal MONTO As Double) Handles UcNecesidadesEstablecimientos1.NumeroSolicitud
        'al asignar numero de programa de compra
        Me.LblDoc.Text = NumSolicitud
        Me.LblMonto.Text = MONTO
        Me.LblPresupuesto.Text = Presupuesto
    End Sub

    Protected Sub UcNecesidadesEstablecimientos1_SobrepasoPropuesta() Handles UcNecesidadesEstablecimientos1.SobrepasoPropuesta
        'al sobrepasar la propuesta
        MsgBox1.ShowAlert("Ha sobrepasado numero de propuestas del periodo", "error5", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbttObservaciones.Click
        'al seleccionar imprimir observaciones de las necesidades
        Session.Item("idDocRep") = Me.LblDoc.Text
        Session.Item("idEstRep") = Session.Item("IdEstablecimiento")
        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptObservacionesNecesidades.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

End Class
