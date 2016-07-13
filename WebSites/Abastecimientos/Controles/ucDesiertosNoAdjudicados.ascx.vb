Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucDesiertosNoAdjudicados
    Inherits System.Web.UI.UserControl

    Dim _EVAL_FEC_REC As Boolean
    Dim _EVAL_FEC_RET As Boolean
    Dim _ESTADO As Integer
    Dim _ESTADOS() As Integer
    Dim _IDESTABLECIMIENTO As Integer
    Dim _USUARIOCOMISION As String
    Dim _MUESTRAFECHAPUBLICACION As Boolean = True
    Dim _MUESTRALUGARRETIRO As Boolean = True

    Private _PaginaRedirect As String
    Private _IDENCARGADO As Integer

#Region " Propiedades "

    Public Property ESTADO() As Integer
        Get
            Return _ESTADO
        End Get
        Set(ByVal value As Integer)
            _ESTADO = value
        End Set
    End Property

    Public Property MUESTRAFECHAPUBLICA() As Boolean
        Get
            Return _MUESTRAFECHAPUBLICACION
        End Get
        Set(ByVal value As Boolean)
            _MUESTRAFECHAPUBLICACION = value
        End Set
    End Property

    Public Property MUESTRALUGARRETIRO() As Boolean
        Get
            Return _MUESTRALUGARRETIRO
        End Get
        Set(ByVal value As Boolean)
            _MUESTRALUGARRETIRO = value
        End Set
    End Property

    Public Property ESTADOS() As Integer()
        Get
            Return Me._ESTADOS
        End Get
        Set(ByVal Value As Integer())
            Array.Resize(Me._ESTADOS, Value.Length)
            Me._ESTADOS = Value
        End Set
    End Property

    Public Property PaginaRedirect() As String
        Get
            Return _PaginaRedirect
        End Get
        Set(ByVal Value As String)
            _PaginaRedirect = Value
            If Not Me.ViewState("PaginaRedirect") Is Nothing Then Me.ViewState.Remove("PaginaRedirect")
            Me.ViewState.Add("PaginaRedirect", Value)
        End Set
    End Property

    Public Property IDENCARGADO() As Integer
        Get
            Return _IDENCARGADO
        End Get
        Set(ByVal Value As Integer)
            _IDENCARGADO = Value
        End Set
    End Property

    Public Property USUARIOCOMISION() As String
        Get
            Return _USUARIOCOMISION
        End Get
        Set(ByVal value As String)
            _USUARIOCOMISION = value
        End Set
    End Property

    Public WriteOnly Property EVAL_FEC_RET() As Boolean
        Set(ByVal value As Boolean)
            _EVAL_FEC_RET = value
        End Set
    End Property

    Public WriteOnly Property EVAL_FEC_REC() As Boolean
        Set(ByVal value As Boolean)
            _EVAL_FEC_REC = value
        End Set
    End Property

    Public ReadOnly Property IDPROCESO() As Integer
        Get
            IDPROCESO = Me.gvProcesosCompra.SelectedRow.Cells(1).Text
        End Get
    End Property

    Public WriteOnly Property IDESTABLECIMIENTO() As Integer
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
        End Set
    End Property

#End Region

    Public Sub Consultar()
        Me.gvProcesosCompra.Columns(4).Visible = _MUESTRAFECHAPUBLICACION
        Me.gvProcesosCompra.Columns(3).Visible = _MUESTRALUGARRETIRO
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        Dim mComponente As New cPROCESOCOMPRAS
        Dim lENTIDAD As New PROCESOCOMPRAS
        Dim ds As Data.DataSet

        lENTIDAD.IDESTADOPROCESOCOMPRA = ESTADO
        lENTIDAD.IDESTABLECIMIENTO = _IDESTABLECIMIENTO
        lENTIDAD.IDENCARGADO = IDENCARGADO

        ds = mComponente.ObtenerListapor_ESTADO(lENTIDAD, _EVAL_FEC_RET, _EVAL_FEC_REC, ESTADOS, USUARIOCOMISION)

        Me.gvProcesosCompra.DataSource = ds
        Me.gvProcesosCompra.DataBind()

        If Me.gvProcesosCompra.Rows.Count = 0 Then
            Me.lblSeleccione.Visible = False
        Else
            Me.lblSeleccione.Visible = True
        End If

    End Sub

    Protected Sub gvProcesosCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProcesosCompra.PageIndexChanging
        Me.gvProcesosCompra.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvProcesosCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProcesosCompra.SelectedIndexChanged
        Session("IdProcesoCompra") = Me.gvProcesosCompra.SelectedRow.Cells(1).Text
        SINAB_Utils.Utils.MostrarVentana("/Reportes/FrmRptDesiertosNoAdjudicados.aspx?1")

        'Page.ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptDesiertosNoAdjudicados.aspx?1', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.ViewState("PaginaRedirect") Is Nothing Then Me._PaginaRedirect = Me.ViewState("PaginaRedirect")
    End Sub

End Class
