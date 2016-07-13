Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlUNIDADMEDIDASUMINISTROS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_CAT_UNIDADMEDIDASUMINISTROS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty(""), ToolboxData("<{0}:ddlUNIDADMEDIDASUMINISTROS runat=server></{0}:ddlUNIDADMEDIDASUMINISTROS>")> _
Public Class ddlUNIDADMEDIDASUMINISTROS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDSUMINISTRO As Int32, ByVal IDUNIDADMEDIDA As Int32)
        Dim miComponente As New cUNIDADMEDIDASUMINISTROS
        Dim Lista As listaUNIDADMEDIDASUMINISTROS

        Lista = miComponente.ObtenerLista(IDSUMINISTRO, IDUNIDADMEDIDA)

        Me.DataSource = Lista
        Me.DataTextField = "AUUSUARIOCREACION"
        Me.DataValueField = "AUUSUARIOCREACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
