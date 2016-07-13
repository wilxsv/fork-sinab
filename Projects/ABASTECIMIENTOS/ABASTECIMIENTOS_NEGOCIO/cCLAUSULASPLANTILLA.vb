''' -----------------------------------------------------------------------------
''' Project	 : ABASTECIMIENTOS_BL
''' Class	 : BL.cCLAUSULASPLANTILLA
'''
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones CRUD(Create, Read, Update y Delete) de la tabla SAB_UACI_CLAUSULASPLANTILLA
''' </summary>
''' <remarks>
''' Generado con GenApp V1.6.2.0, Carías y Asociados, (info@cariasyasociados.com)
''' </remarks>
''' <history>
''' 	[GenApp]	16/01/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cCLAUSULASPLANTILLA
    Inherits controladorBase

#Region " Metodos Generador "

#Region " Privadas "
    Private mDb As New dbCLAUSULASPLANTILLA()
    Private mEntidad As New CLAUSULASPLANTILLA
#End Region

    Public Function ObtenerLista(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPLANTILLA As Int32, ByVal IDCLAUSULA As Int32) As listaCLAUSULASPLANTILLA
        Try
            Return mDb.ObtenerListaPorID(IDESTABLECIMIENTO, IDPLANTILLA, IDCLAUSULA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerCLAUSULASPLANTILLA(ByRef aEntidad As CLAUSULASPLANTILLA) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.Recuperar(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerCLAUSULASPLANTILLA(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPLANTILLA As Int32, ByVal IDCLAUSULA As Int32, ByVal ORDEN As Byte) As CLAUSULASPLANTILLA
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPLANTILLA = IDPLANTILLA
            mEntidad.IDCLAUSULA = IDCLAUSULA
            mEntidad.ORDEN = ORDEN
            Dim liRet As Integer
            liRet = mDb.Recuperar(mEntidad)
            If liRet = 1 Then Return mEntidad
            Return Nothing
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function EliminarCLAUSULASPLANTILLA(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPLANTILLA As Int32, ByVal IDCLAUSULA As Int32, ByVal ORDEN As Byte) As Integer
        Try
            mEntidad.IDESTABLECIMIENTO = IDESTABLECIMIENTO
            mEntidad.IDPLANTILLA = IDPLANTILLA
            mEntidad.IDCLAUSULA = IDCLAUSULA
            mEntidad.ORDEN = ORDEN
            Return mDb.Eliminar(mEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ActualizarCLAUSULASPLANTILLA(ByVal aEntidad As CLAUSULASPLANTILLA) As Integer
        Try
            Return mDb.Actualizar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPLANTILLA As Int32, ByVal IDCLAUSULA As Int32) As DataSet
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPLANTILLA, IDCLAUSULA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDataSetPorId(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPLANTILLA As Int32, ByVal IDCLAUSULA As Int32, ByRef ds As DataSet) As Integer
        Try
            Return mDb.ObtenerDataSetPorID(IDESTABLECIMIENTO, IDPLANTILLA, IDCLAUSULA, ds)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

#End Region

End Class
