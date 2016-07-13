Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class UACI_frmRecepAper
    Inherits System.Web.UI.Page

    Private mComponente As New cRECEPCIONOFERTAS

    Private _IDPROCESOCOMPRA, _IDESTABLECIMIENTO As Int64
    Private _permiteGuardar As Boolean = False
    Private _action As Integer
    Private _IDUNIDADMEDIDA As Integer
    Private _IDPROVEEDOR As Integer

    Public Property IDPROCESOCOMPRA() As Int64
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Int64)
            _IDPROCESOCOMPRA = value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IdProcesoCompra", value)
        End Set
    End Property

    Public Property IDESTABLECIMIENTO() As Int64
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int64)
            _IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
        End Set
    End Property

    Public Property action() As Int64
        Get
            Return _action
        End Get
        Set(ByVal value As Int64)
            _action = value
            If Not Me.ViewState("action") Is Nothing Then Me.ViewState.Remove("action")
            Me.ViewState.Add("action", value)
        End Set
    End Property

    Public Property permiteGuardar() As Boolean
        Get
            Return _permiteGuardar
        End Get
        Set(ByVal value As Boolean)
            _permiteGuardar = value
            If Not Me.ViewState("permiteGuardar") Is Nothing Then Me.ViewState.Remove("permiteGuardar")
            Me.ViewState.Add("permiteGuardar", value)
        End Set
    End Property

    Public Property IDUNIDADMEDIDA() As Int64
        Get
            Return _IDUNIDADMEDIDA
        End Get
        Set(ByVal value As Int64)
            _IDUNIDADMEDIDA = value
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me.ViewState.Remove("IDUNIDADMEDIDA")
            Me.ViewState.Add("IDUNIDADMEDIDA", value)
        End Set
    End Property

    Public Property IDPROVEEDOR() As Int64
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Int64)
            _IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            IDESTABLECIMIENTO = Session("IDEstablecimiento")
            IDPROCESOCOMPRA = Request.QueryString("idProc")

            With Me.UcBarraNavegacion1
                .PermitirImprimir = False
                .PermitirGuardar = False
                .PermitirEditar = False
                .HabilitarEdicion(False)
                .PermitirConsultar = False
                .Navegacion = False
            End With
            obtenerListaOfertasPresentadas()
            consultarproveedoresretirabase()
            Dim cP As New cPROCESOCOMPRAS
            Dim ds As New Data.DataSet
            cP.ObtenerCodigoyTipoLicitacion(Session("IDEstablecimiento"), Request.QueryString("idProc"), ds)

            Me.lblCodigoLicitacion.Text = ds.Tables(0).Rows(0).Item(1)
            Me.lblTituloLicitacion.Text = ds.Tables(0).Rows(0).Item(3)

            'APERTURA DE OFERTAS
            consultarProcesoCompra()
            consultarEmpleados()
            verificaProcesoAperturado()

        Else
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("action") Is Nothing Then Me._action = Me.ViewState("action")
            If Not Me.ViewState("permiteGuardar") Is Nothing Then Me._permiteGuardar = Me.ViewState("permiteGuardar")
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me._IDUNIDADMEDIDA = Me.ViewState("IDUNIDADMEDIDA")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
        End If

        If Me.dgOfertaPresentada.Rows.Count = 0 Then
            Me.btnImprimirPresntaronOfertas.Visible = False
            Me.Button2.Visible = False
        Else
            Me.btnImprimirPresntaronOfertas.Visible = True
            Me.Button2.Visible = True
        End If

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub consultarproveedoresretirabase()

        Dim ds As Data.DataSet
        ds = mComponente.obtenerProveedoresNoAsignados(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        If ds.Tables(0).Rows.Count > 0 Then
            Me.ddlProveedorEntregaBase.DataSource = ds
            Me.ddlProveedorEntregaBase.DataTextField = "NOMBRE"
            Me.ddlProveedorEntregaBase.DataValueField = "IDPROVEEDOR"
            Me.ddlProveedorEntregaBase.DataBind()
        Else
            Me.UcBarraNavegacion1.PermitirAgregar = False
            Me.UcBarraNavegacion1.Visible = False
        End If
    End Sub

    Private Sub obtenerListaOfertasPresentadas()

        Me.UcBarraNavegacion1.PermitirAgregar = True

        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDataSet_OfertasRecibidas(Request.QueryString("idProc"), Session("IDEstablecimiento"))

        If ds.Tables(0).Rows.Count = 0 Then
            Me.lblOrden.Text = 1
        Else
            Me.lblOrden.Text = ds.Tables(0).Rows.Count + 1
        End If

        Me.dgOfertaPresentada.DataSource = ds
        Me.dgOfertaPresentada.DataBind()
    End Sub

    Protected Sub UcBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Agregar
        Panel1.Visible = True

        Me.UcBarraNavegacion1.HabilitarEdicion(True)
        Me.UcBarraNavegacion1.PermitirEditar = True
        Me.UcBarraNavegacion1.PermitirAgregar = False
        Me.UcBarraNavegacion1.PermitirGuardar = True
        inicializarPanel1()
        Dim Cp As New cPROCESOCOMPRAS
        Dim P As New ABASTECIMIENTOS.ENTIDADES.PROCESOCOMPRAS
        P.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        P.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Cp.ObtenerPROCESOCOMPRAS(P)

        If P.FECHAHORAFINRECEPCION < Today Then
            Me.MsgBox1.ShowAlert("La fecha para recibir ofertas ha expirado.", "r", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Private Sub inicializarPanel1()
        Me.UcBarraNavegacion1.PermitirAgregar = False
        obtenerListaOfertasPresentadas()
        Me.txtPersonaEntrega.Text = ""
        tpHoraEntrega.SelectedTime = Now.TimeOfDay.ToString
    End Sub

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar
        Me.UcBarraNavegacion1.Visible = True
        Me.UcBarraNavegacion1.PermitirEditar = False
        Me.UcBarraNavegacion1.HabilitarEdicion(False)
        Me.UcBarraNavegacion1.PermitirGuardar = False
        Me.UcBarraNavegacion1.PermitirImprimir = False
        Me.UcBarraNavegacion1.PermitirAgregar = True
        Me.Panel1.Visible = False
    End Sub

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar

        Dim lEntidad As New RECEPCIONOFERTAS
        'Guardar recepcion de ofertas
        Try
            With lEntidad
                .FECHAENTREGA = Me.tpHoraEntrega.SelectedValue.ToString
                .IDESTABLECIMIENTO = Session("IDEstablecimiento")
                .IDPROCESOCOMPRA = Request.QueryString("idProc")
                .IDPROVEEDOR = Me.ddlProveedorEntregaBase.SelectedValue
                .ORDENLLEGADA = Me.lblOrden.Text
                .PERSONAENTREGA = Me.txtPersonaEntrega.Text
            End With

            Dim fechaRecepcion As String
            fechaRecepcion = Me.tpHoraEntrega.SelectedTime

            mComponente.AgregarRECEPCIONOFERTAS(lEntidad)

            obtenerListaOfertasPresentadas()
            Me.Panel1.Visible = False
            Me.UcBarraNavegacion1.PermitirEditar = False
            Me.UcBarraNavegacion1.PermitirGuardar = False
            Me.UcBarraNavegacion1.PermitirImprimir = False
            Me.UcBarraNavegacion1.PermitirAgregar = True
            Me.UcBarraNavegacion1.HabilitarEdicion(False)
            Me.btnImprimirPresntaronOfertas.Visible = True
            Me.Button2.Visible = True

        Catch ex As Exception
            Me.MsgBox1.ShowAlert("Error al guardar el registro", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        End Try

    End Sub

    Protected Sub btnImprimirPresntaronOfertas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimirPresntaronOfertas.Click
        Dim proceso As String = Request.QueryString("idProc")
        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmrptPresentaronOfertas.aspx?id=" + proceso + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.dgOfertaPresentada.Rows.Count = 0 Then
            Me.MsgBox1.ShowAlert("El proceso de recepción aún no ha sido finalizado.", "s", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            Dim Cp As New cPROCESOCOMPRAS
            Dim P As New ABASTECIMIENTOS.ENTIDADES.PROCESOCOMPRAS
            P.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            P.IDPROCESOCOMPRA = Request.QueryString("idProc")
            Cp.ObtenerPROCESOCOMPRAS(P)

            If P.FECHAHORAFINAPERTURA < Today Then
                Me.MsgBox1.ShowAlert("La fecha para realizar la apertura de ofertas ha expirado.", "r", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If

            consultarEmpresaPresentaOferta()
            Me.Panel2.Visible = True
            Me.Panel3.Visible = False
            Me.Button2.Visible = False
        End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mComponente As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS

        If validaActaApertura() = True Then
            With lEntidad
                .ACTAAPERTURA = Me.txtNoActa.Text
                .FECHAREALIZADAAPERTURA = Me.cpFechaRealizadoProceso.SelectedDate & " " & Me.tpHoraRealizadoProceso.SelectedTime.TimeOfDay.ToString
                .LUGARAPERTURABASE = Me.txtLugarApertura.Text
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                .IDPROCESOCOMPRA = Request.QueryString("idProc")
                .IDESTADOPROCESOCOMPRA = 5 'Permanece en Aperturar ofertas.
                .OBSERVACIONESACTA = Me.txtObservacionesActa.Text
                .AUUSUARIOMODIFICACION = User.Identity.Name
                .AUFECHAMODIFICACION = Date.Now
            End With
            If mComponente.ActualizarPROCESOCOMPRASAperturaBase(lEntidad) = 1 Then

                'Inserta valores en REPRESENTANTEAPERTURAPROCESOS

                Dim mComponenteRAC As New cREPRESENTANTEAPERTURAPROCESOS
                Dim lEntidadRAC As New REPRESENTANTEAPERTURAPROCESOS

                Dim dsAP As Data.DataSet
                dsAP = mComponenteRAC.ObtenerRepresentantes(Session("IdEstablecimiento"), Request.QueryString("idProc"))

                If dsAP.Tables(0).Rows.Count = 0 Then

                    'NO EXISTEN REGISTROS EN LA TABLA
                    lEntidadRAC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    lEntidadRAC.IDPROCESOCOMPRA = Request.QueryString("idProc")

                    If Not Me.txtNombre1.Text = Nothing Then
                        lEntidadRAC.IDDETALLE = 1
                        lEntidadRAC.NOMBRE = Me.txtNombre1.Text
                        lEntidadRAC.CARGO = Me.txtCargo1.Text
                        lEntidadRAC.AUUSUARIOCREACION = User.Identity.Name
                        lEntidadRAC.AUFECHACREACION = Now
                        mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                    End If

                    If Not Me.txtNombre2.Text = Nothing Then
                        lEntidadRAC.IDDETALLE = 2
                        lEntidadRAC.NOMBRE = Me.txtNombre2.Text
                        lEntidadRAC.CARGO = Me.txtCargo2.Text
                        lEntidadRAC.AUUSUARIOCREACION = User.Identity.Name
                        lEntidadRAC.AUFECHACREACION = Now
                        mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                    End If

                    If Not Me.txtNombre3.Text = Nothing Then
                        lEntidadRAC.IDDETALLE = 3
                        lEntidadRAC.NOMBRE = Me.txtNombre3.Text
                        lEntidadRAC.CARGO = Me.txtCargo3.Text
                        lEntidadRAC.AUUSUARIOCREACION = User.Identity.Name
                        lEntidadRAC.AUFECHACREACION = Now
                        mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                    End If

                    If Not Me.txtNombre4.Text = Nothing Then
                        lEntidadRAC.IDDETALLE = 4
                        lEntidadRAC.NOMBRE = Me.txtNombre4.Text
                        lEntidadRAC.CARGO = Me.txtCargo4.Text
                        lEntidadRAC.AUUSUARIOCREACION = User.Identity.Name
                        lEntidadRAC.AUFECHACREACION = Now
                        mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                    End If

                Else ' EXISTEN REGISTROS EN LA TABLA
                    mComponenteRAC.EliminarTodos(Session("IdEstablecimiento"), Request.QueryString("idProc"))

                    lEntidadRAC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    lEntidadRAC.IDPROCESOCOMPRA = Request.QueryString("idProc")

                    If Not Me.txtNombre1.Text = Nothing Then
                        lEntidadRAC.IDDETALLE = 1
                        lEntidadRAC.NOMBRE = Me.txtNombre1.Text
                        lEntidadRAC.CARGO = Me.txtCargo1.Text
                        lEntidadRAC.AUUSUARIOCREACION = User.Identity.Name
                        lEntidadRAC.AUFECHACREACION = Now
                        mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                    End If

                    If Not Me.txtNombre2.Text = Nothing Then
                        lEntidadRAC.IDDETALLE = 2
                        lEntidadRAC.NOMBRE = Me.txtNombre2.Text
                        lEntidadRAC.CARGO = Me.txtCargo2.Text
                        lEntidadRAC.AUUSUARIOCREACION = User.Identity.Name
                        lEntidadRAC.AUFECHACREACION = Now
                        mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                    End If

                    If Not Me.txtNombre3.Text = Nothing Then
                        lEntidadRAC.IDDETALLE = 3
                        lEntidadRAC.NOMBRE = Me.txtNombre3.Text
                        lEntidadRAC.CARGO = Me.txtCargo3.Text
                        lEntidadRAC.AUUSUARIOCREACION = User.Identity.Name
                        lEntidadRAC.AUFECHACREACION = Now
                        mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                    End If

                    If Not Me.txtNombre4.Text = Nothing Then
                        lEntidadRAC.IDDETALLE = 4
                        lEntidadRAC.NOMBRE = Me.txtNombre4.Text
                        lEntidadRAC.CARGO = Me.txtCargo4.Text
                        lEntidadRAC.AUUSUARIOCREACION = User.Identity.Name
                        lEntidadRAC.AUFECHACREACION = Now
                        mComponenteRAC.AgregarREPRESENTANTEAPERTURAPROCESOS(lEntidadRAC)
                    End If

                End If

            End If
        End If

        Dim mComponenteOPC As New cOFERTAPROCESOCOMPRA
        Dim lEntidadOPC As New OFERTAPROCESOCOMPRA


        Dim i As Integer
        For i = 0 To Me.dgEmpresaPresentaOferta.Items.Count - 1

            With lEntidadOPC

                .NOMBREREPRESENTANTE = "NA"
                .MONTOOFERTA = CType(Me.dgEmpresaPresentaOferta.Items(i).Cells(4).Controls(3), eWorld.UI.NumericBox).Text
                .MONTOGARANTIA = 0
                .IDPROVEEDOR = Me.dgEmpresaPresentaOferta.Items(i).Cells(3).Text
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                .IDPROCESOCOMPRA = Request.QueryString("idProc")
                .ESTAHABILITADO = 1
                .OBSERVACION = ""
                .ESTASINCRONIZADA = 0

            End With

            Dim dsOPC As Data.DataSet
            dsOPC = mComponenteOPC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.dgEmpresaPresentaOferta.Items(i).Cells(3).Text)

            If dsOPC.Tables(0).Rows.Count = 0 Then
                lEntidadOPC.AUUSUARIOCREACION = User.Identity.Name
                lEntidadOPC.AUFECHACREACION = Date.Now
                mComponenteOPC.AgregarOFERTAPROCESOCOMPRA(lEntidadOPC)
            Else
                lEntidadOPC.AUUSUARIOMODIFICACION = User.Identity.Name
                lEntidadOPC.AUFECHAMODIFICACION = Date.Now
                mComponenteOPC.ActualizarMontos(lEntidadOPC)
            End If
        Next


        Me.MsgBox1.ShowAlert("El registro se ha guardado satisfactoriamente", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

    End Sub

    Private Function validaActaApertura() As Boolean

        If Me.txtNoActa.ReadOnly = False Then
            Dim mComProcesoCompra As New cPROCESOCOMPRAS

            Dim ds As Data.DataSet
            ds = mComProcesoCompra.ObtenerNoActaApertura(Session("IdEstablecimiento"), Me.txtNoActa.Text)

            If ds.Tables(0).Rows.Count > 0 Then
                Me.MsgBox1.ShowAlert("El número de acta ya existe", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If

    End Function

    Private Sub consultarProcesoCompra()
        Dim mComponente As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS

        With lEntidad
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDPROCESOCOMPRA = Request.QueryString("idProc")
        End With

        Dim ds As Data.DataSet
        ds = mComponente.recuperarDatosProcesoCompra(lEntidad)

        With ds.Tables(0).Rows(0)
            Try
                Me.txtNoActa.Text = .Item("ACTAAPERTURA")
                Me.txtNoActa.ReadOnly = True
            Catch ex As Exception
                Me.txtNoActa.ReadOnly = False
                Me.txtNoActa.Text = ""
            End Try

            Me.txtObservacionesActa.Text = .Item("OBSERVACIONESACTA").ToString

        End With
    End Sub

    Private Sub consultarEmpleados()
        Dim mComponenteRAC As New cREPRESENTANTEAPERTURAPROCESOS
        Dim lEntidadRAC As New REPRESENTANTEAPERTURAPROCESOS

        Dim dsRAC As Data.DataSet
        dsRAC = mComponenteRAC.ObtenerRepresentantes(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        If dsRAC.Tables(0).Rows.Count = 0 Then

        Else

            Dim dr As Data.DataRow = dsRAC.Tables(0).NewRow
            Dim i As Integer = 0
            For Each dr In dsRAC.Tables(0).Rows
                Select Case i
                    Case 0
                        Me.lblId1.Text = dr(2)
                        Me.txtNombre1.Text = dr(3)
                        Me.txtCargo1.Text = dr(4)
                    Case 1
                        Me.lblId2.Text = dr(2)
                        Me.txtNombre2.Text = dr(3)
                        Me.txtCargo2.Text = dr(4)
                    Case 2
                        Me.lblId3.Text = dr(2)
                        Me.txtNombre3.Text = dr(3)
                        Me.txtCargo3.Text = dr(4)
                    Case 3
                        Me.lblId4.Text = dr(2)
                        Me.txtNombre4.Text = dr(3)
                        Me.txtCargo4.Text = dr(4)
                End Select
                i += 1
            Next
        End If

    End Sub

    Private Sub verificaProcesoAperturado()
        Dim mComProcCompra As New cPROCESOCOMPRAS

        Dim ds As Data.DataSet
        ds = mComProcCompra.ObtenerDataSetPorId(IDESTABLECIMIENTO, Request.QueryString("idProc"))

        With ds.Tables(0).Rows(0)
            If IsDBNull(.Item("LUGARAPERTURABASE")) Then
                Me.txtLugarApertura.Text = ""
            Else
                Me.txtLugarApertura.Text = .Item("LUGARAPERTURABASE")
            End If

            Try
                cpFechaRealizadoProceso.SelectedDate = Format(.Item("FECHAREALIZADAAPERTURA"), "dd/MM/yyyy")
                tpHoraRealizadoProceso.SelectedTime = Format(.Item("FECHAREALIZADAAPERTURA"), "HH:mm")
            Catch ex As Exception

            End Try
        End With

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Response.Write("<script language=javascript>")
        'Response.Write("window.open('" + Request.ApplicationPath + "/Reportes/FrmRptActaAperturaOfertaLG.aspx?idProc=" & Request.QueryString("idProc") & "&noACTA=" & Me.txtNoActa.Text & " ');")
        'Response.Write("</script>")
        SINAB_Utils.Utils.MostrarVentana("/Reportes/FrmRptActaAperturaOfertaLG.aspx?idProc=" & Request.QueryString("idProc") & "&noACTA=" & Me.txtNoActa.Text)
    End Sub

    Private Sub consultarEmpresaPresentaOferta()

        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDataSet_OfertasRecibidas(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        If ds.Tables(0).Rows.Count > 0 Then
            Me.dgEmpresaPresentaOferta.DataSource = ds
            Me.dgEmpresaPresentaOferta.DataBind()
        End If
    End Sub

End Class
