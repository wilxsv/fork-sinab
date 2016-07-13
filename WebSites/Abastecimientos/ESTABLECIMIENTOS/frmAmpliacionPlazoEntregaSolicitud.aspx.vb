Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Partial Class frmAmpliacionPlazoEntregaSolicitud
    Inherits System.Web.UI.Page
    Dim lId As Int64
    Private mComponente As New cENTREGACONTRATO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.IsAuthenticated Then
            If Not IsPostBack Then

                Me.UcAmpliaPlazosEntrega1.Enabled = False
                'Me.Master.ControlEncabezado.Width = 500
                'Me.Master.Visible = False
                Me.dgLista.DataSource = Me.mComponente.obtieneEntregasAmpliacion(Session.Item("IdEstablecimiento"), Request.QueryString("idProv"), Request.QueryString("idCont"), Request.QueryString("idRenglon"))
                Me.dgLista.DataBind()
            End If
        End If
    End Sub
End Class
