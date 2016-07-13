
Imports System.Linq
Imports System.Collections.Generic
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Tipos
Imports System.Transactions
Imports SINAB_Utils

Partial Class ESTABLECIMIENTOS_AsignarCifradosSolicitud
    Inherits System.Web.UI.Page


    Public Property Solicitud() As SAB_EST_SOLICITUDES
        Get
            Return CType(ViewState("solicitud"), SAB_EST_SOLICITUDES)
        End Get
        Set(ByVal value As SAB_EST_SOLICITUDES)
            ViewState("solicitud") = value
        End Set
    End Property

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim usr = Membresia.ObtenerUsuario()
            Master.ControlMenu.Visible = False

            If Request.QueryString("id") IsNot Nothing Then
                Solicitud = Solicitudes.Obtener(usr.ESTABLECIMIENTO.IDESTABLECIMIENTO, CType(Request.QueryString("id"), Long), usr.NombreUsuario)
                Label2.Text = Solicitud.CORRELATIVO + "-" + CType(Solicitud.CorrelativoGeneral, String)

                ProductosDistribucion.Solicitud = Solicitud
                CargarDistribucion()
            End If
        End If
    End Sub

    'Protected Sub Distribucion(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductosDistribucion.VerDistribucionProducto
    '    CargarDatosDistribucionPorProducto(CType(sender, ProductosSolicitudCorrelativo))
    'End Sub


    'Private Sub CargarDatosDistribucionPorProducto(ByVal productoseleccionado As ProductosSolicitudCorrelativo)





    'End Sub


    Private Sub CargarDistribucion()
        Try
            Dim recs = ProductoSolicitud.ObtenerTodos(CType(Solicitud.IDSOLICITUD, Integer), Solicitud.IDESTABLECIMIENTO)
            If recs.Any() Then
                ProductosDistribucion.CargarDatos(recs)
            End If
        Catch ex As Exception
            If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
                Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompra.aspx?id=" & Request.QueryString("id"), True)
            End If
        End Try
    End Sub

    'Public Sub GuardarDistribucion()
    '    'CountAgregados = 0
    '    Dim detalle As SAB_EST_DETALLESOLICITUDES = DistribucionPorProducto.ObtenerDetalle()
    '    Dim infoDistribucion As New List(Of SINAB_Entidades.Tipos.ProductosSolicitudCorrelativo)
    '    Dim infoEntregas As New List(Of SAB_EST_ENTREGAS)
    '    Dim entrega = DistribucionPorProducto.NumeroEntregas

    '    Try

    '        Try
    '            infoDistribucion = DistribucionPorProducto.Distribuciones
    '            If Solicitud.EntregaUniforme Then
    '                infoEntregas = Entregas.ObtenerEntregas(Solicitud, CType(entrega, Integer))
    '            Else
    '                infoEntregas = DistribucionPorProducto.ObtenerEntregasProcesadas()
    '            End If

    '        Catch ex As Exception
    '            Throw New Exception("No existe información de distribución para este producto -" & ex.Message)
    '        End Try


    '        Using ts As New TransactionScope
    '            Try
    '                Using db As New SinabEntities
    '                    'si ya existe la distribucion hay que borrar toda la informacion para incluir la nueva
    '                    If AlmacenesEntregaSolicitud.ExisteDistribucion(db, detalle) Or DetalleSolicitudes.ExisteDetalle(db, Solicitud, detalle) Then
    '                        ' EstablecimientoHelpers.Solicitud.EliminarDetalleSolicitud(db, Solicitud, CType(detalle.IDPRODUCTO, Integer), detalle.ESPECIFICACIONTECNICA)

    '                        DetalleSolicitudes.Borrar(db, Solicitud, CType(detalle.RENGLON, Integer), CType(detalle.IDPRODUCTO, Long), detalle.ESPECIFICACIONTECNICA)
    '                        db.SaveChanges()

    '                    End If
    '                End Using
    '                EstablecimientoHelpers.Solicitud.AgregarDetalleSolicitud(Solicitud, detalle, infoEntregas, infoDistribucion)

    '                ts.Complete()
    '            Catch ex As Exception
    '                Throw New Exception(ex.Message)
    '            End Try
    '        End Using


    '    Catch ex As Exception
    '        MessageBox.Alert("Error en la distribución: " & ex.Message)
    '    End Try
    'End Sub

   

    Protected Sub lbReporteCifrados_Click(sender As Object, e As EventArgs) Handles lbReporteCifrados.Click
        Utils.MostrarVentana(CType("~/Reportes/frmReporteAbastecimientoCifrado.aspx?id=" & Solicitud.IDSOLICITUD & "&ide=" & Solicitud.IDESTABLECIMIENTO, String))
    End Sub
End Class
