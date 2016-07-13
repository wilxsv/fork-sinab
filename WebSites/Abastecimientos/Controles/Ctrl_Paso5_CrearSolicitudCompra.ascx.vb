Imports System.Linq
Imports System.Collections.Generic
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Utils.MessageBox
Partial Class Controles_Ctrl_Paso5_CrearSolicitudCompra
    Inherits System.Web.UI.UserControl

#Region "Propiedades"
    ''' <summary>
    ''' Asigna la solicitud actual (creada o no) para poder utilizarla y cargar los datos
    ''' </summary>
    ''' <value>sab_est_solicitud</value>
    ''' <returns>el valor de viewstate de tipo sab_est_solicitud</returns>
    ''' <remarks>al asignar la solicitud este mismo valor de solicitud lo asigna a administradores de contrato OJO!</remarks>
    Public Property Solicitud As SAB_EST_SOLICITUDES
        Get
            Return CType(ViewState("_solicitud"), SAB_EST_SOLICITUDES)
        End Get
        Set(value As SAB_EST_SOLICITUDES)
            ViewState("_solicitud") = value
            EntregasProductos.Solicitud = value
        End Set
    End Property

    Public Property EntregaUniforme As Boolean
        Get
            Return chkUniforme.Checked
        End Get
        Set(value As Boolean)
            chkUniforme.Checked = value
            pEntregaUniforme.Visible = value

            If value Then
                CargarEntregas()
            Else
                RaiseEvent ActualizarEstado(True, New EventArgs())
            End If
        End Set
    End Property


#End Region

#Region "Handlers"
    Public Event ActualizarEstado As EventHandler
#End Region

    ''' <summary>
    ''' Guarda la lista de entregas y las agrega a la solicitud
    ''' </summary>
    ''' <param name="e">evento de navegacion</param>
    ''' <remarks>Si el formulario no es valido interrumpe navegacion</remarks>
    Public Sub ProcesarEntregas(ByVal e As EventArgs)

        'Page.Validate("ventregas")
        'If Not Page.IsValid Then
        '    e.Cancel = True
        '    Exit Sub
        'End If

        With Solicitud
            .EntregaUniforme = EntregaUniforme
            .ENTREGAS = 0
        End With

        Try
            If EntregaUniforme Then
                Dim usr = Membresia.ObtenerUsuario()
                Solicitud = Solicitud
                Dim listaEntregas = EntregasProductos.ObtenerEntregas()
                With Solicitud
                    .ENTREGAS = EntregasProductos.Entregas
                    .PLAZOENTREGA = listaEntregas.Max(Function(en) en.DIASENTREGA)
                    .AUUSUARIOMODIFICACION = usr.NombreUsuario
                    .AUFECHAMODIFICACION = Now
                    .IDCLASESUMINISTRO = EstablecimientoHelpers.Solicitud.ObtenerClaseSuministro(Solicitud)
                    .SAB_EST_ENTREGAS.Clear() 'limpia las entregas para agregar las nuevas
                End With
                'agrega las entregas
                For Each en In listaEntregas
                    Solicitud.SAB_EST_ENTREGAS.Add(en)
                Next
            End If
            EstablecimientoHelpers.Solicitud.Modificar(Solicitud)

        Catch ex As Exception
            '  e.Cancel = True
            Alert("Error al procesar entrega: " & ex.Message)
            Exit Sub
        End Try
        'Verificamos por inconsistencias
    End Sub

    Public Sub LlenarTablaEntregas()
        EntregasProductos.LlenarTablaEntregas()
    End Sub

    Protected Sub chkUniforme_CheckedChanged(sender As Object, e As EventArgs) Handles chkUniforme.CheckedChanged
        pEntregaUniforme.Visible = chkUniforme.Checked
        Solicitud.EntregaUniforme = chkUniforme.Checked
        If chkUniforme.Checked Then
            CargarEntregas()
        End If
    End Sub

    Private Sub CargarEntregas()
        EntregasProductos.Solicitud = Solicitud
        EntregasProductos.CargarEntregas()
        If Solicitud.SAB_EST_ENTREGAS.Any() Then RaiseEvent ActualizarEstado(True, New EventArgs())
    End Sub
End Class
