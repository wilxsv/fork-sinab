Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlALMACENESENTREGACONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_UACI_ALMACENESENTREGACONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	01/02/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDESTABLECIMIENTO"), ToolboxData("<{0}:ddlALMACENESENTREGACONTRATOS runat=server></{0}:ddlALMACENESENTREGACONTRATOS>")> _
Public Class ddlALMACENESENTREGACONTRATOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByVal IDDETALLE As Int64, ByVal IDALMACENENTREGA As Int32)
        Dim miComponente As New cALMACENESENTREGACONTRATOS
        Dim Lista As listaALMACENESENTREGACONTRATOS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, IDDETALLE, IDALMACENENTREGA)

        Me.DataSource = Lista
        Me.DataTextField = "CANTIDAD"
        Me.DataValueField = "CANTIDAD"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
