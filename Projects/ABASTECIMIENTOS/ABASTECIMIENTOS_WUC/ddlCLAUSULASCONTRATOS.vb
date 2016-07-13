Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlCLAUSULASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla CLAUSULASCONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDCONTRATO"), ToolboxData("<{0}:ddlCLAUSULASCONTRATOS runat=server></{0}:ddlCLAUSULASCONTRATOS>")> _
Public Class ddlCLAUSULASCONTRATOS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDCLAUSULA As Int32)
        Dim miComponente As New cCLAUSULASCONTRATOS
        Dim Lista As listaCLAUSULASCONTRATOS

        Lista = miComponente.ObtenerLista(IDCLAUSULA)

        Me.DataSource = Lista
        Me.DataTextField = "ENCABEZADOCLAUSULA"
        Me.DataValueField = "IDCONTRATO"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
