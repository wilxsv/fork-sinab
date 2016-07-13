Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers

Partial Class ucMenu
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim dsMenu As Data.DataSet
            Dim iFila As Integer

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
                Dim mComponente As New cUSUARIOS
                dsMenu = mComponente.ObtenerDsUsuariosOpciones(Membresia.ObtenerUsuario().IDUSUARIO)

                'Recorremos el dataset para agregar los elementos que estaran en la cabecera del menú.
                For iFila = 0 To dsMenu.Tables(0).Rows.Count - 1
                    'Esta condicion indica que son elementos Padres
                    If IsDBNull(dsMenu.Tables(0).Rows(iFila).Item("IDPADRE")) Then
                        Dim mnuMenuItem As New MenuItem
                        mnuMenuItem.Value = dsMenu.Tables(0).Rows(iFila).Item("IDOPCIONSISTEMA")
                        mnuMenuItem.Text = dsMenu.Tables(0).Rows(iFila).Item("DESCRIPCION")
                        mnuMenuItem.NavigateUrl = Trim(dsMenu.Tables(0).Rows(iFila).Item("URL"))
                        'Agregamos el Ítem al menú
                        Me.Menu1.Items.Add(mnuMenuItem)
                        'Hacemos un llamado al metodo recursivo encargado de generar el árbol del menú.
                        AddMenuItem(mnuMenuItem, dsMenu)
                    End If
                Next
            End If

        End If

    End Sub

    Private Sub AddMenuItem(ByRef mnuMenuItem As MenuItem, ByRef dsMenu As Data.DataSet)

        Dim iFila As Integer

        'Recorremos cada elemento del dataset para poder determinar cuales son elementos hijos
        'del menuitem dado pasado como parametro a la funcion.
        For iFila = 0 To dsMenu.Tables(0).Rows.Count - 1
            If Not IsDBNull(dsMenu.Tables(0).Rows(iFila).Item("IDPADRE")) AndAlso dsMenu.Tables(0).Rows(iFila).Item("IDPADRE") = mnuMenuItem.Value Then
                Dim mnuNewMenuItem As New MenuItem
                mnuNewMenuItem.Value = dsMenu.Tables(0).Rows(iFila).Item("IDOPCIONSISTEMA")
                mnuNewMenuItem.Text = dsMenu.Tables(0).Rows(iFila).Item("DESCRIPCION")
                mnuNewMenuItem.NavigateUrl = Trim(dsMenu.Tables(0).Rows(iFila).Item("URL"))
                'Agregamos el Nuevo MenuItem al MenuItem que viene de un nivel superior.
                mnuMenuItem.ChildItems.Add(mnuNewMenuItem)
                'Llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                AddMenuItem(mnuNewMenuItem, dsMenu)
            End If
        Next

    End Sub

End Class
