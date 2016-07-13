Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlAJUSTE
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla AJUSTE
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDALMACEN"), ToolboxData("<{0}:ddlAJUSTE runat=server></{0}:ddlAJUSTE>")> _
Public Class ddlAJUSTE
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDALMACEN As Int32, ByVal IDINVENTARIO As Int32, ByVal IDDETALLE As Int32)
        Dim miComponente As New cAJUSTE
        Dim Lista As listaAJUSTE

        Lista = miComponente.ObtenerLista(IDALMACEN, IDINVENTARIO, IDDETALLE)

        Me.DataSource = Lista
        Me.DataTextField = "MOTIVO"
        Me.DataValueField = "MOTIVO"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
