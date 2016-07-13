'Notificar incumplimientos de documentacion
'CU-UACI011
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario que muestra las solicitude y las ofertas asociadas al proceso de compras listos pa notificar el incumplimiento de
'documentacion
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data

Partial Class FrmGenerarNotaIncumplimientoPaso2
    Inherits System.Web.UI.Page

    'declaracion e inicializacion de variables
    Private mComponente As New cPROCESOCOMPRAS
    Private mCompNota As New cNOTASINCUMPLIMIENTO

    Private mCompProcesoSolicitud As New cSOLICITUDESPROCESOCOMPRAS
    Private mEntidad As New PROCESOCOMPRAS
    Private mEntNota As New NOTASINCUMPLIMIENTO
    Private mCompEstados As New cESTADOS
    Private mCompDependencia As New cDEPENDENCIAS
    Private _IDPROCESOCOMPRA As Int64

    Public Property IDPROCESOCOMPRA() As Int64
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Int64)
            _IDPROCESOCOMPRA = value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IDPROCESOCOMPRA", value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al carga la pagina

        If Not Page.IsPostBack Then 'para la primera vez
            Me.Master.ControlMenu.Visible = False 'oculta menu

            IDPROCESOCOMPRA = Request.QueryString("id") 'obtiene el identificador de proceso de compra 
            Me.DocOfertaCompleta.Text = 0
            Me.EstaCompleta.Text = "True"
            Me.gvLista2.Visible = True
            Me.gvLista.Visible = True
            Me.lblmensaje2.Visible = True
            Me.lblmensaje3.Visible = True
            Me.lblLicitacion.Visible = True

            mEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA

            btnImprimir1.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptDocumentacionFaltanteOfertanteTodas.aspx?id=" + Me.IDPROCESOCOMPRA.ToString)
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptDocumentacionFaltanteOfertanteTodas.aspx?id=" + Me.IDPROCESOCOMPRA.ToString + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return;"
            btnImprimir2.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptDocumentacionFaltanteRenglonTodas.aspx?id=" + Me.IDPROCESOCOMPRA.ToString)
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptDocumentacionFaltanteRenglonTodas.aspx?id=" + Me.IDPROCESOCOMPRA.ToString + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return;"
            btnImprimir3.OnClientClick = SINAB_Utils.Utils.ReferirVentana("/Reportes/FrmRptDocumentacionFaltante.aspx?id=" + Me.IDPROCESOCOMPRA.ToString)
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptDocumentacionFaltante.aspx?id=" + Me.IDPROCESOCOMPRA.ToString + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 ');return;"

            mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")

            mComponente.ObtenerPROCESOCOMPRAS(mEntidad)

            Me.lblLicitacion.Text = mEntidad.CODIGOLICITACION & " " & mEntidad.DESCRIPCIONLICITACION

            CargarDatosProcesoCompraSolicitud(Me.IDPROCESOCOMPRA, Session.Item("IdEstablecimiento"))

            Cargar()

            If Val(Me.DocOfertaCompleta.Text) > 0 Then
                Me.btnImprimir1.Enabled = False
                Me.btnImprimir2.Enabled = False
                Me.btnImprimir3.Enabled = False
            Else
                Me.btnImprimir1.Enabled = True
                Me.btnImprimir2.Enabled = True
                Me.btnImprimir3.Enabled = True
            End If

            If Me.EstaCompleta.Text = "True" Then
                Me.btnImprimir1.Enabled = False
                Me.btnImprimir2.Enabled = False
                Me.btnImprimir3.Enabled = False
            End If
        Else
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me._IDPROCESOCOMPRA = Me.ViewState("IDPROCESOCOMPRA")
        End If
    End Sub

    Private Sub Cargar()
        'carga datos del grid de ofertas del proceso de compra
        Dim ds As DataSet
        ds = Me.mComponente.ObtenerOfertasPrcesoCompra(Session.Item("IdEstablecimiento"), eESTADOPROCESOSCOMPRAS.CONSOLIDACIONDEOFERTAS, Me.IDPROCESOCOMPRA) 'Examen preliminar (6)

        If ds.Tables(0).Rows.Count > 0 Then
            Me.gvLista.DataSource = ds
            Try
                Me.gvLista.DataBind()
            Catch ex As Exception
                Me.gvLista.PageIndex = 0
                Me.gvLista.DataBind()
            End Try
        Else
            Me.DocOfertaCompleta.Text = 1
        End If
    End Sub

    Private Sub CargarDatosProcesoCompraSolicitud(ByVal IDPROCESO As Int32, ByVal idESTABLECIMIENTO As Int32)
        'carga grid de solicitud asociadas al proceso de compra 
        Me.gvLista2.DataSource = Me.mCompProcesoSolicitud.ObtenerSolicitudesProcesoCompra(IDPROCESO, idESTABLECIMIENTO)

        Try
            Me.gvLista2.DataBind()
        Catch ex As Exception
            Me.gvLista2.PageIndex = 0
            Me.gvLista2.DataBind()
        End Try

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'redirecciona a la pagina principal
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub gvLista2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista2.PageIndexChanging
        'al momento de cambiar el indice de pagina del grid de solicitudes asociadase
        Me.gvLista2.PageIndex = e.NewPageIndex
        Me.CargarDatosProcesoCompraSolicitud(Me.IDPROCESOCOMPRA, Session.Item("IdEstablecimiento"))
    End Sub

    Protected Sub gvLista_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvLista.RowEditing
        'al momento de crear o consulta una nota de incumplimiento
        Dim IDESTABLECIMIENTO, IDPROVEEDOR, IDPROCESOCOMPRA, IDOFERTA As Integer
        IDESTABLECIMIENTO = Me.gvLista.DataKeys(e.NewEditIndex).Values.Item("IDESTABLECIMIENTO")
        IDPROVEEDOR = Me.gvLista.DataKeys(e.NewEditIndex).Values.Item("IDPROVEEDOR")
        IDPROCESOCOMPRA = Me.gvLista.DataKeys(e.NewEditIndex).Values.Item("IdProcesoCompra")
        IDOFERTA = Me.gvLista.DataKeys(e.NewEditIndex).Values.Item("ORDENLLEGADAOFERTA")

        Response.Redirect("~/UACI/FrmNotaIncumplimiento.aspx?idproceso= " + IDPROCESOCOMPRA.ToString + "&idoferta= " + IDOFERTA.ToString & "&idproveedor= " + IDPROVEEDOR.ToString & "&idestablecimiento= " + IDESTABLECIMIENTO.ToString)
    End Sub

    Protected Sub gvLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        'al momento de cargar los registros del grid de ofertas

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim a As LinkButton = CType(e.Row.FindControl("LinkButton1"), LinkButton) 'crear o consultar nota

            Dim IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR As Integer
            IDESTABLECIMIENTO = Me.gvLista.DataKeys(e.Row.RowIndex).Values.Item("IDESTABLECIMIENTO")
            IDPROCESOCOMPRA = Me.gvLista.DataKeys(e.Row.RowIndex).Values.Item("IdProcesoCompra")
            IDPROVEEDOR = Me.gvLista.DataKeys(e.Row.RowIndex).Values.Item("IDPROVEEDOR")

            'verifica existencia de nota
            If mCompNota.ValidarExistenciaNota(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR) Then
                a.Attributes.Add("onclick", "if(!window.confirm('¿Desea modificar o imprimir Nota de Incumplimiento?')){return false;}")
                a.ToolTip = "Consultar nota"
                a.CssClass = "GridEditar"
            Else
                a.Attributes.Add("onclick", "if(!window.confirm('¿Desea generar Nota de Incumplimiento?')){return false;}")
                a.ToolTip = "Generar nota"
                a.CssClass = "GridAgregarNota"
            End If

            'verifica documentos faltantes del ofertante para entrega 1
            If mComponente.FaltanDocumentosOfertaEntrega1(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR) Then
                CType(e.Row.FindControl("lblDocsOferta"), Label).Text = "INCOMPLETA"
                Me.EstaCompleta.Text = "False"
            Else
                CType(e.Row.FindControl("lblDocsOferta"), Label).Text = "COMPLETA"
            End If

            'verifica documentos faltantes para los renglones
            If mComponente.FaltanDocumentosRenglonOfertaEntrega1(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR) Then
                CType(e.Row.FindControl("lblDocRenglon"), Label).Text = "INCOMPLETA"
                Me.EstaCompleta.Text = "False"
            Else
                CType(e.Row.FindControl("lblDocRenglon"), Label).Text = "COMPLETA"
            End If

            'oculta la boton de imagen para consultar o crear nota si documentacion esta completa
            If CType(e.Row.FindControl("lblDocsOferta"), Label).Text = "COMPLETA" And CType(e.Row.FindControl("lblDocRenglon"), Label).Text = "COMPLETA" Then
                CType(e.Row.FindControl("LinkButton1"), LinkButton).Visible = False
            End If
            If (CType(e.Row.FindControl("lblDocsOferta"), Label).Text = "INCOMPLETA" And CType(e.Row.FindControl("LinkButton1"), LinkButton).ToolTip = "Generar nota" And CType(e.Row.FindControl("LinkButton1"), LinkButton).Visible = True) Or (CType(e.Row.FindControl("lblDocRenglon"), Label).Text = "INCOMPLETA" And CType(e.Row.FindControl("LinkButton1"), LinkButton).ToolTip = "Generar nota" And CType(e.Row.FindControl("LinkButton1"), LinkButton).Visible = True) Then
                Me.DocOfertaCompleta.Text = Val(Me.DocOfertaCompleta.Text) + 1
            End If
        End If
    End Sub

    Protected Sub dgLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        'al momento de cambiar el numero de indice de pagina del grid de ofertantes
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.Cargar()
    End Sub

End Class
