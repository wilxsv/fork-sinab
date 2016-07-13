Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Controles_ucAsesoriasNecesidadesEstablecimientos
    Inherits System.Web.UI.UserControl

    Private mEntProducto As New CATALOGOPRODUCTOS
    Private mCompProducto As New cCATALOGOPRODUCTOS

    Private _pag As Integer

#Region "propertys"

    Public Property pag() As Integer
        Get
            Return Me._pag
        End Get
        Set(ByVal Value As Integer)
            Me._pag = Value
            If Not Me.ViewState("pag") Is Nothing Then Me.ViewState.Remove("pag")
            Me.ViewState.Add("pag", Value)
        End Set
    End Property

#End Region

    Public Sub ObtenerDetalleDocumento()

        Dim mComponente As New cDETALLENECESIDADESTABLECIMIENTOS
        Me.dgLista.DataSource = mComponente.ObtenerDsDetalleNecesidadPorId(Request.QueryString("idE"), Request.QueryString("idN"), Me.DdlSUMINISTROS1.SelectedValue)

        Me.dgLista.DataSourceID = ""
        Me.dgLista.CurrentPageIndex = 0
        Me.dgLista.DataBind()

        Me.DdlESTABLECIMIENTOS1.Recuperar()
        Me.DdlESTABLECIMIENTOS1.SelectedValue = Request.QueryString("idE")

        Session("establecimiento") = Me.DdlESTABLECIMIENTOS1.SelectedItem.Text
        Me.Label17.Text = Me.DdlESTABLECIMIENTOS1.SelectedItem.Text

        Me.Label19.Text = Request.QueryString("Su")
        Session("Su") = Request.QueryString("Su")
        Me.Label21.Text = Request.QueryString("Pr")
        Session("Pr") = Request.QueryString("Pr")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.DdlSUMINISTROS1.Recuperar()
            Me.DdlSUMINISTROS1.SelectedItem.Text = Request.QueryString("Su")
            Me.pnFiltroGrupo.Visible = False
            Me.pnFiltroSubGrupo.Visible = False
            Me.pnFiltroProducto.Visible = False
        Else
            If Not Me.ViewState("pag") Is Nothing Then Me._pag = Me.ViewState("pag")
        End If

        Session("idDocRep") = Request.QueryString("idN")
        Session("idE") = Request.QueryString("idE")
        Session.Item("idEstRep") = Request.QueryString("idE")

        btnVerObservaciones.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptObservacionesNecesidades.aspx")
        '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptObservacionesNecesidades.aspx', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"
        Button1.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/frmRptAsesoriasEstablecimientos.aspx")
        '"window.open('" + Request.ApplicationPath + "/Reportes/frmRptAsesoriasEstablecimientos.aspx', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;"

    End Sub

    Protected Sub dgLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.ItemCommand
        If e.CommandName = "Select" Then
            Dim mComponenteODN As New cOBSERVACIONDETALLENECESIDAD
            Dim mEntidadODN As New OBSERVACIONDETALLENECESIDAD

            Me.lblcantidadactual.Text = CType(e.Item.FindControl("Label3"), Label).Text
            Session("NecesidadFinal") = CType(e.Item.FindControl("Label3"), Label).Text
            Session("idNecesidad") = CType(e.Item.FindControl("lblIdNecesidad"), Label).Text
            Session("idproducto") = CType(e.Item.FindControl("Label_IdProducto"), Label).Text
            Session("CodigoProducto") = CType(e.Item.FindControl("lblCodigoProducto"), Label).Text
            Session("NomProducto") = CType(e.Item.FindControl("lblProducto"), Label).Text
            Session("UnidadMedida") = CType(e.Item.FindControl("lblUnidadMedida"), Label).Text
            Session("ConsumoAnual") = CType(e.Item.FindControl("Label1"), Label).Text
            Session("DemandaInsatisfecha") = CType(e.Item.FindControl("Label27"), Label).Text
            Session("Reserva") = CType(e.Item.FindControl("Label23"), Label).Text
            Session("ReservaTotal") = CType(e.Item.FindControl("Label28"), Label).Text
            Session("ExistenciaEstimada") = e.Item.Cells(5).Text
            Session("NecesidadReal") = CType(e.Item.FindControl("Label6"), Label).Text
            Session("NecesidadAjustada") = CType(e.Item.FindControl("Label2"), Label).Text
            Session("CTR") = CType(e.Item.FindControl("Label4"), Label).Text
            Session("CTA") = CType(e.Item.FindControl("Label25"), Label).Text

            Dim ds As Data.DataSet
            ds = mComponenteODN.Obtenerobservaciones(Request.QueryString("idE"), CType(e.Item.FindControl("lblIdNecesidad"), Label).Text, CType(e.Item.FindControl("Label_IdProducto"), Label).Text)

            Me.gvObservaciones.DataSource = ds.Tables(0)
            Me.gvObservaciones.DataBind()
            Me.Panel1.Visible = True

            Me.Panel2.Visible = True
            Dim Entidadasesoria As New ASESORIAPREDEFINIDA
            Dim mComponente As New cASESORIAPREDEFINIDA
            Me.DropDownList1.DataSource = mComponente.ObtenerLista
            Me.DropDownList1.DataTextField = "DESCRIPCION"
            Me.DropDownList1.DataValueField = "IDASESORIA"
            Me.DropDownList1.DataBind()

            If Me.gvObservaciones.Rows.Count = 0 Then
                Me.Button1.Visible = False
            Else
                Me.Button1.Visible = True
            End If
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Panel2.Visible = True
        Dim Entidadasesoria As New ASESORIAPREDEFINIDA
        Dim mComponente As New cASESORIAPREDEFINIDA
        Me.DropDownList1.DataSource = mComponente.ObtenerLista
        Me.DropDownList1.DataTextField = "DESCRIPCION"
        Me.DropDownList1.DataValueField = "IDASESORIA"
        Me.DropDownList1.DataBind()

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim mComponenteODN As New cOBSERVACIONDETALLENECESIDAD
        Dim mEntidadODN As New OBSERVACIONDETALLENECESIDAD

        'TODO: cambiar el establecimiento
        mEntidadODN.IDESTABLECIMIENTO = Request.QueryString("idE")
        mEntidadODN.IDPRODUCTO = Session("idproducto")
        mEntidadODN.IDNECESIDAD = Request.QueryString("idN")

        mEntidadODN.OBSERVACION = Me.TextBox1.Text
        mEntidadODN.FECHA = DateTime.Now
        mEntidadODN.CANTIDADACTUAL = Me.lblcantidadactual.Text
        mEntidadODN.IDASESORIA = Me.DropDownList1.SelectedValue

        mComponenteODN.ActualizarOBSERVACIONDETALLENECESIDAD(mEntidadODN)

        Me.gvObservaciones.DataSource = mComponenteODN.Obtenerobservaciones(Request.QueryString("idE"), Request.QueryString("idN"), Session("idproducto"))
        Me.gvObservaciones.DataBind()

        Me.Button3.Enabled = True
        Me.Button3.Visible = True
        Me.Button1.Visible = True

        Me.DropDownList1.SelectedIndex = -1
        Me.TextBox1.Text = ""

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        Me.Panel1.Visible = False
        Me.Panel2.Visible = False

        Me.MsgBox2.ShowConfirm("Esta seguro que desea finalizar la asesoría para el establecimiento. Esta acción cambiará el estado del programa de compra a Revisado y ya no la podra revisar (o consolidar) hasta que el establecimiento lo envie de nuevo. Desea continuar?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
    End Sub

    Protected Sub rbFiltros_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbFiltros.SelectedIndexChanged
        Dim cgrupos As New cGRUPOS
        Dim csubgrupo As New cSUBGRUPOS

        Select Case Me.rbFiltros.SelectedValue

            Case 1
                Me.pnFiltroSubGrupo.Visible = False
                Me.pnFiltroGrupo.Visible = False
                Me.pnFiltroProducto.Visible = False

            Case 2
                Me.pnFiltroSubGrupo.Visible = False
                Me.pnFiltroGrupo.Visible = True
                Me.pnFiltroProducto.Visible = False

                Me.ddlGrupo.DataSource = cgrupos.ObtenerLista()
                Me.ddlGrupo.DataTextField = "descripcion"
                Me.ddlGrupo.DataValueField = "idgrupo"
                Me.ddlGrupo.DataBind()

            Case 3
                Me.pnFiltroSubGrupo.Visible = True
                Me.pnFiltroGrupo.Visible = False
                Me.pnFiltroProducto.Visible = False

                Me.ddlSubGrupo.DataSource = csubgrupo.ObtenerLista()
                Me.ddlSubGrupo.DataTextField = "descripcion"
                Me.ddlSubGrupo.DataValueField = "idsubgrupo"
                Me.ddlSubGrupo.DataBind()

            Case 4
                Me.pnFiltroProducto.Visible = True
                Me.pnFiltroGrupo.Visible = False
                Me.pnFiltroSubGrupo.Visible = False
                Me.txtCodigoProducto.Text = ""
                Me.txtCodigoProducto.Enabled = True
                Me.btnBusquedaProducto.Enabled = True
        End Select

    End Sub

    Public Function Propuesta(ByVal letras As String) As Integer
        Select Case letras
            Case Is = "A"
                Return 1
            Case Is = "B"
                Return 2
            Case Is = "C"
                Return 3
        End Select
    End Function

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.rbFiltros.Enabled = False
        Me.dgLista.Visible = True

        Select Case Me.rbFiltros.SelectedValue
            Case 1
                Me.pnFiltroSubGrupo.Visible = False
                Me.pnFiltroGrupo.Visible = False
                Me.pnFiltroProducto.Visible = False
                ObtenerDetalleDocumento()
                pag = 1

            Case 2

                Session("idgrupo") = Me.ddlGrupo.SelectedValue
                Me.dgLista.DataSourceID = Me.ObjectDataSource2.ID
                pag = 2
                Me.dgLista.CurrentPageIndex = 0
                Me.dgLista.DataBind()
                Me.ddlGrupo.Enabled = False

            Case 3

                Session("idsubgrupo") = Me.ddlSubGrupo.SelectedValue
                Me.dgLista.DataSourceID = Me.ObjectDataSource3.ID
                pag = 3
                Me.dgLista.CurrentPageIndex = 0
                Me.dgLista.DataBind()
                Me.ddlSubGrupo.Enabled = False

            Case 4
                Me.dgLista.CurrentPageIndex = 0
                pag = 4

        End Select

        Me.Button4.Enabled = False
        Me.Button5.Enabled = True
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.rbFiltros.Enabled = True
        Me.pnFiltroSubGrupo.Visible = False
        Me.pnFiltroGrupo.Visible = False
        Me.pnFiltroProducto.Visible = False

        Me.dgLista.Visible = False
        Me.Button4.Enabled = True
        Me.Button5.Enabled = False
        Me.Panel1.Visible = False

        Me.ddlGrupo.Enabled = True
        Me.ddlSubGrupo.Enabled = True
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Page.ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptAsesoriasEstablecimientos.aspx', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');</script>")
    End Sub

    Protected Sub btnBusquedaProducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBusquedaProducto.Click
        If Me.txtCodigoProducto.Text = "" Then
            Me.lblmensajecodproducto.Text = "Ingrese un código"
            Me.lblmensajecodproducto.Visible = True
            Exit Sub
        Else
            Me.lblmensajecodproducto.Text = ""
            Me.lblmensajecodproducto.Visible = False
        End If

        Session("codproducto") = Me.txtCodigoProducto.Text
        Me.dgLista.DataSourceID = Me.ObjectDataSource4.ID
        Me.dgLista.DataBind()

        If Me.dgLista.Items.Count = 0 Then
            Me.lblmensajecodproducto.Text = "Código de Producto no encontrado"
            Me.lblmensajecodproducto.Visible = True
            Me.dgLista.Visible = False
            Exit Sub
        End If

        Me.lblmensajecodproducto.Visible = False
        Me.dgLista.Visible = True
        Me.txtCodigoProducto.Enabled = False
        Me.btnBusquedaProducto.Enabled = False

        Me.Button4.Enabled = False
        Me.dgLista.Visible = True
        Me.Button5.Enabled = True
    End Sub

    Protected Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista.PageIndexChanged

        Select Case pag
            Case Is = 1
                Me.dgLista.CurrentPageIndex = e.NewPageIndex
                Dim mComponente As New cDETALLENECESIDADESTABLECIMIENTOS
                Me.dgLista.DataSource = mComponente.ObtenerDsDetalleNecesidadPorId(Request.QueryString("idE"), Request.QueryString("idN"), Me.DdlSUMINISTROS1.SelectedValue)
                Me.dgLista.DataSourceID = ""
                Me.dgLista.DataBind()
            Case Is = 2
                Me.dgLista.CurrentPageIndex = e.NewPageIndex
                Session("idgrupo") = Me.ddlGrupo.SelectedValue
                Me.dgLista.DataSourceID = Me.ObjectDataSource2.ID
                Me.dgLista.DataBind()
            Case Is = 3
                Me.dgLista.CurrentPageIndex = e.NewPageIndex
                Session("idsubgrupo") = Me.ddlSubGrupo.SelectedValue
                Me.dgLista.DataSourceID = Me.ObjectDataSource3.ID
                Me.dgLista.DataBind()
            Case Is = 4
                Me.dgLista.CurrentPageIndex = e.NewPageIndex
                Session("codproducto") = Me.txtCodigoProducto.Text
                Me.dgLista.DataSourceID = Me.ObjectDataSource4.ID
                Me.dgLista.DataBind()
        End Select
    End Sub

    Protected Sub MsgBox2_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox2.YesChosen
        If e.Key = "A" Then
            Dim mComponenteNE As New cNECESIDADESTABLECIMIENTOS
            Dim entidadNE As New NECESIDADESTABLECIMIENTOS
            entidadNE.IDESTADO = 3
            entidadNE.IDESTABLECIMIENTO = Request.QueryString("idE")
            entidadNE.IDNECESIDAD = Request.QueryString("idN")

            mComponenteNE.ActualizarEstados(entidadNE)
            Response.Redirect("~/FrmPrincipal.aspx", False)
        End If
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Response.Redirect("~/URMIM/FrmRevisionEstimacionNecesidades.aspx")
    End Sub

End Class
