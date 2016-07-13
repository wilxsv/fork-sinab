'INVENTARIO FISICO
'CU-ALMACEN012
'Ing. Yessenia Pennelope Henriquez Duran
'INVENTARIO FISICO DEL ESTABLECIMIENTO
'Consiste en recuiento de las existencias de productos dentro del almacen para la comparacion 
'de los valores realies y fisicos

Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Data
Partial Class Controles_ucDesgloceArticulosInventarioFinal
    Inherits System.Web.UI.UserControl
    'declaracion e incializacion de variables y eventos
    Public Event Eliminado(ByVal CODIGOENZABEZADODOCUMENTO As Int32)
    Private _Enabled As Boolean
    Private _PermitirEliminar As Boolean = True
    Private _PermitirGuardar As Boolean = True
    Private _PermitirVencidos As Boolean = True
    Private _PermitirNoDisponibles As Boolean = True

    Private mEntProducto As New CATALOGOPRODUCTOS
    Private mCompProducto As New cCATALOGOPRODUCTOS
    Dim dsDisponibles As New DataSet
    Dim dsVencidos As New DataSet
    Dim dsNodisponible As New DataSet
    Dim iddetalle As Integer

    Private _IDALMACEN As Int32
    Private _IDSUMINISTRO As Int32
    Private _IDFUENTE As Int32
    Private _IDRESPONSABLE As Int32
    Private _CONSIDERARVENCIDOS As Int32
    Private _CONSIDERARNODISPONIBLES As Int32
    Private _CONSIDERARFUENTE As Int32
    Private _CONSIDERARRESPONSABLE As Int32
    Private _CIERREEXISTENCIAS As Date

    Dim mComponente As New cDETALLEINVENTARIO
    Dim mCompAjuste As New cAJUSTE
    Dim mEntidad As New DETALLEINVENTARIO
    Dim mCompInventario As New cINVENTARIO

    Public Property CIERREEXISTENCIAS() As Date 'fecha de cierre de existencias
        Get
            Return Me._CIERREEXISTENCIAS
        End Get
        Set(ByVal Value As Date)
            Me._CIERREEXISTENCIAS = Value
            Me.Calendar.SelectedDate = Me._CIERREEXISTENCIAS
        End Set
    End Property
    Public Property IDALMACEN() As Int32 'identificador del almacen
        Get
            Return Me._IDALMACEN
        End Get
        Set(ByVal Value As Int32)
            Me._IDALMACEN = Value
            Me.lblAlmacen.Text = Me._IDALMACEN
        End Set
    End Property
    Public Property IDSUMINISTRO() As Int32 'identificador del suministro
        Get
            Return Me._IDSUMINISTRO
        End Get
        Set(ByVal Value As Int32)
            Me._IDSUMINISTRO = Value
            Me.Lblsuminstro.Text = Me._IDSUMINISTRO
        End Set
    End Property
    Public Property IDFUENTE() As Int32 'identificador de la fuente de financiamiento
        Get
            Return Me._IDFUENTE
        End Get
        Set(ByVal Value As Int32)
            Me._IDFUENTE = Value
            Me.LblFuente.Text = Me._IDFUENTE
        End Set
    End Property
    Public Property IDRESPONSABLE() As Int32 'identificador del responsable de distribucion
        Get
            Return Me._IDRESPONSABLE
        End Get
        Set(ByVal Value As Int32)
            Me._IDRESPONSABLE = Value
            Me.LblResponsable.Text = Me._IDRESPONSABLE
        End Set
    End Property
    Public Property CONSIDERARVENCIDOS() As Int32 ' 'considerar vencidos
        Get
            Return Me._CONSIDERARVENCIDOS
        End Get
        Set(ByVal Value As Int32)
            Me._CONSIDERARVENCIDOS = Value
            Me.cVencidos.Text = Me._CONSIDERARVENCIDOS
        End Set
    End Property
    Public Property CONSIDERARNODISPONIBLES() As Int32 'considerar no disponibles
        Get
            Return Me._CONSIDERARNODISPONIBLES
        End Get
        Set(ByVal Value As Int32)
            Me._CONSIDERARNODISPONIBLES = Value
            Me.cNodisponibles.Text = Me._CONSIDERARNODISPONIBLES
        End Set
    End Property
    Public Property CONSIDERARFUENTE() As Int32 'considerar fuentes
        Get
            Return Me._CONSIDERARFUENTE
        End Get
        Set(ByVal Value As Int32)
            Me._CONSIDERARFUENTE = Value
            Me.cfuente.Text = Me._CONSIDERARFUENTE
        End Set
    End Property
    Public Property CONSIDERARRESPONSABLE() As Int32 'considerar responsables
        Get
            Return Me._CONSIDERARRESPONSABLE
        End Get
        Set(ByVal Value As Int32)
            Me._CONSIDERARRESPONSABLE = Value
            Me.cResponsable.Text = Me._CONSIDERARRESPONSABLE
        End Set
    End Property


    Public Sub obtenerInventario()
        Dim disponibles As Double
        Dim nodisponibles As Double
        Dim vencidos As Double

        'calcula las existencia la guarda en el detalle de inventario

        'no considerar fuente ni responsable
        If Me.cfuente.Text = "0" And Me.cResponsable.Text = "0" Then
            dsDisponibles = mCompInventario.obtenerExistenciasDisponiblesInventarioAlmacen(Me.lblAlmacen.Text, Me.Lblsuminstro.Text, Me.Calendar.SelectedDate)
        End If
        'si considerar fuente no responsable
        If Me.cfuente.Text = "1" And Me.cResponsable.Text = "0" Then
            dsDisponibles = mCompInventario.obtenerExistenciasDisponiblesInventarioAlmacen(Me.lblAlmacen.Text, Me.Lblsuminstro.Text, Me.Calendar.SelectedDate, CInt(Me.LblFuente.Text))
        End If
        'no considerar fuente si responsable
        If Me.cfuente.Text = "0" And Me.cResponsable.Text = "1" Then
            dsDisponibles = mCompInventario.obtenerExistenciasDisponiblesInventarioAlmacen(Me.lblAlmacen.Text, Me.Lblsuminstro.Text, Me.Calendar.SelectedDate, CInt(Me.LblResponsable.Text))
        End If
        'si considerar fuente si responsable
        If Me.cfuente.Text = "1" And Me.cResponsable.Text = "1" Then
            dsDisponibles = mCompInventario.obtenerExistenciasDisponiblesInventarioAlmacen(Me.lblAlmacen.Text, Me.Lblsuminstro.Text, Me.Calendar.SelectedDate, Me.LblFuente.Text, Me.LblResponsable.Text)
        End If

        'disponible
        Dim r As DataRow

        For Each r In dsDisponibles.Tables(0).Rows
            disponibles = 0
            mEntidad.IDALMACEN = r("IDALMACEN")
            mEntidad.IDINVENTARIO = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
            mEntidad.IDDETALLE = 0
            mEntidad.IDPRODUCTO = r("IDPRODUCTO")
            mEntidad.IDLOTE = r("IDLOTE")
            mEntidad.IDUNIDADMEDIDA = r("IDUNIDADMEDIDA")
            mEntidad.PRECIO = r("PRECIOLOTE")
            disponibles = r("total")
            mEntidad.CANTIDADDISPONIBLESISTEMA = disponibles
            mEntidad.CANTIDADDISPONIBLECAPTURA = disponibles
            mEntidad.CANTIDADDISPONIBLEDIFERENCIA = 0
            mEntidad.CANTIDADVENCIDASISTEMA = 0
            mEntidad.CANTIDADVENCIDACAPTURA = 0
            mEntidad.CANTIDADVENCIDADIFERENCIA = 0
            mEntidad.CANTIDADNODISPONIBLESISTEMA = 0
            mEntidad.CANTIDADNODISPONIBLECAPTURA = 0
            mEntidad.CANTIDADNODISPONIBLEDIFERENCIA = 0
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHACREACION = Now()
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
            mEntidad.ESTASINCRONIZADA = 0
            mComponente.ActualizarDETALLEINVENTARIO(mEntidad)
        Next r
        'vencidos
        dsVencidos = mCompInventario.obtenerExistenciasDisponiblesInventarioAlmacen(Me.lblAlmacen.Text, Me.Lblsuminstro.Text, Me.Calendar.SelectedDate, Me.LblFuente.Text, Me.LblResponsable.Text, 1)

        Dim r2 As DataRow
        For Each r2 In dsVencidos.Tables(0).Rows
            disponibles = 0
            vencidos = 0

            mEntidad.IDALMACEN = r2("IDALMACEN")
            mEntidad.IDINVENTARIO = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
            mEntidad.IDPRODUCTO = r2("IDPRODUCTO")
            mEntidad.IDLOTE = r2("IDLOTE")

            mComponente.ObtenerDetalleProducto(mEntidad)

            mEntidad.IDUNIDADMEDIDA = r2("IDUNIDADMEDIDA")
            mEntidad.PRECIO = r2("PRECIOLOTE")
            disponibles = mEntidad.CANTIDADDISPONIBLESISTEMA
            vencidos = r2("total")
            mEntidad.CANTIDADVENCIDASISTEMA = vencidos
            mEntidad.CANTIDADVENCIDACAPTURA = vencidos
            mEntidad.CANTIDADVENCIDADIFERENCIA = 0
            If disponibles <> 0 Then mEntidad.CANTIDADDISPONIBLESISTEMA = disponibles - vencidos
            If disponibles <> 0 Then mEntidad.CANTIDADDISPONIBLECAPTURA = disponibles - vencidos
            mEntidad.CANTIDADDISPONIBLEDIFERENCIA = 0
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
            mEntidad.ESTASINCRONIZADA = 0

            mComponente.ActualizarDETALLEINVENTARIO(mEntidad)
        Next r2
        'no disponible

        dsNodisponible = mCompInventario.obtenerExistenciasNoDisponiblesInventarioAlmacen(Me.lblAlmacen.Text, Me.Lblsuminstro.Text, Me.Calendar.SelectedDate, Me.LblFuente.Text, Me.LblResponsable.Text)
        Dim r3 As DataRow
        For Each r3 In dsNodisponible.Tables(0).Rows
            disponibles = 0
            nodisponibles = 0

            mEntidad.IDALMACEN = r3("IDALMACEN")
            mEntidad.IDINVENTARIO = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
            mEntidad.IDPRODUCTO = r3("IDPRODUCTO")
            mEntidad.IDLOTE = r3("IDLOTE")

            mComponente.ObtenerDetalleProducto(mEntidad)

            mEntidad.IDUNIDADMEDIDA = r3("IDUNIDADMEDIDA")
            mEntidad.PRECIO = r3("PRECIOLOTE")
            disponibles = mEntidad.CANTIDADDISPONIBLESISTEMA
            nodisponibles = r3("total")
            mEntidad.CANTIDADNODISPONIBLESISTEMA = nodisponibles
            mEntidad.CANTIDADNODISPONIBLECAPTURA = nodisponibles
            mEntidad.CANTIDADNODISPONIBLEDIFERENCIA = 0
            If disponibles > 0 Then mEntidad.CANTIDADDISPONIBLESISTEMA = disponibles - nodisponibles
            If disponibles > 0 Then mEntidad.CANTIDADDISPONIBLECAPTURA = disponibles - nodisponibles
            mEntidad.CANTIDADDISPONIBLEDIFERENCIA = 0
            mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntidad.AUFECHAMODIFICACION = Now()
            mEntidad.ESTASINCRONIZADA = 0

            mComponente.ActualizarDETALLEINVENTARIO(mEntidad)
        Next r3


        'ocultar(columnas)

        If Me.cVencidos.Text = "1" Then
            Me.PermitirVencidos = True
        Else
            Me.PermitirVencidos = False
        End If


        If Me.cNodisponibles.Text = "1" Then
            Me.PermitirNoDisponibles = True
        Else
            Me.PermitirNoDisponibles = False
        End If


    End Sub
    Public Sub ObtenerDetalleDocumento(ByVal CODIGOENCABEZADODOCUMENTO As Int32)
        'carga grid con dettalle de inventario
        Me.Label_CODIGOENZABEZADODOCUMENTO.Text = CODIGOENCABEZADODOCUMENTO
        Me.dgLista.DataSource = mComponente.ObtenerDsDetalleInventario(CODIGOENCABEZADODOCUMENTO, Session.Item("IdAlmacen"))
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception
            Me.dgLista.CurrentPageIndex = 0
            Me.dgLista.DataBind()
        End Try
    End Sub

    Public Sub GenerarInventario(ByVal idinventario As Int32)
        'Me.Label_CODIGOENZABEZADODOCUMENTO.Text = idinventario
        obtenerInventario()
        ObtenerDetalleDocumento(Me.Label_CODIGOENZABEZADODOCUMENTO.Text)
        Me.PermitirEliminar = False
    End Sub
    Public Property Enabled() As Boolean 'habilita edicion
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Private Sub dgLista_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        'al momento de cargar registros en el grid
        If e.Item.ItemType = ListItemType.AlternatingItem Or _
           e.Item.ItemType = ListItemType.Item Then
            Dim a As LinkButton = CType(e.Item.FindControl("LinkButton1"), LinkButton) 'eliminar
            a.Attributes.Add("onclick", "if(!window.confirm('¿Esta seguro de Eliminar el producto?')){return false;}")

            Dim b As LinkButton = CType(e.Item.FindControl("LinkButton2"), LinkButton) 'guardar
            b.Attributes.Add("onclick", "if(!window.confirm('¿Esta a punto de guardar modificciones de producto?')){return false;}")

            Dim c As ImageButton = CType(e.Item.FindControl("ImbAjustar"), ImageButton) 'ajustar



            If CType(e.Item.FindControl("dispdif"), Label).Text = "0.00" And CType(e.Item.FindControl("nodispdif"), Label).Text = "0.00" And CType(e.Item.FindControl("vencdif"), Label).Text = "0.00" Then
                'inventario cuadra no ajustar

                CType(e.Item.FindControl("ImbAjustar"), ImageButton).Visible = False

            Else
                ' inventario no cuadra ajustar
                CType(e.Item.FindControl("ImbAjustar"), ImageButton).Visible = True
                iddetalle = CType(e.Item.FindControl("id"), Label).Text

                If mCompAjuste.ValidarExistenciaAjuste(Me.lblAlmacen.Text, Me.Label_CODIGOENZABEZADODOCUMENTO.Text, iddetalle) Then
                    c.Attributes.Add("onclick", "if(!window.confirm('¿Desea modificar o imprimir Ajuste?')){return false;}")
                    c.ToolTip = "Consultar ajuste"
                    c.ImageUrl = "~/Imagenes/consulta.gif"
                    CType(e.Item.FindControl("lblExiste"), Label).Text = "True"
                    b.Visible = False
                Else
                    c.Attributes.Add("onclick", "if(!window.confirm('¿Desea Ajustar producto?, una vez realizado ajustes no se podra eliminar el inventario')){return false;}")
                    c.ToolTip = "Ajustar producto"
                    c.ImageUrl = "~/Imagenes/Ajustar.gif"
                    CType(e.Item.FindControl("lblExiste"), Label).Text = "False"
                End If
            End If
        End If
    End Sub

    Private Sub dgLista_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.DeleteCommand
        'al momento de elimianr un registro del grid
        Dim mComponente As New cDETALLEINVENTARIO

        If mComponente.EliminarDETALLEINVENTARIO(Session.Item("IdAlmacen"), CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), CLng(CType(Me.dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton1"), LinkButton).ToolTip)) = 0 Then
            'Si se cometio un error
        Else
            Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
            RaiseEvent Eliminado(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.UcAjusteInventario1.Visible = False
            'ocultar(columnas)

            If Me.cVencidos.Text = "1" Then
                Me.PermitirVencidos = True
            Else
                Me.PermitirVencidos = False
            End If


            If Me.cNodisponibles.Text = "1" Then
                Me.PermitirNoDisponibles = True
            Else
                Me.PermitirNoDisponibles = False
            End If
        End If
    End Sub
    Public Function Actualizar() As String
        'proceso
    End Function

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'habilita controles para edicion
        HabilitarGrid(edicion)
        Me.PermitirEliminar = edicion
        Me.PermitirGuardar = edicion

    End Sub

    Public Property PermitirEliminar() As Boolean
        'habilita poder eliminar
        Get
            Return _PermitirEliminar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirEliminar = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 1).Visible = Value
        End Set
    End Property
    Public Property PermitirGuardar() As Boolean
        'habilita poder guardar
        Get
            Return _PermitirGuardar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirGuardar = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 2).Visible = Value
        End Set
    End Property
    Public Property PermitirAjustar() As Boolean
        'habilita poder ajustar
        Get
            Return _PermitirVencidos
        End Get
        Set(ByVal Value As Boolean)
            _PermitirVencidos = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 3).Visible = Value
        End Set
    End Property
    Public Property PermitirVencidos() As Boolean
        'habilita poder ver existencia vencida
        Get
            Return _PermitirVencidos
        End Get
        Set(ByVal Value As Boolean)
            _PermitirVencidos = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 4).Visible = Value
        End Set
    End Property
    Public Property PermitirNoDisponibles() As Boolean
        'habilita poder ver existencia no dispónible
        Get
            Return _PermitirNoDisponibles
        End Get
        Set(ByVal Value As Boolean)
            _PermitirNoDisponibles = Value
            Me.dgLista.Columns(Me.dgLista.Columns.Count - 5).Visible = Value
        End Set
    End Property

    Private Sub HabilitarGrid(ByVal edicion As Boolean)
        'habilita edicion de controles grid
        Dim j As Integer
        For j = 0 To dgLista.Items.Count - 1
            CType(dgLista.Items(j).FindControl("TxtDisponibleCaptura"), TextBox).Enabled = edicion
            CType(dgLista.Items(j).FindControl("TxtNoDisponibleCaptura"), TextBox).Enabled = edicion
            CType(dgLista.Items(j).FindControl("TxtVencidaCaptura"), TextBox).Enabled = edicion
        Next
    End Sub

    Protected Sub dgLista_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.UpdateCommand
        'al momento de guardar registro grid

        Dim mEntDetalleInventario As New DETALLEINVENTARIO
        Dim mCompDetalleInventario As New cDETALLEINVENTARIO
        Dim mEntInventario As New INVENTARIO
        Dim mCompInventario As New cINVENTARIO


        mEntDetalleInventario.IDDETALLE = CLng(CType(dgLista.Items(e.Item.ItemIndex).FindControl("LinkButton1"), LinkButton).ToolTip)
        mEntDetalleInventario.IDINVENTARIO = (CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        mEntDetalleInventario.IDALMACEN = Session.Item("IdAlmacen")
        mCompDetalleInventario.ObtenerDETALLEINVENTARIO(mEntDetalleInventario)

        mEntDetalleInventario.CANTIDADDISPONIBLECAPTURA = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtDisponibleCaptura"), TextBox).Text
        Dim DisponibleSistema As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("sdisp"), Label)
        Dim DisponibleCAptura As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtDisponibleCaptura"), TextBox)
        CType(dgLista.Items(e.Item.ItemIndex).FindControl("dispdif"), Label).Text = DisponibleSistema.Text - DisponibleCAptura.Text
        mEntDetalleInventario.CANTIDADDISPONIBLEDIFERENCIA = DisponibleSistema.Text - DisponibleCAptura.Text

        mEntDetalleInventario.CANTIDADNODISPONIBLECAPTURA = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtNoDisponibleCaptura"), TextBox).Text
        Dim NoDisponibleSistema As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("snodisp"), Label)
        Dim NoDisponibleCAptura As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtNoDisponibleCaptura"), TextBox)
        CType(dgLista.Items(e.Item.ItemIndex).FindControl("nodispdif"), Label).Text = NoDisponibleSistema.Text - NoDisponibleCAptura.Text
        mEntDetalleInventario.CANTIDADNODISPONIBLEDIFERENCIA = NoDisponibleSistema.Text - NoDisponibleCAptura.Text

        mEntDetalleInventario.CANTIDADVENCIDACAPTURA = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtVencidaCaptura"), TextBox).Text
        Dim VencidaSistema As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("svenc"), Label)
        Dim VencidaCAptura As TextBox = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtVencidaCaptura"), TextBox)
        CType(dgLista.Items(e.Item.ItemIndex).FindControl("vencdif"), Label).Text = VencidaSistema.Text - VencidaCAptura.Text
        mEntDetalleInventario.CANTIDADVENCIDADIFERENCIA = VencidaSistema.Text - VencidaCAptura.Text

        mEntDetalleInventario.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntDetalleInventario.AUFECHACREACION = Now()
        mEntDetalleInventario.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntDetalleInventario.AUFECHAMODIFICACION = Now()
        mEntDetalleInventario.ESTASINCRONIZADA = 0
        mCompDetalleInventario.ActualizarDETALLEINVENTARIO(mEntDetalleInventario)

        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
    End Sub
    Protected Sub dgLista_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.EditCommand
        'al momento de crear o consultar ajuste
        Me.UcAjusteInventario1.IDALMACEN = Me.lblAlmacen.Text
        Me.UcAjusteInventario1.IDINVENTARIO = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        Me.UcAjusteInventario1.IDDETALLE = CType(dgLista.Items(e.Item.ItemIndex).FindControl("id"), Label).Text
        Me.UcAjusteInventario1.DIFERENCIADISPONIBLE = CType(dgLista.Items(e.Item.ItemIndex).FindControl("dispdif"), Label).Text
        Me.UcAjusteInventario1.DIFERENCIANODISPONIBLE = CType(dgLista.Items(e.Item.ItemIndex).FindControl("nodispdif"), Label).Text
        Me.UcAjusteInventario1.DIFERENCIAVENCIDA = CType(dgLista.Items(e.Item.ItemIndex).FindControl("vencdif"), Label).Text
        Me.UcAjusteInventario1.EXISTE = CType(dgLista.Items(e.Item.ItemIndex).FindControl("lblExiste"), Label).Text
        Me.UcAjusteInventario1.PRODUCTO = CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtCodigoProducto"), TextBox).Text & " / " & CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtLote"), TextBox).Text & " / " & CType(dgLista.Items(e.Item.ItemIndex).FindControl("TxtProducto"), TextBox).Text
        Me.UcAjusteInventario1.IDPRODUCTO = CType(dgLista.Items(e.Item.ItemIndex).FindControl("idprod"), Label).Text
        Me.UcAjusteInventario1.IDLOTE = CType(dgLista.Items(e.Item.ItemIndex).FindControl("idlote"), Label).Text
        Me.UcAjusteInventario1.PRECIO = CType(dgLista.Items(e.Item.ItemIndex).FindControl("lblprecio"), Label).Text
        Me.UcAjusteInventario1.Visible = True
    End Sub

    Protected Sub UcAjusteInventario1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcAjusteInventario1.Agregar
        'al momento de agregar ajuste al inventario
        Me.UcAjusteInventario1.Visible = False
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
    End Sub

    Protected Sub UcAjusteInventario1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcAjusteInventario1.Cancelar
        'al momento de cancelar
        Me.UcAjusteInventario1.Visible = False
    End Sub

    Protected Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista.PageIndexChanged
        'al momento de cambiar de indice de pagina
        Me.dgLista.CurrentPageIndex = e.NewPageIndex
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
    End Sub
End Class
