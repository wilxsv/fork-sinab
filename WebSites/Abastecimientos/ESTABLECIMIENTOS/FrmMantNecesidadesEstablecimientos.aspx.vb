'CALCULO DE NECESIDADES ESTABLECIMIENTO
'CU-ESTA0003
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para la creacion y mantenimiento de programas de compra
'la region o sibasi realiza progrma de compras pára establecimientos del nivel 1
'estabglecimientos hospitales nivel 2 y 3 hacen programa de compras
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmMantNecesidadesEstablecimientos
    Inherits System.Web.UI.Page
    'Derclaracion e inicializacion de variables
    Private mComponente As New cNECESIDADESTABLECIMIENTOS
    Private mEntidad As New NECESIDADESTABLECIMIENTOS
    Private mEntDetalleNecesidad As New DETALLENECESIDADESTABLECIMIENTOS
    Private mCompDetalleNecesidad As New cDETALLENECESIDADESTABLECIMIENTOS
    Private mCompObservaciones As New cOBSERVACIONDETALLENECESIDAD

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al momento de cargar la  pagina
        Me.Master.ControlMenu.Visible = False 'oculta menu

        If Not Page.IsPostBack Then 'al cargar la primera vez
            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = False
            CargarDatos()
        End If
    End Sub

    Private Sub CargarDatos()
        'carga de datos a mostrar en grid
        Dim lNECESIDADESTABLECIMIENTOS As listaNECESIDADESTABLECIMIENTOS
        
        lNECESIDADESTABLECIMIENTOS = Me.mComponente.ObtenerLista(Session.Item("IdEstablecimiento"))
        Me.dgLista.DataSource = lNECESIDADESTABLECIMIENTOS
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.CurrentPageIndex = 0
            Me.dgLista.DataBind()
        End Try


    End Sub

    Protected Sub dgLista_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.EditCommand
        ' al momento de enviar un programa de compras
        'cambia a estado de enviado

        mEntidad.IDNECESIDAD = CLng(CType(Me.dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton2"), LinkButton).ToolTip)
        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        Me.mComponente.ObtenerNECESIDADESTABLECIMIENTOS(mEntidad)
        mEntidad.IDESTADO = 2 'enviado
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mComponente.ActualizarNECESIDADESTABLECIMIENTOS(mEntidad)
        Me.CargarDatos()
        MsgBox1.ShowAlert("Su programa de compras fue enviado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)


    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        'al cargar los datos del grid

        Dim mesInicio As String
        Dim añoInicio As String
        Dim mesFin As String
        Dim añoFin As String

        If e.Item.ItemType = ListItemType.AlternatingItem Or _
           e.Item.ItemType = ListItemType.Item Then
            Dim a As LinkButton = CType(e.Item.FindControl("LinkButton1"), LinkButton) 'eliminar
            a.Attributes.Add("onclick", "if(!window.confirm('¿Esta seguro de Eliminar el programa?')){return false;}")

            Dim b As LinkButton = CType(e.Item.FindControl("LinkButton2"), LinkButton) 'enviar
            b.Attributes.Add("onclick", "if(!window.confirm('¿Esta seguro de Enviar programa de compra?')){return false;}")

            'Mostra envio y eliminacion
            Dim montoAjustado, PresupuestoAsignado As Double


            montoAjustado = mCompDetalleNecesidad.CalcularMontoAjustadoNecesidad(CType(e.Item.FindControl("ID"), Label).Text, Session.Item("IdEstablecimiento"))
            PresupuestoAsignado = mComponente.ObtenerPresupuestoNecesidad(Session.Item("IdEstablecimiento"), CType(e.Item.FindControl("ID"), Label).Text)


            ' validaciones de necesidades existentes para verificar si estan compleatas o no y asi permitir el poder enviar

            'verifica que contenga detalle de productos
            If mCompDetalleNecesidad.ExisteProductosAsociadosNecesidad(CType(e.Item.FindControl("ID"), Label).Text, Session.Item("IdEstablecimiento")) Then
                CType(e.Item.FindControl("lblObservacion"), Label).Text = "COMPLETA"
            Else
                CType(e.Item.FindControl("lblObservacion"), Label).Text = "INCOMPLETA"
            End If
            'verifica que el monto ajustado no sobrepase presupuesto asignado

            If montoAjustado > PresupuestoAsignado Then
                CType(e.Item.FindControl("lblObservacion"), Label).Text = "SOBREPASA PRESUPUESTO"
                CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = True 'eliminar
                CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = False 'enviar
                CType(e.Item.FindControl("lblObservacion"), Label).Visible = True
            End If
            'verifica si existen observaciones para la necesidad
            If mCompObservaciones.ExistenObservacionesNecesidad(Session.Item("IdEstablecimiento"), CType(e.Item.FindControl("ID"), Label).Text) Then
                CType(e.Item.FindControl("lblObservacion"), Label).Text = "OBSERVACIONES"
                CType(e.Item.FindControl("lblObservacion"), Label).Visible = True
            End If
            'verifica si esta grabada y completa
            If CType(e.Item.FindControl("Label_IdEstado"), Label).Text = 1 And CType(e.Item.FindControl("lblObservacion"), Label).Text = "COMPLETA" Then
                CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = True 'elimianr
                CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = True 'enviar
                CType(e.Item.FindControl("lblObservacion"), Label).Visible = False
            End If
            'verifica si esta grabada e incompleta
            If CType(e.Item.FindControl("Label_IdEstado"), Label).Text = 1 And CType(e.Item.FindControl("lblObservacion"), Label).Text = "INCOMPLETA" Then
                CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = True 'eliminar
                CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = False 'enviar
                CType(e.Item.FindControl("lblObservacion"), Label).Visible = True
            End If

            'verifica si el estado es diferente de grabado e incompleta
            If CType(e.Item.FindControl("Label_IdEstado"), Label).Text > 1 And CType(e.Item.FindControl("lblObservacion"), Label).Text = "INCOMPLETA" Then
                CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = False 'eliminar
                CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = False 'enviar
                CType(e.Item.FindControl("lblObservacion"), Label).Visible = True
            End If
            'verifica si el estado es de enviado y con observaciones
            If CType(e.Item.FindControl("Label_IdEstado"), Label).Text = 2 And CType(e.Item.FindControl("lblObservacion"), Label).Text = "OBSERVACIONES" Then
                CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = False 'eliminar
                CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = False 'enviar
                CType(e.Item.FindControl("lblObservacion"), Label).Visible = True
            End If
            'verifica si el estado es diferente de grabado y completa
            If CType(e.Item.FindControl("Label_IdEstado"), Label).Text > 1 And CType(e.Item.FindControl("lblObservacion"), Label).Text = "COMPLETA" Then
                CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = False 'elimianr

                If CType(e.Item.FindControl("Label_IdEstado"), Label).Text = 3 Then 'rechazada UACI
                    CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = True 'enviar
                Else
                    CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = False 'enviar
                End If
                CType(e.Item.FindControl("lblObservacion"), Label).Visible = False
            End If
            'verifica que este rechazada UACI y con observaciones
            If CType(e.Item.FindControl("Label_IdEstado"), Label).Text = 3 And CType(e.Item.FindControl("lblObservacion"), Label).Text = "OBSERVACIONES" Then
                CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = False 'elimianr
                CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = True 'enviar
            End If

            '-----

            'carga estado de necesidades
            Dim mDdlESTADOSNECESIDADES As ABASTECIMIENTOS.WUC.ddlESTADOSNECESIDADES
            mDdlESTADOSNECESIDADES = e.Item.FindControl("DdlESTADOSNECESIDADES1")
            mDdlESTADOSNECESIDADES.Recuperar()
            Dim mESTADOSCONSUMOSNECESIDAES As String
            mESTADOSCONSUMOSNECESIDAES = CType(e.Item.FindControl("Label_IdEstado"), Label).Text
            If mESTADOSCONSUMOSNECESIDAES <> "" Then
                mDdlESTADOSNECESIDADES.SelectedValue = mESTADOSCONSUMOSNECESIDAES
            End If
            CType(e.Item.FindControl("TxtEstado"), TextBox).Text = CType(e.Item.FindControl("DdlESTADOSNECESIDADES1"), DropDownList).SelectedItem.Text
            'carga empleados

            Dim mDdlEMPLEADO As ABASTECIMIENTOS.WUC.ddlEMPLEADOS
            mDdlEMPLEADO = e.Item.FindControl("DdlEMPLEADOS1")
            mDdlEMPLEADO.Recuperar()
            Dim mEMPLEADOS As String
            mEMPLEADOS = CType(e.Item.FindControl("Lbl_Empleado"), Label).Text
            If mEMPLEADOS <> "" Then
                mDdlEMPLEADO.SelectedValue = mEMPLEADOS
            End If
            CType(e.Item.FindControl("TxtEmpleado"), TextBox).Text = CType(e.Item.FindControl("DdlEMPLEADOS1"), DropDownList).SelectedItem.Text

            'carga de periodos de inicio y fin
            mesInicio = CType(e.Item.FindControl("DdlMes"), DropDownList).SelectedItem.Text
            añoInicio = CType(e.Item.FindControl("DdlAño"), DropDownList).SelectedItem.Text
            CType(e.Item.FindControl("TxtMesConsumo"), TextBox).Text = mesInicio & "/" & añoInicio

            mesFin = CType(e.Item.FindControl("DdlMes2"), DropDownList).SelectedItem.Text
            añoFin = CType(e.Item.FindControl("DdlAño2"), DropDownList).SelectedItem.Text
            CType(e.Item.FindControl("TxtMesConsumo2"), TextBox).Text = mesFin & "/" & añoFin

            'carga el numero de propuesta
            CType(e.Item.FindControl("TxtProp"), TextBox).Text = CType(e.Item.FindControl("ddlpropuesta"), DropDownList).SelectedItem.Text

        End If
    End Sub

    Private Sub dgLista_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        'al borrar un registro del grid
        If CLng(CType(e.Item.FindControl("Label_IdEstado"), Label).Text) = 1 Then 'grabado

            Me.mCompDetalleNecesidad.EliminarDETALLES(CLng(CType(Me.dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton1"), LinkButton).ToolTip), Session.Item("IdEstablecimiento"))
            Me.mComponente.EliminarNECESIDADESTABLECIMIENTOS(Session.Item("IdEstablecimiento"), CLng(CType(Me.dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton1"), LinkButton).ToolTip))
            Me.dgLista.CurrentPageIndex = 0
            Me.CargarDatos()
            MsgBox1.ShowAlert("Su programa de compras fue eliminado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            Response.Write("<script language='JavaScript'>alert('No se puede eliminar programa porque ya esta enviado')</script>")
        End If
    End Sub

    Private Sub BarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        'evento agregar de barra de navegacion
        Response.Redirect("~/ESTABLECIMIENTOS/FrmDetaMantNecesidadEstablecimiento.aspx?id=0")
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        'al enviar a pagina principal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista.PageIndexChanged
        'al cambiar numero de indice de pagina del grid
        Me.dgLista.CurrentPageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

End Class
