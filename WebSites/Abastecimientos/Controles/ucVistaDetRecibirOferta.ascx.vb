Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Linq
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Utils
Imports SINAB_Utils.MessageBox
Imports SINAB_Entidades.Tipos

Partial Class Controles_ucVistaDetRecibirOferta
    Inherits System.Web.UI.UserControl

    Private _IDPROCESOCOMPRA, _IDESTABLECIMIENTO As Int64
    Private _permiteGuardar As Boolean = False
    Private _action As Integer
    Private _IDUNIDADMEDIDA As Integer
    Private _IDPROVEEDOR As Integer

#Region " Propiedades "

    Public Property IDPROCESOCOMPRA() As Int64
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Int64)
            _IDPROCESOCOMPRA = value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IDPROCESOCOMPRA", value)
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

#End Region

    Public Sub CargarDatos()
        UcVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = IDPROCESOCOMPRA
        UcVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = CType(IDESTABLECIMIENTO, Integer)
        UcVistaDetalleSolicProcesCompra1.Consultar()

        Me.UcVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
        Me.UcVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False
    End Sub

    Public Sub ocultarQuitarSolicitud()
        UcVistaDetalleSolicProcesCompra1.ocultarQuitarSolicitud()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            With Me.UcBarraNavegacion1
                .PermitirImprimir = False
                .PermitirGuardar = False
                .PermitirEditar = False
                .HabilitarEdicion(False)
                .PermitirConsultar = False
                .Navegacion = False

            End With
            ConsultarDatosProcesoCompra()
            Me.ConsultarProveedoresRetiraBase()
            ConfiguraListaOfertaspresentadas()
            ValidaTiempoVencido()
        Else
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me._IDPROCESOCOMPRA = CType(Me.ViewState("IdProcesoCompra"), Long)
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = CType(Me.ViewState("IDESTABLECIMIENTO"), Long)
            If Not Me.ViewState("action") Is Nothing Then Me._action = CType(Me.ViewState("action"), Integer)
            If Not Me.ViewState("permiteGuardar") Is Nothing Then Me._permiteGuardar = CType(Me.ViewState("permiteGuardar"), Boolean)
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me._IDUNIDADMEDIDA = CType(Me.ViewState("IDUNIDADMEDIDA"), Integer)
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = CType(Me.ViewState("IDPROVEEDOR"), Integer)

            If ConfirmTarget = "Finalizado" Then ProcesarFinalizado()
        End If

    End Sub

    Private Sub ProcesarFinalizado()
        Response.Redirect("~/UACI/FrmMantRecibirOferta.aspx")
    End Sub



    Private Sub ValidaTiempoVencido()

        Dim lEntidad = UACIHelpers.ProcesoCompras.Obtener(Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO, CType(Request.QueryString("idProc"), Integer))

        If Date.Now > CDate(lEntidad.FECHAHORAFINRECEPCION) Then
            divError.Visible = True
            Me.lblWarning.Text = "Aviso: El tiempo definido para la recepción de ofertas ya expiró"
        Else
            divError.Visible = False
        End If

    End Sub

    Private Sub ConsultarDatosProcesoCompra()

        ctlFechas.CargarDatos(Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO, CType(Request.QueryString("idProc"), Integer))


        
    End Sub

    Private Sub ConsultarProveedoresRetiraBase()
        Dim ds = UACIHelpers.EntregaBases.ObtenerTodos(Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO, CType(IDPROCESOCOMPRA, Integer))

        If ds.Any() Then
            dgProveedorRetiraBase.DataSource = ds
            dgProveedorRetiraBase.DataBind()
        End If

        Dim mComponenteRO As New cRECEPCIONOFERTAS

        Dim dsProveedores As Data.DataSet
        dsProveedores = mComponenteRO.obtenerProveedoresNoAsignados(CType(Request.QueryString("idProc"), Long), Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO)

        If dsProveedores.Tables(0).Rows.Count > 0 Then
            Me.ddlProveedorEntregaBase.DataSource = dsProveedores
            Me.ddlProveedorEntregaBase.DataTextField = "NOMBRE"
            Me.ddlProveedorEntregaBase.DataValueField = "IDPROVEEDOR"
            Me.ddlProveedorEntregaBase.DataBind()
        Else
            Me.UcBarraNavegacion1.PermitirAgregar = False
            Me.UcBarraNavegacion1.Visible = False
        End If

    End Sub



    Private Sub InicializarPanel1()
        tpFechaEntrega.Visible = False
        ddlProveedorEntregaBase.Enabled = True
        Me.UcBarraNavegacion1.PermitirAgregar = False
        ConfiguraListaOfertaspresentadas()
        ConsultarProveedoresRetiraBase()
        Me.txtPersonaEntrega.Text = ""
        tpHoraEntrega.Text = DateTime.Now.ToString("hh:mm tt")
    End Sub

    Private Sub ConfiguraListaOfertaspresentadas()
        ObtenerListaOfertasPresentadas()
    End Sub

    Private Sub ObtenerListaOfertasPresentadas()

        Me.UcBarraNavegacion1.PermitirAgregar = True

        Dim ds = UACIHelpers.RecepcionOferta.ObtenerTodos(Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO, CType(Request.QueryString("idProc"), Integer))


        If ds.Any() Then
            Me.tbOrden.Text = CType((ds.Count + 1), String)
        Else
            Me.tbOrden.Text = 1
        End If

        Me.dgOfertaPresentada.DataSource = ds
        Me.dgOfertaPresentada.DataBind()
    End Sub

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar
        With UcBarraNavegacion1
            .Visible = True
            .PermitirEditar = False
            .HabilitarEdicion(False)
            .PermitirGuardar = False
            .PermitirImprimir = False
            .PermitirAgregar = True
        End With
        Me.Panel1.Visible = False
    End Sub
    Protected Sub UcBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Agregar
        Panel1.Visible = True
        With UcBarraNavegacion1
            .HabilitarEdicion(True)
            .PermitirEditar = True
            .PermitirAgregar = False
            .PermitirGuardar = True
        End With


        InicializarPanel1()

    End Sub

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar
        Dim recepcionOferta As New SAB_UACI_RECEPCIONOFERTAS
        'Guardar recepcion de ofertas
        Dim fechaRecepcion = CType((DateTime.Now.ToShortDateString() & " " & tpHoraEntrega.Text), Date)
        With recepcionOferta
            .FECHAENTREGA = fechaRecepcion
            .IDESTABLECIMIENTO = CType(IDESTABLECIMIENTO, Integer)
            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
            .IDPROVEEDOR = CType(ddlProveedorEntregaBase.SelectedValue, Integer)
            .ORDENLLEGADA = CType(tbOrden.Text, Integer)
            .PERSONAENTREGA = txtPersonaEntrega.Text
            .DUIENTREGA = txtDuiPersonaEntrega.Text
        End With

        If Not UACIHelpers.RecepcionOferta.Existe(recepcionOferta) Then
            Dim idEstab = Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO
            Using db = New SinabEntities()
                Dim procesoCompra = UACIHelpers.ProcesoCompras.Obtener(db, idEstab, CType(Request.QueryString("idProc"), Integer))
                Dim maxRecepcion As DateTime

                If CDate(fechaRecepcion) < CDate(procesoCompra.FECHAHORAINICIORECEPCION) Then
                    Alert("La hora debe estar en el rango asignado para la recepción de ofertas entre las " & procesoCompra.FECHAHORAINICIORECEPCION.Value.ToString("HH:mm") & " y las " & procesoCompra.FECHAHORAFINRECEPCION.Value.ToString("HH:mm"), "Error")
                    Exit Sub
                Else
                    maxRecepcion = UACIHelpers.RecepcionOferta.ObtenerMaxFechaRecepcion(db, idEstab, CType(Request.QueryString("idProc"), Integer))
                    If maxRecepcion > DateTime.MinValue Then
                        If maxRecepcion > fechaRecepcion Then
                            Alert("El valor de la fecha de recepción debe ser mayor que la fecha de recepción del ultimo proveedor con fecha " & maxRecepcion.ToString("HH:mm"), "Error")
                        Else
                            ProcesarFecha(recepcionOferta, db)
                        End If
                    Else
                        ProcesarFecha(recepcionOferta, db)
                    End If
                End If
            End Using
        Else
            Try
                recepcionOferta.FECHAENTREGA = CType((tpFechaEntrega.Text & " " & tpHoraEntrega.Text), Date)
                UACIHelpers.RecepcionOferta.Actualizar(recepcionOferta)
                ObtenerListaOfertasPresentadas()
                Me.Panel1.Visible = False

            Catch ex As Exception
                Alert("Error al guardar el registro", "Error")
            End Try

            With UcBarraNavegacion1
                .PermitirEditar = False
                .PermitirGuardar = False
                .PermitirImprimir = False
                .PermitirAgregar = True
                .HabilitarEdicion(False)
            End With
            ConsultarProveedoresRetiraBase()
        End If
    End Sub

    Private Sub ProcesarFecha(ByVal recepcionOferta As SAB_UACI_RECEPCIONOFERTAS, ByVal db As SinabEntities)

        Try
            UACIHelpers.RecepcionOferta.Agregar(db, recepcionOferta)
            ObtenerListaOfertasPresentadas()
            Me.Panel1.Visible = False

        Catch ex As Exception
            Alert("Error al guardar el registro", "Error")
        End Try

        Me.UcBarraNavegacion1.PermitirEditar = False
        Me.UcBarraNavegacion1.PermitirGuardar = False
        Me.UcBarraNavegacion1.PermitirImprimir = False
        Me.UcBarraNavegacion1.PermitirAgregar = True
        Me.UcBarraNavegacion1.HabilitarEdicion(False)

        ConsultarProveedoresRetiraBase()
    End Sub


   

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim mComPC As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS

        'If validaDatosFinancierosProveedores(PROVEEDOR) = True Then
        With lEntidad
            .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO
            .IDPROCESOCOMPRA = CType(Request.QueryString("IdProc"), Long)
            .IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.APERTURADEOFERTA
            .AUFECHAMODIFICACION = DateTime.Now
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
        End With

        mComPC.ActualizarEstadoFinRecepcion(lEntidad)
        AlertSubmit("La recepción de ofertas ha finalizado satisfactoriamente", "Finalizado")


    End Sub

    Protected Sub dgProveedorRetiraBase_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgProveedorRetiraBase.PageIndexChanged
        Me.dgProveedorRetiraBase.CurrentPageIndex = e.NewPageIndex


        Dim ds = UACIHelpers.EntregaBases.ObtenerTodos(Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO, CType(IDPROCESOCOMPRA, Integer))
        If ds.Any() Then
            Me.dgProveedorRetiraBase.DataSource = ds
            Me.dgProveedorRetiraBase.DataBind()
        End If
    End Sub

    Protected Sub btnImprimirPresntaronOfertas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimirPresntaronOfertas.Click
        Utils.MostrarVentana("/Reportes/frmrptPresentaronOfertas.aspx?id=" + IDPROCESOCOMPRA.ToString())
        ' Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmrptPresentaronOfertas.aspx?id=" + IDPROCESOCOMPRA.ToString() + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

  

    Protected Sub dgOfertaPresentada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dgOfertaPresentada.SelectedIndexChanged
        Dim index As Integer = dgOfertaPresentada.SelectedIndex
        Dim idProveedor = CType(dgOfertaPresentada.DataKeys(index).Values(0), Integer)
        Dim idPreocesoCOmpra = CType(dgOfertaPresentada.DataKeys(index).Values(1), Integer)
        Dim idEstablecimiento = CType(dgOfertaPresentada.DataKeys(index).Values(2), Integer)

        Dim oferta = UACIHelpers.RecepcionOferta.Obtener(idEstablecimiento, idPreocesoCOmpra, idProveedor)

        Panel1.Visible = True
        With UcBarraNavegacion1
            .HabilitarEdicion(True)
            .PermitirEditar = True
            .PermitirAgregar = False
            .PermitirGuardar = True
        End With

        Me.UcBarraNavegacion1.PermitirAgregar = False
        'ConfiguraListaOfertaspresentadas()
        ' ConsultarProveedoresRetiraBase()


        '---------------------------------

        Dim ds = UACIHelpers.EntregaBases.ObtenerTodos(Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO, CType(IDPROCESOCOMPRA, Integer))

        With ddlProveedorEntregaBase
            If ds.Any() Then
                .DataSource = ds
                .DataTextField = "NOMBRE"
                .DataValueField = "IDPROVEEDOR"
                .DataBind()
            End If
            .SelectedValue = oferta.IDPROVEEDOR.ToString()
            .Enabled = False
        End With

        tbOrden.Text = oferta.ORDENLLEGADA.ToString()
        txtDuiPersonaEntrega.Text = oferta.DUIENTREGA
        txtPersonaEntrega.Text = oferta.PERSONAENTREGA
        tpHoraEntrega.Text = oferta.FECHAENTREGA.ToString("hh:mm tt")

        tpFechaEntrega.Visible = True
        tpFechaEntrega.Text = oferta.FECHAENTREGA.ToShortDateString()
    End Sub
End Class
