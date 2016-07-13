Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class frmReportes
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
    Private _flag As Integer
    Public Property flag() As Integer
        Get
            Return Me._flag
        End Get
        Set(ByVal value As Integer)
            Me._flag = value
            If Not Me.ViewState("flag") Is Nothing Then Me.ViewState.Remove("flag")
            Me.ViewState.Add("flag", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            'cargarDatos()
            P1.Visible = True
            Me.RadioButtonList1.SelectedValue = 0
        Else
            If Not Me.ViewState("id") Is Nothing Then Me.ide = Me.ViewState("id")
            If Not Me.ViewState("flag") Is Nothing Then Me.flag = Me.ViewState("flag")
        End If
    End Sub
    'Public Sub cargarDatos()
    '    Dim cx As New cRegistroProveedores
    '    Me.GridView1.DataSource = cx.ObtenerCausas()
    '    Me.GridView1.DataBind()

    'End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        flag = 0
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        ide = Me.GridView2a.DataKeys(row.RowIndex).Values(0).ToString

        Me.mdlPopup.Show()
    End Sub
    Protected Sub BtnSave2_Click(ByVal sender As Object, ByVal e As EventArgs)
        flag = 1
        Dim btnDetails As Button = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        ide = Me.GridView2a.DataKeys(row.RowIndex).Values(0).ToString
        Me.mdlPopup.Show()
    End Sub
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)
        'boton cancelar del agregar/editar
        Me.mdlPopup.Hide()

    End Sub


    'Protected Sub BtnClose2_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    'boton cancelar del eliminar
    '    ide = 0
    '    Me.Modalpopupextender1.Hide()

    'End Sub

    'Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim btnDetails As ImageButton = sender
    '    Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

    '    Dim cx As New cRegistroProveedores
    '    Dim ds As New Data.DataSet
    '    ds = cx.ObtenerDataSetPorID2CAUSAS(Me.GridView1.DataKeys(row.RowIndex).Values(0).ToString)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Me.Label1.Text = ds.Tables(0).Rows(0).Item(0)
    '        ide = ds.Tables(0).Rows(0).Item(0)
    '        Me.TextBox1.Text = ds.Tables(0).Rows(0).Item(1)
    '        Me.mdlPopup.Show()
    '    End If

    '    'Me.updPnlCustomerDetail.Update()

    'End Sub

    'Protected Sub BtnViewDetails2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim btnDetails As ImageButton = sender
    '    Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

    '    ide = Me.GridView1.DataKeys(row.RowIndex).Values(0)

    '    Me.Modalpopupextender1.Show()
    'End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim c As New cRegistroProveedores
        Dim ds As New Data.DataSet

        Select Case Me.RadioButtonList2.SelectedValue
            Case Is = 0
                If Me.TextBox4.Text <> "" Then
                    ds = c.ObtenerProveedoresFiltrados(Me.TextBox4.Text.ToString, "")
                Else
                    ds = c.ObtenerProveedoresFiltrados("", "")
                End If

            Case Is = 1
                If Me.TextBox4.Text <> "" Then
                    ds = c.ObtenerProveedoresFiltrados("", Me.TextBox4.Text.ToString)
                Else
                    ds = c.ObtenerProveedoresFiltrados("", "")
                End If

        End Select

        Me.GridView2a.DataSource = ds
        Me.GridView2a.DataBind()

        Me.Panel2.Visible = True
    End Sub

    'Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.RadioButtonList1.SelectedValue = 0 Then
    '        Me.pnlPopup.Visible = True
    '    Else
    '        Me.pnlPopup.Visible = False
    '    End If
    'End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.RadioButtonList1.SelectedValue = 0 Then
            Me.TextBox4.MaxLength = 14
        Else
            Me.TextBox4.MaxLength = 200
        End If
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Reporte As ReportDocument
        Reporte = New ReportDocument

        Select Case flag
            Case Is = 0
                Dim reportPath As String = Server.MapPath("Reporte1.rpt")
                Reporte.Load(reportPath)
            Case Is = 1
                Dim reportPath As String = Server.MapPath("Reporte3.rpt")
                Reporte.Load(reportPath)
            Case Is = 2
                Dim reportPath As String = Server.MapPath("Reporte2.rpt")
                Reporte.Load(reportPath)
        End Select


        Dim cEntidad As New cRegistroProveedores
        Dim ds As Data.DataSet
        Select Case flag
            Case Is = 2
                ds = cEntidad.ObtenerReporte1y3(0, IIf(Me.RadioButtonList3.SelectedValue = 0, Me.TextBox1.Text, Me.DropDownList1.SelectedValue))
                Reporte.SetDataSource(ds.Tables(0))
            Case Is = 0
                ds = cEntidad.ObtenerReporte1y3(ide, "-")
                Reporte.SetDataSource(ds.Tables(0))
            Case Is = 1
                ds = cEntidad.ObtenerReporte2(ide)
                Reporte.SetDataSource(ds.Tables(0))
                Reporte.Subreports.Item(0).SetDataSource(ds.Tables(1))
                Reporte.Subreports.Item(1).SetDataSource(ds.Tables(2))
                Reporte.Subreports.Item(2).SetDataSource(ds.Tables(3))
                Reporte.Subreports.Item(3).SetDataSource(ds.Tables(4))
        End Select

        

        Select Case Me.DropDownList99.SelectedValue
            Case Is = 0
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Reporte")
            Case Is = 1
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, True, "Reporte")
            Case Is = 2
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, True, "Reporte")
        End Select

        Me.mdlPopup.Hide()

    End Sub

    Protected Sub RadioButtonList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList3.SelectedIndexChanged
        If Me.RadioButtonList3.SelectedValue = 0 Then
            Me.Label2.Visible = True
            Me.TextBox1.Visible = True
            Me.Label3.Visible = False
            Me.DropDownList1.Visible = False
        Else
            Me.Label2.Visible = False
            Me.TextBox1.Visible = False
            Me.Label3.Visible = True
            Me.DropDownList1.Visible = True
            Dim c As New cSUMINISTROS
            Me.DropDownList1.DataSource = c.obtenerSuministroOrdenado
            Me.DropDownList1.DataTextField = "descripcion"
            Me.DropDownList1.DataValueField = "idsuministro"
            Me.DropDownList1.DataBind()
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        flag = 2
        Me.mdlPopup.Show()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.SelectedValue = 0 Then
            P1.Visible = True
            P2.Visible = False
        Else
            P1.Visible = False
            P2.Visible = True
        End If
    End Sub
End Class
