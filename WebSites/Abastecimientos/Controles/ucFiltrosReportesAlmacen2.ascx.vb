
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers

Partial Class ucFiltrosReportesAlmacen2
    Inherits System.Web.UI.UserControl

    Private _EstablecimientoRequerido As Boolean

    Public Event Consultar()
    Public Event SelectedIndexChanged()

#Region " Propiedades "

    Public ReadOnly Property IDALMACEN() As Integer
        Get
            If Me.ddlALMACENES1.Visible Then
                Return Me.ddlALMACENES1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property IDPROGRAMA() As Integer
        Get
            If Me.DropDownList1.Visible Then
                Return Me.DropDownList1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property
    Public ReadOnly Property IDALMACENORIGEN() As Integer
        Get
            If Me.ddlALMACENES2.Visible Then
                Return Me.ddlALMACENES2.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property FECHADESDE() As String
        Get
            If Me.cpFechaDesde.Visible Then
                If cbFechas.Visible And cbFechas.Checked Then
                    Return Date.MinValue.ToShortDateString
                Else
                    Return Me.cpFechaDesde.SelectedDate.ToShortDateString
                End If
            Else
                Return Date.MinValue.ToShortDateString
            End If
        End Get
    End Property

    Public ReadOnly Property FECHAHASTA() As String
        Get
            If Me.cpFechaHasta.Visible Then
                If cbFechas.Visible And cbFechas.Checked Then
                    Return Date.Now.Date.ToShortDateString
                Else
                    Return Me.cpFechaHasta.SelectedDate.ToShortDateString
                End If
            Else
                Return Date.Now.Date.ToShortDateString
            End If
        End Get
    End Property

    Public ReadOnly Property MESPERIODO() As String
        Get
            If Me.ddlMesPeriodo.Visible Then
                Return Me.ddlMesPeriodo.SelectedValue
            Else
                Return Now.Month.ToString
            End If
        End Get
    End Property

    Public ReadOnly Property ANIOPERIODO() As String
        Get
            If Me.nbAnioPeriodo.Visible Then
                Return Me.nbAnioPeriodo.Text
            Else
                Return Now.Year.ToString
            End If
        End Get
    End Property

    Public ReadOnly Property ANIO() As String
        Get
            If Me.nbAnio.Visible Then
                Return Me.nbAnio.Text
            Else
                Return Now.Year.ToString
            End If
        End Get
    End Property

    Public ReadOnly Property IDGRUPOFUENTEFINANCIAMIENTO() As Integer
        Get
            If Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Visible Then
                Return Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDFUENTEFINANCIAMIENTO() As Integer
        Get
            If Me.ddlFUENTEFINANCIAMIENTOS1.Visible Then
                Return Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDRESPONSABLEDISTRIBUCION() As Integer
        Get
            If Me.ddlRESPONSABLEDISTRIBUCION1.Visible Then
                Return Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDSUMINISTRO() As Integer
        Get
            If Me.ddlSUMINISTROS1.Visible Then
                Return Me.ddlSUMINISTROS1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDGRUPO() As Integer
        Get
            If Me.ddlGRUPOS1.Visible Then
                Return Me.ddlGRUPOS1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDESTABLECIMIENTO() As Integer
        Get
            If Me.ddlESTABLECIMIENTOS1.Visible Then
                Return Me.ddlESTABLECIMIENTOS1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDPROVEEDOR() As Integer
        Get
            If Me.ddlPROVEEDORES1.Visible Then
                Return Me.ddlPROVEEDORES1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDESTADO() As Integer
        Get
            If Me.ddlESTADOSMOVIMIENTOS1.Visible Then
                Return Me.ddlESTADOSMOVIMIENTOS1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property PRODUCTO() As String
        Get
            If Me.txtProducto.Visible Then
                Return Me.txtProducto.Text
            Else
                Return "0"
            End If
        End Get
    End Property

    Public ReadOnly Property FOS() As Integer
        Get
            If Me.cbFOSALUD.Visible Then
                If Me.cbFOSALUD.Checked Then
                    Return 1
                Else
                    Return 0
                End If
            Else
                Return -1
            End If
        End Get
    End Property
    Public ReadOnly Property Transf() As Integer
        Get
            If Me.CheckBox1.Visible Then
                If Me.CheckBox1.Checked Then
                    Return 1
                Else
                    Return 0
                End If
            Else
                Return -1
            End If
        End Get
    End Property
    Public ReadOnly Property IDPRODUCTO() As Integer
        Get
            If Me.ddlLOTES1.Visible Then
                Return Me.ddlLOTES1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDESPECIFICOGASTO() As Integer
        Get
            If Me.ddlESPECIFICOSGASTO1.Visible Then
                Return Me.ddlESPECIFICOSGASTO1.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property Documento() As String
        Get
            If Me.nbDocumento.Visible Then
                Return Me.nbDocumento.Text
            Else
                Return "0"
            End If
        End Get
    End Property

    Private _a As Integer = 0
    Public WriteOnly Property a() As Integer
        Set(ByVal value As Integer)
            _a = value
        End Set
    End Property

    Private _b As Integer = 0
    Public WriteOnly Property b() As Integer
        Set(ByVal value As Integer)
            _b = value
        End Set
    End Property

    Public WriteOnly Property VerAlmacen() As Boolean
        Set(ByVal value As Boolean)
            Me.lblAlmacen.Visible = value
            Me.ddlALMACENES1.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerAlmacenOrigen() As Boolean
        Set(ByVal value As Boolean)
            Me.lblAlmacenOrigen.Visible = value
            Me.ddlALMACENES2.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerFechaDesde() As Boolean
        Set(ByVal value As Boolean)
            Me.lblFechaDesde.Visible = value
            Me.cpFechaDesde.Visible = value
            Me.cvFechaHasta1.Visible = IIf(value And cpFechaHasta.Visible, value, False)
        End Set
    End Property

    Public WriteOnly Property VerFechaHasta() As Boolean
        Set(ByVal value As Boolean)
            Me.lblFechaHasta.Visible = value
            Me.cpFechaHasta.Visible = value
            Me.cvFechaHasta1.Visible = IIf(value And cpFechaDesde.Visible, value, False)
            Me.cvFechaHasta2.Visible = value
        End Set
    End Property

    Public WriteOnly Property SetFechaHasta() As Date
        Set(ByVal value As Date)
            Me.cpFechaHasta.SelectedDate = value
            If Date.Compare(value, Today) > 0 Then
                cvFechaHasta2.Operator = ValidationCompareOperator.GreaterThanEqual
                cvFechaHasta2.ErrorMessage = "La fecha hasta no puede ser anterior a hoy."
            End If
        End Set
    End Property

    Public WriteOnly Property VerPeriodo() As Boolean
        Set(ByVal value As Boolean)
            Me.lblPeriodo.Visible = value
            Me.ddlMesPeriodo.Visible = value
            Me.nbAnioPeriodo.Visible = value
            Me.rfvAnioPeriodo.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerAnio() As Boolean
        Set(ByVal value As Boolean)
            Me.lblAnio.Visible = value
            Me.nbAnio.Visible = value
            Me.rfvAnio.Visible = value
        End Set
    End Property

    Public WriteOnly Property FechasRequeridas() As Boolean
        Set(ByVal value As Boolean)
            Me.cbFechas.Visible = Not value
            Me.cbFechas.Checked = Not value
        End Set
    End Property

    Public WriteOnly Property VerGrupoFuenteFinanciamiento() As Boolean
        Set(ByVal value As Boolean)
            Me.lblGrupoFuenteFinanciamiento.Visible = value
            Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerFuenteFinanciamiento() As Boolean
        Set(ByVal value As Boolean)
            Me.lblFuenteFinanciamiento.Visible = value
            Me.ddlFUENTEFINANCIAMIENTOS1.Visible = value
        End Set
    End Property
    Public WriteOnly Property VerPrograma() As Boolean
        Set(ByVal value As Boolean)
            Me.Label2.Visible = value
            Me.DropDownList1.Visible = value
        End Set
    End Property
    Public WriteOnly Property VerResponsableDistribucion() As Boolean
        Set(ByVal value As Boolean)
            Me.lblResponsableDistribucion.Visible = value
            Me.ddlRESPONSABLEDISTRIBUCION1.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerProveedor() As Boolean
        Set(ByVal value As Boolean)
            Me.lblProveedor.Visible = value
            Me.ddlPROVEEDORES1.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerEstablecimiento() As Boolean
        Set(ByVal value As Boolean)
            Me.lblEstablecimiento.Visible = value
            Me.ddlESTABLECIMIENTOS1.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerTipoSuministro() As Boolean
        Set(ByVal value As Boolean)
            Me.lblTipoProducto.Visible = value
            Me.ddlSUMINISTROS1.Visible = value
            Me.ddlSUMINISTROS1.AutoPostBack = False
        End Set
    End Property

    Public WriteOnly Property VerGrupo() As Boolean
        Set(ByVal value As Boolean)
            Me.lblGrupo.Visible = value
            Me.ddlGRUPOS1.Visible = value
            Me.ddlSUMINISTROS1.AutoPostBack = True
        End Set
    End Property

    Public WriteOnly Property VerEstadoDocumento() As Boolean
        Set(ByVal value As Boolean)
            Me.lblEstadoDocumento.Visible = value
            Me.ddlESTADOSMOVIMIENTOS1.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerDocumento() As String
        Set(ByVal value As String)
            Dim visible As Boolean = IIf(value = String.Empty, False, True)
            Me.lblDocumento.Visible = visible
            Me.nbDocumento.Visible = visible
            Me.rfvDocumento.Visible = visible

            If visible Then
                Me.lblDocumento.Text = value + ":"

                If rblBuscarPor.Items.Count = 1 Then
                    Dim item As New ListItem
                    item.Text = value
                    item.Value = "2"
                    item.Selected = False

                    Me.rblBuscarPor.Items.Add(item)
                End If
            End If

            Me.lblBuscarPor.Visible = visible
            Me.rblBuscarPor.Visible = visible
        End Set
    End Property

    Public WriteOnly Property VerProducto() As Boolean
        Set(ByVal value As Boolean)
            Me.lblProducto.Visible = value
            Me.txtProducto.Visible = value
            Me.rfvProducto.Visible = value
            Me.lbSeleccionar.Visible = value

            Me.ddlLOTES1.Visible = Not value
        End Set
    End Property

    Public Property EstablecimientoRequerido() As Boolean
        Get
            Return _EstablecimientoRequerido
        End Get
        Set(ByVal value As Boolean)
            _EstablecimientoRequerido = value
        End Set
    End Property

    Public WriteOnly Property VerAgruparPor() As Boolean
        Set(ByVal value As Boolean)
            Me.lblAgruparPor.Visible = value
            Me.ddlAgruparPor.Visible = value
        End Set
    End Property

    Public ReadOnly Property AgruparPor() As Integer
        Get
            If Me.ddlAgruparPor.Visible Then
                Return Me.ddlAgruparPor.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDESTABLECIMIENTO2() As Integer
        Get
            If Me.ddlESTABLECIMIENTOS2.Visible Then
                Return Me.ddlESTABLECIMIENTOS2.SelectedValue
            Else
                Return 0
            End If
        End Get
    End Property

    Public WriteOnly Property VerEstablecimientoTodos() As Boolean
        Set(ByVal value As Boolean)
            Me.lblEstablecimiento2.Visible = value
            Me.ddlESTABLECIMIENTOS2.Visible = value
            Me.ddlESTABLECIMIENTOS2.AutoPostBack = True
        End Set
    End Property

    Public WriteOnly Property VerEspecificoGasto() As Boolean
        Set(ByVal value As Boolean)
            Me.lblEspecificoGasto.Visible = value
            Me.ddlESPECIFICOSGASTO1.Visible = value
        End Set
    End Property
    Public WriteOnly Property VerTransferencia() As Boolean
        Set(ByVal value As Boolean)
            Me.Label1.Visible = value
            Me.CheckBox1.Visible = value
        End Set
    End Property
    Private _TipoSuministroTodos As Boolean
    Public Property TipoSuministroTodos() As Boolean
        Get
            Return _TipoSuministroTodos
        End Get
        Set(ByVal value As Boolean)
            _TipoSuministroTodos = value
        End Set
    End Property

