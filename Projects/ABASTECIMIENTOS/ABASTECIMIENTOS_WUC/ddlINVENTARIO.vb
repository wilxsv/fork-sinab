Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlINVENTARIO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla INVENTARIO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDINVENTARIO"), ToolboxData("<{0}:ddlINVENTARIO runat=server></{0}:ddlINVENTARIO>")> _
Public Class ddlINVENTARIO
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDALMACEN As Int32)
        Dim miComponente As New cINVENTARIO
        Dim Lista As listaINVENTARIO

        Lista = miComponente.ObtenerLista(IDALMACEN)

        Me.DataSource = Lista
        Me.DataTextField = "FECHAINICIO"
        Me.DataValueField = "IDINVENTARIO"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
