
Partial Class UACI_FrmModificacionFechasLG
    Inherits System.Web.UI.Page

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Dim cP As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS
            Dim P As New ABASTECIMIENTOS.ENTIDADES.PROCESOCOMPRAS
            P.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            P.IDPROCESOCOMPRA = Request.QueryString("idProc")
            cP.ObtenerPROCESOCOMPRAS(P)

            If Not IsDBNull(P.FECHAHORAFINRETIRO) Then
                Me.CalendarPopup1.SelectedDate = P.FECHAHORAFINRETIRO
            End If
            If Not IsDBNull(P.FECHAHORAFINRECEPCION) Then
                Me.CalendarPopup2.SelectedDate = P.FECHAHORAFINRECEPCION
            End If
            If Not IsDBNull(P.FECHAHORAFINAPERTURA) Then
                Me.CalendarPopup3.SelectedDate = P.FECHAHORAFINAPERTURA
            End If

        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cp As New ABASTECIMIENTOS.NEGOCIO.cPROCESOCOMPRAS
        Dim ap As New ABASTECIMIENTOS.ENTIDADES.PROCESOCOMPRAS

        Try
            ap.IDPROCESOCOMPRA = Request.QueryString("idProc")
            ap.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            ap.FECHAHORAFINRETIRO = Format(Me.CalendarPopup1.SelectedDate, "dd/MM/yyyy")
            ap.FECHAHORAFINRECEPCION = Format(Me.CalendarPopup2.SelectedDate, "dd/MM/yyyy")
            ap.FECHAHORAFINAPERTURA = Format(Me.CalendarPopup3.SelectedDate, "dd/MM/yyyy")
            ap.FECHAPUBLICACION = Format(Me.CalendarPopup4.SelectedDate, "dd/MM/yyyy")
            ap.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS
            ap.AUFECHAMODIFICACION = Date.Now
            ap.AUUSUARIOMODIFICACION = User.Identity.Name
            cp.ActualizarEstado(ap, 0)
            Me.MsgBox1.ShowAlert("Actualización realizada satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Catch ex As Exception
            Me.MsgBox1.ShowAlert("Error en el registro.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End Try




    End Sub
End Class
