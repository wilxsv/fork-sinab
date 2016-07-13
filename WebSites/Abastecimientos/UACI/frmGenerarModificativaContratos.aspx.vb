
Partial Class frmGenerarModificativaContratos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Me.UcVistaDetalleListaProcesoCompra2
            ._ESTADO = 17      'Debe ser para Generar Contratos
            ._EVAL_FEC_REC = False
            ._EVAL_FEC_RET = False
            ._IDESTABLECIMIENTO = Session("IdEstablecimiento")
            ._PAGINA_CONSULTA = ""
            ._PAGINA_REDIREC = "frmGenerarModificativaContratosPlantilla.aspx"
            '.cargarDatos(Session("IdEmpleado") )
            .cargarDatos(0)

        End With
    End Sub
End Class
