Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlAMPLIACIONCONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_UTMIM_AMPLIACIONCONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	16/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDAMPLIACIONCONTRATO"), ToolboxData("<{0}:ddlAMPLIACIONCONTRATO runat=server></{0}:ddlAMPLIACIONCONTRATO>")> _
Public Class ddlAMPLIACIONCONTRATO
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64)
        Dim miComponente As New cAMPLIACIONCONTRATO
        Dim Lista As listaAMPLIACIONCONTRATO

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDCONTRATO)

        Me.DataSource = Lista
        Me.DataTextField = "CANTIDADAMPLIADA"
        Me.DataValueField = "IDAMPLIACIONCONTRATO"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
