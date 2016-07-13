
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Partial Class UACI_FrmGenerarResolucionAdjudicacionModificacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            IniDatos()
        End If

    End Sub
    Private Sub IniDatos()
        Dim objAdjudicacion As New cADJUDICACION
        Dim idpc, ide, renglon As String
        ide = String.Empty
        idpc = ide
        renglon = ide
        idpc = Request.QueryString("IDPC")
        ide = Request.QueryString("IDe")
        renglon = Request.QueryString("IDR")
        Dim dtProducto, dtAlmacen As New DataTable
        dtProducto = objAdjudicacion.obtenerDatasetRenglonProductoCantidadRecomendada(ide, idpc, renglon).Tables(0)
        Dim dv As New DataView(dtProducto)
        If Not dtProducto Is Nothing Then
            If Not dtProducto.Rows.Count = 0 Then
                Dim dtRenglones As DataTable = dv.ToTable(True, "renglon")
                ddlRenglon.DataSource = dtRenglones
                ddlRenglon.DataTextField = "renglon"
                ddlRenglon.DataValueField = "renglon"
                ddlRenglon.DataBind()
            End If
        End If
        If (Not dtProducto.Rows.Count = 0) And (Not dtAlmacen.Rows.Count = 0) Then
            btnSave.Visible = True
        Else
            btnSave.Visible = False
        End If
        
        'dtAlmacen = objAdjudicacion.obtenerDatasetRenglonProveedorAlmacenCantidad(ide, idpc, renglon).Tables(0)
        'gvRenglonProductoCantidad.DataSource = dtProducto
        'gvRenglonProductoCantidad.DataBind()
        'gvEstablecimientoCantidad.DataSource = dtAlmacen
        'gvEstablecimientoCantidad.DataBind()

    End Sub

    Protected Sub gvEstablecimientoCantidad_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEstablecimientoCantidad.RowDataBound
        'me.gvRenglonProductoCantidad.FindControl("txtCantidadEntrega") e.Row.Cells(
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim almacen, proveedor, entrega As String
            Dim cuenta As Integer = 0
            almacen = e.Row.Cells(2).Text
            proveedor = e.Row.Cells(4).Text
            entrega = e.Row.Cells(7).Text
            'For Each reg As GridViewRow In gvEstablecimientoCantidad.Rows
            '    cuenta = 0
            '    If almacen = reg.Cells(2).Text And proveedor = reg.Cells(4).Text And entrega = e.Row.Cells(7).Text Then
            '        cuenta += 1
            '    End If
            'Next
            If cuenta = 0 Then
                CType(e.Row.FindControl("txtNuevaDistribucion"), TextBox).Text = e.Row.Cells(5).Text
                CType(e.Row.FindControl("txtNuevaDistribucion"), TextBox).Enabled = True
            Else
                CType(e.Row.FindControl("txtNuevaDistribucion"), TextBox).Enabled = False
            End If
            'CType(e.Row.FindControl("txtNuevaEntrega"), TextBox).Text = e.Row.Cells(5).Text * e.Row.Cells(9).Text.Substring(0, e.Row.Cells(9).Text.Length - 1) / 100
        End If
    End Sub

    Protected Function ValidarValoresGrid() As Boolean
        Return GetCantidadProveedor()
    End Function
    Private Function GetCantidadProveedor() As Boolean
        lblMsj.Text = ""
        For i As Integer = 0 To gvRenglonProductoCantidad.Rows.Count - 1
            Dim idp, idd As String
            Dim subTotalP As Double = 0
            Dim limite As Double = 0
            idp = gvRenglonProductoCantidad.Rows(i).Cells(3).Text
            idd = gvRenglonProductoCantidad.Rows(i).Cells(4).Text
            limite = gvRenglonProductoCantidad.Rows(i).Cells(5).Text
            For j As Integer = 0 To gvEstablecimientoCantidad.Rows.Count - 1
                If idp = gvEstablecimientoCantidad.Rows(j).Cells(4).Text And idd = gvEstablecimientoCantidad.Rows(j).Cells(8).Text Then
                    Dim txt As TextBox

                    Dim almacen, proveedor, entrega, iddetalle As String
                    Dim cuenta As Integer = 0
                    almacen = gvEstablecimientoCantidad.Rows(j).Cells(2).Text
                    proveedor = gvEstablecimientoCantidad.Rows(j).Cells(4).Text
                    entrega = gvEstablecimientoCantidad.Rows(j).Cells(7).Text
                    iddetalle = gvEstablecimientoCantidad.Rows(j).Cells(8).Text
                    For reg As Integer = 0 To j - 1
                        cuenta = 0
                        If almacen = gvEstablecimientoCantidad.Rows(reg).Cells(2).Text And proveedor = gvEstablecimientoCantidad.Rows(reg).Cells(4).Text And entrega = gvEstablecimientoCantidad.Rows(reg).Cells(7).Text And iddetalle = gvEstablecimientoCantidad.Rows(reg).Cells(8).Text Then
                            cuenta += 1
                        End If
                    Next reg
                    If cuenta = 0 Then
                        txt = gvEstablecimientoCantidad.Rows(j).Cells(6).FindControl("txtNuevaDistribucion")
                        If txt.Text = "" Then
                            subTotalP += 0
                        Else
                            subTotalP += txt.Text
                        End If
                    End If
                    'CType(gvEstablecimientoCantidad.Rows(j).FindControl("txtNuevaEntrega"), TextBox).Text = txt.Text * gvEstablecimientoCantidad.Rows(j).Cells(9).Text.Substring(0, gvEstablecimientoCantidad.Rows(j).Cells(9).Text.Length - 1) / 100
                    If limite < subTotalP Then
                        lblMsj.Text = "la suma no es igual al total Adjudicado Total adjudicado: " & limite & " suma total de la nueva distribucion: " & subTotalP & " <br> diferencia de : " & (limite - subTotalP)
                        lblMsj.ForeColor = Drawing.Color.Red
                        lblMsj.Font.Bold = True
                        gvEstablecimientoCantidad.Rows(j).Cells(6).BackColor = Drawing.Color.Red
                        gvRenglonProductoCantidad.Rows(i).Cells(5).BackColor = Drawing.Color.Red

                        Return False

                    Else
                        gvEstablecimientoCantidad.Rows(j).Cells(6).BackColor = Drawing.Color.Empty
                        gvRenglonProductoCantidad.Rows(i).Cells(5).BackColor = Drawing.Color.Empty
                    End If

                    ' Response.Write(gvEstablecimientoCantidad.Rows(j).Cells(5).BackColor)


                    '

                End If
            Next j
            If Not limite = subTotalP Then
                lblMsj.Text = "la suma no es igual al total Adjudicado Total adjudicado: " & limite & " suma total de la nueva distribucion: " & subTotalP & " <br> diferencia de : " & (limite - subTotalP)
                lblMsj.ForeColor = Drawing.Color.Red
                lblMsj.Font.Bold = True
                For j As Integer = 0 To gvEstablecimientoCantidad.Rows.Count - 1
                    If idp = gvEstablecimientoCantidad.Rows(j).Cells(4).Text And idd = gvEstablecimientoCantidad.Rows(j).Cells(8).Text Then
                        gvEstablecimientoCantidad.Rows(j).Cells(6).BackColor = Drawing.Color.Red
                    End If
                Next j
                gvRenglonProductoCantidad.Rows(i).Cells(5).BackColor = Drawing.Color.Red
                Return False
            End If
        Next
        Return True
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidarValoresGrid() Then
            actualizaCambiosGrid()
        Else
            'lblMsj.Text = "Favor de revisar las cantidades de distribuicion "
        End If
    End Sub

    Protected Sub txtNuevaDistribucion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If ValidarValoresGrid() Then
        'Me.MsgBox1.ShowAlert("Registro guardado exitosamente", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Stop)
        ' Else
        'Me.MsgBox1.ShowAlert("Favor de revisar las cantidades de distribuicion ", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, Cooperator.Framework.Web.Controls.AlertType.Stop)
        ' End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        ' Response.Write(e.Key)
    End Sub
    Private Function actualizaCambiosGrid() As Boolean
        Dim objAdjudicacion As New cADJUDICACION
        Dim idpc, ide, renglon, idproveedor, identrega, idalmacen, iddetalle As String
        Dim Cantidad As Double
        ide = String.Empty
        idpc = ide
        renglon = ide
        idpc = Request.QueryString("IDPC")
        ide = Request.QueryString("IDe")
        renglon = ddlRenglon.SelectedValue
        For j As Integer = 0 To gvEstablecimientoCantidad.Rows.Count - 1
            If Not CType(gvEstablecimientoCantidad.Rows(j).Cells(6).FindControl("txtNuevaDistribucion"), TextBox).Text = gvEstablecimientoCantidad.Rows(j).Cells(4).Text Then
                Cantidad = 0
                idproveedor = gvEstablecimientoCantidad.Rows(j).Cells(4).Text
                idalmacen = gvEstablecimientoCantidad.Rows(j).Cells(2).Text
                identrega = gvEstablecimientoCantidad.Rows(j).Cells(7).Text
                iddetalle = gvEstablecimientoCantidad.Rows(j).Cells(8).Text
                Cantidad = CType(gvEstablecimientoCantidad.Rows(j).Cells(6).FindControl("txtNuevaDistribucion"), TextBox).Text

                objAdjudicacion.ActualizarALMACENESENTREGAADJUDICACION(ide, idpc, renglon, idproveedor, idalmacen, identrega, Cantidad, Session.Item("CodUsuario"), iddetalle)
            End If
        Next j
        lblMsj.Text = "Registro guardado exitosamente"
        lblMsj.ForeColor = Drawing.Color.Blue
        lblMsj.Font.Bold = True
        Return False
    End Function


   
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Script passing data to main page
        Response.Write("<script>window.close();</script>")
        'Dim Script As String = ""
        'Script += vbLf & "<script language=JavaScript id='ClosePopup'>" & vbLf
        'Dim data As String = String.Empty
        ''  data = TextBox1.Text
        '' Script += "window.opener.addOption('" & data & "'); "
        'Script += "self.close();"
        'Script += "</script>"

        ''Check wether it is already registerd.
        'If Not ClientScript.IsClientScriptBlockRegistered("ClosePopup") Then
        '    'Register the script
        '    ClientScript.RegisterClientScriptBlock(Me.GetType, "ClosePopup", Script)
        'End If
    End Sub

    Protected Sub btnVer_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LlenaGrid()
    End Sub
    Private Sub LlenaGrid()
        Dim objAdjudicacion As New cADJUDICACION
        Dim idpc, ide, renglon, idproveedor, identrega, idalmacen As String
        idpc = Request.QueryString("IDPC")
        ide = Request.QueryString("IDe")
        renglon = ddlRenglon.SelectedValue
        Dim dtProducto, dtAlmacen As New DataTable
        dtProducto = objAdjudicacion.obtenerDatasetRenglonProductoCantidadRecomendada(ide, idpc, renglon).Tables(0)
        dtAlmacen = objAdjudicacion.obtenerDatasetRenglonProveedorAlmacenCantidad(ide, idpc, renglon).Tables(0)
        gvRenglonProductoCantidad.DataSource = dtProducto
        gvRenglonProductoCantidad.DataBind()
        gvEstablecimientoCantidad.DataSource = dtAlmacen
        gvEstablecimientoCantidad.DataBind()
        If (Not dtProducto.Rows.Count = 0) And (Not dtAlmacen.Rows.Count = 0) Then
            btnSave.Visible = True
        Else
            btnSave.Visible = False
        End If

    End Sub
End Class
