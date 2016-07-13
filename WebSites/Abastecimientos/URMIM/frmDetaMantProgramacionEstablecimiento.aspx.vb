Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class URMIM_frmDetaMantProgramacionEstablecimiento
    Inherits System.Web.UI.Page

    Private _IDPROGRAMACION As Integer
    Private _ESTADO As Integer

    Private mCompCatalogoProductos As New cCATALOGOPRODUCTOS

    Public Property IDPROGRAMACION() As Integer 'identificador de programacion
        Get
            Return Me._IDPROGRAMACION
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROGRAMACION = Value
            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me.ViewState.Remove("IDPROGRAMACION")
            Me.ViewState.Add("IDPROGRAMACION", Value)
        End Set
    End Property

    Public Property ESTADO() As Integer 'identificador de estado
        Get
            Return Me._ESTADO
        End Get
        Set(ByVal Value As Integer)
            Me._ESTADO = Value
            If Not Me.ViewState("ESTADO") Is Nothing Then Me.ViewState.Remove("ESTADO")
            Me.ViewState.Add("ESTADO", Value)
        End Set
    End Property

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/URMIM/frmDetaMantProgramacionProducto.aspx?id=" & Me.ViewState("IDPROGRAMACION"), False)
    End Sub

    Private Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar

        Dim arr As New ArrayList

        For Each row As GridViewRow In gvLista.Rows

            Dim eComponente As New PROGRAMACIONPRODUCTO

            eComponente.IDPROGRAMACION = Me.gvLista.DataKeys(row.RowIndex).Values(0)
            eComponente.IDESTABLECIMIENTO = Me.gvLista.DataKeys(row.RowIndex).Values(1)
            eComponente.PRESUPUESTOREAL = Me.gvLista.DataKeys(row.RowIndex).Values(3)

            eComponente.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eComponente.AUFECHAMODIFICACION = Now

            Dim txtAd As eWorld.UI.NumericBox

            txtAd = row.FindControl("txtMonto")

            If txtAd.Text <> "" Then

                If Val(txtAd.Text) <> eComponente.PRESUPUESTOREAL Then
                    eComponente.PRESUPUESTOREAL = Val(txtAd.Text)
                    arr.Add(eComponente)
                End If

            End If

        Next

        If arr.Count > 0 Then

            Dim cComponente As New cPROGRAMACIONPRODUCTO
            If cComponente.actualizarProgramacionMonto(arr) = -1 Then
                Me.MsgBox1.ShowAlert("Error al guardar los registros.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Exit Sub

            End If

        End If

        Call CargarDatos()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            If Request.QueryString("id") = "" Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirGuardar = True

            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            Me.IDPROGRAMACION = lId


            Dim cComponente As New cPROGRAMACION
            Dim eComponente As New PROGRAMACION
            eComponente = cComponente.obtenerProgramacionPorID(lId)

            Me.ESTADO = eComponente.ESTADO
            If eComponente.ESTADO >= 3 Then
                Me.PnlAgregarProducto.Enabled = False
                Me.gvLista.Enabled = False
            End If

            CargarDatos()

            'Panel para agregar productos
            cargarEstablecimientos()

        Else

            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me._IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")

        End If

    End Sub

    Private Sub cargarEstablecimientos()

        Me.cboEst.Items.Clear()

        Me.cboEst.Items.Add("[Seleccione un establecimiento]")
        Dim bEntidadEst As New cESTABLECIMIENTOS

        Me.cboEst.DataValueField = "idEstablecimiento"
        Me.cboEst.DataTextField = "nombre"

        Me.cboEst.DataSource = bEntidadEst.obtenerHospitalesRegionesParaiso(Me.ViewState("IDPROGRAMACION"))

        Me.cboEst.DataBind()


    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACION

        ds = mComponente.obtenerEstablecimientosProgramacion(Me.IDPROGRAMACION)

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim monto As Decimal
            monto = Me.gvLista.DataKeys(e.Row.RowIndex).Values(3)

            Dim txtAd As eWorld.UI.NumericBox

            txtAd = e.Row.FindControl("txtMonto")
            txtAd.Text = monto

            If Me.gvLista.DataKeys(e.Row.RowIndex).Values(2) >= 3 Then
                txtAd.Enabled = False
            End If

        End If
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting

        Dim cComponente As New cPROGRAMACION

        'al eliminar un registro del gridview
        Dim IDPROGRAMACION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDESTABLECIMIENTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(1)

        If cComponente.eliminarProgramacionEstablecimiento(IDPROGRAMACION, IDESTABLECIMIENTO) < 1 Then
            Me.MsgBox1.ShowAlert("Error al eliminar el registro.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Call CargarDatos()
        Call cargarEstablecimientos()

    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        If Me.cboEst.SelectedIndex = 0 Then
            Me.MsgBox1.ShowAlert("Debe seleccionar un establecimiento.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else

            'Obtenemos el detalle de la programacion de compras
            Dim cEntidad As New cPROGRAMACION

            'Creamos nuestro universo de datos para el establecimiento según su tipo
            If cEntidad.agregarProgramacionEstablecimientos(Me.ViewState("IDPROGRAMACION"), Me.cboEst.SelectedItem.Value, HttpContext.Current.User.Identity.Name) = -1 Then
                Me.MsgBox1.ShowAlert("Imposible agregar el establecimiento", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Exit Sub

            Else
                cargarEstablecimientos()
                CargarDatos()

            End If

        End If


    End Sub
End Class
