Partial Class cQUEDANS

    ''' <summary>
    ''' Agregar un quedan nuevo
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo QUEDAN
    ''' <returns>
    ''' numero de registro afectados por la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function AgregarQUEDANS(ByVal aEntidad As QUEDANS) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Validar la existencia de quedan para el proveedor para un contrato especifico
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador establecimiento
    ''' <param name="IDCONTRATO"></param> identificador de contrato
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <param name="IDTIPOGARANTIA"></param> identificador de tipo de garantia
    ''' <param name="IDGARANTIACONTRATO"></param> identificador de garantia contrato
    ''' <returns>
    ''' verdadero si quedan existe
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarExistenciaQuedan(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDTIPOGARANTIA As Int32, ByVal IDGARANTIACONTRATO As Int32) As Boolean
        Try
            Return mDb.ValidarExistenciaQuedan(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, IDTIPOGARANTIA, IDGARANTIACONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Recupera la informacion de datos para la elaboracion de quedan
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo QUEDAN
    ''' <returns>
    ''' Numero de registros recuperados
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerInformacionQuedan(ByRef aEntidad As QUEDANS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.RecuperarInformacionQuedan(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Obtener idntificador de quedan
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo QUEDAN
    ''' <returns>
    ''' el numero de identificador
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerIdQuedan(ByRef aEntidad As QUEDANS) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.ObtenerIdQuedan(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Dataset con la informacion necesaria de los contratos con referente al quedan
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDCONTRATO"></param> identificador del contrato
    ''' <param name="IDTIPOGARANTIA"></param> identificador del tipo de garantia
    ''' <param name="IDPROVEEDOR"></param> identificador del proveedor
    ''' <param name="IDGARANTIACONTRATO"></param> identificador de la garantia contrato
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DatasetContratoQuedan(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDTIPOGARANTIA As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDGARANTIACONTRATO As Int32) As DataSet
        Return mDb.DatasetContratoQuedan(IDESTABLECIMIENTO, IDCONTRATO, IDTIPOGARANTIA, IDPROVEEDOR, IDGARANTIACONTRATO)
    End Function

    ''' <summary>
    ''' Dataset con la informacion necesaria para la elaboracion del reporte de quedan
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador del establecimiento
    ''' <param name="IDCONTRATO"></param> identificador de contrato
    ''' <param name="IDTIPOGARANTIA"></param> identificador de tipo de garantia
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <param name="IDQUEDAN"></param> identificador de quedan
    ''' <param name="IDGARANTIACONTRATO"></param> identificador de garantia contrato
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DatasetReporteQuedan(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDTIPOGARANTIA As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDQUEDAN As Int32, ByVal IDGARANTIACONTRATO As Int32) As DataSet
        Return mDb.DatasetReporteQuedan(IDESTABLECIMIENTO, IDCONTRATO, IDTIPOGARANTIA, IDPROVEEDOR, IDQUEDAN, IDGARANTIACONTRATO)
    End Function

End Class
