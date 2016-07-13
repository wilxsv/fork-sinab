Imports System.ComponentModel
Imports System.Web.UI

''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_WebUC
''' Class	 : WebUC.ddlOBSERVACIONDETALLENECESIDAD
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase del Control de Usuario Personalizado de una Lista Desplegable Web
''' de la tabla OBSERVACIONDETALLENECESIDAD
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	17/11/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
<DefaultProperty("IDOBSERVACION"), ToolboxData("<{0}:ddlOBSERVACIONDETALLENECESIDAD runat=server></{0}:ddlOBSERVACIONDETALLENECESIDAD>")> _
Public Class ddlOBSERVACIONDETALLENECESIDAD
    Inherits System.Web.UI.WebControls.DropDownList

    Private _sError As Boolean
    Public Event ErrorEvent As EventHandler

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Sub Recuperar(ByVal IDESTABLECIMIENTO As Int32, ByVal IDNECESIDAD As Int64, ByVal IDPRODUCTO As Int64)
        Dim miComponente As New cOBSERVACIONDETALLENECESIDAD
        Dim Lista As listaOBSERVACIONDETALLENECESIDAD

        Lista = miComponente.ObtenerLista(IDESTABLECIMIENTO, IDNECESIDAD, IDPRODUCTO)

        Me.DataSource = Lista
        Me.DataTextField = "OBSERVACION"
        Me.DataValueField = "IDOBSERVACION"

        Me.DataBind()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
    End Sub

End Class
