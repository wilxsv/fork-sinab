Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlALMACENESENTREGAADJUDICACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_UACI_ALMACENESENTREGAADJUDICACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	01/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty(""), ToolboxData("<{0}:ddlALMACENESENTREGAADJUDICACION runat=server></{0}:ddlALMACENESENTREGAADJUDICACION>")> _
Public Class ddlALMACENESENTREGAADJUDICACION
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64, ByVal IDENTREGA As Byte, ByVal IDALMACEN As Int32)
        Dim miComponente As New cALMACENESENTREGAADJUDICACION
        Dim Lista As listaALMACENESENTREGAADJUDICACION

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, IDENTREGA, IDALMACEN)

        Me.DataSource = Lista
        Me.DataTextField = "CANTIDAD"
        Me.DataValueField = "CANTIDAD"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
