Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlDETALLESOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla DETALLESOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDDETALLE"), ToolboxData("<{0}:ddlDETALLESOLICITUDES runat=server></{0}:ddlDETALLESOLICITUDES>")> _
Public Class ddlDETALLESOLICITUDES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64)
        Dim miComponente As New cDETALLESOLICITUDES
        Dim Lista As listaDETALLESOLICITUDES

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDSOLICITUD)

        Me.DataSource = Lista
        Me.DataTextField = "RENGLON"
        Me.DataValueField = "IDDETALLE"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
