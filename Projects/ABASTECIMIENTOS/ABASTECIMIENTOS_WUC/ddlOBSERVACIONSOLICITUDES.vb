Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlOBSERVACIONSOLICITUDES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla OBSERVACIONSOLICITUDES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDESTABLECIMIENTO"), ToolboxData("<{0}:ddlOBSERVACIONSOLICITUDES runat=server></{0}:ddlOBSERVACIONSOLICITUDES>")> _
Public Class ddlOBSERVACIONSOLICITUDES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64, ByVal IDESTADO As Int32)
        Dim miComponente As New cOBSERVACIONSOLICITUDES
        Dim Lista As listaOBSERVACIONSOLICITUDES

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDSOLICITUD, IDESTADO)

        Me.DataSource = Lista
        Me.DataTextField = "OBSERVACION"
        Me.DataValueField = "OBSERVACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
