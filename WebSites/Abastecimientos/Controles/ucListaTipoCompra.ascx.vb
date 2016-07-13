Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucListaTipoCompra
    Inherits System.Web.UI.UserControl

    Dim mComponente As New cTIPOCOMPRAS
    Dim ESTABLECEVALOR As Integer
    Dim ENABLED As Boolean


    Public WriteOnly Property _ESTABLECEVALOR() As Integer
        Set(ByVal value As Integer)
            ESTABLECEVALOR = value
        End Set
    End Property

    Public ReadOnly Property _VALORACTUAL() As Integer
        Get
            _VALORACTUAL = Me.ddlListaCompras.SelectedValue
        End Get
    End Property



    Public WriteOnly Property _ENABLED() As Boolean
        Set(ByVal value As Boolean)
            ENABLED = value
        End Set
    End Property

    Public Sub obtenerDatos()
        Me.ddlListaCompras.DataSource = mComponente.ObtenerLista()
        Me.ddlListaCompras.DataTextField = "DESCRIPCION"
        Me.ddlListaCompras.DataValueField = "IDTIPOCOMPRA"
        Me.ddlListaCompras.DataBind()
    End Sub

    Public Sub establecerValor()
        Me.ddlListaCompras.SelectedValue = Me.ESTABLECEVALOR
    End Sub

    Public Sub habilitarControl()
        Me.ddlListaCompras.Enabled = ENABLED
    End Sub



End Class
