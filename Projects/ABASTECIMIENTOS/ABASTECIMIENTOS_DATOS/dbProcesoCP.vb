Imports System.Text
Public Class dbProcesoCP
    Inherits dbBase

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
        Dim lEntidad As PROCESOCP
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDPROCESO = 0 _
            Or lEntidad.IDPROCESO = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDPROCESO = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CP_PROCESO ")
        strSQL.Append(" SET ESTADO = @ESTADO, FECHAFIN=@FECHAFIN, COMENTARIO=@COMENTARIO  ")
        strSQL.Append(" WHERE IDPROCESO = @IDPROCESO AND IDTIPOPRODUCTO=@IDTIPOPRODUCTO ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROCESO
        args(1) = New SqlParameter("@IDTIPOPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOPRODUCTO
        args(2) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(2).Value = lEntidad.ESTADO
        args(3) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(3).Value = IIf(lEntidad.FECHAINICIO = Nothing, DBNull.Value, lEntidad.FECHAINICIO)
        args(4) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(4).Value = lEntidad.FECHAFIN
        args(5) = New SqlParameter("@COMENTARIO", SqlDbType.VarChar)
        args(5).Value = lEntidad.COMENTARIO
        args(6) = New SqlParameter("@NUMPROCESO", SqlDbType.VarChar)
        args(6).Value = lEntidad.NUMPROCESO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROCESOCP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CP_PROCESO ")
        strSQL.Append(" values (@IDPROCESO,@IDTIPOPRODUCTO,@ESTADO,@FECHAINICIO, @FECHAFIN,@COMENTARIO, @NUMPROCESO ) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROCESO
        args(1) = New SqlParameter("@IDTIPOPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOPRODUCTO
        args(2) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(2).Value = lEntidad.ESTADO
        args(3) = New SqlParameter("@FECHAINICIO", SqlDbType.DateTime)
        args(3).Value = lEntidad.FECHAINICIO
        args(4) = New SqlParameter("@FECHAFIN", SqlDbType.DateTime)
        args(4).Value = IIf(lEntidad.FECHAFIN = Nothing, DBNull.Value, lEntidad.FECHAFIN)
        args(5) = New SqlParameter("@COMENTARIO", SqlDbType.VarChar)
        args(5).Value = lEntidad.COMENTARIO
        args(6) = New SqlParameter("@NUMPROCESO", SqlDbType.VarChar)
        args(6).Value = lEntidad.NUMPROCESO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As PROCESOCP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_PROCESO ")
        strSQL.Append(" WHERE IDPROCESO = @IDPROCESO AND IDTIPOPRODUCTO=@IDTIPOPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROCESO
        args(1) = New SqlParameter("@IDTIPOPRODUCTO", SqlDbType.Int)
        args(1).Value = lEntidad.IDTIPOPRODUCTO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT * ")
        strSQL.Append(" FROM SAB_CP_PROCESO ")

    End Sub
    Public Function ObtenerDataSetPorID() As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function BuscarEstadoTipoProducto(ByVal idtipoproducto As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT estado ")
        strSQL.Append(" FROM SAB_CP_PROCESO where idtipoproducto=" & idtipoproducto)

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As PROCESOCP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDPROCESO),0) + 1 ")
        strSQL.Append(" FROM SAB_CP_PROCESO ")
        strSQL.Append(" WHERE IDTIPOPRODUCTO=@IDTIPOPRODUCTO ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOPRODUCTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOPRODUCTO

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function

    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

    End Function


    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

    End Function
    Public Function ObtenerDataSetPorID2(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT A.IDPROCESO, A.NUMPROCESO, A.IDTIPOPRODUCTO, CASE WHEN A.ESTADO=0 THEN 'ABIERTO' ELSE 'CERRADO' END AS ESTADO, A.FECHAINICIO, A.FECHAFIN, L.DESCRIPCION AS TIPOPRODUCTO ")
        strSQL.Append(" FROM SAB_CP_PROCESO A INNER JOIN SAB_CAT_SUMINISTROS  L ")
        strSQL.Append(" ON A.IDTIPOPRODUCTO=L.IDSUMINISTRO  ")
        strSQL.Append(" WHERE A.IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " and A.IDPROCESO=" & IDPROCESO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerDataSetPorID3(ByVal IDTIPOPRODUCTO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDTIPOPRODUCTO=" & IDTIPOPRODUCTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerID2(ByVal IDTIPOPRODUCTO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDPROCESO),0) + 1 ")
        strSQL.Append(" FROM SAB_CP_PROCESO WHERE IDTIPOPRODUCTO=" & IDTIPOPRODUCTO)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    'Public Function ObtenerListas() As DataSet

    '    Dim strSQL As New StringBuilder
    '    strSQL.Append("SELECT IDLISTA, NOMBRE  ")
    '    strSQL.Append(" FROM SAB_CP_CAT_LISTA ")

    '    Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    'End Function

    Public Function ObtenerPROCESO() As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT A.IDPROCESO, A.NUMPROCESO, A.IDTIPOPRODUCTO, CASE WHEN A.ESTADO=0 THEN 'ABIERTO' ELSE 'CERRADO' END AS ESTADO, A.FECHAINICIO, A.FECHAFIN, L.DESCRIPCION AS TIPOPRODUCTO ")
        strSQL.Append(" FROM SAB_CP_PROCESO A INNER JOIN SAB_CAT_SUMINISTROS  L ")
        strSQL.Append(" ON A.IDTIPOPRODUCTO=L.IDSUMINISTRO ORDER BY A.ESTADO ")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerPROCESOFiltrados(Optional ByVal idt As Integer = 0, Optional ByVal idestado As Integer = -1) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT A.IDPROCESO, A.NUMPROCESO, A.IDTIPOPRODUCTO, CASE WHEN A.ESTADO=0 THEN 'ABIERTO' ELSE 'CERRADO' END AS ESTADO, A.FECHAINICIO, A.FECHAFIN, L.DESCRIPCION AS TIPOPRODUCTO ")
        strSQL.Append(" FROM SAB_CP_PROCESO A INNER JOIN SAB_CAT_SUMINISTROS  L ")
        strSQL.Append(" ON A.IDTIPOPRODUCTO=L.IDSUMINISTRO  ")
        strSQL.Append(" WHERE (IDTIPOPRODUCTO=@IDTIPOPRODUCTO OR @IDTIPOPRODUCTO=0) ")
        strSQL.Append(" AND (ESTADO=@ESTADO OR @ESTADO=-1) ")
        strSQL.Append(" ORDER BY A.ESTADO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOPRODUCTO", SqlDbType.Int)
        args(0).Value = idt
        args(1) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(1).Value = idestado

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds
    End Function

    Public Function ObtenerDataSetProveedores(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer, Optional ByVal NIT As String = "", Optional ByVal nombre As String = "") As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT P.NIT, P.NOMBRE as proveedor, ")


        strSQL.Append(" PP.PRODUCTOSC,PP.PRODUCTOSN, ")
        strSQL.Append(" PP.IDPROCESO, PP.IDTIPOPRODUCTO, PP.IDPROVEEDOR")

        strSQL.Append(" FROM SAB_CP_PROVEEDORESPROCESO pp INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append(" ON PP.IDPROVEEDOR=P.IDPROVEEDOR  ")
        strSQL.Append(" WHERE PP.IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " and PP.IDPROCESO=" & IDPROCESO)

        If NIT <> "" Then
            strSQL.Append(" AND P.NIT='" & NIT & "'")
        End If

        If nombre <> "" Then
            strSQL.Append(" AND P.NOMBRE LIKE '%" & nombre & "%'")
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerProveedoresSINAB(ByVal NIT As String, ByVal nombre As String) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT CASE WHEN P.NIT='' THEN '-' ELSE P.NIT END AS NIT, P.NOMBRE, P.IDPROVEEDOR ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES P ")
        strSQL.Append(" WHERE (P.NIT='" & NIT & "' OR P.NOMBRE like '%" & nombre & "%')")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function AgregarProveedoresProceso(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CP_PROVEEDORESPROCESO ")
        strSQL.Append(" values (@IDPROCESO,@IDTIPOPRODUCTO,@IDPROVEEDOR,0,0) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(0).Value = idproceso
        args(1) = New SqlParameter("@IDTIPOPRODUCTO", SqlDbType.Int)
        args(1).Value = idtipoproducto
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = idproveedor
       

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerNITyNombre(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer, ByVal idproveedor As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT P.NIT, P.NOMBRE as proveedor ")
        strSQL.Append(" FROM SAB_CP_PROVEEDORESPROCESO pp INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append(" ON PP.IDPROVEEDOR=P.IDPROVEEDOR  ")
        strSQL.Append(" WHERE PP.IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " and PP.IDPROCESO=" & IDPROCESO & " and pp.idproveedor=" & idproveedor)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerProveedoresxProceso(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT P.IDPROVEEDOR, P.NOMBRE  ")
        strSQL.Append(" FROM SAB_CP_PROVEEDORESPROCESO pp INNER JOIN SAB_CAT_PROVEEDORES P ")
        strSQL.Append(" ON PP.IDPROVEEDOR=P.IDPROVEEDOR  ")
        strSQL.Append(" WHERE PP.IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " and PP.IDPROCESO=" & IDPROCESO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerCodNomPais(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer, ByVal idproveedor As Integer, ByVal IDPRODUCTO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT V.CORRPRODUCTO, V.DESCLARGO, P.NOMBRE ")
        strSQL.Append(" FROM VV_CATALOGOPRODUCTOS V INNER JOIN SAB_CP_PRODUCTOSPROVEEDORES PP ")
        strSQL.Append(" ON PP.IDPRODUCTO=V.IDPRODUCTO ")
        strSQL.Append(" INNER JOIN SAB_CP_CAT_PAIS P ON P.IDPAIS=PP.IDPAIS ")
        strSQL.Append(" WHERE PP.IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " and PP.IDPROCESO=" & IDPROCESO & " and pp.idproveedor=" & idproveedor & " AND PP.IDPRODUCTO=" & IDPRODUCTO)


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerIdAspectos() As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT ISNULL(MAX(IDASPECTOS),0)+1  ")
        strSQL.Append(" FROM SAB_CP_ASPECTOSPRODUCTOS ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerDataSetProductos(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, Optional ByVal CODIGO As String = "", Optional ByVal NOMBRE As String = "") As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT PP.IDPROCESO, PP.IDTIPOPRODUCTO, PP.IDPROVEEDOR, PP.IDPRODUCTO, pp.id, CP.CORRPRODUCTO AS CODIGO, CP.DESCLARGO AS NOMBRE, ISNULL(PP.MARCA,'') AS MARCA, ISNULL(P.NOMBRE,'') AS PAIS, ")
        strSQL.Append(" ( ")
        strSQL.Append(" SELECT CASE WHEN ESTADO=0 THEN 'CERTIFICADO' ELSE 'NO CERTIFICADO' END AS ESTADO ")
        strSQL.Append(" FROM SAB_CP_ESTADOSPRODUCTOS ")
        strSQL.Append(" WHERE IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " and IDPROCESO=" & IDPROCESO & " AND IDPROVEEDOR= " & IDPROVEEDOR & " AND IDPRODUCTO=PP.IDPRODUCTO AND ID=PP.ID AND FECHA= ")
        strSQL.Append(" ( ")
        strSQL.Append(" SELECT MAX(FECHA) ")
        strSQL.Append(" FROM SAB_CP_ESTADOSPRODUCTOS ")
        strSQL.Append(" WHERE IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " and IDPROCESO=" & IDPROCESO & " AND IDPROVEEDOR= " & IDPROVEEDOR & " AND IDPRODUCTO=PP.IDPRODUCTO AND ID=PP.ID ")
        strSQL.Append(" ) ")
        strSQL.Append(" ) as ESTADO ")

        strSQL.Append(" FROM SAB_CP_PRODUCTOSPROVEEDORES PP INNER JOIN VV_CATALOGOPRODUCTOS CP ON ")
        strSQL.Append(" PP.IDPRODUCTO = CP.IDPRODUCTO ")
        'strSQL.Append(" INNER JOIN SAB_CP_ESTADOSPRODUCTOS E ON E.IDESTADOPRODUCTO=PP.IDESTADOPRODUCTO ")
        strSQL.Append(" LEFT OUTER JOIN SAB_CP_CAT_PAIS P ON P.IDPAIS=PP.IDPAIS ")

        strSQL.Append(" WHERE PP.IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " and PP.IDPROCESO=" & IDPROCESO & " AND PP.IDPROVEEDOR= " & IDPROVEEDOR)

        If CODIGO <> "" Then
            strSQL.Append(" AND CP.CORRPRODUCTO='" & CODIGO & "'")
        End If

        If NOMBRE <> "" Then
            strSQL.Append(" AND CP.DESCLARGO LIKE '%" & NOMBRE & "%'")
        End If


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerProductosSINAB(ByVal Codigo As String, ByVal nombre As String) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT v.idproducto, v.corrproducto as codigo, v.desclargo, v.descripcion as um ")
        strSQL.Append(" FROM vv_CATALOGOPRODUCTOS V inner join SAB_UACI_GRUPOREQTEC_PRODUCTOS gp on gp.idproducto=v.idproducto ")
        strSQL.Append(" WHERE V.PERTENECELISTADOOFICIAL=1 AND (v.corrproducto='" & Codigo & "' OR v.desclargo like '%" & nombre & "%')")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function AgregarProductoProveedor(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal idlista As Integer) As Integer

        Dim strSQL2 As New StringBuilder
        strSQL2.Append(" SELECT ISNULL(MAX(ID),0)+1 FROM SAB_CP_PRODUCTOSPROVEEDORES WHERE idproceso=" & idproceso & " and idtipoproducto=" & idtipoproducto & " and idproveedor=" & idproveedor & " and idproducto=" & idproducto)
        Dim id As Integer = SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL2.ToString())

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CP_PRODUCTOSPROVEEDORES ")
        strSQL.Append(" values (@IDPROCESO,@IDTIPOPRODUCTO,@IDPROVEEDOR,@idproducto," & id & ",NULL,NULL,NULL,NULL,NULL,NULL,@idlista,NULL,NULL) ")

        Dim args(4) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(0).Value = idproceso
        args(1) = New SqlParameter("@IDTIPOPRODUCTO", SqlDbType.Int)
        args(1).Value = idtipoproducto
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = idproveedor
        args(3) = New SqlParameter("@idproducto", SqlDbType.Int)
        args(3).Value = idproducto
        args(4) = New SqlParameter("@idlista", SqlDbType.Int)
        args(4).Value = idlista

        SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)
        Return id

    End Function

    Public Function ObtenerIdLista(ByVal idproducto As Integer, ByVal IDSUMINISTRO As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT G.IDGRUPOREQ, L.NOMBRE FROM SAB_UACI_GRUPOREQTEC_PRODUCTOS G INNER JOIN SAB_CP_CAT_LISTA L ON G.IDGRUPOREQ=L.IDLISTA AND L.IDSUMINISTRO=" & IDSUMINISTRO & " WHERE G.IDPRODUCTO=" & idproducto)

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerPaises() As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IDPAIS, NOMBRE FROM SAB_CP_CAT_PAIS ")
        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    'Public Function ObtenerIdEstadosProductos() As Integer
    '    Dim strSQL As New StringBuilder
    '    strSQL.Append("SELECT ISNULL(MAX(IDESTADOPRODUCTO),0)+1 FROM SAB_CP_ESTADOSPRODUCTOS ")
    '    Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
    'End Function
    Public Function ObtenerIPC() As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT ISNULL(MAX(IPC),0)+1 FROM SAB_CP_PC ")
        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function AgregarESTADOSPRODUCTOS(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ESTADO As Integer, ByVal FECHA As DateTime, ByVal COMENTARIO As String, ByVal USUARIO As String, ByVal id As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CP_ESTADOSPRODUCTOS ")
        strSQL.Append(" values (@IDPROCESO,@IDTIPOPRODUCTO,@IDPROVEEDOR, @idproducto,@id,@ESTADO,@FECHA,@COMENTARIO,@USUARIO) ")

        Dim args(8) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(0).Value = IDPROCESO
        args(1) = New SqlParameter("@IDTIPOPRODUCTO", SqlDbType.Int)
        args(1).Value = IDTIPOPRODUCTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@idproducto", SqlDbType.Int)
        args(3).Value = IDPRODUCTO
        args(4) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(4).Value = ESTADO
        args(5) = New SqlParameter("@FECHA", SqlDbType.DateTime)
        args(5).Value = FECHA
        args(6) = New SqlParameter("@COMENTARIO", SqlDbType.Text)
        args(6).Value = COMENTARIO
        args(7) = New SqlParameter("@USUARIO", SqlDbType.Text)
        args(7).Value = USUARIO
        args(8) = New SqlParameter("@id", SqlDbType.Int)
        args(8).Value = id

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerEstadosProductos(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ID As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT CASE WHEN ESTADO=0 THEN 'CERTIFICADO' ELSE 'NO CERTIFICADO' END AS ESTADO, FECHA,COMENTARIO,USUARIO FROM SAB_CP_ESTADOSPRODUCTOS WHERE IDPROCESO=" & IDPROCESO & " AND IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " AND IDPROVEEDOR=" & IDPROVEEDOR & " AND IDPRODUCTO=" & IDPRODUCTO & " AND ID=" & ID)

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerProcesoCompra(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ID As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IdProcesoCompra, PROCESOCOMPRA FROM SAB_CP_PC WHERE  IDPROCESO=" & IDPROCESO & " AND IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " AND IDPROVEEDOR=" & IDPROVEEDOR & " AND IDPRODUCTO=" & IDPRODUCTO & " AND ID=" & ID)

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerIdEstadoProducto(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ID As Integer) As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IDESTADOPRODUCTO FROM SAB_CP_PRODUCTOSPROVEEDORES WHERE IDPROCESO=" & IDPROCESO & " AND IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " AND IDPROVEEDOR=" & IDPROVEEDOR & " AND IDPRODUCTO=" & IDPRODUCTO & " AND ID=" & ID)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerIPC(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ID As Integer) As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(idprocesocompra),0)+1 FROM SAB_CP_PC WHERE IDPROCESO=" & IDPROCESO & " AND IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " AND IDPROVEEDOR=" & IDPROVEEDOR & " AND IDPRODUCTO=" & IDPRODUCTO & " AND ID=" & ID)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ActualizarEstadoProducto(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal FLAG As Char, ByVal OPERADOR As Char) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("UPDATE  SAB_CP_PROVEEDORESPROCESO ")
        strSQL.Append(" SET PRODUCTOS" & FLAG & "=PRODUCTOS" & FLAG & " " & OPERADOR & " 1 WHERE IDPROCESO=" & IDPROCESO & " AND IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " AND IDPROVEEDOR=" & IDPROVEEDOR)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ActualizarIdAspectos(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal Idaspectos As Integer, ByVal ID As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("UPDATE  SAB_CP_PRODUCTOSPROVEEDORES ")
        strSQL.Append(" SET IdAspectos=" & Idaspectos & " WHERE IDPROCESO=" & IDPROCESO & " AND IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " AND IDPROVEEDOR=" & IDPROVEEDOR & " AND IDPRODUCTO=" & IDPRODUCTO & " AND ID=" & ID)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerUltimoEstado(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ID As Integer) As String
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT CASE WHEN ESTADO=0 THEN 'CERTIFICADO' ELSE 'NO CERTIFICADO' END AS ESTADO ")
        strSQL.Append(" FROM SAB_CP_ESTADOSPRODUCTOS ")
        strSQL.Append(" WHERE IDPROCESO=" & IDPROCESO & " AND IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " AND IDPROVEEDOR=" & IDPROVEEDOR & " AND IDPRODUCTO=" & IDPRODUCTO & " AND ID=" & ID & " AND FECHA= ")
        strSQL.Append(" ( ")
        strSQL.Append(" SELECT MAX(FECHA) ")
        strSQL.Append(" FROM SAB_CP_ESTADOSPRODUCTOS ")
        strSQL.Append(" WHERE IDPROCESO=" & IDPROCESO & " AND IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " AND IDPROVEEDOR=" & IDPROVEEDOR & " AND IDPRODUCTO=" & IDPRODUCTO & " AND ID=" & ID)
        strSQL.Append(" ) ")

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function AgregarProcesoCompra(ByVal IDPROCESO As Int32, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal IPC As Integer, ByVal procesocompra As String, ByVal ID As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CP_PC ")
        strSQL.Append(" values (@IDPROCESO,@IDTIPOPRODUCTO,@IDPROVEEDOR, @idproducto,@ID,@IPC,@Procesocompra) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDPROCESO", SqlDbType.Int)
        args(0).Value = IDPROCESO
        args(1) = New SqlParameter("@IDTIPOPRODUCTO", SqlDbType.Int)
        args(1).Value = IDTIPOPRODUCTO
        args(2) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(2).Value = IDPROVEEDOR
        args(3) = New SqlParameter("@idproducto", SqlDbType.Int)
        args(3).Value = IDPRODUCTO
        args(4) = New SqlParameter("@IPC", SqlDbType.Int)
        args(4).Value = IPC
        args(5) = New SqlParameter("@Procesocompra", SqlDbType.Text)
        args(5).Value = procesocompra
        args(6) = New SqlParameter("@ID", SqlDbType.Int)
        args(6).Value = ID


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function AgregarAspectosProductos(ByVal IDASPECTOS As Integer, ByVal IDLISTA As Int32) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append(" INSERT INTO SAB_CP_ASPECTOSPRODUCTOS ")
        strSQL.Append(" SELECT @IDASPECTOS, A.IDASPECTO, 1,NULL,NULL,NULL,NULL ")
        strSQL.Append(" FROM SAB_CP_CAT_ASPECTOS A ")
        strSQL.Append(" WHERE A.IDLISTA=@IDLISTA ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(0).Value = IDLISTA
        args(1) = New SqlParameter("@IDASPECTOS", SqlDbType.Int)
        args(1).Value = IDASPECTOS

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarProcesoCompra(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal IPC As Integer, ByVal ID As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("DELETE SAB_CP_PC ")
        strSQL.Append(" WHERE IDPROCESO=" & idproceso & " AND IDTIPOPRODUCTO=" & idtipoproducto & " AND IDPROVEEDOR=" & idproveedor & " AND IDPRODUCTO=" & idproducto & " AND IDPROCESOCOMPRA=" & IPC & " AND ID=" & ID)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ActualizarProductosProveedores(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal ID As Integer, ByVal NombreComercial As String, ByVal CSSP As String, ByVal CPF As String, ByVal Marca As String, ByVal IdPaisOrigen As String, ByVal Nombrefab As String, ByVal comentario As String) As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CP_PRODUCTOSPROVEEDORES ")
        strSQL.Append(" SET NOMBRECOMERCIAL = '" & NombreComercial & "', NumeroCSSP='" & CSSP & "', CPFOMS='" & CPF & "', Marca='" & Marca & "', IdPais=" & IdPaisOrigen & ", NombreFab='" & Nombrefab & "', COMENTARIOS='" & comentario & "'")
        strSQL.Append(" WHERE IDPROCESO =" & idproceso & " AND IDTIPOPRODUCTO=" & idtipoproducto & " AND IDPROVEEDOR=" & idproveedor & " AND IDPRODUCTO=" & idproducto & " AND ID=" & ID)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerDatosProductosProveedores(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal ID As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT pp.nombrecomercial,pp.numerocssp,pp.cpfoms, pp.marca, pp.idpais as pais, pp.nombrefab, pp.comentarios ")
        strSQL.Append(" FROM SAB_CP_PRODUCTOSPROVEEDORES PP  ")
        strSQL.Append(" WHERE PP.IDPROCESO= " & idproceso & " AND PP.IDTIPOPRODUCTO=" & idtipoproducto & " AND PP.IDPROVEEDOR=" & idproveedor & " AND PP.IDPRODUCTO=" & idproducto & " AND PP.ID=" & ID)

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerDataSetAspectos(ByVal IDPROCESO As Integer, ByVal IDTIPOPRODUCTO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDPRODUCTO As Integer, ByVal ID As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT AP.IDASPECTOS, A.IDASPECTO AS CORRELATIVO, A.NOMBRE AS ASPECTO, ")
        strSQL.Append(" CASE WHEN AP.ESTADO=0 THEN 'CUMPLE' WHEN AP.ESTADO=1 THEN 'NO CUMPLE' WHEN AP.ESTADO=2 THEN 'NO APLICA' END AS ESTADO, PP.IDLISTA ")
        strSQL.Append(" FROM SAB_CP_CAT_ASPECTOS A INNER JOIN SAB_CP_PRODUCTOSPROVEEDORES PP ON ")
        strSQL.Append(" A.IDLISTA=PP.IDLISTA ")
        strSQL.Append(" INNER JOIN SAB_CP_ASPECTOSPRODUCTOS AP ON ")
        strSQL.Append(" AP.IDA=A.IDASPECTO AND ")
        strSQL.Append(" AP.IDASPECTOS=PP.IDASPECTOS ")
        strSQL.Append(" WHERE PP.IDTIPOPRODUCTO=" & IDTIPOPRODUCTO & " and PP.IDPROCESO=" & IDPROCESO & " AND PP.IDPROVEEDOR= " & IDPROVEEDOR & " AND PP.IDPRODUCTO= " & IDPRODUCTO & " AND PP.ID= " & ID)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerDataSetAspecto(ByVal idaspectos As Integer, ByVal ida As Integer, ByVal idlista As Integer) As DataSet

        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT A.NOMBRE AS ASPECTO, AP.IDASPECTOS, AP.IDA, AP.ESTADO, AP.FECHAEMISION, AP.FECHAVTO,AP.COMENTARIO,AP.PC ")
        strSQL.Append(" FROM SAB_CP_ASPECTOSPRODUCTOS AP INNER JOIN SAB_CP_CAT_ASPECTOS A ON A.IDASPECTO=AP.IDA ")
        strSQL.Append(" WHERE AP.IDASPECTOS=" & idaspectos & " and AP.IDA=" & ida & " and A.IDLISTA=" & idlista)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function EliminarAspecto(ByVal idaspectos As Integer, ByVal IdA As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("DELETE SAB_CP_ASPECTOSPRODUCTOS ")
        strSQL.Append(" WHERE IDASPECTOS=" & idaspectos & " AND IDA=" & IdA)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function AgregarASPECTO(ByVal idaspectos As Integer, ByVal IdA As Integer, ByVal estado As Integer, ByVal fechaemision As DateTime, ByVal fechavto As DateTime, ByVal comentario As String, ByVal pc As String) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CP_ASPECTOSPRODUCTOS ")
        strSQL.Append(" values (@IDASPECTOS,@IDA,@ESTADO, @FECHAEMISION, ")
        If fechavto = "01/01/1900" Then
            strSQL.Append(" NULL, ")
        Else
            strSQL.Append(" @FECHAVTO, ")
        End If
        strSQL.Append(" @COMENTARIO,@PC) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDASPECTOS", SqlDbType.Int)
        args(0).Value = idaspectos
        args(1) = New SqlParameter("@IDA", SqlDbType.Int)
        args(1).Value = IdA
        args(2) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(2).Value = estado
        args(3) = New SqlParameter("@FECHAEMISION", SqlDbType.DateTime)
        args(3).Value = fechaemision
        If fechavto <> "01/01/1900" Then
            args(4) = New SqlParameter("@FECHAVTO", SqlDbType.DateTime)
            args(4).Value = fechavto
        End If
        args(5) = New SqlParameter("@COMENTARIO", SqlDbType.Text)
        args(5).Value = comentario
        args(6) = New SqlParameter("@PC", SqlDbType.Text)
        args(6).Value = pc

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerPROCESOxSuministro(ByVal idsuministro As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT A.IDPROCESO, A.NUMPROCESO ")
        strSQL.Append(" FROM SAB_CP_PROCESO A ")
        strSQL.Append(" WHERE A.IDTIPOPRODUCTO= " & idsuministro)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerPROCESOxSuministro2(ByVal idsuministro As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT A.IDPROCESO, A.NUMPROCESO ")
        strSQL.Append(" FROM SAB_CP_PROCESO A ")
        strSQL.Append(" WHERE A.ESTADO=0 AND A.IDTIPOPRODUCTO= " & idsuministro)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerPROCESOSCOMPRA(ByVal IDESTABLECIMIENTO As Integer, ByVal idsuministro As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT A.IDPROCESOCOMPRA, A.CODIGOLICITACION ")
        strSQL.Append(" FROM SAB_UACI_PROCESOCOMPRAS A INNER JOIN SAB_EST_SOLICITUDESPROCESOCOMPRAS SP ON A.IDPROCESOCOMPRA=SP.IDPROCESOCOMPRA AND A.IDESTABLECIMIENTO=SP.IDESTABLECIMIENTO INNER JOIN SAB_EST_SOLICITUDES S ON S.IDSOLICITUD=SP.IDSOLICITUD AND S.IDESTABLECIMIENTO=SP.IDESTABLECIMIENTO ")
        strSQL.Append(" WHERE A.IDESTABLECIMIENTO=" & IDESTABLECIMIENTO & " AND S.IDCLASESUMINISTRO=" & idsuministro & " AND A.IDESTADOPROCESOCOMPRA BETWEEN 2 AND 5")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerReporte1(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal nit As String, ByVal corrproducto As String) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT distinct pp.idproceso, pp.idtipoproducto, pp.idproveedor, pp.idproducto,PP.ID,prov.nit, prov.nombre as proveedor,s.descripcion as tipoproducto,v.corrproducto as codigo, v.desclargo as producto, pp.marca, p.nombre as pais, ")
        strSQL.Append(" ( ")
        strSQL.Append(" SELECT CASE WHEN ESTADO=0 THEN 'Certificado' ELSE 'No Certificado' END AS ESTADO  ")
        strSQL.Append(" FROM SAB_CP_ESTADOSPRODUCTOS  ")
        strSQL.Append(" WHERE IDPROCESO=pp.idproceso AND IDTIPOPRODUCTO=pp.idtipoproducto AND IDPROVEEDOR=pp.idproveedor AND IDPRODUCTO=pp.idproducto AND ID=PP.ID AND FECHA=  ")
        strSQL.Append(" (  ")
        strSQL.Append(" SELECT MAX(FECHA)  ")
        strSQL.Append(" FROM SAB_CP_ESTADOSPRODUCTOS  ")
        strSQL.Append(" WHERE IDPROCESO=pp.idproceso AND IDTIPOPRODUCTO=pp.idtipoproducto AND IDPROVEEDOR=pp.idproveedor AND IDPRODUCTO=pp.idproducto AND ID=PP.ID")
        strSQL.Append(" ) ")
        strSQL.Append(" ) as estado ")
        strSQL.Append("  ")
        strSQL.Append(" FROM SAB_CP_PRODUCTOSPROVEEDORES PP INNER JOIN SAB_CP_ESTADOSPRODUCTOS EP ")
        strSQL.Append(" ON pp.idproceso=ep.idproceso and ")
        strSQL.Append(" pp.idtipoproducto=ep.idtipoproducto and ")
        strSQL.Append(" pp.idproveedor=ep.idproveedor and ")
        strSQL.Append(" pp.idproducto=ep.idproducto AND")
        strSQL.Append(" pp.ID=ep.ID ")
        strSQL.Append(" inner join sab_cp_cat_pais p on p.idpais=pp.idpais ")
        strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=pp.idproducto ")
        strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=pp.idproveedor ")
        strSQL.Append(" inner join sab_cat_suministros s on s.idsuministro=pp.idtipoproducto ")
        strSQL.Append("  ")
        strSQL.Append(" where (pp.idproceso =" & idproceso & " ) and ")
        strSQL.Append(" (pp.idtipoproducto=" & idtipoproducto & " )  ")

        If nit <> "nohay" Then
            strSQL.Append(" and (prov.nit='" & nit & "' ) ")
        End If
        If corrproducto <> "nohay" Then
            strSQL.Append(" and (v.corrproducto='" & corrproducto & "' ) ")
        End If

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerReporte7(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal nit As String, ByVal idproveedor As Integer, ByVal corrproducto As String) As DataSet
        Dim strSQL As New StringBuilder

        strSQL.Append(" SELECT distinct pp.idproceso, pp.idtipoproducto, pp.idproveedor, pp.idproducto,pp.id, prov.nit, prov.nombre as proveedor,s.descripcion as tipoproducto,v.corrproducto as codigo, v.desclargo as producto, pp.marca, p.nombre as pais, ")
        strSQL.Append(" ( ")
        strSQL.Append(" SELECT CASE WHEN ESTADO=0 THEN 'Certificado' ELSE 'No Certificado' END AS ESTADO  ")
        strSQL.Append(" FROM SAB_CP_ESTADOSPRODUCTOS  ")
        strSQL.Append(" WHERE IDPROCESO=pp.idproceso AND IDTIPOPRODUCTO=pp.idtipoproducto AND IDPROVEEDOR=pp.idproveedor AND IDPRODUCTO=pp.idproducto AND ID=PP.ID AND FECHA=  ")
        strSQL.Append(" (  ")
        strSQL.Append(" SELECT MAX(FECHA)  ")
        strSQL.Append(" FROM SAB_CP_ESTADOSPRODUCTOS  ")
        strSQL.Append(" WHERE IDPROCESO=pp.idproceso AND IDTIPOPRODUCTO=pp.idtipoproducto AND IDPROVEEDOR=pp.idproveedor AND IDPRODUCTO=pp.idproducto AND ID=PP.ID ")
        strSQL.Append(" ) ")
        strSQL.Append(" ) as estado ")
        strSQL.Append("  ")
        strSQL.Append(" FROM SAB_CP_PRODUCTOSPROVEEDORES PP INNER JOIN SAB_CP_ESTADOSPRODUCTOS EP ")
        strSQL.Append(" ON pp.idproceso=ep.idproceso and ")
        strSQL.Append(" pp.idtipoproducto=ep.idtipoproducto and ")
        strSQL.Append(" pp.idproveedor=ep.idproveedor and ")
        strSQL.Append(" pp.idproducto=ep.idproducto and")
        strSQL.Append(" pp.id=ep.id ")
        strSQL.Append(" inner join sab_cp_cat_pais p on p.idpais=pp.idpais ")
        strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=pp.idproducto ")
        strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=pp.idproveedor ")
        strSQL.Append(" inner join sab_cat_suministros s on s.idsuministro=pp.idtipoproducto ")
        strSQL.Append("  ")
        strSQL.Append(" where (pp.idproceso =" & idproceso & " ) and ")
        strSQL.Append(" (pp.idtipoproducto=" & idtipoproducto & " )  ")

        If nit <> "nohay" Then
            strSQL.Append(" and (prov.nit='" & nit & "' ) ")
        Else
            strSQL.Append(" and (pp.idproveedor=" & idproveedor & " ) ")
        End If
        If corrproducto <> "nohay" Then
            strSQL.Append(" and (v.corrproducto='" & corrproducto & "' ) ")
        End If

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerReporteCP1y7(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer) As DataSet
        Dim strSQL As New StringBuilder


        strSQL.Append(" SELECT distinct pp.idproceso, pp.idtipoproducto, pp.idproveedor, pp.idproducto, ")
        strSQL.Append(" prov.nit, prov.nombre as proveedor,pcs.numproceso,s.descripcion as tipoproducto,v.corrproducto as codigo, v.desclargo as producto, pp.marca, p.nombre as pais,  ")
        'strSQL.Append(" case when ep.estado=0 THEN 'Certificado' ELSE 'No Certificado' END as estado,ep.fecha,ep.comentario, ")
        strSQL.Append(" l.nombre as lista, ap.ida as correlativo, a.nombre as aspecto, case when ap.estado=0 then 'Cumple' when ap.estado=1 then 'No Cumple' when ap.estado=2 then 'No Aplica' end as estadoaspecto, ")
        strSQL.Append(" ap.fechaemision, ap.fechavto, ap.comentario as comentario2 ")
        strSQL.Append("    ")
        strSQL.Append(" FROM SAB_CP_PRODUCTOSPROVEEDORES PP ")
        'strSQL.Append(" INNER JOIN SAB_CP_ESTADOSPRODUCTOS EP  ")
        'strSQL.Append(" ON pp.idproceso=ep.idproceso and  ")
        'strSQL.Append(" pp.idtipoproducto=ep.idtipoproducto and  ")
        'strSQL.Append(" pp.idproveedor=ep.idproveedor and  ")
        'strSQL.Append(" pp.idproducto=ep.idproducto  ")
        strSQL.Append(" inner join sab_cp_proceso pcs on pcs.idproceso=pp.idproceso and pcs.idtipoproducto=pp.idtipoproducto ")
        strSQL.Append(" inner join sab_cp_cat_lista l on l.idlista=pp.idlista ")
        strSQL.Append(" inner join sab_cp_cat_aspectos a on a.idlista=l.idlista ")
        strSQL.Append(" inner join sab_cp_aspectosproductos ap on ap.idaspectos=pp.idaspectos and ap.ida=a.idaspecto ")
        strSQL.Append(" inner join sab_cp_cat_pais p on p.idpais=pp.idpais  ")
        strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=pp.idproducto  ")
        strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=pp.idproveedor  ")
        strSQL.Append(" inner join sab_cat_suministros s on s.idsuministro=pp.idtipoproducto  ")

        strSQL.Append(" WHERE pp.idproceso=" & idproceso & " and pp.idtipoproducto=" & idtipoproducto & " and pp.idproveedor=" & idproveedor & " and pp.idproducto=" & idproducto) ' & " and pp.id=" & id)

        strSQL.Append(" SELECT ")
        strSQL.Append(" case when ep.estado=0 THEN 'Certificado' ELSE 'No Certificado' END as estado,ep.fecha,ep.comentario ")
        strSQL.Append(" FROM sAB_CP_ESTADOSPRODUCTOS EP ")
        strSQL.Append(" WHERE ep.idproceso=" & idproceso & " and ep.idtipoproducto=" & idtipoproducto & " and ep.idproveedor=" & idproveedor & " and ep.idproducto=" & idproducto) ' & " and ep.id=" & id)
        strSQL.Append(" ORDER BY EP.FECHA ASC ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerReporteCP2(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal NIT As String, ByVal CORRPRODUCTO As String) As DataSet
        Dim strSQL As New StringBuilder


        strSQL.Append("  SELECT distinct pp.idproceso, pp.idtipoproducto, pp.idproveedor, pp.idproducto,pp.id,  ")
        strSQL.Append(" prov.nit, prov.nombre as proveedor,pcs.numproceso,s.descripcion as tipoproducto,v.corrproducto as codigo, v.desclargo as producto, pp.marca, p.nombre as pais,   ")
        strSQL.Append(" ( ")
        strSQL.Append(" SELECT CASE WHEN ESTADO=0 THEN 'Certificado' ELSE 'No Certificado' END AS ESTADO  ")
        strSQL.Append(" FROM SAB_CP_ESTADOSPRODUCTOS  ")
        strSQL.Append(" WHERE IDPROCESO=pp.idproceso AND IDTIPOPRODUCTO=pp.idtipoproducto AND IDPROVEEDOR=pp.idproveedor AND IDPRODUCTO=pp.idproducto AND id=pp.id and FECHA=  ")
        strSQL.Append(" (  ")
        strSQL.Append(" SELECT MAX(FECHA)  ")
        strSQL.Append(" FROM SAB_CP_ESTADOSPRODUCTOS  ")
        strSQL.Append(" WHERE IDPROCESO=pp.idproceso AND IDTIPOPRODUCTO=pp.idtipoproducto AND IDPROVEEDOR=pp.idproveedor AND IDPRODUCTO=pp.idproducto and id=pp.id  ")
        strSQL.Append(" ) ")
        strSQL.Append(" ) as estado ")



        strSQL.Append(" FROM SAB_CP_PRODUCTOSPROVEEDORES PP  ")
        strSQL.Append(" INNER JOIN SAB_CP_ESTADOSPRODUCTOS EP   ")
        strSQL.Append(" ON pp.idproceso=ep.idproceso and   ")
        strSQL.Append(" pp.idtipoproducto=ep.idtipoproducto and   ")
        strSQL.Append(" pp.idproveedor=ep.idproveedor and   ")
        strSQL.Append(" pp.idproducto=ep.idproducto  and ")
        strSQL.Append(" pp.id=ep.id   ")
        strSQL.Append(" inner join sab_cp_proceso pcs on pcs.idproceso=pp.idproceso and pcs.idtipoproducto=pp.idtipoproducto  ")
        strSQL.Append(" inner join sab_cp_cat_pais p on p.idpais=pp.idpais   ")
        strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=pp.idproducto   ")
        strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=pp.idproveedor   ")
        strSQL.Append(" inner join sab_cat_suministros s on s.idsuministro=pp.idtipoproducto   ")
        strSQL.Append("   ")

        strSQL.Append(" WHERE pp.idproceso=" & idproceso & " and pp.idtipoproducto=" & idtipoproducto)
        If NIT <> "nohay" Then
            If idproveedor = 0 Then
                strSQL.Append(" and PROV.nit='" & NIT & "'")
            End If
        Else
            If idproveedor <> 0 Then
                strSQL.Append(" and pp.idproveedor=" & idproveedor)
            End If
        End If

        If CORRPRODUCTO <> "nohay" Then
            If idproducto = 0 Then
                strSQL.Append(" and v.corrproducto='" & CORRPRODUCTO & "'")
            End If
        Else
            If idproducto <> 0 Then
                strSQL.Append(" and pp.idproducto=" & idproducto)
            End If
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerReporteCP3(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal NIT As String, ByVal CORRPRODUCTO As String) As DataSet
        Dim strSQL As New StringBuilder


        strSQL.Append("  SELECT distinct pp.idproceso, pp.idtipoproducto, pp.idproveedor, pp.idproducto,pp.id,  ")
        strSQL.Append(" prov.nit, prov.nombre as proveedor,pcs.numproceso,s.descripcion as tipoproducto,v.corrproducto as codigo, v.desclargo as producto, pp.marca, p.nombre as pais,   ")

        strSQL.Append("  (  ")
        strSQL.Append(" SELECT   top 1 ep.estado as estado ")
        strSQL.Append(" FROM sAB_CP_ESTADOSPRODUCTOS EP ")
        strSQL.Append(" WHERE   ep.idproceso=pp.idproceso  and    ")
        strSQL.Append(" ep.idtipoproducto=pp.idtipoproducto and     ")
        strSQL.Append(" ep.idproveedor=pp.idproveedor and     ")
        strSQL.Append(" ep.idproducto=pp.idproducto   and ")
        strSQL.Append(" ep.id=pp.id    ")
        strSQL.Append(" order by ep.fecha desc ")
        strSQL.Append(" ) as estado, ")

        strSQL.Append(" l.nombre as lista, ap.ida as correlativo, a.nombre as aspecto, case when ap.estado=0 then 'Cumple' when ap.estado=1 then 'No Cumple' when ap.estado=2 then 'No Aplica' end as estadoaspecto, ")
        strSQL.Append(" ap.fechaemision, ap.fechavto, ap.comentario as comentario2 ")

        strSQL.Append(" FROM SAB_CP_PRODUCTOSPROVEEDORES PP  ")
        strSQL.Append(" inner join sab_cp_proceso pcs on pcs.idproceso=pp.idproceso and pcs.idtipoproducto=pp.idtipoproducto  ")
        strSQL.Append(" inner join sab_cp_cat_pais p on p.idpais=pp.idpais   ")
        strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=pp.idproducto   ")
        strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=pp.idproveedor   ")
        strSQL.Append(" inner join sab_cat_suministros s on s.idsuministro=pp.idtipoproducto   ")
        strSQL.Append(" inner join sab_cp_cat_lista l on l.idlista=pp.idlista ")
        strSQL.Append(" inner join sab_cp_cat_aspectos a on a.idlista=l.idlista ")
        strSQL.Append(" inner join sab_cp_aspectosproductos ap on ap.idaspectos=pp.idaspectos and ap.ida=a.idaspecto ")

        strSQL.Append("   ")

        strSQL.Append(" WHERE pp.idproceso=" & idproceso & " and pp.idtipoproducto=" & idtipoproducto)
        If NIT <> "nohay" Then
            If idproveedor = 0 Then
                strSQL.Append(" and PROV.nit='" & NIT & "'")
            End If
        Else
            If idproveedor <> 0 Then
                strSQL.Append(" and pp.idproveedor=" & idproveedor)
            End If
        End If

        If CORRPRODUCTO <> "nohay" Then
            If idproducto = 0 Then
                strSQL.Append(" and v.corrproducto='" & CORRPRODUCTO & "'")
            End If
        Else
            If idproducto <> 0 Then
                strSQL.Append(" and pp.idproducto=" & idproducto)
            End If
        End If

        strSQL.Append(" SELECT ")
        strSQL.Append(" case when ep.estado=0 THEN 'Certificado' ELSE 'No Certificado' END as estado,ep.fecha,ep.comentario ")
        strSQL.Append(" FROM sAB_CP_ESTADOSPRODUCTOS EP ")
        strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=ep.idproducto   ")
        strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=ep.idproveedor   ")
        strSQL.Append(" WHERE ep.idproceso=" & idproceso & " and ep.idtipoproducto=" & idtipoproducto)
        '& " and ep.idproveedor=" & idproveedor & " and ep.idproducto=" & idproducto)
        If NIT <> "nohay" Then
            If idproveedor = 0 Then
                strSQL.Append(" and PROV.nit='" & NIT & "'")
            End If
        Else
            If idproveedor <> 0 Then
                strSQL.Append(" and pp.idproveedor=" & idproveedor)
            End If
        End If

        If CORRPRODUCTO <> "nohay" Then
            If idproducto = 0 Then
                strSQL.Append(" and v.corrproducto='" & CORRPRODUCTO & "'")
            End If
        Else
            If idproducto <> 0 Then
                strSQL.Append(" and pp.idproducto=" & idproducto)
            End If
        End If
        strSQL.Append(" ORDER BY EP.FECHA ASC ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerReporteCP5(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal NIT As String, ByVal CORRPRODUCTO As String) As DataSet
        Dim strSQL As New StringBuilder


        strSQL.Append("  SELECT distinct pp.idproceso, pp.idtipoproducto, pp.idproveedor, pp.idproducto, pp.id, ")
        strSQL.Append(" prov.nit, prov.nombre as proveedor,pcs.numproceso,s.descripcion as tipoproducto,v.corrproducto as codigo, v.desclargo as producto, pp.marca, p.nombre as pais,   ")

        strSQL.Append("  (  ")
        strSQL.Append(" SELECT   top 1 ep.estado as estado ")
        strSQL.Append(" FROM sAB_CP_ESTADOSPRODUCTOS EP ")
        strSQL.Append(" WHERE   ep.idproceso=pp.idproceso  and    ")
        strSQL.Append(" ep.idtipoproducto=pp.idtipoproducto and     ")
        strSQL.Append(" ep.idproveedor=pp.idproveedor and     ")
        strSQL.Append(" ep.idproducto=pp.idproducto  and  ")
        strSQL.Append(" ep.id=pp.id    ")
        strSQL.Append(" order by ep.fecha desc ")
        strSQL.Append(" ) as estado, ")

        strSQL.Append(" l.nombre as lista, ap.ida as correlativo, a.nombre as aspecto, case when ap.estado=0 then 'Cumple' when ap.estado=1 then 'No Cumple' when ap.estado=2 then 'No Aplica' end as estadoaspecto, ")
        strSQL.Append(" ap.fechaemision, ap.fechavto, ap.comentario as comentario2 ")

        strSQL.Append(" FROM SAB_CP_PRODUCTOSPROVEEDORES PP  ")
        strSQL.Append(" inner join sab_cp_proceso pcs on pcs.idproceso=pp.idproceso and pcs.idtipoproducto=pp.idtipoproducto  ")
        strSQL.Append(" inner join sab_cp_cat_pais p on p.idpais=pp.idpais   ")
        strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=pp.idproducto   ")
        strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=pp.idproveedor   ")
        strSQL.Append(" inner join sab_cat_suministros s on s.idsuministro=pp.idtipoproducto   ")
        strSQL.Append(" inner join sab_cp_cat_lista l on l.idlista=pp.idlista ")
        strSQL.Append(" inner join sab_cp_cat_aspectos a on a.idlista=l.idlista ")
        strSQL.Append(" inner join sab_cp_aspectosproductos ap on ap.idaspectos=pp.idaspectos and ap.ida=a.idaspecto ")

        strSQL.Append("   ")

        strSQL.Append(" WHERE pp.idproceso=" & idproceso & " and pp.idtipoproducto=" & idtipoproducto)
        If NIT <> "nohay" Then
            If idproveedor = 0 Then
                strSQL.Append(" and PROV.nit='" & NIT & "'")
            End If
        Else
            If idproveedor <> 0 Then
                strSQL.Append(" and pp.idproveedor=" & idproveedor)
            End If
        End If

        If CORRPRODUCTO <> "nohay" Then
            If idproducto = 0 Then
                strSQL.Append(" and v.corrproducto='" & CORRPRODUCTO & "'")
            End If
        Else
            If idproducto <> 0 Then
                strSQL.Append(" and pp.idproducto=" & idproducto)
            End If
        End If

        strSQL.Append(" SELECT top 1 ")
        strSQL.Append(" case when ep.estado=0 THEN 'Certificado' ELSE 'No Certificado' END as estado,ep.fecha,ep.comentario ")
        strSQL.Append(" FROM sAB_CP_ESTADOSPRODUCTOS EP ")
        strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=ep.idproducto   ")
        strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=ep.idproveedor   ")
        strSQL.Append(" WHERE ep.idproceso=" & idproceso & " and ep.idtipoproducto=" & idtipoproducto)
        '& " and ep.idproveedor=" & idproveedor & " and ep.idproducto=" & idproducto)
        If NIT <> "nohay" Then
            If idproveedor = 0 Then
                strSQL.Append(" and PROV.nit='" & NIT & "'")
            End If
        Else
            If idproveedor <> 0 Then
                strSQL.Append(" and pp.idproveedor=" & idproveedor)
            End If
        End If

        If CORRPRODUCTO <> "nohay" Then
            If idproducto = 0 Then
                strSQL.Append(" and v.corrproducto='" & CORRPRODUCTO & "'")
            End If
        Else
            If idproducto <> 0 Then
                strSQL.Append(" and pp.idproducto=" & idproducto)
            End If
        End If
        strSQL.Append(" ORDER BY EP.FECHA DESC ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerReporteCP4(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal NIT As String, ByVal FECHALIMITE As DateTime) As DataSet
        Dim strSQL As New StringBuilder


        strSQL.Append("  SELECT distinct pp.idproceso, pp.idtipoproducto, pp.idproveedor, pp.idproducto, pp.id,  ")
        strSQL.Append(" prov.nit, prov.nombre as proveedor,pcs.numproceso,s.descripcion as tipoproducto,v.corrproducto as codigo, v.desclargo as producto, pp.marca, p.nombre as pais,   ")

        strSQL.Append("  (  ")
        strSQL.Append(" SELECT   top 1 ep.estado as estado ")
        strSQL.Append(" FROM sAB_CP_ESTADOSPRODUCTOS EP ")
        strSQL.Append(" WHERE   ep.idproceso=pp.idproceso  and    ")
        strSQL.Append(" ep.idtipoproducto=pp.idtipoproducto and     ")
        strSQL.Append(" ep.idproveedor=pp.idproveedor and     ")
        strSQL.Append(" ep.idproducto=pp.idproducto  and  ")
        strSQL.Append(" ep.id=pp.id    ")
        strSQL.Append(" order by ep.fecha desc ")
        strSQL.Append(" ) as estado, ")

        strSQL.Append(" l.nombre as lista, ap.ida as correlativo, a.nombre as aspecto, case when ap.estado=0 then 'Cumple' when ap.estado=1 then 'No Cumple' when ap.estado=2 then 'No Aplica' end as estadoaspecto, ")
        strSQL.Append(" ap.fechaemision, ap.fechavto, ap.comentario as comentario2 ")

        strSQL.Append(" FROM SAB_CP_PRODUCTOSPROVEEDORES PP  ")
        strSQL.Append(" inner join sab_cp_proceso pcs on pcs.idproceso=pp.idproceso and pcs.idtipoproducto=pp.idtipoproducto  ")
        strSQL.Append(" inner join sab_cp_cat_pais p on p.idpais=pp.idpais   ")
        strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=pp.idproducto   ")
        strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=pp.idproveedor   ")
        strSQL.Append(" inner join sab_cat_suministros s on s.idsuministro=pp.idtipoproducto   ")
        strSQL.Append(" inner join sab_cp_cat_lista l on l.idlista=pp.idlista ")
        strSQL.Append(" inner join sab_cp_cat_aspectos a on a.idlista=l.idlista ")
        strSQL.Append(" inner join sab_cp_aspectosproductos ap on ap.idaspectos=pp.idaspectos and ap.ida=a.idaspecto ")

        strSQL.Append("   ")

        strSQL.Append(" WHERE pp.idproceso=" & idproceso & " and pp.idtipoproducto=" & idtipoproducto & " and ap.fechavto < @FECHAVTO")
        If NIT <> "nohay" Then
            If idproveedor = 0 Then
                strSQL.Append(" and PROV.nit='" & NIT & "'")
            End If
        Else
            If idproveedor <> 0 Then
                strSQL.Append(" and pp.idproveedor=" & idproveedor)
            End If
        End If


        strSQL.Append(" SELECT top 1 ")
        strSQL.Append(" case when ep.estado=0 THEN 'Certificado' ELSE 'No Certificado' END as estado,ep.fecha,ep.comentario ")
        strSQL.Append(" FROM sAB_CP_ESTADOSPRODUCTOS EP ")
        strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=ep.idproducto   ")
        strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=ep.idproveedor   ")
        strSQL.Append(" WHERE ep.idproceso=" & idproceso & " and ep.idtipoproducto=" & idtipoproducto)
        '& " and ep.idproveedor=" & idproveedor & " and ep.idproducto=" & idproducto)
        If NIT <> "nohay" Then
            If idproveedor = 0 Then
                strSQL.Append(" and PROV.nit='" & NIT & "'")
            End If
        Else
            If idproveedor <> 0 Then
                strSQL.Append(" and pp.idproveedor=" & idproveedor)
            End If
        End If

        strSQL.Append(" ORDER BY EP.FECHA DESC ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@FECHAVTO", SqlDbType.DateTime)
        args(0).Value = FECHALIMITE

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds
    End Function
    Public Function ObtenerReporteCP6(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal NIT As String, ByVal idprocesocompra As Integer) As DataSet
        Dim strSQL As New StringBuilder


        strSQL.Append("  SELECT distinct pp.idproceso, pp.idtipoproducto, pp.idproveedor, pp.idproducto, pp.id, ")
        strSQL.Append(" prov.nit, prov.nombre as proveedor,pcs.numproceso,s.descripcion as tipoproducto,v.corrproducto as codigo, v.desclargo as producto, pp.marca, p.nombre as pais,   ")

        strSQL.Append("  (  ")
        strSQL.Append(" SELECT   top 1 ep.estado as estado ")
        strSQL.Append(" FROM sAB_CP_ESTADOSPRODUCTOS EP ")
        strSQL.Append(" WHERE   ep.idproceso=pp.idproceso  and    ")
        strSQL.Append(" ep.idtipoproducto=pp.idtipoproducto and     ")
        strSQL.Append(" ep.idproveedor=pp.idproveedor and     ")
        strSQL.Append(" ep.idproducto=pp.idproducto   and ")
        strSQL.Append(" ep.id=pp.id    ")
        strSQL.Append(" order by ep.fecha desc ")
        strSQL.Append(" ) as estado ")

        'strSQL.Append(" l.nombre as lista, ap.ida as correlativo, a.nombre as aspecto, case when ap.estado=0 then 'Cumple' when ap.estado=1 then 'No Cumple' when ap.estado=2 then 'No Aplica' end as estadoaspecto, ")
        'strSQL.Append(" ap.fechaemision, ap.fechavto, ap.comentario as comentario2 ")

        strSQL.Append(" FROM SAB_CP_PRODUCTOSPROVEEDORES PP  ")
        strSQL.Append(" inner join sab_cp_proceso pcs on pcs.idproceso=pp.idproceso and pcs.idtipoproducto=pp.idtipoproducto  ")
        strSQL.Append(" inner join sab_cp_cat_pais p on p.idpais=pp.idpais   ")
        strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=pp.idproducto   ")
        strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=pp.idproveedor   ")
        strSQL.Append(" inner join sab_cat_suministros s on s.idsuministro=pp.idtipoproducto   ")
        'strSQL.Append(" inner join sab_cp_cat_lista l on l.idlista=pp.idlista ")
        'strSQL.Append(" inner join sab_cp_cat_aspectos a on a.idlista=l.idlista ")
        'strSQL.Append(" inner join sab_cp_aspectosproductos ap on ap.idaspectos=pp.idaspectos and ap.ida=a.idaspecto ")

        strSQL.Append(" inner join SAB_UACI_DETALLEPROCESOCOMPRA dpc on dpc.idproducto=pp.idproducto ")
        strSQL.Append(" inner join sab_uaci_procesocompras pc on pc.idprocesocompra=dpc.idprocesocompra and pc.idestablecimiento=dpc.idestablecimiento ")

        strSQL.Append(" WHERE pc.idprocesocompra=" & idprocesocompra & " and pp.idproceso=" & idproceso & " and pp.idtipoproducto=" & idtipoproducto)
        If NIT <> "nohay" Then
            If idproveedor = 0 Then
                strSQL.Append(" and PROV.nit='" & NIT & "'")
            End If
        Else
            If idproveedor <> 0 Then
                strSQL.Append(" and pp.idproveedor=" & idproveedor)
            End If
        End If


        'strSQL.Append(" SELECT top 1 ")
        'strSQL.Append(" case when ep.estado=0 THEN 'Certificado' ELSE 'No Certificado' END as estado,ep.fecha,ep.comentario ")
        'strSQL.Append(" FROM sAB_CP_ESTADOSPRODUCTOS EP ")
        'strSQL.Append(" inner join vv_catalogoproductos v on v.idproducto=ep.idproducto   ")
        'strSQL.Append(" inner join sab_cat_proveedores prov on prov.idproveedor=ep.idproveedor   ")
        'strSQL.Append(" WHERE ep.idproceso=" & idproceso & " and ep.idtipoproducto=" & idtipoproducto)
        ''& " and ep.idproveedor=" & idproveedor & " and ep.idproducto=" & idproducto)
        'If NIT <> "nohay" Then
        '    If idproveedor = 0 Then
        '        strSQL.Append(" and PROV.nit='" & NIT & "'")
        '    End If
        'Else
        '    If idproveedor <> 0 Then
        '        strSQL.Append(" and pp.idproveedor=" & idproveedor)
        '    End If
        'End If

        'strSQL.Append(" ORDER BY EP.FECHA DESC ")


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function


    Public Function EliminarPC(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal id As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_PC ")
        strSQL.Append(" WHERE IDPROCESO = " & idproceso & " AND IDTIPOPRODUCTO=" & idtipoproducto & " AND IDPROVEEDOR=" & idproveedor & " AND IDPRODUCTO=" & idproducto & " AND ID=" & id)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
   
    Public Function EliminareSTADOSpRODUCTOS(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal id As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_ESTADOSPRODUCTOS ")
        strSQL.Append(" WHERE IDPROCESO = " & idproceso & " AND IDTIPOPRODUCTO=" & idtipoproducto & " AND IDPROVEEDOR=" & idproveedor & " AND IDPRODUCTO=" & idproducto & " and id=" & id)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function EliminarPRODUCTOSPROVEEDORES(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal id As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_PRODUCTOSPROVEEDORES ")
        strSQL.Append(" WHERE IDPROCESO = " & idproceso & " AND IDTIPOPRODUCTO=" & idtipoproducto & " AND IDPROVEEDOR=" & idproveedor & " AND IDPRODUCTO=" & idproducto & " and id=" & id)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerIdAspectos2(ByVal idproceso As Integer, ByVal IDSUMINISTRO As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal id As Integer) As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IDASPECTOS FROM SAB_CP_PRODUCTOSPROVEEDORES ")
        strSQL.Append(" WHERE IDPROCESO= " & idproceso & " and idtipoproducto=" & IDSUMINISTRO & " and idproveedor=" & idproveedor & " and idproducto=" & idproducto & " and id=" & id)
        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function ObtenerIdAspectos3(ByVal idproceso As Integer, ByVal IDSUMINISTRO As Integer, ByVal idproveedor As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(IDASPECTOS,0) FROM SAB_CP_PRODUCTOSPROVEEDORES ")
        strSQL.Append(" WHERE IDPROCESO= " & idproceso & " and idtipoproducto=" & IDSUMINISTRO & " and idproveedor=" & idproveedor)
        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function EliminarPC2(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_PC ")
        strSQL.Append(" WHERE IDPROCESO = " & idproceso & " AND IDTIPOPRODUCTO=" & idtipoproducto & " AND IDPROVEEDOR=" & idproveedor)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function EliminarASPECTOSPRODUCTOS(ByVal idaspectos As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_ASPECTOSPRODUCTOS ")
        strSQL.Append(" WHERE IDASPECTOS = " & idaspectos)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function EliminareSTADOSpRODUCTOS2(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_ESTADOSPRODUCTOS ")
        strSQL.Append(" WHERE IDPROCESO = " & idproceso & " AND IDTIPOPRODUCTO=" & idtipoproducto & " AND IDPROVEEDOR=" & idproveedor)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function EliminarPRODUCTOSPROVEEDORES2(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_PRODUCTOSPROVEEDORES ")
        strSQL.Append(" WHERE IDPROCESO = " & idproceso & " AND IDTIPOPRODUCTO=" & idtipoproducto & " AND IDPROVEEDOR=" & idproveedor)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function EliminarPROVEEDORESPROCESO(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_proveedoresproceso ")
        strSQL.Append(" WHERE IDPROCESO = " & idproceso & " AND IDTIPOPRODUCTO=" & idtipoproducto & " AND IDPROVEEDOR=" & idproveedor)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function chequearListadoOficial(ByVal idproducto As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT COUNT(idproducto) ")
        strSQL.Append(" FROM vv_CATALOGOPRODUCTOS WHERE PERTENECELISTADOOFICIAL=1 AND IDPRODUCTO=" & idproducto)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function chequearPerteneceLista(ByVal idproducto As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("  Select Case COUNT(idproducto) ")
        strSQL.Append(" FROM SAB_UACI_GRUPOREQTEC_PRODUCTOS ")
        strSQL.Append(" WHERE idproducto =" & idproducto)


        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerIdProductosPRoveedores(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer) As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT MAX(id) FROM SAB_CP_PRODUCTOSPROVEEDORES where IDPROCESO=" & idproceso & " AND IDTIPOPRODUCTO=" & idtipoproducto & " AND IDPROVEEDOR=" & idproveedor & " AND IDPRODUCTO=" & idproducto)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
    Public Function VerificarSiExisteProducto(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal NombreComercial As String, ByVal Marca As String, ByVal IdPaisOrigen As String, ByVal Nombrefab As String) As Integer
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT COUNT(IDPRODUCTO) ")
        strSQL.Append(" FROM SAB_CP_PRODUCTOSPROVEEDORES  ")
        strSQL.Append(" WHERE IDPROCESO =" & idproceso & " AND IDTIPOPRODUCTO=" & idtipoproducto & " AND IDPROVEEDOR=" & idproveedor & " AND IDPRODUCTO=" & idproducto & " AND NOMBRECOMERCIAL='" & NombreComercial & "' AND MARCA='" & Marca & "' AND NOMBREFAB='" & Nombrefab & "' AND IDPAIS=" & IdPaisOrigen)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function
End Class
