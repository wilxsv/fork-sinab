Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO


Partial Class Controles_ucCalificaProveedor
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub consultarProveedores()
        Dim mComProveedor As New cPROVEEDORES
        If Not IsPostBack Then


            Me.ddlProveedor.DataSource = mComProveedor.obtenerProveedoresContrato(Session("IdEstablecimiento"))
            Me.ddlProveedor.DataTextField = "NOMBRE"
            Me.ddlProveedor.DataValueField = "IDPROVEEDOR"
            Me.ddlProveedor.DataBind()

        End If

    End Sub

    Protected Sub btnConsultarContratos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultarContratos.Click
        Dim mComCalifProvee As New cCALIFICACIONPROVEEDORES

        Dim cComInc As New cINCUMPLIMIENTO

        cComInc.idEstablecimiento = Session("IdEstablecimiento")
        cComInc.idProveedor = Me.ddlProveedor.SelectedValue

        Dim diasatraso As Integer
        Dim rechazos As Integer

        Dim cContrato As New cCONTRATOS
        diasatraso = cContrato.DiasAtraso(Session("IdEstablecimiento"), Me.ddlProveedor.SelectedValue, Format(Me.CalendarPopup1.SelectedDate, "dd/MM/yyyy"), Format(Me.CalendarPopup2.SelectedDate, "dd/MM/yyyy"))

        rechazos = cContrato.CalculoRechazo(Session("IdEstablecimiento"), Me.ddlProveedor.SelectedValue)


        Me.dgCalificacion.DataSource = mComCalifProvee.obtenerContratosProveedor(Session("IdEstablecimiento"), Me.ddlProveedor.SelectedValue, diasatraso, rechazos, Format(Me.CalendarPopup1.SelectedDate, "dd/MM/yyyy"), Format(Me.CalendarPopup2.SelectedDate, "dd/MM/yyyy"))
        Me.dgCalificacion.DataBind()
    End Sub

    Protected Sub dgCalificacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCalificacion.SelectedIndexChanged

    End Sub
End Class
