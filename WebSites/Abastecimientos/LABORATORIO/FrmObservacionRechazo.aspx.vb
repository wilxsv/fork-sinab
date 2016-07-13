
Partial Class LABORATORIO_FrmObservacionRechazo
    Inherits System.Web.UI.Page
    Private _IDESTABLECIMIENTO As Integer
    Private _IDINFORME As Integer
    Public Property IDINFORME() As Integer
        Get
            Return _IDINFORME
        End Get
        Set(ByVal value As Integer)
            _IDINFORME = value
            If Not Me.ViewState("IDINFORME") Is Nothing Then Me.ViewState.Remove("IDINFORME")
            Me.ViewState.Add("IDINFORME", value)
        End Set
    End Property
    Public Property IDESTABLECIMIENTO() As Integer
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDESTABLECIMIENTO = value
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.ViewState.Remove("IDESTABLECIMIENTO")
            Me.ViewState.Add("IDESTABLECIMIENTO", value)
        End Set
    End Property

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cim As New ABASTECIMIENTOS.NEGOCIO.cINFORMEMUESTRAS
        cim.ActualizarEstadoInforme(Session("IdEstablecimiento"), IDINFORME, User.Identity.Name, Now, 3)

        cim.ActualizarObservacionAsignacionInforme(Session("IdEstablecimiento"), IDINFORME, User.Identity.Name, Now, Request.QueryString("idE") & "/ " & Me.TextBox1.Text)
        Me.Label3.Text = "Observacion guardada satisfactoriamente, el informe ha sido de enviado al inspector."
        Me.Button1.Visible = False

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            IDINFORME = Request.QueryString("idI")
            IDESTABLECIMIENTO = Request.QueryString("idE")

        Else
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me.IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDINFORME") Is Nothing Then Me.IDINFORME = Me.ViewState("IDINFORME")

        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "CerrarVistaPrevia", "<script language='javascript' type'text/javascript'> window.opener.document.forms(0).submit(); self.close() </script>")
    End Sub
End Class
