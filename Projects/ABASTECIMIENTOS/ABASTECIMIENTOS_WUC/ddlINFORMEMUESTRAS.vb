Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlINFORMEMUESTRAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_LAB_INFORMEMUESTRAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDINFORME"), ToolboxData("<{0}:ddlINFORMEMUESTRAS runat=server></{0}:ddlINFORMEMUESTRAS>")> _
Public Class ddlINFORMEMUESTRAS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32)
        Dim miComponente As New cINFORMEMUESTRAS
        Dim Lista As listaINFORMEMUESTRAS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO)

        Me.DataSource = Lista
        Me.DataTextField = "NUMEROINFORME"
        Me.DataValueField = "IDINFORME"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
