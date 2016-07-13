Partial Class cCARGADATOSSIM

    ''' <summary>
    ''' Agregar registro a CARGADATOSSIM
    ''' </summary>
    ''' <param name="aEntidad"></param>
    ''' <returns>
    ''' El valor de filas afectadas
    ''' </returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function AgregarCARGADATOSSIM(ByVal aEntidad As CARGADATOSSIM) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Obtener el numero de correlativo
    ''' </summary>
    ''' <param name="aEntidad"></param> 'entidad tipo CARGADATOSSIM
    ''' <returns>
    ''' numero de correlativo
    ''' </returns>
    ''' <remarks></remarks>
    '''<history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function id_Carga(ByVal aEntidad As CARGADATOSSIM) As Integer
        Return mDb.ObtenerID(aEntidad)
    End Function

    ''' <summary>
    ''' Obtener el numero de carga que se realizo del SIM al SAB pero no se ha generado consumo
    ''' </summary>
    ''' <param name="idestablecimiento"></param> 'identificador de establecimiento
    ''' <returns>
    ''' numero de id de carga
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_CARGADATOSSIM</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerCargaSIM(ByVal idestablecimiento As Int32) As Integer
        Return mDb.ObtenerCargaSIM(idestablecimiento)
    End Function

End Class
