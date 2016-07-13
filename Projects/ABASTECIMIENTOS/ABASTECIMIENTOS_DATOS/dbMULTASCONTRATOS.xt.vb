Imports System.Text

Partial Public Class dbMULTASCONTRATOS

#Region "Metodos agregados"

    Public Function obtenerPlantilla(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Integer, ByVal TIPO As Integer) As StringBuilder

        Dim strSQL As New Text.StringBuilder
        Dim strSQL1 As New Text.StringBuilder
        strSQL.Append(" SELECT CONTENIDO ")
        strSQL.Append(" FROM SAB_UACI_PLANTILLASMULTAS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPLANTILLA = " & IDPLANTILLA & ") AND (TIPOPLANTILLA = " & TIPO & ")")

        strSQL1.Append(CStr(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())))

        Return strSQL1

    End Function

    Public Function obtenerPlantilla(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer) As StringBuilder

        Dim strSQL As New Text.StringBuilder
        Dim strSQL1 As New Text.StringBuilder
        strSQL.Append(" SELECT isnull(CONTENIDO,'') as conte ")
        strSQL.Append(" FROM SAB_UACI_MULTASCONTRATOS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = " & IDESTABLECIMIENTO & ") AND (IDPROVEEDOR = " & IDPROVEEDOR & ") AND (IDCONTRATO = " & IDCONTRATO & ") AND (IDMULTA = " & IDMULTA & ")")

        strSQL1.Append(CStr(SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())))

        Return strSQL1

    End Function

    Public Function ObtenerIncumplimientosAtraso(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDNOTA As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA, RENGLON, PRECIOUNITARIO, CANTIDADCONTRATADA, CANTIDADENTREGADAATRASO, ")
        strSQL.Append(" FECHAENTREGAPROGRAMADA, FECHAENTREGAREAL, MONTOATRASO, DIASATRASO, PORCENTAJEINCLUMPLIMIENTO, ENTREGA, ")
        strSQL.Append(" TIPOINCUMPLIMIENTO ")
        strSQL.Append(" FROM SAB_UACI_DETALLENOTAINCUMPLIMIENTOCONTRATO ")
        strSQL.Append(" WHERE (TIPOINCUMPLIMIENTO = 0) AND (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND (IDCONTRATO = @IDCONTRATO) AND (IDNOTA = @IDNOTA) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDNOTA", SqlDbType.Int)
        args(3).Value = IDNOTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerMultasAtrasoDS(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDMULTA, IDDETALLE, RENGLON, PRECIOUNITARIO, CANTIDADCONTRATADA, CANTIDADENTREGAATRASO, FECHAENTREGAPROGRAMADA, ")
        strSQL.Append(" FECHAENTREGAREAL, DIASATRASO, MONTOINCUMPLIDO as MONTOATRASO, PORCENTAJECALCULO as PORCENTAJEINCLUMPLIMIENTO, ENTREGA, TIPOINCUMPLIMIENTO")
        strSQL.Append(" FROM SAB_UACI_DETALLEMULTASCONTRATOS ")
        strSQL.Append(" WHERE (TIPOINCUMPLIMIENTO = 0) AND (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND ")
        strSQL.Append(" (IDCONTRATO = @IDCONTRATO) AND (IDMULTA = @IDMULTA) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.Int)
        args(3).Value = IDMULTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerMultasAtraso(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDMULTA, IDDETALLE, RENGLON, PRECIOUNITARIO, CANTIDADCONTRATADA, CANTIDADENTREGAATRASO, FECHAENTREGAPROGRAMADA, ")
        strSQL.Append(" FECHAENTREGAREAL, DIASATRASO, MONTOINCUMPLIDO, PORCENTAJECALCULO, ENTREGA, TIPOINCUMPLIMIENTO")
        strSQL.Append(" FROM SAB_UACI_DETALLEMULTASCONTRATOS ")
        strSQL.Append(" WHERE (TIPOINCUMPLIMIENTO = 0) AND (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND ")
        strSQL.Append(" (IDCONTRATO = @IDCONTRATO) AND (IDMULTA = @IDMULTA) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.Int)
        args(3).Value = IDMULTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerIncumplimientosNoEntregado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDNOTA As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDNOTA, RENGLON, PRECIOUNITARIO, CANTIDADCONTRATADA, CANTIDADENTREGADAATRASO, ")
        strSQL.Append(" FECHAENTREGAPROGRAMADA, FECHAENTREGAREAL, MONTOATRASO, DIASATRASO, PORCENTAJEINCLUMPLIMIENTO, ENTREGA, ")
        strSQL.Append(" TIPOINCUMPLIMIENTO ")
        strSQL.Append(" FROM SAB_UACI_DETALLENOTAINCUMPLIMIENTOCONTRATO ")
        strSQL.Append(" WHERE (TIPOINCUMPLIMIENTO = 1) AND (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND (IDCONTRATO = @IDCONTRATO) AND (IDNOTA = @IDNOTA) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDNOTA", SqlDbType.Int)
        args(3).Value = IDNOTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerMultasNoEntregadoDS(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDMULTA, IDDETALLE, RENGLON, PRECIOUNITARIO, CANTIDADCONTRATADA, CANTIDADENTREGAATRASO, FECHAENTREGAPROGRAMADA, ")
        strSQL.Append(" FECHAENTREGAREAL, DIASATRASO, MONTOINCUMPLIDO as MONTOATRASO, PORCENTAJECALCULO as PORCENTAJEINCLUMPLIMIENTO, ENTREGA, TIPOINCUMPLIMIENTO")
        strSQL.Append(" FROM SAB_UACI_DETALLEMULTASCONTRATOS ")
        strSQL.Append(" WHERE (TIPOINCUMPLIMIENTO = 1) AND (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND ")
        strSQL.Append(" (IDCONTRATO = @IDCONTRATO) AND (IDMULTA = @IDMULTA) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.Int)
        args(3).Value = IDMULTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerMultasNoEntregado(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDMULTA, IDDETALLE, RENGLON, PRECIOUNITARIO, CANTIDADCONTRATADA, CANTIDADENTREGAATRASO, FECHAENTREGAPROGRAMADA, ")
        strSQL.Append(" FECHAENTREGAREAL, DIASATRASO, MONTOINCUMPLIDO, PORCENTAJECALCULO, ENTREGA, TIPOINCUMPLIMIENTO")
        strSQL.Append(" FROM SAB_UACI_DETALLEMULTASCONTRATOS ")
        strSQL.Append(" WHERE (TIPOINCUMPLIMIENTO = 1) AND (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND ")
        strSQL.Append(" (IDCONTRATO = @IDCONTRATO) AND (IDMULTA = @IDMULTA) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.Int)
        args(3).Value = IDMULTA

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function guardarPlantilla(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPLANTILLA As Integer, ByVal NOMBRE As String, ByVal CONTENIDO As String, ByVal TIPOPLANTILLA As Integer) As Integer

        If IDPLANTILLA = 0 Then
            Dim ID As Integer

            Dim strSQL As New StringBuilder
            strSQL.Append(" SELECT MAX(IDPLANTILLA) AS IDP FROM SAB_UACI_PLANTILLASMULTAS ")
            strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO")

            ID = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
            strSQL = Nothing

            strSQL.Append(" INSERT INTO SAB_UACI_PLANTILLASMULTAS ")
            strSQL.Append(" (IDESTABLECIMIENTO, IDPLANTILLA,  NOMBRE, CONTENIDO TIPOPLANTILLA) ")
            strSQL.Append(" VALUES     (@IDESTABLECIMIENTO, @IDPLANTILLA, @NOMBRE ,@CONTENIDO  , @TIPOPLANTILLA) ")

            Dim args(4) As SqlParameter
            args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
            args(0).Value = IDESTABLECIMIENTO
            args(1) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
            args(1).Value = ID
            args(2) = New SqlParameter("@CONTENIDO", SqlDbType.VarChar)
            args(2).Value = CONTENIDO
            args(3) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
            args(3).Value = NOMBRE
            args(4) = New SqlParameter("@TIPOPLANTILLA", SqlDbType.Int)
            args(4).Value = IDPLANTILLA

            Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Else
            Dim strSQL As New StringBuilder
            strSQL.Append(" UPDATE SAB_UACI_PLANTILLASMULTAS ")
            strSQL.Append(" SET  CONTENIDO = @CONTENIDO ")
            strSQL.Append(" WHERE ( IDESTABLECIMIENTO = @IDESTABLECIMIENTO AND  IDPLANTILLA = @IDPLANTILLA)")

            Dim args(4) As SqlParameter
            args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
            args(0).Value = IDESTABLECIMIENTO
            args(1) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
            args(1).Value = IDPLANTILLA
            args(2) = New SqlParameter("@CONTENIDO", SqlDbType.VarChar)
            args(2).Value = CONTENIDO
            args(3) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
            args(3).Value = NOMBRE
            args(4) = New SqlParameter("@TIPOPLANTILLA", SqlDbType.Int)
            args(4).Value = IDPLANTILLA

            Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        End If

    End Function

    Public Function ObtenerDatosAudiencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT C.IDESTABLECIMIENTO, C.IDPROVEEDOR, C.IDCONTRATO, CP.NOMBRE AS PROVEEDOR, C.NUMEROCONTRATO AS CONTRATO, ")
        strSQL.Append(" PC.CODIGOLICITACION AS NUMEROPROCESO, PC.TITULOLICITACION AS NOMBREPROCESO, C.MONTOCONTRATO, CONVERT(VARCHAR(10),C.FECHADISTRIBUCION,103) AS FECHADISTRIBUCION, ")
        strSQL.Append(" NIC.NUMEROINFORME, SUM(DNIC.MONTOATRASO) AS MONTOINCUMPLIDO ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOSPROCESOCOMPRA AS CPC INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOS AS C ON CPC.IDESTABLECIMIENTO = C.IDESTABLECIMIENTO AND CPC.IDPROVEEDOR = C.IDPROVEEDOR AND ")
        strSQL.Append(" CPC.IDCONTRATO = C.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO AS NIC ON C.IDESTABLECIMIENTO = NIC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" C.IDPROVEEDOR = NIC.IDPROVEEDOR AND C.IDCONTRATO = NIC.IDCONTRATO INNER JOIN ")
        strSQL.Append(" SAB_UACI_PROCESOCOMPRAS AS PC ON CPC.IDPROCESOCOMPRA = PC.IDPROCESOCOMPRA AND ")
        strSQL.Append(" CPC.IDESTABLECIMIENTO = PC.IDESTABLECIMIENTO INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES AS CP ON C.IDPROVEEDOR = CP.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_DETALLENOTAINCUMPLIMIENTOCONTRATO AS DNIC ON NIC.IDESTABLECIMIENTO = DNIC.IDESTABLECIMIENTO AND ")
        strSQL.Append(" NIC.IDPROVEEDOR = DNIC.IDPROVEEDOR And NIC.IDCONTRATO = DNIC.IDCONTRATO And NIC.IDNOTA = DNIC.IDNOTA ")
        strSQL.Append(" GROUP BY C.IDESTABLECIMIENTO, C.IDPROVEEDOR, C.IDCONTRATO, CP.NOMBRE, C.NUMEROCONTRATO, PC.CODIGOLICITACION, PC.TITULOLICITACION, ")
        strSQL.Append(" C.MONTOCONTRATO, C.FECHADISTRIBUCION, NIC.NUMEROINFORME ")
        strSQL.Append(" HAVING (C.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (C.IDPROVEEDOR = 104) AND (C.IDCONTRATO = 1) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function obtenerInformesIncumplimiento(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDNOTA, NUMEROINFORME, FECHAENTREGA, TITULONOTA ")
        strSQL.Append(" FROM SAB_UACI_NOTASINCUMPLIMIENTOCONTRATO AS NIC ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND (IDCONTRATO = @IDCONTRATO) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function obtenerAudiencias(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDMULTA, FECHAMULTA, NUMEROMULTA, NUMEROINFORMESEGUIMIENTO as IDNOTA ")
        strSQL.Append(" FROM SAB_UACI_MULTASCONTRATOS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND (IDCONTRATO = @IDCONTRATO) AND (TIPODOCUMENTO = 0) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Sub copiarRenglonesAudiencia(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer, ByVal IDNOTA As Integer)

        Dim strSQL As New StringBuilder
        strSQL.Append(" INSERT INTO SAB_UACI_DETALLEMULTASCONTRATOS ")
        strSQL.Append(" (IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, PRECIOUNITARIO, CANTIDADCONTRATADA, CANTIDADENTREGAATRASO, ")
        strSQL.Append(" FECHAENTREGAPROGRAMADA, FECHAENTREGAREAL, MONTOINCUMPLIDO, DIASATRASO, PORCENTAJECALCULO, ENTREGA, ")
        strSQL.Append(" TIPOINCUMPLIMIENTO, IDMULTA) ")
        strSQL.Append(" SELECT IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, PRECIOUNITARIO, CANTIDADCONTRATADA, CANTIDADENTREGADAATRASO, ")
        strSQL.Append(" FECHAENTREGAPROGRAMADA, FECHAENTREGAREAL, MONTOATRASO, DIASATRASO, PORCENTAJEINCLUMPLIMIENTO, ENTREGA, ")
        strSQL.Append(" 0 AS TIPOINCUMPLIMIENTO, @IDMULTA AS IDMULTA ")
        strSQL.Append(" FROM SAB_UACI_DETALLENOTAINCUMPLIMIENTOCONTRATO ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND (IDCONTRATO = @IDCONTRATO) AND (IDNOTA = @IDNOTA) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.Int)
        args(3).Value = IDMULTA
        args(4) = New SqlParameter("@IDNOTA", SqlDbType.Int)
        args(4).Value = IDNOTA

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Sub

    Public Function obtenerId2(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT ISNULL(MAX(IDMULTA), 0) + 1 AS idmulta ")
        strSQL.Append(" FROM SAB_UACI_MULTASCONTRATOS")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND (IDCONTRATO = @IDCONTRATO) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function encabezadoAudiencia_Multa(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDNOTA As String, ByVal IDPLANTILLA As Integer, ByVal TIPODOCUMENTO As Integer) As Integer

        Dim strSQL As New StringBuilder
        Dim multa As Integer
        Dim ok As Integer
        strSQL.Append(" SELECT ISNULL(IDMULTA,0) AS A ")
        strSQL.Append(" FROM SAB_UACI_MULTASCONTRATOS ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND (IDCONTRATO = @IDCONTRATO) AND (NUMEROINFORMESEGUIMIENTO = @NUMEROINFORMESEGUIMIENTO) AND (TIPODOCUMENTO = @TIPODOCUMENTO)")

        Dim args0(4) As SqlParameter
        args0(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args0(0).Value = IDESTABLECIMIENTO
        args0(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args0(1).Value = IDPROVEEDOR
        args0(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args0(2).Value = IDCONTRATO
        args0(3) = New SqlParameter("@NUMEROINFORMESEGUIMIENTO", SqlDbType.VarChar)
        args0(3).Value = IDNOTA
        args0(4) = New SqlParameter("@TIPODOCUMENTO", SqlDbType.Int)
        args0(4).Value = TIPODOCUMENTO

        ok = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args0)

        Dim strSQL1 As New StringBuilder

        If ok = 0 Then
            multa = obtenerId2(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

            strSQL1.Append(" INSERT INTO SAB_UACI_MULTASCONTRATOS ")
            strSQL1.Append(" (IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, IDMULTA, IDPLANTILLA, FECHAMULTA, NUMEROINFORMESEGUIMIENTO, TIPODOCUMENTO) ")
            strSQL1.Append(" VALUES     (@IDESTABLECIMIENTO,@IDPROVEEDOR, @IDCONTRATO, @IDMULTA, 1, GETDATE(), @NUMEROINFORMESEGUIMIENTO , @TIPO  ) ")

            Dim args(5) As SqlParameter
            args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
            args(0).Value = IDESTABLECIMIENTO
            args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
            args(1).Value = IDPROVEEDOR
            args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
            args(2).Value = IDCONTRATO
            args(3) = New SqlParameter("@IDMULTA", SqlDbType.Int)
            args(3).Value = multa
            args(4) = New SqlParameter("@NUMEROINFORMESEGUIMIENTO", SqlDbType.VarChar)
            args(4).Value = IDNOTA
            args(5) = New SqlParameter("@TIPO", SqlDbType.Int)
            args(5).Value = TIPODOCUMENTO

            SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL1.ToString(), args)
            Return multa
        Else
            Return ok
        End If

    End Function

    Public Function prefijoArchivo(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer) As String

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT SAB_UACI_CONTRATOS.NUMEROCONTRATO + '_' + SAB_CAT_PROVEEDORES.NOMBRE AS Expr1 ")
        strSQL.Append(" FROM SAB_UACI_MULTASCONTRATOS INNER JOIN ")
        strSQL.Append(" SAB_CAT_PROVEEDORES ON SAB_UACI_MULTASCONTRATOS.IDPROVEEDOR = SAB_CAT_PROVEEDORES.IDPROVEEDOR INNER JOIN ")
        strSQL.Append(" SAB_UACI_CONTRATOS ON SAB_UACI_MULTASCONTRATOS.IDESTABLECIMIENTO = SAB_UACI_CONTRATOS.IDESTABLECIMIENTO AND ")
        strSQL.Append(" SAB_UACI_MULTASCONTRATOS.IDPROVEEDOR = SAB_UACI_CONTRATOS.IDPROVEEDOR AND ")
        strSQL.Append(" SAB_UACI_MULTASCONTRATOS.IDCONTRATO = SAB_UACI_CONTRATOS.IDCONTRATO AND ")
        strSQL.Append(" SAB_CAT_PROVEEDORES.IDPROVEEDOR = SAB_UACI_CONTRATOS.IDPROVEEDOR ")
        strSQL.Append(" WHERE (SAB_UACI_MULTASCONTRATOS.IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (SAB_UACI_MULTASCONTRATOS.IDPROVEEDOR = @IDPROVEEDOR) AND ")
        strSQL.Append(" (SAB_UACI_MULTASCONTRATOS.IDCONTRATO = @IDCONTRATO) AND (SAB_UACI_MULTASCONTRATOS.IDMULTA = @IDMULTA) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.Int)
        args(3).Value = IDMULTA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function modificarDetalle(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDMULTA As Integer, ByVal IDDETALLE As Integer, ByVal CANTIDAD As Integer, ByVal DIAS As Integer, ByVal JUSTIFICACION As String) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_DETALLEMULTASCONTRATOS ")
        strSQL.Append(" SET CANTIDADATRASO = @CANTIDAD, DIASATRASO = @DIAS, JUSTIFICACION = @JUSTIFICACION ")
        strSQL.Append(" WHERE (IDESTABLECIMIENTO = @IDESTABLECIMIENTO) AND (IDPROVEEDOR = @IDPROVEEDOR) AND (IDCONTRATO = @IDCONTRATO)")
        strSQL.Append(" AND (IDMULTA = @IDMULTA) AND (IDDETALLE = @IDDETALLE)")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.Int)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDMULTA", SqlDbType.Int)
        args(3).Value = IDMULTA
        args(4) = New SqlParameter("@IDDETALLE", SqlDbType.Int)
        args(4).Value = IDDETALLE
        args(5) = New SqlParameter("@CANTIDAD", SqlDbType.Int)
        args(5).Value = CANTIDAD
        args(6) = New SqlParameter("@DIAS", SqlDbType.Int)
        args(6).Value = DIAS
        args(7) = New SqlParameter("@JUSTIFICACION", SqlDbType.VarChar)
        args(7).Value = JUSTIFICACION

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

#End Region

End Class
