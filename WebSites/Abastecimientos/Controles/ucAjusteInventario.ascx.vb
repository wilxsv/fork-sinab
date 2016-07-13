'INVENTARIO FISICO
'CU-ALMACEN012
'Ing. Yessenia Pennelope Henriquez Duran
'Control de usuario para el ajuste del inventario
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Data

Partial Class Controles_ucAjusteInventario
    Inherits System.Web.UI.UserControl
    'declaracion e incializacion de variables y eventos
    Private _IDALMACEN As Int32
    Private _IDINVENTARIO As Int32
    Private _IDDETALLE As Int32
    Private _DIFERENCIADISPONIBLE As Double
    Private _DIFERENCIANODISPONIBLE As Double
    Private _DIFERENCIAVENCIDA As Double
    Private _PRODUCTO As String
    Private _EXISTE As Boolean
    Private _IDPRODUCTO As Int32
    Private _IDLOTE As Int32
    Private _PRECIO As Decimal

    Public Event Cancelar As EventHandler
    Public Event Agregar As EventHandler
    Dim mComponente As New cAJUSTE
    Dim mEntidad As New AJUSTE
    Dim mEntMovimiento As New MOVIMIENTOS
    Dim mCompMovimiento As New cMOVIMIENTOS
    Dim mCompInventario As cDETALLEINVENTARIO
    Dim mEntDetalleMovimiento As New DETALLEMOVIMIENTOS
    Dim mCompDetalleMovimiento As New cDETALLEMOVIMIENTOS
    Dim mEntLote As New LOTES
    Dim mCompLote As New cLOTES

    Dim opc As Integer
    '--------------------------------------------------
    'propiedades
    Public Property IDALMACEN() As Int32 'identificador almacen
        Get
            Return Me._IDALMACEN
        End Get
        Set(ByVal Value As Int32)
            Me._IDALMACEN = Value
            Me.lblIDALMACEN.Text = Me._IDALMACEN
        End Set
    End Property
    Public Property IDINVENTARIO() As Int32 'identificador de inventario
        Get
            Return Me._IDINVENTARIO
        End Get
        Set(ByVal Value As Int32)
            Me._IDINVENTARIO = Value
            Me.lblIDINVENTARIO.Text = Me._IDINVENTARIO
        End Set
    End Property
    Public Property IDPRODUCTO() As Int32 'identificador de producto
        Get
            Return Me._IDPRODUCTO
        End Get
        Set(ByVal Value As Int32)
            Me._IDPRODUCTO = Value
            Me.lblIDPRODUCTO.Text = Me._IDPRODUCTO
        End Set
    End Property
    Public Property IDLOTE() As Int32 'identificador de lote
        Get
            Return Me._IDLOTE
        End Get
        Set(ByVal Value As Int32)
            Me._IDLOTE = Value
            Me.lblIDLOTE.Text = Me._IDLOTE
        End Set
    End Property
    Public Property IDDETALLE() As Int32 'identificador de detalle de inventario
        Get
            Return Me._IDDETALLE
        End Get
        Set(ByVal Value As Int32)
            Me._IDDETALLE = Value
            Me.lblIDDETALLE.Text = Me._IDDETALLE
        End Set
    End Property
    Public Property PRECIO() As Decimal 'precio producto
        Get
            Return Me._PRECIO
        End Get
        Set(ByVal Value As Decimal)
            Me._PRECIO = Value
            Me.lblPRECIO.Text = Me._PRECIO
        End Set
    End Property
    Public Property DIFERENCIADISPONIBLE() As Double 'diferencia disponible
        Get
            Return Me._DIFERENCIADISPONIBLE
        End Get
        Set(ByVal Value As Double)
            Me._DIFERENCIADISPONIBLE = Value
            Me.lblDDif.Text = Me._DIFERENCIADISPONIBLE
        End Set
    End Property
    Public Property DIFERENCIANODISPONIBLE() As Double 'diferencia no disponible
        Get
            Return Me._DIFERENCIANODISPONIBLE
        End Get
        Set(ByVal Value As Double)
            Me._DIFERENCIANODISPONIBLE = Value
            Me.lblNDif.Text = Me._DIFERENCIANODISPONIBLE
        End Set
    End Property
    Public Property DIFERENCIAVENCIDA() As Double 'diferencia vencida
        Get
            Return Me._DIFERENCIAVENCIDA
        End Get
        Set(ByVal Value As Double)
            Me._DIFERENCIAVENCIDA = Value
            Me.lblVDif.Text = Me._DIFERENCIAVENCIDA
        End Set
    End Property
    Public Property PRODUCTO() As String 'nombre porducto
        Get
            Return Me._PRODUCTO
        End Get
        Set(ByVal Value As String)
            Me._PRODUCTO = Value
            Me.LblProducto.Text = Me._PRODUCTO
        End Set
    End Property
    Public Property EXISTE() As Boolean 'existencia de ajuste
        Get
            Return Me._EXISTE
        End Get
        Set(ByVal Value As Boolean)
            Me._EXISTE = Value
            Me.lblExiste.Text = Me._EXISTE

            If Me._EXISTE Then
                opc = 2 'existe
                cargarDatos()
                AjustesInventario()
                Me.ImgbImprimir.Visible = True
            Else
                opc = 1 'agregar
                AjustesInventario()
                Me.ImgbImprimir.Visible = False
            End If
        End Set
    End Property
    Private Sub AjustesInventario()
        'muestra los ajustes a realizar en el inventario
        If Val(Me.lblDDif.Text) <> 0 Then
            If Val(Me.lblDDif.Text) > 0 Then
                Me.lblCantidadDisponible.Text = Me.lblDDif.Text
                Me.lblMensajeDisponible.Text = "Movimiento de ajuste (-) " & Me.lblDDif.Text
                Me.lblMovimientoDisponible.Text = "-"
            End If
            If Val(Me.lblDDif.Text) < 0 Then
                Me.lblCantidadDisponible.Text = Me.lblDDif.Text * -1
                Me.lblMensajeDisponible.Text = "Movimiento de ajuste (+) " & (Me.lblDDif.Text * -1)
                Me.lblMovimientoDisponible.Text = "+"
            End If

        Else
            Me.lblMensajeDisponible.Text = "Ningun movimiento al inventario"
            Me.lblMovimientoDisponible.Text = "0"
        End If

        If Val(Me.lblNDif.Text) <> 0 Then
            If Val(Me.lblNDif.Text) > 0 Then
                Me.lblCantidadNoDisponible.Text = Me.lblNDif.Text
                Me.lblMensajeNoDisponible.Text = "Movimiento de ajuste (-) " & Me.lblNDif.Text
                Me.lblMovimientoNoDisponible.Text = "-"
            End If

            If Val(Me.lblNDif.Text) < 0 Then
                Me.lblCantidadNoDisponible.Text = Me.lblNDif.Text * -1
                Me.lblMensajeNoDisponible.Text = "Movimiento de ajuste (+) " & (Me.lblNDif.Text * -1)
                Me.lblMovimientoNoDisponible.Text = "+"
            End If

        Else
            Me.lblMensajeNoDisponible.Text = "Ningun movimiento al inventario"
            Me.lblMovimientoNoDisponible.Text = "0"
        End If

        If Val(Me.lblVDif.Text) <> 0 Then
            If Val(Me.lblVDif.Text) > 0 Then
                Me.lblCantidadVencida.Text = Me.lblVDif.Text
                Me.lblMensajeVencido.Text = "Movimiento de ajuste (-) " & Me.lblVDif.Text
                Me.lblMovimientoVencido.Text = "-"
            End If

            If Val(Me.lblVDif.Text) < 0 Then
                Me.lblCantidadVencida.Text = Me.lblVDif.Text * -1
                Me.lblMensajeVencido.Text = "Movimiento de ajuste (+) " & (Me.lblVDif.Text * -1)
                Me.lblMovimientoVencido.Text = "+"
            End If

        Else
            Me.lblMensajeVencido.Text = "Ningun movimiento al inventario"
            Me.lblMovimientoVencido.Text = "0"
        End If

    End Sub

    Protected Sub Actualizar()
        'al momento de actualizar

        Dim mEntDetalleInventario As New DETALLEINVENTARIO
        Dim mCompDetalleInventario As New cDETALLEINVENTARIO
        Dim mEntInventario As New INVENTARIO
        Dim mCompInventario As New cINVENTARIO

        mEntidad.IDDETALLE = Me.lblIDDETALLE.Text
        mEntidad.IDINVENTARIO = Me.lblIDINVENTARIO.Text
        mEntidad.IDALMACEN = Me.lblIDALMACEN.Text
        mEntidad.IDJEFEALMACEN = Session.Item("IdEmpleado")

        mEntidad.MOTIVO = Me.TxtMotivo.Text
        mEntidad.OBSERVACION = Me.TxtObservacion.Text
        mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHACREACION = Now()
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0

        Select Case opc
            Case Is = 1 'agregar
                If mComponente.AgregarAJUSTE(mEntidad) <> 1 Then
                    MsgBox1.ShowAlert("Errores al guardar la informacion", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Else
                    MsgBox1.ShowAlert("Cambios guardados satisfactoriamente", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    'creacion de movimiento de ajustes
                    If Me.lblMovimientoDisponible.Text <> "0" Then CrearMovimientoAjuste(Me.lblMovimientoDisponible.Text, Me.lblCantidadDisponible.Text, 1)
                    If Me.lblMovimientoNoDisponible.Text <> "0" Then CrearMovimientoAjuste(Me.lblMovimientoNoDisponible.Text, Me.lblCantidadNoDisponible.Text, 2)
                    If Me.lblMovimientoVencido.Text <> "0" Then CrearMovimientoAjuste(Me.lblMovimientoVencido.Text, Me.lblCantidadVencida.Text, 3)

                End If
            Case Is = 2 'actualizar
                If mComponente.ActualizarAJUSTE(mEntidad) <> 1 Then
                    MsgBox1.ShowAlert("Errores al guardar la informacion", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Else
                    MsgBox1.ShowAlert("Cambios guardados satisfactoriamente", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

                End If
        End Select
    End Sub

    Protected Sub ImgbGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbGuardar.Click
        'al momento de seleccioanr guardar 
        If mComponente.ValidarExistenciaAjuste(Me.lblIDALMACEN.Text, Me.lblIDINVENTARIO.Text, Me.lblIDDETALLE.Text) Then
            opc = 2 'actualizar
        Else
            opc = 1 'agregar
        End If

        If Me.TxtMotivo.Text = "" Then
            MsgBox1.ShowAlert("Favor ingrese el motivo del ajuste", "F", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            Actualizar()
            RaiseEvent Agregar(sender, e)
        End If
    End Sub

    Protected Sub ImgbCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCancelar.Click
        'al presionar cancelar
        RaiseEvent Cancelar(sender, e)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar pagina
        If Not IsPostBack Then 'la primera vez
            Me.DdlCATALOGOPRODUCTOS1.Recuperar2()
        End If
    End Sub

    Private Sub cargarDatos()
        'carga de datos si existe ajuste
        mEntidad.IDALMACEN = Me.lblIDALMACEN.Text
        mEntidad.IDINVENTARIO = Me.lblIDINVENTARIO.Text
        mEntidad.IDDETALLE = Me.lblIDDETALLE.Text
        mComponente.ObtenerAJUSTE(mEntidad)

        Me.TxtMotivo.Text = mEntidad.MOTIVO
        Me.TxtObservacion.Text = mEntidad.OBSERVACION

    End Sub

    Protected Sub ImgbImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbImprimir.Click
        'al presionar imprimir ajuste
        Session.Item("RptAlmacen") = Me.lblIDALMACEN.Text 'identificador de almacen
        Session.Item("RptInventario") = Me.lblIDINVENTARIO.Text 'identificador de inventario
        Session.Item("RptDetalle") = Me.lblIDDETALLE.Text 'identificador de detalle

        Session.Item("RptVencidos") = True 'mostrar vencidos
        Session.Item("RptNoDisponibles") = True 'mostrar no disponible

        Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'>window.open('" + Request.ApplicationPath + "/Reportes/FrmRptAjusteInventario.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Private Sub CrearMovimientoAjuste(ByVal movimiento As String, ByVal cantidad As Double, ByVal tipocantidad As Integer)
        'cracion del documento de ajuste

        'encabezado de documento
        mEntMovimiento.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        If movimiento = "+" Then mEntMovimiento.IDTIPOTRANSACCION = 9 'Ajuste inventario (+)
        If movimiento = "-" Then mEntMovimiento.IDTIPOTRANSACCION = 10 'Ajuste inventario (-)
        Me.idMovimiento.Text = mCompMovimiento.ObtenerID(mEntMovimiento)
        mEntMovimiento.IDMOVIMIENTO = Me.idMovimiento.Text
        mEntMovimiento.IDALMACEN = Me.lblIDALMACEN.Text
        mEntMovimiento.IDTIPODOCREF = 5 'inventario fisico
        mEntMovimiento.NUMERODOCREF = Me.lblIDINVENTARIO.Text
        mEntMovimiento.ANIO = Now.Year
        mEntMovimiento.IDESTADO = 1 'grabado
        mEntMovimiento.TOTALMOVIMIENTO = cantidad * Me.lblPRECIO.Text
        mEntMovimiento.IDEMPLEADOALMACEN = Session.Item("IdEmpleado")
        mEntMovimiento.FECHAMOVIMIENTO = Now.Date
        mEntMovimiento.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntMovimiento.AUFECHACREACION = Now()
        mEntMovimiento.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntMovimiento.AUFECHAMODIFICACION = Now()
        mEntMovimiento.ESTASINCRONIZADA = 0
        mCompMovimiento.AgregarMOVIMIENTOS(mEntMovimiento)

        'detalle movimiento
        mEntDetalleMovimiento.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        If movimiento = "+" Then mEntDetalleMovimiento.IDTIPOTRANSACCION = 9 'Ajuste inventario (+)
        If movimiento = "-" Then mEntDetalleMovimiento.IDTIPOTRANSACCION = 10 'Ajuste inventario (-)
        mEntDetalleMovimiento.IDMOVIMIENTO = Me.idMovimiento.Text
        mEntDetalleMovimiento.IDDETALLEMOVIMIENTO = 0 'nuevo
        mEntDetalleMovimiento.IDALMACEN = Me.lblIDALMACEN.Text
        If Me.lblIDLOTE.Text <> "" Then mEntDetalleMovimiento.IDLOTE = Me.lblIDLOTE.Text
        mEntDetalleMovimiento.IDPRODUCTO = Me.lblIDPRODUCTO.Text
        mEntDetalleMovimiento.CANTIDAD = cantidad
        mEntDetalleMovimiento.MONTO = cantidad * Me.lblPRECIO.Text
        mEntDetalleMovimiento.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntDetalleMovimiento.AUFECHACREACION = Now()
        mEntDetalleMovimiento.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntDetalleMovimiento.AUFECHAMODIFICACION = Now()
        mEntDetalleMovimiento.ESTASINCRONIZADA = 0
        mCompDetalleMovimiento.ActualizarDETALLEMOVIMIENTOS(mEntDetalleMovimiento)

        'actualizacion de lotes en almacen 
        ActualizarLoteAlmacen(movimiento, cantidad, tipocantidad)

    End Sub
    Private Sub ActualizarLoteAlmacen(ByVal movimiento As String, ByVal cantidad As Double, ByVal tipocantidad As Integer)
        'cracion del documento de ajuste
        'LblCantidadTemporal
        'encabezado de documento

        mEntLote.IDALMACEN = Me.lblIDALMACEN.Text
        mEntLote.IDLOTE = Me.lblIDLOTE.Text
        mCompLote.ObtenerLOTES(mEntLote)

        If tipocantidad = 1 Then 'disponible
            Me.LblCantidadTemporal.Text = mEntLote.CANTIDADDISPONIBLE
            If movimiento = "+" Then cantidad = cantidad + Me.LblCantidadTemporal.Text 'Ajuste inventario (+)
            If movimiento = "-" Then cantidad = cantidad - Me.LblCantidadTemporal.Text 'Ajuste inventario (-)
            mEntLote.CANTIDADDISPONIBLE = cantidad
        End If

        If tipocantidad = 2 Then  'no disponible
            Me.LblCantidadTemporal.Text = mEntLote.CANTIDADNODISPONIBLE
            If movimiento = "+" Then cantidad = cantidad + Me.LblCantidadTemporal.Text 'Ajuste inventario (+)
            If movimiento = "-" Then cantidad = cantidad - Me.LblCantidadTemporal.Text 'Ajuste inventario (-)
            mEntLote.CANTIDADNODISPONIBLE = cantidad
        End If

        If tipocantidad = 3 Then 'vencida
            Me.LblCantidadTemporal.Text = mEntLote.CANTIDADVENCIDA
            If movimiento = "+" Then cantidad = cantidad + Me.LblCantidadTemporal.Text 'Ajuste inventario (+)
            If movimiento = "-" Then cantidad = cantidad - Me.LblCantidadTemporal.Text 'Ajuste inventario (-)
            mEntLote.CANTIDADVENCIDA = cantidad
        End If

        mEntLote.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntLote.AUFECHAMODIFICACION = Now()
        mCompLote.ActualizarLOTES(mEntLote)


    End Sub
End Class
