Imports System.Text
Imports SharpPieces.Web.Controls

Partial Class GERENCIA_frmReporteAbastecimiento
    Inherits System.Web.UI.Page

    Dim porcentaje1 As Decimal = 0
    Dim porcentaje2 As Decimal = 0
    Dim contador As Integer = 0

    Dim mesesSP() As String = {"Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"}

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Master.ControlMenu.Visible = False 'ocultar menu
        'JScript, CSS

        If Not Page.IsPostBack Then

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirCancelar = False

            For i As Integer = 2007 To Now.Year
                Me.cboAnio.Items.Add(i)
            Next

            Me.cboAnio.SelectedIndex = Me.cboAnio.Items.Count - 1

        End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cCONSUMOS
        Dim tipo As Integer = IIf(Me.rd1.Checked = True, 0, 1)

        Dim f1 As Date = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex + 1, 1)

        Me.lblFecha.Text = Me.cboMes.SelectedItem.Value & "/" & Me.cboAnio.SelectedItem.Value
        Me.lblTipo.Text = IIf(Me.rd1.Checked = True, "Nivel de Abastecimiento", "Nivel de Desabastecimiento")

        If tipo = 1 Then
            Me.gvLista.Columns(1).Visible = True
            Me.gvLista.Columns(2).Visible = False
            Me.gvLista2.Columns(1).Visible = True
            Me.gvLista2.Columns(2).Visible = False
        Else
            Me.gvLista.Columns(1).Visible = False
            Me.gvLista.Columns(2).Visible = True
            Me.gvLista2.Columns(1).Visible = False
            Me.gvLista2.Columns(2).Visible = True
        End If

        porcentaje1 = 0
        porcentaje2 = 0
        contador = 0

        Me.gvLista.DataSource = cEntidad.obtenerDesabastecimientoHospitalFecha(f1, tipo)
        Me.gvLista.DataBind()

        porcentaje1 = 0
        porcentaje2 = 0
        contador = 0

        Me.gvLista2.DataSource = cEntidad.obtenerDesabastecimientoRegionFecha(f1, tipo)
        Me.gvLista2.DataBind()

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'evento al presionar link menu
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' add the UnitPrice and QuantityTotal to the running total variables
            porcentaje1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "porcentaje"))
            porcentaje2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "abastecimiento"))
            contador += 1
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Text = "Promedio:"
            ' for the Footer, display the running totals
            e.Row.Cells(1).Text = CStr(Math.Round(porcentaje1 / contador, 2))
            e.Row.Cells(2).Text = CStr(Math.Round(porcentaje2 / contador, 2))

            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Left
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Font.Bold = True
        End If


    End Sub

    Protected Sub gvLista2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista2.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' add the UnitPrice and QuantityTotal to the running total variables
            porcentaje1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "porcentaje"))
            porcentaje2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "abastecimiento"))
            contador += 1
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Text = "Promedio:"
            ' for the Footer, display the running totals
            e.Row.Cells(1).Text = CStr(Math.Round(porcentaje1 / contador, 2))
            e.Row.Cells(2).Text = CStr(Math.Round(porcentaje2 / contador, 2))

            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Left
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Font.Bold = True
        End If

    End Sub
End Class
