Imports System.ComponentModel.Design
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.UACIHelpers.ProcesoCompras
Imports SINAB_Utils

Partial Class Controles_ucFechasProcesoCompra
    Inherits System.Web.UI.UserControl

    Public Property IdEstablecimiento() As Integer
        Set(value As Integer)
            ViewState("ide") = value
        End Set
        Get
            Return CType(ViewState("ide"), Integer)
        End Get
    End Property

    Public Property IdProcesocompra() As Integer
        Set(value As Integer)
            ViewState("idpc") = value
        End Set
        Get
            Return CType(ViewState("idpc"), Integer)
        End Get
    End Property

    Public Sub CargarDatos(ByVal idE As Integer, ByVal idPc As Integer)
        IdEstablecimiento = idE
        IdProcesocompra = idPc

        'UACIHelpers.ProcesoCompras.Obtener(Membresia.ObtenerUsuario().Establecimiento.IDESTABLECIMIENTO, CType(Request.QueryString("idProc"), Integer))
        Dim pc = Obtener(IdEstablecimiento, IdProcesocompra)
        With pc

            AsignarFechas(lblFechaPublicacion, lblFechaPublicacion2, .FECHAPUBLICACION)

            AsignarFechas(lblFechaIniciadoProceso, lblFechaIniciadoProceso2, .FECHAINICIOPROCESOCOMPRA)

            AsignarFechas(tbFechaRecepcionOfertas, tbTiempoRecepcionOfertas, lblFechaRecepcionOfertas, .FECHAHORAINICIORECEPCION)

            AsignarFechas(tbFechaFinRecepOferta, tbTiempoFinRecepOferta, lblFechaFinRecepOferta, .FECHAHORAFINRECEPCION)

            AsignarFechas(tbInicioApertura, tbTiempoInicioApertura, lblinicioapertura, .FECHAHORAINICIOAPERTURA)

            AsignarFechas(tbfinapertura, tbTiempofinapertura, lblfinapertura, .FECHAHORAFINAPERTURA)


        End With
        mv.ActiveViewIndex = 0

    End Sub
    Private Sub AsignarFechas(ByVal tbFecha As TextBox, ByVal tbTiempo As TextBox, ByVal lbl As Label, ByVal infofecha As DateTime?)
        If Not IsNothing(infofecha) Then
            lbl.Text = infofecha.Value.ToString()
            tbFecha.Text = infofecha.Value.ToShortDateString()
            tbTiempo.Text = infofecha.Value.ToShortTimeString()
        Else
            lbl.Text = Nothing
            tbFecha.Text = Nothing
            tbTiempo.Text = Nothing
        End If
    End Sub

    Private Sub AsignarFechas(ByVal lbl1 As Label, ByVal lbl2 As Label, ByVal infofecha As DateTime?)
        If Not IsNothing(infofecha) Then
            lbl1.Text = infofecha.Value.ToString()
            lbl2.Text = infofecha.Value.ToString()
        Else
            lbl1.Text = Nothing
            lbl2.Text = Nothing
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        mv.ActiveViewIndex = 1
    End Sub

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            Dim tpl = SendMail.ReadDateTimeAdviseTemplate()
            Dim body = String.Format(tpl, IdProcesocompra, Membresia.ObtenerUsuario().NombreUsuario, RecuperarFecha(tbInicioApertura.Text, tbTiempoInicioApertura.Text), RecuperarFecha(tbfinapertura.Text, tbTiempoInicioApertura.Text), RecuperarFecha(tbFechaRecepcionOfertas.Text, tbTiempoRecepcionOfertas.Text), RecuperarFecha(tbFechaFinRecepOferta.Text, tbTiempoFinRecepOferta.Text))
            SendMail.Send("faldana@salud.gob.sv, mmartinez@salud.gob.sv", "Notificación de cambio de fecha SINAB - SICO", body)

        
        Using db As New SinabEntities
            Dim obj = Obtener(db, IdEstablecimiento, IdProcesocompra)
            obj.FECHAHORAINICIORECEPCION = RecuperarFecha(tbFechaRecepcionOfertas.Text, tbTiempoRecepcionOfertas.Text)
            obj.FECHAHORAFINRECEPCION = RecuperarFecha(tbFechaFinRecepOferta.Text, tbTiempoFinRecepOferta.Text)
            obj.FECHAHORAINICIOAPERTURA = RecuperarFecha(tbInicioApertura.Text, tbTiempoInicioApertura.Text)
                obj.FECHAHORAFINAPERTURA = RecuperarFecha(tbfinapertura.Text, tbTiempofinapertura.Text)
            obj.AUUSUARIOMODIFICACION = Membresia.ObtenerUsuario().NombreUsuario
            obj.AUFECHAMODIFICACION = DateTime.Now
            db.SaveChanges()
        End Using
            CargarDatos(IdEstablecimiento, IdProcesocompra)
      
        Catch ex As Exception
            MessageBox.Alert(ex.Message)
        End Try
    End Sub

    Private Function RecuperarFecha(ByVal Fecha As String, ByVal Tiempo As String) As DateTime?
        If String.IsNullOrEmpty(Fecha) And String.IsNullOrEmpty(Tiempo) Then
            Return Nothing
        Else
            Return CDate(String.Format("{0} {1}", Fecha, Tiempo))
        End If
    End Function

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        mv.ActiveViewIndex = 0
    End Sub
End Class
