
Public Class cPROVEEDORESCG
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbPROVEEDORESCG()
    Private mPROVEEDORES As New PROVEEDORESCG
#End Region

    Public Function ObtenerPROVEEDORES(ByRef aPROVEEDORES As PROVEEDORESCG) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aPROVEEDORES)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerPROVEEDORES(ByVal IDPROVEEDORES As Int32, ByVal IDESTABLECIMIENTO As Integer) As PROVEEDORESCG
        Try
            mPROVEEDORES.IDPROVEEDOR = IDPROVEEDORES
            mPROVEEDORES.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Dim liRet As Integer
            liRet = mDb.Recuperar(mPROVEEDORES)
            If liRet = 1 Then Return mPROVEEDORES
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarPROVEEDORES(ByVal IDPROVEEDORES As Int32, ByVal IDESTABLECIMIENTO As Integer) As Integer
        Try
            mPROVEEDORES.IDPROVEEDOR = IDPROVEEDORES
            mPROVEEDORES.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            Return mDb.Eliminar(mPROVEEDORES)
        Catch ex As System.Data.SqlClient.SqlException
            ExceptionManager.Publish(ex)
            Return ex.Number
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarPROVEEDORES(ByVal aPROVEEDORES As PROVEEDORESCG) As Integer
        Try
            Return mDb.Actualizar(aPROVEEDORES)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function ObtenerDataSetPorId2(ByVal IDPROVEEDOR As Integer, ByVal IDESTABLECIMIENTO As Integer) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID2(IDPROVEEDOR, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerID2(ByVal IDESTABLECIMIENTO As Integer) As Integer
        Try
            Return mDb.ObtenerID2(IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function ObtenerDataSetPorNIT(ByVal idestablecimiEnto As Integer, ByVal NIT As String) As Integer
        Try
            Return mDb.ObtenerDataSetPorNIT(idestablecimiEnto, NIT)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function
    Public Function ObtenerProveedorPorNIT(ByVal idestablecimiEnto As Integer, ByVal NIT As String) As DataSet
        Try
            Return mDb.ObtenerProveedorPorNIT(idestablecimiEnto, NIT)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
    Public Function ObtenerProveedorPorIdProveedor(ByVal idestablecimiEnto As Integer, ByVal idp As Integer) As DataSet
        Try
            Return mDb.ObtenerProveedorPorIdProveedor(idestablecimiEnto, idp)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function
#End Region

End Class
