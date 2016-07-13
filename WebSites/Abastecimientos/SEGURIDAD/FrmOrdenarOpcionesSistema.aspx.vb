Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmOrdenarOpcionesSistema
    Inherits System.Web.UI.Page

    Private _LastSelectedNodeValuePath As String

#Region " Propiedades "

    Private Property LastSelectedNodeValuePath() As String
        Get
            Return _LastSelectedNodeValuePath
        End Get
        Set(ByVal value As String)
            Me._LastSelectedNodeValuePath = value
            If Not Me.ViewState("LastSelectedNodeValuePath") Is Nothing Then Me.ViewState.Remove("LastSelectedNodeValuePath")
            Me.ViewState.Add("LastSelectedNodeValuePath", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            CargarDatos2()
        Else
            If Not Me.ViewState("LastSelectedNodeValuePath") Is Nothing Then Me._LastSelectedNodeValuePath = Me.ViewState("LastSelectedNodeValuePath")
        End If

    End Sub

    Private Sub CargarDatos2()

        TreeView1.Nodes.Add(New TreeNode("Opciones del Sistema"))

        Dim cO As New cOPCIONESSISTEMA

        Dim ds As Data.DataSet
        ds = cO.ObtenerOpcionesPorOrden()

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            If IsDBNull(ds.Tables(0).Rows(i).Item("IDPADRE")) Then
                Dim Nodo As New TreeNode
                Nodo.Value = ds.Tables(0).Rows(i).Item("IDOPCIONSISTEMA")
                Nodo.Text = ds.Tables(0).Rows(i).Item("DESCRIPCION")
                TreeView1.Nodes.Add(Nodo)
                AgregarNodoHijo(Nodo, ds)
                Nodo.CollapseAll()
            End If
        Next

    End Sub

    Private Sub AgregarNodoHijo(ByRef Nodo As TreeNode, ByRef ds As Data.DataSet)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            If Not IsDBNull(ds.Tables(0).Rows(i).Item("IDPADRE")) AndAlso ds.Tables(0).Rows(i).Item("IDPADRE") = Nodo.Value Then
                Dim NodoHijo As New TreeNode
                NodoHijo.Value = ds.Tables(0).Rows(i).Item("IDOPCIONSISTEMA")
                NodoHijo.Text = ds.Tables(0).Rows(i).Item("DESCRIPCION")
                Nodo.ChildNodes.Add(NodoHijo)

                AgregarNodoHijo(NodoHijo, ds)
                NodoHijo.CollapseAll()
            End If
        Next

    End Sub

    Private Sub CargarDatos()

        Dim cO As New cOPCIONESSISTEMA

        Dim i As Integer

        Dim enu As IEnumerator

        Dim niveles As Integer
        Dim nivel_actual As Integer = -1

        Dim nodo As TreeNode

        Dim iniciado As Boolean = False

        Dim arrOpciones As New ArrayList
        Dim arrTemp As ArrayList

        Dim ds As Data.DataSet
        ds = cO.ObtenerListaOpcionesReporte("Orden")

        Dim dc As New Data.DataColumn("maximo", System.Type.GetType("System.Int16"), "MAX(level)")
        ds.Tables(0).Columns.Add(dc)

        niveles = ds.Tables(0).Rows(1).Item("maximo")

        For Each drow As Data.DataRow In ds.Tables(0).Rows

            Dim Nivel As Integer = drow("level")

            If iniciado = False Then

                For i = 0 To niveles
                    arrOpciones.Add(New ArrayList)
                Next

                iniciado = True

                nodo = New TreeNode(drow("descripcion").ToString, drow("id").ToString)

                nivel_actual = Nivel

                arrTemp = arrOpciones.Item(Nivel) 'Se obtiene el arraylist (no es necesario, pero es para ser consistente
                arrTemp.Add(nodo) 'Se asigna el valor
                arrOpciones.Item(Nivel) = arrTemp 'Se almacena el arraylis

            Else

                If Nivel >= nivel_actual Then

                    nodo = New TreeNode(drow("descripcion").ToString, drow("id").ToString)
                    arrTemp = arrOpciones.Item(Nivel) 'Se obtiene el arraylist (no es necesario, pero es para ser consistente
                    arrTemp.Add(nodo) 'Se asigna el valor
                    arrOpciones.Item(Nivel) = arrTemp 'Se almacena el arraylis
                    nivel_actual = Nivel

                Else

                    For i = nivel_actual To Nivel + 1 Step -1
                        Dim nodo_padre As TreeNode
                        Dim nodo_hijo As TreeNode

                        arrTemp = arrOpciones.Item(i - 1)

                        nodo_padre = arrTemp.Item(arrTemp.Count - 1)
                        arrTemp = arrOpciones.Item(i)

                        enu = arrTemp.GetEnumerator
                        While enu.MoveNext
                            nodo_hijo = enu.Current
                            nodo_padre.ChildNodes.Add(nodo_hijo)
                        End While

                        arrTemp.Item(arrTemp.Count - 1) = nodo_padre
                        arrOpciones.Item(i) = New ArrayList

                    Next

                    nodo = New TreeNode(drow("descripcion").ToString, drow("id").ToString)
                    arrTemp = arrOpciones.Item(Nivel) 'Se obtiene el arraylist (no es necesario, pero es para ser consistente
                    arrTemp.Add(nodo) 'Se asigna el valor
                    arrOpciones.Item(Nivel) = arrTemp 'Se almacena el arraylis
                    nivel_actual = Nivel

                End If

            End If

        Next

        For i = nivel_actual To 1 Step -1
            Dim nodo_padre As TreeNode
            Dim nodo_hijo As TreeNode

            arrTemp = arrOpciones.Item(i - 1)

            nodo_padre = arrTemp.Item(arrTemp.Count - 1)
            arrTemp = arrOpciones.Item(i)

            enu = arrTemp.GetEnumerator
            While enu.MoveNext
                nodo_hijo = enu.Current
                nodo_padre.ChildNodes.Add(nodo_hijo)
            End While

            arrTemp.Item(arrTemp.Count - 1) = nodo_padre
            arrOpciones.Item(i) = New ArrayList

        Next

        arrTemp = arrOpciones(0)
        enu = arrTemp.GetEnumerator

        TreeView1.Nodes.Add(New TreeNode("Opciones del Sistema"))

        While enu.MoveNext
            Dim nodo_hijo As TreeNode
            nodo_hijo = enu.Current
            nodo_hijo.CollapseAll()
            TreeView1.Nodes(0).ChildNodes.Add(nodo_hijo)
        End While

    End Sub

    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.SelectedNodeChanged

        If LastSelectedNodeValuePath <> "" Then
            TreeView1.FindNode(LastSelectedNodeValuePath).SelectAction = TreeNodeSelectAction.Select
        End If

        LastSelectedNodeValuePath = TreeView1.SelectedNode.ValuePath

        TreeView1.SelectedNode.SelectAction = TreeNodeSelectAction.None

    End Sub

    Protected Sub btnSubir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubir.Click

        If LastSelectedNodeValuePath <> "" Then

            Dim Nodo, NodoPadre As TreeNode

            Nodo = TreeView1.FindNode(LastSelectedNodeValuePath)
            NodoPadre = Nodo.Parent

            Dim i As Integer = NodoPadre.ChildNodes.IndexOf(Nodo)

            If i = 0 Or (NodoPadre.Depth = 0 And NodoPadre.ChildNodes.IndexOf(Nodo) = 0) Then
                Exit Sub
            End If

            TreeView1.Nodes.Remove(Nodo)
            NodoPadre.ChildNodes.AddAt(i - 1, Nodo)

            ActualizarOrdenOpcion(Nodo.Value, i - 1)

            ActualizarOrdenOpcion(NodoPadre.ChildNodes(i).Value, i)

        End If

    End Sub

    Protected Sub btnBajar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBajar.Click

        If LastSelectedNodeValuePath <> "" Then

            Dim Nodo, NodoPadre As TreeNode

            Nodo = TreeView1.FindNode(LastSelectedNodeValuePath)
            NodoPadre = Nodo.Parent

            Dim i As Integer = NodoPadre.ChildNodes.IndexOf(Nodo)

            If i = NodoPadre.ChildNodes.Count() - 1 Then
                Exit Sub
            End If

            TreeView1.Nodes.Remove(Nodo)
            NodoPadre.ChildNodes.AddAt(i + 1, Nodo)

            ActualizarOrdenOpcion(Nodo.Value, i + 1)

            ActualizarOrdenOpcion(NodoPadre.ChildNodes(i).Value, i)

        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub ActualizarOrdenOpcion(ByVal IDOPCIONSISTEMA As Integer, ByVal ORDEN As Integer)

        Dim cOS As New cOPCIONESSISTEMA
        Dim eOS As New OPCIONESSISTEMA
        eOS.IDOPCIONSISTEMA = IDOPCIONSISTEMA
        eOS.ORDEN = ORDEN
        eOS.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eOS.AUFECHAMODIFICACION = Now
        eOS.ESTASINCRONIZADA = 0

        cOS.ActualizarOrden(eOS)

    End Sub

End Class
