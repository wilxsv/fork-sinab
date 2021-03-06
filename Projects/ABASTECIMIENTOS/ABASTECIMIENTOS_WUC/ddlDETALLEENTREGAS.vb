Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlDETALLEENTREGAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla DETALLEENTREGAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDDETALLE"), ToolboxData("<{0}:ddlDETALLEENTREGAS runat=server></{0}:ddlDETALLEENTREGAS>")> _
Public Class ddlDETALLEENTREGAS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDENTREGA As Byte)
        Dim miComponente As New cDETALLEENTREGAS
        Dim Lista As listaDETALLEENTREGAS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDSOLICITUD, IDENTREGA)

        Me.DataSource = Lista
        Me.DataTextField = "DIAS"
        Me.DataValueField = "IDDETALLE"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
