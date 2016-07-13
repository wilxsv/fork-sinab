Imports System.Data

Partial Class Controles_ucFiltrarDatos
    Inherits System.Web.UI.UserControl

    Private _ValorFiltro As String
    Private _CampoFiltro As String
    Private _CampoTexto As String

    Private _Columnas As ArrayList
    Private _ColumnasExcluidas As New ArrayList

    Private _ValorColumnas As System.Web.UI.WebControls.DataControlFieldCollection

    Public Event Buscar()

    Public Property ValorFiltro() As String
        Get
            Return _ValorFiltro
        End Get
        Set(ByVal Value As String)
            _ValorFiltro = Value
            If Not Me.ViewState("ValorFiltro") Is Nothing Then Me.ViewState.Remove("ValorFiltro")
            Me.ViewState.Add("ValorFiltro", Value)
        End Set
    End Property

    Public Property CampoFiltro() As String
        Get
            Return _CampoFiltro
        End Get
        Set(ByVal Value As String)
            _CampoFiltro = Value
            If Not Me.ViewState("CampoFiltro") Is Nothing Then Me.ViewState.Remove("CampoFiltro")
            Me.ViewState.Add("CampoFiltro", Value)
        End Set
    End Property

    Public Property CampoTexto() As String
        Get
            Return _CampoTexto
        End Get
        Set(ByVal Value As String)
            _CampoTexto = Value
            If Not Me.ViewState("CampoTexto") Is Nothing Then Me.ViewState.Remove("CampoTexto")
            Me.ViewState.Add("CampoTexto", Value)
        End Set
    End Property

    Public Property ValorColumnas() As System.Web.UI.WebControls.DataControlFieldCollection
        Get
            Return Me._ValorColumnas
        End Get
        Set(ByVal Value As System.Web.UI.WebControls.DataControlFieldCollection)
            Me._ValorColumnas = Value
            mostrarPanel()
            validarColumnas()
            cargarDatos()
        End Set
    End Property

    Public Sub AddColumnasExcluidas(ByVal valor As String)
        _ColumnasExcluidas.Add(valor)
    End Sub

    Private Sub validarColumnas()

        Dim cll As System.Web.UI.WebControls.BoundField
        Dim i As Integer

        _Columnas = New ArrayList

        For i = 0 To _ValorColumnas.Count - 1
            If _ValorColumnas(i).GetType.Name = "BoundField" And _ValorColumnas(i).Visible Then
                cll = _ValorColumnas(i)

                If Not _ColumnasExcluidas.Contains(cll.HeaderText.ToString) Then
                    Dim stemp(1) As String
                    stemp(0) = cll.DataField.ToString
                    stemp(1) = cll.HeaderText.ToString
                    _Columnas.Add(stemp)
                End If

            End If
        Next

    End Sub

    Private Sub cargarDatos()
        Dim en As IEnumerator
        Dim stemp(1) As String

        Dim ds As New DataSet
        Dim tbl As New DataTable("filtros")
        Dim col As DataColumn
        Dim dr As DataRow

        Me.ddFiltro.Items.Clear()
        Me.ddFiltro.Items.Add("No filtrar resultados")

        en = _Columnas.GetEnumerator

        col = New DataColumn("descripcion", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)

        col = New DataColumn("columna", System.Type.GetType("System.String"))
        tbl.Columns.Add(col)

        dr = tbl.Rows.Add

        dr(0) = ""
        dr(1) = "No filtrar datos..."

        While en.MoveNext
            stemp = en.Current
            dr = tbl.Rows.Add

            dr(0) = stemp(0)
            dr(1) = stemp(1)
        End While

        ds.Tables.Add(tbl)

        Me.ddFiltro.DataSource = ds
        Me.ddFiltro.DataTextField = "columna"
        Me.ddFiltro.DataValueField = "descripcion"

        Me.ddFiltro.DataBind()

    End Sub

    Protected Sub ddFiltro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddFiltro.SelectedIndexChanged
        If Me.ddFiltro.SelectedIndex = 0 Then
            Me.txtFiltro.Text = ""
        End If
    End Sub

    Private Sub mostrarPanel()
        If ddFiltro.SelectedIndex > 0 Then
            Me.Panel1.Visible = True
            Me.lblColumna.Text = CampoTexto
            Me.lblTabla.Text = ValorFiltro
        Else
            CampoFiltro = String.Empty
            CampoTexto = String.Empty
            Me.Panel1.Visible = False
        End If
    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        ValorFiltro = Me.txtFiltro.Text
        If ddFiltro.SelectedIndex > 0 Then
            CampoFiltro = ddFiltro.SelectedValue
            CampoTexto = ddFiltro.SelectedItem.Text
            Me.Panel1.Visible = True
            Me.lblColumna.Text = CampoTexto
            Me.lblTabla.Text = ValorFiltro
        Else
            CampoFiltro = String.Empty
            CampoTexto = String.Empty
            Me.Panel1.Visible = False
        End If

        RaiseEvent Buscar()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not Me.ViewState("ValorFiltro") Is Nothing Then Me._ValorFiltro = Me.ViewState("ValorFiltro")
            If Not Me.ViewState("CampoFiltro") Is Nothing Then Me._CampoFiltro = Me.ViewState("CampoFiltro")
            If Not Me.ViewState("CampoTexto") Is Nothing Then Me._CampoTexto = Me.ViewState("CampoTexto")
        End If
    End Sub

End Class
