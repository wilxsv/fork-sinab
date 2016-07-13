Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class frmConsultaHistoricoPrecios
    Inherits System.Web.UI.Page

    Private mComponente As New cHISTORICOPRECIOS
    Private mCompProductos As New cCATALOGOPRODUCTOS
    Private mCompSubgrupos As New cSUBGRUPOS
    Private mCompGrupos As New cGRUPOS
    Private mCompSuministro As New cSUMINISTROS
    Private mEntProductos As CATALOGOPRODUCTOS
    Private mEntSubgrupos As SUBGRUPOS
    Private mEntGrupos As GRUPOS
    Private mEntSuministro As SUMINISTROS
    Friend Shared bImprimir As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False
        If Not Page.IsPostBack Then

            Me.TxtIdproducto.Text = Request.QueryString("IdPro")
            CargarDatos()
        End If
    End Sub

    Private Sub CargarDatos()
        Dim lIdPro As Int64 = Request.QueryString("IdPro")
        Dim dsHistorico As Data.DataSet
        dsHistorico = mComponente.ObtenerDataSetPorId(lIdPro)
        If dsHistorico.Tables(0).Rows.Count > 0 Then
            bImprimir = True
            Me.PnlPrincipal.Visible = True
            Me.LblValida.Visible = False
        Else
            bImprimir = False
            Me.PnlPrincipal.Visible = False
            Me.LblValida.Visible = True
        End If
        Me.dgLista.DataSource = dsHistorico
        Me.dgLista.DataBind()

        mEntProductos = New CATALOGOPRODUCTOS
        mEntProductos.IDPRODUCTO = Val(Me.TxtIdproducto.Text)

        If mCompProductos.ObtenerCatalogoProductos(mEntProductos) <> 1 Then
            Return
        End If

        Me.TxtCodigo.Text = mEntProductos.CODIGO
        Me.TxtCodSubGrupo.Text = mEntProductos.IDTIPOPRODUCTO
        Me.TxtNombre.Text = mCompProductos.DevolverNombreProducto(mEntProductos.IDPRODUCTO)
        Me.TxtPrecioActual.Text = "$ " + mEntProductos.PRECIOACTUAL.ToString
        Me.DdlUNIDADMEDIDAS1.Recuperar()
        Me.DdlUNIDADMEDIDAS1.SelectedValue = mEntProductos.IDUNIDADMEDIDA
        Me.TxtUnidadMedida.Text = Me.DdlUNIDADMEDIDAS1.SelectedItem.Text

        CargarSubgrupos()
    End Sub

    Private Sub CargarSubgrupos()

        mEntSubgrupos = New SUBGRUPOS
        mEntSubgrupos.IDSUBGRUPO = Val(Me.TxtCodSubGrupo.Text)

        If mCompSubgrupos.ObtenerSUBGRUPOS(mEntSubgrupos) <> 1 Then
            Return
        End If

        Me.TxtSubGrupo.Text = mEntSubgrupos.DESCRIPCION
        Me.TxtCodGrupo.Text = mEntSubgrupos.IDGRUPO

        CargarGrupo()
    End Sub

    Private Sub CargarGrupo()

        mEntGrupos = New GRUPOS
        mEntGrupos.IDGRUPO = Val(Me.TxtCodGrupo.Text)

        If mCompGrupos.ObtenerGRUPOS(mEntGrupos) <> 1 Then
            Return
        End If

        Me.TxtGrupo.Text = mEntGrupos.DESCRIPCION
        Me.TxtCodSum.Text = mEntGrupos.IDSUMINISTRO

        CargarSuministro()
    End Sub

    Private Sub CargarSuministro()

        mEntSuministro = New SUMINISTROS
        mEntSuministro.IDSUMINISTRO = Val(Me.TxtCodSum.Text)

        If mCompSuministro.ObtenerSUMINISTROS(mEntSuministro) <> 1 Then
            Return
        End If

        Me.TxtSuministro.Text = mEntSuministro.DESCRIPCION
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/URMIM/frmProyectarPrecios.aspx")
    End Sub

    Protected Sub ImgbImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbImprimir.Click
        If bImprimir = True Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmrptproyectarprecios.aspx?IdPro=" & Me.TxtIdproducto.Text + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        Else
            MsgBox1.ShowAlert("El reporte no puede ser generado por no existir un historial del producto", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If
    End Sub

End Class

