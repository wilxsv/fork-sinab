Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlNIVELESUSOESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla NIVELESUSOESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDESTABLECIMIENTO"), ToolboxData("<{0}:ddlNIVELESUSOESTABLECIMIENTOS runat=server></{0}:ddlNIVELESUSOESTABLECIMIENTOS>")> _
Public Class ddlNIVELESUSOESTABLECIMIENTOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNIVELUSO As Byte)
        Dim miComponente As New cNIVELESUSOESTABLECIMIENTOS
        Dim Lista As listaNIVELESUSOESTABLECIMIENTOS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDNIVELUSO)

        Me.DataSource = Lista
        Me.DataTextField = "AUUSUARIOCREACION"
        Me.DataValueField = "AUUSUARIOCREACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
