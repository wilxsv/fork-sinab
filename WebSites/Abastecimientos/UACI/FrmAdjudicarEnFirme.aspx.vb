Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmAdjudicarEnFirme
    Inherits System.Web.UI.Page

    Private estados() As Byte = {eESTADOCALIFICACION.RECOMENDADO, eESTADOCALIFICACION.ADJUDICADO, eESTADOCALIFICACION.NOADJUDICADO}

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False
            Me.btnInformeEvaluacionPorOferta.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc"))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"
            Me.btnInformeEvaluacionPorRenglon.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptValorizacionPorRenglon.aspx?id=" + Request.QueryString("idProc"))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValorizacionPorRenglon.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"
            Me.btnAviso.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptAvisoResolucionFirme.aspx?id=" + Request.QueryString("idProc"))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptAvisoResolucionFirme.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return;"

            Dim cPC As New cPROCESOCOMPRAS
            Dim ePC As New PROCESOCOMPRAS
            ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")

            If cPC.ObtenerPROCESOCOMPRAS(ePC) = 1 Then
                If ePC.FECHANOTIFICACION = Nothing Then
                    Me.cvFechaFirmaResolucion.Visible = False
                Else
                    Me.cvFechaFirmaResolucion.ValueToCompare = ePC.FECHANOTIFICACION.ToShortDateString
                End If
            End If

            Me.cvFechaFirmaResolucion1.ValueToCompare = Now.Date

            Dim bUsuarioComision As Boolean

            Dim cCPC As New cCOMISIONPROCESOCOMPRA
            bUsuarioComision = cCPC.ValidarUsuario(HttpContext.Current.User.Identity.Name)

            Dim bRecursos As Boolean
            Dim bNotasAceptacion As Boolean

            Dim cRR As New cRECURSOSREVISION

            If cRR.ObtenerRecursosDeRevision(Session("IdEstablecimiento"), Request.QueryString("idProc")) > 0 Then
                bRecursos = True
                Me.lblRecursosRevisionNotasAceptacion.Text += "Se han registrado recursos de revisión. "
                If bUsuarioComision Then
                    Me.UcRenglonesProcesoCompra1.ObtenerTodos = True
                Else
                    Me.UcRenglonesProcesoCompra1.ObtenerTodos = False
                    Me.UcRenglonesProcesoCompra1.Obtener = False
                End If
            End If

            Dim cNA As New cNOTASACEPTACION

            If cNA.VerificarRecepcionNotasAceptacion(Session("IdEstablecimiento"), Request.QueryString("idProc")) > 0 Then
                bNotasAceptacion = True
                Me.lblRecursosRevisionNotasAceptacion.Text += "Falta al menos una nota de aceptación. "
                If bUsuarioComision Then
                    Me.UcRenglonesProcesoCompra1.ObtenerTodos = True
                Else
                    Me.UcRenglonesProcesoCompra1.ObtenerTodos = False
                    Me.UcRenglonesProcesoCompra1.Obtener = True
                End If
            End If

            If bRecursos Or bNotasAceptacion Then
                Me.lblRecursosRevisionNotasAceptacion.Visible = True
                Me.btnModificarRecomendacion.Visible = True
                Me.btnModificarRecomendacion.Enabled = True
                Me.btnIngresarFechaAdjudicar.Visible = True
                Me.pnRegistrarFecha.Visible = False
                Me.btnInformeEvaluacionPorRenglon.Visible = False
                Me.btnInformeEvaluacionPorOferta.Visible = False
            Else
                If Not bUsuarioComision Then
                    Me.lblRecursosRevisionNotasAceptacion.Visible = False
                    Me.btnModificarRecomendacion.Enabled = False
                    Me.btnIngresarFechaAdjudicar.Visible = True
                    Me.btnModificarRecomendacion.Visible = True
                    Me.pnRegistrarFecha.Visible = False
                    Me.btnInformeEvaluacionPorRenglon.Visible = False
                    Me.btnInformeEvaluacionPorOferta.Visible = False
                Else
                    Me.lblRecursosRevisionNotasAceptacion.Visible = False
                    Me.btnModificarRecomendacion.Enabled = True
                    Me.btnModificarRecomendacion.Visible = False
                    Me.btnIngresarFechaAdjudicar.Visible = False
                    Me.pnRegistrarFecha.Visible = False
                    Me.btnInformeEvaluacionPorRenglon.Visible = False
                    Me.btnInformeEvaluacionPorOferta.Visible = False
                End If
            End If
        End If

    End Sub

    Protected Sub btnAdjudicar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdjudicar.Click
        pnGenerarResolucionAdjudicacion.Visible = False
        pnRegistrarFecha.Visible = True

        Dim cPC As New cPROCESOCOMPRAS
        Dim ePC As New PROCESOCOMPRAS
        ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")
        ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARCONTRATOS
        ePC.FECHAFIRMAACEPTACION = ePC.FECHAFIRMARESOLUCION
        ePC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        ePC.AUFECHAMODIFICACION = Now
        ePC.ESTASINCRONIZADA = 0

        If cPC.ActualizarEstado(ePC, 3, True, True, True) > 0 Then
            Me.MsgBox1.ShowConfirm("Se ha generado la resolución de adjudicación correctamente.  ¿Desea imprimir el documento asociado?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_PostBackOnNo)
        Else
            Me.MsgBox1.ShowAlert("Se produjo un error al intentar generar la resolución de adjudicación.", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

    End Sub

    Protected Sub btnModificarRecomendacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificarRecomendacion.Click
        Me.btnInformeEvaluacionPorOferta.Visible = False
        Me.btnInformeEvaluacionPorRenglon.Visible = False

        Me.pnGenerarResolucionAdjudicacion.Visible = False
        Me.pnRegistrarFecha.Visible = False

        VerRenglonesAdjudicacion()
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub UcAsignarCantidades1_Cancelar() Handles UcAsignarCantidades1.Cancelar

        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.UcRenglonesProcesoCompra1.IDESTADO = estados
        Me.UcRenglonesProcesoCompra1.CargarDatos()

        CargarOfertas()
    End Sub

    Protected Sub UcAsignarCantidades1_Eliminar() Handles UcAsignarCantidades1.Eliminar

        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.UcRenglonesProcesoCompra1.CargarDatos()

        CargarOfertas()
    End Sub

    Protected Sub UcAsignarCantidades1_Guardar() Handles UcAsignarCantidades1.Guardar

        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False
        Me.UcRenglonesProcesoCompra1.CargarDatos()

        CargarOfertas()
    End Sub

    Protected Sub UcOfertasPorRenglonProcesoCompra1_NoAdjudicar() Handles UcOfertasPorRenglonProcesoCompra1.NoAdjudicar
        VerRenglonesAdjudicacion()
    End Sub

    Protected Sub UcOfertasPorRenglonProcesoCompra1_SelectedIndexChanged() Handles UcOfertasPorRenglonProcesoCompra1.SelectedIndexChanged

        If Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA = 0 Then
            Me.UcAsignarCantidades1.LimpiarCantidades()
            Me.UcAsignarCantidades1.Visible = False
        Else
            Me.UcAsignarCantidades1.Visible = True

            Me.UcAsignarCantidades1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            Me.UcAsignarCantidades1.IDPROCESOCOMPRA = Request.QueryString("idProc")
            Me.UcAsignarCantidades1.IDPROVEEDOR = Me.UcOfertasPorRenglonProcesoCompra1.IDPROVEEDOR
            Me.UcAsignarCantidades1.IDDETALLEOFERTA = Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA

            Me.UcAsignarCantidades1.IDPRODUCTO = Me.UcRenglonesProcesoCompra1.IDPRODUCTO
            Me.UcAsignarCantidades1.IDDETALLEPROCESOCOMPRA = Me.UcRenglonesProcesoCompra1.IDDETALLE
            Me.UcAsignarCantidades1.RENGLON = Me.UcRenglonesProcesoCompra1.RENGLON

            Me.UcAsignarCantidades1.PlazoEntrega = Me.UcOfertasPorRenglonProcesoCompra1.PlazoEntrega
            Me.UcAsignarCantidades1.UnidadMedida = Me.UcOfertasPorRenglonProcesoCompra1.UnidadMedida

            Me.UcAsignarCantidades1.CantidadSolicitada = Me.UcRenglonesProcesoCompra1.CantidadSolicitada
            Me.UcAsignarCantidades1.CantidadOferta = Me.UcOfertasPorRenglonProcesoCompra1.CantidadOferta
            Me.UcAsignarCantidades1.CantidadRecomendada = Me.UcOfertasPorRenglonProcesoCompra1.CantidadRecomendada
            Me.UcAsignarCantidades1.CantidadAdjudicada = Me.UcOfertasPorRenglonProcesoCompra1.CantidadAdjudicada
            Me.UcAsignarCantidades1.CantidadAsignadaOfertaSeleccionada = Me.UcOfertasPorRenglonProcesoCompra1.CantidadAdjudicada

            Me.UcAsignarCantidades1.TipoCantidad = 3
            Me.UcAsignarCantidades1.UnidadMedidaB = Me.UcRenglonesProcesoCompra1.UnidadMedida

            Me.UcAsignarCantidades1.Observaciones = Me.UcRenglonesProcesoCompra1.ObtenerObservacionAdjudicacionEnFirme

            Me.UcAsignarCantidades1.CargarDatos()

        End If

        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = True

        Me.UcOfertasPorRenglonProcesoCompra1.CargarDatos()

    End Sub

    Protected Sub UcRenglonesProcesoCompra1_SelectedIndexChanged() Handles UcRenglonesProcesoCompra1.SelectedIndexChanged

        Me.UcRenglonesProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcRenglonesProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcRenglonesProcesoCompra1.IDESTADO = estados
        Me.UcRenglonesProcesoCompra1.CargarDatos()

        If Me.UcRenglonesProcesoCompra1.RENGLON = 0 Then
            Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
            Me.UcOfertasPorRenglonProcesoCompra1.Visible = False

            Me.UcAsignarCantidades1.LimpiarCantidades()
            Me.UcAsignarCantidades1.Visible = False
        Else
            CargarOfertas()
        End If

    End Sub

    Private Sub VerRenglonesAdjudicacion()

        pnGenerarResolucionAdjudicacion.Visible = True
        pnRegistrarFecha.Visible = False

        Me.UcRenglonesProcesoCompra1.Visible = True
        Me.UcRenglonesProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcRenglonesProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcRenglonesProcesoCompra1.RENGLON = 0
        Me.UcRenglonesProcesoCompra1.IDESTADO = estados
        Me.UcRenglonesProcesoCompra1.LimpiarRenglones()
        Me.UcRenglonesProcesoCompra1.CargarDatos()

        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.Visible = False

        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False
    End Sub

    Private Sub CargarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = True
        Me.UcOfertasPorRenglonProcesoCompra1.Visible = True
        Me.UcOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcOfertasPorRenglonProcesoCompra1.IDPRODUCTO = Me.UcRenglonesProcesoCompra1.IDPRODUCTO
        Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEPROCESOCOMPRA = Me.UcRenglonesProcesoCompra1.IDDETALLE
        Me.UcOfertasPorRenglonProcesoCompra1.TipoCantidad = 3
        Me.UcOfertasPorRenglonProcesoCompra1.RENGLON = Me.UcRenglonesProcesoCompra1.RENGLON
        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.CargarDatos()
    End Sub

    Protected Sub btnIngresarFechaAdjudicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresarFechaAdjudicar.Click
        Me.btnInformeEvaluacionPorOferta.Visible = True
        Me.btnInformeEvaluacionPorRenglon.Visible = True

        Me.pnGenerarResolucionAdjudicacion.Visible = False
        Me.pnRegistrarFecha.Visible = True
    End Sub

    Protected Sub MsgBox1_NoChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.NoChosen
        If e.Key = "A" Then
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "A" Then
            Response.Redirect("~/UACI/FrmEditarPlantillaProcesoCompra.aspx?idProc=" + Request.QueryString("idProc") + "&idTP=" + eTIPOPLANTILLA.ADJUDICACIONFIRME.ToString("d"))
        End If
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
