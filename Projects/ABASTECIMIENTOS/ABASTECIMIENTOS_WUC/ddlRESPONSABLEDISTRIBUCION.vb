Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlRESPONSABLEDISTRIBUCION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla RESPONSABLEDISTRIBUCION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDRESPONSABLEDISTRIBUCION"), ToolboxData("<{0}:ddlRESPONSABLEDISTRIBUCION runat=server></{0}:ddlRESPONSABLEDISTRIBUCION>")> _
Public Class ddlRESPONSABLEDISTRIBUCION
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar()
        Dim miComponente As New cRESPONSABLEDISTRIBUCION
        Dim Lista As listaRESPONSABLEDISTRIBUCION

        Lista = miComponente.ObtenerLista()

        Me.DataSource = Lista
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDRESPONSABLEDISTRIBUCION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

#Region "Métodos agregados"

    Public Sub RecuperarNombreCorto()
        Dim miComponente As New cRESPONSABLEDISTRIBUCION
        Dim Lista As listaRESPONSABLEDISTRIBUCION

        Lista = miComponente.ObtenerLista()

        Me.DataSource = Lista
        Me.DataTextField = "NOMBRECORTO"
        Me.DataValueField = "IDRESPONSABLEDISTRIBUCION"

        Me.DataBind()
    End Sub

#End Region

End Class
