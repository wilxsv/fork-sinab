Imports System.ComponentModel
Imports System.Web.UI

<DefaultProperty("IDLOTE"), ToolboxData("<{0}:ddlLotesXProducto runat=server></{0}:ddlLotesXProducto>")> _
Public Class ddlLotesXProducto
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64)
        Dim miComponente As New cLOTES
        Dim Lista As listaLOTES

        Lista = miComponente.ObtenerListaXproducto(IDALMACEN, IDPRODUCTO)

        Me.DataSource = Lista
        Me.DataTextField = "CODIGO"
        Me.DataValueField = "IDLOTE"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class

