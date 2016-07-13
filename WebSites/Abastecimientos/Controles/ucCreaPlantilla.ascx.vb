Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Controles_ucCreaPlantilla
    Inherits System.Web.UI.UserControl

    Private _tipoTransac As String

    Public Property tipoTransac() As String
        Get
            Return _tipoTransac
        End Get
        Set(ByVal value As String)
            _tipoTransac = value
            If Not Me.ViewState("tipoTransac") Is Nothing Then Me.ViewState.Remove("tipoTransac")
            Me.ViewState.Add("tipoTransac", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.tipoTransac = "LISTA"
            Me.pnlLicitacion.Visible = True
        Else
            If Not Me.ViewState("tipoTransac") Is Nothing Then Me._tipoTransac = Me.ViewState("tipoTransac")
        End If

        If Me.tipoTransac = "LISTA" Then
            With UcBarraNavegacion2
                .HabilitarEdicion(False)
                .PermitirAgregar = False
                .PermitirConsultar = False
                .PermitirEditar = False
                .PermitirGuardar = False
                .PermitirImprimir = False
                .Navegacion = False
            End With
        End If

    End Sub

    Public Sub obtenerListaPlantillas()
        Dim mComponente As New cPLANTILLAS
        Me.dgPlantilla.DataSource = mComponente.ObtenerDataSetPorId()
        Me.dgPlantilla.DataBind()
    End Sub

    Protected Sub dgEtiqueta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEtiqueta.SelectedIndexChanged
        Dim textoPlantilla As New Text.StringBuilder
        Windows.Forms.Clipboard.SetDataObject(Me.dgEtiqueta.SelectedItem.Cells(1).Text, True)
        Me.rtePlantilla.Text = textoPlantilla.ToString
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim mComponente As New cPLANTILLAS
        Dim lEntidad As New PLANTILLAS

        With lEntidad
            .CODIGOFUENTE = Me.rtePlantilla.Text
            .NOMBRE = Me.txtPlantilla.Text
            .IDTIPOCOMPRA = Me.DdlMODALIDADESCOMPRA1.SelectedValue
            .IDPLANTILLA = Me.ViewState("idPlantillaSel")
        End With

        Try
            If Me.tipoTransac = "NEW" Then
                lEntidad.IDPLANTILLA = 0
                mComponente.ActualizarPLANTILLAS(lEntidad)
                Me.ViewState("idPlantillaSel") = lEntidad.IDPLANTILLA
                Me.tipoTransac = "EDIT"
            Else
                mComponente.ActualizarPLANTILLAS(lEntidad)
            End If
            Me.MsgBox1.ShowAlert("La plantilla se guardó satisfactoriamente", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Catch ex As Exception
            Me.MsgBox1.ShowAlert(ex.Message, "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End Try

    End Sub

    Protected Sub dgPlantilla_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgPlantilla.PageIndexChanged
        Me.dgPlantilla.CurrentPageIndex = e.NewPageIndex
        obtenerListaPlantillas()
    End Sub

    Protected Sub dgPlantilla_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPlantilla.SelectedIndexChanged
        Me.ViewState("idPlantillaSel") = Me.dgPlantilla.SelectedItem.Cells(2).Text
        Me.pnlListaPlantilla.Visible = False
        Me.pnlDetPlantilla.Visible = True
        Me.btnGuardarComo.Visible = True
        'Me.btnGuardar.Text = "Modificar"
        Me.tipoTransac = "EDIT"
        'If Not IsPostBack Then
        obtenerDatos()
        'End If
    End Sub

    Private Sub obtenerDatos()
        Dim mComponente As New cETIQUETASCAMPOS
        Dim lEntidad As New ETIQUETASCAMPOS
        Dim mComPlantilla As New cPLANTILLAS
        Dim dsPlantilla As Data.DataSet
        Me.DdlMODALIDADESCOMPRA1.Recuperar()
        dsPlantilla = mComPlantilla.ObtenerDataSetPlantillas(Me.ViewState("idPlantillaSel"))
        If dsPlantilla.Tables(0).Rows.Count > 0 Then
            Me.rtePlantilla.Text = dsPlantilla.Tables(0).Rows(0).Item("CODIGOFUENTE")
            Me.txtPlantilla.Text = dsPlantilla.Tables(0).Rows(0).Item("NOMBRE")
        End If

        If Me.tipoTransac = "EDIT" Then
            Me.DdlMODALIDADESCOMPRA1.SelectedValue = dsPlantilla.Tables(0).Rows(0).Item("IDTIPOCOMPRA")
            Select Case dsPlantilla.Tables(0).Rows(0).Item("IDTIPOCOMPRA").ToString
                Case Is = 1
                    Me.pnlLicitacion.Visible = True
                    Me.pnlLibreGestion.Visible = False
                    Me.pnlContratacionDirecta.Visible = False
                Case Is = 2
                    Me.pnlLicitacion.Visible = False
                    Me.pnlLibreGestion.Visible = True
                    Me.pnlContratacionDirecta.Visible = False
                Case Is = 3
                    Me.pnlLicitacion.Visible = False
                    Me.pnlLibreGestion.Visible = False
                    Me.pnlContratacionDirecta.Visible = True
            End Select
        End If

        Me.dgEstablecimiento.DataSource = (mComponente.ObtenerDataSetPorTABLA("ESTABLECIMIENTO"))
        Me.dgEstablecimiento.DataBind()

        Me.dgEtiqueta.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROCESOCOMPRAS"))
        Me.dgEtiqueta.DataBind()

        Me.dgEtiquetaLG.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROCESOCOMPRAS_LG"))
        Me.dgEtiquetaLG.DataBind()

        Me.dgEtiquetaCD.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROCESOCOMPRAS_CD"))
        Me.dgEtiquetaCD.DataBind()

        Me.dgDocumentos.DataSource = (mComponente.ObtenerDataSetPorTABLA("DOCUMENTOS"))
        Me.dgDocumentos.DataBind()

        Me.dgCriterios.DataSource = (mComponente.ObtenerDataSetPorTABLA("CRITERIOS"))
        Me.dgCriterios.DataBind()

        Me.dgCriterioLG.DataSource = (mComponente.ObtenerDataSetPorTABLA("CRITERIO_LG"))
        Me.dgCriterioLG.DataBind()

        Me.dgCriterio_Tecnico.DataSource = (mComponente.ObtenerDataSetPorTABLA("CRITERIO_TEC"))
        Me.dgCriterio_Tecnico.DataBind()

        Me.dgCriterio_Financiero.DataSource = (mComponente.ObtenerDataSetPorTABLA("CRITERIO_FIN"))
        Me.dgCriterio_Financiero.DataBind()

        Me.dgGarantiaMnttoOferta.DataSource = (mComponente.ObtenerDataSetPorTABLA("GARANTIAMANTTOOFERTA"))
        Me.dgGarantiaMnttoOferta.DataBind()


        Me.dgGarantiaAnticipo.DataSource = (mComponente.ObtenerDataSetPorTABLA("GARANTIAANTICIPO"))
        Me.dgGarantiaAnticipo.DataBind()

        Me.dgBuenaCalidad.DataSource = (mComponente.ObtenerDataSetPorTABLA("GARANTIABUENACALIDAD"))
        Me.dgBuenaCalidad.DataBind()

        Me.dgCumplimientoContrato.DataSource = (mComponente.ObtenerDataSetPorTABLA("GARANTIACUMPLIMIENTO"))
        Me.dgCumplimientoContrato.DataBind()


        Me.dgProductos.DataSource = (mComponente.ObtenerDataSetPorTABLA("PRODUCTOS"))
        Me.dgProductos.DataBind()

        Me.dgProductosLG.DataSource = (mComponente.ObtenerDataSetPorTABLA("PRODUCTOS_LG"))
        Me.dgProductosLG.DataBind()

        Me.dgProductosCD.DataSource = (mComponente.ObtenerDataSetPorTABLA("PRODUCTOS_CD"))
        Me.dgProductosCD.DataBind()

        Me.dgEntregas.DataSource = (mComponente.ObtenerDataSetPorTABLA("ENTREGAS"))
        Me.dgEntregas.DataBind()

        Me.dgEntregaLG.DataSource = (mComponente.ObtenerDataSetPorTABLA("ENTREGAS_LG"))
        Me.dgEntregaLG.DataBind()

        Me.dgEntregaCD.DataSource = (mComponente.ObtenerDataSetPorTABLA("ENTREGAS_CD"))
        Me.dgEntregaCD.DataBind()

        Me.dgProgramaDistribucion.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROGRAMA_DISTRIBUCION"))
        Me.dgProgramaDistribucion.DataBind()

        Me.dgDistribucionLG.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROGRAMA_DISTRIBUCION_LG"))
        Me.dgDistribucionLG.DataBind()

        Me.dgDistribucionCD.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROGRAMA_DISTRIBUCION_CD"))
        Me.dgDistribucionCD.DataBind()


        With Me.UcBarraNavegacion2
            .HabilitarEdicion(True)
            .PermitirEditar = True
            .PermitirAgregar = False
            .PermitirConsultar = False
            .PermitirGuardar = False
            .PermitirImprimir = False
            .Navegacion = False
        End With

    End Sub

    Protected Sub btnPlantillas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPlantillas.Click
        pnlDetPlantilla.Visible = False
        pnlListaPlantilla.Visible = True
        UcBarraNavegacion2.Visible = False
    End Sub

    Protected Sub UcBarraNavegacion2_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion2.Cancelar
        Me.tipoTransac = "LISTA"
        Me.pnlListaPlantilla.Visible = True
        Me.pnlDetPlantilla.Visible = False
        Me.UcBarraNavegacion2.PermitirEditar = False
        Me.UcBarraNavegacion2.HabilitarEdicion(False)
        obtenerListaPlantillas()
        'Me.tipoTransac = "NEW"
        'Me.btnGuardar.Text = "Guardar"
        'Me.btnGuardarComo.Visible = False
        'obtenerDatos()
        'Me.DdlMODALIDADESCOMPRA1.Recuperar()
        'Me.rtePlantilla.Text = ""
        'Me.txtPlantilla.Text = ""
    End Sub

    Protected Sub btnGuardarComo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarComo.Click
        Dim mComponente As New cPLANTILLAS
        Dim lEntidad As New PLANTILLAS

        With lEntidad
            .CODIGOFUENTE = Me.rtePlantilla.Text
            .NOMBRE = Me.txtPlantilla.Text
            .IDTIPOCOMPRA = 1
            '.IDPLANTILLA = Me.idPlantillaSel
        End With

        'validar nombre ya existe
        If mComponente.ExisteNombrePlantilla(lEntidad.NOMBRE) Then
            Me.MsgBox1.ShowAlert("Debe elegir un nombre diferente para la plantilla.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            Try
                Me.ViewState("idPlantillaSel") = mComponente.ActualizarPLANTILLAS(lEntidad)
                Me.MsgBox1.ShowAlert("La plantilla se guardo satisfactoriamente", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Catch ex As Exception
                Me.MsgBox1.ShowAlert(ex.Message, "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End Try
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.pnlListaPlantilla.Visible = False
        Me.pnlDetPlantilla.Visible = True
        Me.tipoTransac = "NEW"
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardarComo.Visible = False
        obtenerDatos()
        Me.DdlMODALIDADESCOMPRA1.Recuperar()
        Me.rtePlantilla.Text = ""
        Me.txtPlantilla.Text = ""
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        'Me.MsgBox1.ShowConfirm("¿Desea eliminar la plantilla?", "ELIMINAR", Cooperator.Framework.Web.Controls.ConfirmOption.CallBackOnYes_CallBackOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        eliminaDocumentos()
        eliminaCriterioPlantilla()
        Dim mComponente As New cPLANTILLAS
        mComponente.EliminarPLANTILLAS(Me.ViewState("idPlantillaSel"))
        Me.tipoTransac = "LISTA"
        Me.pnlListaPlantilla.Visible = True
        Me.pnlDetPlantilla.Visible = False
        obtenerListaPlantillas()
        Me.UcBarraNavegacion2.PermitirEditar = False
        Me.UcBarraNavegacion2.HabilitarEdicion(False)

    End Sub

    Private Sub eliminaDocumentos()
        Dim mComponente As New cDOCUMENTOSBASEPLANTILLA
        mComponente.EliminarPorPLANTILLA(Me.ViewState("idPlantillaSel"))
    End Sub

    Private Sub eliminaCriterioPlantilla()
        Dim mComponente As New cCRITERIOSPLANTILLAS
        mComponente.eliminaPorPlantilla(Me.ViewState("idPlantillaSel"))
    End Sub

    Protected Sub lbGeneral_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbGeneral.Click
        Me.dgEstablecimiento.Visible = False
        Me.dgEtiqueta.Visible = True
        Me.dgCriterio_Financiero.Visible = False
        Me.dgCriterio_Tecnico.Visible = False
        Me.dgDocumentos.Visible = False
        Me.dgCriterios.Visible = False
        Me.dgGarantiaMnttoOferta.Visible = False
        Me.dgGarantiaAnticipo.Visible = False
        Me.dgCumplimientoContrato.Visible = False
        Me.dgBuenaCalidad.Visible = False
        Me.dgProductos.Visible = False
        Me.dgEntregas.Visible = False
        Me.dgProgramaDistribucion.Visible = False
    End Sub

    Protected Sub lbDocumentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbDocumentos.Click
        Me.dgDocumentos.Visible = True
        Me.dgEstablecimiento.Visible = False
        Me.dgCriterio_Financiero.Visible = False
        Me.dgCriterio_Tecnico.Visible = False
        Me.dgEtiqueta.Visible = False
        Me.dgCriterios.Visible = False
        Me.dgGarantiaMnttoOferta.Visible = False
        Me.dgGarantiaAnticipo.Visible = False
        Me.dgCumplimientoContrato.Visible = False
        Me.dgBuenaCalidad.Visible = False
        Me.dgProductos.Visible = False
        Me.dgEntregas.Visible = False
        Me.dgProgramaDistribucion.Visible = False
    End Sub

    Protected Sub lbCriterios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbCriterios.Click
        Me.dgCriterios.Visible = True
        Me.dgEstablecimiento.Visible = False
        Me.dgCriterio_Financiero.Visible = True
        Me.dgCriterio_Tecnico.Visible = True
        Me.dgDocumentos.Visible = False
        Me.dgEtiqueta.Visible = False
        Me.dgCumplimientoContrato.Visible = False
        Me.dgBuenaCalidad.Visible = False
        Me.dgGarantiaMnttoOferta.Visible = False
        Me.dgGarantiaAnticipo.Visible = False
        Me.dgProductos.Visible = False
        Me.dgEntregas.Visible = False
        Me.dgProgramaDistribucion.Visible = False
    End Sub

    Protected Sub lbGarantias_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbGarantias.Click
        Me.dgEstablecimiento.Visible = False
        Me.dgCriterios.Visible = False
        Me.dgCriterio_Financiero.Visible = False
        Me.dgCriterio_Tecnico.Visible = False
        Me.dgDocumentos.Visible = False
        Me.dgEtiqueta.Visible = False
        Me.dgGarantiaMnttoOferta.Visible = True
        Me.dgGarantiaAnticipo.Visible = True
        Me.dgCumplimientoContrato.Visible = True
        Me.dgBuenaCalidad.Visible = True
        Me.dgProductos.Visible = False
        Me.dgEntregas.Visible = False
        Me.dgProgramaDistribucion.Visible = False
    End Sub

    Protected Sub lbProductos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbProductos.Click
        Me.dgEstablecimiento.Visible = False
        Me.dgCriterios.Visible = False
        Me.dgEstablecimiento.Visible = False
        Me.dgCriterio_Financiero.Visible = False
        Me.dgCriterio_Tecnico.Visible = False
        Me.dgDocumentos.Visible = False
        Me.dgGarantiaAnticipo.Visible = False
        Me.dgEtiqueta.Visible = False
        Me.dgGarantiaMnttoOferta.Visible = False
        Me.dgCumplimientoContrato.Visible = False
        Me.dgBuenaCalidad.Visible = False
        Me.dgProductos.Visible = True
        Me.dgEntregas.Visible = False
        Me.dgProgramaDistribucion.Visible = False
    End Sub

    Protected Sub lbPlazoEntrega_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbPlazoEntrega.Click
        Me.dgEstablecimiento.Visible = False
        Me.dgCriterios.Visible = False
        Me.dgEstablecimiento.Visible = False
        Me.dgCriterio_Financiero.Visible = False
        Me.dgCriterio_Tecnico.Visible = False
        Me.dgDocumentos.Visible = False
        Me.dgEtiqueta.Visible = False
        Me.dgGarantiaAnticipo.Visible = False
        Me.dgGarantiaMnttoOferta.Visible = False
        Me.dgCumplimientoContrato.Visible = False
        Me.dgBuenaCalidad.Visible = False
        Me.dgProductos.Visible = False
        Me.dgEntregas.Visible = True
        Me.dgProgramaDistribucion.Visible = False
    End Sub

    Protected Sub dgDocumentos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDocumentos.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgDocumentos.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla

    End Sub

    Protected Sub dgCriterios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCriterios.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgCriterios.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgGarantiaMnttoOferta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgGarantiaMnttoOferta.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgGarantiaMnttoOferta.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgCumplimientoContrato_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCumplimientoContrato.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgCumplimientoContrato.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgBuenaCalidad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgBuenaCalidad.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgBuenaCalidad.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgProductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProductos.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgProductos.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgEntregas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEntregas.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgEntregas.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgCriterio_Tecnico_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCriterio_Tecnico.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgCriterio_Tecnico.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgCriterio_Financiero_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCriterio_Financiero.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgCriterio_Financiero.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.dgEstablecimiento.Visible = False
        Me.dgProgramaDistribucion.Visible = True
        Me.dgCriterios.Visible = False
        Me.dgCriterio_Financiero.Visible = False
        Me.dgCriterio_Tecnico.Visible = False
        Me.dgGarantiaAnticipo.Visible = False
        Me.dgDocumentos.Visible = False
        Me.dgEtiqueta.Visible = False
        Me.dgGarantiaMnttoOferta.Visible = False
        Me.dgCumplimientoContrato.Visible = False
        Me.dgBuenaCalidad.Visible = False
        Me.dgProductos.Visible = False
        Me.dgEntregas.Visible = False
    End Sub

    Protected Sub dgProgramaDistribucion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProgramaDistribucion.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgProgramaDistribucion.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub DdlTIPOCOMPRAS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlTIPOCOMPRAS1.SelectedIndexChanged
        Me.lblEtiqueta.Visible = True
        Select Case Me.DdlMODALIDADESCOMPRA1.SelectedValue
            Case Is = 1
                Me.pnlLicitacion.Visible = True
                Me.pnlLibreGestion.Visible = False
                Me.pnlContratacionDirecta.Visible = False
            Case Is = 2
                Me.pnlLicitacion.Visible = False
                Me.pnlLibreGestion.Visible = True
                Me.pnlContratacionDirecta.Visible = False
            Case Is = 3
                Me.pnlLicitacion.Visible = False
                Me.pnlLibreGestion.Visible = False
                Me.pnlContratacionDirecta.Visible = True
        End Select
    End Sub

    Protected Sub DdlMODALIDADESCOMPRA1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlMODALIDADESCOMPRA1.SelectedIndexChanged
        Me.lblEtiqueta.Visible = True
        Select Case Me.DdlMODALIDADESCOMPRA1.SelectedValue
            Case Is = 1
                Me.pnlLicitacion.Visible = True
                Me.pnlLibreGestion.Visible = False
                Me.pnlContratacionDirecta.Visible = False
            Case Is = 2
                Me.pnlLicitacion.Visible = False
                Me.pnlLibreGestion.Visible = True
                Me.pnlContratacionDirecta.Visible = False
            Case Is = 3
                Me.pnlLicitacion.Visible = False
                Me.pnlLibreGestion.Visible = False
                Me.pnlContratacionDirecta.Visible = True
        End Select
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Me.dgEtiquetaLG.Visible = True
        Me.dgCriterioLG.Visible = False
        Me.dgProductosLG.Visible = False
        Me.dgEntregaLG.Visible = False
        Me.dgDistribucionLG.Visible = False
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        Me.dgEtiquetaLG.Visible = False
        Me.dgCriterioLG.Visible = True
        Me.dgProductosLG.Visible = False
        Me.dgEntregaLG.Visible = False
        Me.dgDistribucionLG.Visible = False
    End Sub

    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click
        Me.dgEtiquetaLG.Visible = False
        Me.dgCriterioLG.Visible = False
        Me.dgProductosLG.Visible = True
        Me.dgEntregaLG.Visible = False
        Me.dgDistribucionLG.Visible = False
    End Sub

    Protected Sub LinkButton7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton7.Click
        Me.dgEtiquetaLG.Visible = False
        Me.dgCriterioLG.Visible = False
        Me.dgProductosLG.Visible = False
        Me.dgEntregaLG.Visible = True
        Me.dgDistribucionLG.Visible = False
    End Sub

    Protected Sub LinkButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton8.Click
        Me.dgEtiquetaLG.Visible = False
        Me.dgCriterioLG.Visible = False
        Me.dgProductosLG.Visible = False
        Me.dgEntregaLG.Visible = False
        Me.dgDistribucionLG.Visible = True
    End Sub

    Protected Sub LinkButton9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton9.Click
        Me.dgEtiquetaCD.Visible = True

        Me.dgProductosCD.Visible = False
        Me.dgEntregaCD.Visible = False
        Me.dgDistribucionCD.Visible = False
    End Sub

    Protected Sub LinkButton13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton13.Click
        Me.dgEtiquetaCD.Visible = False

        Me.dgProductosCD.Visible = True
        Me.dgEntregaCD.Visible = False
        Me.dgDistribucionCD.Visible = False
    End Sub

    Protected Sub LinkButton14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton14.Click
        Me.dgEtiquetaCD.Visible = False

        Me.dgProductosCD.Visible = False
        Me.dgEntregaCD.Visible = True
        Me.dgDistribucionCD.Visible = False
    End Sub

    Protected Sub LinkButton15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton15.Click
        Me.dgEtiquetaCD.Visible = False

        Me.dgProductosCD.Visible = False
        Me.dgEntregaCD.Visible = False
        Me.dgDistribucionCD.Visible = True
    End Sub

    Protected Sub dgEtiquetaLG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEtiquetaLG.SelectedIndexChanged
        Dim textoPlantilla As New Text.StringBuilder

        Windows.Forms.Clipboard.SetDataObject(Me.dgEtiquetaLG.SelectedItem.Cells(1).Text, True)

        Me.rtePlantilla.Text = textoPlantilla.ToString

    End Sub

    Protected Sub dgCriterioLG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCriterioLG.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgCriterioLG.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla

    End Sub

    Protected Sub dgProductosLG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProductosLG.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgProductosLG.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgProductosCD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProductosCD.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgProductosCD.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgEntregaLG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEntregaLG.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgEntregaLG.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgEntregaCD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEntregaCD.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgEntregaCD.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgDistribucionLG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDistribucionLG.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgDistribucionLG.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub dgDistribucionCD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDistribucionCD.SelectedIndexChanged
        Dim textoPlantilla As String

        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgDistribucionCD.SelectedItem.Cells(1).Text
        Me.rtePlantilla.Text = textoPlantilla
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Me.dgEstablecimiento.Visible = True
        Me.dgEtiqueta.Visible = False
        Me.dgCriterio_Financiero.Visible = False
        Me.dgCriterio_Tecnico.Visible = False
        Me.dgDocumentos.Visible = False
        Me.dgCriterios.Visible = False
        Me.dgGarantiaMnttoOferta.Visible = False
        Me.dgCumplimientoContrato.Visible = False
        Me.dgBuenaCalidad.Visible = False
        Me.dgProductos.Visible = False
        Me.dgEntregas.Visible = False
        Me.dgProgramaDistribucion.Visible = False
    End Sub

End Class
