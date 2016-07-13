
Imports System.Linq
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Utils

Partial Class ALMACEN_FrmNivelAbastecimiento
    Inherits System.Web.UI.Page


    Private Sub CargarSemanasActuales(semana As Integer)
        With ddlSemanaAbas
            .DataSource = SINAB_Utils.Semana.ObtenerTodasHastaHoy()
            .DataTextField = "Value"
            .DataValueField = "Key"
            .DataBind()
        End With
        ddlSemanaAbas.SelectedValue = semana.ToString()
    End Sub

    Private Property InicioSemana As Date
        Get
            Return CType(ViewState("iw"), Date)
        End Get
        Set(value As Date)
            ViewState("iw") = value
        End Set
    End Property

    Private Property SumatoriaAbas() As Decimal
        Get
            Return CType(ViewState("sa"), Decimal)
        End Get
        Set(value As Decimal)
            ViewState("sa") = value
        End Set
    End Property

    Private ReadOnly Property PromedioAbas() As String
        Get
            Dim sum = Math.Round(SumatoriaAbas, 2)
            Return String.Format("{0}%", Math.Round((sum / (Rownum - 1)), 1))
        End Get
    End Property

    Private ReadOnly Property PromedioDesabas() As String
        Get
            Dim sum = Math.Round(SumatoriaAbas, 2)
            Dim dis = Math.Round((sum / (Rownum - 1)), 2)
            Dim div = Math.Round((100 - dis), 1)
            Return String.Format("{0}%", div)
        End Get
    End Property
    Private Property Rownum() As Int32
        Get
            Return CType(ViewState("rn"), Int32)
        End Get
        Set(value As Int32)
            ViewState("rn") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.Label2.Text = DateTime.Now.Year

            'Asi se llenan los años:
            Dim currentYear = DateTime.Now.Year
            For y As Integer = 2011 To currentYear
                ddlAnioAbas.Items.Add(New ListItem(y.ToString(), y.ToString()))
            Next
            ddlAnioAbas.SelectedValue = currentYear.ToString()

            'asi se llenan la semana
            Dim numerosemana = Semana.ObtenerNumero()
            CargarSemanasActuales(numerosemana)



            Using db As New SinabEntities
                Suministros.CargarALista(db, ddlSuministro, True)
                Programas.CargarALista(db, ddlProgramas)
            End Using


            Dim item As New ListItem("(Todos)", 0)
            Me.ddlProgramas.Items.Insert(0, item)
            Me.ddlProgramas.SelectedIndex = 0

            rownum = 1
            CargarDatos()

        End If

    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Protected Sub CargarDatos()
        Dim cA As New ABASTECIMIENTOS.NEGOCIO.cALMACENES

        If Not Me.ddlSemanaAbas.SelectedValue = "" Then
            InicioSemana = Semana.FechaInicio(CType(ddlAnioAbas.SelectedValue, Integer), CType(ddlSemanaAbas.SelectedValue, Integer))

            Me.grvAlmacenes.DataSource = Almacen.ObtenerTodosConCuandroBasico()
            Me.grvAlmacenes.DataBind()

            'Me.Label1.Text = FormatPercent(cA.ObtenerPromedioNacional(Me.ddlSemanaAbas.SelectedValue, Me.ddlSuministro.SelectedValue, ddlAnioAbas.SelectedValue), 1, TriState.False)
            ' Me.Label5.Text = Format(100 - (cA.ObtenerPromedioNacional(Me.ddlSemanaAbas.SelectedValue, Me.ddlSuministro.SelectedValue, ddlAnioAbas.SelectedValue) * 100), "##,##0.0") & "%"

            'Dim cA As New ABASTECIMIENTOS.NEGOCIO.cALMACENES
            'Dim ds As Data.DataSet

            'ds = cA.ObtenerNivelAbastecimientoPantalla(Me.DropDownList2.SelectedValue, Me.DropDownList1.SelectedValue, Me.ddlAnioAbas.SelectedValue)
            ltDesabastecimiento.Text = PromedioDesabas
            ltAbastecimiento.Text = PromedioAbas
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cad = String.Format("/Reportes/FrmRptNivelAbastecimiento.aspx?idSe={0}&idS={1}&idA={2}&idP={3}", ddlSemanaAbas.SelectedValue, ddlSuministro.SelectedValue, ddlAnioAbas.SelectedValue, ddlProgramas.SelectedValue)
        Utils.MostrarVentana(cad)
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = sender
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Dim idh As Integer = CType(Me.grvAlmacenes.DataKeys(row.RowIndex).Values(0), Integer)
        Dim cad = String.Format("/Reportes/FrmRptNivelAbastecimientoProductos.aspx?idSe={0}&idS={1}&idH={2}", ddlSemanaAbas.SelectedValue, ddlSuministro.SelectedValue, idh)
        Utils.MostrarVentana(cad)
    End Sub

    Protected Sub ddlSemanaAbas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemanaAbas.SelectedIndexChanged
        CargarDatos()
    End Sub

    Protected Sub ddlAnioAbas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAnioAbas.SelectedIndexChanged

        If ddlAnioAbas.SelectedValue < DateTime.Today.Year Then
            With ddlSemanaAbas
                .DataSource = Semana.ObtenerTodasAnteriores(CType(ddlAnioAbas.SelectedValue, Integer))
                .DataTextField = "Value"
                .DataValueField = "Key"
                .DataBind()
            End With
        Else
            CargarSemanasActuales(Semana.ObtenerNumero())
        End If
    End Sub

    Protected Sub grvAlmacenes_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grvAlmacenes.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'im nb = CType(e.Row.FindControl("chkExistencias"), CheckBox)
            Dim idalmacen = grvAlmacenes.DataKeys(e.Row.RowIndex).Values(0)
            Dim res = ProductoAlmacen.ObtenerDesabastecimiento(CType(idalmacen, Integer), CType(ddlSuministro.SelectedValue, Integer), CType(ddlSemanaAbas.SelectedValue, Integer), InicioSemana, CType(ddlAnioAbas.SelectedValue, Integer))
            Dim desabas = CType(e.Row.FindControl("ltDes"), Literal)
            Dim abas = CType(e.Row.FindControl("ltAbas"), Literal)
            Dim cb = CType(e.Row.FindControl("ltCuadroBasico"), Literal)
            Dim lnkDesabas = CType(e.Row.FindControl("lnkDesabas"), LinkButton)
            Dim rowText = CType(e.Row.FindControl("ltNum"), Literal)
            rowText.Text = rownum.ToString()
            rownum += 1
            If res.Any() Then
                Dim info = res.FirstOrDefault()
                With info
                    cb.Text = .cb.ToString()
                    abas.Text = .porcabas.ToString()
                    desabas.Text = .porcdes.ToString()
                    lnkDesabas.Text = .se.ToString()
                    SumatoriaAbas += .porcabas
                End With
            Else
                cb.Text = "-"
                abas.Text = "-"
                desabas.Text = "-"
                lnkDesabas.Text = "-"
                SumatoriaAbas += 0
            End If

        End If
    End Sub
End Class
