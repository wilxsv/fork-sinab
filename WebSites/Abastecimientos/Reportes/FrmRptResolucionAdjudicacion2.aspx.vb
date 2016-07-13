Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.UACIHelpers

Partial Class FrmRptResolucionAdjudicacion2
    Inherits System.Web.UI.Page

    Private Reporte As ReportDocument

    Private CANTIDADOFERTAS As String = "$CantidadOfertas(Numero)$"
    Private CANTIDADOFERTAS_LETRAS As String = "$CantidadOfertas(Letras)$"
    Private CARGOTITULAR As String = "$CargoTitular$"
    Private DESCRIPCION As String = "$Descripcion$"
    Private ESTABLECIMIENTO As String = "$Establecimiento$"
    Private FECHAHORAFINRECOMENDACION As String = "$FechaHoraFinRecomendacionEnLetras$"
    Private FECHAHORAINICIORECEPCION As String = "$FechaHoraPresentacionOfertasEnLetras$"
    Private FECHAHORAFINRECEPCION As String = "$FechaHoraFinRecepcionOfertasEnLetras$"
    Private LISTAPROVEEDORES As String = "$ListaProveedores$"
    Private MIEMBROSCOMISION As String = "$MiembrosComision$"
    Private MODALIDADCOMPRA As String = "$ModalidadCompra$"
    Private NUMERO As String = "$Numero$"
    Private TITULAR As String = "$Titular$"
    Private TITULO As String = "$Titulo$"


    Private _TipoPlantilla As Integer

    Private mComponente As New cDETALLEPLANTILLAPROCESOCOMPRA


    Private Sub ConfiguracionReporte()
        Dim IDESTABLECIMIENTO, IDPROCESOCOMPRA, TIPOPLANTILLA, IDALMACEN As Integer
        IDALMACEN = Request.QueryString("idA")
        IDESTABLECIMIENTO = Request.QueryString("idE")
        IDPROCESOCOMPRA = Request.QueryString("idPC")
        TIPOPLANTILLA = Request.QueryString("TP")

        Dim reportPath As String
        Dim X As New cPROGRAMADISTRIBUCION
        If X.ObtenerAlmacenFosIsss(IDESTABLECIMIENTO, IDPROCESOCOMPRA) = 0 Then
            reportPath = Server.MapPath("RptResolucionAdjudicacion2.rpt")
        Else
            If IDALMACEN = 0 Then
                reportPath = Server.MapPath("RptResolucionAdjudicacion22.rpt")
            Else
                reportPath = Server.MapPath("RptResolucionAdjudicacion2.rpt")
            End If

        End If

        Reporte = New ReportDocument
        'Dim reportPath As String = Server.MapPath("RptResolucionAdjudicacion2.rpt")
        Reporte.Load(reportPath)

        Dim cDPC As New cDETALLEPROCESOCOMPRA
        Dim ds As New Data.DataSet

        Select Case TIPOPLANTILLA
            Case eTIPOPLANTILLA.ADJUDICACION
                cDPC.ResolucionAdjudicacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ds, IDALMACEN)
            Case eTIPOPLANTILLA.ADJUDICACIONFIRME
                cDPC.ResolucionAdjudicacionEnFirme(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ds, IDALMACEN)
            Case Else
                Return
        End Select


        Dim cPC As New cPROCESOCOMPRAS
        Dim a As ArrayList

        a = cPC.ObtenerInfoLicitacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        Dim paramField As New ParameterField()
        Dim paramFields As New ParameterFields()
        Dim discreteVal As New ParameterDiscreteValue()

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Establecimiento"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = a.Item(0).ToString
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Modalidad"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = a.Item(1).ToString
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Titulo"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = a.Item(2).ToString
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Descripcion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = a.Item(3).ToString
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Resolucion"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = "Resolución de Adjudicación No. " + a.Item(4).ToString
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Encabezado"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = ReemplazarEtiquetas(ds.Tables("Table2").Rows(0).Item(0))
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Pie"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = "NOTIFÍQUESE"
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Titular"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = a.Item(5).ToString
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "CargoTitular"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = a.Item(6).ToString
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "modificativa"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value =""
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

         paramField = New ParameterField()
        paramField.ParameterFieldName = "notifiquese"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value =""
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "E"
        discreteVal = New ParameterDiscreteValue()

        Select Case Request.QueryString("idA")
            Case Is = 0
                discreteVal.Value = ""
            Case Is = 1
                discreteVal.Value = "MINSAL"
            Case Is = 114, 116
                discreteVal.Value = "FOSALUD"
            Case Is = 499
                discreteVal.Value = "ISSS"
        End Select
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        'If Not ds.Tables.Count = 0 Then
        '    For Each reg As Data.DataRow In ds.Tables("dtValorizacionPorRenglon").Rows
        '        If Not (reg("Monto") Is DBNull.Value) Then
        '            reg.BeginEdit()
        '            reg("Monto") = FormatNumber(reg("Monto"), 4)
        '            reg.EndEdit()
        '        End If

        '    Next
        'End If

        Reporte.SetDataSource(ds)
        'Reporte.Subreports(0).SetDataSource(ds.Tables("Table2"))

        Reporte.Subreports(0).SetDataSource(DetalleProcesoCompras.ObtenerSubReporte(IDESTABLECIMIENTO, IDPROCESOCOMPRA))

        'If X.ObtenerAlmacenFosIsss(IDESTABLECIMIENTO, IdProcesoCompra) <> 0 Then
        '    If IDALMACEN = 0 Then
        '        Reporte.Subreports(1).SetDataSource(ds.Tables("ResolucionAdjudicacion2"))
        '        Reporte.Subreports(2).SetDataSource(ds.Tables("ResolucionAdjudicacion3"))
        '    End If
        'End If

        Me.crvPrincipal.ParameterFieldInfo = paramFields
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
        ConfiguracionReporte()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Reporte.Close()
        Reporte.Dispose()
    End Sub
    Private Function ReemplazarEtiquetas(ByVal texto As String) As String

        Dim s As New StringBuilder(texto)

        Dim cPC As New cPROCESOCOMPRAS
        Dim ePC As New ABASTECIMIENTOS.ENTIDADES.PROCESOCOMPRAS
        ePC.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        ePC.IDPROCESOCOMPRA = Request.QueryString("idPc")

        cPC.ObtenerPROCESOCOMPRAS(ePC)

        s.Replace(FECHAHORAINICIORECEPCION, clsUtilitarios.DateToWords(ePC.FECHAHORAINICIORECEPCION))
        s.Replace(FECHAHORAFINRECEPCION, clsUtilitarios.DateToWords(ePC.FECHAHORAFINRECEPCION))
        s.Replace(FECHAHORAFINRECOMENDACION, clsUtilitarios.DateToWords(ePC.FECHAFINRECOMENDACION))

        Dim a As ArrayList
        a = cPC.ObtenerInfoLicitacion(ePC.IDESTABLECIMIENTO, ePC.IDPROCESOCOMPRA)
        If Not a.Count = 0 Then

            s.Replace(MODALIDADCOMPRA, a.Item(1).ToString)
            s.Replace(TITULO, a.Item(2).ToString)
            s.Replace(DESCRIPCION, a.Item(3).ToString)
            s.Replace(NUMERO, a.Item(4).ToString)
            s.Replace(TITULAR, a.Item(5).ToString)
            s.Replace(CARGOTITULAR, a.Item(6).ToString)
        End If
        Dim lista As String
        lista = cPC.ObtenerListaProveedores(ePC.IDESTABLECIMIENTO, ePC.IDPROCESOCOMPRA)
        s.Replace(LISTAPROVEEDORES, lista)

        lista = cPC.ObtenerMiembros(ePC.IDESTABLECIMIENTO, ePC.IDPROCESOCOMPRA)
        s.Replace(MIEMBROSCOMISION, lista)

        Dim cDO As New cDETALLEOFERTA
        Dim c As Integer
        c = cDO.ObtenerCantidadOfertas(ePC.IDESTABLECIMIENTO, ePC.IDPROCESOCOMPRA)
        s.Replace(CANTIDADOFERTAS, c.ToString)

        s.Replace(CANTIDADOFERTAS_LETRAS, clsUtilitarios.Num2Text(c))

        s.Replace(ESTABLECIMIENTO, Membresia.ObtenerUsuario().Establecimiento.NOMBRE.ToString)

        Return s.ToString

    End Function
End Class
