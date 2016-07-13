Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils

Partial Class FrmComisionEvaluacion
    Inherits System.Web.UI.Page

    Private mComponenteEmpleado As New cEMPLEADOS
    Private mComponenteCargo As New cCARGOS
    Private mComponenteProcesoCompra As New cPROCESOCOMPRAS
    Private mComponenteComisionProcesoCompra As New cCOMISIONPROCESOCOMPRA
    Private mComponenteComisionEvaluadora As New cCOMISIONESEVALUADORAS
    Private mComponenteDetalleComision As New cDETALLECOMISIONEVALUADORA

    Private mEntidadComisionEva As COMISIONESEVALUADORAS
    Private mEntidadDetalleComisionEvaluadora As DETALLECOMISIONEVALUADORA
    Private mEntidadComisionProcesoCompra As COMISIONPROCESOCOMPRA

    Private _IDCOMISION As Integer

    Private TComisionEvaluadora As Data.DataTable

    Dim dsComision As Data.DataSet

#Region "propertys"

    Public Property IDCOMISION() As Int32
        Get
            Return Me._IDCOMISION
        End Get
        Set(ByVal Value As Int32)
            Me._IDCOMISION = Value
            If Not Me.ViewState("IdComision") Is Nothing Then Me.ViewState.Remove("IdComision")
            Me.ViewState.Add("IdComision", Value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            CargarDatos()

            CrearTablaComisionEvaluadora()

            Dim ds As New Data.DataSet
            mComponenteProcesoCompra.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), ds)
            Me.lblcodigoevaluacion.Text = ds.Tables(0).Rows(0).Item(1)

            Dim cm As New cMODALIDADESCOMPRA
            Dim ds2 As Data.DataSet
            ds2 = cm.obtenerModalidadCompra(Request.QueryString("idProc"), Session("IdEstablecimiento"))
            If ds2.Tables(0).Rows(0).Item(1) = 2 Then
                Me.txtNoResolucion.Text = " "
                Me.txtNoResolucion.Visible = False
                Me.Label1.Visible = False
            End If

        Else
            If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.TComisionEvaluadora = Me.ViewState("TComisionEvaluadora")
            If Not Me.ViewState("IdComision") Is Nothing Then Me._IDCOMISION = Me.ViewState("IdComision")
            If MessageBox.ConfirmTarget = "Sustitución" Then Sustituir()
            If MessageBox.ConfirmTarget = "Confirmar" Then Confirmar()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub CargarDatos()

        If mComponenteComisionProcesoCompra.ExisteComisionEvaluacion(Session("IdEstablecimiento"), Request.QueryString("idProc")) Then
            Me.PnNuevaComision.Visible = False
            Me.PnConsultaComision.Visible = True
            Me.gvComisionConsulta.DataSource = mComponenteComisionEvaluadora.ObtenerListaComisiones(Session("IdEstablecimiento"), Request.QueryString("idProc"))
            Me.gvComisionConsulta.DataBind()
        Else
            Me.PnNuevaComision.Visible = True
            Me.PnConsultaComision.Visible = False
        End If

        Me.ddlEmpleado.RecuperarEmpleadosComision()
        Me.ddlEmpleadoSuplente.RecuperarEmpleadosComision()
        Me.txtCodigoEmpleado.Text = 1

    End Sub

    'Protected Sub ddlEmpleado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpleado.SelectedIndexChanged

    '    Dim EmpleadoSeleccionado As Integer = Me.ddlEmpleado.SelectedValue

    '    If TComisionEvaluadora.Rows.Contains(EmpleadoSeleccionado) Then
    '        Me.MsgBox1.ShowAlert("Este empleado ya ha sido agregado.", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        'Me.plDatosEmpleado.Visible = False
    '        Exit Sub
    '    End If

    '    Dim mEntidadEmpleado As New EMPLEADOS
    '    Dim mEntidadCargo As New CARGOS

    '    mEntidadEmpleado.IDEMPLEADO = EmpleadoSeleccionado
    '    mComponenteEmpleado.ObtenerEMPLEADOS(mEntidadEmpleado)

    '    Me.txtCodigoEmpleado.Text = mEntidadEmpleado.IDEMPLEADO
    '    Me.txtNombreEmpleado.Text = mEntidadEmpleado.NOMBRE
    '    Me.txtApellidoEmpleado.Text = mEntidadEmpleado.APELLIDO

    '    Dim cD As New cDEPENDENCIAS
    '    'Me.txtDependencia.Text = cD.ObtenerNOMDependencia(mEntidadEmpleado.IDDEPENDENCIA)

    '    mEntidadCargo.IDCARGO = mEntidadEmpleado.IDCARGO

    '    mComponenteCargo.ObtenerCARGOS(mEntidadCargo)

    '    'Me.txtCargoMSPAS.Text = mEntidadCargo.DESCRIPCION

    '    'Me.plDatosEmpleado.Visible = True
    '    Me.btnAgregar.Visible = True
    '    Me.txtCargoDesempeñaComision.Text = ""

    'End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        Dim drEmpleado As Data.DataRow = TComisionEvaluadora.NewRow

        drEmpleado("IDEMPLEADO") = Me.txtCodigoEmpleado.Text
        drEmpleado("NOMBRE") = Me.txtNombreEmpleado.Text & " " & Me.txtApellidoEmpleado.Text
        drEmpleado("CARGO") = Me.txtCargoDesempeñaComision.Text
        drEmpleado("ESTAHABILITADO") = 1

        TComisionEvaluadora.Rows.Add(drEmpleado)

        ' Me.txtCodigoEmpleado.Text = TComisionEvaluadora.Rows.Count + 1
        'drEmpleado("IDEMPLEADO") = Val(Me.txtCodigoEmpleado.Text) + 1
        If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.ViewState.Remove("TComisionEvaluadora")
        Me.ViewState.Add("TComisionEvaluadora", TComisionEvaluadora)

        Me.gvComisionEvaluacion.DataSource = TComisionEvaluadora
        Me.gvComisionEvaluacion.DataBind()

        Me.txtCodigoEmpleado.Text = TComisionEvaluadora.Rows(TComisionEvaluadora.Rows.Count - 1).Item(0) + 1

        Me.btnGuardar.Visible = True
        Me.btnImpresion.Visible = True
        'Me.plDatosEmpleado.Visible = False
        'Me.btnAgregar.Visible = False

        Me.txtNombreEmpleado.Text = ""
        Me.txtApellidoEmpleado.Text = ""
        Me.txtCargoDesempeñaComision.Text = ""

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If Me.TComisionEvaluadora.Rows.Count() = 0 Then
            Me.lblError.Text = "No hay empleados asignados a una comisión."
            Exit Sub
        End If

        If Me.txtNombreComision.Text = "" Then
            Me.lblError.Text = "Falta completar información requerida."
            Exit Sub
        End If

        MessageBox.Confirm("Una vez guardada la información, no se podrán agregar nuevos miembros a la comisión. Confirma que desea guardar?", "Confirmar", MessageBox.OptionPostBack.YesPostBack)
        ' Me.MsgBox1.ShowConfirm("Una vez guardada la información, no se podrán agregar nuevos miembros a la comisión. Confirma que desea guardar?", "C", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)

    End Sub

    Private Sub CrearTablaComisionEvaluadora()

        TComisionEvaluadora = New Data.DataTable

        Dim ColumIdEmpleado As New Data.DataColumn("IDEMPLEADO", System.Type.GetType("System.Int32"))
        Dim ColumNombre As New Data.DataColumn("NOMBRE", System.Type.GetType("System.String"))
        Dim ColumCargo As New Data.DataColumn("CARGO", System.Type.GetType("System.String"))
        Dim ColumEstaHabilitado As New Data.DataColumn("ESTAHABILITADO", System.Type.GetType("System.Int32"))

        TComisionEvaluadora.Columns.Add(ColumIdEmpleado)
        TComisionEvaluadora.Columns.Add(ColumNombre)
        TComisionEvaluadora.Columns.Add(ColumCargo)
        TComisionEvaluadora.Columns.Add(ColumEstaHabilitado)

        Dim PrimaryKey(1) As Data.DataColumn
        PrimaryKey(0) = ColumIdEmpleado

        TComisionEvaluadora.PrimaryKey = PrimaryKey

        If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.ViewState.Remove("TComisionEvaluadora")
        Me.ViewState.Add("TComisionEvaluadora", TComisionEvaluadora)

    End Sub

    Protected Sub gvComisionEvaluacion_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvComisionEvaluacion.RowDeleting

        Dim IDEMPLEADO As Integer = Me.gvComisionEvaluacion.DataKeys(e.RowIndex).Values(0)

        TComisionEvaluadora.Rows.Remove(TComisionEvaluadora.Rows.Find(IDEMPLEADO))

        If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.ViewState.Remove("TComisionEvaluadora")
        Me.ViewState.Add("TComisionEvaluadora", TComisionEvaluadora)


        Me.txtCodigoEmpleado.Text = TComisionEvaluadora.Rows(TComisionEvaluadora.Rows.Count - 1).Item(0) + 1

        gvComisionEvaluacion.DataSource = TComisionEvaluadora
        gvComisionEvaluacion.DataBind()


    End Sub

    Protected Sub gvComisionConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvComisionConsulta.SelectedIndexChanged

        Me.IDCOMISION = Me.gvComisionConsulta.SelectedRow.Cells(1).Text

        dsComision = mComponenteDetalleComision.ObtenerDetalleporComision(IDCOMISION, Session("IdEstablecimiento"))

        Me.gvDetalleComision.DataSource = dsComision
        Me.gvDetalleComision.DataBind()
        Me.gvDetalleComision.Visible = True

        TComisionEvaluadora.Clear()

        ' TComisionEvaluadora.Merge(dsComision.Tables(0), False, Data.MissingSchemaAction.Ignore)

        'Me.plDatosEmpleado.Visible = False
        Me.Button4.Visible = True
    End Sub

    'Protected Sub ddlEmpleadoSuplente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpleadoSuplente.SelectedIndexChanged

    '    Dim EmpleadoSeleccionado As Integer = Me.ddlEmpleadoSuplente.SelectedValue

    '    If TComisionEvaluadora.Rows.Contains(EmpleadoSeleccionado) Then
    '        Me.MsgBox2.ShowAlert("El empleado seleccionado ya conforma la comisión.", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        Me.pnEmpleadoSuplente.Visible = False
    '        Exit Sub
    '    End If

    '    Dim mEntidadEmpleado As New EMPLEADOS
    '    Dim mEntidadCargo As New CARGOS

    '    mEntidadEmpleado.IDEMPLEADO = EmpleadoSeleccionado
    '    mComponenteEmpleado.ObtenerEMPLEADOS(mEntidadEmpleado)

    '    Me.txtCodigoEmpleadoSuplente.Text = mEntidadEmpleado.IDEMPLEADO
    '    Me.txtNombreEmpleadoSuplente.Text = mEntidadEmpleado.NOMBRE
    '    Me.txtApellidoEmpleadoSuplente.Text = mEntidadEmpleado.APELLIDO

    '    Dim CD As New cDEPENDENCIAS
    '    Me.txtDependenciaSuplente.Text = CD.ObtenerNOMDependencia(mEntidadEmpleado.IDDEPENDENCIA)

    '    mEntidadCargo.IDCARGO = mEntidadEmpleado.IDCARGO

    '    mComponenteCargo.ObtenerCARGOS(mEntidadCargo)

    '    Me.txtCargoMSPASSuplente.Text = mEntidadCargo.DESCRIPCION
    '    Me.pnEmpleadoSuplente.Visible = True

    'End Sub

    Protected Sub btnSuplantar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSuplantar.Click

        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Then
            MessageBox.Alert("Falta(n) dato(s) requerido(s).", "Error")
            'Me.MsgBox2.ShowAlert("Falta(n) dato(s) requerido(s).", "h", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            Exit Sub
        End If

        mEntidadDetalleComisionEvaluadora = New DETALLECOMISIONEVALUADORA

        'suplente
        mEntidadDetalleComisionEvaluadora.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mEntidadDetalleComisionEvaluadora.IDCOMISION = Me.IDCOMISION
        mEntidadDetalleComisionEvaluadora.IDDETALLE = Nothing
        mEntidadDetalleComisionEvaluadora.NOMBRE = Me.TextBox1.Text & Me.TextBox2.Text
        'mEntidadDetalleComisionEvaluadora.IDEMPLEADO = Me.txtCodigoEmpleadoSuplente.Text
        mEntidadDetalleComisionEvaluadora.CARGO = Me.TextBox3.Text
        mEntidadDetalleComisionEvaluadora.ESTAHABILITADO = 1
        mEntidadDetalleComisionEvaluadora.IDPADRE = Me.gvDetalleComision.DataKeys(Me.gvDetalleComision.SelectedIndex).Values(0)

        mComponenteDetalleComision.ActualizarDETALLECOMISIONEVALUADORA(mEntidadDetalleComisionEvaluadora)

        'suplantado
        mEntidadDetalleComisionEvaluadora = Nothing
        mEntidadDetalleComisionEvaluadora = New DETALLECOMISIONEVALUADORA
        mEntidadDetalleComisionEvaluadora.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mEntidadDetalleComisionEvaluadora.IDDETALLE = Me.gvDetalleComision.DataKeys(Me.gvDetalleComision.SelectedIndex).Values(0)
        mEntidadDetalleComisionEvaluadora.ESTAHABILITADO = 0

        mComponenteDetalleComision.ActualizarEmpleadoComision(mEntidadDetalleComisionEvaluadora)

        MessageBox.AlertSubmit("El empleado ha sido sustituido satisfactoriamente.", "Sustitución")
        'Me.MsgBox2.ShowAlert("El empleado ha sido sustituido satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

    End Sub

    Protected Sub gvDetalleComision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDetalleComision.SelectedIndexChanged
        Me.pnEmpleadoSuplente.Visible = False
        Me.pnSuplente.Visible = True
        Me.pnEmpleadoSuplente.Visible = True
    End Sub

    Protected Sub btnImpresion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImpresion.Click

        Dim dsL As New Data.DataSet
        mComponenteProcesoCompra.ObtenerInfoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), dsL)
        Session("TipoLicitacion") = dsL.Tables(0).Rows(0).Item(0)
        Session("NumLicitacion") = dsL.Tables(0).Rows(0).Item(1)
        Session("TituloLicitacion") = dsL.Tables(0).Rows(0).Item(2)
        Session("DescPC") = dsL.Tables(0).Rows(0).Item(3)
        Session("FechaCreacion") = Me.CalendarPopup1.SelectedDate

        Utils.MostrarVentana("/Reportes/frmRptComision.aspx?idProc=" & Request.QueryString("idProc"))
        'ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='JavaScript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptComision.aspx?idProc=" & Request.QueryString("idProc") & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');</script>")

    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Session("NomComision") = Server.HtmlDecode(Me.gvComisionConsulta.SelectedRow.Cells(2).Text)

        Dim dsL As New Data.DataSet
        mComponenteProcesoCompra.ObtenerInfoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), dsL)
        Session("TipoLicitacion") = dsL.Tables(0).Rows(0).Item(0)
        Session("NumLicitacion") = dsL.Tables(0).Rows(0).Item(1)
        Session("TituloLicitacion") = dsL.Tables(0).Rows(0).Item(2)
        Session("DescPC") = dsL.Tables(0).Rows(0).Item(3)
        Session("FechaCreacion") = Me.gvComisionConsulta.SelectedRow.Cells(4).Text
        Utils.MostrarVentana("/Reportes/frmRptComision.aspx?idProc=" & Request.QueryString("idProc"))
        '  ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='JavaScript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptComision.aspx?idProc=" & Request.QueryString("idProc") & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');</script>")

    End Sub


    Protected Sub Sustituir() ' Protected Sub MsgBox2_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox2.OkChosen

        ' If e.Key = "A" Then

        dsComision = mComponenteDetalleComision.ObtenerDetalleporComision(Me.IDCOMISION, Session("IdEstablecimiento"))

        Me.gvDetalleComision.DataSource = dsComision
        Me.gvDetalleComision.DataBind()
        Me.gvDetalleComision.Visible = True

        TComisionEvaluadora.Clear()

        'TComisionEvaluadora.Merge(dsComision.Tables(0), False, Data.MissingSchemaAction.Ignore)
        TComisionEvaluadora = dsComision.Tables(0)
        Session("ComisionFinal") = TComisionEvaluadora

        Me.Button4.Visible = True
        Me.pnSuplente.Visible = False

        Me.btnImpresion.Enabled = True
        Me.btnImpresion.Visible = True
        Me.btnGuardar.Enabled = False
        ' End If

    End Sub

    Protected Sub Confirmar() ' Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

        ' If e.Key = "C" Then

        '---------INGRESA COMISION EVALUADORA
        mEntidadComisionEva = New COMISIONESEVALUADORAS
        'mEntidadComisionEva.NUMRESOLUCION = Me.txtNoResolucion.Text
        'mEntidadComisionEva.FECHARESOLUCION = Me.CalendarPopup2.SelectedDate
        mEntidadComisionEva.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mEntidadComisionEva.NOMBRE = Me.txtNombreComision.Text
        mEntidadComisionEva.FECHACREACION = Me.CalendarPopup1.SelectedDate
        mEntidadComisionEva.ESTADO = Me.rblEstado.SelectedValue
        mEntidadComisionEva.ESALTONIVEL = 0
        mEntidadComisionEva.NUMRESOLUCION = Me.txtNoResolucion.Text
        mEntidadComisionEva.FECHARESOLUCION = Me.CalendarPopup2.SelectedDate

        Session("NomComision") = Me.txtNombreComision.Text

        mComponenteComisionEvaluadora.ActualizarCOMISIONESEVALUADORAS(mEntidadComisionEva)

        IDCOMISION = mEntidadComisionEva.IDCOMISION

        '-------------INGRESA DETALLECOMISIONEVALUADORA
        mEntidadDetalleComisionEvaluadora = New DETALLECOMISIONEVALUADORA

        For Each drComision As Data.DataRow In TComisionEvaluadora.Rows
            mEntidadDetalleComisionEvaluadora.IDESTABLECIMIENTO = mEntidadComisionEva.IDESTABLECIMIENTO
            mEntidadDetalleComisionEvaluadora.IDCOMISION = mEntidadComisionEva.IDCOMISION
            mEntidadDetalleComisionEvaluadora.IDDETALLE = 0
            'mEntidadDetalleComisionEvaluadora.IDEMPLEADO = drComision.Item(0)
            mEntidadDetalleComisionEvaluadora.NOMBRE = drComision.Item(1)
            mEntidadDetalleComisionEvaluadora.CARGO = drComision.Item(2)
            mEntidadDetalleComisionEvaluadora.ESTAHABILITADO = drComision.Item(3)

            mComponenteDetalleComision.ActualizarDETALLECOMISIONEVALUADORA(mEntidadDetalleComisionEvaluadora)
        Next

        Session("ComisionFinal") = TComisionEvaluadora

        '-----INGRESA COMISION-PROCESOCOMPRA
        mEntidadComisionProcesoCompra = New COMISIONPROCESOCOMPRA
        mEntidadComisionProcesoCompra.IDESTABLECIMIENTO = mEntidadComisionEva.IDESTABLECIMIENTO
        mEntidadComisionProcesoCompra.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadComisionProcesoCompra.IDCOMISION = mEntidadComisionEva.IDCOMISION
        mEntidadComisionProcesoCompra.USUARIOCOMISION = Nothing
        mEntidadComisionProcesoCompra.CLAVE = Nothing

        mComponenteComisionProcesoCompra.AgregarCOMISIONPROCESOCOMPRA(mEntidadComisionProcesoCompra)

        '--ACTUALIZAR ESTADO
        'Dim cPC As New cPROCESOCOMPRAS
        'Dim Estado As Integer
        'Estado = cPC.ChequearEstadosPC(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        'If Estado = eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINAR Then
        '    Dim pc As New PROCESOCOMPRAS
        '    pc.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        '    pc.IdProcesoCompra = Request.QueryString("idProc")
        '    pc.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.COMISIONDEEVALUACIONINGRESADA
        '    mComponenteProcesoCompra.ActualizarEstado(pc)
        'End If

        'If Estado = eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINARFINALIZADO Then
        '    Dim pc As New PROCESOCOMPRAS
        '    pc.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        '    pc.IdProcesoCompra = Request.QueryString("idProc")
        '    pc.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA
        '    mComponenteProcesoCompra.ActualizarEstado(pc)
        'End If

        Me.btnImpresion.Enabled = True
        Me.btnImpresion.Visible = True
        Me.btnGuardar.Enabled = False
        Me.txtCodigoEmpleado.Text = Val(Me.txtCodigoEmpleado.Text) + 1

        Me.gvComisionEvaluacion.Columns(0).Visible = False
        'Me.plDatosEmpleado.Visible = False
        'Me.Label14.Visible = False
        'Me.ddlEmpleado.Visible = False
        Me.Label13.Visible = False
        Me.btnAgregar.Visible = False
        Me.lblError.Text = "La comisión se ha creado satisfactoriamente."
        'End If
    End Sub

End Class
