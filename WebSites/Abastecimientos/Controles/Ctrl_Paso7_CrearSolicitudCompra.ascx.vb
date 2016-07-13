
Imports System.Collections.Generic
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Utils
Imports SINAB_Entidades.Tipos
Imports System.Transactions

Partial Class Controles_Ctrl_Paso7_CrearSolicitudCompra
    Inherits System.Web.UI.UserControl

    Public Property Solicitud() As SAB_EST_SOLICITUDES
        Get
            Return CType(ViewState("_solicitud"), SAB_EST_SOLICITUDES)
        End Get
        Set(ByVal value As SAB_EST_SOLICITUDES)
            ViewState("_solicitud") = value
        End Set
    End Property 

    Public Property Producto() As ProductosSolicitudCorrelativo
        Get
            Return CType(ViewState("_producto"), ProductosSolicitudCorrelativo)
        End Get
        Set(value As ProductosSolicitudCorrelativo)
            ViewState("_producto") = value
        End Set
    End Property

    Public Sub CargarDatos()
        Try
            Dim recs = AlmacenesEntregaSolicitud.ObtenerProductosDistribucion(Solicitud.IDSOLICITUD, Solicitud.IDESTABLECIMIENTO, Producto.Renglon, CType(Producto.IdProducto, Integer))

            'Using db = New SinabEntities()
            '    For Each dist As ProductosSolicitudCorrelativo In recs
            '        dist.Cifrados = CifradoProductoSolicitud.ObtenerTodos(db, dist.IdSolicitud, dist.IdEstablecimiento, dist.IdProducto, dist.Renglon, dist.IdFuenteFinanciamiento, dist.IdAlmacen)

            '    Next
            'End Using

            With EntregasPorProducto
                .Solicitud = Solicitud
                .ProductoSeleccionado = Producto
                .Distribuciones = recs

                .CargarDatos()
            End With

        Catch ex As Exception
            Throw New Exception("Error en Solicitud, No se encontró la solicitud : " & ex.Message)
        End Try
    End Sub
    Public Sub GuardarDistribucion()
        'CountAgregados = 0
        Dim detalle As SAB_EST_DETALLESOLICITUDES = EntregasPorProducto.ObtenerDetalle()
        Dim infoDistribucion As New List(Of ProductosSolicitudCorrelativo)
        Dim infoEntregas As New List(Of SAB_EST_ENTREGAS)
        Dim entrega = EntregasPorProducto.NumeroEntregas

        Try
            Try
                infoDistribucion = EntregasPorProducto.Distribuciones
                If Solicitud.EntregaUniforme Then
                    Dim se = Entregas.TieneEntrega(Solicitud, CType(entrega, Integer))
                    If Not se Then
                        infoEntregas = Entregas.GenerarEntregas(Solicitud, CType(entrega, Integer))
                        Entregas.ActualizarEntregas(infoEntregas, Solicitud)
                    Else
                        infoEntregas = Entregas.ObtenerEntregas(Solicitud, CType(entrega, Integer))
                    End If
                Else
                    infoEntregas = EntregasPorProducto.ObtenerEntregasProcesadas()
                    Entregas.ActualizarEntregas(infoEntregas, Solicitud)
                End If

            Catch ex As Exception
                Throw New Exception("No existe información de distribución para este producto -" & ex.Message)
            End Try

            Using ts As New TransactionScope
                Try
                    Using db As New SinabEntities
                        'si ya existe la distribucion hay que borrar toda la informacion para incluir la nueva
                        If AlmacenesEntregaSolicitud.ExisteDistribucion(db, detalle) Or DetalleSolicitudes.ExisteDetalle(db, Solicitud, detalle) Then


                          
                            DetalleSolicitudes.Borrar(db, Solicitud, CType(detalle.RENGLON, Integer), CType(detalle.IDPRODUCTO, Long), detalle.ESPECIFICACIONTECNICA)

                            db.SaveChanges()

                        End If

                        EstablecimientoHelpers.Solicitud.AgregarDetalleSolicitud(db, Solicitud, detalle, infoEntregas, infoDistribucion)
                    End Using
                    ts.Complete()
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Using


        Catch ex As Exception
            MessageBox.Alert("Error en la distribución: " & ex.Message)
        End Try
    End Sub
End Class
