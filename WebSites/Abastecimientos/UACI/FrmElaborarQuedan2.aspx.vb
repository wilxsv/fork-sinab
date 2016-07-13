'ELABORAR QUEDAN
'CU-UACI030
'Ing. Yessenia Pennelope Henriquez Duran
'presentan las solicitudes asociadas al proceso de compra
'Formulario con las garantias del contrato para la elaboracion de los contratos
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Partial Class FrmElaborarQuedan2
    Inherits System.Web.UI.Page

    'declarar e inicializar variables

    Private mComponente As New cQUEDANS
    Private mCompProceso As New cPROCESOCOMPRAS
    Private mEntProceso As New PROCESOCOMPRAS
    Private mEntContrato As New CONTRATOS
    Private mCompContrato As New cCONTRATOS
    Private mCompProcesoSolicitud As New cSOLICITUDESPROCESOCOMPRAS
    Private mEntidad As New QUEDANS
    Private mCompFuenteC As New cFUENTEFINANCIAMIENTOSCONTRATOS
    Private mCompGarantias As New cGARANTIASCONTRATOS

    Dim lId As Int32
    Dim lcontrato As Int32
    Dim lproveedor As Int32
    Dim loferta As Int32
    Dim ds As DataSet
    Dim renglones As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina

        If Not Page.IsPostBack Then 'al cargar por primera vez
            Me.Master.ControlMenu.Visible = False 'ocultar menu

            lId = Request.QueryString("id") 'identificador del proceso de compra
            lcontrato = Request.QueryString("contrato") 'identificador del contrato
            lproveedor = Request.QueryString("proveedor") 'identificador del proveedores
            loferta = Request.QueryString("oferta") 'identificador de la oferta

            'carga los datos para el proceso de compra seleccionado

            Me.dgLista2.Visible = True
            Me.dgLista.Visible = True
            Me.lblmensaje2.Visible = True
            Me.lblLicitacion.Visible = True

            Me.lblid.Text = lId
            Me.lblcont.Text = lcontrato
            Me.lblOferta.Text = loferta
            Me.DdlPROVEEDORES1.Recuperar()
            Me.DdlPROVEEDORES1.SelectedValue = lproveedor
            Me.lblProveedor.Text = Me.DdlPROVEEDORES1.SelectedItem.Text


            mEntContrato.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntContrato.IDPROVEEDOR = lproveedor
            mEntContrato.IDCONTRATO = lcontrato
            mCompContrato.ObtenerCONTRATOS(mEntContrato)

            Me.LblContrato.Text = mEntContrato.NUMEROCONTRATO
            If mEntContrato.TIPOPERSONA = "N" Then Me.lblPersoneria.Text = "Natural"
            If mEntContrato.TIPOPERSONA = "J" Then Me.lblPersoneria.Text = "Juridica"
            Me.lblFechaContrato.Text = mEntContrato.FECHADISTRIBUCION.ToString("dd/MM/yyyy")


            mEntProceso.IDPROCESOCOMPRA = lId
            mEntProceso.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mCompProceso.ObtenerPROCESOCOMPRAS(mEntProceso)
            Me.lblLicitacion.Text = mEntProceso.CODIGOLICITACION & " " & mEntProceso.TITULOLICITACION
            Me.lblFechaResolucion.Text = mEntProceso.FECHAFIRMAACEPTACION.ToString("dd/MM/yyyy")
            Me.lblResolucion.Text = mEntProceso.NUMERORESOLUCION

            CargarDatosProcesoCompraSolicitud(lId, Session.Item("IdEstablecimiento"))
            renglonesAdjudicados(Session.Item("IdEstablecimiento"), lcontrato, lproveedor)
            CargarFuentesContrato(Session.Item("IdEstablecimiento"), lcontrato, lproveedor)
            CargarGarantias(Session.Item("IdEstablecimiento"), lcontrato, lproveedor)


        End If
    End Sub

    Private Sub renglonesAdjudicados(ByVal idestablecimiento As Int32, ByVal idcontrato As Int32, ByVal IDPROVEEDOR As Int32)
        'obtiene los renglones adjudicados para el contrato

        ds = mCompContrato.obtenerRenglonesAdjudicadosXContrato(idestablecimiento, idcontrato, IDPROVEEDOR)

        Dim r As DataRow

        For Each r In ds.Tables(0).Rows
            If ds.Tables(0).Rows.Count > 1 Then renglones = renglones & r("RENGLON") & ","
            If ds.Tables(0).Rows.Count <= 1 Then renglones = renglones & r("RENGLON")
        Next r

        Me.lblRenglones.Text = renglones
    End Sub

    Private Sub CargarGarantias(ByVal idestablecimiento As Int32, ByVal idcontrato As Int32, ByVal IDPROVEEDOR As Int32)
        'obtiene las garantias para el contrato

        Me.dgLista.DataSource = Me.mCompGarantias.obtenerGarantiasXContrato(idestablecimiento, idcontrato, IDPROVEEDOR)
        'carga grid
        Try
            Me.dgLista.DataBind()
        Catch ex As Exception 'al momento de error de pagineo
            Me.dgLista.CurrentPageIndex = 0
            Me.dgLista.DataBind()
        End Try

    End Sub

    Private Sub CargarFuentesContrato(ByVal idestablecimiento As Int32, ByVal idcontrato As Int32, ByVal idproveedor As Int32)
        'obtiene las fuentes asociadas al contrato y las muestra en el grid

        Me.dglista3.DataSource = Me.mCompFuenteC.ObtenerFuentesPorContratoDS(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)
        Try
            Me.dglista3.DataBind()
        Catch ex As Exception
            Me.dglista3.CurrentPageIndex = 0
            Me.dglista3.DataBind()
        End Try
        Me.lblmonto.Text = Me.mCompFuenteC.CalcularMontoTotalFuenteContrato(idestablecimiento, idcontrato, idproveedor)
    End Sub

    Private Sub CargarDatosProcesoCompraSolicitud(ByVal idProceso As Int32, ByVal idESTABLECIMIENTO As Int32)
        'obtiene las solicitudes asiociadas al programa de compras y la muestra en el grid

        Me.dgLista2.DataSource = Me.mCompProcesoSolicitud.ObtenerSolicitudesProcesoCompra(idProceso, idESTABLECIMIENTO)

        Try
            Me.dgLista2.DataBind()
        Catch ex As Exception
            Me.dgLista2.CurrentPageIndex = 0
            Me.dgLista2.DataBind()
        End Try

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        'redirecciona a la pagina principal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub dgLista2_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista2.PageIndexChanged
        'al momento de cambio de indice de pagina para el grid con el detalle de solicitudes
        Me.dgLista2.CurrentPageIndex = e.NewPageIndex
        Me.CargarDatosProcesoCompraSolicitud(Me.lblid.Text, Session.Item("IdEstablecimiento"))
    End Sub

    Protected Sub dgLista_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista.EditCommand
        'al momento de seleccionar crear o consultar quedan
        Dim lbldgproveedor As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("lblidproveedor"), Label)
        Dim lbldgestablecimiento As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("lblidestablecimiento"), Label)
        Dim lbldgcontrato As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("lblidcontrato"), Label)
        Dim lbldgtipogarantia As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("lblidtipogarantia"), Label)
        Dim lbldgarantiacontrato As Label = CType(dgLista.Items(e.Item.ItemIndex).FindControl("lblidgarantiacontrato"), Label)

        If lbldgproveedor.Text = "" Or lbldgestablecimiento.Text = "" Or lbldgcontrato.Text = "" Or lbldgtipogarantia.Text = "" Or Me.lblOferta.Text = "" Or Me.lblid.Text = "" Or lbldgarantiacontrato.Text = "" Then
            MsgBox1.ShowAlert("Falta informacion para generar quedan", "error5", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            Response.Redirect("~/UACI/FrmQuedan.aspx?idproveedor= " + lbldgproveedor.Text & "&idestablecimiento= " + lbldgestablecimiento.Text & "&idcontrato= " + lbldgcontrato.Text & "&idtipogarantia= " + lbldgtipogarantia.Text & "&idoferta= " + Me.lblOferta.Text & "&idproceso= " + Me.lblid.Text & "&idgarantiacontrato= " + lbldgarantiacontrato.Text)
        End If


    End Sub

    Private Sub dgLista_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgLista.ItemDataBound
        'al momento de cargar los tipos de garanria del contrato

        If e.Item.ItemType = ListItemType.AlternatingItem Or _
           e.Item.ItemType = ListItemType.Item Then
            Dim a As ImageButton = CType(e.Item.FindControl("LinkButton1"), ImageButton) 'crear o consultar quedan
            'valida si existe quedan

            If mComponente.ValidarExistenciaQuedan(Session.Item("IdEstablecimiento"), Me.lblid.Text, Val(CType(e.Item.FindControl("lblidproveedor"), Label).Text), Val(CType(e.Item.FindControl("lblidtipogarantia"), Label).Text), Val(CType(e.Item.FindControl("lblidgarantiacontrato"), Label).Text)) Then
                a.Attributes.Add("onclick", "if(!window.confirm('¿Desea modificar o imprimir quedan?')){return false;}")
                a.ToolTip = "Consultar quedan"
                a.ImageUrl = "~/Imagenes/consulta.gif"
            Else
                a.Attributes.Add("onclick", "if(!window.confirm('¿Desea generar quedan?')){return false;}")
                a.ToolTip = "Generar quedan"
                a.ImageUrl = "~/Imagenes/generar.gif"
            End If
        End If
    End Sub

    Protected Sub dgLista_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista.PageIndexChanged
        'al momento de cambiar el indice de pagina del grid de garantias de contrato

        Me.dgLista.CurrentPageIndex = e.NewPageIndex
        Me.CargarGarantias(Session.Item("IdEstablecimiento"), Me.lblcont.Text, Me.DdlPROVEEDORES1.SelectedValue)
    End Sub
End Class
