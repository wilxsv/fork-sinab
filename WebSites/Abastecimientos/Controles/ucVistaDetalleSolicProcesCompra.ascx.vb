Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Linq
Imports SINAB_Entidades.Helpers

Partial Class Controles_ucVistaDetalleSolicProcesCompra
    Inherits System.Web.UI.UserControl

    Private mComponenteSPC As New cSOLICITUDESPROCESOCOMPRAS

    Private _IDPROCESOCOMPRA As Int64
    Private _IDESTABLECIMIENTO As Int32

    Private _PermiteSeleccionar As Boolean
    Private _Redirect As String

    Private _BtnAnularProcesoEnabled As Boolean
    Private _BtnQuitarSolicitudEnabled As Boolean
    Private _BtnEliminaProcesoEnabled As Boolean

    Public Property IDPROCESOCOMPRA() As Integer
        Get
            Return _IDPROCESOCOMPRA
        End Get
        Set(ByVal value As Integer)
            _IDPROCESOCOMPRA = value
            If Not Me.ViewState("IdProcesoCompra") Is Nothing Then Me.ViewState.Remove("IdProcesoCompra")
            Me.ViewState.Add("IdProcesoCompra", value)
        End Set
    End Property

    Public Property IDESTABLECIMIENTO() As Int32
        Get
            Return _IDESTABLECIMIENTO
        End Get
        Set(ByVal value As Int32)
            _IDESTABLECIMIENTO = value
        End Set
    End Property

    Public Property PermiteSeleccionar() As Boolean
        Get
            Return _PermiteSeleccionar
        End Get
        Set(ByVal value As Boolean)
            _PermiteSeleccionar = value
            If Not Me.ViewState("PermiteSeleccionar") Is Nothing Then Me.ViewState.Remove("PermiteSeleccionar")
            Me.ViewState.Add("PermiteSeleccionar", value)
        End Set
    End Property

    Public Property Redirect() As String
        Get
            Return _Redirect
        End Get
        Set(ByVal value As String)
            _Redirect = value
            If Not Me.ViewState("Redirect") Is Nothing Then Me.ViewState.Remove("Redirect")
            Me.ViewState.Add("Redirect", value)
        End Set
    End Property

    Public Property BtnAnularProcesoEnabled() As Boolean
        Get
            Return _BtnAnularProcesoEnabled
        End Get
        Set(ByVal value As Boolean)
            _BtnAnularProcesoEnabled = value
            Me.btnAnularProceso.Enabled = value
            Me.btnAnularProceso.Visible = value
            If Not Me.ViewState("BtnAnularProcesoEnabled") Is Nothing Then Me.ViewState.Remove("BtnAnularProcesoEnabled")
            Me.ViewState.Add("BtnAnularProcesoEnabled", value)
        End Set
    End Property

    Public Property BtnQuitarSolicitudEnabled() As Boolean
        Get
            Return _BtnQuitarSolicitudEnabled
        End Get
        Set(ByVal value As Boolean)
            _BtnQuitarSolicitudEnabled = value
            Me.btnQuitarSolicitud.Enabled = value
            Me.btnQuitarSolicitud.Visible = value
            If Not Me.ViewState("BtnQuitarSolicitudEnabled") Is Nothing Then Me.ViewState.Remove("BtnQuitarSolicitudEnabled")
            Me.ViewState.Add("BtnQuitarSolicitudEnabled", value)
        End Set
    End Property

    Public Property BtnEliminaProcesoEnabled() As Boolean
        Get
            Return _BtnEliminaProcesoEnabled
        End Get
        Set(ByVal value As Boolean)
            _BtnEliminaProcesoEnabled = value
            Me.btnEliminaProceso.Enabled = value
            Me.btnEliminaProceso.Visible = value
            If Not Me.ViewState("BtnEliminaProcesoEnabled") Is Nothing Then Me.ViewState.Remove("BtnEliminaProcesoEnabled")
            Me.ViewState.Add("BtnEliminaProcesoEnabled", value)
        End Set
    End Property

    Public WriteOnly Property VerDetalleProcesoCompra() As Boolean
        Set(ByVal value As Boolean)
            Me.dvProcesoCompra.Enabled = value
            Me.dvProcesoCompra.Visible = value
        End Set
    End Property

    Public Sub ocultaSeleccion()
        Me.gvSolicitudes.Columns(0).Visible = Me.PermiteSeleccionar
    End Sub

    Public Sub Consultar()
        Me.gvSolicitudes.Columns(0).Visible = Me.PermiteSeleccionar
        Me.BtnAnularProcesoEnabled = Me.PermiteSeleccionar

        consultarSolicitudes()
    End Sub

    Public Function ConsultarTipoSuministro() As Integer
        Me.gvSolicitudes.DataSource = Me.mComponenteSPC.obtenerSolProcCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        Me.gvSolicitudes.DataBind()
        Return Me.gvSolicitudes.DataKeys(0).Values.Item("IDCLASESUMINISTRO").ToString()
    End Function

    Public Sub ocultarQuitarSolicitud()
        BtnQuitarSolicitudEnabled = False
    End Sub

    Private Sub consultarSolicitudes()

        Select Case Request.QueryString("redirect")
            Case "FrmGenerarRecomCompra.aspx"
                VerDetalleProcesoCompra = True
                dvProcesoCompra.Fields(2).Visible = False
                dvProcesoCompra.Fields(3).Visible = False
                dvProcesoCompra.Fields(4).Visible = False
            Case "FrmGenerarResolucionAdjudicacion.aspx"
                VerDetalleProcesoCompra = True
                dvProcesoCompra.Fields(1).Visible = False
                dvProcesoCompra.Fields(2).Visible = True
                dvProcesoCompra.Fields(3).Visible = False
                dvProcesoCompra.Fields(4).Visible = False
            Case "FrmDistribuirContratos.aspx"
                VerDetalleProcesoCompra = True
                dvProcesoCompra.Fields(1).Visible = False
                dvProcesoCompra.Fields(2).Visible = False
                dvProcesoCompra.Fields(3).Visible = False
                dvProcesoCompra.Fields(4).Visible = False
            Case Else
                VerDetalleProcesoCompra = False
        End Select

        

        'Dim cPC As New cPROCESOCOMPRAS
        'Dim ds As Data.DataSet
        if IDPROCESOCOMPRA = 0 then Response.Redirect("~/FrmPrincipal.aspx")

        dim ds = SINAB_Entidades.Helpers.UACIHelpers.ProcesoCompras.ObtenerTodosConsolidados(IDESTABLECIMIENTO, IDPROCESOCOMPRA)
        If ds.FirstOrDefault().IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.PROCESODECOMPRAANULADO Then
            Me.BtnAnularProcesoEnabled = False
            Me.BtnQuitarSolicitudEnabled = False
            Me.Label2.Text = "El proceso ha sido anulado"
            Me.Label2.ForeColor = Drawing.Color.Red
        Else
            Me.Label2.Text = "Solicitudes consolidadas en el proceso de compra seleccionado"
            Me.Label2.ForeColor = Drawing.Color.Black
        End If

        If dvProcesoCompra.Visible Then
            Me.dvProcesoCompra.DataSource = ds
            Me.dvProcesoCompra.DataBind()
        End If

        Dim dt As Data.DataSet
        dt = Me.mComponenteSPC.obtenerSolProcCompra(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        If ds.FirstOrDefault().IDESTADOPROCESOCOMPRA <> eESTADOPROCESOSCOMPRAS.PROCESODECOMPRAANULADO Then
            Me.gvSolicitudes.DataSource = dt
            Me.gvSolicitudes.DataBind()
        End If

    End Sub

    Protected Sub gvSolicitudes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvSolicitudes.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim cFFS As New cFUENTEFINANCIAMIENTOSOLICITUDES

            Dim IDESTABLECIMIENTOSOLICITUD As Integer = sender.DataKeys(e.Row.RowIndex).Values.Item("IDESTABLECIMIENTO")
            Dim IDSOLICITUD As Integer = sender.DataKeys(e.Row.RowIndex).Values.Item("IDSOLICITUD")

            Dim gv As GridView = CType(e.Row.FindControl("gvFuentesFinanciamiento"), GridView)

            Dim ds As Data.DataSet
            ds = cFFS.ObtenerNombresFuenteFinanciamientoSolicitud(IDESTABLECIMIENTOSOLICITUD, IDSOLICITUD)

            gv.DataSource = ds
            gv.DataBind()

            Select Case e.Row.RowState
                Case DataControlRowState.Normal
                    gv.RowStyle.CssClass = sender.RowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.RowStyle.CssClass
                Case DataControlRowState.Alternate
                    gv.RowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.AlternatingRowStyle.CssClass
                Case DataControlRowState.Selected
                    gv.RowStyle.CssClass = sender.SelectedRowStyle.CssClass
                    gv.AlternatingRowStyle.CssClass = sender.SelectedRowStyle.CssClass
            End Select

        End If

    End Sub

    Protected Sub gvSolicitudes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvSolicitudes.SelectedIndexChanged
        Me.btnQuitarSolicitud.Visible = BtnQuitarSolicitudEnabled
    End Sub

    Protected Sub btnAnularProceso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnularProceso.Click
        Me.MsgBox1.ShowConfirm("¿Desea anular el proceso de compra?", "ANULAR", Cooperator.Framework.Web.Controls.ConfirmOption.CallBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Protected Sub btnQuitarSolicitud_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuitarSolicitud.Click
        Me.pnlObservaciones.Visible = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            If Not Me.ViewState("BtnAnularProcesoEnabled") Is Nothing Then Me._BtnAnularProcesoEnabled = Me.ViewState("BtnAnularProcesoEnabled")
            If Not Me.ViewState("BtnQuitarSolicitudEnabled") Is Nothing Then Me._BtnQuitarSolicitudEnabled = Me.ViewState("BtnQuitarSolicitudEnabled")
            If Not Me.ViewState("BtnEliminaProcesoEnabled") Is Nothing Then Me._BtnEliminaProcesoEnabled = Me.ViewState("BtnEliminaProcesoEnabled")
            If Not Me.ViewState("PermiteSeleccionar") Is Nothing Then Me._BtnEliminaProcesoEnabled = Me.ViewState("PermiteSeleccionar")
            If Not Me.ViewState("Redirect") Is Nothing Then Me._Redirect = Me.ViewState("Redirect")
        End If
    End Sub

    Protected Sub btnQuitar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        Me.MsgBox1.ShowConfirm("¿Desea quitar la solicitud del proceso de compra?", "QUITAR", Cooperator.Framework.Web.Controls.ConfirmOption.CallBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.pnlObservaciones.Visible = False
        Me.txtObservaciones.Text = ""
    End Sub

    Protected Sub btnEliminaProceso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminaProceso.Click
        Me.MsgBox1.ShowConfirm("¿Desea eliminar el proceso de compra y todos los registros asociados?", "ELIMINAR_PROCESO", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        Select Case e.Key
            Case Is = "ELIMINAR_PROCESO"
                Dim mComProcesoCompra As New cPROCESOCOMPRAS
                mComProcesoCompra.eliminarProcesoCompleto(Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, _IDPROCESOCOMPRA)
                Response.Redirect("~/UACI/FrmMantProcesoCompra.aspx")
            Case Is = "ANULAR"
                Dim mComponente As New cPROCESOCOMPRAS
                Dim lEntidad As New PROCESOCOMPRAS
                lEntidad.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.PROCESODECOMPRAANULADO
                lEntidad.IDPROCESOCOMPRA = IDPROCESOCOMPRA
                lEntidad.IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
                lEntidad.ESTASINCRONIZADA = 0
                lEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                lEntidad.AUFECHAMODIFICACION = Now
                If mComponente.ActualizarEstado(lEntidad, 0) = 1 Then
                    Response.Redirect("~/UACI/FrmMantProcesoCompra.aspx")
                End If
            Case Is = "QUITAR"

                Dim IDSOLICITUD As Integer = gvSolicitudes.DataKeys(gvSolicitudes.SelectedRow.RowIndex).Values.Item("IDSOLICITUD")

                Dim mComSol As New cSOLICITUDES
                Dim lEntSol As New SOLICITUDES
                lEntSol.OBSERVACION = Me.txtObservaciones.Text
                lEntSol.AUFECHAMODIFICACION = Now
                lEntSol.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                lEntSol.IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
                lEntSol.ESTASINCRONIZADA = 0
                lEntSol.IDSOLICITUD = IDSOLICITUD

                mComSol.ActualizarObservacionSolicitud(lEntSol, Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO, IDSOLICITUD)

                Dim mComponente As New cPROCESOCOMPRAS
                mComponente.RechazarSolicitud(IDPROCESOCOMPRA, IDSOLICITUD, Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO)
                Me.MsgBox1.ShowAlert("Se ha desasociado la solicitud del proceso de compra", "", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                consultarSolicitudes()

                Me.pnlObservaciones.Visible = False
        End Select
    End Sub

End Class
