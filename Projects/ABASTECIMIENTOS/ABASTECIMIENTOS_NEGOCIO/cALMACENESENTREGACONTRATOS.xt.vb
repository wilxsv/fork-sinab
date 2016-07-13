Partial Public Class cALMACENESENTREGACONTRATOS

    Public Function RptComprasEnTransito(ByVal IDESTABLECIMIENTO As Integer, ByVal IDZONA As Integer, ByVal IDSUMINISTRO As Integer, ByVal IDGRUPO As Integer, ByVal IDSUBGRUPO As Integer, ByVal IDPRODUCTO As Integer) As DataSet
        Try
            Return mDb.RptComprasEnTransito(IDESTABLECIMIENTO, IDZONA, IDSUMINISTRO, IDGRUPO, IDSUBGRUPO, IDPRODUCTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDsEntregas(ByVal IDESTABLECIMIENTO As Int32, ByVal IDPROVEEDOR As Int32, ByVal IDCONTRATO As Int64, ByVal RENGLON As Int64, ByVal IDALMACENENTREGA As Int32, Optional ByVal IDFUENTEFINANCIAMIENTO As Integer = -1, Optional ByVal ORDEN As Int16 = 0) As DataSet
        Try
            Return mDb.ObtenerDsEntrega(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, IDALMACENENTREGA, ORDEN, IDFUENTEFINANCIAMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarCantidadEntregada(ByVal aEntidad As ALMACENESENTREGACONTRATOS) As Integer
        Try
            Return mDb.ActualizarCantidadEntregada(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

End Class