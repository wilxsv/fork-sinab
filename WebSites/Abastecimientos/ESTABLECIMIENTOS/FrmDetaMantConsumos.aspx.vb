'INGRESO DE CONSUMO, DEMANDA INSATISFECHA Y CONSUMO
'CU-ESTA0002
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la creacion y mantenimiento de consumos
'Establecimientos del nivel 1 ingresan consumo, demanda insatifecha y existencia mensual
'establecimientos del nivel 2 y 3 consumo es diario y se realiza por medio de interfaz SIM
'la existencia no es ingresada para estos establecimientos
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports Cooperator.Framework.Web.Controls

Partial Class FrmDetaMantConsumos
    Inherits System.Web.UI.Page
    'Private mComponente As New cCONSUMOS
    'Private mCompDetalle As New cDETALLECONSUMOS
    'Private _Consulta As Boolean = False
    'Private _Nuevo As Boolean = False
    'Private _Grabado As Boolean = False


    'Dim lestado As Int32
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'al cargar pagina
    '    Me.Master.ControlMenu.Visible = False 'ocutar menu

    '    If Not Page.IsPostBack Then ' al cargar la primera vez
    '        Me.ucBarraNavegacion1.Navegacion = False
    '        Me.ucBarraNavegacion1.PermitirAgregar = False
    '        Me.ucBarraNavegacion1.PermitirEditar = True
    '        Me.ucBarraNavegacion1.PermitirConsultar = False
    '        Me.ucBarraNavegacion1.HabilitarEdicion(True)
    '        Me.ucBarraNavegacion1.PermitirImprimir = True

    '        Dim lId As Int32 = Request.QueryString("id") 'identificador de consumo
    '        lestado = Request.QueryString("estado") 'identificador de estado
    '        Me.UcConsumo1.CODIGOENCABEZADODOCUMENTO = lId
    '        Me.LblDoc.Text = lId

    '        If lestado > 1 Then 'diferente de grabado
    '            Consulta = False

    '        Else
    '            If lestado = 1 Then 'grabado
    '                grabado = True

    '            Else
    '                If lestado = Nothing Then 'nuevo
    '                    nuevo = True

    '                End If
    '            End If
    '        End If

    '    End If
    'End Sub

    'Public Property nuevo() As Boolean
    '    'nuevo consumo
    '    Get
    '        Return Me._Nuevo
    '    End Get
    '    Set(ByVal Value As Boolean)

    '        Me._Nuevo = Value
    '        Me.HabilitarNuevo(_Nuevo)
    '        Me.ucBarraNavegacion1.PermitirEditar = Value
    '        Me.ucBarraNavegacion1.PermitirGuardar = Value
    '        Me.ucBarraNavegacion1.PermitirImprimir = False

    '    End Set
    'End Property
    'Public Property grabado() As Boolean
    '    'consumo grabado
    '    Get
    '        Return Me._Grabado
    '    End Get
    '    Set(ByVal Value As Boolean)

    '        Me._Grabado = Value
    '        Me.HabilitarGrabado(_Grabado)
    '        Me.ucBarraNavegacion1.PermitirEditar = Value
    '        Me.ucBarraNavegacion1.PermitirGuardar = Value
    '        Me.ucBarraNavegacion1.PermitirImprimir = True
    '    End Set
    'End Property
    'Public Property Consulta() As Boolean
    '    'consulta de consumo
    '    Get
    '        Return Me._Consulta
    '    End Get
    '    Set(ByVal Value As Boolean)

    '        Me._Consulta = Value
    '        Me.HabilitarConsulta(_Consulta)
    '        Me.ucBarraNavegacion1.PermitirEditar = True
    '        Me.ucBarraNavegacion1.PermitirGuardar = False
    '        Me.ucBarraNavegacion1.PermitirImprimir = True

    '    End Set
    'End Property

    'Private Sub BarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
    '    'al cancelar
    '    MsgBox1.ShowConfirm("Con esta operacion, si no ha guardado los cambios realizados, los perdera, desea seguir con la operación ?", "C", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_CallBackOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)

    'End Sub

    'Private Sub BarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
    '    'al guardar
    '    evaluaciones()
    'End Sub

    'Private Sub HabilitarConsulta(ByVal edicion As Boolean)
    '    'Habilita consumo para consulta
    '    Me.UcConsumo1.Consulta = edicion
    'End Sub

    'Private Sub HabilitarNuevo(ByVal edicion As Boolean)
    '    'habilita consumo para nuevo
    '    Me.UcConsumo1.Nuevo = edicion
    'End Sub

    'Private Sub HabilitarGrabado(ByVal edicion As Boolean)
    '    'habilita consumo para estado grabado
    '    Me.UcConsumo1.grabado = edicion
    'End Sub

    'Protected Sub BarraNavegacion1_Imprimir(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Imprimir
    '    'al imprimir consumo
    '    Session.Item("idDocRep") = Me.LblDoc.Text
    '    Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptConsumo.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    'End Sub

    'Private Sub evaluacionesDetalle()
    '    'evaluaciones al guardar detalle de consumo
    '    Dim sError As String
    '    'verifica existencias en el detalle del consumo
    '    If mCompDetalle.ExisteProductosAsociadosConsumo(CInt(Me.LblDoc.Text), CInt(Session.Item("IdEstablecimiento"))) Then

    '        sError = Me.UcConsumo1.Actualizar()
    '        If sError <> "" Then 'error al guardar
    '            MsgBox1.ShowAlert("Error al intentar guardar el consumo", "error2", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '            Return
    '        Else
    '            'Grabado exitoso

    '        End If

    '    Else
    '        MsgBox1.ShowAlert("Debe agregar productos al consumo", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

    '    End If

    'End Sub

    'Private Sub evaluaciones()
    '    Dim sError As String
    '    'evaluaciones al guardar encabezado de consumo

    '    'verifica existan productos en el detalle
    '    If mCompDetalle.ExisteProductosAsociadosConsumo(CInt(Me.LblDoc.Text), CInt(Session.Item("IdEstablecimiento"))) Then

    '        sError = Me.UcConsumo1.Actualizar()
    '        If sError <> "" Then 'error al guardar
    '            MsgBox1.ShowAlert("Error al intentar guardar el consumo", "error2", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '            Return
    '        Else
    '            MsgBox1.ShowAlert("Los cambios al consumo han sido guardado satisfactoriamente", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction, AlertType.Exclamation)
    '        End If

    '    Else
    '        MsgBox1.ShowAlert("Debe agregar productos al consumo", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

    '    End If

    'End Sub

    'Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
    '    'al escoger ok en los mensajes mostrados
    '    If e.Key = "B" Then
    '        MsgBox1.ShowConfirm("desea salir de la opción?", "D", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    '    End If
    '    If e.Key = "errorx" Then
    '        Response.Redirect("~/ESTABLECIMIENTOS/FrmMantConsumos.aspx")
    '    End If

    'End Sub

    'Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
    '    'al escoger yes en los mensajes desplegados
    '    If e.Key = "D" Then
    '        Response.Redirect("~/ESTABLECIMIENTOS/FrmMantConsumos.aspx")
    '    End If
    '    If e.Key = "C" Then
    '        Response.Redirect("~/ESTABLECIMIENTOS/FrmMantConsumos.aspx")
    '    End If
    'End Sub

    'Protected Sub UcConsumo1_EliminoDetalle() Handles UcConsumo1.EliminoDetalle
    '    'al elimianr un producto del detalle
    '    evaluacionesDetalle()
    'End Sub

    'Protected Sub UcConsumo1_ErrorEvent(ByVal errorMessage As String) Handles UcConsumo1.ErrorEvent
    '    'evento error
    '    MsgBox1.ShowAlert(errorMessage, "errorx", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
    'End Sub

    'Protected Sub UcConsumo1_GuardoDetalle() Handles UcConsumo1.GuardoDetalle
    '    'al guardar detalle
    '    evaluacionesDetalle()
    'End Sub

    'Protected Sub UcConsumo1_NumeroConsumo(ByVal NumConsumo As String) Handles UcConsumo1.NumeroConsumo
    '    'al asignar numero al consumo
    '    Me.LblDoc.Text = NumConsumo
    'End Sub

End Class
