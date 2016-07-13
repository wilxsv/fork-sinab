Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class Controles_ucDetCreaPlantillaContratoLG
    Inherits System.Web.UI.UserControl

    Private _IDPLANTILLA, _NoClausula, _NoC As Integer
    Private _j As Integer = 0
    Private _valorActual As Integer = 0
    Private _tipoModificativa As Integer = 0
    Private _clausulasGuardadas As Integer = 0

    Private mComponente As New cCLAUSULASPLANTILLA

#Region " Propiedades "

    Public Property IDPLANTILLA() As Integer
        Get
            Return _IDPLANTILLA
        End Get
        Set(ByVal value As Integer)
            _IDPLANTILLA = value
            If Not Me.ViewState("IDPLANTILLA") Is Nothing Then Me.ViewState.Remove("IDPLANTILLA")
            Me.ViewState.Add("IDPLANTILLA", value)
        End Set
    End Property

    Public Property NoClausula() As Integer
        Get
            Return _NoClausula
        End Get
        Set(ByVal value As Integer)
            _NoClausula = value
            If Not Me.ViewState("NoClausula") Is Nothing Then Me.ViewState.Remove("NoClausula")
            Me.ViewState.Add("NoClausula", value)

        End Set
    End Property

    Public Property NoC() As Integer
        Get
            Return _NoC
        End Get
        Set(ByVal value As Integer)
            _NoC = value
            If Not Me.ViewState("NoC") Is Nothing Then Me.ViewState.Remove("NoC")
            Me.ViewState.Add("NoC", value)
        End Set
    End Property

    Public Property j() As Integer
        Get
            Return _j
        End Get
        Set(ByVal value As Integer)
            _j = value
            If Not Me.ViewState("j") Is Nothing Then Me.ViewState.Remove("j")
            Me.ViewState.Add("j", value)
        End Set
    End Property

    Public Property valorActual() As Integer
        Get
            Return _valorActual
        End Get
        Set(ByVal value As Integer)
            _valorActual = value
            If Not Me.ViewState("valorActual") Is Nothing Then Me.ViewState.Remove("valorActual")
            Me.ViewState.Add("valorActual", value)
        End Set
    End Property

    Public Property tipoModificativa() As Integer
        Get
            Return _tipoModificativa
        End Get
        Set(ByVal value As Integer)
            _tipoModificativa = value
            If Not Me.ViewState("tipoModificativa") Is Nothing Then Me.ViewState.Remove("tipoModificativa")
            Me.ViewState.Add("tipoModificativa", value)
        End Set
    End Property

    Public Property clausulasGuardadas() As Integer
        Get
            Return _clausulasGuardadas
        End Get
        Set(ByVal value As Integer)
            _clausulasGuardadas = value
            If Not Me.ViewState("clausulasGuardadas") Is Nothing Then Me.ViewState.Remove("clausulasGuardadas")
            Me.ViewState.Add("clausulasGuardadas", value)

        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.IDPLANTILLA = Request.QueryString("id")
        Else

            If Not Me.ViewState("IDPLANTILLA") Is Nothing Then Me._IDPLANTILLA = Me.ViewState("IDPLANTILLA")
            If Not Me.ViewState("NoClausula") Is Nothing Then Me._NoClausula = Me.ViewState("NoClausula")
            If Not Me.ViewState("NoC") Is Nothing Then Me._NoC = Me.ViewState("NoC")
            If Not Me.ViewState("j") Is Nothing Then Me._j = Me.ViewState("j")
            If Not Me.ViewState("valorActual") Is Nothing Then Me._valorActual = Me.ViewState("valorActual")
            If Not Me.ViewState("tipoModificativa") Is Nothing Then Me._tipoModificativa = Me.ViewState("tipoModificativa")
            If Not Me.ViewState("clausulasGuardadas") Is Nothing Then Me._clausulasGuardadas = Me.ViewState("clausulasGuardadas")

        End If
        UcBarraNavegacion1.Visible = False

        With Me.UcBarraNavegacion1
            .PermitirAgregar = False
            .PermitirConsultar = False
            .PermitirEditar = True
            .PermitirGuardar = True
            .PermitirImprimir = False
            .Navegacion = False
            .HabilitarEdicion(True)
        End With

        If Request.QueryString("mod") = "EDIT" Then
            If Not IsPostBack Then
                obtenerDatos()
            End If
        End If
        tipoModificativa = Request.QueryString("tipoMod")
        If Request.QueryString("tipoMod") = 1 Then
            Me.lblPlantillaModificativa.Text = "Plantilla para modificativa de contratos"
            Me.lblPlantillaModificativa.Font.Bold = True
        End If

    End Sub

    Private Sub obtenerDatos()
        Dim mComponente As New cPLANTILLASCONTRATO
        Dim lEntidad As New PLANTILLASCONTRATO

        With lEntidad
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDPLANTILLA = IDPLANTILLA
        End With

        Dim ds As Data.DataSet
        ds = mComponente.obtenerDataSetxPlantilla(lEntidad)

        If ds.Tables(0).Rows.Count > 0 Then
            Me.DdlTIPOCOMPRAS1.SelectedValue = ds.Tables(0).Rows(0).Item("IDTIPOCOMPRA")
            Me.DdlSUMINISTROS1.SelectedValue = ds.Tables(0).Rows(0).Item("IDSUMINISTRO")
            Me.txtNombre.Text = ds.Tables(0).Rows(0).Item("NOMBRE")
            Me.txtPersoneriaJuridica.Text = ds.Tables(0).Rows(0).Item("PERSONERIAJURIDICA").ToString
        End If

    End Sub

    Public Sub cargarDatos()
        If Not IsPostBack Then
            clausulasGuardadas = 0
            Me.DdlSUMINISTROS1.Recuperar()
            Me.DdlTIPOCOMPRAS1.ObtenerTipoCompraXModalidad(2)
        End If
    End Sub

    Public Sub cargarClausula()

        Dim cC As New cCLAUSULAS

        If Request.QueryString("mod") = "EDIT" Then
            Dim ds As Data.DataSet
            ds = mComponente.ObtenerDataSetporPlantilla(Session("IdEstablecimiento"), Request.QueryString("id"))

            Me.dgClausula.DataSource = cC.ObtenerDataSetPorTipoModificativa(Me.DdlTIPOCOMPRAS1.SelectedValue, Me.tipoModificativa)
            Me.dgClausula.DataBind()

            Dim i, j As Integer

            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To Me.dgClausula.Items.Count - 1
                    If dgClausula.Items(j).Cells(2).Text = ds.Tables(0).Rows(i).Item(1) Then
                        Dim chk As CheckBox = CType(dgClausula.Items(j).FindControl("chkClausula"), CheckBox)
                        chk.Checked = True
                    End If
                Next
            Next

        Else
            If clausulasGuardadas > 0 Then
                Dim ds As Data.DataSet
                ds = mComponente.ObtenerDataSetporPlantilla(Session("IdEstablecimiento"), Request.QueryString("id"))

                Me.dgClausula.DataSource = cC.ObtenerDataSetPorTipoModificativa(Me.DdlTIPOCOMPRAS1.SelectedValue, Me.tipoModificativa)
                Me.dgClausula.DataBind()

                Dim i, j As Integer

                For i = 0 To ds.Tables(0).Rows.Count - 1
                    For j = 0 To Me.dgClausula.Items.Count - 1
                        If dgClausula.Items(j).Cells(2).Text = ds.Tables(0).Rows(i).Item(1) Then
                            Dim chk As CheckBox = CType(dgClausula.Items(j).FindControl("chkClausula"), CheckBox)
                            chk.Checked = True
                        End If
                    Next
                Next
            Else
                Me.dgClausula.DataSource = cC.ObtenerDataSetPorTipoModificativa(Me.DdlTIPOCOMPRAS1.SelectedValue, tipoModificativa)
                Me.dgClausula.DataBind()
            End If
        End If

    End Sub

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar
        guardarDatos()
    End Sub

    Private Sub guardarDatos()
        Dim i As Integer
        If Panel4.Visible = True Then
            Dim lEntidad As New CLAUSULASPLANTILLA

            With lEntidad
                .AUFECHAMODIFICACION = Date.Today
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .ESTASINCRONIZADA = Me.tipoModificativa
                .IDPLANTILLA = IDPLANTILLA
                .IDCLAUSULA = Me.dgClausula.Items(i).Cells(2).Text
                .ORDEN = mComponente.obtenerOrden(Session("IdEstablecimiento"), IDPLANTILLA, Me.dgClausula.Items(i).Cells(2).Text)
                .CONTENIDO = Me.rteContenido.Text
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            End With
            mComponente.ActualizarxClausula(lEntidad, Me.txtValidaOrden.Text)
            j += 1
            cargarPanel3()
        End If

        If Panel2.Visible = True Then
            Dim lEntidad As New CLAUSULASPLANTILLA
            NoClausula = dgClausula.Items.Count
            For i = 0 To Me.dgClausula.Items.Count - 1
                Dim chk As CheckBox = CType(Me.dgClausula.Items(i).FindControl("chkClausula"), CheckBox)
                If chk.Checked = True Then
                    With lEntidad
                        .AUFECHACREACION = Date.Today
                        .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                        .ESTASINCRONIZADA = tipoModificativa
                        .IDPLANTILLA = IDPLANTILLA
                        .IDCLAUSULA = Me.dgClausula.Items(i).Cells(2).Text
                        .CONTENIDO = Me.dgClausula.Items(i).Cells(3).Text
                        .ORDEN = 0
                        .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    End With
                    mComponente.AgregarCLAUSULASPLANTILLA(lEntidad)
                End If
            Next
            Me.Panel2.Visible = False
            Me.Panel3.Visible = True
            'cargarPanel3()
            CargarClausulas()
        End If

        If Panel1.Visible = True Then
            Dim mComponente As New cPLANTILLASCONTRATO
            Dim lEntidad As New PLANTILLASCONTRATO
            With lEntidad
                If Request.QueryString("mod") = "EDIT" Then
                    .IDPLANTILLA = IDPLANTILLA
                End If
                .AUFECHACREACION = Date.Today
                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                .ESTASINCRONIZADA = tipoModificativa
                .IDSUMINISTRO = Me.DdlSUMINISTROS1.SelectedValue
                .IDTIPOCOMPRA = Me.DdlTIPOCOMPRAS1.SelectedValue
                .NOMBRE = Me.txtNombre.Text
                .PERSONERIAJURIDICA = "" 'Me.txtPersoneriaJuridica.Text
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                .AUFECHACREACION = Date.Today
                .AUFECHAMODIFICACION = Date.Today
                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            End With
            mComponente.ActualizarPLANTILLASCONTRATO(lEntidad)
            IDPLANTILLA = lEntidad.IDPLANTILLA
            If IDPLANTILLA > 0 Then
                Panel1.Visible = False
                Panel2.Visible = True
                cargarClausula()
            End If
        End If
    End Sub

    Private Sub cargarPanel3()
        Me.lblNoClausulas.Text = "Ha seleccionado " & NoClausula & " clausula(s) para la plantilla"

        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDataSetporPlantilla(Session("IdEstablecimiento"), IDPLANTILLA)

        If ds.Tables(0).Rows.Count > 0 Then
            NoC = ds.Tables(0).Rows.Count

            If j <= NoC - 1 Then

                Me.lblClausula.Text = ds.Tables(0).Rows(j).Item("NOMBRE")
                Me.rteContenido.Text = ds.Tables(0).Rows(j).Item("CONTENIDO")
                Me.txtOrden.Text = 0
                CargarEtiqueta()
            Else

                Me.Panel3.Visible = False
                Me.Panel4.Visible = True
                CargarClausulas()

            End If


        End If

    End Sub

    Private Sub CargarClausulas()
        DataGrid1.DataSource = mComponente.ObtenerDataSetporPlantilla(Session("IdEstablecimiento"), IDPLANTILLA) 'Request.QueryString("id")
        Me.DataGrid1.DataBind()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Me.guardarDatos()
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        'Me.guardarDatos()
        guardaClausulas()
    End Sub

    Private Sub guardaClausulas()
        Dim lEntidad As New CLAUSULASPLANTILLA
        Dim ds As New Data.DataSet
        Dim i As Integer

        For i = 0 To Me.dgClausula.Items.Count - 1
            Dim chk As CheckBox = CType(Me.dgClausula.Items(i).FindControl("chkClausula"), CheckBox)
            If chk.Checked = True Then
                If mComponente.ObtenerDataSetPorId(Session("IdEstablecimiento"), IDPLANTILLA, Me.dgClausula.Items(i).Cells(2).Text).Tables(0).Rows.Count = 0 Then
                    With lEntidad
                        .AUFECHACREACION = Date.Today
                        .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                        .ESTASINCRONIZADA = Me.dgClausula.Items(i).Cells(4).Text
                        .IDPLANTILLA = IDPLANTILLA
                        .IDCLAUSULA = Me.dgClausula.Items(i).Cells(2).Text
                        .CONTENIDO = Me.dgClausula.Items(i).Cells(3).Text
                        .ORDEN = 0
                        .IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    End With
                    mComponente.AgregarCLAUSULASPLANTILLA(lEntidad)

                End If
            Else
                If mComponente.ObtenerDataSetPorId(Session("IdEstablecimiento"), IDPLANTILLA, Me.dgClausula.Items(i).Cells(2).Text).Tables(0).Rows.Count > 0 Then
                    mComponente.EliminarCLAUSULASPLANTILLA(Session("IdEstablecimiento"), IDPLANTILLA, dgClausula.Items(i).Cells(2).Text, 0)
                End If
            End If
        Next
        clausulasGuardadas = 1
        Me.Panel2.Visible = False
        Me.Panel3.Visible = True
        'cargarPanel3()
        CargarClausulas()

    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        Me.guardarDatos()
    End Sub

    Private Sub CargarEtiqueta()
        Dim mComponente As New cETIQUETASCLAUSULAS
        Dim lEntidad As New ETIQUETASCLAUSULAS

        Me.dgEtiqueta.DataSource = mComponente.ObtenerDataSetPorTipo(Me.tipoModificativa)
        Me.dgEtiqueta.DataBind()

    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Me.Panel1.Visible = True
        Me.Panel2.Visible = False

    End Sub

    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
        Me.Panel3.Visible = False
        Me.Panel2.Visible = True
        cargarClausula()
    End Sub

    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click
        CargarClausulas()
        Me.Panel3.Visible = True
        Me.Panel4.Visible = False
    End Sub

    Protected Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        Dim a As Integer
        If e.CommandName = "DELETE" Then
            a = 1
        End If
    End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged
        Me.Panel3.Visible = False
        Me.valorActual = Me.DataGrid1.SelectedItem.Cells(3).Text
        Me.CargarEtiqueta()
        Me.Panel4.Visible = True
        Dim idClausula As Integer
        idClausula = Me.DataGrid1.SelectedItem.Cells(4).Text
        lblClausula.Text = Me.DataGrid1.SelectedItem.Cells(1).Text
        NoClausula = idClausula

        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDataSetPorId(Session("IdEstablecimiento"), IDPLANTILLA, idClausula)

        With ds.Tables(0).Rows(0)
            If Request.QueryString("mod") = "EDIT" Then

                If valorActual <> 0 Then
                    Me.txtOrden.Text = valorActual
                Else
                    Me.txtOrden.Text = mComponente.obtenerOrden(Session("IdEstablecimiento"), IDPLANTILLA, idClausula) - 1
                    Me.txtOrden.Text += 1
                End If

                '.Item("ORDEN")

                Me.txtValidaOrden.Text = .Item("ORDEN")
            Else
                Me.txtOrden.Text = mComponente.obtenerOrden(Session("IdEstablecimiento"), IDPLANTILLA, idClausula)
                Me.txtValidaOrden.Text = valorActual
            End If
            Me.rteContenido.Text = .Item("CONTENIDO")
        End With

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim lEntidad As New CLAUSULASPLANTILLA
        Dim noOrden As Integer = 0

        If Request.QueryString("mod") = "EDIT" Then
            If Me.txtValidaOrden.Text <> Me.txtOrden.Text Then
                noOrden = mComponente.validaOrden(Session("IdEstablecimiento"), IDPLANTILLA, NoClausula, Me.txtOrden.Text)
            End If
        Else
            noOrden = mComponente.validaOrden(Session("IdEstablecimiento"), IDPLANTILLA, NoClausula, Me.txtOrden.Text)
        End If



        If noOrden = 0 Then
            With lEntidad
                .AUFECHAMODIFICACION = Date.Today
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .ESTASINCRONIZADA = 0
                .IDPLANTILLA = IDPLANTILLA
                .IDCLAUSULA = NoClausula
                .ORDEN = Me.txtOrden.Text
                .CONTENIDO = Me.rteContenido.Text
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            End With
            If mComponente.ActualizarxClausula(lEntidad, Me.txtValidaOrden.Text) = 1 Then
                Me.MsgBox1.ShowConfirm("El registro se guardó satisfactoriamente, ¿Desea seleccionar otra Clausula?", "GUARDAR", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
            End If
            'j += 1
            'cargarPanel3()
        Else
            RequiredFieldValidator1.ErrorMessage = "Digite otro valor para el orden, este ya existe. Valor sugerido es: " & mComponente.obtenerOrden(Session("IdEstablecimiento"), IDPLANTILLA, NoClausula)
            RequiredFieldValidator1.IsValid = False
        End If


    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "ELIMINAR" Then
            Dim lEntidad As New CLAUSULASPLANTILLA
            Dim noOrden As Integer = 0
            With lEntidad
                .AUFECHAMODIFICACION = Date.Today
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .ESTASINCRONIZADA = 0
                .IDPLANTILLA = IDPLANTILLA
                .IDCLAUSULA = NoClausula
                .ORDEN = Me.txtOrden.Text
                .CONTENIDO = Me.rteContenido.Text
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            End With
            mComponente.EliminarCLAUSULASPLANTILLA(Session("IdEstablecimiento"), IDPLANTILLA, NoClausula, Me.txtOrden.Text)
            CargarClausulas()
            Me.Panel3.Visible = True
            Me.Panel4.Visible = False
        Else
            CargarClausulas()
            Me.Panel3.Visible = True
            Me.Panel4.Visible = False
        End If

    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Me.MsgBox1.ShowConfirm("¿Desea eliminar esta clausula?", "ELIMINAR", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        'If mComponente.EliminarCLAUSULASPLANTILLA(Session("IdEstablecimiento")lEntidad, ) = 1 Then
        '    Me.MsgBox1.ShowConfirm("El registro se guardó satisfactoriamente, ¿Desea seleccionar otra Clausula?", "GUARDAR", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        'End If
        'j += 1
        'cargarPanel3()
        'Else
        'RequiredFieldValidator1.ErrorMessage = "Digite otro valor para el orden, este ya existe. Valor sugerido es: " & mComponente.obtenerOrden(Session("IdEstablecimiento"), IDPLANTILLA, NoClausula)
        'End If
    End Sub

End Class
