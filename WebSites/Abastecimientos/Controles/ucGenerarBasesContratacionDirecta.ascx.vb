Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.IO

Partial Class Controles_ucGenerarBasesContratacionDirecta
    Inherits System.Web.UI.UserControl

    Friend Shared IDPROCESOCOMPRA As Integer
    Friend Shared IDPLANTILLA As Integer
    Friend Shared CODIGOFUENTE As String
    Friend Shared modo As String = "NEW"
    Friend Shared idPlantillaSel As Integer
    Friend Shared TituloLibreGestion, codigoLibreGestion As String

    Public Property _IDPROCESOCOMPRA() As Integer
        Get
            Return IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Integer)
            IDPROCESOCOMPRA = value
        End Set
    End Property

    Public Property _IDPLANTILLA() As Integer
        Get
            Return IDPLANTILLA
        End Get
        Set(ByVal value As Integer)
            IDPLANTILLA = value
        End Set
    End Property

    Public Property _IDMODALIDADCOMPRA() As Integer
        Get
            Return Me.ViewState("IDMODALIDADCOMPRA")
        End Get
        Set(ByVal value As Integer)
            Me.ViewState("IDMODALIDADCOMPRA") = value
        End Set
    End Property

    Public Property _CODIGOFUENTE() As String
        Get
            Return CODIGOFUENTE
        End Get
        Set(ByVal value As String)
            CODIGOFUENTE = value
        End Set
    End Property

    Public Sub ActivarPaso1()
        If Not IsPostBack Then
            Me.pnlPaso1.Visible = True
        End If
    End Sub

    Public Sub CargaDatos()
        obtenerPlantillas()
        idPlantillaSel = IDPLANTILLA
        If Not IsPostBack Then
            Me.DdlESTABLECIMIENTOS1.Recuperar()
            'Me.ddlIDTITULAR.RecuperarNombreCompleto()
            'Me.DdlMUNICIPIOS1.RecuperarNombreMunicipio()
            'Me.DdlMUNICIPIOS2.RecuperarNombreMunicipio()
            'obtenerCargoEmpleado()
            'obtenerDocLegFinJuridico()
            'obtenerDocLegFinNatural()
            'obtenerAspectoTecnico()
            'obtenerEvaluacionTecnica()
            'obtenerEvaluacionFinanciera()
            obtenerProductos()
            obtenerLugarPlazoEntrega()

        End If
    End Sub

    Private Sub obtenerPlantillas()
        Dim mComponente As New cPLANTILLAS
        'Me.DataGrid1.DataSource = mComponente.ObtenerLista()
        'Me.DataGrid1.DataBind()



        'dgLegalFinanNatural.DataSource = obtenerDocumentos(2)
        'dgLegalFinanNatural.DataBind()

        'Me.dgAspectoTecnico.DataSource = obtenerDocumentos(3)
        'Me.dgAspectoTecnico.DataBind()

    End Sub

    'Public Sub cargarDatos()
    '    Me.DdlESTABLECIMIENTOS1.Recuperar()
    '    Me.DdlESTABLECIMIENTOS1.SelectedValue = Session("IdEstablecimiento")
    '    obtenerProductos()
    'End Sub

    Private Sub obtenerLugarPlazoEntrega()

        Dim mComponente As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS
        Dim ds As Data.DataSet
        Dim i As Integer
        Dim dsDetalle As Data.DataSet
        Dim pn As New Panel
        Dim dg As New DataGrid

        ds = mComponente.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, Session("IdEstablecimiento"))

        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count
                dsDetalle = mComponente.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, Session("IdEstablecimiento"), i)
                If dsDetalle.Tables(0).Rows.Count > 0 Then
                    pn = pnlPaso3.FindControl("pnlE" & i)
                    pn.Visible = True
                    dg = pn.FindControl("dg" & i)
                    dg.DataSource = dsDetalle
                    dg.DataBind()
                End If
            Next
        End If
    End Sub

    Private Sub obtenerDatosPlantilla()
        Dim mComponente As New cPLANTILLAPROCESOCOMPRA
        Dim ds As Data.DataSet
        ds = mComponente.ObtenerDataSetPorId(Session("idEstablecimiento"), IDPROCESOCOMPRA, IDPLANTILLA)

        If ds.Tables(0).Rows.Count > 0 Then
            modo = "EDIT"
            cargarDatos()
        Else
            modo = "NEW"
        End If
    End Sub

    Public Sub cargarDatos()
        Me.DdlESTABLECIMIENTOS1.Recuperar()
        Me.DdlESTABLECIMIENTOS1.SelectedValue = Session("IdEstablecimiento")

        modo = Request.QueryString("mod")

        If Not IsPostBack Then
            buscarDireccionMunicipio()
            If modo = "EDIT" Then
                ObtenerDatos()
            Else
                buscarPrefijoBase()
            End If
            obtenerProductos()
            obtenerLugarPlazoEntrega()
        End If

    End Sub

    Private Sub ObtenerDatos()
        Dim mComponente As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS
        Dim ds As Data.DataSet

        With lEntidad
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
        End With

        ds = mComponente.recuperarDatosProcesoCompra(lEntidad)

        With ds.Tables(0).Rows(0)
            Me.txtCODIGOLICITACION.Text = .Item("CODIGOLICITACION")
            Me.txtTITULOLICITACION.Text = .Item("TITULOLICITACION").ToString
            Me.txtDESCRIPCIONLICITACION.Text = .Item("DESCRIPCIONLICITACION").ToString

            Try
                Me.txtTiempoEntrega.Text = .Item("TIEMPOENTREGA")
            Catch ex As Exception
                Me.txtTiempoEntrega.Text = ""
            End Try


            Try
                Me.txtFechaInicioRetiroBases.SelectedDate = CStr(Format(.Item("FECHAHORAINICIORETIRO"), "dd/MM/yyyy"))
            Catch ex As Exception
                Me.txtFechaInicioRetiroBases.SelectedDate = CStr(Format(Date.Now, "dd/MM/yyyy"))
            End Try
            Try
                Me.txtHoraInicioRetiroBases.SelectedTime = Format(.Item("FECHAHORAINICIORETIRO"), "HH:mm")
            Catch ex As Exception
                Me.txtHoraInicioRetiroBases.SelectedTime = CStr(Format(Date.Now, "HH:mm"))
            End Try
            Try
                Me.txtFechaFinRetiroBases.SelectedDate = Format(.Item("FECHAHORAFINRETIRO"), "dd/MM/yyyy")
            Catch ex As Exception
                Me.txtFechaFinRetiroBases.SelectedDate = Format(Date.Now, "dd/MM/yyyy")
            End Try
            Try
                Me.txtHoraFinRetiroBases.SelectedTime = Format(.Item("FECHAHORAFINRETIRO"), "HH:mm")
            Catch ex As Exception
                Me.txtHoraFinRetiroBases.SelectedTime = Format(Date.Now, "dd/MM/yyyy")
            End Try



            Try
                Me.txtFECHAINICIORECEPCION.SelectedDate = CStr(Format(.Item("FECHAHORAINICIORECEPCION"), "dd/MM/yyyy"))
            Catch ex As Exception
                Me.txtFECHAINICIORECEPCION.SelectedDate = CStr(Format(Date.Now, "dd/MM/yyyy"))
            End Try
            Try
                Me.txtHORAINICIORECEPCION.SelectedTime = Format(.Item("FECHAHORAINICIORECEPCION"), "HH:mm")
            Catch ex As Exception
                Me.txtHORAINICIORECEPCION.SelectedTime = CStr(Format(Date.Now, "HH:mm"))
            End Try
            Try
                Me.txtFECHAFINRECEPCION.SelectedDate = Format(.Item("FECHAHORAFINRECEPCION"), "dd/MM/yyyy")
            Catch ex As Exception
                Me.txtFECHAFINRECEPCION.SelectedDate = Format(Date.Now, "dd/MM/yyyy")
            End Try
            Try
                Me.txtHORAFINRECEPCION.SelectedTime = Format(.Item("FECHAHORAFINRECEPCION"), "HH:mm")
            Catch ex As Exception
                Me.txtHORAFINRECEPCION.SelectedTime = Format(Date.Now, "dd/MM/yyyy")
            End Try


            Try
                Me.txtFechaInicioRetiroBases.SelectedDate = Format(.Item("FECHAHORAINICIOAPERTURA"), "dd/MM/yyyy")
            Catch ex As Exception
                txtFECHAINICIOAPERTURA.SelectedDate = Format(Date.Now, "dd/MM/yyyy")
            End Try
            Try
                txtHORAINICIOAPERTURA.SelectedTime = Format(.Item("FECHAHORAINICIOAPERTURA"), "HH:mm")
            Catch ex As Exception
                txtHORAINICIOAPERTURA.SelectedTime = "0:00"
            End Try

            Try
                txtFECHAFINAPERTURA.SelectedDate = Format(.Item("FECHAHORAFINAPERTURA"), "dd/MM/yyyy")
            Catch ex As Exception
                txtFECHAFINAPERTURA.SelectedDate = Format(Date.Now, "dd/MM/yyyy")
            End Try
            Try
                txtHORAFINAPERTURA.SelectedTime = Format(.Item("FECHAHORAFINAPERTURA"), "HH:mm")
            Catch ex As Exception
                txtHORAFINAPERTURA.SelectedTime = "0:00"
            End Try



            Try
                txtFECHAINICIOAPERTURA.SelectedDate = Format(.Item("FECHAHORAINICIOAPERTURA"), "dd/MM/yyyy")
            Catch ex As Exception
                txtFECHAINICIOAPERTURA.SelectedDate = Format(Date.Now, "dd/MM/yyyy")
            End Try
            Try
                txtHORAINICIOAPERTURA.SelectedTime = Format(.Item("FECHAHORAINICIOAPERTURA"), "HH:mm")
            Catch ex As Exception
                txtHORAINICIOAPERTURA.SelectedTime = "0:00"
            End Try

            Try
                txtFECHAFINAPERTURA.SelectedDate = Format(.Item("FECHAHORAFINAPERTURA"), "dd/MM/yyyy")
            Catch ex As Exception
                txtFECHAFINAPERTURA.SelectedDate = Format(Date.Now, "dd/MM/yyyy")
            End Try
            Try
                txtHORAFINAPERTURA.SelectedTime = Format(.Item("FECHAHORAFINAPERTURA"), "HH:mm")
            Catch ex As Exception
                txtHORAFINAPERTURA.SelectedTime = "0:00"
            End Try

            Try
                Me.txtFechaInicioConsultasAclaraciones.SelectedDate = Format(.Item("FECHAINICIOACLARACIONES"), "dd/MM/yyyy")
            Catch ex As Exception
                Me.txtFechaInicioConsultasAclaraciones.SelectedDate = Format(Date.Now, "dd/MM/yyyy")
            End Try

            Try
                Me.TimePicker1.SelectedTime = Format(.Item("FECHAINICIOACLARACIONES"), "HH:mm")
            Catch ex As Exception
                TimePicker1.SelectedTime = "0:00"
            End Try

            Try
                Me.txtFechaFinConsultasAclaraciones.SelectedDate = Format(.Item("FECHAFINACLARACIONES"), "dd/MM/yyyy")
            Catch ex As Exception
                Me.txtFechaFinConsultasAclaraciones.SelectedDate = Format(Date.Now, "dd/MM/yyyy")
            End Try

            Try
                TimePicker2.SelectedTime = Format(.Item("FECHAFINACLARACIONES"), "HH:mm")
            Catch ex As Exception
                TimePicker2.SelectedTime = "0:00"
            End Try

            Try
                Me.txtGARANTIACUMPLIMIENTOVIGENCIA.Text = .Item("VIGENCIACOTIZACION")
            Catch ex As Exception

            End Try
            Try
                Me.txtGARANTIACALIDADVALOR.Text = .Item("GARANTIACALIDADVALOR")
            Catch ex As Exception

            End Try

            Try
                txtGarantiaCumplimientoOrdenCompra.Text = .Item("GARANTIACUMPLIMIENTOORDENCOMPRA")
            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub buscarDireccionMunicipio()

        Dim mComponente As New cESTABLECIMIENTOS

        Dim ds As Data.DataSet
        ds = mComponente.ObtenerUbicacionEstablecimiento(Me.DdlESTABLECIMIENTOS1.SelectedValue)

        Me.lblUACI.Text = ds.Tables(0).Rows(0).Item("DIRECCION")
        Me.lblMunicipio.Text = ds.Tables(0).Rows(0).Item("NOMBRE")

    End Sub

    Private Sub buscarPrefijoBase()
        Dim mComTipoCompra As New cTIPOCOMPRAS

        Me.txtCODIGOLICITACION.Text = mComTipoCompra.obtenerTipoCompraxMODALIDAD(Me.ViewState("IDMODALIDADCOMPRA")).Tables(0).Rows(0).Item("PREFIJOBASE")
        Me.lblPrefijoBase.Text = Me.txtCODIGOLICITACION.Text
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

        Dim inicioRetiroBase, finRetiraBase As String

        Dim hayError As Boolean = False

        inicioRetiroBase = Format(txtFechaInicioRetiroBases.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHoraInicioRetiroBases.SelectedTime, "HH:mm")
        If CDate(inicioRetiroBase) < Date.Today Then
            RequiredFieldValidator6.ErrorMessage = "Debe ser mayor que la actual"
            RequiredFieldValidator6.IsValid = False
            hayError = True
        End If

        finRetiraBase = Format(Me.txtFechaFinRetiroBases.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHoraFinRetiroBases.SelectedTime, "HH:mm")

        If CDate(finRetiraBase) < Date.Today Then
            RequiredFieldValidator10.ErrorMessage = "Debe ser mayor que la actual"
            RequiredFieldValidator10.IsValid = False
            hayError = True
        ElseIf CDate(finRetiraBase) < CDate(inicioRetiroBase) Then
            RequiredFieldValidator10.ErrorMessage = "La fecha debe ser mayor que la fecha de inicio de retiro"
            RequiredFieldValidator10.IsValid = False
            hayError = True
        ElseIf CDate(finRetiraBase) = CDate(inicioRetiroBase) Then
            If CDate(txtHoraInicioRetiroBases.SelectedTime) >= CDate(txtHoraFinRetiroBases.SelectedTime) Then
                RequiredFieldValidator10.ErrorMessage = "La fecha debe ser mayor que la fecha de inicio de retiro"
                RequiredFieldValidator10.IsValid = False
                hayError = True
            End If
        Else
            hayError = False
        End If


        hayError = validacionFechasRecepcion(hayError)

        hayError = validaFechasApertura(hayError)

        hayError = validarFechasConsultas(hayError)

        hayError = False
        If hayError = False Then
            Me.pnlPaso1.Visible = False
            Me.pnlPaso2.Visible = True
        End If


        'Me.pnlPaso1.Visible = False
        'Me.pnlPaso2.Visible = True
    End Sub

    Private Function validarFechasConsultas(ByVal hayError As Boolean) As Boolean
        'Dim hayError As Boolean = False

        Dim fechaInicioConsultas As String
        Dim fechaFinConsultas As String
        Dim fechaInicioEntrega As String
        Dim fechaFinEntrega As String


        fechaInicioConsultas = Format(Me.txtFechaInicioConsultasAclaraciones.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.TimePicker1.SelectedTime, "HH:mm")
        fechaFinConsultas = Format(Me.txtFechaFinConsultasAclaraciones.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.TimePicker2.SelectedTime, "HH:mm")

        fechaInicioEntrega = Format(Me.txtFechaInicioRetiroBases.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHoraInicioRetiroBases.SelectedTime, "HH:mm")
        fechaFinEntrega = Format(Me.txtFechaFinRetiroBases.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHoraFinRetiroBases.SelectedTime, "HH:mm")


        If CDate(fechaInicioConsultas) < CDate(fechaInicioEntrega) Then
            RequiredFieldValidator11.ErrorMessage = "La fecha y hora deben ser mayores que la fecha de inicio de entrega de bases"
            RequiredFieldValidator11.IsValid = False
            hayError = True
        End If

        If CDate(fechaFinConsultas) > CDate(fechaFinEntrega) Then
            RequiredFieldValidator12.ErrorMessage = "La fecha y hora deben ser menores que la fecha de fin de entrega de bases"
            RequiredFieldValidator12.IsValid = False
            hayError = True
        End If

        If CDate(fechaInicioConsultas) > CDate(fechaFinEntrega) Then
            RequiredFieldValidator11.ErrorMessage = "La fecha y hora deben ser menores que la fecha de fin de entrega de bases"
            RequiredFieldValidator11.IsValid = False
            hayError = True
        End If

        If CDate(fechaFinConsultas) > CDate(fechaFinEntrega) Then
            RequiredFieldValidator12.ErrorMessage = "La fecha y hora deben ser mayores que la fecha de inicio de entrega de bases"
            RequiredFieldValidator12.IsValid = False
            hayError = True
        End If

        If CDate(fechaInicioConsultas) < CDate(fechaInicioEntrega) Then
            RequiredFieldValidator11.ErrorMessage = "La fecha y hora deben ser mayores que la fecha de inicio de entrega de bases"
            RequiredFieldValidator11.IsValid = False
            hayError = True
        End If

        If txtFechaInicioConsultasAclaraciones.SelectedDate < Me.txtFECHAFINRECEPCION.SelectedDate Then
            RequiredFieldValidator11.ErrorMessage = "La fecha debe ser mayor que la fecha de fin de presentación"
            RequiredFieldValidator11.IsValid = False
            hayError = True
        End If

        If CDate(fechaFinConsultas) < CDate(fechaInicioConsultas) Then
            RequiredFieldValidator12.ErrorMessage = "La fecha y hora deben ser mayores que la fecha de inicio de consulta"
            RequiredFieldValidator12.IsValid = False
            hayError = True
        End If


        Return hayError


    End Function

    Private Function validacionFechasRecepcion(ByVal hayError As Boolean) As Boolean

        'Dim hayError As Boolean = False


        Dim fechaInicioRecepcion As String
        Dim fechaFinRecepcion As String
        Dim fechaFinEntrega As String


        fechaInicioRecepcion = Format(Me.txtFECHAINICIORECEPCION.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHORAINICIORECEPCION.SelectedTime, "HH:mm")
        fechaFinRecepcion = Format(Me.txtFECHAFINRECEPCION.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHORAFINRECEPCION.SelectedTime, "HH:mm")

        fechaFinEntrega = Format(Me.txtFechaFinRetiroBases.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHoraFinRetiroBases.SelectedTime, "HH:mm")




        If fechaInicioRecepcion < Date.Now Then
            RequiredFieldValidator13.ErrorMessage = "La fecha y hora debe ser mayor que la actual"
            RequiredFieldValidator13.IsValid = False
            hayError = True
        End If

        If fechaFinRecepcion < Date.Now Then
            RequiredFieldValidator14.ErrorMessage = "La fecha y hora debe ser mayor que la actual"
            RequiredFieldValidator14.IsValid = False
            hayError = True
        End If

        If Me.txtFECHAINICIORECEPCION.SelectedDate > Date.Today.AddDays(30) Then
            RequiredFieldValidator13.ErrorMessage = "Advertencia: La fecha debe ser menor a 30 días"
            RequiredFieldValidator13.IsValid = False
        End If

        If CDate(fechaFinRecepcion) < fechaInicioRecepcion Then
            RequiredFieldValidator14.ErrorMessage = "La fecha y hora debe ser mayor que la de inicio de recepción"
            RequiredFieldValidator14.IsValid = False
            hayError = True
        End If
        If CDate(Me.txtFECHAFINRECEPCION.SelectedDate) = Me.txtFECHAINICIORECEPCION.SelectedDate Then
            If Me.txtHORAINICIORECEPCION.SelectedTime >= Me.txtHORAFINRECEPCION.SelectedTime Then
                RequiredFieldValidator14.ErrorMessage = "La hora debe ser mayor que la de inicio de recepción"
                RequiredFieldValidator14.IsValid = False
                hayError = True
            End If
        End If

        If CDate(fechaInicioRecepcion) < CDate(fechaFinEntrega) Then
            RequiredFieldValidator13.ErrorMessage = "La fecha y hora de inicio debe ser mayor que la fecha y hora de fin de recepcion de ofertas"
            RequiredFieldValidator13.IsValid = False
            hayError = True
        End If


        Return hayError




    End Function

    Private Function validaFechasApertura(ByVal hayError As Boolean) As Boolean

        'Dim hayError As Boolean = False

        If Me.txtFECHAINICIOAPERTURA.SelectedDate < Me.txtFECHAFINRECEPCION.SelectedDate Then
            RequiredFieldValidator15.ErrorMessage = "La fecha debe ser mayor que la fecha de fin de retiro de ofertas"
            RequiredFieldValidator15.IsValid = False
            hayError = True
        End If

        If Me.txtFECHAINICIOAPERTURA.SelectedDate = Me.txtFECHAFINRECEPCION.SelectedDate Then
            If Me.txtHORAINICIOAPERTURA.SelectedTime <= Me.txtHORAFINRECEPCION.SelectedTime Then
                RequiredFieldValidator15.ErrorMessage = "La hora de inicio de apertura debe ser mayor que la hora de fin de retiro de ofertas"
                RequiredFieldValidator15.IsValid = False
                hayError = True
            End If

        End If

        If Me.txtFECHAFINAPERTURA.SelectedDate < Date.Today Then
            RequiredFieldValidator16.ErrorMessage = "La fecha debe ser mayor que la fecha de fin de retiro de ofertas"
            RequiredFieldValidator16.IsValid = False
            hayError = True
        End If

        If CDate(Me.txtFECHAFINAPERTURA.SelectedDate) < Me.txtFECHAINICIOAPERTURA.SelectedDate Then
            RequiredFieldValidator16.ErrorMessage = "La fecha debe ser mayor o igual que la de inicio de apertura"
            RequiredFieldValidator16.IsValid = False
            hayError = True
        End If
        If CDate(Me.txtFECHAFINAPERTURA.SelectedDate) = Me.txtFECHAINICIOAPERTURA.SelectedDate Then
            If Me.txtHORAINICIOAPERTURA.SelectedTime >= Me.txtHORAFINAPERTURA.SelectedTime Then
                RequiredFieldValidator16.ErrorMessage = "La hora debe ser mayor que la de inicio de apertura"
                RequiredFieldValidator16.IsValid = False
                hayError = True
            End If
        End If


        Return hayError
    End Function

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        Me.pnlPaso2.Visible = False
        Me.pnlPaso1.Visible = True
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Me.pnlPaso2.Visible = False
        Me.pnlPaso3.Visible = True
    End Sub

    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
        Me.pnlPaso2.Visible = True
        Me.pnlPaso3.Visible = False
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Me.pnlPaso3.Visible = False
        Me.pnlPaso5.Visible = True
    End Sub

    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click
        Me.pnlPaso3.Visible = True
        Me.pnlPaso5.Visible = False
    End Sub

    Private Sub obtenerProductos()
        Dim mComponente As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS
        Me.dgDetalleProductos.DataSource = mComponente.obtenerDetalleProductos(IDPROCESOCOMPRA, Session("IdEstablecimiento"))
        Me.dgDetalleProductos.DataBind()
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        guardarProcesoCompra()
    End Sub

    Private Sub guardarProcesoCompra()
        Dim mComponente As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS
        With lEntidad

            .IDENTIDADSOLICITA = Me.DdlESTABLECIMIENTOS1.SelectedValue
            .FECHAHORAINICIORETIRO = Format(Me.txtFechaInicioRetiroBases.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHoraInicioRetiroBases.SelectedTime, "HH:mm")
            .FECHAHORAFINRETIRO = Format(Me.txtFechaFinRetiroBases.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHoraFinRetiroBases.SelectedTime, "HH:mm")
            .FECHAINICIOACLARACIONES = Format(Me.txtFechaInicioConsultasAclaraciones.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.TimePicker1.SelectedTime, "HH:mm")
            .FECHAFINACLARACIONES = Format(Me.txtFechaFinConsultasAclaraciones.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.TimePicker2.SelectedTime, "HH:mm")
            .FECHAHORAINICIORECEPCION = Format(Me.txtFECHAINICIORECEPCION.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHORAINICIORECEPCION.SelectedTime, "HH:mm")
            .FECHAHORAFINRECEPCION = Format(Me.txtFECHAFINRECEPCION.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHORAFINRECEPCION.SelectedTime, "HH:mm")
            .FECHAHORAINICIOAPERTURA = Format(Me.txtFECHAINICIOAPERTURA.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHORAINICIOAPERTURA.SelectedTime, "HH:mm")
            .FECHAHORAFINAPERTURA = Format(Me.txtFECHAFINAPERTURA.SelectedDate, "dd/MM/yyyy") & " " & Format(Me.txtHORAFINAPERTURA.SelectedTime, "HH:mm")


            .CODIGOLICITACION = Me.txtCODIGOLICITACION.Text
            .TITULOLICITACION = Me.txtTITULOLICITACION.Text
            .DESCRIPCIONLICITACION = Me.txtDESCRIPCIONLICITACION.Text
            .IDESTADOPROCESOCOMPRA = 1
            .FECHAELABORACIONBASE = Date.Now
            .VIGENCIACOTIZACION = Me.txtGARANTIACUMPLIMIENTOVIGENCIA.Text
            .GARANTIACUMPLIMIENTOORDENCOMPRA = Me.txtGarantiaCumplimientoOrdenCompra.Text

            Dim garantiaCalidadV As Decimal

            If Not IsNumeric(Me.txtGARANTIACALIDADVALOR.Text) Then
                garantiaCalidadV = 0
            Else
                garantiaCalidadV = CDec(Me.txtGARANTIACALIDADVALOR.Text)
            End If

            .GARANTIACALIDADVALOR = garantiaCalidadV

            .TIEMPOENTREGA = CInt(txtTiempoEntrega.Text)
            '.GARANTIACALIDADVALOR = Me.txtGARANTIACALIDADVALOR.Text
            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .ESTASINCRONIZADA = 0
            .AUFECHAMODIFICACION = Date.Now
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        End With
        mComponente.ActualizarValores_GenerarBasesLibreGestion(lEntidad)
    End Sub

    Protected Sub btnGeneraDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGeneraDocumento.Click
        generarDocumento()
        Me.btnContinuar.Visible = True
    End Sub

    Private Sub generarDocumento()
        Dim mComponente As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS
        Dim ds As Data.DataSet
        Dim i As Integer
        Dim mDocumento As New Text.StringBuilder

        'Dim codigoFuente As New Text.StringBuilder
        'codigoFuente.Append(codigoFuente) '

        mDocumento.Append(CODIGOFUENTE)

        With lEntidad
            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
        End With

        ds = mComponente.recuperarDatosProcesoCompra(lEntidad)

        ' TABLA: PROCESOCOMPRAS
        Dim mComponenteEtiqueta As New cETIQUETASCAMPOS
        Dim dsEtiqueta As Data.DataSet
        dsEtiqueta = mComponenteEtiqueta.ObtenerDataSetPorTABLA("PROCESOCOMPRAS_CD")

        For i = 0 To dsEtiqueta.Tables(0).Rows.Count - 1
            If mDocumento.ToString.IndexOf(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA")) > 0 Then
                If dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA") = "$TITULOLICITACION$" Then
                    TituloLibreGestion = ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO"))
                End If
                If dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA") = "$CODIGOLICITACION$" Then
                    codigoLibreGestion = ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO"))
                End If

                mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
                'mDocumento = Replace(mDocumento.ToString, dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
            End If
        Next

        ''TABLA: GARANTIABUENACALIDAD

        'dsEtiqueta = mComponenteEtiqueta.ObtenerDataSetPorTABLA("GARANTIABUENACALIDAD")



        'For i = 0 To dsEtiqueta.Tables(0).Rows.Count - 1
        '    If mDocumento.ToString.IndexOf(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA")) > 0 Then
        '        'mDocumento.Replace(mDocumento.ToString, dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
        '        mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
        '    End If
        'Next


        ''TABLA: GARANTIACUMPLIMIENTO

        'dsEtiqueta = mComponenteEtiqueta.ObtenerDataSetPorTABLA("GARANTIACUMPLIMIENTO")


        'For i = 0 To dsEtiqueta.Tables(0).Rows.Count - 1
        '    If mDocumento.ToString.IndexOf(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA")) > 0 Then
        '        'mDocumento = Replace(mDocumento, dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
        '        mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
        '    End If
        'Next

        ''TABLA: GARANTIAMANTTOOFERTA

        'dsEtiqueta = mComponenteEtiqueta.ObtenerDataSetPorTABLA("GARANTIAMANTTOOFERTA")



        'For i = 0 To dsEtiqueta.Tables(0).Rows.Count - 1
        '    If mDocumento.ToString.IndexOf(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA")) > 0 Then
        '        'mDocumento = Replace(mDocumento, dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
        '        mDocumento.Replace(dsEtiqueta.Tables(0).Rows(i).Item("ETIQUETA"), ds.Tables(0).Rows(0).Item(dsEtiqueta.Tables(0).Rows(i).Item("CAMPO")))
        '    End If
        'Next

        ''TABLA: CRITERIO OFERTA TECNICA

        'Dim mComponenteCriterio As New cCRITERIOPROCESOCOMPRA
        'Dim dsCriterio As New Data.DataSet
        'Dim tabla As New Text.StringBuilder

        'dsCriterio = mComponenteCriterio.ObtenerDataSetCriteriosProcesoCompra(Session("IdEstablecimiento"), IdProcesoCompra, 1)
        'tabla.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        'tabla.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        'tabla.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Criterio para oferta técnica</p></td>")
        'tabla.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Porcentaje evaluación</p></td></tr>")

        'If dsCriterio.Tables(0).Rows.Count > 0 Then
        '    For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
        '        tabla.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        '        tabla.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsCriterio.Tables(0).Rows(i).Item("DESCRIPCION") & "</p></td>")
        '        tabla.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsCriterio.Tables(0).Rows(i).Item("PORCENTAJE") & "</p></td></tr>")
        '    Next
        'End If
        'tabla.Append("</table>")

        ''mDocumento = Replace(mDocumento, "$CRITERIO_OFERTA_TECNICA$", tabla.ToString)
        'mDocumento.Replace("$CRITERIO_OFERTA_TECNICA$", tabla.ToString)


        ''TABLA: CRITERIO FINANCIERO

        ''Dim mComponenteCriterio As New cCRITERIOPROCESOCOMPRA
        ''Dim dsCriterio As New Data.DataSet
        'Dim tablaFinanciero As New Text.StringBuilder

        'dsCriterio = mComponenteCriterio.ObtenerDataSetCriteriosFinancieroProcesoCompra(Session("IdEstablecimiento"), IdProcesoCompra)
        'tablaFinanciero.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        'tablaFinanciero.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        'tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Indice de Solvencia</p></td>")
        'tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Capital de trabajo</p></td>")
        'tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Endeudamiento</p></td>")
        'tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Referencia Bancaria</p></td>")
        'tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Financiero</p></td></tr><tr>")


        'If dsCriterio.Tables(0).Rows.Count > 0 Then
        '    'For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
        '    tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsCriterio.Tables(0).Rows(0).Item("PORCENTAJEINDICESOLVENCIA") & "</p></td>")
        '    tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsCriterio.Tables(0).Rows(0).Item("PORCENTAJECAPITALTRABAJO") & "</p></td>")
        '    tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsCriterio.Tables(0).Rows(0).Item("PORCENTAJEENDEUDAMIENTO") & "</p></td>")
        '    tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsCriterio.Tables(0).Rows(0).Item("PORCENTAJEREFERENCIASBANC") & "</p></td>")
        '    tablaFinanciero.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsCriterio.Tables(0).Rows(0).Item("PORCENTAJEFINANCIERO") & "</p></td>")
        '    'Next
        'End If
        'tablaFinanciero.Append("</tr></table>")

        ''mDocumento = Replace(mDocumento, "$CRITERIO_ASPECTO_FINANCIERO$", tablaFinanciero.ToString)
        'mDocumento.Replace("$CRITERIO_ASPECTO_FINANCIERO$", tablaFinanciero.ToString)


        ''CRITERIOS 

        'Dim mComponenteCriterio As New cCRITERIOPROCESOCOMPRA
        'Dim dsCriterio As New Data.DataSet
        'Dim Etiqueta As String
        'Dim Porcentaje As Decimal
        'Dim dsEtiquetaCriterio As New Data.DataSet

        'dsCriterio = mComponenteCriterio.ObtenerDataSetCriteriosProcesoCompra(Session("IdEstablecimiento"), IdProcesoCompra, 3)

        'For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
        '    Etiqueta = mComponenteCriterio.EtiquetaCriterioTecnico("CRITERIO_LG", dsCriterio.Tables(0).Rows(i).Item("DESCRIPCION")).Tables(0).Rows(0).Item("ETIQUETA")
        '    Porcentaje = dsCriterio.Tables(0).Rows(i).Item("PORCENTAJE")
        '    mDocumento.Replace(Etiqueta, Porcentaje)
        'Next



        ''dsCriterio = mComponenteCriterio.ObtenerDataSetCriteriosFinancieroProcesoCompra(Session("IdEstablecimiento"), IdProcesoCompra)

        'With dsCriterio.Tables(0).Rows(0)
        '    mDocumento.Replace("$CAPITAL_TRABAJO$", .Item("PORCENTAJECAPITALTRABAJO"))
        '    mDocumento.Replace("$INDICE_ENDEUDAMIENTO$", .Item("PORCENTAJEENDEUDAMIENTO"))
        '    mDocumento.Replace("$INDICE_SOLVENCIA$", .Item("PORCENTAJEINDICESOLVENCIA"))
        '    mDocumento.Replace("$PORCENTAJE_GLOBAL_FINANCIERO$", .Item("PORCENTAJEFINANCIERO"))
        '    mDocumento.Replace("$REFERENCIAS_BANCARIAS$", .Item("PORCENTAJEREFERENCIASBANC"))
        'End With

        ''DOCUMENTOS LEGAL JURIDICO

        'Dim mComponenteDoc As New cDOCUMENTOSPROCESOSCOMPRA
        'Dim dsDocumento As New Data.DataSet
        'Dim tablaDocJuridico As New Text.StringBuilder

        'dsDocumento = mComponenteDoc.ObtenerDataSetPorTipoDocumento(Session("IdEstablecimiento"), IdProcesoCompra, 1)
        'If dsDocumento.Tables(0).Rows.Count > 0 Then


        '    tablaDocJuridico.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        '    tablaDocJuridico.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        '    tablaDocJuridico.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Documentación legal y financiera si es persona jurídica</p></td></tr>")


        '    If dsCriterio.Tables(0).Rows.Count > 0 Then


        '        For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
        '            tablaDocJuridico.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDocumento.Tables(0).Rows(i).Item("DESCRIPCION") & "</p></td></tr>")
        '        Next
        '    End If
        '    tablaDocJuridico.Append("</table>")

        '    'mDocumento = Replace(mDocumento, "$LISTA_DOCUMENTO_LEGAL_JURIDICA$", tablaDocJuridico.ToString)
        '    mDocumento.Replace("$LISTA_DOCUMENTO_LEGAL_JURIDICA$", tablaDocJuridico.ToString)


        'End If

        ''DOCUMENTOS LEGAL NATURAL


        'Dim tablaDocNatural As New Text.StringBuilder

        'dsDocumento = mComponenteDoc.ObtenerDataSetPorTipoDocumento(Session("IdEstablecimiento"), IdProcesoCompra, 2)
        'If dsDocumento.Tables(0).Rows.Count > 0 Then


        '    tablaDocNatural.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        '    tablaDocNatural.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        '    tablaDocNatural.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Documentación legal y financiera si es persona natural</p></td></tr>")


        '    If dsCriterio.Tables(0).Rows.Count > 0 Then


        '        For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
        '            tablaDocNatural.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDocumento.Tables(0).Rows(i).Item("DESCRIPCION") & "</p></td></tr>")
        '        Next
        '    End If
        '    tablaDocNatural.Append("</table>")


        '    'tablaDocNatural.Append("<table><tr><td>Documentación legal y financiera si es persona natural</td></tr>")

        '    'If dsCriterio.Tables(0).Rows.Count > 0 Then


        '    '    For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
        '    '        tablaDocNatural.Append("<tr><td>" & dsDocumento.Tables(0).Rows(i).Item("DESCRIPCION") & "</td></tr>")
        '    '    Next
        '    'End If
        '    'tablaDocNatural.Append("</tabla>")

        '    'mDocumento = Replace(mDocumento, "$LISTA_DOCUMENTO_LEGAL_NATURAL$", tablaDocNatural.ToString)
        '    mDocumento.Replace("$LISTA_DOCUMENTO_LEGAL_NATURAL$", tablaDocNatural.ToString)


        'End If

        ''DOCUMENTOS ASPECTO TECNICO

        'Dim tablaDocTecnico As New Text.StringBuilder

        'dsDocumento = mComponenteDoc.ObtenerDataSetPorTipoDocumento(Session("IdEstablecimiento"), IdProcesoCompra, 3)
        'If dsDocumento.Tables(0).Rows.Count > 0 Then


        '    tablaDocTecnico.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        '    tablaDocTecnico.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        '    tablaDocTecnico.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Documentación a solicitar de aspecto técnico</p></td></tr>")


        '    If dsCriterio.Tables(0).Rows.Count > 0 Then


        '        For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
        '            tablaDocTecnico.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDocumento.Tables(0).Rows(i).Item("DESCRIPCION") & "</p></td></tr>")
        '        Next
        '    End If
        '    tablaDocTecnico.Append("</table>")

        '    'tablaDocTecnico.Append("<table><tr><td>Documentación a solicitar de aspecto técnico</td></tr>")
        '    'If dsCriterio.Tables(0).Rows.Count > 0 Then
        '    '    For i = 0 To dsCriterio.Tables(0).Rows.Count - 1
        '    '        tablaDocTecnico.Append("<tr><td>" & dsDocumento.Tables(0).Rows(i).Item("DESCRIPCION") & "</td></tr>")
        '    '    Next
        '    'End If
        '    'tablaDocTecnico.Append("</tabla>")

        '    'mDocumento = Replace(mDocumento, "$LISTA_DOCUMENTOS_ASPECTO_TECNICO$", tablaDocTecnico.ToString)
        '    mDocumento.Replace("$LISTA_DOCUMENTOS_ASPECTO_TECNICO$", tablaDocTecnico.ToString)


        'End If

        'PROGRAMA DE DISTRIBUCION

        Dim mComponentePC As New cPROCESOCOMPRAS
        Dim dsPD As Data.DataSet
        Dim tablaPD As New StringBuilder
        'Dim i As Integer

        dsPD = mComponentePC.obtenerProgramaDistribucion(Session("IdEstablecimiento"), IDPROCESOCOMPRA, 1) 'Revisar la distribucion en lugar de 1 es IDRENGLON

        tablaPD.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
        tablaPD.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=2><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Programa de distribución de compra</P></TD></tr>")

        tablaPD.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Renglon</P></TD>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Almacen</P></TD>")
        tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Cantidad Solicitada</P></TD></TR>")


        For i = 0 To dsPD.Tables(0).Rows.Count - 1
            tablaPD.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item("RENGLON") & "</P></td>")
            tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item("ALMACEN") & "</P></td>")
            tablaPD.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsPD.Tables(0).Rows(i).Item("CANTIDADSOLICITADA") & "</P></td></tr>")
        Next

        tablaPD.Append("</table>")

        mDocumento.Replace("$PROGRAMA_DISTRIBUCION$", tablaPD.ToString)

        'PRODUCTOS

        Dim mComponenteProd As New cDETALLEPROCESOCOMPRA
        Dim dsProductos As Data.DataSet
        Dim tablaProducto As New Text.StringBuilder

        dsProductos = mComponenteProd.ObtenerDataListaProductos(IDPROCESOCOMPRA, Session("IdEstablecimiento"))
        If dsProductos.Tables(0).Rows.Count > 0 Then

            tablaProducto.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
            tablaProducto.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
            tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=6><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Detalle de Productos a solicitar</P></TD></tr>")

            tablaProducto.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Renglon</P></TD>")
            tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Código</P></TD>")
            tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Nombre</P></TD>")
            tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Especificaciones</P></TD>")
            tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Unidad de Medida</P></TD>")
            tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Cantidad</P></TD>")
            tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Entregas</P></TD></TR>")

            If dsProductos.Tables(0).Rows.Count > 0 Then

                For i = 0 To dsProductos.Tables(0).Rows.Count - 1
                    tablaProducto.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("RENGLON") & "</P></td>")
                    tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("CODIGO") & "</P></td>")
                    tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("NOMBRE") & "</P></td>")
                    tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("ESPECIFICACIONESTECNICAS") & "</P></td>")
                    tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("DESCRIPCION") & "</P></td>")
                    tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("CANTIDAD") & "</P></td>")
                    tablaProducto.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsProductos.Tables(0).Rows(i).Item("NUMEROENTREGAS") & "</P></td></tr>")
                Next
            End If
            tablaProducto.Append("</table>")

            'mDocumento = Replace(mDocumento, "$LISTADO_PRODUCTOS$", tablaProducto.ToString)
            mDocumento.Replace("$LISTADO_PRODUCTOS$", tablaProducto.ToString)


        End If

        'ENTREGAS
        Dim mComponenteEntregas As New cPROCESOCOMPRAS
        Dim lEntidadEntregas As New PROCESOCOMPRAS
        Dim dsEntregas As Data.DataSet
        Dim dsDetalleEntrega As Data.DataSet
        Dim tablaEntrega As New Text.StringBuilder
        Dim j As Integer

        dsEntregas = mComponenteEntregas.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, Session("IdEstablecimiento"))

        If dsEntregas.Tables(0).Rows.Count > 0 Then
            For i = 1 To dsEntregas.Tables(0).Rows.Count
                dsDetalleEntrega = mComponente.obtenerLugarPlazoEntrega(IDPROCESOCOMPRA, Session("IdEstablecimiento"), i)

                tablaEntrega.Append("<TABLE class=MsoTableGrid style='BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 480; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext' cellSpacing=0 cellPadding=0 border=1>")
                tablaEntrega.Append("<TR style='mso-yfti-irow: 0; mso-yfti-firstrow: yes'>")
                tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; BORDER-TOP: windowtext 1pt solid; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt' vAlign=top colspan=2><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Plazos y porcentajes de entrega de los productos para " & i & " entrega(s)</P></TD></tr>")

                tablaEntrega.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'>")
                tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Plazo</P></TD>")
                tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>Porcentaje</P></TD></TR>")

                If dsDetalleEntrega.Tables(0).Rows.Count > 0 Then
                    For j = 0 To dsDetalleEntrega.Tables(0).Rows.Count - 1
                        tablaEntrega.Append("<TR style='mso-yfti-irow: 1; mso-yfti-lastrow: yes'><TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDetalleEntrega.Tables(0).Rows(j).Item("DIAS") & "</P></td>")
                        tablaEntrega.Append("<TD style='BORDER-RIGHT: windowtext 1pt solid; PADDING-RIGHT: 5.4pt; PADDING-LEFT: 5.4pt; PADDING-BOTTOM: 0cm; BORDER-LEFT: windowtext 1pt solid; WIDTH: 216.1pt; BORDER-TOP-COLOR: #ece9d8; PADDING-TOP: 0cm; BORDER-BOTTOM: windowtext 1pt solid; BACKGROUND-COLOR: transparent; mso-border-alt: solid windowtext .5pt; mso-border-top-alt: solid windowtext .5pt' vAlign=top><P class=MsoNormal style='MARGIN: 0cm 0cm 0pt'>" & dsDetalleEntrega.Tables(0).Rows(j).Item("Porcentaje") & "</P></td></tr>")
                    Next
                End If
                tablaEntrega.Append("</table>")
            Next
        End If

        mDocumento.Replace("$PLAZOS_ENTREGAS$", tablaEntrega.ToString)
        mDocumento.Replace("<?xml:namespace prefix = o ns = " & Chr(34) & "urn:schemas-microsoft-com:office:office" & Chr(34) & " />", "")
        mDocumento.Replace("<DIV class=Section1><SPAN lang=ES-GT><o:p><FONT face=Tahoma size=3>&nbsp; ", "")
        mDocumento.Replace("<DIV class=Section1>", "")

        Dim directorio As String
        Dim Documento As String

        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & IDPROCESOCOMPRA

        codigoLibreGestion = Replace(codigoLibreGestion, "/", "-")
        codigoLibreGestion = Replace(codigoLibreGestion, " ", "_")

        Documento = "B" & codigoLibreGestion & ".htm"

        If File.Exists(Server.MapPath(directorio & "\BASES\" & Documento)) Then
            File.Delete(Server.MapPath(directorio & "\BASES\" & Documento))
            File.AppendAllText(Server.MapPath(directorio & "\BASES\" & Documento), "<html><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" & mDocumento.ToString & "</html>")
        Else
            Directory.CreateDirectory(Server.MapPath(directorio & "\BASES"))
            File.AppendAllText(Server.MapPath(directorio & "\BASES\" & Documento), "<html><meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" & mDocumento.ToString & "</html>")
        End If

        Me.lbBase.Visible = True
        Me.lblBaseGenerada.Visible = True

    End Sub

    Protected Sub lbBase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbBase.Click
        Dim openWindow As String

        Dim directorio As String
        Dim Base As String

        directorio = "EST" & Session("IdEstablecimiento") & "_PROC" & IDPROCESOCOMPRA
        Base = "B" & codigoLibreGestion & ".htm"

        openWindow = "<script type=text/javascript> window.open('" & directorio & "/BASES/" & Base & "',  '_blank') </script>"

        Response.Write(openWindow)
    End Sub

    Protected Sub txtCODIGOLICITACION_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCODIGOLICITACION.TextChanged
        Dim lonPrefijo As Integer
        If Me.txtCODIGOLICITACION.Text <> "" Then
            lonPrefijo = Len(Me.lblPrefijoBase.Text)
            If Me.txtCODIGOLICITACION.Text.Substring(0, lonPrefijo) <> Me.lblPrefijoBase.Text Then
                RequiredFieldValidator1.ErrorMessage = "El prefijo que debe utilizar para el número de solicitud es: " & Me.lblPrefijoBase.Text & ", verifique sus datos"
                RequiredFieldValidator1.IsValid = False
            End If
            Dim pos As Integer
            Dim annio As Integer
            pos = InStr(Me.txtCODIGOLICITACION.Text, "/")
            If pos > 0 Then
                annio = CInt(Me.txtCODIGOLICITACION.Text.Substring(pos))
                If annio < Today.Year Then
                    RequiredFieldValidator1.ErrorMessage = "Debe ingresar el año actual o el siguiente"
                    RequiredFieldValidator1.IsValid = False
                End If
            Else
                RequiredFieldValidator1.ErrorMessage = "En el formato de número de solicitud  debe utilizar el caracter / seguido por el año actual o el año siguiente"
                RequiredFieldValidator1.IsValid = False
            End If
        Else
            RequiredFieldValidator1.ErrorMessage = "Debe ingresar el código de Compra Directa - CD"
            RequiredFieldValidator1.IsValid = False
        End If
    End Sub

    Protected Sub imbGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbGuardar.Click
        guardarProcesoCompra()
        guardarPlantillaProcesoCompra()
        Label2.Text = "La base ha sido guardada satisfactoriamente, acontinuación deberá generar las bases"
        Me.lblMensaje.Text = "La base ha sido guardada satisfactoriamente"
        Me.lblMensaje.ForeColor = Drawing.Color.Red
    End Sub

    Private Sub guardarPlantillaProcesoCompra()
        Dim mComponente As New cPLANTILLAPROCESOCOMPRA
        Dim lEntidad As New PLANTILLAPROCESOCOMPRA

        With lEntidad
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDPLANTILLA = IDPLANTILLA
            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
            .ESTASINCRONIZADA = 1
            If modo = "NEW" Then
                .AUFECHAMODIFICACION = Now
                .AUFECHACREACION = Now
            Else
                .AUFECHAMODIFICACION = Now
            End If
            .AUUSUARIOCREACION = ""
        End With

        mComponente.AgregarPLANTILLAPROCESOCOMPRA(lEntidad)

    End Sub

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinuar.Click
        Dim mComponente As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS

        With lEntidad
            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            .IDESTADOPROCESOCOMPRA = 2
            .AUFECHAMODIFICACION = Date.Today
            .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            .ESTASINCRONIZADA = 0
            lEntidad.FECHAELABORACIONBASE = Date.Today
        End With
        If mComponente.ActualizarEstado(lEntidad, 0) = 1 Then
            Me.MsgBox1.ShowAlert("El registro se modificó satisfactoriamente", "OK", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            Me.MsgBox1.ShowAlert("Error en la actualización, Consulte con su administrador", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "OK" Then
            Response.Redirect("~/UACI/FrmGenerarBases.aspx")
        End If
    End Sub

End Class
