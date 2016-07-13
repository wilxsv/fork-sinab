Partial Public Class cCORRECCIONESALMACENES

#Region " Metodos Agregados "

    ''' <summary>
    ''' Devuelve los datos necesarios para el reporte de correcci�n de existencias.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almac�n.</param>
    ''' <param name="ANIO">A�o del movimiento.</param>
    ''' <param name="IDCORRECCION">Identificador del movimiento de correcci�n.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]   Creado
    ''' </history>
    Public Function RptCorreccionesAlmacen(ByVal IDALMACEN As Integer, ByVal ANIO As Integer, ByVal IDCORRECCION As Integer) As DataSet
        Try
            Return mDb.RptCorreccionesAlmacen(IDALMACEN, ANIO, IDCORRECCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerListaCorreccionesAlmacen(ByVal IDALMACEN As Integer, ByVal FECHADESDE As Date, ByVal FECHAHASTA As Date, ByVal NUMEROCORRECCION As Integer) As DataSet
        Try
            Return mDb.ObtenerListaCorreccionesAlmacen(IDALMACEN, FECHADESDE, FECHAHASTA, NUMEROCORRECCION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
