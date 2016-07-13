Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlHISTORICOPRECIOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla HISTORICOPRECIOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("CORRELATIVO"), ToolboxData("<{0}:ddlHISTORICOPRECIOS runat=server></{0}:ddlHISTORICOPRECIOS>")> _
Public Class ddlHISTORICOPRECIOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDPRODUCTO As Int64)
        Dim miComponente As New cHISTORICOPRECIOS
        Dim Lista As listaHISTORICOPRECIOS

        Lista = miComponente.ObtenerLista(IDPRODUCTO)

        Me.DataSource = Lista
        Me.DataTextField = "FECHA"
        Me.DataValueField = "CORRELATIVO"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
