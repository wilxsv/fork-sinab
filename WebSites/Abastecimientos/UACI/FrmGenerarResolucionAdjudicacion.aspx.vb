Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils.MessageBox

Partial Class FrmGenerarResolucionAdjudicacion
    Inherits System.Web.UI.Page

    Private estados() As Byte = {eESTADOCALIFICACION.RECOMENDADO, eESTADOCALIFICACION.ADJUDICADO, eESTADOCALIFICACION.NOADJUDICADO}

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.btnInformeEvaluacionPorOferta.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc"))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"
            Me.btnInformeEvaluacionPorRenglon.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptValorizacionPorRenglon.aspx?id=" + Request.QueryString("idProc"))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValorizacionPorRenglon.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"

            Dim cPC As New cPROCESOCOMPRAS
            Dim ePC As New PROCESOCOMPRAS
            ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")

            If cPC.ObtenerPROCESOCOMPRAS(ePC) = 1 Then
                If ePC.FECHAFINRECOMENDACION = Nothing Then
                    Me.cvFechaFirmaResolucion.Visible = False
                Else
                    Me.cvFechaFirmaResolucion.ValueToCompare = ePC.FECHAFINRECOMENDACION.ToShortDateString
                End If

                Me.ddlEMPLEADOS1.RecuperarTitulares(Session("IdEstablecimiento"))
                If Me.ddlEMPLEADOS1.Items.Count > 0 Then
                    If Not ePC.IDTITULARADJUDICACION = Nothing Then
                        Me.ddlEMPLEADOS1.SelectedValue = ePC.IDTITULARADJUDICACION
                    End If
                End If
            End If

            Me.cvFechaFirmaResolucion1.ValueToCompare = Now.Date
        Else
            If ConfirmTarget = "Imprimir" Then ProcesarImprimir(CType(ConfirmArgument, Boolean))
            If ConfirmTarget = "Generar" Then ProcesarGenerar(CType(ConfirmArgument, Boolean))
        End If

    End Sub

    Private Sub ProcesarGenerar(ByVal argument As Boolean)
        If argument Then

            Dim cPC As New cPROCESOCOMPRAS
            Dim ePC As New PROCESOCOMPRAS
            ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")
            ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION
            ePC.FECHAFIRMARESOLUCION = CType(cpFechaFirmaResolucion.Text, Date) ' Me.cpFechaFirmaResolucion.SelectedDate
            ePC.FECHAFIRMAACEPTACION = ePC.FECHAFIRMARESOLUCION
            ePC.NUMERORESOLUCION = Me.txtNroResolucion.Text
            ePC.IDTITULARADJUDICACION = Me.ddlEMPLEADOS1.SelectedValue
            ePC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            ePC.AUFECHAMODIFICACION = Now
            ePC.ESTASINCRONIZADA = 0

            Dim ds As Data.DataSet
            ds = cPC.obtenerTipoProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"))
            Dim DistribuirCantidadesAlmacen, RegistrarPreciosHistoricos, InhabilitarUsuarioComisionAltoNivel As Boolean

            If ds.Tables(0).Rows(0).Item(0) = 3 Or ds.Tables(0).Rows(0).Item(0) = 4 Then
                DistribuirCantidadesAlmacen = True
                RegistrarPreciosHistoricos = True
                InhabilitarUsuarioComisionAltoNivel = True
                ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION


                'X CADA PROVEEDOR
                Dim mComponente As New cANALISTAPROVEEDORES
                Dim A As New cADJUDICACION
                Dim ds1 As Data.DataSet
                ds1 = A.obtenerDatasetProveedoresAdjudicados(Session("IdEstablecimiento"), Request.QueryString("idProc"))

                For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                    Dim mEntidad As New ANALISTAPROVEEDORES
                    'mEntidad.IDANALISTA = Session("IdEmpleado")
                    mEntidad.IDPROVEEDOR = ds1.Tables(0).Rows(i).Item(0)
                    mEntidad.IDESTABLECIMIENTO = Me.Session("IdEstablecimiento")
                    mEntidad.IDPROCESOCOMPRA = Me.Request.QueryString("IdProc")
                    mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    mEntidad.AUFECHACREACION = Today
                    'SE ELIMINA AGREGAR ANALISTAPROVEEDOR DE ESTE MOMENTO
                    'mComponente.AgregarANALISTAPROVEEDORES(mEntidad)
                Next


            End If

            If cPC.ActualizarEstado(ePC, 2, True, RegistrarPreciosHistoricos, InhabilitarUsuarioComisionAltoNivel) > 0 Then
                Confirm("Se ha generado la resolución de adjudicación correctamente.  ¿Desea imprimir el documento asociado?", "Imprimir", OptionPostBack.YesNotPostBack)
                'Me.MsgBox1.ShowConfirm("Se ha generado la resolución de adjudicación correctamente.  ¿Desea imprimir el documento asociado?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_PostBackOnNo)
            Else
                Alert("Se produjo un error al intentar generar la resolución de adjudicación.", "Error")
                'Me.MsgBox1.ShowAlert("Se produjo un error al intentar generar la resolución de adjudicación.", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If
        End If
    End Sub

    Private Sub ProcesarImprimir(ByVal argument As Boolean)
        If argument Then
            Response.Redirect("~/UACI/FrmEditarPlantillaProcesoCompra.aspx?idProc=" + Request.QueryString("idProc") + "&idTP=" + eTIPOPLANTILLA.ADJUDICACION.ToString("d"))
        Else
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub


    'Protected Sub MsgBox1_NoChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.NoChosen
    '    If e.Key = "A" Then
    '        Response.Redirect("~/FrmPrincipal.aspx", False)
    '    End If
    'End Sub

    'Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
    '    If e.Key = "A" Then
    '        Response.Redirect("~/UACI/FrmEditarPlantillaProcesoCompra.aspx?idProc=" + Request.QueryString("idProc") + "&idTP=" + eTIPOPLANTILLA.ADJUDICACION.ToString("d"))
    '    End If
    '    If e.Key = "B" Then
    '        Dim cPC As New cPROCESOCOMPRAS
    '        Dim ePC As New PROCESOCOMPRAS
    '        ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
    '        ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")
    '        ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION
    '        ePC.FECHAFIRMARESOLUCION = CType(cpFechaFirmaResolucion.Text, Date) ' Me.cpFechaFirmaResolucion.SelectedDate
    '        ePC.FECHAFIRMAACEPTACION = ePC.FECHAFIRMARESOLUCION
    '        ePC.NUMERORESOLUCION = Me.txtNroResolucion.Text
    '        ePC.IDTITULARADJUDICACION = Me.ddlEMPLEADOS1.SelectedValue
    '        ePC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
    '        ePC.AUFECHAMODIFICACION = Now
    '        ePC.ESTASINCRONIZADA = 0

    '        Dim ds As Data.DataSet
    '        ds = cPC.obtenerTipoProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"))
    '        Dim DistribuirCantidadesAlmacen, RegistrarPreciosHistoricos, InhabilitarUsuarioComisionAltoNivel As Boolean

    '        If ds.Tables(0).Rows(0).Item(0) = 3 Or ds.Tables(0).Rows(0).Item(0) = 4 Then
    '            DistribuirCantidadesAlmacen = True
    '            RegistrarPreciosHistoricos = True
    '            InhabilitarUsuarioComisionAltoNivel = True
    '            ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION


    '            'X CADA PROVEEDOR
    '            Dim mComponente As New cANALISTAPROVEEDORES
    '            Dim A As New cADJUDICACION
    '            Dim ds1 As Data.DataSet
    '            ds1 = A.obtenerDatasetProveedoresAdjudicados(Session("IdEstablecimiento"), Request.QueryString("idProc"))

    '            For i As Integer = 0 To ds1.Tables(0).Rows.Count - 1
    '                Dim mEntidad As New ANALISTAPROVEEDORES
    '                'mEntidad.IDANALISTA = Session("IdEmpleado")
    '                mEntidad.IDPROVEEDOR = ds1.Tables(0).Rows(i).Item(0)
    '                mEntidad.IDESTABLECIMIENTO = Me.Session("IdEstablecimiento")
    '                mEntidad.IDPROCESOCOMPRA = Me.Request.QueryString("IdProc")
    '                mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
    '                mEntidad.AUFECHACREACION = Today
    '                'SE ELIMINA AGREGAR ANALISTAPROVEEDOR DE ESTE MOMENTO
    '                'mComponente.AgregarANALISTAPROVEEDORES(mEntidad)
    '            Next


    '        End If

    '        If cPC.ActualizarEstado(ePC, 2, True, RegistrarPreciosHistoricos, InhabilitarUsuarioComisionAltoNivel) > 0 Then
    '            Confirm("Se ha generado la resolución de adjudicación correctamente.  ¿Desea imprimir el documento asociado?", "Imprimir", OptionPostBack.YesNotPostBack)
    '            'Me.MsgBox1.ShowConfirm("Se ha generado la resolución de adjudicación correctamente.  ¿Desea imprimir el documento asociado?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_PostBackOnNo)
    '        Else
    '            Alert("Se produjo un error al intentar generar la resolución de adjudicación.", "Error")
    '            'Me.MsgBox1.ShowAlert("Se produjo un error al intentar generar la resolución de adjudicación.", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        End If
    '    End If

    'End Sub


    Protected Sub btnAdjudicar_Click(sender As Object, e As System.EventArgs) Handles btnAdjudicar.Click

        pnGenerarResolucionAdjudicacion.Visible = False
        pnRegistrarFecha.Visible = True

        'Dim cPC As New cPROCESOCOMPRAS
        'Dim ePC As New PROCESOCOMPRAS
        'ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        'ePC.IdProcesoCompra = Request.QueryString("idProc")
        'ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA
        'ePC.FECHAFIRMARESOLUCION = Me.cpFechaFirmaResolucion.SelectedDate
        'ePC.FECHAFIRMAACEPTACION = ePC.FECHAFIRMARESOLUCION
        'ePC.NUMERORESOLUCION = Me.txtNroResolucion.Text
        'ePC.IDTITULARADJUDICACION = Me.ddlEMPLEADOS1.SelectedValue
        'ePC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        'ePC.AUFECHAMODIFICACION = Now
        'ePC.ESTASINCRONIZADA = 0

        'Preguntar al usuario si desea generar la resolución de adjudicación porque cambiara de estado
        Confirm("¿Desea generar la resolución de adjudicación", "Generar", OptionPostBack.YesNotPostBack)
        'Me.MsgBox1.ShowConfirm("¿Desea generar la resolución de adjudicación", "B", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_PostBackOnNo)
        'If cPC.ActualizarEstado(ePC) > 0 Then
        '    Me.MsgBox1.ShowConfirm("Se ha generado la resolución de adjudicación correctamente.  ¿Desea imprimir el documento asociado?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_PostBackOnNo)
        'Else
        '    Me.MsgBox1.ShowAlert("Se produjo un error al intentar generar la resolución de adjudicación.", "E", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        'End If

    End Sub

    Protected Sub btnModificarRecomendacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificarRecomendacion.Click
        Me.btnInformeEvaluacionPorOferta.Visible = False
        Me.btnInformeEvaluacionPorRenglon.Visible = False

        Me.pnGenerarResolucionAdjudicacion.Visible = False
        Me.pnRegistrarFecha.Visible = False
        Me.pnError.Visible = False

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

            Me.UcAsignarCantidades1.TipoCantidad = 2
            Me.UcAsignarCantidades1.UnidadMedidaB = Me.UcRenglonesProcesoCompra1.UnidadMedida

            Me.UcAsignarCantidades1.Observaciones = Me.UcRenglonesProcesoCompra1.ObtenerObservacionAdjudicacion()

            Me.UcAsignarCantidades1.CargarDatos()

        End If

        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False
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
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False
        Me.UcOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = True
        Me.UcOfertasPorRenglonProcesoCompra1.Visible = True
        Me.UcOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcOfertasPorRenglonProcesoCompra1.IDPRODUCTO = Me.UcRenglonesProcesoCompra1.IDPRODUCTO
        Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEPROCESOCOMPRA = Me.UcRenglonesProcesoCompra1.IDDETALLE
        Me.UcOfertasPorRenglonProcesoCompra1.TipoCantidad = 2
        Me.UcOfertasPorRenglonProcesoCompra1.RENGLON = Me.UcRenglonesProcesoCompra1.RENGLON
        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.CargarDatos()
    End Sub

    Protected Sub btnIngresarFechaAdjudicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresarFechaAdjudicar.Click

        If Me.ddlEMPLEADOS1.Items.Count = 0 Then
            Me.btnInformeEvaluacionPorOferta.Visible = False
            Me.btnInformeEvaluacionPorRenglon.Visible = False

            Me.pnGenerarResolucionAdjudicacion.Visible = False
            Me.pnRegistrarFecha.Visible = False
            Me.pnError.Visible = True
            Me.lblError.Text = "El establecimiento debe tener definido un titular para permitir generar la resolucion."
        Else
            Me.btnInformeEvaluacionPorOferta.Visible = True
            Me.btnInformeEvaluacionPorRenglon.Visible = True

            Me.pnGenerarResolucionAdjudicacion.Visible = False
            Me.pnRegistrarFecha.Visible = True
            Me.pnError.Visible = False
        End If

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
