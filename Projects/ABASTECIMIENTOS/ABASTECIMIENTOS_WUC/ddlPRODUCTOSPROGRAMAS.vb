Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlPRODUCTOSPROGRAMAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_CAT_PRODUCTOSPROGRAMAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.7.0.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	28/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty(""), ToolboxData("<{0}:ddlPRODUCTOSPROGRAMAS runat=server></{0}:ddlPRODUCTOSPROGRAMAS>")> _
Public Class ddlPRODUCTOSPROGRAMAS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDPRODUCTO As Int64, ByVal IDPROGRAMA As Int16)
        Dim miComponente As New cPRODUCTOSPROGRAMAS
        Dim Lista As listaPRODUCTOSPROGRAMAS

        Lista = miComponente.ObtenerLista(IDPRODUCTO, IDPROGRAMA)

        Me.DataSource = Lista
        Me.DataTextField = "AUUSUARIOCREACION"
        Me.DataValueField = "AUUSUARIOCREACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
