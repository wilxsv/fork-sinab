'INVENTARIO FISICO
'CU-ALMACEN012
'Ing. Yessenia Pennelope Henriquez Duran
'INVENTARIO FISICO DEL ESTABLECIMIENTO
'Consiste en recuiento de las existencias de productos dentro del almacen para la comparacion 
'de los valores realies y fisicos

Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class ucInventarioFinal
    Inherits System.Web.UI.UserControl

    'declaracion e inicializacion de variables
    Private mEntidad As New INVENTARIO
    Private mComponente As New cINVENTARIO
    Public Event actualizoInventario(ByVal idInventario As Int32)
    Public Event considerarInventario(ByVal fuente As Int32, ByVal repsonsable As Int32, ByVal vencidos As Int32, ByVal nodisponible As Int32)

    Public Property Nuevo() As Boolean
        'inventario nuevo
        Get
            Return Me.UcVistaDetalleInventarioFisico1.Enabled
        End Get
        Set(ByVal Value As Boolean)

            Me.UcVistaDetalleInventarioFisico1.habilitarInventario(True)
            Me.UcVistaDetalleInventarioFisico1.HabilitarCamposCierre(False)
            Me.BttGenerar.Visible = True
            Me.BttCerrar.Visible = False
            Me.BttCerrarConteo.Visible = False
            Me.UcDesgloceArticulosInventarioFinal1.Visible = True
            Me.UcDesgloceArticulosInventarioFinal1.PermitirEliminar = False
            Me.UcDesgloceArticulosInventarioFinal1.PermitirGuardar = True
        End Set
    End Property

    Public Property grabado(ByVal estado As Integer) As Boolean
        'inventrio en estado grabado
        Get
            Return Me.UcVistaDetalleInventarioFisico1.Enabled
        End Get
        Set(ByVal Value As Boolean)
            If estado = 0 Then 'sin cerrar
                Me.UcVistaDetalleInventarioFisico1.habilitarInventario(False)
                Me.BttGenerar.Visible = False
                Me.BttCerrar.Visible = False
                Me.BttCerrarConteo.Visible = True
                Me.UcDesgloceArticulosInventarioFinal1.Visible = True
                Me.UcDesgloceArticulosInventarioFinal1.PermitirEliminar = False
                Me.UcDesgloceArticulosInventarioFinal1.PermitirGuardar = True
            End If
            If estado = 2 Then 'cerrado conteo
                Me.UcVistaDetalleInventarioFisico1.habilitarInventario(False)
                Me.BttGenerar.Visible = False
                Me.BttCerrar.Visible = True
                Me.BttCerrarConteo.Visible = False
                Me.UcDesgloceArticulosInventarioFinal1.Visible = True
                Me.UcDesgloceArticulosInventarioFinal1.PermitirEliminar = False
                Me.UcDesgloceArticulosInventarioFinal1.PermitirGuardar = False
            End If
        End Set
    End Property
    Public Property cerrado() As Boolean
        'inventario cerrado
        Get
            Return Me.UcVistaDetalleInventarioFisico1.Enabled
        End Get
        Set(ByVal Value As Boolean)

            Me.UcVistaDetalleInventarioFisico1.habilitarInventario(False)
            Me.BttGenerar.Visible = False
            Me.BttCerrar.Visible = False
            Me.BttCerrarConteo.Visible = False
            Me.UcDesgloceArticulosInventarioFinal1.Visible = True
            Me.UcDesgloceArticulosInventarioFinal1.Enabled = False

        End Set
    End Property
    Public Property CODIGOENCABEZADODOCUMENTO() As Int32
        'identificador del inventario
        Get
            Return Me.UcVistaDetalleInventarioFisico1.IDINVENTARIO
        End Get
        Set(ByVal Value As Int32)
            Me.lblidinventario.Text = Value

            Me.UcVistaDetalleInventarioFisico1.IDINVENTARIO = Value
            Me.UcDesgloceArticulosInventarioFinal1.ObtenerDetalleDocumento(Value)
        End Set
    End Property

    Public ReadOnly Property ALMACEN() As Label 'identificador almacen
        Get
            Return Me.lblAlmacen
        End Get
    End Property
    Public ReadOnly Property FUENTE() As Label 'identificador fuente
        Get
            Return Me.LblFuente
        End Get
    End Property
    Public ReadOnly Property RESPONSABLE() As Label 'identificador responsable distribucion
        Get
            Return Me.LblResponsable
        End Get
    End Property
    Public ReadOnly Property SUMINISTRO() As Label 'identificador suministro
        Get
            Return Me.Lblsuminstro
        End Get
    End Property
    Public ReadOnly Property VENCIDOS() As Label 'mostrar vencidos
        Get
            Return Me.cVencidos
        End Get
    End Property
    Public ReadOnly Property NODISPONIBLES() As Label 'mostrar no disponible
        Get
            Return Me.cNodisponibles
        End Get
    End Property

    Public Function Actualizar() As String
        'al momentod e actualizar
        Dim sError As String
        sError = Me.UcVistaDetalleInventarioFisico1.Actualizar()
        If sError <> "" Then 'error al guardar
            Return sError
        End If
        Return Me.UcDesgloceArticulosInventarioFinal1.Actualizar()
    End Function

    Protected Sub UcDesgloceArticulosInventarioFinal1_Eliminado(ByVal CODIGOENZABEZADODOCUMENTO As Integer) Handles UcDesgloceArticulosInventarioFinal1.Eliminado
        'eliminado producto del detalle
        Me.UcVistaDetalleInventarioFisico1.IDINVENTARIO = CODIGOENZABEZADODOCUMENTO
    End Sub
    Protected Sub UcVistaDetalleInventarioFisico1_actualizoInventario(ByVal idInventario As Integer, ByVal idAlmacen As Integer, ByVal idsuministro As Integer, ByVal idfuente As Integer, ByVal idRespionsabe As Integer, ByVal Cierreexistencia As Date) Handles UcVistaDetalleInventarioFisico1.actualizoInventario
        'al actualizar encabezado de inventario
        Me.UcDesgloceArticulosInventarioFinal1.IDALMACEN = idAlmacen
        Me.lblAlmacen.Text = idAlmacen
        Me.UcDesgloceArticulosInventarioFinal1.IDSUMINISTRO = idsuministro
        Me.Lblsuminstro.Text = idsuministro
        Me.UcDesgloceArticulosInventarioFinal1.IDFUENTE = idfuente
        Me.LblFuente.Text = idfuente
        Me.UcDesgloceArticulosInventarioFinal1.IDRESPONSABLE = idRespionsabe
        Me.LblResponsable.Text = idRespionsabe
        Me.UcDesgloceArticulosInventarioFinal1.CIERREEXISTENCIAS = Cierreexistencia
        Me.UcDesgloceArticulosInventarioFinal1.ObtenerDetalleDocumento(idInventario)
        RaiseEvent actualizoInventario(idInventario)
    End Sub

    Protected Sub UcVistaDetalleInventarioFisico1_considerarInventario(ByVal fuente As Integer, ByVal repsonsable As Integer, ByVal vencidos As Integer, ByVal nodisponible As Integer) Handles UcVistaDetalleInventarioFisico1.considerarInventario
        'aspectos a considerar en inventario
        RaiseEvent considerarInventario(fuente, repsonsable, vencidos, nodisponible)
        Me.UcDesgloceArticulosInventarioFinal1.CONSIDERARVENCIDOS = vencidos
        If vencidos = 1 Then Me.cVencidos.Text = "True" Else Me.cVencidos.Text = "False"
        Me.UcDesgloceArticulosInventarioFinal1.CONSIDERARNODISPONIBLES = nodisponible
        If nodisponible = 1 Then Me.cNodisponibles.Text = "True" Else Me.cNodisponibles.Text = "False"

        Me.UcDesgloceArticulosInventarioFinal1.CONSIDERARFUENTE = fuente
        If fuente = 0 Then Me.LblFuente.Text = 0
        Me.UcDesgloceArticulosInventarioFinal1.CONSIDERARRESPONSABLE = repsonsable
        If repsonsable = 0 Then Me.LblResponsable.Text = 0

    End Sub

    Protected Sub BttGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BttGenerar.Click
        'al momento de generar el invaentario
        Me.UcVistaDetalleInventarioFisico1.Actualizar()
        Me.UcDesgloceArticulosInventarioFinal1.GenerarInventario(Me.lblidinventario.Text)
        Me.UcVistaDetalleInventarioFisico1.habilitarInventario(False)
        Me.UcDesgloceArticulosInventarioFinal1.PermitirAjustar = False
        Me.BttGenerar.Visible = False
        Me.BttCerrarConteo.Visible = True
        Me.BttCerrar.Visible = False

    End Sub

    Protected Sub BttCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BttCerrar.Click
        'al momento de cerrar inventario
        Me.UcVistaDetalleInventarioFisico1.HabilitarCamposCierre(True)
        Me.UcVistaDetalleInventarioFisico1.cerrarInventario()
        Me.UcDesgloceArticulosInventarioFinal1.PermitirAjustar = True
        Me.UcDesgloceArticulosInventarioFinal1.Enabled = False
        Me.BttCerrar.Visible = False
        Me.BttGenerar.Visible = False
        Me.BttCerrarConteo.Visible = False

    End Sub

    Protected Overrides Sub Finalize()
        'al finalizar
        MyBase.Finalize()
    End Sub
    Protected Sub BttCerrarConteo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BttCerrarConteo.Click
        'al momento de cerrar conteo
        Me.UcVistaDetalleInventarioFisico1.HabilitarCamposCierre(False)
        Me.UcDesgloceArticulosInventarioFinal1.PermitirAjustar = True
        Me.UcVistaDetalleInventarioFisico1.cerrarConteo()
        Me.UcDesgloceArticulosInventarioFinal1.Enabled = False
        Me.BttCerrar.Visible = True
        Me.BttCerrarConteo.Visible = False
        Me.BttGenerar.Visible = False

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        deshabilitarDobleClickBotones()
    End Sub

    Protected Sub deshabilitarDobleClickBotones()
        BttGenerar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(BttGenerar, Nothing) + ";"
        BttCerrar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(BttCerrar, Nothing) + ";"
        BttCerrarConteo.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(BttCerrarConteo, Nothing) + ";"
    End Sub

End Class
