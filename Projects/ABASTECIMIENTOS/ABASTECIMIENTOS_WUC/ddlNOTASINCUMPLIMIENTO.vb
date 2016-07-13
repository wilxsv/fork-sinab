Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlNOTASINCUMPLIMIENTO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla NOTASINCUMPLIMIENTO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDESTABLECIMIENTO"), ToolboxData("<{0}:ddlNOTASINCUMPLIMIENTO runat=server></{0}:ddlNOTASINCUMPLIMIENTO>")> _
Public Class ddlNOTASINCUMPLIMIENTO
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32)
        Dim miComponente As New cNOTASINCUMPLIMIENTO
        Dim Lista As listaNOTASINCUMPLIMIENTO

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)

        Me.DataSource = Lista
        Me.DataTextField = "FECHALIMITE"
        Me.DataValueField = "FECHALIMITE"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
