Partial Public Class cCANCELACIONPRODUCTO

#Region " Metodos Agregados "

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="aEntidad"></param>
    ''' <param name="aLista"></param>
    ''' <param name="ESTAHABILITADO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ActualizarCancelacionDetalleLote(ByVal aEntidad As CANCELACIONPRODUCTO, ByVal aLista As listaDETALLECANCELACIONPRODUCTO, ByVal ESTAHABILITADO As Integer) As Integer

        Try
            mDb.Actualizar(aEntidad)

            Dim cDCP As New cDETALLECANCELACIONPRODUCTO
            Dim cCL As New cCANCELACIONLOTE
            Dim eCL As New CANCELACIONLOTE

            For Each e As DETALLECANCELACIONPRODUCTO In aLista
                e.IDCANCELACION = aEntidad.IDCANCELACION

                cDCP.ActualizarDETALLECANCELACIONPRODUCTO(e)

                eCL.IDESTABLECIMIENTO = e.IDESTABLECIMIENTO
                eCL.IDPROVEEDOR = e.IDPROVEEDOR
                eCL.IDCONTRATO = e.IDCONTRATO
                eCL.RENGLON = e.RENGLON
                eCL.LOTE = e.LOTE
                eCL.ESTAHABILITADO = e.ESTAHABILITADO
                eCL.AUUSUARIOCREACION = e.AUUSUARIOCREACION
                eCL.AUFECHACREACION = e.AUFECHACREACION
                eCL.AUUSUARIOMODIFICACION = e.AUUSUARIOMODIFICACION
                eCL.AUFECHAMODIFICACION = e.AUFECHAMODIFICACION
                eCL.ESTASINCRONIZADA = e.ESTASINCRONIZADA

                cCL.ActualizarCANCELACIONLOTE(eCL)
            Next

            Dim cPC As New cPRODUCTOSCONTRATO
            cPC.HabilitarRecepcionesRenglon(aEntidad.IDESTABLECIMIENTO, aEntidad.IDPROVEEDOR, aEntidad.IDCONTRATO, aEntidad.RENGLON, ESTAHABILITADO)

            Return 1
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <param name="RENGLON"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    '''     [Carlos Ceconi]    Creado
    ''' </history>
    Public Function ObtenerCancelacionesPorRenglon(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64) As DataSet
        Try
            Return mDb.ObtenerCancelacionesPorRenglon(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

#End Region

End Class
