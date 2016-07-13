Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmMantCatalogosRoles
    Inherits System.Web.UI.Page

    Private mComponente As New cOPCIONESSISTEMA

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirGuardar = True
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.PermitirImprimir = False
            'Me.ucBarraNavegacion1.ibtnImprimirOnClientClick = ReporteOpcionesRoles()

            Me.ddlROLES1.RecuperarListaRolesHabilitados()

            If Request.QueryString.HasKeys Then
                Dim lId As Int32 = Request.QueryString("idRol")
                Me.ddlROLES1.SelectedValue = lId
            End If

            CargarDatos()

        End If

    End Sub

    Private Sub CargarDatos()

        Dim ds As Data.DataSet
        ds = Me.mComponente.ObtenerOpcionesPorRol(Me.ddlROLES1.SelectedValue, True)

        Dim dsVista As New Data.DataView(ds.Tables(0))

        If ucFiltrarDatos1.CampoFiltro <> "" And ucFiltrarDatos1.ValorFiltro <> "" Then
            Try
                Select Case dsVista.Table.Columns(ucFiltrarDatos1.CampoFiltro).DataType.Name
                    Case "String"
                        dsVista.RowFilter = ucFiltrarDatos1.CampoFiltro & " LIKE '%" & ucFiltrarDatos1.ValorFiltro & "%'"
                    Case "DateTime"
                        dsVista.RowFilter = ucFiltrarDatos1.CampoFiltro & " = '" & ucFiltrarDatos1.ValorFiltro & "'"
                    Case Else
                        dsVista.RowFilter = ucFiltrarDatos1.CampoFiltro & " = " & ucFiltrarDatos1.ValorFiltro
                End Select
            Catch ex As Exception

            End Try

        End If

        Me.gvLista.DataSource = dsVista

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        If Not Page.IsPostBack Then ucFiltrarDatos1.ValorColumnas = gvLista.Columns

    End Sub

    Protected Sub ddlROLES1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlROLES1.SelectedIndexChanged
        CargarDatos()
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Private Function ReporteOpcionesRoles() As String
        Dim cad = "/Reportes/FrmRptOpcionesRoles.aspx?op=1"

        'Dim s As New StringBuilder

        's.Append("window.open('")
        '.Append(Request.ApplicationPath)
        ' s.Append("/Reportes/FrmRptOpcionesRoles.aspx?op=1")
        's.Append("', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")
        '

        Return SINAB_Utils.Utils.ReferirVentana(cad)
        's.ToString()
    End Function

    Protected Sub ucFiltrarDatos1_Buscar() Handles ucFiltrarDatos1.Buscar
        CargarDatos()
    End Sub

    Protected Sub ucBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Guardar

        Dim cOSR As New cOPCIONESSISTEMAROLES

        For Each row As GridViewRow In gvLista.Rows

            Dim PERMITEEDITAR As Integer = IIf(CType(row.FindControl("cbPermiteEditar"), CheckBox).Checked(), 1, 0)

            If PERMITEEDITAR <> Me.gvLista.DataKeys(row.RowIndex).Values.Item("PERMITEEDITAR") Then

                Dim eOSR As New OPCIONESSISTEMAROLES

                eOSR.IDOPCIONSISTEMA = Me.gvLista.DataKeys(row.RowIndex).Values.Item("IDOPCIONSISTEMA")
                eOSR.IDROL = ddlROLES1.SelectedValue
                eOSR.PERMITEEDITAR = PERMITEEDITAR
                eOSR.AUUSUARIOCREACION = IIf(Me.gvLista.DataKeys(row.RowIndex).Values.Item("AUUSUARIOCREACION") Is DBNull.Value, Nothing, Me.gvLista.DataKeys(row.RowIndex).Values.Item("AUUSUARIOCREACION"))
                eOSR.AUFECHACREACION = IIf(Me.gvLista.DataKeys(row.RowIndex).Values.Item("AUFECHACREACION") Is DBNull.Value, Nothing, Me.gvLista.DataKeys(row.RowIndex).Values.Item("AUFECHACREACION"))
                eOSR.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                eOSR.AUFECHAMODIFICACION = Now

                cOSR.ActualizarOPCIONESSISTEMAROLES(eOSR)

            End If

        Next

        CargarDatos()

    End Sub

End Class
