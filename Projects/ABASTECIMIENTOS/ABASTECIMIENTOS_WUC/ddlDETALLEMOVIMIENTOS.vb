Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlDETALLEMOVIMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_ALM_DETALLEMOVIMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	11/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDDETALLEMOVIMIENTO"), ToolboxData("<{0}:ddlDETALLEMOVIMIENTOS runat=server></{0}:ddlDETALLEMOVIMIENTOS>")> _
Public Class ddlDETALLEMOVIMIENTOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Private Sub RecuperarLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64)
        Dim miComponente As New cDETALLEMOVIMIENTOS
        Dim Lista As New listaDETALLEMOVIMIENTOS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO)
        If Not Lista.Count > 0 Then
            Return
        End If

        Me.DataSource = Lista
        Me.DataTextField = "IDPRODUCTO"
        Me.DataValueField = "IDDETALLEMOVIMIENTO"

        Me.DataBind()
    End Sub

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDTIPOTRANSACCION As Int32, ByVal IDMOVIMIENTO As Int64)
        RecuperarLista(IDESTABLECIMIENTO, IDTIPOTRANSACCION, IDMOVIMIENTO)
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub
End Class
