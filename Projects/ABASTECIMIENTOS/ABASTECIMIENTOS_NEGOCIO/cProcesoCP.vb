Public Class cProcesoCP
    Inherits controladorBase
    Private mDb As New dbProcesoCP()
    Private mProcesoCP As New PROCESOCP

    Public Function ObtenerPROCESOS() As DataSet
        Try
            Return mDb.ObtenerPROCESO()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    Public Function ObtenerPROCESOFiltrados(Optional ByVal idt As Integer = 0, Optional ByVal idestado As Integer = -1) As DataSet
        Try
            Return mDb.ObtenerPROCESOFiltrados(idt, idestado)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    'Public Function ObtenerListas() As DataSet
    '    Try
    '        Return mDb.ObtenerListas()
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return Nothing
    '    End Try
    'End Function

    Public Function ActualizarProceso(ByVal aProcesoCP As PROCESOCP) As Integer
        Try
            Return mDb.Actualizar(aProcesoCP)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function BuscarEstadoTipoProducto(ByVal idtipoproducto As Integer) As DataSet
        Try
            Return mDb.BuscarEstadoTipoProducto(idtipoproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function EliminarProceso(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer) As Integer
        Try
            mProcesoCP.IDPROCESO = IDPROCESO
            mProcesoCP.IDTIPOPRODUCTO = IDTIPOPRODUCTO
            Return mDb.Eliminar(mProcesoCP)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function ObtenerDataSetPorId2(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2(IDPROCESO, IDTIPOPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerID2(ByVal IDTIPOPRODUCTO As Integer) As Integer
        Try
            Return mDb.ObtenerID2(IDTIPOPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetProveedores(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, Optional ByVal NIT As String = "", Optional ByVal Nombre As String = "") As DataSet
        Try
            Return mDb.ObtenerDataSetProveedores(IDPROCESO, IDTIPOPRODUCTO, NIT, Nombre)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerProveedoresSINAB(ByVal NIT As String, ByVal NOMBRE As String) As DataSet
        Try
            Return mDb.ObtenerProveedoresSINAB(NIT, NOMBRE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function AgregarProveedorProceso(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer) As Integer
        Try
            Return mDb.AgregarProveedoresProceso(idproceso, idtipoproducto, idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function ObtenerNITyNombre(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer, ByVal idproveedor As Integer) As DataSet
        Try
            Return mDb.ObtenerNITyNombre(IDPROCESO, IDTIPOPRODUCTO, idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerProveedoresxProceso(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer) As DataSet
        Try
            Return mDb.ObtenerProveedoresxProceso(IDPROCESO, IDTIPOPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerCodNomPais(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer) As DataSet
        Try
            Return mDb.ObtenerCodNomPais(IDPROCESO, IDTIPOPRODUCTO, idproveedor, idproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetProductos(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, Optional ByVal CODIGO As String = "", Optional ByVal NOMBRE As String = "") As DataSet
        Try
            Return mDb.ObtenerDataSetProductos(IDPROCESO, IDTIPOPRODUCTO, IDPROVEEDOR, CODIGO, NOMBRE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerProductosSINAB(ByVal codigo As String, ByVal NOMBRE As String) As DataSet
        Try
            Return mDb.ObtenerProductosSINAB(codigo, NOMBRE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarEstadoProducto(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal FLAG As Char, ByVal OPERADOR As Char) As Integer
        Try
            Return mDb.ActualizarEstadoProducto(IDPROCESO, IDTIPOPRODUCTO, IDPROVEEDOR, FLAG, OPERADOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function AgregarProductoProveedor(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal usuario As String) As Integer
        Try
            Dim DS As New DataSet

            DS = mDb.ObtenerIdLista(idproducto, idtipoproducto)
            Dim idpp = mDb.AgregarProductoProveedor(idproceso, idtipoproducto, idproveedor, idproducto, DS.Tables(0).Rows(0).Item(0))
            Dim ID As Integer = mDb.ObtenerIdProductosPRoveedores(idproceso, idtipoproducto, idproveedor, idproducto)
            mDb.AgregarESTADOSPRODUCTOS(idproceso, idtipoproducto, idproveedor, idproducto, 1, DateTime.Now, "Estado Inicial", usuario, ID)
            mDb.ActualizarEstadoProducto(idproceso, idtipoproducto, idproveedor, "N", "+")
            Dim idAspectos As Integer = mDb.ObtenerIdAspectos()
            mDb.AgregarAspectosProductos(idAspectos, DS.Tables(0).Rows(0).Item(0))
            mDb.ActualizarIdAspectos(idproceso, idtipoproducto, idproveedor, idproducto, idAspectos, ID)
            Return idpp
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function AgregarESTADOSPRODUCTOS(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal estado As Integer, ByVal fecha As DateTime, ByVal comentario As String, ByVal usuario As String, ByVal ID As Integer) As Integer
        Try
            Return mDb.AgregarESTADOSPRODUCTOS(idproceso, idtipoproducto, idproveedor, idproducto, estado, fecha, comentario, usuario, ID)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerIdProductosPRoveedores(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer) As Integer
        Try
            Return mDb.ObtenerIdProductosPRoveedores(idproceso, idtipoproducto, idproveedor, idproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function AgregarAspecto(ByVal IDASPECTOS As Integer, ByVal IDA As Integer, ByVal ESTADO As Integer, ByVal FECHAEMISION As DateTime, ByVal FECHAVTO As DateTime, ByVal COMENTARIO As String, ByVal PC As String) As Integer
        Try
            mDb.EliminarAspecto(IDASPECTOS, IDA)
            mDb.AgregarASPECTO(IDASPECTOS, IDA, ESTADO, FECHAEMISION, FECHAVTO, COMENTARIO, PC)
            Return 1
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerIdLista(ByVal idproducto As Integer, ByVal idtipoproducto As Integer) As DataSet
        Try
            Return mDb.ObtenerIdLista(idproducto, idtipoproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerPaises() As DataSet
        Try
            Return mDb.ObtenerPaises()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerEstadosProductos(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ID As Integer) As DataSet
        Try
            Return mDb.ObtenerEstadosProductos(IDPROCESO, IDTIPOPRODUCTO, IDPROVEEDOR, IDPRODUCTO, ID)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerProcesoCompra(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ID As Integer) As DataSet
        Try
            Return mDb.ObtenerProcesoCompra(IDPROCESO, IDTIPOPRODUCTO, IDPROVEEDOR, IDPRODUCTO, ID)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerIdEstadoProducto(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ID As Integer) As Integer
        Try
            Return mDb.ObtenerIdEstadoProducto(IDPROCESO, IDTIPOPRODUCTO, IDPROVEEDOR, IDPRODUCTO, ID)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerIPC(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ID As Integer) As Integer
        Try
            Return mDb.ObtenerIPC(IDPROCESO, IDTIPOPRODUCTO, IDPROVEEDOR, IDPRODUCTO, ID)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerUltimoEstado(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ID As Integer) As String
        Try
            Return mDb.ObtenerUltimoEstado(IDPROCESO, IDTIPOPRODUCTO, IDPROVEEDOR, IDPRODUCTO, ID)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function AgregarProcesoCompra(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal procesocompra As String, ByVal ID As Integer) As Integer
        Try

            Dim IPC As Integer = mDb.ObtenerIPC(idproceso, idtipoproducto, idproveedor, idproducto, ID)
            mDb.AgregarProcesoCompra(idproceso, idtipoproducto, idproveedor, idproducto, IPC, procesocompra, ID)
            'mDb.ActualizarIPC(idproceso, idtipoproducto, idproveedor, idproducto, IPC)
            Return 1
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    'Public Function AgregarMasProcesoCompra(ByVal IPC As Integer, ByVal procesocompra As String) As Integer
    '    Try
    '        mDb.AgregarProcesoCompra(IPC, procesocompra)
    '        Return 1
    '    Catch ex As Exception
    '        ExceptionManager.Publish(ex)
    '        Return Nothing
    '    End Try
    'End Function
    Public Function EliminarProcesoCompra(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal IPC As Integer, ByVal ID As Integer) As Integer
        Try
            Return mDb.EliminarProcesoCompra(idproceso, idtipoproducto, idproveedor, idproducto, IPC, ID)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarProductosProveedores(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal id As Integer, ByVal NombreComercial As String, ByVal CSSP As String, ByVal CPF As String, ByVal Marca As String, ByVal IdPaisOrigen As String, ByVal Nombrefab As String, ByVal comentarios As String) As Integer
        Try
            Return mDb.ActualizarProductosProveedores(idproceso, idtipoproducto, idproveedor, idproducto, id, NombreComercial, CSSP, CPF, Marca, IdPaisOrigen, Nombrefab, comentarios)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDatosProductosProveedores(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal id As Integer) As DataSet
        Try
            Return mDb.ObtenerDatosProductosProveedores(idproceso, idtipoproducto, idproveedor, idproducto, id)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetAspectos(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal id As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetAspectos(IDPROCESO, IDTIPOPRODUCTO, IDPROVEEDOR, IDPRODUCTO, id)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetAspecto(ByVal idaspectos As Integer, ByVal ida As Integer, ByVal idlista As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetAspecto(idaspectos, ida, idlista)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerPROCESOxSuministro(ByVal idsuministro As Integer) As DataSet
        Try
            Return mDb.ObtenerPROCESOxSuministro(idsuministro)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerPROCESOxSuministro2(ByVal idsuministro As Integer) As DataSet
        Try
            Return mDb.ObtenerPROCESOxSuministro2(idsuministro)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerPROCESOSCOMPRA(ByVal IDESTABLECIMIENTO As Integer, ByVal idsuministro As Integer) As DataSet
        Try
            Return mDb.ObtenerPROCESOSCOMPRA(IDESTABLECIMIENTO, idsuministro)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporte1(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal nit As String, ByVal corrproducto As String) As DataSet
        Try
            Return mDb.ObtenerReporte1(idproceso, idtipoproducto, nit, corrproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporte7(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal nit As String, ByVal idproveedor As Integer, ByVal corrproducto As String) As DataSet
        Try
            Return mDb.ObtenerReporte7(idproceso, idtipoproducto, nit, idproveedor, corrproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteCP1y7(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer) As DataSet
        Try
            Return mDb.ObtenerReporteCP1y7(idproceso, idtipoproducto, idproveedor, idproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteCP2(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal nit As String, ByVal corrproducto As String) As DataSet
        Try
            Return mDb.ObtenerReporteCP2(idproceso, idtipoproducto, idproveedor, idproducto, nit, corrproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteCP3(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal NIT As String, ByVal CORRPRODUCTO As String) As DataSet
        Try
            Return mDb.ObtenerReporteCP3(idproceso, idtipoproducto, idproveedor, idproducto, NIT, CORRPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteCP5(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal NIT As String, ByVal CORRPRODUCTO As String) As DataSet
        Try
            Return mDb.ObtenerReporteCP5(idproceso, idtipoproducto, idproveedor, idproducto, NIT, CORRPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteCP4(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal NIT As String, ByVal FECHALIMITE As DateTime) As DataSet
        Try
            Return mDb.ObtenerReporteCP4(idproceso, idtipoproducto, idproveedor, NIT, FECHALIMITE)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporteCP6(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal NIT As String, ByVal idprocesocompra As Integer) As DataSet
        Try
            Return mDb.ObtenerReporteCP6(idproceso, idtipoproducto, idproveedor, NIT, idprocesocompra)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function EliminarUnProducto(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal id As Integer) As Integer
        Try

            mDb.EliminarPC(IDPROCESO, IDTIPOPRODUCTO, idproveedor, idproducto, id)
            Dim idaspectos As Integer = mDb.ObtenerIdAspectos2(IDPROCESO, IDTIPOPRODUCTO, idproveedor, idproducto, id)
            mDb.EliminarASPECTOSPRODUCTOS(idaspectos)
            mDb.EliminareSTADOSpRODUCTOS(IDPROCESO, IDTIPOPRODUCTO, idproveedor, idproducto, id)
            mDb.EliminarPRODUCTOSPROVEEDORES(IDPROCESO, IDTIPOPRODUCTO, idproveedor, idproducto, id)

            Return 1

        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function EliminarUnProveedor(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal idproveedor As Integer) As Integer
        Try

            mDb.EliminarPC2(IDPROCESO, IDTIPOPRODUCTO, idproveedor)
            Dim ds As New DataSet
            ds = mDb.ObtenerIdAspectos3(IDPROCESO, IDTIPOPRODUCTO, idproveedor)
            Dim i As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    mDb.EliminarASPECTOSPRODUCTOS(ds.Tables(0).Rows(i).Item(0))
                Next
            End If

            mDb.EliminareSTADOSpRODUCTOS2(IDPROCESO, IDTIPOPRODUCTO, idproveedor)
            mDb.EliminarPRODUCTOSPROVEEDORES2(IDPROCESO, IDTIPOPRODUCTO, idproveedor)
            mDb.EliminarPROVEEDORESPROCESO(IDPROCESO, IDTIPOPRODUCTO, idproveedor)

            Return 1

        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function chequearListadoOficial(ByVal IDproducto As Integer) As Integer
        Try
            Return mDb.chequearListadoOficial(IDproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function chequearPerteneceLista(ByVal IDproducto As Integer) As Integer
        Try
            Return mDb.chequearPerteneceLista(IDproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function VerificarSiExisteProducto(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal NombreComercial As String, ByVal Marca As String, ByVal IdPaisOrigen As String, ByVal Nombrefab As String) As Integer
        Try
            Return mDb.VerificarSiExisteProducto(idproceso, idtipoproducto, idproveedor, idproducto, NombreComercial, Marca, IdPaisOrigen, Nombrefab)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
End Class
