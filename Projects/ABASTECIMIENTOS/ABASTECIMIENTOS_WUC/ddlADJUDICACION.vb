Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlADJUDICACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla ADJUDICACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDPROCESOCOMPRA"), ToolboxData("<{0}:ddlADJUDICACION runat=server></{0}:ddlADJUDICACION>")> _
Public Class ddlADJUDICACION
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64)
        Dim miComponente As New cADJUDICACION
        Dim Lista As listaADJUDICACION

        Lista = miComponente.ObtenerLista(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDPROVEEDOR, IDDETALLE)

        Me.DataSource = Lista
        Me.DataTextField = "CANTIDADRECOMENDACION"
        Me.DataValueField = "CANTIDADRECOMENDACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
