
Imports System.Linq
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades
Imports SINAB_Utils.MessageBox

Partial Class Controles_Ctrl_Paso3_CrearSolicitudCompra
    Inherits System.Web.UI.UserControl

#Region "Propiedades"
    Public Property Solicitud() As SAB_EST_SOLICITUDES
        Get
            Return CType(ViewState("solicitud"), SAB_EST_SOLICITUDES)
        End Get
        Set(value As SAB_EST_SOLICITUDES)
            ViewState("solicitud") = value

            BuscarLugarEntrega.IdEstablecimiento = value.IDESTABLECIMIENTO
            BuscarLugarEntrega.IdSolicitud = value.IDSOLICITUD
        End Set
    End Property
#End Region

#Region "Handlers"
    Public Event ActualizarEstado As EventHandler
#End Region

#Region "Eventos"
    Protected Sub lnkUpdateGrid_Click(sender As Object, e As EventArgs)
        CargarLugaresEntrega()
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim almacenEntrega As New SAB_EST_ALMACENESENTREGA
        Try
            With almacenEntrega
                .IDESTABLECIMIENTO = Solicitud.IDESTABLECIMIENTO
                .IDSOLICITUD = Solicitud.IDSOLICITUD
                .IDALMACEN = CType(BuscarLugarEntrega.IdAlmacen, Integer)
                .AUUSUARIOCREACION = Membresia.ObtenerUsuario().NombreUsuario
                .AUFECHACREACION = Now
            End With
            BuscarLugarEntrega.SearchingText = String.Empty
            AlmacenesEntrega.Agregar(almacenEntrega)

        Catch ex As Data.UpdateException
            Alert("Error! verifique que el Lugar de entrega no ha sido agregado")
        Catch ex As Exception
            Alert("Error al guardar Lugar de entrega : " & ex.Message)
        End Try
        CargarLugaresEntrega()
    End Sub

    Protected Sub gvLugarEntregas_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLugarEntregas.RowDeleting
        Dim idAlmacen As Integer = CType(gvLugarEntregas.DataKeys(e.RowIndex).Values(0), Integer)
        Try
            EstablecimientoHelpers.Solicitud.EliminarAlmacenEntrega(idAlmacen, Solicitud)
            CargarLugaresEntrega()
        Catch ex As Exception
            Alert("Se produjo un error al eliminar el lugar de entrega. error:" & ex.Message)
            Exit Sub
        End Try
    End Sub
#End Region

    Public Sub CargarLugaresEntrega()
        Dim habilitar = False

        Dim recs = EstablecimientoHelpers.Solicitud.ObtenerAlmacenesEntrega(Solicitud)
        If recs.Any() Then
            gvLugarEntregas.DataSource = recs
            gvLugarEntregas.DataBind()
            habilitar = True
        Else
            gvLugarEntregas.DataSource = Nothing
            gvLugarEntregas.DataBind()
            habilitar = False
        End If

        RaiseEvent ActualizarEstado(habilitar, New EventArgs())
    End Sub

   
End Class
