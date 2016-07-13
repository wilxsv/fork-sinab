Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES


Partial Class Controles_ucConsultarContratos
    Inherits System.Web.UI.UserControl

    
    Protected Sub rblParametro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblParametro.SelectedIndexChanged

        Dim cContratos As New cCONTRATOS
        Dim ds As Data.DataSet
        ds = cContratos.obtenerProveedores(Session("IdEstablecimiento"))

        Select Case Me.rblParametro.SelectedValue
            Case Is = 0
                Me.lblProducto.Visible = False
                Me.lblNoContrato.Visible = True
                Me.txtNoContrato.Visible = True

                Me.lblProveedor.Visible = Not True
                Me.DdlPROVEEDORES1.Visible = Not True
                DdlCATALOGOPRODUCTOS1.Visible = False
                Me.lblProducto.Visible = Not True
                'Me.DdlPRODUCTOSESTABLECIMIENTOS1.Visible = Not True
                Me.lblCodProceso.Visible = False
                Me.txtCodProceso.Visible = False
            Case Is = 1
                Me.lblProducto.Visible = False
                Me.lblNoContrato.Visible = Not True
                Me.txtNoContrato.Visible = Not True
                Me.lblProveedor.Visible = True
                DdlCATALOGOPRODUCTOS1.Visible = False
                Me.DdlPROVEEDORES1.Visible = True

                Me.DdlPROVEEDORES1.DataSource = ds
                Me.DdlPROVEEDORES1.DataTextField = "NOMBRE"
                Me.DdlPROVEEDORES1.DataValueField = "IDPROVEEDOR"
                Me.DdlPROVEEDORES1.DataBind()
                Me.lblCodProceso.Visible = False
                Me.txtCodProceso.Visible = False
            Case Is = 3
                Me.lblProducto.Visible = False
                Me.lblNoContrato.Visible = Not True
                Me.txtNoContrato.Visible = Not True
                Me.lblProveedor.Visible = Not True
                DdlCATALOGOPRODUCTOS1.Visible = False
                Me.DdlPROVEEDORES1.Visible = Not True
                'Me.DdlPROVEEDORES1.RecuperarListaNombreOrdenada(1)
                Me.DdlPROVEEDORES1.DataSource = ds
                Me.DdlPROVEEDORES1.DataTextField = "NOMBRE"
                Me.DdlPROVEEDORES1.DataValueField = "IDPROVEEDOR"
                Me.DdlPROVEEDORES1.DataBind()
                Me.lblCodProceso.Visible = True
                Me.txtCodProceso.Visible = True
            Case Is = 2
                Me.lblNoContrato.Visible = False
                Me.txtNoContrato.Visible = False
                Me.lblCodProceso.Visible = False
                Me.txtCodProceso.Visible = False
                Me.lblProveedor.Visible = Not True
                Me.DdlPROVEEDORES1.Visible = Not True

                Me.lblProducto.Visible = True
                'Me.DdlPRODUCTOSESTABLECIMIENTOS1.Visible = True

                Dim mComponente As New cCATALOGOPRODUCTOS
                DdlCATALOGOPRODUCTOS1.Visible = True
                Me.DdlCATALOGOPRODUCTOS1.DataSource = mComponente.ObtenerCatalogoProductos  '(.obtenerProductosAdjudicadosProCompra(Session("IdEstablecimiento"), Request.QueryString("IdProc"))
                Me.DdlCATALOGOPRODUCTOS1.DataTextField = "DESCPRODUCTO"
                Me.DdlCATALOGOPRODUCTOS1.DataValueField = "CORRPRODUCTO"
                Me.DdlCATALOGOPRODUCTOS1.DataBind()

        End Select
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim mComponente As New cCONTRATOS

        Dim idProveedor As Integer = 0
        Dim idTipoDocumento As Integer = 0
        Dim nContrato As String = ""
        Dim idProducto As Integer = 0
        Dim idTipoConsulta As Integer = 0
        Dim idProcesoCompra As Integer

        Select Case Me.rblParametro.SelectedValue
            Case Is = 0
                If Me.txtNoContrato.Text = "" Then
                    nContrato = 0
                Else
                    nContrato = Me.txtNoContrato.Text
                End If

            Case Is = 1
                idProveedor = Me.DdlPROVEEDORES1.SelectedValue
            Case Is = 2
                idProducto = Me.DdlCATALOGOPRODUCTOS1.SelectedValue
            Case Is = 3

                idProcesoCompra = Me.txtCodProceso.Text
        End Select

        Me.dgContrato.DataSource = mComponente.ObtenerDsConsultaContratos(Session("IdEstablecimiento"), idProveedor, idTipoDocumento, nContrato, idProducto, idTipoConsulta, idProcesoCompra)
        Me.dgContrato.DataBind()

    End Sub

    Protected Sub dgContrato_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgContrato.SelectedIndexChanged
        Dim idContrato As Integer
        Dim idProveedor As Integer

        idContrato = dgContrato.SelectedItem.Cells(5).Text
        idProveedor = dgContrato.SelectedItem.Cells(4).Text
        Response.Redirect("~/UFI/frmDetConsultarContratos.aspx?idProc=" & Me.dgContrato.SelectedItem.Cells(9).Text & "&id=" & idContrato & "&idProv=" & idProveedor & "&numcon=" & dgContrato.SelectedItem.Cells(6).Text)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DdlCATALOGOPRODUCTOS1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlCATALOGOPRODUCTOS1.SelectedIndexChanged
        Me.lblNombreProducto.Text = Me.DdlCATALOGOPRODUCTOS1.SelectedItem.Text
    End Sub

    Protected Sub DdlPROVEEDORES1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlPROVEEDORES1.SelectedIndexChanged

    End Sub
End Class
