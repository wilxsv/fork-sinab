Imports System.ComponentModel
Imports System.Web.UI

<DefaultProperty("IDGRUPO"), ToolboxData("<{0}:ddlGRUPOSFUENTEFINANCIAMIENTO runat=server></{0}:ddlGRUPOSFUENTEFINANCIAMIENTO>")> _
Public Class ddlGRUPOSFUENTEFINANCIAMIENTO
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar()
        Dim miComponente As New cGRUPOSFUENTEFINANCIAMIENTO

        Me.DataSource = miComponente.ObtenerLista()
        Me.DataTextField = "DESCRIPCION"
        Me.DataValueField = "IDGRUPO"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
