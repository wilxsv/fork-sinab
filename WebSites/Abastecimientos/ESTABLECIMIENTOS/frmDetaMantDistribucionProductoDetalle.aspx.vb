Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports SINAB_Utils.MessageBox

Partial Class ESTABLECIMIENTOS_frmDetaMantdistribucionProductoDetalle
    Inherits System.Web.UI.Page

    Private _IDDISTRIBUCION As Integer

    Public Property IDDISTRIBUCION() As Integer 'identificador de distribución
        Get
            Return Me._IDDISTRIBUCION
        End Get
        Set(ByVal Value As Integer)
            Me._IDDISTRIBUCION = Value
            If Not Me.ViewState("IDDISTRIBUCION") Is Nothing Then Me.ViewState.Remove("IDDISTRIBUCION")
            Me.ViewState.Add("IDDISTRIBUCION", Value)
        End Set
    End Property

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'evento cancelar
        Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'al cargar por primera vez la página

            'No viene de la pagina principal el usuario
            If Request.QueryString("id") Is Nothing Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
            End If

            If Request.QueryString("id") = "" Then
                Response.Redirect("~/ESTABLECIMIENTOS/frmMantDistribucion.aspx", False)
            End If

            'Navegacion
            Me.Master.ControlMenu.Visible = False 'ocultar menu
            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirCancelar = True
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False

            Dim lId As String = Request.QueryString("id") 'identificador de usuario
            IDDISTRIBUCION = lId

            CargarDatos()

            'Llenamos restantes
            Dim cDistro As New cDistribucion
            Dim eDistro As DISTRIBUCION = cDistro.obtenerDistribucionPorID(IDDISTRIBUCION, Session.Item("IdEstablecimiento"))

            Me.lblDistro.Text = "No. " & eDistro.IDDISTRIBUCION & " (" & eDistro.FECHADISTRIBUCION.Month & "/" & eDistro.FECHADISTRIBUCION.Year & ") - " & eDistro.DESCRIPCION
            Me.lblAlmacen.Text = eDistro.NOMBREALMACEN
            Me.lblSuministro.Text = eDistro.SUMINISTRO

            If eDistro.ESTADO = 2 Then
                btnCierre.Enabled = False
            End If

        Else

            If Not Me.ViewState("IDDISTRIBUCION") Is Nothing Then Me._IDDISTRIBUCION = Me.ViewState("IDDISTRIBUCION")

        End If

    End Sub

    Private Sub CargarDatos() 'carga los datos y los muestra en el gridview

        Dim ds As Data.DataSet
        Dim mComponente As New cDISTRIBUCIONPRODUCTO
        Dim filtro As String

        ds = mComponente.obtenerDistribucionProductosDetalle(Me.IDDISTRIBUCION, Session.Item("IdEstablecimiento"))

        If Me.CheckBox1.Checked Then
            filtro = "CANTIDADALMACEN >=0"
        Else
            filtro = "CANTIDADALMACEN >0"
        End If

        Dim dv As Data.DataView = New Data.DataView(ds.Tables(0), filtro, "CORRPRODUCTO", Data.DataViewRowState.CurrentRows)

        Me.gvLista.DataSource = dv

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        CargarDatos()
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting


        Dim IDDISTRIBUCION As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(0)
        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.RowIndex).Values(1)

        Dim TIPO As Integer


        TIPO = 1


        'Mostrar el reporte
        Dim alerta As String = "/Reportes/frmRptDistribucion.aspx?id=" & IDDISTRIBUCION & "&tipo=" & TIPO & "&est=0&prod=" & IDPRODUCTO

        SINAB_Utils.Utils.MostrarVentana(alerta)


    End Sub

    Protected Sub gvLista_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvLista.SelectedIndexChanging

        Dim IDDISTRIBUCION As Integer = Me.gvLista.DataKeys(e.NewSelectedIndex).Values(0)
        Dim IDPRODUCTO As Integer = Me.gvLista.DataKeys(e.NewSelectedIndex).Values(1)

        Dim ruta As String

        Dim cdistro As New cDistribucion
        Dim edistro As DISTRIBUCION = cdistro.obtenerDistribucionPorID(IDDISTRIBUCION, Session.Item("IdEstablecimiento"))

        If edistro.idestablecimiento <> 620 Then
            ruta = "~/ESTABLECIMIENTOS/frmMantDistribucionDetalle.aspx?id=" & IDDISTRIBUCION & "&idProducto=" & IDPRODUCTO
        Else
            ruta = "~/ESTABLECIMIENTOS/frmMantDistribucionDetalle2.aspx?id=" & IDDISTRIBUCION & "&idProducto=" & IDPRODUCTO
        End If


        Response.Redirect(ruta, False)

    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Call CargarDatos()
    End Sub

    Protected Sub btnReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReporte.Click

        Dim IDDISTRIBUCION As Integer = Me.ViewState("IDDISTRIBUCION")
        Dim TIPO As Integer


        TIPO = 1


        'Mostrar el reporte
        Dim alerta As String = "/Reportes/frmRptDistribucion.aspx?id=" & IDDISTRIBUCION & "&tipo=" & TIPO & "&est=0&prod=0"

        SINAB_Utils.Utils.MostrarVentana(alerta)


    End Sub

    Protected Sub btnCierre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCierre.Click

        Dim xIDDISTRIBUCION As Integer = Me.ViewState("IDDISTRIBUCION")
        Dim xUSUARIO As String = HttpContext.Current.User.Identity.Name

        Dim cComponente As New cDistribucion

        If cComponente.actualizarEstadoDistribucion(xIDDISTRIBUCION, Session.Item("IdEstablecimiento"), 2, xUSUARIO, Session.Item("idTipoEstablecimiento")) = -1 Then
            'Me.MsgBox1.ShowAlert("Error al cerrar la distribución.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Alert("Error al cerrar la distribución.")
            Exit Sub
        Else
            'SCMS
            'Se inserta la distribución cerrada en las tablas de distribuciones cerradas con todo el detalle
            cComponente.agregarDistribucionCerradas(xIDDISTRIBUCION, Session.Item("IdEstablecimiento"))

            Alert("Se ha cerrado exitosamente la distribución.")
            'Me.MsgBox1.ShowAlert("Se ha cerrado exitosamente la distribución.", "Aviso", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If


    End Sub

    Protected Sub btnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnular.Click

        Dim xIDDISTRIBUCION As Integer = Me.ViewState("IDDISTRIBUCION")
        Dim xUSUARIO As String = HttpContext.Current.User.Identity.Name

        Dim cComponente As New cDistribucion

        If cComponente.actualizarEstadoDistribucion(xIDDISTRIBUCION, Session.Item("IdEstablecimiento"), 5, xUSUARIO, Session.Item("idTipoEstablecimiento")) = -1 Then
            Alert("Error al Anular la distribución.")
            'Me.MsgBox1.ShowAlert("Error al Anular la distribución.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        Else
            Alert("Se ha Anulado exitosamente la distribución.")
            'Me.MsgBox1.ShowAlert("Se ha Anulado exitosamente la distribución.", "Aviso", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If



    End Sub
End Class
