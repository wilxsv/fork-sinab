Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlDETALLENOTAINCUMPLIMIENTOCONTRATO
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla SAB_UACI_DETALLENOTAINCUMPLIMIENTOCONTRATO
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	18/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDDETALLENOTAINCUMPLIMIENTOCONTRATO"), ToolboxData("<{0}:ddlDETALLENOTAINCUMPLIMIENTOCONTRATO runat=server></{0}:ddlDETALLENOTAINCUMPLIMIENTOCONTRATO>")> _
Public Class ddlDETALLENOTAINCUMPLIMIENTOCONTRATO
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Private Sub RecuperarLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDNOTA As Int32)
        Dim miComponente As New cDETALLENOTAINCUMPLIMIENTOCONTRATO
        Dim Lista As New listaDETALLENOTAINCUMPLIMIENTOCONTRATO

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
        If Not Lista.Count > 0 Then
            Return
        End If

        Me.DataSource = Lista
        Me.DataTextField = "RENGLON"
        Me.DataValueField = "IDDETALLENOTAINCUMPLIMIENTOCONTRATO"

        Me.DataBind()
    End Sub

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDNOTA As Int32)
        RecuperarLista(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub
End Class