#End Region

    Dim item As ListItem

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim usr = Membresia.ObtenerUsuario()
            Dim enrol = False
            If Me.cpFechaDesde.Visible Then cpFechaDesde.SelectedDate = Now.Date.AddDays(-30)

            If Me.cvFechaHasta2.Visible Then Me.cvFechaHasta2.ValueToCompare = Now.Date

            If Me.ddlMesPeriodo.Visible Then

                For i As Integer = 1 To 12
                    item = New ListItem(MonthName(i).ToUpper, i)
                    item.Selected = False

                    Me.ddlMesPeriodo.Items.Add(item)
                Next

                If Now.Month = 1 Then
                    Me.ddlMesPeriodo.SelectedValue = 12
                    Me.nbAnioPeriodo.Text = (Now.Year - 1).ToString
                Else
                    Me.ddlMesPeriodo.SelectedValue = Now.Month - 1
                    Me.nbAnioPeriodo.Text = Now.Year.ToString
                End If

            End If

            item = New ListItem("(Todos)", 0)

            Me.nbAnio.Text = Now.Year.ToString

            'If Me.DropDownList1.Visible Then
            '    Dim cE As New ABASTECIMIENTOS.NEGOCIO.cESTABLECIMIENTOS
            '    Me.DropDownList1.Items.Add(item)
            '    If Session("IdEstablecimiento") = 619 Then
            '    Me.DropDownList1.DataSource = cE.RecuperarEstablecimientos
            '    Me.DropDownList1.DataTextField = "NOMBRE"
            '    Me.DropDownList1.DataValueField = "IDESTABLECIMIENTO"
            '    Me.DropDownList1.DataBind()
            '    Else
            '        Me.lblEstablecimiento.Visible = True
            '        Me.ddlESTABLECIMIENTOS1.Visible = True
            '        Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
            '        If Not _EstablecimientoRequerido Then
            '            Me.ddlESTABLECIMIENTOS1.Items.Insert(0, item)
            '        End If
            'End If
            'End If

            If Me.ddlESTABLECIMIENTOS2.Visible Then
                If Membresia.EsUsuarioRol("Consulta Almacen I") Then
                    enrol = True
                    ddlESTABLECIMIENTOS2.Visible = False
                    ltEstablecimiento.Text = usr.ESTABLECIMIENTO.NOMBRE
                    ltEstablecimiento.Visible = True
                Else
                    enrol = False
                    Establecimientos.CargarHospitalesYRegionesALista(ddlESTABLECIMIENTOS2)
                    Me.ddlALMACENES1.Items.Insert(0, item)
                End If
            End If

            If Me.ddlALMACENES1.Visible Then
                If enrol Then
                    Me.ddlALMACENES1.RecuperarListaAlmacenEstablecimiento(usr.ESTABLECIMIENTO.IDESTABLECIMIENTO)
                Else
                    Me.ddlALMACENES1.RecuperarListaAlmacenEstablecimiento(ddlESTABLECIMIENTOS2.SelectedValue)
                End If
                Me.ddlALMACENES1.Items.Insert(0, item)
            End If

            If Me.ddlALMACENES2.Visible Then
                Me.ddlALMACENES2.RecuperarListaOrdenada(1)
                Me.ddlALMACENES2.Items.Insert(0, item)
            End If

            If Me.ddlESTABLECIMIENTOS1.Visible Then
                Me.cbVerTodos.Visible = True

                If Session.Item("idTipoEstablecimiento") = 3 Or Session.Item("idTipoEstablecimiento") = 8 Then
                    Me.ddlESTABLECIMIENTOS1.RecuperarLugarEntregaHospital(Session.Item("IdAlmacen"), IIf(Me.cbVerTodos.Checked, 1, 0))
                Else
                    Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
                End If

                If Not _EstablecimientoRequerido Then
                    Me.ddlESTABLECIMIENTOS1.Items.Insert(0, item)
                End If
            Else
                Me.cbVerTodos.Visible = False
            End If

            If Me.ddlPROVEEDORES1.Visible Then
                Me.ddlPROVEEDORES1.RecuperarListaNombreOrdenada(1)
                Me.ddlPROVEEDORES1.Items.Insert(0, item)
            End If

            If Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Visible Then

                If _a <> 1 Then
                    Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Items.Insert(0, item)
                Else
                    Me.lblFOSALUD.Visible = False
                    Me.cbFOSALUD.Visible = False
                    Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.AutoPostBack = False
                End If

                Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Recuperar()

                If Session("Idestablecimiento") = 620 Then
                    If _b = 1 Then
                        Dim item2 As ListItem = New ListItem("FOSALUD", 3)
                        If _a <> 1 Then
                            Me.lblFOSALUD.Visible = True
                            Me.cbFOSALUD.Visible = True
                        Else
                            Me.lblFOSALUD.Visible = False
                            Me.cbFOSALUD.Visible = False

                        End If
                        Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Items.Add(item2)
                    Else
                        Me.lblFOSALUD.Visible = False
                        Me.cbFOSALUD.Visible = False
                    End If

                End If

            End If

            If Me.ddlFUENTEFINANCIAMIENTOS1.Visible Then
                Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue)
                Me.ddlFUENTEFINANCIAMIENTOS1.Enabled = False
                Me.ddlFUENTEFINANCIAMIENTOS1.Items.Insert(0, item)
            End If

            If Me.ddlRESPONSABLEDISTRIBUCION1.Visible Then
                Me.ddlRESPONSABLEDISTRIBUCION1.Recuperar()
                Me.ddlRESPONSABLEDISTRIBUCION1.Items.Insert(0, item)
            End If

            If Me.ddlESTADOSMOVIMIENTOS1.Visible Then
                Me.ddlESTADOSMOVIMIENTOS1.Recuperar()
                Me.ddlESTADOSMOVIMIENTOS1.Items.Insert(0, item)
            End If

            If Me.ddlSUMINISTROS1.Visible Then
                Me.ddlSUMINISTROS1.RecuperarOrdenadaPorCorrelativo()

                If Me.TipoSuministroTodos Then
                    Me.ddlSUMINISTROS1.Items.Insert(0, item)
                End If

                If Me.ddlGRUPOS1.Visible Then
                    Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
                    Me.ddlGRUPOS1.Items.Insert(0, item)
                End If
            End If

            If Me.txtProducto.Visible Then
                Dim IDALMACEN As Integer = Session.Item("IdAlmacen")
                Me.ddlLOTES1.RecuperarProductosAlmacen(IDALMACEN)
            End If

            If Me.ddlAgruparPor.Visible Then
                Me.ddlAgruparPor.Items.Add(New ListItem(eAGRUPAR.Fecha.ToString, eAGRUPAR.Fecha))
                Me.ddlAgruparPor.Items.Add(New ListItem(eAGRUPAR.Grupo.ToString, eAGRUPAR.Grupo))
                Me.ddlAgruparPor.Items.Add(New ListItem(eAGRUPAR.Producto.ToString, eAGRUPAR.Producto))
            End If

            If Me.ddlESPECIFICOSGASTO1.Visible Then
                Me.ddlESPECIFICOSGASTO1.RecuperarEspecificos()
                Me.ddlESPECIFICOSGASTO1.Items.Insert(0, item)
            End If


            If Me.DropDownList1.Visible Then
                Dim bEntidad2 As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMAS
                Me.DropDownList1.DataSource = bEntidad2.ObtenerPROGRAMAS
                Me.DropDownList1.DataValueField = "idPrograma"
                Me.DropDownList1.DataTextField = "NOMBRE"

                Me.DropDownList1.DataBind()

                Dim item As New ListItem("(Todos)", 0)
                Me.DropDownList1.Items.Insert(0, item)

                Me.DropDownList1.SelectedIndex = 0
            End If
        End If

    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        RaiseEvent Consultar()
    End Sub

    Protected Sub rblBuscarPor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblBuscarPor.SelectedIndexChanged

        Me.txtProducto.Text = String.Empty
        Me.nbDocumento.Text = String.Empty

        If rblBuscarPor.SelectedValue = 1 Then
            Me.plCriterio.Visible = True
            Me.plDocumento.Visible = False
        Else
            Me.plCriterio.Visible = False
            Me.plDocumento.Visible = True
        End If

        RaiseEvent SelectedIndexChanged()

    End Sub

    Protected Sub lbSeleccionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSeleccionar.Click
        If Me.txtProducto.Visible Then
            Me.txtProducto.Visible = False
            Me.rfvProducto.Visible = False
            Me.ddlLOTES1.Visible = True
            Me.lbSeleccionar.Text = "Digitar el código de producto..."
        Else
            Me.txtProducto.Text = String.Empty
            Me.txtProducto.Visible = True
            Me.rfvProducto.Visible = True
            Me.ddlLOTES1.Visible = False
            Me.lbSeleccionar.Text = "Seleccionar de una lista..."
        End If
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        item = New ListItem("(Todos)", 0)
        item.Selected = True
        Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
        Me.ddlGRUPOS1.Items.Insert(0, item)
    End Sub

    'Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
    '    item = New ListItem("(Todos)", 0)
    '    item.Selected = True
    '    Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.RadioButtonList1.SelectedValue)
    '    Me.ddlFUENTEFINANCIAMIENTOS1.Items.Insert(0, item)
    'End Sub

    Protected Sub ddlGRUPOSFUENTEFINANCIAMIENTO1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedIndexChanged

        If Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue = 0 Or Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue = 3 Then
            Me.ddlFUENTEFINANCIAMIENTOS1.Enabled = False
            'Me.CheckBox1.Enabled = False
        Else
            Me.ddlFUENTEFINANCIAMIENTOS1.Enabled = True
            Me.ddlFUENTEFINANCIAMIENTOS1.Items.Clear()
            'Me.CheckBox1.Enabled = True
            item = New ListItem("(Todos)", 0)
            'item.Selected = True

            Me.ddlFUENTEFINANCIAMIENTOS1.Items.Insert(0, item)
            Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue)
            Me.ddlFUENTEFINANCIAMIENTOS1.SelectedIndex = 0
        End If

    End Sub

    Protected Sub ddlESTABLECIMIENTOS2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlESTABLECIMIENTOS2.SelectedIndexChanged

        If Me.ddlESTABLECIMIENTOS2.SelectedValue = 0 Then
            Me.ddlALMACENES1.Enabled = False
            item = New ListItem("(Todos)", 0)
            Me.ddlALMACENES1.Items.Insert(0, item)
            Me.ddlALMACENES1.SelectedIndex = 0
        Else
            Me.ddlALMACENES1.Enabled = True
            Me.ddlALMACENES1.Items.Clear()
            Me.ddlALMACENES1.RecuperarListaAlmacenEstablecimiento(Me.ddlESTABLECIMIENTOS2.SelectedValue)
            Me.ddlALMACENES1.SelectedIndex = 0
        End If

    End Sub

    Protected Sub cbVerTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodos.CheckedChanged
        If cbVerTodos.Checked Then
            Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
        Else
            If Session.Item("idTipoEstablecimiento") = 3 Or Session.Item("idTipoEstablecimiento") = 8 Then
                Me.ddlESTABLECIMIENTOS1.RecuperarLugarEntregaHospital(Session.Item("IdAlmacen"), IIf(Me.cbVerTodos.Checked, 1, 0))
                item = New ListItem("(Todos)", 0)
                Me.ddlESTABLECIMIENTOS1.Items.Insert(0, item)
                ddlESTABLECIMIENTOS1.SelectedIndex = 0
            Else
                Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
            End If
        End If
    End Sub

End Class
