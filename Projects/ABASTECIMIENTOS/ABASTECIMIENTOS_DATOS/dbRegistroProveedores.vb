Imports System.Text
Public Class dbRegistroProveedores
    Inherits dbBase

    Public Overrides Function Actualizar(ByVal aEntidad As entidadBase) As Integer
        Dim lEntidad As LISTACP
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDLISTA = 0 _
            Or lEntidad.IDLISTA = Nothing Then

            lID = Me.ObtenerID(lEntidad)

            If lID = -1 Then Return -1

            lEntidad.IDLISTA = lID

            Return Agregar(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CP_CAT_LISTA ")
        strSQL.Append(" SET NOMBRE = @NOMBRE ")
        strSQL.Append(" WHERE IDLISTA = @IDLISTA AND IDSUMINISTRO=@IDSUMINISTRO ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(0).Value = lEntidad.IDLISTA
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(2).Value = lEntidad.IDSUMINISTRO


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ActualizarTipoSancion(ByVal aEntidad As TIPOSANCIONRP) As Integer
        Dim lEntidad As TIPOSANCIONRP
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDTIPOSANCION = 0 _
            Or lEntidad.IDTIPOSANCION = Nothing Then

            lID = Me.ObtenerIDTipoSancion()

            If lID = -1 Then Return -1

            lEntidad.IDTIPOSANCION = lID

            Return AgregarTipoSancion(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_RP_CAT_TIPOSANCION ")
        strSQL.Append(" SET NOMBRE = @NOMBRE ")
        strSQL.Append(" WHERE idtiposancion = @idtiposancion  ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@idtiposancion", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOSANCION
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
  


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ActualizarCausas(ByVal aEntidad As CAUSASRP) As Integer
        Dim lEntidad As CAUSASRP
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDCAUSA = 0 _
            Or lEntidad.IDCAUSA = Nothing Then

            lID = Me.ObtenerIDCausas()

            If lID = -1 Then Return -1

            lEntidad.IDCAUSA = lID

            Return AgregarCausas(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_RP_CAT_CAUSAS ")
        strSQL.Append(" SET NOMBRE = @NOMBRE ")
        strSQL.Append(" WHERE idcausa = @idcausa  ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@idcausa", SqlDbType.Int)
        args(0).Value = lEntidad.IDCAUSA
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE



        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ActualizarDocumentos(ByVal aEntidad As DOCUMENTOSRP) As Integer
        Dim lEntidad As DOCUMENTOSRP
        lEntidad = aEntidad

        Dim lID As Long
        If lEntidad.IDDOCUMENTO = 0 _
            Or lEntidad.IDDOCUMENTO = Nothing Then

            lID = Me.ObtenerIDDocumentos()

            If lID = -1 Then Return -1

            lEntidad.IDDOCUMENTO = lID

            Return AgregarDocumentos(lEntidad)

        End If

        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_RP_CAT_DOCUMENTOS ")
        strSQL.Append(" SET NOMBRE = @NOMBRE ")
        strSQL.Append(" WHERE iddocumento = @iddocumento  ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDDOCUMENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDDOCUMENTO
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE



        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Agregar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As LISTACP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CP_CAT_LISTA ")
        strSQL.Append(" values (@IDLISTA,@NOMBRE, @IDSUMINISTRO) ")



        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(0).Value = lEntidad.IDLISTA
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(2).Value = lEntidad.IDSUMINISTRO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function AgregarTipoSancion(ByVal aEntidad As TIPOSANCIONRP) As Integer

        Dim lEntidad As TIPOSANCIONRP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_RP_CAT_TIPOSANCION ")
        strSQL.Append(" values (@IDTIPOSANCION,@NOMBRE) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDTIPOSANCION", SqlDbType.Int)
        args(0).Value = lEntidad.IDTIPOSANCION
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function AgregarCausas(ByVal aEntidad As CAUSASRP) As Integer

        Dim lEntidad As CAUSASRP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_RP_CAT_CAUSAS ")
        strSQL.Append(" values (@IDCAUSA,@NOMBRE) ")

        Dim args(2) As SqlParameter
        args(0) = New SqlParameter("@IDCAUSA", SqlDbType.Int)
        args(0).Value = lEntidad.IDCAUSA
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function AgregarDocumentos(ByVal aEntidad As DOCUMENTOSRP) As Integer

        Dim lEntidad As DOCUMENTOSRP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_RP_CAT_DOCUMENTOS ")
        strSQL.Append(" values (@IDDOCUMENTO,@C1,@C2,@NOMBRE) ")

        Dim args(3) As SqlParameter
        args(0) = New SqlParameter("@IDDOCUMENTO", SqlDbType.Int)
        args(0).Value = lEntidad.IDDOCUMENTO
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@C1", SqlDbType.Int)
        args(2).Value = lEntidad.C1
        args(3) = New SqlParameter("@C2", SqlDbType.Int)
        args(3).Value = lEntidad.C2

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Overrides Function Eliminar(ByVal aEntidad As entidadBase) As Integer

        Dim lEntidad As LISTACP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CP_CAT_LISTA ")
        strSQL.Append(" WHERE IDLISTA = @IDLISTA AND IDSUMINISTRO=@IDSUMINISTRO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDLISTA", SqlDbType.Int)
        args(0).Value = lEntidad.IDLISTA
        args(1) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        args(1).Value = lEntidad.IDSUMINISTRO

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarTipoSancion(ByVal idtiposancion As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_RP_CAT_TIPOSANCION ")
        strSQL.Append(" WHERE IDtiposancion = @IDtiposancion ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDtiposancion", SqlDbType.Int)
        args(0).Value = idtiposancion


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarCAusas(ByVal idcausa As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_RP_CAT_CAUSAS ")
        strSQL.Append(" WHERE IDcausa = @IDcausa ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDcausa", SqlDbType.Int)
        args(0).Value = idcausa


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarDocumentos(ByVal iddocumento As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_RP_CAT_DOCUMENTOS ")
        strSQL.Append(" WHERE IDDOCUMENTO = @IDDOCUMENTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDDOCUMENTO", SqlDbType.Int)
        args(0).Value = iddocumento


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Private Sub SelectTabla(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDLISTA, IDSUMINISTRO, ")
        strSQL.Append(" NOMBRE ")
        strSQL.Append(" FROM SAB_CP_CAT_LISTA ")

    End Sub
    Private Sub SelectTablaTipoSancion(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDtiposancion,  ")
        strSQL.Append(" NOMBRE ")
        strSQL.Append(" FROM SAB_RP_CAT_TIPOSANCION ")

    End Sub
    Private Sub SelectTablaCausas(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDcausa,  ")
        strSQL.Append(" NOMBRE ")
        strSQL.Append(" FROM SAB_RP_CAT_CAUSAS ")

    End Sub
    Private Sub SelectTablaDOCUMENTOS(ByRef strSQL As StringBuilder)

        strSQL.Append(" SELECT IDDOCUMENTO,C1,C2,  ")
        strSQL.Append(" NOMBRE ")
        strSQL.Append(" FROM SAB_RP_CAT_DOCUMENTOS ")

    End Sub
    Public Function ObtenerDataSetPorID() As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerDataSetPorIDTiposancion() As DataSet

        Dim strSQL As New StringBuilder
        SelectTablaTipoSancion(strSQL)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Overrides Function ObtenerID(ByVal aEntidad As entidadBase) As String

        Dim lEntidad As LISTACP
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDLISTA),0) + 1 ")
        strSQL.Append(" FROM SAB_CP_CAT_LISTA ")
        ' strSQL.Append(" WHERE IDSUMINISTRO=@IDSUMINISTRO ")

        'Dim args(0) As SqlParameter
        'args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        'args(0).Value = lEntidad.IDTIPOGARANTIA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerIDTipoSancion() As String



        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDTIPOSANCION),0) + 1 ")
        strSQL.Append(" FROM SAB_RP_CAT_TIPOSANCION ")
        ' strSQL.Append(" WHERE IDSUMINISTRO=@IDSUMINISTRO ")

        'Dim args(0) As SqlParameter
        'args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        'args(0).Value = lEntidad.IDTIPOGARANTIA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function

    Public Function ObtenerIDCausas() As String



        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDCausa),0) + 1 ")
        strSQL.Append(" FROM SAB_RP_CAT_CAUSAS ")
        ' strSQL.Append(" WHERE IDSUMINISTRO=@IDSUMINISTRO ")

        'Dim args(0) As SqlParameter
        'args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        'args(0).Value = lEntidad.IDTIPOGARANTIA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerIDDocumentos() As String



        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(iddocumento),0) + 1 ")
        strSQL.Append(" FROM SAB_RP_CAT_DOCUMENTOS ")
        ' strSQL.Append(" WHERE IDSUMINISTRO=@IDSUMINISTRO ")

        'Dim args(0) As SqlParameter
        'args(0) = New SqlParameter("@IDSUMINISTRO", SqlDbType.Int)
        'args(0).Value = lEntidad.IDTIPOGARANTIA

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Overrides Function Recuperar(ByVal aEntidad As entidadBase) As Integer

    End Function


    Public Function ObtenerDataSetPorID(ByRef ds As DataSet) As Integer

    End Function
    Public Function ObtenerDataSetPorID2(ByVal Idcausal As Integer, ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDLISTA=" & Idcausal & " and IDSUMINISTRO=" & IDSUMINISTRO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerDataSetPorID2TIPOSANCION(ByVal IDTIPOSANCION As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTablaTipoSancion(strSQL)
        strSQL.Append(" WHERE IDTIPOSANCION=" & IDTIPOSANCION)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerDataSetPorID2CAUSAS(ByVal idcausa As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTablaCausas(strSQL)
        strSQL.Append(" WHERE IDCAUSA=" & idcausa)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerDataSetPorID2DOCUMENTOS(ByVal IDDOCUMENTO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTablaDOCUMENTOS(strSQL)
        strSQL.Append(" WHERE IDDOCUMENTO=" & IDDOCUMENTO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerDataSetPorID3(ByVal IDSUMINISTRO As Integer) As DataSet

        Dim strSQL As New StringBuilder
        SelectTabla(strSQL)
        strSQL.Append(" WHERE IDSUMINISTRO=" & IDSUMINISTRO)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerID2(ByVal IDSUMINISTRO As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT isnull(max(IDLISTAL),0) + 1 ")
        strSQL.Append(" FROM SAB_CP_CAT_LISTA WHERE IDSUMINISTRO=" & IDSUMINISTRO)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerSuministros() As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT IDSUMINISTRO, DESCRIPCION  ")
        strSQL.Append(" FROM SAB_CAT_SUMINISTROS ")

        Return SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())
    End Function

    Public Function ObtenerLISTAS() As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT L.IDLISTA, L.IDSUMINISTRO, L.NOMBRE, S.DESCRIPCION AS SUMINISTRO ")
        strSQL.Append(" FROM SAB_CP_CAT_LISTA L INNER JOIN SAB_CAT_SUMINISTROS  S ")
        strSQL.Append(" ON L.IDSUMINISTRO=S.IDSUMINISTRO ORDER BY S.IDSUMINISTRO ")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerTiposSanciones() As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT idtiposancion, nombre")
        strSQL.Append(" FROM SAB_RP_CAT_TIPOSANCION ")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerCausas() As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT Idcausa, nombre")
        strSQL.Append(" FROM SAB_RP_CAT_CAUSAS ")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObtenerDocumentos(ByVal C1 As Integer, ByVal C2 As Integer) As DataSet
        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT IDDOCUMENTO, nombre, CASE WHEN C1=1 THEN 'NATURAL' ELSE 'JURÍDICO' END AS C1, CASE WHEN C2=1 THEN 'NACIONAL' ELSE 'EXTRANJERO' END AS C2 ")
        strSQL.Append(" FROM SAB_RP_CAT_DOCUMENTOS ")

        Select Case C1
            Case Is = 0
                Select Case C2
                    Case Is = 0
                        'strSQL.Append(" WHERE C1=1 ")
                    Case Is = 1
                        strSQL.Append(" WHERE  C2=1 ")
                    Case Is = 2
                        strSQL.Append(" WHERE  C2=2 ")
                End Select

            Case Is = 1
                Select Case C2
                    Case Is = 0
                        strSQL.Append(" WHERE C1=1 ")
                    Case Is = 1
                        strSQL.Append(" WHERE C1=1 AND C2=1 ")
                    Case Is = 2
                        strSQL.Append(" WHERE C1=1 AND C2=2 ")
                End Select
            Case Is = 2
                Select Case C2
                    Case Is = 0
                        strSQL.Append(" WHERE C1=2  ")
                    Case Is = 1
                        strSQL.Append(" WHERE C1=2 AND C2=1 ")
                    Case Is = 2
                        strSQL.Append(" WHERE C1=2 AND C2=2 ")
                End Select
        End Select

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds
    End Function
    Public Function ObteneProveedores() As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT p.IDPROVEEDOR, p.NOMBRE, p.NIT, ")
        strSQL.Append(" ( SELECT CASE WHEN ESTADO=0 THEN 'Habilitado' WHEN ESTADO=1 THEN 'Deshabilitado' end as estado from sab_rp_estadosproveedores where idproveedor=p.idproveedor and idestado=(select max(idestado) from sab_rp_estadosproveedores where idproveedor=p.idproveedor) ")
        strSQL.Append(" ) as estado ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES p")
        strSQL.Append(" ORDER BY p.NOMBRE ")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerProveedoresFiltrados(Optional ByVal NIT As String = "", Optional ByVal nombre As String = "") As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT P.IDPROVEEDOR,P.NIT, P.NOMBRE, ")
        strSQL.Append(" ( SELECT CASE WHEN ESTADO=0 THEN 'Habilitado' WHEN ESTADO=1 THEN 'Deshabilitado' end as estado from sab_rp_estadosproveedores where idproveedor=p.idproveedor and idestado=(select max(idestado) from sab_rp_estadosproveedores where idproveedor=p.idproveedor) ")
        strSQL.Append(" ) as estado ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES p ")


        If NIT <> "" Then
            strSQL.Append(" where P.NIT='" & NIT & "'")
        End If

        If nombre <> "" Then
            strSQL.Append(" where P.NOMBRE LIKE '%" & nombre & "%'")
        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function

    Public Function ObtenerDatosProveedor(ByVal IDPROVEEDOR As Int32) As System.Data.DataSet

        Dim strSQL As New Text.StringBuilder
        strSQL.Append("SELECT NIT, NOMBRE, C1, ")
        strSQL.Append(" ( SELECT CASE WHEN ESTADO=0 THEN 'Habilitado' WHEN ESTADO=1 THEN 'Deshabilitado' end as estado from sab_rp_estadosproveedores where idproveedor=" & IDPROVEEDOR & " and idestado=(select max(idestado) from sab_rp_estadosproveedores where idproveedor=" & IDPROVEEDOR & ") ")
        strSQL.Append(" ) as estado ")
        strSQL.Append("FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append("WHERE IDPROVEEDOR = @IDPROVEEDOR ")

        Dim args(0) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = IDPROVEEDOR

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

        Return ds

    End Function
    Public Function ObtenerUnProveedor(ByVal idproveedor As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT NOMBRE, isnull(DIRECCION,'') as direccion, ISNULL(REPRESENTANTELEGAL,'') AS REPRESENTANTELEGAL,ISNULL(REPRESENTANTELEGAL2,' ') AS REPRESENTANTELEGAL2,ISNULL(REPRESENTANTELEGAL3,' ') AS REPRESENTANTELEGAL3, isnull(telefono,'') as telefono, isnull(telefono2,' ') as telefono2,isnull(telefono3,' ') as telefono3, isnull(fax,' ') as fax, isnull(correo,' ') as correo, isnull(giro,' ') as giro, isnull(nombreabreviado,' ') as nombreabreviado, procedencia, C1,C3, tp1,tp2,tp3,isnull(matricula,' ') as matricula, NIT ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append(" WHERE IDPROVEEDOR=" & idproveedor)

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ActualizarProveedores(ByVal aEntidad As PROVEEDORESRG) As Integer
        Dim lEntidad As PROVEEDORESRG
        lEntidad = aEntidad


        Dim strSQL As New StringBuilder
        strSQL.Append("UPDATE SAB_CAT_PROVEEDORES ")
        strSQL.Append(" SET NOMBRE = @NOMBRE, DIRECCION=@DIRECCION, REPRESENTANTELEGAL=@REPRESENTANTELEGAL, MATRICULA=@MATRICULA, TELEFONO=@TELEFONO, FAX=@FAX, GIRO=@GIRO, AUUSUARIOMODIFICACION=@AUUSUARIOMODIFICACION, AUFECHAMODIFICACION=@AUFECHAMODIFICACION, CORREO=@CORREO, PROCEDENCIA=@PROCEDENCIA, C1=@C1, C3=@C3, NOMBREABREVIADO=@NOMBREABREVIADO,TELEFONO2=@TELEFONO2, TELEFONO3=@TELEFONO3, TP1=@TP1, TP2=@TP2, TP3=@TP3 ")
        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR  ")

        Dim args(19) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROVEEDOR
      
        args(1) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(1).Value = lEntidad.NOMBRE
        args(2) = New SqlParameter("@DIRECCION", SqlDbType.VarChar)
        args(2).Value = lEntidad.DIRECCION
        args(3) = New SqlParameter("@REPRESENTANTELEGAL", SqlDbType.VarChar)
        args(3).Value = lEntidad.REPRESENTANTELEGAL
        args(4) = New SqlParameter("@MATRICULA", SqlDbType.VarChar)
        args(4).Value = lEntidad.MATRICULA
        args(5) = New SqlParameter("@TELEFONO", SqlDbType.VarChar)
        args(5).Value = lEntidad.TELEFONO
        args(6) = New SqlParameter("@FAX", SqlDbType.VarChar)
        args(6).Value = lEntidad.FAX
     
        args(7) = New SqlParameter("@GIRO", SqlDbType.VarChar)
        args(7).Value = lEntidad.GIRO

        args(8) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(8).Value = lEntidad.AUUSUARIOMODIFICACION
        args(9) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(9).Value = lEntidad.AUFECHAMODIFICACION

        args(10) = New SqlParameter("@CORREO", SqlDbType.VarChar)
        args(10).Value = lEntidad.CORREO
        args(11) = New SqlParameter("@PROCEDENCIA", SqlDbType.Int)
        args(11).Value = lEntidad.PROCEDENCIA
        args(12) = New SqlParameter("@C1", SqlDbType.Int)
        args(12).Value = lEntidad.C1
        args(13) = New SqlParameter("@C3", SqlDbType.Int)
        args(13).Value = lEntidad.C3
        args(14) = New SqlParameter("@NOMBREABREVIADO", SqlDbType.VarChar)
        args(14).Value = lEntidad.NOMBREABR
        args(15) = New SqlParameter("@TELEFONO2", SqlDbType.VarChar)
        args(15).Value = lEntidad.TELEFONO2
        args(16) = New SqlParameter("@TELEFONO3", SqlDbType.VarChar)
        args(16).Value = lEntidad.TELEFONO3
        args(17) = New SqlParameter("@TP1", SqlDbType.Int)
        args(17).Value = lEntidad.TP1
        args(18) = New SqlParameter("@TP2", SqlDbType.Int)
        args(18).Value = lEntidad.TP2
        args(19) = New SqlParameter("@TP3", SqlDbType.Int)
        args(19).Value = lEntidad.TP3

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function AgregarProveedores(ByVal aEntidad As PROVEEDORESRG) As Integer

        Dim lEntidad As PROVEEDORESRG
        lEntidad = aEntidad

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_CAT_PROVEEDORES ")
        strSQL.Append(" values (@IDPROVEEDOR,@CODIGOPROVEEDOR,@NOMBRE,@DIRECCION,@REPRESENTANTELEGAL,@MATRICULA, @TELEFONO, @FAX, @NIT, @GIRO, @realizadonaciones,@AUUSUARIOCREACION, @AUFECHACREACION, @AUUSUARIOMODIFICACION, @AUFECHAMODIFICACION,@estasincronizada, @CORREO, @PROCEDENCIA, @C1, @C3,@NOMBREABREVIADO,@REPRESENTANTELEGAL2, @REPRESENTANTELEGAL3, @TELEFONO2,@TELEFONO3,@TP1,@TP2,@TP3) ")

        Dim args(27) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = lEntidad.IDPROVEEDOR
        args(1) = New SqlParameter("@CODIGOPROVEEDOR", SqlDbType.VarChar)
        args(1).Value = lEntidad.CODIGOPROVEEDOR
        args(2) = New SqlParameter("@NOMBRE", SqlDbType.VarChar)
        args(2).Value = lEntidad.NOMBRE
        args(3) = New SqlParameter("@DIRECCION", SqlDbType.VarChar)
        args(3).Value = lEntidad.DIRECCION
        args(4) = New SqlParameter("@REPRESENTANTELEGAL", SqlDbType.VarChar)
        args(4).Value = lEntidad.REPRESENTANTELEGAL
        args(5) = New SqlParameter("@MATRICULA", SqlDbType.VarChar)
        args(5).Value = lEntidad.MATRICULA
        args(6) = New SqlParameter("@TELEFONO", SqlDbType.VarChar)
        args(6).Value = lEntidad.TELEFONO
        args(7) = New SqlParameter("@FAX", SqlDbType.VarChar)
        args(7).Value = lEntidad.FAX
        args(8) = New SqlParameter("@NIT", SqlDbType.VarChar)
        args(8).Value = lEntidad.NIT
        args(9) = New SqlParameter("@GIRO", SqlDbType.VarChar)
        args(9).Value = lEntidad.GIRO
        args(10) = New SqlParameter("@AUUSUARIOCREACION", SqlDbType.VarChar)
        args(10).Value = lEntidad.AUUSUARIOCREACION
        args(11) = New SqlParameter("@AUFECHACREACION", SqlDbType.DateTime)
        args(11).Value = lEntidad.AUFECHACREACION
        args(12) = New SqlParameter("@AUUSUARIOMODIFICACION", SqlDbType.VarChar)
        args(12).Value = lEntidad.AUUSUARIOMODIFICACION
        args(13) = New SqlParameter("@AUFECHAMODIFICACION", SqlDbType.DateTime)
        args(13).Value = lEntidad.AUFECHAMODIFICACION
        args(14) = New SqlParameter("@CORREO", SqlDbType.VarChar)
        args(14).Value = lEntidad.CORREO
        args(15) = New SqlParameter("@PROCEDENCIA", SqlDbType.Int)
        args(15).Value = lEntidad.PROCEDENCIA
        args(16) = New SqlParameter("@C1", SqlDbType.Int)
        args(16).Value = lEntidad.C1
        args(17) = New SqlParameter("@C3", SqlDbType.Int)
        args(17).Value = lEntidad.C3
        args(18) = New SqlParameter("@NOMBREABREVIADO", SqlDbType.VarChar)
        args(18).Value = lEntidad.NOMBREABR
        args(19) = New SqlParameter("@TELEFONO2", SqlDbType.VarChar)
        args(19).Value = lEntidad.TELEFONO2
        args(20) = New SqlParameter("@TELEFONO3", SqlDbType.VarChar)
        args(20).Value = lEntidad.TELEFONO3
        args(21) = New SqlParameter("@TP1", SqlDbType.Int)
        args(21).Value = lEntidad.TP1
        args(22) = New SqlParameter("@TP2", SqlDbType.Int)
        args(22).Value = lEntidad.TP2
        args(23) = New SqlParameter("@TP3", SqlDbType.Int)
        args(23).Value = lEntidad.TP3
        args(24) = New SqlParameter("@REPRESENTANTELEGAL2", SqlDbType.VarChar)
        args(24).Value = lEntidad.REPRESENTANTELEGAL2
        args(25) = New SqlParameter("@REPRESENTANTELEGAL3", SqlDbType.VarChar)
        args(25).Value = lEntidad.REPRESENTANTELEGAL3
        args(26) = New SqlParameter("@estasincronizada", SqlDbType.Int)
        args(26).Value = 0
        args(27) = New SqlParameter("@realizadonaciones", SqlDbType.Int)
        args(27).Value = 0

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObteneProductosProveedores(ByVal idproveedor As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT pp.idproducto, v.descsuministro as suministro, v.corrproducto as codigo, v.desclargo as producto  ")
        strSQL.Append(" FROM SAB_RP_PRODUCTOSPROVEEDORES PP INNER JOIN VV_CATALOGOPRODUCTOS v on pp.idproducto=v.idproducto")
        strSQL.Append(" WHERE PP.IDPROVEEDOR=" & idproveedor)
        strSQL.Append(" ORDER BY v.idsuministro ")

        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerProductosSINAB(ByVal Codigo As String, ByVal nombre As String) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT v.idproducto, v.corrproducto as codigo, v.desclargo, v.descripcion as um ")
        strSQL.Append(" FROM vv_CATALOGOPRODUCTOS V  ")
        strSQL.Append(" WHERE V.PERTENECELISTADOOFICIAL=1 AND (v.corrproducto='" & Codigo & "' OR v.desclargo like '%" & nombre & "%')")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function EliminarProductoProveedor(ByVal idproveedor As Integer, ByVal idproducto As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_RP_PRODUCTOSPROVEEDORES ")
        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR AND IDPRODUCTO=@IDPRODUCTO ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = idproveedor
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = idproducto


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function chequearListadoOficial(ByVal idproducto As Integer, ByVal idsuministro As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append("SELECT COUNT(idproducto) ")
        strSQL.Append(" FROM vv_CATALOGOPRODUCTOS WHERE PERTENECELISTADOOFICIAL=1 AND IDPRODUCTO=" & idproducto & " AND IDSUMINISTRO=" & idsuministro)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function AgregarProductosProveedores(ByVal idproducto As Integer, ByVal idproveedor As Integer) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_RP_PRODUCTOSPROVEEDORES ")
        strSQL.Append(" values(@IDPROVEEDOR,@IDPRODUCTO) ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = idproveedor
        args(1) = New SqlParameter("@IDPRODUCTO", SqlDbType.Int)
        args(1).Value = idproducto
        

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerDocumentosProveedores(ByVal idproveedor As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT D.IDDOCUMENTO, D.NOMBRE as DOCUMENTO, ISNULL(convert(varchar,DP.FECHAEMISION,103),'-') AS FECHAEMISION, ISNULL(convert(varchar,DP.FECHACADUCIDAD,103),'-') AS FECHACADUCIDAD ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES P INNER JOIN SAB_RP_CAT_DOCUMENTOS D ON D.C1=P.C1 AND D.C2=P.PROCEDENCIA ")
        strSQL.Append(" LEFT OUTER JOIN SAB_RP_DOCUMENTOSPROVEEDORES DP ON P.IDPROVEEDOR=DP.IDPROVEEDOR AND D.IDDOCUMENTO=DP.IDDOCUMENTO ")
        strSQL.Append(" WHERE P.IDPROVEEDOR=" & idproveedor)


        Dim ds As DataSet

        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function EliminarDocumentosProveedor(ByVal idproveedor As Integer, ByVal iddocumento As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_RP_DOCUMENTOSPROVEEDORES ")
        strSQL.Append(" WHERE IDPROVEEDOR = @IDPROVEEDOR AND IDDOCUMENTO=@iddocumento ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = idproveedor
        args(1) = New SqlParameter("@iddocumento", SqlDbType.Int)
        args(1).Value = iddocumento


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function AgregarDocumentosProveedores(ByVal iddocumento As Integer, ByVal idproveedor As Integer, ByVal fechaemision As DateTime, ByVal fechacaducidad As DateTime, ByVal fechareporte As DateTime, ByVal usuario As String, ByVal personavistobueno As string) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_RP_DOCUMENTOSPROVEEDORES ")
        strSQL.Append(" values(@IDPROVEEDOR,@IDDOCUMENTO,@FECHAEMISION, @FECHACADUCIDAD, @FECHAREPORTE,@USUARIO,@PERSONAVISTOBUENO) ")

        Dim args(6) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = idproveedor
        args(1) = New SqlParameter("@IDDOCUMENTO", SqlDbType.Int)
        args(1).Value = iddocumento
        args(2) = New SqlParameter("@FECHAEMISION", SqlDbType.DateTime)
        args(2).Value = fechaemision
        args(3) = New SqlParameter("@FECHACADUCIDAD", SqlDbType.DateTime)
        args(3).Value = IIf(IsDBNull(fechacaducidad), "NULL", fechacaducidad)
        args(4) = New SqlParameter("@FECHAREPORTE", SqlDbType.DateTime)
        args(4).Value = IIf(IsDBNull(fechareporte), "NULL", fechareporte)
        args(5) = New SqlParameter("@USUARIO", SqlDbType.VarChar)
        args(5).Value = IIf(IsDBNull(usuario), "NULL", usuario)
        args(6) = New SqlParameter("@PERSONAVISTOBUENO", SqlDbType.VarChar)
        args(6).Value = IIf(IsDBNull(personavistobueno), "NULL", personavistobueno)

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerEstadosProveedores(ByVal idproveedor As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT EP.IDESTADO, CASE WHEN EP.ESTADO=0 THEN 'HABILITADO' WHEN EP.ESTADO=1 THEN 'INHABILITADO' END AS ESTADO, convert(varchar,EP.FECHACAMBIO,103) as fechacambio, C.NOMBRE as causa, isnull(convert(varchar,ep.fechainicioi,103),'-') as fechainicioi, isnull(convert(varchar,ep.fechafini,103),'-') as fechafini, isnull(ep.comentario,'-') as comentario ")
        strSQL.Append(" FROM SAB_RP_ESTADOSPROVEEDORES EP INNER JOIN SAB_RP_CAT_CAUSAS C ON EP.IDCAUSA=C.IDCAUSA ")
        strSQL.Append(" WHERE EP.IDPROVEEDOR=" & idproveedor)
        strSQL.Append(" ORDER BY EP.IDESTADO DESC ")

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerUltimoEstado(ByVal idproveedor As Integer) As Integer

        Dim strSQL, strsql2 As New StringBuilder
        strSQL.Append(" SELECT count(estado) from SAB_RP_ESTADOSPROVEEDORES WHERE IDPROVEEDOR=" & idproveedor)

        If SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString()) = 0 Then
            Return 99
        Else
            strsql2.Append(" SELECT estado ")
            strsql2.Append(" FROM SAB_RP_ESTADOSPROVEEDORES ")
            strsql2.Append(" WHERE IDPROVEEDOR=" & idproveedor & " AND IDESTADO=(SELECT MAX(IDESTADO) FROM SAB_RP_ESTADOSPROVEEDORES WHERE IDPROVEEDOR=" & idproveedor & " ) ")
            Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strsql2.ToString())
        End If


        



    End Function
    Public Function AgregarEstadosProveedores(ByVal idproveedor As Integer, ByVal idestado As Integer, ByVal estado As Integer, ByVal fechacambio As DateTime, ByVal idcausa As Integer, ByVal fechainicioi As DateTime, ByVal fechafini As DateTime, ByVal comentario As String) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_RP_ESTADOSPROVEEDORES ")
        strSQL.Append(" values(@IDPROVEEDOR,@IDESTADO,@ESTADO,@Fechacambio,@idcausa,@fechainicioi, @fechafini,@comentario) ")

        Dim args(7) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = idproveedor
        args(1) = New SqlParameter("@IDESTADO", SqlDbType.Int)
        args(1).Value = idestado
        args(2) = New SqlParameter("@ESTADO", SqlDbType.Int)
        args(2).Value = estado
        args(3) = New SqlParameter("@Fechacambio", SqlDbType.DateTime)
        args(3).Value = fechacambio
        args(4) = New SqlParameter("@idcausa", SqlDbType.Int)
        args(4).Value = idcausa
        args(5) = New SqlParameter("@fechainicioi", SqlDbType.DateTime)
        args(5).Value = fechainicioi
        args(6) = New SqlParameter("@fechafini", SqlDbType.DateTime)
        args(6).Value = fechafini
        args(7) = New SqlParameter("@comentario", SqlDbType.VarChar)
        args(7).Value = comentario


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerUltimoIdEstado(ByVal idproveedor As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT isnull(max(idestado),0)+1 ")
        strSQL.Append(" FROM SAB_RP_ESTADOSPROVEEDORES ")
        strSQL.Append(" WHERE IDPROVEEDOR=" & idproveedor)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function ObtenerSancionesProveedores(ByVal idproveedor As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT SP.IDSANCION, T.NOMBRE AS TIPOSANCION, SP.MONTO, SP.FECHAIMPRESION, SP.FECHAFIRME, ISNULL(convert(varchar,SP.FECHAPAGO,103),'-') AS FECHAPAGO, ISNULL(SP.NUMOFERTA,'') AS NUMOFERTA, ISNULL(SP.NUMCONTRATO,'') AS NUMCONTRATO, ISNULL(SP.NUMPC,'') AS NUMPC, ISNULL(SP.COMENTARIO,'')  as comentario ")
        strSQL.Append(" FROM SAB_RP_SANCIONESPROVEEDORES SP INNER JOIN SAB_RP_CAT_TIPOSANCION T ON SP.IDTIPOSANCION=T.IDTIPOSANCION ")
        strSQL.Append(" WHERE SP.IDPROVEEDOR=" & idproveedor)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerUltimoIdSancion(ByVal idproveedor As Integer) As Integer

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT isnull(max(idsancion),0)+1 ")
        strSQL.Append(" FROM SAB_RP_SANCIONESPROVEEDORES ")
        strSQL.Append(" WHERE IDPROVEEDOR=" & idproveedor)

        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString())

    End Function
    Public Function AgregarSancionesProveedores(ByVal idproveedor As Integer, ByVal idsancion As Integer, ByVal idtiposancion As Integer, ByVal fechaimpresion As DateTime, ByVal fechafirme As DateTime, ByVal fechapago As DateTime, ByVal numoferta As String, ByVal numcontrato As String, ByVal numpc As String, ByVal comentario As String, ByVal monto As Decimal) As Integer

        Dim strSQL As New StringBuilder

        strSQL.Append("INSERT INTO SAB_RP_SANCIONESPROVEEDORES ")
        strSQL.Append(" values(@IDPROVEEDOR,@IDSANCION,@IDTIPOSANCION,@MONTO,@FECHAIMPRESION,@FECHAFIRME,@FECHAPAGO,@NUMOFERTA, @NUMCONTRATO,@NUMPC,@COMENTARIO) ")

        Dim args(10) As SqlParameter
        args(0) = New SqlParameter("@IDPROVEEDOR", SqlDbType.Int)
        args(0).Value = idproveedor
        args(1) = New SqlParameter("@IDSANCION", SqlDbType.Int)
        args(1).Value = idsancion
        args(2) = New SqlParameter("@fechaimpresion", SqlDbType.DateTime)
        args(2).Value = fechaimpresion
        args(3) = New SqlParameter("@fechafirme", SqlDbType.DateTime)
        args(3).Value = fechafirme
        args(4) = New SqlParameter("@idtiposancion", SqlDbType.Int)
        args(4).Value = idtiposancion
        args(5) = New SqlParameter("@fechapago", SqlDbType.DateTime)
        args(5).Value = fechapago
        args(6) = New SqlParameter("@numoferta", SqlDbType.VarChar)
        args(6).Value = numoferta
        args(7) = New SqlParameter("@numcontrato", SqlDbType.VarChar)
        args(7).Value = numcontrato
        args(8) = New SqlParameter("@numpc", SqlDbType.VarChar)
        args(8).Value = numpc
        args(9) = New SqlParameter("@comentario", SqlDbType.VarChar)
        args(9).Value = comentario
        args(10) = New SqlParameter("@monto", SqlDbType.Decimal)
        args(10).Value = monto

        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarProveedor(ByVal idproveedor As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_CAT_PROVEEDORES ")
        strSQL.Append(" WHERE idproveedor = @idproveedor ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idproveedor", SqlDbType.Int)
        args(0).Value = idproveedor


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarpRODUCTOSProveedor(ByVal idproveedor As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_RP_PRODUCTOSPROVEEDORES ")
        strSQL.Append(" WHERE idproveedor = @idproveedor ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idproveedor", SqlDbType.Int)
        args(0).Value = idproveedor


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarSANCIONESProveedor(ByVal idproveedor As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_RP_SANCIONESPROVEEDORES ")
        strSQL.Append(" WHERE idproveedor = @idproveedor ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idproveedor", SqlDbType.Int)
        args(0).Value = idproveedor


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarESTADOSProveedor(ByVal idproveedor As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_RP_ESTADOSPROVEEDORES ")
        strSQL.Append(" WHERE idproveedor = @idproveedor ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idproveedor", SqlDbType.Int)
        args(0).Value = idproveedor


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function EliminarDOCUMENTOSProveedor(ByVal idproveedor As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append("DELETE FROM SAB_RP_DOCUMENTOSPROVEEDORES ")
        strSQL.Append(" WHERE idproveedor = @idproveedor ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idproveedor", SqlDbType.Int)
        args(0).Value = idproveedor


        Return SqlHelper.ExecuteNonQuery(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function BuscarExistenciaIDProveedor(ByVal idproveedor As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT COUNT(IDPROVEEDOR) FROM SAB_UACI_DETALLEOFERTA ")
        strSQL.Append(" WHERE idproveedor = @idproveedor ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idproveedor", SqlDbType.Int)
        args(0).Value = idproveedor


        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function BuscarExistenciaIDProveedor2(ByVal idproveedor As Integer) As Integer


        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT COUNT(IDPROVEEDOR) FROM SAB_UACI_CONTRATOS ")
        strSQL.Append(" WHERE idproveedor = @idproveedor ")

        Dim args(1) As SqlParameter
        args(0) = New SqlParameter("@idproveedor", SqlDbType.Int)
        args(0).Value = idproveedor


        Return SqlHelper.ExecuteScalar(Me.cnnStr, CommandType.Text, strSQL.ToString(), args)

    End Function
    Public Function ObtenerReporte1y3(ByVal idproveedor As Integer, ByVal CODIGO As String) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT P.IDPROVEEDOR,P.NIT,P.NOMBRE, V.IDSUMINISTRO, V.DESCSUMINISTRO, V.CORRPRODUCTO, V.DESCLARGO, ")
        strSQL.Append(" (select CASE WHEN ESTADO=0 THEN 'HABILITADO' WHEN ESTADO=1 THEN 'INHABILITADO' END AS ESTADO FROM SAB_RP_ESTADOSPROVEEDORES WHERE IDESTADO=(SELECT MAX(IDESTADO) FROM SAB_RP_ESTADOSPROVEEDORES WHERE IDPROVEEDOR=P.IDPROVEEDOR) AND IDPROVEEDOR=P.IDPROVEEDOR) AS ESTADO ")
        strSQL.Append(" FROM SAB_CAT_PROVEEDORES P INNER JOIN SAB_RP_PRODUCTOSPROVEEDORES PP ON P.IDPROVEEDOR=PP.IDPROVEEDOR INNER JOIN VV_CATALOGOPRODUCTOS V ON V.IDPRODUCTO=PP.IDPRODUCTO ")
        If idproveedor <> 0 Then
            strSQL.Append(" WHERE P.IDPROVEEDOR=" & idproveedor)
        Else
            Select Case CODIGO
                Case Is = "0"

                Case Is = "1"
                    strSQL.Append(" WHERE V.IDSUMINISTRO=" & CInt(CODIGO))
                Case Is = "2"
                    strSQL.Append(" WHERE V.IDSUMINISTRO=" & CInt(CODIGO))
                Case Is = "3"
                    strSQL.Append(" WHERE V.IDSUMINISTRO=" & CInt(CODIGO))
                Case Is = "4"
                    strSQL.Append(" WHERE V.IDSUMINISTRO=" & CInt(CODIGO))
                Case Is = "5"
                    strSQL.Append(" WHERE V.IDSUMINISTRO=" & CInt(CODIGO))
                Case Is = "6"
                    strSQL.Append(" WHERE V.IDSUMINISTRO=" & CInt(CODIGO))
                Case Is = "7"
                    strSQL.Append(" WHERE V.IDSUMINISTRO=" & CInt(CODIGO))
                Case Is = "8"
                    strSQL.Append(" WHERE V.IDSUMINISTRO=" & CInt(CODIGO))
                Case Is = "9"
                    strSQL.Append(" WHERE V.IDSUMINISTRO=" & CInt(CODIGO))
                Case Else
                    strSQL.Append(" WHERE V.CORRPRODUCTO='" & CODIGO & "'")

            End Select

        End If

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerReporte2(ByVal idproveedor As Integer) As DataSet

        Dim strSQL As New StringBuilder
        'DATOS GENERALES
        strSQL.Append(" SELECT P.IDPROVEEDOR,P.NIT,P.NOMBRE, CASE WHEN P.PROCEDENCIA=0 THEN 'NACIONAL' WHEN P.PROCEDENCIA=1 THEN 'EXTRANJERO' END AS PROCEDENCIA, CASE WHEN P.C1=0 THEN 'NATURAL'  WHEN P.C1=1 THEN 'JURÍDICA' END AS C1, CASE WHEN P.C3=0 THEN 'PYME' WHEN P.C3=1 THEN 'NO PYME' END AS C3, P.NOMBREABREVIADO,P.DIRECCION,P.REPRESENTANTELEGAL, P.REPRESENTANTELEGAL2,P.REPRESENTANTELEGAL3, P.MATRICULA, P.TELEFONO, P.TELEFONO2,P.TELEFONO3, P.FAX,P.CORREO, CASE WHEN P.tp1=1 THEN 'OBRAS' END AS TIPOPRODUCTO1, CASE WHEN P.tp2=1 THEN 'BIENES' END TIPOPRODUCTO2, CASE WHEN P.tp3=1 THEN 'SERVICIOS' END AS TIPOPRODUCTO3, P.GIRO ")
        strSQL.Append("  FROM SAB_CAT_PROVEEDORES P ")
        strSQL.Append(" WHERE P.IDPROVEEDOR=" & idproveedor)

        'PRODUCTOS
        strSQL.Append(" SELECT V.IDSUMINISTRO, V.DESCSUMINISTRO, V.CORRPRODUCTO, V.DESCLARGO ")
        strSQL.Append(" FROM SAB_RP_PRODUCTOSPROVEEDORES PP INNER JOIN VV_CATALOGOPRODUCTOS V ON V.IDPRODUCTO=PP.IDPRODUCTO ")
        strSQL.Append(" WHERE PP.IDPROVEEDOR=" & idproveedor)

        'DOCUMENTOS
        strSQL.Append(" SELECT D.NOMBRE AS NOMBREDOCUMENTO, DP.FECHAEMISION, DP.FECHACADUCIDAD ")
        strSQL.Append(" FROM SAB_RP_DOCUMENTOSPROVEEDORES DP  INNER JOIN SAB_RP_CAT_DOCUMENTOS D ON D.IDDOCUMENTO=DP.IDDOCUMENTO ")
        strSQL.Append(" WHERE DP.IDPROVEEDOR=" & idproveedor)

        'ESTADOS
        strSQL.Append(" SELECT CASE WHEN EP.ESTADO=0 THEN 'HABILITADO' WHEN EP.ESTADO=1 THEN 'INHABILITADO' END AS ESTADO, EP.FECHACAMBIO, C.NOMBRE AS CAUSA ")
        strSQL.Append(" FROM SAB_RP_ESTADOSPROVEEDORES EP  INNER JOIN SAB_RP_CAT_CAUSAS C ON C.IDCAUSA=EP.IDCAUSA ")
        strSQL.Append(" WHERE EP.IDPROVEEDOR=" & idproveedor)

        'SANCIONES
        strSQL.Append(" SELECT  TS.NOMBRE AS TIPOSANCION, SP.FECHAIMPRESION, SP.FECHAFIRME ")
        strSQL.Append(" FROM SAB_RP_SANCIONESPROVEEDORES SP INNER JOIN SAB_RP_CAT_TIPOSANCION TS ON TS.IDTIPOSANCION=SP.IDTIPOSANCION ")
        strSQL.Append(" WHERE SP.IDPROVEEDOR=" & idproveedor)

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
    Public Function ObtenerDocumentoProveedores(ByVal idproveedor As Integer, ByVal iddocumento As Integer) As DataSet

        Dim strSQL As New StringBuilder
        strSQL.Append(" SELECT ISNULL(CONVERT(VARCHAR,DP.FECHAEMISION,103),' ') AS FECHAEMISION,ISNULL(CONVERT(VARCHAR,DP.FECHACADUCIDAD,103),' ') AS FECHACADUCIDAD, ISNULL(CONVERT(VARCHAR,DP.FECHAREPORTE,103),' ') AS FECHAREPORTE, ISNULL(DP.USUARIO,' ') AS USUARIO, ISNULL(DP.PERSONAVISTOBUENO,' ') AS PERSONAVISTOBUENO ")
        strSQL.Append(" FROM SAB_RP_DOCUMENTOSPROVEEDORES DP ")
        strSQL.Append(" WHERE DP.IDPROVEEDOR=" & idproveedor & " AND DP.IDDOCUMENTO=" & iddocumento)


        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(Me.cnnStr, CommandType.Text, strSQL.ToString())

        Return ds

    End Function
End Class
