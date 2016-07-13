Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Partial Class ESTABLECIMIENTOS_FrmCrearSolicitudCompraDistribucion
    Inherits System.Web.UI.Page
    Private _idsol As Integer
    Public Property idsol() As Integer
        Get
            Return Me._idsol
        End Get
        Set(ByVal value As Integer)
            Me._idsol = value
            If Not Me.ViewState("idsol") Is Nothing Then Me.ViewState.Remove("idsol")
            Me.ViewState.Add("idsol", value)
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            idsol = Request.QueryString("idsol")
            'Dim idsuministro As Integer
            'idsuministro = Request.QueryString("idsu")

            Dim cdetsolicitudes As New cDETALLESOLICITUDES
            gvProductos.DataSource = cdetsolicitudes.obtenerProductosSolicitud2(Session("IdEstablecimiento"), idsol)
            gvProductos.DataBind()

            If Request.QueryString("R") Is Nothing Or Request.QueryString("R") = "" Then
            Else
                Me.LinkButton13.Visible = True
            End If


        Else
            If Not Me.ViewState("idsol") Is Nothing Then Me.idsol = Me.ViewState("idsol")
        End If
    End Sub
    Protected Sub Button6_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click

        If Me.TextBox2.Text = "" And Me.TextBox2.Enabled = True Then
            Me.Label1.Text = "Escriba un parámetro de búsqueda."
            Exit Sub
        Else
            Me.Label1.Text = ""
        End If

        If Me.DropDownList1.SelectedValue = 1 And Me.TextBox2.Text.Length < 8 Then
            Me.Label1.Text = "El código del producto debe ser de 8 dígitos"
            Exit Sub
        End If

        If Me.DropDownList1.SelectedValue = 2 And Me.RadioButtonList2.SelectedIndex = -1 Then
            Me.Label1.Text = "Debe seleccionar un estado."
            Exit Sub
        End If

        Dim ds As New Data.DataSet
        Dim cdetsolicitudes As New cDETALLESOLICITUDES
        ds = cdetsolicitudes.obtenerProductosSolicitud2(idsol, Session("IdEstablecimiento"))
        Dim dv As New Data.DataView
        dv.Table = ds.Tables(0)

        Select Case Me.DropDownList1.SelectedValue
            Case Is = 1
                dv.RowFilter = "renglon=" & Me.TextBox2.Text
            Case Is = 2
                dv.RowFilter = "corrproducto=" & Me.TextBox2.Text
            Case Is = 3
                If Me.RadioButtonList2.SelectedValue = 0 Then
                    'lo que esta capturado
                    dv.RowFilter = "capturado>0"
                Else
                    'lo que no esta capturado
                    dv.RowFilter = "capturado=0"
                End If
        End Select

        gvProductos.DataSource = dv
        gvProductos.DataBind()

        Me.GridView1.Visible = False
        Me.Label17.Visible = False
        Me.Button2.Visible = False

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If Me.DropDownList1.SelectedValue = 3 Then
            Me.TextBox2.Visible = False
            Me.TextBox2.Text = ""
            Me.RadioButtonList2.Visible = True
        Else
            Me.TextBox2.Visible = True
            Me.TextBox2.Text = ""
            Me.RadioButtonList2.Visible = False
            Me.RadioButtonList2.SelectedIndex = -1
        End If
    End Sub
    Protected Sub gvProductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProductos.SelectedIndexChanged, GridView1.SelectedIndexChanged
        Dim renglon, idproducto, idespecificacion, identificadorproducto As Integer

        renglon = Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(2)
        idproducto = Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(0)
        If IsDBNull(Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(4)) Then
            idespecificacion = 0
        Else
            idespecificacion = Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(4)
        End If
        identificadorproducto = Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(5)

        Dim cds As New cDETALLESOLICITUDES

        If cds.ExisteDistribucion(Session("IdEstablecimiento"), idsol, renglon, idproducto) = 0 Then
            cds.InsertarDetallesSolicitudes(Session("IdEstablecimiento"), idsol, renglon, idproducto, idespecificacion, User.Identity.Name, identificadorproducto)
        End If


        GridView1.DataSource = GetSortableData(String.Empty, renglon, idproducto)

        'Me.GridView1.DataSource = cds.obtenerProductosSolicitudDistribucion(Session("IdEstablecimiento"), idsol, renglon, idproducto)
        Me.GridView1.DataBind()

        Me.GridView1.Visible = True
        Me.Label17.Visible = True
        Me.Button2.Visible = True
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim nb As eWorld.UI.NumericBox
            nb = e.Row.FindControl("NumericBox5")
            nb.Text = GridView1.DataKeys(e.Row.RowIndex).Values(2)
        End If

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim renglon, idproducto, idalmacenentrega, idfuentefinanciamiento As Integer

        renglon = Me.GridView1.DataKeys(e.RowIndex).Values(1)
        idproducto = Me.GridView1.DataKeys(e.RowIndex).Values(0)
        idfuentefinanciamiento = Me.GridView1.DataKeys(e.RowIndex).Values(3)
        idalmacenentrega = Me.GridView1.DataKeys(e.RowIndex).Values(4)

        Try
            Dim caes As New cALMACENESENTREGASOLICITUD

            Dim CANTIDAD As Integer = caes.ObtenerSumaCantidad(idsol, Session("IdEstablecimiento"), idalmacenentrega, idfuentefinanciamiento, renglon, idproducto)

            caes.borrarAlmacenesEntregaSolicitud(idsol, Session("IdEstablecimiento"), idalmacenentrega, renglon, idproducto, idfuentefinanciamiento)

            Dim cds As New cDETALLESOLICITUDES
            Dim ds As New DETALLESOLICITUDES
            ds = cds.ObtenerDETALLESOLICITUDES(Session("IdEstablecimiento"), idsol, renglon)

            ds.CANTIDAD = ds.CANTIDAD - CANTIDAD

            cds.ActualizarDETALLESOLICITUDES(ds)

            Me.GridView1.DataSource = cds.obtenerProductosSolicitudDistribucion(Session("IdEstablecimiento"), idsol, renglon, idproducto)
            Me.GridView1.DataBind()

            Me.GridView1.Visible = True
            Me.Label17.Visible = True
            Me.Button2.Visible = True

        Catch ex As Exception
            Me.Label17.Text = "Ocurrio un error al eliminar."
        End Try

    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click


        Dim D As GridViewRow ' Data.DataRow = TProd.NewRow
        For Each D In Me.GridView1.Rows 'TProd.Rows

            Dim c As String

            c = CStr(CType(D.Cells(2).Controls(1), eWorld.UI.NumericBox).Text())
            If c = "" Or c = "0" Then
                Me.Label17.Text = "No se puede agregar productos con cantidad 0.Si no desea esa distribución proceda a eliminarla."
                Exit Sub
            Else
                Me.Label17.Text = ""
            End If

        Next

        Dim cDS As New cDETALLESOLICITUDES
        Dim DS As New DETALLESOLICITUDES


        Try

            Dim x As GridViewRow
            Dim cantidadtotal As Integer
            Dim renglon2 As Integer
            Dim idespecificacion As Integer
            For Each x In Me.GridView1.Rows
                Dim idproducto, renglon, cantidad, idfuente, idalmacen As Integer
                Dim preciounitario As Decimal

                idproducto = Me.GridView1.DataKeys(x.RowIndex).Values(0)
                renglon = Me.GridView1.DataKeys(x.RowIndex).Values(1)
                preciounitario = Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(6)
                renglon2 = renglon
                'cantidad = Me.GridView1.DataKeys(x.RowIndex).Values(2)

                Dim c2 As Integer = CInt(CType(x.Cells(2).Controls(1), eWorld.UI.NumericBox).Text())

                cantidad = c2
                idfuente = Me.GridView1.DataKeys(x.RowIndex).Values(3)
                idalmacen = Me.GridView1.DataKeys(x.RowIndex).Values(4)
                If IsDBNull(Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(4)) Then
                    idespecificacion = 0
                Else
                    idespecificacion = Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(4)
                End If
                'idespecificacion = Me.GridView1.DataKeys(x.RowIndex).Values(5)

                cantidadtotal += cantidad

                'prorrateo bajo metodo ceconi
                Dim ce As New cENTREGASOLICITUDES
                Dim dse As New Data.DataSet
                dse = ce.obtenerEntregasParaProrratear(Session("IdEstablecimiento"), idsol, idproducto, renglon)

                Dim i, numeroentregas As Integer
                Dim sumadistribucion As Decimal = 0
                Dim valor, valoraprox As Decimal
                numeroentregas = dse.Tables(0).Rows.Count

                For i = 0 To numeroentregas - 1

                    If (cantidad - sumadistribucion) > 0 Then
                        If i = numeroentregas - 1 Then
                            dse.Tables(0).Rows(i).Item("cantidad") = cantidad - sumadistribucion
                        Else
                            valoraprox = Fix((cantidad * dse.Tables(0).Rows(i).Item("porcentajeentrega")) / 100)
                            valor = (cantidad * (dse.Tables(0).Rows(i).Item("porcentajeentrega")) / 100)
                            If (valor - valoraprox) >= 0.5 Then
                                dse.Tables(0).Rows(i).Item("cantidad") = valoraprox + 1
                            Else
                                dse.Tables(0).Rows(i).Item("cantidad") = valoraprox
                            End If
                            sumadistribucion += dse.Tables(0).Rows(i).Item("cantidad")
                        End If
                    End If

                Next

                'actualizar aes
                Dim caes As New cALMACENESENTREGASOLICITUD
                Dim y As Integer
                'ACTUALIZACION POR CADA ENTREGA
                For y = 0 To dse.Tables(0).Rows.Count - 1

                    caes.actualizarCantidad(Session("IdEstablecimiento"), idsol, dse.Tables(0).Rows.Count, dse.Tables(0).Rows(y).Item(0), renglon, idproducto, idalmacen, idfuente, dse.Tables(0).Rows(y).Item(2), preciounitario)

                Next

            Next
            ' actualizar la cantidad global en detallesolicitud

            DS = cDS.ObtenerDETALLESOLICITUDES(Session("IdEstablecimiento"), idsol, renglon2)

            DS.CANTIDAD = cantidadtotal
            DS.IDESPECIFICACION = idespecificacion
            DS.PRESUPUESTOTOTAL = DS.PRESUPUESTOUNITARIO * cantidadtotal

            cDS.actualizarCANTIDADProductoSolicitud(cantidadtotal, Session("IdEstablecimiento"), idsol, DS.IDPRODUCTO, idespecificacion)

            cDS.ActualizarDETALLESOLICITUDES(DS)

            Me.GridView1.Visible = False
            Me.Button2.Visible = False
            Me.Label17.Visible = False

            Dim cdetsolicitudes As New cDETALLESOLICITUDES
            gvProductos.DataSource = cdetsolicitudes.obtenerProductosSolicitud2(Session("IdEstablecimiento"), idsol)
            gvProductos.SelectedIndex = -1
            gvProductos.DataBind()

            Me.LinkButton13.Visible = True
            Me.MsgBox1.ShowAlert("Las cantidades se han actualizado satisfactoriamente.", "h", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

        Catch ex As Exception
            Me.MsgBox1.ShowAlert("Error al actualizar las cantidades.", "f", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End Try

    End Sub

    Private Property SortDirection() As String
        Get
            If (ViewState("SortDirection") Is Nothing) Then ViewState("SortDirection") = String.Empty
            Return ViewState("SortDirection").ToString()
        End Get
        Set(ByVal value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    Public Function GetSortableData(ByVal Expression As String, ByVal renglon As Integer, ByVal idproducto As Integer) As Data.DataView
        Dim SelectQry = "select * from Products"
        Dim SortableView As Data.DataView
        Try

            Dim cds As New cDETALLESOLICITUDES
            Dim ds As New Data.DataSet
            ds = cds.obtenerProductosSolicitudDistribucion(Session("IdEstablecimiento"), idsol, renglon, idproducto)

            SortableView = ds.Tables(0).DefaultView
            If (Not String.IsNullOrEmpty(Expression)) Then
                If (SortDirection.ToUpper() = "ASC") Then
                    SortDirection = "DESC"
                Else
                    SortDirection = "ASC"
                End If
                SortableView.Sort = Expression & " " & SortDirection
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return SortableView
    End Function

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim renglon, idproducto As Integer

        renglon = Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(2)
        idproducto = Me.gvProductos.DataKeys(gvProductos.SelectedIndex).Values(0)

        GridView1.DataSource = GetSortableData(e.SortExpression, renglon, idproducto)
        GridView1.DataBind()
    End Sub
    Protected Sub gvProductos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProductos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'validacion si existe distribucion o no
            Dim caes As New cALMACENESENTREGASOLICITUD


            Dim imgOK, imgCheck As Image
            If caes.ExistenRegistrosAES(idsol, Session("IdEstablecimiento"), Me.gvProductos.DataKeys(e.Row.RowIndex).Values(0), Me.gvProductos.DataKeys(e.Row.RowIndex).Values(2)) = 0 Then
                imgOK = e.Row.FindControl("Image1")
                imgOK.Visible = False
                imgCheck = e.Row.FindControl("Image2")
                imgCheck.Visible = True
            Else
                imgOK = e.Row.FindControl("Image1")
                imgOK.Visible = True
                imgCheck = e.Row.FindControl("Image2")
                imgCheck.Visible = False
            End If
        End If
    End Sub
    Protected Sub LinkButton13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton13.Click
        'actualizar los montos en solicitudes y fuente financiamientos solicitudes
        Try
            Dim dsmontofuente As New Data.DataSet
            Dim caes As New cALMACENESENTREGASOLICITUD
            dsmontofuente = caes.ObtenerMontosxFuente(idsol, Session("IdEstablecimiento"))
            Dim i As Integer
            Dim total As Decimal
            For i = 0 To dsmontofuente.Tables(0).Rows.Count - 1
                Dim cffs As New cFUENTEFINANCIAMIENTOSOLICITUDES
                Dim ffs As New FUENTEFINANCIAMIENTOSOLICITUDES
                ffs.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                ffs.IDSOLICITUD = idsol
                ffs.IDFUENTEFINANCIAMIENTO = dsmontofuente.Tables(0).Rows(i).Item(0)
                ffs.MONTOPARTICIPACION = dsmontofuente.Tables(0).Rows(i).Item(1)
                total += dsmontofuente.Tables(0).Rows(i).Item(1)
                cffs.ActualizarFUENTEFINANCIAMIENTOSOLICITUDES(ffs)
            Next

            Dim cs As New cSOLICITUDES
            Dim S As New SOLICITUDES
            S.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            S.IDSOLICITUD = idsol
            S.MONTOSOLICITADO = total
            cs.ActualizarMontoSolicitado(S)
            If Request.QueryString("cj") Is Nothing Or Request.QueryString("cj") = "" Then
                Response.Redirect("~/ESTABLECIMIENTOS/FrmConsultarSolicitudes.aspx", True)
            Else
                Response.Redirect("~/ESTABLECIMIENTOS/FrmConsultarSolicitudesConsolidadas.aspx", True)
            End If

        Catch ex As Exception
            Exit Sub
        End Try
        
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Request.QueryString("cj") Is Nothing Or Request.QueryString("cj") = "" Then
            Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompraProductos.aspx?id=" & idsol & "&R=0&idsu=" & Request.QueryString("idsu") & "&cj=" & Request.QueryString("cj") & "&gu=" & Request.QueryString("gu"))
        Else
            Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompraProductosConsolidado.aspx?id=" & idsol & "&R=0&idsu=" & Request.QueryString("idsu") & "&cj=" & Request.QueryString("cj") & "&gu=" & Request.QueryString("gu"))
        End If

    End Sub
    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
End Class
