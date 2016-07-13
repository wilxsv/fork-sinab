'CONTROL DE USUARIO PARA AGREGAR PRODUCTOS A LA SOLICITUD DE COMPRAS
'UTILIZADO EN CU-ESTA001
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario que forma parte de la solicitud de productos de los establecimientos
'el cual permite agregar un producto al detalle de la solicitud

'Importacion
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data

Partial Class Controles_ucAgregarProductosDetalleSolicitud
    Inherits System.Web.UI.UserControl

    'INICIALIZAR VARIABLES

    Public Event Cancelar As EventHandler
    Public Event Agregar As EventHandler
    Private mCompProductos As New cCATALOGOPRODUCTOS
    Private mEntProductos As New CATALOGOPRODUCTOS
    Private mEntUnidadMedida As New UNIDADMEDIDAS
    Private mEntSuministros As New SUMINISTROS
    Private mCompSuministros As New cSUMINISTROS
    Private _IDDETALLE As Int64
    Private _Enabled As Boolean = True
    Private _sError As String
    Private _nuevo As Boolean = False
    Protected WithEvents dsDatos As System.Data.DataSet
    Private mComponente As New cDETALLESOLICITUDES
    Private mEntidad As New DETALLESOLICITUDES
    Private mCompUnidadMedida As New cUNIDADMEDIDAS
    Public Event ErrorEvent(ByVal errorMessage As String)
    Private mCompEntregasSolicitud As New cENTREGASOLICITUDES
    Dim entregas, ent As Integer


    'INICIALIZAR PROPIEDADES
    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property
    Public ReadOnly Property IDSOLICITUD() As Label
        Get
            Return Me.Labelid
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

    Public Sub ObtenerSuministro(ByVal IDSUMINISTRO As Int32)
        'obtien el suministro del encabezado y verifico el tipo de suministro al que pertenece
        Me.lblSuministro.Text = IDSUMINISTRO
        mEntSuministros.IDSUMINISTRO = IDSUMINISTRO
        mCompSuministros.ObtenerSUMINISTROS(mEntSuministros)
        Me.lblTipoSuministro.Text = mEntSuministros.IDTIPOSUMINISTRO
    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        ' propiedad que nos permitira la habilitacion o no de la edicion 
        Me.DdlCATALOGOPRODUCTOS1.Enabled = edicion
        Me.txtCANTIDAD.Enabled = edicion
        Me.lblproducto.Enabled = edicion
        Me.LblDescripcionCompleta.Enabled = edicion
    End Sub

    Private Sub Nuevo()
        'HABILITAR UNO NUEVO
        Me._nuevo = True
        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If
    End Sub

    Protected Sub ImgbGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar.Click
        'evento al presionar la imagen de guardar y Validaciones relaizadas al momento de guardar los datos del producto agregado al detalle
        If Me.lblproducto.Text = "" Then
            MsgBox1.ShowAlert("Favor agregue un producto", "F", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            If Me.txtCANTIDAD.Text = 0 Then

                MsgBox1.ShowAlert("La cantidad no puede ser 0", "G", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Else
                Actualizar()
                Me.txtCANTIDAD.Text = 0
                Me.txtPRESUPUESTOUNITARIO.Text = 0
                Me.DDLnumeroEntregas.ClearSelection()
                Me.lblproducto.Text = ""
                Me.LblDescripcionCompleta.Text = ""
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
        End If
    End Sub

    Public Function Actualizar() As String

        'Realiza la llamada de la actualizacion de los datos a la capa de negocio y esta a su vez a la capa
        ' de datos

        mEntidad = New DETALLESOLICITUDES

        Me.txtPRESUPUESTOUNITARIO.AutoFormatCurrency = False

        mEntidad.IDDETALLE = 0
        mEntidad.IDSOLICITUD = Me.Labelid.Text
        mEntidad.IDPRODUCTO = Val(Me.lblproducto.Text)
        mEntidad.CANTIDAD = Me.txtCANTIDAD.Text
        mEntidad.IDUNIDADMEDIDA = Me.DdlUNIDADMEDIDAS1.SelectedValue
        mEntidad.PRESUPUESTOUNITARIO = Me.txtPRESUPUESTOUNITARIO.Text
        mEntidad.PRESUPUESTOTOTAL = Me.txtCANTIDAD.Text * Me.txtPRESUPUESTOUNITARIO.Text
        mEntidad.RENGLON = 0
        If Me.DDLnumeroEntregas.SelectedValue <> "" Then
            mEntidad.NUMEROENTREGAS = Me.DDLnumeroEntregas.SelectedValue
        Else
            MsgBox1.ShowAlert("No se han definido las entregas", "errorentregas", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If
        If mEntidad.AUFECHACREACION = Nothing Then
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntidad.AUFECHACREACION = Nothing Then
            mEntidad.AUFECHACREACION = Now()
        End If
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0
        mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

        If mComponente.ActualizarDETALLESOLICITUDES(mEntidad) <> 1 Then

            MsgBox1.ShowAlert("Error al guardar el registro", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Return "Error al Guardar registro."

        End If
        Me.txtPRESUPUESTOUNITARIO.AutoFormatCurrency = True
    End Function

    Protected Sub ImgbCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCancelar.Click

        'evento resultante al presionar la imagen cancelar 

        Me.txtCANTIDAD.Text = 0
        Me.txtPRESUPUESTOUNITARIO.Text = 0
        Me.DDLnumeroEntregas.ClearSelection()
        Me.lblproducto.Text = ""
        Me.LblDescripcionCompleta.Text = ""
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' evento a relizarce cada vez que inicialize la pagina 

        If Not IsPostBack Then 'LA PRIMERA VEZ
            DDLnumeroEntregas.Visible = False
            Me.DdlUNIDADMEDIDAS1.Recuperar()
            Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.lblSuministro.Text)
            Me.txtCANTIDAD.Text = 0
            Me.txtPRESUPUESTOUNITARIO.Text = 0
            Me.DDLnumeroEntregas.ClearSelection()
            Me.lblproducto.Text = ""
            Me.TxtProducto.Text = ""
            If Me.lblTipoSuministro.Text = "1" Then 'medico
                Me.DdlCATALOGOPRODUCTOS1.RecuperarHabilitadosxCodigoXSuministro(Me.lblSuministro.Text, Session.Item("IdEstablecimiento"))
            Else 'no medico
                Me.DdlCATALOGOPRODUCTOS1.RecuperarListaNoMedicosConHomogeneos(Me.lblSuministro.Text)
            End If
        End If

        If Not Me.ViewState("nuevo") Is Nothing Then 'SI ES NUEVO
            Me._nuevo = Me.ViewState("nuevo")
        End If

    End Sub

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

            If Me.lblTipoSuministro.Text = "1" Then 'medico
                Me.DdlCATALOGOPRODUCTOS1.RecuperarHabilitadosxCodigoXSuministro(Me.lblSuministro.Text, Session.Item("IdEstablecimiento"))
            Else 'no medico
                Me.DdlCATALOGOPRODUCTOS1.RecuperarListaNoMedicosConHomogeneos(Me.lblSuministro.Text)
            End If

            Me.DdlCATALOGOPRODUCTOS1.Visible = True
            Me.LblDescripcionCompleta.Visible = False
            Me.DdlGRUPOS1.Visible = False
            Me.bttgenerar.Visible = False
        End If

        If Me.rdblCriterio.SelectedValue = 2 Then 'Busqueda por grupo terapeutico
            Me.TxtProducto.Visible = False
            Me.BtnBuscar.Visible = False
            Me.DdlCATALOGOPRODUCTOS1.Visible = False
            Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.lblSuministro.Text)
            Me.DdlGRUPOS1.Visible = True
            Me.bttgenerar.Visible = True
            Me.LblDescripcionCompleta.Visible = False
        End If
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click

        'EVENTO AL PRESIONAR BUSCAR UN PRODUCTO

        'Validacion de numeros de entregas para habilitar 

        entregas = mCompEntregasSolicitud.ObtenerNumeroEntregas(Me.Labelid.Text, Session.Item("IdEstablecimiento"))
        If entregas >= 1 Then
            DDLnumeroEntregas.Visible = True
            DDLnumeroEntregas.Items.Clear()
            For ent = 1 To entregas
                DDLnumeroEntregas.Items.Add(ent)
            Next ent

        Else
            DDLnumeroEntregas.Visible = False
        End If

        '---

        Me.rdblCriterio.ClearSelection()
        Dim dsCatalogoProductos As DataSet

        Dim dsProductosSolicitud As DataSet
        dsProductosSolicitud = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Me.Labelid.Text, Me.TxtProducto.Text)

        'VERIFICACION SI EL PRODUCTO YA ESTA EN LA SOLICITUD

        If dsProductosSolicitud.Tables(0).Rows.Count > 0 Then
            MsgBox1.ShowAlert("Este producto ya fu ingresado a la solicitud", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Me.TxtProducto.Text = ""
            Me.lblproducto.Text = ""
            Me.LblDescripcionCompleta.Text = ""
            Me.TxtProducto.Focus()
        Else
            If Me.BtnBuscar.Text = "Aceptar" Then ' AL PRESIONAR ACEPTAR UN PRODUCTO

                Me.TxtProducto.Text = Me.DdlCATALOGOPRODUCTOS1.SelectedValue

                If Me.lblTipoSuministro.Text = "1" Then 'medico
                    dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProductoHabilitadoXSuministro(Me.TxtProducto.Text, Session.Item("IdEstablecimiento"), Me.lblSuministro.Text)
                Else 'no medico
                    dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProductoNoMedico(Me.TxtProducto.Text, Me.lblTipoSuministro.Text)
                End If

                dsProductosSolicitud = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Me.Labelid.Text, Me.TxtProducto.Text)

                If dsProductosSolicitud.Tables(0).Rows.Count > 0 Then
                    MsgBox1.ShowAlert("Este producto ya fue ingresado a la solicitud", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
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
                        Me.txtPRESUPUESTOUNITARIO.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("PRECIOACTUAL")
                        Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                        Me.LblDescripcionCompleta.Visible = True
                    End If
                End If
            Else  ' AL PRESIONAR BUSCAR UN PRODUCTO

                If Me.lblTipoSuministro.Text = "1" Then 'medico
                    dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProductoHabilitadoXSuministro(Me.TxtProducto.Text, Session.Item("IdEstablecimiento"), Me.lblSuministro.Text)
                Else 'no medico
                    dsCatalogoProductos = mCompProductos.ObtenerDataSetPorCodigoProductoNoMedicoConHomogeneos(Me.TxtProducto.Text, Me.lblTipoSuministro.Text)
                End If

                dsProductosSolicitud = mComponente.ObtenerDataSetPorCodigo(Session.Item("IdEstablecimiento"), Me.Labelid.Text, Me.TxtProducto.Text)

                If dsProductosSolicitud.Tables(0).Rows.Count > 0 Then
                    MsgBox1.ShowAlert("Este producto ya fue ingresado a la solicitud", "D", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Me.TxtProducto.Text = ""
                    Me.lblproducto.Text = ""
                    Me.LblDescripcionCompleta.Text = ""
                    LblDescripcionCompleta.Focus()
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
                        Me.txtPRESUPUESTOUNITARIO.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("PRECIOACTUAL")
                        Me.LblDescripcionCompleta.Text = dsCatalogoProductos.Tables(0).Rows(0).Item("DESCLARGO")
                        Me.LblDescripcionCompleta.Visible = True
                    End If
                End If
            End If
        End If

    End Sub

    Protected Sub bttgenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttgenerar.Click

        'EVENTO AL PRESIONAR BOTON PARA FILTRAR POR GRUPO TERAPEUTICO
        Me.rdblCriterio.ClearSelection()
        Me.TxtProducto.Visible = False
        Me.BtnBuscar.Visible = True
        Me.BtnBuscar.Text = "Aceptar"

        If Me.lblTipoSuministro.Text = "1" Then 'medico
            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaHabilitadoXCodigoMSPASxgrupo(CInt(Me.DdlGRUPOS1.SelectedValue), Session.Item("IdEstablecimiento"))
        Else 'no medico
            Me.DdlCATALOGOPRODUCTOS1.RecuperarListaXCodigoMSPASxgrupoNoMedico(CInt(Me.DdlGRUPOS1.SelectedValue), Me.lblTipoSuministro.Text)
        End If

        Me.DdlCATALOGOPRODUCTOS1.Visible = True
        Me.LblDescripcionCompleta.Visible = False
        Me.DdlGRUPOS1.Visible = False
        Me.bttgenerar.Visible = False
    End Sub

End Class
