Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils

Partial Class FrmGenerarRecomCompraLG
    Inherits System.Web.UI.Page

    Private _TipoProcesoCompra As Integer
    Private _Movimiento As Integer

    Private estadosEvaluacion() As Byte = {eESTADOCALIFICACION.NOCALIFICADO, eESTADOCALIFICACION.CALIFICADO, eESTADOCALIFICACION.NOREQUIERECALIFICACION, eESTADOCALIFICACION.RECOMENDADO, eESTADOCALIFICACION.NOADJUDICADO, eESTADOCALIFICACION.NORECOMENDADO, eESTADOCALIFICACION.ADJUDICADO}
    Private estadosRecomendacion() As Byte = {eESTADOCALIFICACION.CALIFICADO, eESTADOCALIFICACION.NOREQUIERECALIFICACION, eESTADOCALIFICACION.RECOMENDADO, eESTADOCALIFICACION.NOADJUDICADO}
    Private estadosCuadroTecnico() As Byte = {eESTADOCALIFICACION.CALIFICADO, eESTADOCALIFICACION.NOREQUIERECALIFICACION, eESTADOCALIFICACION.RECOMENDADO, eESTADOCALIFICACION.NOADJUDICADO}
    Private estadosFinalizarRecomendacion As Byte() = {eESTADOCALIFICACION.RECOMENDADO, eESTADOCALIFICACION.NOADJUDICADO, eESTADOCALIFICACION.DESIERTO, eESTADOCALIFICACION.ADJUDICADO, eESTADOCALIFICACION.NOREQUIERECALIFICACION}
    Private estadosNoRecomendados As Byte() = {eESTADOCALIFICACION.CALIFICADO}

    Private ds As Data.DataSet

