Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades

Imports System.Linq
Imports System.Collections.Generic
Imports SINAB_Entidades.Tipos
Partial Class Controles_EntregasProductos
    Inherits System.Web.UI.UserControl
    Private _solicitud As SAB_EST_SOLICITUDES

    Public Property Solicitud() As SAB_EST_SOLICITUDES
        Get
            Return CType(ViewState("solicitud"), SAB_EST_SOLICITUDES)
        End Get
        Set(value As SAB_EST_SOLICITUDES)
            ViewState("solicitud") = value
        End Set
    End Property

    Public Property Entregas() As Int32
        Get
            Return CType(ViewState("entregas"), Int32)
        End Get
        Set(value As Int32)
            ViewState("entregas") = value
        End Set
    End Property

    Public Property ProductoSeleccionado() As BaseProductos
        Private Get
            Return CType(ViewState("seleccionado"), BaseProductos)
        End Get
        Set(value As BaseProductos)
            ViewState("seleccionado") = value
        End Set
    End Property

    ''' <summary>
    ''' Llena el formulario con las entregas de la solicitud
    ''' </summary>
    ''' <remarks>si la solicitud no tiene entregas entonces muesta una linea vacia</remarks>
    Public Sub CargarEntregas()
        If Solicitud.EntregaUniforme Then
            RecuperarEntregas()
        Else
            Dim numeroEntrega As Int32 = Convert.ToInt32(ProductoSeleccionado.NumeroEntrega)
            If Solicitud.SAB_EST_ENTREGAS.Any(Function(en) en.IDENTREGA = numeroEntrega) Then
                Entregas = numeroEntrega
            Else : Entregas = 0
            End If
        End If

        GenerarListaEntregas()

        If Entregas = 0 Then Entregas = 1

        cboEntregasDef.SelectedValue = Entregas.ToString()

        LlenarTablaEntregas()
    End Sub

    Public Sub LlenarTablaEntregas()
        Dim numeroEntrega As Int32
        Dim entregs As New List(Of SAB_EST_ENTREGAS)
        Dim procesar = False

        For Each tr In tblEntregas.Rows
            tr.Visible = False
        Next
        
        If Solicitud.EntregaUniforme Then
            If Entregas = 0 Then RecuperarEntregas()
            If Solicitud.SAB_EST_ENTREGAS.Any() Then
                entregs = Solicitud.SAB_EST_ENTREGAS.Where(Function(en) en.IDENTREGA = Entregas).OrderBy(Function(s) s.DIASENTREGA).ToList()
                procesar = True
            End If
        Else
            If Not IsNothing(ProductoSeleccionado) Then numeroEntrega = Convert.ToInt32(ProductoSeleccionado.NumeroEntrega)

            If Solicitud.SAB_EST_ENTREGAS.Any() And numeroEntrega > 0 Then
                entregs = Solicitud.SAB_EST_ENTREGAS.Where(Function(ent) ent.IDENTREGA = numeroEntrega).OrderBy(Function(s) s.DIASENTREGA).ToList()
                procesar = True
            End If
        End If

        If procesar Then
            ColocarEntrega(entregs)
        Else 'Agrega fila vacia
            AgregarFilaEntregaVacia(1)
        End If
    End Sub

    Private Sub RecuperarEntregas()
        If Solicitud.SAB_EST_ENTREGAS.Any() Then
            Entregas = Solicitud.SAB_EST_ENTREGAS.Max(Function(en) en.IDENTREGA)
        Else
            Entregas = 0
        End If
    End Sub

    Private Sub ColocarEntrega(ByVal entregs As List(Of SAB_EST_ENTREGAS))
        'encabezado de tabla
        tblEntregas.Rows(0).Visible = True

        Dim index = 1
        For Each en As SAB_EST_ENTREGAS In entregs
            Dim fila = tblEntregas.Rows(index)
            fila.Visible = True

            Dim ciento As TextBox = CType(fila.FindControl("tbPercent" & index), TextBox)
            Dim dias As TextBox = CType(fila.FindControl("tbDays" & index), TextBox)
            ciento.Text = en.PORCENTAJEENTREGA.ToString()
            dias.Text = en.DIASENTREGA.ToString()

            'aumenta contador
            index += 1
        Next
    End Sub

    Public Function ObtenerEntregas() As List(Of SAB_EST_ENTREGAS)
        Dim listaEntregas = New List(Of SAB_EST_ENTREGAS)

        Entregas = CType(cboEntregasDef.SelectedValue, Integer)
        If Entregas = 0 Then Entregas = 1

        Dim sumPorciento = 0

        For i As Integer = 1 To Entregas
            Dim tr As TableRow = tblEntregas.Rows(i)
            Dim ciento As TextBox = CType(tr.FindControl("tbPercent" & i), TextBox)
            Dim dias As TextBox = CType(tr.FindControl("tbDays" & i), TextBox)

            sumPorciento += CType(ciento.Text, Integer)
            Dim nuevaEntrega = New SAB_EST_ENTREGAS
            With nuevaEntrega

                .IDSOLICITUD = Solicitud.IDSOLICITUD
                .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
                .IDENTREGA = CType(cboEntregasDef.SelectedValue, Short)
                .NUMEROENTREGA = CType(i, Short)
                .PORCENTAJEENTREGA = CType(ciento.Text, Decimal)
                .DIASENTREGA = CType(dias.Text, Short)
                .AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                .AUFECHACREACION = Now
            End With
            listaEntregas.Add(nuevaEntrega)
        Next

        If sumPorciento <> 100 Then
            listaEntregas.Clear()
            Throw New Exception("Inconsistencia de datos, verifique todos los valores. Porcentajes deben sumar 100%")
        End If

        Return listaEntregas
        'Catch ex As Exception
        '    listaEntregas.Clear()
        '    Alert("Error al procesar entrega: " & ex.Message)
        '    Exit Sub
        'End Try
    End Function

    ''' <summary>
    ''' Maneja el cambio del total de entregas. Verifica si existen productos antes para ese tipo de entregas
    ''' </summary>
    ''' <param name="sender">desencadenador</param>
    ''' <param name="e">evento</param>
    ''' <remarks>Dependiendo del valor seleccionado en la cantidad de categorias asi genera los renglones para nuevas categorias</remarks>
    Protected Sub cboEntregasDef_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntregasDef.SelectedIndexChanged

        Entregas = cboEntregasDef.SelectedValue
        'Dim entregasTotales = CType(Establecimiento.Solicitud.ObtenerTotalEntregas(Solicitud), Integer)
        'If Solicitud.EntregaUniforme And Entregas < entregasTotales Then
        '    '  Throw New Exception("Existen productos con más entregas a las especificadas. ")
        'End If
        Dim ents = Solicitud.SAB_EST_ENTREGAS.Where(Function(ent) ent.IDENTREGA = Entregas).ToList()

        For Each tr As TableRow In tblEntregas.Rows
            tr.Visible = False
        Next

        If ents.Any() And Entregas > 0 And Not Solicitud.EntregaUniforme Then
            Dim entregs = ents.OrderBy(Function(s) s.DIASENTREGA).ToList()

           
            ColocarEntrega(entregs)
        Else
            AgregarFilaEntregaVacia(Entregas)
        End If
    End Sub

