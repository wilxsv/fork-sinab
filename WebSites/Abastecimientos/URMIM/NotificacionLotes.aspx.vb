
Imports System.ServiceModel.Channels
Imports System.IO
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.LabHelpres
Imports SharpPieces.Web.Controls
Imports SINAB_Entidades.Helpers
Imports SINAB_Utils
Imports SINAB_Utils.MessageBox
Imports SINAB_Utils.Utils


Partial Class URMIM_NotificacionLotes
    Inherits System.Web.UI.Page

   

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            cargaDatos()           
        End If
    End Sub

    Public Sub cargaDatos()
        '  Dim cIM As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        try
        Me.gvEncabezado.DataSource = UACIHelpers.ContratosAdjudicados.ObtenerTodos(EnumHelpers.EstadoNotificacion.Creada, Membresia.ObtenerUsuario().NombreUsuario) 'cIM.ObtenerNotificacionesCapturadas(1, IDPROVEEDOR)
        Me.gvEncabezado.DataBind()
            Catch ex As Exception
            MessageBox.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lnkReporte_cmd(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim indx As Integer = CType(e.CommandArgument.ToString(), Integer)
        Dim idE = gvEncabezado.DataKeys(indx).Values(0)
        Dim idPc = gvEncabezado.DataKeys(indx).Values(1)
        Dim idP = gvEncabezado.DataKeys(indx).Values(2)
        Dim idC = gvEncabezado.DataKeys(indx).Values(3)

        MostrarVentana(CType(("Reportes/frmRptNotificacionLotes.aspx?idE=" & idE & "&idP=" & idP & "&idPc=" & idPc & "&idC=" & idC), String))
    End Sub


    Protected Sub lnkEdit_cmd(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim indx As Integer = CType(e.CommandArgument.ToString(), Integer)
        Dim idE = gvEncabezado.DataKeys(indx).Values(0)
        Dim idPc = gvEncabezado.DataKeys(indx).Values(1)
        Dim idP = gvEncabezado.DataKeys(indx).Values(2)
        Dim idC = gvEncabezado.DataKeys(indx).Values(3)
        Response.Redirect(String.Format("~/URMIM/EditarNotificacionLotes.aspx?ide={0}&idpc={1}&idp={2}&idc={3}", idE, idPc, idP, idC))
    End Sub

    Protected Sub lnkClose_cmd(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim indx As Integer = CType(e.CommandArgument.ToString(), Integer)
        Dim idE As Integer = CType(gvEncabezado.DataKeys(indx).Values(0), Integer)
        Dim idPc As Integer = CType(gvEncabezado.DataKeys(indx).Values(1), Integer)
        Dim idP As Integer = CType(gvEncabezado.DataKeys(indx).Values(2), Integer)
        Dim idC As Integer = CType(gvEncabezado.DataKeys(indx).Values(3), Integer)
        Try
            Notificaciones.ActualizarTodos(idP, idPc, idE, idC, EnumHelpers.EstadoNotificacion.Asignacion)
            cargaDatos()
            MessageBox.Alert("La notificación ha sido cerrada con exito", "Cerrada")
        Catch ex As Exception
            Alert("La notificación no ha sido cerrada. Error: " + ex.Message)
        End Try

    End Sub

  

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Response.Redirect("~/URMIM/NuevaNotificacionLote.aspx")
    End Sub

    Protected Sub gvEncabezado_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvEncabezado.RowDeleting

        Dim idE = CType(Me.gvEncabezado.DataKeys(e.RowIndex).Values(0), Integer)
        Dim idPc = CType(Me.gvEncabezado.DataKeys(e.RowIndex).Values(1), Integer)
        Dim idP = CType(Me.gvEncabezado.DataKeys(e.RowIndex).Values(2), Integer)
        Dim idC = CType(Me.gvEncabezado.DataKeys(e.RowIndex).Values(3), Integer)

        Try
            Notificaciones.BorrarTodos(idP, idPc, idE, idC, 1)
            cargaDatos()

            Alert("Se ha eliminado la notificación satisfactoriamente.", "Aceptar")

        Catch ex As Exception
            Alert("Error al eliminar la notificación", "Error")
        End Try
    End Sub
End Class
