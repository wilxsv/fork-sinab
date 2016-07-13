Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucListaEstados
    Inherits System.Web.UI.UserControl

    Dim mComponente As New cESTADOS
    Dim ESTABLECEVALOR As Integer
    Dim ENABLED As Boolean


    Public WriteOnly Property _ESTABLECEVALOR() As Integer
        Set(ByVal value As Integer)
            ESTABLECEVALOR = value
        End Set
    End Property

    Public ReadOnly Property _VALORACTUAL() As Integer
        Get
            _VALORACTUAL = Me.ddlListaEstados.SelectedValue
        End Get
    End Property



    Public WriteOnly Property _ENABLED() As Boolean
        Set(ByVal value As Boolean)
            ENABLED = value
        End Set
    End Property

    Public Sub obtenerDatos()
        Me.ddlListaEstados.DataSource = mComponente.ObtenerLista()
        Me.ddlListaEstados.DataTextField = "DESCRIPCION"
        Me.ddlListaEstados.DataValueField = "IDESTADO"
        Me.ddlListaEstados.DataBind()
    End Sub

    Public Sub establecerValor()
        Me.ddlListaEstados.SelectedValue = Me.ESTABLECEVALOR
    End Sub

    Public Sub habilitarControl()
        Me.ddlListaEstados.Enabled = ENABLED
    End Sub



End Class
