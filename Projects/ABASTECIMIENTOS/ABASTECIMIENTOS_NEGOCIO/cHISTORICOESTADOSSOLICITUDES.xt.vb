Partial Public Class cHISTORICOESTADOSSOLICITUDES

    ''' <summary>
    ''' Agregar un historico de estado de solicitudes
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo HISTORICOESTADOSSOLICITUDES
    ''' <returns>
    ''' numero de registros afectados con la operación
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history>
    Public Function AgregarHISTORICOESTADOSSOLICITUDES(ByVal aEntidad As HISTORICOESTADOSSOLICITUDES) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' genera un identificador de historico de estado de solicitudes
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo HISTORICOESTADOSSOLICITUDES
    ''' <returns>
    ''' numero de registros afectados con la operación
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history>
    Public Function id_HISTORICOESTADOSSOLICITUDES(ByVal aEntidad As HISTORICOESTADOSSOLICITUDES) As Integer
        Try
            Return mDb.ObtenerID(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

End Class
