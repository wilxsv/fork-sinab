Partial Public Class cINFORMESNOACEPTACION

    ''' <summary>
    ''' Obtener ID
    ''' </summary>
    ''' <param name="aEntidad"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: JOSE CHAVEZ]    Creado
    ''' </history>
    Public Function ObtenerID(ByVal aEntidad As entidadBase) As String
        Try
            Return mDb.ObtenerID(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return "-1"
        End Try
    End Function

    ''' <summary>
    ''' Devuelve todos los informes de aceptación que cumplen con las condiciones especificadas.
    ''' </summary>
    ''' <param name="IDALMACEN"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="FECHADESDE"></param>
    ''' <param name="FECHAHASTA"></param>
    ''' <param name="IDFUENTEFINANCIAMIENTO"></param>
    ''' <param name="IDRESPONSABLEDISTRIBUCION"></param>
    ''' <param name="IDESTADO"></param>
    ''' <param name="NUMEROINFORME"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerListaInformesNoAceptacion(ByVal IDALMACEN As Integer, ByVal IDPROVEEDOR As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal IDRESPONSABLEDISTRIBUCION As Integer, ByVal IDESTADO As Integer, Optional ByVal NUMEROINFORME As Integer = 0) As DataSet
        Try
            Return mDb.ObtenerListaInformesNoAceptacion(IDALMACEN, IDPROVEEDOR, FECHADESDE, FECHAHASTA, IDFUENTEFINANCIAMIENTO, IDRESPONSABLEDISTRIBUCION, IDESTADO, NUMEROINFORME)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
