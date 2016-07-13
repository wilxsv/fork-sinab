Imports Microsoft.VisualBasic
Imports System

Public Class BusquedaAlmacen
    Public Shared Function GetAlmacenByIDEmplead(ByVal IDEmpleado As Integer) As Integer
        Dim IDALMACEN As Integer
        Dim dba As New ABASTECIMIENTOS.NEGOCIO.cALMACENES
        Dim oCEA As New ABASTECIMIENTOS.NEGOCIO.cEMPLEADOSALMACEN
        Dim oCA As New ABASTECIMIENTOS.NEGOCIO.cALMACENES
        Dim oEAlmacenes As New ABASTECIMIENTOS.ENTIDADES.ALMACENES
        Dim dsAlm As New Data.DataSet
        dsAlm = oCEA.ObtenerDsIdAlmacen(IDEmpleado)
        For ca As Integer = 0 To dsAlm.Tables(0).Rows.Count
            oEAlmacenes = oCA.ObtenerALMACENES(dsAlm.Tables(0).Rows(ca)("IDALMACEN"))
            If Not CBool(oEAlmacenes.ESFARMACIA) Then
                IDALMACEN = oEAlmacenes.IDALMACEN
                Exit For
            End If
        Next
        Return IDALMACEN
    End Function
End Class
