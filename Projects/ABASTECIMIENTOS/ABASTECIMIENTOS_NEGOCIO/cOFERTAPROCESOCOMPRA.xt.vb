Partial Public Class cOFERTAPROCESOCOMPRA

#Region " Metodos Agregados "

    Public Function ActualizarOfertaProcesoCompraRecepcion(ByVal aEntidad As OFERTAPROCESOCOMPRA) As Integer
        Try
            Return mDb.ActualizarOfertaProcesoCompra(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarMontos(ByVal aEntidad As OFERTAPROCESOCOMPRA) As Integer
        Try
            Return mDb.ActualizarMontos(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarInfoFinanciera(ByVal aEntidad As OFERTAPROCESOCOMPRA, Optional ByVal joker As Integer = 0) As Integer
        Try
            Return mDb.ActualizarInfoFinanciera(aEntidad, joker)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerInfoFinanciera(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal ordenllegada As Int32) As DataSet
        Try
            Return mDb.ObtenerInfoFinanciera(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ordenllegada)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerOrdenLLegada(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerOrdenLLegada(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarObservacionDocumento(ByVal aEntidad As OFERTAPROCESOCOMPRA) As Integer
        Try
            Return mDb.ActualizarObservacionDocumento(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerObservacionDocumento(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROCESOCOMPRA As Int64, ByVal idproveedor As Integer) As String
        Try
            Return mDb.ObtenerDocumentoObservacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarFechaExamen(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal FECHAEXAMEN As DateTime) As Integer
        Try
            Return mDb.ActualizarFechaExamen(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, FECHAEXAMEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ValidarInformacionFinanciera(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataTable
        Dim mComOFPC As New cOFERTAPROCESOCOMPRA
        Dim i As Integer

        Dim mComponente As New cRECEPCIONOFERTAS
        Dim ds As DataSet
        ds = mComponente.ObtenerDataSet_OfertasRecibidas(IDPROCESOCOMPRA, IDESTABLECIMIENTO)

        Dim dsT As New DataTable
        dsT.Columns.Add(New DataColumn("ORDENLLEGADA", GetType(Integer)))
        dsT.Columns.Add(New DataColumn("PROVEEDOR", GetType(String)))
        dsT.Columns.Add(New DataColumn("INFORMACIONFALTANTE", GetType(String)))

        For i = 0 To ds.Tables(0).Rows.Count - 1
            'Proveedor = ds.Tables(0).Rows(i).Item("NOMBRE")
            If mComOFPC.ObtenerDataSetPorId(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ds.Tables(0).Rows(i).Item("IDPROVEEDOR")).Tables(0).Rows.Count > 0 Then

            Else
                Dim datar As DataRow = dsT.NewRow
                datar(0) = ds.Tables(0).Rows(i).Item("ORDENLLEGADA")
                datar(1) = ds.Tables(0).Rows(i).Item("NOMBRE")
                datar(2) = "FALTA INFORMACIÓN FINANCIERA"
                dsT.Rows.Add(datar)
            End If
        Next

        Return dsT

    End Function

    Public Function ValidarIngresoProductosOfertas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataTable
        Dim mComDO As New cDETALLEOFERTA
        Dim i As Integer

        Dim mComponente As New cRECEPCIONOFERTAS
        Dim ds As DataSet
        ds = mComponente.ObtenerDataSet_OfertasRecibidas(IDPROCESOCOMPRA, IDESTABLECIMIENTO)

        Dim dsT As New DataTable
        dsT.Columns.Add(New DataColumn("ORDENLLEGADA", GetType(Integer)))
        dsT.Columns.Add(New DataColumn("PROVEEDOR", GetType(String)))
        dsT.Columns.Add(New DataColumn("INFORMACIONFALTANTE", GetType(String)))

        For i = 0 To ds.Tables(0).Rows.Count - 1

            If mComDO.ObtenerDataSetPorId(IDESTABLECIMIENTO, IDPROCESOCOMPRA, ds.Tables(0).Rows(i).Item("IDPROVEEDOR")).Tables(0).Rows.Count > 0 Then

            Else
                Dim datar As DataRow = dsT.NewRow
                datar(0) = ds.Tables(0).Rows(i).Item("ORDENLLEGADA")
                datar(1) = ds.Tables(0).Rows(i).Item("NOMBRE")
                datar(2) = "FALTA INFORMACIÓN DE RENGLONES"
                dsT.Rows.Add(datar)
            End If
        Next

        Return dsT
    End Function

    Public Function ObtenerDesiertosNoAdjudicados(ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Try
            Return mDb.ObtenerDesiertosNoAdjudicados(IDPROCESOCOMPRA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
