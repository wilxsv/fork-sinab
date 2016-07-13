Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlRECEPCIONOFERTAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla RECEPCIONOFERTAS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDESTABLECIMIENTO"), ToolboxData("<{0}:ddlRECEPCIONOFERTAS runat=server></{0}:ddlRECEPCIONOFERTAS>")> _
Public Class ddlRECEPCIONOFERTAS
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Int32)
        Dim miComponente As New cRECEPCIONOFERTAS
        Dim Lista As listaRECEPCIONOFERTAS

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)

        Me.DataSource = Lista
        Me.DataTextField = "ORDENLLEGADA"
        Me.DataValueField = "ORDENLLEGADA"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class