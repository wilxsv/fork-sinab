Partial Public Class dbPROVEEDORES

#Region " Métodos Agregados "

    Public Function ObtenerDataSetIDPROVEEDOR(ByVal CODIGOPROVEEDOR As String) As Integer

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDPROVEEDOR ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append(" WHERE CODIGOPROVEEDOR = @CODIGOPROVEEDOR ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@CODIGOPROVEEDOR", SqlDbType.VarChar)
        args(0).Value = CODIGOPROVEEDOR

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerDsProveedorProcesoCompra(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_UACI_ADJUDICACION.IDPROVEEDOR, SAB_CAT_PROVEEDORES.NOMBRE ")
        strSQL.Append(" FROM SAB_UACI_ADJUDICACION INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_ADJUDICACION.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_ADJUDICACION.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (SAB_UACI_ADJUDICACION.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerDataSetPROVEEDOROrden(ByVal tipo As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)

        Select Case tipo
            Case Is = 1
                strSQL.Append(" order by NOMBRE ASC ")
            Case Is = 0
                strSQL.Append(" order by NOMBRE DESC ")
        End Select

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerdSProveedorNoBaseEntrega(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT IDPROVEEDOR, NOMBRE ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append(" WHERE (NOT (IDPROVEEDOR IN ")
        strSQL.Append(" (SELECT IDPROVEEDOR ")
        strSQL.Append(" FROM SAB_UACI_ENTREGABASES ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ")))) ")
        strSQL.Append(" ORDER BY NOMBRE ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    ''' <summary>
    ''' Obtiene los proveedores relacionados a un proceso de compra.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos.</param>
    ''' <param name="IDPROCESOCOMPRA">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function ObtenerDsProveedorProcesoCompraContrato(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        ' PROVEEDORES
        strSQL.Append(" SELECT P.IDPROVEEDOR, P.NOMBRE ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA CP INNER JOIN ")
        strSQL.Append("            SAB_CAT_PROVEEDORES P ON CP.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append(" WHERE (CP.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & " ) AND (CP.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerDsProveedorProcesoCompraContratoMultas(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal IDANALISTA As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT p.IDPROVEEDOR, p.NOMBRE ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA AS cp INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS p ON cp.IDPROVEEDOR = p.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO AS nI ON cp.IDESTABLECIMIENTO = nI.IDESTABLECIMIENTO AND ")
        strSQL.Append(" cp.IDPROVEEDOR = nI.IDPROVEEDOR AND cp.IDCONTRATO = nI.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_ANALISTAPROVEEDORES AS AP ON cp.IDESTABLECIMIENTO = AP.IDESTABLECIMIENTO AND ")
        strSQL.Append(" cp.IDPROCESOCOMPRA = AP.IDPROCESOCOMPRA And cp.IDPROVEEDOR = AP.IDPROVEEDOR ")
        strSQL.Append(" WHERE (cp.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & " ) AND (cp.IDPROCESOCOMPRA = " & IDPROCESOCOMPRA & ") AND (AP.IDANALISTA = " & IDANALISTA & ") ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerDatasetProveedorPorPeriodo(ByVal fini As Date, ByVal ffin As Date, ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT p.CODIGOPROVEEDOR, p.NOMBRE, pc.FECHAINICIOPROCESOCOMPRA ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA AS cp INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS p ON cp.IDPROVEEDOR = p.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS AS pc ON cp.IDPROCESOCOMPRA = pc.IDPROCESOCOMPRA AND ")
        strSQL.Append(" cp.IDESTABLECIMIENTO = pc.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE (cp.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (pc.FECHAINICIOPROCESOCOMPRA >= @fini) AND ")
        strSQL.Append(" (pc.FECHAINICIOPROCESOCOMPRA <= @ffin) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@fini", SqlDbType.DateTime)
        args(1).Value = fini
        args(2) = New SqlParameter("@ffin", SqlDbType.DateTime)
        args(2).Value = ffin

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene los proveedores de un proceso de compra
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos.</param>
    ''' <param name="IDPROCESOCOMPRA">Filtro para devolver los datos.</param>
    ''' <param name="IDPROVEEDOR">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' <item><description>SAB_UACI_CONTRATOSPROCESOCOMPRA</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function DevolverProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT 	0 AS RENGLON, '' AS CORRPRODUCTO, '' AS DESCLARGO, 0 AS CANTIDADENTREGAS, '' AS NUMEROCONTRATO, '' AS NOMBRECONTRATO, '' AS NOMBREALMACEN, P.CODIGOPROVEEDOR, P.NOMBRE AS NOMBREPROVEEDOR ")
        strSQL.Append(" FROM 	SAB_CAT_PROVEEDORES P INNER JOIN ")
        strSQL.Append("        	SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON ")
        strSQL.Append(" 	P.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append(" WHERE 	CPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND CPC.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")
        strSQL.Append(" 	AND P.IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.BigInt)
        args(1).Value = IDPROCESOCOMPRA
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(2).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Obtiene el detalle de los proveedores contratados
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Filtro para devolver los datos.</param>
    ''' <param name="IDPROVEEDOR">Filtro para devolver los datos.</param>
    ''' <param name="IDCONTRATO">Filtro para devolver los datos.</param>
    ''' <returns>Dataset</returns>
    ''' <remarks>Tablas utilizadas:
    ''' <list type="bullet">
    ''' <item><description>SAB_UACI_ENTREGACONTRATO</description></item>
    ''' <item><description>SAB_UACI_PRODUCTOSCONTRATO</description></item>
    ''' <item><description>vv_CATALOGOPRODUCTOS</description></item>
    ''' </list>
    ''' </remarks>
    ''' <history>
    '''     [Henry Zavaleta]    Creado
    ''' </history>
    Public Function DetalleProveedoresContratados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("PC.PRECIOUNITARIO * PC.CANTIDAD AS MONTOENTREGA, ")
        strSQL.Append("PC.RENGLON, ")
        strSQL.Append("( ")
        strSQL.Append(" SELECT COUNT(IDDETALLE) ")
        strSQL.Append(" FROM SAB_UACI_ENTREGACONTRATO EC ")
        strSQL.Append(" WHERE EC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO AND EC.IDPROVEEDOR = PC.IDPROVEEDOR AND EC.IDCONTRATO = PC.IDCONTRATO AND EC.RENGLON = PC.RENGLON ")
        strSQL.Append(") ENTREGAS, ")
        strSQL.Append("PC.IDPRODUCTO, ")
        strSQL.Append("C.CORRPRODUCTO, ")
        strSQL.Append("C.DESCLARGO, ")
        strSQL.Append("C.DESCRIPCION, ")
        strSQL.Append("PC.CANTIDAD ")
        strSQL.Append("FROM SAB_UACI_PRODUCTOSCONTRATO PC ")
        strSQL.Append("INNER JOIN vv_CATALOGOPRODUCTOS C ")
        strSQL.Append("ON PC.IDPRODUCTO = C.IDPRODUCTO ")
        strSQL.Append("WHERE PC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND PC.IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND PC.IDCONTRATO = @IDCONTRATO ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    ''' <summary>
    ''' Devuelve la lista de proveedores filtrados por el campo REALIZADONACIONES.
    ''' </summary>
    ''' <param name="CLASIFICACION">Indica el tipo de proveedor a mostrar.</param>
    ''' <returns>Dataset con la lista de proveedores.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_PROVEEDORES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [José Alberto Chávez Loarca]  08/02/2007    Creado
    ''' </history> 
    Public Function ObtenerProveedoresClasificados(ByVal CLASIFICACION As Int16) As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append("WHERE REALIZADONACIONES = @CLASIFICACION ")
        strSQL.Append("ORDER BY NOMBRE ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@CLASIFICACION", SqlDbType.Int)
        args(0).Value = CLASIFICACION

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function DevolverProveedorPeriodo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal dsP As DataSet) As DataSet

        Dim strSQL As New Text.StringBuilder
        Dim i As Integer
        For i = 0 To dsP.Tables(0).Rows.Count - 1
            strSQL.Append(" SELECT 	0 AS RENGLON, '' AS CORRPRODUCTO, '' AS DESCLARGO, 0 AS CANTIDADENTREGAS, '' AS NUMEROCONTRATO, '' AS NOMBRECONTRATO, '' AS NOMBREALMACEN, P.CODIGOPROVEEDOR, P.NOMBRE AS NOMBREPROVEEDOR ")
            strSQL.Append(" FROM 	SAB_CAT_PROVEEDORES P INNER JOIN ")
            strSQL.Append("        	SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON ")
            strSQL.Append(" 	P.IDPROVEEDOR = CPC.IDPROVEEDOR ")
            strSQL.Append(" WHERE 	CPC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND CPC.IDPROCESOCOMPRA = " & dsP.Tables(0).Rows(i).Item(0).ToString & " ")
            strSQL.Append(" 	AND P.IDPROVEEDOR = @IDPROVEEDOR ")

            If i < dsP.Tables(0).Rows.Count - 1 Then
                strSQL.Append(" union ")
            End If
        Next

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.BigInt)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.BigInt)
        args(1).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ProveedoresConContratosDistribuidos() As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_PROVEEDORES.IDPROVEEDOR, SAB_CAT_PROVEEDORES.CODIGOPROVEEDOR, SAB_CAT_PROVEEDORES.NOMBRE, ")
        strSQL.Append(" SAB_UACI_CONTRATOS.IDESTADOCONTRATO ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOS ON SAB_CAT_PROVEEDORES.IDPROVEEDOR = SAB_UACI_CONTRATOS.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_CONTRATOS.IDESTADOCONTRATO = 3) ")
        strSQL.Append(" ORDER BY SAB_CAT_PROVEEDORES.NOMBRE ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

#End Region

#Region " Validaciones Adicionales "

    'Validar codigo Proveedores
    Public Function ValidarCodigoProveedor(ByVal CODIGOPROVEEDOR As String, ByVal IDPROVEEDOR As Int32) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append("WHERE CODIGOPROVEEDOR = @CODIGOPROVEEDOR ")
        strSQL.Append("AND (IDPROVEEDOR <> @IDPROVEEDOR OR @IDPROVEEDOR = 0) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@CODIGOPROVEEDOR", SqlDbType.VarChar)
        args(0).Value = CODIGOPROVEEDOR
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    'Validar Nombre Proveedores
    Public Function ValidarNombre(ByVal NOMBRE As String, ByVal IDPROVEEDOR As Int32) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append("WHERE NOMBRE = @NOMBRE ")
        strSQL.Append("AND (IDPROVEEDOR <> @IDPROVEEDOR OR @IDPROVEEDOR = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(0).Value = NOMBRE
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    'Validar NIT Proveedores
    Public Function ValidarNIT(ByVal NIT As String, ByVal IDPROVEEDOR As Int32) As Int16

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT count(*) ")
        strSQL.Append("FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append("WHERE NIT = @NIT ")
        strSQL.Append("AND (IDPROVEEDOR <> @IDPROVEEDOR OR @IDPROVEEDOR = 0)")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@NIT", SqlDbType.VarChar)
        args(0).Value = NIT
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaordenada(ByVal tipo As Integer) As listaPROVEEDORES

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        Select Case tipo
            Case Is = 1
                strSQL.Append(" order by CODIGOPROVEEDOR ASC ")
            Case Is = 0
                strSQL.Append(" order by CODIGOPROVEEDOR DESC ")
        End Select

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaPROVEEDORES

        Try
            Do While dr.Read()
                Dim mEntidad As New PROVEEDORES
                mEntidad.IDPROVEEDOR = IIf(dr("IDPROVEEDOR") Is DBNull.Value, Nothing, dr("IDPROVEEDOR"))
                mEntidad.CODIGOPROVEEDOR = IIf(dr("CODIGOPROVEEDOR") Is DBNull.Value, Nothing, dr("CODIGOPROVEEDOR"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DIRECCION = IIf(dr("DIRECCION") Is DBNull.Value, Nothing, dr("DIRECCION"))
                mEntidad.REPRESENTANTELEGAL = IIf(dr("REPRESENTANTELEGAL") Is DBNull.Value, Nothing, dr("REPRESENTANTELEGAL"))
                mEntidad.MATRICULA = IIf(dr("MATRICULA") Is DBNull.Value, Nothing, dr("MATRICULA"))
                mEntidad.TELEFONO = IIf(dr("TELEFONO") Is DBNull.Value, Nothing, dr("TELEFONO"))
                mEntidad.FAX = IIf(dr("FAX") Is DBNull.Value, Nothing, dr("FAX"))
                mEntidad.NIT = IIf(dr("NIT") Is DBNull.Value, Nothing, dr("NIT"))
                mEntidad.GIRO = IIf(dr("GIRO") Is DBNull.Value, Nothing, dr("GIRO"))
                mEntidad.REALIZADONACIONES = IIf(dr("REALIZADONACIONES") Is DBNull.Value, Nothing, dr("REALIZADONACIONES"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                mEntidad.CORREO = IIf(dr("CORREO") Is DBNull.Value, Nothing, dr("CORREO"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerDataSetCODIGOPROVEEDOR(ByVal IDPROVEEDOR As Int32) As System.Data.DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT IDPROVEEDOR, CODIGOPROVEEDOR AS UIDPROVEEDOR ")
        strSQL.Append("FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append("WHERE IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerUltimoCodigoProveedor() As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT CODIGOPROVEEDOR ")
        strSQL.Append("FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append("WHERE IDPROVEEDOR = (SELECT isnull(max(IDPROVEEDOR), 0) FROM SAB_CAT_PROVEEDORES) ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerULTIMOID() As String

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT isnull(max(IDPROVEEDOR),0) ")
        strSQL.Append("FROM SAB_CAT_PROVEEDORES ")
        'strSQL.Append("WHERE REALIZADONACIONES = 0 ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    'OBTENER EL CODIGO Y NOMBRE DEL PROVEEDOR A TRAVEZ DE UNA BUSQUEDA
    'Mayra 29/01/2007
    Public Function BuscarListaCodigoNombre(ByVal CRITERIO As String, ByVal TIPO As Int16) As listaPROVEEDORES

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)

        Select Case TIPO
            Case Is = 1
                strSQL.Append(" WHERE IDPROVEEDOR = " & Val(CRITERIO))
            Case Is = 2
                strSQL.Append(" WHERE CODIGOPROVEEDOR = '" & CRITERIO & "'")
            Case Is = 3
                strSQL.Append(" WHERE NOMBRE = '" & CRITERIO & "'")
        End Select

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaPROVEEDORES

        Try
            Do While dr.Read()
                Dim mEntidad As New PROVEEDORES
                mEntidad.IDPROVEEDOR = IIf(dr("IDPROVEEDOR") Is DBNull.Value, Nothing, dr("IDPROVEEDOR"))
                mEntidad.CODIGOPROVEEDOR = IIf(dr("CODIGOPROVEEDOR") Is DBNull.Value, Nothing, dr("CODIGOPROVEEDOR"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DIRECCION = IIf(dr("DIRECCION") Is DBNull.Value, Nothing, dr("DIRECCION"))
                mEntidad.REPRESENTANTELEGAL = IIf(dr("REPRESENTANTELEGAL") Is DBNull.Value, Nothing, dr("REPRESENTANTELEGAL"))
                mEntidad.MATRICULA = IIf(dr("MATRICULA") Is DBNull.Value, Nothing, dr("MATRICULA"))
                mEntidad.TELEFONO = IIf(dr("TELEFONO") Is DBNull.Value, Nothing, dr("TELEFONO"))
                mEntidad.FAX = IIf(dr("FAX") Is DBNull.Value, Nothing, dr("FAX"))
                mEntidad.NIT = IIf(dr("NIT") Is DBNull.Value, Nothing, dr("NIT"))
                mEntidad.GIRO = IIf(dr("GIRO") Is DBNull.Value, Nothing, dr("GIRO"))
                mEntidad.REALIZADONACIONES = IIf(dr("REALIZADONACIONES") Is DBNull.Value, Nothing, dr("REALIZADONACIONES"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                mEntidad.CORREO = IIf(dr("CORREO") Is DBNull.Value, Nothing, dr("CORREO"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function obtenerProveedoresContrato(ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT SAB_CAT_PROVEEDORES.IDPROVEEDOR, SAB_CAT_PROVEEDORES.NOMBRE ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_CONTRATOS.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_CONTRATOS.IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") ")
        strSQL.Append(" GROUP BY SAB_CAT_PROVEEDORES.IDPROVEEDOR, SAB_CAT_PROVEEDORES.NOMBRE, SAB_UACI_CONTRATOS.IDESTABLECIMIENTO ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerListaNombreOrdenada(ByVal tipo As Integer) As listaPROVEEDORES

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)

        Select Case tipo
            Case Is = 1
                strSQL.Append(" order by NOMBRE ASC ")
            Case Is = 0
                strSQL.Append(" order by NOMBRE DESC ")
        End Select

        Dim dr As SqlDataReader
        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Dim lista As New listaPROVEEDORES

        Try
            Do While dr.Read()
                Dim mEntidad As New PROVEEDORES
                mEntidad.IDPROVEEDOR = IIf(dr("IDPROVEEDOR") Is DBNull.Value, Nothing, dr("IDPROVEEDOR"))
                mEntidad.CODIGOPROVEEDOR = IIf(dr("CODIGOPROVEEDOR") Is DBNull.Value, Nothing, dr("CODIGOPROVEEDOR"))
                mEntidad.NOMBRE = IIf(dr("NOMBRE") Is DBNull.Value, Nothing, dr("NOMBRE"))
                mEntidad.DIRECCION = IIf(dr("DIRECCION") Is DBNull.Value, Nothing, dr("DIRECCION"))
                mEntidad.REPRESENTANTELEGAL = IIf(dr("REPRESENTANTELEGAL") Is DBNull.Value, Nothing, dr("REPRESENTANTELEGAL"))
                mEntidad.MATRICULA = IIf(dr("MATRICULA") Is DBNull.Value, Nothing, dr("MATRICULA"))
                mEntidad.TELEFONO = IIf(dr("TELEFONO") Is DBNull.Value, Nothing, dr("TELEFONO"))
                mEntidad.FAX = IIf(dr("FAX") Is DBNull.Value, Nothing, dr("FAX"))
                mEntidad.NIT = IIf(dr("NIT") Is DBNull.Value, Nothing, dr("NIT"))
                mEntidad.GIRO = IIf(dr("GIRO") Is DBNull.Value, Nothing, dr("GIRO"))
                mEntidad.REALIZADONACIONES = IIf(dr("REALIZADONACIONES") Is DBNull.Value, Nothing, dr("REALIZADONACIONES"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = dr("ESTASINCRONIZADA")
                mEntidad.CORREO = IIf(dr("CORREO") Is DBNull.Value, Nothing, dr("CORREO"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function RecuperarOrdenada() As DataSet

        Dim strSQL As New Text.StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" ORDER BY NOMBRE ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function obtenerProveedoresAdjudicadosEnAlmacen(ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT AEA.IDPROVEEDOR, P.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ")
        strSQL.Append("		LEFT OUTER JOIN	SAB_UACI_CONTRATOS C ON ")
        strSQL.Append("			AEA.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
        strSQL.Append("			AEA.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("		INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("			ON AEA.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("WHERE AEA.IDALMACEN = @IDALMACEN AND ")
        strSQL.Append("	  C.IDCONTRATO IS NULL ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerProveedoresContratoEnAlmacen(ByVal IDALMACEN As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT AEC.IDPROVEEDOR, P.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ON ")
        strSQL.Append("AEC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND ")
        strSQL.Append("AEC.IDPROVEEDOR = C.IDPROVEEDOR AND ")
        strSQL.Append("AEC.IDCONTRATO = C.IDCONTRATO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON AEC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("WHERE AEC.IDALMACENENTREGA = @IDALMACEN ")
        strSQL.Append("ORDER BY P.NOMBRE ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(0).Value = IDALMACEN

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerProveedoresContratoEstablecimiento(ByVal IDESTABLECIMIENTO As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_ALMACENESENTREGACONTRATOS AEC ")
        strSQL.Append("INNER JOIN SAB_UACI_CONTRATOS C ")
        strSQL.Append("ON AEC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO ")
        strSQL.Append("AND AEC.IDPROVEEDOR = C.IDPROVEEDOR ")
        strSQL.Append("AND AEC.IDCONTRATO = C.IDCONTRATO ")
        strSQL.Append("INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append("ON AEC.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("WHERE AEC.IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("GROUP BY ")
        strSQL.Append("AEC.IDPROVEEDOR, ")
        strSQL.Append("P.NOMBRE ")
        strSQL.Append("ORDER BY P.NOMBRE ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerModalidadesCompraEnAlmacen(ByVal IDALMACEN As Integer, ByVal IDPROVEEDOR As Integer) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append(" SELECT DISTINCT PC.IDPROCESOCOMPRA, A.IDPROVEEDOR, A.IDESTABLECIMIENTO, MP.DESCRIPCION, PC.CODIGOLICITACION, E.NOMBRE ")
        strSQL.Append("FROM SAB_UACI_PROCESOCOMPRAS PC ")
        strSQL.Append("	INNER JOIN SAB_UACI_ADJUDICACION A ON ")
        strSQL.Append("		A.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA AND ")
        strSQL.Append("		A.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("	INNER JOIN SAB_UACI_ALMACENESENTREGAADJUDICACION AEA ON ")
        strSQL.Append("		AEA.IDESTABLECIMIENTO = A.IDESTABLECIMIENTO AND ")
        strSQL.Append("		AEA.IDPROCESOCOMPRA = A.IDPROCESOCOMPRA AND ")
        strSQL.Append("		AEA.IDPROVEEDOR = A.IDPROVEEDOR AND ")
        strSQL.Append("		AEA.IDDETALLE = A.IDDETALLE ")
        strSQL.Append("    LEFT OUTER JOIN SAB_UACI_CONTRATOS C ON ")
        strSQL.Append("		C.IDESTABLECIMIENTO = AEA.IDESTABLECIMIENTO AND ")
        strSQL.Append("		C.IDPROVEEDOR = AEA.IDPROVEEDOR ")
        strSQL.Append("	INNER JOIN SAB_CAT_TIPOCOMPRAS TP ON ")
        strSQL.Append("		TP.IDTIPOCOMPRA = PC.IDTIPOCOMPRAEJECUTAR ")
        strSQL.Append("	INNER JOIN SAB_CAT_MODALIDADESCOMPRA MP ON ")
        strSQL.Append("		MP.IDMODALIDADCOMPRA = TP.IDMODALIDADCOMPRA ")
        strSQL.Append("	INNER JOIN SAB_CAT_ESTABLECIMIENTOS E ON ")
        strSQL.Append("		E.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO ")
        strSQL.Append("WHERE	A.CANTIDADFIRME <> 0 AND ")
        strSQL.Append("		AEA.IDPROVEEDOR = @IDPROVEEDOR AND ")
        strSQL.Append("		AEA.IDALMACEN = @IDALMACEN AND ")
        strSQL.Append("		C.IDCONTRATO IS NULL ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = IDPROVEEDOR
        args(1) = New SqlParameter("@IDALMACEN", SqlDbType.Int)
        args(1).Value = IDALMACEN

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerProveedoresAdj(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal Notificados As Boolean, Optional ByVal IDINSPECTOR As Integer = 0) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT A.IDPROVEEDOR, P.NOMBRE, isnull(C.NUMEROCONTRATO,'Pendiente') as NUMEROCONTRATO, ISNULL(C.IDCONTRATO,0) AS IDCONTRATO, A.IDESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("	INNER JOIN SAB_CAT_PROVEEDORES P ON ")
        strSQL.Append("		A.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("	LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON ")
        strSQL.Append("		A.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append("		A.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA AND ")
        strSQL.Append("		A.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("	LEFT OUTER JOIN SAB_UACI_CONTRATOS C ON ")
        strSQL.Append("		C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append("		C.IDPROVEEDOR = CPC.IDPROVEEDOR AND ")
        strSQL.Append("		C.IDCONTRATO = CPC.IDCONTRATO ")

        If Notificados = True Or IDINSPECTOR <> 0 Then
            strSQL.Append(" INNER JOIN SAB_LAB_INFORMEMUESTRAS IM ON ")
            strSQL.Append(" P.IDPROVEEDOR = IM.IDPROVEEDOR AND")
            strSQL.Append(" CPC.IDESTABLECIMIENTO = IM.IDESTABLECIMIENTOCONTRATO ")
        End If

        strSQL.Append("WHERE A.CANTIDADFIRME > 0 AND ")
        strSQL.Append("	  A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("	  A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        If Notificados = True Then
            strSQL.Append(" AND IM.NUMEROINFORME IS NULL ")
        End If
        If IDINSPECTOR <> 0 Then
            strSQL.Append(" AND IM.IDINSPECTOR = @IDINSPECTOR ")
        End If
        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO
        If IDINSPECTOR <> 0 Then
            args(2) = New SqlParameter("@IDINSPECTOR", SqlDbType.Int)
            args(2).Value = IDINSPECTOR
        End If

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function obtenerProveedoresCertificados(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal Notificados As Boolean) As DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT DISTINCT A.IDPROVEEDOR, P.NOMBRE, isnull(C.NUMEROCONTRATO,'Pendiente') as NUMEROCONTRATO, ISNULL(C.IDCONTRATO,0) AS IDCONTRATO, A.IDESTABLECIMIENTO ")
        strSQL.Append("FROM SAB_UACI_ADJUDICACION A ")
        strSQL.Append("	INNER JOIN SAB_CAT_PROVEEDORES P ON ")
        strSQL.Append("		A.IDPROVEEDOR = P.IDPROVEEDOR ")
        strSQL.Append("	LEFT OUTER JOIN SAB_UACI_CONTRATOSPROCESOCOMPRA CPC ON ")
        strSQL.Append("		A.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append("		A.IDPROCESOCOMPRA = CPC.IDPROCESOCOMPRA AND ")
        strSQL.Append("		A.IDPROVEEDOR = CPC.IDPROVEEDOR ")
        strSQL.Append("	LEFT OUTER JOIN SAB_UACI_CONTRATOS C ON ")
        strSQL.Append("		C.IDESTABLECIMIENTO = CPC.IDESTABLECIMIENTO AND ")
        strSQL.Append("		C.IDPROVEEDOR = CPC.IDPROVEEDOR AND ")
        strSQL.Append("		C.IDCONTRATO = CPC.IDCONTRATO ")

        If Notificados = True Then
            strSQL.Append(" INNER JOIN SAB_LAB_INFORMEMUESTRAS IM ON ")
            strSQL.Append(" P.IDPROVEEDOR = IM.IDPROVEEDOR AND")
            strSQL.Append(" CPC.IDESTABLECIMIENTO = IM.IDESTABLECIMIENTOCONTRATO ")
        End If

        strSQL.Append("WHERE A.CANTIDADFIRME > 0 AND ")
        strSQL.Append("	  A.IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND ")
        strSQL.Append("	  A.IDPROCESOCOMPRA = @IDPROCESOCOMPRA ")

        If Notificados = True Then
            strSQL.Append(" AND IM.IDESTADO = 6 ")
        End If

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESOCOMPRA", SqlDbType.Int)
        args(0).Value = IDPROCESOCOMPRA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = IDESTABLECIMIENTO

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
