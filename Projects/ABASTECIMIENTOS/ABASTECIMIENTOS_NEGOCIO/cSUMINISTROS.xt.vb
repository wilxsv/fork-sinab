Partial Public Class cSUMINISTROS

    Public Function ObtenerLista2() As listaSUMINISTROS
        'Try
            Return mDb.ObtenerListaPorID2()
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    ' Autor: JOSE CHAVEZ
    ' Utilizada para devolver una lista filtrada por el tipo de suministro
    ' Fecha: 21/12/06 
    Public Function ObtenerListaPorIDtipo(ByVal IDTIPOSUMINISTRO As Int32, Optional ByVal NM As Integer = 0) As listaSUMINISTROS
        'Try
            Return mDb.ObtenerListaPorIDtipo(IDTIPOSUMINISTRO, NM)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerListaPorIDtipo2() As listaSUMINISTROS
        'Try
            Return mDb.ObtenerListaPorIDtipo2()
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    'Validar si un nombre corto ya existe
    '15/12/06 Responsable Eduardo Rodriguez
    Public Function BuscarTSuministrosCorrelativo(ByVal TSUMINISTRO As Int32, ByVal CORRELATIVO As String) As Boolean
        'Try
            Return mDb.BuscarTSuministrosCorrelativo(TSUMINISTRO, CORRELATIVO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function BuscarSuministrosEnGrupos(ByVal IDSUMINISTRO As Int32) As Boolean
        'Try
            Return mDb.BuscarSuministrosEnGrupos(IDSUMINISTRO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function BuscarSuministrosEnInventarios(ByVal IDSUMINISTRO As Int32) As Boolean
        'Try
            Return mDb.BuscarSuministrosEnInventarios(IDSUMINISTRO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function BuscarSuministrosEnNecesidadesEstablecimiento(ByVal IDSUMINISTRO As Int32) As Boolean
        'Try
            Return mDb.BuscarSuministrosEnNecesidadesEstablecimiento(IDSUMINISTRO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function BuscarSuministrosEnPlantillasContrato(ByVal IDSUMINISTRO As Int32) As Boolean
        'Try
            Return mDb.BuscarSuministrosEnPlantillasContrato(IDSUMINISTRO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function BuscarSuministrosEnSuministroDependencia(ByVal IDSUMINISTRO As Int32) As Boolean
        'Try
            Return mDb.BuscarSuministrosEnSuministroDependencia(IDSUMINISTRO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function BuscarSuministrosEnSolicitudes(ByVal IDSUMINISTRO As Int32) As Boolean
        'Try
            Return mDb.BuscarSuministrosEnSolicitudes(IDSUMINISTRO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function DevolverCorrSuministro(ByVal IDsuministro As Integer) As String
        'Try
            Return mDb.DevolverCORRSuministro(IDsuministro)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function DevolverIdSuministro(ByVal CORR As String) As Integer
        'Try
            Return mDb.DevolverIDSuministro(CORR)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function RecuperarOrdenada() As DataSet
        'Try
            Return mDb.RecuperarOrdenada
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function RecuperarOrdenadaPorCorrelativo() As DataSet
        'Try
            Return mDb.RecuperarOrdenadaPorCorrelativo
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function ObtenerTIPOSUMINISTROS(ByVal IDSUMINISTRO As Int32) As Integer
        'Try
            Return mDb.ObtenerTIPOSUMINISTROS(IDSUMINISTRO)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function obtenerSuministroUT(ByVal iddependencia As Integer) As DataSet
        'Try
            Return mDb.obtenerSuministroUT(iddependencia)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function obtenerSuministroPorUT(ByVal idUT As Integer) As DataSet
        'Try
            Return mDb.obtenerSuministroPorUT(idUT)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
Public Function obtenerSuministroPorUTyGU(ByVal idUT As Integer, ByVal GU As Integer) As DataSet
        'Try
            Return mDb.obtenerSuministroPorUTyGU(idUT, GU)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function obtenerSuministroPorUTyGUwithCorrProducto(ByVal idUT As Integer, ByVal GU As Integer, ByVal corrProducto As String) As DataSet
        'Try
            Return mDb.obtenerSuministroPorUTyGUWithCorrProducto(idUT, GU, corrProducto)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

    Public Function RecuperarParaCargaInicial(ByVal IDALMACEN As Int32) As DataSet
        'Try
            Return mDb.RecuperarParaCargaInicial(IDALMACEN)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function
    Public Function DevolverDescSuministro(ByVal IDsuministro As Integer) As String
        'Try
            Return mDb.DevolverDescSuministro(IDsuministro)
        'Catch ex As Exception
            'ExceptionManager.Publish(ex)
            'Return Nothing
        'End Try
    End Function

End Class
