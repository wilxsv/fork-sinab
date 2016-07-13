Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlSUMINISTRODEPENDENCIAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SUMINISTRODEPENDENCIAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDDEPENDENCIA"), ToolboxData("<{0}:ddlSUMINISTRODEPENDENCIAS runat=server></{0}:ddlSUMINISTRODEPENDENCIAS>")> _
Public Class ddlSUMINISTRODEPENDENCIAS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDDEPENDENCIA As Int32, ByVal IDSUMINISTRO As Int32)
        Dim miComponente As New cSUMINISTRODEPENDENCIAS
        Dim Lista As listaSUMINISTRODEPENDENCIAS

        Lista = miComponente.ObtenerLista(IDDEPENDENCIA, IDSUMINISTRO)

        Me.DataSource = Lista
        Me.DataTextField = "AUUSUARIOCREACION"
        Me.DataValueField = "AUUSUARIOCREACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
