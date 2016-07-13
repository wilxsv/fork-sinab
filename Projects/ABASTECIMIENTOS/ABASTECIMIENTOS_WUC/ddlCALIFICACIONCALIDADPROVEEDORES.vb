Imports System.ComponentModel

Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlCALIFICACIONCALIDADPROVEEDORES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla CALIFICACIONCALIDADPROVEEDORES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDCALIFICACION"), ToolboxData("<{0}:ddlCALIFICACIONCALIDADPROVEEDORES runat=server></{0}:ddlCALIFICACIONCALIDADPROVEEDORES>")> _
Public Class ddlCALIFICACIONCALIDADPROVEEDORES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar()
        Dim miComponente As New cCALIFICACIONCALIDADPROVEEDORES
        Dim Lista As listaCALIFICACIONCALIDADPROVEEDORES

        Lista = miComponente.ObtenerLista()

        Me.DataSource = Lista
        Me.DataTextField = "CANTIDADINICIO"
        Me.DataValueField = "IDCALIFICACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
