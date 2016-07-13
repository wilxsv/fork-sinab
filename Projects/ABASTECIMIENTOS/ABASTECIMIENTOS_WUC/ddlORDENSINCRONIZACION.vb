Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlORDENSINCRONIZACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla ORDENSINCRONIZACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("ORDEN"), ToolboxData("<{0}:ddlORDENSINCRONIZACION runat=server></{0}:ddlORDENSINCRONIZACION>")> _
Public Class ddlORDENSINCRONIZACION
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar()
        Dim miComponente As New cORDENSINCRONIZACION
        Dim Lista As listaORDENSINCRONIZACION

        Lista = miComponente.ObtenerLista()

        Me.DataSource = Lista
        Me.DataTextField = "TABLA"
        Me.DataValueField = "ORDEN"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
