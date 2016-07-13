Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SladeHome.SimpleCrypto

Partial Class FrmComisionEvaluacionAltoNivel
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

        Me.lblFechaSistema.Text = DateTime.Now.Date

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim cRR As New cRECURSOSREVISION
            If cRR.ExistenRecursos(Session("IdEstablecimiento"), Request.QueryString("idProc")) = 0 Then
                Me.Panel5.Visible = True
            Else

                CargarDatos()

                CrearTablaComisionEvaluadora()

                Dim ds As New Data.DataSet
                mComponenteProcesoCompra.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), ds)
                Me.lblcodigoevaluacion.Text = ds.Tables(0).Rows(0).Item(1) 'CODIGO COMISION IGUAL AL CODIGO PROCESO DE COMPRA

            End If
        Else
            If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.TComisionEvaluadora = Me.ViewState("TComisionEvaluadora")
            If Not Me.ViewState("IdComision") Is Nothing Then Me._IDCOMISION = Me.ViewState("IdComision")
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub CargarDatos()

        Dim mEntidadProcesoCompra As New PROCESOCOMPRAS
        mEntidadProcesoCompra.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadProcesoCompra.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        If mComponenteProcesoCompra.ObtenerPROCESOCOMPRAS(mEntidadProcesoCompra) <> 1 Then
            Return
        End If

        Dim Estado As Integer
        Estado = mComponenteProcesoCompra.ChequearEstadosPC(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        If Estado <> eESTADOPROCESOSCOMPRAS.COMISIONDEALTONIVELINGRESADA Then
            Me.PnNuevaComision.Visible = True
            Me.PnConsultaComision.Visible = False
            Me.lblUsuarioComision.Text = "usrcomE" & Session("IdEstablecimiento") & "P" & Request.QueryString("idProc")
            Me.Label24.Text = Me.lblUsuarioComision.Text

            Me.CompareValidator2.ValueToCompare = mComponenteProcesoCompra.ObtenerFechaLimiteAceptacion(Request.QueryString("idProc"), Session("IdEstablecimiento"))
            Me.CompareValidator3.ValueToCompare = Today
        Else
            Me.PnNuevaComision.Visible = False
            Me.PnConsultaComision.Visible = True
            Me.gvComisionConsulta.DataBind()
        End If

        'Me.ddlEmpleado.RecuperarEmpleadosComision()
        'Me.ddlEmpleadoSuplente.RecuperarEmpleadosComision()

    End Sub

    'Protected Sub ddlEmpleado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpleado.SelectedIndexChanged

    '    Dim EmpleadoSeleccionado As Integer = Me.ddlEmpleado.SelectedValue

    '    If TComisionEvaluadora.Rows.Contains(EmpleadoSeleccionado) Then
    '        Me.MsgBox1.ShowAlert("Este empleado ya ha sido agregado.", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        Me.plDatosEmpleado.Visible = False
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
    '    Me.txtDependencia.Text = cD.ObtenerNOMDependencia(mEntidadEmpleado.IDDEPENDENCIA)

    '    mEntidadCargo.IDCARGO = mEntidadEmpleado.IDCARGO

    '    mComponenteCargo.ObtenerCARGOS(mEntidadCargo)

    '    Me.txtCargoMSPAS.Text = mEntidadCargo.DESCRIPCION

    '    Me.plDatosEmpleado.Visible = True
    '    Me.btnAgregar.Visible = True
    '    Me.txtCargoDesempeñaComision.Text = ""

    'End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim row As Data.DataRow = Me.TComisionEvaluadora.NewRow
        For Each row In TComisionEvaluadora.Rows
            If row.Item(1) = Me.txtNombreMiembroComision.Text Then
                'msgbox
                Me.MsgBox5.ShowAlert("Los miembros de la comisión no pueden ser repetidos.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Me.txtNombreMiembroComision.Text = ""
                Me.txtCargoDesempeñaComision.Text = ""
                Exit Sub
            End If
        Next

        Dim drEmpleado As Data.DataRow = TComisionEvaluadora.NewRow

        drEmpleado("IDEMPLEADO") = 0
        drEmpleado("NOMBRE") = Me.txtNombreMiembroComision.Text
        drEmpleado("CARGO") = Me.txtCargoDesempeñaComision.Text
        drEmpleado("ESTAHABILITADO") = 1

        TComisionEvaluadora.Rows.Add(drEmpleado)

        If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.ViewState.Remove("TComisionEvaluadora")
        Me.ViewState.Add("TComisionEvaluadora", TComisionEvaluadora)

        Me.gvComisionEvaluacion.DataSource = TComisionEvaluadora
        Me.gvComisionEvaluacion.DataBind()

        Me.btnGuardar.Visible = True
        Me.btnImpresion.Visible = True
        'Me.plDatosEmpleado.Visible = False
        'Me.btnAgregar.Visible = False

        Me.txtNombreMiembroComision.Text = ""
        Me.txtCargoDesempeñaComision.Text = ""

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If Me.gvComisionEvaluacion.Rows.Count() = 0 Then
            Me.lblError.Text = "No hay empleados asignados a una comisión."
            Exit Sub
        End If

        If Me.txtNombreComision.Text = "" Then
            Me.lblError.Text = "Falta completar información requerida."
            Exit Sub
        End If

        Me.MsgBox1.ShowConfirm("Una vez guardada la información, no se podrán agregar nuevos miembros a la comisión. Confirma que desea guardar?", "C", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)

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
        PrimaryKey(0) = ColumNombre

        TComisionEvaluadora.PrimaryKey = PrimaryKey

        If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.ViewState.Remove("TComisionEvaluadora")
        Me.ViewState.Add("TComisionEvaluadora", TComisionEvaluadora)

    End Sub

    Protected Sub gvComisionEvaluacion_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvComisionEvaluacion.RowDeleting

        Dim NOMBRE As String

        NOMBRE = Me.gvComisionEvaluacion.Rows(e.RowIndex).Cells(2).Text

        TComisionEvaluadora.Rows.Remove(TComisionEvaluadora.Rows.Find(NOMBRE))

        If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.ViewState.Remove("TComisionEvaluadora")
        Me.ViewState.Add("TComisionEvaluadora", TComisionEvaluadora)

        gvComisionEvaluacion.DataSource = TComisionEvaluadora
        gvComisionEvaluacion.DataBind()

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.PnNuevaComision.Visible = True
        Me.PnConsultaComision.Visible = False
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.PnConsultaComision.Visible = True
        Me.PnNuevaComision.Visible = False

        Me.gvComisionConsulta.DataBind()
    End Sub

    Protected Sub gvComisionConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvComisionConsulta.SelectedIndexChanged

        Me.IDCOMISION = Me.gvComisionConsulta.SelectedRow.Cells(1).Text

        dsComision = mComponenteDetalleComision.ObtenerDetalleporComisionAN(IDCOMISION, Session("IdEstablecimiento"))

        Me.gvDetalleComision.DataSource = dsComision
        Me.gvDetalleComision.DataBind()
        Me.gvDetalleComision.Visible = True

        TComisionEvaluadora.Clear()

        Me.plDatosEmpleado.Visible = False
        Me.Button4.Visible = True

        Me.LinkButton1.Visible = True
        Me.Label24.Text = "usrcomE" & Session("IdEstablecimiento") & "P" & Request.QueryString("idProc")
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

        Dim NombreSuplantado As String
        NombreSuplantado = Me.gvDetalleComision.SelectedRow.Cells(0).Text

        mEntidadDetalleComisionEvaluadora = New DETALLECOMISIONEVALUADORA

        'suplente
        mEntidadDetalleComisionEvaluadora.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mEntidadDetalleComisionEvaluadora.IDCOMISION = Me.IDCOMISION
        mEntidadDetalleComisionEvaluadora.IDDETALLE = Nothing
        'mEntidadDetalleComisionEvaluadora.IDEMPLEADO = Me.txtCodigoEmpleadoSuplente.Text
        mEntidadDetalleComisionEvaluadora.NOMBRE = Me.txtnombresuplenteComision.Text
        mEntidadDetalleComisionEvaluadora.CARGO = Me.txtcargosuplentecomision.Text
        mEntidadDetalleComisionEvaluadora.ESTAHABILITADO = 1
        mEntidadDetalleComisionEvaluadora.IDPADRE = Nothing 'Me.gvDetalleComision.DataKeys(Me.gvDetalleComision.SelectedIndex).Values(0)

        mComponenteDetalleComision.ActualizarDETALLECOMISIONEVALUADORA(mEntidadDetalleComisionEvaluadora)

        'suplantado
        mEntidadDetalleComisionEvaluadora = Nothing
        mEntidadDetalleComisionEvaluadora = New DETALLECOMISIONEVALUADORA
        mEntidadDetalleComisionEvaluadora.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mEntidadDetalleComisionEvaluadora.IDCOMISION = Me.IDCOMISION
        mEntidadDetalleComisionEvaluadora.NOMBRE = Me.gvDetalleComision.SelectedRow.Cells(0).Text
        mEntidadDetalleComisionEvaluadora.ESTAHABILITADO = 0

        mComponenteDetalleComision.ActualizarEmpleadoComisionAN(mEntidadDetalleComisionEvaluadora)

        Me.MsgBox2.ShowAlert("El empleado ha sido suplantado satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

    End Sub

    Protected Sub gvDetalleComision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDetalleComision.SelectedIndexChanged
        Me.pnEmpleadoSuplente.Visible = True
        Me.pnSuplente.Visible = True
    End Sub

    Protected Sub btnImpresion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImpresion.Click

        Dim dsL As New Data.DataSet
        mComponenteProcesoCompra.ObtenerInfoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), dsL)
        Session("TipoLicitacion") = dsL.Tables(0).Rows(0).Item(0)
        Session("NumLicitacion") = dsL.Tables(0).Rows(0).Item(1)
        Session("TituloLicitacion") = dsL.Tables(0).Rows(0).Item(2)
        Session("DescPC") = dsL.Tables(0).Rows(0).Item(3)
        Session("FechaCreacion") = Me.CalendarPopup1.SelectedDate

        ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptComision.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');</script>")

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

        ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptComision.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');</script>")

    End Sub

    Protected Sub MsgBox2_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox2.OkChosen

        If e.Key = "A" Then

            dsComision = mComponenteDetalleComision.ObtenerDetalleporComisionAN(Me.IDCOMISION, Session("IdEstablecimiento"))

            Me.gvDetalleComision.DataSource = dsComision
            Me.gvDetalleComision.DataBind()
            Me.gvDetalleComision.Visible = True

            TComisionEvaluadora.Clear()

            TComisionEvaluadora.Merge(dsComision.Tables(0), False, Data.MissingSchemaAction.Ignore)

            Session("ComisionFinal") = TComisionEvaluadora

            Me.Button4.Visible = True
            Me.pnSuplente.Visible = False

            Me.btnImpresion.Enabled = True
            Me.btnImpresion.Visible = True
            Me.btnGuardar.Enabled = False
        End If
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "D" Then
            Me.Panel2.Visible = False
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

        If e.Key = "A" Then

            '--ACTUALIZA ESTADO PC
            Dim pc As New PROCESOCOMPRAS
            pc.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            pc.IDPROCESOCOMPRA = Request.QueryString("idProc")
            pc.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA
            mComponenteProcesoCompra.ActualizarEstado(pc, 0)

            Me.btnImpresion.Enabled = True
            Me.lblError.Text = "La comisión se ha creado satisfactoriamente."

        End If


        If e.Key = "C" Then

            '---------INGRESA COMISION EVALUADORA ALTO NIVEL
            mEntidadComisionEva = New COMISIONESEVALUADORAS
            mEntidadComisionEva.FECHACREACION = Me.CalendarPopup1.SelectedDate
            mEntidadComisionEva.ESTADO = Me.rblEstado.SelectedValue
            mEntidadComisionEva.ESALTONIVEL = 1
            mEntidadComisionEva.NOMBRE = Me.txtNombreComision.Text

            Session("NomComision") = Me.txtNombreComision.Text
            mEntidadComisionEva.IDESTABLECIMIENTO = Session("IdEstablecimiento")

            IDCOMISION = mComponenteComisionEvaluadora.ObtenerID(mEntidadComisionEva)

            mComponenteComisionEvaluadora.ActualizarCOMISIONESEVALUADORASAN(mEntidadComisionEva)

            '-------------INGRESA DETALLECOMISIONEVALUADORA
            mEntidadDetalleComisionEvaluadora = New DETALLECOMISIONEVALUADORA

            Dim c As Integer
            For Each drComision As Data.DataRow In TComisionEvaluadora.Rows
                c += 1
                mEntidadDetalleComisionEvaluadora.IDCOMISION = IDCOMISION
                'mEntidadDetalleComisionEvaluadora.IDEMPLEADO = 0
                mEntidadDetalleComisionEvaluadora.IDDETALLE = 0
                mEntidadDetalleComisionEvaluadora.NOMBRE = drComision.Item(1)
                mEntidadDetalleComisionEvaluadora.CARGO = drComision.Item(2)
                mEntidadDetalleComisionEvaluadora.ESTAHABILITADO = drComision.Item(3)
                mEntidadDetalleComisionEvaluadora.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                If c <> 1 Then
                    mEntidadDetalleComisionEvaluadora.IDDETALLE = Nothing
                End If
                mComponenteDetalleComision.ActualizarDETALLECOMISIONEVALUADORA(mEntidadDetalleComisionEvaluadora)
            Next

            Session("ComisionFinal") = TComisionEvaluadora

            '-----INGRESA COMISION-PROCESOCOMPRA
            mEntidadComisionProcesoCompra = New COMISIONPROCESOCOMPRA
            mEntidadComisionProcesoCompra.IDCOMISION = IDCOMISION
            mEntidadComisionProcesoCompra.IDPROCESOCOMPRA = Request.QueryString("idProc")
            mEntidadComisionProcesoCompra.IDESTABLECIMIENTO = Session("IdEstablecimiento")

            mComponenteComisionProcesoCompra.IngresarCOMISIONPROCESOCOMPRA(mEntidadComisionProcesoCompra)

            '--ACTUALIZAR ESTADO
            Dim pc As New PROCESOCOMPRAS
            pc.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            pc.IDPROCESOCOMPRA = Request.QueryString("idProc")
            pc.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.COMISIONDEALTONIVELINGRESADA
            mComponenteProcesoCompra.ActualizarEstado(pc, 0)

            Me.btnImpresion.Enabled = True
            Me.btnImpresion.Visible = True
            Me.btnGuardar.Enabled = False
            Me.Label13.Visible = False
            'Me.Label14.Visible = False
            'Me.ddlEmpleado.Visible = False
            Me.txtNombreComision.Enabled = False
            Me.CalendarPopup1.Enabled = False
            Me.plDatosEmpleado.Visible = False
            Me.btnAgregar.Visible = False

            Me.gvComisionEvaluacion.Columns(0).Visible = False

            Me.Panel2.Visible = True

            Me.MsgBox4.ShowAlert("La comisión se ha creado satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

        End If

    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarClave.Click
        Dim hashed As String
        Dim encrypted As String

        encrypted = Crypto.EncryptTripleDES(Me.TextBox1.Text, "ABAS")
        hashed = Crypto.GetMD5Hash(encrypted)

        mComponenteComisionProcesoCompra.ActualizarClave(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDCOMISION, hashed)

        Me.Msgbox3.ShowAlert("Cambio de clave realizado.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Panel4.Visible = True
    End Sub

    Protected Sub Msgbox3_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles Msgbox3.OkChosen
        If e.Key = "A" Then
            Me.Panel4.Visible = False
        End If
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim encrypted, hashed As String
        encrypted = Crypto.EncryptTripleDES(Me.txtClave.Text, "ABAS")
        hashed = Crypto.GetMD5Hash(encrypted)

        mEntidadComisionProcesoCompra = New COMISIONPROCESOCOMPRA
        mEntidadComisionProcesoCompra.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mEntidadComisionProcesoCompra.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadComisionProcesoCompra.IDCOMISION = IDCOMISION
        mEntidadComisionProcesoCompra.USUARIOCOMISION = Me.lblUsuarioComision.Text
        mEntidadComisionProcesoCompra.CLAVE = hashed
        mEntidadComisionProcesoCompra.ESTAHABILITADO = 1

        mComponenteComisionProcesoCompra.ActualizarCOMISIONPROCESOCOMPRA(mEntidadComisionProcesoCompra)

        Me.MsgBox1.ShowAlert("El usuario y clave se ha guardado satisfactoriamente.", "D", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

    End Sub

End Class
