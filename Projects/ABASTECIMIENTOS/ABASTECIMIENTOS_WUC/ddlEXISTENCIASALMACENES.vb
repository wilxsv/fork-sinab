Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlEXISTENCIASALMACENES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla EXISTENCIASALMACENES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDALMACEN"), ToolboxData("<{0}:ddlEXISTENCIASALMACENES runat=server></{0}:ddlEXISTENCIASALMACENES>")> _
Public Class ddlEXISTENCIASALMACENES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDALMACEN As Int32, ByVal IDPRODUCTO As Int64)
        Dim miComponente As New cEXISTENCIASALMACENES
        Dim Lista As listaEXISTENCIASALMACENES

        Lista = miComponente.ObtenerLista(IDALMACEN, IDPRODUCTO)

        Me.DataSource = Lista
        Me.DataTextField = "MAX"
        Me.DataValueField = "MAX"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
