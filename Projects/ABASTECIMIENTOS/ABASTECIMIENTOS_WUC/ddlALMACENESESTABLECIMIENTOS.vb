Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlALMACENESESTABLECIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla ALMACENESESTABLECIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDESTABLECIMIENTO"), ToolboxData("<{0}:ddlALMACENESESTABLECIMIENTOS runat=server></{0}:ddlALMACENESESTABLECIMIENTOS>")> _
Public Class ddlALMACENESESTABLECIMIENTOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDALMACEN As Int32)
        Dim miComponente As New cALMACENESESTABLECIMIENTOS
        Me.DataSource = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDALMACEN)
        Me.DataTextField = "ESPRINCIPAL"
        Me.DataValueField = "ESPRINCIPAL"
        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

    Public Sub RecuperarAlmacenPrincipal(ByVal IDESTABLECIMIENTO As Int32)
        Dim miComponente As New cALMACENESESTABLECIMIENTOS
        Me.DataSource = miComponente.ObtenerAlmacenesPrincipales(IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDALMACEN"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaSubAlmacenes(ByVal IDESTABLECIMIENTO As Int32)
        Dim miComponente As New cALMACENESESTABLECIMIENTOS
        Me.DataSource = miComponente.ObtenerTodosAlmacenEstablecimiento(IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDALMACEN"
        Me.DataBind()
    End Sub

End Class
