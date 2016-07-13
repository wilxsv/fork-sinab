Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlMULTASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_UACI_MULTASCONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDMULTA"), ToolboxData("<{0}:ddlMULTASCONTRATOS runat=server></{0}:ddlMULTASCONTRATOS>")> _
Public Class ddlMULTASCONTRATOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64)
        Dim miComponente As New cMULTASCONTRATOS
        Dim Lista As listaMULTASCONTRATOS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

        Me.DataSource = Lista
        Me.DataTextField = "FECHAMULTA"
        Me.DataValueField = "IDMULTA"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
