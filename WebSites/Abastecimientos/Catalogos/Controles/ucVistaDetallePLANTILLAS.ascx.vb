Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucVistaDetallePLANTILLAS
    Inherits System.Web.UI.UserControl

    Private _IDPLANTILLA As Int16
    Private _AUUSUARIOCREACION As String
    Private _AUFECHACREACION As DateTime
    Private _TIPOPLANTILLA As Int16

    Private _sError As String
    Private _nuevo As Boolean = False

    Private mComponente As New cPLANTILLAS
    Private mEntidad As PLANTILLAS

    Public Event ErrorEvent(ByVal errorMessage As String)

#Region " Propiedades "

    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal value As Boolean)
            Me.HabilitarEdicion(value)
        End Set
    End Property

    Public ReadOnly Property sError() As String
        Get
            Return _sError
        End Get
    End Property

    Public Property IDPLANTILLA() As Int16
        Get
            Return _IDPLANTILLA
        End Get
        Set(ByVal value As Int16)
            Me._IDPLANTILLA = value
            Me.CargarDDLs()
            If Me._IDPLANTILLA > 0 Then
                Me.CargarDatos()
            Else
                Me.Nuevo()
            End If
            If Not Me.ViewState("IDPLANTILLA") Is Nothing Then Me.ViewState.Remove("IDPLANTILLA")
            Me.ViewState.Add("IDPLANTILLA", value)
        End Set
    End Property

    Public Property AUUSUARIOCREACION() As String
        Get
            Return Me._AUUSUARIOCREACION
        End Get
        Set(ByVal value As String)
            Me._AUUSUARIOCREACION = value
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me.ViewState.Remove("AUUSUARIOCREACION")
            Me.ViewState.Add("AUUSUARIOCREACION", value)
        End Set
    End Property

    Public Property AUFECHACREACION() As DateTime
        Get
            Return Me._AUFECHACREACION
        End Get
        Set(ByVal value As DateTime)
            Me._AUFECHACREACION = value
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me.ViewState.Remove("AUFECHACREACION")
            Me.ViewState.Add("AUFECHACREACION", value)
        End Set
    End Property

    Public Property TIPOPLANTILLA() As Int16
        Get
            Return _TIPOPLANTILLA
        End Get
        Set(ByVal value As Int16)
            Me._TIPOPLANTILLA = value
            If Not Me.ViewState("TIPOPLANTILLA") Is Nothing Then Me.ViewState.Remove("TIPOPLANTILLA")
            Me.ViewState.Add("TIPOPLANTILLA", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("nuevo") Is Nothing Then Me._nuevo = Me.ViewState("nuevo")
            If Not Me.ViewState("IDPLANTILLA") Is Nothing Then Me._IDPLANTILLA = Me.ViewState("IDPLANTILLA")
            If Not Me.ViewState("AUUSUARIOCREACION") Is Nothing Then Me._AUUSUARIOCREACION = Me.ViewState("AUUSUARIOCREACION")
            If Not Me.ViewState("AUFECHACREACION") Is Nothing Then Me._AUFECHACREACION = Me.ViewState("AUFECHACREACION")
            If Not Me.ViewState("TIPOPLANTILLA") Is Nothing Then Me._TIPOPLANTILLA = Me.ViewState("TIPOPLANTILLA")
        End If

    End Sub

    Private Sub CargarDatos()

        mEntidad = New PLANTILLAS

        mEntidad.IDPLANTILLA = IDPLANTILLA

        If mComponente.ObtenerPLANTILLAS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener el registro.")
            Return
        End If

        Me.ddlMODALIDADESCOMPRA1.SelectedValue = mEntidad.IDTIPOCOMPRA
        Me.txtNOMBRE.Text = mEntidad.NOMBRE
        Me.rteCODIGOFUENTE.Text = mEntidad.CODIGOFUENTE
        Me.TIPOPLANTILLA = mEntidad.TIPOPLANTILLA

        Me.AUUSUARIOCREACION = mEntidad.AUUSUARIOCREACION
        Me.AUFECHACREACION = mEntidad.AUFECHACREACION

    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        Me.ddlMODALIDADESCOMPRA1.Enabled = edicion
        Me.txtNOMBRE.Enabled = edicion
        Me.rteCODIGOFUENTE.ReadOnly = Not edicion
        Me.rteCODIGOFUENTE.HideToolBars = Not edicion
    End Sub

    Private Sub Nuevo()

        Me._nuevo = True

        If Me.ViewState("nuevo") Is Nothing Then
            Me.ViewState.Add("nuevo", Me._nuevo)
        Else
            Me.ViewState("nuevo") = Me._nuevo
        End If

    End Sub

    Public Function Actualizar() As String

        mEntidad = New PLANTILLAS

        If Me._nuevo Then
            mEntidad.IDPLANTILLA = 0
            mEntidad.TIPOPLANTILLA = Nothing
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
        Else
            mEntidad.IDPLANTILLA = Me.IDPLANTILLA
            mEntidad.TIPOPLANTILLA = Me.TIPOPLANTILLA
            mEntidad.AUUSUARIOCREACION = Me.AUUSUARIOCREACION
            mEntidad.AUFECHACREACION = Me.AUFECHACREACION
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
        End If

        mEntidad.IDTIPOCOMPRA = Me.ddlMODALIDADESCOMPRA1.SelectedValue
        mEntidad.NOMBRE = Me.txtNOMBRE.Text
        mEntidad.CODIGOFUENTE = Me.rteCODIGOFUENTE.Text
        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarPLANTILLAS(mEntidad) = 1 Then
            Return ""
        Else
            Return "Error al guardar el registro."
        End If

    End Function

    Private Sub CargarDDLs()
        Me.ddlMODALIDADESCOMPRA1.Recuperar()
    End Sub

    '#Region " Plantillas "

    '    Protected Sub DdlMODALIDADESCOMPRA1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMODALIDADESCOMPRA1.SelectedIndexChanged
    '        Me.lblEtiqueta.Visible = True
    '        Select Case Me.ddlMODALIDADESCOMPRA1.SelectedValue
    '            Case Is = 1
    '                Me.pnlLicitacion.Visible = True
    '                Me.pnlLibreGestion.Visible = False
    '                Me.pnlContratacionDirecta.Visible = False
    '            Case Is = 2
    '                Me.pnlLicitacion.Visible = False
    '                Me.pnlLibreGestion.Visible = True
    '                Me.pnlContratacionDirecta.Visible = False
    '            Case Is = 3
    '                Me.pnlLicitacion.Visible = False
    '                Me.pnlLibreGestion.Visible = False
    '                Me.pnlContratacionDirecta.Visible = True
    '        End Select
    '    End Sub

    '    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
    '        Me.dgEtiquetaLG.Visible = True
    '        Me.dgCriterioLG.Visible = False
    '        Me.dgProductosLG.Visible = False
    '        Me.dgEntregaLG.Visible = False
    '        Me.dgDistribucionLG.Visible = False
    '    End Sub

    '    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
    '        Me.dgEtiquetaLG.Visible = False
    '        Me.dgCriterioLG.Visible = True
    '        Me.dgProductosLG.Visible = False
    '        Me.dgEntregaLG.Visible = False
    '        Me.dgDistribucionLG.Visible = False
    '    End Sub

    '    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click
    '        Me.dgEtiquetaLG.Visible = False
    '        Me.dgCriterioLG.Visible = False
    '        Me.dgProductosLG.Visible = True
    '        Me.dgEntregaLG.Visible = False
    '        Me.dgDistribucionLG.Visible = False
    '    End Sub

    '    Protected Sub LinkButton7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton7.Click
    '        Me.dgEtiquetaLG.Visible = False
    '        Me.dgCriterioLG.Visible = False
    '        Me.dgProductosLG.Visible = False
    '        Me.dgEntregaLG.Visible = True
    '        Me.dgDistribucionLG.Visible = False
    '    End Sub

    '    Protected Sub LinkButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton8.Click
    '        Me.dgEtiquetaLG.Visible = False
    '        Me.dgCriterioLG.Visible = False
    '        Me.dgProductosLG.Visible = False
    '        Me.dgEntregaLG.Visible = False
    '        Me.dgDistribucionLG.Visible = True
    '    End Sub

    '    Protected Sub LinkButton9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton9.Click
    '        Me.dgEtiquetaCD.Visible = True

    '        Me.dgProductosCD.Visible = False
    '        Me.dgEntregaCD.Visible = False
    '        Me.dgDistribucionCD.Visible = False
    '    End Sub

    '    Protected Sub LinkButton13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton13.Click
    '        Me.dgEtiquetaCD.Visible = False

    '        Me.dgProductosCD.Visible = True
    '        Me.dgEntregaCD.Visible = False
    '        Me.dgDistribucionCD.Visible = False
    '    End Sub

    '    Protected Sub LinkButton14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton14.Click
    '        Me.dgEtiquetaCD.Visible = False

    '        Me.dgProductosCD.Visible = False
    '        Me.dgEntregaCD.Visible = True
    '        Me.dgDistribucionCD.Visible = False
    '    End Sub

    '    Protected Sub LinkButton15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton15.Click
    '        Me.dgEtiquetaCD.Visible = False

    '        Me.dgProductosCD.Visible = False
    '        Me.dgEntregaCD.Visible = False
    '        Me.dgDistribucionCD.Visible = True
    '    End Sub

    '    Protected Sub dgEtiquetaLG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEtiquetaLG.SelectedIndexChanged
    '        Dim textoPlantilla As New Text.StringBuilder

    '        Windows.Forms.Clipboard.SetDataObject(Me.dgEtiquetaLG.SelectedItem.Cells(1).Text, True)

    '        Me.rtePlantilla.Text = textoPlantilla.ToString

    '    End Sub

    '    Protected Sub dgCriterioLG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCriterioLG.SelectedIndexChanged
    '        Dim textoPlantilla As String

    '        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgCriterioLG.SelectedItem.Cells(1).Text
    '        Me.rtePlantilla.Text = textoPlantilla

    '    End Sub

    '    Protected Sub dgProductosLG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProductosLG.SelectedIndexChanged
    '        Dim textoPlantilla As String

    '        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgProductosLG.SelectedItem.Cells(1).Text
    '        Me.rtePlantilla.Text = textoPlantilla
    '    End Sub

    '    Protected Sub dgProductosCD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProductosCD.SelectedIndexChanged
    '        Dim textoPlantilla As String

    '        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgProductosCD.SelectedItem.Cells(1).Text
    '        Me.rtePlantilla.Text = textoPlantilla
    '    End Sub

    '    Protected Sub dgEntregaLG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEntregaLG.SelectedIndexChanged
    '        Dim textoPlantilla As String

    '        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgEntregaLG.SelectedItem.Cells(1).Text
    '        Me.rtePlantilla.Text = textoPlantilla
    '    End Sub

    '    Protected Sub dgEntregaCD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgEntregaCD.SelectedIndexChanged
    '        Dim textoPlantilla As String

    '        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgEntregaCD.SelectedItem.Cells(1).Text
    '        Me.rtePlantilla.Text = textoPlantilla
    '    End Sub

    '    Protected Sub dgDistribucionLG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDistribucionLG.SelectedIndexChanged
    '        Dim textoPlantilla As String

    '        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgDistribucionLG.SelectedItem.Cells(1).Text
    '        Me.rtePlantilla.Text = textoPlantilla
    '    End Sub

    '    Protected Sub dgDistribucionCD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDistribucionCD.SelectedIndexChanged
    '        Dim textoPlantilla As String

    '        textoPlantilla = Me.rtePlantilla.Text & " " & Me.dgDistribucionCD.SelectedItem.Cells(1).Text
    '        Me.rtePlantilla.Text = textoPlantilla
    '    End Sub

    '    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
    '        Me.dgEstablecimiento.Visible = True
    '        Me.dgEtiqueta.Visible = False
    '        Me.dgCriterio_Financiero.Visible = False
    '        Me.dgCriterio_Tecnico.Visible = False
    '        Me.dgDocumentos.Visible = False
    '        Me.dgCriterios.Visible = False
    '        Me.dgGarantiaMnttoOferta.Visible = False
    '        Me.dgCumplimientoContrato.Visible = False
    '        Me.dgBuenaCalidad.Visible = False
    '        Me.dgProductos.Visible = False
    '        Me.dgEntregas.Visible = False
    '        Me.dgProgramaDistribucion.Visible = False
    '    End Sub

    '    Protected Sub btnGuardarComo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardarComo.Click
    '        Dim mComponente As New cPLANTILLAS
    '        Dim lEntidad As New PLANTILLAS

    '        With lEntidad
    '            .CODIGOFUENTE = Me.rtePlantilla.Text
    '            .NOMBRE = Me.txtPlantilla.Text
    '            .IDTIPOCOMPRA = 1
    '            '.IDPLANTILLA = Me.idPlantillaSel
    '        End With

    '        'validar nombre ya existe
    '        If mComponente.ExisteNombrePlantilla(lEntidad.NOMBRE) Then
    '            Me.MsgBox1.ShowAlert("Debe elegir un nombre diferente para la plantilla.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        Else
    '            Try
    '                Me.ViewState("idPlantillaSel") = mComponente.ActualizarPLANTILLAS(lEntidad)
    '                Me.MsgBox1.ShowAlert("La plantilla se guardo satisfactoriamente", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '            Catch ex As Exception
    '                Me.MsgBox1.ShowAlert(ex.Message, "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '            End Try
    '        End If

    '    End Sub

    '    Private Sub obtenerDatos()
    '        Dim mComponente As New cETIQUETASCAMPOS
    '        Dim lEntidad As New ETIQUETASCAMPOS
    '        Dim mComPlantilla As New cPLANTILLAS
    '        Dim dsPlantilla As Data.DataSet
    '        Me.ddlMODALIDADESCOMPRA1.Recuperar()
    '        dsPlantilla = mComPlantilla.ObtenerDataSetPlantillas(Me.ViewState("idPlantillaSel"))
    '        If dsPlantilla.Tables(0).Rows.Count > 0 Then
    '            Me.rtePlantilla.Text = dsPlantilla.Tables(0).Rows(0).Item("CODIGOFUENTE")
    '            Me.txtPlantilla.Text = dsPlantilla.Tables(0).Rows(0).Item("NOMBRE")
    '        End If

    '        If Me.tipoTransac = "EDIT" Then
    '            Me.ddlMODALIDADESCOMPRA1.SelectedValue = dsPlantilla.Tables(0).Rows(0).Item("IDTIPOCOMPRA")
    '            Select Case dsPlantilla.Tables(0).Rows(0).Item("IDTIPOCOMPRA").ToString
    '                Case Is = 1
    '                    Me.pnlLicitacion.Visible = True
    '                    Me.pnlLibreGestion.Visible = False
    '                    Me.pnlContratacionDirecta.Visible = False
    '                Case Is = 2
    '                    Me.pnlLicitacion.Visible = False
    '                    Me.pnlLibreGestion.Visible = True
    '                    Me.pnlContratacionDirecta.Visible = False
    '                Case Is = 3
    '                    Me.pnlLicitacion.Visible = False
    '                    Me.pnlLibreGestion.Visible = False
    '                    Me.pnlContratacionDirecta.Visible = True
    '            End Select
    '        End If

    '        Me.dgEstablecimiento.DataSource = (mComponente.ObtenerDataSetPorTABLA("ESTABLECIMIENTO"))
    '        Me.dgEstablecimiento.DataBind()

    '        Me.dgEtiqueta.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROCESOCOMPRAS"))
    '        Me.dgEtiqueta.DataBind()

    '        Me.dgEtiquetaLG.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROCESOCOMPRAS_LG"))
    '        Me.dgEtiquetaLG.DataBind()

    '        Me.dgEtiquetaCD.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROCESOCOMPRAS_CD"))
    '        Me.dgEtiquetaCD.DataBind()

    '        Me.dgDocumentos.DataSource = (mComponente.ObtenerDataSetPorTABLA("DOCUMENTOS"))
    '        Me.dgDocumentos.DataBind()

    '        Me.dgCriterios.DataSource = (mComponente.ObtenerDataSetPorTABLA("CRITERIOS"))
    '        Me.dgCriterios.DataBind()

    '        Me.dgCriterioLG.DataSource = (mComponente.ObtenerDataSetPorTABLA("CRITERIO_LG"))
    '        Me.dgCriterioLG.DataBind()

    '        Me.dgCriterio_Tecnico.DataSource = (mComponente.ObtenerDataSetPorTABLA("CRITERIO_TEC"))
    '        Me.dgCriterio_Tecnico.DataBind()

    '        Me.dgCriterio_Financiero.DataSource = (mComponente.ObtenerDataSetPorTABLA("CRITERIO_FIN"))
    '        Me.dgCriterio_Financiero.DataBind()

    '        Me.dgGarantiaMnttoOferta.DataSource = (mComponente.ObtenerDataSetPorTABLA("GARANTIAMANTTOOFERTA"))
    '        Me.dgGarantiaMnttoOferta.DataBind()


    '        Me.dgGarantiaAnticipo.DataSource = (mComponente.ObtenerDataSetPorTABLA("GARANTIAANTICIPO"))
    '        Me.dgGarantiaAnticipo.DataBind()

    '        Me.dgBuenaCalidad.DataSource = (mComponente.ObtenerDataSetPorTABLA("GARANTIABUENACALIDAD"))
    '        Me.dgBuenaCalidad.DataBind()

    '        Me.dgCumplimientoContrato.DataSource = (mComponente.ObtenerDataSetPorTABLA("GARANTIACUMPLIMIENTO"))
    '        Me.dgCumplimientoContrato.DataBind()


    '        Me.dgProductos.DataSource = (mComponente.ObtenerDataSetPorTABLA("PRODUCTOS"))
    '        Me.dgProductos.DataBind()

    '        Me.dgProductosLG.DataSource = (mComponente.ObtenerDataSetPorTABLA("PRODUCTOS_LG"))
    '        Me.dgProductosLG.DataBind()

    '        Me.dgProductosCD.DataSource = (mComponente.ObtenerDataSetPorTABLA("PRODUCTOS_CD"))
    '        Me.dgProductosCD.DataBind()

    '        Me.dgEntregas.DataSource = (mComponente.ObtenerDataSetPorTABLA("ENTREGAS"))
    '        Me.dgEntregas.DataBind()

    '        Me.dgEntregaLG.DataSource = (mComponente.ObtenerDataSetPorTABLA("ENTREGAS_LG"))
    '        Me.dgEntregaLG.DataBind()

    '        Me.dgEntregaCD.DataSource = (mComponente.ObtenerDataSetPorTABLA("ENTREGAS_CD"))
    '        Me.dgEntregaCD.DataBind()

    '        Me.dgProgramaDistribucion.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROGRAMA_DISTRIBUCION"))
    '        Me.dgProgramaDistribucion.DataBind()

    '        Me.dgDistribucionLG.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROGRAMA_DISTRIBUCION_LG"))
    '        Me.dgDistribucionLG.DataBind()

    '        Me.dgDistribucionCD.DataSource = (mComponente.ObtenerDataSetPorTABLA("PROGRAMA_DISTRIBUCION_CD"))
    '        Me.dgDistribucionCD.DataBind()
    '    End Sub

    '#End Region

End Class
