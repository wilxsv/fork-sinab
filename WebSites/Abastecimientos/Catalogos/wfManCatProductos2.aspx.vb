Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.WUC

Partial Class Catalogos_wfManCatProductos2
    Inherits System.Web.UI.Page

    Private cCP As New cCATALOGOPRODUCTOS

    Private _IDPRODUCTO As Integer
    Private _IDTIPOPRODUCTO As Integer

    Private _NivelUso As Integer
    Private _Estado As Integer

#Region " Propiedades "

    Public Property IDPRODUCTO() As Integer
        Get
            Return Me._IDPRODUCTO
        End Get
        Set(ByVal Value As Integer)
            Me._IDPRODUCTO = Value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", Value)
        End Set
    End Property

    Public Property IDTIPOPRODUCTO() As Integer
        Get
            Return Me._IDTIPOPRODUCTO
        End Get
        Set(ByVal Value As Integer)
            Me._IDTIPOPRODUCTO = Value
            If Not Me.ViewState("IDTIPOPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDTIPOPRODUCTO")
            Me.ViewState.Add("IDTIPOPRODUCTO", Value)
        End Set
    End Property

    Public Property NivelUso() As Integer
        Get
            Return Me._NivelUso
        End Get
        Set(ByVal Value As Integer)
            Me._NivelUso = Value
            If Not Me.ViewState("NivelUso") Is Nothing Then Me.ViewState.Remove("NivelUso")
            Me.ViewState.Add("NivelUso", Value)
        End Set
    End Property

    Public Property Estado() As Integer
        Get
            Return Me._Estado
        End Get
        Set(ByVal Value As Integer)
            Me._Estado = Value
            If Not Me.ViewState("Estado") Is Nothing Then Me.ViewState.Remove("Estado")
            Me.ViewState.Add("Estado", Value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            If Request.QueryString("idS") Is Nothing Then
                Me.ddlSUMINISTROS1.RecuperarListaFiltrada(1, 1)
            Else
                Me.ddlSUMINISTROS1.RecuperarListaFiltrada(Request.QueryString("idS"), 1)
            End If

            Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
            Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)

        Else
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")
            If Not Me.ViewState("IDTIPOPRODUCTO") Is Nothing Then Me._IDTIPOPRODUCTO = Me.ViewState("IDTIPOPRODUCTO")
            If Not Me.ViewState("NivelUso") Is Nothing Then Me._NivelUso = Me.ViewState("NivelUso")
            If Not Me.ViewState("Estado") Is Nothing Then Me._Estado = Me.ViewState("Estado")
        End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub gvProductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProductos.SelectedIndexChanged

        IDPRODUCTO = Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(0)
        IDTIPOPRODUCTO = Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(1)

        Dim ds As Data.DataSet
        ds = cCP.ObtenerDataSetPorIDProducto(IDPRODUCTO)
        Me.DetailsView1.DataSource = ds.Tables(0)
        Me.DetailsView1.DataBind()

        Dim u As ddlUNIDADMEDIDAS
        u = Me.DetailsView1.Rows(0).FindControl("ddlUNIDADMEDIDAS1")
        u.SelectedValue = ds.Tables(0).Rows(0).Item(3)

        Me.DetailsView1.Visible = True
    End Sub

    Protected Sub DetailsView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetailsView1.DataBound

        Dim idsuministro As Label
        idsuministro = sender.FindControl("Label1")

        If Not IsNothing(idsuministro) Then
            If Left(idsuministro.Text, 1) = 0 Then
                Session("Sololetras") = True
            End If
        End If

        Dim CS As New cSUMINISTROS
        Dim ddlUNIDADMEDIDAS As ddlUNIDADMEDIDAS
        ddlUNIDADMEDIDAS = sender.FindControl("ddlUNIDADMEDIDAS1")
        If Not IsNothing(ddlUNIDADMEDIDAS) Then
            ddlUNIDADMEDIDAS.RecuperarPorSuministro(CS.DevolverIdSuministro(Left(idsuministro.Text, 1)))
        End If

        Dim estadop As CheckBox
        estadop = sender.FindControl("cbEstadoProducto")

        If estadop.Checked Then
            Estado = 1
        Else
            Estado = 2
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("~/Catalogos/wfCatProducto2.aspx")
    End Sub

    Protected Sub DetailsView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewCommandEventArgs) Handles DetailsView1.ItemCommand

        If e.CommandName = "Eliminar" Then
            Me.MsgBox1.ShowConfirm("Esta seguro de eliminar este producto del catálogo?", "A", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
        End If

        If e.CommandName = "Cancelar" Then
            Me.gvProductos.SelectedIndex = -1
            Me.DetailsView1.Visible = False
        End If

        If e.CommandName = "Guardar" Then

            Dim eCP As New CATALOGOPRODUCTOS

            eCP.IDPRODUCTO = IDPRODUCTO
            eCP.CODIGO = CType(Me.DetailsView1.Rows(0).FindControl("Label1"), Label).Text ' & CType(Me.DetailsView1.Rows(0).FindControl("TextBox1"), TextBox).Text
            eCP.IDTIPOPRODUCTO = IDTIPOPRODUCTO
            eCP.IDUNIDADMEDIDA = CType(Me.DetailsView1.Rows(0).FindControl("ddlUNIDADMEDIDAS1"), ddlUNIDADMEDIDAS).SelectedValue
            eCP.NOMBRE = CType(Me.DetailsView1.Rows(0).FindControl("TextBox2"), TextBox).Text
            eCP.NIVELUSO = 7
            eCP.CONCENTRACION = ""
            eCP.FORMAFARMACEUTICA = ""
            eCP.PRESENTACION = ""
            eCP.PRIORIDAD = 1
            eCP.PRECIOACTUAL = CType(Me.DetailsView1.Rows(0).FindControl("NumericBox2"), eWorld.UI.NumericBox).Text
            eCP.APLICALOTE = IIf(CType(Me.DetailsView1.Rows(0).FindControl("cbAPLICALOTE"), CheckBox).Checked, 1, 0)
            eCP.EXISTENCIAACTUAL = 0
            eCP.PERTENECELISTADOOFICIAL = 1
            eCP.ESTADOPRODUCTO = IIf(CType(Me.DetailsView1.Rows(0).FindControl("cbESTADOPRODUCTO"), CheckBox).Checked, 1, 0)
            eCP.OBSERVACION = CType(Me.DetailsView1.Rows(0).FindControl("TextBox7"), TextBox).Text

            cCP.ActualizarCATALOGOPRODUCTOS(eCP)

            Me.MsgBox1.ShowAlert("El producto ha sido actualizado en el catálogo.", "V", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

        End If

    End Sub

    Protected Sub MsgBox2_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox2.OkChosen
        If e.Key = "B" Then

            Me.gvProductos.DataSource = cCP.RecuperarCP(1)
            Me.gvProductos.PageIndex = 0
            Me.gvProductos.SelectedIndex = -1
            Me.gvProductos.DataBind()

            Me.DetailsView1.Visible = False
        End If
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "V" Then

            Me.gvProductos.DataSource = cCP.RecuperarCP(1)
            Me.gvProductos.DataBind()

            Me.DetailsView1.Visible = False
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "A" Then
            Try
                Dim R As Integer

                R = cCP.EliminarProducto(IDPRODUCTO)
                If R = 0 Then
                    Me.MsgBox2.ShowAlert("El producto ha sido eliminado del catálogo.", "B", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
                Else
                    Me.MsgBox2.ShowAlert("El producto NO se ha eliminado del catálogo, es posible que aún se este utilizando dicho producto dentro de la aplicación.", "C", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
                End If

            Catch ex As Exception
                Me.MsgBox2.ShowAlert("" & ex.Message & "", "B", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            End Try

        End If
    End Sub

    Protected Sub gvProductos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProductos.PageIndexChanging
        If Me.CheckBox3.Checked Then
            Me.gvProductos.PageIndex = e.NewPageIndex

            Me.gvProductos.DataSource = cCP.RecuperarCP(1)
            Try
                Me.gvProductos.DataBind()
            Catch ex As Exception
                Me.gvProductos.PageIndex = 0
                Me.gvProductos.DataBind()
            End Try
            Me.DetailsView1.Visible = False
        Else
            Me.gvProductos.PageIndex = e.NewPageIndex

            Me.gvProductos.DataSource = cCP.RecuperarCP2(Me.ddlSUBGRUPOS1.SelectedValue, 1)
            Try
                Me.gvProductos.DataBind()
            Catch ex As Exception
                Me.gvProductos.PageIndex = 0
                Me.gvProductos.DataBind()
            End Try
            Me.DetailsView1.Visible = False
        End If

    End Sub

    Protected Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If Me.CheckBox3.Checked Then
            Me.ddlSUMINISTROS1.Enabled = False
            Me.ddlGRUPOS1.Enabled = False
            Me.ddlSUBGRUPOS1.Enabled = False
        Else
            Me.ddlSUMINISTROS1.Enabled = True
            Me.ddlGRUPOS1.Enabled = True
            Me.ddlSUBGRUPOS1.Enabled = True
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.CheckBox3.Checked Then

            Me.gvProductos.DataSource = cCP.RecuperarCP(1)
            Me.gvProductos.DataBind()
        Else

            Me.gvProductos.DataSource = cCP.RecuperarCP2(Me.ddlSUBGRUPOS1.SelectedValue, 1)
            Me.gvProductos.DataBind()
        End If

        Me.gvProductos.Visible = True
        Me.Button1.Visible = True
    End Sub

    Protected Sub ddlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSUMINISTROS1.SelectedIndexChanged
        Me.ddlGRUPOS1.RecuperarListaFiltrada(Me.ddlSUMINISTROS1.SelectedValue)
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
    End Sub

    Protected Sub ddlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOS1.SelectedIndexChanged
        Me.ddlSUBGRUPOS1.RecuperarListaFiltrada(Me.ddlGRUPOS1.SelectedValue)
    End Sub

End Class
