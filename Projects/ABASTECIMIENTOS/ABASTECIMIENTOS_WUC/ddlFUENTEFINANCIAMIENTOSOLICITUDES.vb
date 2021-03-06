Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlFUENTEFINANCIAMIENTOSOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla FUENTEFINANCIAMIENTOSOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDESTABLECIMIENTO"), ToolboxData("<{0}:ddlFUENTEFINANCIAMIENTOSOLICITUDES runat=server></{0}:ddlFUENTEFINANCIAMIENTOSOLICITUDES>")> _
Public Class ddlFUENTEFINANCIAMIENTOSOLICITUDES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDFUENTEFINANCIAMIENTO As Int32)
        Dim miComponente As New cFUENTEFINANCIAMIENTOSOLICITUDES
        Dim Lista As listaFUENTEFINANCIAMIENTOSOLICITUDES

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDSOLICITUD, IDFUENTEFINANCIAMIENTO)

        Me.DataSource = Lista
        Me.DataTextField = "MONTOPARTICIPACION"
        Me.DataValueField = "MONTOPARTICIPACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
