
Imports SINAB_Entidades

Partial Class Controles_Notificacion_NuevaNotificacion
    Inherits System.Web.UI.UserControl

    Public Property IdNotificacion As Integer
        Get
            Return CType(ViewState("id"), Integer)
        End Get
        Set(value As Integer)
            ViewState("id") = value
        End Set
    End Property

    Public Property NombreComercial() As String
        Get
            Return tbNombreComercial.Text
        End Get
        Set(value As String)
            tbNombreComercial.Text = value
        End Set
    End Property

    Public Property LaboraTorioFabricante() As String
        Get
            Return tbLaboratorio.Text
        End Get
        Set(value As String)
            tbLaboratorio.Text = value
        End Set
    End Property

    Public Property Lote() As String
        Get
            Return tbNoLote.Text
        End Get
        Set(value As String)
            tbNoLote.Text = value
        End Set
    End Property

    Public Property LoteSize() As Decimal
        Get
            Return CType(tbTamanioLote.Text, Decimal)
        End Get
        Set(value As Decimal)
            tbTamanioLote.Text = value.ToString()
        End Set
    End Property

    Public Property FechaFabricacion() As Date?
        Get
            If Not String.IsNullOrEmpty(tbFechaPublicacion.Text) Then
                Return CType(tbFechaPublicacion.Text, Date)
            End If
            Return Nothing
        End Get
        Set(value As Date?)
            If (Not IsNothing(value)) Or (value > DateTime.MinValue) Then
                tbFechaPublicacion.Text = String.Format("{0:00}/{1}", value.Value.Month, value.Value.Year)
                tbFechaPublicacion.Enabled = True
                chbFFnoaplica.Checked = False
                rfvFechaPublicacion.Enabled = True
            Else
                tbFechaPublicacion.Text = ""
                tbFechaPublicacion.Enabled = False
                chbFFnoaplica.Checked = True
                rfvFechaPublicacion.Enabled = False

            End If
        End Set
    End Property

    Public Property FechaVencimiento() As Date?
        Get
            If Not String.IsNullOrEmpty(tbFechaVencimiento.Text) Then
                Return CType(tbFechaVencimiento.Text, Date)
            End If
            Return Nothing
        End Get
        Set(value As Date?)
            If (Not IsNothing(value)) Or (value > DateTime.MinValue) Then
                tbFechaVencimiento.Text = String.Format("{0:00}/{1}", value.Value.Month, value.Value.Year)
                tbFechaVencimiento.Enabled = True
                chbFVnoaplica.Checked = False
                rfvFechaVencimiento.Enabled = True
            Else
                tbFechaVencimiento.Text = ""
                tbFechaVencimiento.Enabled = False
                chbFVnoaplica.Checked = True
                rfvFechaVencimiento.Enabled = False
            End If

        End Set
    End Property

    Public Property Cantidad() As Decimal
        Get
            Return CType(tbCantidadEntregar.Text, Decimal)
        End Get
        Set(value As Decimal)
            tbCantidadEntregar.Text = value.ToString()
        End Set
    End Property

    Public Property FechaNotificacion() As DateTime?
        Get
            Return CType(tbFecha.Text, Date)
        End Get
        Set(value As DateTime?)
            If IsNothing(value) Then
                tbFecha.Text = ""
            Else
                tbFecha.Text = value.Value.ToShortDateString()
            End If

        End Set
    End Property

    Protected Sub chbFFnoaplica_CheckedChanged(sender As Object, e As EventArgs) Handles chbFFnoaplica.CheckedChanged
        If chbFFnoaplica.Checked Then
            tbFechaPublicacion.Text = ""
            tbFechaPublicacion.Enabled = False
            rfvFechaPublicacion.Enabled = False
        Else
            rfvFechaPublicacion.Enabled = True
            tbFechaPublicacion.Enabled = True
        End If

    End Sub

    Protected Sub chbFVnoaplica_CheckedChanged(sender As Object, e As EventArgs) Handles chbFVnoaplica.CheckedChanged
        If chbFVnoaplica.Checked Then
            tbFechaVencimiento.Text = ""
            tbFechaVencimiento.Enabled = False
            rfvFechaVencimiento.Enabled = False
        Else
            rfvFechaVencimiento.Enabled = True
            tbFechaVencimiento.Enabled = True
        End If
    End Sub

    Public Sub CargarDatos(ByVal notificacion As SAB_LAB_INFORMEMUESTRAS)
        With notificacion
            IdNotificacion = .IDINFORME
            NombreComercial = .NOMBRECOMERCIAL
            LaboraTorioFabricante = .LABORATORIOFABRICANTE
            Lote = .LOTE
            LoteSize = CType(.NUMEROUNIDADES, Decimal)
            FechaFabricacion = .FECHAFABRICACION
            FechaVencimiento = .FECHAVENCIMIENTO
            Cantidad = CType(.CANTIDADAENTREGAR, Decimal)
            FechaNotificacion = CType(.FECHANOTIFICACION, Date)
        End With
    End Sub

    Public Sub Limpiar()
        Lote = ""
        LoteSize = 0
        FechaFabricacion = Nothing
        FechaVencimiento = Nothing
        Cantidad = 0
        FechaNotificacion = Nothing
    End Sub
End Class
