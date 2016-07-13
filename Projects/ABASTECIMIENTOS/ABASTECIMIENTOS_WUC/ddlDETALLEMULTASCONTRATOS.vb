Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlDETALLEMULTASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_UACI_DETALLEMULTASCONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	22/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDDETALLE"), ToolboxData("<{0}:ddlDETALLEMULTASCONTRATOS runat=server></{0}:ddlDETALLEMULTASCONTRATOS>")> _
Public Class ddlDETALLEMULTASCONTRATOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDMULTA As Int64)
        Dim miComponente As New cDETALLEMULTASCONTRATOS
        Dim Lista As listaDETALLEMULTASCONTRATOS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMULTA)

        Me.DataSource = Lista
        Me.DataTextField = "RENGLON"
        Me.DataValueField = "IDDETALLE"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
