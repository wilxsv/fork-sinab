Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlCLAUSULASPLANTILLA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_UACI_CLAUSULASPLANTILLA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	16/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("ORDEN"), ToolboxData("<{0}:ddlCLAUSULASPLANTILLA runat=server></{0}:ddlCLAUSULASPLANTILLA>")> _
Public Class ddlCLAUSULASPLANTILLA
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPLANTILLA As Int32, ByVal IDCLAUSULA As Int32)
        Dim miComponente As New cCLAUSULASPLANTILLA
        Dim Lista As listaCLAUSULASPLANTILLA

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPLANTILLA, IDCLAUSULA)

        Me.DataSource = Lista
        Me.DataTextField = "CONTENIDO"
        Me.DataValueField = "ORDEN"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
