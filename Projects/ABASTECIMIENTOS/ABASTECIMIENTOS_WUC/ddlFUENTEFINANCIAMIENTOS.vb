Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlFUENTEFINANCIAMIENTOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla FUENTEFINANCIAMIENTOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDFUENTEFINANCIAMIENTO"), ToolboxData("<{0}:ddlFUENTEFINANCIAMIENTOS runat=server></{0}:ddlFUENTEFINANCIAMIENTOS>")> _
Public Class ddlFUENTEFINANCIAMIENTOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar()
        Dim miComponente As New cFUENTEFINANCIAMIENTOS
        Dim Lista As listaFUENTEFINANCIAMIENTOS

        Lista = miComponente.ObtenerLista()

        Me.DataSource = Lista
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDFUENTEFINANCIAMIENTO"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

    Public Sub RecuperarPorGrupo(Optional ByVal IDGRUPO As Integer = 0)
        Dim miComponente As New cFUENTEFINANCIAMIENTOS

        Me.DataSource = miComponente.RecuperarPorGrupo(IDGRUPO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDFUENTEFINANCIAMIENTO"

        Me.DataBind()
    End Sub
    Public Sub RecuperarPorGrupoYFuente(Optional ByVal IDGRUPO As Integer = 0)
        Dim miComponente As New cFUENTEFINANCIAMIENTOS

        Me.DataSource = miComponente.RecuperarPorGrupo(IDGRUPO)
        Me.DataTextField = "GRUPOYFUENTE"
        Me.DataValueField = "IDFUENTEFINANCIAMIENTO"

        Me.DataBind()
    End Sub
End Class
