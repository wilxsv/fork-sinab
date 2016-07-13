Imports System.Text

Partial Public Class cMULTASCONTRATOS

    Public Function obtenerPlantilla(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Integer, ByVal TIPO As Integer) As StringBuilder
        Try
            Return mDb.obtenerPlantilla(IDESTABLECIMIENTO, IDPLANTILLA, TIPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerPlantilla(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer) As StringBuilder
        Try
            Return mDb.obtenerPlantilla(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMULTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerIncumplimientosNoEntregado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDNOTA As Integer) As DataSet
        Try
            Return mDb.ObtenerIncumplimientosNoEntregado(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerIncumplimientosAtraso(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDNOTA As Integer) As DataSet
        Try
            Return mDb.ObtenerIncumplimientosAtraso(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenermultasNoEntregado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDNOTA As Integer) As DataSet
        Try
            Return mDb.ObtenerMultasNoEntregado(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerMultasAtraso(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDNOTA As Integer) As DataSet
        Try
            Return mDb.ObtenerMultasAtraso(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function guardarPlantilla(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Integer, ByVal NOMBRE As String, ByVal CONTENIDO As String, ByVal TIPOPLANTILLA As Integer) As Integer
        Try
            Return mDb.guardarPlantilla(IDESTABLECIMIENTO, IDPLANTILLA, NOMBRE, CONTENIDO, TIPOPLANTILLA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDatosAudiencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.ObtenerDatosAudiencia(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerInformesIncumplimiento(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.obtenerInformesIncumplimiento(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerAudiencias(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.obtenerAudiencias(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function calcularMulta(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDNOTA As Integer) As DataSet
        Dim dsAtraso As DataSet
        Dim dsNoEntregado As DataSet
        Dim dsMulta As New DataSet
        Dim mdb2 As New dbPORCENTAJESMULTAS
        Dim dsPorcentajes As DataSet
        Dim dt As New DataTable
        dsPorcentajes = mdb2.ObtenerDataSetPorID
        dsAtraso = mDb.ObtenerIncumplimientosAtraso(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
        dsNoEntregado = mDb.ObtenerIncumplimientosNoEntregado(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
        dt = tablaMultas()
        Dim i, j, k As Integer
        Dim dr As DataRow
        Dim atrasofila As Integer
        ' falta probar bien, con datos reales
        For i = 0 To dsAtraso.Tables(0).Rows.Count - 1
            For j = 0 To dsPorcentajes.Tables(0).Rows.Count - 2
                dr = dt.NewRow
                If dsAtraso.Tables(0).Rows(i).Item("DIASATRASO") > dsPorcentajes.Tables(0).Rows(j).Item("FINPERIODO") Then
                    atrasofila = dsPorcentajes.Tables(0).Rows(i).Item("FINPERIODO")
                    dr = dsAtraso.Tables(0).Rows(i)
                    dr("DIASATRASO") = atrasofila
                    dr("PORCENTAJEINCLUMPLIMIENTO") = CDbl(dr("MONTOATRASO").ToString) * atrasofila * CDbl(dsPorcentajes.Tables(0).Rows(j).Item("PORCENTAJE").ToString)
                    dt.Rows.Add(dr)
                ElseIf dsAtraso.Tables(0).Rows(i).Item("DIASATRASO") < dsPorcentajes.Tables(0).Rows(j).Item("INICIOPERIODO") Then
                    j = dsPorcentajes.Tables(0).Rows.Count - 2
                ElseIf dsAtraso.Tables(0).Rows(i).Item("DIASATRASO") <= dsPorcentajes.Tables(0).Rows(j).Item("INICIOPERIODO") Then
                    atrasofila = dsPorcentajes.Tables(0).Rows(j).Item("FINPERIODO") - dsAtraso.Tables(0).Rows(i).Item("DIASATRASO")
                    dr = dsAtraso.Tables(0).Rows(i)
                    dr("DIASATRASO") = atrasofila
                    dr("PORCENTAJEINCLUMPLIMIENTO") = CDbl(dr("MONTOATRASO").ToString) * atrasofila * CDbl(dsPorcentajes.Tables(0).Rows(i).Item("PORCENTAJE").ToString)
                    dt.Rows.Add(dr)
                End If
            Next
            For k = 0 To dsNoEntregado.Tables(0).Rows.Count - 1
                dr = dt.NewRow
                If dsAtraso.Tables(0).Rows(i).Item("RENGLON") = dsNoEntregado.Tables(0).Rows(k).Item("RENGLON") Then
                    dr = dsNoEntregado.Tables(0).Rows(k)
                    dr("PORCENTAJEINCLUMPLIMIENTO") = CDbl(dr("MONTOATRASO").ToString) * CDbl(dsPorcentajes.Tables(0).Rows(j).Item("PORCENTAJE").ToString)
                    dt.Rows.Add(dr)
                End If
            Next
        Next

        dsMulta.Tables.Add(dt)

        Return dsMulta

    End Function

    Public Function calcularMulta2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDNOTA As Integer) As DataSet
        Dim dsAtraso As DataSet
        Dim dsNoEntregado As DataSet
        Dim dsMulta As New DataSet
        Dim mdb2 As New dbPORCENTAJESMULTAS
        Dim dsPorcentajes As DataSet
        Dim dt As New DataTable
        dsPorcentajes = mdb2.ObtenerDataSetPorID
        dsAtraso = mDb.ObtenerMultasAtrasoDS(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
        dsNoEntregado = mDb.ObtenerMultasNoEntregadoDS(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA)
        dt = tablaMultas()
        Dim i, j, k As Integer
        Dim dr As DataRow
        Dim atrasofila As Integer
        ' falta probar bien, con datos reales
        For i = 0 To dsAtraso.Tables(0).Rows.Count - 1
            For j = 0 To dsPorcentajes.Tables(0).Rows.Count - 2
                dr = dt.NewRow
                If dsAtraso.Tables(0).Rows(i).Item("DIASATRASO") > dsPorcentajes.Tables(0).Rows(j).Item("FINPERIODO") Then
                    atrasofila = dsPorcentajes.Tables(0).Rows(i).Item("FINPERIODO")
                    dr = dsAtraso.Tables(0).Rows(i)
                    dr("DIASATRASO") = atrasofila
                    dr("PORCENTAJEINCLUMPLIMIENTO") = CDbl(dr("MONTOATRASO").ToString) * atrasofila * CDbl(dsPorcentajes.Tables(0).Rows(j).Item("PORCENTAJE").ToString)
                    dt.Rows.Add(dr)
                ElseIf dsAtraso.Tables(0).Rows(i).Item("DIASATRASO") < dsPorcentajes.Tables(0).Rows(j).Item("INICIOPERIODO") Then
                    j = dsPorcentajes.Tables(0).Rows.Count - 2
                ElseIf dsAtraso.Tables(0).Rows(i).Item("DIASATRASO") <= dsPorcentajes.Tables(0).Rows(j).Item("INICIOPERIODO") Then
                    atrasofila = dsPorcentajes.Tables(0).Rows(j).Item("FINPERIODO") - dsAtraso.Tables(0).Rows(i).Item("DIASATRASO")
                    dr = dsAtraso.Tables(0).Rows(i)
                    dr("DIASATRASO") = atrasofila
                    dr("PORCENTAJEINCLUMPLIMIENTO") = CDbl(dr("MONTOATRASO").ToString) * atrasofila * CDbl(dsPorcentajes.Tables(0).Rows(i).Item("PORCENTAJE").ToString)
                    dt.Rows.Add(dr)
                End If
            Next
            For k = 0 To dsNoEntregado.Tables(0).Rows.Count - 1
                dr = dt.NewRow
                If dsAtraso.Tables(0).Rows(i).Item("RENGLON") = dsNoEntregado.Tables(0).Rows(k).Item("RENGLON") Then
                    dr = dsNoEntregado.Tables(0).Rows(k)
                    dr("PORCENTAJEINCLUMPLIMIENTO") = CDbl(dr("MONTOATRASO").ToString) * CDbl(dsPorcentajes.Tables(0).Rows(j).Item("PORCENTAJE").ToString)
                    dt.Rows.Add(dr)
                End If
            Next
        Next

        dsMulta.Tables.Add(dt)

        Return dsMulta

    End Function

    Private Function tablaMultas() As Data.DataTable
        Dim T As New Data.DataTable
        Dim col As New Data.DataColumn

        '0 RENGLON
        col = New Data.DataColumn("RENGLON", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '1 PRECIOUNITARIO
        col = New Data.DataColumn("PRECIOUNITARIO", System.Type.GetType("System.Double"))
        T.Columns.Add(col)
        '2 CANTIDADCONTRATADA
        col = New Data.DataColumn("CANTIDADCONTRATADA", System.Type.GetType("System.Double"))
        T.Columns.Add(col)
        '3 CANTIDADENTREGADAATRASO
        col = New Data.DataColumn("CANTIDADENTREGADAATRASO", System.Type.GetType("System.Double"))
        T.Columns.Add(col)
        '4 FECHAENTREGAPROGRAMADA
        col = New Data.DataColumn("FECHAENTREGAPROGRAMADA", System.Type.GetType("System.DateTime"))
        T.Columns.Add(col)
        '5 FECHAENTREGAREAL
        col = New Data.DataColumn("FECHAENTREGAREAL", System.Type.GetType("System.DateTime"))
        T.Columns.Add(col)
        '6 MONTOATRASO
        col = New Data.DataColumn("MONTOATRASO", System.Type.GetType("System.Double"))
        T.Columns.Add(col)
        '7 DIASATRASO
        col = New Data.DataColumn("DIASATRASO", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '8 ENTREGA
        col = New Data.DataColumn("ENTREGA", System.Type.GetType("System.Int32"))
        T.Columns.Add(col)
        '9 PORCENTAJEINCLUMPLIMIENTO
        col = New Data.DataColumn("PORCENTAJEINCLUMPLIMIENTO", System.Type.GetType("System.Double"))
        T.Columns.Add(col)

        Return T

    End Function

    Public Function copiarRenglonesAudiencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer, ByVal IDNOTA As Integer) As Integer
        Try
            mDb.copiarRenglonesAudiencia(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMULTA, IDNOTA)
            Return 1
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function encabezadoAudiencia_Multa(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDNOTA As String, ByVal IDPLANTILLA As Integer, ByVal TIPO As Integer) As Integer
        Try
            Return mDb.encabezadoAudiencia_Multa(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA, IDPLANTILLA, TIPO)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function prefijoArchivo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer) As String
        Try
            Return mDb.prefijoArchivo(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMULTA)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function modificarDetalle(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer, ByVal IDDETALLE As Integer, ByVal CANTIDAD As Integer, ByVal DIAS As Integer, ByVal JUSTIFICACION As String) As Integer
        Try
            Return mDb.modificarDetalle(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMULTA, IDDETALLE, CANTIDAD, DIAS, JUSTIFICACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

End Class
