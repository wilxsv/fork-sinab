Partial Public Class cDETALLECANCELACIONPRODUCTO

#Region " Metodos Generador "

    ''' <summary>
    ''' Devuelve las cancelaciones y anulaciones efectuadas para un renglón dado.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROVEEDOR">Identificador del proveedor.</param>
    ''' <param name="IDCONTRATO">Identificador del contrato.</param>
    ''' <param name="RENGLON">Número de renglón.</param>
    ''' <returns>DataSet.</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item>SAB_UACI_DETALLECANCELACIONPRODUCTO</item>
    ''' <item>SAB_UACI_CANCELACIONPRODUCTO</item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Carlos Ceconi]   Creado
    ''' </history>
    Public Function ObtenerCancelacionDetalles(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal RENGLON As Integer) As DataSet
        Try
            Return mDb.ObtenerCancelacionDetalles(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
