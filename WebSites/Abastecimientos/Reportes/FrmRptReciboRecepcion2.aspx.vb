Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptReciboRecepcion2
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Dim lIdMovimiento As Int64
    Dim lIdAlmacen As Int64
    Dim lAnio As Integer

    Private Sub ConfigureCrystalReports()

        Reporte = New ReportDocument

        Dim reportPath As String

        lIdMovimiento = Request.QueryString("IdMov")
        lIdAlmacen = Request.QueryString("IdAlmacen")
        lAnio = Request.QueryString("IdAnio")

        Dim IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO As Integer
        IDESTABLECIMIENTO = Request.QueryString("Establecimiento")
        IDPROVEEDOR = Request.QueryString("Proveedor")
        IDCONTRATO = Request.QueryString("Contrato")

        reportPath = Server.MapPath("RptReciboRecepcion.rpt")

        Reporte.Load(reportPath)

        Dim mCompMovimientos As New cMOVIMIENTOS
        Dim mCompModificativas As New cMODIFICATIVASCONTRATO
        Dim mCompContratos As New cCONTRATOS
        Dim mEntContratos As New CONTRATOS
        Dim mCompModalidadesCompra As New cMODALIDADESCOMPRA
        Dim mCompTipoDocumento As New cTIPODOCUMENTOCONTRATO
        Dim dsReciboRecepcion As DataSet
        Dim dsModificativas As DataSet
        Dim dsModalidades As DataSet
        Dim dsTipoDocumento As DataSet
        Dim Modificativas As String = ""
        Dim Modalidad As String = ""
        Dim TipoDocumento As String = ""

        dsModificativas = mCompModificativas.ObtenerDataSetPorId(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

        mEntContratos.IDESTABLECIMIENTO = IDESTABLECIMIENTO
        mEntContratos.IDPROVEEDOR = IDPROVEEDOR
        mEntContratos.IDCONTRATO = IDCONTRATO
        mCompContratos.ObtenerCONTRATOS(mEntContratos)

        dsModalidades = mCompModalidadesCompra.ObtenerModalidadPorID(mEntContratos.IDMODALIDADCOMPRA)
        If dsModalidades.Tables(0).Rows.Count > 0 Then
            Modalidad = dsModalidades.Tables(0).Rows(0).Item("DESCRIPCION") + ": " + mEntContratos.NUMEROMODALIDADCOMPRA
        End If

        dsTipoDocumento = mCompTipoDocumento.ObtenerTipoDocumentoPorID(mEntContratos.IDTIPODOCUMENTO)
        If dsTipoDocumento.Tables(0).Rows.Count > 0 Then
            TipoDocumento = dsTipoDocumento.Tables(0).Rows(0).Item("DESCRIPCION")
        End If

        If dsModificativas.Tables(0).Rows.Count > 0 Then
            Dim iFila As Integer = 0
            For iFila = 0 To dsModificativas.Tables(0).Rows.Count - 1
                If iFila = 0 Then
                    Modificativas = Modificativas + dsModificativas.Tables(0).Rows(iFila).Item("NUMEROMODIFICATIVA")
                Else
                    Modificativas = Modificativas + ", " + dsModificativas.Tables(0).Rows(iFila).Item("NUMEROMODIFICATIVA")
                End If
            Next
        End If

        dsReciboRecepcion = mCompMovimientos.ObtenerReciboRecepcionDS3(lIdMovimiento, lIdAlmacen, lAnio)

        Reporte.DataDefinition.FormulaFields("ModalidadCompra").Text = "'" + Modalidad + "'"
        Reporte.DataDefinition.FormulaFields("TipoDocumento").Text = "'" + TipoDocumento + "'"
        Reporte.DataDefinition.FormulaFields("Modificativas").Text = "'" + Modificativas + "'"

        Reporte.SetDataSource(dsReciboRecepcion.Tables(0))

        Me.crvPrincipal.ReportSource = Reporte

        Me.crvPrincipal.DisplayGroupTree = False
        Me.crvPrincipal.DisplayToolbar = True

        Me.crvPrincipal.EnableDrillDown = False

        Me.crvPrincipal.HasCrystalLogo = False
        Me.crvPrincipal.HasDrillUpButton = False
        Me.crvPrincipal.HasGotoPageButton = True
        Me.crvPrincipal.HasPageNavigationButtons = True
        Me.crvPrincipal.HasPrintButton = True
        Me.crvPrincipal.HasRefreshButton = False
        Me.crvPrincipal.HasSearchButton = False
        Me.crvPrincipal.HasToggleGroupTreeButton = False
        Me.crvPrincipal.HasViewList = False
        Me.crvPrincipal.HasZoomFactorList = False

        Me.crvPrincipal.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        ConfigureCrystalReports()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub

End Class
