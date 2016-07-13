Imports ABASTECIMIENTOS.NEGOCIO

Partial Class frmPlazoEntregaSolicitud
    Inherits System.Web.UI.Page

    Private mComponente As New cDETALLEENTREGAS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.IsAuthenticated Then
            If Not IsPostBack Then
                Dim IDSOLICITUD As Int64 = CInt(Session.Item("idDoc"))
                Dim IDESTABLECIMIENTO As Int64 = CInt(Session.Item("IdEstablecimiento"))
                Me.UcPlazosEntrega1.IDESTABLECIMIENTO = IDESTABLECIMIENTO
                Me.UcPlazosEntrega1.IDSOLICITUD = IDSOLICITUD
                Me.UcPlazosEntrega1.Enabled = False
                Me.dgLista.DataSource = Me.mComponente.ObtenerDataSetPorSolicitud(IDSOLICITUD, IDESTABLECIMIENTO)
                Me.dgLista.DataBind()
            End If
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "CerrarVistaPrevia", "<script language='javascript' type'text/javascript'> window.opener.document.forms(0).submit(); self.close() </script>")
    End Sub

End Class
