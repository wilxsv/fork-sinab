Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Utils.MessageBox

Partial Class ESTABLECIMIENTOS_frmMantConsumoAbastecimiento
    Inherits System.Web.UI.Page
    Private _FARMACIA As Integer

    Public Property FARMACIA() As Integer 'identificador de programacion
        Get
            Return Me._FARMACIA
        End Get
        Set(ByVal Value As Integer)
            Me._FARMACIA = Value
            If Not Me.ViewState("FARMACIA") Is Nothing Then Me.ViewState.Remove("FARMACIA")
            Me.ViewState.Add("FARMACIA", Value)
        End Set
    End Property

    Protected Sub btGuardar_Click(sender As Object, e As System.EventArgs) Handles btGuardar.Click
        'evento guardar
        'evento guardar
        Dim sError As String
        sError = Me.actualizar2()
        If sError <> "" Then
            'Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Alert(sError, "Error")
            Return
        Else
            CargarDatos()
            'Me.MsgBox1.ShowAlert("Los datos se han actualizado con éxito", "Exito", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Alert("Los datos se han actualizado con éxito", "Exito")
            Return
        End If
    End Sub

    Protected Sub btCancelar_Click(sender As Object, e As System.EventArgs) Handles btCancelar.Click
        'evento cancelar
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    'Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
    '    'evento cancelar
    '    Response.Redirect("~/FrmPrincipal.aspx", False)
    'End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'evento al presionar link menu
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub

    'Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar
    '    'evento guardar
    '    'evento guardar
    '    Dim sError As String
    '    sError = Me.actualizar()
    '    If sError <> "" Then
    '        'Me.MsgBox1.ShowAlert(sError, "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        Alert(sError, "Error", OptionPostBack.WithoutPostBack)
    '        Return
    '    Else
    '        CargarDatos()
    '        'Me.MsgBox1.ShowAlert("Los datos se han actualizado con éxito", "Exito", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '        Alert("Los datos se han actualizado con éxito", "Exito", OptionPostBack.WithoutPostBack)
    '        Return
    '    End If
    'End Sub

    Private Function actualizar() As String

        Dim arr As New ArrayList

        Dim consumo As Decimal
        Dim existencia As Decimal

        For Each row As GridViewRow In gvLista.Rows

            Dim eComponente As New CONSUMOS

            eComponente.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            eComponente.IDALMACEN = Me.cboAlmacen.SelectedItem.Value
            eComponente.IDPRODUCTO = Me.gvLista.DataKeys(row.RowIndex).Values(1)
            eComponente.FECHACONSUMO = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex, 1)

            If Me.gvLista.DataKeys(row.RowIndex).Values(3) Is DBNull.Value Then

                If Me.ViewState("FARMACIA") = 1 Then
                    eComponente.CONSUMOREAL = -1
                    eComponente.CONSUMOAJUSTADO = -1
                Else
                    eComponente.CONSUMOREAL = 0
                    eComponente.CONSUMOAJUSTADO = 0
                End If

                eComponente.EXISTENCIA = -1

            Else
                eComponente.CONSUMOREAL = Me.gvLista.DataKeys(row.RowIndex).Values(3)
                eComponente.EXISTENCIA = IIf(IsDBNull(Me.gvLista.DataKeys(row.RowIndex).Values(4)), "0", Me.gvLista.DataKeys(row.RowIndex).Values(4))
                eComponente.CONSUMOAJUSTADO = Me.gvLista.DataKeys(row.RowIndex).Values(5)
            End If

            eComponente.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eComponente.AUFECHACREACION = Now

            Dim txtAd As eWorld.UI.NumericBox
            Dim txtAd2 As eWorld.UI.NumericBox

            'Consumo
            txtAd = row.FindControl("txtConsumo")
            If txtAd.Text = "" Then
                txtAd.Text = "0"
            End If

            'Existencia
            txtAd2 = row.FindControl("txtExistencia")

            If Me.ViewState("FARMACIA") = 1 And Not (txtAd.Text = "") Then
                'FARMACIA
                If (txtAd.Text = "" Or txtAd2.Text = "") Then
                    Return "Debe especificar el consumo"
                Else

                    If Me.gvLista.DataKeys(row.RowIndex).Values(2) = "CTO" Then
                        consumo = txtAd.Text
                        'existencia = txtAd2.Text

                        'Existencia - consumo = existencia final
                        existencia = IIf(IsDBNull(Me.gvLista.DataKeys(row.RowIndex).Values(4)), "0", Me.gvLista.DataKeys(row.RowIndex).Values(4)) - consumo
                    Else
                        consumo = CInt(txtAd.Text)
                        ' existencia = CInt(txtAd2.Text)

                        'Existencia - consumo = existencia final
                        existencia = CInt(IIf(IsDBNull(Me.gvLista.DataKeys(row.RowIndex).Values(4)), "0", Me.gvLista.DataKeys(row.RowIndex).Values(4)) - consumo)

                    End If


                    If consumo <> eComponente.CONSUMOREAL Or existencia <> eComponente.EXISTENCIA Then

                        If consumo <> eComponente.CONSUMOREAL Then
                            eComponente.CONSUMOAJUSTADO = consumo
                        End If

                        eComponente.CONSUMOREAL = consumo

                        eComponente.EXISTENCIA = existencia

                        arr.Add(eComponente)

                    End If

                End If
            ElseIf Me.ViewState("FARMACIA") = 0 And Not txtAd2.Text = "" Then
                'ALMACEN
                If Me.gvLista.DataKeys(row.RowIndex).Values(2) = "CTO" Then
                    consumo = txtAd.Text
                    existencia = txtAd2.Text
                Else
                    consumo = CInt(txtAd.Text)
                    existencia = CInt(txtAd2.Text)
                End If

                If existencia <> eComponente.EXISTENCIA Then
                    eComponente.CONSUMOAJUSTADO = 0
                    eComponente.CONSUMOREAL = 0
                    eComponente.EXISTENCIA = existencia
                    arr.Add(eComponente)
                End If

            End If

        Next

        If arr.Count > 0 Then


            Dim cComponente As New cCONSUMOS

            If cComponente.actualizarConsumos(arr) = -1 Then
                Return "Error al guardar los registro. Intente nuevamente"
            End If

        End If

        Return ""

    End Function
    'SCMS
    Private Function actualizar2() As String

        Dim arr As New ArrayList

        Dim consumo As Decimal
        Dim existencia As Decimal


        If Me.ViewState("FARMACIA") = 1 Then
            ' es farmacia
            ' borrar todo los registros de esa fecha y almacen en sab_est_consumos
            Dim CCONS As New cCONSUMOS
            CCONS.BorrarRegistrosMes(Session.Item("IdEstablecimiento"), Me.cboAlmacen.SelectedItem.Value, New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex, 1))

        End If




        For Each row As GridViewRow In gvLista.Rows

            Dim eComponente As New CONSUMOS

            eComponente.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            eComponente.IDALMACEN = Me.cboAlmacen.SelectedItem.Value
            eComponente.IDPRODUCTO = Me.gvLista.DataKeys(row.RowIndex).Values(1)
            eComponente.FECHACONSUMO = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex, 1)

            If Me.gvLista.DataKeys(row.RowIndex).Values(3) Is DBNull.Value Then

                If Me.ViewState("FARMACIA") = 1 Then
                    eComponente.CONSUMOREAL = -1
                    eComponente.CONSUMOAJUSTADO = -1
                Else
                    eComponente.CONSUMOREAL = 0
                    eComponente.CONSUMOAJUSTADO = 0
                End If

                eComponente.EXISTENCIA = -1

            Else
                eComponente.CONSUMOREAL = Me.gvLista.DataKeys(row.RowIndex).Values(3)
                eComponente.EXISTENCIA = IIf(IsDBNull(Me.gvLista.DataKeys(row.RowIndex).Values(4)), "0", Me.gvLista.DataKeys(row.RowIndex).Values(4))
                eComponente.CONSUMOAJUSTADO = Me.gvLista.DataKeys(row.RowIndex).Values(5)
            End If

            eComponente.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eComponente.AUFECHACREACION = Now

            Dim txtAd As eWorld.UI.NumericBox
            Dim txtAd2 As eWorld.UI.NumericBox

            'Consumo
            txtAd = row.FindControl("txtConsumo")
            If txtAd.Text = "" Then
                txtAd.Text = "0"
            End If

            'Existencia
            txtAd2 = row.FindControl("txtExistencia")

            If Me.ViewState("FARMACIA") = 1 And Not (txtAd.Text = "") Then
                'FARMACIA
                'ingresar todo basado siempre en la existencia original


                If (txtAd.Text = "" Or txtAd2.Text = "") Then
                    Return "Debe especificar el consumo"
                Else

                    If Me.gvLista.DataKeys(row.RowIndex).Values(2) = "CTO" Then
                        consumo = txtAd.Text
                        'existencia = txtAd2.Text

                        'existencia final = (existencia del mes anterior mas ajustes mas despachos) - consumos

                        Dim existenciaMesAnterior As Decimal
                        Dim cCONs As New cCONSUMOS
                        existenciaMesAnterior = cCONs.obtenerExistenciaMesAnterior(eComponente.IDESTABLECIMIENTO, eComponente.IDALMACEN, eComponente.FECHACONSUMO, eComponente.IDPRODUCTO)


                        Dim ajustes As Decimal
                        ajustes = cCONs.obtenerAjustesDelMes(eComponente.IDESTABLECIMIENTO, eComponente.IDALMACEN, eComponente.FECHACONSUMO, eComponente.IDPRODUCTO)

                        Dim despachos As Decimal
                        despachos = cCONs.obtenerDespachosDelMes(eComponente.IDESTABLECIMIENTO, eComponente.IDALMACEN, eComponente.FECHACONSUMO, eComponente.IDPRODUCTO)


                        'existencia = IIf(IsDBNull(Me.gvLista.DataKeys(row.RowIndex).Values(4)), "0", Me.gvLista.DataKeys(row.RowIndex).Values(4)) - consumo

                        existencia = (existenciaMesAnterior + ajustes + despachos) - consumo


                    Else
                        consumo = CInt(txtAd.Text)
                        ' existencia = CInt(txtAd2.Text)

                        'existencia final = (existencia del mes anterior mas ajustes mas despachos) - consumos
                        ' existencia = CInt(IIf(IsDBNull(Me.gvLista.DataKeys(row.RowIndex).Values(4)), "0", Me.gvLista.DataKeys(row.RowIndex).Values(4)) - consumo)

                        Dim existenciaMesAnterior As Decimal
                        Dim cCONs As New cCONSUMOS
                        existenciaMesAnterior = cCONs.obtenerExistenciaMesAnterior(eComponente.IDESTABLECIMIENTO, eComponente.IDALMACEN, eComponente.FECHACONSUMO, eComponente.IDPRODUCTO)


                        Dim ajustes As Decimal
                        ajustes = cCONs.obtenerAjustesDelMes(eComponente.IDESTABLECIMIENTO, eComponente.IDALMACEN, eComponente.FECHACONSUMO, eComponente.IDPRODUCTO)

                        Dim despachos As Decimal
                        despachos = cCONs.obtenerDespachosDelMes(eComponente.IDESTABLECIMIENTO, eComponente.IDALMACEN, eComponente.FECHACONSUMO, eComponente.IDPRODUCTO)


                        'existencia = IIf(IsDBNull(Me.gvLista.DataKeys(row.RowIndex).Values(4)), "0", Me.gvLista.DataKeys(row.RowIndex).Values(4)) - consumo

                        existencia = (existenciaMesAnterior + ajustes + despachos) - consumo

                    End If


                    'If consumo <> eComponente.CONSUMOREAL Then

                    If consumo <> eComponente.CONSUMOREAL Then
                        eComponente.CONSUMOAJUSTADO = consumo
                    End If

                    eComponente.CONSUMOREAL = consumo


                    eComponente.EXISTENCIA = existencia

                    arr.Add(eComponente)

                    'End If

                End If
            ElseIf Me.ViewState("FARMACIA") = 0 And Not txtAd2.Text = "" Then
                'ALMACEN
                If Me.gvLista.DataKeys(row.RowIndex).Values(2) = "CTO" Then
                    consumo = txtAd.Text
                    existencia = txtAd2.Text
                Else
                    consumo = CInt(txtAd.Text)
                    existencia = CInt(txtAd2.Text)
                End If

                If existencia <> eComponente.EXISTENCIA Then
                    eComponente.CONSUMOAJUSTADO = 0
                    eComponente.CONSUMOREAL = 0
                    eComponente.EXISTENCIA = existencia
                    arr.Add(eComponente)
                End If

            End If

        Next

        If arr.Count > 0 Then


            Dim cComponente As New cCONSUMOS

            If cComponente.actualizarConsumos(arr) = -1 Then
                Return "Error al guardar los registro. Intente nuevamente"
            End If

        End If

        Return ""

    End Function
    'Public Sub HabilitarEdicion(ByVal edicion As Boolean)
    '    'FUNCION DE HABILITACION DEL EVENTO EDITAR
    '    If edicion Then
    '        Me.ibtnEditarCancelar.CssClass = "opCancelar"
    '    Else
    '        Me.ibtnEditarCancelar.CssClass = "opEditar"
    '    End If
    '    Me.ibtnEditarCancelar.Enabled = True
    '    Me.ibtnAgregar.Enabled = Not edicion
    '    Me.ibtnGuardar.Enabled = edicion
    'End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu
            pNavegacion.Visible = False
            'Me.ucBarraNavegacion1.Navegacion = False
            'Me.ucBarraNavegacion1.PermitirAgregar = False
            'Me.ucBarraNavegacion1.PermitirEditar = False
            'Me.ucBarraNavegacion1.PermitirConsultar = False
            'Me.ucBarraNavegacion1.HabilitarEdicion(True)
            'Me.ucBarraNavegacion1.PermitirImprimir = False
            'Me.ucBarraNavegacion1.PermitirGuardar = False
            'Me.ucBarraNavegacion1.PermitirCancelar = False


            Me.cboAnio.Items.Add("[Seleccione un año]")

            For i As Integer = 2009 To Now.Year
                Me.cboAnio.Items.Add(i)
            Next

            Me.cboAnio.SelectedIndex = 0

            'Verificamos si el usuario cuenta con mas de un almacen o farmacia
            Dim cEntidad As New cEMPLEADOSALMACEN
            Dim ds As Data.DataSet = cEntidad.ObtenerDsDetalleAlmacenesEmpleados(Session.Item("IdEmpleado"))

            If ds Is Nothing Then
                Response.Redirect("~/frmLogin.aspx")
            End If

            'If ds.Tables(0).Rows.Count = 0 Then
            '    Response.Redirect("~/frmLogin.aspx")
            'End If

            Dim bEntidad2 As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMAS
            Me.DropDownList1.DataSource = bEntidad2.ObtenerPROGRAMAS
            Me.DropDownList1.DataValueField = "IDPROGRAMA"
            Me.DropDownList1.DataTextField = "NOMBRE"

            Me.DropDownList1.DataBind()
            Me.DropDownList1.Items.Insert(0, "(Todos)")
            Me.DropDownList1.SelectedValue = 0


            Me.cboAlmacen.Items.Add("[Seleccione un almacén/farmacia]")

            If ds.Tables(0).Rows.Count <> 1 Then
                Dim il As New ListItem("Informe consolidado", 0)
                Me.cboAlmacen.Items.Add(il)
            End If

            Me.cboAlmacen.DataTextField = "nombre"
            Me.cboAlmacen.DataValueField = "idAlmacen"
            Me.cboAlmacen.DataSource = ds
            Me.cboAlmacen.DataBind()

            ' Session("IdAlmacenHospital") = Me.cboAlmacen.Items(3).Value
            ' Me.cboAlmacen.Items.Remove(Me.cboAlmacen.Items(3))

            If ds.Tables(0).Rows.Count < 2 Then

                If ds.Tables(0).Rows.Count = 1 Then
                    FARMACIA = ds.Tables(0).Rows(0).Item("ESFARMACIA")
                Else
                    FARMACIA = -1
                End If

                Me.cboAlmacen.SelectedIndex = 1
                Me.cboAlmacen.Enabled = False
                Me.cboAnio.Enabled = True
                Me.cboMes.Enabled = True
                Me.b1.Enabled = True
            Else
                Me.btnConsA.Enabled = True
            End If



            'CargarDatos()
        Else
            If Not Me.ViewState("FARMACIA") Is Nothing Then FARMACIA = Me.ViewState("FARMACIA")
        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cCONSUMOS

        Dim fecha As Date = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex, 1)

        If Me.ViewState("FARMACIA") = -1 Then
            ds = mComponente.obtenerConsumoTotalFecha2(Session.Item("IdEstablecimiento"), fecha)
        Else
            If mComponente.ChequearCYEMEsAnterior(Session.Item("IdEstablecimiento"), Me.cboAlmacen.SelectedItem.Value, fecha, IIf(Me.cboAlmacen.SelectedItem.Text.ToUpper.Contains("FARMACIA"), 0, 1)) = 0 Then
                'no hay datos de consumos mes anterior, no se puede continuar
                Alert("No existe registro de consumos y existencias del mes anterior al que se desea ingresar. Para el cálculo de la existencia, es necesario haber ingresado información del mes anterior. Proceda a ingresar la información del mes anterior.", "Error")
                Exit Sub
            Else
                ds = mComponente.obtenerExistenciaEstablecimientoFecha2(Session.Item("IdEstablecimiento"), Me.cboAlmacen.SelectedItem.Value, fecha, IIf(Me.cboAlmacen.SelectedItem.Text.ToUpper.Contains("FARMACIA"), 0, 1), Session("IdEmpleado")) ' IIf(Me.cboAlmacen.SelectedItem.Text.ToUpper.Contains("FARMACIA"), 0, 1))
            End If

        End If

        Me.gvLista.DataSource = ds

        If Me.ViewState("FARMACIA") = 0 Then
            Me.gvLista.Columns(3).Visible = False
            Me.gvLista.Columns(4).Visible = False
            Me.gvLista.Columns(5).Visible = False
            Me.gvLista.Columns(6).Visible = False
            Me.gvLista.Columns(7).Visible = False
            Me.gvLista.Columns(8).Visible = True
            Me.gvLista.Columns(9).Visible = False
            Me.gvLista.Columns(10).Visible = True
            Me.gvLista.Columns(1).HeaderStyle.Width = 665
        ElseIf Me.ViewState("FARMACIA") = -1 Then
            Me.gvLista.Columns(3).Visible = False
            Me.gvLista.Columns(4).Visible = False
            Me.gvLista.Columns(5).Visible = False
            Me.gvLista.Columns(6).Visible = True
            Me.gvLista.Columns(7).Visible = True
            Me.gvLista.Columns(8).Visible = False
            Me.gvLista.Columns(9).Visible = True
            Me.gvLista.Columns(10).Visible = False
            Me.gvLista.Columns(1).HeaderStyle.Width = 665
            Me.gvLista.Columns(11).Visible = False

        Else
            'es farmacia
            Me.gvLista.Columns(3).Visible = True
            Me.gvLista.Columns(4).Visible = True
            Me.gvLista.Columns(5).Visible = True
            Me.gvLista.Columns(6).Visible = False
            Me.gvLista.Columns(7).Visible = True
            Me.gvLista.Columns(8).Visible = True
            Me.gvLista.Columns(9).Visible = False
            Me.gvLista.Columns(10).Visible = True
            Me.gvLista.Columns(1).HeaderStyle.Width = 465
            Me.Button32.Visible = True
        End If

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    'Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

    '    Call actualizar2()

    '    Me.gvLista.PageIndex = e.NewPageIndex
    '    Call CargarDatos()
    'End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim valor As Decimal
            Dim txtAd As eWorld.UI.NumericBox
            Dim imgB As ImageButton
            Dim lnkB As LinkButton


            'Consumo
            txtAd = e.Row.FindControl("txtConsumo")
            If txtAd.Text = "" Then
                txtAd.Text = "0"
            End If
            'txtAd.DecimalPlaces = IIf(Me.gvLista.DataKeys(e.Row.RowIndex).Values(2) = "CTO", 2, 0)
            'txtAd.RealNumber = IIf(Me.gvLista.DataKeys(e.Row.RowIndex).Values(2) = "CTO", True, False)
            If Not Me.gvLista.DataKeys(e.Row.RowIndex).Values(3) Is DBNull.Value Then
                valor = IIf(Me.gvLista.DataKeys(e.Row.RowIndex).Values(2) = "CTO", Me.gvLista.DataKeys(e.Row.RowIndex).Values(3), CInt(Me.gvLista.DataKeys(e.Row.RowIndex).Values(3)))
                txtAd.Text = valor

                If Me.ViewState("FARMACIA") = 0 Then
                    txtAd.Text = "0"
                End If

            Else
                lnkB = e.Row.FindControl("ImageButton1")
                lnkB.Visible = False
                imgB = e.Row.FindControl("BtnViewDetails")
                imgB.Visible = False
                imgB = e.Row.FindControl("BtnViewDetails2")
                imgB.Visible = False

                If Me.ViewState("FARMACIA") = 0 Then
                    txtAd.Text = "0"
                End If

            End If

            txtAd = e.Row.FindControl("txtExistencia")
            'txtAd.DecimalPlaces = IIf(Me.gvLista.DataKeys(e.Row.RowIndex).Values(2) = "CTO", 2, 0)
            'txtAd.RealNumber = IIf(Me.gvLista.DataKeys(e.Row.RowIndex).Values(2) = "CTO", True, False)
            If Not Me.gvLista.DataKeys(e.Row.RowIndex).Values(4) Is DBNull.Value Then
                valor = IIf(Me.gvLista.DataKeys(e.Row.RowIndex).Values(2) = "CTO", Me.gvLista.DataKeys(e.Row.RowIndex).Values(4), CInt(Me.gvLista.DataKeys(e.Row.RowIndex).Values(4)))
                txtAd.Text = valor
            Else
                txtAd.Text = "0"
            End If

            'Select Case Me.cboAlmacen.SelectedItem.Text
            '    Case Is = 2
            '        txtAd.Enabled = True
            '    Case Is = 3
            '        txtAd.Enabled = False
            'End Select
            If Me.cboAlmacen.SelectedItem.Text.ToUpper.Contains("FARMACIA") Then
                txtAd.Enabled = True
            Else
                txtAd.Enabled = False
            End If


        End If
    End Sub



    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim btnDetails As ImageButton = sender

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Me.lblIdEstablecimiento.Text = Me.gvLista.DataKeys(row.RowIndex).Values(0)
        Me.lblIdProducto.Text = Me.gvLista.DataKeys(row.RowIndex).Values(1)
        Me.lblConsumo.Text = Me.gvLista.DataKeys(row.RowIndex).Values(3)
        Me.lblUM.Text = Me.gvLista.DataKeys(row.RowIndex).Values(2)
        Me.lblProd.Text = Me.gvLista.DataKeys(row.RowIndex).Values(6)

        Me.txtDemandaIns.Text = ""
        Me.txtDiasDesab.Text = ""
        Me.updPnlCustomerDetail.Update()
        Me.mdlPopup.Show()

    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim dias As Integer

        Dim fecha1 = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex, 1)
        Dim fecha2 = DateAdd(DateInterval.Month, 1, fecha1)

        dias = DateDiff(DateInterval.Day, fecha1, fecha2)

        If Me.txtDiasDesab.Text.Trim = "" Then
            Me.lblError.Text = "Debe definir los dias desabastecidos"
            Exit Sub
        End If

        If Me.txtDiasDesab.Text < 1 Or Me.txtDiasDesab.Text > dias Then
            Me.lblError.Text = "Los dias desabastecidos deben ser menor o igual al número de dias del mes"
            Exit Sub
        End If

        'dias desabastecido iguales 
        'Dim consumoAjustado As Decimal = CDbl(Me.lblConsumo.Text) / (1 - (CInt(Me.txtDiasDesab.Text) / dias))

        Dim consumoAjustado As Decimal

        If CInt(Me.txtDiasDesab.Text) = dias Then
            consumoAjustado = CDbl(Me.lblConsumo.Text)
        Else
            consumoAjustado = CDbl(Me.lblConsumo.Text) / (1 - (CInt(Me.txtDiasDesab.Text) / dias))
        End If


        If Me.lblUM.Text <> "CTO" Then
            consumoAjustado = Math.Ceiling(consumoAjustado)
        Else
            consumoAjustado = Math.Round(consumoAjustado, 2)
        End If


        Dim mdb As New cCONSUMOS
        Dim eEntidad As New CONSUMOS

        eEntidad.DEMANDAINSATISFECHA = 0
        eEntidad.DIASDESABASTECIDOS = Me.txtDiasDesab.Text
        eEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        eEntidad.IDALMACEN = Me.cboAlmacen.SelectedValue
        eEntidad.IDPRODUCTO = Me.lblIdProducto.Text
        eEntidad.FECHACONSUMO = fecha1
        eEntidad.CONSUMOAJUSTADO = consumoAjustado
        eEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eEntidad.AUFECHAMODIFICACION = Now

        If mdb.ajustarConsumo(eEntidad) = -1 Then
            'Me.MsgBox1.ShowAlert("Error al almacenar los datos", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Alert("Error al almacenar los datos", "Error")
            Exit Sub
        End If

        Me.mdlPopup.Hide()
        Call CargarDatos()
        Me.updatePanel.Update()

    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.mdlPopup.Hide()

    End Sub

    Protected Sub BtnViewDetails2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim btnDetails As ImageButton = sender

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Me.lblIdEstablecimiento2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(0)
        Me.lblIdProducto2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(1)
        Me.lblConsumo2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(3)
        Me.lblUM2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(2)
        Me.lblProd2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(6)

        Me.txtDemandaIns.Text = ""
        Me.txtDiasDesab.Text = ""

        Me.txtDemandaIns.RealNumber = IIf(Me.gvLista.DataKeys(row.RowIndex).Values(2) = "CTO", True, False)

        Me.updPnlCustomerDetail2.Update()
        Me.mdlPopup2.Show()

    End Sub

    Protected Sub BtnSave2_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim fecha1 = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex, 1)

        If Me.txtDemandaIns.Text.Trim = "" Then
            Me.lblError2.Text = "Debe definir la demanda insatisfecha"
            Exit Sub
        End If

        If Me.txtDemandaIns.Text = 0 Then
            Me.lblError2.Text = "La demanda insatisfecha no puede ser igual a cero"
            Exit Sub
        End If

        Dim consumoAjustado As Decimal = CDbl(Me.lblConsumo2.Text) + CDbl(Me.txtDemandaIns.Text)

        If Me.lblUM2.Text <> "CTO" Then
            consumoAjustado = Math.Ceiling(consumoAjustado)
        Else
            consumoAjustado = Math.Round(consumoAjustado, 2)
        End If


        Dim mdb As New cCONSUMOS
        Dim eEntidad As New CONSUMOS

        eEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        eEntidad.DEMANDAINSATISFECHA = Me.txtDemandaIns.Text
        eEntidad.DIASDESABASTECIDOS = 0
        eEntidad.IDALMACEN = Me.cboAlmacen.SelectedValue
        eEntidad.IDPRODUCTO = Me.lblIdProducto2.Text
        eEntidad.FECHACONSUMO = fecha1
        eEntidad.CONSUMOAJUSTADO = consumoAjustado
        eEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eEntidad.AUFECHAMODIFICACION = Now

        If mdb.ajustarConsumo(eEntidad) = -1 Then
            ' Me.MsgBox1.ShowAlert("Error al almacenar los datos", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Alert("Error al almacenar los datos", "Error")
            Exit Sub
        End If

        Me.mdlPopup2.Hide()
        Call CargarDatos()
        Me.updatePanel.Update()

    End Sub

    Protected Sub BtnClose2_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.mdlPopup2.Hide()

    End Sub

    Protected Sub b1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles b1.Click

        If Me.cboAnio.SelectedIndex = 0 Or Me.cboMes.SelectedIndex = 0 Then
            Me.Label1.Visible = True
            Exit Sub
        End If

        Dim fecha As Date = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex, 1)

        If fecha >= New Date(Now.Year, Now.Month, 1) Then
            Me.Label1.Visible = True
            Exit Sub
        End If

        If Me.cboAlmacen.SelectedItem.Value <> 0 Then
            pNavegacion.Visible = True
            btCancelar.Visible = False
            'Me.ucBarraNavegacion1.PermitirGuardar = True
        Else
            Me.btnCobertura.Visible = True
        End If


        Me.btnReporte.Visible = True
        Me.DropDownList1.Visible = True
        Me.Label82.Visible = True
        Me.cboAnio.Enabled = False
        Me.cboMes.Enabled = False
        Me.b1.Enabled = False
        Me.b2.Enabled = True
        Me.gvLista.Visible = True
        Me.Label1.Visible = False
        CargarDatos()

    End Sub

    Protected Sub b2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles b2.Click
        pNavegacion.Visible = True
        btCancelar.Visible = False
        Me.btnReporte.Visible = False
        Me.Label82.Visible = False
        Me.DropDownList1.Visible = False
        Me.cboAnio.Enabled = True
        Me.cboMes.Enabled = True
        Me.b1.Enabled = True
        Me.b2.Enabled = False
        Me.gvLista.Visible = False
        Me.gvLista.DataSource = Nothing
        Me.gvLista.DataBind()
        Me.btnCobertura.Visible = False
        btGuardar.Visible = True
        pNavegacion.Visible = False
        Me.Button32.Visible = False
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim cComponente As New cCONSUMOS

        'al eliminar un registro del gridview
        Dim IDESTABLECIMIENTO As Integer = Session.Item("IdEstablecimiento")
        Dim IDALMACEN As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(1)
        Dim FECHACONSUMO As Date = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex, 1)

        If cComponente.eliminarConsumo(IDESTABLECIMIENTO, IDALMACEN, IDPRODUCTO, FECHACONSUMO) < 0 Then
            'Me.MsgBox1.ShowAlert("Error al eliminar el registro.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Alert("Error al eliminar el registro.", "Error")

            Exit Sub
        End If

        Call CargarDatos()

    End Sub


    Protected Sub btnReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim alerta As String

        If Me.DropDownList1.SelectedIndex = 0 Then
            alerta = CType(("/Reportes/frmRptConsumo.aspx?mes=" & Me.cboMes.SelectedIndex & "&anio=" & Me.cboAnio.SelectedItem.Text & "&tipo=" & Me.ViewState("FARMACIA") & "&est=" & Me.cboAlmacen.SelectedItem.Value & "&idprog=0"), String)
        Else
            alerta = CType(("/Reportes/frmRptConsumo.aspx?mes=" & Me.cboMes.SelectedIndex & "&anio=" & Me.cboAnio.SelectedItem.Text & "&tipo=" & Me.ViewState("FARMACIA") & "&est=" & Me.cboAlmacen.SelectedItem.Value & "&idprog=" & Me.DropDownList1.SelectedValue.ToString), String)
        End If

        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub


    Protected Sub btnConsA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsA.Click

        If Me.cboAlmacen.SelectedIndex = 0 Then Exit Sub


        If Me.cboAlmacen.SelectedIndex = 1 Then
            FARMACIA = -1

        Else
            Dim cEntidad As New cALMACENES
            Dim ds As Data.DataSet = cEntidad.FiltroAlmacenPorId(Me.cboAlmacen.SelectedItem.Value)

            If ds Is Nothing Then Exit Sub
            If ds.Tables(0).Rows.Count = 0 Then Exit Sub

            FARMACIA = ds.Tables(0).Rows(0).Item("ESFARMACIA")

        End If

        Me.cboAlmacen.Enabled = False
        Me.btnConsA.Enabled = False
        Me.btnCancA.Enabled = True

        Me.cboAnio.Enabled = True
        Me.cboMes.Enabled = True
        Me.b1.Enabled = True

    End Sub

    Protected Sub btnCancA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancA.Click

        Call b2_Click(sender, e)

        Me.cboAlmacen.Enabled = True
        Me.cboAlmacen.SelectedIndex = 0

        Me.btnConsA.Enabled = True
        Me.btnCancA.Enabled = False

        Me.cboAnio.SelectedIndex = 0
        Me.cboMes.SelectedIndex = 0

        Me.cboAnio.Enabled = False
        Me.cboMes.Enabled = False
        Me.b1.Enabled = False
        Me.b2.Enabled = False
        btGuardar.Visible = True
        pNavegacion.Visible = False

    End Sub

    Protected Sub btnCobertura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCobertura.Click
        Dim alerta As String

        alerta = CType(("/Reportes/frmRptConsumo.aspx?mes=" & Me.cboMes.SelectedIndex & "&anio=" & Me.cboAnio.SelectedItem.Text & "&tipo=" & Me.ViewState("FARMACIA") & "&est=" & Me.cboAlmacen.SelectedItem.Value & "&c=1"), String)

        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    'icono en el grid que lanza la ventana emergente de ajuste de existencia
    Protected Sub ImageButton2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim btnDetails As ImageButton = sender

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Me.lblIdEstablecimiento2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(0)
        Me.lblIdProducto2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(1)
        'campo de existencia
        Me.lblConsumo2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(4) 'existencia
        Me.lblUM2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(2)
        Me.lblProd2.Text = Me.gvLista.DataKeys(row.RowIndex).Values(6)

        Me.NumericBox11.Text = ""
        Me.TextBox1.Text = ""

        Me.NumericBox11.RealNumber = IIf(Me.gvLista.DataKeys(row.RowIndex).Values(2) = "CTO", True, False)

        Me.UpdatePanel11.Update()
        Me.ModalPopupExtender11.Show()
    End Sub

    'Boton guardar de ventana emergente de ajuste de existencia
    Protected Sub Button21_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim fecha1 = New Date(Me.cboAnio.SelectedItem.Text, Me.cboMes.SelectedIndex, 1)

        If Me.NumericBox11.Text.Trim = "" Then
            Me.lblError2.Text = "Debe ingresar un valor al ajuste de existencia"
            Exit Sub
        End If

        If Me.NumericBox11.Text = 0 Then
            Me.lblError2.Text = "El ajuste de existencia no puede ser igual a cero"
            Exit Sub
        End If

        If Me.TextBox1.Text.Trim = "" Then
            Me.lblError2.Text = "Debe ingresar un motivo del ajuste"
            Exit Sub
        End If

        'SCMS: De aqui para abajo iniciar proceso de guardar la existencia ajustada

        Dim ExistenciaAjustada As Decimal = CDbl(Me.NumericBox11.Text)

        If Me.lblUM2.Text <> "CTO" Then
            ExistenciaAjustada = Math.Ceiling(ExistenciaAjustada)
        Else
            ExistenciaAjustada = Math.Round(ExistenciaAjustada, 2)
        End If


        Dim mdb As New cCONSUMOS
        Dim eEntidad As New CONSUMOS

        eEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        ' eEntidad.DEMANDAINSATISFECHA = Me.txtDemandaIns.Text
        ' eEntidad.DIASDESABASTECIDOS = 0
        eEntidad.IDALMACEN = Me.cboAlmacen.SelectedValue
        eEntidad.IDPRODUCTO = Me.lblIdProducto2.Text
        eEntidad.FECHACONSUMO = fecha1
        eEntidad.EXISTENCIA = CDec(lblConsumo2.Text) + ExistenciaAjustada
        ' eEntidad.motivoexistenciaajustada = Me.TextBox1.Text
        eEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eEntidad.AUFECHAMODIFICACION = Now

        If mdb.ajustarExistencia(eEntidad) = -1 Then
            ' Me.MsgBox1.ShowAlert("Error al almacenar los datos", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Alert("Error al almacenar los datos", "Error")
            Exit Sub
        Else
            mdb.IngresarMotivoExistenciaAjustada(Session.Item("IdEstablecimiento"), Me.cboAlmacen.SelectedValue, Me.lblIdProducto2.Text, fecha1, ExistenciaAjustada, Me.TextBox1.Text)

        End If

        Me.ModalPopupExtender11.Hide()
        Call CargarDatos()
        Me.UpdatePanel11.Update()

    End Sub
    'Boton cancelar de ventana emergente existencia ajustada
    Protected Sub Button31_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.ModalPopupExtender11.Hide()

    End Sub


    Protected Sub Button32_Click(sender As Object, e As System.EventArgs) Handles Button32.Click
        Dim alerta As String

        ' If Me.DropDownList1.SelectedIndex = 0 Then
        alerta = CType(("/Reportes/FrmRptConsumoAjusteExistencia.aspx?mes=" & Me.cboMes.SelectedIndex & "&anio=" & Me.cboAnio.SelectedItem.Text & "&tipo=" & Me.ViewState("FARMACIA") & "&est=" & Me.cboAlmacen.SelectedItem.Value & "&idprog=0"), String)
        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub
End Class