#Region " Propiedades "

    Public Property TipoProcesoCompra() As Integer
        Get
            Return _TipoProcesoCompra
        End Get
        Set(ByVal Value As Integer)
            _TipoProcesoCompra = Value
            If Not Me.ViewState("TipoProcesoCompra") Is Nothing Then Me.ViewState.Remove("TipoProcesoCompra")
            Me.ViewState.Add("TipoProcesoCompra", Value)
        End Set
    End Property

    Public Property Movimiento() As Integer
        Get
            Return _Movimiento
        End Get
        Set(ByVal Value As Integer)
            _Movimiento = Value
            If Not Me.ViewState("Movimiento") Is Nothing Then Me.ViewState.Remove("Movimiento")
            Me.ViewState.Add("Movimiento", Value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.btnInformeEvaluacionPorOferta.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc"))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"
            Me.btnInformeEvaluacionPorRenglon.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc"))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"


            'TOTAL DE OFERTAS
            'Dim mComponente As New cRECEPCIONOFERTAS

            'Dim dsOFERTAS As Data.DataSet
            'dsOFERTAS = mComponente.ObtenerDataSet_OfertasRecibidas(Request.QueryString("idProc"), Session("IdEstablecimiento"))

            'Dim TOTALOFERTAS As Integer = dsOFERTAS.Tables(0).Rows.Count

            ''analisis financiero
            'Dim cEO1 As New cEXAMENOFERTA
            'Dim dsFinanciero As Data.DataSet
            'dsFinanciero = cEO1.ObtenerProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))

            ''analisis legal
            'Dim cDO As New cDOCUMENTOSOFERTA
            'Dim dsLegal As Data.DataSet
            'dsLegal = cDO.ObtenerProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))

            ''analisis tecnico
            'Dim mC As New cOFERTAPROCESOCOMPRA
            'Dim dste As Data.DataSet
            'dste = mC.ObtenerOrdenLLegada(Session("IdEstablecimiento"), Request.QueryString("idProc"))

            'Dim drTe As Data.DataRow = dste.Tables(0).NewRow
            'Dim cDOR As New cEXAMENRENGLON
            'Dim Resultado As Boolean
            'Dim dsTecnico As Integer = 0
            'For Each drTe In dste.Tables(0).Rows
            '    Resultado = cDOR.ChequeoAnalisisCompletoXProveedor(Session("IdEstablecimiento"), Request.QueryString("idProc"), drTe(1))
            '    If Resultado = True Then
            '        'YA ESTA ANALIZADO EL PROVEEDOR
            '        dsTecnico += 1
            '    End If
            'Next
            'Dim ixs As Integer = 0
            ''VALIDAR QUE TODOS LOS EXAMENES ESTEN COMPLETOS
            'If Not TOTALOFERTAS = dsFinanciero.Tables(0).Rows(0).Item(0) Then
            '    Me.btnFinalizarRecomendacion.Visible = False
            '    EsconderBotones()
            '    Me.Label3.Visible = True
            '    Me.Label2.Visible = True
            '    Me.Label2.Text = "- Examen Financiero. "
            '    ixs = 1
            'End If
            'If Not TOTALOFERTAS = dsLegal.Tables(0).Rows(0).Item(0) Then
            '    Me.btnFinalizarRecomendacion.Visible = False
            '    EsconderBotones()
            '    Me.Label3.Visible = True
            '    Me.Label4.Visible = True
            '    Me.Label4.Text = "- Examen Legal. "
            '    ixs = 1
            'End If
            'If Not TOTALOFERTAS = dsTecnico Then
            '    Me.btnFinalizarRecomendacion.Visible = False
            '    EsconderBotones()
            '    Me.Label3.Visible = True
            '    Me.Label5.Visible = True
            '    Me.Label5.Text = "- Examen Técnico. "
            '    ixs = 1
            'End If

            'VALIDAR QUE LA COMISION ESTE CREADA
            'Dim cCPC As New cCOMISIONPROCESOCOMPRA
            'If cCPC.ExisteComisionEvaluacion(Session("IdEstablecimiento"), Request.QueryString("idProc")) = False Then
            '    EsconderBotones()
            '    Me.btnFinalizarRecomendacion.Visible = False
            '    Me.Label3.Visible = True
            '    Me.Label7.Visible = True
            '    Me.Label7.Text = "- Crear Comisión Evaluación."
            '    ixs = 1
            'End If
            'If ixs = 0 Then
            Me.btnFinalizarRecomendacion.Visible = True
            EsconderBotones()
            Me.btnEvaluar_Click(sender, e)
            'End If
        Else

            If Not Me.ViewState("TipoProcesoCompra") Is Nothing Then Me._TipoProcesoCompra = Me.ViewState("TipoProcesoCompra")
            If Not Me.ViewState("Movimiento") Is Nothing Then Me._Movimiento = Me.ViewState("Movimiento")

            If MessageBox.ConfirmTarget = "Generar" Then EvaluarGenerar(MessageBox.ConfirmArgument)
            If MessageBox.ConfirmTarget = "Evaluado" Then Limpiar()
        End If

    End Sub

    Private Sub EsconderBotones()
        Me.btnEvaluar.Visible = False
        Me.btnRecomendar.Visible = False
        Me.btnCuadroEvaluacion.Visible = False
        Me.btnInformeEvaluacion.Visible = False
    End Sub

    Protected Sub UcRenglonesProcesoCompra1_SelectedIndexChanged() Handles UcRenglonesProcesoCompra1.SelectedIndexChanged

        Me.UcRenglonesProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcRenglonesProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")

        Me.UcOfertasPorRenglonProcesoCompra1.TipoCantidad = 1

        If Movimiento = 1 Or Movimiento = 2 Then

            If Movimiento = 1 Then
                Me.UcRenglonesProcesoCompra1.IDESTADO = estadosEvaluacion
                Me.UcOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = False
            Else
                Me.UcRenglonesProcesoCompra1.IDESTADO = estadosRecomendacion
                Me.UcOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = True
            End If

            Me.UcRenglonesProcesoCompra1.CargarDatos()

            If Me.UcRenglonesProcesoCompra1.RENGLON = 0 Then
                Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
                Me.UcOfertasPorRenglonProcesoCompra1.Visible = False

                Me.btnHojaAnalisis.Visible = False
                Me.Panel1.Visible = False

                Me.UcAsignarCantidades1.LimpiarCantidades()
                Me.UcAsignarCantidades1.Visible = False
                Me.pnContratacion.Visible = False
                Me.pnLicitacion.Visible = False
                Me.pnInformeEvaluacion.Visible = False
            Else

                ' Me.btnHojaAnalisis.Visible = True
                Me.Panel1.Visible = True

                'Me.UcOfertasPorRenglonProcesoCompra1.Visible = True
                Me.UcOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                Me.UcOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
                Me.UcOfertasPorRenglonProcesoCompra1.IDPRODUCTO = Me.UcRenglonesProcesoCompra1.IDPRODUCTO
                Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEPROCESOCOMPRA = Me.UcRenglonesProcesoCompra1.IDDETALLE

                Me.UcOfertasPorRenglonProcesoCompra1.RENGLON = Me.UcRenglonesProcesoCompra1.RENGLON

                Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = (Movimiento = 2)
                Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
                Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False

                Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
                Me.UcOfertasPorRenglonProcesoCompra1.CargarDatos()

            End If

            'ElseIf Movimiento = 3 Then

            '    Me.UcRenglonesProcesoCompra1.IDESTADO = estadosCuadroTecnico
            '    Me.UcRenglonesProcesoCompra1.CargarDatos()

            '    Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
            '    Me.UcOfertasPorRenglonProcesoCompra1.Visible = False

            '    Me.UcAsignarCantidades1.LimpiarCantidades()
            '    Me.UcAsignarCantidades1.Visible = False

            '    If Me.UcRenglonesProcesoCompra1.RENGLON = 0 Then
            '        Me.pnCuadroEvaluacion.Visible = False
            '    Else
            '        Me.pnCuadroEvaluacion.Visible = True
            '        Dim cDO As New cDETALLEOFERTA

            '        ds = cDO.CuadroEvaluacionOferta(Me.UcRenglonesProcesoCompra1.IDESTABLECIMIENTO, Me.UcRenglonesProcesoCompra1.IdProcesoCompra, Me.UcRenglonesProcesoCompra1.RENGLON)
            '        Me.gvCuadroEvaluacion.DataSource = ds
            '        Me.gvCuadroEvaluacion.DataBind()

            '        Dim cDPC As New cDETALLEPROCESOCOMPRA
            '        txtObservacionRecomendacion.Text = cDPC.ObtenerObservacionRecomendacion(Me.UcRenglonesProcesoCompra1.IDESTABLECIMIENTO, Me.UcRenglonesProcesoCompra1.IdProcesoCompra, Me.UcRenglonesProcesoCompra1.IDPRODUCTO, Me.UcRenglonesProcesoCompra1.IDDETALLE)

            '        Me.btnImprimirCuadro.Attributes.Add("onclick", "window.open('Reportes/FrmRptCuadroEvTF.aspx?idE=" + Me.UcRenglonesProcesoCompra1.IDESTABLECIMIENTO.ToString + "&idPC=" + Me.UcRenglonesProcesoCompra1.IdProcesoCompra.ToString + "&R=" + Me.UcRenglonesProcesoCompra1.RENGLON.ToString + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")
            '    End If
            Dim cad = "/Reportes/FrmRptCuadroEvTF.aspx?idE=" + Me.UcRenglonesProcesoCompra1.IDESTABLECIMIENTO.ToString + "&idPC=" + Me.UcRenglonesProcesoCompra1.IDPROCESOCOMPRA.ToString + "&R=" + Me.UcRenglonesProcesoCompra1.RENGLON.ToString
            Me.btnImprimirCuadro.Attributes.Add("onclick", SINAB_Utils.Utils.ReferirVentana(cad))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptCuadroEvTF.aspx?idE=" + Me.UcRenglonesProcesoCompra1.IDESTABLECIMIENTO.ToString + "&idPC=" + Me.UcRenglonesProcesoCompra1.IDPROCESOCOMPRA.ToString + "&R=" + Me.UcRenglonesProcesoCompra1.RENGLON.ToString + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")
            cad = "/Reportes/frmRptHojaAnalisisXRenglon.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idP=" + Request.QueryString("idProc").ToString + "&renglon=" + CStr(Me.UcRenglonesProcesoCompra1.RENGLON)
            Me.btnHojaAnalisis.Attributes.Add("onclick", SINAB_Utils.Utils.ReferirVentana(cad))
            '"window.open('" + Request.ApplicationPath + "/Reportes/frmRptHojaAnalisisXRenglon.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idP=" + Request.QueryString("idProc").ToString + "&renglon=" + CStr(Me.UcRenglonesProcesoCompra1.RENGLON) + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")
        End If
        Me.Button1.BackColor = Drawing.Color.Empty
        Me.Button2.BackColor = Drawing.Color.Empty
        Me.Button3.BackColor = Drawing.Color.Empty
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub btnEvaluar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEvaluar.Click

        Movimiento = 1

        Dim cPC As New cPROCESOCOMPRAS

        ds = cPC.obtenerTipoProcesoCompra(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        Me.txtTipoEvaluacion.Text = ds.Tables(0).Rows(0).Item(1)
        Me.txtTipoEvaluacion.Visible = True
        Me.lblTipoEvaluacion.Visible = True
        TipoProcesoCompra = ds.Tables(0).Rows(0).Item(2)

        Me.UcRenglonesProcesoCompra1.Visible = True
        Me.UcRenglonesProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcRenglonesProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")

        Me.UcRenglonesProcesoCompra1.IDESTADO = estadosEvaluacion
        Me.UcRenglonesProcesoCompra1.LimpiarRenglones()
        Me.UcRenglonesProcesoCompra1.CargarDatos()

        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.Visible = False

        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.pnContratacion.Visible = False
        Me.pnLicitacion.Visible = False
        Me.pnCuadroEvaluacion.Visible = False
        Me.pnInformeEvaluacion.Visible = False

    End Sub

    Protected Sub UcOfertasPorRenglonProcesoCompra1_SelectedIndexChanged() Handles UcOfertasPorRenglonProcesoCompra1.SelectedIndexChanged

        Select Case Movimiento
            Case Is = 1

                Me.UcAsignarCantidades1.LimpiarCantidades()
                Me.UcAsignarCantidades1.Visible = False

                Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = False
                Me.UcOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = False

                Select Case TipoProcesoCompra
                    Case Is = 1

                        If Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA = 0 Then
                            'Me.Panel1.Visible = False
                            Me.pnLicitacion.Visible = False
                            Me.pnContratacion.Visible = False
                            Me.txtObservacionNA.Text = ""
                        Else

                            Me.pnLicitacion.Visible = True
                            Me.pnContratacion.Visible = False
                            Me.btnHojaAnalisis.Visible = False

                            Dim cCPC As New cCRITERIOPROCESOCOMPRA
                            ds = cCPC.ObtenerDataSetCriteriosProcesoCompraRC(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.UcOfertasPorRenglonProcesoCompra1.IDPROVEEDOR, Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA, TipoProcesoCompra)
                            gvCriterios.DataSource = ds
                            gvCriterios.DataBind()

                            Dim cDPC As New cDETALLEPROCESOCOMPRA
                            Me.txtObservacionNA.Text = cDPC.ObtenerObservacionRecomendacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.UcRenglonesProcesoCompra1.IDPRODUCTO, Me.UcRenglonesProcesoCompra1.IDDETALLE)
                        End If
                        'LIBRE GESTION
                    Case Is = 2
                        If Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA = 0 Then
                            Me.pnLicitacion.Visible = False
                            Me.pnContratacion.Visible = False
                            Me.txtObservacion.Text = ""
                        Else
                            Me.pnLicitacion.Visible = True
                            Me.pnContratacion.Visible = False
                            Me.btnHojaAnalisis.Visible = False

                            Dim cCPC As New cCRITERIOPROCESOCOMPRA
                            ds = cCPC.ObtenerDataSetCriteriosProcesoCompraRC(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.UcOfertasPorRenglonProcesoCompra1.IDPROVEEDOR, Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA, TipoProcesoCompra)
                            gvCriterios.DataSource = ds
                            gvCriterios.DataBind()

                            Dim cDPC As New cDETALLEPROCESOCOMPRA
                            Me.txtObservacionNA.Text = cDPC.ObtenerObservacionRecomendacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.UcRenglonesProcesoCompra1.IDPRODUCTO, Me.UcRenglonesProcesoCompra1.IDDETALLE)
                        End If
                End Select


            Case Is = 2

                Me.UcOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = True


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
                    Me.UcAsignarCantidades1.CantidadAsignadaOfertaSeleccionada = Me.UcOfertasPorRenglonProcesoCompra1.CantidadRecomendada

                    Me.UcAsignarCantidades1.TipoCantidad = 1
                    Me.UcAsignarCantidades1.UnidadMedidaB = Me.UcRenglonesProcesoCompra1.UnidadMedida

                    Me.UcAsignarCantidades1.Observaciones = Me.UcRenglonesProcesoCompra1.ObtenerObservacionRecomendacion

                    Me.UcAsignarCantidades1.CargarDatos()

                End If

                Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True

                'Case Is = 3

                '    Me.UcAsignarCantidades1.LimpiarCantidades()
                '    Me.UcAsignarCantidades1.Visible = False

                '    Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True

        End Select

        'VOLVER A CARGAR LA OFERTA CON LA FILA SELECCIONADA
        Me.UcOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcOfertasPorRenglonProcesoCompra1.RENGLON = Me.UcRenglonesProcesoCompra1.RENGLON
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False

        Me.UcOfertasPorRenglonProcesoCompra1.CargarDatos()

    End Sub

    Private Sub LimpiarCD()
        Me.pnContratacion.Visible = False
    End Sub

    Private Sub LimpiarLP()
        Me.gvCriterios.DataSource = Nothing
        Me.gvCriterios.DataBind()
        Me.lblCalificacionLP.Text = ""
        Me.btnGuardarCalificacionesLP.Enabled = False
    End Sub

    Protected Sub btnObtenerCalificacionLP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnObtenerCalificacionLP.Click
        Dim calificacion As Decimal
        Dim calificacioncriterio As String
        For Each row As GridViewRow In Me.gvCriterios.Rows
            calificacioncriterio = CType(row.FindControl("NumericBox4"), TextBox).Text
            If Not Trim(calificacioncriterio) = String.Empty Then
                calificacion += CDec(calificacioncriterio)
            End If
        Next
        Me.lblCalificacionLP.Text = calificacion.ToString + "%"
        Me.btnGuardarCalificacionesLP.Enabled = True
    End Sub

    Protected Sub btnGuardarCalificacionesLP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarCalificacionesLP.Click
        Dim cCRO As New cCALIFICACIONRENGLONOFERTAS
        Dim CRO As New CALIFICACIONRENGLONOFERTAS
        Dim cDO As New cDETALLEOFERTA
        Dim cDPC As New cDETALLEPROCESOCOMPRA

        CRO.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        CRO.IDPROCESOCOMPRA = Request.QueryString("idProc")
        CRO.IDPROVEEDOR = Me.UcOfertasPorRenglonProcesoCompra1.IDPROVEEDOR
        CRO.IDDETALLE = Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA

        ' AGREGAR LA CALIFICACION A CADA CRITERIO
        For Each row As GridViewRow In Me.gvCriterios.Rows
            CRO.PORCENTAJE = CDec(CType(row.FindControl("NumericBox4"), TextBox).Text)
            CRO.IDCRITERIOEVALUACION = gvCriterios.DataKeys(row.RowIndex).Values(0)
            cCRO.EliminarCALIFICACIONRENGLONOFERTAS(CRO.IDESTABLECIMIENTO, CRO.IDPROCESOCOMPRA, CRO.IDCRITERIOEVALUACION, CRO.IDPROVEEDOR, CRO.IDDETALLE)
            cCRO.AgregarCALIFICACIONRENGLONOFERTAS(CRO)
        Next

        ' ACTUALIZAR EL ESTADO A LA OFERTA ( ESTADO=CALIFICADO)
        cDO.ActualizarEstadoCalificacionOferta(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.UcOfertasPorRenglonProcesoCompra1.IDPROVEEDOR, Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA, 2)
        ' cDPC.ActualizarObservacionRecomendacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.UcRenglonesProcesoCompra1.IDPRODUCTO, Me.UcRenglonesProcesoCompra1.IDDETALLE, Me.txtObservacion.Text)

        'SI TODAS LAS OFERTAS HAN SIDO CALIFICADAS, ACTUALIZA EL ESTADO AL RENGLON
        If cDO.OfertanteCalificado(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.UcOfertasPorRenglonProcesoCompra1.IDPROVEEDOR, Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA, Me.UcRenglonesProcesoCompra1.RENGLON) = True Then
            Dim eDPC As New DETALLEPROCESOCOMPRA
            eDPC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            eDPC.IDPROCESOCOMPRA = Request.QueryString("idProc")
            eDPC.IDPRODUCTO = Me.UcRenglonesProcesoCompra1.IDPRODUCTO
            eDPC.IDDETALLE = Me.UcRenglonesProcesoCompra1.IDDETALLE
            eDPC.IDESTADOCALIFICACION = eESTADOCALIFICACION.CALIFICADO
            eDPC.AUUSUARIOMODIFICACION = User.Identity.Name
            eDPC.AUFECHAMODIFICACION = Now

            cDPC.ActualizarEstadoCalificacionProcesoCompra(eDPC)
        End If

        MessageBox.AlertSubmit("El proveedor ha sido evaluado satisfactoriamente.", "Evaluado")
        'Me.MsgBox1.ShowAlert("El proveedor ha sido evaluado satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        Me.pnLicitacion.Visible = False
        Me.LimpiarLP()

        'Me.txtObservacion.Text = ""
        For Each row As GridViewRow In Me.gvCriterios.Rows
            CType(row.FindControl("NumericBox4"), TextBox).Text = 0
        Next

        'btnGuardarCalificacionesLP.Enabled = False

        Me.UcRenglonesProcesoCompra1.IDESTADO = estadosEvaluacion
        Me.UcRenglonesProcesoCompra1.CargarDatos()

        Me.UcOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcOfertasPorRenglonProcesoCompra1.RENGLON = Me.UcRenglonesProcesoCompra1.RENGLON
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False
        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.CargarDatos()

    End Sub

    Protected Sub btnRecomendar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecomendar.Click
        VerRenglonesRecomendacion()
    End Sub

    Protected Sub btnCuadroEvaluacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCuadroEvaluacion.Click
        Movimiento = 3

        Me.lblTipoEvaluacion.Visible = False
        Me.txtTipoEvaluacion.Visible = False

        Me.UcRenglonesProcesoCompra1.Visible = True
        Me.UcRenglonesProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcRenglonesProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")

        Me.UcRenglonesProcesoCompra1.IDESTADO = estadosCuadroTecnico
        Me.UcRenglonesProcesoCompra1.LimpiarRenglones()
        Me.UcRenglonesProcesoCompra1.CargarDatos()

        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.Visible = False

        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.pnContratacion.Visible = False
        Me.pnLicitacion.Visible = False
        Me.pnCuadroEvaluacion.Visible = False
        Me.pnInformeEvaluacion.Visible = False
    End Sub

    Protected Sub gvCuadroEvaluacion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCuadroEvaluacion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cDO As New cDETALLEOFERTA
            Dim IDPROVEEDOR, IDDETALLE As Integer

            IDPROVEEDOR = Me.gvCuadroEvaluacion.DataKeys(e.Row.RowIndex).Values(0)
            IDDETALLE = Me.gvCuadroEvaluacion.DataKeys(e.Row.RowIndex).Values(1)

            ds = cDO.CuadroEvaluacionCriterio(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDPROVEEDOR, IDDETALLE)

            Dim g As GridView = CType(e.Row.Cells(2).Controls(1), GridView)
            g.DataSource = ds.Tables(0)
            g.DataBind()
        End If
    End Sub

    Protected Sub UcAsignarCantidades1_Cancelar() Handles UcAsignarCantidades1.Cancelar

        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.UcRenglonesProcesoCompra1.IDESTADO = estadosRecomendacion
        Me.UcRenglonesProcesoCompra1.CargarDatos()

        Me.UcOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcOfertasPorRenglonProcesoCompra1.RENGLON = Me.UcRenglonesProcesoCompra1.RENGLON
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False
        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.CargarDatos()

    End Sub

    Protected Sub UcAsignarCantidades1_Eliminar() Handles UcAsignarCantidades1.Eliminar
        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.UcRenglonesProcesoCompra1.CargarDatos()

        Me.UcOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcOfertasPorRenglonProcesoCompra1.RENGLON = Me.UcRenglonesProcesoCompra1.RENGLON
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False
        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.CargarDatos()
    End Sub

    Protected Sub UcAsignarCantidades1_Guardar() Handles UcAsignarCantidades1.Guardar
        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.UcRenglonesProcesoCompra1.CargarDatos()

        Me.UcOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcOfertasPorRenglonProcesoCompra1.RENGLON = Me.UcRenglonesProcesoCompra1.RENGLON
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False
        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.CargarDatos()
    End Sub

    Protected Sub btnInformeEvaluacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInformeEvaluacion.Click
        Me.pnInformeEvaluacion.Visible = True

        Me.UcRenglonesProcesoCompra1.Visible = False

        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.Visible = False

        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.pnContratacion.Visible = False
        Me.pnLicitacion.Visible = False
        Me.pnCuadroEvaluacion.Visible = False
    End Sub

    Protected Sub UcOfertasPorRenglonProcesoCompra1_NoAdjudicar() Handles UcOfertasPorRenglonProcesoCompra1.NoAdjudicar
        Me.Panel2.Visible = True
    End Sub

    Protected Sub VerRenglonesRecomendacion()
        Movimiento = 2

        Me.lblTipoEvaluacion.Visible = False
        Me.txtTipoEvaluacion.Visible = False

        Me.UcRenglonesProcesoCompra1.Visible = True
        Me.UcRenglonesProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcRenglonesProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")

        Me.UcRenglonesProcesoCompra1.IDESTADO = estadosRecomendacion
        Me.UcRenglonesProcesoCompra1.LimpiarRenglones()
        Me.UcRenglonesProcesoCompra1.CargarDatos()

        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.Visible = False

        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.pnContratacion.Visible = False
        Me.pnLicitacion.Visible = False
        Me.pnCuadroEvaluacion.Visible = False
        Me.pnInformeEvaluacion.Visible = False

    End Sub

    Protected Sub btnFinalizarRecomendacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinalizarRecomendacion.Click
        Dim cDPC As New cDETALLEPROCESOCOMPRA

        Dim renglonesNoRecomendados As Integer = cDPC.RenglonesRecomendados(Session("IdEstablecimiento"), Request.QueryString("idProc"), estadosFinalizarRecomendacion)

        If renglonesNoRecomendados = 0 Then
            Dim cPC As New cPROCESOCOMPRAS
            Dim PC As New PROCESOCOMPRAS
            PC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            PC.IDPROCESOCOMPRA = Request.QueryString("idProc")
            PC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.GENERARRESOLUCIONDEADJUDICACION
            PC.FECHAFINRECOMENDACION = DateTime.Now
            PC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            PC.AUFECHAMODIFICACION = Now
            PC.ESTASINCRONIZADA = 0
            cPC.ActualizarEstado(PC, 0)

            MessageBox.Confirm("El proceso de compras ha finalizado la evaluación y recomendación satisfactoriamente.  Desea generar el documento?", "Generar", MessageBox.OptionPostBack.YesNotPostBack)
            '  Me.MsgBox2.ShowConfirm("El proceso de compras ha finalizado la evaluación y recomendación satisfactoriamente.  Desea generar el documento?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_PostBackOnNo)
        Else
            MessageBox.Alert("Queda(n) " + renglonesNoRecomendados.ToString + " renglon(es) sin recomendar.  No es posible finalizar la recomendación.", "Sin Recomendar")
            '  Me.MsgBox2.ShowAlert("Queda(n) " + renglonesNoRecomendados.ToString + " renglon(es) sin recomendar.  No es posible finalizar la recomendación.", "I", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        End If
    End Sub
    Protected Sub EvaluarGenerar(ByVal eventArgument As Object)
        Dim arg = CType(eventArgument, Boolean)
        If arg Then
            Response.Redirect("~/UACI/FrmEditarPlantillaProcesoCompra.aspx?idProc=" + Request.QueryString("idProc") + "&idTP=" + eTIPOPLANTILLA.RECOMENDACION.ToString("d"))
        Else
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub
    'Protected Sub MsgBox2_NoChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox2.NoChosen
    '    If e.Key = "A" Then
    '        Response.Redirect("~/FrmPrincipal.aspx", False)
    '    End If
    'End Sub

    'Protected Sub MsgBox2_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox2.YesChosen
    '    If e.Key = "A" Then
    '        Response.Redirect("~/UACI/FrmEditarPlantillaProcesoCompra.aspx?idProc=" + Request.QueryString("idProc") + "&idTP=" + eTIPOPLANTILLA.RECOMENDACION.ToString("d"))
    '    End If
    'End Sub

    Protected Sub Limpiar() ' Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        'If e.Key = "A" Then
        Me.pnLicitacion.Visible = False
        LimpiarLP()
        'End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        pnLicitacion.Visible = False
        Me.UcAsignarCantidades1.Visible = False
        pnInformeEvaluacion.Visible = False
        Me.btnHojaAnalisis.Visible = True
        Movimiento = 1
        'Me.UcOfertasPorRenglonProcesoCompra1.TipoCantidad = 1
        'If Movimiento = 1 Or Movimiento = 2 Then
        '    Me.UcOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = False
        'Else
        '    Me.UcOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = True
        'End If
        Me.UcOfertasPorRenglonProcesoCompra1.Visible = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = False
        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.CargarDatos()

        Me.Button1.BackColor = Drawing.Color.LightCoral
        Me.Button2.BackColor = Drawing.Color.Empty
        Me.Button3.BackColor = Drawing.Color.Empty

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click


        'Dim est As String = Me.UcRenglonesProcesoCompra1.ObtenerEstadoRenglon()

        'If est = "No Evaluado" Then

        '    Me.MsgBox2.ShowAlert("Una o varias ofertas aún no han sido evaluadas", "VA", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        'Else
        pnLicitacion.Visible = False
        'Me.UcAsignarCantidades1.visible = True
        pnInformeEvaluacion.Visible = False
        Me.btnHojaAnalisis.Visible = True
        Movimiento = 2
        Me.UcOfertasPorRenglonProcesoCompra1.Visible = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = True
        Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = (Movimiento = 2)
        Me.UcOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.UcOfertasPorRenglonProcesoCompra1.CargarDatos()

        Me.Button1.BackColor = Drawing.Color.Empty
        Me.Button2.BackColor = Drawing.Color.LightCoral
        Me.Button3.BackColor = Drawing.Color.Empty
        'End If




    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        pnLicitacion.Visible = False
        Me.UcAsignarCantidades1.Visible = False
        pnInformeEvaluacion.Visible = True
        Me.UcOfertasPorRenglonProcesoCompra1.Visible = False
        Me.btnHojaAnalisis.Visible = False

        Me.Button1.BackColor = Drawing.Color.Empty
        Me.Button2.BackColor = Drawing.Color.Empty
        Me.Button3.BackColor = Drawing.Color.LightCoral
    End Sub


    Protected Sub btnGONA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGONA.Click
        Dim cDPC As New cDETALLEPROCESOCOMPRA
        If Me.txtObservacionNA.Text = "" Then
            MessageBox.Alert("Falta agregar una observación.", "Error")
            'Me.MsgBox3.ShowAlert("Falta agregar una observación.", "P", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            Dim eDPC As New DETALLEPROCESOCOMPRA
            eDPC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            eDPC.IDPROCESOCOMPRA = Request.QueryString("idProc")
            eDPC.IDPRODUCTO = Me.UcOfertasPorRenglonProcesoCompra1.IDPRODUCTO
            eDPC.IDDETALLE = Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEPROCESOCOMPRA
            eDPC.OBSERVACIONRECOMENDACION = Me.txtObservacionNA.Text
            eDPC.AUUSUARIOMODIFICACION = User.Identity.Name
            eDPC.AUFECHAMODIFICACION = Now

            cDPC.ActualizarObservacionRecomendacion(eDPC)

            VerRenglonesRecomendacion()

            Me.txtObservacionNA.Text = ""
            Me.Panel2.Visible = False
        End If
    End Sub
End Class
