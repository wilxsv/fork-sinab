
Imports ABASTECIMIENTOS.DATOS
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases
Imports SINAB_Entidades
Imports SINAB_Entidades.EnumHelpers
Imports System.Linq
Imports System.Collections.Generic
Imports SINAB_Utils


Partial Class Controles_LotesDespacho_ProductoCantidad
    Inherits System.Web.UI.UserControl

#Region "PROPIEDADES PUBLICAS"



    Public Property IdMovimiento As Integer
        Get
            Return CType(ViewState("IDMOVIMIENTO"), Integer)
        End Get
        Set(value As Integer)
            ViewState("IDMOVIMIENTO") = value
        End Set
    End Property

    Public Property CodigoProducto As String
        Get
            Return _codproducto
        End Get
        Set(value As String)
            _codproducto = value
            If Not Me.ViewState("CODPRODUCTO") Is Nothing Then Me.ViewState.Remove("CODPRODUCTO")
            Me.ViewState.Add("CODPRODUCTO", _codproducto)
        End Set
    End Property

    Public Property IdProducto As Integer
        Get
            Return _idproducto
        End Get
        Set(value As Integer)
            _idproducto = value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", _idproducto)
        End Set
    End Property

    Public Property IdAlmacen As Integer
        Get
            Return CType(ViewState("IDALMACEN"), Integer)
        End Get
        Set(value As Integer)
            ViewState("IDALMACEN") = value
        End Set
    End Property

    Public Property IdSuministro As Integer
        Get
            Return _idsuministro
        End Get
        Set(value As Integer)
            _idsuministro = value
            If Not Me.ViewState("IDSUMINISTRO") Is Nothing Then Me.ViewState.Remove("IDSUMINISTRO")
            Me.ViewState.Add("IDSUMINISTRO", _idsuministro)
        End Set
    End Property

    Public Property FiltroLote As LotesPorCantidad
        Get
            Return _filtro
        End Get
        Set(value As LotesPorCantidad)
            _filtro = value
            If Not Me.ViewState("FILTROLOTE") Is Nothing Then Me.ViewState.Remove("FILTROLOTE")
            Me.ViewState.Add("FILTROLOTE", _filtro)
        End Set
    End Property

    Public Property TipoMovimiento As Integer
        Get
            Return _tipomovimiento
        End Get
        Set(value As Integer)
            _tipomovimiento = value
            If Not Me.ViewState("TIPOMOVIMIENTO") Is Nothing Then Me.ViewState.Remove("TIPOMOVIMIENTO")
            Me.ViewState.Add("TIPOMOVIMIENTO", _tipomovimiento)
        End Set
    End Property

    Public Property CantidadProducto As Double
        Get
            Return CType(ViewState("CANTIDADPRODUCTO"), Integer)
        End Get
        Set(value As Double)
            ViewState("CANTIDADPRODUCTO") = value
        End Set
    End Property

#End Region

    Public Sub Ejecutar()

        LimpiarCampos()

        Dim lotes = New Lotes
        Dim ds = lotes.ObtenerLotesFiltrados(IdAlmacen, IdSuministro, IdProducto, CodigoProducto, FiltroLote)

        'Retorna errores

        If Not ds.Any() Then Throw New Exception("No se encontró ningún lote disponible para este producto.")

        gvLotes.DataSource = ds
        gvLotes.DataBind()

        lblCorrProducto.Text = gvLotes.DataKeys(0).Values.Item("CORRPRODUCTO").ToString()
        lblDescripcion.Text = gvLotes.DataKeys(0).Values.Item("DESCLARGO").ToString().LimitWithElipsesOnWordBoundary(70)
        lblreqqty.Text = String.Format("{0} {1}", CantidadProducto.ToString, gvLotes.DataKeys(0).Values.Item("UNIDADMEDIDA"))
        hdCantidad.Value = CantidadProducto.ToString()
        gvLotes.Rows(0).Focus()




    End Sub
    
    Public Function ObtenerDetalleLotes() As List(Of SAB_ALM_DETALLEMOVIMIENTOS)
        Dim usr = Membresia.ObtenerUsuario()
        'Dim errorActualizacion As Boolean
        Dim listaDetalles = New List(Of SAB_ALM_DETALLEMOVIMIENTOS)
        For Each row As GridViewRow In From row1 As GridViewRow In gvLotes.Rows Where CType(Me.gvLotes.Rows(row1.RowIndex).FindControl("nbCantidad"), TextBox).Text.Trim <> String.Empty
            Dim detalleMov As New SAB_ALM_DETALLEMOVIMIENTOS
            'Dim OperacionLote As New OperacionesLotes
            'Dim lote As New Clases.Lotes

            With detalleMov

                .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
                .IDTIPOTRANSACCION = TiposTransaccion.Salida
                .IDMOVIMIENTO = IdMovimiento
                .IDPRODUCTO = CType(gvLotes.DataKeys(row.RowIndex).Item("IDPRODUCTO"), Long)
                .IDALMACEN = IdAlmacen
                .IDLOTE = CType(gvLotes.DataKeys(row.RowIndex).Item("IDLOTE"), Long)
                .CANTIDAD = CType(CType(gvLotes.Rows(row.RowIndex).FindControl("nbCantidad"), TextBox).Text, Decimal)
                .MONTO = 0
                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                .AUFECHACREACION = Now
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .AUFECHAMODIFICACION = Now
            End With

            listaDetalles.Add(detalleMov)


            'With OperacionLote

            '    .CantidadReservada = 1

            '    Select Case TipoMovimiento
            '        Case 3 'vencida
            '            .CantidadVencida = 2
            '        Case 4 'no disponible
            '            .CantidadNoDisponible = 2
            '            detalleMov.CANTIDADNODISPONIBLE = 1
            '        Case 5 'temporal
            '            .CantidadTemporal = 2
            '        Case Else 'disponible
            '            .CantidadDisponible = 2
            '    End Select
            'End With


            'If String.IsNullOrEmpty(lote.ActualizarCantidades(detalleMov, OperacionLote)) Then
            '    'todo
            'Else
            '    errorActualizacion = True
            'End If
        Next
        Return listaDetalles
    End Function

    Protected Sub gvLotes_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLotes.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Attributes.Add("id", e.Row.ClientID)

            Dim nb As TextBox = CType(e.Row.FindControl("nbCantidad"), TextBox)

            nb.Attributes.Add("onFocus", e.Row.ClientID + ".className = 'GridListHighLight'")

            Select Case e.Row.RowState
                Case DataControlRowState.Normal
                    nb.Attributes.Add("onBlur", e.Row.ClientID + ".className = '" + sender.RowStyle.CssClass + "'")
                Case DataControlRowState.Alternate
                    nb.Attributes.Add("onBlur", e.Row.ClientID + ".className = '" + sender.AlternatingRowStyle.CssClass + "'")
                Case DataControlRowState.Selected
            End Select
        End If
    End Sub


    Private Sub LimpiarCampos()
        gvLotes.DataSource = Nothing
        gvLotes.DataBind()
        lblCorrProducto.Text = String.Empty
        lblDescripcion.Text = String.Empty
    End Sub

#Region "PROPIEDADES PRIVADAS"
    Private _codproducto As Integer
    Private _idproducto As Integer
    Private _idsuministro As Integer
    Private _filtro As LotesPorCantidad
    Private _tipomovimiento As Integer
#End Region

End Class

