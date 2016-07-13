Imports System.Text
''' <summary>
''' Contiene funciones y métodos para la manipulación y lectura de  información de los consumos y existencias  
''' </summary>
''' <remarks></remarks>
Public Class dbCONSUMOS
    Inherits dbBase

#Region "Funciones que el genapp utiliza pero nosotros no"
    Public Overrides Function Actualizar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As ENTIDADES.entidadBase) As String
        Return String.Empty
    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As ENTIDADES.entidadBase) As Integer

    End Function
#End Region

    ''' <summary>
    ''' Obtiene los datos de consumo y existencia para un establecimiento y fecha dada por almacén
    ''' </summary>
    ''' <param name="idEstablecimiento">Identificador del establecimiento que se desea consultar</param>
    ''' <param name="idAlmacen">Identificador del almacen que se desea consultar</param>
    ''' <param name="fechaConsumo">Mes/Año de consumo y existencia que se desea consultar</param>
    ''' <param name="tipo">Tipo de relación en la base de datos</param>
    ''' <returns>Lista de consumos y existencias para el establecimiento y fecha en forma de dataset</returns>
    ''' <remarks></remarks>
    'SCMS
    Public Function obtenerConsumoEstablecimientoFecha(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal idalmacenhospital As Integer, Optional ByVal tipo As String = "left outer", Optional IdPrograma As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select  ")
        strSQL.Append("   c.idAlmacen, cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, ")
        strSQL.Append("   c.consumoreal, c.consumoajustado, ")
        'strSQL.Append(" ( select isnull(eh.cantidaddisponible,0) from SAB_ALM_EXISTENCIAHISTORICA EH where eh.idproducto=cp.idproducto and eh.idalmacen=@IDALMACENHOSPITAL and eh.fecha=@FECHACONSUMO ) as existencia , c.diasdesab, c.demandainsatis, cp.idUnidadMedida ")
        strSQL.Append(" c.existencia , c.diasdesab, c.demandainsatis, cp.idUnidadMedida ")
        strSQL.Append(" from ")
        strSQL.Append("   vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("     inner join SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe on ")
        strSQL.Append("       cp.idProducto = pe.idProducto and ")
        strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")
        strSQL.Append("     inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on ")
        strSQL.Append("       pe.idEstablecimiento = ae.idEstablecimiento and ")
        strSQL.Append("       ae.idAlmacen = @IDALMACEN ")

        If IdPrograma <> 0 Then
            strSQL.Append("     inner join SAB_CAT_PRODUCTOSPROGRAMAS pp on ")
            strSQL.Append("       pp.idProducto = cp.idproducto and ")
            strSQL.Append("       pp.idPrograma = @IDPROGRAMA ")
        End If
        'strSQL.Append("       join SAB_ALM_EXISTENCIAHISTORICA EH on ")
        'strSQL.Append("       cp.idproducto=eh.idproducto and ")
        'strSQL.Append("       ae.idalmacen=eh.idalmacen and  ")
        'strSQL.Append("       eh.fecha=@FECHACONSUMO ")
        strSQL.Append(tipo)
        strSQL.Append(" join sab_est_consumos c on ")
        strSQL.Append("       pe.idProducto = c.idProducto and ")
        strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
        strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
        strSQL.Append("       c.fechaConsumo = @FECHACONSUMO ")
        strSQL.Append(" order by ")
        strSQL.Append("   cp.corrproducto asc ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idEstablecimiento
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = idAlmacen
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = fechaConsumo
        args(3) = New SqlParameter("@IDALMACENHOSPITAL", SqlDbType.Int)
        args(3).Value = idalmacenhospital
        args(4) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(4).Value = IdPrograma

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    Public Function obtenerAjusteExistenciaFarmacia(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal idalmacenhospital As Integer, Optional ByVal tipo As String = "left outer", Optional IdPrograma As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select  ")
        strSQL.Append("   c.idAlmacen, cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, ")
        strSQL.Append("   c.consumoajustado, ")
        strSQL.Append(" c.existencia , c.diasdesab, c.demandainsatis, cp.idUnidadMedida, cma.ajusteexistencia consumoreal,cma.motivo as nombre ")
        strSQL.Append(" from ")
        strSQL.Append("   vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("     inner join SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe on ")
        strSQL.Append("       cp.idProducto = pe.idProducto and ")
        strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")
        strSQL.Append("     inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on ")
        strSQL.Append("       pe.idEstablecimiento = ae.idEstablecimiento and ")
        strSQL.Append("       ae.idAlmacen = @IDALMACEN ")

        If IdPrograma <> 0 Then
            strSQL.Append("     inner join SAB_CAT_PRODUCTOSPROGRAMAS pp on ")
            strSQL.Append("       pp.idProducto = cp.idproducto and ")
            strSQL.Append("       pp.idPrograma = @IDPROGRAMA ")
        End If
        'strSQL.Append("       join SAB_ALM_EXISTENCIAHISTORICA EH on ")
        'strSQL.Append("       cp.idproducto=eh.idproducto and ")
        'strSQL.Append("       ae.idalmacen=eh.idalmacen and  ")
        'strSQL.Append("       eh.fecha=@FECHACONSUMO ")
        strSQL.Append(tipo)
        strSQL.Append(" join sab_est_consumos c on ")
        strSQL.Append("       pe.idProducto = c.idProducto and ")
        strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
        strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
        strSQL.Append("       c.fechaconsumo=@fechaconsumo ")

        strSQL.Append(" inner join SAB_EST_CONSUMOSMOTIVOAJUSTE cma on ")
        strSQL.Append("       cma.idProducto = c.idProducto and ")
        strSQL.Append("       cma.idEstablecimiento = c.idEstablecimiento and ")
        strSQL.Append("       cma.idAlmacen = c.idAlmacen and ")
        strSQL.Append("       cma.fechaconsumo='" & fechaConsumo & "'")

        strSQL.Append(" order by ")
        strSQL.Append("   cp.corrproducto asc ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idEstablecimiento
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = idAlmacen
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = fechaConsumo
        args(3) = New SqlParameter("@IDALMACENHOSPITAL", SqlDbType.Int)
        args(3).Value = idalmacenhospital
        args(4) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(4).Value = IdPrograma

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    Public Function obtenerExistenciaEstablecimientoFecha(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal FoA As Integer, Optional ByVal tipo As String = "left outer") As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select  ")
        strSQL.Append("   c.idAlmacen, cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, ")
        strSQL.Append("   c.consumoreal, c.consumoajustado, ")
        If FoA = 0 Then
            'farmacia
            strSQL.Append("   c.existencia, ")
        Else
            'almacen
            strSQL.Append("   eh.cantidaddisponible as existencia, ")
        End If

        strSQL.Append(" c.diasdesab, c.demandainsatis, cp.idUnidadMedida ")
        strSQL.Append(" from ")
        strSQL.Append("   vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("     inner join SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe on ")
        strSQL.Append("       cp.idProducto = pe.idProducto and ")
        strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")
        strSQL.Append("     inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on ")
        strSQL.Append("       pe.idEstablecimiento = ae.idEstablecimiento and ")
        strSQL.Append("       ae.idAlmacen = @IDALMACEN ")

        If FoA = 0 Then
            'farmacia

        Else
            'almacen
            strSQL.Append("       inner join SAB_ALM_EXISTENCIAHISTORICA EH on ")
            strSQL.Append("       cp.idproducto=eh.idproducto and ")
            strSQL.Append("       ae.idalmacen=eh.idalmacen and  ")
            strSQL.Append("       eh.fecha=@FECHACONSUMO ")
        End If

        strSQL.Append(tipo)
        strSQL.Append(" join sab_est_consumos c on ")
        strSQL.Append("       pe.idProducto = c.idProducto and ")
        strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
        strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
        strSQL.Append("       c.fechaConsumo = @FECHACONSUMO ")
        strSQL.Append(" order by ")
        strSQL.Append("   cp.corrproducto asc ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idEstablecimiento
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = idAlmacen
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = fechaConsumo

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    ''' <summary>
    ''' Obtiene los datos sumarizados de consumo y existencia para un establecimiento y fecha dada
    ''' </summary>
    ''' <param name="idEstablecimiento">Identificador del establecimiento que se desea consultar</param>
    ''' <param name="fechaConsumo">Mes/Año de consumo y existencia que se desea consultar</param>
    ''' <param name="tipo">Tipo de relación en la base de datos</param>
    ''' <returns>Lista de consumos y existencias sumarizados para el establecimiento y fecha en forma de dataset</returns>
    ''' <remarks></remarks>
    'SCMS
    Public Function obtenerConsumoTotalFecha(ByVal idEstablecimiento As Integer, ByVal fechaConsumo As Date, Optional ByVal tipo As String = "left outer", Optional idprograma As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select  ")
        strSQL.Append("   cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, count(c.idAlmacen) as idAlmacen, ")
        strSQL.Append("   sum(c.consumoreal) as consumoReal, sum(c.consumoajustado) as consumoAjustado, sum(c.existencia) as existencia, ")
        strSQL.Append("   max(c.diasdesab) as diasdesab, sum(c.demandainsatis) as demandainsatis ")
        strSQL.Append(" from ")
        strSQL.Append("   vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("     inner join SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe on ")
        strSQL.Append("       cp.idProducto = pe.idProducto and ")
        strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")
        strSQL.Append("     inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on ")
        strSQL.Append("       pe.idEstablecimiento = ae.idEstablecimiento ")

        If idprograma <> 0 Then
            strSQL.Append("     inner join SAB_CAT_PRODUCTOSPROGRAMAS pp on ")
            strSQL.Append("       pp.idProducto = cp.idproducto and ")
            strSQL.Append("       pp.idPrograma = @IDPROGRAMA ")
        End If

        strSQL.Append(tipo)
        strSQL.Append(" join sab_est_consumos c on ")
        strSQL.Append("       pe.idProducto = c.idProducto and ")
        strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
        strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
        strSQL.Append("       c.fechaConsumo = @FECHACONSUMO ")
        strSQL.Append(" group by ")
        strSQL.Append("   cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion ")
        strSQL.Append(" order by ")
        strSQL.Append("   cp.corrproducto asc ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idEstablecimiento
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = fechaConsumo
        args(3) = New SqlParameter("@idprograma", SqlDbType.Int)
        args(3).Value = idprograma
        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    'SCMS
    Public Function ChequearCYEMEsAnterior(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal FoA As Integer, Optional ByVal tipo As String = "left outer") As Integer
        If FoA = 0 Then
            Dim fechamesanterior As Date
            fechamesanterior = DateAdd("m", -1, fechaConsumo)

            Dim strSQL1 As New StringBuilder
            strSQL1.Append(" select  count(*) from sab_est_consumos where ")
            strSQL1.Append("       idEstablecimiento = @IDESTABLECIMIENTO and ")
            strSQL1.Append("       idAlmacen = @IDALMACEN and ")
            strSQL1.Append("       fechaConsumo = @FECHACONSUMO ")

            Dim args1(3) As SqlParameter
            args1(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
            args1(0).Value = idEstablecimiento
            args1(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
            args1(1).Value = idAlmacen
            args1(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
            args1(2).Value = fechamesanterior

            Dim Ex As New Integer
            Ex = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL1.ToString, args1)

            Return Ex
        End If
    End Function
    'SCMS
    Public Function ChequearCYEMEsPosterior(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal FoA As Integer, Optional ByVal tipo As String = "left outer") As Integer
        If FoA = 0 Then
            Dim fechamesanterior As Date
            fechamesanterior = DateAdd("m", 1, fechaConsumo)

            Dim strSQL1 As New StringBuilder
            strSQL1.Append(" select  count(*) from sab_est_consumos where ")
            strSQL1.Append("       idEstablecimiento = @IDESTABLECIMIENTO and ")
            strSQL1.Append("       idAlmacen = @IDALMACEN and ")
            strSQL1.Append("       fechaConsumo = @FECHACONSUMO ")

            Dim args1(3) As SqlParameter
            args1(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
            args1(0).Value = idEstablecimiento
            args1(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
            args1(1).Value = idAlmacen
            args1(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
            args1(2).Value = fechamesanterior

            Dim Ex As New Integer
            Ex = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL1.ToString, args1)

            Return Ex
        End If
    End Function
    'SCMS 
    Public Function obtenerExistenciaEstablecimientoFecha2(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, ByVal FoA As Integer, idempleado As Integer, Optional ByVal tipo As String = "left outer") As DataSet

        'ver si es farmacia o almacen
        If FoA = 0 Then
            'es farmacia

            'Chequear si carga por primera vez o ya hay consumos de ese mes ingresados
            Dim strSQL1 As New StringBuilder
            strSQL1.Append(" select  count(*) from sab_est_consumos where ")
            strSQL1.Append("       idEstablecimiento = @IDESTABLECIMIENTO and ")
            strSQL1.Append("       idAlmacen = @IDALMACEN and ")
            strSQL1.Append("       fechaConsumo = @FECHACONSUMO ")

            Dim args1(3) As SqlParameter
            args1(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
            args1(0).Value = idEstablecimiento
            args1(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
            args1(1).Value = idAlmacen
            args1(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
            args1(2).Value = fechaConsumo

            Dim Ex As New Integer
            Ex = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL1.ToString, args1)

            If Ex = 0 Then
                ' ES PRIMERA VEZ
                '-llenarlo con datos de existencias del mes anterior

                Dim fechamesanterior As Date
                fechamesanterior = DateAdd("m", -1, fechaConsumo)

                Dim strSQL As New StringBuilder

                strSQL.Append(" select  ")
                'strSQL.Append("   c.idAlmacen, cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, ")
                'strSQL.Append("   c.consumoreal, c.consumoajustado, ")
                'strSQL.Append("   isnull(c.existencia,0) existencia, ")
                'strSQL.Append(" C.diasdesab, c.demandainsatis, cp.idUnidadMedida ")

                strSQL.Append("   @IDALMACEN as IDALMACEN, cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, ")
                strSQL.Append("  0.00 as consumoreal, 0.00 as consumoajustado, ")
                strSQL.Append("   isnull(c.existencia,0)+dbo.fn_DespachosDelMes(@idalmacenHospital,cp.idproducto,@fechaConsumo) existencia, ")
                strSQL.Append(" 0 as diasdesab, 0 as demandainsatis, cp.idUnidadMedida ")


                strSQL.Append(" from ")
                strSQL.Append("   vv_CATALOGOPRODUCTOS cp ")
                strSQL.Append("     inner join SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe on ")
                strSQL.Append("       cp.idProducto = pe.idProducto and ")
                strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")
                strSQL.Append("     inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on ")
                strSQL.Append("       pe.idEstablecimiento = ae.idEstablecimiento and ")
                strSQL.Append("       ae.idAlmacen = @IDALMACEN ")
                strSQL.Append(tipo)
                strSQL.Append(" join sab_est_consumos c on ")
                strSQL.Append("       pe.idProducto = c.idProducto and ")
                strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
                strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
                strSQL.Append("       c.fechaConsumo =  @fechamesanterior ")
                strSQL.Append(" order by ")
                strSQL.Append("   cp.corrproducto asc ")

                Dim args(4) As SqlParameter
                args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
                args(0).Value = idEstablecimiento
                args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
                args(1).Value = idAlmacen
                args(2) = New SqlParameter("@fechamesanterior", SqlDbType.DateTime)
                args(2).Value = fechamesanterior
                args(3) = New SqlParameter("@fechaConsumo", SqlDbType.DateTime)
                args(3).Value = fechaConsumo
                args(4) = New SqlParameter("@idalmacenHospital", SqlDbType.Int)
                args(4).Value = obtenerIdAlmacenHospital(idempleado)

                Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

            Else
                'NO ES PRIMERA VEZ
                '-cargar todo igual
                Dim strSQL As New StringBuilder

                strSQL.Append(" select  ")
                strSQL.Append("   c.idAlmacen, cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, ")
                strSQL.Append("   c.consumoreal, c.consumoajustado, ")
                strSQL.Append("   c.existencia, ")

                strSQL.Append(" c.diasdesab, c.demandainsatis, cp.idUnidadMedida ")
                strSQL.Append(" from ")
                strSQL.Append("   vv_CATALOGOPRODUCTOS cp ")
                strSQL.Append("     inner join SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe on ")
                strSQL.Append("       cp.idProducto = pe.idProducto and ")
                strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")
                strSQL.Append("     inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on ")
                strSQL.Append("       pe.idEstablecimiento = ae.idEstablecimiento and ")
                strSQL.Append("       ae.idAlmacen = @IDALMACEN ")

                strSQL.Append(tipo)
                strSQL.Append(" join sab_est_consumos c on ")
                strSQL.Append("       pe.idProducto = c.idProducto and ")
                strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
                strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
                strSQL.Append("       c.fechaConsumo = @FECHACONSUMO ")
                strSQL.Append(" order by ")
                strSQL.Append("   cp.corrproducto asc ")

                Dim args(3) As SqlParameter
                args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
                args(0).Value = idEstablecimiento
                args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
                args(1).Value = idAlmacen
                args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
                args(2).Value = fechaConsumo

                Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

            End If


        Else
            'es almacen

            Dim strSQL As New StringBuilder

            strSQL.Append(" select  ")
            strSQL.Append("   c.idAlmacen, cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, ")
            strSQL.Append("   c.consumoreal, c.consumoajustado, ")

            strSQL.Append("   eh.cantidaddisponible as existencia, ")

            strSQL.Append(" c.diasdesab, c.demandainsatis, cp.idUnidadMedida ")
            strSQL.Append(" from ")
            strSQL.Append("   vv_CATALOGOPRODUCTOS cp ")
            strSQL.Append("     inner join SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe on ")
            strSQL.Append("       cp.idProducto = pe.idProducto and ")
            strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")
            strSQL.Append("     inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on ")
            strSQL.Append("       pe.idEstablecimiento = ae.idEstablecimiento and ")
            strSQL.Append("       ae.idAlmacen = @IDALMACEN ")

            strSQL.Append("       inner join SAB_ALM_EXISTENCIAHISTORICA EH on ")
            strSQL.Append("       cp.idproducto=eh.idproducto and ")
            strSQL.Append("       ae.idalmacen=eh.idalmacen and  ")
            strSQL.Append("       eh.fecha=@FECHACONSUMO ")

            strSQL.Append(tipo)
            strSQL.Append(" join sab_est_consumos c on ")
            strSQL.Append("       pe.idProducto = c.idProducto and ")
            strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
            strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
            strSQL.Append("       c.fechaConsumo = @FECHACONSUMO ")
            strSQL.Append(" order by ")
            strSQL.Append("   cp.corrproducto asc ")

            Dim args(3) As SqlParameter
            args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
            args(0).Value = idEstablecimiento
            args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
            args(1).Value = idAlmacen
            args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
            args(2).Value = fechaConsumo

            Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

        End If

        '---------------------------------------------------------------------------------------------

        '' Paso 1,ver si este ingreso es del presente o retroactivo.
        'If fechaConsumo.Month = Date.Now.Month - 1 Then
        '    'presente

        '    'si es farmacia
        '    If FoA = 0 Then

        '        '' Obtener la existencia del mes anterior para cada producto

        '        Dim strSQL As New StringBuilder
        '        strSQL.Append(" select  ")
        '        strSQL.Append("  idproducto, isnull(existencia,0) existencia ")
        '        ' strSQL.Append(tipo)
        '        strSQL.Append(" from sab_est_consumos  where ")
        '        strSQL.Append("       idEstablecimiento = @IDESTABLECIMIENTO and ")
        '        strSQL.Append("       idAlmacen = @IDALMCEN and ")
        '        strSQL.Append("       fechaConsumo = '" & fechaConsumo.Month - 1 & "'")
        '        strSQL.Append(" order by ")
        '        strSQL.Append("   cp.corrproducto asc ")


        '    End If





        'Else
        '    'retroactivo - se lee el dato de la tabla de consumos.

        '    Dim strSQL As New StringBuilder

        '    strSQL.Append(" select  ")
        '    strSQL.Append("   c.idAlmacen, cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, ")
        '    strSQL.Append("   c.consumoreal, c.consumoajustado, ")
        '    If FoA = 0 Then
        '        'farmacia
        '        strSQL.Append("   c.existencia, ")

        '    Else
        '        'almacen
        '        strSQL.Append("   eh.cantidaddisponible as existencia ")
        '    End If

        '    strSQL.Append(" c.diasdesab, c.demandainsatis, cp.idUnidadMedida ")
        '    strSQL.Append(" from ")
        '    strSQL.Append("   vv_CATALOGOPRODUCTOS cp ")
        '    strSQL.Append("     inner join SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe on ")
        '    strSQL.Append("       cp.idProducto = pe.idProducto and ")
        '    strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")
        '    strSQL.Append("     inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on ")
        '    strSQL.Append("       pe.idEstablecimiento = ae.idEstablecimiento and ")
        '    strSQL.Append("       ae.idAlmacen = @IDALMACEN ")

        '    If FoA = 0 Then
        '        'farmacia

        '    Else
        '        'almacen
        '        strSQL.Append("       inner join SAB_ALM_EXISTENCIAHISTORICA EH on ")
        '        strSQL.Append("       cp.idproducto=eh.idproducto and ")
        '        strSQL.Append("       ae.idalmacen=eh.idalmacen and  ")
        '        strSQL.Append("       eh.fecha=@FECHACONSUMO ")
        '    End If

        '    strSQL.Append(tipo)
        '    strSQL.Append(" join sab_est_consumos c on ")
        '    strSQL.Append("       pe.idProducto = c.idProducto and ")
        '    strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
        '    strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
        '    strSQL.Append("       c.fechaConsumo = @FECHACONSUMO ")
        '    strSQL.Append(" order by ")
        '    strSQL.Append("   cp.corrproducto asc ")

        '    Dim args(3) As SqlParameter
        '    args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        '    args(0).Value = idEstablecimiento
        '    args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        '    args(1).Value = idAlmacen
        '    args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        '    args(2).Value = fechaConsumo

        '    Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)
        'End If

    End Function
    Public Function obtenerExistenciaMesAnterior(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, idproducto As Integer) As Decimal
        Dim fechamesanterior As Date
        fechamesanterior = DateAdd("m", -1, fechaConsumo)


        Dim strSQL As New StringBuilder
        strSQL.Append("     select isnull(existencia,0) existencia ")
        strSQL.Append("     from sab_est_consumos  ")
        strSQL.Append("     where  ")
        strSQL.Append("     idproducto=@idproducto  ")
        strSQL.Append("     and idestablecimiento=@IDESTABLECIMIENTO  ")
        strSQL.Append("     and idalmacen= @IDALMACEN ")
        strSQL.Append("     and fechaconsumo=@fechamesanterior  ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idEstablecimiento
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = idAlmacen
        args(2) = New SqlParameter("@fechamesanterior", SqlDbType.DateTime)
        args(2).Value = fechamesanterior
        args(3) = New SqlParameter("@idproducto", SqlDbType.Int)
        args(3).Value = idproducto

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString, args)
    End Function
    Public Function obtenerAjustesDelMes(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, idproducto As Integer) As Decimal


        Dim strSQL As New StringBuilder
        strSQL.Append("     select isnull(sum(ajusteexistencia),0)  ")
        strSQL.Append("     from SAB_EST_CONSUMOSMOTIVOAJUSTE  ")
        strSQL.Append("     where  ")
        strSQL.Append("     idproducto=@idproducto  ")
        strSQL.Append("     and idestablecimiento=@IDESTABLECIMIENTO  ")
        strSQL.Append("     and idalmacen= @IDALMACEN ")
        ' strSQL.Append("     and fechaconsumo='" & Format(fechaConsumo, "yyyyddMM") & "'")
        strSQL.Append("     and fechaconsumo='" & fechaConsumo & "'")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idEstablecimiento
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = idAlmacen
        args(2) = New SqlParameter("@fechaconsumo", SqlDbType.VarChar)
        args(2).Value = fechaConsumo
        args(3) = New SqlParameter("@idproducto", SqlDbType.Int)
        args(3).Value = idproducto

        Dim x As Integer
        x = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString, args)
        Return x

    End Function
    Public Function obtenerDespachosDelMes(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date, idproducto As Integer) As Decimal

        Dim strSQL As New StringBuilder
        'strSQL.Append("     select isnull(ajusteexistencia,0)  ")
        'strSQL.Append("     from SAB_EST_CONSUMOSMOTIVOAJUSTE  ")
        'strSQL.Append("     where  ")
        'strSQL.Append("     idproducto=@idproducto  ")
        'strSQL.Append("     and idestablecimiento=@IDESTABLECIMIENTO  ")
        'strSQL.Append("     and idalmacen= @IDALMACEN ")
        'strSQL.Append("     and fechaconsumo=@fechaconsumo  ")

        strSQL.Append("    SELECT  ")
        strSQL.Append("    SUM(DM.CANTIDAD) CANTIDAD  ")
        strSQL.Append("    FROM SAB_ALM_DETALLEMOVIMIENTOS DM  ")
        strSQL.Append("    INNER JOIN SAB_ALM_MOVIMIENTOS M  ")
        strSQL.Append("    ON (DM.IDESTABLECIMIENTO = M.IDESTABLECIMIENTO  ")
        strSQL.Append("    AND DM.IDTIPOTRANSACCION = M.IDTIPOTRANSACCION  ")
        strSQL.Append("    AND DM.IDMOVIMIENTO = M.IDMOVIMIENTO)  ")
        strSQL.Append("    INNER JOIN vv_CATALOGOPRODUCTOS CP  ")
        strSQL.Append("    ON DM.IDPRODUCTO = CP.IDPRODUCTO  ")
        strSQL.Append("    INNER JOIN SAB_CAT_LUGARES_ENTREGA_HOSPITALES LEH ")
        strSQL.Append("    ON LEH.ID_LUGAR_ENTREGA_HOSPITAL = M.ID_LUGAR_ENTREGA_HOSPITAL ")
        strSQL.Append("    AND LEH.IDALMACEN=M.IDALMACEN ")

        strSQL.Append("    WHERE ")
        strSQL.Append("    M.IDALMACEN = @IDALMACEN ")
        strSQL.Append("    AND M.ANIO = @ANIO  ")
        strSQL.Append("    AND CP.IDSUMINISTRO = 1  ")
        strSQL.Append("     ")
        strSQL.Append("    AND LEH.NOMBRE_LUGAR_ENTREGA_HOSPITAL LIKE '%FARMACIA%' ")
        strSQL.Append("     ")
        strSQL.Append("    AND M.IDTIPOTRANSACCION = 2  ")
        strSQL.Append("    AND M.IDESTADO in (2, 4, 6)  ")
        strSQL.Append("    AND  DATEPART(month, FECHAMOVIMIENTO)=@MES ")
        strSQL.Append("    AND DM.IDPRODUCTO=@IDPRODUCTO ")
        strSQL.Append("     ")
        strSQL.Append("    GROUP BY DM.IDALMACEN, M.IDESTABLECIMIENTODESTINO, DM.IDPRODUCTO, DATEPART(month, FECHAMOVIMIENTO) ")
        strSQL.Append("    ORDER BY DM.IDPRODUCTO ")


        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@ANIO", SqlDbType.Int)
        args(0).Value = fechaConsumo.Year
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = idAlmacen
        args(2) = New SqlParameter("@MES", SqlDbType.Int)
        args(2).Value = fechaConsumo.Month
        args(3) = New SqlParameter("@idproducto", SqlDbType.Int)
        args(3).Value = idproducto

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString, args)
    End Function
    Public Function BorrarRegistrosMes(ByVal idEstablecimiento As Integer, ByVal idAlmacen As Integer, ByVal fechaConsumo As Date) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("     DELETE SAB_EST_CONSUMOS  ")

        strSQL.Append("     where  ")
        strSQL.Append("     idestablecimiento=@IDESTABLECIMIENTO  ")
        strSQL.Append("     and idalmacen= @IDALMACEN ")
        strSQL.Append("     and fechaconsumo=@fechaconsumo  ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idEstablecimiento
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = idAlmacen
        args(2) = New SqlParameter("@fechaconsumo", SqlDbType.DateTime)
        args(2).Value = fechaConsumo
   

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString, args)
    End Function
    'Public Function CrearTablaConsumos() As DataTable

    '    Dim col As New DataColumn
    '    Dim tbl As New DataTable("x")

    '    col = New DataColumn("idalmacen", System.Type.GetType("System.Int32"))
    '    tbl.Columns.Add(col)

    '    col = New DataColumn("idproducto", System.Type.GetType("System.Int32"))
    '    tbl.Columns.Add(col)

    '    col = New DataColumn("corrproducto", System.Type.GetType("System.String"))
    '    tbl.Columns.Add(col)

    '    col = New DataColumn("desclargo", System.Type.GetType("System.String"))
    '    tbl.Columns.Add(col)

    '    col = New DataColumn("descripcion", System.Type.GetType("System.String"))
    '    tbl.Columns.Add(col)

    '    col = New DataColumn("consumoreal", System.Type.GetType("System.Decimal"))
    '    tbl.Columns.Add(col)

    '    col = New DataColumn("consumoajustado", System.Type.GetType("System.Decimal"))
    '    tbl.Columns.Add(col)

    '    col = New DataColumn("existencia", System.Type.GetType("System.Decimal"))
    '    tbl.Columns.Add(col)

    '    col = New DataColumn("diasdesab", System.Type.GetType("System.Int32"))
    '    tbl.Columns.Add(col)

    '    col = New DataColumn("demandainsatis", System.Type.GetType("System.Int32"))
    '    tbl.Columns.Add(col)

    '    col = New DataColumn("idunidadmedida", System.Type.GetType("System.Int32"))
    '    tbl.Columns.Add(col)

    '    Return tbl
    'End Function
    ''' <summary>
    ''' Obtiene los datos sumarizados de consumo y existencia para un establecimiento y fecha dada
    ''' </summary>
    ''' <param name="idEstablecimiento">Identificador del establecimiento que se desea consultar</param>
    ''' <param name="fechaConsumo">Mes/Año de consumo y existencia que se desea consultar</param>
    ''' <param name="tipo">Tipo de relación en la base de datos</param>
    ''' <returns>Lista de consumos y existencias sumarizados para el establecimiento y fecha en forma de dataset</returns>
    ''' <remarks></remarks>
    'SCMS 
    Public Function obtenerConsumoTotalFecha2(ByVal idEstablecimiento As Integer, ByVal fechaConsumo As Date, Optional ByVal tipo As String = "left outer", Optional idprograma As Integer = 0) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select  ")
        strSQL.Append("   cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, count(c.idAlmacen) as idAlmacen, ")
        strSQL.Append("   sum(c.consumoreal) as consumoReal, sum(c.consumoajustado) as consumoAjustado, sum(c.existencia) as existencia, ")
        strSQL.Append("   max(c.diasdesab) as diasdesab, sum(c.demandainsatis) as demandainsatis ")
        strSQL.Append(" from ")
        strSQL.Append("   vv_CATALOGOPRODUCTOS cp ")
        strSQL.Append("     inner join SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe on ")
        strSQL.Append("       cp.idProducto = pe.idProducto and ")
        strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")
        strSQL.Append("     inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on ")
        strSQL.Append("       pe.idEstablecimiento = ae.idEstablecimiento ")

        If idprograma <> 0 Then
            strSQL.Append("     inner join SAB_CAT_PRODUCTOSPROGRAMAS pp on ")
            strSQL.Append("       pp.idProducto = cp.idproducto and ")
            strSQL.Append("       pp.idPrograma = @IDPROGRAMA ")
        End If

        strSQL.Append(tipo)
        strSQL.Append(" join sab_est_consumos c on ")
        strSQL.Append("       pe.idProducto = c.idProducto and ")
        strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
        strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
        strSQL.Append("       c.fechaConsumo = @FECHACONSUMO ")
        strSQL.Append(" group by ")
        strSQL.Append("   cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion ")
        strSQL.Append(" order by ")
        strSQL.Append("   cp.corrproducto asc ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idEstablecimiento
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = fechaConsumo

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    'SCMS 
    Public Function obtenerConsumoTotalxEstablecimientoMensual(ByVal idproducto As Integer, ByVal fechaConsumo As Date, idprograma As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select   ")
        strSQL.Append(" e.nombre AS ESTABLECIMIENTO,c.IDESTABLECIMIENTO, a.nombre AS ALMACEN, c.IDALMACEN, ")
        strSQL.Append(" cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, count(c.idAlmacen) as idAlmacen,  ")
        strSQL.Append(" sum(c.consumoreal) as consumoReal, sum(c.consumoajustado) as consumoAjustado, sum(c.existencia) as existencia,  ")
        strSQL.Append(" max(c.diasdesab) as diasdesab, sum(c.demandainsatis) as demandainsatis  ")
        strSQL.Append(" from  ")
        strSQL.Append(" vv_CATALOGOPRODUCTOS cp  ")
        strSQL.Append(" inner join SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe on  ")
        strSQL.Append(" cp.idProducto = pe.idProducto  ")

        strSQL.Append(" inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on  ")
        strSQL.Append(" pe.idEstablecimiento = ae.idEstablecimiento  ")

        strSQL.Append(" inner join SAB_CAT_PRODUCTOSPROGRAMAS pp on  ")
        strSQL.Append(" pp.idProducto = cp.idproducto and  ")
        strSQL.Append(" pp.idPrograma = @IDPROGRAMA  ")

        strSQL.Append(" inner join sab_cat_establecimientos e on e.idestablecimiento=pe.idestablecimiento ")
        strSQL.Append(" inner join SAB_CAT_ALMACENES a on a.IDALMACEN=ae.IDALMACEN  ")

        strSQL.Append(" inner join sab_est_consumos c on  ")
        strSQL.Append(" pe.idProducto = c.idProducto and  ")
        strSQL.Append(" ae.idEstablecimiento = c.idEstablecimiento and  ")
        strSQL.Append(" ae.idAlmacen = c.idAlmacen and  ")
        strSQL.Append(" c.fechaConsumo = @FECHACONSUMO and ")
        strSQL.Append(" c.IDPRODUCTO=@idproducto ")

        strSQL.Append(" group by  ")
        strSQL.Append(" e.nombre,c.IDESTABLECIMIENTO,a.nombre,c.IDALMACEN, cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion  ")
        strSQL.Append(" order by  ")
        strSQL.Append(" c.idestablecimiento asc ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(0).Value = idproducto
        args(1) = New SqlParameter("@IDPROGRAMA", SqlDbType.Int)
        args(1).Value = idprograma
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = fechaConsumo

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    Public Function obtenerReporteSSR(ByVal idEstablecimiento As Integer, ByVal fechaConsumo As Date, Optional ByVal tipo As String = "left outer") As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select  ")
        strSQL.Append("   cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion, count(c.idAlmacen) as idAlmacen, ")
        strSQL.Append("   sum(c.consumoreal) as consumoReal, sum(c.existencia) as existencia ")

        strSQL.Append(" from ")
        strSQL.Append("   vv_CATALOGOPRODUCTOS cp ")
        'strSQL.Append("     inner join SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe on ")
        'strSQL.Append("       cp.idProducto = pe.idProducto and ")
        'strSQL.Append("       pe.idEstablecimiento = @IDESTABLECIMIENTO ")

        strSQL.Append("     inner join SAB_CAT_PRODUCTOS_SSR SSR on ")
        strSQL.Append("     SSR.IDPRODUCTO=CP.IDPRODUCTO ")

        strSQL.Append("     inner join SAB_CAT_ALMACENESESTABLECIMIENTOS ae on ")
        strSQL.Append("       ae.idEstablecimiento = @IDESTABLECIMIENTO ")
        strSQL.Append(tipo)
        strSQL.Append(" join sab_est_consumos c on ")
        strSQL.Append("       SSR.idProducto = c.idProducto and ")
        strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
        strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
        strSQL.Append("       c.fechaConsumo = @FECHACONSUMO ")
        strSQL.Append(" group by ")
        strSQL.Append("   cp.idProducto, cp.corrproducto, cp.desclargo, cp.descripcion ")
        strSQL.Append(" order by ")
        strSQL.Append("   cp.corrproducto asc ")

        strSQL.Append(" EXEC SPROC_SSR_FINAL @FECHACONSUMO,@IDESTABLECIMIENTO ")
        'strSQL.Append(" FROM FN_SSR_PORCENTAJES(@FECHACONSUMO,@IDESTABLECIMIENTO) ORDER BY ORDEN ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = idEstablecimiento
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = fechaConsumo

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    ''' <summary>
    ''' Obtiene el desabastecimiento a nivel regional para un intervalo de tiempo definido
    ''' </summary>
    ''' <param name="FECHAINICIO">Fecha de inicio de la consulta</param>
    ''' <param name="FECHAFIN">Fecha fin de la consulta</param>
    ''' <returns>Desabastecimiento regional por mes, para los valores solicitados en forma de arreglo</returns>
    ''' <remarks></remarks>
    Public Function obtenerDesabastecimientoRegiones(ByVal FECHAINICIO As Date, ByVal FECHAFIN As Date) As ArrayList

        Dim arr As New ArrayList
        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   convert(varchar(10), fechaConsumo, 121) as fecha, round(avg(porcentajeDesab)*100, 2) as porciento ")
        strSQL.Append(" from ")
        strSQL.Append("   sce.dbo.fn_DesabastecimientoRegion(@FECHAINICIO, @FECHAFIN) ")
        strSQL.Append(" group by ")
        strSQL.Append("   fechaConsumo ")
        strSQL.Append(" order by ")
        strSQL.Append("   fechaConsumo ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(0).Value = FECHAINICIO
        args(1) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(1).Value = FECHAFIN

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

        While dr.Read

            Dim arrDatos(1) As String
            arrDatos(0) = dr.Item("fecha")
            arrDatos(1) = dr.Item("porciento")
            arr.Add(arrDatos)

        End While

        dr.Close()

        Return arr

    End Function

    ''' <summary>
    ''' Obtiene el desabastecimiento a nivel hospitalario para un intervalo de tiempo definido
    ''' </summary>
    ''' <param name="FECHAINICIO">Fecha de inicio de la consulta</param>
    ''' <param name="FECHAFIN">Fecha fin de la consulta</param>
    ''' <returns>Desabastecimiento hospitalario por mes, para los valores solicitados en forma de arreglo</returns>
    ''' <remarks></remarks>
    Public Function obtenerDesabastecimientoHospitales(ByVal FECHAINICIO As Date, ByVal FECHAFIN As Date) As ArrayList

        Dim arr As New ArrayList
        Dim strSQL As New StringBuilder

        strSQL.Append(" with q as ( ")
        strSQL.Append(" select ")
        strSQL.Append("   w.hospital, w.fechaConsumo, (convert(decimal(15,2), count(w.idProducto))/ ")
        strSQL.Append("   (select count(idProducto) ")
        strSQL.Append("    from fn_ConsumoHospital(@FECHAINICIO, @FECHAFIN) ")
        strSQL.Append("    where fechaConsumo = w.fechaConsumo and hospital = w.hospital)) as porcentaje ")
        strSQL.Append(" from ")
        strSQL.Append("   fn_ConsumoHospital(@FECHAINICIO, @FECHAFIN) w ")
        strSQL.Append(" where ")
        strSQL.Append("   w.cobertura < 1 ")
        strSQL.Append(" group by ")
        strSQL.Append("   w.hospital, w.fechaConsumo ")
        strSQL.Append(" ) ")
        strSQL.Append(" ")
        strSQL.Append(" select ")
        strSQL.Append("   convert(varchar(10), cec.fechaConsumo, 121) as fecha, ")
        strSQL.Append("   round(avg(isnull(porcentaje,0))*100,2) as porciento ")
        strSQL.Append(" from ")
        strSQL.Append("   fn_ConsultaEstablecimientosConsumo(@FECHAINICIO, @FECHAFIN) cec ")
        strSQL.Append("     left outer join q on ")
        strSQL.Append("       cec.idEstablecimiento = q.hospital and ")
        strSQL.Append("       cec.fechaConsumo = q.fechaConsumo ")
        strSQL.Append(" group by ")
        strSQL.Append("   cec.fechaConsumo ")
        strSQL.Append(" order by cec.fechaConsumo ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(0).Value = FECHAINICIO
        args(1) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(1).Value = FECHAFIN

        Dim dr As SqlClient.SqlDataReader = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

        While dr.Read

            Dim arrDatos(1) As String
            arrDatos(0) = dr.Item("fecha")
            arrDatos(1) = dr.Item("porciento")
            arr.Add(arrDatos)

        End While

        dr.Close()

        Return arr

    End Function

    ''' <summary>
    ''' Verifica si se ha registrado consumo y existencia para un producto en un almacén a una fecha específica
    ''' </summary>
    ''' <param name="eEntidad">Entidad correspondiente a los datos de consumos y existencias</param>
    ''' <param name="tran">Transacción relacionada a la conexión a la base de datos</param>
    ''' <returns>Un entero indicando si se ha registrado o no el consumo para la fecha dada</returns>
    ''' <remarks></remarks>
    Public Function existeConsumo(ByVal eEntidad As CONSUMOS, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("SELECT count(idProducto) FROM sab_est_consumos WHERE ")
        strSQL.Append("idAlmacen = @IDALMACEN and ")
        strSQL.Append("idEstablecimiento = @IDESTABLECIMIENTO and ")
        strSQL.Append("idProducto = @IDPRODUCTO and ")
        strSQL.Append("fechaConsumo = @FECHACONSUMO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = eEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = eEntidad.FECHACONSUMO
        args(3) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(3).Value = eEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteScalar(tran.SqlTransaction, CommandType.Text, strSQL.ToString, args)

    End Function

    ''' <summary>
    ''' Adiciona un registro de consumo y existencia para un almacén dado en una fecha específica
    ''' </summary>
    ''' <param name="eEntidad">Entidad correspondiente a los datos de consumos y existencias</param>
    ''' <param name="tran">Transacción relacionada a la conexión a la base de datos</param>
    ''' <returns>Un entero indicando si se ha ingresado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function ingresarConsumos(ByVal eEntidad As CONSUMOS, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO sab_est_consumos (idEstablecimiento, idAlmacen, idProducto, fechaConsumo, consumoReal, consumoAjustado, existencia, auUsuarioCreacion, auFechaCreacion) ")
        strSQL.Append("VALUES(@IDESTABLECIMIENTO, @IDALMACEN, @IDPRODUCTO, @FECHACONSUMO, @CONSUMO, @CONSUMO, @EXISTENCIA, @AUUSUARIOCREACION, @AUFECHACREACION) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = eEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = eEntidad.FECHACONSUMO
        args(3) = New SqlParameter("@CONSUMO", SqlDbType.Decimal)
        args(3).Value = eEntidad.CONSUMOREAL
        args(4) = New SqlParameter("@EXISTENCIA", SqlDbType.Decimal)
        args(4).Value = eEntidad.EXISTENCIA
        args(5) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(5).Value = eEntidad.AUUSUARIOCREACION
        args(6) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(6).Value = eEntidad.AUFECHACREACION
        args(7) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(7).Value = eEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString, args)

    End Function

    ''' <summary>
    ''' Actualiza un registro de consumo y existencia para un almacén dado en una fecha específica
    ''' </summary>
    ''' <param name="eEntidad">Entidad correspondiente a los datos de consumos y existencias</param>
    ''' <param name="tran">Transacción relacionada a la conexión a la base de datos</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function actualizarConsumos(ByVal eEntidad As CONSUMOS, ByVal tran As DistributedTransaction) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE sab_est_consumos SET ")
        strSQL.Append(" consumoReal=@CONSUMO, consumoAjustado=@CONSUMOAJUSTADO, existencia=@EXISTENCIA, auUsuarioModificacion=@AUUSUARIOCREACION, auFechaModificacion=@AUFECHACREACION  ")
        strSQL.Append(" WHERE idEstablecimiento = @IDESTABLECIMIENTO and idAlmacen=@IDALMACEN and idProducto=@IDPRODUCTO and fechaConsumo=@FECHACONSUMO ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = eEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = eEntidad.FECHACONSUMO
        args(3) = New SqlParameter("@CONSUMO", SqlDbType.Decimal)
        args(3).Value = eEntidad.CONSUMOREAL
        args(4) = New SqlParameter("@CONSUMOAJUSTADO", SqlDbType.Decimal)
        args(4).Value = eEntidad.CONSUMOAJUSTADO
        args(5) = New SqlParameter("@EXISTENCIA", SqlDbType.Decimal)
        args(5).Value = eEntidad.EXISTENCIA
        args(6) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(6).Value = eEntidad.AUUSUARIOCREACION
        args(7) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(7).Value = eEntidad.AUFECHACREACION
        args(8) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(8).Value = eEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(tran.SqlTransaction, CommandType.Text, strSQL.ToString, args)

    End Function

    ''' <summary>
    ''' Elimina un registro de consumo y existencia para un almacén dado en una fecha específica
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento al que pertenece el almacén</param>
    ''' <param name="IDALMACEN">Identificador del almacén para el cual se desea eliminar el registro</param>
    ''' <param name="IDPRODUCTO">Identificador del producto para el cual se desea eliminar el registro</param>
    ''' <param name="FECHACONSUMO">Fecha para la cual se desea eliminar el registro</param>
    ''' <returns>Un entero indicando si se ha eliminado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function eliminarConsumo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDALMACEN As Integer, ByVal IDPRODUCTO As Integer, ByVal FECHACONSUMO As DateTime) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" DELETE FROM sab_est_consumos ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND IDALMACEN=@IDALMACEN and idProducto=@IDPRODUCTO and fechaConsumo=@FECHACONSUMO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = IDPRODUCTO
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = FECHACONSUMO
        args(3) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(3).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function

    ''' <summary>
    ''' Actualiza el consumo de un producto en base a dias desabastecidos o demanda insatisfecha
    ''' </summary>
    ''' <param name="eEntidad">Entidad correspondiente a los datos de consumos y existencias</param>
    ''' <returns>Un entero indicando si se ha actualizado o no el registro en la base de datos</returns>
    ''' <remarks></remarks>
    Public Function ajustarConsumo(ByVal eEntidad As CONSUMOS) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE sab_est_consumos SET ")
        strSQL.Append(" consumoAjustado=@CONSUMO, diasdesab=@DIASDESABASTECIDOS, demandainsatis=@DEMANDAINSATISFECHA,")
        strSQL.Append(" auUsuarioModificacion=@AUUSUARIOMODIFICACION, auFechaModificacion=@AUFECHAMODIFICACION  ")
        strSQL.Append(" WHERE idEstablecimiento = @IDESTABLECIMIENTO and idAlmacen=@IDALMACEN and idProducto=@IDPRODUCTO and fechaConsumo=@FECHACONSUMO ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = eEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = eEntidad.FECHACONSUMO
        args(3) = New SqlParameter("@CONSUMO", SqlDbType.Decimal)
        args(3).Value = eEntidad.CONSUMOAJUSTADO
        args(4) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(4).Value = eEntidad.AUUSUARIOMODIFICACION
        args(5) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(5).Value = eEntidad.AUFECHAMODIFICACION
        args(6) = New SqlParameter("@DIASDESABASTECIDOS", SqlDbType.Int)
        args(6).Value = eEntidad.DIASDESABASTECIDOS
        args(7) = New SqlParameter("@DEMANDAINSATISFECHA", SqlDbType.Decimal)
        args(7).Value = eEntidad.DEMANDAINSATISFECHA
        args(8) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(8).Value = eEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    Public Function ajustarExistencia(ByVal eEntidad As CONSUMOS) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" UPDATE sab_est_consumos SET ")
        strSQL.Append(" Existencia=@ExistenciaAjustada, ")
        strSQL.Append(" auUsuarioModificacion=@AUUSUARIOMODIFICACION, auFechaModificacion=@AUFECHAMODIFICACION  ")
        strSQL.Append(" WHERE idEstablecimiento = @IDESTABLECIMIENTO and idAlmacen=@IDALMACEN and idProducto=@IDPRODUCTO and fechaConsumo=@FECHACONSUMO ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = eEntidad.IDALMACEN
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = eEntidad.IDPRODUCTO
        args(2) = New SqlParameter("@FECHACONSUMO", SqlDbType.DateTime)
        args(2).Value = eEntidad.FECHACONSUMO
        args(3) = New SqlParameter("@ExistenciaAjustada", SqlDbType.Decimal)
        args(3).Value = eEntidad.EXISTENCIA
        args(4) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(4).Value = eEntidad.AUUSUARIOMODIFICACION
        args(5) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(5).Value = eEntidad.AUFECHAMODIFICACION
        'args(6) = New SqlParameter("@MotivoExistenciaAjustada", SqlDbType.VarChar)
        'args(6).Value = eEntidad.MOTIVOEXISTENCIAAJUSTADA
        args(6) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(6).Value = eEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function
    Public Function IngresarMotivoExistenciaAjustada(ByVal idestablecimiento As Integer, idalmacen As Integer, idproducto As Integer, fechaconsumo As DateTime, existenciaajustada As Decimal, MOTIVOEXISTENCIA As String) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO sab_est_consumosmotivoajuste(IDESTABLECIMIENTO,IDALMACEN,IDPRODUCTO,FECHACONSUMO,ajusteexistencia,MOTIVO) VALUES( ")
        strSQL.Append(idestablecimiento & "," & idalmacen & "," & idproducto & ",'" & fechaconsumo & "'," & existenciaajustada & ",'" & MOTIVOEXISTENCIA & "')")

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString)

    End Function
    ''' <summary>
    ''' Obtiene el desabastecimiento hospitalario para una fecha dada
    ''' </summary>
    ''' <param name="FECHA">Fecha para la cual se desea consultar el desabastecimiento</param>
    ''' <returns>Lista de desabastecimiento hospitalario en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDesabastecimientoHospitalFecha(ByVal FECHA As Date) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("    e.nombre, ")
        strSQL.Append("    round(convert(decimal(15,2), count(ch.idProducto))/ ")
        strSQL.Append("      ( ")
        strSQL.Append("         select ")
        strSQL.Append("           count(ch2.idProducto) ")
        strSQL.Append("         from ")
        strSQL.Append("           dbo.fn_ConsumoHospital(@FECHA, @FECHA) ch2 ")
        strSQL.Append("         where ")
        strSQL.Append("           ch2.hospital = e.idEstablecimiento ")
        strSQL.Append("       )*100,2) as porcentaje ")
        strSQL.Append("  from ")
        strSQL.Append("    dbo.fn_ConsultaEstablecimientosConsumo(@FECHA, @FECHA) e ")
        strSQL.Append("      left outer join dbo.fn_ConsumoHospital(@FECHA, @FECHA) ch on ")
        strSQL.Append("        ch.hospital = e.idEstablecimiento and ")
        strSQL.Append("        ch.cobertura < 1 ")
        strSQL.Append("  group by  ")
        strSQL.Append("    e.nombre, e.idEstablecimiento ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(0).Value = FECHA

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function

    ''' <summary>
    ''' Obtiene el desabastecimiento regional para una fecha dada
    ''' </summary>
    ''' <param name="FECHA">Fecha para la cual se desea consultar el desabastecimiento</param>
    ''' <returns>Lista de desabastecimiento regional en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function obtenerDesabastecimientoRegionFecha(ByVal FECHA As Date) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append("  select ")
        strSQL.Append("    e1.nombre, round((cr.porcentajeDesab *100),2) as porcentaje ")
        strSQL.Append("  from ")
        strSQL.Append("    sce.dbo.fn_ConsumoRegion(@FECHA, @FECHA) cr ")
        strSQL.Append("      inner join sab_cat_establecimientos e1 on ")
        strSQL.Append("        cr.idEstablecimientoAbas = e1.idEstablecimiento ")
        strSQL.Append(" order by e1.nombre ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(0).Value = FECHA

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function

    ''' <summary>
    ''' Obtiene el total de establecimientos con registro de consumo y existencia para una fecha dada
    ''' </summary>
    ''' <param name="FECHA">Fecha para la cual se desea consultar los establecimientos</param>
    ''' <returns>Un entero indicando el número de establecimientos con registros para la fecha solicitada</returns>
    ''' <remarks></remarks>
    Public Function totalEstablecimientosConsumo(ByVal FECHA As Date) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("  select ")
        strSQL.Append("    count (idEstablecimiento) ")
        strSQL.Append("  from ")
        strSQL.Append("    fn_ConsultaEstablecimientosConsumo(@FECHA, @FECHA) ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(0).Value = FECHA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function

    ''' <summary>
    ''' Obtiene una lista de los hospitales que capturan consumos y existencias
    ''' </summary>
    ''' <returns>Lista de hospitales en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function listaHospitalesCaptura() As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("    distinct e.idEstablecimiento, e.nombre ")
        strSQL.Append("  from ")
        strSQL.Append("    SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe ")
        strSQL.Append("      inner join SAB_CAT_ESTABLECIMIENTOS e on ")
        strSQL.Append("        pe.idEstablecimiento = e.idEstablecimiento ")
        strSQL.Append("  where ")
        strSQL.Append("    e.idTipoEstablecimiento in (3,8) ")
        strSQL.Append("  order by ")
        strSQL.Append("    e.nombre ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString)

    End Function

    ''' <summary>
    ''' Obtiene el universo de medicamentos definidos por un establecimiento para la captura de consumos y existencias
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento del cual se desea conocer el universo de medicamentos</param>
    ''' <returns>Universo de medicamentos para el establecimiento en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function listaUniversoCapturaHospital(ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   cp.corrproducto, cp.desclargo, cp.descripcion, ")
        strSQL.Append("   case when ")
        strSQL.Append("     (select count(idProducto) ")
        strSQL.Append("      from dbo.SAB_EST_CONSUMOS ")
        strSQL.Append("      where idEstablecimiento = pe.idEstablecimiento and idProducto = pe.idProducto) > 0 ")
        strSQL.Append("     then 1 ")
        strSQL.Append("     else 0 ")
        strSQL.Append("   end as capturado ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe ")
        strSQL.Append("     inner join SAB_CAT_ESTABLECIMIENTOS e on ")
        strSQL.Append("       pe.idEstablecimiento = e.idEstablecimiento ")
        strSQL.Append("     inner join dbo.vv_CATALOGOPRODUCTOS cp on ")
        strSQL.Append("       pe.idProducto = cp.idProducto ")
        strSQL.Append(" where ")
        strSQL.Append("   e.idEstablecimiento = @IDESTABLECIMIENTO ")
        strSQL.Append(" order by ")
        strSQL.Append("   cp.corrproducto asc ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function

    ''' <summary>
    ''' Obtiene el universo de hospitales que capturan un medicamento específico en consumos y existencias
    ''' </summary>
    ''' <param name="CODIGO">Código del medicamento del cual se desea conocer los establecimientos</param>
    ''' <returns>Lista de hospitales en forma de dataset</returns>
    ''' <remarks></remarks>
    Public Function listaUniversoCapturaMedicamento(ByVal CODIGO As String) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   e.nombre, cp.corrproducto, cp.desclargo, cp.descripcion, ")
        strSQL.Append("   case when ")
        strSQL.Append("        (select count(idProducto) ")
        strSQL.Append("         from dbo.SAB_EST_CONSUMOS ")
        strSQL.Append("         where idEstablecimiento = pe.idEstablecimiento and idProducto = pe.idProducto) > 0 ")
        strSQL.Append("        then 1 ")
        strSQL.Append("        else 0 ")
        strSQL.Append("      end as capturado ")
        strSQL.Append(" from ")
        strSQL.Append("   SAB_CAT_PRODUCTOSESTABLECIMIENTOS pe ")
        strSQL.Append("     inner join SAB_CAT_ESTABLECIMIENTOS e on ")
        strSQL.Append("       pe.idEstablecimiento = e.idEstablecimiento ")
        strSQL.Append("     inner join dbo.vv_CATALOGOPRODUCTOS cp on ")
        strSQL.Append("       pe.idProducto = cp.idProducto ")
        strSQL.Append(" where ")
        strSQL.Append("   cp.corrproducto = @CODIGO and ")
        strSQL.Append("   e.idtipoEstablecimiento in (3,8) ")
        strSQL.Append(" order by ")
        strSQL.Append("   e.nombre asc ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@CODIGO", SqlDbType.VarChar)
        args(0).Value = CODIGO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString, args)

    End Function

    ''' <summary>
    ''' Obtiene todos los hospitales que pueden capturar datos de consumos y existencias
    ''' </summary>
    ''' <returns>Lista de hospitales en forma de arreglo</returns>
    ''' <remarks></remarks>
    Public Function listaHospitalesFarmaciaAlmacenes() As ArrayList

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   distinct e.nombre ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_cat_establecimientos e ")
        strSQL.Append("     inner join sab_cat_almacenesestablecimientos ae on ")
        strSQL.Append("       e.idEstablecimiento = ae.idEstablecimiento ")
        strSQL.Append("     inner join sab_cat_almacenes a on ")
        strSQL.Append("       ae.idAlmacen = a.idAlmacen ")
        strSQL.Append(" where ")
        strSQL.Append("   e.idTipoEstablecimiento in (3, 8) and ")
        strSQL.Append("   a.nombre not like '%PEIS%' and ")
        strSQL.Append("   a.nombre not like '%Sibasi%' ")
        strSQL.Append(" group by ")
        strSQL.Append("   e.nombre ")
        strSQL.Append(" order by ")
        strSQL.Append("   e.nombre ")

        Dim dr As SqlClient.SqlDataReader
        Dim arr As New ArrayList

        dr = SqlHelper.ExecuteReader(Me._cnnStr, CommandType.Text, strSQL.ToString)

        Do While dr.Read
            arr.Add(dr.Item(0))
        Loop

        dr.Close()

        Return arr

    End Function

    Public Function listaHospitalesFarmaciaAlmacenesCodigo() As ArrayList

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   distinct e.nombre, e.codigoEstablecimiento ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_cat_establecimientos e ")
        strSQL.Append("     inner join sab_cat_almacenesestablecimientos ae on ")
        strSQL.Append("       e.idEstablecimiento = ae.idEstablecimiento ")
        strSQL.Append("     inner join sab_cat_almacenes a on ")
        strSQL.Append("       ae.idAlmacen = a.idAlmacen ")
        strSQL.Append(" where ")
        strSQL.Append("   e.idTipoEstablecimiento in (3, 8) and ")
        strSQL.Append("   a.nombre not like '%PEIS%' and ")
        strSQL.Append("   a.nombre not like '%Sibasi%' ")
        strSQL.Append(" group by ")
        strSQL.Append("   e.codigoEstablecimiento, e.nombre ")
        strSQL.Append(" order by ")
        strSQL.Append("   e.codigoEstablecimiento, e.nombre ")

        Dim dr As SqlClient.SqlDataReader
        Dim arr As New ArrayList

        dr = SqlHelper.ExecuteReader(Me._cnnStr, CommandType.Text, strSQL.ToString)

        Do While dr.Read
            arr.Add(dr.Item(0))
        Loop

        dr.Close()

        Return arr

    End Function

    Public Function listaRegionesSCE() As ArrayList

        Dim strSQL As New StringBuilder

        strSQL.Append(" select ")
        strSQL.Append("   'Región ' + nombre ")
        strSQL.Append(" from ")
        strSQL.Append("   sce.dbo.vv_REGIONES ")
        strSQL.Append(" order by ")
        strSQL.Append("   nombre ")

        Dim dr As SqlClient.SqlDataReader
        Dim arr As New ArrayList

        dr = SqlHelper.ExecuteReader(Me._cnnStr, CommandType.Text, strSQL.ToString)

        Do While dr.Read
            arr.Add(dr.Item(0))
        Loop

        dr.Close()

        Return arr

    End Function

    ''' <summary>
    ''' Obtiene el estado de captura hospitalario de consumos y existencias para una fecha dada
    ''' </summary>
    ''' <param name="fecha">Fecha de la que se desea conocer el estado de captura</param>
    ''' <param name="arrHosp">Lista de los hospitales que pueden capturar consumos y existencias</param>
    ''' <returns>Estado de captura en forma de arreglo</returns>
    ''' <remarks></remarks>
    Public Function obtenerCodigosCapturadosConsumo(ByVal fecha As Date, ByRef arrHosp As ArrayList) As Array

        Dim strSQL As New StringBuilder

        Dim arrHospitales As ArrayList = listaHospitalesFarmaciaAlmacenes()

        Dim matriz(arrHospitales.Count, 1) As Integer

        strSQL.Append(" select ")
        strSQL.Append("   e.nombre as establecimiento, c.fechaConsumo, a.idAlmacen, a.nombre as farmacia, a.esFarmacia, count(c.idProducto) as productos ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_cat_establecimientos e ")
        strSQL.Append("     inner join sab_cat_almacenesestablecimientos ae on ")
        strSQL.Append("       e.idEstablecimiento = ae.idEstablecimiento ")
        strSQL.Append("     inner join sab_cat_almacenes a on ")
        strSQL.Append("       ae.idAlmacen = a.idAlmacen ")
        strSQL.Append("     left outer join sab_est_consumos c on ")
        strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
        strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
        strSQL.Append("       c.fechaconsumo = @FECHA ")
        strSQL.Append(" where ")
        strSQL.Append("   e.idTipoEstablecimiento in (3, 8) and ")
        strSQL.Append("   a.nombre not like '%PEIS%' and ")
        strSQL.Append("   a.nombre not like '%Sibasi%' ")
        strSQL.Append(" group by ")
        strSQL.Append("   e.nombre, a.idAlmacen, a.nombre, c.fechaConsumo, a.esFarmacia ")
        strSQL.Append(" order by ")
        strSQL.Append("   e.nombre, fechaConsumo, a.esFarmacia ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(0).Value = fecha

        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me._cnnStr, CommandType.Text, strSQL.ToString, args)

        Do While dr.Read

            Dim a As Integer = dr.Item("esFarmacia")
            Dim f As Integer = arrHospitales.IndexOf(dr.Item("establecimiento"))
            Dim posicion As Integer

            posicion = 0

            If a = 1 Then posicion += 1

            matriz(f, posicion) = dr.Item(5)

        Loop

        dr.Close()

        arrHosp = arrHospitales

        Return matriz

    End Function

    Public Function obtenerCodigosCapturadosConsumoIntervalo(ByVal fecha As Date, ByRef arrHosp As ArrayList, ByRef arrFechas As ArrayList) As Array

        Dim strSQL As New StringBuilder

        'Obtenemos el listado de hospitales en la base de datos
        Dim arrHospitales As ArrayList = listaHospitalesFarmaciaAlmacenesCodigo()

        'construimos las fechas, orden asc
        Dim f1 As Date = DateAdd(DateInterval.Month, -2, fecha)
        Dim arrFech As New ArrayList

        Do While f1 <= fecha
            arrFech.Add(f1)
            f1 = DateAdd(DateInterval.Month, 1, f1)
        Loop

        'Creamos la matriz: n*m*l en  donde
        'n: los hospitales
        'm: las fechas
        'l: datos de almacen y farmacia

        Dim matriz(arrHospitales.Count, arrFech.Count, 1) As Integer

        strSQL.Append(" select ")
        strSQL.Append("   e.nombre as establecimiento, c.fechaConsumo, a.idAlmacen, a.nombre as farmacia, a.esFarmacia, count(c.idProducto) as productos ")
        strSQL.Append(" from ")
        strSQL.Append("   sab_cat_establecimientos e ")
        strSQL.Append("     inner join sab_cat_almacenesestablecimientos ae on ")
        strSQL.Append("       e.idEstablecimiento = ae.idEstablecimiento ")
        strSQL.Append("     inner join sab_cat_almacenes a on ")
        strSQL.Append("       ae.idAlmacen = a.idAlmacen ")
        strSQL.Append("     left outer join sab_est_consumos c on ")
        strSQL.Append("       ae.idEstablecimiento = c.idEstablecimiento and ")
        strSQL.Append("       ae.idAlmacen = c.idAlmacen and ")
        strSQL.Append("       (c.fechaconsumo >= @FECHA and c.fechaConsumo <= @FECHA2) ")
        strSQL.Append(" where ")
        strSQL.Append("   e.idTipoEstablecimiento in (3, 8) and ")
        strSQL.Append("   a.nombre not like '%PEIS%' and ")
        strSQL.Append("   a.nombre not like '%Sibasi%' ")
        strSQL.Append(" group by ")
        strSQL.Append("   e.nombre, a.idAlmacen, a.nombre, c.fechaConsumo, a.esFarmacia ")
        strSQL.Append(" order by ")
        strSQL.Append("   e.nombre, fechaConsumo, a.esFarmacia ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@FECHA2", SqlDbType.DateTime)
        args(0).Value = fecha
        args(1) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(1).Value = DateAdd(DateInterval.Month, -2, fecha)

        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me._cnnStr, CommandType.Text, strSQL.ToString, args)

        Do While dr.Read

            Dim a As Integer = dr.Item("esFarmacia")
            Dim f As Integer = arrHospitales.IndexOf(dr.Item("establecimiento"))

            Dim posicion As Integer = 0
            Dim posicion2 As Integer = arrFech.IndexOf(dr.Item("fechaConsumo"))

            If a = 1 Then posicion += 1

            If posicion2 <> -1 Then matriz(f, posicion2, posicion) = dr.Item(5)

        Loop

        dr.Close()

        arrHosp = arrHospitales
        arrFechas = arrFech

        Return matriz

    End Function

    Public Function obtenerCodigosRegionesConsumoIntervalo(ByVal fecha As Date, ByRef arrFechas As ArrayList, ByRef arrRegiones As ArrayList) As Array

        Dim strSQL As New StringBuilder

        'Obtenemos el listado de hospitales en la base de datos
        Dim arrReg As ArrayList = listaRegionesSCE()

        'construimos las fechas, orden asc
        Dim f1 As Date = DateAdd(DateInterval.Month, -2, fecha)
        Dim arrFech As New ArrayList

        Do While f1 <= fecha
            arrFech.Add(f1)
            f1 = DateAdd(DateInterval.Month, 1, f1)
        Loop

        'Creamos la matriz: n*m*l en  donde
        'n: los regiones
        'm: las fechas
        'l: datos de region

        Dim matriz(arrReg.Count, arrFech.Count, 2) As Integer

        strSQL.Append(" select region, fecha, tipo, total from fn_EstadoCapturaRegion(@FECHA1) ")
        strSQL.Append(" union ")
        strSQL.Append(" select region, fecha, tipo, total from fn_EstadoCapturaRegion(@FECHA2) ")
        strSQL.Append(" union ")
        strSQL.Append(" select region, fecha, tipo, total from fn_EstadoCapturaRegion(@FECHA3) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@FECHA3", SqlDbType.DateTime)
        args(0).Value = fecha
        args(1) = New SqlParameter("@FECHA2", SqlDbType.DateTime)
        args(1).Value = DateAdd(DateInterval.Month, -1, fecha)
        args(2) = New SqlParameter("@FECHA1", SqlDbType.DateTime)
        args(2).Value = DateAdd(DateInterval.Month, -2, fecha)

        Dim dr As SqlClient.SqlDataReader

        dr = SqlHelper.ExecuteReader(Me._cnnStr, CommandType.Text, strSQL.ToString, args)

        Do While dr.Read

            Dim f As Integer = arrReg.IndexOf(dr.Item("region"))

            Dim posicion As Integer = dr.Item("tipo")
            Dim posicion2 As Integer = arrFech.IndexOf(dr.Item("fecha"))

            If posicion2 <> -1 Then matriz(f, posicion2, posicion) = dr.Item("total")

        Loop

        dr.Close()

        arrRegiones = arrReg
        arrFechas = arrFech

        Return matriz

    End Function
    Public Function IngresarConsumoExistenciaCero(ByVal idestablecimiento As Integer, idalmacen As Integer, idproducto As Integer, fechaconsumo As DateTime) As Integer

        Dim strSQL As New StringBuilder

        Dim fechamesanterior As Date
        fechamesanterior = DateAdd("m", -1, fechaconsumo)

        strSQL.Append(" INSERT INTO sab_est_consumos(IDESTABLECIMIENTO,IDALMACEN,IDPRODUCTO,FECHACONSUMO,consumoreal,consumoajustado,existencia,diasdesab,demandainsatis,auusuariocreacion,aufechacreacion,auusuariomodificacion,aufechamodificacion,estasincronizada) VALUES( ")
        strSQL.Append(idestablecimiento & "," & idalmacen & "," & idproducto & ",'" & fechamesanterior.Year & convertirmes(fechamesanterior.Month) & "01',0,0,0,0,0,'SINAB',getdate(),'SINAB',getdate(),0)")

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString)

    End Function
    Public Function convertirmes(Month As Integer) As String
        Select Case Month
            Case Is = 1
                Return "01"
            Case Is = 2
                Return "02"
            Case Is = 3
                Return "03"
            Case Is = 4
                Return "04"
            Case Is = 5
                Return "05"
            Case Is = 6
                Return "06"
            Case Is = 7
                Return "07"
            Case Is = 8
                Return "08"
            Case Is = 9
                Return "09"
            Case Is = 10
                Return "10"
            Case Is = 11
                Return "11"
            Case Is = 12
                Return "12"
            Case Else
                Return String.Empty
        End Select
    End Function

    Public Function obtenerIdAlmacenHospital(ByVal idempleado As Integer) As Integer
        Dim strSQL As New StringBuilder


        strSQL.Append(" select a.IDALMACEN ")
        strSQL.Append(" from sab_cat_almacenesestablecimientos ae inner join sab_cat_almacenes a ")
        strSQL.Append(" on a.idalmacen = ae.idalmacen ")
        strSQL.Append(" inner join sab_cat_empleadosalmacen ea ")
        strSQL.Append(" on ea.idalmacen=a.idalmacen ")
        strSQL.Append(" where a.esfarmacia=0 and ea.idempleado=" & idempleado & "  and ae.esprincipal=1 ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString)
    End Function

    Public Function ObtenerIdAlmacenHospital(ByVal idempleado As Integer, ByVal esFarmacia As Boolean) As Integer
        Dim strSQL As New StringBuilder


        strSQL.Append(" select a.IDALMACEN ")
        strSQL.Append(" from sab_cat_almacenesestablecimientos ae inner join sab_cat_almacenes a ")
        strSQL.Append(" on a.idalmacen = ae.idalmacen ")
        strSQL.Append(" inner join sab_cat_empleadosalmacen ea ")
        strSQL.Append(" on ea.idalmacen=a.idalmacen ")
        If esFarmacia Then
            strSQL.Append(" where a.esfarmacia=1 and ea.idempleado=" & idempleado & "  and ae.esprincipal=0 ")
        Else
            strSQL.Append(" where a.esfarmacia=0 and ea.idempleado=" & idempleado & "  and ae.esprincipal=1 ")
        End If


        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString)
    End Function
End Class
