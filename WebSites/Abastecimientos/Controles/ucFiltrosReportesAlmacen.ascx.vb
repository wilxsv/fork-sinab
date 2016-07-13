
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Tipos
Imports System.Activities.Statements
Imports System.Linq

Partial Class ucFiltrosReportesAlmacen
    Inherits System.Web.UI.UserControl

    Private _EstablecimientoRequerido As Boolean

    Public Event Consultar()
    Public Event SelectedIndexChanged()

#Region " Propiedades "
#Region "Gets"

    Public ReadOnly Property IDALMACEN() As Integer
        Get
            If trAlmacen.Visible Then
                Return CType(ddlALMACENES1.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDALMACENORIGEN() As Integer
        Get
            If trAlmacenOrigen.Visible Then
                Return CType(Me.ddlALMACENES2.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property FECHADESDE() As String
        Get
            If Me.trFechaDesde.Visible Then
                If cbFechas.Visible And cbFechas.Checked Then
                    Return Date.MinValue.ToShortDateString
                Else
                    Return Me.cpFechaDesde.Text
                End If
            Else
                Return Date.MinValue.ToShortDateString
            End If
        End Get
    End Property

    Public ReadOnly Property FECHAHASTA() As String
        Get
            If Me.trFechaHasta.Visible Then
                If cbFechas.Visible And cbFechas.Checked Then
                    Return Date.Now.Date.ToShortDateString
                Else
                    Return Me.cpFechaHasta.Text
                End If
            Else
                Return Date.Now.Date.ToShortDateString
            End If
        End Get
    End Property

    Public ReadOnly Property MESPERIODO() As String
        Get
            If Me.trPeriodo.Visible Then
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
            If trAnio.Visible Then
                Return nbAnio.Text
            Else
                Return Now.Year.ToString
            End If
        End Get
    End Property

    Public ReadOnly Property IDGRUPOFUENTEFINANCIAMIENTO() As Integer
        Get
            If Me.trGrupoFF.Visible Then
                Return CType(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDFUENTEFINANCIAMIENTO() As Integer
        Get
            If Me.trFuenteFinanciamiento.Visible Then
                Return CType(Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDRESPONSABLEDISTRIBUCION() As Integer
        Get
            If trResponsableDistribucion.Visible Then
                Return CType(Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDSUMINISTRO() As Integer
        Get
            If trTipoProducto.Visible Then
                Return CType(Me.ddlSUMINISTROS1.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDGRUPO() As Integer
        Get
            If trGrupo.Visible Then
                Return CType(Me.ddlGRUPOS1.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDESTABLECIMIENTO() As Integer
        Get
            If Me.trEstablecimiento.Visible Then
                Return CType(Me.ddlESTABLECIMIENTOS1.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDPROVEEDOR() As Integer
        Get
            If trProveedor.Visible Then
                Return CType(ddlPROVEEDORES1.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDESTADO() As Integer
        Get
            If trEstadoDoc.Visible Then
                Return CType(Me.ddlESTADOSMOVIMIENTOS1.SelectedValue, Integer)
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
            If Me.trFosalud.Visible Then
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
            If Me.trTransferencias.Visible Then
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
                Return CType(Me.ddlLOTES1.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property IDESPECIFICOGASTO() As Integer
        Get
            If trEspecificoG.Visible Then
                Return CType(Me.ddlESPECIFICOSGASTO1.SelectedValue, Integer)
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

    Public ReadOnly Property IDESTABLECIMIENTO2() As Integer
        Get
            If Membresia.EsUsuarioRol("Consulta Almacen I") Or Membresia.EsUsuarioRol("AlmacenFosalud") Then
                Return Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
            ElseIf Me.ddlESTABLECIMIENTOS2.Visible Then
                Return CType(Me.ddlESTABLECIMIENTOS2.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

#End Region

#Region "Visibles"

    Public WriteOnly Property VerAlmacen() As Boolean
        Set(ByVal value As Boolean)

            trAlmacen.Visible = value
        End Set

    End Property

    Public WriteOnly Property VerAlmacenOrigen() As Boolean
        Set(ByVal value As Boolean)
            trAlmacenOrigen.Visible = value
        End Set

    End Property

    Public WriteOnly Property VerFechaDesde() As Boolean
        Set(ByVal value As Boolean)
            trFechaDesde.Visible = value
            cbFechas.Visible = value
            Me.cvFechaHasta1.Visible = (value And trFechaHasta.Visible AndAlso value)
        End Set
    End Property

    Public WriteOnly Property VerFechaHasta() As Boolean
        Set(ByVal value As Boolean)
            trFechaHasta.Visible = value
            Me.cvFechaHasta1.Visible = (value And trFechaDesde.Visible AndAlso value)
            Me.cvFechaHasta2.Visible = value
        End Set
    End Property

    Public WriteOnly Property SetFechaHasta() As Date
        Set(ByVal value As Date)
            Me.cpFechaHasta.Text = value.ToShortDateString()
            If Date.Compare(value, Today) > 0 Then
                cvFechaHasta2.Operator = ValidationCompareOperator.GreaterThanEqual
                cvFechaHasta2.ErrorMessage = "La fecha hasta no puede ser anterior a hoy."
            End If
        End Set
    End Property

    Public WriteOnly Property VerPeriodo() As Boolean
        Set(ByVal value As Boolean)
            trPeriodo.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerAnio() As Boolean
        Set(ByVal value As Boolean)
            trAnio.Visible = value
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
            trGrupoFF.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerFuenteFinanciamiento() As Boolean
        Set(ByVal value As Boolean)
            trFuenteFinanciamiento.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerResponsableDistribucion() As Boolean
        Set(ByVal value As Boolean)
            trResponsableDistribucion.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerProveedor() As Boolean
        Set(ByVal value As Boolean)
            trProveedor.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerEstablecimiento() As Boolean
        Set(ByVal value As Boolean)
            trEstablecimiento.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerTipoSuministro() As Boolean
        Set(ByVal value As Boolean)
            trTipoProducto.Visible = value
            Me.ddlSUMINISTROS1.AutoPostBack = False
        End Set
    End Property

    Public WriteOnly Property VerGrupo() As Boolean
        Set(ByVal value As Boolean)
            trGrupo.Visible = value
            Me.ddlSUMINISTROS1.AutoPostBack = True
        End Set
    End Property

    Public WriteOnly Property VerEstadoDocumento() As Boolean
        Set(ByVal value As Boolean)
            trEstadoDoc.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerDocumento() As String
        Set(ByVal value As String)
            Dim visible As Boolean = (value <> String.Empty)
            Me.lblDocumento.Visible = visible
            Me.nbDocumento.Visible = visible
            Me.rfvDocumento.Visible = visible

            If visible Then
                Me.lblDocumento.Text = value + ":"

                If rblBuscarPor.Items.Count = 1 Then
                    Dim itm As New ListItem
                    itm.Text = value
                    itm.Value = "2"
                    itm.Selected = False

                    Me.rblBuscarPor.Items.Add(itm)
                End If
            End If

            'Me.lblBuscarPor.Visible = visible
            'Me.rblBuscarPor.Visible = visible
            trBuscarPor.Visible = visible
        End Set
    End Property

    Public WriteOnly Property VerProducto() As Boolean
        Set(ByVal value As Boolean)

            Me.txtProducto.Visible = value
            Me.rfvProducto.Visible = value
            trProducto.Visible = value

            Me.ddlLOTES1.Visible = Not value
        End Set
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
            trEspecificoG.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerTransferencia() As Boolean
        Set(ByVal value As Boolean)
            trTransferencias.Visible = value
        End Set
    End Property

    Public WriteOnly Property VerAgruparPor() As Boolean
        Set(ByVal value As Boolean)
            trAgrupar.Visible = value
        End Set
    End Property

#End Region

    Public Property EstablecimientoRequerido() As Boolean
        Get
            Return _EstablecimientoRequerido
        End Get
        Set(ByVal value As Boolean)
            _EstablecimientoRequerido = value
        End Set
    End Property

    Public ReadOnly Property AgruparPor() As Integer
        Get
            If trAgrupar.Visible Then
                Return CType(Me.ddlAgruparPor.SelectedValue, Integer)
            Else
                Return 0
            End If
        End Get
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

    Public Property UrlRegresar() As String
        Get
            Return lnkBack.NavigateUrl
        End Get
        Set(value As String)
            lnkBack.NavigateUrl = value
        End Set
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

#End Region

    Dim item As ListItem

    Public Sub IniciarDatos()
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        If String.IsNullOrEmpty(lnkBack.NavigateUrl) Then
            lnkBack.NavigateUrl = ResolveUrl("~/Almacen/FrmReportesAlmacenes.aspx")
        End If

            Dim usr = Membresia.ObtenerUsuario()
            Dim enrol = False
            If trFechaDesde.Visible Then cpFechaDesde.Text = (Now.Date.AddDays(-30)).ToShortDateString()
            If trFechaHasta.Visible And String.IsNullOrEmpty(cpFechaHasta.Text) Then cpFechaHasta.Text = Now.ToShortDateString()
            If Me.cvFechaHasta2.Visible Then Me.cvFechaHasta2.ValueToCompare = CType(Now.Date, String)

            If Me.trPeriodo.Visible Then

                For i As Integer = 1 To 12
                    item = New ListItem(MonthName(i).ToUpper, i)
                    item.Selected = False

                    Me.ddlMesPeriodo.Items.Add(item)
                Next

                If Now.Month = 1 Then
                    Me.ddlMesPeriodo.SelectedValue = 12
                    Me.nbAnioPeriodo.Text = (Now.Year - 1).ToString
                Else
                    Me.ddlMesPeriodo.SelectedValue = CType((Now.Month - 1), String)
                    Me.nbAnioPeriodo.Text = Now.Year.ToString
                End If

            End If

            item = New ListItem("(Todos)", 0)

            Me.nbAnio.Text = Now.Year.ToString


            If Me.ddlESTABLECIMIENTOS2.Visible Then

                If Membresia.EsUsuarioRol("Consulta Almacen I") Or Membresia.EsUsuarioRol("AlmacenFosalud") Then
                    enrol = True
                    ddlESTABLECIMIENTOS2.Visible = False
                    ltEstablecimiento.Text = usr.ESTABLECIMIENTO.NOMBRE
                    ltEstablecimiento.Visible = True
                Else
                    enrol = False
                    Establecimientos.CargarHospitalesYRegionesALista(ddlESTABLECIMIENTOS2)
                    Me.ddlALMACENES1.Items.Insert(0, item)
                End If

                'Me.ddlESTABLECIMIENTOS2.RecuperarEstablecimientos()

            End If

            If trAlmacen.Visible Then
                If enrol Then
                    Me.ddlALMACENES1.RecuperarListaAlmacenEstablecimiento(usr.ESTABLECIMIENTO.IDESTABLECIMIENTO)
                Else
                    Me.ddlALMACENES1.RecuperarListaAlmacenEstablecimiento(CType(ddlESTABLECIMIENTOS2.SelectedValue, Integer))
                End If
                Me.ddlALMACENES1.Items.Insert(0, item)
            End If

            If trAlmacenOrigen.Visible Then
                Me.ddlALMACENES2.RecuperarListaOrdenada(1)
                Me.ddlALMACENES2.Items.Insert(0, item)
            End If

            If trEstablecimiento.Visible Then
                ' Me.cbVerTodos.Visible = True

                If usr.ESTABLECIMIENTO.IDTIPOESTABLECIMIENTO = 3 Or usr.ESTABLECIMIENTO.IDTIPOESTABLECIMIENTO = 8 Then
                Me.ddlESTABLECIMIENTOS1.RecuperarLugarEntregaHospital(usr.Almacen.IDALMACEN, IIf(Me.cbVerTodos.Checked, 1, 0))
                Else
                    Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
                End If

                If Not _EstablecimientoRequerido Then
                    Me.ddlESTABLECIMIENTOS1.Items.Insert(0, item)
                End If
            Else
                'Me.cbVerTodos.Visible = False
            End If

            If trProveedor.Visible Then
                Me.ddlPROVEEDORES1.RecuperarListaNombreOrdenada(1)
                Me.ddlPROVEEDORES1.Items.Insert(0, item)
            End If

            If Me.trGrupoFF.Visible Then

                If _a <> 1 Then
                    Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Items.Insert(0, item)
                Else
                    trFosalud.Visible = False
                    Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.AutoPostBack = False
                End If

                Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Recuperar()

                If usr.ESTABLECIMIENTO.IDESTABLECIMIENTO = 620 Then
                    ' If _b = 1 Then
                    'Dim item2 As ListItem = New ListItem("FOSALUD", 3)
                    'If _a <> 1 Then
                    '    Me.lblFOSALUD.Visible = True
                    '    Me.cbFOSALUD.Visible = True
                    'Else
                    'trFosalud.Visible = False

                    'End Iflol
                    'Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Items.Add(item2)
                    '  Else
                    trFosalud.Visible = False
                    ' End If

                End If

            End If

            If Me.trFuenteFinanciamiento.Visible Then
                With ddlFUENTEFINANCIAMIENTOS1
                    .RecuperarPorGrupo(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue)
                    .Enabled = False
                    .Items.Insert(0, item)
                End With

            End If

            If Me.trResponsableDistribucion.Visible Then
                Me.ddlRESPONSABLEDISTRIBUCION1.Recuperar()
                Me.ddlRESPONSABLEDISTRIBUCION1.Items.Insert(0, item)
            End If

            If trEstadoDoc.Visible Then
                Me.ddlESTADOSMOVIMIENTOS1.Recuperar()
                Me.ddlESTADOSMOVIMIENTOS1.Items.Insert(0, item)
            End If

            If trTipoProducto.Visible Then
                Me.ddlSUMINISTROS1.RecuperarOrdenadaPorCorrelativo()

                If Me.TipoSuministroTodos Then
                    Me.ddlSUMINISTROS1.Items.Insert(0, item)
                End If

                If trGrupo.Visible Then
                    Me.ddlGRUPOS1.RecuperarListaFiltrada(CType(Me.ddlSUMINISTROS1.SelectedValue, Integer))
                    Me.ddlGRUPOS1.Items.Insert(0, item)
                End If
            End If

        If Me.txtProducto.Visible Then
            Try
                Me.ddlLOTES1.RecuperarProductosAlmacen(usr.Almacen.IDALMACEN)
            Catch ex As Exception
                'todo: que lotes debe seleccionar?
            End Try

        End If

            If trAgrupar.Visible Then
                Me.ddlAgruparPor.Items.Add(New ListItem(eAGRUPAR.Fecha.ToString, eAGRUPAR.Fecha))
                Me.ddlAgruparPor.Items.Add(New ListItem(eAGRUPAR.Grupo.ToString, eAGRUPAR.Grupo))
                Me.ddlAgruparPor.Items.Add(New ListItem(eAGRUPAR.Producto.ToString, eAGRUPAR.Producto))
            End If

            If trEspecificoG.Visible Then
                Me.ddlESPECIFICOSGASTO1.RecuperarEspecificos()
                Me.ddlESPECIFICOSGASTO1.Items.Insert(0, item)
            End If

            If ddlESTABLECIMIENTOS2.Visible Or trAlmacen.Visible Then
                tblFiltros.Visible = True
            Else
                tblFiltros.Visible = False
            End If
        'End If

    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        RaiseEvent Consultar()
    End Sub

    Protected Sub rblBuscarPor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblBuscarPor.SelectedIndexChanged

        Me.txtProducto.Text = String.Empty
        Me.nbDocumento.Text = String.Empty

        If rblBuscarPor.SelectedValue = 1 Then
            Me.tblCriterio.Visible = True
            tblFiltros.Visible = True
            Me.plDocumento.Visible = False
        Else
            If Membresia.EsUsuarioRol("AdministracionAlmacenes") Then
                tblCriterio.Visible = False
                tblFiltros.Visible = True
            Else
                Me.tblCriterio.Visible = False
                tblFiltros.Visible = False
            End If

            Me.plDocumento.Visible = True
        End If

        RaiseEvent SelectedIndexChanged()

    End Sub

    Protected Sub lbSeleccionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSeleccionar.Click
        If Me.txtProducto.Visible Then
            Me.txtProducto.Visible = False
            Me.rfvProducto.Visible = False
            Me.ddlLOTES1.Visible = True
            Me.ddlLOTES1.RecuperarProductosAlmacen(Membresia.ObtenerUsuario().Almacen.IDALMACEN)
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
        Me.ddlGRUPOS1.RecuperarListaFiltrada(CType(Me.ddlSUMINISTROS1.SelectedValue, Integer))
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
            With ddlFUENTEFINANCIAMIENTOS1
                .Enabled = True
                .Items.Clear()
                'Me.CheckBox1.Enabled = True
                item = New ListItem("(Todos)", 0)
                'item.Selected = True

                .Items.Insert(0, item)
                .RecuperarPorGrupo(CType(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue, Integer))
                .SelectedIndex = 0
            End With

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
            Me.ddlALMACENES1.RecuperarListaAlmacenEstablecimiento(CType(Me.ddlESTABLECIMIENTOS2.SelectedValue, Integer))
            Try
                Me.ddlALMACENES1.SelectedIndex = 0
            Catch ex As Exception
                'todo:que hacer
            End Try

        End If

    End Sub

    Protected Sub cbVerTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVerTodos.CheckedChanged
        If cbVerTodos.Checked Then
            Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
        Else
            Dim usr = Membresia.ObtenerUsuario()
            If usr.ESTABLECIMIENTO.IDTIPOESTABLECIMIENTO = 3 Or usr.ESTABLECIMIENTO.IDTIPOESTABLECIMIENTO = 8 Then
                Me.ddlESTABLECIMIENTOS1.RecuperarLugarEntregaHospital(usr.Almacen.IDALMACEN, IIf(Me.cbVerTodos.Checked, 1, 0))
                item = New ListItem("(Todos)", 0)
                Me.ddlESTABLECIMIENTOS1.Items.Insert(0, item)
                ddlESTABLECIMIENTOS1.SelectedIndex = 0
            Else
                Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
            End If
        End If
    End Sub


End Class
