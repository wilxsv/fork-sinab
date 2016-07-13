Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlHISTORICOESTADOSNECESIDADES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla HISTORICOESTADOSNECESIDADES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDDETALLE"), ToolboxData("<{0}:ddlHISTORICOESTADOSNECESIDADES runat=server></{0}:ddlHISTORICOESTADOSNECESIDADES>")> _
Public Class ddlHISTORICOESTADOSNECESIDADES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32)
        Dim miComponente As New cHISTORICOESTADOSNECESIDADES
        Dim Lista As listaHISTORICOESTADOSNECESIDADES

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO)

        Me.DataSource = Lista
        Me.DataTextField = "FECHA"
        Me.DataValueField = "IDDETALLE"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
