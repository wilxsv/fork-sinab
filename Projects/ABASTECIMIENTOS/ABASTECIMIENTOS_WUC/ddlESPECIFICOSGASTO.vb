Imports System.ComponentModel
Imports System.Web.UI

<DefaultProperty("IDESPECIFICOGASTO"), ToolboxData("<{0}:ddlESPECIFICOSGASTO runat=server></{0}:ddlESPECIFICOSGASTO>")> _
Public Class ddlESPECIFICOSGASTO
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar()
        Dim miComponente As New cESPECIFICOSGASTO

        Me.DataSource = miComponente.ObtenerLista()
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDESPECIFICOGASTO"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

    Public Sub RecuperarEspecificos()
        Dim miComponente As New cESPECIFICOSGASTO

        Me.DataSource = miComponente.RecuperarEspecificos()
        Me.DataTextField = "CODIGONOMBRE"
        Me.DataValueField = "IDESPECIFICOGASTO"

        Me.DataBind()
    End Sub

End Class
