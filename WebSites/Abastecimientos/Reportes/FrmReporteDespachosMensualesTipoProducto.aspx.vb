
Partial Class FrmReporteDespachosMensualesTipoProducto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucFiltrosReportesAlmacen1.VerDocumento = ""

            Me.ucFiltrosReportesAlmacen1.VerAnio = True
            Me.ucFiltrosReportesAlmacen1.VerEstablecimiento = True
            Me.ucFiltrosReportesAlmacen1.EstablecimientoRequerido = True
            Me.ucFiltrosReportesAlmacen1.VerTipoSuministro = True
            Me.ucFiltrosReportesAlmacen1.VerGrupo = True
            ucFiltrosReportesAlmacen1.IniciarDatos()
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        With ucFiltrosReportesAlmacen1
            Dim cad = String.Format("/Reportes/frmRptDespachoXTipoProducto.aspx?idA={0}&A={1}&idS={2}&idG={3}&idED={4}", Session("IdAlmacen"), .ANIO, .IDSUMINISTRO, .IDGRUPO, .IDESTABLECIMIENTO)
            SINAB_Utils.Utils.MostrarVentana(cad)
        End With
    End Sub

End Class
