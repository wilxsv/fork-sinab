Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class UACI_FrmCrearSolicitudLG
    Inherits System.Web.UI.Page

    Private cCP As New cCATALOGOPRODUCTOS

    Private _idsolicitud As Integer
    Public Property idsolicitud() As Integer
        Get
            Return Me._idsolicitud
        End Get
        Set(ByVal value As Integer)
            Me._idsolicitud = value
            If Not Me.ViewState("idsolicitud") Is Nothing Then Me.ViewState.Remove("idsolicitud")
            Me.ViewState.Add("idsolicitud", value)
        End Set
    End Property

    Private _edicion As Integer
    Public Property edicion() As Integer
        Get
            Return Me._edicion
        End Get
        Set(ByVal value As Integer)
            Me._edicion = value
            If Not Me.ViewState("edicion") Is Nothing Then Me.ViewState.Remove("edicion")
            Me.ViewState.Add("edicion", value)
        End Set
    End Property

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub cargaddl()
        Me.ddlESTABLECIMIENTOS1.RecuperarOrdenada(1)
        Me.ddlESTABLECIMIENTOS1.SelectedIndex = 0
        Dim cd As New cDEPENDENCIAESTABLECIMIENTOS

        'Me.ddlDEPENDENCIAS1.Recuperar()
        Me.ddlESTABLECIMIENTOS2.RecuperarOrdenada(1)

        Me.ddlALMACENES1.RecuperarListaOrdenada(0)
        Me.ddlMODALIDADESCOMPRA1.Recuperar()
        Me.ddlSUMINISTROS1.Recuperar()
        ' cargar()
        Me.ddlMODALIDADESCOMPRA1.SelectedValue = 2
        Me.ddlESTABLECIMIENTOS1.SelectedValue = 619
        Me.ddlDEPENDENCIAS1.DataSource = cd.ObtenerDependenciaEstablecimiento(Me.ddlESTABLECIMIENTOS1.SelectedValue)
        Me.ddlDEPENDENCIAS1.DataTextField = "NOMBRE"
        Me.ddlDEPENDENCIAS1.DataValueField = "IDDEPENDENCIA"
        Me.ddlDEPENDENCIAS1.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            cargaddl()

            If Request.QueryString("id") Is Nothing Then
                'nuevo
                edicion = 0
            Else
                'edicion
                Dim cs As New cSOLICITUDES
                Dim ds As Data.DataSet
                idsolicitud = Request.QueryString("id")
                ds = cs.ObtenerLaSolicitud(Request.QueryString("id"), Request.QueryString("idestablecimiento"), User.Identity.Name)

                Me.CalendarPopup1.SelectedDate = ds.Tables(0).Rows(0).Item("FECHASOLICITUD")
                Me.ddlSUMINISTROS1.SelectedValue = ds.Tables(0).Rows(0).Item("IDCLASESUMINISTRO")
                Me.ddlMODALIDADESCOMPRA1.SelectedValue = 2
                Me.Numericbox4.Text = ds.Tables(0).Rows(0).Item("MONTOSOLICITADO")
                Me.NumericBox2.Text = ds.Tables(0).Rows(0).Item("PERIODOUTILIZACION")
                Me.Numericbox1.Text = ds.Tables(0).Rows(0).Item("PLAZOENTREGA")

                Me.ddlESTABLECIMIENTOS1.SelectedValue = ds.Tables(0).Rows(0).Item("IDESTABLECIMIENTO")
                Me.ddlDEPENDENCIAS1.SelectedValue = ds.Tables(0).Rows(0).Item("IDDEPENDENCIASOLICITANTE")
                Me.TextBox1.Text = ds.Tables(0).Rows(0).Item("CORRELATIVO")
                Me.TextBox1.Enabled = False

                If IsDBNull(ds.Tables(0).Rows(0).Item("IDESTABLECIMIENTOENTREGA")) Then
                    Me.RadioButtonList1.SelectedIndex = 0
                    Me.ddlALMACENES1.SelectedValue = ds.Tables(0).Rows(0).Item("IDALMACENENTREGA")
                    Me.ddlALMACENES1.Visible = True
                Else
                    Me.RadioButtonList1.SelectedIndex = 1
                    Me.ddlESTABLECIMIENTOS2.SelectedValue = ds.Tables(0).Rows(0).Item("IDESTABLECIMIENTOENTREGA")
                    Me.ddlESTABLECIMIENTOS2.Visible = True
                End If

                Me.TextBox3.Text = ds.Tables(0).Rows(0).Item("EMPLEADOSOLICITANTE")
                Me.TextBox4.Text = ds.Tables(0).Rows(0).Item("EMPLEADOAREATECNICA")
                edicion = 1
            End If


        Else
            If Not Me.ViewState("idsolicitud") Is Nothing Then Me.idsolicitud = Me.ViewState("idsolicitud")
            If Not Me.ViewState("edicion") Is Nothing Then Me.edicion = Me.ViewState("edicion")
            '  If Not Me.ViewState("entregas") Is Nothing Then Me.entregas = Me.ViewState("entregas")
            '   CargarArbolEntregas()
            If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.TComisionEvaluadora = Me.ViewState("TComisionEvaluadora")
            If Not Me.ViewState("TProd") Is Nothing Then Me.TProd = Me.ViewState("TProd")

        End If
    End Sub

    'Private _entregas As Integer
    'Public Property entregas() As Integer
    '    Get
    '        Return Me._entregas
    '    End Get
    '    Set(ByVal value As Integer)
    '        Me._entregas = value
    '        If Not Me.ViewState("entregas") Is Nothing Then Me.ViewState.Remove("entregas")
    '        Me.ViewState.Add("entregas", value)
    '    End Set
    'End Property

    Dim DetalleEntrega As Data.DataSet

    'Public Sub CargarArbolEntregas() 'llena el treeviw de entreegas
    '    Me.TvEntregas.Nodes.Clear()
    '    Me.TvEntregas.ShowLines = True
    '    Me.TvEntregas.Nodes.Add(BuildNode("Entregas Definidas"))
    '    Dim parent As TreeNode
    '    Dim r As Data.DataRow
    '    Dim mCompEntregas As New cENTREGASOLICITUDES
    '    'entregas = mCompEntregas.ObtenerNumeroEntregas(Me.txtIDSOLICITUD.Text, Session.Item("IdEstablecimiento"))
    '    entregas = mCompEntregas.ObtenerNumeroEntregas(idsolicitud, Me.ddlESTABLECIMIENTOS1.SelectedValue)
    '    If entregas >= 1 Then
    '        Me.BttFormasEntrega.Enabled = False
    '        Me.TvEntregas.ExpandAll()
    '        Me.TvEntregas.Visible = True
    '    End If

    '    Dim i As Integer
    '    For i = 0 To entregas
    '        If i <> entregas Then
    '            Me.TvEntregas.Nodes(0).ChildNodes.Add(BuildNode("Entrega " & i + 1))
    '            DetalleEntrega = mCompEntregas.ObtenerDetalleEntrega(idsolicitud, Me.ddlESTABLECIMIENTOS1.SelectedValue, i + 1)
    '            parent = TvEntregas.Nodes(0).ChildNodes(i)
    '            For Each r In DetalleEntrega.Tables(0).Rows
    '                Dim Nombre As String = r("DIAS") & " Dias / " & r("PORCENTAJE") & " % / " & r("DESCRIPCION")
    '                parent.ChildNodes.Add(BuildNode(Nombre))
    '            Next r
    '        End If
    '    Next i
    'End Sub

    'Private Function BuildNode(ByVal strTextAndValue As String, Optional ByVal strURL As String = "javascript:void(0)") As TreeNode
    '    ' Crea a TreeNode y asigna
    '    ' el texto y el valor 
    '    Dim node As New TreeNode
    '    node.Text = strTextAndValue
    '    node.Value = strTextAndValue
    '    node.NavigateUrl = strURL
    '    node.SelectAction = TreeNodeSelectAction.None

    '    Return node
    'End Function

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cS As New cSOLICITUDES
        Dim s As New SOLICITUDES

        Try
            If edicion = 0 Then
                If cS.ValidarCodigoSolicitud(Me.TextBox1.Text, Me.ddlESTABLECIMIENTOS1.SelectedValue, Me.ddlDEPENDENCIAS1.SelectedValue) Then
                    Me.MsgBox1.ShowAlert("El codigo asignado a esta solicitud ya existe", "d", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                    Exit Sub
                End If

                'AGREGA SOLICITUD

                s.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                s.IDDEPENDENCIASOLICITANTE = Me.ddlDEPENDENCIAS1.SelectedValue
                s.IDSOLICITUD = cS.id_Solicitud(s)

                s.CORRELATIVO = Me.TextBox1.Text
                s.FECHASOLICITUD = Me.CalendarPopup1.SelectedDate
                s.PLAZOENTREGA = Me.Numericbox1.Text
                s.IDCLASESUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue
                s.PERIODOUTILIZACION = 12
                s.MONTOSOLICITADO = Me.Numericbox4.Text
                s.MONTODISPONIBLE = Me.Numericbox4.Text
                s.IDSOLICITANTE = Nothing
                s.EMPLEADOSOLICITANTE = Me.TextBox3.Text
                s.IDAREATECNICA = Nothing
                s.EMPLEADOAREATECNICA = Me.TextBox4.Text
                s.IDESTADO = 6
                Dim cmc As New cTIPOCOMPRAS
                Dim dstc As Data.DataSet
                dstc = cmc.obtenerTipoCompraporMontoLG(Me.Numericbox4.Text)
                s.IDTIPOCOMPRAEJECUTAR = dstc.Tables(0).Rows(0).Item(0)
                s.IDTIPOCOMPRASOLICITADO = dstc.Tables(0).Rows(0).Item(0)
                s.IDTIPOCOMPRASUGERIDO = dstc.Tables(0).Rows(0).Item(0)

                If Me.RadioButtonList1.SelectedValue = 0 Then
                    s.IDALMACENENTREGA = Me.ddlALMACENES1.SelectedValue
                    s.IDESTABLECIMIENTOENTREGA = Nothing
                Else
                    s.IDALMACENENTREGA = Nothing
                    s.IDESTABLECIMIENTOENTREGA = Me.ddlESTABLECIMIENTOS2.SelectedValue
                End If

                s.COMPRACONJUNTA = 0
                s.NUMCORR = 1
                s.AUFECHACREACION = DateTime.Now
                s.AUUSUARIOCREACION = User.Identity.Name
                s.IDCERTIFICA = 15
                s.IDAUTORIZA = 21

                cS.AgregarSOLICITUDES(s)
                Me.idsolicitud = s.IDSOLICITUD
                creartablaf()
                CrearTabla2()
            Else

                'If cS.ValidarCodigoSolicitud(Me.TextBox1.Text, Me.ddlESTABLECIMIENTOS1.SelectedValue) Then
                '    Me.MsgBox1.ShowAlert("El codigo asignado a esta solicitud ya existe", "d", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                '    Exit Sub
                'End If
                s.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                s.IDDEPENDENCIASOLICITANTE = Me.ddlDEPENDENCIAS1.SelectedValue
                s.IDSOLICITUD = idsolicitud

                s.CORRELATIVO = Me.TextBox1.Text
                s.FECHASOLICITUD = Me.CalendarPopup1.SelectedDate
                s.PLAZOENTREGA = Me.Numericbox1.Text
                s.IDCLASESUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue
                s.PERIODOUTILIZACION = 12
                s.MONTOSOLICITADO = Me.Numericbox4.Text
                s.MONTODISPONIBLE = Me.Numericbox4.Text
                s.IDSOLICITANTE = Nothing
                s.EMPLEADOSOLICITANTE = Me.TextBox3.Text
                s.IDAREATECNICA = Nothing
                s.EMPLEADOAREATECNICA = Me.TextBox4.Text
                s.IDESTADO = 6

                Dim cmc As New cTIPOCOMPRAS
                Dim dstc As Data.DataSet
                dstc = cmc.obtenerTipoCompraporMontoLG(Me.Numericbox4.Text)
                s.IDTIPOCOMPRAEJECUTAR = dstc.Tables(0).Rows(0).Item(0)
                s.IDTIPOCOMPRASOLICITADO = dstc.Tables(0).Rows(0).Item(0)
                s.IDTIPOCOMPRASUGERIDO = dstc.Tables(0).Rows(0).Item(0)

                If Me.RadioButtonList1.SelectedValue = 0 Then
                    s.IDALMACENENTREGA = Me.ddlALMACENES1.SelectedValue
                    s.IDESTABLECIMIENTOENTREGA = Nothing
                Else
                    s.IDALMACENENTREGA = Nothing
                    s.IDESTABLECIMIENTOENTREGA = Me.ddlESTABLECIMIENTOS2.SelectedValue
                End If

                s.COMPRACONJUNTA = 0
                s.NUMCORR = 1
                s.AUUSUARIOCREACION = User.Identity.Name
                s.AUFECHAMODIFICACION = DateTime.Now
                s.AUUSUARIOMODIFICACION = User.Identity.Name
                s.IDCERTIFICA = 15
                s.IDAUTORIZA = 21

                cS.ActualizarSOLICITUDES(s)


                'CargarArbolEntregas()
                'Me.LinkButton1.Visible = True

                creartablaf()
                CrearTabla2()

                Dim cffs As New cFUENTEFINANCIAMIENTOSOLICITUDES
                Dim ccf As New cFUENTEFINANCIAMIENTOS

                Dim ds As Data.DataSet
                ds = cffs.ObtenerDatasetFuentesPorSolicitud(Me.ddlESTABLECIMIENTOS1.SelectedValue, idsolicitud)

                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim drProd As Data.DataRow = TComisionEvaluadora.NewRow

                    drProd("IDFUENTE") = ds.Tables(0).Rows(i).Item("IDFUENTEFINANCIAMIENTO")
                    drProd("FUENTE") = ccf.DevolverFFSo(idsolicitud, Me.ddlESTABLECIMIENTOS1.SelectedValue, ds.Tables(0).Rows(i).Item("IDFUENTEFINANCIAMIENTO"))
                    drProd("PORCENTAJE") = ds.Tables(0).Rows(i).Item("PORCENTAJEPARTICIPACION")
                    drProd("PORCENTAJEF") = ds.Tables(0).Rows(i).Item("PORCENTAJEPARTICIPACION") / 100
                    drProd("MONTO") = ds.Tables(0).Rows(i).Item("MONTOPARTICIPACION") 'Server.HtmlDecode(Me.gvProductos.Rows(e.NewSelectedIndex).Cells(3).Text)
                    TComisionEvaluadora.Rows.Add(drProd)
                Next

                If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.ViewState.Remove("TComisionEvaluadora")
                Me.ViewState.Add("TComisionEvaluadora", TComisionEvaluadora)

                Me.GridView2.DataSource = TComisionEvaluadora
                Me.GridView2.DataBind()
                Me.GridView2.Visible = True
                Me.Button5.Visible = True
                Me.ddlFUENTEFINANCIAMIENTOS1.SelectedIndex = -1
                Me.NumericBox3.Text = ""


                'CARGA DE PRODUCTOS
                Dim CDS As New cDETALLESOLICITUDES
                Dim DSS As Data.DataSet
                DSS = CDS.ObtenerDsGridDetalleSolicitud2(idsolicitud, Me.ddlESTABLECIMIENTOS1.SelectedValue)

                For d As Integer = 0 To DSS.Tables(0).Rows.Count - 1
                    Dim drProd As Data.DataRow = TProd.NewRow

                    drProd("IDPRODUCTO") = DSS.Tables(0).Rows(d).Item("IDPRODUCTO") 'Me.gvProductos.DataKeys(e.NewSelectedIndex).Values(0)
                    drProd("CORRPRODUCTO") = DSS.Tables(0).Rows(d).Item("CORRPRODUCTO") 'Server.HtmlDecode(Me.gvProductos.Rows(e.NewSelectedIndex).Cells(1).Text)
                    drProd("DESCLARGO") = DSS.Tables(0).Rows(d).Item("DESCLARGO") 'Server.HtmlDecode(Me.gvProductos.Rows(e.NewSelectedIndex).Cells(2).Text)
                    drProd("DESCRIPCION") = DSS.Tables(0).Rows(d).Item("UNIDAD") 'Server.HtmlDecode(Me.gvProductos.Rows(e.NewSelectedIndex).Cells(3).Text)
                    drProd("CANTIDAD") = DSS.Tables(0).Rows(d).Item("CANTIDAD")
                    drProd("IDUM") = DSS.Tables(0).Rows(d).Item("IDUNIDADMEDIDA")
                    drProd("PU") = DSS.Tables(0).Rows(d).Item("PRESUPUESTOUNITARIO")
                    drProd("R") = DSS.Tables(0).Rows(d).Item("ORDEN")

                    TProd.Rows.Add(drProd)
                Next

                If Not Me.ViewState("TProd") Is Nothing Then Me.ViewState.Remove("TProd")
                Me.ViewState.Add("TProd", TProd)

                Me.GridView1.DataSource = TProd
                Me.GridView1.DataBind()
                Me.GridView1.Visible = True
                Me.Label5.Visible = True


            End If

            Me.MsgBox1.ShowAlert("Los datos generales de la solicitud han sido almacenados, continue adicionando/actualizando el detalle de la solicitud.", "s", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

            Me.Panel2.Visible = True
            Me.Panel1.Visible = True
            Me.Panel4.Visible = True

            Me.TextBox1.Enabled = False
            Me.CalendarPopup1.Enabled = False
            Me.ddlSUMINISTROS1.Enabled = False
            Me.ddlMODALIDADESCOMPRA1.Enabled = False
            Me.NumericBox2.Enabled = False
            Me.ddlDEPENDENCIAS1.Enabled = False
            Me.TextBox10.Enabled = False
            Me.Button3.Enabled = False
            Me.Numericbox4.Enabled = False
            Me.Numericbox1.Enabled = False
            Me.ddlESTABLECIMIENTOS1.Enabled = False
            Me.ddlALMACENES1.Enabled = False
            Me.ddlESTABLECIMIENTOS2.Enabled = False
            Me.TextBox3.Enabled = False
            'Me.TextBox4.Enabled = False
            Me.RadioButtonList1.Enabled = False


            Me.ddlFUENTEFINANCIAMIENTOS1.Recuperar()


        Catch ex As Exception
            Me.MsgBox1.ShowAlert(ex.ToString, "s", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End Try

    End Sub

    Dim TComisionEvaluadora As Data.DataTable

    Private Sub creartablaf()
        TComisionEvaluadora = New Data.DataTable
        Dim ColumIdEmpleado As New Data.DataColumn("IDFUENTE", System.Type.GetType("System.Int32"))
        Dim ColumIdEmpleado2 As New Data.DataColumn("FUENTE", System.Type.GetType("System.String"))
        Dim ColumNombre As New Data.DataColumn("PORCENTAJE", System.Type.GetType("System.Decimal"))
        Dim ColumCargo As New Data.DataColumn("MONTO", System.Type.GetType("System.Decimal"))
        Dim ColumPorc As New Data.DataColumn("PORCENTAJEF", System.Type.GetType("System.Decimal"))
        TComisionEvaluadora.Columns.Add(ColumIdEmpleado)
        TComisionEvaluadora.Columns.Add(ColumIdEmpleado2)
        TComisionEvaluadora.Columns.Add(ColumNombre)
        TComisionEvaluadora.Columns.Add(ColumCargo)
        TComisionEvaluadora.Columns.Add(ColumPorc)
        Dim PrimaryKey(1) As Data.DataColumn
        PrimaryKey(0) = ColumIdEmpleado

        TComisionEvaluadora.PrimaryKey = PrimaryKey

        If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.ViewState.Remove("TComisionEvaluadora")
        Me.ViewState.Add("TComisionEvaluadora", TComisionEvaluadora)
    End Sub

    Private TProd As Data.DataTable

    Private Sub CrearTabla2()
        TProd = New Data.DataTable

        Dim ColumIdProducto As New Data.DataColumn("IDPRODUCTO", System.Type.GetType("System.Int32"))
        Dim ColumCodigo As New Data.DataColumn("CORRPRODUCTO", System.Type.GetType("System.String"))
        Dim ColumNombre As New Data.DataColumn("DESCLARGO", System.Type.GetType("System.String"))
        Dim ColumUM As New Data.DataColumn("DESCRIPCION", System.Type.GetType("System.String"))
        Dim ColumQ As New Data.DataColumn("CANTIDAD", System.Type.GetType("System.Decimal"))
        Dim ColumIDUM As New Data.DataColumn("IDUM", System.Type.GetType("System.Int32"))
        Dim ColumPU As New Data.DataColumn("PU", System.Type.GetType("System.Decimal"))
        Dim ColumR As New Data.DataColumn("R", System.Type.GetType("System.Int32"))
        Dim Columx As New Data.DataColumn("X", System.Type.GetType("System.Int32"))
        Dim Columy As New Data.DataColumn("Y", System.Type.GetType("System.Int32"))
        'Dim ColumEstaHabilitado As New Data.DataColumn("ESTAHABILITADO", System.Type.GetType("System.Int32"))

        TProd.Columns.Add(ColumIdProducto)
        TProd.Columns.Add(ColumCodigo)
        TProd.Columns.Add(ColumNombre)
        TProd.Columns.Add(ColumUM)
        TProd.Columns.Add(ColumQ)
        TProd.Columns.Add(ColumIDUM)
        TProd.Columns.Add(ColumPU)
        TProd.Columns.Add(ColumR)
        TProd.Columns.Add(Columx)
        TProd.Columns.Add(Columy)

        ' TProv.Columns.Add(ColumEstaHabilitado)

        Dim PrimaryKey(1) As Data.DataColumn
        PrimaryKey(0) = ColumIdProducto

        TProd.PrimaryKey = PrimaryKey

        If Not Me.ViewState("TProd") Is Nothing Then Me.ViewState.Remove("TProv")
        Me.ViewState.Add("TProd", TProd)
    End Sub

    Protected Sub ddlESTABLECIMIENTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlESTABLECIMIENTOS1.SelectedIndexChanged
        Dim cD As New cDEPENDENCIAESTABLECIMIENTOS
        Me.ddlDEPENDENCIAS1.DataSource = cD.ObtenerDependenciaEstablecimiento(Me.ddlESTABLECIMIENTOS1.SelectedValue)
        Me.ddlDEPENDENCIAS1.DataTextField = "NOMBRE"
        Me.ddlDEPENDENCIAS1.DataValueField = "IDDEPENDENCIA"
        Me.ddlDEPENDENCIAS1.DataBind()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.SelectedValue = 0 Then
            Me.ddlALMACENES1.Visible = True
            Me.ddlESTABLECIMIENTOS2.Visible = False
        Else
            Me.ddlALMACENES1.Visible = False
            Me.ddlESTABLECIMIENTOS2.Visible = True
        End If
    End Sub

    Protected Sub Button6_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click

        If Me.TextBox2.Text = "" And Me.TextBox2.Enabled = True Then
            Me.Label1.Text = "Escriba un parámetro de búsqueda."
            Exit Sub
        Else
            Me.Label1.Text = ""
        End If

        If Me.DropDownList1.SelectedValue = 0 And Me.TextBox2.Enabled = True Then
            If Me.TextBox2.Text.Length <> 8 Then
                Me.Label1.Text = "El código del producto debe ser de 8 dígitos"
                Exit Sub
            Else
                Me.Label1.Text = ""
            End If
        End If


        Dim ds As Data.DataSet
        If Me.CheckBox1.Checked Then
            ds = cCP.ObtenerCatalogoProductosCompletoHabilitados(Me.ddlSUMINISTROS1.SelectedValue)
        Else

            ds = cCP.ObtenerCatalogoProductosCompletoHabilitados(Me.ddlSUMINISTROS1.SelectedValue, Me.TextBox2.Text)
        End If

        Me.gvProductos.DataSource = ds
        Me.gvProductos.DataBind()
        Me.gvProductos.Visible = True
        Me.gvProductos.SelectedIndex = -1


    End Sub

    Protected Sub CheckBox1_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If Me.CheckBox1.Checked Then
            Me.DropDownList1.Enabled = False
            Me.TextBox2.Enabled = False
        Else
            Me.DropDownList1.Enabled = True
            Me.TextBox2.Enabled = True
        End If
    End Sub


    Protected Sub gvProductos_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvProductos.SelectedIndexChanging
        Dim D As Data.DataRow = TProd.NewRow
        For Each D In TProd.Rows
            If Me.gvProductos.DataKeys(e.NewSelectedIndex).Values(0) = D("IDPRODUCTO") Then
                Me.Label4.Text = "Este producto ya ha sido seleccionado."
                Exit Sub
            Else
                Me.Label4.Text = ""
            End If
        Next

        Dim drProd As Data.DataRow = TProd.NewRow

        drProd("IDPRODUCTO") = Me.gvProductos.DataKeys(e.NewSelectedIndex).Values(0)
        drProd("CORRPRODUCTO") = Server.HtmlDecode(Me.gvProductos.Rows(e.NewSelectedIndex).Cells(1).Text)
        drProd("DESCLARGO") = Server.HtmlDecode(Me.gvProductos.Rows(e.NewSelectedIndex).Cells(2).Text)
        drProd("DESCRIPCION") = Server.HtmlDecode(Me.gvProductos.Rows(e.NewSelectedIndex).Cells(3).Text)
        drProd("CANTIDAD") = 0
        drProd("IDUM") = Me.gvProductos.DataKeys(e.NewSelectedIndex).Values(1)
        drProd("PU") = Me.gvProductos.DataKeys(e.NewSelectedIndex).Values(2)
        drProd("R") = TProd.Rows.Count + 1

        TProd.Rows.Add(drProd)

        ' Me.txtCodigoEmpleado.Text = TComisionEvaluadora.Rows.Count + 1
        'drEmpleado("IDEMPLEADO") = Val(Me.txtCodigoEmpleado.Text) + 1
        If Not Me.ViewState("TProd") Is Nothing Then Me.ViewState.Remove("TProd")
        Me.ViewState.Add("TProd", TProd)

        Me.GridView1.DataSource = TProd
        Me.GridView1.DataBind()
        Me.GridView1.Visible = True
        Me.Label5.Visible = True

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim l, h As DropDownList

            l = CType(e.Row.FindControl("DropDownList2"), DropDownList)


            Select Case Me.RadioButtonList2.SelectedValue
                Case Is = 1
                    Dim x As New ListItem
                    x.Text = 1
                    x.Value = 1
                    l.Items.Add(x)
                Case Is = 2
                    Dim x As New ListItem
                    x.Text = 1
                    x.Value = 1
                    l.Items.Add(x)
                    Dim x2 As New ListItem
                    x2.Text = 2
                    x2.Value = 2
                    l.Items.Add(x2)
                Case Is = 3
                    Dim x As New ListItem
                    x.Text = 1
                    x.Value = 1
                    l.Items.Add(x)
                    Dim x2 As New ListItem
                    x2.Text = 2
                    x2.Value = 2
                    l.Items.Add(x2)
                    Dim x3 As New ListItem
                    x3.Text = 3
                    x3.Value = 3
                    l.Items.Add(x3)
            End Select

            h = CType(e.Row.FindControl("DropDownList3"), DropDownList)

            Dim z As New cFUENTEFINANCIAMIENTOSOLICITUDES
            Dim ds As New Data.DataSet
            ds = z.ObtenerFF(Me.ddlESTABLECIMIENTOS1.SelectedValue, Me.idsolicitud)
            Dim i As Integer

            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim list As New ListItem
                list.Text = ds.Tables(0).Rows(i).Item("nombre")
                list.Value = ds.Tables(0).Rows(i).Item("idfuentefinanciamiento")
                h.Items.Add(list)
            Next
            If edicion <> 0 Then
                ' aqui debe de ir la carga de las fuentes y entregas en cada fila del grid.


            End If
        End If

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim IDPRODUCTO As Integer = Me.GridView1.DataKeys(e.RowIndex).Values(0)

        Try
            'Dim cEB As New cDETALLESOLICITUDES
            'cEB.EliminarENTREGABASES(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDPROVEEDOR)
            TProd.Rows.Remove(TProd.Rows.Find(IDPRODUCTO))

            If Not Me.ViewState("TProd") Is Nothing Then Me.ViewState.Remove("TProd")
            Me.ViewState.Add("TProd", TProd)
            Me.GridView1.DataSource = TProd
            Me.GridView1.DataBind()
            Me.Label17.Text = ""

        Catch ex As Exception
            Me.Label17.Text = "Ocurrio un error al eliminar."
        End Try

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        If Me.GridView1.Rows.Count = 0 Then
            Me.Label17.Text = "No existen productos en la presente solicitud."
            Exit Sub
        Else
            Me.Label17.Text = ""
        End If

        Dim D As GridViewRow ' Data.DataRow = TProd.NewRow
        For Each D In Me.GridView1.Rows 'TProd.Rows

            Dim c As String

            c = CStr(CType(D.Cells(4).Controls(1), eWorld.UI.NumericBox).Text())
            If c = "" Or c = "0" Then
                Me.Label17.Text = "No se puede agregar productos con cantidad 0."
                Exit Sub
            Else
                Me.Label17.Text = ""
            End If

        Next

        Dim cDS As New cDETALLESOLICITUDES
        Dim DS As New DETALLESOLICITUDES

        'Dim cES As New cENTREGASOLICITUDES
        'Dim ES As New ENTREGASOLICITUDES



        Try

            cDS.EliminarDetallesSolicitud(Me.idsolicitud, Me.ddlESTABLECIMIENTOS1.SelectedValue)


            'insertar entregas
            Dim a, b, c As Integer
            a = 0
            b = 0
            c = 0
            For Each GvP As GridViewRow In Me.GridView1.Rows
                Select Case CInt(CType(GvP.Cells(5).Controls(1), DropDownList).SelectedItem.Text)
                    Case Is = 1
                        If a = 0 Then
                            'tabla entregas
                            Dim cE As New cENTREGASOLICITUDES
                            Dim arr As New ArrayList
                            Dim eEntidad As New ENTREGASOLICITUD

                            eEntidad.IDSOLICITUD = idsolicitud
                            eEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                            eEntidad.IDENTREGA = 1
                            eEntidad.NUMEROENTREGA = 1
                            eEntidad.PORCENTAJEENTREGA = 100
                            eEntidad.DIASENTREGA = CInt(Me.TextBox2x.Text)
                            eEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                            eEntidad.AUFECHACREACION = Now
                            arr.Add(eEntidad)

                            cE.actualizarEntregas(idsolicitud, Me.ddlESTABLECIMIENTOS1.SelectedValue, arr)
                            a = 1
                        End If
                        
                    Case Is = 2
                        If b = 0 Then
                            Dim cE As New cENTREGASOLICITUDES
                            Dim arr As New ArrayList
                            Dim eEntidad As New ENTREGASOLICITUD

                            eEntidad.IDSOLICITUD = idsolicitud
                            eEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                            eEntidad.IDENTREGA = 2
                            eEntidad.NUMEROENTREGA = 1
                            eEntidad.PORCENTAJEENTREGA = CDec(Me.TextBox5.Text)
                            eEntidad.DIASENTREGA = CInt(Me.TextBox4.Text)
                            eEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                            eEntidad.AUFECHACREACION = Now
                            arr.Add(eEntidad)

                            Dim eEntidad2 As New ENTREGASOLICITUD

                            eEntidad2.IDSOLICITUD = idsolicitud
                            eEntidad2.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                            eEntidad2.IDENTREGA = 2
                            eEntidad2.NUMEROENTREGA = 2
                            eEntidad2.PORCENTAJEENTREGA = CDec(Me.TextBox8.Text)
                            eEntidad2.DIASENTREGA = CInt(Me.TextBox7.Text)
                            eEntidad2.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                            eEntidad2.AUFECHACREACION = Now
                            arr.Add(eEntidad2)

                            cE.actualizarEntregas(idsolicitud, Me.ddlESTABLECIMIENTOS1.SelectedValue, arr)
                            b = 1
                        End If
                       
                    Case Is = 3
                        If c = 0 Then
                            Dim cE As New cENTREGASOLICITUDES
                            Dim arr As New ArrayList
                            Dim eEntidad As New ENTREGASOLICITUD

                            eEntidad.IDSOLICITUD = idsolicitud
                            eEntidad.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                            eEntidad.IDENTREGA = 3
                            eEntidad.NUMEROENTREGA = 1
                            eEntidad.PORCENTAJEENTREGA = CDec(Me.TextBox11.Text)
                            eEntidad.DIASENTREGA = CInt(Me.TextBox9.Text)
                            eEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                            eEntidad.AUFECHACREACION = Now
                            arr.Add(eEntidad)

                            Dim eEntidad2 As New ENTREGASOLICITUD

                            eEntidad2.IDSOLICITUD = idsolicitud
                            eEntidad2.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                            eEntidad2.IDENTREGA = 3
                            eEntidad2.NUMEROENTREGA = 2
                            eEntidad2.PORCENTAJEENTREGA = CDec(Me.TextBox13.Text)
                            eEntidad2.DIASENTREGA = CInt(Me.TextBox12.Text)
                            eEntidad2.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                            eEntidad2.AUFECHACREACION = Now
                            arr.Add(eEntidad2)

                            Dim eEntidad3 As New ENTREGASOLICITUD

                            eEntidad3.IDSOLICITUD = idsolicitud
                            eEntidad3.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                            eEntidad3.IDENTREGA = 3
                            eEntidad3.NUMEROENTREGA = 3
                            eEntidad3.PORCENTAJEENTREGA = CDec(Me.TextBox15.Text)
                            eEntidad3.DIASENTREGA = CInt(Me.TextBox14.Text)
                            eEntidad3.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                            eEntidad3.AUFECHACREACION = Now
                            arr.Add(eEntidad2)

                            cE.actualizarEntregas(idsolicitud, Me.ddlESTABLECIMIENTOS1.SelectedValue, arr)
                            c = 1
                        End If
                        
                End Select
            Next


            'Dim det As Data.DataRow = TProd.NewRow
            For Each GvP As GridViewRow In Me.GridView1.Rows

                DS.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                DS.IDSOLICITUD = Me.idsolicitud
                DS.RENGLON = GvP.Cells(0).Text 'det("R")
                DS.IDPRODUCTO = Me.GridView1.DataKeys(GvP.RowIndex).Values(0) 'det("IDPRODUCTO")
                DS.CANTIDAD = CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) 'GvP.Cells(0).Text

                DS.IDUNIDADMEDIDA = Me.GridView1.DataKeys(GvP.RowIndex).Values(1) 'det("IDUM")
                DS.PRESUPUESTOUNITARIO = CDec(Me.GridView1.DataKeys(GvP.RowIndex).Values(2)) ' det("PU")
                DS.PRESUPUESTOTOTAL = DS.CANTIDAD * DS.PRESUPUESTOUNITARIO

                DS.NUMEROENTREGAS = CInt(CType(GvP.Cells(5).Controls(1), DropDownList).SelectedItem.Text)
                DS.AUFECHACREACION = Now
                DS.AUUSUARIOCREACION = User.Identity.Name
                DS.ESTASINCRONIZADA = 0
                cDS.ActualizarDETALLESOLICITUDES(DS)


                'entregas
                Select Case CInt(CType(GvP.Cells(5).Controls(1), DropDownList).SelectedItem.Text)
                    'tabla entregasolicitudes
                    Case Is = 1
                        Dim cE As New cENTREGASOLICITUDES

                        Dim entidadE As New ENTREGASOLICITUDES

                        entidadE.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                        entidadE.IDSOLICITUD = idsolicitud
                        entidadE.IDPRODUCTO = Me.GridView1.DataKeys(GvP.RowIndex).Values(0)
                        entidadE.identrega = 1
                        entidadE.AUUSUARIOCREACION = User.Identity.Name
                        entidadE.AUFECHACREACION = DateTime.Now
                        entidadE.ESTASINCRONIZADA = 0

                        cE.AgregarENTREGASOLICITUDES(entidadE)

                        Dim AES As New ALMACENESENTREGASOLICITUD
                        Dim caes As New cALMACENESENTREGASOLICITUD
                        AES.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                        AES.IDSOLICITUD = idsolicitud
                        AES.identrega = 1
                        AES.numeroentrega = 1
                        AES.RENGLON = GvP.Cells(0).Text
                        AES.IDPRODUCTO = Me.GridView1.DataKeys(GvP.RowIndex).Values(0)
                        If Me.RadioButtonList1.SelectedValue = 0 Then
                            AES.IDALMACENENTREGA = Me.ddlALMACENES1.SelectedValue
                        Else
                            Select Case Me.ddlSUMINISTROS1.SelectedValue
                                Case Is = 1
                                    AES.IDALMACENENTREGA = 42
                                Case Is = 2 Or 3
                                    AES.IDALMACENENTREGA = 44
                                Case Is = 4
                                    AES.IDALMACENENTREGA = 46
                                Case Is = 8 Or 9
                                    AES.IDALMACENENTREGA = 50
                                Case Is = 11
                                    AES.IDALMACENENTREGA = 48
                            End Select
                        End If
                        AES.IDUNIDADMEDIDA = Me.GridView1.DataKeys(GvP.RowIndex).Values(1)
                        AES.IDFUENTEFINANCIAMIENTO = CInt(CType(GvP.Cells(6).Controls(1), DropDownList).SelectedValue)
                        AES.CANTIDAD = CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text)
                        AES.PRECIOUNITARIO = CDec(Me.GridView1.DataKeys(GvP.RowIndex).Values(2))
                        AES.AUUSUARIOCREACION = User.Identity.Name
                        AES.AUFECHACREACION = DateTime.Now
                        AES.ESTASINCRONIZADA = 0

                        caes.AgregaralmacenesENTREGAsolicitud(AES)


                    Case Is = 2
                        Dim entidadE As New ENTREGASOLICITUDES
                        Dim cE As New cENTREGASOLICITUDES
                        entidadE.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                        entidadE.IDSOLICITUD = idsolicitud
                        entidadE.IDPRODUCTO = Me.GridView1.DataKeys(GvP.RowIndex).Values(0)
                        entidadE.IDENTREGA = 2
                        entidadE.AUUSUARIOCREACION = User.Identity.Name
                        entidadE.AUFECHACREACION = DateTime.Now
                        entidadE.ESTASINCRONIZADA = 0

                        cE.AgregarENTREGASOLICITUDES(entidadE)

                        Dim AES As New ALMACENESENTREGASOLICITUD
                        Dim caes As New cALMACENESENTREGASOLICITUD
                        AES.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                        AES.IDSOLICITUD = idsolicitud
                        AES.IDENTREGA = 2
                        AES.NUMEROENTREGA = 1
                        AES.RENGLON = GvP.Cells(0).Text
                        AES.IDPRODUCTO = Me.GridView1.DataKeys(GvP.RowIndex).Values(0)
                        If Me.RadioButtonList1.SelectedValue = 0 Then
                            AES.IDALMACENENTREGA = Me.ddlALMACENES1.SelectedValue
                        Else
                            Select Case Me.ddlSUMINISTROS1.SelectedValue
                                Case Is = 1
                                    AES.IDALMACENENTREGA = 42
                                Case Is = 2 Or 3
                                    AES.IDALMACENENTREGA = 44
                                Case Is = 4
                                    AES.IDALMACENENTREGA = 46
                                Case Is = 8 Or 9
                                    AES.IDALMACENENTREGA = 50
                                Case Is = 11
                                    AES.IDALMACENENTREGA = 48
                            End Select
                        End If
                        AES.IDUNIDADMEDIDA = Me.GridView1.DataKeys(GvP.RowIndex).Values(1)
                        AES.IDFUENTEFINANCIAMIENTO = CInt(CType(GvP.Cells(6).Controls(1), DropDownList).SelectedValue)

                        If CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) Mod 2 > 0 Then
                            AES.CANTIDAD = (CInt(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) / 2) + 1
                        Else
                            AES.CANTIDAD = CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) / 2
                        End If

                        AES.PRECIOUNITARIO = CDec(Me.GridView1.DataKeys(GvP.RowIndex).Values(2))
                        AES.AUUSUARIOCREACION = User.Identity.Name
                        AES.AUFECHACREACION = DateTime.Now
                        AES.ESTASINCRONIZADA = 0

                        caes.AgregaralmacenesENTREGAsolicitud(AES)


                        Dim AES2 As New ALMACENESENTREGASOLICITUD
                        Dim caes2 As New cALMACENESENTREGASOLICITUD
                        AES2.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                        AES2.IDSOLICITUD = idsolicitud
                        AES2.IDENTREGA = 2
                        AES2.NUMEROENTREGA = 2
                        AES2.RENGLON = GvP.Cells(0).Text
                        AES2.IDPRODUCTO = Me.GridView1.DataKeys(GvP.RowIndex).Values(0)
                        If Me.RadioButtonList1.SelectedValue = 0 Then
                            AES2.IDALMACENENTREGA = Me.ddlALMACENES1.SelectedValue
                        Else
                            Select Case Me.ddlSUMINISTROS1.SelectedValue
                                Case Is = 1
                                    AES2.IDALMACENENTREGA = 42
                                Case Is = 2 Or 3
                                    AES2.IDALMACENENTREGA = 44
                                Case Is = 4
                                    AES2.IDALMACENENTREGA = 46
                                Case Is = 8 Or 9
                                    AES2.IDALMACENENTREGA = 50
                                Case Is = 11
                                    AES2.IDALMACENENTREGA = 48
                            End Select
                        End If
                        AES2.IDUNIDADMEDIDA = Me.GridView1.DataKeys(GvP.RowIndex).Values(1)
                        AES2.IDFUENTEFINANCIAMIENTO = CInt(CType(GvP.Cells(6).Controls(1), DropDownList).SelectedValue)

                        If CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) Mod 2 > 0 Then
                            AES2.CANTIDAD = (CInt(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) / 2) - 1
                        Else
                            AES2.CANTIDAD = CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) / 2
                        End If

                        AES2.PRECIOUNITARIO = CDec(Me.GridView1.DataKeys(GvP.RowIndex).Values(2))
                        AES2.AUUSUARIOCREACION = User.Identity.Name
                        AES2.AUFECHACREACION = DateTime.Now
                        AES2.ESTASINCRONIZADA = 0

                        caes2.AgregaralmacenesENTREGAsolicitud(AES2)


                    Case Is = 3
                        Dim entidadE As New ENTREGASOLICITUDES
                        Dim cE As New cENTREGASOLICITUDES
                        entidadE.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                        entidadE.IDSOLICITUD = idsolicitud
                        entidadE.IDPRODUCTO = Me.GridView1.DataKeys(GvP.RowIndex).Values(0)
                        entidadE.IDENTREGA = 3
                        entidadE.AUUSUARIOCREACION = User.Identity.Name
                        entidadE.AUFECHACREACION = DateTime.Now
                        entidadE.ESTASINCRONIZADA = 0

                        cE.AgregarENTREGASOLICITUDES(entidadE)

                        Dim AES As New ALMACENESENTREGASOLICITUD
                        Dim caes As New cALMACENESENTREGASOLICITUD
                        AES.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                        AES.IDSOLICITUD = idsolicitud
                        AES.IDENTREGA = 3
                        AES.NUMEROENTREGA = 1
                        AES.RENGLON = GvP.Cells(0).Text
                        AES.IDPRODUCTO = Me.GridView1.DataKeys(GvP.RowIndex).Values(0)
                        If Me.RadioButtonList1.SelectedValue = 0 Then
                            AES.IDALMACENENTREGA = Me.ddlALMACENES1.SelectedValue
                        Else
                            Select Case Me.ddlSUMINISTROS1.SelectedValue
                                Case Is = 1
                                    AES.IDALMACENENTREGA = 42
                                Case Is = 2 Or 3
                                    AES.IDALMACENENTREGA = 44
                                Case Is = 4
                                    AES.IDALMACENENTREGA = 46
                                Case Is = 8 Or 9
                                    AES.IDALMACENENTREGA = 50
                                Case Is = 11
                                    AES.IDALMACENENTREGA = 48
                            End Select
                        End If
                        AES.IDUNIDADMEDIDA = Me.GridView1.DataKeys(GvP.RowIndex).Values(1)
                        AES.IDFUENTEFINANCIAMIENTO = CInt(CType(GvP.Cells(6).Controls(1), DropDownList).SelectedValue)

                        If CInt(CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox11.Text)) - CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox11.Text) > 0 Then
                            AES.CANTIDAD = (CInt(CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox11.Text))) + 1
                        Else
                            AES.CANTIDAD = CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox11.Text)
                        End If

                        AES.PRECIOUNITARIO = CDec(Me.GridView1.DataKeys(GvP.RowIndex).Values(2))
                        AES.AUUSUARIOCREACION = User.Identity.Name
                        AES.AUFECHACREACION = DateTime.Now
                        AES.ESTASINCRONIZADA = 0

                        caes.AgregaralmacenesENTREGAsolicitud(AES)

                        Dim AES2 As New ALMACENESENTREGASOLICITUD
                        Dim caes2 As New cALMACENESENTREGASOLICITUD
                        AES2.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                        AES2.IDSOLICITUD = idsolicitud
                        AES2.IDENTREGA = 3
                        AES2.NUMEROENTREGA = 2
                        AES2.RENGLON = GvP.Cells(0).Text
                        AES2.IDPRODUCTO = Me.GridView1.DataKeys(GvP.RowIndex).Values(0)
                        If Me.RadioButtonList1.SelectedValue = 0 Then
                            AES2.IDALMACENENTREGA = Me.ddlALMACENES1.SelectedValue
                        Else
                            Select Case Me.ddlSUMINISTROS1.SelectedValue
                                Case Is = 1
                                    AES2.IDALMACENENTREGA = 42
                                Case Is = 2 Or 3
                                    AES2.IDALMACENENTREGA = 44
                                Case Is = 4
                                    AES2.IDALMACENENTREGA = 46
                                Case Is = 8 Or 9
                                    AES2.IDALMACENENTREGA = 50
                                Case Is = 11
                                    AES2.IDALMACENENTREGA = 48
                            End Select
                        End If
                        AES2.IDUNIDADMEDIDA = Me.GridView1.DataKeys(GvP.RowIndex).Values(1)
                        AES2.IDFUENTEFINANCIAMIENTO = CInt(CType(GvP.Cells(6).Controls(1), DropDownList).SelectedValue)

                        If CInt(CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox13.Text)) - CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox13.Text) > 0 Then
                            AES2.CANTIDAD = (CInt(CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox13.Text))) + 1
                        Else
                            AES2.CANTIDAD = CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox13.Text)
                        End If

                        AES2.PRECIOUNITARIO = CDec(Me.GridView1.DataKeys(GvP.RowIndex).Values(2))
                        AES2.AUUSUARIOCREACION = User.Identity.Name
                        AES2.AUFECHACREACION = DateTime.Now
                        AES2.ESTASINCRONIZADA = 0

                        caes2.AgregaralmacenesENTREGAsolicitud(AES2)


                        Dim AES3 As New ALMACENESENTREGASOLICITUD
                        Dim caes3 As New cALMACENESENTREGASOLICITUD
                        AES3.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                        AES3.IDSOLICITUD = idsolicitud
                        AES3.IDENTREGA = 3
                        AES3.NUMEROENTREGA = 3
                        AES3.RENGLON = GvP.Cells(0).Text
                        AES3.IDPRODUCTO = Me.GridView1.DataKeys(GvP.RowIndex).Values(0)
                        If Me.RadioButtonList1.SelectedValue = 0 Then
                            AES3.IDALMACENENTREGA = Me.ddlALMACENES1.SelectedValue
                        Else
                            Select Case Me.ddlSUMINISTROS1.SelectedValue
                                Case Is = 1
                                    AES3.IDALMACENENTREGA = 42
                                Case Is = 2 Or 3
                                    AES3.IDALMACENENTREGA = 44
                                Case Is = 4
                                    AES3.IDALMACENENTREGA = 46
                                Case Is = 8 Or 9
                                    AES3.IDALMACENENTREGA = 50
                                Case Is = 11
                                    AES3.IDALMACENENTREGA = 48
                            End Select
                        End If
                        AES3.IDUNIDADMEDIDA = Me.GridView1.DataKeys(GvP.RowIndex).Values(1)
                        AES3.IDFUENTEFINANCIAMIENTO = CInt(CType(GvP.Cells(6).Controls(1), DropDownList).SelectedValue)

                        If CInt(CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox15.Text)) - CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox15.Text) > 0 Then
                            AES3.CANTIDAD = (CInt(CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox15.Text))) - 2
                        Else
                            AES3.CANTIDAD = CDec(CType(GvP.Cells(4).Controls(1), eWorld.UI.NumericBox).Text) * CDec(Me.TextBox15.Text)
                        End If

                        AES3.PRECIOUNITARIO = CDec(Me.GridView1.DataKeys(GvP.RowIndex).Values(2))
                        AES3.AUUSUARIOCREACION = User.Identity.Name
                        AES3.AUFECHACREACION = DateTime.Now
                        AES3.ESTASINCRONIZADA = 0

                        caes3.AgregaralmacenesENTREGAsolicitud(AES3)


                End Select

            Next

            Me.GridView1.Columns(5).Visible = True
            Me.Button2.Enabled = False
            Me.MsgBox1.ShowAlert("Los productos se han almacenado satisfactoriamente.", "h", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

        Catch ex As Exception
            Me.MsgBox1.ShowAlert("Error al guardar los productos.", "f", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End Try


    End Sub

    'Protected Sub BttFormasEntrega_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BttFormasEntrega.Click
    '    Session.Item("IdEst") = Me.ddlESTABLECIMIENTOS1.SelectedValue
    '    Session.Item("idDoc") = Me.idsolicitud
    '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "vistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/ESTABLECIMIENTOS/frmPlazoEntregaSolicitud.aspx', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 600 ,height= 600 '); </script>")
    '    Me.BttFormasEntrega.Enabled = False
    '    Me.BttFormasEntrega.Text = "Entregas definidas"
    'End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim drProd As Data.DataRow = TComisionEvaluadora.NewRow

        drProd("IDFUENTE") = Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue
        drProd("FUENTE") = Me.ddlFUENTEFINANCIAMIENTOS1.SelectedItem.Text
        drProd("PORCENTAJE") = Me.NumericBox3.Text
        drProd("PORCENTAJEF") = Me.NumericBox3.Text / 100
        drProd("MONTO") = (Me.NumericBox3.Text * Me.Numericbox4.Text) / 100 'Server.HtmlDecode(Me.gvProductos.Rows(e.NewSelectedIndex).Cells(3).Text)
        TComisionEvaluadora.Rows.Add(drProd)

        If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.ViewState.Remove("TComisionEvaluadora")
        Me.ViewState.Add("TComisionEvaluadora", TComisionEvaluadora)

        Me.GridView2.DataSource = TComisionEvaluadora
        Me.GridView2.DataBind()
        Me.GridView2.Visible = True
        Me.Button5.Visible = True
        Me.ddlFUENTEFINANCIAMIENTOS1.SelectedIndex = -1
        Me.NumericBox3.Text = ""

    End Sub

    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Dim IDFUENTE As Integer = Me.GridView2.DataKeys(e.RowIndex).Values(0)

        Try
            'Dim cEB As New cDETALLESOLICITUDES
            'cEB.EliminarENTREGABASES(Session("IdEstablecimiento"), Request.QueryString("idProc"), IDPROVEEDOR)
            Me.TComisionEvaluadora.Rows.Remove(TComisionEvaluadora.Rows.Find(IDFUENTE))

            If Not Me.ViewState("TComisionEvaluadora") Is Nothing Then Me.ViewState.Remove("TComisionEvaluadora")
            Me.ViewState.Add("TComisionEvaluadora", TComisionEvaluadora)
            Me.GridView2.DataSource = TComisionEvaluadora
            Me.GridView2.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim porc As Decimal
        For Each row1 As GridViewRow In Me.GridView2.Rows
            porc += Me.GridView2.DataKeys(row1.RowIndex).Values(1)
        Next
        If porc > 100 Then
            Me.MsgBox1.ShowAlert("Los porcentajes de participacion de las fuentes de financiamiento superan el 100%.", "l", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If

        Dim dF As New cFUENTEFINANCIAMIENTOSOLICITUDES
        Dim f As New FUENTEFINANCIAMIENTOSOLICITUDES
        Try
            If edicion <> 0 Then
                dF.EliminarFUENTESSOLICITUD(idsolicitud, Me.ddlESTABLECIMIENTOS1.SelectedValue)
            End If
            For Each row As GridViewRow In Me.GridView2.Rows

                f.IDESTABLECIMIENTO = Me.ddlESTABLECIMIENTOS1.SelectedValue
                f.IDSOLICITUD = Me.idsolicitud
                f.IDFUENTEFINANCIAMIENTO = Me.GridView2.DataKeys(row.RowIndex).Values(0)
                f.MONTOPARTICIPACION = row.Cells(2).Text
                f.PORCENTAJEPARTICIPACION = Me.GridView2.DataKeys(row.RowIndex).Values(1)
                f.AUUSUARIOCREACION = User.Identity.Name
                f.AUFECHACREACION = Now
                f.ESTASINCRONIZADA = 0

                dF.AgregarFUENTEFINANCIAMIENTOSOLICITUDES(f)
            Next
            Me.Panel3.Visible = False
            Me.Button5.Visible = False
            Me.GridView2.Columns(3).Visible = False

            Me.MsgBox1.ShowAlert("Las fuentes de financiamiento han sido guardadas satisfactoriamente.", "f", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cTS As New cSUMINISTROS
        Dim tipoS As Integer = cTS.ObtenerTIPOSUMINISTROS(Me.ddlSUMINISTROS1.SelectedValue)
        If tipoS = 1 Then
            Response.Redirect("~/Catalogos/wfManCatProductos.aspx?idS=" & Me.ddlSUMINISTROS1.SelectedValue, False)
        Else
            Response.Redirect("~/Catalogos/wfManCatProductos2.aspx?idS=" & Me.ddlSUMINISTROS1.SelectedValue, False)
        End If

    End Sub

    'Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

    '    Dim mCompEntregas As New cENTREGASOLICITUDES
    '    Dim DE As New cDETALLEENTREGAS
    '    Try
    '        DE.EliminarDETALLEENTREGASxSolicitud(idsolicitud, Me.ddlESTABLECIMIENTOS1.SelectedValue)
    '        mCompEntregas.EliminarENTREGASXSolicitud(idsolicitud, Me.ddlESTABLECIMIENTOS1.SelectedValue)
    '        Me.TvEntregas.Nodes.Clear()

    '    Catch ex As Exception
    '        Me.MsgBox1.ShowAlert("Ocurrio un error.", "s", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    '    End Try

    'End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList2.SelectedIndexChanged
        Select Case Me.RadioButtonList2.SelectedValue
            Case Is = 1
                Me.Panel5x.Visible = True
                Me.Panel6.Visible = False
                Me.Panel7.Visible = False
            Case Is = 2
                Me.Panel5x.Visible = True
                Me.Panel6.Visible = True
                Me.Panel7.Visible = False
            Case Is = 3
                Me.Panel5x.Visible = True
                Me.Panel6.Visible = True
                Me.Panel7.Visible = True
        End Select
    End Sub

    Protected Sub Button6x_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6x.Click
        Me.Panel2.Enabled = False

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

  
End Class
