
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades.Helpers

Partial Class ALMACEN_FrmDistribucionPorEstablecimiento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim usr = Membresia.ObtenerUsuario()
            Dim dba As New ABASTECIMIENTOS.NEGOCIO.cDistribucion
            Me.Master.ControlMenu.Visible = False

            Me.Label2.Text = DateTime.Now.Year

            ' Me.Label3.Text = dba.ObtenerSemana(DateTime.Now)
            'Me.Label1.Text = dba.ObtenerDatosSemana(Me.Label3.Text)
            Me.ddlAnioAbas.DataSource = dba.AniosDistribuciones()
            Me.ddlAnioAbas.DataTextField = "anio"
            Me.ddlAnioAbas.DataValueField = "anio"
            Me.ddlAnioAbas.DataBind()
            Me.ddlAnioAbas.SelectedValue = Now.Year


            Distribucion.CargarCerradosALista(DropDownList2, usr.Establecimiento.IDESTABLECIMIENTO, CType(ddlAnioAbas.SelectedValue, Integer))

            'Me.DropDownList2.DataSource = dba.ListaDistribucionesCerradas(Me.ddlAnioAbas.SelectedValue, 620, 0, Session("idestablecimiento"), False)
            'Me.DropDownList2.DataTextField = "DESCRIPCION"
            'Me.DropDownList2.DataValueField = "IDDISTRIBUCION"
            'Me.DropDownList2.DataBind()

            'Me.DropDownList2.DataSource = dba.ObtenerSemanasaConsultar()
            'Me.DropDownList2.DataTextField = "SEMANA"
            'Me.DropDownList2.DataValueField = "IDSEMANA"
            'Me.DropDownList2.DataBind()

            'Dim bEntidad2 As New ABASTECIMIENTOS.NEGOCIO.cPROGRAMAS
            'Me.DropDownList3.DataSource = bEntidad2.ObtenerPROGRAMAS
            'Me.DropDownList3.DataValueField = "idPrograma"
            'Me.DropDownList3.DataTextField = "NOMBRE"

            'Me.DropDownList3.DataBind()

            'Dim item As New ListItem("(Todos)", 0)
            'Me.DropDownList3.Items.Insert(0, item)

            'Me.DropDownList3.SelectedIndex = 0


            'Me.DropDownList2.SelectedValue = dba.ObtenerSemana(DateTime.Now) - 1



        End If
        'Button1_Click(sender, e)
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim iddistribucion As Integer = CType(Me.DropDownList2.SelectedValue, Integer)
        Dim idestablecimientodistribucion As Integer = Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO

        Dim idestablecimiento = Distribucion.ObtenerCerrados(iddistribucion, idestablecimientodistribucion).IDESTABLECIMIENTO

        Dim tipo As Integer
        tipo = 0

        'Mostrar el reporte
        Dim alerta As String = "/Reportes/frmRptDistribucion.aspx?id=" & iddistribucion & "&tipo=" & tipo & "&est=" & idestablecimiento & "&prod=0&elaborodist=true"

        SINAB_Utils.Utils.MostrarVentana(alerta)
    End Sub

    Protected Sub ddlAnioAbas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAnioAbas.SelectedIndexChanged
        Dim dba As New ABASTECIMIENTOS.NEGOCIO.cDistribucion
        Me.DropDownList2.DataSource = dba.ListaDistribuciones(Me.ddlAnioAbas.SelectedValue, Session("idestablecimiento"))
        Me.DropDownList2.DataTextField = "DESCRIPCION"
        Me.DropDownList2.DataValueField = "IDDISTRIBUCION"
        Me.DropDownList2.DataBind()
    End Sub
End Class
