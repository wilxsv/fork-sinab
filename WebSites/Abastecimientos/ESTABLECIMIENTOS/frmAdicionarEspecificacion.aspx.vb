Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class ESTABLECIMIENTOS_frmAdicionarEspecificacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.Label7.Text = Request.QueryString("idprod")
            Me.Label1.Text = Request.QueryString("renglon")

            'Datos del producto
            Dim bEntidad1 As New cCATALOGOPRODUCTOS
            Dim entidadvista = 0

            If Not String.IsNullOrEmpty(Request.QueryString("idprod")) Then entidadvista = CType(Request.QueryString("idprod"), Integer)

            Dim eEntidad As CATALOGOPRODUCTOS = bEntidad1.devolverEntidadVista(entidadvista)

            Me.lblCodProd.Text = eEntidad.CODIGO
            Me.lblUM.Text = eEntidad.CONCENTRACION
            Me.lblNomProd.Text = eEntidad.NOMBRE

            Dim cds As New cDETALLESOLICITUDES
            'cargar grid especificaciones
            Me.GridView5.DataSource = cds.ObtenerEspecificacion(Session("IdEstablecimiento"), entidadvista, 0)
            Me.GridView5.DataBind()


            If Request.QueryString("btndet") <> "Adicionar >>" Then
                'cargar la especificacion
                Dim IDESPECIFICACION As Integer = CType(Request.QueryString("idesp"), Integer)
                Me.Label10.Text = IDESPECIFICACION

                Dim DSET As New Data.DataSet
                DSET = cds.ObtenerEspecificacion(Session("IdEstablecimiento"), entidadvista, IDESPECIFICACION)
                'Me.Label3.Text = DSET.Tables(0).Rows(0).Item(2)
                'Me.Label2.Text = DSET.Tables(0).Rows(0).Item(1)
                Me.Panel1.Visible = True

            End If

        Else

        End If

    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Request.QueryString("cj") Is Nothing Or Request.QueryString("cj") = "" Then
            Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompraProductos.aspx?id=" & Request.QueryString("idsol") & "&idsu=" & Request.QueryString("idsu") & "&cj=" & Request.QueryString("cj"))
        Else
            Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompraProductosConsolidado.aspx?idsol=" & Request.QueryString("idsol") & "&idsu=" & Request.QueryString("idsu"))
        End If

    End Sub
    Protected Sub GridView5_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView5.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim nb As LinkButton
            nb = e.Row.FindControl("LinkButton12")
            nb.Text = GridView5.DataKeys(e.Row.RowIndex).Values(3)

        End If
    End Sub
    Protected Sub LinkButton12_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails As LinkButton = sender

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        Dim cds As New cDETALLESOLICITUDES
        Me.Label2.Text = Me.GridView5.DataKeys(row.RowIndex).Values(3)
        Dim ds As New Data.DataSet
        ds = cds.ObtenerEspecificacion(Session("IdEstablecimiento"), Me.GridView5.DataKeys(row.RowIndex).Values(1), Me.GridView5.DataKeys(row.RowIndex).Values(2))
        Me.Label3.Text = ds.Tables(0).Rows(0).Item(2)

        Me.Panel1.Visible = True
    End Sub
    Protected Sub GridView5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView5.SelectedIndexChanged

        'actualizar el Idespecificacion en ps
        Dim cds As New cDETALLESOLICITUDES
        Dim PS As New PRODUCTOSSOLICITUD
        PS.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        PS.IDSOLICITUD = Request.QueryString("idsol")
        PS.IDPRODUCTO = Me.GridView5.DataKeys(Me.GridView5.SelectedIndex).Values(1)
        PS.IDESPECIFICACION = Me.GridView5.DataKeys(Me.GridView5.SelectedIndex).Values(2)
        PS.IDDEPENDENCIA = Session("IdDependencia")
        PS.RENGLON = Me.Label1.Text

        cds.actualizarProductoSolicitud3(PS)

        If Request.QueryString("cj") Is Nothing Or Request.QueryString("cj") = "" Then
            Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompraProductos.aspx?id=" & Request.QueryString("idsol") & "&idsu=" & Request.QueryString("idsu") & "&cj=" & Request.QueryString("cj"))
        Else
            Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompraProductosConsolidado.aspx?idsol=" & Request.QueryString("idsol") & "&idsu=" & Request.QueryString("idsu"))
        End If


    End Sub

End Class
