'Comunicar incumplimientos de contrato
'CU-UACI023
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario con la informacion de la nota dirigida al area juridica de la UACI para la aplicacion
'de las multas a los proveedores que han incumplido con las entregas programadas en el contrato
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Imports Cooperator.Framework.Web.Controls

Partial Class FrmNotaIncumplimientoContrato
    Inherits System.Web.UI.Page

    ' declaracion e inicializacion de variables
    Private mEntidadContrato As New CONTRATOS
    Private mCompContrato As New cCONTRATOS
    Private mEntidad As New NOTASINCUMPLIMIENTOCONTRATO
    Private mComponente As New cNOTASINCUMPLIMIENTOCONTRATO
    Private mCompEntregas As New cENTREGACONTRATO
    Dim entregas As Integer
    Dim DetalleEntrega As DataSet
    Private tEntidad As New INCUMPLIMIENTOCONTRATO 'entidad temporal

    Private _IDESTABLECIMIENTO As Int32
    Private _IDPROVEEDOR As Int32
    Private _IDRENGLON As Int32
    Private _IDPROCESO As Int32
    Private _IDCONTRATO As Integer

    Dim ds As DataSet
    Dim ds2 As DataSet

    Public Property IDPROCESO() As Int32 'identificador de proceso de compra
        Get
            Return Me._IDPROCESO
        End Get
        Set(ByVal Value As Int32)
            Me._IDPROCESO = Value
            Me.idproces.Text = Value
        End Set
    End Property

    Public Property IDRENGLON() As Int32    'identificador de renglon
        Get
            Return Me._IDRENGLON
        End Get
        Set(ByVal Value As Int32)
            Me._IDRENGLON = Value
            Me.idreng.Text = Value
        End Set
    End Property

    Public Property IDESTABLECIMIENTO() As Int32    'identificador de establecimiento
        Get
            Return Me._IDESTABLECIMIENTO
        End Get
        Set(ByVal Value As Int32)
            Me._IDESTABLECIMIENTO = Value
            Me.idestablec.Text = Value
        End Set
    End Property

    Public Property IDPROVEEDOR() As Int32  'identificador de proveedor
        Get
            Return Me._IDPROVEEDOR
        End Get
        Set(ByVal Value As Int32)
            Me._IDPROVEEDOR = Value
            Me.idprov.Text = Value
        End Set
    End Property

    Public Property IDCONTRATO() As Integer 'identificador de contrato
        Get
            Return Me._IDCONTRATO
        End Get
        Set(ByVal Value As Integer)
            Me._IDCONTRATO = Value
            Me.idcontrat.Text = Value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al momento de cargar la pagina

        If Not Page.IsPostBack Then 'la primera vez que carga la pagina
            Me.Master.ControlMenu.Visible = False 'oculta menu
            Try
                CargaInicial()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Public Sub CargaInicial()
        'funcion de carga inicial

        'oculta o muestra aspectos de la barra de navegacion
        Me.UcBarraNavegacion1.Navegacion = False
        Me.UcBarraNavegacion1.PermitirAgregar = False
        Me.UcBarraNavegacion1.PermitirEditar = True
        Me.UcBarraNavegacion1.PermitirConsultar = False
        Me.UcBarraNavegacion1.HabilitarEdicion(True)
        Me.UcBarraNavegacion1.PermitirImprimir = False
        Me.UcBarraNavegacion1.PermitirGuardar = False

        'asigna valores a los identificadores provenientes de la pagina que realizo llamada
        IDPROVEEDOR = Request.QueryString("idproveedor")
        IDESTABLECIMIENTO = Request.QueryString("idestablecimiento")
        IDCONTRATO = Request.QueryString("idcontrato")
        IDRENGLON = Request.QueryString("idrenglon")
        IDPROCESO = Request.QueryString("idproceso")

        'obtiene los controles adjudicados de un contrato y lo meuestra
        ds = mComponente.DatasetRenglonesContrato(Me.idestablec.Text, Me.idcontrat.Text, Me.idprov.Text)
        Dim r As DataRow
        For Each r In ds.Tables(0).Rows
            Me.LblProducto.Text = r("DESCLARGO") & " / " & r("DESCRIPCIONPROVEEDOR")
            Me.LblCodigo.Text = r("CORRPRODUCTO")
            Me.LblRenglon.Text = r("RENGLON")
        Next r

        DetallarEntregas() 'llama el detalle de entregas

        If Me.mostrarImprimir Then
            Me.ImageButton1.Visible = True
            Me.ImageButton2.Visible = True
        Else
            Me.ImageButton1.Visible = False
            Me.ImageButton2.Visible = False
        End If
    End Sub

    Private Sub DetallarEntregas()
        'funcion de detalle de entregas realizadas para un contrato
        Dim i As Integer
        Dim pc As New ArrayList

        entregas = mCompEntregas.ObtenerNumeroEntregas(Me.idcontrat.Text, Session.Item("IdEstablecimiento"))
        For i = 1 To 5
            MostrarEntrega(i, False)
        Next i
        For i = 1 To entregas
            Dim cInc As New cINCUMPLIMIENTO
            cInc.idEstablecimiento = Me.idestablec.Text
            pc.Add(Me.idproces.Text)
            cInc.idProcesoCompra = pc.ToArray
            cInc.idContrato = Me.idcontrat.Text
            cInc.idProveedor = Me.idprov.Text
            cInc.renglon = Me.idreng.Text
            cInc.entrega = i
            ds2 = cInc.obtenerDatasetIncumplimientos()
            LlenarEntrega(i, True, ds2)
        Next i
    End Sub

    Private Sub MostrarEntrega(ByVal id As Integer, ByVal edicion As Boolean)

        'funcion para mostrar control de entreas con cantidades de atraso y no entregados en funcion al numero de entregas del contrato
        Select Case id 'entrega
            Case 1 'entrega 1
                Me.UcEntregasConAtraso1.Visible = edicion
                Me.UcEntregasCantidadesNoEntregadas1.Visible = edicion
                Me.lblEntregaAtraso1.Visible = edicion
                Me.lblNoEntrega1.Visible = edicion
            Case 2 'entrega 2
                Me.UcEntregasConAtraso2.Visible = edicion
                Me.UcEntregasCantidadesNoEntregadas2.Visible = edicion
                Me.lblEntregaAtraso2.Visible = edicion
                Me.lblNoEntrega2.Visible = edicion
            Case 3 'entrega 3
                Me.UcEntregasConAtraso3.Visible = edicion
                Me.UcEntregasCantidadesNoEntregadas3.Visible = edicion
                Me.lblEntregaAtraso3.Visible = edicion
                Me.lblNoEntrega3.Visible = edicion
            Case 4 'entrega 4
                Me.UcEntregasConAtraso4.Visible = edicion
                Me.UcEntregasCantidadesNoEntregadas4.Visible = edicion
                Me.lblEntregaAtraso4.Visible = edicion
                Me.lblNoEntrega4.Visible = edicion
            Case 5 'entrega 5
                Me.UcEntregasConAtraso5.Visible = edicion
                Me.UcEntregasCantidadesNoEntregadas5.Visible = edicion
                Me.lblEntregaAtraso5.Visible = edicion
                Me.lblNoEntrega5.Visible = edicion
        End Select
    End Sub

    Private Sub LlenarEntrega(ByVal id As Integer, ByVal edicion As Boolean, ByVal dst As DataSet)
        'llenar los grid de entregas con atraso o no entregas en funcion a numero de entregas
        Select Case id 'entrega
            Case 1 'entrega 1
                Me.UcEntregasConAtraso1.Visible = edicion
                Me.UcEntregasCantidadesNoEntregadas1.Visible = edicion
                Me.UcEntregasConAtraso1.LlenarGridEntregaConAtraso(dst)
                Me.UcEntregasCantidadesNoEntregadas1.LlenarGridNoEntrega(dst)
                Me.lblEntregaAtraso1.Visible = edicion
                Me.lblNoEntrega1.Visible = edicion
            Case 2 'entrega 2
                Me.UcEntregasConAtraso2.Visible = edicion
                Me.UcEntregasCantidadesNoEntregadas2.Visible = edicion
                Me.UcEntregasConAtraso2.LlenarGridEntregaConAtraso(dst)
                Me.UcEntregasCantidadesNoEntregadas2.LlenarGridNoEntrega(dst)
                Me.lblEntregaAtraso2.Visible = edicion
                Me.lblNoEntrega2.Visible = edicion
            Case 3 'entrega 3
                Me.UcEntregasConAtraso3.Visible = edicion
                Me.UcEntregasCantidadesNoEntregadas3.Visible = edicion
                Me.UcEntregasConAtraso3.LlenarGridEntregaConAtraso(dst)
                Me.UcEntregasCantidadesNoEntregadas3.LlenarGridNoEntrega(dst)
                Me.lblEntregaAtraso3.Visible = edicion
                Me.lblNoEntrega3.Visible = edicion
            Case 4 'entrega 4
                Me.UcEntregasConAtraso4.Visible = edicion
                Me.UcEntregasCantidadesNoEntregadas4.Visible = edicion
                Me.UcEntregasConAtraso4.LlenarGridEntregaConAtraso(dst)
                Me.UcEntregasCantidadesNoEntregadas4.LlenarGridNoEntrega(dst)
                Me.lblEntregaAtraso4.Visible = edicion
                Me.lblNoEntrega4.Visible = edicion
            Case 5 'entrega 5
                Me.UcEntregasConAtraso5.Visible = edicion
                Me.UcEntregasCantidadesNoEntregadas5.Visible = edicion
                Me.UcEntregasConAtraso5.LlenarGridEntregaConAtraso(dst)
                Me.UcEntregasCantidadesNoEntregadas5.LlenarGridNoEntrega(dst)
                Me.lblEntregaAtraso5.Visible = edicion
                Me.lblNoEntrega5.Visible = edicion
        End Select
    End Sub

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar
        'evento al presionar cancelar en la barra de navegacion
        Response.Redirect("~/UACI/FrmComunicarIncumplimientos2.aspx?id= " + Me.idproces.Text & "&contrato= " + Me.idcontrat.Text & "&proveedor= " + Me.idprov.Text)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        'con atraso
        'al imprimir nota de inciumplimiento de contrato
        Session.Item("idContRep") = Me.idcontrat.Text
        Session.Item("idProvRep") = Me.idprov.Text
        Session.Item("idProceso") = Me.idproces.Text
        Session.Item("opc") = "2"
        Session.Item("DataSetRep") = DataSetReporte()
        Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptIncumplimientoContrato.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        'no entregadas
        'al imprimir nota de inciumplimiento de contrato
        Session.Item("idContRep") = Me.idcontrat.Text
        Session.Item("idProvRep") = Me.idprov.Text
        Session.Item("idProceso") = Me.idproces.Text
        Session.Item("opc") = "1"
        Session.Item("DataSetRep") = DataSetReporte()
        Page.ClientScript.RegisterStartupScript(Me.GetType, "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptIncumplimientoContrato.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Function mostrarImprimir() As Boolean
        If Me.UcEntregasConAtraso1.ESTADOENTREGA.Text = False Then Return False
        If Me.UcEntregasCantidadesNoEntregadas1.ESTADOENTREGA.Text = False Then Return False

        If Me.UcEntregasConAtraso2.ESTADOENTREGA.Text = False Then Return False
        If Me.UcEntregasCantidadesNoEntregadas2.ESTADOENTREGA.Text = False Then Return False

        If Me.UcEntregasConAtraso3.ESTADOENTREGA.Text = False Then Return False
        If Me.UcEntregasCantidadesNoEntregadas3.ESTADOENTREGA.Text = False Then Return False

        If Me.UcEntregasConAtraso4.ESTADOENTREGA.Text = False Then Return False
        If Me.UcEntregasCantidadesNoEntregadas4.ESTADOENTREGA.Text = False Then Return False

        If Me.UcEntregasConAtraso5.ESTADOENTREGA.Text = False Then Return False
        If Me.UcEntregasCantidadesNoEntregadas5.ESTADOENTREGA.Text = False Then Return False
        Return True
    End Function

    Protected Function DataSetReporte() As DataSet
        Dim dsti, dstrpt As DataSet
        Dim dtti As DataTable
        Dim r As DataRow
        Dim i As Integer
        Dim pc As New ArrayList
        Dim numentregas As Integer
        Dim Encabezado As INCUMPLIMIENTOCONTRATO

        dsti = mComponente.CreacionDataSetIncumplimientoContrato()
        dtti = dsti.Tables("INCUMPLIMIENTOCONTRATO")
        Encabezado = Session.Item("EntidadEncabezadoRep")

        numentregas = mCompEntregas.ObtenerNumeroEntregas(Me.idcontrat.Text, Session.Item("IdEstablecimiento"))

        For i = 1 To numentregas
            Dim cInc As New cINCUMPLIMIENTO
            cInc.idEstablecimiento = Me.idestablec.Text
            pc.Add(Me.idproces.Text)
            cInc.idProcesoCompra = pc.ToArray
            cInc.idContrato = Me.idcontrat.Text
            cInc.idProveedor = Me.idprov.Text
            cInc.renglon = Me.idreng.Text
            cInc.entrega = i
            ds2 = cInc.obtenerDatasetIncumplimientos()

            For Each r In ds2.Tables(0).Rows
                'llenar dataset reporte
                tEntidad.IDESTABLECIMIENTO = Me.idestablec.Text
                tEntidad.IDCONTRATO = Me.idcontrat.Text
                tEntidad.IDPROVEEDOR = Me.idprov.Text
                tEntidad.IDPROCESO = Me.idproces.Text
                tEntidad.TITULONOTA = Encabezado.TITULONOTA
                tEntidad.NOMBREDIRIGIDO = Encabezado.NOMBREDIRIGIDO
                tEntidad.CARGODIRIGIDO = Encabezado.CARGODIRIGIDO
                tEntidad.NOMBREENVIA = Encabezado.NOMBREENVIA
                tEntidad.CARGOENVIA = Encabezado.CARGOENVIA
                tEntidad.FECHAENTREGA = Encabezado.FECHAENTREGA
                tEntidad.IDNOTA = Encabezado.IDNOTA
                tEntidad.NUMEROCONTRATO = Encabezado.NUMEROCONTRATO
                tEntidad.TIPOLICITACION = Encabezado.TIPOLICITACION
                tEntidad.MONTOCONTRATO = Encabezado.MONTOCONTRATO
                tEntidad.CODIGOLICITACION = Encabezado.CODIGOLICITACION
                tEntidad.DESCRIPCIONLICITACION = Encabezado.DESCRIPCIONLICITACION
                tEntidad.PROVEEDOR = Encabezado.PROVEEDOR
                tEntidad.ENTREGA = r("numeroentrega")
                tEntidad.IDRENGLON = r("renglon")
                tEntidad.ALMACEN = r("almacen")
                tEntidad.CANTIDADNOENTREGADA = r("cantidadalmacen") - r("cantidadentregadaalmacen")
                tEntidad.CANTIDADCONATRASO = r("cantidadatrasoalmacen")
                tEntidad.DIASATRASO = r("tiempoatraso")
                tEntidad.IDPRODUCTO = r("idproducto")
                tEntidad.CODIGOPRODUCTO = r("codigoproducto")
                'tEntidad.LOTE = r("lote")
                'tEntidad.EXPIRA = r("fechavencimiento")
                tEntidad.PRECIO = r("preciounitario")
                tEntidad.MONTONOENTREGADO = (r("cantidadalmacen") - r("cantidadentregadaalmacen")) * r("preciounitario")
                tEntidad.MONTOCONATRASO = r("cantidadatrasoalmacen") * r("preciounitario")
                dstrpt = mComponente.CrearEntregaIncumplimiento(dsti, dtti, tEntidad)
                If i = numentregas Then Return dstrpt
            Next r
        Next i
        Return dsti
    End Function
End Class
