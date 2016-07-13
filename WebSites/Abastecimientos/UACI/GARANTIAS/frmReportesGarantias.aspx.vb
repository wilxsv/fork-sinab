Imports ABASTECIMIENTOS.NEGOCIO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class UACI_GARANTIAS_frmReportesGarantias
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
    Private _idt As Integer
    Public Property idtg() As Integer
        Get
            Return Me._idt
        End Get
        Set(ByVal value As Integer)
            Me._idt = value
            If Not Me.ViewState("idt") Is Nothing Then Me.ViewState.Remove("idt")
            Me.ViewState.Add("idt", value)
        End Set
    End Property
    Private _c As Integer
    Public Property c() As Integer
        Get
            Return Me._c
        End Get
        Set(ByVal value As Integer)
            Me._c = value
            If Not Me.ViewState("c") Is Nothing Then Me.ViewState.Remove("c")
            Me.ViewState.Add("c", value)
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim p As New cPROVEEDORESCG

            Me.DropDownList1.DataSource = p.ObtenerDataSetPorId(Session("IdEstablecimiento"))
            Me.DropDownList1.DataValueField = "IDPROVEEDOR"
            Me.DropDownList1.DataTextField = "NOMBRE"
            Me.DropDownList1.DataBind()
            Dim L As New ListItem
            L.Text = "(Todos)"
            L.Value = 0
            L.Selected = True
            Me.DropDownList1.Items.Insert(0, L)

            Dim g As New cREGISTROGARANTIAS
            Me.DropDownList2.DataSource = g.ObtenerGarantias
            Me.DropDownList2.DataValueField = "IDTIPOGARANTIA"
            Me.DropDownList2.DataTextField = "NOMBRE"
            Me.DropDownList2.DataBind()

            Dim t As New ListItem
            t.Text = "(Todos)"
            t.Value = 0
            t.Selected = True
            Me.DropDownList2.Items.Insert(0, t)

            Dim m As New cMODALIDADCOMPRACG
            Me.DropDownList3.DataSource = m.ObtenerDataSetPorId()
            Me.DropDownList3.DataValueField = "IDMODALIDADCOMPRA"
            Me.DropDownList3.DataTextField = "NOMBRE"
            Me.DropDownList3.DataBind()

            Dim H As New ListItem
            H.Text = "(Todos)"
            H.Value = 0
            H.Selected = True
            Me.DropDownList3.Items.Insert(0, H)
        Else
            If Not Me.ViewState("id") Is Nothing Then Me.ide = Me.ViewState("id")
            If Not Me.ViewState("idt") Is Nothing Then Me.idtg = Me.ViewState("idt")
            If Not Me.ViewState("c") Is Nothing Then Me.c = Me.ViewState("c")
        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.RadioButtonList1.SelectedValue = 0 Then
            Me.DropDownList1.Visible = True
            Me.DropDownList1.SelectedIndex = -1
            Me.TextBox1.Visible = False
        Else
            Me.DropDownList1.Visible = False
            Me.TextBox1.Visible = True
            Me.TextBox1.Text = ""
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim idproveedor As Integer
        Dim nit As String
        Dim idtipogarantia As Integer
        Dim ee, eeg, idmodalidad As Integer

        If Me.RadioButtonList1.SelectedValue = 0 Then
            idproveedor = Me.DropDownList1.SelectedValue
            nit = ""
        Else
            nit = Me.TextBox1.Text.ToString
            idproveedor = 0
        End If

        idtipogarantia = Me.DropDownList2.SelectedValue
        idmodalidad = Me.DropDownList3.SelectedValue
        Dim fechaprox As DateTime
        If Me.RadioButtonList2.SelectedValue = 3 Then
            If Me.TextBox3.Text = "" Then
                Exit Sub
            Else
                fechaprox = CDate(Me.TextBox3.Text & " 12:00:00 AM")
            End If
            ee = Me.RadioButtonList2.SelectedValue
        Else
            fechaprox = DateTime.Now
            ee = Me.RadioButtonList2.SelectedValue
        End If
        eeg = Me.RadioButtonList3.SelectedValue

        Dim x As New cREGISTROGARANTIAS
        Dim ds As New Data.DataSet
        ds = x.ObtenerReporte(fechaprox, idproveedor, nit, ee, eeg, idtipogarantia, idmodalidad)
        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()

        If Me.GridView1.Rows.Count > 0 Then
            Me.Button2.Visible = True
        Else
            Me.Button2.Visible = False
        End If

    End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.RadioButtonList2.SelectedValue = 3 Then
            Me.TextBox3.Visible = True
            Me.TextBox3.Text = ""
            Me.Label1.Visible = True
        Else
            Me.TextBox3.Visible = False
            Me.Label1.Visible = False
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        ide = Me.GridView1.DataKeys(row.RowIndex).Values(0).ToString
        idtg = Me.GridView1.DataKeys(row.RowIndex).Values(1).ToString
        c = 2
        Me.mdlPopup.Show()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        c = 1
        Me.mdlPopup.Show()
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Reporte As ReportDocument
        Select Case c
            Case Is = 1

                Reporte = New ReportDocument
                Dim reportPath As String = Server.MapPath("rptGarantia.rpt")
                Reporte.Load(reportPath)


                'Dim fecha As Date = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex, 1)

                Dim idproveedor As Integer
                Dim nit As String
                Dim idtipogarantia As Integer
                Dim ee, eeg, idmodalidad As Integer

                Dim discreteVal As New ParameterDiscreteValue()

                If Me.RadioButtonList1.SelectedValue = 0 Then
                    idproveedor = Me.DropDownList1.SelectedValue
                    nit = ""
                    discreteVal = New ParameterDiscreteValue()
                    discreteVal.Value = Me.DropDownList1.SelectedItem.Text
                Else
                    nit = Me.TextBox1.Text.ToString
                    idproveedor = 0
                    discreteVal = New ParameterDiscreteValue()
                    discreteVal.Value = nit
                End If

                idtipogarantia = Me.DropDownList2.SelectedValue
                idmodalidad = Me.DropDownList3.SelectedValue
                Dim fechaprox As DateTime
                If Me.RadioButtonList2.SelectedValue = 3 Then
                    If Me.TextBox3.Text = "" Then
                        Exit Sub
                    Else
                        fechaprox = CDate(Me.TextBox3.Text & " 12:00:00 AM")
                    End If
                    ee = Me.RadioButtonList2.SelectedValue
                Else
                    fechaprox = DateTime.Now
                    ee = Me.RadioButtonList2.SelectedValue
                End If
                eeg = Me.RadioButtonList3.SelectedValue

                Dim cEntidad As New cREGISTROGARANTIAS
                Dim ds As Data.DataSet
                ds = cEntidad.ObtenerReporte(fechaprox, idproveedor, nit, ee, eeg, idtipogarantia, idmodalidad)
                Reporte.SetDataSource(ds.Tables(0))

                'Reporte.Subreports.Item(0).SetDataSource(ds.Tables(1))

                Reporte.SetParameterValue(0, discreteVal)
                Reporte.SetParameterValue(1, Me.DropDownList2.SelectedItem.Text)
                Reporte.SetParameterValue(2, Me.DropDownList3.SelectedItem.Text)
                Reporte.SetParameterValue(3, Me.RadioButtonList2.SelectedItem.Text)
                Reporte.SetParameterValue(4, fechaprox)
                Reporte.SetParameterValue(5, Me.RadioButtonList3.SelectedItem.Text)

            Case Is = 2

                Reporte = New ReportDocument
                Select Case idtg
                    Case Is = 1
                        Dim reportPath As String = Server.MapPath("rptGarantia1.rpt")
                        Reporte.Load(reportPath)
                    Case Is = 2
                        Dim reportPath As String = Server.MapPath("rptGarantia2.rpt")
                        Reporte.Load(reportPath)
                    Case Is = 3
                        Dim reportPath As String = Server.MapPath("rptGarantia3.rpt")
                        Reporte.Load(reportPath)
                    Case Is = 4
                        Dim reportPath As String = Server.MapPath("rptGarantia4.rpt")
                        Reporte.Load(reportPath)
                    Case Is = 5
                        Dim reportPath As String = Server.MapPath("rptGarantia5.rpt")
                        Reporte.Load(reportPath)
                End Select

                Dim cEntidad As New cREGISTROGARANTIAS
                Dim ds As Data.DataSet
                ds = cEntidad.ObtenerReporteUnaGarantia(ide, idtg, Session("IdEstablecimiento"))
                Reporte.SetDataSource(ds.Tables(0))

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

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.mdlPopup.Hide()

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class
