
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.LabHelpres

Partial Class Controles_ctrlLabRechazo
    Inherits System.Web.UI.UserControl

    Public Event EstadoActualizado As EventHandler

    Public Property IdInforme() As Integer
        Get
            Return CType(ViewState("idi"), Integer)
        End Get
        Set(value As Integer)
            ViewState("idi") = value
        End Set
    End Property

    Public Property IdEstablecimiento() As Integer
        Get
            Return CType(ViewState("ide"), Integer)
        End Get
        Set(value As Integer)
            ViewState("ide") = value
        End Set
    End Property

    Public Property Aestado() As Integer
        Get
            Return CType(ViewState("es"), Integer)
        End Get
        Set(value As Integer)
            ViewState("es") = value
        End Set
    End Property

    Public Sub CargarDatos()
        lblerror.Text =""
        Dim im = Notificaciones.Obtener(IdInforme, IdEstablecimiento)
    
        tbObservacion.Text = im.OBSERVACIONASIGNACION
        mdlPopup.Show()
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            Using db As New SinabEntities()
                Dim obj = Notificaciones.Obtener(db, IdInforme, IdEstablecimiento)
                obj.IDESTADO = Aestado
                obj.OBSERVACIONASIGNACION = tbObservacion.Text
                db.SaveChanges()
            End Using
            mdlPopup.Hide()
            RaiseEvent EstadoActualizado(btnsave, New EventArgs())
        Catch ex As Exception
            lblerror.Text ="No se ha podido rechazar la notificación. Error: "+ ex.Message
            mdlPopup.Show()
        End Try
    End Sub
End Class
