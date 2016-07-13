
Imports SINAB_Entidades.Helpers

Partial Class FrmVerSolicitudesProcesoCompra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.ucVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
            Me.ucVistaDetalleSolicProcesCompra1.BtnEliminaProcesoEnabled = False
            Me.ucVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False

            Dim allKeys As Integer = Request.QueryString.AllKeys.Length - 1
            Dim key, value As String

            For i As Integer = 0 To allKeys
                key = Request.QueryString.GetKey(i)
                value = Request.QueryString(i)

                If key = "redirect" Then
                    Select Case value
                        Case "FrmCapturarDetalleOfertas.aspx"
                            Me.lblRuta.Text += "Captura de Ofertas"
                        Case "FrmComisionEvaluacion.aspx"
                            Me.lblRuta.Text += "Comisión de evaluación"
                        Case "FrmComisionEvaluacionAltoNivel.aspx"
                            Me.lblRuta.Text += "Comisión de alto nivel"
                        Case "FrmGenerarValorizacion.aspx"
                            Me.lblRuta.Text += "Generar valorización"
                        Case "FrmGenerarRecomCompra.aspx"
                            Me.lblRuta.Text += "Evaluación y recomendación de compra"
                        Case "FrmGenerarResolucionAdjudicacion.aspx"
                            Me.lblRuta.Text += "Generar resolución de adjudicación"
                        Case "FrmAdjudicarEnFirme.aspx"
                            Me.lblRuta.Text += "Adjudicación en firme y resolución modificativa"
                        Case "FrmGenerarBasesPlantilla.aspx"
                            Me.lblRuta.Text += "Generar bases"
                    End Select
                End If

                If i > 0 Then
                    If i = 1 Then
                        value = "?" + key + "=" + value
                    Else
                        value = "&" + key + "=" + value
                    End If
                End If

                Me.ucVistaDetalleSolicProcesCompra1.Redirect += value
            Next

            Me.ucVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = CType(Request.QueryString("idProc"), Integer)
            Me.ucVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
            Me.ucVistaDetalleSolicProcesCompra1.Consultar()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinuar.Click
        Response.Redirect(Me.ucVistaDetalleSolicProcesCompra1.Redirect, False)
    End Sub

    Protected Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        SINAB_Utils.Utils.MostrarVentana("/Reportes/frmRptConsolidadoDistribucionDetalle.aspx?id="+Request.QueryString("idProc"))
    End Sub
End Class
