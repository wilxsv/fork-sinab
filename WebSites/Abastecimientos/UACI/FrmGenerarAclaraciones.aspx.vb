Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases

Partial Class frmGenerarAclaraciones
    Inherits System.Web.UI.Page
#Region " Propiedades "

    Dim IDESTABLECIMIENTO As Integer
    Dim IDPROCESOCOMPRA As Integer
    Dim NUMEROACLARACION As String
    Dim FECHAACLARACION As DateTime
    Dim DETALLEACLARACION As String
    Dim AUUSUARIOCREACION As String
    Dim IDACLARACION As Integer

    Private _PaginaRedirect As String
    Public WriteOnly Property _IDESTABLECIMIENTO() As Integer
        Set(ByVal value As Integer)
            IDESTABLECIMIENTO = value
        End Set
    End Property

    Public ReadOnly Property _IDPROCESOCOMPRA() As Integer
        Get
            _IDPROCESOCOMPRA = Me.gvAclaraciones.SelectedRow.Cells(1).Text
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PaginaRedirect = "frmdetalleACLARACION.aspx"
        Dim mComponente As New cACLARACIONES
        Dim lENTIDAD As New ACLARACIONES
        Dim dsACLARACIONES As System.Data.DataSet

        'Me.UcBarraNavegacion1.PermitirConsultar = False
        'Me.UcBarraNavegacion1.PermitirEditar = False
        'Me.UcBarraNavegacion1.PermitirImprimir = False
        'Me.UcBarraNavegacion1.PermitirGuardar = False
        'Me.UcBarraNavegacion1.Navegacion = False
        Me.Master.ControlMenu.Visible = False
        IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        IDPROCESOCOMPRA = Session("IdProcesoCompra")

        dsACLARACIONES = mComponente.ObtenerACLARACIONESPorProceso(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        Me.gvAclaraciones.DataSource = dsACLARACIONES
        Me.gvAclaraciones.DataBind()

        If Me.gvAclaraciones.Rows.Count = 0 Then
            Me.lblSeleccione.Visible = False
        Else
            Me.lblSeleccione.Visible = True
        End If
    End Sub

    Private Sub CargarDatos()

        Dim mComponente As New cACLARACIONES
        Dim lENTIDAD As New ACLARACIONES
        Dim dsACLARACIONES As System.Data.DataSet

        dsACLARACIONES = mComponente.ObtenerACLARACIONESPorProceso(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        Me.gvAclaraciones.DataSource = dsACLARACIONES
        Me.gvAclaraciones.DataBind()

        If Me.gvAclaraciones.Rows.Count = 0 Then
            Me.lblSeleccione.Visible = False
        Else
            Me.lblSeleccione.Visible = True
        End If

    End Sub

    Protected Sub gvProcesosCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvAclaraciones.PageIndexChanging
        Me.gvAclaraciones.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Protected Sub btGuardar_Click(sender As Object, e As System.EventArgs) Handles btGuardar.Click
        Response.Redirect("~/UACI/frmDetACLARACIONES.aspx?id=0")
    End Sub


    Protected Sub gvACLARACIONES_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAclaraciones.SelectedIndexChanged
        SINAB_Utils.Utils.MostrarVentana("/Reportes/frmrptaclaraciones.aspx?id=" & gvAclaraciones.SelectedRow.Cells(1).Text & "&p=" & IDPROCESOCOMPRA)
        ' ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "window.open('" + Request.ApplicationPath + "/Reportes/frmrptaclaraciones.aspx?id=" & gvAclaraciones.SelectedRow.Cells(1).Text & "&p=" & IDPROCESOCOMPRA & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800px ,height= 600px ');", True)
    End Sub


End Class
