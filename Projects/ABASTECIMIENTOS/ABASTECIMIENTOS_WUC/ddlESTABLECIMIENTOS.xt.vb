Partial Public Class ddlESTABLECIMIENTOS

    Private miComponente As New cESTABLECIMIENTOS

#Region " Metodos Agregados"

    Public Sub RecuperarOrdenada(ByVal tipo As Integer)
        Me.DataSource = miComponente.ObtenerListaOrden(tipo)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDESTABLECIMIENTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarPorSibasi(ByVal IDESTABLECIMIENTO As Int32)
        Me.DataSource = miComponente.obtenetEstablecimientosXSibasi(IDESTABLECIMIENTO)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDESTABLECIMIENTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarEstablecimientosZonaETZ(Optional ByVal IDZONA As Int32 = 0)
        Me.DataSource = miComponente.FiltrosEstablecimientosETZ(IDZONA)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDESTABLECIMIENTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarCodigoEstablecimiento()
        Me.DataSource = miComponente.ObtenerDataSetCodigoEstablecimiento()
        Me.DataTextField = "NOMBRECODIGO"
        Me.DataValueField = "IDESTABLECIMIENTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarEstablecimientosPorZonaAlmancen(ByVal IDALMACEN As Integer, Optional ByVal VERTODOS As Integer = 0)
        Me.DataSource = miComponente.RecuperarEstablecimientosPorZonaAlmancen(IDALMACEN, VERTODOS)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDESTABLECIMIENTO"
        Me.DataBind()
    End Sub

    Public Sub ObtenerLista2(ByVal IDZONA As Integer)
        Me.DataSource = miComponente.ObtenerLista2(IDZONA)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDESTABLECIMIENTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarLugarEntregaHospital(ByVal IDALMACEN As Integer, Optional ByVal VERTODOS As Integer = 0)
        Me.DataSource = miComponente.RecuperarLugaresDestinoHospitales(IDALMACEN, VERTODOS)
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "ID_LUGAR_ENTREGA_HOSPITAL"
        Me.DataBind()
    End Sub

    Public Sub RecuperarEstablecimientos()
        Me.DataSource = miComponente.RecuperarEstablecimientos
        Me.DataTextField = "NOMBRE"
        Me.DataValueField = "IDESTABLECIMIENTO"
        Me.DataBind()
    End Sub

#End Region

End Class
