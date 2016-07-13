Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils

Partial Class FrmSeleccionarProveedores
    Inherits System.Web.UI.Page

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            CrearTabla()
            cargar()
            CargarProveedoresInvitados()
        Else
            If Not Me.ViewState("TProv") Is Nothing Then Me.TProv = Me.ViewState("TProv")
        End If

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        AddHandler WucFiltroGrid1.filtrar, AddressOf filtro_cargar
    End Sub

    Sub filtro_cargar()

        If Not ViewState.Item("valorFiltro") Is Nothing Then ViewState.Remove("valorFiltro")
        If Not ViewState.Item("columnaFiltro") Is Nothing Then ViewState.Remove("columnaFiltro")
        If Not ViewState.Item("posicionFiltro") Is Nothing Then ViewState.Remove("posicionFiltro")

        If WucFiltroGrid1.posicionFiltro > 0 Then
            ViewState.Add("valorFiltro", WucFiltroGrid1.valorFiltro)
            ViewState.Add("columnaFiltro", WucFiltroGrid1.columnaFiltro)
            ViewState.Add("posicionFiltro", WucFiltroGrid1.posicionFiltro)
        End If

        cargar()
    End Sub

    'Carga de datos 
    Public Sub cargar()

        Dim cP As New cPROVEEDORES

        Dim ds As Data.DataSet
        ds = cP.ObtenerDataSetPROVEEDOROrden() '(Session.Item("IdEstablecimiento"), "", 0, 0)

        Dim dsVista As New System.Data.DataView(ds.Tables(0))

        If Not Me.ViewState("columnaFiltro") Is Nothing Then

            Dim columnaFiltro As String = CType(Me.ViewState("columnaFiltro"), String)
            Dim valorFiltro As String = CType(Me.ViewState("valorFiltro"), String)

            dsVista.RowFilter = columnaFiltro & " LIKE '%" & valorFiltro & "%'"

        End If

        Me.GridView1.DataSource = dsVista
        Me.GridView1.DataBind()
        mostrarFiltro()
    End Sub

    Private Sub CargarProveedoresInvitados()
        Dim cEB As New cENTREGABASES

        Dim ds As Data.DataSet
        ds = cEB.ObtenerDataSetPROVEEDOR(Request.QueryString("idProc"), Session("IdEstablecimiento"))

        Me.GridView2.DataSource = ds.Tables(0)
        Me.GridView2.DataBind()

        TProv.Merge(ds.Tables(0), False, Data.MissingSchemaAction.Ignore)
        If Not Me.ViewState("TProv") Is Nothing Then Me.ViewState.Remove("TProv")
        Me.ViewState.Add("TProv", TProv)

        Dim cP As New cPROCESOCOMPRAS

        Dim ds1 As New Data.DataSet
        cP.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), ds1)
        Me.Label3.Text = ds1.Tables(0).Rows(0).Item(1)

    End Sub

    'posicion del filtro
    Protected Sub mostrarFiltro()

        If Not ViewState.Item("posicionFiltro") Is Nothing Then
            WucFiltroGrid1.posicionFiltro = CType(ViewState.Item("posicionFiltro"), Integer)
        End If

        WucFiltroGrid1.dataGridMostrar = filtroRemision()
    End Sub

    'Datos que van al filtro
    Private Function filtroRemision() As ArrayList

        Dim e_E As eDatosFiltro
        Dim columnas As New ArrayList

        e_E = New eDatosFiltro("NIT", "NIT")
        columnas.Add(e_E)
        e_E = New eDatosFiltro("Razón social", "NOMBRE")
        columnas.Add(e_E)

        Return columnas

    End Function

    Private TProv As Data.DataTable

    Private Sub CrearTabla()
        TProv = New Data.DataTable

        Dim ColumIdEmpleado As New Data.DataColumn("IDPROVEEDOR", System.Type.GetType("System.Int32"))
        Dim ColumNombre As New Data.DataColumn("NIT", System.Type.GetType("System.String"))
        Dim ColumCargo As New Data.DataColumn("NOMBRE", System.Type.GetType("System.String"))
        'Dim ColumEstaHabilitado As New Data.DataColumn("ESTAHABILITADO", System.Type.GetType("System.Int32"))

        TProv.Columns.Add(ColumIdEmpleado)
        TProv.Columns.Add(ColumNombre)
        TProv.Columns.Add(ColumCargo)
        ' TProv.Columns.Add(ColumEstaHabilitado)

        Dim PrimaryKey(1) As Data.DataColumn
        PrimaryKey(0) = ColumIdEmpleado

        TProv.PrimaryKey = PrimaryKey

        If Not Me.ViewState("TProv") Is Nothing Then Me.ViewState.Remove("TProv")
        Me.ViewState.Add("TProv", TProv)
    End Sub

    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Dim IDPROVEEDOR As Integer = Me.GridView2.DataKeys(e.RowIndex).Values(0)

        Dim cR As New cRECEPCIONOFERTAS
        Dim ds As Data.DataSet
        ds = cR.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDPROVEEDOR)
        If ds.Tables(0).Rows.Count = 0 Then
            Try
                Dim cEB As New cENTREGABASES
                cEB.EliminarENTREGABASES(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDPROVEEDOR)
                TProv.Rows.Remove(TProv.Rows.Find(IDPROVEEDOR))

                If Not Me.ViewState("TProv") Is Nothing Then Me.ViewState.Remove("TProv")
                Me.ViewState.Add("TProv", TProv)
                Me.GridView2.DataSource = TProv
                Me.GridView2.DataBind()
                Me.Label4.Text = ""
            Catch ex As Exception
                Me.Label4.Text = "Ocurrio un error al eliminar."
            End Try

        Else
            Me.Label4.Text = "No se puede eliminar este suministrante, ya que se le ha recibido oferta."
        End If


    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim D As Data.DataRow = TProv.NewRow
        For Each D In TProv.Rows
            If Me.GridView1.DataKeys(e.NewSelectedIndex).Values(0) = D("IDPROVEEDOR") Then
                Me.Label2.Text = "Este proveedor ya ha sido seleccionado."
                Me.Label4.Text = ""
                Exit Sub
            Else
                Me.Label2.Text = ""
                Me.Label4.Text = ""
            End If
        Next

        Dim drProv As Data.DataRow = TProv.NewRow

        drProv("IDPROVEEDOR") = Me.GridView1.DataKeys(e.NewSelectedIndex).Values(0) 'SelectedRow.Cells(1).Text() 'Me.txtCodigoEmpleado.Text
        drProv("NIT") = Server.HtmlDecode(Me.GridView1.Rows(e.NewSelectedIndex).Cells(1).Text)
        drProv("NOMBRE") = Server.HtmlDecode(Me.GridView1.Rows(e.NewSelectedIndex).Cells(2).Text)

        TProv.Rows.Add(drProv)

        ' Me.txtCodigoEmpleado.Text = TComisionEvaluadora.Rows.Count + 1
        'drEmpleado("IDEMPLEADO") = Val(Me.txtCodigoEmpleado.Text) + 1
        If Not Me.ViewState("TProv") Is Nothing Then Me.ViewState.Remove("TProv")
        Me.ViewState.Add("TProv", TProv)

        Me.GridView2.DataSource = TProv
        Me.GridView2.DataBind()

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("~/Catalogos/wfMantPROVEEDORES.aspx", False)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If Me.GridView2.Rows.Count <> 0 Then

                For Each drow As Data.DataRow In Me.TProv.Rows
                    Dim mComEntregaBase As New cENTREGABASES
                    Dim cR As New cRECEPCIONOFERTAS
                    Dim ds1 As Data.DataSet
                    ds1 = cR.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("idProc"), drow("IDPROVEEDOR"))
                    If ds1.Tables(0).Rows.Count = 0 Then
                        Dim ds2 As Data.DataSet = mComEntregaBase.ObtenerDataSetPorId(Session("IdEstablecimiento"), Request.QueryString("idProc"), drow("IDPROVEEDOR"))
                        If ds2.Tables(0).Rows.Count = 0 Then
                            Dim Orden As Integer
                            Orden = mComEntregaBase.ObtenerOrdenRecibeOferta(Session("IdEstablecimiento"), Request.QueryString("idProc"))

                            Dim mEntidadEB As New ENTREGABASES
                            mEntidadEB.IDPROCESOCOMPRA = Request.QueryString("idProc")
                            mEntidadEB.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                            mEntidadEB.IDPROVEEDOR = drow("IDPROVEEDOR")
                            mEntidadEB.ORDEN = Orden
                            mEntidadEB.NUMERORECIBO = "NA"
                            mEntidadEB.PERSONARECIBE = "NA"
                            mEntidadEB.FECHAHORAENTREGA = Now 'Format(fechaEntrega, "dd/MM/yyyy") & " " & Format(HoraEntrega, "HH:mm")
                            mEntidadEB.AUFECHACREACION = Now
                            mEntidadEB.AUUSUARIOCREACION = User.Identity.Name

                            mComEntregaBase.AgregarENTREGABASES(mEntidadEB)
                        End If
                    End If
                Next
            End If
            Me.Button3.Enabled = True
            Me.Label4.Text = ""
            MessageBox.Alert("Datos almacenados satisfactoriamente.", "Guardado")
            ' Me.MsgBox1.ShowAlert("Datos almacenados satisfactoriamente.", "S", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Catch ex As Exception
            Me.Label4.Text = ""
            MessageBox.Alert("Error al Guardar registro.", "Error")
            ' Me.MsgBox1.ShowAlert("Error al Guardar registro.", "S", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End Try

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Utils.MostrarVentana("/Reportes/frmRptNotasInvitacionLG.aspx")

    End Sub

End Class
