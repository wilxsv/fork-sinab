
Partial Class FrmMantRegistrarInspeccionMuestras
    Inherits System.Web.UI.Page

    Private mComponente As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = False

            If Request.QueryString.HasKeys Then
                If Request.QueryString("id").ToUpper = "C" Then
                    Me.ucBarraNavegacion1.PermitirAgregar = False
                    Me.gvLista.Columns(8).Visible = False

                    Me.lblRuta.Text += "Verificar inspección de muestras"
                Else
                    Me.lblRuta.Text += "Registrar inspección de muestras"
                End If
            Else
                Me.lblRuta.Text += "Registrar inspección de muestras"
            End If

            CargarDatos()
        End If

    End Sub

    Private Sub CargarDatos()

        Dim IDTIPOINFORME() As Byte = {eTIPOINFORME.ACEPTACION, eTIPOINFORME.RECHAZO, eTIPOINFORME.NOINSPECCION}

        Dim ds As Data.DataSet
        ds = mComponente.ObtenerListaInformes(Session("IdEstablecimiento"), 1, IDTIPOINFORME, Session("IdEmpleado"))

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try
    End Sub

    Private Sub ucBarraNavegacion1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Agregar
        Response.Redirect("~/LABORATORIO/FrmDetaMantRegistrarInspeccionMuestras.aspx?id=0")
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim a As ImageButton = CType(e.Row.FindControl("ImageButton1"), ImageButton)
            Dim s As String
            s = "if("
            s += a.CommandArgument
            s += "==2){alert('El informe se encuentra enviado, y no puede ser eliminado.');return false;}else{if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}}"
            a.Attributes.Add("onclick", s)
        End If
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim IDESTABLECIMIENTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDINFORME As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(1)

        If Me.mComponente.EliminarMotivosEInforme(IDESTABLECIMIENTO, IDINFORME) = 0 Then
            'Si se cometio un error
        Else
            Me.CargarDatos()
        End If
    End Sub

End Class
