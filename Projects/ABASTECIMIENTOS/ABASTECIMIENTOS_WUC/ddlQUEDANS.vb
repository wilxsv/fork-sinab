Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlQUEDANS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_UACI_QUEDANS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	24/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDQUEDAN"), ToolboxData("<{0}:ddlQUEDANS runat=server></{0}:ddlQUEDANS>")> _
Public Class ddlQUEDANS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16, ByVal IDGARANTIACONTRATO As Int32)
        Dim miComponente As New cQUEDANS
        Dim Lista As listaQUEDANS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDTIPOGARANTIA, IDGARANTIACONTRATO)

        Me.DataSource = Lista
        Me.DataTextField = "FECHAINGRESO"
        Me.DataValueField = "IDQUEDAN"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
