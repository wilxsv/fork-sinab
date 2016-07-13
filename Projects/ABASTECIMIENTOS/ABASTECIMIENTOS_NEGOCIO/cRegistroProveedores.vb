Public Class cRegistroProveedores
    Inherits controladorBase
    Private mDb As New dbRegistroProveedores()
    Private mListaCP As New ListaCP

    Public Function ObtenerListas() As DataSet
        Try
            Return mDb.ObtenerLISTAS()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
    Public Function ObtenerTiposSanciones() As DataSet
        Try
            Return mDb.ObtenerTiposSanciones()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerCausas() As DataSet
        Try
            Return mDb.ObtenerCausas()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDocumentos(ByVal C1 As Integer, ByVal C2 As Integer) As DataSet
        Try
            Return mDb.ObtenerDocumentos(C1, C2)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerSuministros() As DataSet
        Try
            Return mDb.ObtenerSuministros()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarLista(ByVal aLista As ListaCP) As Integer
        Try
            Return mDb.Actualizar(aLista)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function EliminarLista(ByVal IDLISTA As Int32, ByVal IDSUMINISTRO As Integer) As Integer
        Try
            mListaCP.IDLISTA = IDLISTA
            mListaCP.IDSUMINISTRO = IDSUMINISTRO
            Return mDb.Eliminar(mListaCP)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function ObtenerDataSetPorId2(ByVal IDLISTA As Int32, ByVal IDSUMINISTRO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2(IDLISTA, IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerID2(ByVal IDSUMINISTRO As Integer) As Integer
        Try
            Return mDb.ObtenerID2(IDSUMINISTRO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try


    End Function
    Public Function ObtenerDataSetPorID2TIPOSANCION(ByVal IDTIPOSANCION As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2TIPOSANCION(IDTIPOSANCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetPorID2CAUSAS(ByVal IDCAUSA As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2CAUSAS(IDCAUSA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetPorID2DOCUMENTOS(ByVal IDDOCUMENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2DOCUMENTOS(IDDOCUMENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerIDTipoSancion() As String
        Try
            Return mDb.ObtenerIDTipoSancion()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerIDCausas() As String
        Try
            Return mDb.ObtenerIDCausas()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerIDDocumentos() As String
        Try
            Return mDb.ObtenerIDDocumentos()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDataSetPorIDTiposancion() As DataSet
        Try
            Return mDb.ObtenerDataSetPorIDTiposancion()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function EliminarTipoSancion(ByVal idtiposancion As Integer) As Integer
        Try
            Return mDb.EliminarTipoSancion(idtiposancion)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function EliminarCausas(ByVal idcausa As Integer) As Integer
        Try
            Return mDb.EliminarCAusas(idcausa)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function EliminarDocumentos(ByVal iddocumento As Integer) As Integer
        Try
            Return mDb.EliminarDocumentos(iddocumento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarTipoSancion(ByVal aEntidad As TIPOSANCIONRP) As Integer
        Try
            Return mDb.ActualizarTipoSancion(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarCausas(ByVal aEntidad As CAUSASRP) As Integer
        Try
            Return mDb.ActualizarCausas(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarDocumentos(ByVal aEntidad As DOCUMENTOSRP) As Integer
        Try
            Return mDb.ActualizarDocumentos(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerProveedores() As DataSet
        Try
            Return mDb.ObteneProveedores()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerProveedoresFiltrados(ByVal NIT As String, ByVal Nombre As String) As DataSet
        Try
            Return mDb.ObtenerProveedoresFiltrados(NIT, Nombre)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDatosProveedor(ByVal IDPROVEEDOR As Int32) As System.Data.DataSet
        Try
            Return mDb.ObtenerDatosProveedor(IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerUnProveedores(ByVal idproveedor As Integer) As DataSet
        Try
            Return mDb.ObtenerUnProveedor(idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ActualizarProveedores(ByVal aEntidad As PROVEEDORESRG) As Integer
        Try
            Return mDb.ActualizarProveedores(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function AgregarProveedores(ByVal aEntidad As PROVEEDORESRG) As Integer
        Try
            Return mDb.AgregarProveedores(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerProductosProveedor(ByVal idproveedor As Integer) As DataSet
        Try
            Return mDb.ObteneProductosProveedores(idproveedor)
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
    Public Function EliminarProductoProveedor(ByVal idproveedor As Integer, ByVal idproducto As Integer) As Integer
        Try
            Return mDb.EliminarProductoProveedor(idproveedor, idproducto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function chequearListadoOficial(ByVal idproducto As Integer, ByVal idsuministro As Integer) As Integer
        Try
            Return mDb.chequearListadoOficial(idproducto, idsuministro)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function AgregarProductosProveedores(ByVal idproducto As Integer, ByVal idproveedor As Integer) As Integer
        Try
            mDb.EliminarProductoProveedor(idproveedor, idproducto)
            Return mDb.AgregarProductosProveedores(idproducto, idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDocumentosProveedores(ByVal idproveedor As Integer) As DataSet
        Try
            Return mDb.ObtenerDocumentosProveedores(idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function AgregarDocumentosProveedores(ByVal iddocumento As Integer, ByVal idproveedor As Integer, ByVal fechaemision As DateTime, ByVal fechacaducidad As DateTime, ByVal fechareporte As DateTime, ByVal usuario As String, ByVal personavistobueno As String) As Integer
        Try
            mDb.EliminarDocumentosProveedor(idproveedor, iddocumento)
            Return mDb.AgregarDocumentosProveedores(iddocumento, idproveedor, fechaemision, fechacaducidad, fechareporte, usuario, personavistobueno)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerEstadosProveedores(ByVal idproveedor As Integer) As DataSet
        Try
            Return mDb.ObtenerEstadosProveedores(idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerUltimoEstado(ByVal idproveedor As Integer) As Integer
        Try
            Return mDb.ObtenerUltimoEstado(idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerUnEstadosProveedores(ByVal idproveedor As Integer) As DataSet
        Try
            Return mDb.ObtenerEstadosProveedores(idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function AgregarEstadosProveedores(ByVal idproveedor As Integer, ByVal estado As Integer, ByVal fechacambio As DateTime, ByVal idcausa As Integer, ByVal fechainicioi As DateTime, ByVal fechafini As DateTime, ByVal comentario As String) As Integer
        Try
            Return mDb.AgregarEstadosProveedores(idproveedor, mDb.ObtenerUltimoIdEstado(idproveedor), estado, fechacambio, idcausa, fechainicioi, fechafini, comentario)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerSancionesProveedores(ByVal idproveedor As Integer) As DataSet
        Try
            Return mDb.ObtenerSancionesProveedores(idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function AgregarSancionesProveedores(ByVal idproveedor As Integer, ByVal idtiposancion As Integer, ByVal fechaimpresion As DateTime, ByVal fechafirme As DateTime, ByVal fechapago As DateTime, ByVal numoferta As String, ByVal numcontrato As String, ByVal numpc As String, ByVal comentario As String, ByVal monto As Decimal) As Integer
        Try
            Return mDb.AgregarSancionesProveedores(idproveedor, mDb.ObtenerUltimoIdSancion(idproveedor), idtiposancion, fechaimpresion, fechafirme, fechapago, numoferta, numcontrato, numpc, comentario, monto)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function EliminarProveedor(ByVal idproveedor As Integer) As Integer
        Try
            If mDb.BuscarExistenciaIDProveedor(idproveedor) = 0 And mDb.BuscarExistenciaIDProveedor2(idproveedor) = 0 Then
                mDb.EliminarSANCIONESProveedor(idproveedor)
                mDb.EliminarpRODUCTOSProveedor(idproveedor)
                mDb.EliminarESTADOSProveedor(idproveedor)
                mDb.EliminarDocumentosProveedor(idproveedor)
                Return mDb.EliminarProveedor(idproveedor)
            Else
                Return 0
            End If
            
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporte1y3(ByVal idproveedor As Integer, ByVal codigo As String) As DataSet
        Try
            Return mDb.ObtenerReporte1y3(idproveedor, codigo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerReporte2(ByVal idproveedor As Integer) As DataSet
        Try
            Return mDb.ObtenerReporte2(idproveedor)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerUnDocumentoProveedores(ByVal idproveedor As Integer, ByVal iddocumento As Integer) As DataSet
        Try
            Return mDb.ObtenerDocumentoProveedores(idproveedor, iddocumento)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
End Class
