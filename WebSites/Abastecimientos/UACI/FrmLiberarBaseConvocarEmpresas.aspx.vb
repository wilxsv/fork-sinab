Imports System.ServiceModel.Description
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Windows.Forms
Imports SICO_Entidades
Imports SICO_Entidades.Helpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Utils
Imports System.Transactions

Partial Class UACI_FrmLiberarBaseConvocarEmpresas
    Inherits System.Web.UI.Page
    Public Property RegisterProviderTemplate() As String
        Get
            If IsNothing(Session("tplRegProveedor")) Then Return Nothing
            Return Session("tplRegProveedor").ToString()
        End Get
        Set(value As String)
            Session("tplRegProveedor") = value
        End Set
    End Property

    Public Property LoginProviderTemplate() As String
        Get
            If IsNothing(Session("tplLoginProveedor")) Then Return Nothing
            Return Session("tplLoginProveedor").ToString()
        End Get
        Set(value As String)
            Session("tplLoginProveedor") = value
        End Set
    End Property

    Public Property ActivateProviderTemplate() As String
        Get
            If IsNothing(Session("tplActivarProveedor")) Then Return Nothing
            Return Session("tplActivarProveedor").ToString()
        End Get
        Set(value As String)
            Session("tplActivarProveedor") = value
        End Set
    End Property

    Public Property ProcesoCompra() As SAB_UACI_PROCESOCOMPRAS
        Get
            If IsNothing(ViewState("vspc")) Then Return Nothing
            Return CType(ViewState("vspc"), SAB_UACI_PROCESOCOMPRAS)
        End Get
        Set(value As SAB_UACI_PROCESOCOMPRAS)
            ViewState("vspc") = value
        End Set
    End Property

    Public Property Solicitud() As Solicitud
        Get
            If IsNothing(ViewState("sol")) Then Return Nothing
            Return CType(ViewState("sol"), Solicitud)
        End Get
        Set(value As Solicitud)
            ViewState("sol") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ProcesoCompra Is Nothing Then
            CargarProcesoCompra()
        End If

        If Not IsPostBack Then
            Master.ControlMenu.Visible = False
            Try
                If SolicitudHelper.Existe(ProcesoCompra) Then
                    Solicitud = SolicitudHelper.Obtener(ProcesoCompra)
                    mvBases.ActiveViewIndex = 1
                    CargarGvEnviados()


                Else
                    mvBases.ActiveViewIndex = 0
                End If
            Catch ex As Exception
                Response.Redirect("~/FrmPrincipal.aspx", False)
            End Try
        End If
    End Sub

    Private Sub CargarGvEnviados()

        Dim ds = SINAB_Entidades.Helpers.UACIHelpers.EntregaBases.ObtenerTodos(ProcesoCompra.IDESTABLECIMIENTO, CType(ProcesoCompra.IDPROCESOCOMPRA, Integer))
        gvEnviados.DataSource = ds
        gvEnviados.DataBind()
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub CargarProcesoCompra()

        Dim usr = Membresia.ObtenerUsuario()
        Dim pc = New SAB_UACI_PROCESOCOMPRAS
        With pc
            .IDPROCESOCOMPRA = CType(Request.QueryString("idProc"), Long)
            .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
        End With
        Try
            ProcesoCompra = UACIHelpers.ProcesoCompras.Obtener(pc)
            CargarDatos()
        Catch ex As Exception
            SINAB_Utils.MessageBox.Alert(ex.Message)

        End Try
    End Sub

    Private Sub CargarDatos()
        With ProcesoCompra
            lpcId.Text = .IDPROCESOCOMPRA.ToString()
            lpcCodigo.Text = .CODIGOLICITACION
            lpcFecha.Text = .FECHAHORAINICIORETIRO.ToString()
        End With
    End Sub

    Protected Sub Unnamed1_Click(sender As Object, e As EventArgs)
        Try
            Solicitud = SolicitudHelper.CrearAsignar(ProcesoCompra)
            SINAB_Utils.MessageBox.Alert("La Generación a terminado exitosamente")
            mvBases.ActiveViewIndex = 1
        Catch ex As Exception
            SINAB_Utils.MessageBox.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub Unnamed2_Click(sender As Object, e As EventArgs)
        Try
            Dim empresa = CatalogoHelpers.Proveedores.Proveedor(BuscarEmpresaLight1.ProviderId)
            Dim usr = Membresia.ObtenerUsuario()
            Dim prov = New Proveedor()

            With prov
                .Usuario = "usr" + empresa.CODIGOPROVEEDOR

                .IdProveedor = empresa.IDPROVEEDOR
                .RazonSocial = empresa.NOMBRE
                .FechaCreacion = DateTime.Now
                .UsuarioCreacion = Membresia.ObtenerUsuario().NombreUsuario
                .IdSolicitud = Solicitud.Id
            End With

            Dim o = New Oferta
            With o
                .IdProveedor = prov.Id
                .IdSolicitud = Solicitud.Id
                .Habilitada = True
                .FechaCreacion = DateTime.Now
            End With

            Dim entregaB = New SAB_UACI_ENTREGABASES()
            With entregaB
                .IDPROCESOCOMPRA = ProcesoCompra.IDPROCESOCOMPRA
                .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
                .IDPROVEEDOR = prov.IdProveedor
                .PERSONARECIBE = prov.Email
                .FECHAHORAENTREGA = DateTime.Now
                .AUFECHACREACION = DateTime.Now
                .AUUSUARIOCREACION = usr.NombreUsuario
                .AUFECHAMODIFICACION = DateTime.Now
                .AUUSUARIOMODIFICACION = usr.NombreUsuario
                .ORDEN = SINAB_Entidades.Helpers.UACIHelpers.EntregaBases.ObtenerMaxOrden(entregaB)
            End With

            Dim isConvocated = False

            Try
                Using db As New SICOEntidades

                    Dim pv = ProveedorHelper.Obtener(db, prov)

                    If Not IsNothing(pv) Then
                        prov = pv
                        prov.Email = tbEmail.Text
                        o.IdProveedor = prov.Id
                        'si la oferta no existe se crea
                        If Not OfertaHelper.Existe(db, o) Then OfertaHelper.Crear(db, o)

                        If ProveedorHelper.Activado(db, prov) Then 'si activado -> login
                            'arma el correo
                            EnviarLoginProveedor(prov)
                        Else 'si no esta activado debe ser activado -> Activate
                            'arma el correo
                            EnviarRegistroProveedor(prov)
                        End If

                    Else 'si no existe se crea proveedor y oferta.
                        prov.Email = tbEmail.Text
                        o.Proveedor = prov
                        ProveedorHelper.Crear(db, prov)
                        EnviarRegistroProveedor(prov)
                    End If
                    db.SaveChanges()
                End Using

                With entregaB
                    .IDPROVEEDOR = prov.IdProveedor
                    .PERSONARECIBE = prov.Email
                End With
                isConvocated = SINAB_Entidades.Helpers.UACIHelpers.EntregaBases.Existe(entregaB)
                If Not isConvocated Then
                    SINAB_Entidades.Helpers.UACIHelpers.EntregaBases.Agregar(entregaB)
                Else
                    SINAB_Entidades.Helpers.UACIHelpers.EntregaBases.Actualizar(entregaB)
                End If


                CargarGvEnviados()
                tbEmail.Text = ""
                BuscarEmpresaLight1.SearchingText = ""
                SINAB_Utils.MessageBox.Alert("Su correo ha sido enviado exitosamente a la dirección " + prov.Email)

            Catch ex As Exception
                Throw
            End Try

        Catch ex As Exception
            SINAB_Utils.MessageBox.Alert(ex.Message)
        End Try
    End Sub

    Private Sub EnviarLoginProveedor(ByVal prov As Proveedor)

        Dim url = String.Format("{0}Account/Login", Config.ObtenerRutaSICO)

        If IsNothing(LoginProviderTemplate) Then LoginProviderTemplate = SendMail.ReadLoginProviderTemplate()

        'arma el cuerpo del correo
        Dim html = String.Format(LoginProviderTemplate, ProcesoCompra.IDPROCESOCOMPRA, ProcesoCompra.CODIGOLICITACION, prov.Usuario, prov.Email, url)

        'manda el correo
        SendMail.SendToProvider(tbEmail.Text, "Convocatoria a Licitación", html)
    End Sub

    Private Sub EnviarRegistroProveedor(ByVal prov As Proveedor)

        'arma el correo
        Dim url = String.Format("{0}Account/Register?u={1}", Config.ObtenerRutaSICO, prov.Id)

        If IsNothing(RegisterProviderTemplate) Then RegisterProviderTemplate = SendMail.ReadRegisterProviderTemplate()

        'arma el cuerpo del correo
        Dim html = String.Format(RegisterProviderTemplate, ProcesoCompra.IDPROCESOCOMPRA, ProcesoCompra.CODIGOLICITACION, prov.Usuario, prov.Email, url)

        'manda el correo
        SendMail.SendToProvider(tbEmail.Text, "Convocatoria a Licitación", html)
    End Sub

    Private Sub MandarCorreo()

    End Sub
End Class
