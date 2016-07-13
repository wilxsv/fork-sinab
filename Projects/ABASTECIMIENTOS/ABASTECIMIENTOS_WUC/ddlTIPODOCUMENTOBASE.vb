Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlTIPODOCUMENTOBASE
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla TIPODOCUMENTOBASE
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDTIPODOCUMENTOBASE"), ToolboxData("<{0}:ddlTIPODOCUMENTOBASE runat=server></{0}:ddlTIPODOCUMENTOBASE>")> _
Public Class ddlTIPODOCUMENTOBASE
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar()
        Dim miComponente As New cTIPODOCUMENTOBASE
        Dim Lista As listaTIPODOCUMENTOBASE

        Lista = miComponente.ObtenerLista()
        Me.DataSource = Lista
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDTIPODOCUMENTOBASE"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

    Public Sub RecuperarListaPorProcesoCompra(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int32, Optional ByVal IDTIPODOCUMENTOBASE() As Integer = Nothing)
        Dim miComponente As New cTIPODOCUMENTOBASE

        Me.DataSource = miComponente.RecuperarListaPorProcesoCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDTIPODOCUMENTOBASE)
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDTIPODOCUMENTOBASE"

        Me.DataBind()
    End Sub

End Class
