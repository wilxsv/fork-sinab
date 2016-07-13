'INGRESO DE SOLICITUD DE COMPRAS
'CU-ESTA0001
'Ing. Yessenia Pennelope Henriquez Duran
'control de usaurio para detalle de productos de solicitudes de compra

Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Data

Partial Class Controles_ucDesgloceArticulosSolicituCompra
    Inherits System.Web.UI.UserControl

    'declaracion e incializacion de variables
    Public Event Eliminado(ByVal CODIGOENZABEZADODOCUMENTO As Int32)
    Private _Enabled As Boolean
    Private _PermitirEliminar As Boolean = True
    Private _PermitirGuardar As Boolean = True
    Private _PermitirAgregar As Boolean = True
    Private _HabilitarEntregas As Boolean = True
    Public Event AgregoDetalle(ByVal MONTO As Double)
    Public Event GuardoDetalle()
    Public Event CalculoMonto(ByVal MONTO As Double, ByVal flag As Boolean)
    Private mEntProducto As New CATALOGOPRODUCTOS

    Private mComponente As New cDETALLESOLICITUDES
    Private mEntDetalleSolicitud As New DETALLESOLICITUDES
    Private mCompEntregasSolicitud As New cENTREGASOLICITUDES
    Dim entregas, ent As Integer

    Public Sub ObtenerDetalleDocumento(ByVal CODIGOENCABEZADODOCUMENTO As Int32)
        'llena grid de detalle con productos de la solicitud
        Me.Label_CODIGOENZABEZADODOCUMENTO.Text = CODIGOENCABEZADODOCUMENTO.ToString

        Dim mCompSolicitud As New cSOLICITUDES
        Me.dgLista.DataSource = mComponente.ObtenerDsGridDetalleSolicitud(CODIGOENCABEZADODOCUMENTO, Session.Item("IdEstablecimiento"))

        'carga lista
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.CurrentPageIndex = 0 'error de pagineo
            Me.dgLista.DataBind()
        End Try
    End Sub

    Public Sub ObtenerSuministro(ByVal SUMINISTRO As Int32)
        'obtien el suministro para filtrar medicamentos
        Me.lblSuministro.Text = SUMINISTRO
        Me.UcAgregarProductosDetalleSolicitud1.ObtenerSuministro(SUMINISTRO)
    End Sub

    Public Property Enabled() As Boolean 'disponibles
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Private Sub dgLista_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        'al momento de cargar los registros en el grid
        If e.Item.ItemType = ListItemType.AlternatingItem Or _
           e.Item.ItemType = ListItemType.Item Then

            entregas = mCompEntregasSolicitud.ObtenerNumeroEntregas(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))
            If entregas >= 1 Then
                CType(e.Item.FindControl("DDLnumeroEntregas"), DropDownList).Items.Clear()
                For ent = 1 To entregas
                    CType(e.Item.FindControl("DDLnumeroEntregas"), DropDownList).Items.Add(ent)
                    CType(e.Item.FindControl("DDLnumeroEntregas"), DropDownList).SelectedValue = CType(e.Item.FindControl("LblNumEntregas"), Label).Text
                Next ent
            Else
                CType(e.Item.FindControl("DDLnumeroEntregas"), DropDownList).Visible = False
            End If
        Else
        End If
    End Sub

    Private Sub dgLista_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        'al momento de elimianr un registro del detalle
        Dim idespecificacion As Integer
        If dgLista.Items(e.Item.ItemIndex).Cells(dgLista.Columns.Count - 1).Text = "" Then
            idespecificacion = 0
        Else
            idespecificacion = dgLista.Items(e.Item.ItemIndex).Cells(dgLista.Columns.Count - 1).Text
        End If
        If mComponente.EliminarDETALLESOLICITUDES(Session.Item("IdEstablecimiento"), CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), CLng(CType(Me.dgLista.Items(e.Item.ItemIndex).FindControl("ImageButton1"), ImageButton).ToolTip), idespecificacion) = 0 Then
            MsgBox1.ShowAlert(" Errores al momento de eliminar el producto de la solitud", "error2", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
        Else
            mComponente.AsignarRenglon(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))

            Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
            Me.LblMonto.Text = mComponente.CalcularMontoTotalSolicitud(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
            Me.TxtMonto.Text = Me.LblMonto.Text
            RaiseEvent Eliminado(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
            Me.dgLista.CurrentPageIndex = 0
            Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        End If

    End Sub

    Protected Sub ImgbAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbAgregar.Click
        'al momento de dar agregar un producto
        Session.Item("estado") = "nuevo"
        Session.Item("IdEncabezado") = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        Me.UcAgregarProductosDetalleSolicitud1.IDSOLICITUD.Text = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        Me.UcAgregarProductosDetalleSolicitud1.Visible = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al momento de cargar control
        If Not Page.IsPostBack Then 'la primera vez
            Me.UcAgregarProductosDetalleSolicitud1.Visible = False
            Me.LblMonto.Text = mComponente.CalcularMontoTotalSolicitud(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
            Me.TxtMonto.Text = Me.LblMonto.Text
        End If
    End Sub

    Public Sub Actualizar()
        'al momento de actualizar
        Session.Item("TotalSolicitud") = mComponente.CalcularMontoTotalSolicitud(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
    End Sub

    Public Function Agregar() As String
        'al momento de agregar
        Me.Label_CODIGOENZABEZADODOCUMENTO.Text = Session.Item("idDoc")
        Session.Item("estado") = "nuevo"
        Session.Item("IdEncabezado") = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        Me.UcAgregarProductosDetalleSolicitud1.IDSOLICITUD.Text = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        Me.UcAgregarProductosDetalleSolicitud1.Visible = True
        Me.dgLista.Visible = False
        Me.ImgbAgregar.Visible = False
    End Function

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'habilita los campos a edicion
        Me.HabilitarGrid(edicion)
        Me.PermitirEliminar = edicion
        Me.PermitirGuardar = edicion
        Me.PermitirAgregar = edicion
    End Sub

    Public Sub HabilitarEdicionConjunta(ByVal edicion As Boolean)
        'habilita los campos de edicion conjunta
        If edicion Then
            Me.HabilitarGridConjunta()
            Me.lblConjunta.Text = 1
        Else
            Me.lblConjunta.Text = 0
        End If
    End Sub

    Public Property PermitirEliminar() As Boolean
        'permite eliminar
        Get
            Return _PermitirEliminar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirEliminar = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 1).Visible = _PermitirEliminar
        End Set
    End Property

    Public Property PermitirAgregar() As Boolean
        'permite agregar
        Get
            Return _PermitirAgregar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirAgregar = Value
            Me.ImgbAgregar.Visible = _PermitirAgregar
        End Set
    End Property

    Public Property HabilitarEntregas() As Boolean
        'habilita las entregas
        Get
            Return _HabilitarEntregas
        End Get
        Set(ByVal Value As Boolean)
            _HabilitarEntregas = Value

            Dim j As Integer
            For j = 0 To dgLista.Items.Count - 1
                CType(dgLista.Items(j).FindControl("DDLnumeroEntregas"), DropDownList).Enabled = _HabilitarEntregas
            Next

        End Set
    End Property

    Public Property PermitirGuardar() As Boolean
        'permite guardar
        Get
            Return _PermitirGuardar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirGuardar = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 2).Visible = _PermitirGuardar
        End Set
    End Property

    Private Sub HabilitarGrid(ByVal edicion As Boolean)
        'habilita grid para edicion
        Dim j As Integer
        For j = 0 To dgLista.Items.Count - 1
            CType(dgLista.Items(j).FindControl("DDLnumeroEntregas"), DropDownList).Enabled = edicion
            CType(dgLista.Items(j).FindControl("TxtCant"), TextBox).Enabled = edicion
        Next
    End Sub

    Private Sub HabilitarGridConjunta()
        'habilita grid para conjunta
        Dim j As Integer
        For j = 0 To dgLista.Items.Count - 1
            CType(dgLista.Items(j).FindControl("DDLnumeroEntregas"), DropDownList).Enabled = True
            CType(dgLista.Items(j).FindControl("TxtCant"), TextBox).Enabled = False
        Next
    End Sub

    Protected Sub dgLista_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.UpdateCommand
        'al momento de guardar un registro

        Dim MentDetalleSol As New DETALLESOLICITUDES


        If CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtCant"), TextBox).Text > 0 Then
            MentDetalleSol.IDDETALLE = CLng(CType(dgLista.Items(e.Item.ItemIndex).FindControl("ImageButton2"), ImageButton).ToolTip)
            Dim cantidadTexto As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtCant"), TextBox)
            If cantidadTexto.Text = "" Then cantidadTexto.Text = 0
            Dim PresupuestoUnitario As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("lblprecio"), Label)

            MentDetalleSol.IDSOLICITUD = (CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
            MentDetalleSol.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mComponente.ObtenerDETALLESOLICITUDES(MentDetalleSol)
            MentDetalleSol.CANTIDAD = cantidadTexto.Text
            MentDetalleSol.PRESUPUESTOTOTAL = (cantidadTexto.Text) * (PresupuestoUnitario.Text)
            MentDetalleSol.NUMEROENTREGAS = CType(dgLista.Items(e.Item.ItemIndex).FindControl("DDLnumeroEntregas"), DropDownList).SelectedValue
            MentDetalleSol.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            MentDetalleSol.AUFECHAMODIFICACION = Now()
            MentDetalleSol.ESTASINCRONIZADA = 0

            If mComponente.ActualizarDETALLESOLICITUDES(MentDetalleSol) Then
                RaiseEvent GuardoDetalle()
            Else
                MsgBox1.ShowAlert(" Errores al momento de guardar las modificaciones de la solitud", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)

            End If
        Else
            MsgBox1.ShowAlert("La cantidad no puede ser 0", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

        Me.LblMonto.Text = mComponente.CalcularMontoTotalSolicitud(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
        Me.TxtMonto.Text = Me.LblMonto.Text
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        RaiseEvent AgregoDetalle((Me.LblMonto.Text))

        If Me.lblConjunta.Text = 1 Then 'es conjunta
            HabilitarEdicionConjunta(True)
        End If

    End Sub

    Protected Sub UcAgregarProductosDetalleSolicitud1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcAgregarProductosDetalleSolicitud1.Agregar
        'al momento de agregar un producto al detalle de solicitudes
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        Me.LblMonto.Text = mComponente.CalcularMontoTotalSolicitud(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
        Me.TxtMonto.Text = Me.LblMonto.Text
        RaiseEvent AgregoDetalle((Me.LblMonto.Text))
        Me.UcAgregarProductosDetalleSolicitud1.Visible = False
        Me.dgLista.Visible = True
        Me.ImgbAgregar.Visible = True
        mComponente.AsignarRenglon(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))

    End Sub

    Public Sub CalcularMonto(ByVal flag As Boolean)
        'al momento de calcular monto
        Me.LblMonto.Text = mComponente.CalcularMontoTotalSolicitud(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
        Me.TxtMonto.Text = Me.LblMonto.Text
        RaiseEvent CalculoMonto((Me.LblMonto.Text), flag)
    End Sub

    Protected Sub UcAgregarProductosDetalleSolicitud1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcAgregarProductosDetalleSolicitud1.Cancelar
        'al momento de cancelar
        Me.UcAgregarProductosDetalleSolicitud1.Visible = False
        Me.dgLista.Visible = True
        Me.ImgbAgregar.Visible = True
    End Sub

    Private Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista.PageIndexChanged
        'al momento de cambiar indice de pagineo
        Me.dgLista.CurrentPageIndex = e.NewPageIndex
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
    End Sub

    Protected Sub UcAgregarProductosDetalleSolicitud1_ErrorEvent(ByVal errorMessage As String) Handles UcAgregarProductosDetalleSolicitud1.ErrorEvent
        'evento error
        Me.ImgbAgregar.Visible = True
    End Sub

End Class
