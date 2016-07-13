
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports CrystalDecisions.Web.Services
Imports System.Linq
Imports System.Collections.Generic
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils

Partial Class ALMACEN_FrmReporteProductosSinExistencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dba As New ABASTECIMIENTOS.NEGOCIO.cALMACENES
            Me.Master.ControlMenu.Visible = False

            Me.Label2.Text = DateTime.Now.Year.ToString()

            Me.Label3.Text = Semana.ObtenerInformacion(DateTime.Now.Year, Semana.ObtenerNumero())


            CatalogoHelpers.Suministros.CargarALista(DropDownList1, True)
            'Dim cS As New ABASTECIMIENTOS.NEGOCIO.cSUMINISTROS
            'Me.DropDownList1.DataSource = cS.RecuperarOrdenadaPorCorrelativo
            'Me.DropDownList1.DataTextField = "DESCRIPCION"
            'Me.DropDownList1.DataValueField = "IDSUMINISTRO"
            'Me.DropDownList1.DataBind()


        End If

    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'paso 1: Borrar datos en sab_alm_productossinexistencias

        Dim usr = Membresia.ObtenerUsuario()
        ProductoSinExistencia.EliminarTodos(usr.Almacen.IDALMACEN, CType(DropDownList1.SelectedValue, Integer), SINAB_Utils.Semana.ObtenerNumero())


        Dim ds = ProductoSinExistencia.ObtenerTodos(usr.Almacen.IDALMACEN, CType(DropDownList1.SelectedValue, Integer))

        Dim res = New List(Of SAB_ALM_PRODUCTOSSINEXISTENCIA)
        Dim semana = SINAB_Utils.Semana.ObtenerNumero()
        For Each dr As prc_ProductosSinExistenciaLocal_Result In ds
            Dim pse = New SAB_ALM_PRODUCTOSSINEXISTENCIA
            With pse
                .IDALMACEN = usr.Almacen.IDALMACEN
                .IDSEMANA = semana
                .IDSUMINISTRO = CType(Me.DropDownList1.SelectedValue, Integer)
                .IDPRODUCTO = dr.IDPRODUCTO
                .ANIO = DateTime.Now.Year
                .EXISTENCIAFARMACIA = 0
                .AUFECHACREACION = DateTime.Now
                .AUUSUARIOCREACION = Membresia.ObtenerUsuario().NombreUsuario
            End With
            res.Add(pse)
            'dba.AdicionarProductosSinExistencia(, dba.ObtenerSemana(DateTime.Now), Me.DropDownList1.SelectedValue, dr(4))
        Next

        ProductoSinExistencia.AgregarTodos(res)

        'paso 3: Lanzar el reporte

        Dim cad = String.Format("/Reportes/FrmRptProductosSinExistencia.aspx?idA={0}&idS={1}", usr.Almacen.IDALMACEN, DropDownList1.SelectedValue)
        SINAB_Utils.Utils.MostrarVentana(cad)


    End Sub
End Class
