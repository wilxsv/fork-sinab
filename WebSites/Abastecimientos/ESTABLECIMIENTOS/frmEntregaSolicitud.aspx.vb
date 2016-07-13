'MODIFICACION DE DETALLE DE ENTREGAS DE SOLICITUD DE COMPRAS
'CU-ESTA0001
'Ing. Yessenia Pennelope Henriquez Duran
'formulario para la modificacion de detalle de entregas de solicitud de compras

Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Data
Partial Class frmEntregaSolicitud
    Inherits System.Web.UI.Page
    Dim lId As Int64
    Private mComponente As New cDETALLEENTREGAS
    Private mCompEntregas As New cENTREGASOLICITUDES
    Dim entregas As Integer
    Dim DetalleEntrega As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.IsAuthenticated Then
            If Not IsPostBack Then
                lId = Request.QueryString("id") 'identificador de solicitud
                Me.txtIDSOLICITUD.Text = lId
                Me.UcPlazosEntregaModificacion1.IDSOLICITUD = Me.txtIDSOLICITUD.Text
                Me.UcPlazosEntregaModificacion1.Enabled = False
                CargarArbolEntregas()
                Me.TvEntregas.ExpandAll()
                Me.TvEntregas.ExpandDepth = 3
            End If
        End If
    End Sub

    Private Sub CargarArbolEntregas() 'llena el treeviw de entreegas
        Me.TvEntregas.Nodes.Clear()
        Me.TvEntregas.ShowLines = True
        Me.TvEntregas.Nodes.Add(BuildNode("Entregas Definidas"))
        Dim parent As TreeNode
        Dim r As DataRow

        entregas = mCompEntregas.ObtenerNumeroEntregas(Me.txtIDSOLICITUD.Text, Session.Item("IdEstablecimiento"))
        Dim i As Integer

        For i = 0 To entregas
            If i <> entregas Then
                Me.TvEntregas.Nodes(0).ChildNodes.Add(BuildNode("Entrega " & i + 1))
                DetalleEntrega = mCompEntregas.ObtenerDetalleEntrega(Me.txtIDSOLICITUD.Text, Session.Item("IdEstablecimiento"), i + 1)
                parent = TvEntregas.Nodes(0).ChildNodes(i)
                For Each r In DetalleEntrega.Tables(0).Rows
                    Dim Nombre As String = r("DIAS") & " Dias / " & r("PORCENTAJE") & " % / " & r("DESCRIPCION")
                    parent.ChildNodes.Add(BuildNode(Nombre))
                Next r
            End If
        Next i
    End Sub

    Private Function BuildNode(ByVal strTextAndValue As String, Optional ByVal strURL As String = "javascript:void(0)") As TreeNode
        ' Crea a TreeNode y asigna
        ' el texto y el valor 
        Dim node As New TreeNode
        node.Text = strTextAndValue
        node.Value = strTextAndValue
        node.NavigateUrl = strURL
        node.SelectAction = TreeNodeSelectAction.None
        Return node
    End Function

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("~/ESTABLECIMIENTOS/FrmSolicitudEntregas.aspx")
    End Sub

    Protected Sub UcPlazosEntregaModificacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcPlazosEntregaModificacion1.Guardar
        Me.UcPlazosEntregaModificacion1.IDSOLICITUD = Me.txtIDSOLICITUD.Text
        CargarArbolEntregas()
        Me.TvEntregas.ExpandAll()
        Me.TvEntregas.ExpandDepth = 3
    End Sub
End Class
