Imports System.Data

Partial Class Controles_ucFiltrarDatos2
    Inherits System.Web.UI.UserControl

    'Variables
    Private _dataGridMostrar As ArrayList
    Private _valorFiltro As String 'Datos que ingresa el usuario y queremos filtrar
    Private _columnaFiltro As String 'Columna a  filtrar
    Private _posicionFiltro As Integer = 0

    Public Event filtrar()

    Public WriteOnly Property dataGridMostrar() As ArrayList
        Set(ByVal value As ArrayList)
            _dataGridMostrar = value
            cargar()
        End Set
    End Property

    Public Property valorFiltro() As String
        Get
            Return _valorFiltro
        End Get
        Set(ByVal Value As String)
            _valorFiltro = Value
        End Set
    End Property

    Public Property columnaFiltro() As String
        Get
            Return _columnaFiltro
        End Get
        Set(ByVal Value As String)
            _columnaFiltro = Value
        End Set
    End Property

    Public Property posicionFiltro() As Integer
        Get
            Return _posicionFiltro
        End Get
        Set(ByVal value As Integer)
            _posicionFiltro = value
        End Set
    End Property

    Private Sub cargar()

        Dim en As IEnumerator
        Dim eColumnas As ABASTECIMIENTOS.ENTIDADES.eDatosFiltro

        en = _dataGridMostrar.GetEnumerator

        Dim i As New ListItem("Seleccione un filtro", "-")

        Me.cboFiltro.Items.Clear()
        Me.cboFiltro.Items.Add(i)

        While en.MoveNext

            eColumnas = en.Current

            'If eColumnas.esVisible And eColumnas.consultar Then
            i = New ListItem(eColumnas.encabezado, eColumnas.dataBind)
            cboFiltro.Items.Add(i)
            'End If

        End While

        cboFiltro.SelectedIndex = _posicionFiltro

    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click

        valorFiltro = Me.txtFiltro.Text

        If cboFiltro.SelectedIndex > 0 Then
            columnaFiltro = cboFiltro.SelectedValue
            posicionFiltro = cboFiltro.SelectedIndex
            Me.lblColumna.Text = Me.cboFiltro.SelectedItem.Text
            Me.lblTabla.Text = Me.txtFiltro.Text
        Else
            columnaFiltro = String.Empty
            posicionFiltro = 0
            Me.txtFiltro.Text = String.Empty
            Me.lblColumna.Text = String.Empty
            Me.lblTabla.Text = String.Empty
        End If

        RaiseEvent filtrar()

    End Sub

    Public Sub borrar()
        Me.txtFiltro.Text = ""
        Me.lblTabla.Text = ""
        Me.lblColumna.Text = ""
    End Sub

End Class
