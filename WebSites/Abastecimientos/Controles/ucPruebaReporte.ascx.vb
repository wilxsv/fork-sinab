Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports CrystalDecisions.Shared


Partial Class Controles_ucPruebaReporte
    Inherits System.Web.UI.UserControl

    Dim mComponente As New cPROCESOCOMPRAS
    Dim paramField As New ParameterField
    Dim paramFields As New ParameterFields
    Dim discreteVal As New ParameterDiscreteValue


    Protected Sub lbReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbReporte.Click
        Dim lEntidad As New PROCESOCOMPRAS
        lEntidad.IDPROCESOCOMPRA = 1





        'Me.mComponente.ObtenerLista.BuscarPorId(1)

    End Sub
End Class
