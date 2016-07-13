Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data.OleDb
Imports SINAB_Utils

Partial Class UACI_frmEntregaSolicitudCotizacion
    Inherits System.Web.UI.Page

    Private _NOMBREARCHIVO As String

    Public Property NOMBREARCHIVO() As String
        Get
            Return _NOMBREARCHIVO
        End Get
        Set(ByVal Value As String)
            Me._NOMBREARCHIVO = Value
            If Not Me.ViewState("NOMBREARCHIVO") Is Nothing Then Me.ViewState.Remove("NOMBREARCHIVO")
            Me.ViewState.Add("NOMBREARCHIVO", Value)
        End Set
    End Property

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub imbGeneraDisco_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbGeneraDisco.Click
        Me.copiarArchivos()
        generaDiscoSolProveedor()
        generaDiscoDetSolProveedor()
        generaDiscoProveedorDatoProveedor()
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

        NombreDirectorio = Me.DropDownList1.SelectedValue & "_" & Request.QueryString("IdProc") + "_" + Session("IdEstablecimiento").ToString

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

        Dim mComponente As New cENTREGABASES

        Dim tabla As String
        tabla = "Csolicitud"

        Dim NombreDirectorio As String
        NombreDirectorio = Me.DropDownList1.SelectedValue & "_" & Request.QueryString("IdProc") & "_" & Session("IdEstablecimiento")

        Dim directorioDestino As String
        directorioDestino = Server.MapPath(NombreDirectorio)

        Dim ds As Data.DataSet
        ds = mComponente.GeneraSolDiscoProveedorR(Request.QueryString("idProc"), Session("IdEstablecimiento"))

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
        Dim mComponente As New cENTREGABASES

        Dim tabla As String
        tabla = "C2detsolicitud"

        Dim directorioDestino As String
        directorioDestino = Server.MapPath(Me.DropDownList1.SelectedValue & "_" & Request.QueryString("idProc") & "_" & Session("IdEstablecimiento"))

        Dim ds As Data.DataSet
        ds = mComponente.GeneraDetalleDiscoProveedorR(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        Dim conString As String = "Provider=VFPOLEDB.1; Data Source=" & directorioDestino

        Dim con As New OleDbConnection(conString)
        Dim cmd As New OleDbCommand
        cmd.Connection = con

        Dim cmdText As String

        cmd.Connection.Open()

        For Each row As Data.DataRow In ds.Tables(0).Rows
            cmdText = "INSERT INTO " & tabla & " VALUES ( " & row.Item("numero") & ", " & row.Item("linea") & ", '" & row.Item("codigo") & "', '" & row.Item("nombre") & "', " & row.Item("entrega1") & ", " & row.Item("cantidad1") & ", 0, 0, '" & row.Item("descripcio") & "', '" & row.Item("unidmedida") & "', '" & row.Item("CODIGOESTABLECIMIENTO") & "')"
            cmd.CommandText = cmdText
            cmd.ExecuteNonQuery()
        Next

        cmd.Connection.Close()

    End Sub

    Private Sub generaDiscoProveedorDatoProveedor()
        Try
            Dim mComponente As New cENTREGABASES
            Dim tabla As String
            tabla = "cproveed"

            Dim directorioDestino As String
            directorioDestino = Server.MapPath(Me.DropDownList1.SelectedValue & "_" & Request.QueryString("idProc") & "_" & Session("IdEstablecimiento"))

            Dim ds As Data.DataSet
            ds = mComponente.GeneraProvDiscoProveedor(Me.DropDownList1.SelectedValue)

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

            Me.Label13.Text = "Los archivos se generaron satisfactoriamente"

        Catch ex As Exception
            Me.Label13.Text = ex.Message
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
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

        Me.MsgBox1.ShowAlert("A continuación descargará el archivo " & NOMBREARCHIVO & ", debe almacenarlo en el disco de la unidad 'a:'", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        Me.descargarArchivo()
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        Me.descargarArchivo()
    End Sub

    Private Sub descargarArchivo()

        Dim NombreDirectorio As String

        NombreDirectorio = Me.DropDownList1.SelectedValue & "_" & Request.QueryString("IdProc") & "_" & Session("IdEstablecimiento")

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

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Me.Label14.Visible = False
        Me.Label15.Visible = False
        Me.Label16.Visible = False
        Me.Label17.Visible = False
        Me.lbListaArchivos.Visible = False
        Me.Button1.Visible = False
        Me.lbDescarga.Visible = False
        Me.Button2.Visible = False

        Me.lbDescarga.Items.Clear()

        Me.Label13.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Dim cEB As New cENTREGABASES
            Dim ds As Data.DataSet
            ds = cEB.ObtenerDataSetPROVEEDOR(Request.QueryString("idProc"), Session("IdEstablecimiento"))
            Me.DropDownList1.DataSource = ds.Tables(0)
            Me.DropDownList1.DataTextField = "NOMBRE"
            Me.DropDownList1.DataValueField = "IDPROVEEDOR"
            Me.DropDownList1.DataBind()

            Dim cP As New cPROCESOCOMPRAS
            Dim ds1 As New Data.DataSet
            cP.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), ds1)

            Me.Label1.Text = ds1.Tables(0).Rows(0).Item(1)
            Me.Label2.Text = ds1.Tables(0).Rows(0).Item(3)
            Me.Label3.Text = ds1.Tables(0).Rows(0).Item(4)

            Dim P As New ABASTECIMIENTOS.ENTIDADES.PROCESOCOMPRAS
            P.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            P.IDPROCESOCOMPRA = Request.QueryString("idProc")
            cP.ObtenerPROCESOCOMPRAS(P)

            If P.FECHAHORAFINRETIRO < Today Then
                Me.MsgBox1.ShowAlert("La fecha de entrega de solicitudes de cotización ha expirado.", "r", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            End If

        Else
            If Not Me.ViewState("NOMBREARCHIVO") Is Nothing Then Me._NOMBREARCHIVO = Me.ViewState("NOMBREARCHIVO")
        End If
    End Sub

    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
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

        Me.MsgBox1.ShowAlert("A continuación descargará el archivo " & NOMBREARCHIVO & ", debe almacenarlo en el disco de la unidad 'a:'", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.lbDescarga.Items.Clear()
    End Sub

    Protected Sub BtnSoco_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSoco.Click
        Dim c As New cSOLICITUDESPROCESOCOMPRAS
        Dim idsolicitud As Integer
        idsolicitud = c.ObtenerIdSolicitud(Request.QueryString("idProc"), Session("IdEstablecimiento"))
        Utils.MostrarVentana("/Reportes/frmRptSolicitudCompraLG.aspx?idSol=" & Request.QueryString("idProc") & "&Sumi=" & Me.DropDownList1.SelectedItem.Text)
        'ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptSolicitudCompraLG.aspx?idSol=" & Request.QueryString("idProc") & "&Sumi=" & Me.DropDownList1.SelectedItem.Text & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');</script>")
    End Sub

End Class
