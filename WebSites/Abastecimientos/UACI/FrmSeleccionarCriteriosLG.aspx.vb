
Imports SINAB_Utils

Partial Class FrmSeleccionarCriteriosLG
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

    'Carga de datos 
    Public Sub cargar()

        Dim cP As New ABASTECIMIENTOS.NEGOCIO.cCRITERIOSEVALUACION

        Dim ds As Data.DataSet
        ds = cP.ObtenerDataSetxTipoCriterio(3) '(Session.Item("IdEstablecimiento"), "", 0, 0)

        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()

    End Sub

    Private Sub CargarProveedoresInvitados()
        Dim cEB As New ABASTECIMIENTOS.NEGOCIO.cCRITERIOPROCESOCOMPRA

        Dim ds As Data.DataSet
        ds = cEB.ObtenerDataSetCriteriosPC(Session("IdEstablecimiento"), Request.QueryString("idProc"), 3)

        Me.GridView2.DataSource = ds.Tables(0)
        Me.GridView2.DataBind()

        TProv.Merge(ds.Tables(0), False, Data.MissingSchemaAction.Ignore)
        If Not Me.ViewState("TProv") Is Nothing Then Me.ViewState.Remove("TProv")
        Me.ViewState.Add("TProv", TProv)

        Dim cP As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS

        Dim ds1 As New Data.DataSet
        cP.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), ds1)
        Me.Label3.Text = ds1.Tables(0).Rows(0).Item(1)

    End Sub

    Private TProv As Data.DataTable
    Private Sub CrearTabla()
        TProv = New Data.DataTable

        Dim ColumIdEmpleado As New Data.DataColumn("IDCRITERIO", System.Type.GetType("System.Int32"))
        Dim ColumNombre As New Data.DataColumn("CRITERIO", System.Type.GetType("System.String"))
        Dim ColumCargo As New Data.DataColumn("PORCENTAJE", System.Type.GetType("System.String"))
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

        TProv.Rows.Remove(TProv.Rows.Find(IDPROVEEDOR))

        If Not Me.ViewState("TProv") Is Nothing Then Me.ViewState.Remove("TProv")
        Me.ViewState.Add("TProv", TProv)
        Me.GridView2.DataSource = TProv
        Me.GridView2.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        Dim D As Data.DataRow = TProv.NewRow
        For Each D In TProv.Rows
            If Me.GridView1.DataKeys(e.NewSelectedIndex).Values(0) = D("IDCRITERIO") Then
                Me.Label2.Text = "Este criterio de evaluacion ya ha sido seleccionado."
                Exit Sub
            Else
                Me.Label2.Text = ""
            End If
        Next

        Dim drProv As Data.DataRow = TProv.NewRow

        drProv("IDCRITERIO") = Me.GridView1.DataKeys(e.NewSelectedIndex).Values(0) 'SelectedRow.Cells(1).Text() 'Me.txtCodigoEmpleado.Text
        drProv("CRITERIO") = Server.HtmlDecode(Me.GridView1.Rows(e.NewSelectedIndex).Cells(1).Text)
        drProv("PORCENTAJE") = Server.HtmlDecode(Me.GridView1.Rows(e.NewSelectedIndex).Cells(2).Text)

        TProv.Rows.Add(drProv)

        ' Me.txtCodigoEmpleado.Text = TComisionEvaluadora.Rows.Count + 1
        'drEmpleado("IDEMPLEADO") = Val(Me.txtCodigoEmpleado.Text) + 1
        If Not Me.ViewState("TProv") Is Nothing Then Me.ViewState.Remove("TProv")
        Me.ViewState.Add("TProv", TProv)

        Me.GridView2.DataSource = TProv
        Me.GridView2.DataBind()

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("~/Catalogos/wfMantCRITERIOSEVALUACIONLG.aspx")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            Dim mComponenteEB As New ABASTECIMIENTOS.NEGOCIO.cCRITERIOPROCESOCOMPRA

            mComponenteEB.BorrarCRITERIOPROCESOCOMPRA(Session("IdEstablecimiento"), Request.QueryString("idProc"))

            If Me.GridView2.Rows.Count <> 0 Then
                Dim drow As Data.DataRow = Me.TProv.NewRow
                For Each drow In Me.TProv.Rows

                    Dim mEntidadEB As New ABASTECIMIENTOS.ENTIDADES.CRITERIOPROCESOCOMPRA
                    mEntidadEB.IDPROCESOCOMPRA = Request.QueryString("idProc")
                    mEntidadEB.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                    mEntidadEB.IDCRITERIOEVALUACION = drow("IDCRITERIO")
                    mEntidadEB.PORCENTAJE = drow("PORCENTAJE")
                    mEntidadEB.AUFECHACREACION = DateTime.Now
                    mEntidadEB.AUUSUARIOCREACION = User.Identity.Name

                    mComponenteEB.AgregarCRITERIOPROCESOCOMPRA(mEntidadEB)

                Next
            End If
            MessageBox.Alert("Datos almacenados satisfactoriamente.", "Guardado")
            '  Me.MsgBox1.ShowAlert("Datos almacenados satisfactoriamente.", "S", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Catch ex As Exception
            MessageBox.Alert("Error al Guardar registro.", "Error")
            '  Me.MsgBox1.ShowAlert("Error al Guardar registro.", "S", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End Try

    End Sub

End Class
