Imports ABASTECIMIENTOS.DATOS

Public Class cPRODUCTOSESTABLECIMIENTOS
    Inherits controladorBase

    Private dbEntidad As New dbPRODUCTOSESTABLECIMIENTOS

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbPRODUCTOSESTABLECIMIENTOS()
    Private mEntidad As New PRODUCTOSESTABLECIMIENTOS
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int64) As listaPRODUCTOSESTABLECIMIENTOS
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerPRODUCTOSESTABLECIMIENTOS(ByRef aEntidad As PRODUCTOSESTABLECIMIENTOS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerPRODUCTOSESTABLECIMIENTOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int64) As PRODUCTOSESTABLECIMIENTOS
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPRODUCTO = IDPRODUCTO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarPRODUCTOSESTABLECIMIENTOS(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPRODUCTO As Int64) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPRODUCTO = IDPRODUCTO
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function AgregarPRODUCTOSESTABLECIMIENTOS(ByVal aEntidad As PRODUCTOSESTABLECIMIENTOS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function agregarProductoEstablecimiento(ByVal idEstablecimiento As Integer, ByVal idProducto As Integer) As Integer
        Try
            Return mDb.agregarProductoEstablecimiento(idEstablecimiento, idProducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function quitarPRODUCTOSESTABLECIMIENTOS(ByVal idEstablecimiento As Integer, ByVal idProducto As Integer) As Integer
        Try
            Return mDb.quitarProductoEstablecimiento(idEstablecimiento, idProducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

    Public Function obtenerListaProductosEstablecimientos(ByVal idEstablecimiento As Integer) As DataSet

        Try
            Dim ds As DataSet = dbEntidad.obtenerListaProductosEstablecimientos(idEstablecimiento)
            ds.Tables(0).TableName = "tabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function contarProductosEstablecimiento(ByVal idEstablecimiento As Integer, Optional ByVal filtro As String = "") As Integer

        Try
            Return dbEntidad.contarProductosEstablecimiento(idEstablecimiento, filtro)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerListaProductosNoEnEstablecimientos(ByVal idEstablecimiento As Integer, ByVal campoOrden As String, ByVal tipoOrden As String, ByVal inicio As Integer, ByVal limite As Integer, Optional ByVal filtro As String = "") As ArrayList

        Try
            Return dbEntidad.obtenerListaProductosNoEnEstablecimientos(idEstablecimiento, campoOrden, tipoOrden, inicio, limite, filtro)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function contarProductosNoEnEstablecimiento(ByVal idEstablecimiento As Integer, Optional ByVal filtro As String = "") As Integer

        Try
            Return dbEntidad.contarProductosNoEnEstablecimiento(idEstablecimiento, filtro)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    'Public Function moverProductoEstablecimiento(ByVal idEstablecimiento As Integer, ByVal listaProducto As String, ByVal accion As String) As Integer

    '    Dim tran As New DistributedTransaction

    '    Try

    '        Dim arr() As String = listaProducto.Split(",")

    '        For i As Integer = 0 To UBound(arr)

    '            Select Case accion
    '                Case "agregar"
    '                    dbEntidad.agregarProductoEstablecimiento(idEstablecimiento, arr(i), tran)
    '                Case "eliminar"
    '                    dbEntidad.quitarProductoEstablecimiento(idEstablecimiento, arr(i), tran)
    '            End Select

    '        Next

    '        tran.Commit()
    '    Catch ex As Exception
    '        tran.Abort()
    '    End Try


    'End Function
    Public Function obtenerIdProductoEstablecimiento(ByVal codProd As String) As DataSet
        Try
            Return mDb.obtenerIdProductoEstablecimiento(codProd)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function obtenerCodigoProductoEstablecimiento(ByVal CODIGO As String) As DataSet

        Try
            Return mDb.obtenerCodigoProductoEstablecimiento(CODIGO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function


End Class
