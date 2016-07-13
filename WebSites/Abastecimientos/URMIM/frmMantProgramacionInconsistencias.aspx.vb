Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class URMIM_frmMantProgramacionInconsistencias
    Inherits System.Web.UI.Page

    Private _IDPROGRAMACION As Integer
    Private _IDPROGRAMACION2 As Integer
    Private _TIPOREPORTE As Integer

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

    Public Property IDPROGRAMACION2() As Integer 'identificador de programacion
        Get
            Return Me._IDPROGRAMACION2
        End Get
        Set(ByVal Value As Integer)
            Me._IDPROGRAMACION2 = Value
            If Not Me.ViewState("IDPROGRAMACION2") Is Nothing Then Me.ViewState.Remove("IDPROGRAMACION2")
            Me.ViewState.Add("IDPROGRAMACION2", Value)
        End Set
    End Property

    Public Property TIPOREPORTE() As Integer 'identificador de programacion
        Get
            Return Me._TIPOREPORTE
        End Get
        Set(ByVal Value As Integer)
            Me._TIPOREPORTE = Value
            If Not Me.ViewState("TIPOREPORTE") Is Nothing Then Me.ViewState.Remove("TIPOREPORTE")
            Me.ViewState.Add("TIPOREPORTE", Value)
        End Set
    End Property

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Select Case CInt(Me.ViewState("TIPOREPORTE"))
            Case 1 : Response.Redirect("~/URMIM/frmDetaMantProgramacionProducto.aspx?id=" & Me.ViewState("IDPROGRAMACION"), False)
            Case 2 : Response.Redirect("~/URMIM/frmDetaMantDetalleProgramacionEntrega.aspx?id=" & Me.ViewState("IDPROGRAMACION"), False)
            Case 3 : Response.Redirect("~/URMIM/frmDetaMantProgramacionEntrega.aspx?id=" & Me.ViewState("IDPROGRAMACION"), False)
        End Select

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página
            'ocultar menu

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Or Request.QueryString("tipo") Is Nothing Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            If Request.QueryString("id") = "" Or Request.QueryString("tipo") = "" Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            If Not IsNumeric(Request.QueryString("id")) Or Not IsNumeric(Request.QueryString("tipo")) Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirCancelar = True

            Dim lId As String = Request.QueryString("id") 'identificador de usuario

            IDPROGRAMACION = lId
            TIPOREPORTE = Request.QueryString("tipo")

            If CInt(Request.QueryString("tipo")) < 1 Or CInt(Request.QueryString("tipo")) > 3 Then
                Response.Redirect("~/URMIM/frmMantProgramacion.aspx", False)
            End If

            Dim cEntidad As New cPROGRAMACION
            Dim eEntidad As PROGRAMACION = cEntidad.obtenerProgramacionPorID(lId)

            Me.lblNProgramacion.Text = eEntidad.DESCRIPCION

            Select Case Request.QueryString("tipo")
                Case 1 : Me.lblTitulo.Text = "Inconsistencias en Precios"
                Case 2 : Me.lblTitulo.Text = "Inconsistencias en Entregas"
                Case 3 : Me.lblTitulo.Text = "Inconsistencias en la Tabla de Entregas"
            End Select

            CargarDatos()

        Else

            If Not Me.ViewState("IDPROGRAMACION") Is Nothing Then Me._IDPROGRAMACION = Me.ViewState("IDPROGRAMACION")

        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cPROGRAMACION

        ds = mComponente.obtenerDsProgramacionFiltrada(Me.ViewState("IDPROGRAMACION"))

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Sub cargardatos2()

        Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMACION

        Select Case CInt(Me.ViewState("TIPOREPORTE"))
            Case 1
                Me.gvLista2.DataSource = cEntidad.inconsistenciasPrecios(Me.ViewState("IDPROGRAMACION"), Me.ViewState("IDPROGRAMACION2"))
                Me.gvLista2.DataBind()
            Case 2
                Me.gvLista2.DataSource = cEntidad.inconsistenciasEntregas(Me.ViewState("IDPROGRAMACION"), Me.ViewState("IDPROGRAMACION2"))
                Me.gvLista2.DataBind()
        End Select

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging

        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()

    End Sub

    Protected Sub chk1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim ckb As CheckBox = sender
        Dim rowCkb As GridViewRow = sender.parent.parent

        If ckb.Checked = False Then Exit Sub

        For Each row As GridViewRow In gvLista.Rows

            If rowCkb.RowIndex <> row.RowIndex Then
                Dim ckb2 As CheckBox = row.FindControl("chkSelect")
                ckb2.Checked = False
            End If

        Next

    End Sub

    Protected Sub btnComparar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComparar.Click

        Me.lblTit2.Text = ""
        Me.gvLista2.Visible = False
        Me.gvLista2.DataSource = Nothing
        Me.gvLista2.DataBind()

        Dim xidProgramacion As Integer = 0
        Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMACION

        For Each row As GridViewRow In gvLista.Rows

            Dim ckb As CheckBox = row.FindControl("chkSelect")

            If ckb.Checked = True Then
                xidProgramacion = Me.gvLista.DataKeys(row.RowIndex).Values(0)
                Exit For
            End If

        Next

        If xidProgramacion = 0 Then
            Me.lblTit2.Text = "Debe seleccionar una programación para comparar"
            Exit Sub
        End If

        IDPROGRAMACION2 = xidProgramacion

        Select Case CInt(Me.ViewState("TIPOREPORTE"))
            Case 1
                Me.gvLista2.DataSource = cEntidad.inconsistenciasPrecios(Me.ViewState("IDPROGRAMACION"), xidProgramacion)
                Me.gvLista2.DataBind()
                Me.gvLista2.Visible = True
            Case 2
                Me.gvLista2.DataSource = cEntidad.inconsistenciasEntregas(Me.ViewState("IDPROGRAMACION"), xidProgramacion)
                Me.gvLista2.DataBind()
                Me.gvLista2.Visible = True
            Case 3
                If cEntidad.inconsistenciasTablaEntregas(Me.ViewState("IDPROGRAMACION"), xidProgramacion) > 0 Then
                    Me.lblTit2.Text = "Existe inconsistencias en las tablas de entregas"
                Else
                    Me.lblTit2.Text = "No se detectaron inconsistencias"
                End If
        End Select

    End Sub

    Protected Sub gvLista2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista2.PageIndexChanging
        Me.gvLista2.PageIndex = e.NewPageIndex
        Call cargardatos2()
    End Sub

End Class
