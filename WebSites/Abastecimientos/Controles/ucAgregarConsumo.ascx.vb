'CONTROL DE USUARIO PARA AGREGAR PRODUCTOS AL INGRESO DE CONSUMO
'UTILIZADO EN CU-ESTA002
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario que forma parte del ingreso de consumos de los establecimientos
'el cual permite agregar un producto al detalle del consumo

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data

Partial Class ucAgregarConsumo
    Inherits System.Web.UI.UserControl
    'INICIALIZACION DE VARIABLES

    Private _IDDETALLE As Int64
    Private _Enabled As Boolean = True
    Private _sError As String
    Private _nuevo As Boolean = False
    Public Event Cancelar As EventHandler
    Public Event Agregar As EventHandler
    Protected WithEvents dsDatos As System.Data.DataSet
    Private mComponente As New cDETALLECONSUMOS
    Private mCompProducto As New cCATALOGOPRODUCTOS
    Private mCompUnidadMedida As New cUNIDADMEDIDAS
    Private mEntidad As DETALLECONSUMOS

    Private mEntProductos As New CATALOGOPRODUCTOS
    Private mEntUnidadMedida As New UNIDADMEDIDAS
    Public Event ErrorEvent(ByVal errorMessage As String)


    'INICIALIZACION DE PROPIEDADES
    Public ReadOnly Property sError() As String 'MANEJA ERROR
        Get
            Return _sError
        End Get
    End Property

    Public Property IDDETALLE() As Int64
        Get
            Return Me._IDDETALLE
        End Get
        Set(ByVal Value As Int64)
            Me._IDDETALLE = Value
            Me.Nuevo()
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'EVENTO AL CARGAR PAGINA
        If Not IsPostBack Then 'LA PRIMERA VEZ
            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaHabilitadoXCodigoMSPAS(Session.Item("IdEstablecimiento"))
            Me.DdlUNIDADMEDIDAS1.Recuperar()
            Me.DdlGRUPOS1.RecuperarListaOrdenada()
            Me.txtCANTIDADCONSUMIDA.Text = 0
            Me.txtDEMANDAINSATISFECHA.Text = 0
            Me.txtEXISTENCIAACTUAL.Text = 0
            Me.LblDescripcionCompleta.Text = ""
            Me.lblproducto.Text = ""
            Me.TxtProducto.Text = ""
        End If

        If Not Me.ViewState("nuevo") Is Nothing Then 'VERIFICA SI ES NUEVO
            Me._nuevo = Me.ViewState("nuevo")
        End If

    End Sub


    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'HABILITA LA EDICION DE LOS CAMPOS DEL CONTROL DE USUARIO

        Me.txtIDCONSUMO.Enabled = edicion
        Me.txtCANTIDADCONSUMIDA.Enabled = edicion
        Me.txtDEMANDAINSATISFECHA.Enabled = edicion
        Me.txtEXISTENCIAACTUAL.Enabled = edicion

    End Sub

    Private Sub Nuevo()
        'AL SER UN NUEVO PRODUCTO

        Me._nuevo = True
        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If
    End Sub

    Public Function Actualizar() As String
        'FUNCION PARA LA ACTUALIZACION DE LOS DATOS EN LA BASE DE DATOS

        mEntidad = New DETALLECONSUMOS

        mEntidad.IDDETALLE = 0
        mEntidad.IDCONSUMO = Session.Item("IdEncabezado")
        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntidad.IDPRODUCTO = Me.lblproducto.Text
        mEntidad.IDUNIDADMEDIDA = Me.DdlUNIDADMEDIDAS1.SelectedValue

        If Me.txtCANTIDADCONSUMIDA.Text <> "" Or Me.txtCANTIDADCONSUMIDA.Text <> Nothing Then
            mEntidad.CANTIDADCONSUMIDA = Me.txtCANTIDADCONSUMIDA.Text
        Else
            mEntidad.CANTIDADCONSUMIDA = 0
        End If

        If Me.txtDEMANDAINSATISFECHA.Text <> "" Or Me.txtDEMANDAINSATISFECHA.Text <> Nothing Then
            mEntidad.DEMANDAINSATISFECHA = Me.txtDEMANDAINSATISFECHA.Text
        Else
            mEntidad.DEMANDAINSATISFECHA = 0
        End If

        If Me.txtEXISTENCIAACTUAL.Text <> "" Or Me.txtEXISTENCIAACTUAL.Text <> Nothing Then
            mEntidad.EXISTENCIAACTUAL = Me.txtEXISTENCIAACTUAL.Text
        Else
            mEntidad.EXISTENCIAACTUAL = 0
        End If

        If mEntidad.AUUSUARIOCREACION = Nothing Then
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntidad.AUFECHACREACION = Nothing Then
            mEntidad.AUFECHACREACION = Now()
        End If
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarDETALLECONSUMOS(mEntidad) <> 1 Then
            MsgBox1.ShowAlert("Error al guardar el registro", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return "Error al Guardar registro."

        End If
    End Function
    Protected Sub rdblCriterio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblCriterio.SelectedIndexChanged
        'EVENTO AL SELECIONAR UNO DE LOS CRITERIO DE FILTRO PARA LA BUSQUEDA DE UN PRODUCTO
        If Me.rdblCriterio.SelectedValue = 0 Then 'Busqueda por codigo
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.BtnBuscar.Visible = True
            Me.BtnBuscar.Text = "Buscar"
            Me.DdlGRUPOS1.Visible = False
            Me.bttgenerar.Visible = False
        End If
        If Me.rdblCriterio.SelectedValue = 1 Then 'Busqueda por seleccion
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = True
            Me.BtnBuscar.Text = "Aceptar"
            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaHabilitadoXCodigoMSPAS(Session.Item("IdEstablecimiento"))
            Me.DdlCATALOGOPRODUCTOS1.Visible = True
            Me.LblDescripcionCompleta.Visible = False
            Me.DdlGRUPOS1.Visible = False
            Me.bttgenerar.Visible = False
        End If
        If Me.rdblCriterio.SelectedValue = 2 Then 'Busqueda por grupo terapeutico
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.DdlGRUPOS1.RecuperarListaOrdenada()
            Me.DdlGRUPOS1.Visible = True
            Me.bttgenerar.Visible = True
            Me.LblDescripcionCompleta.Visible = False
        End If


    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        'EVENTO AL PRESIONAR BUSCAR UN PRODUCTO
        Me.rdblCriterio.ClearSelection()

        Dim dsCatalogoProductos As DataSet
        Dim dsProductosConsumo As DataSet
        dsProductosConsumo = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"), Me.TxtProducto.Text)

        'VERIFICACION SI EL PRODUCTO YA ESTA EN EL CONSUMO
        If dsProductosConsumo.Tables(0).Rows.Count > 0 Then
            MsgBox1.ShowAlert("Este producto ya fue ingresado al consumo", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Me.TxtProducto.Text = ""
            Me.lblproducto.Text = ""
            Me.LblDescripcionCompleta.Text = ""
            Me.TxtProducto.Focus()
        Else

            If Me.BtnBuscar.Text = "Aceptar" Then ' AL PRESIONAR ACEPTAR UN PRODUCTO

                Me.TxtProducto.Text = Me.DdlCATALOGOPRODUCTOS1.SelectedValue
                dsCatalogoProductos = mCompProducto.ObtenerDataSetPorCodigoProductoHabilitados(Me.TxtProducto.Text, Session.Item("IdEstablecimiento"))

                dsProductosConsumo = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"), Me.TxtProducto.Text)
                If dsProductosConsumo.Tables(0).Rows.Count > 0 Then
                    MsgBox1.ShowAlert("Este producto ya fue ingresado al consumo", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Me.TxtProducto.Text = ""
                    Me.lblproducto.Text = ""
                    Me.LblDescripcionCompleta.Text = ""
                    LblDescripcionCompleta.Focus()
                Else
                    If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
                        MsgBox1.ShowAlert("El código del producto no esta habilitado, es incorrecto o no existe", "C", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                        Me.TxtProducto.Text = ""
                        Me.lblproducto.Text = ""
                        Me.LblDescripcionCompleta.Text = ""
                        Me.TxtProducto.Focus()
                    Else
                        Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
                        Me.DdlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("CORRPRODUCTO")
                        Me.lblproducto.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
                        Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                        Me.LblDescripcionCompleta.Visible = True
                    End If
                End If

            Else ' AL PRESIONAR BUSCAR UN PRODUCTO
                dsCatalogoProductos = mCompProducto.ObtenerDataSetPorCodigoProductoHabilitados(Me.TxtProducto.Text, Session.Item("IdEstablecimiento"))

                dsProductosConsumo = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Session.Item("IdEncabezado"), Me.TxtProducto.Text)
                If dsProductosConsumo.Tables(0).Rows.Count > 0 Then
                    MsgBox1.ShowAlert("Este producto ya fue ingresado al consumo", "D", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Me.TxtProducto.Text = ""
                    Me.lblproducto.Text = ""
                    Me.LblDescripcionCompleta.Text = ""
                    Me.LblDescripcionCompleta.Focus()
                Else
                    If dsCatalogoProductos.Tables(0).Rows.Count = 0 Then
                        MsgBox1.ShowAlert("El código del producto no esta habilitado, es incorrecto o no existe", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                        Me.TxtProducto.Text = ""
                        Me.lblproducto.Text = ""
                        Me.LblDescripcionCompleta.Text = ""
                        Me.TxtProducto.Focus()
                    Else
                        Me.DdlUNIDADMEDIDAS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("IDUNIDADMEDIDA")
                        Me.DdlCATALOGOPRODUCTOS1.SelectedValue = dsCatalogoProductos.Tables(0).Rows(0).Item("CORRPRODUCTO")
                        Me.lblproducto.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("IDPRODUCTO")
                        Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                        Me.LblDescripcionCompleta.Visible = True
                    End If
                End If
            End If
        End If
    End Sub
    Protected Sub ImgbGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar.Click
        'EVENTO AL PRESIONAR IMAGEN DE GUARDAR Y VALIDACIONES REALIZADAS AL MOMENTO DE GUARDAR PRODUCTO
        If Me.lblproducto.Text = "" Then
            MsgBox1.ShowAlert("Favor agregue un producto", "F", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            Actualizar()
            Me.txtCANTIDADCONSUMIDA.Text = 0
            Me.txtDEMANDAINSATISFECHA.Text = 0
            Me.txtEXISTENCIAACTUAL.Text = 0
            Me.LblDescripcionCompleta.Text = ""
            Me.lblproducto.Text = ""
            Me.TxtProducto.Text = ""
            Me.rdblCriterio.SelectedValue = 0
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.DdlGRUPOS1.Visible = False
            Me.TxtProducto.Visible = True
            Me.BtnBuscar.Visible = True
            Me.BtnBuscar.Text = "Buscar"
            Me.bttgenerar.Visible = False
            RaiseEvent Agregar(sender, e)
        End If

    End Sub

    Protected Sub ImgbCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCancelar.Click
        'EVENTO AL PRESIONAR LA IMAGEN DE CANCELAR
        Me.txtCANTIDADCONSUMIDA.Text = 0
        Me.txtDEMANDAINSATISFECHA.Text = 0
        Me.txtEXISTENCIAACTUAL.Text = 0
        Me.LblDescripcionCompleta.Text = ""
        Me.lblproducto.Text = ""
        Me.TxtProducto.Text = ""
        Me.rdblCriterio.SelectedValue = 0
        Me.DdlCATALOGOPRODUCTOS1.Visible = False
        Me.DdlGRUPOS1.Visible = False
        Me.TxtProducto.Visible = True
        Me.BtnBuscar.Visible = True
        Me.BtnBuscar.Text = "Buscar"
        Me.bttgenerar.Visible = False

        RaiseEvent Cancelar(sender, e)
    End Sub

    Protected Sub bttgenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttgenerar.Click
        'EVENTO AL PRESIONAR BOTON PARA FILTRAR POR GRUPO TERAPEUTICO
        Me.rdblCriterio.ClearSelection()
        Me.TxtProducto.Visible = False
        Me.BtnBuscar.Visible = True
        Me.BtnBuscar.Text = "Aceptar"
        Me.DdlCATALOGOPRODUCTOS1.RecuperarListaHabilitadoXCodigoMSPASxGrupo(CInt(Me.DdlGRUPOS1.SelectedValue), Session.Item("IdEstablecimiento"))
        Me.DdlCATALOGOPRODUCTOS1.Visible = True
        Me.LblDescripcionCompleta.Visible = False
        Me.DdlGRUPOS1.Visible = False
        Me.bttgenerar.Visible = False
    End Sub

End Class
