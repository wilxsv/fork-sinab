Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers
Imports System.Collections.Generic
Imports SINAB_Entidades.Tipos
Imports System.Linq

Partial Class FrmReporteCuadroDistribucion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            CargarDatos()
        End If

    End Sub

    Private Sub CargarDatos()

        'Dim cPD As New cPROGRAMADISTRIBUCION
        'Dim ds As Data.DataSet
        'ds =  cPD.ObtenerProcesosCompra(, Membresia.ObtenerUsuario().ALMACEN.IDALMACEN)

        Me.gvProcesosCompra.DataSource = UACIHelpers.ProcesoCompras.ObtenerTodosFrm()

        Try
            Me.gvProcesosCompra.DataBind()
        Catch ex As Exception
            Me.gvProcesosCompra.PageIndex = 0
            Me.gvProcesosCompra.DataBind()
        End Try

    End Sub

    Protected Sub gvProcesosCompra_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProcesosCompra.PageIndexChanging
        Me.gvProcesosCompra.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    

    Protected Sub gvProcesosCompra_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProcesosCompra.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lb As LinkButton = CType(e.Row.FindControl("lbVer"), LinkButton)
            Dim idEstablecimiento = gvProcesosCompra.DataKeys(e.Row.RowIndex).Item("IDESTABLECIMIENTO")
            dim idProcesoCompra = gvProcesosCompra.DataKeys(e.Row.RowIndex).Item("IdProcesoCompra")
            Dim cad1 = String.Format("/Reportes/FrmRptCuadroDistribucion.aspx?idE={0}&idPC={1}&idA={2}", idEstablecimiento, idProcesoCompra, Membresia.ObtenerUsuario().Almacen.IDALMACEN)
            lb.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad1)
        End If
    End Sub

End Class
