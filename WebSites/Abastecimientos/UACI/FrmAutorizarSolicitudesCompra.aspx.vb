'CU-UFI0001 AUTORIZAR SOLICITUDES DE COMPRA UFI
'Ing. Yessenia Pennelope Henriquez Duran
'permite la autorizacion de la UFI
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class FrmAutorizarSolicitudesCompra
    Inherits System.Web.UI.Page

    'declarar e inicalizar variables
    Private mComponente As New cSOLICITUDES
    Private mEntidad As New SOLICITUDES
    Private mEntHistoricoEstados As New HISTORICOESTADOSSOLICITUDES
    Private mCompHistoricoEstados As New cHISTORICOESTADOSSOLICITUDES
    Private mCompEstados As New cESTADOS
    Private mCompDependencia As New cDEPENDENCIAS
    Private mCompFuenteFinancSol As New cFUENTEFINANCIAMIENTOSOLICITUDES

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar pagina

        If Not Page.IsPostBack Then 'al cargar por primera vez

            Me.Master.ControlMenu.Visible = False 'oculta menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            CargarDatos()
            Me.pnlObservaciones.Visible = False
        End If
    End Sub

    Private Sub CargarDatos()
        'carga el grid de solicitudes en estado enviado UFI
        Dim textoBusqueda As String
        Dim criterioBusqueda As String
        Dim operadorBusqueda As String

        Dim lSOLICITUDES As listaSOLICITUDES


        textoBusqueda = "5" 'enviado UFI
        criterioBusqueda = "IDESTADO"
        operadorBusqueda = "="

        lSOLICITUDES = Me.mComponente.Filtrar(textoBusqueda, criterioBusqueda, operadorBusqueda, Session.Item("IdEstablecimiento"))
        Me.dgLista.DataSource = lSOLICITUDES

        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.CurrentPageIndex = 0
            Me.dgLista.DataBind()
        End Try


    End Sub

    Protected Sub dgLista_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.EditCommand
        'al aprobar solicitud cambia de estado a aprobado UFI
        If CLng(CType(e.Item.FindControl("Label_IdEstado"), Label).Text) = 5 Then 'enviado UFI

            MostrarObservaciones(CLng(CType(e.Item.FindControl("lbld"), Label).Text), 1, CStr(CType(e.Item.FindControl("lblnum"), Label).Text))

        Else
            'ya esta enviada
        End If
    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        'al cargar los registros del grid

        If e.Item.ItemType = ListItemType.AlternatingItem Or _
           e.Item.ItemType = ListItemType.Item Then

            Dim a As LinkButton = CType(e.Item.FindControl("LinkButton1"), LinkButton) 'rechazar solicitud
            a.Attributes.Add("onclick", "if(!window.confirm('¿Esta seguro de RechazarSolicitud?')){return false;}")

            Dim b As LinkButton = CType(e.Item.FindControl("LinkButton2"), LinkButton) 'aprovar solicitud
            b.Attributes.Add("onclick", "if(!window.confirm('¿Esta seguro de Aprobar Fondos?')){return false;}")
            'carga los estados de la solicitud
            CType(e.Item.FindControl("ddlEstado"), DropDownList).DataTextField = "DESCRIPCION"
            CType(e.Item.FindControl("ddlEstado"), DropDownList).DataValueField = "IDESTADO"
            CType(e.Item.FindControl("ddlEstado"), DropDownList).DataSource = (New cESTADOS).ObtenerLista()
            CType(e.Item.FindControl("ddlEstado"), DropDownList).DataBind()
            CType(e.Item.FindControl("ddlEstado"), DropDownList).SelectedValue = CLng(CType(e.Item.FindControl("Label_IdEstado"), Label).Text)
            CType(e.Item.FindControl("TxtEstado"), TextBox).Text = CType(e.Item.FindControl("ddlEstado"), DropDownList).SelectedItem.Text


            CType(e.Item.FindControl("DdlDEPENDENCIAS1"), DropDownList).DataTextField = "NOMBRE"
            CType(e.Item.FindControl("DdlDEPENDENCIAS1"), DropDownList).DataValueField = "IDDEPENDENCIA"
            CType(e.Item.FindControl("DdlDEPENDENCIAS1"), DropDownList).DataSource = (New cDEPENDENCIAS).ObtenerListaOrden(1)
            CType(e.Item.FindControl("DdlDEPENDENCIAS1"), DropDownList).DataBind()
            CType(e.Item.FindControl("DdlDEPENDENCIAS1"), DropDownList).SelectedValue = CInt(CType(e.Item.FindControl("lbldep"), Label).Text)
            CType(e.Item.FindControl("lblDependencia"), Label).Text = CType(e.Item.FindControl("DdlDEPENDENCIAS1"), DropDownList).SelectedItem.Text


            If mComponente.ValidarCertificadoFondosNulosSolicitud(Session.Item("IdEstablecimiento"), CType(e.Item.FindControl("lbld"), Label).Text) Then
                CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = True 'rechazar
                CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = False 'aprobar
                CType(e.Item.FindControl("lblObservaciones"), Label).Visible = True 'observaciones
                CType(e.Item.FindControl("lblObservaciones"), Label).Text = "Falta Certificacion" 'observaciones
            Else
                CType(e.Item.FindControl("LinkButton1"), LinkButton).Visible = True 'rechazar
                CType(e.Item.FindControl("LinkButton2"), LinkButton).Visible = True 'aprobar
                CType(e.Item.FindControl("lblObservaciones"), Label).Visible = False 'observaciones
            End If
        End If
    End Sub

    Private Sub dgLista_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        'al rechazar solicitud cambia de estado a rechazada UFI
        If CLng(CType(e.Item.FindControl("Label_IdEstado"), Label).Text) = 5 Then 'enviado UFI
            MostrarObservaciones(CLng(CType(e.Item.FindControl("lbld"), Label).Text), 2, CStr(CType(e.Item.FindControl("lblnum"), Label).Text))
        Else
            'ya esta enviada lblnum
        End If
    End Sub

    Private Sub BarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        Response.Redirect("~/ESTABLECIMIENTOS/FrmDetaMantSolicitudCompra.aspx?id=0")
    End Sub

    Private Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista.PageIndexChanged
        'al cambiar indice de pagina
        Me.dgLista.CurrentPageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        'al redireccionar a pagina principal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub MostrarObservaciones(ByVal IDSOLICITUD As Int64, ByVal tipo As Integer, ByVal NumSolicitud As String)
        Me.pnlObservaciones.Visible = True
        Me.lblid.Text = IDSOLICITUD
        Me.lbltipo.Text = tipo
        Me.LblSolicitud.Text = NumSolicitud
        Select Case tipo
            Case 1 'aprobar solicitud
                Me.lblObservacion.Text = "Solicitud Aprobada por UFI"
                Me.BttGuardarObservacion.Text = "Aprobar Solicitud"
            Case 2 'rechazar solicitud
                Me.lblObservacion.Text = "Solicitud Rechazada por UFI"
                Me.BttGuardarObservacion.Text = "Rechazar Solicitud"
        End Select

    End Sub

    Protected Sub BttGuardarObservacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttGuardarObservacion.Click
        Dim idSolicitud As Integer
        Dim tipo As Integer

        tipo = CInt(Me.lbltipo.Text)
        idSolicitud = Me.lblid.Text


        Dim mComSol As New cSOLICITUDES
        Dim lEntSol As New SOLICITUDES
        lEntSol.OBSERVACION = Me.lblObservacion.Text & " /: " & Me.txtObservaciones.Text
        lEntSol.AUFECHAMODIFICACION = Date.Today
        lEntSol.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        lEntSol.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        lEntSol.ESTASINCRONIZADA = 0
        lEntSol.IDSOLICITUD = idSolicitud
        mComSol.ActualizarObservacionSolicitud(lEntSol, Session("IdEstablecimiento"), idSolicitud)

        Select Case tipo
            Case 1 'aprobar solicitud
                mEntidad.IDSOLICITUD = idSolicitud
                mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

                Me.mComponente.ObtenerSOLICITUDES(mEntidad)

                mEntidad.IDESTADO = 6  'Aprobada UFI
                mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                mEntidad.AUFECHAMODIFICACION = Now()
                mComponente.ActualizarSOLICITUDES(mEntidad)

                mEntHistoricoEstados.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                mEntHistoricoEstados.IDDETALLE = mCompHistoricoEstados.id_HISTORICOESTADOSSOLICITUDES(mEntHistoricoEstados)
                mEntHistoricoEstados.IDSOLICITUD = idSolicitud
                mEntHistoricoEstados.IDESTADO = 6 'Aprobada UFI
                mEntHistoricoEstados.FECHA = Now()
                mEntHistoricoEstados.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                mEntHistoricoEstados.AUFECHACREACION = Now()
                mEntHistoricoEstados.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                mEntHistoricoEstados.AUFECHAMODIFICACION = Now()
                mEntHistoricoEstados.ESTASINCRONIZADA = 0

                mCompHistoricoEstados.AgregarHISTORICOESTADOSSOLICITUDES(mEntHistoricoEstados)

                MsgBox1.ShowAlert("La solicitud ha sido aprobada", "error5", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.CargarDatos()

            Case 2 'rechazar solicitud
                mEntidad.IDSOLICITUD = idSolicitud
                mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

                Me.mComponente.ObtenerSOLICITUDES(mEntidad)

                mEntidad.IDESTADO = 4 'rechazada UFI
                mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                mEntidad.AUFECHAMODIFICACION = Now()
                mComponente.ActualizarSOLICITUDES(mEntidad)

                mEntHistoricoEstados.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                mEntHistoricoEstados.IDDETALLE = mCompHistoricoEstados.id_HISTORICOESTADOSSOLICITUDES(mEntHistoricoEstados)
                mEntHistoricoEstados.IDSOLICITUD = idSolicitud
                mEntHistoricoEstados.IDESTADO = 4 'Rechazada UFI
                mEntHistoricoEstados.FECHA = Now()
                mEntHistoricoEstados.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                mEntHistoricoEstados.AUFECHACREACION = Now()
                mEntHistoricoEstados.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                mEntHistoricoEstados.AUFECHAMODIFICACION = Now()
                mEntHistoricoEstados.ESTASINCRONIZADA = 0

                mCompHistoricoEstados.AgregarHISTORICOESTADOSSOLICITUDES(mEntHistoricoEstados)
                MsgBox1.ShowAlert("La solicitud ha sido rechazada", "error6", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.CargarDatos()
        End Select

        Me.pnlObservaciones.Visible = False
    End Sub

    Protected Sub BttCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttCancelar.Click
        Me.pnlObservaciones.Visible = False
        Me.txtObservaciones.Text = ""
    End Sub

End Class
