Imports System.Text
''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_DL
''' Class	 : DL.dbGARANTIASCONTRATOS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Acceso a Datos que contiene las operaciones CRUD(Create, Read,
''' Update y Delete) de la tabla SAB_UACI_GARANTIASCONTRATOS
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	10/03/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class dbGARANTIASCONTRATOS
    Inherits dbBase

#Region " Metodos Generador "

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As GARANTIASCONTRATOS
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDGARANTIACONTRATO = 0 _
            Or lEntidad.IDGARANTIACONTRATO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDGARANTIACONTRATO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_UACI_GARANTIASCONTRATOS ")
        strSQL.Append(" SET IDMODIFICATIVA = @IDMODIFICATIVA, ")
        strSQL.Append(" NUMEROGARANTIA = @NUMEROGARANTIA, ")
        strSQL.Append(" IDESTADOGARANTIA = @IDESTADOGARANTIA, ")
        strSQL.Append(" FECHAENTREGA = @FECHAENTREGA, ")
        strSQL.Append(" FECHARECEPCION = @FECHARECEPCION, ")
        strSQL.Append(" MONTO = @MONTO, ")
        strSQL.Append(" VIGENCIA = @VIGENCIA, ")
        strSQL.Append(" FECHAVENCIMIENTO = @FECHAVENCIMIENTO, ")
        strSQL.Append(" ASEGURADORA = @ASEGURADORA, ")
        strSQL.Append(" FECHAEFECTIVA = @FECHAEFECTIVA, ")
        strSQL.Append(" JUSTIFICACIONEFECTIVA = @JUSTIFICACIONEFECTIVA, ")
        strSQL.Append(" FECHADEVOLUCION = @FECHADEVOLUCION, ")
        strSQL.Append(" JUSTIFICACIONDEVOLUCION = @JUSTIFICACIONDEVOLUCION, ")
        strSQL.Append(" CLASEGARANTIA = @CLASEGARANTIA, ")
        strSQL.Append(" PORCENTAJE = @PORCENTAJE, ")
        strSQL.Append(" ENTREGA = @ENTREGA, ")
        strSQL.Append(" AUUSUARIOCREACION = @AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION = @AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION = @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION = @AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA = @ESTASINCRONIZADA ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append(" AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")

        Dim args(25) As SqlParameter
        args(0) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(0).Value = IIf(lEntidad.IDMODIFICATIVA = Nothing, DBNull.Value, lEntidad.IDMODIFICATIVA)
        args(1) = New SqlParameter("@NUMEROGARANTIA", SqlDbType.VarChar)
        args(1).Value = lEntidad.NUMEROGARANTIA
        args(2) = New SqlParameter("@IDESTADOGARANTIA", SqlDbType.SmallInt)
        args(2).Value = lEntidad.IDESTADOGARANTIA
        args(3) = New SqlParameter("@FECHAENTREGA", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.FECHAENTREGA = Nothing, DBNull.Value, lEntidad.FECHAENTREGA)
        args(4) = New SqlParameter("@FECHARECEPCION", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.FECHARECEPCION = Nothing, DBNull.Value, lEntidad.FECHARECEPCION)
        args(5) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args(5).Value = lEntidad.MONTO
        args(6) = New SqlParameter("@VIGENCIA", SqlDbType.SmallInt)
        args(6).Value = lEntidad.VIGENCIA
        args(7) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(7).Value = IIf(lEntidad.FECHAVENCIMIENTO = Nothing, DBNull.Value, lEntidad.FECHAVENCIMIENTO)
        args(8) = New SqlParameter("@ASEGURADORA", SqlDbType.VarChar)
        args(8).Value = IIf(lEntidad.ASEGURADORA = Nothing, DBNull.Value, lEntidad.ASEGURADORA)
        args(9) = New SqlParameter("@FECHAEFECTIVA", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.FECHAEFECTIVA = Nothing, DBNull.Value, lEntidad.FECHAEFECTIVA)
        args(10) = New SqlParameter("@JUSTIFICACIONEFECTIVA", SqlDbType.VarChar)
        args(10).Value = IIf(lEntidad.JUSTIFICACIONEFECTIVA = Nothing, DBNull.Value, lEntidad.JUSTIFICACIONEFECTIVA)
        args(11) = New SqlParameter("@FECHADEVOLUCION", SqlDbType.DateTime)
        args(11).Value = IIf(lEntidad.FECHADEVOLUCION = Nothing, DBNull.Value, lEntidad.FECHADEVOLUCION)
        args(12) = New SqlParameter("@JUSTIFICACIONDEVOLUCION", SqlDbType.VarChar)
        args(12).Value = IIf(lEntidad.JUSTIFICACIONDEVOLUCION = Nothing, DBNull.Value, lEntidad.JUSTIFICACIONDEVOLUCION)
        args(13) = New SqlParameter("@CLASEGARANTIA", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.CLASEGARANTIA = Nothing, DBNull.Value, lEntidad.CLASEGARANTIA)
        args(14) = New SqlParameter("@PORCENTAJE", SqlDbType.Decimal)
        args(14).Value = IIf(lEntidad.PORCENTAJE = Nothing, DBNull.Value, lEntidad.PORCENTAJE)
        args(15) = New SqlParameter("@ENTREGA", SqlDbType.TinyInt)
        args(15).Value = IIf(lEntidad.ENTREGA = Nothing, DBNull.Value, lEntidad.ENTREGA)
        args(16) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(16).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(17) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(17).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(18) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(18).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(19) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(19).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(20) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(20).Value = lEntidad.ESTASINCRONIZADA
        args(21) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(21).Value = lEntidad.IDESTABLECIMIENTO
        args(22) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(22).Value = lEntidad.IDPROVEEDOR
        args(23) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(23).Value = lEntidad.IDCONTRATO
        args(24) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(24).Value = lEntidad.IDTIPOGARANTIA
        args(25) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(25).Value = lEntidad.IDGARANTIACONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As GARANTIASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_UACI_GARANTIASCONTRATOS ")
        strSQL.Append(" ( IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDTIPOGARANTIA, ")
        strSQL.Append(" IDGARANTIACONTRATO, ")
        strSQL.Append(" IDMODIFICATIVA, ")
        strSQL.Append(" NUMEROGARANTIA, ")
        strSQL.Append(" IDESTADOGARANTIA, ")
        strSQL.Append(" FECHAENTREGA, ")
        strSQL.Append(" FECHARECEPCION, ")
        strSQL.Append(" MONTO, ")
        strSQL.Append(" VIGENCIA, ")
        strSQL.Append(" FECHAVENCIMIENTO, ")
        strSQL.Append(" ASEGURADORA, ")
        strSQL.Append(" FECHAEFECTIVA, ")
        strSQL.Append(" JUSTIFICACIONEFECTIVA, ")
        strSQL.Append(" FECHADEVOLUCION, ")
        strSQL.Append(" JUSTIFICACIONDEVOLUCION, ")
        strSQL.Append(" CLASEGARANTIA, ")
        strSQL.Append(" PORCENTAJE, ")
        strSQL.Append(" ENTREGA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA) ")
        strSQL.Append(" VALUES ")
        strSQL.Append(" ( @IDESTABLECIMIENTO, ")
        strSQL.Append(" @IDPROVEEDOR, ")
        strSQL.Append(" @IDCONTRATO, ")
        strSQL.Append(" @IDTIPOGARANTIA, ")
        strSQL.Append(" @IDGARANTIACONTRATO, ")
        strSQL.Append(" @IDMODIFICATIVA, ")
        strSQL.Append(" @NUMEROGARANTIA, ")
        strSQL.Append(" @IDESTADOGARANTIA, ")
        strSQL.Append(" @FECHAENTREGA, ")
        strSQL.Append(" @FECHARECEPCION, ")
        strSQL.Append(" @MONTO, ")
        strSQL.Append(" @VIGENCIA, ")
        strSQL.Append(" @FECHAVENCIMIENTO, ")
        strSQL.Append(" @ASEGURADORA, ")
        strSQL.Append(" @FECHAEFECTIVA, ")
        strSQL.Append(" @JUSTIFICACIONEFECTIVA, ")
        strSQL.Append(" @FECHADEVOLUCION, ")
        strSQL.Append(" @JUSTIFICACIONDEVOLUCION, ")
        strSQL.Append(" @CLASEGARANTIA, ")
        strSQL.Append(" @PORCENTAJE, ")
        strSQL.Append(" @ENTREGA, ")
        strSQL.Append(" @AUUSUARIOCREACION, ")
        strSQL.Append(" @AUFECHACREACION, ")
        strSQL.Append(" @AUUSUARIOMODIFICACION, ")
        strSQL.Append(" @AUFECHAMODIFICACION, ")
        strSQL.Append(" @ESTASINCRONIZADA) ")

        Dim args(25) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = lEntidad.IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = lEntidad.IDGARANTIACONTRATO
        args(5) = New SqlParameter("@IDMODIFICATIVA", SqlDbType.BigInt)
        args(5).Value = IIf(lEntidad.IDMODIFICATIVA = Nothing, DBNull.Value, lEntidad.IDMODIFICATIVA)
        args(6) = New SqlParameter("@NUMEROGARANTIA", SqlDbType.VarChar)
        args(6).Value = lEntidad.NUMEROGARANTIA
        args(7) = New SqlParameter("@IDESTADOGARANTIA", SqlDbType.SmallInt)
        args(7).Value = lEntidad.IDESTADOGARANTIA
        args(8) = New SqlParameter("@FECHAENTREGA", SqlDbType.DateTime)
        args(8).Value = IIf(lEntidad.FECHAENTREGA = Nothing, DBNull.Value, lEntidad.FECHAENTREGA)
        args(9) = New SqlParameter("@FECHARECEPCION", SqlDbType.DateTime)
        args(9).Value = IIf(lEntidad.FECHARECEPCION = Nothing, DBNull.Value, lEntidad.FECHARECEPCION)
        args(10) = New SqlParameter("@MONTO", SqlDbType.Decimal)
        args(10).Value = lEntidad.MONTO
        args(11) = New SqlParameter("@VIGENCIA", SqlDbType.SmallInt)
        args(11).Value = lEntidad.VIGENCIA
        args(12) = New SqlParameter("@FECHAVENCIMIENTO", SqlDbType.DateTime)
        args(12).Value = IIf(lEntidad.FECHAVENCIMIENTO = Nothing, DBNull.Value, lEntidad.FECHAVENCIMIENTO)
        args(13) = New SqlParameter("@ASEGURADORA", SqlDbType.VarChar)
        args(13).Value = IIf(lEntidad.ASEGURADORA = Nothing, DBNull.Value, lEntidad.ASEGURADORA)
        args(14) = New SqlParameter("@FECHAEFECTIVA", SqlDbType.DateTime)
        args(14).Value = IIf(lEntidad.FECHAEFECTIVA = Nothing, DBNull.Value, lEntidad.FECHAEFECTIVA)
        args(15) = New SqlParameter("@JUSTIFICACIONEFECTIVA", SqlDbType.VarChar)
        args(15).Value = IIf(lEntidad.JUSTIFICACIONEFECTIVA = Nothing, DBNull.Value, lEntidad.JUSTIFICACIONEFECTIVA)
        args(16) = New SqlParameter("@FECHADEVOLUCION", SqlDbType.DateTime)
        args(16).Value = IIf(lEntidad.FECHADEVOLUCION = Nothing, DBNull.Value, lEntidad.FECHADEVOLUCION)
        args(17) = New SqlParameter("@JUSTIFICACIONDEVOLUCION", SqlDbType.VarChar)
        args(17).Value = IIf(lEntidad.JUSTIFICACIONDEVOLUCION = Nothing, DBNull.Value, lEntidad.JUSTIFICACIONDEVOLUCION)
        args(18) = New SqlParameter("@CLASEGARANTIA", SqlDbType.VarChar)
        args(18).Value = IIf(lEntidad.CLASEGARANTIA = Nothing, DBNull.Value, lEntidad.CLASEGARANTIA)
        args(19) = New SqlParameter("@PORCENTAJE", SqlDbType.Decimal)
        args(19).Value = IIf(lEntidad.PORCENTAJE = Nothing, DBNull.Value, lEntidad.PORCENTAJE)
        args(20) = New SqlParameter("@ENTREGA", SqlDbType.TinyInt)
        args(20).Value = IIf(lEntidad.ENTREGA = Nothing, DBNull.Value, lEntidad.ENTREGA)
        args(21) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(21).Value = IIf(lEntidad.AUUSUARIOCREACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOCREACION)
        args(22) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(22).Value = IIf(lEntidad.AUFECHACREACION = Nothing, DBNull.Value, lEntidad.AUFECHACREACION)
        args(23) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(23).Value = IIf(lEntidad.AUUSUARIOMODIFICACION = Nothing, DBNull.Value, lEntidad.AUUSUARIOMODIFICACION)
        args(24) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(24).Value = IIf(lEntidad.AUFECHAMODIFICACION = Nothing, DBNull.Value, lEntidad.AUFECHAMODIFICACION)
        args(25) = New SqlParameter("@ESTASINCRONIZADA", SqlDbType.SmallInt)
        args(25).Value = lEntidad.ESTASINCRONIZADA

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As GARANTIASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_UACI_GARANTIASCONTRATOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append(" AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = lEntidad.IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = lEntidad.IDGARANTIACONTRATO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As GARANTIASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")
        strSQL.Append(" AND IDGARANTIACONTRATO = @IDGARANTIACONTRATO ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = lEntidad.IDTIPOGARANTIA
        args(4) = New SqlParameter("@IDGARANTIACONTRATO", SqlDbType.Int)
        args(4).Value = lEntidad.IDGARANTIACONTRATO

        Dim dsDatos As DataSet

        dsDatos = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        If dsDatos.Tables(0).Rows.Count = 0 Then Return 0

        Try
            With dsDatos.Tables(0).Rows(0)
                lEntidad.IDMODIFICATIVA = IIf(.Item("IDMODIFICATIVA") Is DBNull.Value, Nothing, .Item("IDMODIFICATIVA"))
                lEntidad.NUMEROGARANTIA = IIf(.Item("NUMEROGARANTIA") Is DBNull.Value, Nothing, .Item("NUMEROGARANTIA"))
                lEntidad.IDESTADOGARANTIA = IIf(.Item("IDESTADOGARANTIA") Is DBNull.Value, Nothing, .Item("IDESTADOGARANTIA"))
                lEntidad.FECHAENTREGA = IIf(.Item("FECHAENTREGA") Is DBNull.Value, Nothing, .Item("FECHAENTREGA"))
                lEntidad.FECHARECEPCION = IIf(.Item("FECHARECEPCION") Is DBNull.Value, Nothing, .Item("FECHARECEPCION"))
                lEntidad.MONTO = IIf(.Item("MONTO") Is DBNull.Value, Nothing, .Item("MONTO"))
                lEntidad.VIGENCIA = IIf(.Item("VIGENCIA") Is DBNull.Value, Nothing, .Item("VIGENCIA"))
                lEntidad.FECHAVENCIMIENTO = IIf(.Item("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, .Item("FECHAVENCIMIENTO"))
                lEntidad.ASEGURADORA = IIf(.Item("ASEGURADORA") Is DBNull.Value, Nothing, .Item("ASEGURADORA"))
                lEntidad.FECHAEFECTIVA = IIf(.Item("FECHAEFECTIVA") Is DBNull.Value, Nothing, .Item("FECHAEFECTIVA"))
                lEntidad.JUSTIFICACIONEFECTIVA = IIf(.Item("JUSTIFICACIONEFECTIVA") Is DBNull.Value, Nothing, .Item("JUSTIFICACIONEFECTIVA"))
                lEntidad.FECHADEVOLUCION = IIf(.Item("FECHADEVOLUCION") Is DBNull.Value, Nothing, .Item("FECHADEVOLUCION"))
                lEntidad.JUSTIFICACIONDEVOLUCION = IIf(.Item("JUSTIFICACIONDEVOLUCION") Is DBNull.Value, Nothing, .Item("JUSTIFICACIONDEVOLUCION"))
                lEntidad.CLASEGARANTIA = IIf(.Item("CLASEGARANTIA") Is DBNull.Value, Nothing, .Item("CLASEGARANTIA"))
                lEntidad.PORCENTAJE = IIf(.Item("PORCENTAJE") Is DBNull.Value, Nothing, .Item("PORCENTAJE"))
                lEntidad.ENTREGA = IIf(.Item("ENTREGA") Is DBNull.Value, Nothing, .Item("ENTREGA"))
                lEntidad.AUUSUARIOCREACION = IIf(.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOCREACION"))
                lEntidad.AUFECHACREACION = IIf(.Item("AUFECHACREACION") Is DBNull.Value, Nothing, .Item("AUFECHACREACION"))
                lEntidad.AUUSUARIOMODIFICACION = IIf(.Item("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, .Item("AUUSUARIOMODIFICACION"))
                lEntidad.AUFECHAMODIFICACION = IIf(.Item("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, .Item("AUFECHAMODIFICACION"))
                lEntidad.ESTASINCRONIZADA = IIf(.Item("ESTASINCRONIZADA") Is DBNull.Value, Nothing, .Item("ESTASINCRONIZADA"))
            End With
        Catch ex As Exception
            Throw ex
        End Try

        Return 1

    End Function

    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As GARANTIASCONTRATOS
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDGARANTIACONTRATO),0) + 1 ")
        strSQL.Append(" FROM SAB_UACI_GARANTIASCONTRATOS ")
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = lEntidad.IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = lEntidad.IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = lEntidad.IDTIPOGARANTIA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Function ObtenerListaPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16) As listaGARANTIASCONTRATOS

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = IDTIPOGARANTIA

        Dim dr As SqlDataReader

        dr = SqlHelper.ExecuteReader(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Dim lista As New listaGARANTIASCONTRATOS

        Try
            Do While dr.Read()
                Dim mEntidad As New GARANTIASCONTRATOS
                mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                mEntidad.IDPROVEEDOR = IDPROVEEDOR
                mEntidad.IDCONTRATO = IDCONTRATO
                mEntidad.IDTIPOGARANTIA = IDTIPOGARANTIA
                mEntidad.IDGARANTIACONTRATO = IIf(dr("IDGARANTIACONTRATO") Is DBNull.Value, Nothing, dr("IDGARANTIACONTRATO"))
                mEntidad.IDMODIFICATIVA = IIf(dr("IDMODIFICATIVA") Is DBNull.Value, Nothing, dr("IDMODIFICATIVA"))
                mEntidad.NUMEROGARANTIA = IIf(dr("NUMEROGARANTIA") Is DBNull.Value, Nothing, dr("NUMEROGARANTIA"))
                mEntidad.IDESTADOGARANTIA = IIf(dr("IDESTADOGARANTIA") Is DBNull.Value, Nothing, dr("IDESTADOGARANTIA"))
                mEntidad.FECHAENTREGA = IIf(dr("FECHAENTREGA") Is DBNull.Value, Nothing, dr("FECHAENTREGA"))
                mEntidad.FECHARECEPCION = IIf(dr("FECHARECEPCION") Is DBNull.Value, Nothing, dr("FECHARECEPCION"))
                mEntidad.MONTO = IIf(dr("MONTO") Is DBNull.Value, Nothing, dr("MONTO"))
                mEntidad.VIGENCIA = IIf(dr("VIGENCIA") Is DBNull.Value, Nothing, dr("VIGENCIA"))
                mEntidad.FECHAVENCIMIENTO = IIf(dr("FECHAVENCIMIENTO") Is DBNull.Value, Nothing, dr("FECHAVENCIMIENTO"))
                mEntidad.ASEGURADORA = IIf(dr("ASEGURADORA") Is DBNull.Value, Nothing, dr("ASEGURADORA"))
                mEntidad.FECHAEFECTIVA = IIf(dr("FECHAEFECTIVA") Is DBNull.Value, Nothing, dr("FECHAEFECTIVA"))
                mEntidad.JUSTIFICACIONEFECTIVA = IIf(dr("JUSTIFICACIONEFECTIVA") Is DBNull.Value, Nothing, dr("JUSTIFICACIONEFECTIVA"))
                mEntidad.FECHADEVOLUCION = IIf(dr("FECHADEVOLUCION") Is DBNull.Value, Nothing, dr("FECHADEVOLUCION"))
                mEntidad.JUSTIFICACIONDEVOLUCION = IIf(dr("JUSTIFICACIONDEVOLUCION") Is DBNull.Value, Nothing, dr("JUSTIFICACIONDEVOLUCION"))
                mEntidad.CLASEGARANTIA = IIf(dr("CLASEGARANTIA") Is DBNull.Value, Nothing, dr("CLASEGARANTIA"))
                mEntidad.PORCENTAJE = IIf(dr("PORCENTAJE") Is DBNull.Value, Nothing, dr("PORCENTAJE"))
                mEntidad.ENTREGA = IIf(dr("ENTREGA") Is DBNull.Value, Nothing, dr("ENTREGA"))
                mEntidad.AUUSUARIOCREACION = IIf(dr("AUUSUARIOCREACION") Is DBNull.Value, Nothing, dr("AUUSUARIOCREACION"))
                mEntidad.AUFECHACREACION = IIf(dr("AUFECHACREACION") Is DBNull.Value, Nothing, dr("AUFECHACREACION"))
                mEntidad.AUUSUARIOMODIFICACION = IIf(dr("AUUSUARIOMODIFICACION") Is DBNull.Value, Nothing, dr("AUUSUARIOMODIFICACION"))
                mEntidad.AUFECHAMODIFICACION = IIf(dr("AUFECHAMODIFICACION") Is DBNull.Value, Nothing, dr("AUFECHAMODIFICACION"))
                mEntidad.ESTASINCRONIZADA = IIf(dr("ESTASINCRONIZADA") Is DBNull.Value, Nothing, dr("ESTASINCRONIZADA"))
                lista.Add(mEntidad)
            Loop
        Catch ex As Exception
            Throw ex
        Finally
            dr.Close()
        End Try

        Return lista

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = IDTIPOGARANTIA

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function

    Public Function ObtenerDataSetPorID(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal IDTIPOGARANTIA As Int16, ByRef ds As DataSet) As Integer

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDESTABLECIMIENTO = @IDESTABLECIMIENTO ")
        strSQL.Append(" AND IDPROVEEDOR = @IDPROVEEDOR ")
        strSQL.Append(" AND IDCONTRATO = @IDCONTRATO ")
        strSQL.Append(" AND IDTIPOGARANTIA = @IDTIPOGARANTIA ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDESTABLECIMIENTO", SqlDbType.Int)
        args(0).Value = IDESTABLECIMIENTO
        args(1) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(1).Value = IDPROVEEDOR
        args(2) = New SqlParameter("@IDCONTRATO", SqlDbType.BigInt)
        args(2).Value = IDCONTRATO
        args(3) = New SqlParameter("@IDTIPOGARANTIA", SqlDbType.SmallInt)
        args(3).Value = IDTIPOGARANTIA

        Dim tables(0) As String
        tables(0) = New String("GARANTIASCONTRATOS")

        SqlHelper.FillDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), ds, tables, args)

        Return 1

    End Function

    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDESTABLECIMIENTO, ")
        strSQL.Append(" IDPROVEEDOR, ")
        strSQL.Append(" IDCONTRATO, ")
        strSQL.Append(" IDTIPOGARANTIA, ")
        strSQL.Append(" IDGARANTIACONTRATO, ")
        strSQL.Append(" IDMODIFICATIVA, ")
        strSQL.Append(" NUMEROGARANTIA, ")
        strSQL.Append(" IDESTADOGARANTIA, ")
        strSQL.Append(" FECHAENTREGA, ")
        strSQL.Append(" FECHARECEPCION, ")
        strSQL.Append(" MONTO, ")
        strSQL.Append(" VIGENCIA, ")
        strSQL.Append(" FECHAVENCIMIENTO, ")
        strSQL.Append(" ASEGURADORA, ")
        strSQL.Append(" FECHAEFECTIVA, ")
        strSQL.Append(" JUSTIFICACIONEFECTIVA, ")
        strSQL.Append(" FECHADEVOLUCION, ")
        strSQL.Append(" JUSTIFICACIONDEVOLUCION, ")
        strSQL.Append(" CLASEGARANTIA, ")
        strSQL.Append(" PORCENTAJE, ")
        strSQL.Append(" ENTREGA, ")
        strSQL.Append(" AUUSUARIOCREACION, ")
        strSQL.Append(" AUFECHACREACION, ")
        strSQL.Append(" AUUSUARIOMODIFICACION, ")
        strSQL.Append(" AUFECHAMODIFICACION, ")
        strSQL.Append(" ESTASINCRONIZADA ")
        strSQL.Append(" FROM SAB_UACI_GARANTIASCONTRATOS ")

    End Sub

#End Region

End Class

