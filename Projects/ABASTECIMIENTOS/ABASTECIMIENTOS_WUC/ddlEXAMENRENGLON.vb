Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlEXAMENRENGLON
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla EXAMENRENGLON
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDESTABLECIMIENTO"), ToolboxData("<{0}:ddlEXAMENRENGLON runat=server></{0}:ddlEXAMENRENGLON>")> _
Public Class ddlEXAMENRENGLON
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByVal IDDOCUMENTOBASE As Int16)
        Dim miComponente As New cEXAMENRENGLON
        Dim Lista As listaEXAMENRENGLON

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, IDDOCUMENTOBASE)

        Me.DataSource = Lista
        Me.DataTextField = "ENTREGADO1"
        Me.DataValueField = "ENTREGADO1"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
