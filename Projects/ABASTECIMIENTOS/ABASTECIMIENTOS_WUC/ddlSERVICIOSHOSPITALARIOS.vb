Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlSERVICIOSHOSPITALARIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SERVICIOSHOSPITALARIOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	15/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDSERVICIOHOSPITALARIO"), ToolboxData("<{0}:ddlSERVICIOSHOSPITALARIOS runat=server></{0}:ddlSERVICIOSHOSPITALARIOS>")> _
Public Class ddlSERVICIOSHOSPITALARIOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32)
        Dim miComponente As New cSERVICIOSHOSPITALARIOS
        Me.DataSource = miComponente.ObtenerLista(IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRESERVICIO"
        Me.DataValueField = "IDSERVICIOHOSPITALARIO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaOrdenada(ByVal IDESTABLECIMIENTO As Int32)
        Dim miComponente As New cSERVICIOSHOSPITALARIOS
        Me.DataSource = miComponente.ObtenerListaOrdenada(IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRESERVICIO"
        Me.DataValueField = "IDSERVICIOHOSPITALARIO"
        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
