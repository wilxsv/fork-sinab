Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.DATOS

Partial Class FrmIncumplirRecepciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Dim cP As New cCATALOGOPRODUCTOS
            Dim cC As New cCONTRATOS
            Dim cA As New cALMACENES
            Dim cPr As New cPROVEEDORES

            Me.ddProducto.DataSource = cP.ObtenerDataSetPorContratoProcesoCompra(Request.QueryString("IdProc"), Session("IdEstablecimiento"))
            Me.ddProducto.DataTextField = "DESCLARGO"
            Me.ddProducto.DataValueField = "IDPRODUCTO"
            Me.ddProducto.DataBind()

            Me.GridView3.DataSource = cC.ObtenerDsContratosProcesoCompra(Request.QueryString("IdProc"), Session("IdEstablecimiento"))
            Me.GridView3.DataBind()

            Me.ddAlmacen.DataSource = cA.ObtenerAlmacenesDSProcesoCompraContrato(Request.QueryString("IdProc"), Session("IdEstablecimiento"))
            Me.ddAlmacen.DataTextField = "NOMBRE"
            Me.ddAlmacen.DataValueField = "IDALMACEN"
            Me.ddAlmacen.DataBind()

            Me.ddProveedor.DataSource = cPr.ObtenerDsProveedorProcesoCompraContrato(Request.QueryString("IdProc"), Session("IdEstablecimiento"))
            Me.ddProveedor.DataTextField = "NOMBRE"
            Me.ddProveedor.DataValueField = "idPROVEEDOR"
            Me.ddProveedor.DataBind()

        End If

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged

        Me.Button1.Visible = True
        Select Case Me.RadioButtonList1.SelectedValue


            Case Is = 0
                Me.pnProducto.Visible = True
                Me.pnContrato.Visible = False
                Me.pnAlmacen.Visible = False
                Me.pnProveedor.Visible = False
                Me.pniProducto.Visible = False

            Case Is = 1
                Me.pnProducto.Visible = False
                Me.pnContrato.Visible = True
                Me.pnAlmacen.Visible = False
                Me.pnProveedor.Visible = False
                Me.pniProducto.Visible = False

            Case Is = 2
                Me.pnProducto.Visible = False
                Me.pnContrato.Visible = False
                Me.pnAlmacen.Visible = True
                Me.pnProveedor.Visible = False
                Me.pniProducto.Visible = False

            Case Is = 3
                Me.pnProducto.Visible = False
                Me.pnContrato.Visible = False
                Me.pnAlmacen.Visible = False
                Me.pnProveedor.Visible = True
                Me.pniProducto.Visible = False

        End Select
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.pniProducto.Visible = True
        Me.Button2.Visible = True
        Dim dv As New Data.DataView
        Dim ci As New ABASTECIMIENTOS.NEGOCIO.cINCUMPLIMIENTO

        Dim pc As New ArrayList
        pc.Add(Request.QueryString("IdProc"))
        ci.idProcesoCompra = pc.ToArray
        ci.idEstablecimiento = Session("IdEstablecimiento")
        '620
        Dim ds As Data.DataSet = ci.obtenerDatasetIncumplimientos
        Me.gvDetalle.DataSource = ds.Tables("Global")
        'Me.gvDetalle.DataBind()

        dv.Table = ds.Tables("Global")

        Select Case Me.RadioButtonList1.SelectedValue
            Case Is = 0
                Me.GridView1.DataSource = Nothing
                Dim cC As New cCATALOGOPRODUCTOS
                Me.GridView1.DataSource = cC.DevolverProducto(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.ddProducto.SelectedValue)
                Me.GridView1.Columns(0).Visible = True
                Me.GridView1.Columns(1).Visible = True
                Me.GridView1.Columns(2).Visible = True
                Me.GridView1.Columns(3).Visible = True
                Me.GridView1.Columns(4).Visible = False
                Me.GridView1.Columns(5).Visible = False
                Me.GridView1.Columns(6).Visible = False
                Me.GridView1.Columns(7).Visible = False
                Me.GridView1.Columns(8).Visible = False
                Me.GridView1.DataBind()

                If Me.DropDownList1.SelectedValue = 0 Then
                    dv.RowFilter = "idproducto = " & Me.ddProducto.SelectedValue & " AND cantidadatrasoalmacen > 0 "
                Else
                    dv.RowFilter = "idproducto = " & Me.ddProducto.SelectedValue & " AND ((cantidadtotal-cantidadentregadaalmacen)>0)"
                End If

                'gvDetalle.DataSource = dv

                Me.Session("dsRecepciones") = dv

                Me.gvDetalle.Columns(0).Visible = False
                Me.gvDetalle.Columns(1).Visible = False
                Me.gvDetalle.Columns(2).Visible = False
                Me.gvDetalle.Columns(3).Visible = False
                Me.gvDetalle.Columns(4).Visible = True
                Me.gvDetalle.Columns(5).Visible = True

                If Me.DropDownList1.SelectedValue = 0 Then
                    Me.gvDetalle.Columns(11).Visible = True
                    Me.gvDetalle.Columns(12).Visible = False
                    Me.gvDetalle.Columns(13).Visible = True
                    Me.gvDetalle.Columns(14).Visible = False
                Else
                    Me.gvDetalle.Columns(11).Visible = False
                    Me.gvDetalle.Columns(12).Visible = True
                    Me.gvDetalle.Columns(13).Visible = False
                    Me.gvDetalle.Columns(14).Visible = True
                End If

                'Me.gvDetalle.Columns(8).Visible = True
                Me.gvDetalle.DataBind()

            Case Is = 1
                If Me.GridView3.SelectedIndex = -1 Then
                    Me.MsgBox1.ShowAlert("Debe seleccionar un contrato para realizar la consulta.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
                Else
                    Me.GridView1.DataSource = Nothing
                    Dim cCo As New cCONTRATOS
                    Me.GridView1.DataSource = cCo.DevolverContrato(Session("IdEstablecimiento"), Request.QueryString("IdProc"), CType(Me.GridView3.SelectedRow.FindControl("lblIDCONTRATO"), Label).Text, CType(Me.GridView3.SelectedRow.FindControl("lblIDPROVEEDOR"), Label).Text)
                    Me.GridView1.Columns(0).Visible = False
                    Me.GridView1.Columns(1).Visible = False
                    Me.GridView1.Columns(2).Visible = False
                    Me.GridView1.Columns(3).Visible = False
                    Me.GridView1.Columns(4).Visible = True
                    Me.GridView1.Columns(5).Visible = True
                    Me.GridView1.Columns(6).Visible = False
                    Me.GridView1.Columns(7).Visible = False
                    Me.GridView1.Columns(8).Visible = False
                    Me.GridView1.DataBind()

                    If Me.DropDownList1.SelectedValue = 0 Then
                        dv.RowFilter = "contrato = " & Me.GridView3.DataKeys(Me.GridView3.SelectedIndex).Values("IDCONTRATO").ToString & _
                         "and idproveedor = " & Me.GridView3.DataKeys(Me.GridView3.SelectedIndex).Values("IDPROVEEDOR").ToString & " AND cantidadatrasoalmacen > 0 "
                    Else
                        dv.RowFilter = "contrato = " & Me.GridView3.DataKeys(Me.GridView3.SelectedIndex).Values("IDCONTRATO").ToString & _
                         "and idproveedor = " & Me.GridView3.DataKeys(Me.GridView3.SelectedIndex).Values("IDPROVEEDOR").ToString & "AND ((cantidadtotal-cantidadentregadaalmacen)>0)"
                    End If

                    'gvDetalle.DataSource = dv
                    Me.Session("dsRecepciones") = dv

                    Me.gvDetalle.Columns(0).Visible = True
                    Me.gvDetalle.Columns(1).Visible = True
                    Me.gvDetalle.Columns(2).Visible = True
                    Me.gvDetalle.Columns(3).Visible = True
                    Me.gvDetalle.Columns(4).Visible = False
                    Me.gvDetalle.Columns(5).Visible = False

                    If Me.DropDownList1.SelectedValue = 0 Then
                        Me.gvDetalle.Columns(11).Visible = True
                        Me.gvDetalle.Columns(12).Visible = False
                        Me.gvDetalle.Columns(13).Visible = True
                        Me.gvDetalle.Columns(14).Visible = False
                    Else
                        Me.gvDetalle.Columns(11).Visible = False
                        Me.gvDetalle.Columns(12).Visible = True
                        Me.gvDetalle.Columns(13).Visible = False
                        Me.gvDetalle.Columns(14).Visible = True
                    End If
                    'Me.gvDetalle.Columns(6).Visible = True
                    'Me.gvDetalle.Columns(7).Visible = True
                    'Me.gvDetalle.Columns(8).Visible = True
                    Me.gvDetalle.DataBind()

                End If

            Case Is = 2
                Me.GridView1.DataSource = Nothing
                Dim cA As New cALMACENES
                Me.GridView1.DataSource = cA.DevolverAlmacen(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.ddAlmacen.SelectedValue)
                Me.GridView1.Columns(0).Visible = False
                Me.GridView1.Columns(1).Visible = False
                Me.GridView1.Columns(2).Visible = False
                Me.GridView1.Columns(3).Visible = False
                Me.GridView1.Columns(4).Visible = False
                Me.GridView1.Columns(5).Visible = False
                Me.GridView1.Columns(6).Visible = True
                Me.GridView1.Columns(7).Visible = False
                Me.GridView1.Columns(8).Visible = False
                Me.GridView1.DataBind()

                If Me.DropDownList1.SelectedValue = 0 Then
                    dv.RowFilter = "idalmacen = " & Me.ddAlmacen.SelectedValue & " AND cantidadatrasoalmacen > 0 "
                Else
                    dv.RowFilter = "idalmacen = " & Me.ddAlmacen.SelectedValue & " AND ((cantidadtotal-cantidadentregadaalmacen)>0)"
                End If

                'gvDetalle.DataSource = dv

                Me.Session("dsRecepciones") = dv

                Me.gvDetalle.Columns(0).Visible = True
                Me.gvDetalle.Columns(1).Visible = True
                Me.gvDetalle.Columns(2).Visible = True
                Me.gvDetalle.Columns(3).Visible = True
                Me.gvDetalle.Columns(4).Visible = True
                Me.gvDetalle.Columns(5).Visible = True

                If Me.DropDownList1.SelectedValue = 0 Then
                    Me.gvDetalle.Columns(11).Visible = True
                    Me.gvDetalle.Columns(12).Visible = False
                    Me.gvDetalle.Columns(13).Visible = True
                    Me.gvDetalle.Columns(14).Visible = False
                Else
                    Me.gvDetalle.Columns(11).Visible = False
                    Me.gvDetalle.Columns(12).Visible = True
                    Me.gvDetalle.Columns(13).Visible = False
                    Me.gvDetalle.Columns(14).Visible = True
                End If
                'Me.gvDetalle.Columns(6).Visible = False
                'Me.gvDetalle.Columns(7).Visible = True
                'Me.gvDetalle.Columns(8).Visible = True
                Me.gvDetalle.DataBind()


            Case Is = 3
                Dim cP As New cPROVEEDORES
                Me.GridView1.DataSource = cP.DevolverProveedor(Session("IdEstablecimiento"), Request.QueryString("IdProc"), Me.ddProveedor.SelectedValue)
                Me.GridView1.Columns(0).Visible = False
                Me.GridView1.Columns(1).Visible = False
                Me.GridView1.Columns(2).Visible = False
                Me.GridView1.Columns(3).Visible = False
                Me.GridView1.Columns(4).Visible = False
                Me.GridView1.Columns(5).Visible = False
                Me.GridView1.Columns(6).Visible = False
                Me.GridView1.Columns(7).Visible = True
                Me.GridView1.Columns(8).Visible = True
                Me.GridView1.DataBind()


                If Me.DropDownList1.SelectedValue = 0 Then
                    dv.RowFilter = "idproveedor = " & Me.ddProveedor.SelectedValue & " AND cantidadatrasoalmacen > 0 "
                Else
                    dv.RowFilter = "idproveedor = " & Me.ddProveedor.SelectedValue & " AND ((cantidadtotal-cantidadentregadaalmacen)>0)"
                End If

                ' gvDetalle.DataSource = dv

                Me.Session("dsRecepciones") = dv

                Me.gvDetalle.Columns(0).Visible = True
                Me.gvDetalle.Columns(1).Visible = True
                Me.gvDetalle.Columns(2).Visible = True
                Me.gvDetalle.Columns(3).Visible = True
                Me.gvDetalle.Columns(4).Visible = True
                Me.gvDetalle.Columns(5).Visible = False

                If Me.DropDownList1.SelectedValue = 0 Then
                    Me.gvDetalle.Columns(11).Visible = True
                    Me.gvDetalle.Columns(12).Visible = False
                    Me.gvDetalle.Columns(13).Visible = True
                    Me.gvDetalle.Columns(14).Visible = False
                Else
                    Me.gvDetalle.Columns(11).Visible = False
                    Me.gvDetalle.Columns(12).Visible = True
                    Me.gvDetalle.Columns(13).Visible = False
                    Me.gvDetalle.Columns(14).Visible = True
                End If
                'Me.gvDetalle.Columns(6).Visible = True
                'Me.gvDetalle.Columns(7).Visible = True
                'Me.gvDetalle.Columns(8).Visible = True
                Me.gvDetalle.DataBind()

        End Select
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim TipoI, TipoC As Integer
        If Me.DropDownList1.SelectedValue = 0 Then
            TipoI = 0
        Else
            TipoI = 1
        End If

        Select Case Me.RadioButtonList1.SelectedValue
            Case 0
                TipoC = 0
            Case 1
                TipoC = 1
            Case 2
                TipoC = 2
            Case 3
                TipoC = 3
        End Select

        'Response.Write("<script language=javascript>")
        'Response.Write("window.open('" + Request.ApplicationPath + "/Reportes/frmRptIncumplirRecepciones.aspx?TipoI=" & TipoI & "&TipoC=" & TipoC & "&IdProc=" & Request.QueryString("IdProc") & "');")
        'Response.Write("</script>")
        SINAB_Utils.Utils.MostrarVentana("/Reportes/frmRptIncumplirRecepciones.aspx?TipoI=" & TipoI & "&TipoC=" & TipoC & "&IdProc=" & Request.QueryString("IdProc"))
    End Sub
End Class
