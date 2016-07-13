Imports System.Text
Public Class dbREGISTROGARANTIASCG
    Inherits dbBase

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
        Dim lEntidad As REGISTROGARANTIAS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDGARANTIA = 0 _
            Or lEntidad.IDGARANTIA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDGARANTIA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CG_REGISTROGARANTIAS ")
        strSQL.Append(" SET IDPROVEEDOR= @IDPROVEEDOR, IDTIPODOCUMENTO= @IDTIPODOCUMENTO, IDMODALIDADCOMPRA=@IDMODALIDADCOMPRA, NUMPROCESO=@NUMPROCESO, NUMCONTRATO=@NUMCONTRATO, FECHADISTRIBUCION=@FECHADISTRIBUCION, IDENTIDAD=@IDENTIDAD, NUMGARANTIA=@NUMGARANTIA, MONTO=@MONTO, FECHAEMISION=@FECHAEMISION, TOTALDIAS=@TOTALDIAS, FECHAVTO=@FECHAVTO, FECHASOLDEVGTIA=@FECHASOLDEVGTIA, FECHARESFIRME=@FECHARESFIRME, FECHADEVGTIA=@FECHADEVGTIA, FECHAEFEGTIA=@FECHAEFEGTIA, FECHAAPRPLANUTIANT=@FECHAAPRPLANUTIANT, FECHAUTIPLANAVFI=@FECHAUTIPLANAVFI, FECHAACEPGTIACUMCON=@FECHAACEPGTIACUMCON, FECHAACEPGTIA=@FECHAACEPGTIA, FECHAENVIOUFI=@FECHAENVIOUFI, FECHARECUFI=@FECHARECUFI, FECHAEJEANT=@FECHAEJEANT, FECHAACGTIABVEOB=@FECHAACGTIABVEOB, FECHAACEPFIABUECAL=@FECHAACEPFIABUECAL, FECHAACTAREL=@FECHAACTAREL, FECHALIQUIDACION=@FECHALIQUIDACION, FECHARECBOS=@FECHARECBOS, IDCAUSAL=@IDCAUSAL, OBSERVACIONES=@OBSERVACIONES, USUARIO=@USUARIO, FECHA=@FECHA, VALORCUANTIA=@VALORCUANTIA ")
        strSQL.Append(" WHERE IDGARANTIA = @IDGARANTIA AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")

        Dim args(35) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROVEEDOR
        args(1) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPODOCUMENTO
        args(2) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.Int)
        args(2).Value = lEntidad.IDMODALIDADCOMPRA
        args(3) = New SqlParameter("@NUMPROCESO", SqlDbType.VarChar)
        args(3).Value = lEntidad.NUMPROCESO
        args(4) = New SqlParameter("@NUMCONTRATO", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.NUMCONTRATO = Nothing, DBNull.Value, lEntidad.NUMCONTRATO)
        args(5) = New SqlParameter("@FECHADISTRIBUCION", SqlDbType.DateTime)
        args(5).Value = IIf(lEntidad.FECHADISTRIBUCION = Nothing, DBNull.Value, lEntidad.FECHADISTRIBUCION)
        args(6) = New SqlParameter("@IDENTIDAD", SqlDbType.Int)
        args(6).Value = lEntidad.IDENTIDAD
        args(7) = New SqlParameter("@NUMGARANTIA", SqlDbType.VarChar)
        args(7).Value = lEntidad.NUMGARANTIA
        args(8) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args(8).Value = lEntidad.MONTO
        args(9) = New SqlParameter("@FECHAEMISION", SqlDbType.DateTime)
        args(9).Value = CDate(lEntidad.FECHAEMISION & " 12:00:00 AM ")
        args(10) = New SqlParameter("@TOTALDIAS", SqlDbType.Int)
        args(10).Value = lEntidad.TOTALDIAS
        args(11) = New SqlParameter("@FECHAVTO", SqlDbType.DateTime)
        args(11).Value = CDate(lEntidad.FECHAVTO & " 12:00:00 AM ")
        args(12) = New SqlParameter("@FECHASOLDEVGTIA", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.FECHASOLDEVGTIA = Nothing, DBNull.Value, lEntidad.FECHASOLDEVGTIA)
        args(13) = New SqlParameter("@FECHARESFIRME", SqlDbType.DateTime)
        args(13).Value = IIf(lEntidad.FECHARESFIRME = Nothing, DBNull.Value, lEntidad.FECHARESFIRME)
        args(14) = New SqlParameter("@FECHADEVGTIA", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.FECHADEVGTIA = Nothing, DBNull.Value, lEntidad.FECHADEVGTIA)
        args(15) = New SqlParameter("@FECHAEFEGTIA", SqlDbType.DateTime)
        args(15).Value = IIf(lEntidad.FECHAEFEGTIA = Nothing, DBNull.Value, lEntidad.FECHAEFEGTIA)
        args(16) = New SqlParameter("@FECHAAPRPLANUTIANT", SqlDbType.DateTime)
        args(16).Value = IIf(lEntidad.FECHAAPRPLANUTIANT = Nothing, DBNull.Value, lEntidad.FECHAAPRPLANUTIANT)
        args(17) = New SqlParameter("@FECHAUTIPLANAVFI", SqlDbType.DateTime)
        args(17).Value = IIf(lEntidad.FECHAUTIPLANAVFI = Nothing, DBNull.Value, lEntidad.FECHAUTIPLANAVFI)
        args(18) = New SqlParameter("@FECHAACEPGTIACUMCON", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.FECHAACEPGTIACUMCON = Nothing, DBNull.Value, lEntidad.FECHAACEPGTIACUMCON)
        args(19) = New SqlParameter("@FECHAACEPGTIA", SqlDbType.DateTime)
        args(19).Value = IIf(lEntidad.FECHAACEPGTIA = Nothing, DBNull.Value, lEntidad.FECHAACEPGTIA)
        args(20) = New SqlParameter("@FECHAENVIOUFI", SqlDbType.DateTime)
        args(20).Value = IIf(lEntidad.FECHAENVIOUFI = Nothing, DBNull.Value, lEntidad.FECHAENVIOUFI)
        args(21) = New SqlParameter("@FECHARECUFI", SqlDbType.DateTime)
        args(21).Value = IIf(lEntidad.FECHARECUFI = Nothing, DBNull.Value, lEntidad.FECHARECUFI)
        args(22) = New SqlParameter("@FECHAEJEANT", SqlDbType.DateTime)
        args(22).Value = IIf(lEntidad.FECHAEJEANT = Nothing, DBNull.Value, lEntidad.FECHAEJEANT)
        args(23) = New SqlParameter("@FECHAACGTIABVEOB", SqlDbType.DateTime)
        args(23).Value = IIf(lEntidad.FECHAACGTIABVEOB = Nothing, DBNull.Value, lEntidad.FECHAACGTIABVEOB)
        args(24) = New SqlParameter("@FECHAACEPFIABUECAL", SqlDbType.DateTime)
        args(24).Value = IIf(lEntidad.FECHAACEPFIABUECAL = Nothing, DBNull.Value, lEntidad.FECHAACEPFIABUECAL)
        args(25) = New SqlParameter("@FECHAACTAREL", SqlDbType.DateTime)
        args(25).Value = IIf(lEntidad.FECHAACTAREL = Nothing, DBNull.Value, lEntidad.FECHAACTAREL)
        args(26) = New SqlParameter("@FECHALIQUIDACION", SqlDbType.DateTime)
        args(26).Value = IIf(lEntidad.FECHALIQUIDACION = Nothing, DBNull.Value, lEntidad.FECHALIQUIDACION)
        args(27) = New SqlParameter("@FECHARECBOS", SqlDbType.DateTime)
        args(27).Value = IIf(lEntidad.FECHARECBOS = Nothing, DBNull.Value, lEntidad.FECHARECBOS)
        args(28) = New SqlParameter("@IDCAUSAL", SqlDbType.Int)
        args(28).Value = IIf(lEntidad.IDCAUSAL = Nothing, DBNull.Value, lEntidad.IDCAUSAL)
        args(29) = New SqlParameter("@OBSERVACIONES", SqlDbType.VarChar)
        args(29).Value = IIf(lEntidad.OBSERVACIONES = Nothing, DBNull.Value, lEntidad.OBSERVACIONES)
        args(30) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(30).Value = lEntidad.USUARIO
        args(31) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(31).Value = lEntidad.FECHA
        args(32) = New SqlParameter("@VALORCUANTIA", SqlDbType.Decimal)
        args(32).Value = IIf(lEntidad.VALORCUANTIA = Nothing, DBNull.Value, lEntidad.VALORCUANTIA)
        args(33) = New SqlParameter("@IDGARANTIA", SqlDbType.Int)
        args(33).Value = lEntidad.IDGARANTIA
        args(34) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(34).Value = lEntidad.IDESTABLECIMIENTO
        args(35) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.Int)
        args(35).Value = lEntidad.IDTIPOGARANTIA
        Dim ret As Integer
        ret = SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Return ret

    End Function
    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As REGISTROGARANTIAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CG_REGISTROGARANTIAS ")
        strSQL.Append(" VALUES (@IDGARANTIA,@IDESTABLECIMIENTO,@IDTIPOGARANTIA,@IDPROVEEDOR, @IDTIPODOCUMENTO, @IDMODALIDADCOMPRA, @NUMPROCESO, @NUMCONTRATO, @FECHADISTRIBUCION, @IDENTIDAD, @NUMGARANTIA, @MONTO, @FECHAEMISION, @TOTALDIAS, @FECHAVTO, @FECHASOLDEVGTIA, @FECHARESFIRME, @FECHADEVGTIA, @FECHAEFEGTIA, @FECHAAPRPLANUTIANT, @FECHAUTIPLANAVFI, @FECHAACEPGTIACUMCON, @FECHAACEPGTIA, @FECHAENVIOUFI, @FECHARECUFI, @FECHAEJEANT, @FECHAACGTIABVEOB, @FECHAACEPFIABUECAL, @FECHAACTAREL, @FECHALIQUIDACION, @FECHARECBOS,NULL, @IDCAUSAL, @OBSERVACIONES, @VALORCUANTIA,@USUARIO, @FECHA) ")

        Dim args(35) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROVEEDOR
        args(1) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPODOCUMENTO
        args(2) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.Int)
        args(2).Value = lEntidad.IDMODALIDADCOMPRA
        args(3) = New SqlParameter("@NUMPROCESO", SqlDbType.VarChar)
        args(3).Value = lEntidad.NUMPROCESO
        args(4) = New SqlParameter("@NUMCONTRATO", SqlDbType.VarChar)
        args(4).Value = IIf(lEntidad.NUMCONTRATO = Nothing, DBNull.Value, lEntidad.NUMCONTRATO)
        args(5) = New SqlParameter("@FECHADISTRIBUCION", SqlDbType.DateTime)
        args(5).Value = IIf(lEntidad.FECHADISTRIBUCION = Nothing, DBNull.Value, lEntidad.FECHADISTRIBUCION)
        args(6) = New SqlParameter("@IDENTIDAD", SqlDbType.Int)
        args(6).Value = lEntidad.IDENTIDAD
        args(7) = New SqlParameter("@NUMGARANTIA", SqlDbType.VarChar)
        args(7).Value = lEntidad.NUMGARANTIA
        args(8) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args(8).Value = lEntidad.MONTO
        args(9) = New SqlParameter("@FECHAEMISION", SqlDbType.DateTime)
        args(9).Value = CDate(lEntidad.FECHAEMISION & " 12:00:00 AM ")
        args(10) = New SqlParameter("@TOTALDIAS", SqlDbType.Int)
        args(10).Value = lEntidad.TOTALDIAS
        args(11) = New SqlParameter("@FECHAVTO", SqlDbType.DateTime)
        args(11).Value = CDate(lEntidad.FECHAVTO & " 12:00:00 AM ")
        args(12) = New SqlParameter("@FECHASOLDEVGTIA", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.FECHASOLDEVGTIA = Nothing, DBNull.Value, lEntidad.FECHASOLDEVGTIA)
        args(13) = New SqlParameter("@FECHARESFIRME", SqlDbType.DateTime)
        args(13).Value = IIf(lEntidad.FECHARESFIRME = Nothing, DBNull.Value, lEntidad.FECHARESFIRME)
        args(14) = New SqlParameter("@FECHADEVGTIA", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.FECHADEVGTIA = Nothing, DBNull.Value, lEntidad.FECHADEVGTIA)
        args(15) = New SqlParameter("@FECHAEFEGTIA", SqlDbType.DateTime)
        args(15).Value = IIf(lEntidad.FECHAEFEGTIA = Nothing, DBNull.Value, lEntidad.FECHAEFEGTIA)
        args(16) = New SqlParameter("@FECHAAPRPLANUTIANT", SqlDbType.DateTime)
        args(16).Value = IIf(lEntidad.FECHAAPRPLANUTIANT = Nothing, DBNull.Value, lEntidad.FECHAAPRPLANUTIANT)
        args(17) = New SqlParameter("@FECHAUTIPLANAVFI", SqlDbType.DateTime)
        args(17).Value = IIf(lEntidad.FECHAUTIPLANAVFI = Nothing, DBNull.Value, lEntidad.FECHAUTIPLANAVFI)
        args(18) = New SqlParameter("@FECHAACEPGTIACUMCON", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.FECHAACEPGTIACUMCON = Nothing, DBNull.Value, lEntidad.FECHAACEPGTIACUMCON)
        args(19) = New SqlParameter("@FECHAACEPGTIA", SqlDbType.DateTime)
        args(19).Value = IIf(lEntidad.FECHAACEPGTIA = Nothing, DBNull.Value, lEntidad.FECHAACEPGTIA)
        args(20) = New SqlParameter("@FECHAENVIOUFI", SqlDbType.DateTime)
        args(20).Value = IIf(lEntidad.FECHAENVIOUFI = Nothing, DBNull.Value, lEntidad.FECHAENVIOUFI)
        args(21) = New SqlParameter("@FECHARECUFI", SqlDbType.DateTime)
        args(21).Value = IIf(lEntidad.FECHARECUFI = Nothing, DBNull.Value, lEntidad.FECHARECUFI)
        args(22) = New SqlParameter("@FECHAEJEANT", SqlDbType.DateTime)
        args(22).Value = IIf(lEntidad.FECHAEJEANT = Nothing, DBNull.Value, lEntidad.FECHAEJEANT)
        args(23) = New SqlParameter("@FECHAACGTIABVEOB", SqlDbType.DateTime)
        args(23).Value = IIf(lEntidad.FECHAACGTIABVEOB = Nothing, DBNull.Value, lEntidad.FECHAACGTIABVEOB)
        args(24) = New SqlParameter("@FECHAACEPFIABUECAL", SqlDbType.DateTime)
        args(24).Value = IIf(lEntidad.FECHAACEPFIABUECAL = Nothing, DBNull.Value, lEntidad.FECHAACEPFIABUECAL)
        args(25) = New SqlParameter("@FECHAACTAREL", SqlDbType.DateTime)
        args(25).Value = IIf(lEntidad.FECHAACTAREL = Nothing, DBNull.Value, lEntidad.FECHAACTAREL)
        args(26) = New SqlParameter("@FECHALIQUIDACION", SqlDbType.DateTime)
        args(26).Value = IIf(lEntidad.FECHALIQUIDACION = Nothing, DBNull.Value, lEntidad.FECHALIQUIDACION)
        args(27) = New SqlParameter("@FECHARECBOS", SqlDbType.DateTime)
        args(27).Value = IIf(lEntidad.FECHARECBOS = Nothing, DBNull.Value, lEntidad.FECHARECBOS)
        args(28) = New SqlParameter("@IDCAUSAL", SqlDbType.Int)
        args(28).Value = IIf(lEntidad.IDCAUSAL = Nothing, DBNull.Value, lEntidad.IDCAUSAL)
        args(29) = New SqlParameter("@OBSERVACIONES", SqlDbType.VarChar)
        args(29).Value = IIf(lEntidad.OBSERVACIONES = Nothing, DBNull.Value, lEntidad.OBSERVACIONES)
        args(30) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(30).Value = lEntidad.USUARIO
        args(31) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(31).Value = lEntidad.FECHA
        args(32) = New SqlParameter("@VALORCUANTIA", SqlDbType.Decimal)
        args(32).Value = IIf(lEntidad.VALORCUANTIA = Nothing, DBNull.Value, lEntidad.VALORCUANTIA)
        args(33) = New SqlParameter("@IDGARANTIA", SqlDbType.Int)
        args(33).Value = lEntidad.IDGARANTIA
        args(34) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(34).Value = lEntidad.IDESTABLECIMIENTO
        args(35) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.Int)
        args(35).Value = lEntidad.IDTIPOGARANTIA
        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As REGISTROGARANTIAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CG_REGISTROGARANTIAS ")
        strSQL.Append(" WHERE IDGARANTIA = @IDGARANTIA AND IDESTABLECIMIENTO=@IDESTABLECIMIENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDGARANTIA", SqlDbType.Int)
        args(0).Value = lEntidad.IDGARANTIA
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDESTABLECIMIENTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDGARANTIA,IDESTABLECIMIENTO,IDTIPOGARANTIA,IDPROVEEDOR, IDTIPODOCUMENTO, IDMODALIDADCOMPRA, NUMPROCESO, NUMCONTRATO, FECHADISTRIBUCION, IDENTIDAD, NUMGARANTIA, MONTO, FECHAEMISION, TOTALDIAS, FECHAVTO, FECHASOLDEVGTIA, FECHARESFIRME, FECHADEVGTIA, FECHAEFEGTIA, FECHAAPRPLANUTIANT, FECHAUTIPLANAVFI, FECHAACEPGTIACUMCON, FECHAACEPGTIA, FECHAENVIOUFI, FECHARECUFI, FECHAEJEANT, FECHAACGTIABVEOB, FECHAACEPFIABUECAL, FECHAACTAREL, FECHALIQUIDACION, FECHARECBOS, IDCAUSAL, OBSERVACIONES, VALORCUANTIA, USUARIO, FECHA ")
        strSQL.Append(" FROM SAB_CG_REGISTROGARANTIAS ")

    End Sub
    Public Function ObtenerRegistroUnaGarantia(ByVal idgarantia As Integer, ByVal idestablecimiento As Integer) As DataSet
        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDGARANTIA=" & idgarantia & " AND IDESTABLECIMIENTO=" & idestablecimiento)
        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function

    Public Function ObtenerReporteUnaGarantia(ByVal idgarantia As Integer, ByVal idtg As Integer, ByVal idestablecimiento As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT r.IDGARANTIA,r.IDESTABLECIMIENTO,r.IDTIPOGARANTIA,r.IDPROVEEDOR, r.IDTIPODOCUMENTO, r.IDMODALIDADCOMPRA, r.NUMPROCESO, r.NUMCONTRATO, r.FECHADISTRIBUCION, r.IDENTIDAD, r.NUMGARANTIA, r.MONTO, r.FECHAEMISION, r.TOTALDIAS, r.FECHAVTO, r.FECHASOLDEVGTIA, r.FECHARESFIRME, r.FECHADEVGTIA, r.FECHAEFEGTIA, r.FECHAAPRPLANUTIANT, r.FECHAUTIPLANAVFI, r.FECHAACEPGTIACUMCON, r.FECHAACEPGTIA, r.FECHAENVIOUFI, r.FECHARECUFI, r.FECHAEJEANT, r.FECHAACGTIABVEOB, r.FECHAACEPFIABUECAL, r.FECHAACTAREL, r.FECHALIQUIDACION, r.FECHARECBOS, r.IDCAUSAL, r.OBSERVACIONES, r.VALORCUANTIA, r.USUARIO, r.FECHA, p.nit, p.nombre,p.nombreabr, td.nombre as tipodocumento, mc.nombre as modalidadcompra, e.nombre as entidad, isnull(c.nombre,'') as causal, f.fechapresentacion, f.fechaobservacion  ")
        strSQL.Append(" FROM SAB_CG_REGISTROGARANTIAS r inner join sab_cg_proveedores p on p.idproveedor=r.idproveedor ")
        strSQL.Append(" inner join sab_cg_tiposdocumento td on td.idtipodocumento=r.idtipodocumento ")
        strSQL.Append(" inner join sab_cg_modalidadcompra mc on mc.idmodalidadcompra=r.idmodalidadcompra ")
        strSQL.Append(" inner join sab_cg_entidad e on e.identidad=r.identidad ")
        strSQL.Append(" left outer join sab_cg_causales c on c.idcausal=r.idcausal and c.idtipogarantia=r.idtipogarantia ")
        strSQL.Append(" left outer join sab_cg_fechas f on f.idgarantia=r.idgarantia and f.idestablecimiento=r.idestablecimiento ")

        strSQL.Append(" where r.idgarantia=@idgarantia and r.idtipogarantia=@idtipogarantia and r.idestablecimiento=@idestablecimiento ")


        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@idtipogarantia", SqlDbType.Int)
        args(0).Value = idtg
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = idestablecimiento
        args(2) = New SqlParameter("@idgarantia", SqlDbType.Int)
        args(2).Value = idgarantia

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds
    End Function
    

    Public Function ObtenerDataSetPorID() As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As REGISTROGARANTIAS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDGARANTIA),0) + 1 ")
        strSQL.Append(" FROM SAB_CG_REGISTROGARANTIAS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

    End Function


    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

    End Function
    Public Function ObtenerDataSetGarantias(ByVal idestablecimiento As Integer, ByVal idtipogarantia As Integer) As DataSet
        Dim strSQL As New StringBuilder
        If idtipogarantia = 2 Then
            strSQL.Append(" SELECT R.IDGARANTIA, P.NIT, P.NOMBRE, M.NOMBRE AS MODALIDADCOMPRA, R.NUMCONTRATO,R.NUMPROCESO,R.FECHAEMISION,R.FECHAEJEANT AS FECHAVTO ")
            strSQL.Append(" FROM SAB_CG_REGISTROGARANTIAS R INNER JOIN SAB_CG_PROVEEDORES P ON ")
            strSQL.Append(" P.IDPROVEEDOR=R.IDPROVEEDOR ")
            strSQL.Append(" INNER JOIN dbo.SAB_CG_MODALIDADCOMPRA M ON ")
            strSQL.Append(" M.IDMODALIDADCOMPRA=R.IDMODALIDADCOMPRA ")
            strSQL.Append(" WHERE  ")
            strSQL.Append(" R.IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND ")
            strSQL.Append(" R.IDTIPOGARANTIA=@idtipogarantia ")
            strSQL.Append(" AND (R.FECHADEVGTIA IS NULL AND ")
            strSQL.Append(" R.FECHAEFEGTIA IS NULL) ")

        Else

            strSQL.Append(" SELECT R.IDGARANTIA, P.NIT, P.NOMBRE, M.NOMBRE AS MODALIDADCOMPRA, R.NUMCONTRATO,R.NUMPROCESO,R.FECHAEMISION,R.FECHAVTO ")
            strSQL.Append(" FROM SAB_CG_REGISTROGARANTIAS R INNER JOIN SAB_CG_PROVEEDORES P ON ")
            strSQL.Append(" P.IDPROVEEDOR=R.IDPROVEEDOR ")
            strSQL.Append(" INNER JOIN dbo.SAB_CG_MODALIDADCOMPRA M ON ")
            strSQL.Append(" M.IDMODALIDADCOMPRA=R.IDMODALIDADCOMPRA ")
            strSQL.Append(" WHERE  ")
            strSQL.Append(" R.IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND ")
            strSQL.Append(" R.IDTIPOGARANTIA=@idtipogarantia ")
            strSQL.Append(" AND (R.FECHADEVGTIA IS NULL AND ")
            strSQL.Append(" R.FECHAEFEGTIA IS NULL) ")

        End If
        
        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idtipogarantia", SqlDbType.Int)
        args(0).Value = idtipogarantia
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = idestablecimiento


        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerGarantias() As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDTIPOGARANTIA, NOMBRE ")
        strSQL.Append(" FROM SAB_CG_TIPOSGARANTIA ")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerIDGarantias(ByVal idestablecimiento As Integer, ByVal idtipogarantia As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT max(IDGARANTIA) ")
        strSQL.Append(" FROM SAB_CG_REGISTROGARANTIAS ")
        strSQL.Append(" WHERE  ")
        strSQL.Append(" IDESTABLECIMIENTO=@IDESTABLECIMIENTO AND ")
        strSQL.Append(" IDTIPOGARANTIA=@idtipogarantia ")


        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idtipogarantia", SqlDbType.Int)
        args(0).Value = idtipogarantia
        args(1) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(1).Value = idestablecimiento



        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)



    End Function
    Public Function InsertarFechas(ByVal idgarantia As Integer, ByVal idestablecimiento As Integer, ByVal fechapresentacion As Date, ByVal fechaobservacion As Date) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT SAB_CG_FECHAS VALUES (@IDGARANTIA,@idestablecimiento,@FECHAPRESENTACION,@FECHAOBSERVACION) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@idgarantia", SqlDbType.Int)
        args(0).Value = idgarantia
        args(1) = New SqlParameter("@fechapresentacion", SqlDbType.DateTime)
        args(1).Value = fechapresentacion
        args(2) = New SqlParameter("@fechaobservacion", SqlDbType.DateTime)
        args(2).Value = fechaobservacion
        args(3) = New SqlParameter("@idestablecimiento", SqlDbType.Int)
        args(3).Value = idestablecimiento



        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)



    End Function
    Public Function ObtenerFechas(ByVal idgarantia As Integer, ByVal idestablecimiento As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT FECHAPRESENTACION, FECHAOBSERVACION FROM SAB_CG_FECHAS WHERE IDGARANTIA=@IDGARANTIA AND IDESTABLECIMIENTO=@idestablecimiento ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idgarantia", SqlDbType.Int)
        args(0).Value = idgarantia
        args(1) = New SqlParameter("@idestablecimiento", SqlDbType.Int)
        args(1).Value = idestablecimiento

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)



    End Function
    Public Function BorrarFechasGarantias(ByVal idgarantia As Integer, ByVal idestablecimiento As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" DELETE SAB_CG_FECHAS WHERE IDGARANTIA=@IDGARANTIA and idestablecimiento=@idestablecimiento")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@idgarantia", SqlDbType.Int)
        args(0).Value = idgarantia
        args(1) = New SqlParameter("@idestablecimiento", SqlDbType.Int)
        args(1).Value = idestablecimiento

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)



    End Function
    Public Function ObtenerReporte(ByVal fechaprox As DateTime, Optional ByVal idproveedor As Integer = 0, Optional ByVal nit As String = "", Optional ByVal eg As Integer = 0, Optional ByVal eeg As Integer = 0, Optional ByVal tipo As Integer = 0, Optional ByVal idmodalidad As Integer = 0) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append(" select r.idgarantia, r.idtipogarantia, p.nit, p.nombre as proveedor, ")
        strSQL.Append(" m.nombre AS MODALIDAD, r.numproceso as numproceso, ")
        strSQL.Append(" r.numcontrato, tg.nombre as tipogarantia, r.numgarantia, r.monto,  ")
        strSQL.Append(" case when r.fechavto < getdate() then 'VIGENTE' else 'VENCIDA'  end as estado, convert(varchar(10),r.fechavto,103) AS FECHAVTO, ")
        strSQL.Append(" case when r.fechadevgtia is null then 'PENDIENTE' else 'DEVUELTA' end as estadoentrega, convert(varchar(10),r.fechadevgtia,103) AS FECHADEVGTIA ")
        strSQL.Append(" from sab_cg_registrogarantias r inner join sab_cg_proveedores p on ")
        strSQL.Append(" p.idproveedor=r.idproveedor ")
        strSQL.Append(" inner join sab_cg_tiposgarantia tg on ")
        strSQL.Append(" tg.idtipogarantia=r.idtipogarantia ")
        strSQL.Append(" inner join sab_cg_modalidadcompra m ")
        strSQL.Append(" on m.idmodalidadcompra=r.idmodalidadcompra ")


        strSQL.Append(" where (r.idproveedor=@idproveedor or @idproveedor=0) ")
        strSQL.Append(" and (r.idtipogarantia =@tipo  or @tipo=0) ")
        strSQL.Append(" and (r.idmodalidadcompra =@idmodalidad  or @idmodalidad=0) ")


        If eg = 1 Then
            strSQL.Append(" and r.fechavto > getdate() ") 'vencido
            If eeg = 1 Then
                strSQL.Append(" and r.fechadevgtia is not null ") 'devueltas
            ElseIf eeg = 2 Then
                strSQL.Append(" and r.fechadevgtia is null ") 'pendientes de dev.
            End If
        ElseIf eg = 2 Then
            strSQL.Append(" and r.fechavto < getdate() ") 'vigente
            If eeg = 1 Then
                strSQL.Append(" and r.fechadevgtia is not null ") 'devueltas
            ElseIf eeg = 2 Then
                strSQL.Append(" and r.fechadevgtia is null ") 'pendientes de dev.
            End If
        ElseIf eg = 3 Then
            strSQL.Append(" and r.fechavto < @fechaprox ") 'proximovencer
            If eeg = 1 Then
                strSQL.Append(" and r.fechadevgtia is not null ") 'devueltas
            ElseIf eeg = 2 Then
                strSQL.Append(" and r.fechadevgtia is null ") 'pendientes de dev.
            End If
        End If


        If nit <> "" Then
            strSQL.Append(" and p.nit=@nit ")
            If eg = 1 Then
                strSQL.Append(" and r.fechavto > getdate() ") 'vencido
                If eeg = 1 Then
                    strSQL.Append(" and r.fechadevgtia is not null ") 'devueltas
                ElseIf eeg = 2 Then
                    strSQL.Append(" and r.fechadevgtia is null ") 'pendientes de dev.
                End If
            ElseIf eg = 2 Then
                strSQL.Append(" and r.fechavto < getdate() ") 'vigente
                If eeg = 1 Then
                    strSQL.Append(" and r.fechadevgtia is not null ") 'devueltas
                ElseIf eeg = 2 Then
                    strSQL.Append(" and r.fechadevgtia is null ") 'pendientes de dev.
                End If
            ElseIf eg = 3 Then
                strSQL.Append(" and r.fechavto < @fechaprox ") 'proximovencer
                If eeg = 1 Then
                    strSQL.Append(" and r.fechadevgtia is not null ") 'devueltas
                ElseIf eeg = 2 Then
                    strSQL.Append(" and r.fechadevgtia is null ") 'pendientes de dev.
                End If
            End If
        End If

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@idproveedor", SqlDbType.Int)
        args(0).Value = idproveedor
        args(1) = New SqlParameter("@nit", SqlDbType.VarChar)
        args(1).Value = nit
        args(2) = New SqlParameter("@tipo", SqlDbType.Int)
        args(2).Value = tipo
        args(3) = New SqlParameter("@idmodalidad", SqlDbType.Int)
        args(3).Value = idmodalidad
        args(4) = New SqlParameter("@fechaprox", SqlDbType.DateTime)
        args(4).Value = fechaprox

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
End Class
