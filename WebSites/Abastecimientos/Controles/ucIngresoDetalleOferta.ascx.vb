Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data.OleDb
Imports System.IO
Imports SINAB_Utils.MessageBox

Partial Class ucIngresoDetalleOferta
    Inherits System.Web.UI.UserControl

    Private cDPC As New cDETALLEPROCESOCOMPRA
    Private cDO As New cDETALLEOFERTA

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

    Public Property IDUNIDADMEDIDA() As Integer
        Get
            Return _IDUNIDADMEDIDA
        End Get
        Set(ByVal value As Integer)
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me._IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("permiteGuardar") Is Nothing Then Me._permiteGuardar = Me.ViewState("permiteGuardar")
            If Not Me.ViewState("action") Is Nothing Then Me._action = Me.ViewState("action")
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me._IDUNIDADMEDIDA = Me.ViewState("IDUNIDADMEDIDA")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
        End If
    End Sub

    Public Sub CargarDatos()
        Me.obtenerListaOfertasPresentadas()
    End Sub

    Private Sub obtenerListaOfertasPresentadas()
        Dim cRO As New cRECEPCIONOFERTAS
        Dim ds As Data.DataSet
        ds = cRO.ObtenerDataSet_OfertasRecibidas(Request.QueryString("idProc"), Me.IDESTABLECIMIENTO)
        If ds.Tables(0).Rows.Count = 0 Then
            Me.lblOrden.Text = 1
        Else
            Me.lblOrden.Text = ds.Tables(0).Rows.Count + 1
        End If
        Me.dgOfertaPresentada.DataSource = ds
        Me.dgOfertaPresentada.DataBind()
    End Sub

    Private Sub cargarArchivos()

        Dim rutaDirectorio As String
        rutaDirectorio = Session("IdEstablecimiento") & "_" & Request.QueryString("IdProc") & "_" & Me.dgOfertaPresentada.SelectedItem.Cells(5).Text

        Directory.CreateDirectory(Server.MapPath(rutaDirectorio))

        Dim TargetPath As String = Server.MapPath(rutaDirectorio & "\" & Path.GetFileName(MyFile.PostedFile.FileName))
        'Dim TargetPath = "d:\files\" & Path.GetFileName(myFile.PostedFile.FileName)
        'y por ultimo se envia el archivo a el servidor esto e lo que hace que el archivo se 
        ' envie al el servidor
        MyFile.PostedFile.SaveAs(TargetPath)
        'por ultimo se le envia un mensaje al usuario avisandole el exito de su operación
        'si estas creando directorios dinamicamente para evitar que marque un error por que el 
        'directorio no existe puedes crear el directorio por medio de la siguiente instruccion
        ' Directory.CreateDirectory("/path")
        ' "/path" =la ruta donde se guardara el archivo en el servidor 
        Mensaje.Text = "El archivo se recibió correctamente "

        Dim existeFile As Boolean = False

        If Me.ListBox1.Items.Count > 0 Then
            For i As Integer = 0 To Me.ListBox1.Items.Count - 1
                If Me.ListBox1.Items(i).Text = MyFile.PostedFile.FileName Then
                    existeFile = True
                    Exit For
                End If
            Next
        End If

        If existeFile = False Then
            Me.ListBox1.Items.Add(MyFile.PostedFile.FileName)
        End If

    End Sub

    Private Sub CargarDatosDiscoOferta()

        Dim rutaDirectorio As String
        rutaDirectorio = Server.MapPath(Session("IdEstablecimiento") & "_" & Request.QueryString("IdProc") & "_" & Me.dgOfertaPresentada.SelectedItem.Cells(5).Text)

        Dim conString As String = "Provider=VFPOLEDB.1; Data Source=" & rutaDirectorio

        Dim ds As New Data.DataSet
        Dim da As New Data.OleDb.OleDbDataAdapter("select * from cdetoferta", conString)
        da.Fill(ds)

        Dim mEntidad As New DETALLEOFERTA

        For Each row As Data.DataRow In ds.Tables(0).Rows

            With mEntidad
                .CANTIDAD = row.Item("cantidad")
                .CASAREPRESENTADA = row.Item("casarepres").ToString.Trim
                .CORRELATIVORENGLON = row.Item("id_renglon")
                .DESCRIPCIONPROVEEDOR = row.Item("descripcio").ToString.Trim
                .IDDETALLE = 0
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                .IDESTADOCALIFICACION = eESTADOCALIFICACION.NOCALIFICADO
                .IDPROCESOCOMPRA = IDPROCESOCOMPRA
                .IDPROVEEDOR = Me.obtenerProveedor(row.Item("numproveed"))
                .IDUNIDADMEDIDA = Me.obtenerUnidad(row.Item("unidmedida"))
                .MARCA = row.Item("marca").ToString.Trim
                .NUMEROCSSP = row.Item("nrcssp").ToString.Trim
                .OBSERVACION = row.Item("observacio").ToString.Trim
                .ORIGEN = row.Item("origen").ToString.Trim
                .PLAZOENTREGA = row.Item("plazoentre").ToString.Trim
                .PRECIOUNITARIO = row.Item("preciounit")
                .RENGLON = row.Item("linea")
                .VENCIMIENTO = row.Item("vencimient").ToString.Trim
                .VIGENCIA = row.Item("vigenciaof").ToString.Trim

                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                .AUFECHACREACION = Now
            End With

            If cDO.ActualizarDETALLEOFERTA(mEntidad) <> 1 Then
                Me.lblMsg.Text = "Ha ocurrido un error, no se han ingresado los datos."
            Else
                Dim eDPC As New DETALLEPROCESOCOMPRA
                eDPC.IDESTABLECIMIENTO = mEntidad.IDESTABLECIMIENTO
                eDPC.IDPROCESOCOMPRA = mEntidad.IDPROCESOCOMPRA
                eDPC.RENGLON = mEntidad.RENGLON
                eDPC.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
                eDPC.AUFECHACREACION = Now

                Me.cDPC.ActualizarEstadoNoDesierto(eDPC)

                Me.lblMsg.Text = "Los registros se han cargado satisfactoriamente."
            End If
        Next

    End Sub

    Private Function CargarDatosDiscoFinan() As Boolean

        Dim rutaDirectorio As String
        rutaDirectorio = Server.MapPath(Session("IdEstablecimiento") & "_" & Request.QueryString("IdProc") & "_" & Me.dgOfertaPresentada.SelectedItem.Cells(5).Text)

        Dim conString As String = "Provider=VFPOLEDB.1; Data Source=" & rutaDirectorio

        Dim ds As New Data.DataSet
        Dim da As New OleDbDataAdapter("select * from cfinan", conString)
        da.Fill(ds)

        If Me.dgOfertaPresentada.SelectedItem.Cells(5).Text = Me.obtenerProveedor(ds.Tables(0).Rows(0).Item("numproveed")) Then
            Dim cOPC As New cOFERTAPROCESOCOMPRA
            Dim mEntidad As New OFERTAPROCESOCOMPRA

            Dim ds2 As Data.DataSet
            ds2 = cOPC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.dgOfertaPresentada.SelectedItem.Cells(5).Text)

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                With mEntidad
                    .IDPROCESOCOMPRA = Request.QueryString("IdProc")
                    .IDPROVEEDOR = Me.obtenerProveedor(ds.Tables(0).Rows(i).Item("numproveed"))
                    .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    .ACTIVOCIRCULANTE = ds.Tables(0).Rows(i).Item("activocirc")
                    .PASIVOCIRCULANTE = ds.Tables(0).Rows(i).Item("pasivocirc")
                    .ACTIVOTOTAL = ds.Tables(0).Rows(i).Item("activotota")
                    .PASIVOTOTAL = ds.Tables(0).Rows(i).Item("pasivotota")
                    If ds.Tables(0).Rows(i).Item("referencia") Then
                        .PRESENTAREFERENCIASBANCARIAS = 1
                    Else
                        .PRESENTAREFERENCIASBANCARIAS = 0
                    End If
                End With

                Dim result As Integer

                If ds2.Tables(0).Rows.Count > 0 Then
                    result = cOPC.ActualizarInfoFinanciera(mEntidad, 1)
                Else
                    result = cOPC.AgregarOFERTAPROCESOCOMPRA(mEntidad)
                End If

                If result <> 1 Then
                    Me.lblMsg.Text = "Ha ocurrido un error, no se han ingresado los datos"
                Else
                    Me.lblMsg.Text = "Los registros se han cargado satisfactoriamente"
                End If

            Next

            Return True

        Else
            Alert("No es posible realizar la carga de datos, los archivos que desea cargar pertenecen a otro proveedor", "Error")
            'Me.MsgBox2.ShowAlert("No es posible realizar la carga de datos, los archivos que desea cargar pertenecen a otro proveedor", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
            ListBox1.Items.Clear()
            Return False
        End If

    End Function

    Private Function obtenerProveedor(ByVal codigoProveedor As String) As Int64
        Dim cP As New cPROVEEDORES
        Return cP.ObtenerDataSetIDPROVEEDOR(codigoProveedor)
    End Function

    Private Function obtenerUnidad(ByVal unidadMedida As String) As Int64
        Dim cUM As New cUNIDADMEDIDAS
        Return cUM.ObtenerDataSetIDUNIDADMEDIDA(unidadMedida)
    End Function

    Private Function validaDatosFinancierosProveedores(ByRef proveedor As String) As Boolean
        Dim mComOFPC As New cOFERTAPROCESOCOMPRA
        Dim i As Integer
        Dim cumple As Boolean = True

        Dim cRO As New cRECEPCIONOFERTAS

        Dim ds As Data.DataSet
        ds = cRO.ObtenerDataSet_OfertasRecibidas(Request.QueryString("idProc"), Session("IDEstablecimiento"))


        For i = 0 To ds.Tables(0).Rows.Count - 1
            proveedor = ds.Tables(0).Rows(i).Item("NOMBRE")
            If mComOFPC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("IdProc"), ds.Tables(0).Rows(i).Item("IDPROVEEDOR")).Tables(0).Rows.Count > 0 Then
                cumple = True
            Else
                Return False
            End If
        Next

        Return cumple

    End Function

    Protected Sub dgOfertaPresentada_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgOfertaPresentada.PageIndexChanged
        Me.dgOfertaPresentada.CurrentPageIndex = e.NewPageIndex
        obtenerListaOfertasPresentadas()
    End Sub

    Protected Sub dgOfertaPresentada_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOfertaPresentada.SelectedIndexChanged
        Label40.Visible = True
        Me.Mensaje.Text = ""
        btnLeerInformacion.Visible = True
        Me.rblCargaDisco.Visible = True
        Me.imbCargaDatos.Visible = True
        Me.MyFile.Visible = True
        Me.Panel1.Visible = False
        Me.Panel4.Visible = False
        Me.Panel5.Visible = False
        Me.dgDetalleOferta.Visible = False

        pMostarDatos.Visible = False


        Me.rblCargaDisco.SelectedValue = "S"
        ListBox1.Visible = True
        Me.Label46.Visible = True
        Me.Label47.Visible = True


        Dim cOPC As New cOFERTAPROCESOCOMPRA

        Dim ds As Data.DataSet
        ds = cOPC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.dgOfertaPresentada.SelectedItem.Cells(5).Text)

        Me.IDPROVEEDOR = Me.dgOfertaPresentada.SelectedItem.Cells(5).Text
        Dim valor As Integer = 1

        If ds.Tables(0).Rows.Count > 0 Then
            If IsDBNull(ds.Tables(0).Rows(0).Item("ACTIVOCIRCULANTE")) Then
                valor = 0
            End If
        End If

        If ds.Tables(0).Rows.Count > 0 And valor = 1 Then
            Me.rblCargaDisco.Visible = False
            Me.MyFile.Visible = False
            Me.imbCargaDatos.Visible = False

            pMostarDatos.Visible = True

            Me.Label46.Visible = False
            Me.Label47.Visible = False
            Me.Label40.Visible = False
            btnLeerInformacion.Visible = False
            Me.ListBox1.Visible = False
        Else
            Me.rblCargaDisco.Enabled = True
            Me.ListBox1.Items.Clear()
            Me.MyFile.Visible = True
            ' Me.Label46.Text = "Lista de archivos que han sido cargados:"
            Me.Label46.ForeColor = Drawing.Color.Black
        End If

    End Sub

    Protected Sub rblCargaDisco_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblCargaDisco.SelectedIndexChanged
        If Me.rblCargaDisco.SelectedValue = "S" Then
            pMostarDatos.Visible = False
            Me.Panel4.Visible = False
            Me.Panel5.Visible = False
            Me.MyFile.Visible = True
            Me.Label40.Visible = True
            Me.Mensaje.Text = ""
            btnLeerInformacion.Visible = True
            ListBox1.Visible = True
            Me.Label46.Visible = True
            Me.Label47.Visible = True
            btnLeerInformacion.Visible = True
            Me.imbCargaDatos.Visible = True
            Me.Label48.Text = ""
            Me.Label49.Text = ""
        Else
            pMostarDatos.Visible = True
            Me.MyFile.Visible = False
            Me.Label40.Visible = False
            Me.Mensaje.Text = ""
            btnLeerInformacion.Visible = False
            Me.Label46.Visible = False
            Me.Label47.Visible = False
            ListBox1.Visible = False
            Me.Label48.Text = "Paso 1. Ingresar datos financieros"
            Me.Label49.Text = "Paso 2. Ingresar datos del producto"
            btnLeerInformacion.Visible = False
            Me.imbCargaDatos.Visible = False
        End If
    End Sub

    Protected Sub LinkButton1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.Panel5.Visible = True
        Me.Panel4.Visible = False
        With Me.ucBarraNavegacion3
            .PermitirAgregar = False
            .PermitirConsultar = False
            .PermitirEditar = True
            .PermitirGuardar = True
            .Navegacion = False
            .HabilitarEdicion(True)
            .PermitirImprimir = False
        End With
        obtenerDatosFinancieros()
        Me.lblFecha.Text = Today
        Me.lblNo.Text = Request.QueryString("IdProc")
        Me.lblNombreProveedor.Text = Me.dgOfertaPresentada.SelectedItem.Cells(2).Text

        Dim cRO As New cRECEPCIONOFERTAS

        Dim ds As Data.DataSet
        ds = cRO.obtenerDescripcionRazon(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.dgOfertaPresentada.SelectedItem.Cells(5).Text)

        Me.lblDescripcionProcesoCompra.Text = ds.Tables(0).Rows(0).Item("DESCRIPCIONLICITACION")
        Me.lblRazonSocial.Text = ds.Tables(0).Rows(0).Item("NOMBRE")

    End Sub

    Private Sub obtenerDatosFinancieros()

        Dim cOPC As New cOFERTAPROCESOCOMPRA

        Dim ds As Data.DataSet
        ds = cOPC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.dgOfertaPresentada.SelectedItem.Cells(5).Text)

        If ds.Tables(0).Rows.Count > 0 Then
            If IsDBNull(ds.Tables(0).Rows(0).Item("ACTIVOCIRCULANTE")) Then
                Me.txtActivoCirculante.Text = ""
            Else
                Me.txtActivoCirculante.Text = ds.Tables(0).Rows(0).Item("ACTIVOCIRCULANTE")
            End If
            If IsDBNull(ds.Tables(0).Rows(0).Item("ACTIVOTOTAL")) Then
                Me.txtActivoTotal.Text = ""
            Else
                Me.txtActivoTotal.Text = ds.Tables(0).Rows(0).Item("ACTIVOTOTAL")
            End If
            If IsDBNull(ds.Tables(0).Rows(0).Item("PASIVOCIRCULANTE")) Then
                Me.txtPasivoCirculante.Text = ""
            Else
                Me.txtPasivoCirculante.Text = ds.Tables(0).Rows(0).Item("PASIVOCIRCULANTE")
            End If
            If IsDBNull(ds.Tables(0).Rows(0).Item("PASIVOTOTAL")) Then
                Me.txtPasivoTotal.Text = ""
            Else
                Me.txtPasivoTotal.Text = ds.Tables(0).Rows(0).Item("PASIVOTOTAL")
            End If
            If IsDBNull(ds.Tables(0).Rows(0).Item("PRESENTAREFERENCIASBANCARIAS")) Then
                Me.rblReferenciaBancaria.SelectedValue = 1
            Else
                Me.rblReferenciaBancaria.SelectedValue = ds.Tables(0).Rows(0).Item("PRESENTAREFERENCIASBANCARIAS")
            End If

            Me.ucBarraNavegacion3.PermitirGuardar = True
        Else
            Me.txtActivoCirculante.Text = ""
            Me.txtActivoTotal.Text = ""
            Me.txtPasivoCirculante.Text = ""
            Me.txtPasivoTotal.Text = ""
            Me.rblReferenciaBancaria.SelectedValue = 1
        End If
    End Sub

    Protected Sub LinkButton2_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click

        If validaDatosFinancieros() = True Then
            Me.Panel2.Visible = False
            Me.Panel4.Visible = True
            Me.Panel5.Visible = False
            With ucBarraNavegacion2
                Me.ucBarraNavegacion2.Visible = True
                Me.ucBarraNavegacion2.PermitirImprimir = False
                Me.ucBarraNavegacion2.PermitirAgregar = True
                Me.ucBarraNavegacion2.PermitirGuardar = False
                Me.ucBarraNavegacion2.PermitirEditar = False

                Me.ucBarraNavegacion2.HabilitarEdicion(False)
                Me.ucBarraNavegacion2.PermitirConsultar = False
                Me.ucBarraNavegacion2.Navegacion = False
            End With

            cargarDatosDetalleOferta()

            Me.dgDetalleOferta.Visible = True

            UcBarraNavegacion2_Agregar(sender, e)
        Else
            Alert("Primero debe ingresar los datos financieros", "Obligatorio")
            'Me.MsgBox1.ShowAlert("Primero debe ingresar los datos financieros", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        End If

    End Sub

    Private Function validaDatosFinancieros() As Boolean
        Dim mComOPC As New cOFERTAPROCESOCOMPRA
        Dim ds As Data.DataSet
        ds = mComOPC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.dgOfertaPresentada.SelectedItem.Cells(5).Text)

        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub cargarDatosDetalleOferta()
        Me.dgDetalleOferta.DataSource = cDO.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.dgOfertaPresentada.SelectedItem.Cells(5).Text)
        Me.dgDetalleOferta.DataBind()
    End Sub

    

    Protected Sub UcBarraNavegacion2_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion2.Agregar
        Me.Panel2.Visible = True
        Me.ucBarraNavegacion2.HabilitarEdicion(True)
        Me.ucBarraNavegacion2.PermitirEditar = False
        Me.ucBarraNavegacion2.PermitirGuardar = False
        Me.ucBarraNavegacion2.PermitirAgregar = False



        lblMsg.Text = ""

        Me.ddlRenglon.DataTextField = "RENGLON"
        Me.ddlRenglon.DataValueField = "RENGLON"
        Me.ddlRenglon.DataBind()
        Me.txtCasaRepresentada.Text = ""
        cargarDatosPanel4()
        obtenerProductoRenglon()
        Me.ddlUNIDADMEDIDAS1.SelectedValue = IDUNIDADMEDIDA
        Me.txtDescripcionProveedor.Text = ""
        Me.txtMarcaProductoOfertado.Text = ""
        Me.txtOrigen.Text = ""
        Me.txtVencimiento.Text = ""
        Me.txtPrecioUnitario.Text = ""
        Me.txtPrecioTotalCalculado.Text = ""
        Me.txtPlazoEntrega.Text = ""
        Me.txtCSSP.Text = ""
        Me.txtVigenciaOferta.Text = ""
        Me.txtObservaciones.Text = ""
        action = 0
    End Sub

    Private Sub cargarDatosPanel4()
        Me.lblProcesoCompra.Text = Request.QueryString("IdProc")
        Me.lblProveedor.Text = Me.dgOfertaPresentada.SelectedItem.Cells(2).Text
        Me.ddlUNIDADMEDIDAS1.Recuperar()

        Me.ddlRenglon.DataSource = Me.cDPC.ObtenerDataSetPorId(Me.lblProcesoCompra.Text, Session("IdEstablecimiento"))
        Me.ddlRenglon.DataTextField = "RENGLON"
        Me.ddlRenglon.DataValueField = "RENGLON"
        Me.ddlRenglon.DataBind()

        obtenerProductoRenglon()
        Me.ddlUNIDADMEDIDAS1.SelectedValue = IDUNIDADMEDIDA
    End Sub

    Private Sub obtenerProductoRenglon()
        Dim ds As Data.DataSet
        ds = Me.cDPC.obtenerDSRenglonProducto(Request.QueryString("IdProc"), Session("IdEstablecimiento"), Me.ddlRenglon.SelectedValue)
        Me.txtCantidad.Text = ds.Tables(0).Rows(0).Item("CANTIDAD")
        IDUNIDADMEDIDA = ds.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
        Me.lblDescripcionGenericaProducto.Text = ds.Tables(0).Rows(0).Item("DESCLARGO")
    End Sub

    Protected Sub UcBarraNavegacion2_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion2.Cancelar
        Me.Panel2.Visible = False
        Me.ucBarraNavegacion2.PermitirAgregar = True
        Me.ucBarraNavegacion2.PermitirEditar = False
        Me.ucBarraNavegacion2.HabilitarEdicion(True)
        Me.ucBarraNavegacion2.PermitirGuardar = False
        Me.ucBarraNavegacion2.PermitirEditar = False
        Me.ucBarraNavegacion2.PermitirAgregar = True


    End Sub

    Protected Sub UcBarraNavegacion2_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion2.Guardar
        Me.Panel2.Visible = False

        Dim lEntidad As New DETALLEOFERTA

        With lEntidad
            .IDPROCESOCOMPRA = Request.QueryString("IdProc")
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDPROVEEDOR = Me.dgOfertaPresentada.SelectedItem.Cells(5).Text

            .IDDETALLE = cDO.ObtenerIDDETALLE(lEntidad)
            .RENGLON = Me.ddlRenglon.SelectedValue
            .CASAREPRESENTADA = Me.txtCasaRepresentada.Text
            .MARCA = Me.txtMarcaProductoOfertado.Text
            .ORIGEN = Me.txtOrigen.Text
            .DESCRIPCIONPROVEEDOR = Me.txtDescripcionProveedor.Text
            .VENCIMIENTO = Me.txtVencimiento.Text
            .IDUNIDADMEDIDA = Me.ddlUNIDADMEDIDAS1.SelectedValue
            .CANTIDAD = Me.txtCantidad.Text
            .PRECIOUNITARIO = Me.txtPrecioUnitario.Text
            .PLAZOENTREGA = Me.txtPlazoEntrega.Text
            .NUMEROCSSP = Me.txtCSSP.Text
            .VIGENCIA = Me.txtVigenciaOferta.Text
            .OBSERVACION = Me.txtObservaciones.Text
            .CORRELATIVORENGLON = cDO.validarExistenciaOferta(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.dgOfertaPresentada.SelectedItem.Cells(5).Text, Me.ddlRenglon.SelectedValue)
        End With

        If cDO.Agregar(lEntidad) <> 1 Then
            lblMsg.Text = "Ocurrió un error, el registro no pudo ser almacenado."
        End If

    End Sub

    Protected Sub imbGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imbGuardar.Click

        Me.Panel2.Visible = False

        Dim lEntidad As New DETALLEOFERTA

        Me.ucBarraNavegacion2.Visible = True
        Me.ucBarraNavegacion2.PermitirAgregar = True
        Me.ucBarraNavegacion2.PermitirEditar = False
        Me.ucBarraNavegacion2.HabilitarEdicion(False)
        Me.ucBarraNavegacion2.PermitirGuardar = False




        With lEntidad
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDPROCESOCOMPRA = Request.QueryString("IdProc")
            .IDPROVEEDOR = Me.dgOfertaPresentada.SelectedItem.Cells(5).Text

            .RENGLON = Me.ddlRenglon.SelectedValue
            .CASAREPRESENTADA = Me.txtCasaRepresentada.Text
            .MARCA = Me.txtMarcaProductoOfertado.Text
            .ORIGEN = Me.txtOrigen.Text
            .DESCRIPCIONPROVEEDOR = Me.txtDescripcionProveedor.Text
            .VENCIMIENTO = Me.txtVencimiento.Text
            .IDUNIDADMEDIDA = Me.ddlUNIDADMEDIDAS1.SelectedValue
            .CANTIDAD = Me.txtCantidad.Text
            .PRECIOUNITARIO = Me.txtPrecioUnitario.Text
            .PLAZOENTREGA = Me.txtPlazoEntrega.Text
            .NUMEROCSSP = Me.txtCSSP.Text
            .VIGENCIA = Me.txtVigenciaOferta.Text
            .OBSERVACION = Me.txtObservaciones.Text
            .IDESTADOCALIFICACION = eESTADOCALIFICACION.NOCALIFICADO
        End With

        Dim resultado As Integer

        Try
            If action = 0 Then
                lEntidad.CORRELATIVORENGLON = cDO.validarExistenciaOferta(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.dgOfertaPresentada.SelectedItem.Cells(5).Text, Me.ddlRenglon.SelectedValue)
            Else
                lEntidad.IDDETALLE = Me.dgDetalleOferta.DataKeys(dgDetalleOferta.SelectedIndex).Values.Item("IDDETALLE")
                lEntidad.CORRELATIVORENGLON = Me.dgDetalleOferta.DataKeys(dgDetalleOferta.SelectedIndex).Values.Item("CORRELATIVORENGLON")
            End If

            resultado = cDO.ActualizarDETALLEOFERTA(lEntidad)

            If resultado <> 1 Then
                'Me.MsgBox1.ShowAlert("Ocurrio un error el registro no pudo ser almacenado", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                Alert("Ocurrio un error el registro no pudo ser almacenado", "Error")
            Else
                Dim eDPC As New DETALLEPROCESOCOMPRA
                eDPC.IDESTABLECIMIENTO = lEntidad.IDESTABLECIMIENTO
                eDPC.IDPROCESOCOMPRA = lEntidad.IDPROCESOCOMPRA
                eDPC.RENGLON = lEntidad.RENGLON
                eDPC.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                eDPC.AUFECHACREACION = Now

                Me.cDPC.ActualizarEstadoNoDesierto(eDPC)

                Me.lblMsg.ForeColor = Drawing.Color.Black
                cargarDatosDetalleOferta()
                Confirm("El registro se guardó satisfactoriamente, ¿desea agregar información para otro renglón?", "GRABARENGLON", OptionPostBack.YesPostBack)
                'Me.MsgBox1.ShowConfirm("El registro se guardó satisfactoriamente, ¿desea agregar información para otro renglón?", "GRABARENGLON", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
            End If

        Catch ex As Exception
            Alert(ex.Message, "Excepción")
            'Me.MsgBox1.ShowAlert(ex.Message, "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        End Try

    End Sub

    Protected Sub imbCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imbCancelar.Click
        Me.Panel2.Visible = False
        Me.ucBarraNavegacion2.HabilitarEdicion(False)
        Me.ucBarraNavegacion2.PermitirAgregar = True
        Me.ucBarraNavegacion2.PermitirEditar = False
        Me.ucBarraNavegacion2.PermitirGuardar = False
        Me.ucBarraNavegacion2.PermitirImprimir = False


    End Sub

    Protected Sub UcBarraNavegacion3_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion3.Cancelar
        Me.Panel5.Visible = False
        pMostarDatos.Visible = True
    End Sub

    Protected Sub UcBarraNavegacion3_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion3.Guardar
        Dim cOPC As New cOFERTAPROCESOCOMPRA
        Dim lEntidad As New OFERTAPROCESOCOMPRA
        Dim valido As Boolean = True

        If Me.txtActivoCirculante.Text = "" Then
            Me.Label42.Text = "Requerido"
            valido = False
        Else
            Me.Label42.Text = ""
        End If

        If Me.txtPasivoCirculante.Text = "" Then
            Me.Label43.Text = "Requerido"
            valido = False
        Else
            Me.Label43.Text = ""
        End If

        If Me.txtActivoTotal.Text = "" Then
            Me.Label44.Text = "Requerido"
            valido = False
        Else
            Me.Label44.Text = ""
        End If

        If Me.txtPasivoTotal.Text = "" Then
            Me.Label45.Text = "Requerido"
            valido = False
        Else
            Me.Label45.Text = ""
        End If

        If valido = True Then

            Dim ds As Data.DataSet
            ds = cOPC.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.dgOfertaPresentada.SelectedItem.Cells(5).Text)

            If ds.Tables(0).Rows.Count > 0 Then
                'ACTUALIZAR
                With lEntidad
                    .IDPROCESOCOMPRA = Request.QueryString("IdProc")
                    .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    .IDPROVEEDOR = Me.dgOfertaPresentada.SelectedItem.Cells(5).Text
                    .ACTIVOCIRCULANTE = Me.txtActivoCirculante.Text
                    .ACTIVOTOTAL = Me.txtActivoTotal.Text
                    .PASIVOCIRCULANTE = Me.txtPasivoCirculante.Text
                    .PASIVOTOTAL = Me.txtPasivoTotal.Text
                    .PRESENTAREFERENCIASBANCARIAS = Me.rblReferenciaBancaria.SelectedValue
                    .FECHAEXAMEN = Now.Date
                End With
                cOPC.ActualizarInfoFinanciera(lEntidad)
                AlertSubmit("El Registro se almacenó satisfactoriamente", "GRABA")
                'Me.MsgBox1.ShowAlert("El Registro se almacenó satisfactoriamente", "GRABA", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Information)
                Me.LinkButton2.Enabled = True
            Else
                'AGREGAR
                With lEntidad
                    .IDPROCESOCOMPRA = Request.QueryString("IdProc")
                    .NOMBREREPRESENTANTE = ""
                    .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    .IDPROVEEDOR = Me.dgOfertaPresentada.SelectedItem.Cells(5).Text
                    .ACTIVOCIRCULANTE = Me.txtActivoCirculante.Text
                    .ACTIVOTOTAL = Me.txtActivoTotal.Text
                    .PASIVOCIRCULANTE = Me.txtPasivoCirculante.Text
                    .PASIVOTOTAL = Me.txtPasivoTotal.Text
                    .PRESENTAREFERENCIASBANCARIAS = Me.rblReferenciaBancaria.SelectedValue
                    .FECHAEXAMEN = Now.Date
                End With

                If cOPC.AgregarOFERTAPROCESOCOMPRA(lEntidad) <> 1 Then
                    Alert("Ocurrio un error al ingresar el registro", "Error")
                    'Me.MsgBox1.ShowAlert("Ocurrio un error al ingresar el registro", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
                Else
                    AlertSubmit("El Registro se almacenó satisfactoriamente", "GRABA")
                    'Me.MsgBox1.ShowAlert("El Registro se almacenó satisfactoriamente", "GRABA", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Information)
                    Me.LinkButton2.Enabled = True
                End If
            End If
        End If

    End Sub

    Protected Sub dgDetalleOferta_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles dgDetalleOferta.SelectedIndexChanging
        'se pasa por parametro para editar el detalle de la oferta
        obtenerDatosDetalleOferta(Me.dgDetalleOferta.DataKeys(e.NewSelectedIndex).Values.Item("IDDETALLE"))
        Me.ucBarraNavegacion2.Visible = True
        Me.ucBarraNavegacion2.PermitirEditar = False
        Me.ucBarraNavegacion2.PermitirAgregar = True


    End Sub

    Private Sub obtenerDatosDetalleOferta(ByVal iddetalle As Integer)

        'Dim IDDETALLE As Integer = Me.dgDetalleOferta.DataKeys(dgDetalleOferta.SelectedIndex).Values.Item("IDDETALLE")


        Dim ds As Data.DataSet
        ds = cDO.ObtenerDataSetDetalleOferta(Request.QueryString("IdProc"), Session("IdEstablecimiento"), Me.dgOfertaPresentada.SelectedItem.Cells(5).Text, IDDETALLE)

        If ds.Tables(0).Rows.Count > 0 Then
            Me.Panel2.Visible = True
            With ds.Tables(0).Rows(0)
                Me.lblProcesoCompra.Text = Request.QueryString("IdProc")
                Me.lblProveedor.Text = Me.dgOfertaPresentada.SelectedItem.Cells(2).Text

                Me.ddlRenglon.DataSource = Me.cDPC.ObtenerDataSetPorId(Me.lblProcesoCompra.Text, Session("IdEstablecimiento"))
                Me.ddlRenglon.DataTextField = "RENGLON"
                Me.ddlRenglon.DataValueField = "RENGLON"
                Me.ddlRenglon.DataBind()
                Me.ddlRenglon.SelectedValue = .Item("RENGLON")

                Me.txtCasaRepresentada.Text = .Item("CASAREPRESENTADA")

                obtenerProductoRenglon()

                Try
                    Me.txtDescripcionProveedor.Text = .Item("DESCRIPCIONPROVEEDOR")
                Catch ex As Exception
                    Me.txtDescripcionProveedor.Text = ""
                End Try

                Me.txtMarcaProductoOfertado.Text = .Item("MARCA")
                Me.txtOrigen.Text = .Item("ORIGEN")
                Me.txtVencimiento.Text = .Item("VENCIMIENTO")
                Me.ddlUNIDADMEDIDAS1.Recuperar()
                Me.ddlUNIDADMEDIDAS1.SelectedValue = .Item("IDUNIDADMEDIDA")
                Me.txtCantidad.Text = .Item("CANTIDAD")
                Me.txtPrecioUnitario.Text = .Item("PRECIOUNITARIO")
                Me.txtPrecioTotalCalculado.Text = CDec(CDec(.Item("CANTIDAD")) * CDec(.Item("PRECIOUNITARIO")))
                Me.txtPlazoEntrega.Text = .Item("PLAZOENTREGA")

                Try
                    Me.txtCSSP.Text = .Item("NUMEROCSSP")
                Catch ex As Exception
                    Me.txtCSSP.Text = ""
                End Try

                Me.txtVigenciaOferta.Text = .Item("VIGENCIA")
                Try
                    Me.txtObservaciones.Text = .Item("OBSERVACION")
                Catch ex As Exception
                    Me.txtObservaciones.Text = ""
                End Try

            End With
            action = 1
        Else
            action = 0
            Me.lblProcesoCompra.Text = Request.QueryString("IdProc")
            Me.lblProveedor.Text = Me.dgOfertaPresentada.SelectedItem.Cells(5).Text

            Me.ddlRenglon.DataSource = Me.cDPC.ObtenerDataSetPorId(Me.lblProcesoCompra.Text, Session("IdEstablecimiento"))
            Me.ddlRenglon.DataTextField = "RENGLON"
            Me.ddlRenglon.DataValueField = "RENGLON"
            Me.ddlRenglon.DataBind()
            'Me.ddlRenglon.SelectedValue = .Item("RENGLON")
            Me.txtCasaRepresentada.Text = ""
            obtenerProductoRenglon()
            Me.txtDescripcionProveedor.Text = ""
            Me.txtMarcaProductoOfertado.Text = ""
            Me.txtOrigen.Text = ""
            Me.txtVencimiento.Text = ""
            Me.ddlUNIDADMEDIDAS1.SelectedValue = ""
            Me.txtCantidad.Text = ""
            Me.txtPrecioUnitario.Text = ""
            Me.txtPrecioTotalCalculado.Text = ""
            Me.txtPlazoEntrega.Text = ""
            Me.txtCSSP.Text = ""
            Me.txtVigenciaOferta.Text = ""
            Me.txtObservaciones.Text = ""

            Dim dsDPC As Data.DataSet
            dsDPC = Me.cDPC.obtenerDSRenglonProducto(Request.QueryString("IdProc"), Session("IdEstablecimiento"), Me.ddlRenglon.SelectedValue)

            Me.txtCantidad.Text = dsDPC.Tables(0).Rows(0).Item("CANTIDAD")
            IDUNIDADMEDIDA = dsDPC.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim precioTotal As Decimal
        If txtCantidad.Text <> "" Then
            If txtPrecioUnitario.Text <> "" Then
                precioTotal = CDec(Me.txtCantidad.Text) * CDec(Me.txtPrecioUnitario.Text)
                Me.txtPrecioTotalCalculado.Text = CStr(precioTotal)
            Else
                RequiredFieldValidator7.ErrorMessage = "El precio unitario es requerido"
                RequiredFieldValidator7.IsValid = False
            End If
        Else
            RequiredFieldValidator7.ErrorMessage = "Se requiere un valor para la cantidad"
            RequiredFieldValidator7.IsValid = False
        End If
    End Sub

    Protected Sub imbCargaDatos_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles imbCargaDatos.Click

        If Me.MyFile.FileName <> "" Then
            cargarArchivos()
            permiteGuardar = True
            Me.rblCargaDisco.Enabled = False
            btnLeerInformacion.Visible = True
        Else
            Alert("Debe seleccionar el archivo que desea cargar", "Obligatorio")
            'Me.MsgBox1.ShowAlert("Debe seleccionar el archivo que desea cargar", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If

        If Me.ListBox1.Items.Count = 3 Then
            ' Me.Label46.Text = "Ha cargado todos los archivos satisfactoriamente."
            Me.Label46.ForeColor = Drawing.Color.Red
        Else
            ' Me.Label46.Text = "Lista de archivos que han sido cargados:"
            Me.Label46.ForeColor = Drawing.Color.Black
        End If

    End Sub

    Protected Sub btnLeerInformacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLeerInformacion.Click
        'todo: ing inversa para cargar finan y oferta
        If ListBox1.Items.Count = 3 Then
            If CargarDatosDiscoFinan() = True Then
                CargarDatosDiscoOferta()
                Me.MyFile.Visible = False
                Me.imbCargaDatos.Visible = False
                Me.btnLeerInformacion.Visible = False
                pMostarDatos.Visible = True
            End If
        ElseIf ListBox1.Items.Count < 3 Then
            Alert("Faltan archivos por cargar al servidor", "Incompleto")
            'Me.MsgBox2.ShowAlert("Faltan archivos por cargar al servidor", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
        End If

    End Sub

    Protected Sub ddlRenglon_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRenglon.SelectedIndexChanged
        Me.txtCasaRepresentada.Text = ""
        Me.txtDescripcionProveedor.Text = ""
        Me.txtMarcaProductoOfertado.Text = ""
        Me.txtOrigen.Text = ""
        Me.txtVencimiento.Text = ""
        Me.txtPrecioUnitario.Text = ""
        Me.txtPrecioTotalCalculado.Text = ""
        Me.txtPlazoEntrega.Text = ""
        Me.txtCSSP.Text = ""
        Me.txtVigenciaOferta.Text = ""
        Me.txtObservaciones.Text = ""

        obtenerProductoRenglon()
        Me.ddlUNIDADMEDIDAS1.SelectedValue = IDUNIDADMEDIDA
    End Sub

    
    
End Class
