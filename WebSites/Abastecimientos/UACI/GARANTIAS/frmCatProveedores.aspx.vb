Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class frmCatProveedores
    Inherits System.Web.UI.Page
    Private _id As Integer
    Public Property ide() As Integer
        Get
            Return Me._id
        End Get
        Set(ByVal value As Integer)
            Me._id = value
            If Not Me.ViewState("id") Is Nothing Then Me.ViewState.Remove("id")
            Me.ViewState.Add("id", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            cargarDatos()
        Else
            If Not Me.ViewState("id") Is Nothing Then Me.ide = Me.ViewState("id")
        End If
    End Sub
    Public Sub cargarDatos()
        Dim cx As New cPROVEEDORESCG
        Me.GridView1.DataSource = cx.ObtenerDataSetPorId(Session("IdEstablecimiento"))
        Me.GridView1.DataBind()
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' aqui es el boton OK del agregar/editar

        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Then
            'Exit Sub
            Me.lblError.Text = "Existe información pendiente de completar."
            Me.mdlPopup.Show()
        Else
            Dim cx As New cPROVEEDORESCG
            'buscar si el NIT existe
            If Me.TextBox1.Enabled = True Then
                If cx.ObtenerDataSetPorNIT(Session("IdEstablecimiento"), Me.TextBox1.Text) > 0 Then
                    ' ya existe
                    Me.lblError.Text = "Este número de NIT ya se encuentra registrado."
                    Me.mdlPopup.Show()
                    'Exit Sub
                Else
                    Me.lblError.Text = ""
                    Dim x As New PROVEEDORESCG
                    x.IDPROVEEDOR = ide
                    x.NOMBRE = Me.TextBox2.Text
                    x.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    x.NIT = Me.TextBox1.Text
                    x.NOMBREABR = Me.TextBox3.Text.ToString

                    cx.ActualizarPROVEEDORES(x)
                    ide = 0
                    cargarDatos()
                    Me.mdlPopup.Hide()
                End If
            Else
                Me.lblError.Text = ""
                Dim x As New PROVEEDORESCG
                x.IDPROVEEDOR = ide
                x.NOMBRE = Me.TextBox2.Text
                x.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                x.NIT = Me.TextBox1.Text
                x.NOMBREABR = Me.TextBox3.Text.ToString

                cx.ActualizarPROVEEDORES(x)
                ide = 0
                cargarDatos()
                Me.mdlPopup.Hide()
            End If
        End If

    End Sub
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)
        'boton cancelar del agregar/editar
        Me.mdlPopup.Hide()

    End Sub



    Protected Sub BtnSave2_Click(ByVal sender As Object, ByVal e As EventArgs)


        Dim cx As New cPROVEEDORESCG
        cx.EliminarPROVEEDORES(ide, Session("IdEstablecimiento"))
        ide = 0
        cargarDatos()
        ' aqui es el boton OK del eliminar
        Me.Modalpopupextender1.Hide()

    End Sub
    Protected Sub BtnClose2_Click(ByVal sender As Object, ByVal e As EventArgs)
        'boton cancelar del eliminar
        ide = 0
        Me.Modalpopupextender1.Hide()

    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim cx As New cPROVEEDORESCG
        Dim ds As New Data.DataSet
        ds = cx.ObtenerDataSetPorId2(Me.GridView1.DataKeys(row.RowIndex).Values(0).ToString, Me.GridView1.DataKeys(row.RowIndex).Values(1).ToString)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.Label1.Text = ds.Tables(0).Rows(0).Item(0)
            ide = ds.Tables(0).Rows(0).Item(0)
            Me.TextBox1.Text = ds.Tables(0).Rows(0).Item(2)
            Me.TextBox1.Enabled = False
            Me.TextBox2.Text = ds.Tables(0).Rows(0).Item(3)
            Me.TextBox3.Text = ds.Tables(0).Rows(0).Item(4)

            Me.mdlPopup.Show()
        End If

        'Me.updPnlCustomerDetail.Update()

    End Sub

    Protected Sub BtnViewDetails2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim btnDetails As ImageButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        ide = Me.GridView1.DataKeys(row.RowIndex).Values(0)

        Me.Modalpopupextender1.Show()
    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.updPnlCustomerDetail.Update()

        Dim cx As New cPROVEEDORESCG

        Me.Label1.Text = cx.ObtenerID2(Session("IdEstablecimiento"))
        ide = 0
        Me.TextBox1.Text = ""
        Me.TextBox1.Enabled = True
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""
        Me.mdlPopup.Show()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Modalpopupextender2.Show()
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Reporte As ReportDocument
        Reporte = New ReportDocument
       
        Dim reportPath As String = Server.MapPath("rptProveedores.rpt")
        Reporte.Load(reportPath)
       
        Dim cEntidad As New cPROVEEDORESCG
        Dim ds As Data.DataSet
        ds = cEntidad.ObtenerDataSetPorId(Session("IdEstablecimiento"))
        Reporte.SetDataSource(ds.Tables(0))


        Select Case Me.DropDownList99.SelectedValue
            Case Is = 0
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Proveedores")
            Case Is = 1
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, True, "Proveedores")
            Case Is = 2
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, True, "Proveedores")
        End Select


        Me.Modalpopupextender2.Hide()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Modalpopupextender2.Hide()
    End Sub
End Class
