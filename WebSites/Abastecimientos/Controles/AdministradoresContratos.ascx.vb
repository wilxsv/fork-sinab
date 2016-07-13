Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades
Imports SINAB_Utils.MessageBox
Imports System.Linq


Partial Class Controles_AdministradoresContratos
    Inherits System.Web.UI.UserControl

    Public Property Solicitud() As SAB_EST_SOLICITUDES
        Get
            Return CType(ViewState("solicitud"), SAB_EST_SOLICITUDES)
        End Get
        Set(value As SAB_EST_SOLICITUDES)
            ViewState("solicitud") = value
            If value IsNot Nothing Then
                ReciboRecepcion = Nothing
            End If
        End Set
    End Property

    Public Property ReciboRecepcion() As SAB_ALM_RECIBOSRECEPCION
        Get
            Return CType(ViewState("reciboRecepcion"), SAB_ALM_RECIBOSRECEPCION)
        End Get
        Set(value As SAB_ALM_RECIBOSRECEPCION)
            ViewState("reciboRecepcion") = value
            If value IsNot Nothing Then
                Solicitud = Nothing
            End If
        End Set
    End Property

    Public Sub CargarAdministradores()
        Solicitud = Solicitudes.Obtener(Solicitud.IDESTABLECIMIENTO, Solicitud.IDSOLICITUD)
        CargarAdministradoresNoSolicitud()
    End Sub

    Public Sub CargarAdministradoresNoSolicitud()
        Try
            gvAdministradoresContrato.DataSource = Solicitud.SAB_EST_ADMINISTRADORESCONTRATO.ToList()
            gvAdministradoresContrato.DataBind()
        Catch ex As Exception
            gvAdministradoresContrato.DataSource = Nothing
            gvAdministradoresContrato.DataBind()
        End Try
      
    End Sub

    Protected Sub gvAdministradoresContrato_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvAdministradoresContrato.RowDeleting
        Dim idAdministrador = CType(gvAdministradoresContrato.DataKeys(e.RowIndex).Values(0), Integer)
        Dim idSolicitud = CType(gvAdministradoresContrato.DataKeys(e.RowIndex).Values(1), Integer)
        Dim idEstablecimiento = CType(gvAdministradoresContrato.DataKeys(e.RowIndex).Values(2), Integer)

        Try
            AdministradoresContrato.Eliminar(idAdministrador, idSolicitud, idEstablecimiento)
            CargarAdministradores()
        Catch ex As Exception
            Alert("Error al intentar eliminar Administrador : " & ex.Message)
        End Try
    End Sub

    Protected Sub lnkAgregar_Click(sender As Object, e As EventArgs) Handles lnkAgregar.Click
        Try
            Dim admin As New SAB_EST_ADMINISTRADORESCONTRATO
            With admin
                .Administrador = tbNombreAdmin.Text
                .Cargo = tbCargoAdmin.Text
                .Email = tbEmailAdmin.Text
                .Telefono = tbTelefonoAdmin.Text
                If Solicitud IsNot Nothing Then
                    .IdSolicitud = Solicitud.IDSOLICITUD
                    .IdEstablecimiento = Solicitud.IDESTABLECIMIENTO
                End If
                If ReciboRecepcion IsNot Nothing Then
                    .IdEstablecimiento = ReciboRecepcion.IDESTABLECIMIENTO
                    .IdAlmacen = ReciboRecepcion.IDALMACEN
                    .Anio = ReciboRecepcion.ANIO
                End If
            End With

            AdministradoresContrato.Agregar(admin)

            tbNombreAdmin.Text = String.Empty
            tbCargoAdmin.Text = String.Empty
            tbEmailAdmin.Text = String.Empty
            tbTelefonoAdmin.Text = String.Empty

            CargarAdministradores()
        Catch ex As Exception
            Alert("Error al intentar agregar Administrador: " & ex.Message)
        End Try

    End Sub
End Class
