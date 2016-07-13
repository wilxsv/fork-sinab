Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlTIPOMOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_CAT_TIPOMOVIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	10/06/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDTIPOMOVIMIENTO"), ToolboxData("<{0}:ddlTIPOMOVIMIENTOS runat=server></{0}:ddlTIPOMOVIMIENTOS>")> _
Public Class ddlTIPOMOVIMIENTOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDTIPOTRANSACCION As Int32)
        Dim miComponente As New cTIPOMOVIMIENTOS
        Me.DataSource = miComponente.ObtenerLista(IDTIPOTRANSACCION)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDTIPOMOVIMIENTO"
        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
