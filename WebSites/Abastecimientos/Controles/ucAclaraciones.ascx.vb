Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucAclaraciones
    Inherits System.Web.UI.UserControl

    Dim IDESTABLECIMIENTO As Integer
    Dim IDPROCESOCOMPRA As Integer
    Dim NUMEROACLARACION As String
    Dim FECHAACLARACION As DateTime
    Dim DETALLEACLARACION As String
    Dim AUUSUARIOCREACION As String
    Dim IDACLARACION As Integer

    Private _PaginaRedirect As String

#Region " Propiedades "

    Public WriteOnly Property _IDESTABLECIMIENTO() As Integer
        Set(ByVal value As Integer)
            IDESTABLECIMIENTO = value
        End Set
    End Property

    Public ReadOnly Property _IDPROCESOCOMPRA() As Integer
        Get
            _IDPROCESOCOMPRA = Me.gvACLARACIONES.SelectedRow.Cells(1).Text
        End Get
    End Property

    Public Property _IDACLARACION() As Integer
        Get
            Return IDACLARACION
        End Get
        Set(ByVal value As Integer)
            IDACLARACION = value
        End Set
    End Property

    Public Property _NUMEROACLARACION() As String
        Get
            Return NUMEROACLARACION
        End Get
        Set(ByVal value As String)
            NUMEROACLARACION = value
        End Set
    End Property

    Public Property _FECHAACLARACION() As DateTime
        Get
            Return FECHAACLARACION
        End Get
        Set(ByVal value As DateTime)
            FECHAACLARACION = value
        End Set
    End Property

    Public Property _DETALLEACLARACION() As String
        Get
            Return DETALLEACLARACION
        End Get
        Set(ByVal value As String)
            DETALLEACLARACION = value
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

    
    Private Sub CargarDatos()

        Dim mComponente As New cACLARACIONES

        Dim dsACLARACIONES As System.Data.DataSet
        dsACLARACIONES = mComponente.ObtenerACLARACIONESPorProceso(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        Me.gvACLARACIONES.DataSource = dsACLARACIONES

        Me.gvACLARACIONES.DataBind()

        If Me.gvACLARACIONES.Rows.Count = 0 Then
            Me.lblSeleccione.Visible = False
        Else
            Me.lblSeleccione.Visible = True
        End If

    End Sub

    Protected Sub gvProcesosCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvACLARACIONES.PageIndexChanging
        Me.gvACLARACIONES.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvProcesosCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvACLARACIONES.SelectedIndexChanged
        Try
            Dim idProcesoCompra As String
            Dim idTipoCompra As String
            idProcesoCompra = Me.gvACLARACIONES.SelectedRow.Cells(1).Text
            idTipoCompra = Me.gvACLARACIONES.DataKeys(Me.gvACLARACIONES.SelectedIndex).Values.Item("IDACLARACION").ToString

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
