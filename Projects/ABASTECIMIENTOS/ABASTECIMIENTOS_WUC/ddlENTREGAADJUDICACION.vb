Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlENTREGAADJUDICACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_UACI_ENTREGAADJUDICACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	01/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDENTREGA"), ToolboxData("<{0}:ddlENTREGAADJUDICACION runat=server></{0}:ddlENTREGAADJUDICACION>")> _
Public Class ddlENTREGAADJUDICACION
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64)
        Dim miComponente As New cENTREGAADJUDICACION
        Dim Lista As listaENTREGAADJUDICACION

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE)

        Me.DataSource = Lista
        Me.DataTextField = "PORCENTAJE"
        Me.DataValueField = "IDENTREGA"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
