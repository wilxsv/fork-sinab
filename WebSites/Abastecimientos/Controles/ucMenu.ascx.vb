Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Collections.Generic
Imports System.Linq
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers

Partial Class ucMenu
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim dsMenu As List(Of vv_OPCIONESUSUARIOSROL)
            
            Dim cCPC As New cCOMISIONPROCESOCOMPRA
            If cCPC.ValidarUsuario(HttpContext.Current.User.Identity.Name) Then
                Dim mnuMenuItem As New MenuItem
                mnuMenuItem.Text = "UACI"
                Dim mnuNewMenuItem As New MenuItem
                mnuNewMenuItem.Text = "Adjudicar"
                mnuNewMenuItem.NavigateUrl = "~/FrmSeleccioneProcesoCompra.aspx?id=Adjudicar"
                mnuMenuItem.ChildItems.Add(mnuNewMenuItem)
                Me.Menu1.Items.Add(mnuMenuItem)

            Else
                'Dim mComponente As New cUSUARIOS
                dsMenu = Membresia.ObtenerUsuario().Menu 'mComponente.ObtenerDsUsuariosOpciones(Membresia.ObtenerUsuario().IDUSUARIO)

                'Recorremos el dataset para agregar los elementos que estaran en la cabecera del menú.
                For Each itm As vv_OPCIONESUSUARIOSROL In From itm1 In dsMenu Where IsNothing(itm1.IDPADRE)
                    Dim mnuMenuItem As New MenuItem
                    mnuMenuItem.Value = itm.IDOPCIONSISTEMA.ToString()
                    mnuMenuItem.Text = itm.DESCRIPCION
                    mnuMenuItem.NavigateUrl = itm.URL
                    mnuMenuItem.Selectable = False
                    'Agregamos el Ítem al menú
                    Me.Menu1.Items.Add(mnuMenuItem)
                    'Hacemos un llamado al metodo recursivo encargado de generar el árbol del menú.
                    AddMenuItem(mnuMenuItem, dsMenu)
                Next
               
            End If

        End If

    End Sub

    Private Shared Sub AddMenuItem(ByRef mnuMenuItem As MenuItem, ByRef dsMenu As List(Of vv_OPCIONESUSUARIOSROL))

       
        'Recorremos cada elemento del dataset para poder determinar cuales son elementos hijos
        'del menuitem dado pasado como parametro a la funcion.
        for each itm As vv_OPCIONESUSUARIOSROL In dsMenu
            If Not IsNothing(itm.IDPADRE) AndAlso itm.IDPADRE = mnuMenuItem.Value
                 Dim mnuNewMenuItem As New MenuItem
                mnuNewMenuItem.Value = itm.IDOPCIONSISTEMA.ToString()
                mnuNewMenuItem.Text = itm.DESCRIPCION
                mnuNewMenuItem.NavigateUrl = itm.URL
                'Agregamos el Nuevo MenuItem al MenuItem que viene de un nivel superior.
                mnuMenuItem.ChildItems.Add(mnuNewMenuItem)
                'Llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                AddMenuItem(mnuNewMenuItem, dsMenu)
            End If
        Next
    End Sub

End Class
