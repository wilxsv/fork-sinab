Imports ABASTECIMIENTOS.NEGOCIO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class ALMACEN_FrmBusquedaUbicaciones
    Inherits System.Web.UI.Page

    Private cCP As New cCATALOGOPRODUCTOS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Me.ddlSUMINISTROS1.Recuperar()
            Me.Master.ControlMenu.Visible = False
        End If
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Me.TextBox2.Text = "" And Me.TextBox2.Enabled = True Then
            Me.Label1.Text = "Escriba un código para la búsqueda."
            Exit Sub
        Else
            Me.Label1.Text = ""
        End If

        
        'If Me.ddlSUMINISTROS1.SelectedIndex = -1 Then
        '    Me.Label1.Text = "Seleccione una clase de suministro."
        '    Exit Sub
        'End If


        Me.Label2.Text = cCP.DevolverNombreProducto(cCP.DevolverIDProducto(Me.TextBox2.Text))

        Dim cUP As New cUBICACIONESPRODUCTOS
        Dim ds As Data.DataSet
        ds = cUP.ObtenerUbicacionesProductosAlmacen(Session("IdAlmacen"), cCP.DevolverIDProducto(Me.TextBox2.Text))
        'ds = cCP.ObtenerCatalogoProductosCompletoOficial(Me.ddlSUMINISTROS1.SelectedValue, Me.TextBox2.Text)

        Me.gvProductos.DataSource = ds
        Me.gvProductos.DataBind()
        Me.gvProductos.Visible = True
        'Me.gvProductos.SelectedIndex = -1

        Me.Panel5.Visible = True


    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
     
        Dim Reporte As ReportDocument
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("..\Reportes\RptUbicacionProductos.rpt")
        Reporte.Load(reportPath)

        Dim cp As New cCATALOGOPRODUCTOS

        Dim paramField As New ParameterField()
        Dim discreteVal As New ParameterDiscreteValue()

        paramField = New ParameterField()
        paramField.ParameterFieldName = "producto"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Me.TextBox2.Text & " - " & cp.DevolverNombreProducto(cp.DevolverIDProducto(Me.TextBox2.Text))
        paramField.CurrentValues.Add(discreteVal)


        Dim cL As New cUBICACIONESPRODUCTOS
        Dim ds As Data.DataSet
        ds = cL.ObtenerUbicacionesProductosAlmacen(Session("IdAlmacen"), cp.DevolverIDProducto(Me.TextBox2.Text))

        Reporte.SetDataSource(ds.Tables(0))
        Reporte.SetParameterValue(0, discreteVal)
        Reporte.SetParameterValue(1, Session("NombreAlmacen"))

        Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Ubicacion")


    End Sub
End Class
