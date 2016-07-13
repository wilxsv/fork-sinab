Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlEMPLEADOSALMACEN
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla EMPLEADOSALMACEN
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDALMACEN"), ToolboxData("<{0}:ddlEMPLEADOSALMACEN runat=server></{0}:ddlEMPLEADOSALMACEN>")> _
Public Class ddlEMPLEADOSALMACEN
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDALMACEN As Int32, ByVal IDEMPLEADO As Int32)
        Dim miComponente As New cEMPLEADOSALMACEN
        Dim Lista As listaEMPLEADOSALMACEN

        Lista = miComponente.ObtenerLista(IDALMACEN, IDEMPLEADO)

        Me.DataSource = Lista
        Me.DataTextField = "ESGUARDAALMACEN"
        Me.DataValueField = "ESGUARDAALMACEN"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
