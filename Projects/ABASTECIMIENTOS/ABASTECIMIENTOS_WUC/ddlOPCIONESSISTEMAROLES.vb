Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlOPCIONESSISTEMAROLES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SEGOPCIONESSISTEMAROLES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDROL"), ToolboxData("<{0}:ddlOPCIONESSISTEMAROLES runat=server></{0}:ddlOPCIONESSISTEMAROLES>")> _
Public Class ddlOPCIONESSISTEMAROLES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDROL As Int32, ByVal IDOPCIONSISTEMA As Int32)
        Dim miComponente As New cOPCIONESSISTEMAROLES
        Dim Lista As listaOPCIONESSISTEMAROLES

        Lista = miComponente.ObtenerLista(IDROL, IDOPCIONSISTEMA)

        Me.DataSource = Lista
        Me.DataTextField = "AUUSUARIOCREACION"
        Me.DataValueField = "AUUSUARIOCREACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class