#Region "PROPIEDADES PRIVADAS"
  

    ''' <summary>
    ''' Muestra u oculta las filas de la tabla dependiendo la cantidad de entregas
    ''' </summary>
    ''' <param name="count">cantidad a mostrar</param>
    Private Sub AgregarFilaEntregaVacia(ByVal count As Integer)
        For Each tr As TableRow In tblEntregas.Rows
            tr.Visible = False
        Next

        For index As Integer = 0 To count
            Dim fila = tblEntregas.Rows(index)
            Dim ciento As TextBox = CType(fila.FindControl("tbPercent" & (index + 1)), TextBox)
            Dim dias As TextBox = CType(fila.FindControl("tbDays" & (index + 1)), TextBox)
            ciento.Text = ""
            dias.Text = ""
            fila.Visible = True
        Next
    End Sub

    ''' <summary>
    ''' llena el combo de entregas (1 - 12 entregas)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GenerarListaEntregas()
        With cboEntregasDef
            .Items.Clear()
            For val As Integer = 1 To 12
                If val > 1 Then
                    .Items.Add(New ListItem((val & " Entregas"), val.ToString()))
                Else
                    .Items.Add(New ListItem((val & " Entrega"), val.ToString()))
                End If
            Next
        End With
    End Sub



#End Region
End Class
