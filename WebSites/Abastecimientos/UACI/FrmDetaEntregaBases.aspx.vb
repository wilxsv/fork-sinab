Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data.OleDb

Partial Class FrmDetaEntregaBases
    Inherits System.Web.UI.Page

    Private mComponenteProvee As New cPROVEEDORES
    Private mEntidadPrv As PROVEEDORES
    Private mEntidad As PROCESOCOMPRAS
    Private mComponenteEB As New cENTREGABASES
    Private mEntidadEB As ENTREGABASES

    Public Event ErrorEvent(ByVal errorMessage As String)

    Private _IDPROVEEDOR As Integer
    Private _fechaPublicacion As Date
    Private _indicador As Integer
    Private _nombreArchivo As String
    Private _i As Integer = 1

#Region " Propieadades "

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

    Public Property fechaPublicacion() As Date
        Get
            Return _fechaPublicacion
        End Get
        Set(ByVal value As Date)
            _fechaPublicacion = value
            If Not Me.ViewState("fechaPublicacion") Is Nothing Then Me.ViewState.Remove("fechaPublicacion")
            Me.ViewState.Add("fechaPublicacion", value)
        End Set
    End Property

    Public Property indicador() As Integer
        Get
            Return _indicador
        End Get
        Set(ByVal value As Integer)
            _indicador = value
            If Not Me.ViewState("indicador") Is Nothing Then Me.ViewState.Remove("indicador")
            Me.ViewState.Add("indicador", value)
        End Set
    End Property

    Public Property nombreArchivo() As String
        Get
            Return _nombreArchivo
        End Get
        Set(ByVal value As String)
            _nombreArchivo = value
            If Not Me.ViewState("nombreArchivo") Is Nothing Then Me.ViewState.Remove("nombreArchivo")
            Me.ViewState.Add("nombreArchivo", value)
        End Set
    End Property

    Public Property i() As Integer
        Get
            Return _i
        End Get
        Set(ByVal value As Integer)
            _i = value
            If Not Me.ViewState("i") Is Nothing Then Me.ViewState.Remove("i")
            Me.ViewState.Add("i", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.UcBarraNavegacion1.PermitirAgregar = False
        'Me.UcBarraNavegacion1.Navegacion = False
        'Me.UcBarraNavegacion1.PermitirConsultar = False

        'Me.UcBarraNavegacion1.PermitirImprimir = False
        UcVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
        UcVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False
        UcVistaDetalleSolicProcesCompra1.BtnEliminaProcesoEnabled = False

        Dim mComProcCompra As New cPROCESOCOMPRAS
        Dim lEntidad As New PROCESOCOMPRAS

        With lEntidad
            .IDPROCESOCOMPRA = Request.QueryString("idProc")
            .IDESTABLECIMIENTO = Session("IdEstablecimiento")
        End With

        Dim dsProcCompra As Data.DataSet
        dsProcCompra = mComProcCompra.recuperarDatosProcesoCompra(lEntidad)

        fechaPublicacion = Format(CDate(dsProcCompra.Tables(0).Rows(0).Item("FECHAPUBLICACION")), "dd/MM/yyyy")

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            CargarDatos()
            consultarSolicitudes()
            cargaProveedor()
            If Request.QueryString("est") = "m" Then
                IDPROVEEDOR = Request.QueryString("idProv")
                Me.consultarBaseEntregada()
                txtNoRecibo.ReadOnly = True
                ddlProveedores.Enabled = False
                txtNombrePersonaRecibeBases.ReadOnly = True
                txtFechaEntrega.Enabled = False
                txtHoraEntrega.Enabled = False
                imbGeneraDisco.Visible = True
            End If
        Else
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("fechaPublicacion") Is Nothing Then Me._fechaPublicacion = Me.ViewState("fechaPublicacion")
            If Not Me.ViewState("indicador") Is Nothing Then Me._indicador = Me.ViewState("indicador")
            If Not Me.ViewState("nombreArchivo") Is Nothing Then Me._nombreArchivo = Me.ViewState("nombreArchivo")
            If Not Me.ViewState("i") Is Nothing Then Me._i = Me.ViewState("i")

        End If

        Me.Label13.Text = ""

        Me.CargarDatosgv()
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub CargarDatos()

        Dim mComponente As New cPROCESOCOMPRAS
        mEntidad = New PROCESOCOMPRAS
        mEntidad.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        If mComponente.ObtenerPROCESOCOMPRAS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener Registro.")
            Return
        End If

        Me.lblNoProcesoCompra.Text = Request.QueryString("idProc")
        Me.lblCodigoBase.Text = mEntidad.CODIGOLICITACION
        Me.lblFechaPublicacion.Text = mEntidad.FECHAPUBLICACION
        Me.lblfechaInicioProceso.Text = mEntidad.FECHAHORAINICIORETIRO
    End Sub

    Private Sub consultarSolicitudes()
        UcVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        UcVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        UcVistaDetalleSolicProcesCompra1.Consultar()
    End Sub

    Private Sub cargaProveedor()
        If Request.QueryString("est") = "m" Then
            Me.ddlProveedores.DataSource = Me.mComponenteProvee.ObtenerDataSetPROVEEDOROrden()
            Me.ddlProveedores.DataTextField = "NOMBRE"
            Me.ddlProveedores.DataValueField = "IDPROVEEDOR"
            Me.ddlProveedores.DataBind()
        Else
            Me.ddlProveedores.DataSource = Me.mComponenteProvee.obtenerdSProveedorNoBaseEntrega(Session("IdEstablecimiento"), Request.QueryString("idProc"))
            Me.ddlProveedores.DataTextField = "NOMBRE"
            Me.ddlProveedores.DataValueField = "IDPROVEEDOR"
            Me.ddlProveedores.DataBind()
        End If

        cargaDireccion()
    End Sub

    Protected Sub ddlProveedores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProveedores.SelectedIndexChanged
        cargaDireccion()
    End Sub

    Private Sub cargaDireccion()
        mEntidadPrv = New PROVEEDORES
        mEntidadPrv.IDPROVEEDOR = Me.ddlProveedores.SelectedValue

        If mComponenteProvee.ObtenerPROVEEDORES(mEntidadPrv) <> 1 Then
            'Dim e As EventArgs
            RaiseEvent ErrorEvent("Error al obtener Registro.")
            Return
        End If
        Me.lblDireccionProveedor.Text = mEntidadPrv.DIRECCION
    End Sub
    Protected Sub btGuardar_Click(sender As Object, e As System.EventArgs) Handles btGuardar.Click
        Dim fechaEntrega As Date
        Dim HoraEntrega As DateTime

        Dim Orden As Integer
        Orden = mComponenteEB.ObtenerOrdenRecibeOferta(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        mEntidadEB = New ENTREGABASES
        mEntidadEB.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadEB.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mEntidadEB.IDPROVEEDOR = Me.ddlProveedores.SelectedValue
        mEntidadEB.ORDEN = Orden

        mEntidadEB.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntidadEB.AUFECHACREACION = Now
        mEntidadEB.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidadEB.AUFECHAMODIFICACION = Now

        IDPROVEEDOR = Me.ddlProveedores.SelectedValue
        Me.mEntidadEB.NUMERORECIBO = Me.txtNoRecibo.Text
        Me.mEntidadEB.PERSONARECIBE = Me.txtNombrePersonaRecibeBases.Text

        fechaEntrega = Me.txtFechaEntrega.SelectedDate
        HoraEntrega = Me.txtHoraEntrega.SelectedTime

        Me.mEntidadEB.FECHAHORAENTREGA = Format(fechaEntrega, "dd/MM/yyyy") & " " & Format(HoraEntrega, "HH:mm")
        '& Me.txtHoraEntrega.SelectedTime.Hour & ":"

        If Me.fechaPublicacion.Date > Format(fechaEntrega, "dd/MM/yyyy") Then
            Me.MsgBox1.ShowAlert("La fecha de entrega debe ser mayor que la fecha de publicación", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
        Else
            imbGeneraDisco.Visible = True
            If Request.QueryString("est") = "m" Then
                If Me.mComponenteEB.ActualizarENTREGABASES(mEntidadEB) <> 1 Then
                    Me.lblMsgerror.Text = "Error al Actualizar el registro."
                Else
                    btGuardar.Visible = False
                    Me.lblMsgerror.Text = "El registro se actualizó de manera satisfactoria"
                    'Me.btnDiscoPrograma.Visible = True
                End If
            Else
                If mComponenteEB.AgregarENTREGABASES(mEntidadEB) <> 1 Then
                    Me.lblMsgerror.Text = "Error al Guardar registro."
                Else
                    btGuardar.Visible = False
                    Me.lblMsgerror.Text = "El registro se guardó de manera satisfactoria"
                    'Me.btnDiscoPrograma.Visible = True
                    Me.imbGeneraDisco.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub btCancelar_Click(sender As Object, e As System.EventArgs) Handles btCancelar.Click
        Response.Redirect("~/UACI/FrmDetaMantEntregaBases.aspx?idProc=" & Request.QueryString("idProc"))
    End Sub


  

    Private Sub consultarBaseEntregada()
        Dim ds As Data.DataSet
        ds = Me.mComponenteEB.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("idProc"), Request.QueryString("idProv"))  'TODO: IDESTABLECIMIENTO
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                Me.txtNoRecibo.Text = .Item("NUMERORECIBO")
                Me.ddlProveedores.SelectedValue = .Item("IDPROVEEDOR")
                Me.cargaDireccion()
                Me.txtNombrePersonaRecibeBases.Text = .Item("PERSONARECIBE")
                Me.txtFechaEntrega.SelectedDate = CStr(CDate(.Item("FECHAHORAENTREGA")))
                Me.txtHoraEntrega.SelectedTime = CStr(CDate(.Item("FECHAHORAENTREGA")))
                Me.imbGeneraDisco.Visible = True
            End With
        End If
    End Sub

    Private Sub descargarArchivo()

        Dim NombreDirectorio As String

        NombreDirectorio = IDPROVEEDOR & "_" & Request.QueryString("IdProc") & "_" & Session("IdEstablecimiento")

        Dim path As String = Server.MapPath(NombreDirectorio & "\" & nombreArchivo & "") 'get file object as FileInfo

        Dim file As System.IO.FileInfo = New System.IO.FileInfo(path) '-- if the file exists on the server

        If file.Exists Then 'set appropriate headers
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
            Response.AddHeader("Content-Length", file.Length.ToString())
            Response.ContentType = "application/octet-stream"
            Response.WriteFile(file.FullName)
        Else
            Response.Write("El archivo no existe.")
        End If 'nothing in the URL as HTTP GET

    End Sub

    Private Sub eliminarDirectorio(ByVal Nombre As String)
        FileIO.FileSystem.DeleteDirectory(Server.MapPath(Nombre), FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
    End Sub

    Protected Sub imbGeneraDisco_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbGeneraDisco.Click
        Me.copiarArchivos()
        'generaDiscoSolProveedor()
        'generaDiscoDetSolProveedor()
        generaDiscoProveedorDatoProveedor()
        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.lbListaArchivos.Visible = True
        Me.Button1.Visible = True
        Me.lbDescarga.Visible = True
        Me.Button2.Visible = False

        Me.imbDescargarFormato.Visible = False

    End Sub

    Private Sub copiarArchivos()
        Dim directorioDestino As String
        Dim ruta, destino As String
        Dim NombreDirectorio As String
        Dim IdProveedor As Integer

        If Request.QueryString("idProv") <> "" Then
            IdProveedor = Request.QueryString("idProv")
        Else
            IdProveedor = ddlProveedores.SelectedValue
        End If

        NombreDirectorio = IdProveedor & "_" & Request.QueryString("IdProc") & "_" & Session("IdEstablecimiento")

        directorioDestino = Server.MapPath(NombreDirectorio)
        FileIO.FileSystem.CreateDirectory(directorioDestino)

        ruta = Server.MapPath("~/archivosBaseOferta/c2detsolicitud.dbf")
        destino = Server.MapPath(NombreDirectorio & "\c2detsolicitud.dbf")
        FileIO.FileSystem.CopyFile(ruta, destino, True)

        ruta = Server.MapPath("~/archivosBaseOferta/c2DetSolicitud.FPT")
        destino = Server.MapPath(NombreDirectorio & "\c2DetSolicitud.FPT")
        FileIO.FileSystem.CopyFile(ruta, destino, True)

        ruta = Server.MapPath("~/archivosBaseOferta/cproveed.DBF")
        destino = Server.MapPath(NombreDirectorio & "\cproveed.DBF")
        FileIO.FileSystem.CopyFile(ruta, destino, True)

        ruta = Server.MapPath("~/archivosBaseOferta/cproveed.FPT")
        destino = Server.MapPath(NombreDirectorio & "\cproveed.FPT")
        FileIO.FileSystem.CopyFile(ruta, destino, True)

        ruta = Server.MapPath("~/archivosBaseOferta/csolicitud.DBF")
        destino = Server.MapPath(NombreDirectorio & "\csolicitud.DBF")
        FileIO.FileSystem.CopyFile(ruta, destino, True)

    End Sub

    Private Sub generaDiscoSolProveedor()

        Dim tabla As String
        tabla = "Csolicitud"

        Dim NombreDirectorio As String
        NombreDirectorio = IDPROVEEDOR & "_" & Request.QueryString("IdProc") & "_" & Session("IdEstablecimiento")

        Dim directorioDestino As String
        directorioDestino = Server.MapPath(NombreDirectorio)

        Dim ds As Data.DataSet
        ds = mComponenteEB.GeneraSolDiscoProveedorR(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        Dim conString As String = "Provider=VFPOLEDB.1; Data Source=" & directorioDestino

        Dim con As New OleDbConnection(conString)
        Dim cmd As New OleDbCommand
        cmd.Connection = con

        Dim cmdText As String

        With ds.Tables(0).Rows(0)
            cmdText = "INSERT INTO " & tabla & " VALUES ( " & .Item("numero") & ", '" & .Item("cod_licita") & "', date(" & CDate(.Item("fecha")).Year & "," & CDate(.Item("fecha")).Month & "," & CDate(.Item("fecha")).Day & "), '" & .Item("descripcio") & "', " & .Item("estado_sol") & ", '" & .Item("establec") & "')"
        End With

        cmd.CommandText = cmdText
        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        cmd.Connection.Close()

    End Sub

    Private Sub generaDiscoDetSolProveedor()

        Dim tabla As String
        tabla = "C2detsolicitud"

        Dim directorioDestino As String
        directorioDestino = Server.MapPath(IDPROVEEDOR & "_" & Request.QueryString("idProc") & "_" & Session("IdEstablecimiento"))

        Dim ds As Data.DataSet
        ds = mComponenteEB.GeneraDetalleDiscoProveedorR(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        Dim conString As String = "Provider=VFPOLEDB.1; Data Source=" & directorioDestino

        Dim con As New OleDbConnection(conString)
        Dim cmd As New OleDbCommand
        cmd.Connection = con

        Dim cmdText As String

        cmd.Connection.Open()

        For Each row As Data.DataRow In ds.Tables(0).Rows
            Dim TEM As String = row.Item("nombre")
            If TEM.Length >= 200 Then
                TEM = TEM.Substring(0, 200)

            End If
            ' cmdText = "INSERT INTO " & tabla & " VALUES ( " & row.Item("numero") & ", " & row.Item("linea") & ", '" & row.Item("codigo") & "', '" & row.Item("nombre") & "', " & row.Item("entrega1") & ", " & row.Item("cantidad1") & ", 0, 0, '" & row.Item("descripcio") & "', '" & row.Item("unidmedida") & "', '" & row.Item("CODIGOESTABLECIMIENTO") & "')"

            cmdText = "INSERT INTO " & tabla & " VALUES ( " & row.Item("numero") & ", " & row.Item("linea") & ", '" & row.Item("codigo") & "', '" & TEM & "', " & row.Item("entrega1") & ", " & row.Item("cantidad1") & ", 0, 0, '" & TEM & "', '" & row.Item("unidmedida") & "', '" & row.Item("CODIGOESTABLECIMIENTO") & "')"

            cmd.CommandText = cmdText
            cmd.ExecuteNonQuery()
        Next

        cmd.Connection.Close()

    End Sub

    Private Sub generaDiscoProveedorDatoProveedor()
        Try

            Dim tabla As String
            tabla = "cproveed"

            Dim directorioDestino As String
            directorioDestino = Server.MapPath(IDPROVEEDOR & "_" & Request.QueryString("idProc") & "_" & Session("IdEstablecimiento"))

            Dim ds As Data.DataSet
            ds = mComponenteEB.GeneraProvDiscoProveedor(Me.ddlProveedores.SelectedValue)

            Dim conString As String = "Provider=VFPOLEDB.1; Data Source=" & directorioDestino

            Dim con As New OleDbConnection(conString)
            Dim cmd As New OleDbCommand
            cmd.Connection = con

            Dim cmdText As String

            With ds.Tables(0).Rows(0)
                cmdText = "INSERT INTO " & tabla & " VALUES ('" & .Item("CODIGOPROVEEDOR") & "', '" & .Item("NOMBRE") & "', '" & .Item("NOMBRE") & "', "
                cmdText += " '', '', '', '', '', '', '', '', '', '', '', 0,0,0,0,0, '', 0,0,0,0,0,0, '','','','','','','','','','','','',date(1900,01,01),'','','','',date(1900,01,01),'','',date(1900,01,01),'','','','',date(1900,01,01),'','')"
            End With

            cmd.CommandText = cmdText
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()

            Me.lblMsgerror.Text = "Los archivos se generaron satisfactoriamente"

        Catch ex As Exception
            Me.Label13.Text = ex.Message
        End Try
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        Me.descargarArchivo()
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        Me.descargarArchivo()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim i As Integer
        Dim descargado As Boolean = False
        nombreArchivo = Me.lbListaArchivos.SelectedValue
        If Me.lbDescarga.Items.Count > 0 Then
            For i = 0 To Me.lbDescarga.Items.Count - 1
                If nombreArchivo = Me.lbDescarga.Items(i).Text Then
                    descargado = True
                End If
            Next
        End If

        If descargado = False Then
            Me.lbDescarga.Items.Add(nombreArchivo)
        End If

        If i <= 4 Then
            'Me.lblArchivo.Text = Me.lbListaArchivos.Items(i).Value
            If i < 4 Then
                'Me.lblArchivo.Text = "Descargue el siguiente archivo: " & Me.lbListaArchivos.Items(i + 1).Value
            Else
                'Me.lblArchivo.Text = "La descarga de archivos ha finalizado satisfactoriamente"
                'Me.lblArchivo.ForeColor = Drawing.Color.Red
                imbDescargarFormato.Visible = False
            End If

        Else
            'Me.lblArchivo.Text = "La descarga de archivos ha finalizado satisfactoriamente"
            'Me.lblArchivo.ForeColor = Drawing.Color.Red
            'imbDescargarFormato.Visible = False
        End If

        Me.MsgBox1.ShowAlert("A continuación descargará el archivo " & nombreArchivo & ", debe almacenarlo en el disco de la unidad 'A:'", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

        'If Me.lbDescarga.Items.Count = 5 Then
        '    Me.MsgBox1.ShowAlert("Ha descargado todos los archivos satisfactoriamente.", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        'End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.lbDescarga.Items.Clear()
    End Sub

    Public Function CargarDatosgv() As Integer

        Dim ds As Data.DataSet
        ds = Me.mComponenteProvee.ObtenerDataSetPorId()

        If ds Is Nothing Then Return -1

        Dim dsVista As New System.Data.DataView(ds.Tables(0))

        If Me.txtfiltro.Text <> "" Then
            If Me.rblFiltrar.Items(0).Selected = True Then
                dsVista.RowFilter = "CODIGOPROVEEDOR " & " LIKE '%" & Me.txtfiltro.Text & "%'"
            Else
                dsVista.RowFilter = "NOMBRE " & " LIKE '%" & Me.txtfiltro.Text & "%'"
            End If
        End If

        Me.gvLista.DataSource = dsVista

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Return 1
    End Function

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatosgv()
    End Sub

    Protected Sub gvLista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvLista.SelectedIndexChanged
        Dim x As Integer '= Me.gvLista.SelectedRow.Cells(1).Text
        Dim y As Integer '= Eval("IDPROVEEDOR")
        'Me.mEntidadPrv.IDPROVEEDOR = x
        Me.ddlProveedores.SelectedItem.Value = Me.gvLista.SelectedRow.Cells(1).Text
        Me.ddlProveedores.DataBind()

        x = Me.ddlProveedores.SelectedItem.Value()
        y = Me.ddlProveedores.SelectedValue

        cargaDireccion()
        If mComponenteProvee.ObtenerPROVEEDORES(mEntidadPrv) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener Registro.")
            Return
        End If

    End Sub

    Protected Sub bntFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntFiltrar.Click
        CargarDatosgv()
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.txtfiltro.Text = ""
        CargarDatosgv()
    End Sub

    
End Class
