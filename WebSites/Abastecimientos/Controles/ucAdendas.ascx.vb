Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucAdendas
    Inherits System.Web.UI.UserControl
    Dim IDESTABLECIMIENTO As Integer
    Dim IDPROCESOCOMPRA As Integer
    Dim NUMEROADENDA As String
    Dim FECHAADENDA As DateTime
    Dim DETALLEADENDA As String
    Dim AUUSUARIOCREACION As String
    Dim IDADENDA As Integer

    Private _PaginaRedirect As String

#Region " Propiedades "

    Public WriteOnly Property _IDESTABLECIMIENTO() As Integer
        Set(ByVal value As Integer)
            IDESTABLECIMIENTO = value
        End Set
    End Property

    Public ReadOnly Property _IDPROCESOCOMPRA() As Integer
        Get
            _IDPROCESOCOMPRA = Me.gvAdendas.SelectedRow.Cells(1).Text
        End Get
    End Property

    Public Property _IDADENDA() As Integer
        Get
            Return IDADENDA
        End Get
        Set(ByVal value As Integer)
            IDADENDA = value
        End Set
    End Property

    Public Property _NUMEROADENDA() As String
        Get
            Return NUMEROADENDA
        End Get
        Set(ByVal value As String)
            NUMEROADENDA = value
        End Set
    End Property

    Public Property _FECHAADENDA() As DateTime
        Get
            Return FECHAADENDA
        End Get
        Set(ByVal value As DateTime)
            FECHAADENDA = value
        End Set
    End Property

    Public Property _DETALLEADENDA() As String
        Get
            Return DETALLEADENDA
        End Get
        Set(ByVal value As String)
            DETALLEADENDA = value
        End Set
    End Property

    Public Property _AUUSUARIOCREACION() As String
        Get
            Return AUUSUARIOCREACION
        End Get
        Set(ByVal value As String)
            AUUSUARIOCREACION = value
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


#End Region

    'Public Sub Consultar()
    '    Me.gvProcesosCompra.Columns(4).Visible = MUESTRAFECHAPUBLICACION
    '    Me.gvProcesosCompra.Columns(3).Visible = MUESTRALUGARRETIRO
    '    CargarDatos()
    'End Sub

    Private Sub CargarDatos()

        Dim mComponente As New cADENDAS
        Dim lENTIDAD As New ADENDAS
        Dim dsADENDAS As System.Data.DataSet

        dsADENDAS = mComponente.ObtenerAdendasPorProceso(IDPROCESOCOMPRA)

        Me.gvAdendas.DataSource = dsADENDAS
        Me.gvAdendas.DataBind()

        If Me.gvAdendas.Rows.Count = 0 Then
            Me.lblSeleccione.Visible = False
        Else
            Me.lblSeleccione.Visible = True
        End If

    End Sub

    Protected Sub gvProcesosCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvAdendas.PageIndexChanging
        Me.gvAdendas.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvProcesosCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAdendas.SelectedIndexChanged
        Try
            Dim idProcesoCompra As String
            Dim idTipoCompra As String
            idProcesoCompra = Me.gvAdendas.SelectedRow.Cells(1).Text
            idTipoCompra = Me.gvAdendas.DataKeys(Me.gvAdendas.SelectedIndex).Values.Item("IDADENDA").ToString

            Dim mComTipoCompra As New cTIPOCOMPRAS
            Dim lEntTipoCompra As New TIPOCOMPRAS

            lEntTipoCompra = mComTipoCompra.ObtenerTIPOCOMPRAS(idTipoCompra)

            Dim PrefijoBase As String

            PrefijoBase = lEntTipoCompra.PREFIJOBASE


            PaginaRedirect += IIf(PaginaRedirect.IndexOf("?") > 0, "&", "?")
            PaginaRedirect += "idProc=" + idProcesoCompra
            PaginaRedirect += "&idTC=" + idTipoCompra
            PaginaRedirect += "&pf=" + PrefijoBase

            Response.Redirect(PaginaRedirect, False)
        Catch ex As Exception
            Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.ViewState("PaginaRedirect") Is Nothing Then Me._PaginaRedirect = Me.ViewState("PaginaRedirect")
    End Sub

End Class
