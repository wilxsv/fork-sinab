Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmConsultaInformes
    Inherits System.Web.UI.Page

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim cI As New cINFORMEMUESTRAS
            Me.DropDownList2.DataTextField = "PROVEEDOR"
            Me.DropDownList2.DataValueField = "IDPROVEEDOR"
            Me.DropDownList2.DataSource = cI.RecuperarProveedores()
            Me.DropDownList2.DataBind()
            Me.DropDownList3.DataTextField = "NUMEROCONTRATO"
            Me.DropDownList3.DataValueField = "IDCONTRATO"
            Me.DropDownList3.DataSource = cI.RecuperarcONTRATOS()
            Me.DropDownList3.DataBind()
            Me.DropDownList4.DataTextField = "NUMEROMODALIDADCOMPRA"
            Me.DropDownList4.DataValueField = "IDPROCESOCOMPRA"
            Me.DropDownList4.DataSource = cI.RecuperarCompras()
            Me.DropDownList4.DataBind()
            Me.DropDownList7.DataTextField = "LOTE"
            Me.DropDownList7.DataValueField = "IDINFORME"
            Me.DropDownList7.DataSource = cI.RecuperarLotes()
            Me.DropDownList7.DataBind()
            Me.DropDownList5.DataTextField = "NOMBREMEDICAMENTO"
            Me.DropDownList5.DataValueField = "IDINFORME"
            Me.DropDownList5.DataSource = cI.RecuperarProducto()
            Me.DropDownList5.DataBind()

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ORIGEN As Integer = 2
        Dim TIPOPRODUCTO As Integer = 3
        Dim IDPROVEEDOR As Integer = 0
        Dim IDCONTRATO As String = ""
        Dim NUMEROMODALIDADCOMPRA As String = ""
        Dim IDTIPOINFORME As Integer = 0
        Dim LOTE As String = ""
        Dim NOMBREMEDICAMENTO As String = ""
        Dim RESULTADO As Integer = 0

        Dim mL As New cINFORMEMUESTRAS

        If Me.CheckBox1.Checked Then ORIGEN = Me.RadioButtonList1.SelectedValue
        If Me.CheckBox2.Checked Then TIPOPRODUCTO = Me.DropDownList1.SelectedValue
        If Me.CheckBox3.Checked Then IDPROVEEDOR = Me.DropDownList2.SelectedValue
        If Me.CheckBox4.Checked Then IDCONTRATO = Me.DropDownList3.SelectedItem.Text
        If Me.CheckBox5.Checked Then NUMEROMODALIDADCOMPRA = Me.DropDownList4.SelectedItem.Text
        If Me.CheckBox8.Checked Then IDTIPOINFORME = Me.DropDownList6.SelectedValue
        If Me.CheckBox9.Checked Then LOTE = Me.DropDownList7.SelectedItem.Text
        If Me.CheckBox6.Checked Then NOMBREMEDICAMENTO = Me.DropDownList5.SelectedItem.Text
        If Me.CheckBox7.Checked Then RESULTADO = Me.RadioButtonList2.SelectedValue

        Dim ds As Data.DataSet
        ds = mL.ConsultaInformes(Session("IdEstablecimiento"), ORIGEN, TIPOPRODUCTO, IDPROVEEDOR, IDCONTRATO, NUMEROMODALIDADCOMPRA, IDTIPOINFORME, LOTE, NOMBREMEDICAMENTO, RESULTADO)
        Me.GridView1.DataSource = ds

        Try
            Me.GridView1.DataBind()
        Catch ex As Exception
            Me.GridView1.PageIndex = 0
            Me.GridView1.DataBind()
        End Try

    End Sub

End Class
