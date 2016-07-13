Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Catalogos_ucDetConsultaContratoMulta
    Inherits System.Web.UI.UserControl

    Friend Shared IDPROVEEDOR As Integer
    Public idcontrato As Integer

    Dim mContrato As New cCONTRATOS

    Public Sub cargar(ByVal midproveedor As Integer, ByVal idcontrato As Integer)
        IDPROVEEDOR = midproveedor 'Request.QueryString("idProv")
        obtenerDependencia()
        obtenerClaseSuministro(idcontrato)
        obteniendoFuenteFinanciamiento()
        obteniendoCodigoBaseFechaAceptacionConsultaContrato()
        obtenerFechaDistribucionAMontoTotal(idcontrato)
        obteniendoDatosGarantiaConsultaContrato(idcontrato, midproveedor)
        obteniendoInformacionProductosConsultaContrato()
        lblNumeroContrato.Text = Request.QueryString("id")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub obteniendoFuenteFinanciamiento()
        Me.dgFuenteFinanciamiento.DataSource = mContrato.obteniendoFuenteFinanConsultaContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)
        Me.dgFuenteFinanciamiento.DataBind()
    End Sub

    Private Sub obtenerDependencia()

        Dim ds As Data.DataSet
        ds = mContrato.obtenerDependenciasConsultaContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

        If ds.Tables(0).Rows.Count > 0 Then
            Me.lblDependenciaSolicitante.Text = ds.Tables(0).Rows(0).Item("NOMBRE")
        End If
    End Sub

    Private Sub obtenerClaseSuministro(ByVal idcontrato As Integer)

        Dim ds As Data.DataSet
        ds = mContrato.obtenerClaseSuministroConsultaContrato(Session("IdEstablecimiento"), idcontrato)

        If ds.Tables(0).Rows.Count > 0 Then
            Me.lblClaseSuministro.Text = ds.Tables(0).Rows(0).Item("DESCRIPCION")
        End If
    End Sub

    Private Sub obteniendoCodigoBaseFechaAceptacionConsultaContrato()

        Dim ds As Data.DataSet
        ds = mContrato.obteniendoCodigoBaseFechaAceptacionConsultaContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"))

        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                Me.lblCodigoBase.Text = .Item("CODIGOLICITACION")
                lblFechaResolucion.Text = .Item("FECHAFIRMAACEPTACION")
            End With
        End If
    End Sub

    Private Sub obtenerFechaDistribucionAMontoTotal(ByVal idcontrato As Integer)

        Dim ds As Data.DataSet
        ds = mContrato.obtenerFechaDistribucionAMontoTotal(Session("IdEstablecimiento"), Request.QueryString("IdProc"), idcontrato, IDPROVEEDOR)

        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                Me.lblFechaDistribucion.Text = .Item("FECHADISTRIBUCION")
                lblNumeroOferta.Text = .Item("ORDENLLEGADA")
                lblNombreProveedor.Text = .Item("PROVEEDOR")
                lblTipoPersona.Text = .Item("TIPOPERSONA")
                Me.lblMontoTotal.Text = .Item("MONTOCONTRATO")
                'Me.lblCodigoBase.Text = .Item("CODIGOLICITACION")
                'lblFechaResolucion.Text = .Item("FECHAFIRMAACEPTACION")
            End With
        End If
    End Sub

    Private Sub obteniendoDatosGarantiaConsultaContrato(ByVal idcontrato As Integer, ByVal idproveedor As Integer)
        Me.dgGarantias.DataSource = mContrato.obteniendoDatosGarantiaConsultaContrato(Session("IdEstablecimiento"), idcontrato, idproveedor)
        Me.dgGarantias.DataBind()
    End Sub

    Private Sub obteniendoInformacionProductosConsultaContrato()
        Me.dgProductos.DataSource = mContrato.obteniendoInformacionProductosConsulta(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR)
        Me.dgProductos.DataBind()
    End Sub

    Private Sub obteniendoDetallesProductosConsultaContrato(ByVal RENGLON As Integer)
        Me.dgDetalleProducto.DataSource = mContrato.obteniendoDetalleProductosConsulta(Session("IdEstablecimiento"), Request.QueryString("IdProc"), IDPROVEEDOR, RENGLON)
        Me.dgDetalleProducto.DataBind()
        Me.Label15.Visible = True
    End Sub

    Protected Sub dgProductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProductos.SelectedIndexChanged

        Dim RENGLON As Integer
        RENGLON = Me.dgProductos.SelectedItem.Cells(1).Text

        obteniendoDetallesProductosConsultaContrato(RENGLON)
    End Sub

End Class
