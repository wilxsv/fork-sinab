Imports ABASTECIMIENTOS.DATOS

Public Class cCONSUMOS

    Private dbEntidad As New dbCONSUMOS

    Dim mesesArr() As String = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}

    Public Function obtenerConsumoEstablecimientoFecha(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal idalmacenhospital As Integer, Optional ByVal tipo As String = "left outer", Optional idprograma As Integer = 0) As DataSet

        Try
            Dim ds As DataSet = dbEntidad.obtenerConsumoEstablecimientoFecha(idEstablecimiento, idAlmacen, fechaConsumo, idalmacenhospital, tipo, idprograma)
            ds.Tables(0).TableName = "tabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerExistenciaEstablecimientoFecha(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal FoA As Integer, Optional ByVal tipo As String = "left outer") As DataSet

        Try
            Dim ds As DataSet = dbEntidad.obtenerExistenciaEstablecimientoFecha(idEstablecimiento, idAlmacen, fechaConsumo, FoA, tipo)
            ds.Tables(0).TableName = "tabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerConsumoTotalFecha(ByVal idEstablecimiento As Integer, ByVal fechaConsumo As Date, Optional ByVal tipo As String = "left outer", Optional idprograma As Integer = 0) As DataSet

        Try
            Dim ds As DataSet = dbEntidad.obtenerConsumoTotalFecha(idEstablecimiento, fechaConsumo, tipo, idprograma)
            ds.Tables(0).TableName = "tabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    'SCMS 
    Public Function obtenerExistenciaEstablecimientoFecha2(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal FoA As Integer, idempleado As Integer, Optional ByVal tipo As String = "left outer") As DataSet

        Try
            Dim ds As DataSet = dbEntidad.obtenerExistenciaEstablecimientoFecha2(idEstablecimiento, idAlmacen, fechaConsumo, FoA, idempleado, tipo)
            ds.Tables(0).TableName = "tabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    'SCMS
    Public Function ChequearCYEMEsAnterior(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal FoA As Integer, Optional ByVal tipo As String = "left outer") As Integer
        Try
            Dim ds As Integer = dbEntidad.ChequearCYEMEsAnterior(idEstablecimiento, idAlmacen, fechaConsumo, FoA, tipo)
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    'SCMS
    Public Function ChequearCYEMEsPosterior(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal FoA As Integer, Optional ByVal tipo As String = "left outer") As Integer
        Try
            Dim ds As Integer = dbEntidad.ChequearCYEMEsPosterior(idEstablecimiento, idAlmacen, fechaConsumo, FoA, tipo)
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    'SCMS
    Public Function obtenerAjusteExistenciaFarmacia(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal idalmacenhospital As Integer, Optional ByVal tipo As String = "left outer", Optional IdPrograma As Integer = 0) As DataSet
        Try
            Dim ds As DataSet = dbEntidad.obtenerAjusteExistenciaFarmacia(idEstablecimiento, idAlmacen, fechaConsumo, idalmacenhospital, tipo, IdPrograma)
            ds.Tables(0).TableName = "tabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    'SCMS 
    Public Function obtenerConsumoTotalFecha2(ByVal idEstablecimiento As Integer, ByVal fechaConsumo As Date, Optional ByVal tipo As String = "left outer", Optional idprograma As Integer = 0) As DataSet

        Try
            Dim ds As DataSet = dbEntidad.obtenerConsumoTotalFecha2(idEstablecimiento, fechaConsumo, tipo, idprograma)
            ds.Tables(0).TableName = "tabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerReporteSSR(ByVal idEstablecimiento As Integer, ByVal fechaConsumo As Date, Optional ByVal tipo As String = "left outer") As DataSet

        Try
            Dim ds As DataSet = dbEntidad.obtenerReporteSSR(idEstablecimiento, fechaConsumo, tipo)
            'ds.Tables(0).TableName = "tabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerDesabastecimientoRegiones(ByVal FECHAINICIO As Date, ByVal FECHAFIN As Date) As ArrayList
        Try
            Return dbEntidad.obtenerDesabastecimientoRegiones(FECHAINICIO, FECHAFIN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerDesabastecimientoHospitales(ByVal FECHAINICIO As Date, ByVal FECHAFIN As Date) As ArrayList
        Try
            Return dbEntidad.obtenerDesabastecimientoHospitales(FECHAINICIO, FECHAFIN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function actualizarConsumos(ByVal arr As ArrayList) As Integer

        Dim tran As New DistributedTransaction

        Try

            For i As Integer = 0 To arr.Count - 1

                Dim lentidad As CONSUMOS = arr.Item(i)

                'Dos pasos. Primero verificamos si existe o no el registo.
                'De existir, actualizamos, caso contrario, insertamos
                If dbEntidad.existeConsumo(lentidad, tran) = 0 Then
                    'Ingresamos
                    dbEntidad.ingresarConsumos(lentidad, tran)
                Else
                    'Actualizamos
                    dbEntidad.actualizarConsumos(lentidad, tran)
                End If

            Next

            tran.Commit()

            Return 0

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function eliminarConsumo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer, ByVal IDPRODUCTO As Integer, ByVal FECHACONSUMO As DateTime) As Integer

        Try
            Return dbEntidad.eliminarConsumo(IDESTABLECIMIENTO, IDALMACEN, IDPRODUCTO, FECHACONSUMO)
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function ajustarConsumo(ByVal lEntidad As CONSUMOS) As Integer

        Try
            Return dbEntidad.ajustarConsumo(lEntidad)
        Catch ex As Exception
            Return -1
        End Try

    End Function
    Public Function ajustarExistencia(ByVal lEntidad As CONSUMOS) As Integer

        Try
            Return dbEntidad.ajustarExistencia(lEntidad)
        Catch ex As Exception
            Return -1
        End Try

    End Function
    Public Function IngresarMotivoExistenciaAjustada(ByVal idestablecimiento As Integer, idalmacen As Integer, idproducto As Integer, fechaconsumo As DateTime, existenciaajustada As Decimal, MOTIVOEXISTENCIA As String) As Integer
        Try
            Return dbEntidad.IngresarMotivoExistenciaAjustada(idestablecimiento, idalmacen, idproducto, fechaconsumo, existenciaajustada, MOTIVOEXISTENCIA)
        Catch ex As Exception
            Return -1
        End Try
    End Function
    Public Function obtenerExistenciaMesAnterior(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, idproducto As Integer) As Decimal
        Try
            Return dbEntidad.obtenerExistenciaMesAnterior(idEstablecimiento, idAlmacen, fechaConsumo, idproducto)
        Catch ex As Exception
            Return -1
        End Try
    End Function
    Public Function obtenerAjustesDelMes(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, idproducto As Integer) As Decimal
        Try
            Return dbEntidad.obtenerAjustesDelMes(idEstablecimiento, idAlmacen, fechaConsumo, idproducto)
        Catch ex As Exception
            Return -1
        End Try
    End Function
    Public Function obtenerDespachosDelMes(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, idproducto As Integer) As Decimal
        Try
            Return dbEntidad.obtenerDespachosDelMes(idEstablecimiento, idAlmacen, fechaConsumo, idproducto)
        Catch ex As Exception
            Return -1
        End Try
    End Function
    Public Function BorrarRegistrosMes(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date) As Integer
        Try
            Return dbEntidad.BorrarRegistrosMes(idEstablecimiento, idAlmacen, fechaConsumo)
        Catch ex As Exception
            Return -1
        End Try
    End Function
    Public Function obtenerDesabastecimientoHospitalFecha(ByVal FECHA As Date, ByVal tipo As Integer) As DataSet

        Try

            Dim ds As DataSet

            If dbEntidad.totalEstablecimientosConsumo(FECHA) = 0 Then

                ds = Nothing

            Else
                ds = dbEntidad.obtenerDesabastecimientoHospitalFecha(FECHA)

                ds.Tables(0).TableName = "tabla"

                Dim abas As DataColumn = New DataColumn
                With abas
                    .DataType = System.Type.GetType("System.Decimal")
                    .ColumnName = "abastecimiento"
                    .Expression = "100 - porcentaje"
                End With

                With ds.Tables(0).Columns
                    .Add(abas)
                End With

            End If

            Return ds

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function obtenerDesabastecimientoRegionFecha(ByVal FECHA As Date, ByVal tipo As Integer) As DataSet

        Try
            Dim ds As DataSet = dbEntidad.obtenerDesabastecimientoRegionFecha(FECHA)

            ds.Tables(0).TableName = "tabla"

            Dim abas As DataColumn = New DataColumn
            With abas
                .DataType = System.Type.GetType("System.Decimal")
                .ColumnName = "abastecimiento"
                .Expression = "100 - porcentaje"
            End With

            With ds.Tables(0).Columns
                .Add(abas)
            End With

            Return ds

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listaHospitalesCaptura() As DataSet
        Try
            Return dbEntidad.listaHospitalesCaptura
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function listaUniversoCapturaHospital(ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return dbEntidad.listaUniversoCapturaHospital(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function listaUniversoCapturaMedicamento(ByVal CODIGO As String) As DataSet
        Try
            Return dbEntidad.listaUniversoCapturaMedicamento(CODIGO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerCodigosCapturadosConsumo(ByVal fecha, ByRef arrHosp) As Array

        Try

            Return dbEntidad.obtenerCodigosCapturadosConsumo(fecha, arrHosp)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerCodigosCapturadosConsumoIntervalo(ByVal fecha) As DataSet

        Try
            Dim arrF As New ArrayList
            Dim arrHosp As New ArrayList

            Dim arrDatos As Array = dbEntidad.obtenerCodigosCapturadosConsumoIntervalo(fecha, arrHosp, arrF)

            Dim tabla As DataTable

            tabla = crearTablaCEHospitales()

            Dim row As DataRow


            For i As Integer = 0 To arrHosp.Count - 1

                row = tabla.NewRow()

                row("establecimiento") = arrHosp.Item(i)

                For j As Integer = 0 To arrF.Count - 1

                    Dim fechaTemp As Date = arrF.Item(j)

                    row("fc" & j + 1) = mesesArr(fechaTemp.Month - 1) & "/" & fechaTemp.Year
                    row("a" & j + 1) = arrDatos(i, j, 0)
                    row("f" & j + 1) = arrDatos(i, j, 1)
                    row("d" & j + 1) = Math.Abs(arrDatos(i, j, 0) - arrDatos(i, j, 1))

                Next

                tabla.Rows.Add(row)

            Next

            Dim ds As New Data.DataSet
            ds.Tables.Add(tabla)

            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Private Function crearTablaCEHospitales() As DataTable

        Dim tabla As DataTable = New DataTable("tblCaptura")

        'Establecimiento
        Dim clEstablecimiento As DataColumn = New DataColumn()
        clEstablecimiento.DataType = System.Type.GetType("System.String")
        clEstablecimiento.ColumnName = "establecimiento"
        tabla.Columns.Add(clEstablecimiento)

        'Primero la fecha1
        Dim clFC1 As DataColumn = New DataColumn()
        clFC1.DataType = System.Type.GetType("System.String")
        clFC1.ColumnName = "fc1"
        tabla.Columns.Add(clFC1)

        'Almacen 1
        Dim clA1 As DataColumn = New DataColumn()
        clA1.DataType = System.Type.GetType("System.Int32")
        clA1.ColumnName = "a1"
        tabla.Columns.Add(clA1)

        'Farmacia 1
        Dim clF1 As DataColumn = New DataColumn()
        clF1.DataType = System.Type.GetType("System.Int32")
        clF1.ColumnName = "f1"
        tabla.Columns.Add(clF1)

        'Diferencia 1
        Dim clD1 As DataColumn = New DataColumn()
        clD1.DataType = System.Type.GetType("System.Int32")
        clD1.ColumnName = "d1"
        tabla.Columns.Add(clD1)

        'Primero la fecha2
        Dim clFC2 As DataColumn = New DataColumn()
        clFC2.DataType = System.Type.GetType("System.String")
        clFC2.ColumnName = "fc2"
        tabla.Columns.Add(clFC2)

        'Almacen 2
        Dim clA2 As DataColumn = New DataColumn()
        clA2.DataType = System.Type.GetType("System.Int32")
        clA2.ColumnName = "a2"
        tabla.Columns.Add(clA2)

        'Farmacia 2
        Dim clF2 As DataColumn = New DataColumn()
        clF2.DataType = System.Type.GetType("System.Int32")
        clF2.ColumnName = "f2"
        tabla.Columns.Add(clF2)

        'Diferencia 2
        Dim clD2 As DataColumn = New DataColumn()
        clD2.DataType = System.Type.GetType("System.Int32")
        clD2.ColumnName = "d2"
        tabla.Columns.Add(clD2)

        'Primero la fecha3
        Dim clFC3 As DataColumn = New DataColumn()
        clFC3.DataType = System.Type.GetType("System.String")
        clFC3.ColumnName = "fc3"
        tabla.Columns.Add(clFC3)

        'Almacen 3
        Dim clA3 As DataColumn = New DataColumn()
        clA3.DataType = System.Type.GetType("System.Int32")
        clA3.ColumnName = "a3"
        tabla.Columns.Add(clA3)

        'Farmacia 3
        Dim clF3 As DataColumn = New DataColumn()
        clF3.DataType = System.Type.GetType("System.Int32")
        clF3.ColumnName = "f3"
        tabla.Columns.Add(clF3)

        'Diferencia 3
        Dim clD3 As DataColumn = New DataColumn()
        clD3.DataType = System.Type.GetType("System.Int32")
        clD3.ColumnName = "d3"
        tabla.Columns.Add(clD3)

        'Fecha
        Dim clOrdenF As DataColumn = New DataColumn()
        clOrdenF.DataType = System.Type.GetType("System.DateTime")
        clOrdenF.ColumnName = "ordenF"
        tabla.Columns.Add(clOrdenF)


        ' Return the new DataTable.
        crearTablaCEHospitales = tabla

    End Function

    Public Function obtenerCodigosCapturadosRegiones(ByVal fecha) As DataSet

        Try
            Dim arrF As New ArrayList
            Dim arrReg As New ArrayList

            Dim arrDatos As Array = dbEntidad.obtenerCodigosRegionesConsumoIntervalo(fecha, arrF, arrReg)

            Dim tabla As DataTable

            tabla = crearTablaCEHospitales()

            Dim row As DataRow


            For i As Integer = 0 To arrReg.Count - 1

                For j As Integer = 0 To arrF.Count - 1

                    row = tabla.NewRow()

                    row("establecimiento") = arrReg.Item(i)

                    Dim fechaTemp As Date = arrF.Item(j)

                    row("fc1") = mesesArr(fechaTemp.Month - 1) & "/" & fechaTemp.Year
                    row("a1") = arrDatos(i, j, 0)
                    row("f1") = arrDatos(i, j, 1)
                    row("d1") = arrDatos(i, j, 2)
                    row("ordenF") = fechaTemp

                    tabla.Rows.Add(row)

                Next



            Next

            Dim ds As New Data.DataSet
            ds.Tables.Add(tabla)

            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    'SCMS
    Public Function obtenerConsumoTotalxEstablecimientoMensual(ByVal idproducto As Integer, ByVal fechaConsumo As Date, idprograma As Integer) As DataSet
        Try
            Return dbEntidad.obtenerConsumoTotalxEstablecimientoMensual(idproducto, fechaConsumo, idprograma)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    'SCMS
    Public Function obtenerIdAlmacenHospital(ByVal idempleado As Integer) As Integer
        Try
            Return dbEntidad.obtenerIdAlmacenHospital(idempleado)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
End Class
