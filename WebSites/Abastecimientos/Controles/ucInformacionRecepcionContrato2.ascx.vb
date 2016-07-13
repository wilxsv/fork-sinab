Partial Class Controles_ucInformacionRecepcionContrato2
    Inherits System.Web.UI.UserControl

    Public Event SeleccionarRenglon()

    Private idEstablecimiento As Integer
    Private idProveedor As Integer
    Private idProceso As Integer
    Private idAlmacen As Integer
    Private renglon As Integer

    Public Property _idEstablecimiento() As Integer
        Get
            Return idEstablecimiento
        End Get
        Set(ByVal value As Integer)
            idEstablecimiento = value
        End Set
    End Property

    Public Property _idProveedor() As Integer
        Get
            Return idProveedor
        End Get
        Set(ByVal value As Integer)
            idProveedor = value
        End Set
    End Property

    Public Property _idProceso() As Integer
        Get
            Return idProceso
        End Get
        Set(ByVal value As Integer)
            idProceso = value
        End Set
    End Property

    Public Property _idAlmacen() As Integer
        Get
            Return idAlmacen
        End Get
        Set(ByVal value As Integer)
            idAlmacen = value
        End Set
    End Property

    Public ReadOnly Property _renglon() As Integer
        Get
            Return renglon
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



    End Sub
    Public Sub Cargar()
        'Dim eEntidad As ABASTECIMIENTOS.ENTIDADES.CONTRATOS
        'Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cCONTRATOS

        Dim eEntidadRecibo As New ABASTECIMIENTOS.ENTIDADES.RECIBOSRECEPCION
        Dim cEntidadRecibo As New ABASTECIMIENTOS.NEGOCIO.cRECIBOSRECEPCION
        Dim cFF As New ABASTECIMIENTOS.NEGOCIO.cFUENTEFINANCIAMIENTOS
        Dim cP As New ABASTECIMIENTOS.NEGOCIO.cPROVEEDORES
        'eEntidad = cEntidad.obtenerDatosContrato2(idEstablecimiento, idProveedor, idContrato)

        Dim cPC As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS

        Dim ds As Data.DataSet
        ds = cPC.ObtenerInformacionProceso(idProceso, idEstablecimiento)

        If ds.Tables(0).Rows.Count <> 0 Then
            Me.lblModCompra.Text = ds.Tables(0).Rows(0).Item(0)
            Me.lblNoModCompra.Text = ds.Tables(0).Rows(0).Item(0)
            Me.lblFuenteFinanc.Text = cFF.DevolverFFPC(idProceso, idEstablecimiento)
            Me.lblResAdjud.Text = ds.Tables(0).Rows(0).Item(0)
            Dim eEntidadP As New ABASTECIMIENTOS.ENTIDADES.PROVEEDORES
            eEntidadP.IDPROVEEDOR = idProveedor
            cP.ObtenerPROVEEDORES(eEntidadP)
            Me.lblProveedor.Text = eEntidadP.NOMBRE
            Me.dtRecepcion.SelectedDate = Now

            eEntidadRecibo.IDALMACEN = idAlmacen
            eEntidadRecibo.ANIO = Now.Year

            Me.txtNoRecepcion.Text = cEntidadRecibo.ObtenerID(eEntidadRecibo)
            Dim cAEA As New ABASTECIMIENTOS.NEGOCIO.cALMACENESENTREGAADJUDICACION
            '  cAEA.obtenerDistribucionProducto()

            ' Me.gvRenglones.DataSource = cEntidad.obtenerRenglonesContrato(idEstablecimiento, idProveedor, idContrato, idAlmacen)
            Me.gvRenglones.DataBind()
        End If
        
    End Sub
    Protected Sub gvRenglones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvRenglones.SelectedIndexChanged

        renglon = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("RENGLON")
        idEstablecimiento = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDESTABLECIMIENTO")
        idProveedor = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDPROVEEDOR")
        ' idContrato = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDCONTRATO")
        idAlmacen = Me.gvRenglones.DataKeys(Me.gvRenglones.SelectedIndex).Item("IDALMACENENTREGA")

        RaiseEvent SeleccionarRenglon()

    End Sub
End Class
