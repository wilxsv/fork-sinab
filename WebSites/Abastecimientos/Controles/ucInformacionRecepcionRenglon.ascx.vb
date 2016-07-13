Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.EnumHelpers

Partial Class ucInformacionRecepcionRenglon
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _RENGLON As Integer
    Private _CANTIDADARECIBIR As Decimal
    Private _IDPRODUCTO As Integer
    Private _IDALMACEN As Integer
    Private _IDUNIDADMEDIDA As Integer
    Private _PRECIO As Decimal
    Private _CANTIDADDECIMAL As Integer
    Private _IDDOCUMENTO As Integer
    Private _IDESTABLECIMIENTOCC As Integer
    Private _IDINFORMECC As Integer

    Private _ANIO As Integer
    Private _IDRECIBO As Integer

    Private _IDMOVIMIENTO As Integer

    Private TLotes As Data.DataTable

#Region "Propiedades"

    Public WriteOnly Property PermitirCerrar() As Boolean
        Set(ByVal value As Boolean)
            btnCerrar.Enabled = value
        End Set
    End Property

    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
        End Set
    End Property

    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            _IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property

    Public Property IDCONTRATO() As Integer
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDCONTRATO = value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", value)
        End Set
    End Property

    Public Property RENGLON() As Integer
        Get
            Return _RENGLON
        End Get
        Set(ByVal value As Integer)
            _RENGLON = value
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.ViewState.Remove("RENGLON")
            Me.ViewState.Add("RENGLON", value)
        End Set
    End Property

    Public Property IDALMACEN() As Integer
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Integer)
            _IDALMACEN = value
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.ViewState.Remove("IDALMACEN")
            Me.ViewState.Add("IDALMACEN", value)
        End Set
    End Property

    Public Property CANTIDADARECIBIR() As Decimal
        Get
            Return _CANTIDADARECIBIR
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADARECIBIR = value
            If Not Me.ViewState("CANTIDADARECIBIR") Is Nothing Then Me.ViewState.Remove("CANTIDADARECIBIR")
            Me.ViewState.Add("CANTIDADARECIBIR", value)
            Me.cvCantidad.ValueToCompare = value
        End Set
    End Property

    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _IDPRODUCTO = value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", value)
        End Set
    End Property

    Public Property IDUNIDADMEDIDA() As Integer
        Get
            Return _IDUNIDADMEDIDA
        End Get
        Set(ByVal VALUE As Integer)
            _IDUNIDADMEDIDA = VALUE
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me.ViewState.Remove("IDUNIDADMEDIDA")
            Me.ViewState.Add("IDUNIDADMEDIDA", VALUE)
        End Set
    End Property

    Public Property PRECIO() As Decimal
        Get
            Return _PRECIO
        End Get
        Set(ByVal value As Decimal)
            _PRECIO = value
            If Not Me.ViewState("PRECIO") Is Nothing Then Me.ViewState.Remove("PRECIO")
            Me.ViewState.Add("PRECIO", value)
        End Set
    End Property

    Public Property CANTIDADDECIMAL() As Decimal
        Get
            Return _CANTIDADDECIMAL
        End Get
        Set(ByVal value As Decimal)
            _CANTIDADDECIMAL = value
            If Not Me.ViewState("CANTIDADDECIMAL") Is Nothing Then Me.ViewState.Remove("CANTIDADDECIMAL")
            Me.ViewState.Add("CANTIDADDECIMAL", value)
            Me.nbCantidad.DecimalPlaces = value
        End Set
    End Property

    Public Property IDDOCUMENTO() As Integer
        Get
            Return _IDDOCUMENTO
        End Get
        Set(ByVal value As Integer)
            _IDDOCUMENTO = value
            If Not Me.ViewState("IDDOCUMENTO") Is Nothing Then Me.ViewState.Remove("IDDOCUMENTO")
            Me.ViewState.Add("IDDOCUMENTO", value)
        End Set
    End Property

    Public Property IDINFORMECC() As Integer
        Get
            Return _IDINFORMECC
        End Get
        Set(ByVal value As Integer)
            _IDINFORMECC = value
            If Not Me.ViewState("IDINFORMECC") Is Nothing Then Me.ViewState.Remove("IDINFORMECC")
            Me.ViewState.Add("IDINFORMECC", value)
        End Set
    End Property

    Public Property IDESTABLECIMIENTOCC() As Integer
        Get
            Return _IDESTABLECIMIENTOCC
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTOCC = value
            If Not Me.ViewState("IDESTABLECIMIENTOCC") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTOCC")
            Me.ViewState.Add("IDESTABLECIMIENTOCC", value)
        End Set
    End Property

    Public Property ANIO() As Integer
        Get
            Return _ANIO
        End Get
        Set(ByVal value As Integer)
            _ANIO = value
            If Not Me.ViewState("ANIO") Is Nothing Then Me.ViewState.Remove("ANIO")
            Me.ViewState.Add("ANIO", value)
        End Set
    End Property

    Public Property IDRECIBO() As Integer
        Get
            Return _IDRECIBO
        End Get
        Set(ByVal value As Integer)
            _IDRECIBO = value
            If Not Me.ViewState("IDRECIBO") Is Nothing Then Me.ViewState.Remove("IDRECIBO")
            Me.ViewState.Add("IDRECIBO", value)
        End Set
    End Property

    Public Property IDMOVIMIENTO() As Integer
        Get
            Return _IDMOVIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDMOVIMIENTO = value
            If Not Me.ViewState("IDMOVIMIENTO") Is Nothing Then Me.ViewState.Remove("IDMOVIMIENTO")
            Me.ViewState.Add("IDMOVIMIENTO", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DeshabilitarDobleClickBotones()

        CrearTablaLotes()

        If Not IsPostBack Then
            'Me.cpFechaDocumento.SelectedDate = String.Empty
            Me.cpFechaDocumento.UpperBoundDate = Now
            Me.cpFechaRecepcion.UpperBoundDate = Now
            Me.cpFechaInformeCC.UpperBoundDate = Now
            Me.cvFechaDocumento.ValueToCompare = Now.Date
            Me.cvFechaRecepcion.ValueToCompare = Now.Date

            Me.ddlTIPODOCUMENTORECEPCION1.Recuperar()

            If Session.Item("GuardaAlmacen") = 1 Then Me.txtGuardalmacen.Text = Session.Item("NombreUsuario").ToString

        Else
            If Not Me.ViewState("TLotes") Is Nothing Then Me.TLotes.Merge(Me.ViewState("TLotes"), False, Data.MissingSchemaAction.Ignore)

            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me._IDCONTRATO = Me.ViewState("IDCONTRATO")
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me._IDALMACEN = Me.ViewState("IDALMACEN")
            If Not Me.ViewState("RENGLON") Is Nothing Then Me.RENGLON = Me.ViewState("RENGLON")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("IDUNIDADMEDIDA") Is Nothing Then Me.IDUNIDADMEDIDA = Me.ViewState("IDUNIDADMEDIDA")

            If Not Me.ViewState("CANTIDADARECIBIR") Is Nothing Then Me.CANTIDADARECIBIR = Me.ViewState("CANTIDADARECIBIR")
            If Not Me.ViewState("IDDOCUMENTO") Is Nothing Then Me.IDDOCUMENTO = Me.ViewState("IDDOCUMENTO")
            If Not Me.ViewState("PRECIO") Is Nothing Then Me.PRECIO = Me.ViewState("PRECIO")

            If Not Me.ViewState("CANTIDADDECIMAL") Is Nothing Then Me.CANTIDADDECIMAL = Me.ViewState("CANTIDADDECIMAL")

            If Not Me.ViewState("IDESTABLECIMIENTOCC") Is Nothing Then Me.IDESTABLECIMIENTOCC = Me.ViewState("IDESTABLECIMIENTOCC")
            If Not Me.ViewState("IDINFORMECC") Is Nothing Then Me.IDINFORMECC = Me.ViewState("IDINFORMECC")

            If Not Me.ViewState("ANIO") Is Nothing Then Me.ANIO = Me.ViewState("ANIO")
            If Not Me.ViewState("IDRECIBO") Is Nothing Then Me.IDRECIBO = Me.ViewState("IDRECIBO")

            If Not Me.ViewState("IDMOVIMIENTO") Is Nothing Then Me._IDMOVIMIENTO = Me.ViewState("IDMOVIMIENTO")

        End If

    End Sub

    Public Sub CargarDatos()

        Me.ddlFUENTEFINANCIAMIENTOSCONTRATOS1.RecuperarListaPorContrato(Me.IDESTABLECIMIENTO, Me.IDCONTRATO, Me.IDPROVEEDOR)
        Me.ddlRESPONSABLEDISTRIBUCIONCONTRATO1.RecuperarListaPorContrato(Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO)

        'buscar lotes muestreados para el renglón
        Dim cIM As New cINFORMEMUESTRAS

        Dim ds As Data.DataSet
        ds = cIM.ObtenerInformacionLotesRenglon(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)

        Me.gvLotesMuestreados.DataSource = ds
        Me.gvLotesMuestreados.DataBind()

        Resetear()

        Me.plRecepcion.Visible = True

    End Sub

    Private Sub CrearTablaLotes()

        If TLotes Is Nothing Then

            TLotes = New Data.DataTable

            Dim campo As Data.DataColumn
            Dim PrimaryKey(4) As Data.DataColumn

            campo = New Data.DataColumn("RENGLON", System.Type.GetType("System.Int32"))
            TLotes.Columns.Add(campo)
            PrimaryKey(0) = campo

            campo = New Data.DataColumn("LOTE", System.Type.GetType("System.String"))
            TLotes.Columns.Add(campo)
            PrimaryKey(1) = campo

            campo = New Data.DataColumn("DETALLE", System.Type.GetType("System.String"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("IDLOTE", System.Type.GetType("System.Int32"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("IDDETALLEMOVIMIENTO", System.Type.GetType("System.Int32"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("DOCUMENTO", System.Type.GetType("System.String"))
            TLotes.Columns.Add(campo)
            PrimaryKey(2) = campo

            campo = New Data.DataColumn("FECHADOCUMENTO", System.Type.GetType("System.DateTime"))
            TLotes.Columns.Add(campo)
            PrimaryKey(3) = campo

            campo = New Data.DataColumn("FECHAVENCIMIENTOMMAAAA", System.Type.GetType("System.String"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("CANTIDAD", System.Type.GetType("System.Decimal"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("IDUBICACION", System.Type.GetType("System.Int32"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("UBICACION", System.Type.GetType("System.String"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("IDESTABLECIMIENTOCC", System.Type.GetType("System.Int32"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("IDINFORMECC", System.Type.GetType("System.Int32"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("NUMEROINFORMECC", System.Type.GetType("System.String"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("FECHAINFORMECC", System.Type.GetType("System.DateTime"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("IMPORTE", System.Type.GetType("System.Decimal"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("IDPRODUCTO", System.Type.GetType("System.Int32"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("IDUNIDADMEDIDA", System.Type.GetType("System.Int32"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("PRECIO", System.Type.GetType("System.Decimal"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("IDFUENTEFINANCIAMIENTO", System.Type.GetType("System.Int32"))
            TLotes.Columns.Add(campo)
            PrimaryKey(4) = campo

            campo = New Data.DataColumn("FUENTEFINANCIAMIENTO", System.Type.GetType("System.String"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("IDRESPONSABLEDISTRIBUCION", System.Type.GetType("System.Int32"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("RESPONSABLEDISTRIBUCION", System.Type.GetType("System.String"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("TIPODOCUMENTO", System.Type.GetType("System.String"))
            TLotes.Columns.Add(campo)

            campo = New Data.DataColumn("ELIMINADO", System.Type.GetType("System.Int16"))
            campo.DefaultValue = 0
            TLotes.Columns.Add(campo)

            TLotes.PrimaryKey = PrimaryKey

            TLotes.DefaultView.RowFilter = "ELIMINADO=0"

        End If

    End Sub

    Protected Sub cbLoteNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbLoteNA.CheckedChanged
        Me.txtLote.Enabled = Not Me.cbLoteNA.Checked
        Me.txtLote.Text = String.Empty
        Me.txtDETALLE.Enabled = Not Me.cbLoteNA.Checked
        Me.txtDETALLE.Text = String.Empty
        Me.rfvLote.Visible = Not Me.cbLoteNA.Checked
    End Sub

    Protected Sub cbFechaVtoNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbFechaVtoNA.CheckedChanged
        Me.txtFechaVto.Enabled = Not Me.cbFechaVtoNA.Checked
        Me.rfvFechaVto.Visible = Not Me.cbFechaVtoNA.Checked
    End Sub

    Protected Sub cbNumeroInformeCCNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNumeroInformeCCNA.CheckedChanged
        Me.txtNumeroInformeCC.Text = String.Empty
        Me.txtNumeroInformeCC.Enabled = Not Me.cbNumeroInformeCCNA.Checked
        Me.rfvNumeroInformeCC.Visible = Not Me.cbNumeroInformeCCNA.Checked

        Me.cpFechaInformeCC.Enabled = Not Me.cbNumeroInformeCCNA.Checked
        Me.rfvFechaInformeCC.Visible = Not Me.cbNumeroInformeCCNA.Checked
    End Sub

    Protected Sub btnAgregarLote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarLote.Click

        'validaciones en el servidor
        'If Me.txtLote.Text.Trim = String.Empty And Not Me.cbLoteNA.Checked Then
        '    Me.lblInformesErr.Text = "* Los datos son requeridos si no se marca que no aplican"
        '    Me.lblInformesErr.Visible = True
        '    Exit Sub
        'End If

        'If CDbl(Me.nbCantidad.Text) <= 0 Then
        '    Exit Sub
        'End If

        'If Me.btnAgregarLote.Text = "Actualizar Lote" Then
        '    Dim A, B, C As Decimal
        '    A = CDec(Me.nbCantidad.Text)
        '    B = CDec(Me.Label2.Text)
        '    C = CDbl(Me.nbCantidad.Text)

        '    If B < C Then
        '        If (C - B) > A Then
        '            Exit Sub
        '        End If
        '    End If
        'Else
        '    If CDbl(Me.nbCantidad.Text) > CDbl(Me.nbCantidad.Text) Then
        '        Exit Sub
        '    End If
        'End If

        'If Me.lblImporte.Text = "" Then
        '    Exit Sub
        'End If

        Dim FechaVto As Date

        If Not Me.cbFechaVtoNA.Checked Then

            If Me.txtFechaVto.Text.Trim = String.Empty Then
                Me.MsgBox1.ShowAlert("Debe ingresar la fecha de vencimiento", "e", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                Return
            End If

            FechaVto = New Date(Year(Me.txtFechaVto.Text), Month(Me.txtFechaVto.Text), 1)
            FechaVto = DateAdd(DateInterval.Month, 1, FechaVto)
            FechaVto = DateAdd(DateInterval.Day, -1, FechaVto)

            If FechaVto < Now.Date Then
                Me.MsgBox1.ShowAlert("La fecha de vencimiento debe ser mayor a la fecha actual", "e", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                Return
            End If
        End If

        'buscar en la tabla
        Dim keys(4) As Object
        keys(0) = Me.RENGLON
        keys(1) = Me.txtLote.Text
        keys(2) = Me.txtDocumento.Text
        keys(3) = Me.cpFechaDocumento.SelectedDate
        keys(4) = Me.ddlFUENTEFINANCIAMIENTOSCONTRATOS1.SelectedValue

        If TLotes.Rows.Contains(keys) Then
            Me.MsgBox1.ShowAlert("Lote ya ingresado para este renglón.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
            Return
        End If

        Dim drLote As Data.DataRow = TLotes.NewRow

        drLote("RENGLON") = Me.RENGLON

        drLote("LOTE") = IIf(Me.cbLoteNA.Checked, String.Empty, Me.txtLote.Text)

        If Not Me.cbLoteNA.Checked Then drLote("DETALLE") = Me.txtDETALLE.Text
        If Not Me.cbFechaVtoNA.Checked Then drLote("FECHAVENCIMIENTOMMAAAA") = String.Format("{0:MM/yyy}", FechaVto)

        drLote("TIPODOCUMENTO") = ddlTIPODOCUMENTORECEPCION1.SelectedValue
        drLote("DOCUMENTO") = Me.txtDocumento.Text
        drLote("FECHADOCUMENTO") = Me.cpFechaDocumento.SelectedDate
        drLote("CANTIDAD") = CDec(Me.nbCantidad.Text)
        CANTIDADARECIBIR -= CDec(Me.nbCantidad.Text)

        drLote("UBICACION") = Me.txtUbicacion.Text
        drLote("IDPRODUCTO") = Me.IDPRODUCTO
        drLote("IDUNIDADMEDIDA") = Me.IDUNIDADMEDIDA

        drLote("IDESTABLECIMIENTOCC") = Me.IDINFORMECC
        drLote("IDINFORMECC") = Me.IDINFORMECC
        If Not Me.cbNumeroInformeCCNA.Checked Then drLote("NUMEROINFORMECC") = Me.txtNumeroInformeCC.Text
        If Not Me.cbNumeroInformeCCNA.Checked Then drLote("FECHAINFORMECC") = Me.cpFechaInformeCC.SelectedDate

        drLote("PRECIO") = Me.PRECIO
        drLote("IMPORTE") = CDec(Me.nbCantidad.Text) * Me.PRECIO

        drLote("IDFUENTEFINANCIAMIENTO") = Me.ddlFUENTEFINANCIAMIENTOSCONTRATOS1.SelectedValue
        drLote("FUENTEFINANCIAMIENTO") = Me.ddlFUENTEFINANCIAMIENTOSCONTRATOS1.SelectedItem.Text

        drLote("IDRESPONSABLEDISTRIBUCION") = Me.ddlRESPONSABLEDISTRIBUCIONCONTRATO1.SelectedValue
        drLote("RESPONSABLEDISTRIBUCION") = Me.ddlRESPONSABLEDISTRIBUCIONCONTRATO1.SelectedItem.Text

        TLotes.Rows.Add(drLote)

        If Not Me.ViewState("TLotes") Is Nothing Then Me.ViewState.Remove("TLotes")
        Me.ViewState.Add("TLotes", TLotes)

        Me.gvTemp.DataSource = TLotes
        Me.gvTemp.DataBind()

        'Me.btnGuardar.Enabled = True
        'Me.btnCerrar.Enabled = False
        'Me.btnImprimir.Enabled = False

        Resetear()

    End Sub

    Public Sub Resetear()

        'Me.txtDocumento.Text = String.Empty
        'Me.cpFechaDocumento.SelectedDate = Now

        Me.nbCantidad.Text = String.Empty
        Me.txtUbicacion.Text = String.Empty

        Me.txtLote.Text = String.Empty
        Me.txtLote.Enabled = True
        Me.rfvLote.Visible = True

        Me.txtDETALLE.Text = String.Empty
        Me.txtDETALLE.Enabled = True
        Me.cbLoteNA.Checked = False

        Me.txtFechaVto.Text = String.Empty
        Me.txtFechaVto.Enabled = True
        Me.rfvFechaVto.Visible = True
        Me.cbFechaVtoNA.Checked = False

        Me.txtNumeroInformeCC.Text = String.Empty
        Me.txtNumeroInformeCC.Enabled = True
        Me.rfvNumeroInformeCC.Visible = True

        Me.cpFechaInformeCC.SelectedDate = Now
        Me.cpFechaInformeCC.Enabled = True
        Me.cbNumeroInformeCCNA.Checked = False

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Try
            Dim cRR As New cRECIBOSRECEPCION
            Dim cM As New cMOVIMIENTOS
            Dim cDM As New cDETALLEMOVIMIENTOS
            Dim cL As New cLOTES
            Dim cU As New cUBICACIONESPRODUCTOS
            Dim cAEC As New cALMACENESENTREGACONTRATOS

            'RECIBO
            Dim eRR As New RECIBOSRECEPCION
            eRR.IDALMACEN = Me.IDALMACEN
            eRR.ANIO = IIf(Me.ANIO = 0, Me.cpFechaRecepcion.SelectedDate.Year, Me.ANIO)
            eRR.IDRECIBO = Me.IDRECIBO
            eRR.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
            eRR.IDPROVEEDOR = IDPROVEEDOR
            eRR.IDCONTRATO = IDCONTRATO
            eRR.RESPONSABLEPROVEEDOR = Me.txtDelegadoProveedor.Text
            eRR.NUMEROACTA = 0
            eRR.OBSERVACION = Me.txtObservaciones.Text
            eRR.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eRR.AUFECHACREACION = Now()
            eRR.AUUSUARIOMODIFICACION = Nothing
            eRR.AUFECHAMODIFICACION = Nothing
            eRR.ESTASINCRONIZADA = 0

            cRR.ActualizarRECIBOSRECEPCION(eRR)

            Me.IDDOCUMENTO = eRR.IDRECIBO

            'MOVIMIENTO
            Dim eM As New MOVIMIENTOS

            eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            eM.IDTIPOTRANSACCION = TiposTransaccion.RecepcionProductos
            eM.IDMOVIMIENTO = Me.IDMOVIMIENTO

            eM.IDTIPODOCREF = eTIPODOCUMENTOREFERENCIAS.Contrato
            eM.NUMERODOCREF = 0 '?

            eM.IDALMACEN = eRR.IDALMACEN
            eM.ANIO = eRR.ANIO
            eM.IDDOCUMENTO = eRR.IDRECIBO

            eM.IDESTADO = eESTADOSMOVIMIENTOS.Grabado

            eM.FECHAMOVIMIENTO = Me.cpFechaRecepcion.SelectedDate
            eM.IDESTABLECIMIENTODESTINO = Nothing

            eM.IDALMACENDESTINO = Me.IDALMACEN
            eM.IDUNIDADSOLICITA = Session.Item("IdDependencia")
            eM.TOTALMOVIMIENTO = 0 '?

            eM.IDEMPLEADOSOLICITA = Session.Item("IdEmpleado")

            eM.IDEMPLEADOALMACEN = Nothing
            eM.EMPLEADOALMACEN = Me.txtGuardalmacen.Text

            eM.CLASIFICACIONMOVIMIENTO = 1
            eM.SUBCLASIFICACIONMOVIMIENTO = 1

            eM.RESPONSABLEDISTRIBUCION = Nothing

            eM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eM.AUFECHACREACION = Now()
            eM.AUUSUARIOMODIFICACION = Nothing
            eM.AUFECHAMODIFICACION = Nothing
            eM.ESTASINCRONIZADA = 0

            cM.ActualizarMOVIMIENTOS(eM)

            Me.IDMOVIMIENTO = eM.IDMOVIMIENTO

            For Each row As Data.DataRow In TLotes.Rows

                Dim ELIMINADO As Integer = row.Item("ELIMINADO")

                Dim eL As New LOTES
                Dim eDM As New DETALLEMOVIMIENTOS
                Dim eU As New UBICACIONESPRODUCTOS

                If ELIMINADO = 1 Then

                    'en orden inverso
                    'UBICACIONESPRODUCTOS
                    cU.EliminarUBICACIONESPRODUCTOS(eM.IDALMACEN, row.Item("IDPRODUCTO"), row.Item("IDUBICACION"))
                    'DETALLEMOVIMIENTOS
                    cDM.EliminarDETALLEMOVIMIENTOS(eM.IDESTABLECIMIENTO, eM.IDTIPOTRANSACCION, eM.IDMOVIMIENTO, row.Item("IDDETALLEMOVIMIENTO"))
                    'LOTES
                    cL.EliminarLOTES(eM.IDALMACEN, row.Item("IDLOTE"))


                    Dim eAEC As New ALMACENESENTREGACONTRATOS

                    eAEC.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
                    eAEC.IDPROVEEDOR = Me.IDPROVEEDOR
                    eAEC.IDCONTRATO = Me.IDCONTRATO
                    eAEC.RENGLON = row.Item("RENGLON")
                    eAEC.IDALMACENENTREGA = Me.IDALMACEN
                    eAEC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    eAEC.AUFECHAMODIFICACION = Now

                    Dim ds As Data.DataSet
                    ds = cAEC.ObtenerDsEntregas(Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO, eAEC.RENGLON, Me.IDALMACEN, 1)

                    Dim dr As Data.DataRow
                    Dim i As Integer = 0
                    Dim cantidad As Decimal = row.Item("CANTIDAD")

                    While cantidad > 0 And i < ds.Tables(0).Rows.Count

                        dr = ds.Tables(0).Rows(i)
                        eAEC.IDDETALLE = dr("IDDETALLE")

                        If cantidad > dr("CANTIDADENTREGADA") Then
                            eAEC.CANTIDADENTREGADA = 0
                            cantidad -= dr("CANTIDADENTREGADA")
                        Else
                            eAEC.CANTIDADENTREGADA = dr("CANTIDADENTREGADA") - cantidad
                            cantidad = 0
                        End If

                        cAEC.ActualizarCantidadEntregada(eAEC)

                        i = i + 1

                    End While

                Else
                    'LOTES
                    eL.IDALMACEN = Me.IDALMACEN
                    eL.IDLOTE = IIf(row.Item("IDLOTE") Is DBNull.Value, 0, row.Item("IDLOTE"))
                    eL.IDPRODUCTO = row.Item("IDPRODUCTO")
                    eL.IDUNIDADMEDIDA = row.Item("IDUNIDADMEDIDA")
                    eL.CODIGO = IIf(row.Item("LOTE") Is DBNull.Value, 0, row.Item("LOTE"))
                    eL.DETALLE = IIf(row.Item("DETALLE") Is DBNull.Value, 0, row.Item("DETALLE"))
                    eL.PRECIOLOTE = row.Item("PRECIO")
                    eL.FECHAVENCIMIENTO = IIf(row.Item("FECHAVENCIMIENTOMMAAAA") Is DBNull.Value, Nothing, row.Item("FECHAVENCIMIENTOMMAAAA"))
                    eL.IDFUENTEFINANCIAMIENTO = row.Item("IDFUENTEFINANCIAMIENTO")
                    eL.IDRESPONSABLEDISTRIBUCION = row.Item("IDRESPONSABLEDISTRIBUCION")

                    eL.IDESTABLECIMIENTO = IIf(row.Item("IDESTABLECIMIENTOCC") Is DBNull.Value, Nothing, row.Item("IDESTABLECIMIENTOCC"))
                    eL.IDINFORMECONTROLCALIDAD = IIf(row.Item("IDINFORMECC") Is DBNull.Value, Nothing, row.Item("IDINFORMECC"))

                    eL.NUMEROINFORMECONTROLCALIDAD = IIf(row.Item("NUMEROINFORMECC") Is DBNull.Value, Nothing, row.Item("NUMEROINFORMECC"))
                    eL.FECHAINFORMECONTROLCALIDAD = IIf(row.Item("FECHAINFORMECC") Is DBNull.Value, Nothing, row.Item("FECHAINFORMECC"))

                    eL.CANTIDADDISPONIBLE = row.Item("CANTIDAD")
                    eL.ESTADISPONIBLE = 0

                    eL.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    eL.AUFECHACREACION = Now()
                    eL.AUUSUARIOMODIFICACION = Nothing
                    eL.AUFECHAMODIFICACION = Nothing
                    eL.ESTASINCRONIZADA = 0

                    cL.ActualizarLOTES(eL)

                    'DETALLEMOVIMIENTOS
                    eDM.IDESTABLECIMIENTO = eM.IDESTABLECIMIENTO
                    eDM.IDTIPOTRANSACCION = eM.IDTIPOTRANSACCION
                    eDM.IDMOVIMIENTO = eM.IDMOVIMIENTO
                    eDM.IDDETALLEMOVIMIENTO = IIf(row.Item("IDDETALLEMOVIMIENTO") Is DBNull.Value, 0, row.Item("IDDETALLEMOVIMIENTO"))

                    eDM.IDALMACEN = eM.IDALMACEN
                    eDM.IDLOTE = eL.IDLOTE
                    eDM.IDPRODUCTO = eL.IDPRODUCTO
                    eDM.RENGLON = row.Item("RENGLON")
                    eDM.CANTIDAD = row.Item("CANTIDAD")

                    eDM.IDTIPODOCUMENTO = row.Item("TIPODOCUMENTO")
                    eDM.NUMEROFACTURA = row.Item("DOCUMENTO")
                    eDM.FECHAFACTURA = row.Item("FECHADOCUMENTO")

                    eDM.MONTO = 0

                    eDM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    eDM.AUFECHACREACION = Now()
                    eDM.AUUSUARIOMODIFICACION = Nothing
                    eDM.AUFECHAMODIFICACION = Nothing
                    eDM.ESTASINCRONIZADA = 0

                    cDM.ActualizarDETALLEMOVIMIENTOS(eDM)

                    'UBICACIONESPRODUCTOS
                    eU.IDALMACEN = eM.IDALMACEN
                    eU.IDPRODUCTO = eDM.IDPRODUCTO
                    eU.IDUBICACION = IIf(row.Item("IDUBICACION") Is DBNull.Value, 0, row.Item("IDUBICACION"))
                    eU.UBICACION = row.Item("UBICACION")
                    eU.IDLOTE = eL.IDLOTE
                    eU.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    eU.AUFECHACREACION = Now()
                    eU.AUUSUARIOMODIFICACION = Nothing
                    eU.AUFECHAMODIFICACION = Nothing
                    eU.ESTASINCRONIZADA = 0

                    cU.ActualizarUBICACIONESPRODUCTOS(eU)

                    'TODO: agregar insert en detalle almacen entrega contrato

                    'ACTUALIZAR LAS CANTIDADES EN CADA ENTREGA
                    Dim eAEC As New ALMACENESENTREGACONTRATOS

                    eAEC.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
                    eAEC.IDPROVEEDOR = Me.IDPROVEEDOR
                    eAEC.IDCONTRATO = Me.IDCONTRATO
                    eAEC.RENGLON = eDM.RENGLON
                    eAEC.IDALMACENENTREGA = Me.IDALMACEN
                    eAEC.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    eAEC.AUFECHAMODIFICACION = Now

                    Dim ds As Data.DataSet
                    ds = cAEC.ObtenerDsEntregas(Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO, eDM.RENGLON, Me.IDALMACEN, ddlFUENTEFINANCIAMIENTOSCONTRATOS1.SelectedValue)
                    Dim dr As Data.DataRow
                    Dim i As Integer = 0

                    While eDM.CANTIDAD > 0 And i < ds.Tables(0).Rows.Count

                        dr = ds.Tables(0).Rows(i)
                        eAEC.IDDETALLE = dr("IDDETALLE")

                        If dr("CANTIDADENTREGADA") + eDM.CANTIDAD <= dr("CANTIDAD") Then
                            'no completa entrega
                            eAEC.CANTIDADENTREGADA += eDM.CANTIDAD
                            eDM.CANTIDAD = 0
                        Else
                            'completo entrega
                            eAEC.CANTIDADENTREGADA = dr("CANTIDAD")
                            eDM.CANTIDAD -= (dr("CANTIDAD") - dr("CANTIDADENTREGADA"))
                        End If

                        cAEC.ActualizarCantidadEntregada(eAEC)

                        i = i + 1

                    End While

                End If

            Next

            Me.btnAgregarLote.Enabled = False
            Me.gvTemp.Columns.Item(10).Visible = False

            Me.btnCerrar.Enabled = True
            Me.btnImprimir.Enabled = True

            Me.MsgBox1.ShowAlert("La recepción de los productos se ha guardado satisfactoriamente. Puede imprimir el recibo de recepción.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)

        Catch ex As Exception
            Me.MsgBox1.ShowAlert("Error:" & ex.Message, "e", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        End Try

    End Sub

    Protected Sub gvTemp_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvTemp.RowDeleting

        Dim keys(4) As Object
        keys(0) = Me.gvTemp.DataKeys(e.RowIndex).Values.Item("RENGLON")
        keys(1) = Server.HtmlDecode(Me.gvTemp.DataKeys(e.RowIndex).Values.Item("LOTE"))
        keys(2) = Server.HtmlDecode(Me.gvTemp.DataKeys(e.RowIndex).Values.Item("DOCUMENTO"))
        keys(3) = Me.gvTemp.DataKeys(e.RowIndex).Values.Item("FECHADOCUMENTO")
        keys(4) = Me.gvTemp.DataKeys(e.RowIndex).Values.Item("IDFUENTEFINANCIAMIENTO")

        If Me.gvTemp.DataKeys(e.RowIndex).Values.Item("RENGLON") = Me.RENGLON Then
            CANTIDADARECIBIR += Me.gvTemp.DataKeys(e.RowIndex).Values.Item("CANTIDAD")
        End If

        If Me.gvTemp.DataKeys(e.RowIndex).Values.Item("IDLOTE") Is DBNull.Value Then
            TLotes.Rows.Remove(TLotes.Rows.Find(keys))
        Else
            TLotes.Rows(TLotes.Rows.IndexOf(TLotes.Rows.Find(keys))).Item("ELIMINADO") = 1
        End If

        If Not Me.ViewState("TLotes") Is Nothing Then Me.ViewState.Remove("TLotes")
        Me.ViewState.Add("TLotes", TLotes)

        gvTemp.DataSource = TLotes
        gvTemp.DataBind()

    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click

        Dim eM As New MOVIMIENTOS
        Dim cM As New cMOVIMIENTOS

        eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        eM.IDTIPOTRANSACCION = TiposTransaccion.RecepcionProductos
        eM.IDMOVIMIENTO = Me.IDMOVIMIENTO

        cM.ObtenerMOVIMIENTOS(eM)

        eM.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado
        eM.FECHAMOVIMIENTO = cpFechaRecepcion.SelectedDate

        eM.EMPLEADOALMACEN = Me.txtGuardalmacen.Text

        eM.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eM.AUFECHAMODIFICACION = Now()
        eM.ESTASINCRONIZADA = 0

        cM.ActualizarMOVIMIENTOS(eM)

        Dim eRR As New RECIBOSRECEPCION
        Dim cRR As New cRECIBOSRECEPCION

        eRR.ANIO = eM.ANIO
        eRR.IDRECIBO = eM.IDDOCUMENTO
        eRR.IDALMACEN = eM.IDALMACEN

        cRR.ObtenerRECIBOSRECEPCION(eRR)

        eRR.RESPONSABLEPROVEEDOR = Me.txtDelegadoProveedor.Text
        eRR.NUMEROACTA = eRR.IDRECIBO 'cRR.ObtenerNumeroACTA(eRR.IDALMACEN, eRR.ANIO)
        eRR.OBSERVACION = Me.txtObservaciones.Text
        eRR.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eRR.AUFECHAMODIFICACION = Now()
        eRR.ESTASINCRONIZADA = 0

        cRR.ActualizarRECIBOSRECEPCION(eRR)

        Dim cDM As New cDETALLEMOVIMIENTOS
        Dim cUt As New cUTILERIAS

        Dim lista As listaDETALLEMOVIMIENTOS
        lista = cDM.ObtenerLista(eM.IDESTABLECIMIENTO, eM.IDTIPOTRANSACCION, eM.IDMOVIMIENTO)

        Dim cPD As New cPROGRAMADISTRIBUCION
        Dim cCPC As New cCONTRATOSPROCESOCOMPRA
        Dim cAE As New cALMACENESESTABLECIMIENTOS

        Dim IDPROCESOCOMPRA As Integer = cCPC.ObtenerPCporContrato(Me.IDESTABLECIMIENTO, Me.IDPROVEEDOR, Me.IDCONTRATO)
        Dim IDESTABLECIMIENTOSOLICITA As Integer = cAE.BuscarEstablecimientoAlmacenPrincipal(Me.IDALMACEN)

        For Each eDM As DETALLEMOVIMIENTOS In lista
            cUt.ActualizarCantidadDisponible(eM.IDALMACEN, eDM.IDLOTE, 0, 0)

            'Programa de distribución 
            Dim ePD As New PROGRAMADISTRIBUCION
            ePD.IDESTABLECIMIENTO = eDM.IDESTABLECIMIENTO
            ePD.IDPROCESOCOMPRA = IDPROCESOCOMPRA
            ePD.RENGLON = eDM.RENGLON
            ePD.IDESTABLECIMIENTOSOLICITA = IDESTABLECIMIENTOSOLICITA
            ePD.IDALMACEN = eDM.IDALMACEN

            cPD.ObtenerPROGRAMADISTRIBUCION2(ePD)

            ePD.CANTIDADENTREGADA = ePD.CANTIDADENTREGADA + eDM.CANTIDAD
            ePD.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            ePD.AUFECHAMODIFICACION = Now

            cPD.ActualizarCantidadEntregada(ePD)
        Next

        Me.btnAgregarLote.Enabled = False
        Me.gvTemp.Columns.Item(10).Visible = False

        Me.btnCerrar.Enabled = False
        Me.btnImprimir.Text = "Ver Acta"
        Me.btnImprimir.Enabled = True

    End Sub

    Public Sub Limpiar()

        Me.IDESTABLECIMIENTO = 0
        Me.IDPROVEEDOR = 0
        Me.IDCONTRATO = 0
        Me.IDALMACEN = 0
        Me.IDPRODUCTO = 0
        Me.IDUNIDADMEDIDA = 0

        Me.RENGLON = 0
        Me.CANTIDADARECIBIR = 0
        Me.IDDOCUMENTO = 0
        Me.PRECIO = 0

        Me.CANTIDADDECIMAL = 0

        Me.btnCerrar.Enabled = False
        Me.btnImprimir.Enabled = False

        Me.TLotes.Clear()
        If Not Me.ViewState("TLotes") Is Nothing Then Me.ViewState.Remove("TLotes")

        Me.gvLotesMuestreados.DataSource = Nothing
        Me.gvLotesMuestreados.DataBind()
        Me.gvLotesMuestreados.SelectedIndex = -1

        Me.gvTemp.DataSource = Nothing
        Me.gvTemp.DataBind()
        Me.gvTemp.SelectedIndex = -1
        Me.gvTemp.Columns.Item(10).Visible = True

    End Sub

    Protected Sub gvLotesMuestreados_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvLotesMuestreados.SelectedIndexChanged

        Me.txtLote.Text = Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("LOTE")
        Me.txtFechaVto.Text = Format(Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("FECHAVENCIMIENTO").ToString, "MM/yyyy")

        Me.txtNumeroInformeCC.Text = Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("NUMEROINFORME")
        Me.cpFechaInformeCC.SelectedDate = Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("FECHAELABORACIONINFORME")

        Me.IDESTABLECIMIENTOCC = Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("IDESTABLECIMIENTOCC")
        Me.IDINFORMECC = Me.gvLotesMuestreados.DataKeys(Me.gvLotesMuestreados.SelectedIndex).Item("IDINFORMECC")

    End Sub

    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'>window.open('" + Request.ApplicationPath + "/Reportes/FrmRptReciboRecepcion.aspx?IdEMov=" + Session.Item("IdEstablecimiento").ToString + "&IdMov=" + Me.IDMOVIMIENTO.ToString + "&IdE=" & Me.IDESTABLECIMIENTO.ToString & "&IdP=" & Me.IDPROVEEDOR.ToString & "&IdC=" & Me.IDCONTRATO.ToString & "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600'); </script>")
    End Sub

    Protected Sub DeshabilitarDobleClickBotones()
        btnAgregarLote.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnAgregarLote.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnAgregarLote, Nothing) + ";"
        btnGuardar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnGuardar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnGuardar, Nothing) + ";"
        btnCerrar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate('" + btnCerrar.ValidationGroup + "')==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnCerrar, Nothing) + ";"
    End Sub

    Public Sub CargarLotes()

        'responsable proveedor
        Dim cRR As New cRECIBOSRECEPCION
        Dim eRR As New RECIBOSRECEPCION

        eRR.IDALMACEN = Me.IDALMACEN
        eRR.ANIO = Me.ANIO
        eRR.IDRECIBO = Me.IDRECIBO
        cRR.ObtenerRECIBOSRECEPCION(eRR)

        Me.txtDelegadoProveedor.Text = eRR.RESPONSABLEPROVEEDOR

        'fecha movimiento
        Dim eM As New MOVIMIENTOS
        Dim cM As New cMOVIMIENTOS
        eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        eM.IDTIPOTRANSACCION = TiposTransaccion.RecepcionProductos
        eM.IDMOVIMIENTO = Me.IDMOVIMIENTO
        cM.ObtenerMOVIMIENTOS(eM)

        Me.cpFechaRecepcion.SelectedDate = eM.FECHAMOVIMIENTO

        'detalle
        Dim ds As Data.DataSet
        ds = cRR.RecuperarDetalleRecepcion(IDALMACEN, ANIO, IDRECIBO, TiposTransaccion.RecepcionProductos)

        TLotes.Merge(ds.Tables(0), False, Data.MissingSchemaAction.Ignore)

        If Not Me.ViewState("TLotes") Is Nothing Then Me.ViewState.Remove("TLotes")
        Me.ViewState.Add("TLotes", TLotes)

        Me.gvTemp.DataSource = TLotes
        Me.gvTemp.DataBind()

        Me.plRecepcion.Visible = False

    End Sub

    Public Sub SetFocus()
        Me.txtDocumento.Focus()
    End Sub

End Class
