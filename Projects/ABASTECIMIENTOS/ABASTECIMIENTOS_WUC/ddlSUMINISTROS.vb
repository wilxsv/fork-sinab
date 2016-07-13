Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlSUMINISTROS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_CAT_SUMINISTROS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDSUMINISTRO"), ToolboxData("<{0}:ddlSUMINISTROS runat=server></{0}:ddlSUMINISTROS>")> _
Public Class ddlSUMINISTROS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar()
        Dim miComponente As New cSUMINISTROS

        Me.DataSource = miComponente.ObtenerLista()
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDSUMINISTRO"

        Me.DataBind()
    End Sub
    Public Sub RecuperarxDependencia(ByVal iddependencia As Integer)
        Dim miComponente As New cSUMINISTROS

        Me.DataSource = miComponente.obtenerSuministroUT(iddependencia)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDSUMINISTRO"

        Me.DataBind()
    End Sub
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub
End Class
