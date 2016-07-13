Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlINFORMESNOACEPTACION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla INFORMESNOACEPTACION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDINFORME"), ToolboxData("<{0}:ddlINFORMESNOACEPTACION runat=server></{0}:ddlINFORMESNOACEPTACION>")> _
Public Class ddlINFORMESNOACEPTACION
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDALMACEN As Int32)
        Dim miComponente As New cINFORMESNOACEPTACION
        Dim Lista As listaINFORMESNOACEPTACION

        Lista = miComponente.ObtenerLista(IDALMACEN)

        Me.DataSource = Lista
        Me.DataTextField = "RESPONSABLEPROVEEDOR"
        Me.DataValueField = "IDINFORME"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
