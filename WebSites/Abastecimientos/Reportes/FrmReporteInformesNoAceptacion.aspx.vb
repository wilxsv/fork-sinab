Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Collections.Generic
Imports System.Linq
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Tipos
Imports SINAB_Utils

Partial Class FrmReporteInformesNoAceptacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False
            With ucFiltrosReportesAlmacen1
                .VerDocumento = "Número de informe de no aceptación"
                .VerFechaDesde = True
                .VerFechaHasta = True
                .FechasRequeridas = True
                .VerFuenteFinanciamiento = False
                .VerResponsableDistribucion = False
                .VerProveedor = True
                .VerEstadoDocumento = False

                If Membresia.EsUsuarioRol("AdministracionAlmacenes") Then
                    .VerEstablecimientoTodos = True
                    .VerAlmacen = True
                End If
                .IniciarDatos()
            End With

           CargarDatos()

        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        'Dim cINA As New cINFORMESNOACEPTACION
        'Dim dsf As Data.DataSet
        'dsf = cINA.ObtenerListaInformesNoAceptacion(Membresia.ObtenerUsuario().Almacen.IDALMACEN, ucFiltrosReportesAlmacen1.IDPROVEEDOR, ucFiltrosReportesAlmacen1.FECHADESDE, ucFiltrosReportesAlmacen1.FECHAHASTA, ucFiltrosReportesAlmacen1.IDFUENTEFINANCIAMIENTO, ucFiltrosReportesAlmacen1.IDRESPONSABLEDISTRIBUCION, eESTADOSMOVIMIENTOS.Cerrado, ucFiltrosReportesAlmacen1.Documento)
        Dim ds As New List(Of BaseInformeNoAceptacion)
        With ucFiltrosReportesAlmacen1
            If Membresia.EsUsuarioRol("AdministracionAlmacenes") Then
                ds = AlmacenHelpers.InformeNoAceptacion.ObtenerTodos(.IDALMACEN, .IDESTABLECIMIENTO2, .IDPROVEEDOR, CType(.FECHADESDE, Date), CType(.FECHAHASTA, Date), .IDFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION, eESTADOSMOVIMIENTOS.Cerrado, CType(.Documento, Integer))
            Else
                ds = AlmacenHelpers.InformeNoAceptacion.ObtenerTodos(Membresia.ObtenerUsuario().Almacen.IDALMACEN, 0, .IDPROVEEDOR, CType(.FECHADESDE, Date), CType(.FECHAHASTA, Date), .IDFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION, eESTADOSMOVIMIENTOS.Cerrado, CType(.Documento, Integer))
            End If
        End With


        Try
            gvLista.DataSource = ds
            gvLista.DataBind()
            gvLista.Visible = True
        Catch ex As Exception
            MessageBox.Alert("Error en la carga de datos. Información:" + ex.Message)
        End Try



    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lb As LinkButton = CType(e.Row.FindControl("lbVer"), LinkButton)

            Dim s As New StringBuilder
            Dim idEMov = gvLista.DataKeys(e.Row.RowIndex).Item("IdEstablecimientoMovimiento")
            Dim idMov = gvLista.DataKeys(e.Row.RowIndex).Item("IdMovimiento")
            Dim idE = gvLista.DataKeys(e.Row.RowIndex).Item("IdEstablecimiento")
            Dim idP = gvLista.DataKeys(e.Row.RowIndex).Item("IdProveedor")
            Dim idC = gvLista.DataKeys(e.Row.RowIndex).Item("IdContrato")
            dim cad = string.format("/Reportes/FrmRptInformeNoAceptacion.aspx?IdEMov={0}&IdMov={1}&IdE={2}&IdP={3}&IdC={4}", idEMov, idMov, idE, idP, idC)
          
            lb.OnClientClick = Utils.ReferirVentana(cad)

        End If

    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_SelectedIndexChanged() Handles ucFiltrosReportesAlmacen1.SelectedIndexChanged
        Me.gvLista.Visible = False
    End Sub


End Class
