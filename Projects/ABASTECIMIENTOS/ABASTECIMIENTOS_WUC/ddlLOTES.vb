Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlLOTES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_ALM_LOTES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDLOTE"), ToolboxData("<{0}:ddlLOTES runat=server></{0}:ddlLOTES>")> _
Public Class ddlLOTES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDALMACEN As Int32)
        Dim miComponente As New cLOTES
        Dim Lista As listaLOTES

        Lista = miComponente.ObtenerLista(IDALMACEN)

        Me.DataSource = Lista
        Me.DataTextField = "CODIGO"
        Me.DataValueField = "IDLOTE"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
