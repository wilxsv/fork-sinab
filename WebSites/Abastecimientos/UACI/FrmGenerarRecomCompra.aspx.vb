Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils.MessageBox
Imports SINAB_Utils.Utils

Partial Class FrmGenerarRecomCompra
    Inherits System.Web.UI.Page

    Private _TipoProcesoCompra As Integer
    Private _Movimiento As Integer

    Private estadosEvaluacion() As Byte = {eESTADOCALIFICACION.NOCALIFICADO, eESTADOCALIFICACION.CALIFICADO, eESTADOCALIFICACION.NOREQUIERECALIFICACION, eESTADOCALIFICACION.RECOMENDADO, eESTADOCALIFICACION.NOADJUDICADO, eESTADOCALIFICACION.NORECOMENDADO, eESTADOCALIFICACION.ADJUDICADO}
    Private estadosRecomendacion() As Byte = {eESTADOCALIFICACION.NOCALIFICADO, eESTADOCALIFICACION.CALIFICADO, eESTADOCALIFICACION.NOREQUIERECALIFICACION, eESTADOCALIFICACION.RECOMENDADO, eESTADOCALIFICACION.NOADJUDICADO}
    Private estadosCuadroTecnico() As Byte = {eESTADOCALIFICACION.CALIFICADO, eESTADOCALIFICACION.NOREQUIERECALIFICACION, eESTADOCALIFICACION.RECOMENDADO, eESTADOCALIFICACION.NOADJUDICADO}
    Private estadosFinalizarRecomendacion As Byte() = {eESTADOCALIFICACION.RECOMENDADO, eESTADOCALIFICACION.NOADJUDICADO, eESTADOCALIFICACION.DESIERTO, eESTADOCALIFICACION.ADJUDICADO}
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

            'Me.btnInformeEvaluacionPorOferta.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"
            'Me.btnInformeEvaluacionPorRenglon.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"


            'TOTAL DE OFERTAS
            Dim mComponente As New cRECEPCIONOFERTAS

            Dim dsOFERTAS As Data.DataSet
            dsOFERTAS = mComponente.ObtenerDataSet_OfertasRecibidas(Request.QueryString("idProc"), Session("IdEstablecimiento"))

            Dim TOTALOFERTAS As Integer = dsOFERTAS.Tables(0).Rows.Count

            'analisis financiero
            Dim cEO1 As New cEXAMENOFERTA
            Dim dsFinanciero As Data.DataSet
            dsFinanciero = cEO1.ObtenerProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))

            'analisis legal
            Dim cDO As New cDOCUMENTOSOFERTA
            Dim dsLegal As Data.DataSet
            dsLegal = cDO.ObtenerProveedores(Session("IdEstablecimiento"), Request.QueryString("idProc"))

            'analisis tecnico
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
            Dim ixs As Integer = 0
            'VALIDAR QUE TODOS LOS EXAMENES ESTEN COMPLETOS
            If Not TOTALOFERTAS = dsFinanciero.Tables(0).Rows(0).Item(0) Then
                Me.btnFinalizarRecomendacion.Visible = False
                EsconderBotones()
                Me.Label3.Visible = True
                Me.Label2.Visible = True
                Me.Label2.Text = "- Examen Financiero. "
                ixs = 1
            End If
            If Not TOTALOFERTAS = dsLegal.Tables(0).Rows(0).Item(0) Then
                Me.btnFinalizarRecomendacion.Visible = False
                EsconderBotones()
                Me.Label3.Visible = True
                Me.Label4.Visible = True
                Me.Label4.Text = "- Examen Legal. "
                ixs = 1
            End If
            'If Not TOTALOFERTAS = dsTecnico Then
            '    Me.btnFinalizarRecomendacion.Visible = False
            '    EsconderBotones()
            '    Me.Label3.Visible = True
            '    Me.Label5.Visible = True
            '    Me.Label5.Text = "- Examen Técnico. "
            '    ixs = 1
            'End If

            'VALIDAR QUE LA COMISION ESTE CREADA
            Dim cCPC As New cCOMISIONPROCESOCOMPRA
            If cCPC.ExisteComisionEvaluacion(Session("IdEstablecimiento"), Request.QueryString("idProc")) = False Then
                EsconderBotones()
                Me.btnFinalizarRecomendacion.Visible = False
                Me.Label3.Visible = True
                Me.Label7.Visible = True
                Me.Label7.Text = "- Crear Comisión Evaluación."
                ixs = 1
            End If
            If ixs = 0 Then
                Me.btnFinalizarRecomendacion.Visible = True
                EsconderBotones()
                Me.btnEvaluar_Click(sender, e)
            End If
        Else

            If Not Me.ViewState("TipoProcesoCompra") Is Nothing Then Me._TipoProcesoCompra = Me.ViewState("TipoProcesoCompra")
            If Not Me.ViewState("Movimiento") Is Nothing Then Me._Movimiento = Me.ViewState("Movimiento")

            If ConfirmTarget = "Confirmar" Then ProcesarConfirmacion(CType(ConfirmArgument, Boolean))
            If ConfirmTarget = "Evaluado" Then ProcesarEvaluado()
            End If

    End Sub

    Private Sub ProcesarEvaluado()
        Me.pnLicitacion.Visible = False
        LimpiarLP()
    End Sub

    Private Sub ProcesarConfirmacion(ByVal argument As Boolean)
        If argument Then
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

    'Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
    '    If e.Key = "A" Then
    '        Me.pnLicitacion.Visible = False
    '        LimpiarLP()
    '    End If
    'End Sub

    Private Sub EsconderBotones()
        Me.btnEvaluar.Visible = False
        Me.btnRecomendar.Visible = False
        Me.btnCuadroEvaluacion.Visible = False
        Me.btnInformeEvaluacion.Visible = False
    End Sub

    Protected Sub UcRenglonesProcesoCompra1_SelectedIndexChanged() Handles ucRenglonesProcesoCompra1.SelectedIndexChanged

        Me.ucRenglonesProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.ucRenglonesProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")

        Me.ucOfertasPorRenglonProcesoCompra1.TipoCantidad = 1

        If Movimiento = 1 Or Movimiento = 2 Then

            Me.ucRenglonesProcesoCompra1.IDESTADO = estadosRecomendacion

            If Movimiento = 1 Then
                Me.ucOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = False
            Else
                Me.ucOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = True
            End If

            Me.ucRenglonesProcesoCompra1.CargarDatos()

            If Me.ucRenglonesProcesoCompra1.RENGLON = 0 Then
                Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
                Me.ucOfertasPorRenglonProcesoCompra1.Visible = False

                Me.btnHojaAnalisis.Visible = False
                Me.btnPreciosHistoricos.Visible = False
                Me.Panel1.Visible = False

                Me.UcAsignarCantidades1.LimpiarCantidades()
                Me.UcAsignarCantidades1.Visible = False
                Me.pnContratacion.Visible = False
                Me.pnLicitacion.Visible = False
                Me.pnInformeEvaluacion.Visible = False
            Else

                ' Me.btnHojaAnalisis.Visible = True
                'muestra pantalla de precios historicos 10-01-2010
                Me.btnPreciosHistoricos.Visible = True

                Me.Panel1.Visible = True

                'Me.UcOfertasPorRenglonProcesoCompra1.Visible = True
                Me.ucOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                Me.ucOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
                Me.ucOfertasPorRenglonProcesoCompra1.IDPRODUCTO = Me.ucRenglonesProcesoCompra1.IDPRODUCTO
                Me.ucOfertasPorRenglonProcesoCompra1.IDDETALLEPROCESOCOMPRA = Me.ucRenglonesProcesoCompra1.IDDETALLE

                Me.ucOfertasPorRenglonProcesoCompra1.RENGLON = Me.ucRenglonesProcesoCompra1.RENGLON

                Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = (Movimiento = 2)
                Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
                Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False

                Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
                Me.ucOfertasPorRenglonProcesoCompra1.CargarDatos()

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
            Dim cad = "/Reportes/FrmRptCuadroEvTF.aspx?idE=" + Me.ucRenglonesProcesoCompra1.IDESTABLECIMIENTO.ToString + "&idPC=" + Me.ucRenglonesProcesoCompra1.IDPROCESOCOMPRA.ToString + "&R=" + Me.ucRenglonesProcesoCompra1.RENGLON.ToString
            Me.btnImprimirCuadro.Attributes.Add("onclick", SINAB_Utils.Utils.ReferirVentana(cad))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptCuadroEvTF.aspx?idE=" + Me.ucRenglonesProcesoCompra1.IDESTABLECIMIENTO.ToString + "&idPC=" + Me.ucRenglonesProcesoCompra1.IDPROCESOCOMPRA.ToString + "&R=" + Me.ucRenglonesProcesoCompra1.RENGLON.ToString + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")

            cad = "/Reportes/frmRptHojaAnalisisXRenglon.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idP=" + Request.QueryString("idProc").ToString + "&renglon=" + CStr(Me.ucRenglonesProcesoCompra1.RENGLON)
            Me.btnHojaAnalisis.Attributes.Add("onclick", SINAB_Utils.Utils.ReferirVentana(cad))
            '"window.open('" + Request.ApplicationPath + "/Reportes/frmRptHojaAnalisisXRenglon.aspx?idE=" + Session("IdEstablecimiento").ToString + "&idP=" + Request.QueryString("idProc").ToString + "&renglon=" + CStr(Me.ucRenglonesProcesoCompra1.RENGLON) + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")

            'redirecciona pagina para mostrar precios historicos

            Me.btnPreciosHistoricos.Attributes.Add("onclick", SINAB_Utils.Utils.ReferirVentana("/uaci/frmConsultaPrecio.aspx"))
            '"window.open('" + Request.ApplicationPath + "/uaci/frmConsultaPrecio.aspx ','popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")

            cad = "/Reportes/FrmRptEspecificacionesTecnicas.aspx?idE=" + Me.ucRenglonesProcesoCompra1.IDESTABLECIMIENTO.ToString + "&idPC=" + Me.ucRenglonesProcesoCompra1.IDPROCESOCOMPRA.ToString + "&R=" + Me.ucRenglonesProcesoCompra1.RENGLON.ToString
            Me.btnImprimirEspecificaciones.Attributes.Add("onclick", SINAB_Utils.Utils.ReferirVentana(cad))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptEspecificacionesTecnicas.aspx?idE=" + Me.ucRenglonesProcesoCompra1.IDESTABLECIMIENTO.ToString + "&idPC=" + Me.ucRenglonesProcesoCompra1.IDPROCESOCOMPRA.ToString + "&R=" + Me.ucRenglonesProcesoCompra1.RENGLON.ToString + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")

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

        Me.ucRenglonesProcesoCompra1.Visible = True
        Me.ucRenglonesProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.ucRenglonesProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")

        Me.ucRenglonesProcesoCompra1.IDESTADO = estadosRecomendacion
        Me.ucRenglonesProcesoCompra1.LimpiarRenglones()
        Me.ucRenglonesProcesoCompra1.CargarDatos()

        Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.ucOfertasPorRenglonProcesoCompra1.Visible = False

        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.pnContratacion.Visible = False
        Me.pnLicitacion.Visible = False
        Me.pnCuadroEvaluacion.Visible = False
        Me.pnInformeEvaluacion.Visible = False

    End Sub

    Protected Sub UcOfertasPorRenglonProcesoCompra1_SelectedIndexChanged() Handles ucOfertasPorRenglonProcesoCompra1.SelectedIndexChanged

        Select Case Movimiento
            Case Is = 1

                Me.UcAsignarCantidades1.LimpiarCantidades()
                Me.UcAsignarCantidades1.Visible = False

                Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = False
                Me.ucOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = False

                Select Case TipoProcesoCompra
                    Case Is = 1

                        If Me.ucOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA = 0 Then
                            'Me.Panel1.Visible = False
                            Me.pnLicitacion.Visible = False
                            Me.pnContratacion.Visible = False
                            Me.txtObservacionNA.Text = ""
                        Else

                            Me.pnLicitacion.Visible = True
                            Me.pnContratacion.Visible = False
                            Me.btnHojaAnalisis.Visible = False

                            Dim cCPC As New cCRITERIOPROCESOCOMPRA
                            ds = cCPC.ObtenerDataSetCriteriosProcesoCompraRC(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.ucOfertasPorRenglonProcesoCompra1.IDPROVEEDOR, Me.ucOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA, TipoProcesoCompra)
                            gvCriterios.DataSource = ds
                            gvCriterios.DataBind()

                            Dim cDPC As New cDETALLEPROCESOCOMPRA
                            Me.txtObservacionNA.Text = cDPC.ObtenerObservacionRecomendacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.ucRenglonesProcesoCompra1.IDPRODUCTO, Me.ucRenglonesProcesoCompra1.IDDETALLE)
                        End If
                        'OTROS TIPOS DE PROCESOS DE COMPRA
                        'Case Is = 2
                        '    If Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA = 0 Then
                        '        Me.pnLicitacion.Visible = False
                        '        Me.pnContratacion.Visible = False
                        '        Me.txtObservacion.Text = ""
                        '    Else
                        '        Me.pnLicitacion.Visible = False
                        '        Me.pnContratacion.Visible = False

                        '        Dim cCPC As New cCRITERIOPROCESOCOMPRA
                        '        ds = cCPC.ObtenerDataSetCriteriosProcesoCompraRC(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.UcOfertasPorRenglonProcesoCompra1.IDPROVEEDOR, Me.UcOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA, TipoProcesoCompra)
                        '        gvCriterios.DataSource = ds
                        '        gvCriterios.DataBind()
                        '    End If
                        'Case Is = 3
                        '    Me.pnContratacion.Visible = True
                        '    Me.pnLicitacion.Visible = False
                End Select


            Case Is = 2

                Me.ucOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = True


                If Me.ucOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA = 0 Then

                    Me.UcAsignarCantidades1.LimpiarCantidades()
                    Me.UcAsignarCantidades1.Visible = False
                Else
                    Me.UcAsignarCantidades1.Visible = True

                    Me.UcAsignarCantidades1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    Me.UcAsignarCantidades1.IDPROCESOCOMPRA = Request.QueryString("idProc")
                    Me.UcAsignarCantidades1.IDPROVEEDOR = Me.ucOfertasPorRenglonProcesoCompra1.IDPROVEEDOR
                    Me.UcAsignarCantidades1.IDDETALLEOFERTA = Me.ucOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA
                    Me.UcAsignarCantidades1.IDPRODUCTO = Me.ucRenglonesProcesoCompra1.IDPRODUCTO
                    Me.UcAsignarCantidades1.IDDETALLEPROCESOCOMPRA = Me.ucRenglonesProcesoCompra1.IDDETALLE
                    Me.UcAsignarCantidades1.RENGLON = Me.ucRenglonesProcesoCompra1.RENGLON

                    Me.UcAsignarCantidades1.PlazoEntrega = Me.ucOfertasPorRenglonProcesoCompra1.PlazoEntrega
                    Me.UcAsignarCantidades1.UnidadMedida = Me.ucOfertasPorRenglonProcesoCompra1.UnidadMedida

                    Me.UcAsignarCantidades1.CantidadSolicitada = Me.ucRenglonesProcesoCompra1.CantidadSolicitada
                    Me.UcAsignarCantidades1.CantidadOferta = Me.ucOfertasPorRenglonProcesoCompra1.CantidadOferta
                    Me.UcAsignarCantidades1.CantidadRecomendada = Me.ucOfertasPorRenglonProcesoCompra1.CantidadRecomendada
                    Me.UcAsignarCantidades1.CantidadAsignadaOfertaSeleccionada = Me.ucOfertasPorRenglonProcesoCompra1.CantidadRecomendada

                    Me.UcAsignarCantidades1.TipoCantidad = 1
                    Me.UcAsignarCantidades1.UnidadMedidaB = Me.ucRenglonesProcesoCompra1.UnidadMedida

                    Me.UcAsignarCantidades1.Observaciones = Me.ucRenglonesProcesoCompra1.ObtenerObservacionRecomendacion

                    Me.UcAsignarCantidades1.CargarDatos()

                End If

                Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True

                'Case Is = 3

                '    Me.UcAsignarCantidades1.LimpiarCantidades()
                '    Me.UcAsignarCantidades1.Visible = False

                '    Me.UcOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True

        End Select

        'VOLVER A CARGAR LA OFERTA CON LA FILA SELECCIONADA
        Me.ucOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.ucOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.ucOfertasPorRenglonProcesoCompra1.RENGLON = Me.ucRenglonesProcesoCompra1.RENGLON
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False

        Me.ucOfertasPorRenglonProcesoCompra1.CargarDatos()

    End Sub

    Private Sub LimpiarCD()
        Me.pnContratacion.Visible = False
    End Sub

    Private Sub LimpiarLP()
        Me.gvCriterios.DataSource = Nothing
        Me.gvCriterios.DataBind()
        Me.lblCalificacionLP.Text = ""
        Me.btnGuardarCalificacionesLP.Enabled = True
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
        CRO.IDPROVEEDOR = Me.ucOfertasPorRenglonProcesoCompra1.IDPROVEEDOR
        CRO.IDDETALLE = Me.ucOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA

        ' AGREGAR LA CALIFICACION A CADA CRITERIO
        For Each row As GridViewRow In Me.gvCriterios.Rows
            CRO.PORCENTAJE = CDec(CType(row.FindControl("NumericBox4"), TextBox).Text)
            CRO.IDCRITERIOEVALUACION = gvCriterios.DataKeys(row.RowIndex).Values(0)
            cCRO.EliminarCALIFICACIONRENGLONOFERTAS(CRO.IDESTABLECIMIENTO, CRO.IDPROCESOCOMPRA, CRO.IDCRITERIOEVALUACION, CRO.IDPROVEEDOR, CRO.IDDETALLE)
            cCRO.AgregarCALIFICACIONRENGLONOFERTAS(CRO)
        Next

        ' ACTUALIZAR EL ESTADO A LA OFERTA ( ESTADO=CALIFICADO)
        cDO.ActualizarEstadoCalificacionOferta(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.ucOfertasPorRenglonProcesoCompra1.IDPROVEEDOR, Me.ucOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA, 2)
        ' cDPC.ActualizarObservacionRecomendacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.UcRenglonesProcesoCompra1.IDPRODUCTO, Me.UcRenglonesProcesoCompra1.IDDETALLE, Me.txtObservacion.Text)

        'SI TODAS LAS OFERTAS HAN SIDO CALIFICADAS, ACTUALIZA EL ESTADO AL RENGLON
        If cDO.OfertanteCalificado(Session("IdEstablecimiento"), Request.QueryString("idProc"), Me.ucOfertasPorRenglonProcesoCompra1.IDPROVEEDOR, Me.ucOfertasPorRenglonProcesoCompra1.IDDETALLEOFERTA, Me.ucRenglonesProcesoCompra1.RENGLON) = True Then
            Dim eDPC As New DETALLEPROCESOCOMPRA
            eDPC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            eDPC.IDPROCESOCOMPRA = Request.QueryString("idProc")
            eDPC.IDPRODUCTO = Me.ucRenglonesProcesoCompra1.IDPRODUCTO
            eDPC.IDDETALLE = Me.ucRenglonesProcesoCompra1.IDDETALLE
            eDPC.IDESTADOCALIFICACION = eESTADOCALIFICACION.CALIFICADO
            eDPC.AUUSUARIOMODIFICACION = User.Identity.Name
            eDPC.AUFECHAMODIFICACION = Now

            cDPC.ActualizarEstadoCalificacionProcesoCompra(eDPC)
        End If
        AlertSubmit("El proveedor ha sido evaluado satisfactoriamente.", "Evaluado")
        'Me.MsgBox1.ShowAlert("El proveedor ha sido evaluado satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        Me.pnLicitacion.Visible = False
        Me.LimpiarLP()

        'Me.txtObservacion.Text = ""
        For Each row As GridViewRow In Me.gvCriterios.Rows
            CType(row.FindControl("NumericBox4"), TextBox).Text = 0
        Next

        'btnGuardarCalificacionesLP.Enabled = False

        Me.ucRenglonesProcesoCompra1.IDESTADO = estadosRecomendacion
        Me.ucRenglonesProcesoCompra1.CargarDatos()

        Me.ucOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.ucOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.ucOfertasPorRenglonProcesoCompra1.RENGLON = Me.ucRenglonesProcesoCompra1.RENGLON
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False
        Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.ucOfertasPorRenglonProcesoCompra1.CargarDatos()

    End Sub

    Protected Sub btnRecomendar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecomendar.Click
        VerRenglonesRecomendacion()
    End Sub

    Protected Sub btnCuadroEvaluacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCuadroEvaluacion.Click
        Movimiento = 3

        Me.lblTipoEvaluacion.Visible = False
        Me.txtTipoEvaluacion.Visible = False

        Me.ucRenglonesProcesoCompra1.Visible = True
        Me.ucRenglonesProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.ucRenglonesProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")

        Me.ucRenglonesProcesoCompra1.IDESTADO = estadosCuadroTecnico
        Me.ucRenglonesProcesoCompra1.LimpiarRenglones()
        Me.ucRenglonesProcesoCompra1.CargarDatos()

        Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.ucOfertasPorRenglonProcesoCompra1.Visible = False

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

        Me.ucRenglonesProcesoCompra1.IDESTADO = estadosRecomendacion
        Me.ucRenglonesProcesoCompra1.CargarDatos()

        Me.ucOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.ucOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.ucOfertasPorRenglonProcesoCompra1.RENGLON = Me.ucRenglonesProcesoCompra1.RENGLON
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False
        Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.ucOfertasPorRenglonProcesoCompra1.CargarDatos()

    End Sub

    Protected Sub UcAsignarCantidades1_Eliminar() Handles UcAsignarCantidades1.Eliminar
        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.ucRenglonesProcesoCompra1.CargarDatos()

        Me.ucOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.ucOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.ucOfertasPorRenglonProcesoCompra1.RENGLON = Me.ucRenglonesProcesoCompra1.RENGLON
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False
        Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.ucOfertasPorRenglonProcesoCompra1.CargarDatos()
    End Sub

    Protected Sub UcAsignarCantidades1_Guardar() Handles UcAsignarCantidades1.Guardar
        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.ucRenglonesProcesoCompra1.CargarDatos()

        Me.ucOfertasPorRenglonProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.ucOfertasPorRenglonProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.ucOfertasPorRenglonProcesoCompra1.RENGLON = Me.ucRenglonesProcesoCompra1.RENGLON
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = True
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicada = False
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadAdjudicadaFirme = False
        Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.ucOfertasPorRenglonProcesoCompra1.CargarDatos()
    End Sub

    Protected Sub btnInformeEvaluacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInformeEvaluacion.Click
        Me.pnInformeEvaluacion.Visible = True

        Me.ucRenglonesProcesoCompra1.Visible = False

        Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.ucOfertasPorRenglonProcesoCompra1.Visible = False

        Me.UcAsignarCantidades1.LimpiarCantidades()
        Me.UcAsignarCantidades1.Visible = False

        Me.pnContratacion.Visible = False
        Me.pnLicitacion.Visible = False
        Me.pnCuadroEvaluacion.Visible = False
    End Sub

    Protected Sub UcOfertasPorRenglonProcesoCompra1_NoAdjudicar() Handles ucOfertasPorRenglonProcesoCompra1.NoAdjudicar
        Me.Panel2.Visible = True
        Me.txtObservacionNA.Text = Me.ucRenglonesProcesoCompra1.ObtenerObservacionRecomendacion
    End Sub

    Protected Sub VerRenglonesRecomendacion()

        Movimiento = 2

        Me.lblTipoEvaluacion.Visible = False
        Me.txtTipoEvaluacion.Visible = False

        Me.ucRenglonesProcesoCompra1.Visible = True
        Me.ucRenglonesProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.ucRenglonesProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")

        Me.ucRenglonesProcesoCompra1.IDESTADO = estadosRecomendacion
        Me.ucRenglonesProcesoCompra1.LimpiarRenglones()
        Me.ucRenglonesProcesoCompra1.CargarDatos()

        Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.ucOfertasPorRenglonProcesoCompra1.Visible = False

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
            PC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS
            PC.FECHAFINRECOMENDACION = DateTime.Now
            PC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            PC.AUFECHAMODIFICACION = Now
            PC.ESTASINCRONIZADA = 0

            'MOMENTO 1- RECOMENDACION
            cPC.ActualizarEstado(PC, 1, False)

            Confirm("El proceso de compras ha finalizado la evaluación y recomendación satisfactoriamente.  Desea generar el documento?", "Confirmar", OptionPostBack.YesNotPostBack)
            'Me.MsgBox2.ShowConfirm("El proceso de compras ha finalizado la evaluación y recomendación satisfactoriamente.  Desea generar el documento?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_PostBackOnNo)
        Else
            AlertSubmit("Queda(n) " + renglonesNoRecomendados.ToString + " renglon(es) sin recomendar.  No es posible finalizar la recomendación.", "Aviso")
            'Me.MsgBox2.ShowAlert("Queda(n) " + renglonesNoRecomendados.ToString + " renglon(es) sin recomendar.  No es posible finalizar la recomendación.", "I", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        End If
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
        Me.ucOfertasPorRenglonProcesoCompra1.Visible = True
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = False
        Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.ucOfertasPorRenglonProcesoCompra1.CargarDatos()

        Me.Button1.BackColor = Drawing.Color.LightCoral
        Me.Button2.BackColor = Drawing.Color.Empty
        Me.Button3.BackColor = Drawing.Color.Empty

        Me.Panel2.Visible = False

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
        Me.ucOfertasPorRenglonProcesoCompra1.Visible = True
        Me.ucOfertasPorRenglonProcesoCompra1.VerBotonNoAdjudicar = True
        Me.ucOfertasPorRenglonProcesoCompra1.VerCantidadRecomendada = (Movimiento = 2)
        Me.ucOfertasPorRenglonProcesoCompra1.LimpiarOfertas()
        Me.ucOfertasPorRenglonProcesoCompra1.CargarDatos()

        Me.Button1.BackColor = Drawing.Color.Empty
        Me.Button2.BackColor = Drawing.Color.LightCoral
        Me.Button3.BackColor = Drawing.Color.Empty
        'End If

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        pnLicitacion.Visible = False
        Me.UcAsignarCantidades1.Visible = False
        pnInformeEvaluacion.Visible = True
        Me.ucOfertasPorRenglonProcesoCompra1.Visible = False
        Me.btnHojaAnalisis.Visible = False

        Me.Button1.BackColor = Drawing.Color.Empty
        Me.Button2.BackColor = Drawing.Color.Empty
        Me.Button3.BackColor = Drawing.Color.LightCoral
    End Sub

    Protected Sub btnGONA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGONA.Click
        Dim cDPC As New cDETALLEPROCESOCOMPRA
        If Me.txtObservacionNA.Text = "" Then
            Alert("Falta agregar una observación.", "Error")
            'Me.MsgBox3.ShowAlert("Falta agregar una observación.", "P", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            Dim eDPC As New DETALLEPROCESOCOMPRA
            eDPC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            eDPC.IDPROCESOCOMPRA = Request.QueryString("idProc")
            eDPC.IDPRODUCTO = Me.ucOfertasPorRenglonProcesoCompra1.IDPRODUCTO
            eDPC.IDDETALLE = Me.ucOfertasPorRenglonProcesoCompra1.IDDETALLEPROCESOCOMPRA
            eDPC.OBSERVACIONRECOMENDACION = Me.txtObservacionNA.Text
            eDPC.AUUSUARIOMODIFICACION = User.Identity.Name
            eDPC.AUFECHAMODIFICACION = Now

            cDPC.ActualizarObservacionRecomendacion(eDPC)

            VerRenglonesRecomendacion()

            Me.txtObservacionNA.Text = ""
            Me.Panel2.Visible = False
        End If
    End Sub

    Protected Sub btnResumenProceso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResumenProceso.Click
        Dim dpc As New DETALLEPROCESOCOMPRA
        dpc.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        dpc.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.btnResumenProceso.Attributes.Add("onclick", SINAB_Utils.Utils.ReferirVentana("/uaci/frmConsultaPrecio.aspx"))
        '"window.open('" + Request.ApplicationPath + "/uaci/frmConsultaPrecio.aspx ','popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")


    End Sub

    Protected Sub btnInformeEvaluacionPorRenglon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInformeEvaluacionPorRenglon.Click
        Dim alerta As String
        Dim X As New cPROGRAMADISTRIBUCION
        If X.ObtenerAlmacenFosIsss(Session("IdEstablecimiento"), Request.QueryString("idProc")) = 0 Then
            'alerta = "<script language='JavaScript'>" & _
            '                             "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "&idA=0', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');" & _
            '                             "</script>"
            ''         "window.open('" & Request.ApplicationPath & "/Reportes/FrmRptConsolidadoDistribucion1.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "', 'ProgramacionPr', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _

            'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)

            SINAB_Utils.Utils.MostrarVentana("/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc"))
            Me.Panel3.Visible = False
            Me.Panel4.Visible = False
        Else
            Me.Panel3.Visible = True
            Me.Panel4.Visible = False
        End If
    End Sub

    Protected Sub btnInformeEvaluacionPorOferta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInformeEvaluacionPorOferta.Click
        Dim X As New cPROGRAMADISTRIBUCION
        If X.ObtenerAlmacenFosIsss(Session("IdEstablecimiento"), Request.QueryString("idProc")) = 0 Then
            'Dim alerta As String

            'alerta = "<script language='JavaScript'>" & _
            '         "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');" & _
            '         "</script>"
            ''         "window.open('" & Request.ApplicationPath & "/Reportes/FrmRptConsolidadoDistribucion1.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "', 'ProgramacionPr', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _

            'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)
            SINAB_Utils.Utils.MostrarVentana("/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc"))
            Me.Panel4.Visible = False
            Me.Panel3.Visible = False
        Else
            Me.Panel4.Visible = True
            Me.Panel3.Visible = False
        End If
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim alerta As String

        Select Case Me.RadioButtonList1.SelectedValue
            Case Is = 0
                'alerta = "<script language='JavaScript'>" & _
                '                "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "&idA=0', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');" & _
                '                "</script>"
                ''         "window.open('" & Request.ApplicationPath & "/Reportes/FrmRptConsolidadoDistribucion1.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "', 'ProgramacionPr', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _

                'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)
                MostrarVentana("/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "&idA=0")

            Case Is = 1
                'mspas
                'alerta = "<script language='JavaScript'>" & _
                '               "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "&idA=1', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');" & _
                '               "</script>"
                ''         "window.open('" & Request.ApplicationPath & "/Reportes/FrmRptConsolidadoDistribucion1.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "', 'ProgramacionPr', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _

                'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)
                MostrarVentana("/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "&idA=1")
            Case Is = 2
                'fosalud
                'alerta = "<script language='JavaScript'>" & _
                '               "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "&idA=114', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');" & _
                '               "</script>"
                ''         "window.open('" & Request.ApplicationPath & "/Reportes/FrmRptConsolidadoDistribucion1.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "', 'ProgramacionPr', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _

                'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)
                MostrarVentana("/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "&idA=114")
            Case Is = 3
                'isss
                'alerta = "<script language='JavaScript'>" & _
                '               "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "&idA=499', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');" & _
                '               "</script>"
                ''         "window.open('" & Request.ApplicationPath & "/Reportes/FrmRptConsolidadoDistribucion1.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "', 'ProgramacionPr', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _

                'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)
                MostrarVentana("/Reportes/FrmRptResolucionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "&idA=499")
        End Select
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim alerta As String

        Select Case Me.RadioButtonList2.SelectedValue
            Case Is = 0
                'alerta = "<script language='JavaScript'>" & _
                ' "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc") + "&idA=0', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');" & _
                ' "</script>"
                ''         "window.open('" & Request.ApplicationPath & "/Reportes/FrmRptConsolidadoDistribucion1.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "', 'ProgramacionPr', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _

                'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)
                MostrarVentana("/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc") + "&idA=0")
            Case Is = 1
                'MSPAS
                'alerta = "<script language='JavaScript'>" & _
                '                 "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc") + "&idA=1', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');" & _
                '                 "</script>"
                ''         "window.open('" & Request.ApplicationPath & "/Reportes/FrmRptConsolidadoDistribucion1.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "', 'ProgramacionPr', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _

                'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)
                MostrarVentana("/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc") + "&idA=1")
            Case Is = 2
                'FOSALUD
                'alerta = "<script language='JavaScript'>" & _
                '                              "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc") + "&idA=114', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');" & _
                '                              "</script>"
                ''         "window.open('" & Request.ApplicationPath & "/Reportes/FrmRptConsolidadoDistribucion1.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "', 'ProgramacionPr', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _

                'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)
                MostrarVentana("/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc") + "&idA=114")
            Case Is = 3
                'ISSS
                'alerta = "<script language='JavaScript'>" & _
                '                                             "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc") + "&idA=499', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');" & _
                '                                             "</script>"
                ''         "window.open('" & Request.ApplicationPath & "/Reportes/FrmRptConsolidadoDistribucion1.aspx?id=" & Me.dgLista.DataKeys(row.RowIndex).Values(0) & "', 'ProgramacionPr', 'menubar=0,toolbar=0,resizable=1,scrollbars=1, width=780, height=500');" & _

                'ClientScript.RegisterStartupScript(Page.GetType, "Startup", alerta)
                MostrarVentana("/Reportes/FrmRptValorizacionPorRenglon2.aspx?id=" + Request.QueryString("idProc") + "&idA=499")
        End Select
    End Sub
End Class
