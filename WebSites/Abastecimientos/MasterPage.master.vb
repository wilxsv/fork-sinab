'MASTER PAGE CON MENU
'Ing. Yessenia Pennelope Henriquez Duran
'Plantilla a utilizar por todos los formularios a utilizar en el sistema de abastecimientos
'Contiene las variables de sesion a utilizar en todos los formularios del sistema de abastecimiento
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Linq
Imports System.Globalization
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases
Imports SINAB_Entidades.Tipos
Imports SINAB_Utils

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    'inicializacion de variables
    Public Event ErrorEvent(ByVal errorMessage As String)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
           
           

            logo.ImageUrl = Config.LogoUrl
            'AL MOMENTO DE CARGAR LA PAGINA
            Me.Page.ClientScript.RegisterClientScriptInclude(Me.GetType(), "Global", ResolveClientUrl("~/Script/script.js"))
            lblUserOnline.Text = Application("UsersOnline").ToString()
            If Request.IsAuthenticated Then ' SI ESTA AUTENTICADO EL USUARIO

                Dim usuario = Membresia.ObtenerUsuario()


                If Me.ControlMenu.Visible Then
                    Dim miControlMenu As Control = Page.LoadControl("~/Controles/ucMenu.ascx")
                    Me.Menu.Controls.Add(miControlMenu)
                End If

                If Not Session.Item("DatosCargados") Then 'VERIFICACION SI LOS DATOS YA FUERON CARGADOS
                    CargarEmpleado(usuario)
                End If

                'carga los datos a mostrar en encabezado
                InfoSesion.CargarDatos(usuario)

                Me.lnkUsuario.Text = usuario.USUARIO
                'Me.lnkUsuario.Attributes.Add("onclick", "window.open('" + Request.ApplicationPath + "/seguridad/FrmNuevaContrasena.aspx', 'popup' ,'scrollbars= 0 ,resizable= 0 ,width= 400 ,height= 200, top=150,left=325 ');")

                'Me.LnkbinfoUsuario.Attributes.Add("onclick", "window.open('" + Request.ApplicationPath + "/SEGURIDAD/FrmInformacionSesion.aspx', 'popup' ,'scrollbars=1 ,resizable=1 ,width=800 ,height=600');return false;")
                'Me.lblRol.Text = Session.Item("UsuarioRol")
                'Me.lblDependencia.Text = usuario.DEPENDECIA.NOMBRE
                'Me.lblEstablecimiento.Text = usuario.ESTABLECIMIENTO.NOMBRE
            Else
                Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado
            End If

        End If
    End Sub

    'PROPIEDAD PUBLICA PARA OCULTAR O MOSTRAR MENU
    Public ReadOnly Property ControlMenu() As PlaceHolder
        Get
            Return Me.Menu
        End Get
    End Property

    'PROPIEDAD PUBLICA PARA MANEJO DEL TAMAÑO DE LA IMAGEN
    'Public ReadOnly Property ControlEncabezado() As Image
    '    Get
    '        Return Me.Image1
    '    End Get
    'End Property

    'Protected Sub ImgbInicio_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbInicio.Click
    '    'evento al presionar inicio
    '    Response.Redirect("~/FrmPrincipal.aspx", False)
    'End Sub

    Protected Sub cerrarSesion_Click(sender As Object, e As System.EventArgs) Handles cerrarSesion.Click
        FormsAuthentication.SignOut() ' Logout
        Session.Abandon() ' Clear Session Variables
        Response.Redirect("~/FrmLogin.aspx", False)
    End Sub


    Public Function ObtenerUsuario() As String
        'FUNCION PARA OBTENER LA INFORMACION DEL USUARIO
        Return Context.User.Identity.Name
    End Function

    Private Sub CargarEmpleado(ByVal usuario As Usuario)
        'CARGA LA INFORMACION DEL EMPLEADO Y DEFINE VARIABLES DE SESION A UTILIZAR DURANTE LA SESION DEL USUARIO
        'EN TODO EL SISTEMA

        'NOTA: Solo una sesion es necesaria, se pudó haber utilizado Membership en todos los casos. SINAB_DEV 2013
        If usuario.EsComision Then 'If cCPC.ValidarUsuario(Context.User.Identity.Name) Then


            Session.Item("UsuarioComisionAltoNivel") = True
            Session.Item("IdEstablecimiento") = usuario.Establecimiento.IDESTABLECIMIENTO
            Session.Item("UsuarioEstablecimiento") = usuario.Establecimiento.NOMBRE

            'Nota: Todo se guarda en la variable Usuario que tiene los atributos necesarios 
            'y que puede ser instanciado desde cualquier parte Ej: x: Membresia.ObtenerUsuario()
        Else

            'variables de sesion

            'Nota: ESTE CODIGO DEBE SER BORRADO CUANDO YA NO SE UTILICEN ESTAS VARIABLES DE SESION EN TODAS LAS PAGINAS DEL PROYECTO

            Session.Item("CodUsuario") = usuario.USUARIO 'mEntUsuario.USUARIO 'codigo de usuario
            Session.Item("IdUsuario") = usuario.IDUSUARIO 'mEntUsuario.IDUSUARIO 'identificador de usuario
            Session.Item("UsuarioRol") = String.Join(",", Membresia.ObtenerRoles()) 'mEntRoles.DESCRIPCION 'rol


            'todo: arreglar cuandos e tenga tiempo (multirol)
            Session.Item("IdRol") = Membresia.ObtenerRolesPorUsuario().FirstOrDefault().IDROL


            Session.Item("IdEmpleado") = usuario.Empleado.IDEMPLEADO ' mEntEmpleado.IDEMPLEADO 'identificador de empleado
            Session.Item("NombreUsuario") = String.Format("{0} {1}", usuario.Empleado.NOMBRE, usuario.Empleado.APELLIDO) 'mEntEmpleado.NOMBRE & " " & mEntEmpleado.APELLIDO 'nombre de usuario
            Session.Item("CodigoEmpleado") = usuario.Empleado.NOMBRECORTO 'mEntEmpleado.NOMBRECORTO  'codigo empleado
            Session.Item("UsuarioCargo") = usuario.Cargo.DESCRIPCION 'mEntCargo.DESCRIPCION 'cargo
            Session.Item("IdCargo") = usuario.Cargo.IDCARGO ' mEntCargo.IDCARGO 'identificador de cargo
            Session.Item("NomDependencia") = usuario.Dependencia.NOMBRE 'mEntDependencias.NOMBRE 'dependencia
            Session.Item("IdDependencia") = usuario.Dependencia.IDDEPENDENCIA 'mEntDependencias.IDDEPENDENCIA 'identificador de dependencia
            Session.Item("UsuarioEstablecimiento") = usuario.Establecimiento.NOMBRE 'mEntEstablecimientos.NOMBRE 'establecimiento
            Session.Item("IdEstablecimiento") = usuario.Establecimiento.IDESTABLECIMIENTO 'mEntEstablecimientos.IDESTABLECIMIENTO 'identificador de establecimiento
            Session.Item("Nivel") = usuario.Establecimiento.NIVEL 'mEntEstablecimientos.NIVEL 'nivel de establecimiento
            Session.Item("TipoConsumo") = usuario.Establecimiento.TIPOCONSUMO 'mEntEstablecimientos.TIPOCONSUMO 'tipo de consumo del establecimiento

            If usuario.EmpleadoAlmacenes.Any() Then
                Session.Item("IdAlmacen") = usuario.EmpleadoAlmacenes.FirstOrDefault().IDALMACEN 'mEntEmpleadoAlmacen.IDALMACEN 'identificador del almacen
                Session.Item("GuardaAlmacen") = usuario.EmpleadoAlmacenes.FirstOrDefault().ESGUARDAALMACEN 'mEntEmpleadoAlmacen.ESGUARDAALMACEN 'si el empleado es un guarda almacen
            End If

            If usuario.Almacenes.Any() Then
                Session.Item("Farmacia") = usuario.Farmacia 'mEntAlmacen.ESFARMACIA 'el establecimiento es farmacia 
                Session.Item("NombreAlmacen") = usuario.Almacen.NOMBRE 'mEntAlmacen.NOMBRE 'almacen
            End If

            Session.Item("IdZona") = usuario.Zona.IDZONA 'mEntEstablecimientos.IDZONA 'identificador de zona o region
            Session.Item("idTipoEstablecimiento") = usuario.Establecimiento.IDTIPOESTABLECIMIENTO 'mEntEstablecimientos.IDTIPOESTABLECIMIENTO  'identificador tipo establecimiento
            Session.Item("NombreZona") = usuario.Zona.DESCRIPCION 'mEntZona.DESCRIPCION 'region o zona
            Session.Item("NombreTipoEstablecimiento") = usuario.TipoEstablecimiento.DESCRIPCION ' mEntTipoEstablecimiento.DESCRIPCION 'tipo de establecimiento
            Session.Item("IdPadre") = usuario.Establecimiento.IDPADRE 'mEntEstablecimientos.IDPADRE 'identificador del establecimiento padre



        End If


        Session.Item("DatosCargados") = True

    End Sub

    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNombreUsuario.Click
    '    'Page.ClientScript.RegisterStartupScript(Me.GetType, "Cambio Password", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/seguridad/FrmNuevaContrasena.aspx', 'popup' ,'scrollbars= 0 ,resizable= 0 ,width= 400 ,height= 185, top=150,left=325 '); </script>")
    '    Response.Write("<script language=javascript>")
    '    Response.Write("window.open('" + Request.ApplicationPath + "/seguridad/FrmNuevaContrasena.aspx', 'popup' ,'scrollbars= 0 ,resizable= 0 ,width= 400 ,height= 200, top=150,left=325 ');")
    '    Response.Write("</script>")
    'End Sub



End Class
