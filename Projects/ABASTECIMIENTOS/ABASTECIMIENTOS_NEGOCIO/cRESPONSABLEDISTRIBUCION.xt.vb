Partial Public Class cRESPONSABLEDISTRIBUCION

    Public Function ObtenerDataSetListaResponsableDistribucion() As DataSet
        Try
            Return mDb.ObtenerDataSetListaResponsableDistribucion()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    'Validar si un nombre corto ya existe
    '15/12/06 Responsable Eduardo Rodriguez
    Public Function BuscarEstablecimientoDependencia(ByVal IDestablecimiento As Int32, ByVal IDdependencia As Int32) As Boolean
        Try
            Return mDb.BuscarEstablecimientoDependencia(IDestablecimiento, IDdependencia)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function RecuperarOrdenada() As DataSet
        Try
            Return mDb.RecuperarOrdenada
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Devuelve los responsables de distribución de un contrato.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <returns>Cadena de texto con los responsables de distribución.</returns>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  18/01/2007    Creado
    ''' </history> 
    Public Function DevolverRDContratos(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As String
        Try
            Return mDb.DevolverRDContratos(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

End Class
