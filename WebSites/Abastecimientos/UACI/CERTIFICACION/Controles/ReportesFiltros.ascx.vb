Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.CertificacionHelpers

Partial Class UACI_CERTIFICACION_Controles_ReportesFiltros
    Inherits System.Web.UI.UserControl

    Public ReadOnly Property ExisteProceso() As Boolean
        Get
            Return ddprocesos.Visible
        End Get
    End Property

    Public ReadOnly Property IdProceso() As Decimal
        Get
            Return CType(ddprocesos.SelectedValue, Decimal)
        End Get
    End Property

    Public ReadOnly Property IdTipoProducto() As Decimal
        Get
            Return CType(ddSuministros.SelectedValue, Decimal)
        End Get
    End Property

    Public ReadOnly Property Nit() As String
        Get
            Return tbNit.Text
        End Get
    End Property

    Public ReadOnly Property Producto() As String
        Get
            Return tbCodigo.Text
        End Get
    End Property

    Public ReadOnly Property Estado() As Integer
        Get
            Return CType(rblEstado.SelectedValue, Integer)
        End Get
    End Property

    Public ReadOnly Property PorProducto() As Boolean
        Get
            Return CType(CType(rblProducto.SelectedValue, Byte), Boolean)
        End Get
    End Property

    Public ReadOnly Property FechaLimite() As DateTime
        Get
            Return CDate(tbFecha.Text)
        End Get
    End Property

    Public Property MostarEstado() As Boolean
        Get
            Return pnlEstado.Visible
        End Get
        Set(value As Boolean)
            pnlEstado.Visible = value
        End Set
    End Property

    Public Property MostrarProducto() As Boolean
        Get
            Return pnlProducto.Visible
        End Get
        Set(value As Boolean)
            pnlProducto.Visible = value
        End Set
    End Property

    Public Property MostarFechaLimite() As Boolean
        Get
            Return pnlFechaLimite.Visible
        End Get
        Set(value As Boolean)
            pnlFechaLimite.Visible = value
        End Set
    End Property

    Public Property FijarProveedor() As Boolean
        Get
            Return CType(CType(rblProducto.SelectedValue, Byte), Boolean)
        End Get
        Set(value As Boolean)
            If value Then
                rblProveedor.SelectedValue = 1
                rblProveedor.Enabled = False
                PnlNit.Visible = True
            Else
                rblProveedor.Enabled = True
            End If

        End Set
    End Property




    Public Sub CargarDatos()
        CatalogoHelpers.Suministros.CargarALista(ddSuministros, True)

        CargarListaProcesos()
    End Sub

    Protected Sub ddSuministros_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CargarListaProcesos()
    End Sub

    Protected Sub rblProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblProveedor.SelectedIndexChanged
        Me.tbNit.Text = ""
        If Me.rblProveedor.SelectedValue = 1 Then
            PnlNit.Visible = True
        Else
            PnlNit.Visible = False
        End If
    End Sub

    Protected Sub rblProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.tbCodigo.Text = ""
        If Me.rblProducto.SelectedValue = 1 Then
            pnlCodigo.Visible = True
        Else
            pnlCodigo.Visible = False
        End If
    End Sub

    Private Sub CargarListaProcesos()

        Procesos.CargarALista(ddprocesos, CType(ddSuministros.SelectedValue, Integer))
        If Me.ddprocesos.Items.Count = 0 Then
            ddprocesos.Visible = False
        Else
            ddprocesos.Visible = True
        End If
    End Sub
End Class
