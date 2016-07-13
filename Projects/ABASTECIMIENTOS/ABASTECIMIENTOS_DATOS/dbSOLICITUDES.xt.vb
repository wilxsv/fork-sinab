Partial Public Class dbSOLICITUDES

#Region " Métodos Agregados "

    ''' <summary>
    ''' En esta función se obtiene el listado de solicitudes filtrando por criterio o campo de solicitudes y un operador
    ''' </summary>
    ''' <param name="BFiltro"></param> dato a comparar 
    ''' <param name="BCriterio"></param> campo a comparar con filtro
    ''' <param name="BOperador"></param> operando de comparacion
    ''' <param name="BEstablecimiento"></param> identificador del establecimiento
    ''' <returns>
    ''' lista filtrada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 

  
    Public Function Filtrar(ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal IDESTABLECIMIENTO As Integer, ByVal IDAREATECNICA As Int32) As listaSOLICITUDES

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" FECHASOLICITUD, ")
        strSQL.Append(" PLAZOENTREGA, ")
        strSQL.Append(" IDCLASESUMINISTRO, ")
        strSQL.Append(" PERIODOUTILIZACION, ")
        strSQL.Append(" MONTOSOLICITADO, ")
        strSQL.Append(" MONTODISPONIBLE, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" IDSOLICITANTE, ")
        strSQL.Append(" IDAREATECNICA, ")
        strSQL.Append(" CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" RESERVAFONDO, ")
        strSQL.Append(" FECHAAUTORIZACION, ")
        strSQL.Append(" MONTOAUTORIZADO, ")
        strSQL.Append(" CODRESERVAFONDO, ")
        strSQL.Append(" IDCERTIFICA, ")
        strSQL.Append(" IDAUTORIZA, ")
        strSQL.Append(" IDESTADO, ")
        strSQL.Append(" IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append(" IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append(" IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" IDALMACENENTREGA, ")
        strSQL.Append(" COMPRACONJUNTA, ")
        strSQL.Append(" NUMCORR, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE CRITERIO OPERADOR (@Filtro)")
        strSQL.Replace("CRITERIO", Criterio)
        strSQL.Replace("OPERADOR", Operador)
        strSQL.Append(" AND IDAREATECNICA = @IDAREATECNICA ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@Filtro", SqlDbType.VarChar)
        args(0).Value = Filtro
        args(1) = New SqlParameter("@IDAREATECNICA", SqlDbType.Int)
        args(1).Value = IDAREATECNICA
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaSOLICITUDES

        Try
            Do While dr.Read()
                Dim mEntidad As New SOLICITUDES
                mEntidad.IDSOLICITUD = IIf(dr("IDSOLICITUD") Is DBNull.Value, Nothing, dr("IDSOLICITUD"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.FECHASOLICITUD = IIf(dr("FECHASOLICITUD") Is DBNull.Value, Nothing, dr("FECHASOLICITUD"))
                mEntidad.PLAZOENTREGA = IIf(dr("PLAZOENTREGA") Is DBNull.Value, Nothing, dr("PLAZOENTREGA"))
                mEntidad.IDCLASESUMINISTRO = IIf(dr("IDCLASESUMINISTRO") Is DBNull.Value, Nothing, dr("IDCLASESUMINISTRO"))
                mEntidad.PERIODOUTILIZACION = IIf(dr("PERIODOUTILIZACION") Is DBNull.Value, Nothing, dr("PERIODOUTILIZACION"))
                mEntidad.MONTOSOLICITADO = IIf(dr("MONTOSOLICITADO") Is DBNull.Value, Nothing, dr("MONTOSOLICITADO"))
                mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.IDSOLICITANTE = IIf(dr("IDSOLICITANTE") Is DBNull.Value, Nothing, dr("IDSOLICITANTE"))
                mEntidad.IDAREATECNICA = IIf(dr("IDAREATECNICA") Is DBNull.Value, Nothing, dr("IDAREATECNICA"))
                mEntidad.CIFRADOPRESUPUESTARIO = IIf(dr("CIFRADOPRESUPUESTARIO") Is DBNull.Value, Nothing, dr("CIFRADOPRESUPUESTARIO"))
                mEntidad.RESERVAFONDO = IIf(dr("RESERVAFONDO") Is DBNull.Value, Nothing, dr("RESERVAFONDO"))
                mEntidad.FECHAAUTORIZACION = IIf(dr("FECHAAUTORIZACION") Is DBNull.Value, Nothing, dr("FECHAAUTORIZACION"))
                mEntidad.MONTOAUTORIZADO = IIf(dr("MONTOAUTORIZADO") Is DBNull.Value, Nothing, dr("MONTOAUTORIZADO"))
                mEntidad.CODRESERVAFONDO = IIf(dr("CODRESERVAFONDO") Is DBNull.Value, Nothing, dr("CODRESERVAFONDO"))
                mEntidad.IDCERTIFICA = IIf(dr("IDCERTIFICA") Is DBNull.Value, Nothing, dr("IDCERTIFICA"))
                mEntidad.IDAUTORIZA = IIf(dr("IDAUTORIZA") Is DBNull.Value, Nothing, dr("IDAUTORIZA"))
                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                mEntidad.IDDEPENDENCIASOLICITANTE = IIf(dr("IDDEPENDENCIASOLICITANTE") Is DBNull.Value, Nothing, dr("IDDEPENDENCIASOLICITANTE"))
                mEntidad.IDTIPOCOMPRASOLICITADO = IIf(dr("IDTIPOCOMPRASOLICITADO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASOLICITADO"))
                mEntidad.IDTIPOCOMPRASUGERIDO = IIf(dr("IDTIPOCOMPRASUGERIDO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASUGERIDO"))
                mEntidad.IDTIPOCOMPRAEJECUTAR = IIf(dr("IDTIPOCOMPRAEJECUTAR") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRAEJECUTAR"))
                mEntidad.COMPRACONJUNTA = IIf(dr("COMPRACONJUNTA") Is DBNull.Value, Nothing, dr("COMPRACONJUNTA"))
                mEntidad.NUMCORR = IIf(dr("NUMCORR") Is DBNull.Value, Nothing, dr("NUMCORR"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function
    Public Function Filtrar(ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal IDESTABLECIMIENTO As Integer) As listaSOLICITUDES

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT S.IDESTABLECIMIENTO, ")
        strSQL.Append(" S.IDSOLICITUD, ")
        strSQL.Append(" S.CORRELATIVO, ")
        strSQL.Append(" S.FECHASOLICITUD, ")
        strSQL.Append(" S.PLAZOENTREGA, ")
        strSQL.Append(" S.IDCLASESUMINISTRO, ")
        strSQL.Append(" S.PERIODOUTILIZACION, ")
        strSQL.Append(" S.MONTOSOLICITADO, ")
        strSQL.Append(" S.MONTODISPONIBLE, ")
        strSQL.Append(" S.OBSERVACION, ")
        strSQL.Append(" S.IDSOLICITANTE, ")
        strSQL.Append(" S.IDAREATECNICA, ")
        strSQL.Append(" S.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" S.RESERVAFONDO, ")
        strSQL.Append(" S.FECHAAUTORIZACION, ")
        strSQL.Append(" S.MONTOAUTORIZADO, ")
        strSQL.Append(" S.CODRESERVAFONDO, ")
        strSQL.Append(" S.IDCERTIFICA, ")
        strSQL.Append(" S.IDAUTORIZA, ")
        strSQL.Append(" S.IDESTADO, ")
        strSQL.Append(" S.IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append(" S.IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append(" S.IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" S.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" S.IDALMACENENTREGA, ")
        strSQL.Append(" S.COMPRACONJUNTA, ")
        strSQL.Append(" S.NUMCORR, ")
        strSQL.Append(" S.AUUSUARIOCREACION, ")
        strSQL.Append(" S.AUFECHACREACION, ")
        strSQL.Append(" S.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" S.AUFECHAMODIFICACION, ")
        strSQL.Append(" S.ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES S ")
        ' strSQL.Append(" inner join SAB_EST_SOLICITUDESPROCESOCOMPRAS spc on s.IDSOLICITUD=spc.IDSOLICITUD and s.IDESTABLECIMIENTO=spc.IDESTABLECIMIENTOSOLICITUD ")
        'strSQL.Append(" inner join SAB_UACI_PROCESOCOMPRAS pc on spc.IDPROCESOCOMPRA=pc.IDPROCESOCOMPRA and spc.IDESTABLECIMIENTO=pc.IDESTABLECIMIENTO ")

        strSQL.Append(" WHERE S.CRITERIO OPERADOR (@Filtro)")
        strSQL.Replace("CRITERIO", Criterio)
        strSQL.Replace("OPERADOR", Operador)
        'strSQL.Append(" AND IDAREATECNICA = @IDAREATECNICA ")
        strSQL.Append(" AND S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        ' strSQL.Append(" AND PC.IDENCARGADO = @IDENCARGADO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@Filtro", SqlDbType.VarChar)
        args(0).Value = Filtro
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        '  args(2) = New SqlParameter("@IDENCARGADO", SqlDbType.Int)
        'args(2).Value = IDEMPLEADO


        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaSOLICITUDES

        Try
            Do While dr.Read()
                Dim mEntidad As New SOLICITUDES
                mEntidad.IDSOLICITUD = IIf(dr("IDSOLICITUD") Is DBNull.Value, Nothing, dr("IDSOLICITUD"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.FECHASOLICITUD = IIf(dr("FECHASOLICITUD") Is DBNull.Value, Nothing, dr("FECHASOLICITUD"))
                mEntidad.PLAZOENTREGA = IIf(dr("PLAZOENTREGA") Is DBNull.Value, Nothing, dr("PLAZOENTREGA"))
                mEntidad.IDCLASESUMINISTRO = IIf(dr("IDCLASESUMINISTRO") Is DBNull.Value, Nothing, dr("IDCLASESUMINISTRO"))
                mEntidad.PERIODOUTILIZACION = IIf(dr("PERIODOUTILIZACION") Is DBNull.Value, Nothing, dr("PERIODOUTILIZACION"))
                mEntidad.MONTOSOLICITADO = IIf(dr("MONTOSOLICITADO") Is DBNull.Value, Nothing, dr("MONTOSOLICITADO"))
                mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.IDSOLICITANTE = IIf(dr("IDSOLICITANTE") Is DBNull.Value, Nothing, dr("IDSOLICITANTE"))
                mEntidad.IDAREATECNICA = IIf(dr("IDAREATECNICA") Is DBNull.Value, Nothing, dr("IDAREATECNICA"))
                mEntidad.CIFRADOPRESUPUESTARIO = IIf(dr("CIFRADOPRESUPUESTARIO") Is DBNull.Value, Nothing, dr("CIFRADOPRESUPUESTARIO"))
                mEntidad.RESERVAFONDO = IIf(dr("RESERVAFONDO") Is DBNull.Value, Nothing, dr("RESERVAFONDO"))
                mEntidad.FECHAAUTORIZACION = IIf(dr("FECHAAUTORIZACION") Is DBNull.Value, Nothing, dr("FECHAAUTORIZACION"))
                mEntidad.MONTOAUTORIZADO = IIf(dr("MONTOAUTORIZADO") Is DBNull.Value, Nothing, dr("MONTOAUTORIZADO"))
                mEntidad.CODRESERVAFONDO = IIf(dr("CODRESERVAFONDO") Is DBNull.Value, Nothing, dr("CODRESERVAFONDO"))
                mEntidad.IDCERTIFICA = IIf(dr("IDCERTIFICA") Is DBNull.Value, Nothing, dr("IDCERTIFICA"))
                mEntidad.IDAUTORIZA = IIf(dr("IDAUTORIZA") Is DBNull.Value, Nothing, dr("IDAUTORIZA"))
                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                mEntidad.IDDEPENDENCIASOLICITANTE = IIf(dr("IDDEPENDENCIASOLICITANTE") Is DBNull.Value, Nothing, dr("IDDEPENDENCIASOLICITANTE"))
                mEntidad.IDTIPOCOMPRASOLICITADO = IIf(dr("IDTIPOCOMPRASOLICITADO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASOLICITADO"))
                mEntidad.IDTIPOCOMPRASUGERIDO = IIf(dr("IDTIPOCOMPRASUGERIDO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASUGERIDO"))
                mEntidad.IDTIPOCOMPRAEJECUTAR = IIf(dr("IDTIPOCOMPRAEJECUTAR") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRAEJECUTAR"))
                mEntidad.COMPRACONJUNTA = IIf(dr("COMPRACONJUNTA") Is DBNull.Value, Nothing, dr("COMPRACONJUNTA"))
                mEntidad.NUMCORR = IIf(dr("NUMCORR") Is DBNull.Value, Nothing, dr("NUMCORR"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function
    ''' <summary>
    ''' Listado de solicitudes
    ''' </summary>
    ''' <param name="Filtro">Identificador del filtro</param>
    ''' <param name="Criterio">Identificador del criterio</param>
    ''' <param name="Operador">Identificador del operador</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Listado de solicitudes en formato dataset</returns>

    Public Function Filtrar2(ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SOL.IDESTABLECIMIENTO, ")
        strSQL.Append(" SOL.IDSOLICITUD, ")
        strSQL.Append(" SOL.CORRELATIVO, ")
        strSQL.Append(" SOL.FECHASOLICITUD, ")
        strSQL.Append(" SOL.PLAZOENTREGA, ")
        strSQL.Append(" SOL.IDCLASESUMINISTRO, ")
        strSQL.Append(" S.DESCRIPCION, ")
        strSQL.Append(" SOL.PERIODOUTILIZACION, ")
        strSQL.Append(" SOL.MONTOSOLICITADO, ")
        strSQL.Append(" SOL.MONTODISPONIBLE, ")
        strSQL.Append(" SOL.OBSERVACION, ")
        strSQL.Append(" SOL.IDSOLICITANTE, ")
        strSQL.Append(" SOL.IDAREATECNICA, ")
        strSQL.Append(" SOL.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" SOL.RESERVAFONDO, ")
        strSQL.Append(" SOL.FECHAAUTORIZACION, ")
        strSQL.Append(" SOL.MONTOAUTORIZADO, ")
        strSQL.Append(" SOL.CODRESERVAFONDO, ")
        strSQL.Append(" SOL.IDCERTIFICA, ")
        strSQL.Append(" SOL.IDAUTORIZA, ")
        strSQL.Append(" SOL.IDESTADO, ")
        strSQL.Append(" SOL.IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append(" SOL.IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append(" SOL.IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" SOL.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" SOL.IDALMACENENTREGA, ")
        strSQL.Append(" SOL.COMPRACONJUNTA, ")
        strSQL.Append(" SOL.NUMCORR, ")
        strSQL.Append(" SOL.AUUSUARIOCREACION, ")
        strSQL.Append(" SOL.AUFECHACREACION, ")
        strSQL.Append(" SOL.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" SOL.AUFECHAMODIFICACION, ")
        strSQL.Append(" SOL.ESTASINCRONIZADA, ")
        'strSQL.Append(" d.nombre as unidadtecnica, ")
        strSQL.Append(" d2.nombre as dependenciasolicitante ")

        strSQL.Append(" FROM SAB_EST_SOLICITUDES SOL ")
        strSQL.Append(" INNER JOIN SAB_CAT_SUMINISTROS S ON ")
        strSQL.Append(" S.IDSUMINISTRO = SOL.IDCLASESUMINISTRO ")

        ' strSQL.Append(" inner join sab_cat_dependencias d on d.iddependencia=sol.idunidadtecnica ")
        'strSQL.Append(" inner join sab_cat_dependencias d on d.areatecnica=sol.idsolicitudependencia ")

        strSQL.Append(" inner join sab_cat_dependencias d2 on d2.iddependencia=sol.iddependenciasolicitante ")

        strSQL.Append(" WHERE CRITERIO OPERADOR (@Filtro)")
        strSQL.Replace("CRITERIO", "sol." & Criterio)
        strSQL.Replace("OPERADOR", Operador)
        strSQL.Append(" AND SOL.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@Filtro", SqlDbType.VarChar)
        args(0).Value = Filtro
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        'Dim lista As New listaSOLICITUDES

        'Try
        '    Do While dr.Read()
        '        Dim mEntidad As New SOLICITUDES
        '        mEntidad.IDSOLICITUD = IIf(dr("IDSOLICITUD") Is DBNull.Value, Nothing, dr("IDSOLICITUD"))
        '        mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
        '        mEntidad.FECHASOLICITUD = IIf(dr("FECHASOLICITUD") Is DBNull.Value, Nothing, dr("FECHASOLICITUD"))
        '        mEntidad.PLAZOENTREGA = IIf(dr("PLAZOENTREGA") Is DBNull.Value, Nothing, dr("PLAZOENTREGA"))
        '        mEntidad.IDCLASESUMINISTRO = IIf(dr("IDCLASESUMINISTRO") Is DBNull.Value, Nothing, dr("IDCLASESUMINISTRO"))
        '        mEntidad.PERIODOUTILIZACION = IIf(dr("PERIODOUTILIZACION") Is DBNull.Value, Nothing, dr("PERIODOUTILIZACION"))
        '        mEntidad.MONTOSOLICITADO = IIf(dr("MONTOSOLICITADO") Is DBNull.Value, Nothing, dr("MONTOSOLICITADO"))
        '        mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
        '        mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
        '        mEntidad.IDSOLICITANTE = IIf(dr("IDSOLICITANTE") Is DBNull.Value, Nothing, dr("IDSOLICITANTE"))
        '        mEntidad.IDAREATECNICA = IIf(dr("IDAREATECNICA") Is DBNull.Value, Nothing, dr("IDAREATECNICA"))
        '        mEntidad.CIFRADOPRESUPUESTARIO = IIf(dr("CIFRADOPRESUPUESTARIO") Is DBNull.Value, Nothing, dr("CIFRADOPRESUPUESTARIO"))
        '        mEntidad.RESERVAFONDO = IIf(dr("RESERVAFONDO") Is DBNull.Value, Nothing, dr("RESERVAFONDO"))
        '        mEntidad.FECHAAUTORIZACION = IIf(dr("FECHAAUTORIZACION") Is DBNull.Value, Nothing, dr("FECHAAUTORIZACION"))
        '        mEntidad.MONTOAUTORIZADO = IIf(dr("MONTOAUTORIZADO") Is DBNull.Value, Nothing, dr("MONTOAUTORIZADO"))
        '        mEntidad.CODRESERVAFONDO = IIf(dr("CODRESERVAFONDO") Is DBNull.Value, Nothing, dr("CODRESERVAFONDO"))
        '        mEntidad.IDCERTIFICA = IIf(dr("IDCERTIFICA") Is DBNull.Value, Nothing, dr("IDCERTIFICA"))
        '        mEntidad.IDAUTORIZA = IIf(dr("IDAUTORIZA") Is DBNull.Value, Nothing, dr("IDAUTORIZA"))
        '        mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
        '        mEntidad.IDDEPENDENCIASOLICITANTE = IIf(dr("IDDEPENDENCIASOLICITANTE") Is DBNull.Value, Nothing, dr("IDDEPENDENCIASOLICITANTE"))
        '        mEntidad.IDTIPOCOMPRASOLICITADO = IIf(dr("IDTIPOCOMPRASOLICITADO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASOLICITADO"))
        '        mEntidad.IDTIPOCOMPRASUGERIDO = IIf(dr("IDTIPOCOMPRASUGERIDO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASUGERIDO"))
        '        mEntidad.IDTIPOCOMPRAEJECUTAR = IIf(dr("IDTIPOCOMPRAEJECUTAR") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRAEJECUTAR"))
        '        mEntidad.COMPRACONJUNTA = IIf(dr("COMPRACONJUNTA") Is DBNull.Value, Nothing, dr("COMPRACONJUNTA"))
        '        mEntidad.NUMCORR = IIf(dr("NUMCORR") Is DBNull.Value, Nothing, dr("NUMCORR"))
        '        mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
        '        mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
        '        mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
        '        mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
        '        mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
        '        lista.Add(mEntidad)
        '    Loop
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    dr.Close()
        'End Try

        'Return lista

    End Function
    ''' <summary>
    ''' Listado de información relacionada a la solicitud
    ''' </summary>
    ''' <param name="Filtro">Identificador del filtro</param>
    ''' <param name="Criterio">Identificador del criterio</param>
    ''' <param name="Operador">Identificador del operador</param>
    ''' <param name="AUUSUARIOCREACION">Identificador del usuario</param>
    ''' <returns>Listado de información relacionada a las solicitudes</returns>

    Public Function Filtrar(ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal IDEMPLEADO As String, ByVal IDESTABLECIMIENTO As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("S.*, ")
        strSQL.Append("E.DESCRIPCION ESTADO, ")
        strSQL.Append("isnull(EM.NOMBRE, '') + ' ' + isnull(EM.APELLIDO, '') EMPLEADO, ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_ENTREGASOLICITUDES ES WHERE ES.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND ES.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_DETALLESOLICITUDES DS WHERE DS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND DS.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT isnull(sum(MONTOPARTICIPACION), 0) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) <> S.MONTOSOLICITADO THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT isnull(sum(PORCENTAJEPARTICIPACION), 0) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) < 100 THEN 'INCOMPLETA' ELSE 'COMPLETA' ")
        strSQL.Append("END SITUACION ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES S ")
        strSQL.Append(" inner join SAB_EST_SOLICITUDESPROCESOCOMPRAS spc on s.IDSOLICITUD=spc.IDSOLICITUD and s.IDESTABLECIMIENTO=spc.IDESTABLECIMIENTOSOLICITUD ")
        strSQL.Append(" inner join SAB_UACI_PROCESOCOMPRAS pc on spc.IDPROCESOCOMPRA=pc.IDPROCESOCOMPRA and spc.IDESTABLECIMIENTO=pc.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOS E ON S.IDESTADO = E.IDESTADO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ON pc.IDENCARGADO = EM.IDEMPLEADO ")
        strSQL.Append("WHERE CRITERIO OPERADOR (@Filtro)")
        strSQL.Replace("CRITERIO", Criterio)
        strSQL.Replace("OPERADOR", Operador)
        strSQL.Append("AND S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND pc.IDENCARGADO = @IDEMPLEADO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@Filtro", SqlDbType.VarChar)
        If Operador.ToUpper = "LIKE" Then
            args(0).Value = "%" & Filtro & "%"
        Else
            args(0).Value = Filtro
        End If

        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.VarChar)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDEMPLEADO", SqlDbType.VarChar)
        args(2).Value = IDEMPLEADO
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    '''  En esta función se obtiene el listado de solicitudes filtrando por rango de fecha
    ''' </summary>
    ''' <param name="FechaInicio">fecha de inicio</param> 
    ''' <param name="FechaFin">fecha de fin</param> 
    ''' <param name="Criterio">campo de fecha a filtrar</param> 
    ''' <param name="IDEstablecimiento">identificador de estabelcimiento</param> 
    ''' <returns>
    ''' listado filtrado
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function FiltrarRangoFecha(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Criterio As String, ByVal IDESTABLECIMIENTO As Int32) As listaSOLICITUDES

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDSOLICITUD, ")
        strSQL.Append(" CORRELATIVO, ")
        strSQL.Append(" FECHASOLICITUD, ")
        strSQL.Append(" PLAZOENTREGA, ")
        strSQL.Append(" IDCLASESUMINISTRO, ")
        strSQL.Append(" PERIODOUTILIZACION, ")
        strSQL.Append(" MONTOSOLICITADO, ")
        strSQL.Append(" MONTODISPONIBLE, ")
        strSQL.Append(" OBSERVACION, ")
        strSQL.Append(" IDSOLICITANTE, ")
        strSQL.Append(" IDAREATECNICA, ")
        strSQL.Append(" CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" RESERVAFONDO, ")
        strSQL.Append(" FECHAAUTORIZACION, ")
        strSQL.Append(" MONTOAUTORIZADO, ")
        strSQL.Append(" CODRESERVAFONDO, ")
        strSQL.Append(" IDCERTIFICA, ")
        strSQL.Append(" IDAUTORIZA, ")
        strSQL.Append(" IDESTADO, ")
        strSQL.Append(" IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append(" IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append(" IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" IDALMACENENTREGA, ")
        strSQL.Append(" COMPRACONJUNTA, ")
        strSQL.Append(" NUMCORR, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE CRITERIO BETWEEN (@FiltroInicio) AND (@FiltroFin) ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDESTADO >= 1 ")
        strSQL.Replace("CRITERIO", Criterio)

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@FiltroInicio", SqlDbType.DateTime)
        args(0).Value = FechaInicio
        args(1) = New SqlParameter("@FiltroFin", SqlDbType.DateTime)
        args(1).Value = FechaFin
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaSOLICITUDES
        Try
            Do While dr.Read()
                Dim mEntidad As New SOLICITUDES
                mEntidad.IDSOLICITUD = IIf(dr("IDSOLICITUD") Is DBNull.Value, Nothing, dr("IDSOLICITUD"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.FECHASOLICITUD = IIf(dr("FECHASOLICITUD") Is DBNull.Value, Nothing, dr("FECHASOLICITUD"))
                mEntidad.PLAZOENTREGA = IIf(dr("PLAZOENTREGA") Is DBNull.Value, Nothing, dr("PLAZOENTREGA"))
                mEntidad.IDCLASESUMINISTRO = IIf(dr("IDCLASESUMINISTRO") Is DBNull.Value, Nothing, dr("IDCLASESUMINISTRO"))
                mEntidad.PERIODOUTILIZACION = IIf(dr("PERIODOUTILIZACION") Is DBNull.Value, Nothing, dr("PERIODOUTILIZACION"))
                mEntidad.MONTOSOLICITADO = IIf(dr("MONTOSOLICITADO") Is DBNull.Value, Nothing, dr("MONTOSOLICITADO"))
                mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.IDSOLICITANTE = IIf(dr("IDSOLICITANTE") Is DBNull.Value, Nothing, dr("IDSOLICITANTE"))
                mEntidad.IDAREATECNICA = IIf(dr("IDAREATECNICA") Is DBNull.Value, Nothing, dr("IDAREATECNICA"))
                mEntidad.CIFRADOPRESUPUESTARIO = IIf(dr("CIFRADOPRESUPUESTARIO") Is DBNull.Value, Nothing, dr("CIFRADOPRESUPUESTARIO"))
                mEntidad.RESERVAFONDO = IIf(dr("RESERVAFONDO") Is DBNull.Value, Nothing, dr("RESERVAFONDO"))
                mEntidad.FECHAAUTORIZACION = IIf(dr("FECHAAUTORIZACION") Is DBNull.Value, Nothing, dr("FECHAAUTORIZACION"))
                mEntidad.MONTOAUTORIZADO = IIf(dr("MONTOAUTORIZADO") Is DBNull.Value, Nothing, dr("MONTOAUTORIZADO"))
                mEntidad.CODRESERVAFONDO = IIf(dr("CODRESERVAFONDO") Is DBNull.Value, Nothing, dr("CODRESERVAFONDO"))
                mEntidad.IDCERTIFICA = IIf(dr("IDCERTIFICA") Is DBNull.Value, Nothing, dr("IDCERTIFICA"))
                mEntidad.IDAUTORIZA = IIf(dr("IDAUTORIZA") Is DBNull.Value, Nothing, dr("IDAUTORIZA"))
                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                mEntidad.IDDEPENDENCIASOLICITANTE = IIf(dr("IDDEPENDENCIASOLICITANTE") Is DBNull.Value, Nothing, dr("IDDEPENDENCIASOLICITANTE"))
                mEntidad.IDTIPOCOMPRASOLICITADO = IIf(dr("IDTIPOCOMPRASOLICITADO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASOLICITADO"))
                mEntidad.IDTIPOCOMPRASUGERIDO = IIf(dr("IDTIPOCOMPRASUGERIDO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASUGERIDO"))
                mEntidad.IDTIPOCOMPRAEJECUTAR = IIf(dr("IDTIPOCOMPRAEJECUTAR") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRAEJECUTAR"))
                mEntidad.COMPRACONJUNTA = IIf(dr("COMPRACONJUNTA") Is DBNull.Value, Nothing, dr("COMPRACONJUNTA"))
                mEntidad.NUMCORR = IIf(dr("NUMCORR") Is DBNull.Value, Nothing, dr("NUMCORR"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")

                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista
    End Function
    ''' <summary>
    ''' Consulta filtrada de la solicitud por fecha
    ''' </summary>
    ''' <param name="FechaInicio">Identificador de fecha de inicio</param>
    ''' <param name="FechaFin">Identificador de la fecha fin</param>
    ''' <param name="Criterio">Identificador del criterio</param>
    ''' <param name="AUUSUARIOCREACION">Identificador del usuario creación</param>
    ''' <returns>Listado de informacion de la solicitud</returns>

    Public Function FiltrarRangoFecha(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Criterio As String, ByVal IDENCARGADO As String) As listaSOLICITUDES

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT S.IDESTABLECIMIENTO, ")
        strSQL.Append(" S.IDSOLICITUD, ")
        strSQL.Append(" S.CORRELATIVO, ")
        strSQL.Append(" S.FECHASOLICITUD, ")
        strSQL.Append(" S.PLAZOENTREGA, ")
        strSQL.Append(" S.IDCLASESUMINISTRO, ")
        strSQL.Append(" S.PERIODOUTILIZACION, ")
        strSQL.Append(" S.MONTOSOLICITADO, ")
        strSQL.Append(" S.MONTODISPONIBLE, ")
        strSQL.Append(" S.OBSERVACION, ")
        strSQL.Append(" S.IDSOLICITANTE, ")
        strSQL.Append(" S.IDAREATECNICA, ")
        strSQL.Append(" S.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" S.RESERVAFONDO, ")
        strSQL.Append(" S.FECHAAUTORIZACION, ")
        strSQL.Append(" S.MONTOAUTORIZADO, ")
        strSQL.Append(" S.CODRESERVAFONDO, ")
        strSQL.Append(" S.IDCERTIFICA, ")
        strSQL.Append(" S.IDAUTORIZA, ")
        strSQL.Append(" S.IDESTADO, ")
        strSQL.Append(" S.IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append(" S.IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append(" S.IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" S.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" S.IDALMACENENTREGA, ")
        strSQL.Append(" S.COMPRACONJUNTA, ")
        strSQL.Append(" S.NUMCORR, ")
        strSQL.Append(" S.AUUSUARIOCREACION, ")
        strSQL.Append(" S.AUFECHACREACION, ")
        strSQL.Append(" S.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" S.AUFECHAMODIFICACION, ")
        strSQL.Append(" S.ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES S ")
        strSQL.Append(" inner join SAB_EST_SOLICITUDESPROCESOCOMPRAS spc on s.IDSOLICITUD=spc.IDSOLICITUD and s.IDESTABLECIMIENTO=spc.IDESTABLECIMIENTOSOLICITUD ")
        strSQL.Append(" inner join SAB_UACI_PROCESOCOMPRAS pc on spc.IDPROCESOCOMPRA=pc.IDPROCESOCOMPRA and spc.IDESTABLECIMIENTO=pc.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE CONVERT(VARCHAR,S.CRITERIO,112) BETWEEN convert(varchar,(@FiltroInicio),112) AND convert(varchar,(@FiltroFin),112) ")
        strSQL.Append(" AND PC.IDENCARGADO = @IDENCARGADO ")
        strSQL.Append(" AND S.IDESTADO >= 1 ")
        strSQL.Replace("CRITERIO", Criterio)

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@FiltroInicio", SqlDbType.DateTime)
        args(0).Value = FechaInicio
        args(1) = New SqlParameter("@FiltroFin", SqlDbType.DateTime)
        args(1).Value = FechaFin
        args(2) = New SqlParameter("@IDENCARGADO", SqlDbType.Int)
        args(2).Value = IDENCARGADO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaSOLICITUDES
        Try
            Do While dr.Read()
                Dim mEntidad As New SOLICITUDES
                mEntidad.IDSOLICITUD = IIf(dr("IDSOLICITUD") Is DBNull.Value, Nothing, dr("IDSOLICITUD"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.FECHASOLICITUD = IIf(dr("FECHASOLICITUD") Is DBNull.Value, Nothing, dr("FECHASOLICITUD"))
                mEntidad.PLAZOENTREGA = IIf(dr("PLAZOENTREGA") Is DBNull.Value, Nothing, dr("PLAZOENTREGA"))
                mEntidad.IDCLASESUMINISTRO = IIf(dr("IDCLASESUMINISTRO") Is DBNull.Value, Nothing, dr("IDCLASESUMINISTRO"))
                mEntidad.PERIODOUTILIZACION = IIf(dr("PERIODOUTILIZACION") Is DBNull.Value, Nothing, dr("PERIODOUTILIZACION"))
                mEntidad.MONTOSOLICITADO = IIf(dr("MONTOSOLICITADO") Is DBNull.Value, Nothing, dr("MONTOSOLICITADO"))
                mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.IDSOLICITANTE = IIf(dr("IDSOLICITANTE") Is DBNull.Value, Nothing, dr("IDSOLICITANTE"))
                mEntidad.IDAREATECNICA = IIf(dr("IDAREATECNICA") Is DBNull.Value, Nothing, dr("IDAREATECNICA"))
                mEntidad.CIFRADOPRESUPUESTARIO = IIf(dr("CIFRADOPRESUPUESTARIO") Is DBNull.Value, Nothing, dr("CIFRADOPRESUPUESTARIO"))
                mEntidad.RESERVAFONDO = IIf(dr("RESERVAFONDO") Is DBNull.Value, Nothing, dr("RESERVAFONDO"))
                mEntidad.FECHAAUTORIZACION = IIf(dr("FECHAAUTORIZACION") Is DBNull.Value, Nothing, dr("FECHAAUTORIZACION"))
                mEntidad.MONTOAUTORIZADO = IIf(dr("MONTOAUTORIZADO") Is DBNull.Value, Nothing, dr("MONTOAUTORIZADO"))
                mEntidad.CODRESERVAFONDO = IIf(dr("CODRESERVAFONDO") Is DBNull.Value, Nothing, dr("CODRESERVAFONDO"))
                mEntidad.IDCERTIFICA = IIf(dr("IDCERTIFICA") Is DBNull.Value, Nothing, dr("IDCERTIFICA"))
                mEntidad.IDAUTORIZA = IIf(dr("IDAUTORIZA") Is DBNull.Value, Nothing, dr("IDAUTORIZA"))
                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                mEntidad.IDDEPENDENCIASOLICITANTE = IIf(dr("IDDEPENDENCIASOLICITANTE") Is DBNull.Value, Nothing, dr("IDDEPENDENCIASOLICITANTE"))
                mEntidad.IDTIPOCOMPRASOLICITADO = IIf(dr("IDTIPOCOMPRASOLICITADO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASOLICITADO"))
                mEntidad.IDTIPOCOMPRASUGERIDO = IIf(dr("IDTIPOCOMPRASUGERIDO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASUGERIDO"))
                mEntidad.IDTIPOCOMPRAEJECUTAR = IIf(dr("IDTIPOCOMPRAEJECUTAR") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRAEJECUTAR"))
                mEntidad.COMPRACONJUNTA = IIf(dr("COMPRACONJUNTA") Is DBNull.Value, Nothing, dr("COMPRACONJUNTA"))
                mEntidad.NUMCORR = IIf(dr("NUMCORR") Is DBNull.Value, Nothing, dr("NUMCORR"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")

                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista
    End Function

    ''' <summary>
    ''' En esta función valida si existe correlativo de solicitud
    ''' </summary>
    ''' <param name="idSolicitud">identificador de solicitud</param> 
    ''' <param name="idCorrelativo">id correlativo</param> 
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento identificador establecimiento</param> 
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarCorrelativoSolicitud(ByVal idSolicitud As Int32, ByVal idCorrelativo As String, ByVal idEstablecimiento As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE CORRELATIVO = @correlativo ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @establecimiento ")
        strSQL.Append(" AND IDSOLICITUD <> @solicitud ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@correlativo", SqlDbType.VarChar)
        args(0).Value = idCorrelativo
        args(1) = New SqlParameter("@establecimiento", SqlDbType.Int)
        args(1).Value = idEstablecimiento
        args(2) = New SqlParameter("@solicitud", SqlDbType.Int)
        args(2).Value = idSolicitud

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True
    End Function

    ''' <summary>
    ''' En esta función valida si existe correlativo de solicitud
    ''' </summary>
    ''' <param name="idNumCorrelativo">nemero correlativo</param> 
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento identificador establecimiento</param> 
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function ValidarNumeroCorrelativoSolicitud(ByVal idNumCorrelativo As Int32, ByVal idEstablecimiento As Int32) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE NUMCORR = @numcorrelativo ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @establecimiento ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@numcorrelativo", SqlDbType.Int)
        args(0).Value = idNumCorrelativo
        args(1) = New SqlParameter("@establecimiento", SqlDbType.Int)
        args(1).Value = idEstablecimiento

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True
    End Function
    ''' <summary>
    ''' Metodo para validar el codigo de la solicitud
    ''' </summary>
    ''' <param name="Codigo">Identificador del codigo</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDDEPENDENCIASOLICITANTE">Identificador de la dependencia solicitante</param>
    ''' <returns>Valor booleano </returns>

    Public Function ValidarCodigoSolicitud(ByVal Codigo As String, ByVal IDESTABLECIMIENTO As Int32, ByVal IDDEPENDENCIASOLICITANTE As Integer) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE CORRELATIVO = @Codigo ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND (IDDEPENDENCIASOLICITANTE = @IDDEPENDENCIASOLICITANTE OR @IDDEPENDENCIASOLICITANTE = 0) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@Codigo", SqlDbType.VarChar)
        args(0).Value = Codigo
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDDEPENDENCIASOLICITANTE", SqlDbType.Int)
        args(2).Value = IDDEPENDENCIASOLICITANTE

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) = 0 Then Return False

        Return True

    End Function

    ''' <summary>
    ''' En esta función muestra las fechas de cambio de estado de una solicitud
    ''' </summary>
    ''' <param name="idSOLICITUD">identificador de solicitud</param> 
    ''' <param name="idEstado">identificador de estado de solicitud</param> 
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' <item><description>SAB_EST_HISTORICOESTADOSSOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetHistoricoEstadoSolicitud(ByVal IDSOLICITUD As Int32, ByVal IDESTADO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT S.IDSOLICITUD, ")
        strSQL.Append("S.IDESTABLECIMIENTO, ")
        strSQL.Append("S.CORRELATIVO, ")
        strSQL.Append("S.FECHASOLICITUD, ")
        strSQL.Append("S.PLAZOENTREGA, ")
        strSQL.Append("S.IDCLASESUMINISTRO, ")
        strSQL.Append("S.PERIODOUTILIZACION, ")
        strSQL.Append("S.MONTOSOLICITADO, ")
        strSQL.Append("S.MONTODISPONIBLE, ")
        strSQL.Append("S.OBSERVACION, ")
        strSQL.Append("S.IDSOLICITANTE, ")
        strSQL.Append("S.IDAREATECNICA, ")
        strSQL.Append("S.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append("S.RESERVAFONDO, ")
        strSQL.Append("S.FECHAAUTORIZACION, ")
        strSQL.Append("S.MONTOAUTORIZADO, ")
        strSQL.Append("S.CODRESERVAFONDO, ")
        strSQL.Append("S.IDCERTIFICA, ")
        strSQL.Append("S.IDAUTORIZA, ")
        strSQL.Append("S.IDESTADO, ")
        strSQL.Append("S.IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append("S.IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append("S.IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append("S.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append("S.AUUSUARIOCREACION, ")
        strSQL.Append("S.AUFECHACREACION, ")
        strSQL.Append("S.AUUSUARIOMODIFICACION, ")
        strSQL.Append("S.AUFECHAMODIFICACION, ")
        strSQL.Append("S.ESTASINCRONIZADA, ")
        strSQL.Append("HS.FECHA ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES S, SAB_EST_HISTORICOESTADOSSOLICITUDES HS ")
        strSQL.Append("WHERE S.IDSOLICITUD = @IDSOLICITUD AND S.IDSOLICITUD = HS.IDSOLICITUD ")
        strSQL.Append("AND S.IDESTADO = @IDESTADO AND S.IDSOLICITUD = HS.IDESTADO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(1).Value = IDESTADO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
    End Function

    ''' <summary>
    ''' En esta función muestra las fechas de cambio de estado solicitudes
    ''' </summary>
    ''' <param name="idEstado">identificador de estado</param> 
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento identificador de establecimiento</param> 
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' <item><description>SAB_EST_HISTORICOESTADOSSOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetHistoricoEstados(ByVal IDESTADO As Int32, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT s.IDSOLICITUD, ")
        strSQL.Append("s.IDESTABLECIMIENTO, ")
        strSQL.Append("s.CORRELATIVO, ")
        strSQL.Append("s.FECHASOLICITUD, ")
        strSQL.Append("s.PLAZOENTREGA, ")
        strSQL.Append("s.IDCLASESUMINISTRO, ")
        strSQL.Append("s.PERIODOUTILIZACION, ")
        strSQL.Append("s.MONTOSOLICITADO, ")
        strSQL.Append("s.MONTODISPONIBLE, ")
        strSQL.Append("s.OBSERVACION, ")
        strSQL.Append("s.IDSOLICITANTE, ")
        strSQL.Append("s.IDAREATECNICA, ")
        strSQL.Append("s.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append("s.RESERVAFONDO, ")
        strSQL.Append("s.FECHAAUTORIZACION, ")
        strSQL.Append("s.MONTOAUTORIZADO, ")
        strSQL.Append("s.CODRESERVAFONDO, ")
        strSQL.Append("s.IDCERTIFICA, ")
        strSQL.Append("s.IDAUTORIZA, ")
        strSQL.Append("s.IDESTADO, ")
        strSQL.Append("s.IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append("s.IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append("s.IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append("s.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append("s.AUUSUARIOCREACION, ")
        strSQL.Append("s.AUFECHACREACION, ")
        strSQL.Append("s.AUUSUARIOMODIFICACION, ")
        strSQL.Append("s.AUFECHAMODIFICACION, ")
        strSQL.Append("s.ESTASINCRONIZADA, ")
        strSQL.Append("Hs.FECHA ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES AS s INNER JOIN ")
        strSQL.Append(" SAB_EST_HISTORICOESTADOSSOLICITUDES AS Hs ON s.IDSOLICITUD = Hs.IDSOLICITUD ")
        strSQL.Append(" AND  s.IDESTABLECIMIENTO = Hs.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE Hs.IDESTADO = @IDESTADO")
        strSQL.Append(" AND Hs.IDESTABLECIMIENTO = @IDESTABLECIMIENTO")
        strSQL.Append(" ORDER BY Hs.FECHA ASC")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(0).Value = IDESTADO
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
    End Function

    ''' <summary>
    ''' En esta función muestra las fechas de cambio de estado solicitudes por establecimiento
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento identificador de establecimiento</param> 
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' <item><description>SAB_EST_HISTORICOESTADOSSOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetHistoricoEstados(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT S.IDSOLICITUD, ")
        strSQL.Append("S.IDESTABLECIMIENTO, ")
        strSQL.Append("S.CORRELATIVO, ")
        strSQL.Append("S.FECHASOLICITUD, ")
        strSQL.Append("S.PLAZOENTREGA, ")
        strSQL.Append("S.IDCLASESUMINISTRO, ")
        strSQL.Append("S.PERIODOUTILIZACION, ")
        strSQL.Append("S.MONTOSOLICITADO, ")
        strSQL.Append("S.MONTODISPONIBLE, ")
        strSQL.Append("S.OBSERVACION, ")
        strSQL.Append("S.IDSOLICITANTE, ")
        strSQL.Append("S.IDAREATECNICA, ")
        strSQL.Append("S.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append("S.RESERVAFONDO, ")
        strSQL.Append("S.FECHAAUTORIZACION, ")
        strSQL.Append("S.MONTOAUTORIZADO, ")
        strSQL.Append("S.CODRESERVAFONDO, ")
        strSQL.Append("S.IDCERTIFICA, ")
        strSQL.Append("S.IDAUTORIZA, ")
        strSQL.Append("S.IDESTADO, ")
        strSQL.Append("S.IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append("S.IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append("S.IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append("S.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append("S.AUUSUARIOCREACION, ")
        strSQL.Append("S.AUFECHACREACION, ")
        strSQL.Append("S.AUUSUARIOMODIFICACION, ")
        strSQL.Append("S.AUFECHAMODIFICACION, ")
        strSQL.Append("S.ESTASINCRONIZADA, ")
        strSQL.Append("HS.FECHA ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES S, SAB_EST_HISTORICOESTADOSSOLICITUDES HS ")
        strSQL.Append("WHERE S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND S.IDESTABLECIMIENTO = HS.IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' En esta función para dataset de reporte de solicitud
    ''' </summary>
    ''' <param name="IDSOLICITUD">Identificacion de la solicitud</param> identificador de solicitud
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento identificador de establecimiento</param> 
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' <item><description>SAB_CAT_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ALMACENES</description></item>
    ''' <item><description>SAB_CAT_UNIDADMEDIDAS</description></item>
    ''' <item><description>SAB_CAT_EMPLEADOS</description></item>
    ''' <item><description>SAB_CAT_CARGOS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function DataSetSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, Optional ByVal esp As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" 	SELECT S.IDSOLICITUD AS SOLICITUD, ")
        strSQL.Append("         S.IDESTABLECIMIENTO,  ")
        strSQL.Append("         S.CORRELATIVO AS CODIGO, ")
        strSQL.Append("         S.FECHASOLICITUD AS FECHA,  ")
        strSQL.Append("         S.PLAZOENTREGA AS PLAZO,  ")
        strSQL.Append("         E.NOMBRE AS ESTABLECIMIENTO, ")
        ' Cambio en la pantalla de consulta de solicitudes
        'strSQL.Append("         rank() OVER (ORDER BY CP.CORRPRODUCTO) as RENGLON,   ")
        strSQL.Append("         DS.RENGLON as RENGLON,   ")
        strSQL.Append("         DS.IDPRODUCTO,  ")
        strSQL.Append("         DS.CANTIDAD,  ")
        strSQL.Append("         SU.DESCRIPCION AS SUMINISTRO2,  ")
        strSQL.Append("         S.PERIODOUTILIZACION,  ")
        strSQL.Append("         S.MONTOSOLICITADO,  ")
        strSQL.Append("         S.MONTODISPONIBLE,  ")
        If esp <> 0 Then
            strSQL.Append("         CP.DESCLARGO + ' ESPECIFICACIÓN TÉCNICA:' + isnull(ET.ESPECIFICACION,'<sin especificación técnica>') AS PRODUCTO,  ")
        Else
            strSQL.Append("         CP.DESCLARGO AS PRODUCTO,  ")
        End If

        'strSQL.Append("         A.DIRECCION,  ")
        'strSQL.Append("         A.NOMBRE AS ALMACEN,  ")
        strSQL.Append("         UM.DESCRIPCION AS UNIDAD,  ")
        strSQL.Append("         DS.PRESUPUESTOUNITARIO,  ")
        strSQL.Append("         DS.PRESUPUESTOTOTAL,  ")
        strSQL.Append("         DS.NUMEROENTREGAS,  ")
        strSQL.Append("         S.EMPLEADOSOLICITANTE AS NOMBRESOLICITA,  ")
        ' strSQL.Append("         '' AS APELLIDOSOLICITA,  ")
        strSQL.Append("         S.OBSERVACION,  ")
        strSQL.Append("         S.CARGOSOLICITANTE AS CARGOSOLICITA,  ")
        strSQL.Append("         CP.CORRPRODUCTO AS CODIGOPRODUCTO,  ")
        strSQL.Append("         S.COMPRACONJUNTA,  ")
        strSQL.Append("         D.NOMBRE AS DEPENDENCIA,  ")
        'strSQL.Append("         S.CIFRADOPRESUPUESTARIO,  ")
        ' strSQL.Append("         S.RESERVAFONDO,  ")
        strSQL.Append("         ISNULL(S.EMPLEADOAREATECNICA,'') AS NOMBRETECNICA,  ")
        'strSQL.Append("         EMP_1.APELLIDO AS APELLIDATECNICA,  ")
        'strSQL.Append("         CARG_1.DESCRIPCION AS CARGOTECNICA,  ")
        'strSQL.Append("         EMP_2.NOMBRE AS NOMBRECERTIFICA,  ")
        'strSQL.Append("         EMP_2.APELLIDO AS APELLIDOCERTIFICA,  ")
        'strSQL.Append("         CARG_2.DESCRIPCION AS CARGOCERTIFICA,  ")
        strSQL.Append("         ISNULL(S.EMPLEADOAUTORIZA,'') AS NOMBREAUTORIZA,  ")
        'strSQL.Append("         EMP_3.APELLIDO AS APELLIDOAUTORIZA,  ")
        'strSQL.Append("         CARG_3.DESCRIPCION AS CARGOAUTORIZA,  ")
        strSQL.Append("         CP.ESPECIFICACIONESTECNICAS,  ")
        strSQL.Append("         CP.CODIGONACIONESUNIDAS,  ")
        strSQL.Append("         S.IDESTADO, D2.NOMBRE AS SUMINISTRO  ")
        strSQL.Append("         FROM SAB_EST_SOLICITUDES S  INNER JOIN  ")
        strSQL.Append("         SAB_EST_DETALLESOLICITUDES DS  ")
        strSQL.Append("         ON S.IDSOLICITUD = DS.IDSOLICITUD  ")
        strSQL.Append("         AND  S.IDESTABLECIMIENTO = DS.IDESTABLECIMIENTO  ")
        strSQL.Append("         INNER JOIN  SAB_CAT_ESTABLECIMIENTOS E  ")
        strSQL.Append("         ON S.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO  ")
        strSQL.Append("         INNER JOIN  SAB_CAT_SUMINISTROS SU  ")
        strSQL.Append("         ON S.IDCLASESUMINISTRO = SU.IDSUMINISTRO  ")
        strSQL.Append("         INNER JOIN  dbo.vv_CATALOGOPRODUCTOS CP  ")
        strSQL.Append("         ON DS.IDPRODUCTO = CP.IDPRODUCTO  ")

        'strSQL.Append("         INNER JOIN  SAB_CAT_ALMACENES A  ")
        'strSQL.Append("         ON S.IDALMACENENTREGA = A.IDALMACEN ")

        strSQL.Append("         INNER JOIN  SAB_CAT_UNIDADMEDIDAS UM  ")
        strSQL.Append("         ON DS.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA  ")

        'strSQL.Append("         INNER JOIN  SAB_CAT_EMPLEADOS EMP  ")
        'strSQL.Append("         ON S.IDSOLICITANTE = EMP.IDEMPLEADO  ")

        'strSQL.Append("         INNER JOIN  SAB_CAT_CARGOS CARG  ")
        'strSQL.Append("         ON EMP.IDCARGO = CARG.IDCARGO  ")
        strSQL.Append("         INNER JOIN  SAB_CAT_DEPENDENCIAS D  ")
        strSQL.Append("         ON S.IDDEPENDENCIASOLICITANTE = D.IDDEPENDENCIA  ")

        strSQL.Append("         INNER JOIN  SAB_CAT_DEPENDENCIAS D2  ")
        strSQL.Append("         ON S.IDUNIDADTECNICA = D2.IDDEPENDENCIA  ")

        If esp <> 0 Then
            strSQL.Append("         LEFT OUTER JOIN  SAB_CAT_ESPECIFICACIONES ET  ")
            strSQL.Append("         ON ET.IDPRODUCTO = DS.IDPRODUCTO AND  ")
            strSQL.Append("         ET.IDESPECIFICACION = DS.IDESPECIFICACION  ")
        End If
        'strSQL.Append("         INNER JOIN  SAB_CAT_EMPLEADOS AS EMP_1  ")
        'strSQL.Append("         ON  S.IDAREATECNICA = EMP_1.IDEMPLEADO  ")
        'strSQL.Append("         INNER JOIN  SAB_CAT_CARGOS AS CARG_1  ")
        'strSQL.Append("         ON EMP_1.IDCARGO = CARG_1.IDCARGO  ")
        'strSQL.Append("         INNER JOIN  SAB_CAT_EMPLEADOS AS EMP_2  ")
        'strSQL.Append("         ON S.IDCERTIFICA = EMP_2.IDEMPLEADO  ")
        'strSQL.Append("         INNER JOIN  SAB_CAT_CARGOS AS CARG_2  ")
        'strSQL.Append("         ON EMP_2.IDCARGO = CARG_2.IDCARGO  ")
        'strSQL.Append("         INNER JOIN  SAB_CAT_EMPLEADOS AS EMP_3  ")
        'strSQL.Append("         ON S.IDAUTORIZA = EMP_3.IDEMPLEADO  ")
        'strSQL.Append("         INNER JOIN  SAB_CAT_CARGOS AS CARG_3  ")
        'strSQL.Append("         ON EMP_3.IDCARGO = CARG_3.IDCARGO  ")

        strSQL.Append(" WHERE S.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND DS.CANTIDAD > 0 ")
        strSQL.Append(" ORDER BY DS.RENGLON ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function DataSetSolicitudProductoSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, Optional ByVal esp As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" 	SELECT S.IDSOLICITUD AS SOLICITUD, ")
        strSQL.Append("         S.IDESTABLECIMIENTO,  ")
        strSQL.Append("         S.CORRELATIVO AS CODIGO, ")
        strSQL.Append("         S.FECHASOLICITUD AS FECHA,  ")
        strSQL.Append("         S.PLAZOENTREGA AS PLAZO,  ")
        strSQL.Append("         E.NOMBRE AS ESTABLECIMIENTO, ")
        strSQL.Append("         DS.RENGLON,   ")
        strSQL.Append("         DS.IDPRODUCTO,  ")
        strSQL.Append("         DS.CANTIDAD,  ")
        strSQL.Append("         D2.NOMBRE AS SUMINISTRO,  ")
        strSQL.Append("         S.PERIODOUTILIZACION,  ")
        strSQL.Append("         S.MONTOSOLICITADO,  ")
        strSQL.Append("         S.MONTODISPONIBLE,  ")
        If esp <> 0 Then
            strSQL.Append("         CP.DESCLARGO + ' ESPECIFICACIÓN TÉCNICA:' + isnull(ET.ESPECIFICACION,'<sin especificación técnica>') AS PRODUCTO,  ")
        Else
            strSQL.Append("         CP.DESCLARGO AS PRODUCTO,  ")
        End If
        'strSQL.Append("         A.DIRECCION,  ")
        'strSQL.Append("         A.NOMBRE AS ALMACEN,  ")
        strSQL.Append("         CP.DESCRIPCION AS UNIDAD,  ")
        strSQL.Append("         CP.PRECIOACTUAL AS PRESUPUESTOUNITARIO,  ")
        strSQL.Append("         CP.PRECIOACTUAL * DS.CANTIDAD AS PRESUPUESTOTOTAL,  ")
        strSQL.Append("         '' AS NUMEROENTREGAS,  ")
        strSQL.Append("         S.EMPLEADOSOLICITANTE AS NOMBRESOLICITA,  ")
        ' strSQL.Append("         '' AS APELLIDOSOLICITA,  ")
        strSQL.Append("         S.OBSERVACION,  ")
        strSQL.Append("         S.CARGOSOLICITANTE AS CARGOSOLICITA,  ")
        strSQL.Append("         CP.CORRPRODUCTO AS CODIGOPRODUCTO,  ")
        strSQL.Append("         S.COMPRACONJUNTA,  ")
        strSQL.Append("         D.NOMBRE AS DEPENDENCIA,  ")
        'strSQL.Append("         S.CIFRADOPRESUPUESTARIO,  ")
        ' strSQL.Append("         S.RESERVAFONDO,  ")
        strSQL.Append("         ISNULL(S.EMPLEADOAREATECNICA,'') AS NOMBRETECNICA,  ")
        'strSQL.Append("         EMP_1.APELLIDO AS APELLIDATECNICA,  ")
        'strSQL.Append("         CARG_1.DESCRIPCION AS CARGOTECNICA,  ")
        'strSQL.Append("         EMP_2.NOMBRE AS NOMBRECERTIFICA,  ")
        'strSQL.Append("         EMP_2.APELLIDO AS APELLIDOCERTIFICA,  ")
        'strSQL.Append("         CARG_2.DESCRIPCION AS CARGOCERTIFICA,  ")
        strSQL.Append("         ISNULL(S.EMPLEADOAUTORIZA,'') AS NOMBREAUTORIZA,  ")
        'strSQL.Append("         EMP_3.APELLIDO AS APELLIDOAUTORIZA,  ")
        'strSQL.Append("         CARG_3.DESCRIPCION AS CARGOAUTORIZA,  ")
        strSQL.Append("         CP.ESPECIFICACIONESTECNICAS,  ")
        strSQL.Append("         CP.CODIGONACIONESUNIDAS,  ")
        strSQL.Append("         S.IDESTADO  ")

        strSQL.Append("         FROM SAB_EST_SOLICITUDES S  INNER JOIN  ")
        strSQL.Append("         SAB_EST_PRODUCTOSSOLICITUD DS  ")
        strSQL.Append("         ON S.IDSOLICITUD = DS.IDSOLICITUD  ")
        strSQL.Append("         AND  S.IDESTABLECIMIENTO = DS.IDESTABLECIMIENTO  ")

        strSQL.Append("         INNER JOIN  SAB_CAT_ESTABLECIMIENTOS E  ")
        strSQL.Append("         ON S.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO  ")

        strSQL.Append("         INNER JOIN  SAB_CAT_SUMINISTROS SU  ")
        strSQL.Append("         ON S.IDCLASESUMINISTRO = SU.IDSUMINISTRO  ")

        strSQL.Append("         INNER JOIN  dbo.vv_CATALOGOPRODUCTOS CP  ")
        strSQL.Append("         ON DS.IDPRODUCTO = CP.IDPRODUCTO  ")

        'strSQL.Append("         INNER JOIN  SAB_CAT_ALMACENES A  ")
        'strSQL.Append("         ON S.IDALMACENENTREGA = A.IDALMACEN ")

        'strSQL.Append("         INNER JOIN  SAB_CAT_UNIDADMEDIDAS UM  ")
        'strSQL.Append("         ON DS.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA  ")

        'strSQL.Append("         INNER JOIN  SAB_CAT_EMPLEADOS EMP  ")
        'strSQL.Append("         ON S.IDSOLICITANTE = EMP.IDEMPLEADO  ")

        'strSQL.Append("         INNER JOIN  SAB_CAT_CARGOS CARG  ")
        'strSQL.Append("         ON EMP.IDCARGO = CARG.IDCARGO  ")
        strSQL.Append("         INNER JOIN  SAB_CAT_DEPENDENCIAS D  ")
        strSQL.Append("         ON S.IDDEPENDENCIASOLICITANTE = D.IDDEPENDENCIA  ")

        strSQL.Append("         INNER JOIN  SAB_CAT_DEPENDENCIAS D2  ")
        strSQL.Append("         ON S.IDUNIDADTECNICA = D2.IDDEPENDENCIA  ")
        'strSQL.Append("         INNER JOIN  SAB_CAT_EMPLEADOS AS EMP_1  ")
        'strSQL.Append("         ON  S.IDAREATECNICA = EMP_1.IDEMPLEADO  ")
        'strSQL.Append("         INNER JOIN  SAB_CAT_CARGOS AS CARG_1  ")
        'strSQL.Append("         ON EMP_1.IDCARGO = CARG_1.IDCARGO  ")
        'strSQL.Append("         INNER JOIN  SAB_CAT_EMPLEADOS AS EMP_2  ")
        'strSQL.Append("         ON S.IDCERTIFICA = EMP_2.IDEMPLEADO  ")
        'strSQL.Append("         INNER JOIN  SAB_CAT_CARGOS AS CARG_2  ")
        'strSQL.Append("         ON EMP_2.IDCARGO = CARG_2.IDCARGO  ")
        'strSQL.Append("         INNER JOIN  SAB_CAT_EMPLEADOS AS EMP_3  ")
        'strSQL.Append("         ON S.IDAUTORIZA = EMP_3.IDEMPLEADO  ")
        'strSQL.Append("         INNER JOIN  SAB_CAT_CARGOS AS CARG_3  ")
        'strSQL.Append("         ON EMP_3.IDCARGO = CARG_3.IDCARGO  ")
        If esp <> 0 Then
            strSQL.Append("         LEFT OUTER JOIN  SAB_CAT_ESPECIFICACIONES ET  ")
            strSQL.Append("         ON ET.IDPRODUCTO = DS.IDPRODUCTO AND  ")
            strSQL.Append("         ET.IDESPECIFICACION = DS.IDESPECIFICACION  ")
        End If

        strSQL.Append(" WHERE S.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND DS.CANTIDAD > 0 ")
        strSQL.Append(" ORDER BY CP.CORRPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Información relacionada a la solicitud
    ''' </summary>
    ''' <param name="IDSOLICITUD">Identificacion de la solicitud</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="AUUSUARIOCREACION">Identificacion del usuario</param>
    ''' <returns>Listado con informacion relacionada a la solicitud</returns>

    Public Function DataSetConSolicitud(ByVal IDSOLICITUD As Int64, ByVal IDESTABLECIMIENTO As Int32, ByVal IDEMPLEADO As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT S.*, E.DESCRIPCION ESTADO, ")
        strSQL.Append(" CASE WHEN ")
        strSQL.Append(" (SELECT count(*) FROM SAB_EST_ENTREGASOLICITUDES ES ")
        strSQL.Append(" WHERE ES.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND ES.IDSOLICITUD = S.IDSOLICITUD) = 0 ")
        strSQL.Append(" THEN 'INCOMPLETA' ")
        strSQL.Append(" WHEN ")
        strSQL.Append(" (SELECT count(*) FROM SAB_EST_DETALLESOLICITUDES DS ")
        strSQL.Append(" WHERE DS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND DS.IDSOLICITUD = S.IDSOLICITUD) = 0 ")
        strSQL.Append(" THEN 'INCOMPLETA' ")
        strSQL.Append(" WHEN ")
        strSQL.Append(" (SELECT count(*) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS ")
        strSQL.Append(" WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) = 0 ")
        strSQL.Append(" THEN 'INCOMPLETA' ")
        strSQL.Append(" WHEN ")
        strSQL.Append(" (SELECT isnull(sum(MONTOPARTICIPACION), 0) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS ")
        strSQL.Append(" WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) <> S.MONTOSOLICITADO ")
        strSQL.Append(" THEN 'INCOMPLETA' ")
        strSQL.Append(" WHEN ")
        strSQL.Append(" (SELECT isnull(sum(PORCENTAJEPARTICIPACION), 0) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS ")
        strSQL.Append(" WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) < 100 ")
        strSQL.Append(" THEN 'INCOMPLETA' ")
        strSQL.Append(" ELSE 'COMPLETA' END SITUACION ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES S ")
        strSQL.Append(" inner join SAB_EST_SOLICITUDESPROCESOCOMPRAS spc on s.IDSOLICITUD=spc.IDSOLICITUD and s.IDESTABLECIMIENTO=spc.IDESTABLECIMIENTOSOLICITUD ")
        strSQL.Append(" inner join SAB_UACI_PROCESOCOMPRAS pc on spc.IDPROCESOCOMPRA=pc.IDPROCESOCOMPRA and spc.IDESTABLECIMIENTO=pc.IDESTABLECIMIENTO ")
        strSQL.Append(" INNER JOIN SAB_CAT_ESTADOS E ON S.IDESTADO = E.IDESTADO ")
        strSQL.Append(" WHERE pc.IDENCARGADO = @IDEMPLEADO ")
        strSQL.Append(" AND S.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" ORDER BY S.IDSOLICITUD ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@IDEMPLEADO", SqlDbType.VarChar)
        args(2).Value = IDEMPLEADO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Devuelve la solicitud en base a un proceso de compra
    ''' </summary>
    ''' <param name="IDPROCESOCOMPRA">Identificador relacionado al proceso de compra</param>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Informacion de la solicitud en formato dataset</returns>

    Public Function DataSetSolicitud2(ByVal IDPROCESOCOMPRA As Int64, ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("  SELECT S.IDSOLICITUD        , ")
        strSQL.Append("S.IDESTABLECIMIENTO, ")
        strSQL.Append("PC.CODIGOLICITACION AS CODIGO, ")
        strSQL.Append("S.FECHASOLICITUD AS FECHA, ")
        strSQL.Append("S.PLAZOENTREGA AS PLAZO, ")
        strSQL.Append("E.NOMBRE AS ESTABLECIMIENTO, ")
        strSQL.Append("DS.RENGLON, ")
        strSQL.Append("DS.IDPRODUCTO, ")
        strSQL.Append("DS.CANTIDAD, ")
        strSQL.Append("'' SUMINISTRO, ")
        strSQL.Append("S.PERIODOUTILIZACION, ")
        strSQL.Append("S.MONTOSOLICITADO, ")
        strSQL.Append("S.MONTODISPONIBLE, ")
        strSQL.Append("CP.NOMBRE AS PRODUCTO, ")
        strSQL.Append("A.DIRECCION, ")
        strSQL.Append("A.NOMBRE AS ALMACEN, ")
        strSQL.Append("UM.DESCRIPCION AS UNIDAD, ")
        strSQL.Append("DS.PRESUPUESTOUNITARIO, ")
        strSQL.Append("DS.PRESUPUESTOTOTAL, ")
        strSQL.Append("DS.NUMEROENTREGAS, ")
        strSQL.Append("'' NOMBRESOLICITA, ")
        strSQL.Append("'' APELLIDOSOLICITA, ")
        strSQL.Append("S.OBSERVACION, ")
        strSQL.Append("'' CARGOSOLICITA, ")
        strSQL.Append("CP.CODIGO AS CODIGOPRODUCTO, ")
        strSQL.Append("CP.CONCENTRACION, ")
        strSQL.Append("CP.PRESENTACION, ")
        strSQL.Append("CP.FORMAFARMACEUTICA, ")
        strSQL.Append("S.COMPRACONJUNTA, ")
        strSQL.Append("'' DEPENDENCIA, ")
        strSQL.Append("S.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append("S.RESERVAFONDO, ")
        strSQL.Append("'' NOMBRETECNICA, ")
        strSQL.Append("'' APELLIDATECNICA, ")
        strSQL.Append("'' CARGOTECNICA, ")
        strSQL.Append("'' NOMBRECERTIFICA, ")
        strSQL.Append("'' APELLIDOCERTIFICA, ")
        strSQL.Append("'' CARGOCERTIFICA, ")
        strSQL.Append("'' NOMBREAUTORIZA, ")
        strSQL.Append("'' APELLIDOAUTORIZA, ")
        strSQL.Append("'' CARGOAUTORIZA, ")
        strSQL.Append("CP.ESPECIFICACIONESTECNICAS, ")
        strSQL.Append("CP.CODIGONACIONESUNIDAS, ")
        strSQL.Append("S.IDESTADO, ")
        strSQL.Append("E.DIRECCION as DIRECCIONE, ")
        strSQL.Append("M.NOMBRE AS MUNICIPIO, ")
        strSQL.Append("PC.FECHAHORAFINRECEPCION, ")
        strSQL.Append("CASE WHEN IDALMACENENTREGA IS NOT NULL THEN (SELECT NOMBRE FROM SAB_CAT_ALMACENES WHERE IDALMACEN = IDALMACENENTREGA) ")
        strSQL.Append("WHEN IDESTABLECIMIENTOENTREGA IS NOT NULL THEN (SELECT NOMBRE FROM SAB_CAT_ESTABLECIMIENTOS WHERE IDESTABLECIMIENTO = IDESTABLECIMIENTOENTREGA) ")
        strSQL.Append("ELSE '' ")
        strSQL.Append("END LUGARENTREGA, ")
        strSQL.Append("PC.VIGENCIACOTIZACION ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES S  INNER JOIN ")
        strSQL.Append("SAB_EST_DETALLESOLICITUDES DS ")
        strSQL.Append("ON S.IDSOLICITUD = DS.IDSOLICITUD ")
        strSQL.Append("AND  S.IDESTABLECIMIENTO = DS.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN  SAB_CAT_ESTABLECIMIENTOS E ")
        strSQL.Append("ON S.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO ")
        strSQL.Append("INNER JOIN  SAB_CAT_MUNICIPIOS M ")
        strSQL.Append("ON E.IDMUNICIPIO = M.IDMUNICIPIO ")
        strSQL.Append("INNER JOIN  SAB_CAT_CATALOGOPRODUCTOS CP ")
        strSQL.Append("ON DS.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("LEFT OUTER JOIN  SAB_CAT_ALMACENES A ")
        strSQL.Append("ON S.IDALMACENENTREGA = A.IDALMACEN ")
        strSQL.Append("INNER JOIN  SAB_CAT_UNIDADMEDIDAS UM ")
        strSQL.Append("ON DS.IDUNIDADMEDIDA = UM.IDUNIDADMEDIDA ")
        strSQL.Append("INNER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS SPC ")
        strSQL.Append("ON SPC.IDESTABLECIMIENTOSOLICITUD = 	S.IDESTABLECIMIENTO AND ")
        strSQL.Append("SPC.IDSOLICITUD = S.IDSOLICITUD ")
        strSQL.Append("INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("ON PC.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTO AND ")
        strSQL.Append("PC.IDPROCESOCOMPRA = SPC.IDPROCESOCOMPRA ")
        strSQL.Append("WHERE PC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append("AND PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DS.CANTIDAD >0 ")
        strSQL.Append("ORDER BY DS.RENGLON ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' En esta función se obtiene el listado de solicitudes pero relacionandola con las siguientes tablas:
    ''' DEPENDENCIAS
    ''' TIPOPRODUCTOS
    ''' FUENTEFINANCIAMIENTOS
    ''' TIPOCOMPRAS
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento identificador establecimiento</param> 
    ''' <param name="Filtro">dato a comparar</param> 
    ''' <param name="Criterio">campo a comparar con filtro</param> 
    ''' <param name="Operador">operador de comparacion</param> 
    ''' <returns>
    ''' dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    '''  <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' <item><description>AB_UACI_PROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_EST_SOLICITUDESPROCESOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_ESTADOS</description></item>
    ''' <item><description>SAB_CAT_TIPOCOMPRAS</description></item>
    ''' <item><description>SAB_CAT_DEPENDENCIAS</description></item>
    ''' <item><description>SAB_CAT_SUMINISTROS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor:Juan Rivas]      Creado
    ''' </history>
    Public Function Filtrar_VistaSolicitudes(ByVal IDESTABLECIMIENTO As Int64, ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("SOL.IDESTABLECIMIENTO, ")
        strSQL.Append("SOL.IDSOLICITUD, ")
        strSQL.Append("SOL.CORRELATIVO, ")
        strSQL.Append("D.NOMBRE AS DEPENDENCIA_SOLICITANTE, ")
        strSQL.Append("S.DESCRIPCION AS CLASE_SUMINISTRO, ")
        strSQL.Append("CONVERT(VARCHAR, SOL.FECHASOLICITUD, 103) AS FECHASOLICITUD, ")
        'strSQL.Append("TC.DESCRIPCION AS PROCESO_COMPRA_SOL, ")
        'strSQL.Append("TC1.DESCRIPCION AS PROCESO_COMPRA_SUG, ")
        strSQL.Append("SOL.IDESTADO, ")
        strSQL.Append("SOL.MONTOSOLICITADO, ")
        strSQL.Append("CASE SOL.COMPRACONJUNTA ")
        strSQL.Append("WHEN '1' THEN 'SI' ")
        strSQL.Append("WHEN '0' THEN 'NO' ")
        strSQL.Append("WHEN '2' THEN 'SI' ")
        strSQL.Append("END AS COMPRACONJUNTA, ")
        strSQL.Append("E.DESCRIPCION ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES SOL ")
        strSQL.Append("INNER JOIN SAB_CAT_DEPENDENCIAS D ")
        strSQL.Append("ON SOL.IDDEPENDENCIASOLICITANTE = D.IDDEPENDENCIA ")
        'strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC ")
        'strSQL.Append("ON SOL.IDTIPOCOMPRASOLICITADO = TC.IDTIPOCOMPRA ")
        'strSQL.Append("INNER JOIN SAB_CAT_TIPOCOMPRAS TC1 ")
        'strSQL.Append("ON SOL.IDTIPOCOMPRASUGERIDO = TC1.IDTIPOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("ON SOL.IDCLASESUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOS E ")
        strSQL.Append("ON SOL.IDESTADO = E.IDESTADO ")
        strSQL.Append("WHERE SOL.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        If Filtro = 0 Then
            strSQL.Append("AND SOL.IDESTADO = 6 ")
        Else
            strSQL.Append("AND SOL.CRITERIO OPERADOR (@Filtro) ")
        End If
        strSQL.Append("AND SOL.IDSOLICITUD not in (SELECT SPC.IDSOLICITUD ")
        strSQL.Append("                            FROM SAB_EST_SOLICITUDESPROCESOCOMPRAS SPC ")
        strSQL.Append("                            INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("                            ON (SPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append("                            AND SPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO) ")
        strSQL.Append("                            WHERE PC.IDESTADOPROCESOCOMPRA <> 6 ")
        strSQL.Append("                            AND SPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")

        strSQL.Replace("CRITERIO", Criterio)
        strSQL.Replace("OPERADOR", Operador)

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@Filtro", SqlDbType.VarChar)
        args(0).Value = Filtro
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Devuelve informacion relacionada a la solicitud de libre gestion
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="Filtro">Identificador del filtro</param>
    ''' <param name="Criterio">Identificador del criterio</param>
    ''' <param name="Operador">identificador del operador</param>
    ''' <param name="AUUSUARIOCREACION">Identificador del usuario</param>
    ''' <returns>Informacion de la solicitud de libre gestion en formato dataset</returns>

    Public Function Filtrar_VistaSolicitudesLG(ByVal IDESTABLECIMIENTO As Int64, ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal AUUSUARIOCREACION As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("SOL.IDESTABLECIMIENTO, ")
        strSQL.Append("SOL.IDSOLICITUD, ")
        strSQL.Append("SOL.CORRELATIVO, ")
        strSQL.Append("D.NOMBRE AS DEPENDENCIA_SOLICITANTE, ")
        strSQL.Append("S.DESCRIPCION AS CLASE_SUMINISTRO, ")
        strSQL.Append("CONVERT(VARCHAR, SOL.FECHASOLICITUD, 103) AS FECHASOLICITUD, ")
        strSQL.Append("TC.DESCRIPCION AS PROCESO_COMPRA_SOL, ")
        strSQL.Append("TC1.DESCRIPCION AS PROCESO_COMPRA_SUG, ")
        strSQL.Append("SOL.IDESTADO, ")
        strSQL.Append("SOL.MONTOSOLICITADO, ")
        strSQL.Append("CASE SOL.COMPRACONJUNTA ")
        strSQL.Append("WHEN '1' THEN 'SI' ")
        strSQL.Append("WHEN '0' THEN 'NO' ")
        strSQL.Append("END AS COMPRACONJUNTA, ")
        strSQL.Append("E.DESCRIPCION ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES SOL ")
        strSQL.Append("INNER JOIN SAB_CAT_DEPENDENCIAS D ")
        strSQL.Append("ON SOL.IDDEPENDENCIASOLICITANTE = D.IDDEPENDENCIA ")
        strSQL.Append("LEFT JOIN SAB_CAT_TIPOCOMPRAS TC ")
        strSQL.Append("ON SOL.IDTIPOCOMPRASOLICITADO = TC.IDTIPOCOMPRA ")
        strSQL.Append("LEFT JOIN SAB_CAT_TIPOCOMPRAS TC1 ")
        strSQL.Append("ON SOL.IDTIPOCOMPRASUGERIDO = TC1.IDTIPOCOMPRA ")
        strSQL.Append("INNER JOIN SAB_CAT_SUMINISTROS S ")
        strSQL.Append("ON SOL.IDCLASESUMINISTRO = S.IDSUMINISTRO ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOS E ")
        strSQL.Append("ON SOL.IDESTADO = E.IDESTADO ")

        If Filtro = 0 Then
            strSQL.Append("WHERE (SOL.IDESTADO = 2 OR SOL.IDESTADO = 5 OR SOL.IDESTADO = 6 OR SOL.IDESTADO = 7 ) ")
        Else
            strSQL.Append("WHERE SOL.CRITERIO OPERADOR (@Filtro) ")
       End If
        'strSQL.Append("AND SOL.AUUSUARIOCREACION = @AUUSUARIOCREACION ")
        strSQL.Append("AND SOL.IDSOLICITUD not in (SELECT SPC.IDSOLICITUD ")
        strSQL.Append("                            FROM SAB_EST_SOLICITUDESPROCESOCOMPRAS SPC ")
        strSQL.Append("                            INNER JOIN SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("                            ON (SPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA ")
        strSQL.Append("                            AND SPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO) ")
        strSQL.Append("                            WHERE PC.IDESTADOPROCESOCOMPRA <> 6 ")
        strSQL.Append("                            AND SPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) ")

        strSQL.Replace("CRITERIO", Criterio)
        strSQL.Replace("OPERADOR", Operador)

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@Filtro", SqlDbType.VarChar)
        args(0).Value = Filtro
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        args(2) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(2).Value = AUUSUARIOCREACION

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Rechazar una solicitud
    ''' </summary>
    ''' <param name="aEntidad">Entidad relacionada a la solicitud</param>
    ''' <returns>
    ''' el numero de registros afectados con la operacion
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor:Juan Rivas]      Creado
    ''' </history>
    Public Function RechazarSolicitud(ByVal aEntidad As SOLICITUDES) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_EST_SOLICITUDES SET ")
        strSQL.Append(" IDESTADO = @IDESTADO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(0).Value = IIf(aEntidad.IDESTADO = Nothing, DBNull.Value, aEntidad.IDESTADO)
        args(1) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOCREACION)
        args(2) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHACREACION = Nothing, DBNull.Value, aEntidad.AUFECHACREACION)
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(5) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(5).Value = aEntidad.ESTASINCRONIZADA
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = aEntidad.IDESTABLECIMIENTO
        args(7) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(7).Value = aEntidad.IDSOLICITUD

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Actualiza el estado de una solicitud de compras que ya esta grabada
    ''' </summary>
    ''' <param name="aEntidad">entidad del tipo SOLICITUD</param> 
    ''' <returns>
    ''' el numero de lineas afectadas con la operacion
    ''' </returns>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list> 
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor:Juan Rivas]      Creado
    ''' </history>

    Public Function ActualizarEstado(ByVal aEntidad As SOLICITUDES) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_EST_SOLICITUDES SET ")
        strSQL.Append(" IDESTADO = @IDESTADO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION ")
        'strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        ' strSQL.Append(" AND IDESTADO = 2 ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(0).Value = IIf(aEntidad.IDESTADO = Nothing, DBNull.Value, aEntidad.IDESTADO)
        args(1) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOCREACION)
        args(2) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHACREACION = Nothing, DBNull.Value, aEntidad.AUFECHACREACION)
        args(3) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(3).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(4) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(4).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        'args(5) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        'args(5).Value = aEntidad.ESTASINCRONIZADA
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)
        args(7) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(7).Value = IIf(aEntidad.IDSOLICITUD = Nothing, DBNull.Value, aEntidad.IDSOLICITUD)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ActualizarMontoSolicitado(ByVal aEntidad As SOLICITUDES) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_EST_SOLICITUDES SET ")
        strSQL.Append(" MONTOSOLICITADO = @MONTO ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args(0).Value = IIf(aEntidad.MONTOSOLICITADO = Nothing, DBNull.Value, aEntidad.MONTOSOLICITADO)
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = IIf(aEntidad.IDSOLICITUD = Nothing, DBNull.Value, aEntidad.IDSOLICITUD)
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)
     

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ActualizarEntregas(ByVal aEntidad As SOLICITUDES) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_EST_SOLICITUDES SET ")
        strSQL.Append(" ENTREGAS = @ENTREGA ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@ENTREGA", SqlDbType.Decimal)
        args(0).Value = IIf(aEntidad.ENTREGAS = Nothing, DBNull.Value, aEntidad.ENTREGAS)
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = IIf(aEntidad.IDSOLICITUD = Nothing, DBNull.Value, aEntidad.IDSOLICITUD)
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IIf(aEntidad.IDESTABLECIMIENTO = Nothing, DBNull.Value, aEntidad.IDESTABLECIMIENTO)


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    ''' <summary>
    ''' Obtener el numero de correlativo
    ''' </summary>
    ''' <param name="aEntidad"> entidad del tipo SOLICITUDES</param>
    ''' <returns>
    ''' el correlativo siguiente
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history> 
    Public Function ObtenerCorrelativo(ByVal aEntidad As SOLICITUDES) As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(NUMCORR),0) + 1 ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = aEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Funcion para actualizar las observaciones de la solicitud de compra
    ''' </summary>
    ''' <param name="aEntidad">entidad tipo SOLICITUD</param> 
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento identificador del establecimiento</param> 
    ''' <param name="IDSOLICITUD">Identificacion de la solicitud identificador de solicitud</param> 
    ''' <returns>
    ''' numero de registros afectados
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor:Juan Rivas]      Creado
    ''' </history>
    Public Function ActualizarObservacionSolicitud(ByVal aEntidad As SOLICITUDES, ByVal IDESTABLECIMIENTO As Integer, ByVal IDSOLICITUD As Integer) As Integer

        Dim strSQLObservacion As New Text.StringBuilder
        strSQLObservacion.Append(" SELECT IDESTABLECIMIENTO, IDSOLICITUD, OBSERVACION ")
        strSQLObservacion.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQLObservacion.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDSOLICITUD = " & IDSOLICITUD & ")")

        Dim Observaciones As String

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQLObservacion.ToString())

        If IsDBNull(ds.Tables(0).Rows(0).Item("OBSERVACION")) Then
            Observaciones = ""
        Else
            Observaciones = ds.Tables(0).Rows(0).Item("OBSERVACION")
        End If

        Observaciones = Observaciones & Chr(13) & aEntidad.OBSERVACION

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("UPDATE SAB_EST_SOLICITUDES SET ")
        strSQL.Append(" OBSERVACION = @OBSERVACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        'strSQL.Append(" AND IDESTADO = 2 ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@OBSERVACION", SqlDbType.VarChar)
        args(0).Value = IIf(Observaciones = Nothing, DBNull.Value, Observaciones)
        args(1) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(1).Value = IIf(aEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, aEntidad.AUUSUARIOMODIFICACION)
        args(2) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(2).Value = IIf(aEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, aEntidad.AUFECHAMODIFICACION)
        args(3) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(3).Value = 0
        args(4) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(4).Value = aEntidad.IDESTABLECIMIENTO
        args(5) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(5).Value = aEntidad.IDSOLICITUD

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Obtener el monto de la solicitud
    ''' </summary>
    ''' <param name="IDSOLICITUD">Identificacion de la solicitud identificador de la solicitud</param> 
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento identificador del establecimiento</param> 
    ''' <returns>
    ''' monto de la solicitud
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history> 
    Public Function ObtenerMontoSolicitud(ByVal IDSOLICITUD As Int32, ByVal IDESTABLECIMIENTO As Int64) As Double

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT MONTOSOLICITADO ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDSOLICITUD = @IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(1).Value = IDSOLICITUD

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    ''' <summary>
    ''' Devuelve la información del plan de distribución para la solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento que elaboro la consolidación.</param>
    ''' <param name="IDSOLICITUD">Identificador de la solicitud.</param>
    ''' <returns>Dataset con la información del plan de distribución </returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' <item><description>SAB_CAT_ESTABLECIMIENTOS</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history> 
    Public Function ObtenerDataSetDistribucionSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT CP.CORRPRODUCTO, CP.DESCLARGO, CP.DESCRIPCION AS UNIDAD, DS.RENGLON, DS.NUMEROENTREGAS, E.NOMBRE, ")
        strSQL.Append("CP.CODIGONACIONESUNIDAS, ds.IDSOLICITUD, ds.IDESTABLECIMIENTO, ds.CANTIDAD, ds.PRESUPUESTOUNITARIO, ds.PRESUPUESTOTOTAL ")
        strSQL.Append("FROM SAB_EST_DETALLESOLICITUDES AS DS INNER JOIN ")
        strSQL.Append("SAB_CAT_ESTABLECIMIENTOS AS E ON DS.IDESTABLECIMIENTO = E.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append("vv_CATALOGOPRODUCTOS AS CP ON DS.IDPRODUCTO = CP.IDPRODUCTO ")
        strSQL.Append("WHERE ")
        strSQL.Append("ds.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND DS.IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("ORDER BY DS.RENGLON ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(1).Value = IDSOLICITUD

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Validar que certificado de fondos no sea un campo nulo
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> identificador de establecimiento
    ''' <param name="IDSOLICITUD">Identificacion de la solicitud</param> identificador de solicitud
    ''' <returns>
    ''' verdadero si campo es nulo o vacio
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history> 
    Public Function ValidarCertificadoFondosNulosSolicitud(ByVal IDESTABLECIMIENTO As Int32, ByVal IDSOLICITUD As Int64) As Boolean

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT CIFRADOPRESUPUESTARIO ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES ")
        strSQL.Append("WHERE IDSOLICITUD = @IDSOLICITUD ")
        strSQL.Append("AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDSOLICITUD", SqlDbType.BigInt)
        args(0).Value = IDSOLICITUD
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        If (SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) Is Nothing) Or (SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args) Is DBNull.Value) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' obtener el identificador suministro asociado a una solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param> identificador de establecimiento
    ''' <param name="IDSOLICITUD">Identificacion de la solicitud</param> identificador de solicitud
    ''' <returns>
    ''' identificador de suministro
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_DETALLESOLICITUDES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]  Creado
    ''' </history> 
    Public Function obtenerSuministroSolicitud(ByVal IDESTABLECIMIENTO As Integer, ByVal IDSOLICITUD As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" Select IDCLASESUMINISTRO ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDSOLICITUD = " & IDSOLICITUD & ") ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' Metodo que obtiene el identificador de una solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="correlativo">Identificador del correlativo</param>
    ''' <returns>Valor entero con el identificador de la solicitud</returns>

    Public Function obtenerIdSolicitud(ByVal IDESTABLECIMIENTO As Integer, ByVal correlativo As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" Select IDSOLICITUD ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (CORRELATIVO = '" & correlativo & "') ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' En esta función se obtiene el listado de solicitudes filtrando por criterio o campo de solicitudes y un operador
    ''' </summary>
    ''' <param name="Filtro">dato a comparar </param> 
    ''' <param name="Criterio">campo a comparar con filtro</param> 
    ''' <param name="Operador">operando de comparacion</param> 
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function FiltrarSolicitudesNoAsociadasProcesoCompra(ByVal Filtro As String, ByVal Criterio As String, ByVal Operador As String, ByVal IDESTABLECIMIENTO As Int32) As listaSOLICITUDES

        Criterio = "S." & Criterio

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT S.IDESTABLECIMIENTO, ")
        strSQL.Append(" S.IDSOLICITUD, ")
        strSQL.Append(" S.CORRELATIVO, ")
        strSQL.Append(" S.FECHASOLICITUD, ")
        strSQL.Append(" S.PLAZOENTREGA, ")
        strSQL.Append(" S.IDCLASESUMINISTRO, ")
        strSQL.Append(" S.PERIODOUTILIZACION, ")
        strSQL.Append(" S.MONTOSOLICITADO, ")
        strSQL.Append(" S.MONTODISPONIBLE, ")
        strSQL.Append(" S.OBSERVACION, ")
        strSQL.Append(" S.IDSOLICITANTE, ")
        strSQL.Append(" S.IDAREATECNICA, ")
        strSQL.Append(" S.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" S.RESERVAFONDO, ")
        strSQL.Append(" S.FECHAAUTORIZACION, ")
        strSQL.Append(" S.MONTOAUTORIZADO, ")
        strSQL.Append(" S.CODRESERVAFONDO, ")
        strSQL.Append(" S.IDCERTIFICA, ")
        strSQL.Append(" S.IDAUTORIZA, ")
        strSQL.Append(" S.IDESTADO, ")
        strSQL.Append(" S.IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append(" S.IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append(" S.IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" S.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" S.IDALMACENENTREGA, ")
        strSQL.Append(" S.COMPRACONJUNTA, ")
        strSQL.Append(" S.NUMCORR, ")
        strSQL.Append(" S.AUUSUARIOCREACION, ")
        strSQL.Append(" S.AUFECHACREACION, ")
        strSQL.Append(" S.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" S.AUFECHAMODIFICACION, ")
        strSQL.Append(" S.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES S ")
        strSQL.Append("LEFT OUTER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS SPC ")
        strSQL.Append("ON (S.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTOSOLICITUD ")
        strSQL.Append("AND S.IDSOLICITUD = SPC.IDSOLICITUD) ")
        strSQL.Append("WHERE(SPC.IDSOLICITUD Is NULL) ")
        strSQL.Append(" AND CRITERIO OPERADOR (@Filtro)")
        strSQL.Replace("CRITERIO", Criterio)
        strSQL.Replace("OPERADOR", Operador)
        strSQL.Append(" AND S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@Filtro", SqlDbType.VarChar)
        args(0).Value = Filtro
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaSOLICITUDES
        Try
            Do While dr.Read()
                Dim mEntidad As New SOLICITUDES
                mEntidad.IDSOLICITUD = IIf(dr("IDSOLICITUD") Is DBNull.Value, Nothing, dr("IDSOLICITUD"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.FECHASOLICITUD = IIf(dr("FECHASOLICITUD") Is DBNull.Value, Nothing, dr("FECHASOLICITUD"))
                mEntidad.PLAZOENTREGA = IIf(dr("PLAZOENTREGA") Is DBNull.Value, Nothing, dr("PLAZOENTREGA"))
                mEntidad.IDCLASESUMINISTRO = IIf(dr("IDCLASESUMINISTRO") Is DBNull.Value, Nothing, dr("IDCLASESUMINISTRO"))
                mEntidad.PERIODOUTILIZACION = IIf(dr("PERIODOUTILIZACION") Is DBNull.Value, Nothing, dr("PERIODOUTILIZACION"))
                mEntidad.MONTOSOLICITADO = IIf(dr("MONTOSOLICITADO") Is DBNull.Value, Nothing, dr("MONTOSOLICITADO"))
                mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.IDSOLICITANTE = IIf(dr("IDSOLICITANTE") Is DBNull.Value, Nothing, dr("IDSOLICITANTE"))
                mEntidad.IDAREATECNICA = IIf(dr("IDAREATECNICA") Is DBNull.Value, Nothing, dr("IDAREATECNICA"))
                mEntidad.CIFRADOPRESUPUESTARIO = IIf(dr("CIFRADOPRESUPUESTARIO") Is DBNull.Value, Nothing, dr("CIFRADOPRESUPUESTARIO"))
                mEntidad.RESERVAFONDO = IIf(dr("RESERVAFONDO") Is DBNull.Value, Nothing, dr("RESERVAFONDO"))
                mEntidad.FECHAAUTORIZACION = IIf(dr("FECHAAUTORIZACION") Is DBNull.Value, Nothing, dr("FECHAAUTORIZACION"))
                mEntidad.MONTOAUTORIZADO = IIf(dr("MONTOAUTORIZADO") Is DBNull.Value, Nothing, dr("MONTOAUTORIZADO"))
                mEntidad.CODRESERVAFONDO = IIf(dr("CODRESERVAFONDO") Is DBNull.Value, Nothing, dr("CODRESERVAFONDO"))
                mEntidad.IDCERTIFICA = IIf(dr("IDCERTIFICA") Is DBNull.Value, Nothing, dr("IDCERTIFICA"))
                mEntidad.IDAUTORIZA = IIf(dr("IDAUTORIZA") Is DBNull.Value, Nothing, dr("IDAUTORIZA"))
                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                mEntidad.IDDEPENDENCIASOLICITANTE = IIf(dr("IDDEPENDENCIASOLICITANTE") Is DBNull.Value, Nothing, dr("IDDEPENDENCIASOLICITANTE"))
                mEntidad.IDTIPOCOMPRASOLICITADO = IIf(dr("IDTIPOCOMPRASOLICITADO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASOLICITADO"))
                mEntidad.IDTIPOCOMPRASUGERIDO = IIf(dr("IDTIPOCOMPRASUGERIDO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASUGERIDO"))
                mEntidad.IDTIPOCOMPRAEJECUTAR = IIf(dr("IDTIPOCOMPRAEJECUTAR") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRAEJECUTAR"))
                mEntidad.COMPRACONJUNTA = IIf(dr("COMPRACONJUNTA") Is DBNull.Value, Nothing, dr("COMPRACONJUNTA"))
                mEntidad.NUMCORR = IIf(dr("NUMCORR") Is DBNull.Value, Nothing, dr("NUMCORR"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    ''' <summary>
    '''  En esta función se obtiene el listado de solicitudes filtrando por rango de fecha
    ''' </summary>
    ''' <param name="FechaInicio"></param> fecha de inicio
    ''' <param name="FechaFin"></param> fecha de fin
    ''' <param name="Criterio"></param> campo de fecha a filtrar
    ''' <param name="idEstablecimiento"></param> identificador de estabelcimiento
    ''' <returns>
    ''' listado filtrado
    ''' </returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' <item><description>SAB_EST_SOLICITUDES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function FiltrarRangoFechaSolicitudesSinProceso(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal Criterio As String, ByVal IDESTABLECIMIENTO As Int32) As listaSOLICITUDES

        Criterio = "S." & Criterio

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT S.IDESTABLECIMIENTO, ")
        strSQL.Append(" S.IDSOLICITUD, ")
        strSQL.Append(" S.CORRELATIVO, ")
        strSQL.Append(" S.FECHASOLICITUD, ")
        strSQL.Append(" S.PLAZOENTREGA, ")
        strSQL.Append(" S.IDCLASESUMINISTRO, ")
        strSQL.Append(" S.PERIODOUTILIZACION, ")
        strSQL.Append(" S.MONTOSOLICITADO, ")
        strSQL.Append(" S.MONTODISPONIBLE, ")
        strSQL.Append(" S.OBSERVACION, ")
        strSQL.Append(" S.IDSOLICITANTE, ")
        strSQL.Append(" S.IDAREATECNICA, ")
        strSQL.Append(" S.CIFRADOPRESUPUESTARIO, ")
        strSQL.Append(" S.RESERVAFONDO, ")
        strSQL.Append(" S.FECHAAUTORIZACION, ")
        strSQL.Append(" S.MONTOAUTORIZADO, ")
        strSQL.Append(" S.CODRESERVAFONDO, ")
        strSQL.Append(" S.IDCERTIFICA, ")
        strSQL.Append(" S.IDAUTORIZA, ")
        strSQL.Append(" S.IDESTADO, ")
        strSQL.Append(" S.IDDEPENDENCIASOLICITANTE, ")
        strSQL.Append(" S.IDTIPOCOMPRASOLICITADO, ")
        strSQL.Append(" S.IDTIPOCOMPRASUGERIDO, ")
        strSQL.Append(" S.IDTIPOCOMPRAEJECUTAR, ")
        strSQL.Append(" S.IDALMACENENTREGA, ")
        strSQL.Append(" S.COMPRACONJUNTA, ")
        strSQL.Append(" S.NUMCORR, ")
        strSQL.Append(" S.AUUSUARIOCREACION, ")
        strSQL.Append(" S.AUFECHACREACION, ")
        strSQL.Append(" S.AUUSUARIOMODIFICACION, ")
        strSQL.Append(" S.AUFECHAMODIFICACION, ")
        strSQL.Append(" S.ESTASINCRONIZADA ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES S ")
        strSQL.Append("LEFT OUTER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS SPC ")
        strSQL.Append("ON (S.IDESTABLECIMIENTO = SPC.IDESTABLECIMIENTOSOLICITUD ")
        strSQL.Append("AND S.IDSOLICITUD = SPC.IDSOLICITUD) ")
        strSQL.Append("WHERE(SPC.IDSOLICITUD Is NULL) ")
        strSQL.Append(" AND CRITERIO BETWEEN (@FiltroInicio)AND(@FiltroFin) ")
        strSQL.Append(" AND IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDESTADO >= 1 ")
        strSQL.Replace("CRITERIO", Criterio)

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@FiltroInicio", SqlDbType.DateTime)
        args(0).Value = FechaInicio
        args(1) = New SqlParameter("@FiltroFin", SqlDbType.DateTime)
        args(1).Value = FechaFin
        args(2) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(2).Value = IDESTABLECIMIENTO

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaSOLICITUDES
        Try
            Do While dr.Read()
                Dim mEntidad As New SOLICITUDES
                mEntidad.IDSOLICITUD = IIf(dr("IDSOLICITUD") Is DBNull.Value, Nothing, dr("IDSOLICITUD"))
                mEntidad.CORRELATIVO = IIf(dr("CORRELATIVO") Is DBNull.Value, Nothing, dr("CORRELATIVO"))
                mEntidad.FECHASOLICITUD = IIf(dr("FECHASOLICITUD") Is DBNull.Value, Nothing, dr("FECHASOLICITUD"))
                mEntidad.PLAZOENTREGA = IIf(dr("PLAZOENTREGA") Is DBNull.Value, Nothing, dr("PLAZOENTREGA"))
                mEntidad.IDCLASESUMINISTRO = IIf(dr("IDCLASESUMINISTRO") Is DBNull.Value, Nothing, dr("IDCLASESUMINISTRO"))
                mEntidad.PERIODOUTILIZACION = IIf(dr("PERIODOUTILIZACION") Is DBNull.Value, Nothing, dr("PERIODOUTILIZACION"))
                mEntidad.MONTOSOLICITADO = IIf(dr("MONTOSOLICITADO") Is DBNull.Value, Nothing, dr("MONTOSOLICITADO"))
                mEntidad.MONTODISPONIBLE = IIf(dr("MONTODISPONIBLE") Is DBNull.Value, Nothing, dr("MONTODISPONIBLE"))
                mEntidad.OBSERVACION = IIf(dr("OBSERVACION") Is DBNull.Value, Nothing, dr("OBSERVACION"))
                mEntidad.IDSOLICITANTE = IIf(dr("IDSOLICITANTE") Is DBNull.Value, Nothing, dr("IDSOLICITANTE"))
                mEntidad.IDAREATECNICA = IIf(dr("IDAREATECNICA") Is DBNull.Value, Nothing, dr("IDAREATECNICA"))
                mEntidad.CIFRADOPRESUPUESTARIO = IIf(dr("CIFRADOPRESUPUESTARIO") Is DBNull.Value, Nothing, dr("CIFRADOPRESUPUESTARIO"))
                mEntidad.RESERVAFONDO = IIf(dr("RESERVAFONDO") Is DBNull.Value, Nothing, dr("RESERVAFONDO"))
                mEntidad.FECHAAUTORIZACION = IIf(dr("FECHAAUTORIZACION") Is DBNull.Value, Nothing, dr("FECHAAUTORIZACION"))
                mEntidad.MONTOAUTORIZADO = IIf(dr("MONTOAUTORIZADO") Is DBNull.Value, Nothing, dr("MONTOAUTORIZADO"))
                mEntidad.CODRESERVAFONDO = IIf(dr("CODRESERVAFONDO") Is DBNull.Value, Nothing, dr("CODRESERVAFONDO"))
                mEntidad.IDCERTIFICA = IIf(dr("IDCERTIFICA") Is DBNull.Value, Nothing, dr("IDCERTIFICA"))
                mEntidad.IDAUTORIZA = IIf(dr("IDAUTORIZA") Is DBNull.Value, Nothing, dr("IDAUTORIZA"))
                mEntidad.IDESTADO = IIf(dr("IDESTADO") Is DBNull.Value, Nothing, dr("IDESTADO"))
                mEntidad.IDDEPENDENCIASOLICITANTE = IIf(dr("IDDEPENDENCIASOLICITANTE") Is DBNull.Value, Nothing, dr("IDDEPENDENCIASOLICITANTE"))
                mEntidad.IDTIPOCOMPRASOLICITADO = IIf(dr("IDTIPOCOMPRASOLICITADO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASOLICITADO"))
                mEntidad.IDTIPOCOMPRASUGERIDO = IIf(dr("IDTIPOCOMPRASUGERIDO") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRASUGERIDO"))
                mEntidad.IDTIPOCOMPRAEJECUTAR = IIf(dr("IDTIPOCOMPRAEJECUTAR") Is DBNull.Value, Nothing, dr("IDTIPOCOMPRAEJECUTAR"))
                mEntidad.COMPRACONJUNTA = IIf(dr("COMPRACONJUNTA") Is DBNull.Value, Nothing, dr("COMPRACONJUNTA"))
                mEntidad.NUMCORR = IIf(dr("NUMCORR") Is DBNull.Value, Nothing, dr("NUMCORR"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")

                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function
    ''' <summary>
    ''' Devuelve Informacion de la solicitud 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <returns>Informacion de la solicitud en formato dataset</returns>

    Public Function ObtenerSolicitudes(ByVal IDESTABLECIMIENTO As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("S.*, ")
        strSQL.Append("E.DESCRIPCION ESTADO, ")
        strSQL.Append("ISNULL(EM.NOMBRE, '') + ' ' + ISNULL(EM.APELLIDO, '') EMPLEADO, ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_ENTREGASOLICITUDES ES WHERE ES.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND ES.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_DETALLESOLICITUDES DS WHERE DS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND DS.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT isnull(sum(MONTOPARTICIPACION), 0) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) <> S.MONTOSOLICITADO THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT isnull(sum(PORCENTAJEPARTICIPACION), 0) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) < 100 THEN 'INCOMPLETA' ")
        strSQL.Append("ELSE 'COMPLETA' ")
        strSQL.Append("END SITUACION ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES S ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOS E ")
        strSQL.Append("ON S.IDESTADO = E.IDESTADO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ")
        strSQL.Append("ON S.IDSOLICITANTE = EM.IDEMPLEADO ")
        strSQL.Append("WHERE S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("ORDER BY S.IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Devuelve la informacion de la solicitud filtrada por dependencia
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDDEPENDENCIA">Identificador de la dependencia</param>
    ''' <returns>Informacion de la solicitud filtrada por dependencia</returns>

    Public Function ObtenerSolicitudesPorDependencia(ByVal IDESTABLECIMIENTO As Int32, ByVal IDDEPENDENCIA As Int32) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("S.*, ")
        strSQL.Append("E.DESCRIPCION ESTADO, ")
        strSQL.Append("ISNULL(EM.NOMBRE, '') + ' ' + ISNULL(EM.APELLIDO, '') EMPLEADO, ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_ENTREGASOLICITUDES ES WHERE ES.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND ES.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_DETALLESOLICITUDES DS WHERE DS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND DS.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT isnull(sum(MONTOPARTICIPACION), 0) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) <> S.MONTOSOLICITADO THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT isnull(sum(PORCENTAJEPARTICIPACION), 0) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) < 100 THEN 'INCOMPLETA' ")
        strSQL.Append("ELSE 'COMPLETA' ")
        strSQL.Append("END SITUACION ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES S ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOS E ")
        strSQL.Append("ON S.IDESTADO = E.IDESTADO ")
        strSQL.Append("INNER JOIN SAB_CAT_EMPLEADOS EM ")
        strSQL.Append("ON S.IDSOLICITANTE = EM.IDEMPLEADO ")
        strSQL.Append("WHERE S.IDESTABLECIMIENTO = @IDESTABLECIMIENTO and IDDEPENDENCIASOLICITANTE=@IDDEPENDENCIA  ")
        strSQL.Append("ORDER BY S.IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDDEPENDENCIA", SqlDbType.Int)
        args(1).Value = IDDEPENDENCIA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Devuelve informacion de la solicitud de libre gestion
    ''' </summary>
    ''' <param name="usuario">identificador del usuario</param>
    ''' <returns>Informacion de la solicitud de libre gestion</returns>

    Public Function ObtenerSolicitudesLG(ByVal usuario As String) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("S.*, ")
        strSQL.Append("E.DESCRIPCION ESTADO, ")
        strSQL.Append("CASE ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_ENTREGASOLICITUDES ES WHERE ES.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND ES.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_DETALLESOLICITUDES DS WHERE DS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND DS.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT count(*) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) = 0 THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT isnull(sum(MONTOPARTICIPACION), 0) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) <> S.MONTOSOLICITADO THEN 'INCOMPLETA' ")
        strSQL.Append("WHEN (SELECT isnull(sum(PORCENTAJEPARTICIPACION), 0) FROM SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES FFS WHERE FFS.IDESTABLECIMIENTO = S.IDESTABLECIMIENTO AND FFS.IDSOLICITUD = S.IDSOLICITUD) < 100 THEN 'INCOMPLETA' ")
        strSQL.Append("ELSE 'COMPLETA' ")
        strSQL.Append("END SITUACION ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES S ")
        strSQL.Append("INNER JOIN SAB_CAT_ESTADOS E ")
        strSQL.Append("ON S.IDESTADO = E.IDESTADO ")
        strSQL.Append("WHERE S.AUUSUARIOCREACION = @AUUSUARIOCRECION ")
        strSQL.Append("ORDER BY S.IDSOLICITUD ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@AUUSUARIOCRECION", SqlDbType.VarChar)
        args(0).Value = usuario

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    ''' <summary>
    ''' Metodo que actualiza el estado de una solicitud
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento</param>
    ''' <param name="IDSOLICITUD">Identificacion de la solicitud</param>
    ''' <returns>Valor entero que representa el resultado de la actualizacion</returns>

    Public Function CambiarEstadoSolicitudAprobadoUFI(ByVal IDESTABLECIMIENTO As Integer, ByVal IDSOLICITUD As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" Select IDCLASESUMINISTRO ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDSOLICITUD = " & IDSOLICITUD & ") ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    ''' <summary>
    ''' Devuelve informacion de la solicitud
    ''' </summary>
    ''' <param name="valor">identificador del valor</param>
    ''' <param name="tipob">Identificador del tipob</param>
    ''' <returns>Listado con informacion de la solicitud en formato dataset</returns>

    Public Function ObtenerSolicitudesEstablecimientos(ByVal valor As String, ByVal tipob As Integer, Optional ByVal iddependencia As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        Dim where As String = String.Empty
        strSQL.Append("select s.idsolicitud, s.correlativo, s.fechasolicitud, su.descripcion as suministro, isnull(entregas,'-') as  ")
        strSQL.Append("entregas,isnull(s.montosolicitado,0) montosolicitado,isnull(s.empleadosolicitante,'') as empleadosolicitante ,case when s.compraconjunta=0 then 'Individual' else 'Conjunta' ")
        strSQL.Append("end as tipoSolicitud,")
        strSQL.Append("case when s.idestado=1 then 'Grabada'  when s.idestado=2 then 'Enviada Área T.'  when s.idestado=3 then 'Autorizada' ")
        strSQL.Append("when s.idestado=4 then 'Rechazada Área T.' when s.idestado=5 then 'RECHAZADO Proceso Compra' when s.idestado=6 then 'Aprobado Proceso Compra' else '-' end as Estado, d.nombre as unidadtecnica ")
        strSQL.Append(" ,s.idestado,ds.nombre dependenciasolicitante ")
        strSQL.Append("from sab_est_solicitudes s left join sab_cat_suministros su on ")
        strSQL.Append("s.idclasesuministro=su.idsuministro inner join sab_cat_dependencias d on d.iddependencia=s.idunidadtecnica ")
        strSQL.Append(" inner join sab_cat_dependencias ds on ds.iddependencia=s.IDDEPENDENCIASOLICITANTE ")


        If tipob = 1 Then
            If valor <> "!" Then
                'strSQL.Append("where s.iddependenciasolicitante=" & iddependencia & " s.correlativo like '%" & valor & "%' ")
                where = "where  s.correlativo like '%" & valor & "%' "
                ' strSQL.Append("where  s.correlativo like '%" & valor & "%' ")
                'If iddependencia <> 0 Then
                '    strSQL.Append(" and iddependenciasolicitante=" & iddependencia & " and idestado<>6")
                'End If
            End If
        Else
            'strSQL.Append("where s.iddependenciasolicitante=" & iddependencia & " s.idestado= " & CInt(valor))
            If valor <> "!" Then
                where = "where s.idestado= " & CInt(valor)
                'strSQL.Append("where s.idestado= " & CInt(valor))
                'If iddependencia <> 0 Then
                '    strSQL.Append(" and iddependenciasolicitante=" & iddependencia & " and idestado<>6")
                'End If
            End If

        End If

        'strSQL.Append(" group by s.idsolicitud,s.correlativo,s.fechasolicitud,su.descripcion,s.montosolicitado,s.empleadosolicitante,s.idestado,s.compraconjunta ")
        If Not where = String.Empty Then
            where &= " and "
        Else
            where = " where "
        End If

        If iddependencia <> 0 Then
            where &= " iddependenciasolicitante=" & iddependencia & "  and compraconjunta<> 2 " ' & " And idestado <> 6 "
        Else
            where &= " iddependenciasolicitante=" & iddependencia & ""
        End If
        strSQL.Append(where)
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerSolicitudesEstablecimientosAutorizacion(ByVal iddependencia As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select s.idsolicitud, s.correlativo, s.fechasolicitud, su.descripcion as suministro, isnull(entregas,'-') as  ")
        strSQL.Append("entregas,s.montosolicitado,isnull(s.empleadosolicitante,'') as empleadosolicitante ,case when s.compraconjunta=0 then 'Individual' else 'Conjunta' ")
        strSQL.Append("end as tipoSolicitud,")
        strSQL.Append("case when s.idestado=1 then 'Grabada'  when s.idestado=2 then 'Enviada Área T.'  when s.idestado=3 then 'Autorizada' ")
        strSQL.Append("when s.idestado=4 then 'Rechazada Área T.' when s.idestado=5 then 'Rechazada UACI' end as Estado, s.idestado, d.nombre as dependenciasolicitante  ")
        strSQL.Append("from sab_est_solicitudes s inner join sab_cat_suministros su on ")
        strSQL.Append("s.idclasesuministro=su.idsuministro inner join sab_cat_dependencias d on d.iddependencia=s.iddependenciasolicitante ")
        'strSQL.Append(" INNER JOIN SAB_CAT_SUMINISTRODEPENDENCIAS sd on sd.idsuministro=s.idclasesuministro   ")
        strSQL.Append(" where s.idestado=2 and s.compraconjunta=0 and s.idunidadtecnica=" & iddependencia)


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerSolicitudesEstablecimientosUT(ByVal valor As String, ByVal tipob As Integer, Optional ByVal iddependencia As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("select s.idsolicitud, s.correlativo, s.fechasolicitud, su.descripcion as suministro, isnull(entregas,'-') as  ")
        strSQL.Append("entregas,s.montosolicitado,isnull(s.empleadosolicitante,'') as empleadosolicitante ,case when s.compraconjunta=0 then 'Individual' else 'Conjunta' ")
        strSQL.Append("end as tipoSolicitud,")
        strSQL.Append("case when s.idestado=1 then 'Grabada'  when s.idestado=2 then 'Enviada Área T.'  when s.idestado=3 then 'Autorizada' ")
        strSQL.Append("when s.idestado=4 then 'Rechazada Área T.' when s.idestado=5 then 'Rechazada UACI' end as Estado, s.idestado, d.nombre as unidadtecnica  ")
        strSQL.Append("from sab_est_solicitudes s inner join sab_cat_suministros su on ")
        strSQL.Append("s.idclasesuministro=su.idsuministro  inner join sab_cat_dependencias d on d.iddependencia=s.idunidadtecnica  ")
        If tipob = 1 Then
            If valor <> "!" Then
                'strSQL.Append("where s.iddependenciasolicitante=" & iddependencia & " s.correlativo like '%" & valor & "%' ")
                strSQL.Append("where  s.correlativo like '%" & valor & "%' AND S.COMPRACONJUNTA=2 and idestado<>6 ")
                If iddependencia <> 0 Then
                    strSQL.Append(" and iddependenciasolicitante=" & iddependencia)
                End If
            End If
        Else
            'strSQL.Append("where s.iddependenciasolicitante=" & iddependencia & " s.idestado= " & CInt(valor))
            If valor <> "!" Then
                strSQL.Append("where s.idestado= " & CInt(valor) & " AND S.COMPRACONJUNTA=2 and idestado<>6 ")
                If iddependencia <> 0 Then
                    strSQL.Append(" and iddependenciasolicitante=" & iddependencia)
                End If
            End If

        End If
        'strSQL.Append(" group by s.idsolicitud,s.correlativo,s.fechasolicitud,su.descripcion,s.montosolicitado,s.empleadosolicitante,s.idestado,s.compraconjunta ")
        If iddependencia <> 0 Then
            strSQL.Append(" where iddependenciasolicitante=" & iddependencia & " AND S.COMPRACONJUNTA=2 and idestado<>6 ")
        End If
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function obtenerIdSolicitud2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDDEPENDENCIA As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" Select isnull(MAX(IDSOLICITUDEPENDENCIA),0)+1 ")
        strSQL.Append(" FROM SAB_EST_SOLICITUDES ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDDEPENDENCIASOLICITANTE = " & IDDEPENDENCIA & ") ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerMontoProgramacionCompraSolicitudes(ByVal IDGRUPO As Integer) As Decimal

        Dim strSQL As New Text.StringBuilder

        strSQL.Append(" Select sum(precio * cantidad) ")
        strSQL.Append(" from fn_DetalleDistribucionProgramacion(@IDGRUPO) ")
        
        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDGRUPO", SqlDbType.Int)
        args(0).Value = IDGRUPO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function CopiarProgramacionATemp2(ByVal IDGRUPO As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("sproc_CopiaProgramacion")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@resultado", SqlDbType.Int)
        args(0).Direction = ParameterDirection.ReturnValue
        args(1) = New SqlParameter("@IDGRUPO", SqlDbType.BigInt)
        args(1).Direction = ParameterDirection.Input
        args(1).Value = IDGRUPO

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.StoredProcedure, strSQL.ToString(), args)

        Return args(0).Value

    End Function

    Public Function ObtenerSolicitudesEstablecimientosPorEstado(ByVal IDEstablecimiento As String, ByVal Estado As Integer) As DataSet



        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" select  s.idsolicitud, s.correlativo, s.fechasolicitud, su.descripcion as suministro, isnull(entregas,'-') as ")
        strSQL.Append("entregas,isnull(s.montosolicitado,0) montosolicitado,isnull(s.empleadosolicitante,'') as empleadosolicitante ,case when s.compraconjunta=0 then 'Individual' else 'Conjunta' ")
        strSQL.Append("end as tipoSolicitud, ")
        strSQL.Append(" est.DESCRIPCION ESTADO ")
        strSQL.Append(" , d.nombre as unidadtecnica ")
        strSQL.Append(" ,s.idestado,ds.nombre dependenciasolicitante, ")
        strSQL.Append("s.IDUNIDADTECNICA")
        strSQL.Append(",est.DESCRIPCION ESTADO,d.nombre as UNIDADTECNIC ")
        strSQL.Append("FROM SAB_EST_SOLICITUDES AS s INNER JOIN ")
        strSQL.Append(" SAB_CAT_ESTADOS AS est ON s.IDESTADO = est.IDESTADO ")
        strSQL.Append(" inner join sab_cat_suministros su on ")
        strSQL.Append("s.idclasesuministro=su.idsuministro inner join sab_cat_dependencias d on d.iddependencia=s.idunidadtecnica inner join sab_cat_dependencias ds on ds.iddependencia=s.IDDEPENDENCIASOLICITANTE ")
        strSQL.Append(" where S.IDEstablecimiento=@IDEstablecimiento and S.IDESTADO=@idestado ")
        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDEstablecimiento", SqlDbType.BigInt)
        args(0).Value = IDEstablecimiento
        args(1) = New SqlParameter("@idestado", SqlDbType.Int)
        args(1).Value = Estado

       
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function CambioEstadoSolicitudesEstablecimientosPorEstado(ByVal IDEstablecimiento As String, ByVal IDSOLICITUD As Integer, ByVal Estado As Integer) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" update SAB_EST_SOLICITUDES set IDESTADO=@IDESTADO ")
        strSQL.Append(" where IDEstablecimiento=@IDEstablecimiento and IDSOLICITUD=@IDSOLICITUD ")
        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDEstablecimiento", SqlDbType.BigInt)
        args(0).Value = IDEstablecimiento
        args(1) = New SqlParameter("@idestado", SqlDbType.Int)
        args(1).Value = Estado
        args(2) = New SqlParameter("@IDSOLICITUD", SqlDbType.Int)
        args(2).Value = IDSOLICITUD
        Dim ds As Integer
        ds = SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
#End Region

End Class
