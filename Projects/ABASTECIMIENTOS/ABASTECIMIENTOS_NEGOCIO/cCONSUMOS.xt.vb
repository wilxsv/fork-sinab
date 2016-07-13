Partial Public Class cCONSUMOS

#Region "   Métodos Agregados   "

    ''' <summary>
    ''' En esta función se obtiene el listado de consumos filtrando por mes o año de consumo
    ''' </summary>
    ''' <param name="FiltroAnio"></param> 'año consumo
    ''' <param name="FiltroMes"></param> 'mes consumo
    ''' <param name="BEstablecimiento"></param>
    ''' <returns>
    ''' lista de consumos filtrada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function Filtrar(ByVal FiltroAnio As String, ByVal FiltroMes As String, ByVal BEstablecimiento As Int32) As listaCONSUMOS
        Return Nothing 'Return mDb.Filtrar(FiltroAnio, FiltroMes, BEstablecimiento)
    End Function

    ''' <summary>
    ''' Obtener correlativo de consumo
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo CONSUMOS
    ''' <returns>
    ''' el numero entero de correlativo
    ''' </returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function id_Consumos(ByVal aEntidad As CONSUMOS) As Integer
        Return 0 'Return mDb.ObtenerID(aEntidad)
    End Function

    ''' <summary>
    ''' Se obtiene el mes de consumo
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador de establecimiento
    ''' <param name="ANIO"></param> 'anio de consumo
    ''' <returns>
    ''' devuelve el numero que corresponde al mes del consumo
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function Mes_Consumos(ByVal IDESTABLECIMIENTO As Int32, ByVal ANIO As Int32) As Integer
        Return 0 'Return mDb.ObtenerMes(IDESTABLECIMIENTO, ANIO)
    End Function

    ''' <summary>
    ''' Funcion para agregar un consumo nuevo
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo CONSUMOS   
    ''' <returns>
    ''' Regresa uno si ha sido agregado satisfactoriamente
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function AgregarConsumos(ByVal aEntidad As CONSUMOS) As Integer
        Return 0 'Return mDb.Agregar(aEntidad)
    End Function

    ''' <summary>
    ''' En esta función para dataset con la informacion de un consumo en especifico
    ''' </summary>
    ''' <param name="idConsumo"></param> 'identiicdor del consumo
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <returns>
    ''' Dataset con la informacion del consumo
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerDsConsumo(ByVal idConsumo As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet
        Return Nothing 'Return mDb.DataSetConsumo(idConsumo, IDESTABLECIMIENTO)
    End Function

    ''' <summary>
    ''' Funcion para obtener el año de consumo 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <returns>
    ''' El numero entero que representa el año de consumo
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function año_Consumos(ByVal IDESTABLECIMIENTO As Int32) As Integer
        Return 0 'Return mDb.ObtenerAño(IDESTABLECIMIENTO)
    End Function

    ''' <summary>
    ''' Funcion para obtener dia de consumo
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del etablecimiento
    ''' <param name="MES"></param> 'numero que identifica al mes de consumo
    ''' <returns>
    ''' numero entero que identifica el dia de consumo
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function Dia_Consumos(ByVal IDESTABLECIMIENTO As Int32, ByVal MES As Int32) As Integer
        Return 0 'Return mDb.ObtenerDia(IDESTABLECIMIENTO, MES)
    End Function

    ''' <summary>
    ''' Funcion para verificar existencia de consumo en los establecimientos
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <returns>
    ''' valor verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ExistenConsumosEstablecimiento(ByVal IDESTABLECIMIENTO As Int32) As Boolean
        Return False ' Return mDb.ExistenConsumosEstablecimiento(IDESTABLECIMIENTO)
    End Function

    ''' <summary>
    ''' Obtener cual es el primer consumo en estado de grabado que no ha sido enviado
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> 'identificador del establecimiento
    ''' <returns>
    ''' el identificador del primer consumo sin enviar
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function PrimerConsumoSinEnviar(ByVal IDESTABLECIMIENTO As Int32) As Integer
        Return 0 'Return mDb.ObtenerPrimerConsumoSinEnviar(IDESTABLECIMIENTO)
    End Function
    Public Function IngresarConsumoExistenciaCero(ByVal idestablecimiento As Integer, idalmacen As Integer, idproducto As Integer, fechaconsumo As DateTime) As Integer
        Try
            Return dbEntidad.IngresarConsumoExistenciaCero(idestablecimiento, idalmacen, idproducto, fechaconsumo)
        Catch ex As Exception
            Return -1
        End Try
    End Function
#End Region

End Class
