Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlPROGRAMADISTRIBUCION
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_UACI_PROGRAMADISTRIBUCION
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	29/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("RENGLON"), ToolboxData("<{0}:ddlPROGRAMADISTRIBUCION runat=server></{0}:ddlPROGRAMADISTRIBUCION>")> _
Public Class ddlPROGRAMADISTRIBUCION
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTOSOLICITA As Int32, ByVal IDSOLICITUD As Int64)
        Dim miComponente As New cPROGRAMADISTRIBUCION
        Dim Lista As listaPROGRAMADISTRIBUCION

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDESTABLECIMIENTOSOLICITA, IDSOLICITUD)

        Me.DataSource = Lista
        Me.DataTextField = "CANTIDADSOLICITADA"
        Me.DataValueField = "RENGLON"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
