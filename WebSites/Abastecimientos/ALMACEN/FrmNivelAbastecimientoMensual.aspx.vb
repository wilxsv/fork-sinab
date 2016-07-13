
Partial Class ALMACEN_FrmNivelAbastecimientoMensual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dba As New ABASTECIMIENTOS.NEGOCIO.cALMACENES
            Me.Master.ControlMenu.Visible = False

            Me.Label2.Text = DateTime.Now.Year

            ' Me.Label3.Text = dba.ObtenerSemana(DateTime.Now)
            'Me.Label1.Text = dba.ObtenerDatosSemana(Me.Label3.Text)
            Me.ddlAnioAbas.DataSource = dba.ObtenerAnioAbastecimiento()
            Me.ddlAnioAbas.DataTextField = "anio"
            Me.ddlAnioAbas.DataValueField = "anio"
            Me.ddlAnioAbas.DataBind()
            Me.ddlAnioAbas.SelectedValue = Now.Year

            Dim cS As New ABASTECIMIENTOS.NEGOCIO.cSUMINISTROS
            Me.DropDownList1.DataSource = cS.RecuperarOrdenadaPorCorrelativo
            Me.DropDownList1.DataTextField = "DESCRIPCION"
            Me.DropDownList1.DataValueField = "IDSUMINISTRO"
            Me.DropDownList1.DataBind()

            'Me.DropDownList2.DataSource = dba.ObtenerSemanasaConsultar()
            'Me.DropDownList2.DataTextField = "SEMANA"
            'Me.DropDownList2.DataValueField = "IDSEMANA"
            'Me.DropDownList2.DataBind()

            Dim bEntidad2 As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMAS
            Me.DropDownList3.DataSource = bEntidad2.ObtenerPROGRAMAS
            Me.DropDownList3.DataValueField = "idPrograma"
            Me.DropDownList3.DataTextField = "NOMBRE"

            Me.DropDownList3.DataBind()

            Dim item As New ListItem("(Todos)", 0)
            Me.DropDownList3.Items.Insert(0, item)

            Me.DropDownList3.SelectedIndex = 0


            'Me.DropDownList2.SelectedValue = dba.ObtenerSemana(DateTime.Now) - 1



        End If
        'Button1_Click(sender, e)
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim cA As New ABASTECIMIENTOS.NEGOCIO.cALMACENES
    '    Dim ds As Data.DataSet
    '    If Not Me.DropDownList2.SelectedValue = "" Then
    '        ds = cA.ObtenerNivelAbastecimientoPantalla(Me.DropDownList2.SelectedValue, Me.DropDownList1.SelectedValue, Me.ddlAnioAbas.SelectedValue)
    '        Me.GridView1.DataSource = ds
    '        Me.GridView1.DataBind()
    '        Me.Label1.Text = FormatPercent(cA.ObtenerPromedioNacional(Me.DropDownList2.SelectedValue, Me.DropDownList1.SelectedValue, DateTime.Now.Year), 1, TriState.False)
    '        Me.Label5.Text = Format(100 - (cA.ObtenerPromedioNacional(Me.DropDownList2.SelectedValue, Me.DropDownList1.SelectedValue, DateTime.Now.Year) * 100), "##,##0.0") & "%"


    '    End If



    'End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dba As New ABASTECIMIENTOS.NEGOCIO.cALMACENES
        Dim cad = String.Format("/Reportes/FrmRptNivelAbastecimientoProductosMensual.aspx?idSe={0}&idS={1}&idA={2}&idP={3}", DropDownList2.SelectedValue, DropDownList1.SelectedValue, ddlAnioAbas.SelectedValue, DropDownList3.SelectedValue)
        SINAB_Utils.Utils.MostrarVentana(cad)
    End Sub

    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim dba As New ABASTECIMIENTOS.NEGOCIO.cALMACENES
    '    Dim s As New StringBuilder



    '    s.Append("<script language='javascript'>window.open('")
    '    s.Append(Request.ApplicationPath)
    '    s.Append("/Reportes/FrmRptNivelAbastecimientoProductos.aspx")
    '    s.Append("?idSe=")
    '    s.Append(Me.DropDownList2.SelectedValue)
    '    s.Append("&idS=")
    '    s.Append(Me.DropDownList1.SelectedValue)
    '    s.Append("&idH=")
    '    Dim btnDetails As LinkButton = sender
    '    Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
    '    Dim idh As Integer = Me.GridView1.DataKeys(row.RowIndex).Values(0)
    '    s.Append(idh)
    '    s.Append("', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');</script>")

    '    Page.ClientScript.RegisterStartupScript(Me.GetType, "rpt", s.ToString)
    'End Sub

    'Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged
    '    Button1_Click(sender, e)
    'End Sub

    'Protected Sub ddlAnioAbas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAnioAbas.SelectedIndexChanged
    '    Dim dba As New ABASTECIMIENTOS.NEGOCIO.cALMACENES
    '    If ddlAnioAbas.SelectedValue = Now.Year Then
    '        Me.DropDownList2.DataSource = dba.ObtenerSemanasaConsultar()
    '        Me.DropDownList2.DataTextField = "SEMANA"
    '        Me.DropDownList2.DataValueField = "IDSEMANA"
    '        Me.DropDownList2.DataBind()
    '    Else
    '        Me.DropDownList2.DataSource = dba.ObtenerSemanasaConsultar(ddlAnioAbas.SelectedValue)
    '        Me.DropDownList2.DataTextField = "SEMANA"
    '        Me.DropDownList2.DataValueField = "IDSEMANA"
    '        Me.DropDownList2.DataBind()
    '    End If
    'End Sub

   
  
End Class
