Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class frmGenerarAdendas
    Inherits System.Web.UI.Page

#Region " Propiedades "

    Dim IDESTABLECIMIENTO As Integer
    Dim IDPROCESOCOMPRA As Integer
    Dim NUMEROADENDA As String
    Dim FECHAADENDA As DateTime
    Dim DETALLEADENDA As String
    Dim AUUSUARIOCREACION As String
    Dim IDADENDA As Integer

    Private _PaginaRedirect As String
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'With Me.UcVistaDetalleProcesoCompra1
        'Dim estados As Integer() = {eESTADOPROCESOSCOMPRAS.BASEGENERADA, eESTADOPROCESOSCOMPRAS.BASEPUBLICADA}
        '.ESTADOS = estados
        ''._ESTADO = 2
        ''Session("IdProcesoCompra") = ._IDPROCESO
        '._EVAL_FEC_REC = False
        '._EVAL_FEC_RET = False
        '._IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.PaginaRedirect = "frmdetalleADENDA.aspx"
        '.IDENCARGADO = Session.Item("IdEmpleado")
        '._MUESTRAFECHAPUBLICA = False
        '._MUESTRALUGARRETIRO = False
        '.Consultar()
        ''End With
        'Me.Master.ControlMenu.Visible = False

        Dim mComponente As New cADENDAS
        Dim lENTIDAD As New ADENDAS
        Dim dsADENDAS As System.Data.DataSet

        Me.UcBarraNavegacion1.PermitirConsultar = False
        Me.UcBarraNavegacion1.PermitirEditar = False
        Me.UcBarraNavegacion1.PermitirImprimir = False
        Me.UcBarraNavegacion1.PermitirGuardar = False
        Me.UcBarraNavegacion1.Navegacion = False
        Me.Master.ControlMenu.Visible = False

        IDPROCESOCOMPRA = Session("IdProcesoCompra")

        dsADENDAS = mComponente.ObtenerAdendasPorProceso(IDPROCESOCOMPRA)

        Me.gvAdendas.DataSource = dsADENDAS


        Me.gvAdendas.DataBind()

        If Me.gvAdendas.Rows.Count = 0 Then
            Me.lblSeleccione.Visible = False
        Else
            Me.lblSeleccione.Visible = True
        End If
    End Sub

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

    'Protected Sub gvProcesosCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAdendas.SelectedIndexChanged
    '    IdProcesoCompra = Me.gvProcesosCompra.SelectedRow.Cells(1).Text
    '    Dim alerta As String = "<script language='JavaScript'>" & "window.open('./reportes/frmrptadenda.aspx?id={0}, 'popup');" & "</script>"

    '    ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)


    '    'Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('./reportes/frmrptadenda.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    '    'Try
    '    '    Dim IdProcesoCompra As String
    '    '    Dim idTipoCompra As String
    '    '    IdProcesoCompra = Me.gvAdendas.SelectedRow.Cells(1).Text
    '    '    idTipoCompra = Me.gvAdendas.DataKeys(Me.gvAdendas.SelectedIndex).Values.Item("IDADENDA").ToString

    '    '    Dim mComTipoCompra As New cTIPOCOMPRAS
    '    '    Dim lEntTipoCompra As New TIPOCOMPRAS

    '    '    'lEntTipoCompra = mComTipoCompra.ObtenerTIPOCOMPRAS(idTipoCompra)

    '    '    Dim PrefijoBase As String

    '    '    PrefijoBase = lEntTipoCompra.PREFIJOBASE


    '    '    PaginaRedirect += IIf(PaginaRedirect.IndexOf("?") > 0, "&", "?")
    '    '    PaginaRedirect += "idProc=" + IdProcesoCompra
    '    '    'PaginaRedirect += "&idTC=" + idTipoCompra
    '    '    'PaginaRedirect += "&pf=" + PrefijoBase

    '    '    Response.Redirect(PaginaRedirect, False)
    '    'Catch ex As Exception
    '    '    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex)
    '    'End Try
    'End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub UcBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Agregar
        Response.Redirect("~/UACI/frmDetAdendas.aspx?id=0")
    End Sub

    Protected Sub gvAdendas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAdendas.SelectedIndexChanged
        Session("adenda") = Me.gvAdendas.SelectedRow.Cells(1).Text
        ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmrptadenda.aspx?id=" & Session("adenda") & "1', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

End Class
