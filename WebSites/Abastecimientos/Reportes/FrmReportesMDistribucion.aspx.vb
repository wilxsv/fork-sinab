
Partial Class Reportes_FrmReportesMDistribucion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False

        'Dim Lang As String = "es-MX" 'set your culture here
        'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(Lang)

        If Not IsPostBack Then
            CargarDistribuciones()


            If Session.Item("UsuarioRol") <> "Distribución" Then
                Me.ddlEstab.Visible = False
                Me.chkDistribuidor.Visible = False
                Me.lblEstabPorDefecto.Visible = True
                Me.lblEstabPorDefecto.Text = Session.Item("UsuarioEstablecimiento")
            Else
                Me.lblEstabPorDefecto.Visible = False
                Me.chkDistribuidor.Visible = True
                Me.ddlEstab.Visible = True
                CargarEstablecimientos()
            End If

            CargarProductos()

            
        End If
    End Sub
    Private Sub CargarProductos()
        Dim proddb As New ABASTECIMIENTOS.NEGOCIO.cLOTES
        With Me.ddlProd
            .DataSource = proddb.RecuperarProductosAlmacen(Session.Item("IdAlmacen"))
            .DataTextField = "PRODUCTO"
            .DataValueField = "IDPRODUCTO"
            .DataBind()
            .Items.Insert(0, New ListItem("( Todos )", 0))
        End With
    End Sub

  
    ''' <summary>
    ''' Carga todos los establecimientos en la db
    ''' </summary>
    ''' <remarks>MINSAL - 07/02/2013</remarks>
    Private Sub CargarEstablecimientos()
        Dim estabdb As New ABASTECIMIENTOS.NEGOCIO.cESTABLECIMIENTOS
        With Me.ddlEstab
            .DataSource = estabdb.ObtenerLista
            .DataTextField = "NOMBRE"
            .DataValueField = "IDESTABLECIMIENTO"
            .DataBind()
            .Items.Insert(0, New ListItem("( Todos )", 0))
        End With

    End Sub

    ''' <summary>
    ''' Carga las distribuciones que estan en ESTADO = 2
    ''' </summary>
    ''' <remarks>MINSAL - 07/02/2013</remarks>
    Private Sub CargarDistribuciones()
        Dim distrosdb As New ABASTECIMIENTOS.NEGOCIO.cDistribucion
        'todo: hacer un enumerable con los estados de las distribuciones que se pueda llamar desde cualquier lado
        'ESTADO 2 = En proceso
        With Me.ddlDistro
            .DataSource = distrosdb.obtenerDistribucionPorEstado(2)
            .DataTextField = "DESCRIPCION"
            .DataValueField = "IDDISTRIBUCION"
            .DataBind()
            .Items.Insert(0, New ListItem("( Todos )", 0))
        End With
        
    End Sub

    Protected Sub lnkCambio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCambio.Click
        If lnkCambio.Text = "Listado" Then
            lnkCambio.Text = "Código"
            Me.txtProd.Text = String.Empty
            Me.txtProd.Visible = False
            Me.ddlProd.Visible = True
        Else
            lnkCambio.Text = "Listado"
            Me.txtProd.Visible = True
            Me.ddlProd.SelectedIndex = 0
            Me.ddlProd.Visible = False
        End If


    End Sub

    Protected Sub btnReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReporte.Click

        Dim proddb As New ABASTECIMIENTOS.NEGOCIO.cPRODUCTOSESTABLECIMIENTOS
        Dim productId As Integer = 0
        Dim s As New StringBuilder

      
        s.Append("/Reportes/FrmRptDistroLotesMonto.aspx")

       

        If Me.chkDistro.Checked Then
            s.Append("?t=1&d=")
            s.Append(Me.ddlDistro.SelectedValue.ToString())

            If Me.chkDetalle.Checked Then
                s.Append("&i=true")
            End If
        End If

        If Me.chkEstab.Checked Then
            If Me.ddlProd.Visible Then
                productId = Me.ddlProd.SelectedValue
            Else
                Dim ds As Data.DataSet = proddb.obtenerIdProductoEstablecimiento(Me.txtProd.Text)
                productId = ds.Tables.Item(0).Rows.Item(0).Item(0)
                'TODO: alert si no existe id producto
            End If

            s.Append("?t=2&ee=")
            s.Append(IIf(Me.ddlEstab.Visible, Me.ddlEstab.SelectedValue.ToString(), Session.Item("IdEstablecimiento")))
            If Not Me.ddlEstab.Visible Or Me.chkDistribuidor.Checked Then
                s.Append("&source=true")
            End If

        End If

        If Me.chkProd.Checked Then
            s.Append("?t=3&p=")
            s.Append(productId.ToString())
        End If


        s.Append(String.Format("&fi={0}&ff={1}", Me.txtFechaIni.Text, Me.txtFechaFin.Text))

        SINAB_Utils.Utils.MostrarVentana(s.ToString())



    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub
End Class


