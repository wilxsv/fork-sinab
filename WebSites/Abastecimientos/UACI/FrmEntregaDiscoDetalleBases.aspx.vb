Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Imports System.Data.OleDb

Partial Class FrmEntregaDiscoBases
    Inherits System.Web.UI.Page

    Private _NOMBREARCHIVO As String

    Private mComponente As New cPROCESOCOMPRAS
    Private mEntidad As PROCESOCOMPRAS
    Private mComponenteEB As New cENTREGABASES

    Public Event ErrorEvent(ByVal errorMessage As String)

#Region " Propiedades "

    Public Property NOMBREARCHIVO() As String
        Get
            Return _NOMBREARCHIVO
        End Get
        Set(ByVal value As String)
            Me._NOMBREARCHIVO = value
            If Not Me.ViewState("NOMBREARCHIVO") Is Nothing Then Me.ViewState.Remove("NOMBREARCHIVO")
            Me.ViewState.Add("NOMBREARCHIVO", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.UcBarraNavegacion1.PermitirAgregar = False
            Me.UcBarraNavegacion1.Navegacion = False
            Me.UcBarraNavegacion1.PermitirConsultar = False
            Me.UcBarraNavegacion1.PermitirGuardar = False
            Me.imbGeneraDisco.Visible = True
            Me.UcBarraNavegacion1.PermitirImprimir = False

            mEntidad = New PROCESOCOMPRAS
            With mEntidad
                .IDPROCESOCOMPRA = Request.QueryString("idProc")
                .IDESTABLECIMIENTO = Session("IdEstablecimiento")
            End With

            Dim dsProcCompra As Data.DataSet
            dsProcCompra = mComponente.recuperarDatosProcesoCompra(mEntidad)

            CargarDatos()
        Else
            If Not Me.ViewState("NOMBREARCHIVO") Is Nothing Then Me._NOMBREARCHIVO = Me.ViewState("NOMBREARCHIVO")
        End If

        Me.Label13.Text = ""

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub CargarDatos()

        mEntidad = New PROCESOCOMPRAS
        mEntidad.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        If mComponente.ObtenerPROCESOCOMPRAS(mEntidad) <> 1 Then
            RaiseEvent ErrorEvent("Error al obtener Registro.")
            Return
        End If

        Me.lblNoProcesoCompra.Text = Request.QueryString("idProc")
        Me.lblCodigoBase.Text = mEntidad.CODIGOLICITACION
        Me.lblfechaInicioProceso.Text = mEntidad.FECHAHORAINICIORETIRO
    End Sub

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar
        Response.Redirect("~/UACI/FrmEntregaDiscoBase.aspx?idProc=" & Request.QueryString("idProc"))
    End Sub

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar

        Dim fechaEntrega As Date
        Dim HoraEntrega As DateTime

        Dim Orden As Integer
        Orden = mComponenteEB.ObtenerOrdenRecibeOferta(Session("IdEstablecimiento"), Request.QueryString("idProc"))

        Dim mEntidadEB As ENTREGABASES
        mEntidadEB = New ENTREGABASES
        mEntidadEB.IDPROCESOCOMPRA = Request.QueryString("idProc")
        mEntidadEB.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        mEntidadEB.ORDEN = Orden
        mEntidadEB.FECHAHORAENTREGA = Format(fechaEntrega, "dd/MM/yyyy") & " " & Format(HoraEntrega, "HH:mm")
    End Sub

    Private Sub descargarArchivo()

        Dim NombreDirectorio As String

        NombreDirectorio = Request.QueryString("IdProc") & "_" & Session("IdEstablecimiento")

        Dim path As String = Server.MapPath(NombreDirectorio & "\" & NOMBREARCHIVO & "") 'get file object as FileInfo

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
        copiarArchivos()
        generaDiscoSolProveedor()
        generaDiscoDetSolProveedor()


        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.lbListaArchivos.Visible = True
        Me.Button1.Visible = True
        Me.lbDescarga.Visible = True
        Me.Button2.Visible = True
    End Sub

    Private Sub copiarArchivos()
        Dim directorioDestino As String
        Dim ruta, destino As String
        Dim NombreDirectorio As String

        NombreDirectorio = Request.QueryString("IdProc") + "_" + Session("IdEstablecimiento").ToString

        directorioDestino = Server.MapPath(NombreDirectorio)
        FileIO.FileSystem.CreateDirectory(directorioDestino)

        ruta = Server.MapPath("~/archivosbaseoferta/c2detsolicitud.dbf")
        destino = Server.MapPath(NombreDirectorio & "\c2detsolicitud.dbf")
        FileIO.FileSystem.CopyFile(ruta, destino, True)

        ruta = Server.MapPath("~/archivosbaseoferta/c2detsolicitud.fpt")
        destino = Server.MapPath(NombreDirectorio & "\c2detsolicitud.fpt")
        FileIO.FileSystem.CopyFile(ruta, destino, True)

        ruta = Server.MapPath("~/archivosbaseoferta/cproveed.dbf")
        destino = Server.MapPath(NombreDirectorio & "\cproveed.dbf")
        FileIO.FileSystem.CopyFile(ruta, destino, True)

        ruta = Server.MapPath("~/archivosbaseoferta/cproveed.fpt")
        destino = Server.MapPath(NombreDirectorio & "\cproveed.fpt")
        FileIO.FileSystem.CopyFile(ruta, destino, True)

        ruta = Server.MapPath("~/archivosbaseoferta/csolicitud.dbf")
        destino = Server.MapPath(NombreDirectorio & "\csolicitud.dbf")
        FileIO.FileSystem.CopyFile(ruta, destino, True)

    End Sub

    Private Sub generaDiscoSolProveedor()

        Dim NombreDirectorio As String
        NombreDirectorio = Request.QueryString("IdProc") & "_" & Session("IdEstablecimiento")

        Dim directorioDestino As String
        directorioDestino = Server.MapPath(NombreDirectorio)

        Dim tabla As String
        tabla = "Csolicitud"

        Dim ds As Data.DataSet
        ds = mComponenteEB.GeneraSolDiscoProveedorR(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        If ds.Tables(0).Rows.Count > 0 Then

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

        End If

    End Sub

    Private Sub generaDiscoDetSolProveedor()

        Dim ds As Data.DataSet
        ds = mComponenteEB.GeneraDetalleDiscoProveedorR(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        If ds.Tables(0).Rows.Count > 0 Then

            Dim tabla As String
            tabla = "C2detsolicitud"

            Dim directorioDestino As String
            directorioDestino = Server.MapPath(Request.QueryString("idProc") & "_" & Session("IdEstablecimiento"))

            Dim conString As String = "Provider=VFPOLEDB.1; Data Source=" & directorioDestino

            Dim con As New OleDbConnection(conString)
            Dim cmd As New OleDbCommand
            cmd.Connection = con

            Dim cmdText As String
            Dim descripcion As String
            Dim s1 As New StringBuilder
            lbldirectorio.Text = conString
            cmd.Connection.Open()

            For Each row As DataRow In ds.Tables(0).Rows

                descripcion = row.Item("descripcio").ToString

                s1.Length = 0
                s1.Append(descripcion.Substring(0, Math.Min(descripcion.Length, 255)))

                If descripcion.Length > 255 Then

                    Dim i As Integer = Decimal.ToInt32(Decimal.Floor(Decimal.Divide(descripcion.Length, 255)))

                    For j As Integer = 1 To i
                        If descripcion.Length > (j * 255) Then
                            s1.Append("' + '")
                            s1.Append(descripcion.Substring((j * 255), Math.Min(descripcion.Length - (j * 255), 255)))
                        End If
                    Next
                End If

                cmdText = "INSERT INTO " & tabla & " VALUES ( " & row.Item("numero") & ", " & row.Item("linea") & ", '" & row.Item("codigo") & "', '" & row.Item("nombre").ToString.Substring(0, Math.Min(row.Item("nombre").ToString.Length, 50)) & "', " & row.Item("entrega1") & ", " & row.Item("cantidad1") & ", 0, 0, '" & s1.ToString & "', '" & row.Item("unidmedida") & "', '" & row.Item("CODIGOESTABLECIMIENTO").ToString & "')"
                cmd.CommandText = cmdText
                cmd.ExecuteNonQuery()
            Next

            cmd.Connection.Close()

        End If

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
        NOMBREARCHIVO = Me.lbListaArchivos.SelectedValue
        If Me.lbDescarga.Items.Count > 0 Then
            For i = 0 To Me.lbDescarga.Items.Count - 1
                If NOMBREARCHIVO = Me.lbDescarga.Items(i).Text Then
                    descargado = True
                End If
            Next
        End If

        If descargado = False Then
            Me.lbDescarga.Items.Add(NOMBREARCHIVO)
        End If

        If i <= 2 Then
            If i < 2 Then
            Else
                imbDescargarFormato.Visible = False
                Me.Button3.Visible = True

            End If
        End If

        Me.MsgBox1.ShowAlert("A continuación descargará el archivo " & NOMBREARCHIVO & ", debe almacenarlo en el disco de la unidad 'a:'", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.lbDescarga.Items.Clear()
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.lbDescarga.Items(0).Text = " "
        Me.lbDescarga.Items(1).Text = " "
        Me.lbDescarga.Items(2).Text = " "
        Me.Button3.Visible = False
    End Sub

End Class
