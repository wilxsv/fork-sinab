Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_CONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	02/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbCONTRATOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CONTRATOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDCONTRATO = 0 _
            Or lEntidad.IDCONTRATO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDCONTRATO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_CONTRATOS ")
        strSQL.Append(" SET NUMEROCONTRATO = @NUMEROCONTRATO, ")
        strSQL.Append(" IDTIPODOCUMENTO = @IDTIPODOCUMENTO, ")
        strSQL.Append(" IDPLANTILLA = @IDPLANTILLA, ")
        strSQL.Append(" TIPOPERSONA = @TIPOPERSONA, ")
        strSQL.Append(" REPRESENTANTELEGAL = @REPRESENTANTELEGAL, ")
        strSQL.Append(" PERSONERIAJURIDICA = @PERSONERIAJURIDICA, ")
        strSQL.Append(" FECHAGENERACION = @FECHAGENERACION, ")
        strSQL.Append(" FECHAAPROBACION = @FECHAAPROBACION, ")
        strSQL.Append(" FECHADISTRIBUCION = @FECHADISTRIBUCION, ")
        strSQL.Append(" CODIGOLICITACION = @CODIGOLICITACION, ")
        strSQL.Append(" FECHAINICIOENTREGA = @FECHAINICIOENTREGA, ")
        strSQL.Append(" IDESTADOCONTRATO = @IDESTADOCONTRATO, ")
        strSQL.Append(" IDCALIFICACIONCUMPLIMIENTO = @IDCALIFICACIONCUMPLIMIENTO, ")
        strSQL.Append(" IDCALIFICACIONCALIDAD = @IDCALIFICACIONCALIDAD, ")
        strSQL.Append(" IDMODALIDADCOMPRA = @IDMODALIDADCOMPRA, ")
        strSQL.Append(" NUMEROMODALIDADCOMPRA = @NUMEROMODALIDADCOMPRA, ")
        strSQL.Append(" MONTOCONTRATO = @MONTOCONTRATO, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA, ")
        strSQL.Append(" ACTANOTARIAL = @ACTANOTARIAL, ")
        strSQL.Append(" RESOLUCION = @RESOLUCION, ")
        strSQL.Append(" MODIFICATIVA = @MODIFICATIVA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(27) As SqlParameter
        args(0) = New SqlParameter("@NUMEROCONTRATO", SqlDbType.VarChar)
        args(0).Value = lEntidad.NUMEROCONTRATO
        args(1) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.SmallInt)
        args(1).Value = lEntidad.IDTIPODOCUMENTO
        args(2) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(2).Value = IIf(lEntidad.IDPLANTILLA = Nothing, DBNull.Value, lEntidad.IDPLANTILLA)
        args(3) = New SqlParameter("@TIPOPERSONA", SqlDbType.VarChar)
        args(3).Value = lEntidad.TIPOPERSONA
        args(4) = New SqlParameter("@REPRESENTANTELEGAL", SqlDbType.VarChar)
        args(4).Value = lEntidad.REPRESENTANTELEGAL
        args(5) = New SqlParameter("@PERSONERIAJURIDICA", SqlDbType.VarChar)
        args(5).Value = IIf(IsNothing(lEntidad.PERSONERIAJURIDICA), DBNull.Value, lEntidad.PERSONERIAJURIDICA)
        args(6) = New SqlParameter("@FECHAGENERACION", SqlDbType.DateTime)
        args(6).Value = lEntidad.FECHAGENERACION
        args(7) = New SqlParameter("@FECHAAPROBACION", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.FECHAAPROBACION = Nothing, DBNull.Value, lEntidad.FECHAAPROBACION)
        args(8) = New SqlParameter("@FECHADISTRIBUCION", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.FECHADISTRIBUCION = Nothing, DBNull.Value, lEntidad.FECHADISTRIBUCION)
        args(9) = New SqlParameter("@CODIGOLICITACION", SqlDbType.VarChar)
        args(9).Value = IIf(lEntidad.CODIGOLICITACION = Nothing, DBNull.Value, lEntidad.CODIGOLICITACION)
        args(10) = New SqlParameter("@FECHAINICIOENTREGA", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.FECHAINICIOENTREGA = Nothing, DBNull.Value, lEntidad.FECHAINICIOENTREGA)
        args(11) = New SqlParameter("@IDESTADOCONTRATO", SqlDbType.SmallInt)
        args(11).Value = lEntidad.IDESTADOCONTRATO
        args(12) = New SqlParameter("@IDCALIFICACIONCUMPLIMIENTO", SqlDbType.SmallInt)
        args(12).Value = IIf(lEntidad.IDCALIFICACIONCUMPLIMIENTO = Nothing, DBNull.Value, lEntidad.IDCALIFICACIONCUMPLIMIENTO)
        args(13) = New SqlParameter("@IDCALIFICACIONCALIDAD", SqlDbType.SmallInt)
        args(13).Value = IIf(lEntidad.IDCALIFICACIONCALIDAD = Nothing, DBNull.Value, lEntidad.IDCALIFICACIONCALIDAD)
        args(14) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.TinyInt)
        args(14).Value = IIf(lEntidad.IDMODALIDADCOMPRA = Nothing, DBNull.Value, lEntidad.IDMODALIDADCOMPRA)
        args(15) = New SqlParameter("@NUMEROMODALIDADCOMPRA", SqlDbType.VarChar)
        args(15).Value = IIf(lEntidad.NUMEROMODALIDADCOMPRA = Nothing, DBNull.Value, lEntidad.NUMEROMODALIDADCOMPRA)
        args(16) = New SqlParameter("@MONTOCONTRATO", SqlDbType.Decimal)
        args(16).Value = lEntidad.MONTOCONTRATO
        args(17) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(18) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(18).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(19) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(19).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(20) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(20).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(21) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(21).Value = lEntidad.ESTASINCRONIZADA
        args(22) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(22).Value = lEntidad.IDESTABLECIMIENTO
        args(23) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(23).Value = lEntidad.IDPROVEEDOR
        args(24) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(24).Value = lEntidad.IDCONTRATO
        args(25) = New SqlParameter("@ACTANOTARIAL", SqlDbType.VarChar)
        args(25).Value = IIf(IsNothing(lEntidad.ACTANOTARIAL), DBNull.Value, lEntidad.ACTANOTARIAL)
        args(26) = New SqlParameter("@RESOLUCION", SqlDbType.VarChar)
        args(26).Value = IIf(lEntidad.RESOLUCION = Nothing, DBNull.Value, lEntidad.RESOLUCION)
        args(27) = New SqlParameter("@MODIFICATIVA", SqlDbType.VarChar)
        args(27).Value = IIf(lEntidad.MODIFICATIVA = Nothing, DBNull.Value, lEntidad.MODIFICATIVA)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("INSERT INTO SAB_UACI_CONTRATOS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" NUMEROCONTRATO, ")
        strSQL.Append(" IDTIPODOCUMENTO, ")
        strSQL.Append(" IDPLANTILLA, ")
        strSQL.Append(" TIPOPERSONA, ")
        strSQL.Append(" REPRESENTANTELEGAL, ")
        strSQL.Append(" PERSONERIAJURIDICA, ")
        strSQL.Append(" FECHAGENERACION, ")
        strSQL.Append(" FECHAAPROBACION, ")
        strSQL.Append(" FECHADISTRIBUCION, ")
        strSQL.Append(" CODIGOLICITACION, ")
        strSQL.Append(" FECHAINICIOENTREGA, ")
        strSQL.Append(" IDESTADOCONTRATO, ")
        strSQL.Append(" IDCALIFICACIONCUMPLIMIENTO, ")
        strSQL.Append(" IDCALIFICACIONCALIDAD, ")
        strSQL.Append(" IDMODALIDADCOMPRA, ")
        strSQL.Append(" NUMEROMODALIDADCOMPRA, ")
        strSQL.Append(" MONTOCONTRATO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" ACTANOTARIAL, ")
        strSQL.Append(" RESOLUCION, ")
        strSQL.Append(" MODIFICATIVA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @NUMEROCONTRATO, ")
        strSQL.Append(" @IDTIPODOCUMENTO, ")
        strSQL.Append(" @IDPLANTILLA, ")
        strSQL.Append(" @TIPOPERSONA, ")
        strSQL.Append(" @REPRESENTANTELEGAL, ")
        strSQL.Append(" @PERSONERIAJURIDICA, ")
        strSQL.Append(" @FECHAGENERACION, ")
        strSQL.Append(" @FECHAAPROBACION, ")
        strSQL.Append(" @FECHADISTRIBUCION, ")
        strSQL.Append(" @CODIGOLICITACION, ")
        strSQL.Append(" @FECHAINICIOENTREGA, ")
        strSQL.Append(" @IDESTADOCONTRATO, ")
        strSQL.Append(" @IDCALIFICACIONCUMPLIMIENTO, ")
        strSQL.Append(" @IDCALIFICACIONCALIDAD, ")
        strSQL.Append(" @IDMODALIDADCOMPRA, ")
        strSQL.Append(" @NUMEROMODALIDADCOMPRA, ")
        strSQL.Append(" @MONTOCONTRATO, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA, ")
        strSQL.Append(" @ACTANOTARIAL, ")
        strSQL.Append(" @RESOLUCION, ")
        strSQL.Append(" @MODIFICATIVA) ")

        Dim args(27) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@NUMEROCONTRATO", SqlDbType.VarChar)
        args(3).Value = lEntidad.NUMEROCONTRATO
        args(4) = New SqlParameter("@IDTIPODOCUMENTO", SqlDbType.SmallInt)
        args(4).Value = lEntidad.IDTIPODOCUMENTO
        args(5) = New SqlParameter("@IDPLANTILLA", SqlDbType.Int)
        args(5).Value = IIf(lEntidad.IDPLANTILLA = Nothing, DBNull.Value, lEntidad.IDPLANTILLA)
        args(6) = New SqlParameter("@TIPOPERSONA", SqlDbType.VarChar)
        args(6).Value = lEntidad.TIPOPERSONA
        args(7) = New SqlParameter("@REPRESENTANTELEGAL", SqlDbType.VarChar)
        args(7).Value = IIf(IsNothing(lEntidad.REPRESENTANTELEGAL), DBNull.Value, lEntidad.REPRESENTANTELEGAL)
        args(8) = New SqlParameter("@PERSONERIAJURIDICA", SqlDbType.VarChar)
        args(8).Value = IIf(IsNothing(lEntidad.PERSONERIAJURIDICA), DBNull.Value, lEntidad.PERSONERIAJURIDICA)
        args(9) = New SqlParameter("@FECHAGENERACION", SqlDbType.DateTime)
        args(9).Value = lEntidad.FECHAGENERACION
        args(10) = New SqlParameter("@FECHAAPROBACION", SqlDbType.DateTime)
        args(10).Value = IIf(lEntidad.FECHAAPROBACION = Nothing, DBNull.Value, lEntidad.FECHAAPROBACION)
        args(11) = New SqlParameter("@FECHADISTRIBUCION", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.FECHADISTRIBUCION = Nothing, DBNull.Value, lEntidad.FECHADISTRIBUCION)
        args(12) = New SqlParameter("@CODIGOLICITACION", SqlDbType.VarChar)
        args(12).Value = IIf(lEntidad.CODIGOLICITACION = Nothing, DBNull.Value, lEntidad.CODIGOLICITACION)
        args(13) = New SqlParameter("@FECHAINICIOENTREGA", SqlDbType.DateTime)
        args(13).Value = IIf(lEntidad.FECHAINICIOENTREGA = Nothing, DBNull.Value, lEntidad.FECHAINICIOENTREGA)
        args(14) = New SqlParameter("@IDESTADOCONTRATO", SqlDbType.SmallInt)
        args(14).Value = lEntidad.IDESTADOCONTRATO
        args(15) = New SqlParameter("@IDCALIFICACIONCUMPLIMIENTO", SqlDbType.SmallInt)
        args(15).Value = IIf(lEntidad.IDCALIFICACIONCUMPLIMIENTO = Nothing, DBNull.Value, lEntidad.IDCALIFICACIONCUMPLIMIENTO)
        args(16) = New SqlParameter("@IDCALIFICACIONCALIDAD", SqlDbType.SmallInt)
        args(16).Value = IIf(lEntidad.IDCALIFICACIONCALIDAD = Nothing, DBNull.Value, lEntidad.IDCALIFICACIONCALIDAD)
        args(17) = New SqlParameter("@IDMODALIDADCOMPRA", SqlDbType.TinyInt)
        args(17).Value = IIf(lEntidad.IDMODALIDADCOMPRA = Nothing, DBNull.Value, lEntidad.IDMODALIDADCOMPRA)
        args(18) = New SqlParameter("@NUMEROMODALIDADCOMPRA", SqlDbType.VarChar)
        args(18).Value = IIf(lEntidad.NUMEROMODALIDADCOMPRA = Nothing, DBNull.Value, lEntidad.NUMEROMODALIDADCOMPRA)
        args(19) = New SqlParameter("@MONTOCONTRATO", SqlDbType.Decimal)
        args(19).Value = lEntidad.MONTOCONTRATO
        args(20) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(20).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(21) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(21).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(22) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(22).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(23) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(23).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(24) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(24).Value = lEntidad.ESTASINCRONIZADA
        args(25) = New SqlParameter("@ACTANOTARIAL", SqlDbType.VarChar)
        args(25).Value = IIf(IsNothing(lEntidad.ACTANOTARIAL), DBNull.Value, lEntidad.ACTANOTARIAL)
        args(26) = New SqlParameter("@RESOLUCION", SqlDbType.VarChar)
        args(26).Value = IIf(lEntidad.RESOLUCION = Nothing, DBNull.Value, lEntidad.RESOLUCION)
        args(27) = New SqlParameter("@MODIFICATIVA", SqlDbType.VarChar)
        args(27).Value = IIf(lEntidad.MODIFICATIVA = Nothing, DBNull.Value, lEntidad.MODIFICATIVA)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_CONTRATOS ")
        strSQL.Append("WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append("AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append("AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As CONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.NUMEROCONTRATO = IIf(.Item("NUMEROCONTRATO") Is DBNull.Value, Nothing, .Item("NUMEROCONTRATO"))
                lEntidad.IDTIPODOCUMENTO = IIf(.Item("IDTIPODOCUMENTO") Is DBNull.Value, Nothing, .Item("IDTIPODOCUMENTO"))
                lEntidad.IDPLANTILLA = IIf(.Item("IDPLANTILLA") Is DBNull.Value, Nothing, .Item("IDPLANTILLA"))
                lEntidad.TIPOPERSONA = IIf(.Item("TIPOPERSONA") Is DBNull.Value, Nothing, .Item("TIPOPERSONA"))
                lEntidad.REPRESENTANTELEGAL = IIf(.Item("REPRESENTANTELEGAL") Is DBNull.Value, Nothing, .Item("REPRESENTANTELEGAL"))
                lEntidad.PERSONERIAJURIDICA = IIf(.Item("PERSONERIAJURIDICA") Is DBNull.Value, Nothing, .Item("PERSONERIAJURIDICA"))
                lEntidad.FECHAGENERACION = IIf(.Item("FECHAGENERACION") Is DBNull.Value, Nothing, .Item("FECHAGENERACION"))
                lEntidad.FECHAAPROBACION = IIf(.Item("FECHAAPROBACION") Is DBNull.Value, Nothing, .Item("FECHAAPROBACION"))
                lEntidad.FECHADISTRIBUCION = IIf(.Item("FECHADISTRIBUCION") Is DBNull.Value, Nothing, .Item("FECHADISTRIBUCION"))
                lEntidad.CODIGOLICITACION = IIf(.Item("CODIGOLICITACION") Is DBNull.Value, Nothing, .Item("CODIGOLICITACION"))
                lEntidad.FECHAINICIOENTREGA = IIf(.Item("FECHAINICIOENTREGA") Is DBNull.Value, Nothing, .Item("FECHAINICIOENTREGA"))
                lEntidad.IDESTADOCONTRATO = IIf(.Item("IDESTADOCONTRATO") Is DBNull.Value, Nothing, .Item("IDESTADOCONTRATO"))
                lEntidad.IDCALIFICACIONCUMPLIMIENTO = IIf(.Item("IDCALIFICACIONCUMPLIMIENTO") Is DBNull.Value, Nothing, .Item("IDCALIFICACIONCUMPLIMIENTO"))
                lEntidad.IDCALIFICACIONCALIDAD = IIf(.Item("IDCALIFICACIONCALIDAD") Is DBNull.Value, Nothing, .Item("IDCALIFICACIONCALIDAD"))
                lEntidad.IDMODALIDADCOMPRA = IIf(.Item("IDMODALIDADCOMPRA") Is DBNull.Value, Nothing, .Item("IDMODALIDADCOMPRA"))
                lEntidad.NUMEROMODALIDADCOMPRA = IIf(.Item("NUMEROMODALIDADCOMPRA") Is DBNull.Value, Nothing, .Item("NUMEROMODALIDADCOMPRA"))
                lEntidad.MONTOCONTRATO = IIf(.Item("MONTOCONTRATO") Is DBNull.Value, Nothing, .Item("MONTOCONTRATO"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
                lEntidad.ACTANOTARIAL = IIf(.Item("ACTANOTARIAL") Is DBNull.Value, Nothing, .Item("ACTANOTARIAL"))
                lEntidad.RESOLUCION = IIf(.Item("RESOLUCION") Is DBNull.Value, Nothing, .Item("RESOLUCION"))
                lEntidad.MODIFICATIVA = IIf(.Item("MODIFICATIVA") Is DBNull.Value, Nothing, .Item("MODIFICATIVA"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As CONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDCONTRATO),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32) As listaCONTRATOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaCONTRATOS

        Try
            Do While dr.Read()
                Dim mEntidad As New CONTRATOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IIf(dr("IDCONTRATO") Is DBNull.Value, Nothing, dr("IDCONTRATO"))
                mEntidad.NUMEROCONTRATO = IIf(dr("NUMEROCONTRATO") Is DBNull.Value, Nothing, dr("NUMEROCONTRATO"))
                mEntidad.IDTIPODOCUMENTO = IIf(dr("IDTIPODOCUMENTO") Is DBNull.Value, Nothing, dr("IDTIPODOCUMENTO"))
                mEntidad.IDPLANTILLA = IIf(dr("IDPLANTILLA") Is DBNull.Value, Nothing, dr("IDPLANTILLA"))
                mEntidad.TIPOPERSONA = IIf(dr("TIPOPERSONA") Is DBNull.Value, Nothing, dr("TIPOPERSONA"))
                mEntidad.REPRESENTANTELEGAL = IIf(dr("REPRESENTANTELEGAL") Is DBNull.Value, Nothing, dr("REPRESENTANTELEGAL"))
                mEntidad.PERSONERIAJURIDICA = IIf(dr("PERSONERIAJURIDICA") Is DBNull.Value, Nothing, dr("PERSONERIAJURIDICA"))
                mEntidad.FECHAGENERACION = IIf(dr("FECHAGENERACION") Is DBNull.Value, Nothing, dr("FECHAGENERACION"))
                mEntidad.FECHAAPROBACION = IIf(dr("FECHAAPROBACION") Is DBNull.Value, Nothing, dr("FECHAAPROBACION"))
                mEntidad.FECHADISTRIBUCION = IIf(dr("FECHADISTRIBUCION") Is DBNull.Value, Nothing, dr("FECHADISTRIBUCION"))
                mEntidad.CODIGOLICITACION = IIf(dr("CODIGOLICITACION") Is DBNull.Value, Nothing, dr("CODIGOLICITACION"))
                mEntidad.FECHAINICIOENTREGA = IIf(dr("FECHAINICIOENTREGA") Is DBNull.Value, Nothing, dr("FECHAINICIOENTREGA"))
                mEntidad.IDESTADOCONTRATO = IIf(dr("IDESTADOCONTRATO") Is DBNull.Value, Nothing, dr("IDESTADOCONTRATO"))
                mEntidad.IDCALIFICACIONCUMPLIMIENTO = IIf(dr("IDCALIFICACIONCUMPLIMIENTO") Is DBNull.Value, Nothing, dr("IDCALIFICACIONCUMPLIMIENTO"))
                mEntidad.IDCALIFICACIONCALIDAD = IIf(dr("IDCALIFICACIONCALIDAD") Is DBNull.Value, Nothing, dr("IDCALIFICACIONCALIDAD"))
                mEntidad.IDMODALIDADCOMPRA = IIf(dr("IDMODALIDADCOMPRA") Is DBNull.Value, Nothing, dr("IDMODALIDADCOMPRA"))
                mEntidad.NUMEROMODALIDADCOMPRA = IIf(dr("NUMEROMODALIDADCOMPRA") Is DBNull.Value, Nothing, dr("NUMEROMODALIDADCOMPRA"))
                mEntidad.MONTOCONTRATO = IIf(dr("MONTOCONTRATO") Is DBNull.Value, Nothing, dr("MONTOCONTRATO"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                mEntidad.ACTANOTARIAL = IIf(dr("ACTANOTARIAL") Is DBNull.Value, Nothing, dr("ACTANOTARIAL"))
                mEntidad.RESOLUCION = IIf(dr("RESOLUCION") Is DBNull.Value, Nothing, dr("RESOLUCION"))
                mEntidad.MODIFICATIVA = IIf(dr("MODIFICATIVA") Is DBNull.Value, Nothing, dr("MODIFICATIVA"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR

        Dim tables(0) As String
        tables(0) = New String("CONTRATOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" NUMEROCONTRATO, ")
        strSQL.Append(" IDTIPODOCUMENTO, ")
        strSQL.Append(" IDPLANTILLA, ")
        strSQL.Append(" TIPOPERSONA, ")
        strSQL.Append(" REPRESENTANTELEGAL, ")
        strSQL.Append(" PERSONERIAJURIDICA, ")
        strSQL.Append(" FECHAGENERACION, ")
        strSQL.Append(" FECHAAPROBACION, ")
        strSQL.Append(" FECHADISTRIBUCION, ")
        strSQL.Append(" CODIGOLICITACION, ")
        strSQL.Append(" FECHAINICIOENTREGA, ")
        strSQL.Append(" IDESTADOCONTRATO, ")
        strSQL.Append(" IDCALIFICACIONCUMPLIMIENTO, ")
        strSQL.Append(" IDCALIFICACIONCALIDAD, ")
        strSQL.Append(" IDMODALIDADCOMPRA, ")
        strSQL.Append(" NUMEROMODALIDADCOMPRA, ")
        strSQL.Append(" MONTOCONTRATO, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA, ")
        strSQL.Append(" ACTANOTARIAL, ")
        strSQL.Append(" RESOLUCION, ")
        strSQL.Append(" MODIFICATIVA ")
        strSQL.Append(" FROM SAB_UACI_CONTRATOS ")

    End Sub

#End Region

End Class
