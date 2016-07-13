Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class ESTABLECIMIENTOS_frmReporteSSR
    Inherits System.Web.UI.Page
    Private _FARMACIA As Integer

    Public Property FARMACIA() As Integer 'identificador de programacion
        Get
            Return Me._FARMACIA
        End Get
        Set(ByVal Value As Integer)
            Me._FARMACIA = Value
            If Not Me.ViewState("FARMACIA") Is Nothing Then Me.ViewState.Remove("FARMACIA")
            Me.ViewState.Add("FARMACIA", Value)
        End Set
    End Property

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'evento al presionar link menu
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.cboAnio.Items.Add("[Seleccione un año]")

            For i As Integer = 2009 To Now.Year
                Me.cboAnio.Items.Add(i)
            Next

            Me.cboAnio.SelectedIndex = 0

            'Verificamos si el usuario cuenta con mas de un almacen o farmacia
            Dim cEntidad As New cEMPLEADOSALMACEN
            Dim ds As Data.DataSet = cEntidad.ObtenerDsDetalleAlmacenesEmpleados(Session.Item("IdEmpleado"))

            If ds Is Nothing Then
                Response.Redirect("~/frmLogin.aspx")
            End If

            'If ds.Tables(0).Rows.Count = 0 Then
            '    Response.Redirect("~/frmLogin.aspx")
            'End If



            Me.cboAlmacen.Items.Add("[Seleccione un almacén/farmacia]")

            If ds.Tables(0).Rows.Count <> 1 Then
                Dim il As New ListItem("Informe consolidado", 0)
                Me.cboAlmacen.Items.Add(il)
            End If

            Me.cboAlmacen.DataTextField = "nombre"
            Me.cboAlmacen.DataValueField = "idAlmacen"
            Me.cboAlmacen.DataSource = ds
            Me.cboAlmacen.DataBind()

            If ds.Tables(0).Rows.Count < 2 Then

                If ds.Tables(0).Rows.Count = 1 Then
                    FARMACIA = ds.Tables(0).Rows(0).Item("ESFARMACIA")
                Else
                    FARMACIA = -1
                End If

                Me.cboAlmacen.SelectedIndex = 1
                Me.cboAlmacen.Enabled = False
                Me.cboAnio.Enabled = True
                Me.cboMes.Enabled = True
            Else
                Me.btnConsA.Enabled = True
            End If

        Else
            If Not Me.ViewState("FARMACIA") Is Nothing Then FARMACIA = Me.ViewState("FARMACIA")
        End If

    End Sub
    Private fechas() As String = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)


        Dim Reporte As ReportDocument
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("..\Reportes\rptReporteSSR.rpt")
        Reporte.Load(reportPath)

        Dim cp As New cCATALOGOPRODUCTOS


        Dim discreteVal As New ParameterDiscreteValue()
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = fechas(Me.cboMes.SelectedIndex - 1) & "/" & Me.cboAnio.SelectedItem.Text

        Dim fecha As Date = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex, 1)

        Dim cEntidad As New cCONSUMOS
        Dim ds As Data.DataSet
        ds = cEntidad.obtenerReporteSSR(Session.Item("idEstablecimiento"), fecha, "left outer")

        Reporte.SetDataSource(ds.Tables(0))
        Reporte.Subreports.Item(0).SetDataSource(ds.Tables(1))

        Reporte.SetParameterValue(0, discreteVal)
        Reporte.SetParameterValue(1, Session.Item("UsuarioEstablecimiento"))




        Select Case Me.DropDownList1.SelectedValue
            Case Is = 0
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "ReporteSSR")
            Case Is = 1
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, True, "ReporteSSR")
            Case Is = 2
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, True, "ReporteSSR")
        End Select
       

        Me.mdlPopup.Hide()

    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.mdlPopup.Hide()

    End Sub

    Protected Sub btnConsA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsA.Click

        If Me.cboAlmacen.SelectedIndex = 0 Then Exit Sub


        If Me.cboAlmacen.SelectedIndex = 1 Then
            FARMACIA = -1
        Else
            Dim cEntidad As New cALMACENES
            Dim ds As Data.DataSet = cEntidad.FiltroAlmacenPorId(Me.cboAlmacen.SelectedItem.Value)

            If ds Is Nothing Then Exit Sub
            If ds.Tables(0).Rows.Count = 0 Then Exit Sub

            FARMACIA = ds.Tables(0).Rows(0).Item("ESFARMACIA")
        End If

        Me.cboAlmacen.Enabled = False
        Me.btnConsA.Enabled = False
        Me.btnCancA.Enabled = True

        Me.cboAnio.Enabled = True
        Me.cboMes.Enabled = True

    End Sub

    Protected Sub btnCancA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancA.Click

        'Call b2_Click(sender, e)

        Me.cboAlmacen.Enabled = True
        Me.cboAlmacen.SelectedIndex = 0

        Me.btnConsA.Enabled = True
        Me.btnCancA.Enabled = False

        Me.cboAnio.SelectedIndex = 0
        Me.cboMes.SelectedIndex = 0

        Me.cboAnio.Enabled = False
        Me.cboMes.Enabled = False
        'Me.b1.Enabled = False
        'Me.b2.Enabled = False

    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.updPnlCustomerDetail.Update()
        Me.mdlPopup.Show()

    End Sub

   
End Class
