Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlPLANTILLASMULTAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_UACI_PLANTILLASMULTAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	18/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDPLANTILLA"), ToolboxData("<{0}:ddlPLANTILLASMULTAS runat=server></{0}:ddlPLANTILLASMULTAS>")> _
Public Class ddlPLANTILLASMULTAS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Private Sub RecuperarLista()
        Dim miComponente As New cPLANTILLASMULTAS
        Dim Lista As New listaPLANTILLASMULTAS

        Lista = miComponente.ObtenerLista()
        If Not Lista.Count > 0 Then
            Return
        End If

        Me.DataSource = Lista
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDPLANTILLA"

        Me.DataBind()
    End Sub

    Public Sub Recuperar()
        RecuperarLista()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub
End Class
