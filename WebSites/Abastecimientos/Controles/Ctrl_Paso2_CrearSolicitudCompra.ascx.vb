
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Utils.MessageBox
Imports System.Linq


Partial Class Controles_Ctrl_Paso2_CrearSolicitudCompra
    Inherits System.Web.UI.UserControl

#Region "Propiedades"
    Public Property Solicitud As SAB_EST_SOLICITUDES
        Get
            Return CType(ViewState("_solicitud"), SAB_EST_SOLICITUDES)
        End Get
        Set(value As SAB_EST_SOLICITUDES)
            ViewState("_solicitud") = value
        End Set
    End Property
#End Region

#Region "Handlers"
    Public Event ActualizarEstado As EventHandler
#End Region

#Region "Eventos"
    Protected Sub ddlMasterFuentes_SelectedIndexChanged(sender As Object, e As EventArgs)
        FuentesFinanciamiento.CargarPorGrupoALista(ddlFUENTEFINANCIAMIENTOS1, CType(ddlMasterFuentes.SelectedValue, Integer))
        If ddlFUENTEFINANCIAMIENTOS1.Items.Count <= 0 Then
            ddlFUENTEFINANCIAMIENTOS1.Enabled = False
            btnAgregarFuente.Enabled = False
        Else
            ddlFUENTEFINANCIAMIENTOS1.Enabled = True
            btnAgregarFuente.Enabled = True
        End If
    End Sub


    Protected Sub btnAgregarFuente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarFuente.Click
        Dim f As New SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES
        Try
            f.IDESTABLECIMIENTO = Solicitud.IDESTABLECIMIENTO
            f.IDSOLICITUD = Solicitud.IDSOLICITUD
            f.IDFUENTEFINANCIAMIENTO = CType(ddlFUENTEFINANCIAMIENTOS1.SelectedValue, Integer)
            f.MONTOPARTICIPACION = 0
            f.PORCENTAJEPARTICIPACION = 0
            ' f.AUUSUARIOCREACION = User.Identity.Name
            f.AUFECHACREACION = Now
            f.ESTASINCRONIZADA = 0
            'devuelve la solicitud con las fuentes actualizadas
            Solicitud = SolicitudesFuentesFinanciamiento.Agregar(f)
            
        Catch ex As Exception
            btnAgregarFuente.Enabled = True
            ddlFUENTEFINANCIAMIENTOS1.Enabled = True
            Alert("Error! verifique que la fuente de financiamiento no ha sido agregada con anterioridad")
        End Try
        CargarFuentesFinanciamiento()
    End Sub

    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Dim idFuente As Integer = CType(GridView2.DataKeys(e.RowIndex).Values(0), Integer)
        Try
            EstablecimientoHelpers.Solicitud.EliminarFuenteFinanciamiento(idFuente, Solicitud)
        Catch ex As Exception
            Alert("Se produjo un error al eliminar el lugar de entrega.")
            Exit Sub
        End Try
        CargarFuentesFinanciamiento()
    End Sub
#End Region

#Region "Métodos Públicos"
    Public Sub CargarDatos()
        FuentesFinanciamiento.CargarPorMaestroALista(ddlMasterFuentes)
        FuentesFinanciamiento.CargarPorGrupoALista(ddlFUENTEFINANCIAMIENTOS1, 1)
        CargarFuentesFinanciamiento()
    End Sub
    
#End Region

    ''' <summary>
    ''' Carga la grid de Fuentes de Financiamiento
    ''' </summary>
    Private Sub CargarFuentesFinanciamiento()
        Dim recs = EstablecimientoHelpers.Solicitud.ObtenerFuentesFinanciamiento(Solicitud)
        Dim habilitar = False
        If recs.Any() Then
            With GridView2
                .DataSource = recs
                .DataBind()
            End With
            'btnAgregarFuente.Enabled = False
            'ddlFUENTEFINANCIAMIENTOS1.Enabled = False
            habilitar = True
        Else
            With GridView2
                .DataSource = Nothing
                .DataBind()
            End With
            btnAgregarFuente.Enabled = True
            ddlFUENTEFINANCIAMIENTOS1.Enabled = True
            habilitar = False
        End If

        RaiseEvent ActualizarEstado(habilitar, New EventArgs())

    End Sub

    Protected Sub lnkUpdateSources_Click(sender As Object, e As EventArgs)
        CargarFuentesFinanciamiento()
    End Sub
End Class
