
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases

Partial Class FrmSeleccioneProcesoCompraReporte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
        End If

        If Request.QueryString.HasKeys Then
            Dim id As String
            id = Request.QueryString("id")
            CargarDatos(id)
        End If

    End Sub

    Private Sub CargarDatos(ByVal identificador As String)
        Dim establecimiento = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
        With Me.UcVistaDetalleProcesoCompra1

        Select Case identificador

            Case "OfertaEconomica"
                Me.lblRuta.Text += "Oferta económica"
                Dim estados As Integer() = {eESTADOPROCESOSCOMPRAS.COMISIONDEALTONIVELINGRESADA, _
                eESTADOPROCESOSCOMPRAS.COMISIONDEEVALUACIONINGRESADA, _
                eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS, _
                eESTADOPROCESOSCOMPRAS.CONTRATOSDISTRIBUIDOS, _
                eESTADOPROCESOSCOMPRAS.DISTRIBUIRCONTRATOS, _
                eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION, _
                eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINAR, _
                eESTADOPROCESOSCOMPRAS.EXAMENPRELIMINARFINALIZADO, _
                eESTADOPROCESOSCOMPRAS.GENERARCONTRATOS, _
                eESTADOPROCESOSCOMPRAS.GENERARRECOMENDACIONDECOMPRA, _
                eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION, _
                eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA, _
                eESTADOPROCESOSCOMPRAS.INCUMPLIRRECEPCIONES}
                ._OPCIONPOPUP = 1
                .ESTADOS = estados
                    ._IDESTABLECIMIENTO = establecimiento
                .PaginaReporte = "UACI/FrmReporteOfertaEconomica.aspx"
                .Consultar()

            Case "RetiroBases"
                Me.lblRuta.Text += "Retiro de bases"
                    ._IDESTABLECIMIENTO = establecimiento
                .PaginaReporte = "Reportes/FrmRptProveedoresRetiroBases.aspx"
                .Consultar()

            Case "PresentacionOferta"
                Me.lblRuta.Text = "Presentación de ofertas"
                    ._IDESTABLECIMIENTO = establecimiento
                .PaginaReporte = "Reportes/FrmRptProveedoresEntreganOferta.aspx"
                .Consultar()

            Case "GenerarRecomCompra"
                Me.lblRuta.Text += "Evaluación y recomendación de compra"
                ._OPCIONPOPUP = 2
                    ._IDESTABLECIMIENTO = establecimiento
                Dim estados As Integer() = {eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION, _
                eESTADOPROCESOSCOMPRAS.PROCESODECOMPRAANULADO, _
                eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION, _
                eESTADOPROCESOSCOMPRAS.COMISIONDEALTONIVELINGRESADA, _
                eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA, _
                eESTADOPROCESOSCOMPRAS.GENERARCONTRATOS, _
                eESTADOPROCESOSCOMPRAS.DISTRIBUIRCONTRATOS, _
                eESTADOPROCESOSCOMPRAS.CONTRATOSDISTRIBUIDOS, _
                eESTADOPROCESOSCOMPRAS.INCUMPLIRRECEPCIONES}
                .ESTADOS = estados
                .PaginaReporte = "UACI/FrmVerSolicitudesProcesoCompra.aspx?redirect=FrmGenerarRecomCompra.aspx"
                .Consultar()

            Case "GenerarResolucionAdjudicacion"
                Me.lblRuta.Text += "Generar resolución de adjudicación"
                ._OPCIONPOPUP = 3
                    ._IDESTABLECIMIENTO = establecimiento
                Dim estados As Integer() = {eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION, _
                eESTADOPROCESOSCOMPRAS.COMISIONDEALTONIVELINGRESADA, _
                eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA, _
                eESTADOPROCESOSCOMPRAS.GENERARCONTRATOS, _
                eESTADOPROCESOSCOMPRAS.DISTRIBUIRCONTRATOS, _
                eESTADOPROCESOSCOMPRAS.CONTRATOSDISTRIBUIDOS, _
                eESTADOPROCESOSCOMPRAS.INCUMPLIRRECEPCIONES}
                .ESTADOS = estados
                .PaginaReporte = "~/UACI/FrmEditarPlantillaProcesoCompra.aspx?idProc=#idProc&idTP=" + eTIPOPLANTILLA.ADJUDICACION.ToString("d")
                .Consultar()
        End Select

        End With

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub linkBtnSeguimiento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkBtnSeguimiento.Click
        Response.Redirect("~/UACI/pdf", False)

    End Sub
End Class
