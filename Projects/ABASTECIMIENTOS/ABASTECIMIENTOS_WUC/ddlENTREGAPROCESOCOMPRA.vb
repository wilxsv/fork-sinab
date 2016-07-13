Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlENTREGAPROCESOCOMPRA
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla ENTREGAPROCESOCOMPRA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDENTREGA"), ToolboxData("<{0}:ddlENTREGAPROCESOCOMPRA runat=server></{0}:ddlENTREGAPROCESOCOMPRA>")> _
Public Class ddlENTREGAPROCESOCOMPRA
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64)
        Dim miComponente As New cENTREGAPROCESOCOMPRA
        Dim Lista As listaENTREGAPROCESOCOMPRA

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        Me.DataSource = Lista
        Me.DataTextField = "AUUSUARIOCREACION"
        Me.DataValueField = "IDENTREGA"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
