Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlDEPARTAMENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla DEPARTAMENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDDEPARTAMENTO"), ToolboxData("<{0}:ddlDEPARTAMENTOS runat=server></{0}:ddlDEPARTAMENTOS>")> _
Public Class ddlDEPARTAMENTOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar()
        Dim miComponente As New cDEPARTAMENTOS
        Dim Lista As listaDEPARTAMENTOS

        Lista = miComponente.ObtenerLista()

        Me.DataSource = Lista
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDDEPARTAMENTO"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
