Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlTIPOTRANSACCIONES
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla TIPOTRANSACCIONES
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDTIPOTRANSACCION"), ToolboxData("<{0}:ddlTIPOTRANSACCIONES runat=server></{0}:ddlTIPOTRANSACCIONES>")> _
Public Class ddlTIPOTRANSACCIONES
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar()
        Dim miComponente As New cTIPOTRANSACCIONES
        Dim Lista As listaTIPOTRANSACCIONES

        Lista = miComponente.ObtenerLista()

        Me.DataSource = Lista
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDTIPOTRANSACCION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

#Region " Métodos agregados "

    Public Sub RecuperarTransaccionesAfectanInventario()
        Dim miComponente As New cTIPOTRANSACCIONES

        Me.DataSource = miComponente.RecuperarTransaccionesAfectanInventario()
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDTIPOTRANSACCION"

        Me.DataBind()
    End Sub

#End Region

End Class
