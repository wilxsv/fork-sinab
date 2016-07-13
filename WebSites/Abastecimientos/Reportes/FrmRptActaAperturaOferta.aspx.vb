Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Reportes_FrmRptActaAperturaOferta
    Inherits System.Web.UI.Page

    Private Reporte As New ReportDocument

    Dim paramField As New ParameterField()
    Dim paramFields As New ParameterFields()
    Dim discreteVal As New ParameterDiscreteValue()

    Private Sub ConfiguracionReporte()
        Reporte = New ReportDocument
        Dim reportPath As String = Server.MapPath("RptActaAperturaOferta.rpt")
        Reporte.Load(reportPath)

        Dim dsProveedor As DataSet
        Dim dsEmpleado As DataSet
        Dim dsFinanciamiento As DataSet

        Dim i As Integer
        Dim ProveedorRepresentante As String = String.Empty
        Dim MSPASRepresentante As String = String.Empty
        Dim Fecha As String = String.Empty
        Dim HoraApertura As String = String.Empty
        Dim FechaApertura As String = String.Empty
        Dim MinutoApertura As String = String.Empty
        Dim FuenteFinanciamiento As String = String.Empty

        dsProveedor = clsObtenerDatos.ActaAperturaOfertaDataSet(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        For i = 0 To dsProveedor.Tables(0).Rows.Count - 1
            ProveedorRepresentante += " el(la) " & dsProveedor.Tables(0).Rows(i).Item("NOMBREREPRESENTANTE") & " en representación de " & dsProveedor.Tables(0).Rows(i).Item("NOMBRE") & "; "
        Next

        dsEmpleado = clsObtenerDatos.NvoEmpleadosAperturaOfertaDataSet(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        For i = 0 To dsEmpleado.Tables(0).Rows.Count - 1
            If i = dsEmpleado.Tables(0).Rows.Count - 1 Then
                MSPASRepresentante += " y el(la) Sr(a). " & dsEmpleado.Tables(0).Rows(i).Item(3) & " " & dsEmpleado.Tables(0).Rows(i).Item(4) & ", "
            Else
                'MSPASRepresentante += " el(la) Sr(a). " & dsEmpleado.Tables(0).Rows(i).Item("NOMBRE") & " " & dsEmpleado.Tables(0).Rows(i).Item("APELLIDO") & ", "

                MSPASRepresentante += " el(la) Sr(a). " & dsEmpleado.Tables(0).Rows(i).Item(3) & " " & dsEmpleado.Tables(0).Rows(i).Item(4) & ", "
            End If
        Next

        dsFinanciamiento = clsObtenerDatos.FuenteFinanciamientoAperturaOfertaDataSet(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        For i = 0 To dsFinanciamiento.Tables(0).Rows.Count - 1
            If i = dsFinanciamiento.Tables(0).Rows.Count - 1 Then
                FuenteFinanciamiento += dsFinanciamiento.Tables(0).Rows(i).Item("NOMBRE")
            Else
                FuenteFinanciamiento += dsFinanciamiento.Tables(0).Rows(i).Item("NOMBRE") & ", "
            End If
        Next

        Fecha = dsProveedor.Tables(0).Rows(0).Item("FECHAREALIZADAAPERTURA")

        FechaApertura = CDate(Fecha).ToString("d").ToLower

        Dim diaAperturaOferta As String
        Dim mesAperturaOferta As String
        Dim añoAperturaOferta As String

        diaAperturaOferta = clsUtilitarios.Num2Text(CDate(FechaApertura).Day).ToLower
        mesAperturaOferta = Format(CDate(FechaApertura), "MMMM") ', clsUtilitarios.Num2Text(CDate(FechaApertura).Month)).ToLower
        añoAperturaOferta = clsUtilitarios.Num2Text(CDate(FechaApertura).Year).ToLower

        HoraApertura = CDate(Fecha).Hour.ToString.ToLower

        MinutoApertura = CDate(Fecha).Minute.ToString.ToLower


        Dim mComEstablecimiento As New cESTABLECIMIENTOS
        Dim nombreMunicipio As String
        nombreMunicipio = mComEstablecimiento.ObtenerUbicacionEstablecimiento(Session("IdEstablecimiento")).Tables(0).Rows(0).Item("NOMBRE")

        'Parametros de provedor al reporte
        paramField.ParameterFieldName = "ProveedoresRepresentantes"
        discreteVal.Value = ProveedorRepresentante
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "MSPASRepresentantes"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = MSPASRepresentante
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Municipio"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = nombreMunicipio
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "Establecimiento"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Session.Item("UsuarioEstablecimiento").ToString
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "NoACTA"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = Request.QueryString("noACTA")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "FechaApertura"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = FechaApertura
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        'paramField = New ParameterField()
        'paramField.ParameterFieldName = "diaApertura"
        'discreteVal = New ParameterDiscreteValue()
        'discreteVal.Value = diaAperturaOferta
        'paramField.CurrentValues.Add(discreteVal)
        'paramFields.Add(paramField)

        Reporte.DataDefinition.FormulaFields(0).Text = "'" & diaAperturaOferta & "'"
        Reporte.DataDefinition.FormulaFields(1).Text = "'" & mesAperturaOferta & "'"
        Reporte.DataDefinition.FormulaFields(2).Text = "'" & añoAperturaOferta & "'"


        'paramField = New ParameterField()
        'paramField.ParameterFieldName = "mesApertura"
        'discreteVal = New ParameterDiscreteValue()
        'discreteVal.Value = mesAperturaOferta
        'paramField.CurrentValues.Add(discreteVal)
        'paramFields.Add(paramField)

        'paramField = New ParameterField()
        'paramField.ParameterFieldName = "añoApertura"
        'discreteVal = New ParameterDiscreteValue()
        'discreteVal.Value = añoAperturaOferta
        'paramField.CurrentValues.Add(discreteVal)
        'paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "HoraApertura"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = clsUtilitarios.Num2Text(HoraApertura).ToLower
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "MinutoApertura"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = clsUtilitarios.Num2Text(MinutoApertura)
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField = New ParameterField()
        paramField.ParameterFieldName = "FuenteFinanciamiento"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = FuenteFinanciamiento
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Dim observacionActa As String
        If IsDBNull(dsProveedor.Tables(0).Rows(0).Item("OBSERVACIONESACTA")) Then
            observacionActa = "N/D"
        Else
            observacionActa = dsProveedor.Tables(0).Rows(0).Item("OBSERVACIONESACTA")
        End If

        paramField = New ParameterField()
        paramField.ParameterFieldName = "observacionActa"
        discreteVal = New ParameterDiscreteValue()
        discreteVal.Value = observacionActa
        'discreteVal.Value = dsProveedor.Tables(0).Rows(0).Item("OBSERVACIONESACTA")
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)


        For i = 0 To 3
            paramField = New ParameterField()
            paramField.ParameterFieldName = "Empleado" & i + 1
            discreteVal = New ParameterDiscreteValue()
            Try
                discreteVal.Value = dsEmpleado.Tables(0).Rows(i).Item(3) '& " " & dsEmpleado.Tables(0).Rows(i).Item(4)
            Catch ex As Exception
                discreteVal.Value = ""
            End Try

            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)

            paramField = New ParameterField()
            paramField.ParameterFieldName = "Cargo" & i + 1
            discreteVal = New ParameterDiscreteValue()
            Try
                discreteVal.Value = dsEmpleado.Tables(0).Rows(i).Item("CARGO")
            Catch ex As Exception
                discreteVal.Value = ""
            End Try

            paramField.CurrentValues.Add(discreteVal)
            paramFields.Add(paramField)
        Next

        Reporte.SetDataSource(dsProveedor.Tables(0))

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

End Class
