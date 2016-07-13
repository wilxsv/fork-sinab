Partial Public Class cCLAUSULASPLANTILLA

    Public Function ObtenerDataSetporPlantilla(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetporPlantilla(IDESTABLECIMIENTO, IDPLANTILLA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function AgregarCLAUSULASPLANTILLA(ByVal aEntidad As CLAUSULASPLANTILLA) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarxClausula(ByVal aEntidad As entidadBase, ByVal ORDEN_ACTUAL As Integer) As Integer
        Try
            Return mDb.ActualizarxClausula(aEntidad, ORDEN_ACTUAL)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerOrden(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Integer, ByVal IDCLAUSULA As Integer) As Integer
        Try
            Return mDb.obtenerOrden(IDESTABLECIMIENTO, IDPLANTILLA, IDCLAUSULA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function validaOrden(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Integer, ByVal IDCLAUSULA As Integer, ByVal ORDEN As Integer) As Integer
        Try
            Return mDb.validaOrden(IDESTABLECIMIENTO, IDPLANTILLA, IDCLAUSULA, ORDEN)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    'Esta función permite obtener un listado de las clausulas que pertenecen a la plantilla seleccionada
    'el listado contiene los siguientes campos IDCLAUSULA, NOMBRE, ORDEN, ESREQUERIDA
    'Creado por Juan José Rivas
    '22/01/2007
    Public Function obtenerClausulasPlantillaDs(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal tipo As Integer, ByVal NOMODIFICATIVA As Integer) As DataSet
        Try
            Return mDb.obtenerClausulasPlantillaDs(IDESTABLECIMIENTO, IDPLANTILLA, IDCONTRATO, IDPROVEEDOR, tipo, NOMODIFICATIVA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
