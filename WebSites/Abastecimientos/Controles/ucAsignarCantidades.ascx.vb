Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucAsignarCantidades
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Int32
    Private _IDPROCESOCOMPRA As Int64
    Private _IDPRODUCTO As Int64
    Private _RENGLON As Int32
    Private _IDDETALLEOFERTA As Int64
    Private _IDDETALLEPROCESOCOMPRA As Int64
    Private _IDPROVEEDOR As Int32

    Private _PlazoEntrega As String
    Private _CantidadDecimalesUnidadMedida As Integer
    Private _UM As String
    Private _UMB As String

    Private _CantidadSolicitada As Decimal
    Private _CantidadOferta As Decimal
    Private _CantidadRecomendada As Decimal
    Private _CantidadAdjudicada As Decimal
    Private _CantidadAdjudicadaEnFirme As Decimal
    Private _CantidadAsignadaOfertaSeleccionada As Decimal
    Private _TotalAsignadoOtrosProveedores As Decimal
    Private _TotalAsignadoMismoProveedor As Decimal
    Private _TipoCantidad As Integer
    Private mComponente As New cPROCESOCOMPRAS
    Public Event Guardar()
    Public Event Eliminar()
    Public Event Cancelar()

    Dim dt As New System.Data.DataTable

#Region " Propiedades "

    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Int32)
            _IDESTABLECIMIENTO = Value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", Value)
        End Set
    End Property

    Public Property IDPROCESOCOMPRA() As Int64
        Get
            Return Me._IDPROCESOCOMPRA
        End Get
        Set(ByVal Value As Int64)
            Me._IDPROCESOCOMPRA = Value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IdProcesoCompra", Value)
        End Set
    End Property

    Public Property IDPRODUCTO() As Int64
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal Value As Int64)
            _IDPRODUCTO = Value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", Value)
        End Set
    End Property

    Public Property RENGLON() As Int32
        Get
            Return _RENGLON
        End Get
        Set(ByVal Value As Int32)
            _RENGLON = Value
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.ViewState.Remove("RENGLON")
            Me.ViewState.Add("RENGLON", Value)
        End Set
    End Property

    Public Property IDDETALLEOFERTA() As Int64
        Get
            Return _IDDETALLEOFERTA
        End Get
        Set(ByVal Value As Int64)
            _IDDETALLEOFERTA = Value
            If Not Me.ViewState("IDDETALLEOFERTA") Is Nothing Then Me.ViewState.Remove("IDDETALLEOFERTA")
            Me.ViewState.Add("IDDETALLEOFERTA", Value)
        End Set
    End Property

    Public Property IDDETALLEPROCESOCOMPRA() As Int64
        Get
            Return _IDDETALLEPROCESOCOMPRA
        End Get
        Set(ByVal Value As Int64)
            _IDDETALLEPROCESOCOMPRA = Value
            If Not Me.ViewState("IDDETALLEPROCESOCOMPRA") Is Nothing Then Me.ViewState.Remove("IDDETALLEPROCESOCOMPRA")
            Me.ViewState.Add("IDDETALLEPROCESOCOMPRA", Value)
        End Set
    End Property

    Public Property IDPROVEEDOR() As Int32
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal Value As Int32)
            _IDPROVEEDOR = Value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", Value)
        End Set
    End Property

    Public Property PlazoEntrega() As String
        Get
            Return _PlazoEntrega
        End Get
        Set(ByVal Value As String)
            _PlazoEntrega = Value
        End Set
    End Property

    Public Property CantidadDecimalesUnidadMedida() As Integer
        Get
            Return _CantidadDecimalesUnidadMedida
        End Get
        Set(ByVal Value As Integer)
            _CantidadDecimalesUnidadMedida = Value
            Me.nbCantidadRecomendada.DecimalPlaces = Value
            Me.nbCantidadAdjudicada.DecimalPlaces = Value
            Me.nbCantidadAdjudicadaEnFirme.DecimalPlaces = Value
        End Set
    End Property

    Public Property UnidadMedida() As String
        Get
            Return _UM
        End Get
        Set(ByVal Value As String)
            _UM = Value
        End Set
    End Property

    Public Property UnidadMedidaB() As String
        Get
            Return _UMB
        End Get
        Set(ByVal Value As String)
            _UMB = Value
        End Set
    End Property

    Public Property CantidadOferta() As Decimal
        Get
            Return _CantidadOferta
        End Get
        Set(ByVal Value As Decimal)
            _CantidadOferta = Value
            Me.cvCantidadOferta.ValueToCompare = Value.ToString
        End Set
    End Property

    Public Property CantidadSolicitada() As Decimal
        Get
            Return _CantidadSolicitada
        End Get
        Set(ByVal Value As Decimal)
            _CantidadSolicitada = Value
        End Set
    End Property

    Public Property CantidadRecomendada() As Decimal
        Get
            Return _CantidadRecomendada
        End Get
        Set(ByVal Value As Decimal)
            _CantidadRecomendada = Value
        End Set
    End Property

    Public Property CantidadAdjudicada() As Decimal
        Get
            Return _CantidadAdjudicada
        End Get
        Set(ByVal Value As Decimal)
            _CantidadAdjudicada = Value
        End Set
    End Property

    Public Property CantidadAdjudicadaEnFirme() As Decimal
        Get
            Return _CantidadAdjudicadaEnFirme
        End Get
        Set(ByVal Value As Decimal)
            _CantidadAdjudicadaEnFirme = Value
        End Set
    End Property

    Public Property CantidadAsignadaOfertaSeleccionada() As Decimal
        Get
            Return _CantidadAsignadaOfertaSeleccionada
        End Get
        Set(ByVal Value As Decimal)
            _CantidadAsignadaOfertaSeleccionada = Value
            If Value > 0 Then
                Me.btnEliminar.Enabled = True
                Me.btnEliminar.Visible = True
            Else
                Me.btnEliminar.Enabled = False
                Me.btnEliminar.Visible = False
            End If
        End Set
    End Property

    Public Property TotalAsignadoOtrosProveedores() As Decimal
        Get
            Return _TotalAsignadoOtrosProveedores
        End Get
        Set(ByVal Value As Decimal)
            _TotalAsignadoOtrosProveedores = Value
            Me.cvCantidadSolicitada.ValueToCompare = (Me.CantidadSolicitada - Value).ToString
        End Set
    End Property

    Public Property TotalAsignadoMismoProveedor() As Decimal
        Get
            Return _TotalAsignadoMismoProveedor
        End Get
        Set(ByVal Value As Decimal)
            _TotalAsignadoMismoProveedor = Value
        End Set
    End Property

    Public Property TipoCantidad() As Integer
        Get
            Return _TipoCantidad
        End Get
        Set(ByVal Value As Integer)
            Select Case Value
                Case 1

                    Me.nbCantidadRecomendada.Visible = True
                    Me.nbCantidadAdjudicada.Visible = False
                    Me.nbCantidadAdjudicadaEnFirme.Visible = False

                    Me.rfvCantidadAsignada.ControlToValidate = Me.nbCantidadRecomendada.ID
                    Me.rfvCantidadAsignada.ErrorMessage = "Debe ingresar la cantidad recomendada."

                    Me.cvCantidadAsignada.ControlToValidate = Me.nbCantidadRecomendada.ID
                    Me.cvCantidadAsignada.ErrorMessage = "La cantidad recomendada debe ser mayor a cero."

                    'CAMBIO A PETICIÒN POR EL ING.CEVALLOS
                    Me.cvCantidadSolicitada.ControlToValidate = Me.nbCantidadRecomendada.ID
                    Me.cvCantidadSolicitada.ErrorMessage = "El total recomendado no puede superar el total solicitado."

                    Me.cvCantidadOferta.ControlToValidate = Me.nbCantidadRecomendada.ID
                    Me.cvCantidadOferta.ErrorMessage = "La cantidad recomendada no puede superar la cantidad ofrecida por el proveedor."

                    Me.lblCantidadRecomendada.Visible = False
                    Me.txtCantidadRecomendada.Visible = False
                    Me.lblCantidadAdjudicada.Visible = False
                    Me.txtCantidadAdjudicada.Visible = False

                    Me.lblCantidadOtrosProveedores.Text = "Total recomendado a otros proveedores para este renglón:"

                    Me.lblCantidadAsignada.Text = "Cantidad recomendada:"

                    Me.lblPlazosEntrega.Text = "Plazos de entrega recomendados:"

                    Me.btnEliminar.ToolTip = "Elimina la cantidad recomendada previamente a esta oferta."
                    Me.btnGuardar.ToolTip = "Guarda la cantidad recomendada a esta oferta."

                    Me.lblError.Text = "Ya se ha recomendado otra oferta del mismo proveedor, por lo que no puede recomendarse ésta."

                    Me.lblObservacion.Visible = False
                    Me.txtObservacion.Visible = False

                Case 2

                    Me.nbCantidadRecomendada.Visible = False
                    Me.nbCantidadAdjudicada.Visible = True
                    Me.nbCantidadAdjudicadaEnFirme.Visible = False

                    Me.rfvCantidadAsignada.ControlToValidate = Me.nbCantidadAdjudicada.ID
                    Me.rfvCantidadAsignada.ErrorMessage = "Debe ingresar la cantidad a adjudicar."
                    'Me.rfvCantidadAsignada.Enabled = True

                    Me.cvCantidadAsignada.ControlToValidate = Me.nbCantidadAdjudicada.ID
                    Me.cvCantidadAsignada.ErrorMessage = "La cantidad adjudicada debe ser mayor a cero."

                    'CAMBIO A PETICION DEL ING.CEVALLOS
                    Me.cvCantidadSolicitada.ControlToValidate = Me.nbCantidadAdjudicada.ID
                    Me.cvCantidadSolicitada.ErrorMessage = "El total adjudicado no puede superar el total solicitado."

                    Me.cvCantidadOferta.ControlToValidate = Me.nbCantidadAdjudicada.ID
                    Me.cvCantidadOferta.ErrorMessage = "La cantidad adjudicada no puede superar la cantidad ofrecida por el proveedor."

                    Me.lblCantidadRecomendada.Visible = True
                    Me.txtCantidadRecomendada.Visible = True
                    Me.lblCantidadAdjudicada.Visible = False
                    Me.txtCantidadAdjudicada.Visible = False

                    Me.lblCantidadOtrosProveedores.Text = "Total adjudicado a otros proveedores para este renglón:"

                    Me.lblCantidadAsignada.Text = "Cantidad a adjudicar:"

                    Me.lblPlazosEntrega.Text = "Plazos de entrega para adjudicación:"

                    Me.btnEliminar.ToolTip = "Elimina la cantidad adjudicada previamente a esta oferta."
                    Me.btnGuardar.ToolTip = "Guarda la cantidad adjudicada a esta oferta."

                    Me.lblError.Text = "Ya se ha adjudicado otra oferta del mismo proveedor, por lo que no puede adjudicarse ésta."

                    Me.lblObservacion.Visible = True
                    Me.txtObservacion.Visible = True

                Case 3

                    Me.nbCantidadRecomendada.Visible = False
                    Me.nbCantidadAdjudicada.Visible = False
                    Me.nbCantidadAdjudicadaEnFirme.Visible = True

                    Me.rfvCantidadAsignada.ControlToValidate = Me.nbCantidadAdjudicadaEnFirme.ID
                    Me.rfvCantidadAsignada.ErrorMessage = "Debe ingresar la cantidad a adjudicar en firme."

                    Me.cvCantidadAsignada.ControlToValidate = Me.nbCantidadAdjudicadaEnFirme.ID
                    Me.cvCantidadAsignada.ErrorMessage = "La cantidad adjudicada debe ser mayor a cero."

                    'CAMBIO A PETICIÒN DEL ING.CEVALLOS
                    Me.cvCantidadSolicitada.ControlToValidate = Me.nbCantidadAdjudicadaEnFirme.ID
                    Me.cvCantidadSolicitada.ErrorMessage = "El total adjudicado no puede superar el total solicitado."

                    Me.cvCantidadOferta.ControlToValidate = Me.nbCantidadAdjudicadaEnFirme.ID
                    Me.cvCantidadOferta.ErrorMessage = "La cantidad adjudicada no puede superar la cantidad ofrecida por el proveedor."

                    Me.lblCantidadRecomendada.Visible = True
                    Me.txtCantidadRecomendada.Visible = True
                    Me.lblCantidadAdjudicada.Visible = True
                    Me.txtCantidadAdjudicada.Visible = True

                    Me.lblCantidadOtrosProveedores.Text = "Total adjudicado a otros proveedores para este renglón:"

                    Me.lblCantidadAsignada.Text = "Cantidad a adjudicar:"

                    Me.lblPlazosEntrega.Text = "Plazos de entrega para adjudicación en firme:"

                    Me.btnEliminar.ToolTip = "Elimina la cantidad adjudicada previamente a esta oferta."
                    Me.btnGuardar.ToolTip = "Guarda la cantidad adjudicada a esta oferta."

                    Me.lblError.Text = "Ya se ha adjudicado otra oferta del mismo proveedor, por lo que no puede adjudicarse ésta."

                    Me.lblObservacion.Visible = True
                    Me.txtObservacion.Visible = True

                Case Else
                    Me.rfvCantidadAsignada.Visible = False
                    Me.cvCantidadAsignada.Visible = False
                    Me.cvCantidadSolicitada.Visible = False
                    Me.cvCantidadOferta.Visible = False

                    Me.lblCantidadRecomendada.Visible = False
                    Me.txtCantidadRecomendada.Visible = False
                    Me.lblCantidadAdjudicada.Visible = False
                    Me.txtCantidadAdjudicada.Visible = False

                    Me.lblObservacion.Visible = False
                    Me.txtObservacion.Visible = False

            End Select

            _TipoCantidad = Value

            If Not Me.ViewState("TipoCantidad") Is Nothing Then Me.ViewState.Remove("TipoCantidad")
            Me.ViewState.Add("TipoCantidad", Value)

        End Set
    End Property

    Public WriteOnly Property Observaciones() As String
        Set(ByVal value As String)
            Me.txtObservacion.Text = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me._IDPROCESOCOMPRA = Me.ViewState("IdProcesoCompra")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDDETALLEOFERTA") Is Nothing Then Me._IDDETALLEOFERTA = Me.ViewState("IDDETALLEOFERTA")
            If Not Me.ViewState("IDDETALLEPROCESOCOMPRA") Is Nothing Then Me._IDDETALLEPROCESOCOMPRA = Me.ViewState("IDDETALLEPROCESOCOMPRA")
            If Not Me.ViewState("TipoCantidad") Is Nothing Then Me._TipoCantidad = Me.ViewState("TipoCantidad")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("RENGLON") Is Nothing Then Me._RENGLON = Me.ViewState("RENGLON")
            If Not Me.ViewState("dt") Is Nothing Then Me.dt = Me.ViewState("dt")
            If Not Me.ViewState("dt") Is Nothing Then Me.dt = Me.ViewState("dt")
        End If

    End Sub

    Public Sub CargarDatos()

        CargarDatosEntregasSolicitadas()
        CargarDatosEntregasPorOferta()
        CargarTotales()

        Me.txtOfertaProveedorCantidad.Text = Me.CantidadOferta
        Me.lblUnidadMedidaOferta.Text = Me.UnidadMedida
        Me.txtOfertaProveedorPlazo.Text = Me.PlazoEntrega

        Me.txtCantidadSolicitada.Text = Me.CantidadSolicitada
        Me.lblUnidadMedidaCantidadSolicitada.Text = Me.UnidadMedidaB

        If TipoCantidad = 1 Then
            Me.nbCantidadAdjudicada.Text = IIf(Me.CantidadOferta = Me.CantidadSolicitada, Me.CantidadSolicitada, 0)
        End If

        Me.txtCantidadRecomendada.Text = Me.CantidadRecomendada
        Me.txtCantidadAdjudicada.Text = Me.CantidadAdjudicada

        Me.txtCantidadOtrosProveedores.Text = Me.TotalAsignadoOtrosProveedores

        Dim dsMontoSolicitado As Decimal = SINAB_Entidades.Helpers.UACIHelpers.ProcesoCompras.ObtenerMontoTotal(IDESTABLECIMIENTO, CType(IDPROCESOCOMPRA, Integer))


        Dim dstotalAdjudicado As Decimal
        dstotalAdjudicado = Me.mComponente.dsTotalAdjudicado(Me.IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        Me.txtTotalSolicitado.Text = FormatNumber(dsMontoSolicitado, 2)
        Me.txtTotalAdjudicado.Text = FormatNumber(dstotalAdjudicado, 2)
        If Me.txtTotalSolicitado.Text - Me.txtTotalAdjudicado.Text > 0 Then
            Me.txtTotalDiferencia.ForeColor = Drawing.Color.Blue
            Me.txtTotalDiferencia.Text = FormatNumber(Me.txtTotalSolicitado.Text - Me.txtTotalAdjudicado.Text, 2)
        Else
            Me.txtTotalDiferencia.ForeColor = Drawing.Color.Red
            Me.txtTotalDiferencia.Text = FormatNumber(Val(Me.txtTotalSolicitado.Text - Me.txtTotalAdjudicado.Text), 2)
        End If
        ''OJO se cambia a peticion de UACI CON FECHA 14 DE FEBRERO 2011--Mayra Martínez
        'If Me.TotalAsignadoMismoProveedor > 0 Then
        '    Me.btnGuardar.Enabled = False
        '    Me.btnGuardar.Visible = False
        '    Me.btnCancelar.Enabled = False
        '    Me.btnCancelar.Visible = False

        'Me.rfvCantidadAsignada.Visible = False
        'Me.cvCantidadAsignada.Visible = False
        'Me.cvCantidadSolicitada.Visible = False
        'Me.cvCantidadOferta.Visible = False

        'Me.lblCantidadAsignada.Visible = False
        'Me.nbCantidadRecomendada.Visible = False
        'Me.nbCantidadAdjudicada.Visible = False
        'Me.nbCantidadAdjudicadaEnFirme.Visible = False

        'Me.lblCantidadOtrosProveedores.Visible = False
        'Me.txtCantidadOtrosProveedores.Visible = False

        'Me.lblEntregasSolicitadas.Visible = False

        'Me.lblPlazosEntrega.Visible = False
        'Me.gvEntregasSolicitadas.Visible = False
        'Me.gvEntregasOferta.Visible = False

        'Me.lblObservacion.Visible = False
        'Me.txtObservacion.Visible = False

        'Me.lblError.Visible = True
        'Else
        Me.btnGuardar.Enabled = True
        Me.btnGuardar.Visible = True
        Me.btnCancelar.Enabled = True
        Me.btnCancelar.Visible = True

        Me.rfvCantidadAsignada.Visible = True
        Me.cvCantidadAsignada.Visible = True
        Me.cvCantidadSolicitada.Visible = True
        Me.cvCantidadOferta.Visible = True

        Me.lblCantidadAsignada.Visible = True

        Me.lblCantidadOtrosProveedores.Visible = True
        Me.txtCantidadOtrosProveedores.Visible = True

        Me.lblEntregasSolicitadas.Visible = True

        Me.lblPlazosEntrega.Visible = True
        Me.gvEntregasSolicitadas.Visible = True
        Me.gvEntregasOferta.Visible = False

        Me.lblObservacion.Visible = True
        Me.txtObservacion.Visible = True

        Me.lblError.Visible = False
        'End If

    End Sub

    Public Function CargarDatosEntregasSolicitadas() As Integer

        Dim cDPC As New cDETALLEENTREGASPROCESOCOMPRA

        Me.gvEntregasSolicitadas.DataSource = cDPC.ObtenerEntregasPorRenglonProcesoCompra(Me.IDPROCESOCOMPRA, Me.IDESTABLECIMIENTO, Me.RENGLON)
        Me.gvEntregasSolicitadas.DataBind()

    End Function

    Public Function CargarDatosEntregasPorOferta() As Integer

        Dim cEA As New cENTREGAADJUDICACION

        Dim ds As System.Data.DataSet
        ds = cEA.ObtenerEntregasPorOferta(Me.IDESTABLECIMIENTO, Me.IDPROCESOCOMPRA, Me.IDPROVEEDOR, Me.IDDETALLEOFERTA, Me.RENGLON)

        dt.Reset()
        dt = ds.Tables.Item(0)
        'TODO revisar entregas
        If Not Me.ViewState("dt") Is Nothing Then Me.ViewState.Remove("dt")
        Me.ViewState.Add("dt", dt)

        Me.gvEntregasOferta.DataSource = ds
        Me.gvEntregasOferta.DataBind()

    End Function

    Public Function CargarTotales() As Integer

        Dim cDO As New cDETALLEOFERTA

        Select Case TipoCantidad
            Case 1
                cDO.ObtenerTotalesRecomendados(Me.IDESTABLECIMIENTO, Me.IDPROCESOCOMPRA, Me.IDPROVEEDOR, Me.IDDETALLEOFERTA, Me.RENGLON, Me.TotalAsignadoOtrosProveedores, Me.TotalAsignadoMismoProveedor)
            Case 2
                cDO.ObtenerTotalesAdjudicados(Me.IDESTABLECIMIENTO, Me.IDPROCESOCOMPRA, Me.IDPROVEEDOR, Me.IDDETALLEOFERTA, Me.RENGLON, Me.TotalAsignadoOtrosProveedores, Me.TotalAsignadoMismoProveedor)
            Case 3
                cDO.ObtenerTotalesAdjudicadosEnFirme(Me.IDESTABLECIMIENTO, Me.IDPROCESOCOMPRA, Me.IDPROVEEDOR, Me.IDDETALLEOFERTA, Me.RENGLON, Me.TotalAsignadoOtrosProveedores, Me.TotalAsignadoMismoProveedor)
        End Select

    End Function

    Protected Sub gvEntregasOferta_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEntregasOferta.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim a As LinkButton = CType(e.Row.FindControl("lbEliminar"), LinkButton)
                Dim s As String
                s = "if("
                s += dt.Rows.Count.ToString
                s += "==1){alert('Debe haber al menos una entrega.');return false;}"
                a.OnClientClick = s
        End Select
    End Sub

    Protected Sub gvEntregasOferta_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvEntregasOferta.RowDeleting

        dt.Rows.RemoveAt(e.RowIndex)

        If Not Me.ViewState("dt") Is Nothing Then Me.ViewState.Remove("dt")
        Me.ViewState.Add("dt", dt)

        Me.gvEntregasOferta.DataSource = dt
        Me.gvEntregasOferta.DataBind()

    End Sub

    Protected Sub gvEntregasOferta_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvEntregasOferta.RowUpdating

        Dim drEntrega As System.Data.DataRow = dt.NewRow
        Dim DIAS, PORCENTAJE, IDFECHACONTEO As String

        DIAS = CType(gvEntregasOferta.FooterRow.FindControl("nbDIAS"), TextBox).Text
        PORCENTAJE = CType(gvEntregasOferta.FooterRow.FindControl("nbPORCENTAJE"), TextBox).Text

        IDFECHACONTEO = 1

        drEntrega("DIAS") = CType(DIAS, Int16)
        drEntrega("PORCENTAJE") = CDec(PORCENTAJE)
        drEntrega("IDFECHACONTEO") = CInt(IDFECHACONTEO)

        dt.Rows.Add(drEntrega)

        If Not Me.ViewState("dt") Is Nothing Then Me.ViewState.Remove("dt")
        Me.ViewState.Add("dt", dt)

        Me.gvEntregasOferta.DataSource = dt
        Me.gvEntregasOferta.DataBind()

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        RaiseEvent Cancelar()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click

        Dim i, porcentaje, sumPorcentaje, plazo, plazoAnterior, IDFechaConteo As Integer

        For i = 0 To dt.Rows.Count - 1

            porcentaje = dt.Rows(i).Item("PORCENTAJE")
            sumPorcentaje += porcentaje

            plazo = dt.Rows(i).Item("DIAS")
            IDFechaConteo = dt.Rows(i).Item("IDFECHACONTEO")

            If i = 0 Then
                If IDFechaConteo <> 1 Then
                    Me.lblError.Visible = True
                    Me.lblError.Text = "La primera entrega debe ser a partir de la fecha de liberación del contrato."
                    Exit Sub
                End If
            Else
                If IDFechaConteo = 1 Then
                    If plazo <= plazoAnterior Then
                        Me.lblError.Visible = True
                        Me.lblError.Text = "Los plazos de entrega a partir de la fecha de liberación del contrato deben ser crecientes."
                        Exit Sub
                    End If
                End If
            End If
            plazoAnterior = plazo
        Next

        If sumPorcentaje <> 100 Then
            Me.lblError.Visible = True
            Me.lblError.Text = "El resultado de la suma de los porcentajes de las entregas debe ser 100%."
            Exit Sub
        Else
            Me.lblError.Visible = False

            Dim cA As New cADJUDICACION
            Dim eA As New ADJUDICACION
            Dim eDPC As New DETALLEPROCESOCOMPRA
            Dim lE As New listaENTREGAADJUDICACION

            eA.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
            eA.IDPROCESOCOMPRA = Me.IDPROCESOCOMPRA
            eA.IDPROVEEDOR = Me.IDPROVEEDOR
            eA.IDDETALLE = Me.IDDETALLEOFERTA

            If Me.nbCantidadRecomendada.Visible Then
                eA.CANTIDADRECOMENDACION = (Me.nbCantidadRecomendada.Text)
                eA.CANTIDADADJUDICADA = eA.CANTIDADRECOMENDACION
                eA.CANTIDADFIRME = eA.CANTIDADRECOMENDACION
                eDPC.OBSERVACIONRECOMENDACION = Me.txtObservacion.Text
            ElseIf Me.txtCantidadRecomendada.Visible Then
                eA.CANTIDADRECOMENDACION = CInt(Me.txtCantidadRecomendada.Text)
            End If

            If Me.nbCantidadAdjudicada.Visible Then
                eA.CANTIDADADJUDICADA = (Me.nbCantidadAdjudicada.Text)
                eA.CANTIDADFIRME = eA.CANTIDADADJUDICADA
                eDPC.OBSERVACIONADJUDICADA = Me.txtObservacion.Text
            ElseIf Me.txtCantidadAdjudicada.Visible Then
                eA.CANTIDADADJUDICADA = (Me.txtCantidadAdjudicada.Text)
            End If

            If Me.nbCantidadAdjudicadaEnFirme.Visible Then
                eA.CANTIDADFIRME = (Me.nbCantidadAdjudicadaEnFirme.Text)
                eDPC.OBSERVACIONFIRME = Me.txtObservacion.Text
            End If

            eA.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eA.AUFECHACREACION = Now
            eA.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eA.AUFECHAMODIFICACION = Now
            eA.ESTASINCRONIZADA = 0

            eDPC.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
            eDPC.IDPROCESOCOMPRA = Me.IDPROCESOCOMPRA
            eDPC.IDPRODUCTO = Me.IDPRODUCTO
            eDPC.IDDETALLE = Me.IDDETALLEPROCESOCOMPRA
            eDPC.RENGLON = Me.RENGLON
            eDPC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eDPC.AUFECHAMODIFICACION = Now
            eDPC.ESTASINCRONIZADA = 0

            Dim row As Data.DataRow

            For Each row In dt.Rows

                Dim eE As New ENTREGAADJUDICACION

                eE.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
                eE.IDPROCESOCOMPRA = Me.IDPROCESOCOMPRA
                eE.IDPROVEEDOR = Me.IDPROVEEDOR
                eE.IDDETALLE = Me.IDDETALLEOFERTA
                eE.PORCENTAJE = row.Item("PORCENTAJE")
                eE.DIAS = row.Item("DIAS")
                eE.IDFECHACONTEO = row.Item("IDFECHACONTEO")
                eE.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                eE.AUFECHACREACION = Now
                eE.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                eE.AUFECHAMODIFICACION = Now
                eE.ESTASINCRONIZADA = 0

                lE.Add(eE)
            Next
            'If Me.nbCantidadRecomendada.Visible Then
            cA.AgregarCantidadesYEntregas(eA, lE, eDPC, Me.TipoCantidad, 1)
            'End If
            'If Me.nbCantidadAdjudicada.Visible Then
            '    cA.AgregarCantidadesYEntregas(eA, lE, eDPC, Me.TipoCantidad, 2)
            'End If
            'If Me.nbCantidadAdjudicadaEnFirme.Visible Then
            '    cA.AgregarCantidadesYEntregas(eA, lE, eDPC, Me.TipoCantidad, 3)
            'End If

        End If

        RaiseEvent Guardar()

    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As System.EventArgs) Handles btnEliminar.Click
        Dim cA As New cADJUDICACION
        Dim eA As New ADJUDICACION
        Dim eDPC As New DETALLEPROCESOCOMPRA

        eA.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
        eA.IDPROCESOCOMPRA = Me.IDPROCESOCOMPRA
        eA.IDPROVEEDOR = Me.IDPROVEEDOR
        eA.IDDETALLE = Me.IDDETALLEOFERTA
        eA.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eA.AUFECHAMODIFICACION = Now
        eA.ESTASINCRONIZADA = 0

        eDPC.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
        eDPC.IDPROCESOCOMPRA = Me.IDPROCESOCOMPRA
        eDPC.IDPRODUCTO = Me.IDPRODUCTO
        eDPC.IDDETALLE = Me.IDDETALLEPROCESOCOMPRA
        eDPC.RENGLON = Me.RENGLON
        eDPC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eDPC.AUFECHAMODIFICACION = Now
        eDPC.ESTASINCRONIZADA = 0
        If Me.nbCantidadRecomendada.Visible Then
            cA.EliminarCantidadesYEntregasPorOferta(eA, eDPC, Me.TipoCantidad, 1)

        End If
        If Me.nbCantidadAdjudicada.Visible Then
            cA.EliminarCantidadesYEntregasPorOferta(eA, eDPC, Me.TipoCantidad, 2)

        End If
        If Me.nbCantidadAdjudicadaEnFirme.Visible Then
            cA.EliminarCantidadesYEntregasPorOferta(eA, eDPC, Me.TipoCantidad, 3)

        End If


        RaiseEvent Eliminar()

    End Sub

    Public Sub LimpiarCantidades()
        If Me.nbCantidadRecomendada.Visible Then Me.nbCantidadRecomendada.Text = ""
        If Me.nbCantidadAdjudicada.Visible Then Me.nbCantidadAdjudicada.Text = ""
        If Me.nbCantidadAdjudicadaEnFirme.Visible Then Me.nbCantidadAdjudicadaEnFirme.Text = ""

        Me.txtObservacion.Text = String.Empty
    End Sub


End Class
