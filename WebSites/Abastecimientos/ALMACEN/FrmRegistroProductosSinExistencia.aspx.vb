

Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils

Partial Class ALMACEN_FrmRegistroProductosSinExistencia
    Inherits System.Web.UI.Page

    Private Sub CargarSemanasActuales(semana As Integer)
        With ddlSemana
            .DataSource = SINAB_Utils.Semana.ObtenerTodasHastaHoy()
            .DataTextField = "Value"
            .DataValueField = "Key"
            .DataBind()
        End With
        ddlSemana.SelectedValue = semana.ToString()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim usr = Membresia.ObtenerUsuario()
            Dim semana = SINAB_Utils.Semana.ObtenerNumero()

            CargarSemanasActuales(semana)
            Me.ddlSemana.Enabled = False
            
            Me.Master.ControlMenu.Visible = False

            Me.lblYear.Text = CType(DateTime.Now.Year, String)

            Dim idAlmacen = usr.Almacen.IDALMACEN
            Suministros.CargarALista(ddlSuministro, True)
            ActualizarAlmacenes()
            gvSinExistencias.DataSource = ProductoSinExistencia.ObtenerTodos(idAlmacen, CType(Me.ddlSuministro.SelectedValue, Integer), DateTime.Now.Year, semana)
            gvSinExistencias.DataBind()
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            Using db As New SinabEntities()
                For Each g As GridViewRow In Me.gvSinExistencias.Rows
                    Dim idpse = CType(Me.gvSinExistencias.DataKeys(g.RowIndex).Values(0), Integer)
                    Dim chkexistencias = CType(g.Cells(3).Controls(1), CheckBox)
                    Dim obj = ProductoSinExistencia.Obtener(db, idpse)
                    If chkexistencias.Checked Then
                        obj.EXISTENCIAFARMACIA = 1
                    Else
                        obj.EXISTENCIAFARMACIA = 0
                    End If
                    obj.FECHA = DateTime.Now
                Next
                db.SaveChanges()
            End Using
            MessageBox.Alert("Datos guardados satisfactoriamente.", "Guardado")
        Catch ex As Exception
            MessageBox.Alert("Ocurrió un error en la actualización.", "Error")
        End Try

        ActualizarAlmacenes()
    End Sub

    Protected Sub gvSinExistencias_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvSinExistencias.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim nb = CType(e.Row.FindControl("chkExistencias"), CheckBox)
            If gvSinExistencias.DataKeys(e.Row.RowIndex).Values(2) = 0 Then
                nb.Checked = False
            Else
                nb.Checked = True
            End If
        End If
    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim usr = Membresia.ObtenerUsuario()
        Dim idAlmacen = usr.Almacen.IDALMACEN
        Utils.MostrarVentana(ResolveUrl(String.Format("/Reportes/FrmRptNivelAbastecimientoProductos.aspx?idSe={0}&idS={1}&idH={2}", ddlSemana.SelectedValue, ddlSuministro.SelectedValue, idAlmacen)))
    End Sub

    Protected Sub ddlSemana_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemana.SelectedIndexChanged
        btnRefresh_Click(sender, e)
    End Sub

    Protected Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        ActualizarAlmacenes()
    End Sub

    Private Sub ActualizarAlmacenes()
        Dim usr = Membresia.ObtenerUsuario()
        Dim idAlmacen = usr.Almacen.IDALMACEN
        Dim fechainiciosemana = Semana.FechaInicio(DateTime.Now.Year, CType(ddlSemana.SelectedValue, Integer))
        Dim ds = ProductoAlmacen.ObtenerDesabastecimiento(idAlmacen, CType(ddlSuministro.SelectedValue, Integer), CType(ddlSemana.SelectedValue, Integer), fechainiciosemana, Now.Year)

        Me.grvAlmacenes.DataSource = ds
        Me.grvAlmacenes.DataBind()
    End Sub
End Class
