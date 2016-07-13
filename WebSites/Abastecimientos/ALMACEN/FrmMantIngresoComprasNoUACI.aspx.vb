
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Clases
Imports SINAB_Entidades.Tipos
Imports SINAB_Utils.MessageBox
Imports SINAB_Entidades.Clases.UACI
Imports SINAB_Entidades.Helpers.UACIHelpers


Partial Class FrmMantIngresoComprasNoUACI
    Inherits System.Web.UI.Page

    ' Private mComponente As New cCONTRATOS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            CargarDatos()
        End If
    End Sub

    Private Sub CargarDatos()
        Dim usr = Membresia.ObtenerUsuario()

        Dim idestablecimiento As Int32 = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO

        Dim ds = Contratos.ObtenerTodos(idestablecimiento, 1, usr.NombreUsuario)
        'ds = Me.mComponente.ObtenerDsContratos(idestablecimiento, 1)

        Me.gvLista.DataSource = ds

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Protected Sub ImgbAgregarDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgbAgregarDocumento.Click
        Response.Redirect("~/ALMACEN/FrmDetMantComprasNoUACI.aspx?IdProv=0&IdContrato=0", False)
    End Sub

    Protected Sub gvLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting
        Dim usr = Membresia.ObtenerUsuario()

        Dim base = New SAB_UACI_CONTRATOS
        With base
            .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDPROVEEDOR = CType(gvLista.DataKeys(e.RowIndex).Values.Item("IDPROVEEDOR"), Integer)
            .IDCONTRATO = CType(gvLista.DataKeys(e.RowIndex).Values.Item("IDCONTRATO"), Long)
        End With

        Try
            Contratos.Borrar(base)
        Catch ex As Exception
            Alert("Error al borrar un contrato : " + ex.Message, "Error")
        End Try


        'Dim eEC As New EntregasContrato
        'Dim cFFC As New cFUENTEFINANCIAMIENTOSCONTRATOS
        'Dim cRDC As New cRESPONSABLEDISTRIBUCIONCONTRATO
        'Dim cEC As New cENTREGACONTRATO
        'Dim cPC As New cPRODUCTOSCONTRATO
        'Dim mComponente As New cCONTRATOS

        'eEC.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        'eEC.IDPROVEEDOR = gvLista.DataKeys(e.RowIndex).Values.Item("IDPROVEEDOR")
        'eEC.IDCONTRATO = gvLista.DataKeys(e.RowIndex).Values.Item("IDCONTRATO")

        'cFFC.EliminarAsociados(eEC.IDESTABLECIMIENTO, eEC.IDPROVEEDOR, eEC.IDCONTRATO)
        'cRDC.EliminarAsociados(eEC.IDESTABLECIMIENTO, eEC.IDPROVEEDOR, eEC.IDCONTRATO)
        'cEC.EliminarEntregasContratoTodas(eEC)

        'cPC.EliminarProductosAsociados(eEC.IDESTABLECIMIENTO, eEC.IDPROVEEDOR, eEC.IDCONTRATO)
        'mComponente.EliminarCONTRATOS(eEC.IDESTABLECIMIENTO, eEC.IDPROVEEDOR, eEC.IDCONTRATO)



        CargarDatos()

    End Sub

    Protected Sub GvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.CargarDatos()
    End Sub

    Protected Sub GvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound

        'Dim gv As GridView = CType(e.Row.FindControl("gvFuentes"), GridView)

        'If e.Row.RowIndex > -1 Then
        '    gv.DataSource = mComponente.ObtenerDatasetFuentesFinanciamientoContrato(Me.gvLista.DataKeys(e.Row.RowIndex).Values.Item("IDESTABLECIMIENTO").ToString(), _
        '           Me.gvLista.DataKeys(e.Row.RowIndex).Values.Item("IDPROVEEDOR").ToString(), _
        '           Me.gvLista.DataKeys(e.Row.RowIndex).Values.Item("IDCONTRATO").ToString())
        '    gv.DataBind()
        'End If

        'If e.Row.RowType = DataControlRowType.DataRow Then

        '    Select Case e.Row.RowState
        '        Case Is = DataControlRowState.Normal
        '            gv.RowStyle.CssClass = Me.gvLista.RowStyle.CssClass
        '            gv.AlternatingRowStyle.CssClass = Me.gvLista.RowStyle.CssClass
        '        Case Is = DataControlRowState.Alternate
        '            gv.RowStyle.CssClass = Me.gvLista.AlternatingRowStyle.CssClass
        '            gv.AlternatingRowStyle.CssClass = Me.gvLista.AlternatingRowStyle.CssClass
        '    End Select

        'End If
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
