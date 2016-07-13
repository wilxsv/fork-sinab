Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlCALIFICACIONRENGLONOFERTAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla CALIFICACIONRENGLONOFERTAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	07/12/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("PORCENTAJE"), ToolboxData("<{0}:ddlCALIFICACIONRENGLONOFERTAS runat=server></{0}:ddlCALIFICACIONRENGLONOFERTAS>")> _
Public Class ddlCALIFICACIONRENGLONOFERTAS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDCRITERIOEVALUACION As Int16, ByVal IDPROVEEDOR As Int32, ByVal IDDETALLE As Int64)
        Dim miComponente As New cCALIFICACIONRENGLONOFERTAS
        Dim Lista As listaCALIFICACIONRENGLONOFERTAS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCRITERIOEVALUACION, IDPROVEEDOR, IDDETALLE)

        Me.DataSource = Lista
        Me.DataTextField = "PORCENTAJE"
        Me.DataValueField = "PORCENTAJE"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
