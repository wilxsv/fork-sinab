
Partial Class FrmNotificacionInformes
    Inherits System.Web.UI.Page
    Private _IDPROCESOCOMPRA As Integer
    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Public Property IDPROCESOCOMPRA() As Integer
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDPROCESOCOMPRA = value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IdProcesoCompra", value)
        End Set
    End Property
    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
        End Set
    End Property
    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            _IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property
    Public Property IDCONTRATO() As Integer
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDCONTRATO = value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", value)
        End Set
    End Property
    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            cargar()
        Else
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.IDCONTRATO = Me.ViewState("IDCONTRATO")

        End If
    End Sub

    'Carga de datos 
    Public Sub cargar()

        Dim dPC As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS
        Me.GridView1.DataSource = dPC.ObtenerProcesoCompraAdjudicados()
        Me.GridView1.DataBind()

    End Sub

    'Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView11.SelectedIndexChanged
    '    Me.Panel2.Visible = True
    '    Dim lnk As New LinkButton
    '    lnk = Me.GridView11.Rows(Me.GridView11.SelectedIndex).Cells(0).Controls(1)
    '    Me.Label1.Text = lnk.Text

    'End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Me.CalendarPopup1.PostedDate = "" Then
            Me.Label2.Text = "Debe seleccionar una fecha"
        Else
            Me.Label2.Text = ""

            Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS

            If cIM.ActualizarFechaNotiProv(Session.Item("IdEstablecimiento"), Me.GridView11.DataKeys(Me.GridView11.SelectedIndex).Values.Item("IDINFORME"), Me.CalendarPopup1.SelectedDate) <> 1 Then
                Me.Label2.Text = "Error al guardar la fecha."
            End If
            'cargar()
            Me.GridView11.DataSource = cIM.ObtenerFechasRemision2(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCONTRATO, IDPROVEEDOR)
            Me.GridView11.DataBind()
            Me.Panel2.Visible = False
            Me.GridView11.SelectedIndex = -1
        End If
    End Sub

    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    If Me.ViewState("columnaFiltro") Is Nothing And Me.ViewState("valorFiltro") Is Nothing Then
    '        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRemisionInforme.aspx?Campo=0&Valor=0', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    '    End If
    '    Select Case Me.ViewState("columnaFiltro").ToString
    '        Case Is = "NUMEROINFORME"
    '            Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRemisionInforme.aspx?Campo=1&Valor=" & Me.ViewState("valorFiltro") & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    '        Case Is = "TIPOINFORME"
    '            Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRemisionInforme.aspx?Campo=2&Valor=" & Left(Me.ViewState("valorFiltro"), 1) & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    '        Case Is = "RESULTADO"
    '            Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRemisionInforme.aspx?Campo=3&Valor=" & Left(Me.ViewState("valorFiltro"), 1) & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    '    End Select
    'End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim cP As New ABASTECIMIENTOS.NEGOCIO.cPROVEEDORES
        IDPROCESOCOMPRA = Me.GridView1.DataKeys(e.NewSelectedIndex).Values(1)
        IDESTABLECIMIENTO = Me.GridView1.DataKeys(e.NewSelectedIndex).Values(0)

        Me.GridView2.DataSource = cP.obtenerProveedoresCertificados(IDESTABLECIMIENTO, IDPROCESOCOMPRA, True)
        Me.GridView2.DataBind()
        Me.pnProveedores.Visible = True
    End Sub

    Protected Sub GridView2_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView2.SelectedIndexChanging
        Dim cA As New ABASTECIMIENTOS.NEGOCIO.cADJUDICACION
        IDPROVEEDOR = Me.GridView2.DataKeys(e.NewSelectedIndex).Values(0)
        IDCONTRATO = Me.GridView2.DataKeys(e.NewSelectedIndex).Values(1)

        Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        Me.GridView11.DataSource = cIM.ObtenerFechasRemision2(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDCONTRATO, IDPROVEEDOR)
        Me.GridView11.DataBind()
        Me.Panel1.Visible = True



    End Sub

    Protected Sub GridView11_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView11.SelectedIndexChanging
        Dim lnk As New LinkButton
        lnk = Me.GridView11.Rows(e.NewSelectedIndex).Cells(0).Controls(1)
        Me.Label1.Text = lnk.Text

        Me.Panel2.Visible = True
    End Sub
End Class
