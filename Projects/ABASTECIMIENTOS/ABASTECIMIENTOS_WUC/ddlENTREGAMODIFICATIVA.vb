Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlENTREGAMODIFICATIVA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla ENTREGAMODIFICATIVA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDENTREGA"), ToolboxData("<{0}:ddlENTREGAMODIFICATIVA runat=server></{0}:ddlENTREGAMODIFICATIVA>")> _
Public Class ddlENTREGAMODIFICATIVA
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMODIFICATIVA As Int64, ByVal RENGLON As Int64)
        Dim miComponente As New cENTREGAMODIFICATIVA
        Dim Lista As listaENTREGAMODIFICATIVA

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMODIFICATIVA, RENGLON)

        Me.DataSource = Lista
        Me.DataTextField = "PLAZOENTREGA"
        Me.DataValueField = "IDENTREGA"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
