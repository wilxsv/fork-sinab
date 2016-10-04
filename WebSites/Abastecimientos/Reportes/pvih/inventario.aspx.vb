'pagina principal al momento de cargar la aplicacion al seleccionar INICIO desde cualquier
'punto de la aplicacion de sistema de abastecimientos
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Clases
Imports System.Linq

Partial Class FrmPricipal
    Inherits System.Web.UI.Page

    Private mComponente As New cMENSAJES

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al momento de cargar pagina
        If Not IsPostBack Then

            Dim ds As Data.DataSet
            ds = mComponente.ObtenerDataSetListaMensajesInicio
            Me.gvLista.DataSource = ds.Tables(0)
            Me.gvLista.DataBind()
            Dim pps As Boolean
            If Not (Request.QueryString("pps") = "" Or IsNothing(Request.QueryString("pps"))) Then
                pps = Request.QueryString("pps")
            End If
            If pps Then
                Session("_popup_newpsw") = Nothing
                SINAB_Utils.Utils.MostrarVentana("/seguridad/FrmNuevaContrasena.aspx")
                'Page.ClientScript.RegisterStartupScript(Me.GetType, "Cambio Password", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/seguridad/FrmNuevaContrasena.aspx', 'popup' ,'scrollbars= 0 ,resizable= 0 ,width= 400 ,height= 185, top=150,left=325 '); </script>")
                'Response.Write("<script language=javascript>")
                'Response.Write("window.open('" + Request.ApplicationPath + "/seguridad/FrmNuevaContrasena.aspx', 'popup' ,'scrollbars= 0 ,resizable= 0 ,width= 400 ,height= 200, top=150,left=325 ');")
                'Response.Write("</script>")
                'Return
            End If

            Dim usr = Membresia.ObtenerUsuario()
            If Membresia.EsUsuarioRol("Digitador Almacén") Then
                Dim docs = New Documentos
                Dim mensaje = docs.ObtenerDocumentosAceptados(usr.Almacen.IDALMACEN, EnumHelpers.EstadosMovimiento.EnProceso)
                If mensaje.StartsWith("Error") Then
                    mvMensajes.ActiveViewIndex = 2
                    errorMsj.Text = mensaje
                ElseIf mensaje.StartsWith("Alerta") Then
                    mvMensajes.ActiveViewIndex = 1
                    alertaMsj.Text = mensaje
                ElseIf Not String.IsNullOrEmpty(mensaje) Then
                    mvMensajes.ActiveViewIndex = 0
                    avisoMsj.Text = mensaje
                End If
            End If
        End If
    End Sub

End Class
