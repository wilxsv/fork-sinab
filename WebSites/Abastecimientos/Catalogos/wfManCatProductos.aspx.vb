Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class Catalogos_wfManCatProductos
    Inherits System.Web.UI.Page

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

            Me.DdlSUMINISTROS1.RecuperarListaFiltrada(1)
            Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.DdlSUMINISTROS1.SelectedValue)
            Me.DdlSUBGRUPOS1.RecuperarListaFiltrada(Me.DdlGRUPOS1.SelectedValue)

            'UcFiltrarDatos1.AddColumnasExcluidas(gvProductos.Columns(3).HeaderText)
            'UcFiltrarDatos1.AddColumnasExcluidas(gvProductos.Columns(4).HeaderText)
            'UcFiltrarDatos1.AddColumnasExcluidas(gvProductos.Columns(5).HeaderText)
            'UcFiltrarDatos1.AddColumnasExcluidas(gvProductos.Columns(6).HeaderText)
            UcFiltrarDatos1.ValorColumnas = gvProductos.Columns

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

        Dim ccp As New cCATALOGOPRODUCTOS
        Dim ds As Data.DataSet
        ds = ccp.ObtenerDataSetPorIDProducto(IDPRODUCTO)
        Me.DetailsView1.DataSource = ds.Tables(0)
        Me.DetailsView1.DataBind()

        Dim u As ABASTECIMIENTOS.WUC.ddlUNIDADMEDIDAS
        u = Me.DetailsView1.Rows(0).FindControl("ddlUNIDADMEDIDAS1")
        u.SelectedValue = ds.Tables(0).Rows(0).Item(3)

        Dim d As DropDownList
        d = Me.DetailsView1.Rows(0).FindControl("DropDownList1")
        d.SelectedValue = ds.Tables(0).Rows(0).Item(5)
        NivelUso = ds.Tables(0).Rows(0).Item(5)
        d.Enabled = False
        Me.DetailsView1.Visible = True

    End Sub

    Protected Sub DetailsView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetailsView1.DataBound

        Dim idsuministro As Label
        idsuministro = sender.FindControl("Label1")

        If Not IsNothing(idsuministro) Then
            If Left(idsuministro.Text, 1) = 0 Then
                Session("Sololetras") = True
            End If
            Dim dropdownlist1 As DropDownList
            dropdownlist1 = sender.FindControl("DropDownList1")
            dropdownlist1.DataBind()
        End If

        Dim CS As New cSUMINISTROS
        Dim ddlUNIDADMEDIDAS As ABASTECIMIENTOS.WUC.ddlUNIDADMEDIDAS
        ddlUNIDADMEDIDAS = sender.FindControl("DdlUNIDADMEDIDAS1")
        If Not IsNothing(ddlUNIDADMEDIDAS) Then
            ddlUNIDADMEDIDAS.RecuperarPorSuministro(CS.DevolverIdSuministro(Left(idsuministro.Text, 1)))
        End If


        Dim estadop As CheckBox
        estadop = sender.FindControl("CheckBox2")

        If estadop.Checked Then
            Estado = 1
        Else
            Estado = 2
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("~/Catalogos/wfCatProducto.aspx")
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
            Dim cCP As New cCATALOGOPRODUCTOS
            Dim CP As New CATALOGOPRODUCTOS

            CP.IDPRODUCTO = IDPRODUCTO
            CP.CODIGO = CType(Me.DetailsView1.Rows(0).FindControl("Label1"), Label).Text ' & CType(Me.DetailsView1.Rows(0).FindControl("TextBox1"), TextBox).Text
            CP.IDTIPOPRODUCTO = IDTIPOPRODUCTO
            CP.IDUNIDADMEDIDA = CType(Me.DetailsView1.Rows(0).FindControl("DdlUNIDADMEDIDAS1"), ABASTECIMIENTOS.WUC.ddlUNIDADMEDIDAS).SelectedValue
            CP.NOMBRE = CType(Me.DetailsView1.Rows(0).FindControl("TextBox2"), TextBox).Text
            CP.NIVELUSO = CType(Me.DetailsView1.Rows(0).FindControl("DropDownList1"), DropDownList).SelectedValue
            CP.CONCENTRACION = CType(Me.DetailsView1.Rows(0).FindControl("TextBox3"), TextBox).Text
            CP.FORMAFARMACEUTICA = CType(Me.DetailsView1.Rows(0).FindControl("TextBox4"), TextBox).Text
            CP.PRESENTACION = CType(Me.DetailsView1.Rows(0).FindControl("TextBox5"), TextBox).Text
            CP.PRIORIDAD = CType(Me.DetailsView1.Rows(0).FindControl("DropDownList3"), DropDownList).SelectedValue
            CP.PRECIOACTUAL = CType(Me.DetailsView1.Rows(0).FindControl("NumericBox2"), eWorld.UI.NumericBox).Text
            CP.APLICALOTE = CType(Me.DetailsView1.Rows(0).FindControl("DropDownList2"), DropDownList).SelectedValue
            CP.EXISTENCIAACTUAL = 0 'CDec(CType(Me.DetailsView1.Rows(0).FindControl("NumericBox3"), eWorld.UI.NumericBox).Text)
            CP.CODIGONACIONESUNIDAS = CType(Me.DetailsView1.Rows(0).FindControl("TextBox6"), TextBox).Text
            CP.PERTENECELISTADOOFICIAL = CType(Me.DetailsView1.Rows(0).FindControl("CheckBox1"), CheckBox).Checked
            If CType(Me.DetailsView1.Rows(0).FindControl("CheckBox2"), CheckBox).Checked Then
                CP.ESTADOPRODUCTO = 1
            Else
                CP.ESTADOPRODUCTO = 0
            End If

            CP.OBSERVACION = CType(Me.DetailsView1.Rows(0).FindControl("TextBox7"), TextBox).Text

            cCP.ActualizarCATALOGOPRODUCTOS(CP)

            If CType(Me.DetailsView1.Rows(0).FindControl("CheckBox2"), CheckBox).Checked And Estado = 2 Then

                Dim cNE As New cNIVELESUSOESTABLECIMIENTOS
                Dim dsE As Data.DataSet

                dsE = cNE.DevolverEstablecimientos(CType(Me.DetailsView1.Rows(0).FindControl("DropDownList1"), DropDownList).SelectedValue)

                Dim cPE As New cPRODUCTOSESTABLECIMIENTOS
                Dim pe As New PRODUCTOSESTABLECIMIENTOS

                Dim dr As Data.DataRow = dsE.Tables(0).NewRow
                'por cada establecimiento en nivelesdeusoestablecimientos, hace la insercion en productosestablecimientos
                For Each dr In dsE.Tables(0).Rows
                    pe.IDESTABLECIMIENTO = dr(0)
                    pe.OBSERVACION = "Producto creado"
                    pe.FECHA = Today
                    pe.ESTAHABILITADO = 1
                    pe.IDPRODUCTO = IDPRODUCTO
                    cPE.AgregarPRODUCTOSESTABLECIMIENTOS(pe)
                Next
            ElseIf Not CType(Me.DetailsView1.Rows(0).FindControl("CheckBox2"), CheckBox).Checked And Estado = 1 Then

                Dim cNE As New cNIVELESUSOESTABLECIMIENTOS
                Dim dsE As Data.DataSet

                dsE = cNE.DevolverEstablecimientos(CType(Me.DetailsView1.Rows(0).FindControl("DropDownList1"), DropDownList).SelectedValue)

                Dim cPE As New cPRODUCTOSESTABLECIMIENTOS
                Dim pe As New PRODUCTOSESTABLECIMIENTOS

                Dim dr As Data.DataRow = dsE.Tables(0).NewRow
                'por cada establecimiento en nivelesdeusoestablecimientos, hace la insercion en productosestablecimientos
                For Each dr In dsE.Tables(0).Rows
                    pe.IDESTABLECIMIENTO = dr(0)
                    pe.OBSERVACION = "Producto Deshabilitado"
                    pe.FECHA = Today
                    pe.ESTAHABILITADO = 0
                    pe.IDPRODUCTO = IDPRODUCTO
                    cPE.AgregarPRODUCTOSESTABLECIMIENTOS(pe)
                Next

            End If

            Me.MsgBox1.ShowAlert("El producto ha sido actualizado en el catálogo.", "V", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        End If


    End Sub

    Protected Sub MsgBox2_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox2.OkChosen
        If e.Key = "B" Then
            Dim ccp As New cCATALOGOPRODUCTOS
            Me.gvProductos.DataSource = ccp.RecuperarCP
            Me.gvProductos.PageIndex = 0
            Me.gvProductos.SelectedIndex = -1
            Me.gvProductos.DataBind()

            Me.DetailsView1.Visible = False
        End If
        If e.Key = "C" Then

        End If
    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "V" Then
            Dim ccp As New cCATALOGOPRODUCTOS
            Me.gvProductos.DataSource = ccp.RecuperarCP
            Me.gvProductos.DataBind()

            Me.DetailsView1.Visible = False
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        If e.Key = "A" Then
            Try
                Dim R As Integer
                Dim cCP As New cCATALOGOPRODUCTOS
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
            Dim ccp As New cCATALOGOPRODUCTOS
            Me.gvProductos.DataSource = ccp.RecuperarCP
            Try
                Me.gvProductos.DataBind()
            Catch ex As Exception
                Me.gvProductos.PageIndex = 0
                Me.gvProductos.DataBind()
            End Try
            Me.DetailsView1.Visible = False
        Else
            Me.gvProductos.PageIndex = e.NewPageIndex
            Dim ccp As New cCATALOGOPRODUCTOS
            Me.gvProductos.DataSource = ccp.RecuperarCP2(Me.DdlSUBGRUPOS1.SelectedValue, 1)
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
            Me.DdlSUMINISTROS1.Enabled = False
            Me.DdlGRUPOS1.Enabled = False
            Me.DdlSUBGRUPOS1.Enabled = False
        Else
            Me.DdlSUMINISTROS1.Enabled = True
            Me.DdlGRUPOS1.Enabled = True
            Me.DdlSUBGRUPOS1.Enabled = True
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        CargarDatos()

        Me.gvProductos.Visible = True
        Me.Button1.Visible = True
    End Sub

    Protected Sub DdlSUMINISTROS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlSUMINISTROS1.SelectedIndexChanged
        Me.DdlGRUPOS1.RecuperarListaFiltrada(Me.DdlSUMINISTROS1.SelectedValue)
        Me.DdlSUBGRUPOS1.RecuperarListaFiltrada(Me.DdlGRUPOS1.SelectedValue)
    End Sub

    Protected Sub DdlGRUPOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlGRUPOS1.SelectedIndexChanged
        Me.DdlSUBGRUPOS1.RecuperarListaFiltrada(Me.DdlGRUPOS1.SelectedValue)
    End Sub

    Private Sub CargarDatos()

        Dim ccp As New cCATALOGOPRODUCTOS
        Dim ds As Data.DataSet = Nothing

        If Me.CheckBox3.Checked Then
            ds = ccp.RecuperarCP
        Else
            ds = ccp.RecuperarCP2(Me.DdlSUBGRUPOS1.SelectedValue, 1)
        End If

        If IsNothing(ds) Then Return

        Dim dsVista As New System.Data.DataView(ds.Tables(0))

        If UcFiltrarDatos1.CampoFiltro <> "" And UcFiltrarDatos1.ValorFiltro <> "" Then
            Select Case dsVista.Table.Columns(UcFiltrarDatos1.CampoFiltro).DataType.Name
                Case "String"
                    dsVista.RowFilter = UcFiltrarDatos1.CampoFiltro & " LIKE '%" & UcFiltrarDatos1.ValorFiltro & "%'"
                Case "DateTime"
                    dsVista.RowFilter = UcFiltrarDatos1.CampoFiltro & " = '" & UcFiltrarDatos1.ValorFiltro & "'"
                Case Else
                    dsVista.RowFilter = UcFiltrarDatos1.CampoFiltro & " = " & UcFiltrarDatos1.ValorFiltro
            End Select
        End If

        Me.gvProductos.DataSource = dsVista

        Try
            Me.gvProductos.DataBind()
        Catch ex As Exception
            Me.gvProductos.PageIndex = 0
            Me.gvProductos.DataBind()
        End Try

    End Sub

    Protected Sub UcFiltrarDatos1_Buscar() Handles UcFiltrarDatos1.Buscar
        CargarDatos()
    End Sub

End Class
