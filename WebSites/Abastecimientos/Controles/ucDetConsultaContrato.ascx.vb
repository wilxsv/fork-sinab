Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES


Partial Class Catalogos_ucDetConsultaContrato
    Inherits System.Web.UI.UserControl

    Dim mContrato As New cCONTRATOS

    Private _IDPROVEEDOR As Integer

    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            _IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
        End If
        IDPROVEEDOR = Request.QueryString("idProv")
        obtenerDependencia()
        obtenerClaseSuministro()
        obteniendoFuenteFinanciamiento()
        obteniendoCodigoBaseFechaAceptacionConsultaContrato()
        obtenerFechaDistribucionAMontoTotal()
        obteniendoDatosGarantiaConsultaContrato()
        obteniendoInformacionProductosConsultaContrato()
        lblNumeroContrato.Text = Request.QueryString("numcon")
    End Sub

    Private Sub obteniendoFuenteFinanciamiento()

        Me.dgFuenteFinanciamiento.DataSource = mContrato.obteniendoFuenteFinanConsultaContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Request.QueryString("idProv"))
        Me.dgFuenteFinanciamiento.DataBind()
    End Sub

    Private Sub obtenerDependencia()
        Dim ds As Data.DataSet
        ds = mContrato.obtenerDependenciasConsultaContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"))
        If ds.Tables(0).Rows.Count > 0 Then
            Me.lblDependenciaSolicitante.Text = ds.Tables(0).Rows(0).Item("NOMBRE")
        End If
    End Sub

    Private Sub obtenerClaseSuministro()
        Dim ds As Data.DataSet
        ds = mContrato.obtenerClaseSuministroConsultaContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"))
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

    Private Sub obtenerFechaDistribucionAMontoTotal()
        Dim ds As Data.DataSet
        ds = mContrato.obtenerFechaDistribucionAMontoTotal(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Request.QueryString("id"), IDPROVEEDOR)
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                Me.lblFechaDistribucion.Text = .Item("FECHADISTRIBUCION")
                lblNumeroOferta.Text = .Item("ORDENLLEGADA")
                lblNombreProveedor.Text = .Item("PROVEEDOR")
                If .Item("TIPOPERSONA") = "N" Then
                    lblTipoPersona.Text = "Natural"
                ElseIf .Item("TIPOPERSONA") = "J" Then
                    lblTipoPersona.Text = "Jurídica"
                End If

                Me.lblMontoTotal.Text = "(USD$) " & CStr(Format(.Item("MONTOCONTRATO"), "##,###.00"))
                'Me.lblCodigoBase.Text = .Item("CODIGOLICITACION")
                'lblFechaResolucion.Text = .Item("FECHAFIRMAACEPTACION")
            End With
        End If
    End Sub

    Private Sub obteniendoDatosGarantiaConsultaContrato()
        Me.dgGarantias.DataSource = mContrato.obteniendoDatosGarantiaConsultaContrato(Session("IdEstablecimiento"), Request.QueryString("id"), IDPROVEEDOR)
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

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Response.Redirect("~/UACI/FrmConsultarContratos.aspx")
    End Sub

End Class
