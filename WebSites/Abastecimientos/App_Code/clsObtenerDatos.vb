Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Imports System

Public Class clsObtenerDatos

    Public Shared ReadOnly Property CustomerDataSet(ByVal IDESTABLECIMIENTO As System.Int64) As DataSet
        Get
            Dim mComponente As New cPROCESOCOMPRAS
            Return mComponente.ObtenerDataSetPorId(IDESTABLECIMIENTO)
        End Get
    End Property

    Public Shared ReadOnly Property ActaAperturaOfertaDataSet(ByVal IDESTABLECIMIENTO As System.Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Get
            Dim mComponente As New cPROCESOCOMPRAS
            Return mComponente.obtenerDatasetActaAperturaOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        End Get
    End Property

    Public Shared ReadOnly Property EmpleadosAperturaOfertaDataSet(ByVal IDESTABLECIMIENTO As System.Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Get
            Dim mComponente As New cPROCESOCOMPRAS
            Return mComponente.obtenerDatasetEmpleadoAperturaOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        End Get
    End Property

    Public Shared ReadOnly Property FuenteFinanciamientoAperturaOfertaDataSet(ByVal IDESTABLECIMIENTO As System.Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Get
            Dim mComponente As New cFUENTEFINANCIAMIENTOSOLICITUDES
            Return mComponente.obtenerdatasetFuenteFinanciamientoProceCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        End Get
    End Property

    Public Shared ReadOnly Property CatalogoProductosDataset(ByVal IDPRODUCTO As String) As DataSet
        Get
            Dim mComponente As New cCATALOGOPRODUCTOS
            Return mComponente.FiltrarCatalogoProductos(IDPRODUCTO, 4, 0)
        End Get
    End Property

    Public Shared ReadOnly Property NvoEmpleadosAperturaOfertaDataSet(ByVal IDESTABLECIMIENTO As System.Int64, ByVal IDPROCESOCOMPRA As Int64) As DataSet
        Get
            Dim mComponente As New cPROCESOCOMPRAS
            Return mComponente.obtenerNvoDatasetEmpleadoAperturaOferta(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        End Get
    End Property

    Public Shared Function OpcionPermiteEditar(ByVal IDROL As Int32, ByVal URL As String) As Boolean
        Dim c As New cOPCIONESSISTEMAROLES
        Return c.OpcionPermiteEditar(IDROL, URL)
    End Function

End Class