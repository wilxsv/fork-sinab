Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla CONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDCONTRATO"), ToolboxData("<{0}:ddlCONTRATOS runat=server></{0}:ddlCONTRATOS>")> _
Public Class ddlCONTRATOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32)
        Dim miComponente As New cCONTRATOS
        Dim Lista As listaCONTRATOS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROVEEDOR)

        Me.DataSource = Lista
        Me.DataTextField = "NUMEROCONTRATO"
        Me.DataValueField = "IDCONTRATO"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
