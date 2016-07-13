Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Utils.MessageBox

Partial Class FrmNotificarAdjudicacion
    Inherits System.Web.UI.Page

    Private cPC As New cPROCESOCOMPRAS
    Private ePC As New PROCESOCOMPRAS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Me.cvNotificacion.ValueToCompare = Now.Date

            Me.btnImprimir.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptNotificacionAdjudicacion.aspx?id=" + Request.QueryString("idProc"))
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptNotificacionAdjudicacion.aspx?id=" + Request.QueryString("idProc") + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return;"

            CargarDatos()

        End If

    End Sub

    Private Sub CargarDatos()

        ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")
        ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        If cPC.ObtenerPROCESOCOMPRAS(ePC) <> 1 Then
            'Dim e As EventArgs
            'RaiseEvent ErrorEvent("Error al obtener Registro.")
            ' Return
        End If

        Me.lblNoProcesoCompra.Text = ePC.CODIGOLICITACION
        Me.FechaInicioProcCompra.Text = ePC.FECHAINICIOPROCESOCOMPRA.ToShortDateString
        Me.FechaExamen.Text = ePC.FECHAFINEXAMEN.ToShortDateString
        Me.FechaRecomendacion.Text = ePC.FECHAFINRECOMENDACION.ToShortDateString

        '''''' para modificar
        If ePC.FECHANOTIFICACION.Year > 1900 Then
            Me.cpFechaNotificacion.SelectedDate = ePC.FECHANOTIFICACION
        Else
            Me.cpFechaNotificacion.SelectedDate = Today
        End If

        If ePC.FECHALIMITEACEPTACION.Year > 1900 Then
            Me.cpFechaLimite.SelectedDate = ePC.FECHALIMITEACEPTACION
        Else
            Me.cpFechaLimite.SelectedDate = Today
        End If

    End Sub

    Private Sub Actualizar()

        ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")
        ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION
        cPC.ObtenerPROCESOCOMPRAS(ePC)

        ePC.FECHANOTIFICACION = Me.cpFechaNotificacion.SelectedDate
        ePC.FECHALIMITEACEPTACION = Me.cpFechaLimite.SelectedDate

        If ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.RESOLUCIONDEADJUDICACIONGENERADA Then
            ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.ESPERARRECURSOSDEREVISION
        End If

        cPC.ActualizarPROCESOCOMPRAS(ePC)
        Alert("Datos guardados satisfactoriamente", "Guardados")
        'Me.MsgBox1.ShowAlert("Datos guardados satisfactoriamente", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Actualizar()
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub btnModDistr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModDistr.Click
        cPC.ActualizarPROCESOCOMPRASMODIFICACIONDISTRIBUCION(Session("IdEstablecimiento"), Request.QueryString("idProc"), True)
        Alert("Datos guardados satisfactoriamente Se habilita la Redistribucion de este proceso de compra ", "Guardados")
        'Me.MsgBox1.ShowAlert("Datos guardados satisfactoriamente Se habilita la Redistribucion de este proceso de compra ", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
    End Sub
End Class
