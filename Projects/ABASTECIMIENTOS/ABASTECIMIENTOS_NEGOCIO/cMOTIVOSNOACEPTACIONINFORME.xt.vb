Partial Public Class cMOTIVOSNOACEPTACIONINFORME

#Region " Metodos Agregados "

    ''' <summary>
    ''' Elimina todos los motivos de no aceptación asociados a un informe de muestras.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDINFORME">Identificador del informe de muestras.</param>
    ''' <returns>Integer.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function EliminarMOTIVOSNOACEPTACIONINFORME(ByVal IDESTABLECIMIENTO As Int32, ByVal IDINFORME As Int32) As Integer
        Try
            Return mDb.EliminarMOTIVOSNOACEPTACIONINFORME(IDESTABLECIMIENTO, IDINFORME)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Obtiene todos los motivos de no aceptación correspondientes a un informe de muestras.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDINFORME">Identificador del informe de muestras.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerMOTIVOSNOACEPTACIONINFORME(ByVal IDESTABLECIMIENTO As Int32, ByVal IDINFORME As Int32) As DataSet
        Try
            Return mDb.ObtenerMOTIVOSNOACEPTACIONINFORME(IDESTABLECIMIENTO, IDINFORME)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
