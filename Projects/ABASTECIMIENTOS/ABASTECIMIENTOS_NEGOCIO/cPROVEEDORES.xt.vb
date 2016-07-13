Partial Public Class cPROVEEDORES

#Region "  Metodos Agregados  "

    Public Function ObtenerDataSetIDPROVEEDOR(ByVal codigoProveedor As String) As Integer
        Try
            Return mDb.ObtenerDataSetIDPROVEEDOR(codigoProveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDsProveedorProcesoCompra(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDsProveedorProcesoCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerDataSetPROVEEDOROrden(Optional ByVal tipo As Integer = 1) As DataSet
        Try
            Return mDb.ObtenerDataSetPROVEEDOROrden(tipo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerdSProveedorNoBaseEntrega(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet
        Try
            Return mDb.obtenerdSProveedorNoBaseEntrega(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerDsProveedorProcesoCompraContrato(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDsProveedorProcesoCompraContrato(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerDsProveedorProcesoCompraContratoMultas(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDANALISTA As Integer) As DataSet
        Try
            Return mDb.ObtenerDsProveedorProcesoCompraContratoMultas(IDPROCESOCOMPRA, IDESTABLECIMIENTO, IDANALISTA)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerDatasetProveedorPorPeriodo(ByVal fini As Date, ByVal ffin As Date, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDatasetProveedorPorPeriodo(fini, ffin, IDESTABLECIMIENTO)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DevolverProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Int64, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.DevolverProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DetalleProveedoresContratados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Int64, ByVal IDCONTRATO As Integer) As DataSet
        Try
            Return mDb.DetalleProveedoresContratados(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'JOSE CHAVEZ
    Public Function ObtenerProveedoresClasificados(ByVal CLASIFICACION As Int16) As DataSet
        Try
            Return mDb.ObtenerProveedoresClasificados(CLASIFICACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ProveedoresConContratosDistribuidos() As DataSet
        Try
            Return mDb.ProveedoresConContratosDistribuidos
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Validar Codigo Proveedores
    Public Function ValidarCodigoProveedor(ByVal CODIGOPROVEEDOR As String, ByVal IDPROVEEDOR As Int32) As Int16
        Try
            Return mDb.ValidarCodigoProveedor(CODIGOPROVEEDOR, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Validar Nombre Proveedores
    Public Function ValidarNombre(ByVal NOMBRE As String, ByVal IDPROVEEDOR As Int32) As Int16
        Try
            Return mDb.ValidarNombre(NOMBRE, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Validar Nombre Proveedores
    Public Function ValidarNIT(ByVal NIT As String, ByVal IDPROVEEDOR As Int32) As Int16
        Try
            Return mDb.ValidarNIT(NIT, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaordenada(ByVal tipo As Integer) As listaPROVEEDORES
        Try
            Return mDb.ObtenerListaordenada(tipo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetCODIGOPROVEEDOR(ByVal IDPROVEEDOR As Int32) As System.Data.DataSet
        Try
            Return mDb.ObtenerDataSetCODIGOPROVEEDOR(IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerUltimoCodigoProveedor() As String
        Try
            Return mDb.ObtenerUltimoCodigoProveedor()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerULTIMOID() As String
        Try
            Return mDb.ObtenerULTIMOID()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    'Busqueda
    Public Function BuscarListaCodigoNombre(ByVal BCRITERIO As String, ByVal BTIPO As Int16) As listaPROVEEDORES
        Try
            Return mDb.BuscarListaCodigoNombre(BCRITERIO, BTIPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProveedoresContrato(ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.obtenerProveedoresContrato(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaNombreOrdenada(Optional ByVal tipo As Integer = 1) As listaPROVEEDORES
        Try
            Return mDb.ObtenerListaNombreOrdenada(tipo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarOrdenada() As DataSet
        Try
            Return mDb.RecuperarOrdenada()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function DevolverProveedorPeriodo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal dsP As DataSet) As DataSet
        Try
            Return mDb.DevolverProveedorPeriodo(IDESTABLECIMIENTO, IDPROVEEDOR, dsP)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProveedoresAdjudicadosEnAlmacen(ByVal IDALMACEN As Integer) As DataSet
        Try
            Return mDb.obtenerProveedoresAdjudicadosEnAlmacen(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProveedoresContratoEnAlmacen(ByVal IDALMACEN As Integer) As DataSet
        Try
            Return mDb.ObtenerProveedoresContratoEnAlmacen(IDALMACEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProveedoresContratoEstablecimiento(ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerProveedoresContratoEstablecimiento(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerModalidadesCompraEnAlmacen(ByVal IDALMACEN As Integer, ByVal IDPROVEEDOR As Integer) As DataSet
        Try
            Return mDb.obtenerModalidadesCompraEnAlmacen(IDALMACEN, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProveedoresAdj(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal NOTIFICADOS As Boolean, Optional ByVal IDINSPECTOR As Integer = 0) As DataSet
        Try
            Return mDb.obtenerProveedoresAdj(IDESTABLECIMIENTO, IDPROCESOCOMPRA, NOTIFICADOS, IDINSPECTOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerProveedoresCertificados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal Notificados As Boolean) As DataSet
        Try
            Return mDb.obtenerProveedoresCertificados(IDESTABLECIMIENTO, IDPROCESOCOMPRA, Notificados)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
