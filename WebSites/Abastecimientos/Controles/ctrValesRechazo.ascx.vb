
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers.AlmacenHelpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.LabHelpres
Imports SINAB_Entidades.Tipos
Imports SINAB_Utils

Partial Class Controles_ctrValesRechazo
    Inherits System.Web.UI.UserControl

    public Property DocumentoVale() As String
    get
            return ltInfo.Text
    End Get
    Set(value As String)
            ltInfo.Text = value
    End Set
    End Property
    Public Property Movimiento() As SAB_ALM_MOVIMIENTOS
        Get
            Return CType(ViewState("mov"), SAB_ALM_MOVIMIENTOS)
        End Get
        Set(value As SAB_ALM_MOVIMIENTOS)
            ViewState("mov") = value
        End Set
    End Property

    Public Property Vale() As SAB_ALM_VALESSALIDA
        Get
            Return CType(ViewState("val"), SAB_ALM_VALESSALIDA)
        End Get
        Set(value As SAB_ALM_VALESSALIDA)
            ViewState("val") = value
        End Set
    End Property

    Public Property Operacion() As OperacionesLotes
        Get
            Return CType(ViewState("opl"), OperacionesLotes)
        End Get
        Set(value As OperacionesLotes)
            ViewState("opl") = value
        End Set
    End Property

    Public Sub CargarDatos()
        lblerror.Text =""
      '  Dim im = Notificaciones.Obtener(IdInforme, IdEstablecimiento)
        tbObservacion.Text = Vale.OBSERVACION
        mdlPopup.Show()
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        'Elimina el detalle de detallesmovimiento y actualiza las cantidades, luego guarda en la db
        Try
            if String.IsNullOrEmpty(tbObservacion.Text) then
                Throw New Exception("La observación es obligatoria para anular un vale.")
            End If
            Vale.OBSERVACION = tbObservacion.Text
            Using db As New SinabEntities
                For Each dm In Movimiento.SAB_ALM_DETALLEMOVIMIENTOS
                    Lotes.Actualizar(db, dm, Operacion)                    
                    DetallesMovimiento.Anular(db, dm)
                Next
                Movimientos.Anular(db, Movimiento)
                ValesSalida.Anular(db, Vale)
                'guarda los resultados en la based de datos
                db.SaveChanges()

            End Using
            mdlPopup.Hide()
            RaiseEvent ValeAnulado(btnsave, New EventArgs())
           
        Catch ex As Exception
            lblerror.Text = ex.Message
            mdlPopup.Show()
        End Try
        'Try
        '    Using db As New SinabEntities()
        '        Dim obj = Notificaciones.Obtener(db, IdInforme, IdEstablecimiento)
        '        obj.IDESTADO = Aestado
        '        obj.OBSERVACIONASIGNACION = tbObservacion.Text
        '        db.SaveChanges()
        '    End Using
        '    mdlPopup.Hide()
        ' '   RaiseEvent EstadoActualizado(btnsave, New EventArgs())
        'Catch ex As Exception
        '    lblerror.Text = ex.Message
        '    mdlPopup.Show()
        'End Try
    End Sub

    Public Event ValeAnulado As EventHandler
End Class
