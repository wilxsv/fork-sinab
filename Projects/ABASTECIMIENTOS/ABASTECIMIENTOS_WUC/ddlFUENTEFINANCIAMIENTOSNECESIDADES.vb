Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlFUENTEFINANCIAMIENTOSNECESIDADES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla FUENTEFINANCIAMIENTOSNECESIDADES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDESTABLECIMIENTO"), ToolboxData("<{0}:ddlFUENTEFINANCIAMIENTOSNECESIDADES runat=server></{0}:ddlFUENTEFINANCIAMIENTOSNECESIDADES>")> _
Public Class ddlFUENTEFINANCIAMIENTOSNECESIDADES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32)
        Dim miComponente As New cFUENTEFINANCIAMIENTOSNECESIDADES
        Dim Lista As listaFUENTEFINANCIAMIENTOSNECESIDADES

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDNECESIDAD, IDFUENTEFINANCIAMIENTO)

        Me.DataSource = Lista
        Me.DataTextField = "AUUSUARIOCREACION"
        Me.DataValueField = "AUUSUARIOCREACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
