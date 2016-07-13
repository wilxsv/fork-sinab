Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Collections.Generic
Imports System.Linq
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers

Partial Class Controles_diVistaDetalleDistribucion
    Inherits System.Web.UI.UserControl

#Region "Metodos del Grid"

    Private Property Distribuciones As List(Of SAB_EST_DISTRIBUCION)
        Get
            Return CType(ViewState("DS_Distros"), List(Of SAB_EST_DISTRIBUCION))
        End Get
        Set(value As List(Of SAB_EST_DISTRIBUCION))
            ViewState("DS_Distros") = value
        End Set
    End Property

    Private Property DistribucionesFiltradas As List(Of SAB_EST_DISTRIBUCION)
        Get
            Dim res = CType(ViewState("DS_FiltroDistros"), List(Of SAB_EST_DISTRIBUCION))
            If IsNothing(res) Then Return New List(Of SAB_EST_DISTRIBUCION)()
            Return res
        End Get
        Set(value As List(Of SAB_EST_DISTRIBUCION))
            ViewState("DS_FiltroDistros") = value
        End Set
    End Property


    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        CargarGrid()

    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim hp1 As HyperLink = e.Row.FindControl("hlP")
            Dim hp2 As HyperLink = e.Row.FindControl("hlE")
            Dim hp3 As HyperLink = e.Row.FindControl("hlD")

            Select Case Me.gvLista.DataKeys(e.Row.RowIndex).Values(1)
                Case 0
                    hp3.Visible = False
                Case 1
                    hp3.Visible = True
                Case 2
                    hp3.Visible = True
                    hp1.Text = "Ver"
                    hp2.Text = "Ver"
                    hp3.Text = "Ver"
                Case 3
                    hp1.Text = "Ver"
                    hp2.Text = "Ver"
                    hp3.Text = "Ver"
                Case 4
                    hp1.Text = "Ver"
                    hp2.Text = "Ver"
                    hp3.Text = "Ver"
            End Select

        End If
    End Sub

    Public Sub CargarGrid() 'carga los datos y los muestra en el gridview
        Dim usr = Membresia.ObtenerUsuario()
       
        If Not DistribucionesFiltradas.Any() Then
            Distribuciones = EstablecimientoHelpers.Distribucion.ObtenerTodos(usr.ESTABLECIMIENTO.IDESTABLECIMIENTO, usr.NombreUsuario)
            DistribucionesFiltradas = Distribuciones
        End If

        Me.gvLista.DataSource = DistribucionesFiltradas

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        If Not Page.IsPostBack Then
            LlenaFiltros()
        End If
    End Sub


#End Region


    ''' <summary>
    ''' Llena el dropdownlist de filros solo con los campos databound de la grid
    ''' </summary>
    ''' <remarks>Desarrollo-MINSAL 06/03/2013</remarks>
    Private Sub LlenaFiltros()
        Dim dsFiltro As New Data.DataSet("DSFILTROS")
        dsFiltro.Tables.Add("FILTROS")
        dsFiltro.Tables("FILTROS").Columns.Add("DESCRIPCION")
        dsFiltro.Tables("FILTROS").Columns.Add("CAMPO")

        For Each dc As Object In Me.gvLista.Columns
            If TypeOf dc Is BoundField Then
                Dim FILA As Data.DataRow = dsFiltro.Tables("FILTROS").NewRow
                FILA("CAMPO") = CType(dc, BoundField).DataField
                FILA("DESCRIPCION") = CType(dc, BoundField).HeaderText
                dsFiltro.Tables("FILTROS").Rows.Add(FILA)
            End If
        Next
        ddlFiltro.DataSource = dsFiltro.Tables("FILTROS")

        ddlFiltro.DataTextField = "DESCRIPCION"
        ddlFiltro.DataValueField = "CAMPO"
        ddlFiltro.DataBind()
        ddlFiltro.Items.Insert(0, New ListItem("Parámetro", String.Empty))
    End Sub

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        If Me.ddlFiltro.SelectedValue <> "0" Then
            Dim dvPC As New Data.DataView(CType(Me.ViewState("DS_Distros"), Data.DataSet).Tables(0))
            'dvPC.Sort = "FECHAINICIOPROCESOCOMPRA DESC"

            Select Case Me.ddlFiltro.SelectedValue
                Case "IDDISTRIBUCION"
                    'CAST(10.6496 AS int)
                    If Me.ddlOperadorBusqueda.SelectedValue = "LIKE" Then
                        dvPC.RowFilter = "convert(" & ddlFiltro.SelectedValue & " , 'System.String') LIKE '%" & txtFiltro.Text & "%'"
                    Else
                        dvPC.RowFilter = ddlFiltro.SelectedValue + " " + Me.ddlOperadorBusqueda.SelectedValue + " " + txtFiltro.Text
                    End If
                Case "NESTADO"
                    dvPC.RowFilter = "convert(" & ddlFiltro.SelectedValue & " , 'System.String') LIKE '%" & Me.ddlEstados.SelectedValue & "%'"
                Case Else
                    dvPC.RowFilter = "convert(" & ddlFiltro.SelectedValue & " , 'System.String') LIKE '%" & txtFiltro.Text & "%'"
            End Select


            Dim dsFiltered As New Data.DataSet
            dsFiltered.Tables.Add(dvPC.ToTable())

            Me.gvLista.DataSource = dsFiltered
            Me.gvLista.DataBind()

            Me.ViewState("DS_FiltroDistros") = dsFiltered
            ChangeStatus(False)
        End If
    End Sub

    Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click

        DistribucionesFiltradas.Clear()
        Me.gvLista.DataSource = Distribuciones
        Me.gvLista.DataBind()
        ChangeStatus(True)
    End Sub

    Protected Sub ddlFiltro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not String.IsNullOrEmpty(ddlFiltro.SelectedValue) Then
            ShowHideItems(True)
            If Me.ddlFiltro.SelectedValue <> "IDDISTRIBUCION" Then
                Me.ddlOperadorBusqueda.Visible = False
            End If

            If Me.ddlFiltro.SelectedValue = "NESTADO" Then
                Me.ddlEstados.Visible = True
                Me.txtFiltro.Visible = False
            Else
                Me.ddlEstados.Visible = False
                Me.txtFiltro.Visible = True
            End If
        Else
            ShowHideItems(False)
        End If
    End Sub
    Private Sub ShowHideItems(ByVal status As Boolean)
        Me.ddlOperadorBusqueda.Visible = status
        Me.ddlEstados.Visible = status
        Me.txtFiltro.Visible = status
        Me.btnFind.Visible = status
    End Sub
    Private Sub ChangeStatus(ByVal status As Boolean)
        Me.ddlOperadorBusqueda.Enabled = status
        Me.ddlEstados.Enabled = status
        Me.ddlFiltro.Enabled = status
        Me.txtFiltro.Enabled = status
        Me.btnFind.Visible = status
        Me.btnRemove.Visible = Not status
        If status Then
            Me.ddlFiltro.SelectedIndex = 0
            Me.txtFiltro.Text = String.Empty
            ShowHideItems(False)
        End If
    End Sub


End Class

