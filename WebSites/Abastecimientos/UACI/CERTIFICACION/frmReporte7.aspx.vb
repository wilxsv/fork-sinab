Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Collections.Generic
Imports SINAB_Entidades.Helpers.CertificacionHelpers
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports SINAB_Entidades.Tipos

Partial Class UACI_CERTIFICACION_frmReporte7
    Inherits System.Web.UI.Page
    Private _idproCESO As Integer
    Public Property idproCESO() As Integer
        Get
            Return Me._idproCESO
        End Get
        Set(ByVal value As Integer)
            Me._idproCESO = value
            If Not Me.ViewState("idproCESO") Is Nothing Then Me.ViewState.Remove("idproCESO")
            Me.ViewState.Add("idproCESO", value)
        End Set
    End Property
    Private _idtipoproducto As Integer
    Public Property idtipoproducto() As Integer
        Get
            Return Me._idtipoproducto
        End Get
        Set(ByVal value As Integer)
            Me._idtipoproducto = value
            If Not Me.ViewState("idtipoproducto") Is Nothing Then Me.ViewState.Remove("idtipoproducto")
            Me.ViewState.Add("idtipoproducto", value)
        End Set
    End Property
    Private _idproveedor As Integer
    Public Property idproveedor() As Integer
        Get
            Return Me._idproveedor
        End Get
        Set(ByVal value As Integer)
            Me._idproveedor = value
            If Not Me.ViewState("idproveedor") Is Nothing Then Me.ViewState.Remove("idproveedor")
            Me.ViewState.Add("idproveedor", value)
        End Set
    End Property
    Private _idproducto As Integer
    Public Property idproducto() As Integer
        Get
            Return Me._idproducto
        End Get
        Set(ByVal value As Integer)
            Me._idproducto = value
            If Not Me.ViewState("idproducto") Is Nothing Then Me.ViewState.Remove("idproducto")
            Me.ViewState.Add("idproducto", value)
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim cx As New cListaCP
            Me.ddlTipoProducto.DataSource = cx.ObtenerSuministros()
            Me.ddlTipoProducto.DataTextField = "DESCRIPCION"
            Me.ddlTipoProducto.DataValueField = "idSuministro"
            Me.ddlTipoProducto.DataBind()

            Me.ddlTipoProducto.SelectedValue = 0

            Dim C As New cProcesoCP
            Me.ddlProceso.DataSource = C.ObtenerPROCESOxSuministro2(Me.ddlTipoProducto.SelectedValue)
            Me.ddlProceso.DataTextField = "NUMPROCESO"
            Me.ddlProceso.DataValueField = "IDPROCESO"
            Me.ddlProceso.DataBind()


        Else
            If Not Me.ViewState("idproCESO") Is Nothing Then Me.idproCESO = Me.ViewState("idproCESO")
            If Not Me.ViewState("idtipoproducto") Is Nothing Then Me.idtipoproducto = Me.ViewState("idtipoproducto")
            If Not Me.ViewState("idproveedor") Is Nothing Then Me.idproveedor = Me.ViewState("idproveedor")
            If Not Me.ViewState("idproducto") Is Nothing Then Me.idproducto = Me.ViewState("idproducto")
        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ddlTipoProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim C As New cProcesoCP
        Me.ddlProceso.DataSource = C.ObtenerPROCESOxSuministro(Me.ddlTipoProducto.SelectedValue)
        Me.ddlProceso.DataTextField = "NUMPROCESO"
        Me.ddlProceso.DataValueField = "IDPROCESO"
        Me.ddlProceso.DataBind()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.SelectedValue = 0 Then
            pnlRazon.Visible = False
            pnlNit.Visible = True

            ddlProceso.DataSource = Nothing
            ddlProceso.DataBind()
        Else
            tbNit.Text = ""
            pnlNit.Visible = False
            pnlRazon.Visible = True
            ProveedoresProceso.CargarALista(CType(ddlProceso.SelectedValue, Decimal), CType(ddlTipoProducto.SelectedValue, Decimal), ddlRazon)
        End If
    End Sub



    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Me.ddlProceso.Items.Count = 0 Then
            Exit Sub
        End If

        Dim ds As New List(Of BaseProductosProveedores)
        'Dim c As New cProcesoCP
        If Me.RadioButtonList1.SelectedValue = 0 Then
            ds = ProductosProveedores.ObtenerReporte(CType(ddlProceso.SelectedValue, Decimal), CType(ddlTipoProducto.SelectedValue, Decimal), Me.tbNit.Text, "", TextBox2.Text, 3)
        Else
            ds = ProductosProveedores.ObtenerReporte(CType(ddlProceso.SelectedValue, Decimal), CType(ddlTipoProducto.SelectedValue, Decimal), "", ddlRazon.SelectedValue, TextBox2.Text, 3)
        End If


        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()
    End Sub

    Protected Sub lnkReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = CType(sender, LinkButton)
        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        idproCESO = CType(Me.GridView1.DataKeys(row.RowIndex).Values(0), Integer)
        idtipoproducto = CType(Me.GridView1.DataKeys(row.RowIndex).Values(1), Integer)
        idproveedor = CType(Me.GridView1.DataKeys(row.RowIndex).Values(2), Integer)
        Dim idpp = CType(Me.GridView1.DataKeys(row.RowIndex).Values(3), Integer)


        SINAB_Utils.Utils.MostrarVentana(String.Format("/UACI/CERTIFICACION/Reportes/FrmReporteComision.aspx?idpc={0}&idtp={1}&idprv={2}&idpp={3}", idproCESO, idtipoproducto, idproveedor, idpp))

    End Sub

End Class
