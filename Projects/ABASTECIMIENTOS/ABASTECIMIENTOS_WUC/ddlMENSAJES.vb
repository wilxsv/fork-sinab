Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlMENSAJES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla MENSAJES
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 		18/12/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDMENSAJE"), ToolboxData("<{0}:ddlMENSAJES runat=server></{0}:ddlMENSAJES>")> _
Public Class ddlMENSAJES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Private Sub RecuperarLista()
        Dim miComponente As New cMENSAJES
        Dim Lista As listaMENSAJES

        Lista = miComponente.ObtenerLista()

        Me.DataSource = Lista
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDMENSAJE"

        Me.DataBind()
    End Sub

    Public Sub Recuperar()
        RecuperarLista()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub
End Class
