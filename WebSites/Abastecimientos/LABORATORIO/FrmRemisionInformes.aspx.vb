
Partial Class FrmRemisionInformes
    Inherits System.Web.UI.Page

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            cargar()
        End If
    End Sub

    'Carga de datos 
    Public Sub cargar()

        Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS

        Dim ds As Data.DataSet
        ds = cIM.ObtenerFechasRemision(Session.Item("IdEstablecimiento"), "", 0, 0)

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

    'posicion del filtro
    Protected Sub mostrarFiltro()

        If Not ViewState.Item("posicionFiltro") Is Nothing Then
            WucFiltroGrid1.posicionFiltro = CType(ViewState.Item("posicionFiltro"), Integer)
        End If

        WucFiltroGrid1.dataGridMostrar = filtroRemision()
    End Sub

    'Datos que van al filtro
    Private Function filtroRemision() As ArrayList

        Dim e_E As ABASTECIMIENTOS.ENTIDADES.eDatosFiltro
        Dim columnas As New ArrayList

        e_E = New ABASTECIMIENTOS.ENTIDADES.eDatosFiltro("Número Informe", "NUMEROINFORME")
        columnas.Add(e_E)
        e_E = New ABASTECIMIENTOS.ENTIDADES.eDatosFiltro("Tipo Informe", "TIPOINFORME")
        columnas.Add(e_E)
        e_E = New ABASTECIMIENTOS.ENTIDADES.eDatosFiltro("Resultado", "RESULTADO")
        columnas.Add(e_E)

        Return columnas

    End Function

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.Panel2.Visible = True
        Dim lnk As New LinkButton
        lnk = Me.GridView1.Rows(Me.GridView1.SelectedIndex).Cells(0).Controls(1)
        Me.Label1.Text = lnk.Text

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Me.CalendarPopup1.posteddate = "" Then
            Me.Label2.Text = "Debe seleccionar una fecha"
        Else
            Me.Label2.Text = ""

            Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS

            If cIM.ActualizarFechasRemision(Session.Item("IdEstablecimiento"), Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values.Item("IDINFORME"), Me.CalendarPopup1.SelectedDate) <> 1 Then
                Me.Label2.Text = "Error al guardar la fecha."
            End If
            cargar()
            Me.Panel2.Visible = False
            Me.GridView1.SelectedIndex = -1
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.ViewState("columnaFiltro") Is Nothing And Me.ViewState("valorFiltro") Is Nothing Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRemisionInforme.aspx?Campo=0&Valor=0', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        End If
        Select Case Me.ViewState("columnaFiltro").ToString
            Case Is = "NUMEROINFORME"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRemisionInforme.aspx?Campo=1&Valor=" & Me.ViewState("valorFiltro") & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
            Case Is = "TIPOINFORME"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRemisionInforme.aspx?Campo=2&Valor=" & Left(Me.ViewState("valorFiltro"), 1) & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
            Case Is = "RESULTADO"
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRemisionInforme.aspx?Campo=3&Valor=" & Left(Me.ViewState("valorFiltro"), 1) & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        End Select
    End Sub
End Class
