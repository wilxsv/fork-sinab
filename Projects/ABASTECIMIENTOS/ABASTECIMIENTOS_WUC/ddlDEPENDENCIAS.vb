Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlDEPENDENCIAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_CAT_DEPENDENCIAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDDEPENDENCIA"), ToolboxData("<{0}:ddlDEPENDENCIAS runat=server></{0}:ddlDEPENDENCIAS>")> _
Public Class ddlDEPENDENCIAS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(Optional ByVal ut As Integer = 0)
        Dim miComponente As New cDEPENDENCIAS
        Dim Lista As listaDEPENDENCIAS

        Lista = miComponente.ObtenerLista(ut)

        Me.DataSource = Lista
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDDEPENDENCIA"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
