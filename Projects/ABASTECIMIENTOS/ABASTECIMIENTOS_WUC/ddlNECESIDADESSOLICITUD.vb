Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlNECESIDADESSOLICITUD
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla NECESIDADESSOLICITUD
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDESTABLECIMIENTOSOLICITUD"), ToolboxData("<{0}:ddlNECESIDADESSOLICITUD runat=server></{0}:ddlNECESIDADESSOLICITUD>")> _
Public Class ddlNECESIDADESSOLICITUD
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTOSOLICITUD As Int32, ByVal IDESTABLECIMIENTONECESIDAD As Int32, ByVal IDNECESIDAD As Int64, ByVal IDSOLICITUD As Int64)
        Dim miComponente As New cNECESIDADESSOLICITUD
        Dim Lista As listaNECESIDADESSOLICITUD

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTOSOLICITUD, IDESTABLECIMIENTONECESIDAD, IDNECESIDAD, IDSOLICITUD)

        Me.DataSource = Lista
        Me.DataTextField = "AUUSUARIOCREACION"
        Me.DataValueField = "AUUSUARIOCREACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
