Partial Public Class ddlPROVEEDORES

    Private miComponente As New cPROVEEDORES

#Region " Metodos Agregados "

    Public Sub RecuperarNombre()
        Me.DataSource = miComponente.ObtenerLista()
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDPROVEEDOR"
        Me.DataBind()
    End Sub

    Public Sub ObtenerDsProveedorProcesoCompra(ByVal IDPROCESOCOMPRA As Integer, ByVal IDESTABLECIMIENTO As Integer)
        Me.DataSource = miComponente.ObtenerDsProveedorProcesoCompra(IDPROCESOCOMPRA, IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDPROVEEDOR"
        Me.DataBind()
    End Sub

    Public Sub RecuperarlistaOrdenada(ByVal tipo As Integer)
        Me.DataSource = miComponente.ObtenerListaordenada(tipo)
        Me.DataTextField = "CODIGOPROVEEDOR"
        Me.DataValueField = "IDPROVEEDOR"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaNombreOrdenada(Optional ByVal tipo As Integer = 1)
        Me.DataSource = miComponente.ObtenerListaNombreOrdenada(tipo)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDPROVEEDOR"
        Me.DataBind()
    End Sub

    Public Sub ObtenerProveedoresEntregasPendiente()
        Dim miComponente As New cCONTRATOS
        Me.DataSource = miComponente.ObtenerProveedoresEntregasPendiente()
        Me.DataTextField = "NOMBREPROVEEDOR"
        Me.DataValueField = "IDPROVEEDOR"
        Me.DataBind()
    End Sub

    Public Sub ObtenerProveedoresClasificados(ByVal CLASIFICACION As Int16)
        Me.DataSource = miComponente.ObtenerProveedoresClasificados(CLASIFICACION)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDPROVEEDOR"
        Me.DataBind()
    End Sub

    Public Sub ObtenerProveedoresNoAsignados(ByVal IDESTABLECIMIENTO As Int64, ByVal IDPROCESOCOMPRA As Int64)
        Dim miComponente As New cANALISTAPROVEEDORES
        Me.DataSource = miComponente.ObtenerProveedoresNoAsignados(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDPROVEEDOR"
        Me.DataBind()
    End Sub

    Public Sub ObtenerProveedoresContratoEnAlmacen(ByVal IDALMACEN As Integer)
        Me.DataSource = miComponente.ObtenerProveedoresContratoEnAlmacen(IDALMACEN)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDPROVEEDOR"
        Me.DataBind()
    End Sub

    Public Sub ObtenerProveedoresContratoEstablecimiento(ByVal IDESTABLECIMIENTO As Integer)
        Me.DataSource = miComponente.ObtenerProveedoresContratoEstablecimiento(IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDPROVEEDOR"
        Me.DataBind()
    End Sub

#End Region

End Class
