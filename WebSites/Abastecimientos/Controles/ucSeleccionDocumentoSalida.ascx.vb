
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Linq
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.EnumHelpers


Imports SINAB_Entidades.Tipos
Imports SINAB_Utils

Partial Class ucSeleccionDocumentoSalida
    Inherits System.Web.UI.UserControl

    Private _IDALMACEN As Integer

#Region "Propiedades"

    Public Property IDALMACEN() As Integer
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Integer)
            _IDALMACEN = value
            If Not ViewState("IDALMACEN") Is Nothing Then ViewState.Remove("IDALMACEN")
            ViewState.Add("IDALMACEN", value)
        End Set
    End Property


#End Region


    protected sub RecargarGrid(ByVal sender As Object, ByVal e As EventArgs) Handles ctrVlRechazo.ValeAnulado
MessageBox.Alert("El Vale y su movimiento han sido anulados", "Anulado")        
CargarDatos()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim usuario = Membresia.ObtenerUsuario()
            IDALMACEN = usuario.Almacen.IDALMACEN
            'ddlALMACENESESTABLECIMIENTOS1.RecuperarListaSubAlmacenes(usuario.ESTABLECIMIENTO.IDESTABLECIMIENTO)
            'Dim almacenes = New Almacenes()
            With ddlALMACENESESTABLECIMIENTOS1
                .DataSource = almacenes.ObtenerAlmacenesEstablecimientos(usuario.ESTABLECIMIENTO.IDESTABLECIMIENTO)
                .DataTextField = "NOMBRE"
                .DataValueField = "IDALMACEN"
                .DataBind()
            End With


            If ddlALMACENESESTABLECIMIENTOS1.Items.Count > 1 Then
                plAlmacen.Visible = True
                ddlALMACENESESTABLECIMIENTOS1.SelectedValue = usuario.Almacen.IDALMACEN.ToString()
            Else
                plAlmacen.Visible = False
            End If

            CargarDatos()

        Else
            If Not ViewState("IDALMACEN") Is Nothing Then _IDALMACEN = ViewState("IDALMACEN")
        End If

    End Sub

    Protected Sub ddlAlmancenes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlALMACENESESTABLECIMIENTOS1.SelectedIndexChanged

        IDALMACEN = CType(ddlALMACENESESTABLECIMIENTOS1.SelectedValue, Integer)

        CargarDatos()

    End Sub

    Public Sub CargarDatos()

        'Dim cVS As New cVALESSALIDA
        'Dim documentos As New Documentos


        ' doc1.DataSource = cVS.ObtenerListaValesSalida(IDALMACEN, , , , , , eESTADOSMOVIMIENTOS.Grabado)

        Try
            gvDocumentos.DataSource = documentos.Obtener(IDALMACEN, EstadosMovimiento.Grabado, EstadosMovimiento.EnProceso)
            gvDocumentos.DataBind()
        Catch ex As Exception
            gvDocumentos.PageIndex = 0
            gvDocumentos.DataBind()
        End Try

    End Sub

    Public Sub Limpiar()
        gvDocumentos.DataSource = Nothing
        gvDocumentos.DataBind()
        gvDocumentos.SelectedIndex = -1
    End Sub

    Protected Sub gvDocumentos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDocumentos.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim doc = CType(e.Row.DataItem, Documento)
            Dim cerrarBoton As Button = CType(e.Row.FindControl("btnCerrar"), Button)
            Dim linkadoc As HyperLink = CType(e.Row.FindControl("linktodocument"), HyperLink)

            '<asp:HyperLink runat="server" ID="linktodocument"/>
            '      </ItemTemplate>
            '  </asp:TemplateField>
            '<asp:HyperLinkField HeaderText="No. Documento" DataNavigateUrlFormatString="~/ALMACEN/FrmDetMantDespacharProductos.aspx?IdMov={0}&IdAlm={1}"
            '  DataNavigateUrlFields="IdMovimiento,IdAlmacen" DataTextField="NumeroVale" />
            linkadoc.Text = doc.NumeroVale

            If doc.DeRequisicion Then
                linkadoc.NavigateUrl = String.Format("~/ALMACEN/FrmDetMantDespacharPreOrden.aspx?cr=" + doc.CodigoRequisicion.ToString())
            Else
                If Request.QueryString("d") = 1 Then
                    linkadoc.NavigateUrl = String.Format("~/ALMACEN/FrmDetMantDespacharProductos.aspx?IdMov={0}&IdAlm={1}", doc.IdMovimiento, doc.IdAlmacen)
                ElseIf Request.QueryString("d") = 2 Then
                    cerrarBoton.Visible = False
                    Dim cx As New cDistribucion
                    Dim iddistribucion As Integer = cx.obteneriddistribucion(doc.IdAlmacen, doc.IdMovimiento)
                    linkadoc.NavigateUrl = String.Format("~/ALMACEN/FrmDetMantDespacharProductosDistribucion.aspx?IdMov={0}&IdAlm={1}&IdDis={2}", doc.IdMovimiento, doc.IdAlmacen, iddistribucion)
                Else
                    linkadoc.NavigateUrl = String.Format("~/ALMACEN/FrmDetMantDespacharProductos.aspx?IdMov={0}&IdAlm={1}", doc.IdMovimiento, doc.IdAlmacen)
                End If


            End If


            If doc.IdEstado = EstadosMovimiento.EnProceso Then
                cerrarBoton.Visible = False
            ElseIf doc.EstablecimientoDestino = "Farmacia" And doc.DeRequisicion Then
                cerrarBoton.Visible = False
            End If

            Dim b As Button = CType(e.Row.FindControl("btnImprimir"), Button)
            Dim cad = String.Format("/Reportes/FrmRptValeSalida.aspx?IdEMov={0}&IdMov={1}", gvDocumentos.DataKeys(e.Row.RowIndex).Item("IdEstablecimiento"), gvDocumentos.DataKeys(e.Row.RowIndex).Item("IdMovimiento"))

            'Dim s As New StringBuilder

            's.Append("window.open('")
            's.Append(Request.ApplicationPath)
            's.Append("/Reportes/FrmRptValeSalida.aspx?")
            's.Append("IdEMov=")
            's.Append(gvDocumentos.DataKeys(e.Row.RowIndex).Item("IdEstablecimiento").ToString())
            ' s.Append(doc.IdEstablecimiento.ToString())
            's.Append("&IdMov=")
            's.Append(gvDocumentos.DataKeys(e.Row.RowIndex).Item("IdMovimiento").ToString())
            's.Append(doc.IdMovimiento.ToString())
            's.Append("', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return false;")

            b.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
            's.ToString
        End If

    End Sub

    Protected Sub gvDocumentos_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvDocumentos.RowUpdating
        Dim cDM As New cDETALLEMOVIMIENTOS
        Dim eM As New ABASTECIMIENTOS.ENTIDADES.MOVIMIENTOS
        eM.IDESTABLECIMIENTO = CType(gvDocumentos.DataKeys(e.RowIndex).Values.Item("IdEstablecimiento"), Integer)
        eM.IDMOVIMIENTO = CType(gvDocumentos.DataKeys(e.RowIndex).Values.Item("IdMovimiento"), Long)
        eM.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        eM.AUFECHAMODIFICACION = Now
        'SCMS - Verificar valor de "esFarmacia"
        Dim esFarmacia As Boolean '= CType(IIf(gvDocumentos.DataKeys(e.RowIndex).Values.Item("EstablecimientoDestino").ToString.ToLower = "farmacia", True, False), Boolean)
        esFarmacia = False
        cDM.CerrarDespacho2(eM, esFarmacia)
        CargarDatos()
    End Sub



    Protected Sub gvDocumentos_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvDocumentos.RowDeleting
        
        Dim movimiento = Movimientos.Obtener(CType(gvDocumentos.DataKeys(e.RowIndex).Values.Item("IdMovimiento"), Integer), TiposTransaccion.Salida, CType(gvDocumentos.DataKeys(e.RowIndex).Values.Item("IdEstablecimiento"), Integer))
        'configuracion para actualizar los lotes mediante operacionLote
        Dim operacionlote As New OperacionesLotes
        With operacionlote
            .CantidadDisponible = 1
            .CantidadReservada = 2
        End With

        With ctrVlRechazo
                    .Vale = ValesSalida.Obtener(movimiento)
                    .Movimiento = movimiento
                    .Operacion = operacionlote 'estado al que va a ser asignado (actual -1)
            .DocumentoVale = CType(gvDocumentos.DataKeys(e.RowIndex).Values.Item("numerovale"), string)
                    .CargarDatos()
                End With

        
    End Sub

   
    
End Class
