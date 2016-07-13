Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlMOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_ALM_MOVIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDMOVIMIENTO"), ToolboxData("<{0}:ddlMOVIMIENTOS runat=server></{0}:ddlMOVIMIENTOS>")> _
Public Class ddlMOVIMIENTOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Private Sub RecuperarLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32)
        Dim miComponente As New cMOVIMIENTOS
        Dim Lista As New listaMOVIMIENTOS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDTIPOTRANSACCION)
        If Not Lista.Count > 0 Then
            Return
        End If

        Me.DataSource = Lista
        Me.DataTextField = "NUMERODOCREF"
        Me.DataValueField = "IDMOVIMIENTO"

        Me.DataBind()
    End Sub

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32)
        RecuperarLista(IDESTABLECIMIENTO, IDTIPOTRANSACCION)
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub
End Class
