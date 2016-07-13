Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlCRITERIOSPLANTILLAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla CRITERIOSPLANTILLAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDPLANTILLA"), ToolboxData("<{0}:ddlCRITERIOSPLANTILLAS runat=server></{0}:ddlCRITERIOSPLANTILLAS>")> _
Public Class ddlCRITERIOSPLANTILLAS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDPLANTILLA As Int32, ByVal IDCRITERIOEVALUACION As Int16)
        Dim miComponente As New cCRITERIOSPLANTILLAS
        Dim Lista As listaCRITERIOSPLANTILLAS

        Lista = miComponente.ObtenerLista(IDPLANTILLA, IDCRITERIOEVALUACION)

        Me.DataSource = Lista
        Me.DataTextField = "PORCENTAJE"
        Me.DataValueField = "PORCENTAJE"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
