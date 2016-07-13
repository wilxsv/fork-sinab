Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.EnumHelpers

Partial Class ucInformacionNoAceptacionContrato
    Inherits System.Web.UI.UserControl

    Private _IDESTABLECIMIENTO As Integer
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _IDALMACEN As Integer
    Private _IDDETALLE As Integer
    Private _IDDOCUMENTO As Integer

    Private _IDMOVIMIENTO As Integer

#Region "Propiedades"

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

    Public Property IDPROVEEDOR() As Integer
        Get
            Return _IDPROVEEDOR
        End Get
        Set(ByVal value As Integer)
            _IDPROVEEDOR = value
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me.ViewState.Remove("IDPROVEEDOR")
            Me.ViewState.Add("IDPROVEEDOR", value)
        End Set
    End Property

    Public Property IDCONTRATO() As Integer
        Get
            Return _IDCONTRATO
        End Get
        Set(ByVal value As Integer)
            _IDCONTRATO = value
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me.ViewState.Remove("IDCONTRATO")
            Me.ViewState.Add("IDCONTRATO", value)
        End Set
    End Property

    Public Property IDALMACEN() As Integer
        Get
            Return _IDALMACEN
        End Get
        Set(ByVal value As Integer)
            _IDALMACEN = value
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me.ViewState.Remove("IDALMACEN")
            Me.ViewState.Add("IDALMACEN", value)
        End Set
    End Property

    Public Property IDDETALLE() As Integer
        Get
            Return _IDDETALLE
        End Get
        Set(ByVal value As Integer)
            _IDDETALLE = value
        End Set
    End Property

    Public Property IDDOCUMENTO() As Integer
        Get
            Return _IDDOCUMENTO
        End Get
        Set(ByVal value As Integer)
            _IDDOCUMENTO = value
        End Set
    End Property

    Public Property IDMOVIMIENTO() As Integer
        Get
            Return _IDMOVIMIENTO
        End Get
        Set(ByVal value As Integer)
            _IDMOVIMIENTO = value
            If Not Me.ViewState("IDMOVIMIENTO") Is Nothing Then Me.ViewState.Remove("IDMOVIMIENTO")
            Me.ViewState.Add("IDMOVIMIENTO", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.cvFechaDocumento.ValueToCompare = Now.Date
            Me.cvFechaNoAceptacion.ValueToCompare = Now.Date

            Me.ddlTIPODOCUMENTORECEPCION1.Recuperar()

            If Session.Item("GuardaAlmacen") = 1 Then Me.txtGuardalmacen.Text = Session.Item("NombreUsuario").ToString
        Else
            If Not Me.ViewState("IDESTABLECIMIENTO") Is Nothing Then Me._IDESTABLECIMIENTO = Me.ViewState("IDESTABLECIMIENTO")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me._IDCONTRATO = Me.ViewState("IDCONTRATO")
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me._IDALMACEN = Me.ViewState("IDALMACEN")
            If Not Me.ViewState("IDMOVIMIENTO") Is Nothing Then Me._IDMOVIMIENTO = Me.ViewState("IDMOVIMIENTO")
        End If
    End Sub

    Public Sub CargarDatos()
        Dim eC As New CONTRATOS
        Dim cC As New cCONTRATOS

        eC = cC.obtenerDatosContrato2(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO)

        If Not eC Is Nothing Then

            Me.txtModalidadCompra.Text = eC.DESCRIPCIONMODALIDADCOMPRA
            Me.txtNoModalidadCompra.Text = eC.NUMEROMODALIDADCOMPRA
            Me.txtFuenteFinanciamiento.Text = eC.FUENTESFINANCIAMIENTO
            Me.txtResponsableDistribucion.Text = eC.RESPONSABLEDISTRIBUCION
            Me.txtResolucionAdjudicacion.Text = eC.RESOLUCIONADJUDICACION
            Me.txtNoContratoOrdenCompra.Text = eC.NUMEROCONTRATO
            Me.txtProveedor.Text = eC.NOMBREPROVEEDOR
            Me.txtFechaDistribucion.Text = Format(eC.FECHADISTRIBUCION, "dd/MM/yyyy")

            Me.gvRenglones.DataSource = cC.ObtenerRenglonesPendientesTotales2(IDESTABLECIMIENTO, IDALMACEN, IDPROVEEDOR, IDCONTRATO)
            Me.gvRenglones.DataBind()

        End If
    End Sub

    Public Sub Limpiar()

        Me.IDESTABLECIMIENTO = 0
        Me.IDPROVEEDOR = 0
        Me.IDCONTRATO = 0
        Me.IDALMACEN = 0
        Me.IDMOVIMIENTO = 0

        gvRenglones.DataSource = Nothing
        gvRenglones.DataBind()
        gvRenglones.SelectedIndex = -1

        Me.txtDocumento.Text = String.Empty
        Me.txtMotivo.Text = String.Empty
        Me.txtDelegado.Text = String.Empty

    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim cM As New cMOVIMIENTOS
        Dim eM As New MOVIMIENTOS
        Dim cDM As New cDETALLEMOVIMIENTOS
        Dim cINA As New cINFORMESNOACEPTACION
        Dim eINA As New INFORMESNOACEPTACION

        eINA.IDALMACEN = Me.IDALMACEN
        eINA.ANIO = Me.cpFechaDocumento.SelectedDate.Year
        eINA.IDINFORME = 0
        eINA.IDESTABLECIMIENTO = Me.IDESTABLECIMIENTO
        eINA.IDPROVEEDOR = Me.IDPROVEEDOR
        eINA.IDCONTRATO = Me.IDCONTRATO
        eINA.RESPONSABLEPROVEEDOR = Me.txtDelegado.Text
        eINA.IDJEFEALMACEN = Nothing
        eINA.OBSERVACION = String.Empty
        eINA.MOTIVO = Me.txtMotivo.Text

        eINA.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eINA.AUFECHACREACION = Now()
        eINA.AUUSUARIOMODIFICACION = Nothing
        eINA.AUFECHAMODIFICACION = Nothing
        eINA.ESTASINCRONIZADA = 0

        cINA.ActualizarINFORMESNOACEPTACION(eINA)

        eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        eM.IDTIPOTRANSACCION = TiposTransaccion.InformeNoAceptacion
        eM.IDMOVIMIENTO = 0
        'eM.IDTIPODOCREF = 4
        eM.NUMERODOCREF = Me.txtNoContratoOrdenCompra.Text
        eM.IDALMACEN = eINA.IDALMACEN
        eM.ANIO = eINA.ANIO
        eM.IDDOCUMENTO = eINA.IDINFORME
        eM.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado
        eM.FECHAMOVIMIENTO = Me.cpFechaNoAceptacion.SelectedDate
        eM.IDESTABLECIMIENTODESTINO = Nothing
        eM.IDALMACENDESTINO = Nothing
        eM.IDUNIDADSOLICITA = Session.Item("IdDependencia")
        eM.TOTALMOVIMIENTO = 0
        eM.IDEMPLEADOSOLICITA = Nothing
        eM.IDEMPLEADOALMACEN = Nothing
        eM.EMPLEADOALMACEN = Me.txtGuardalmacen.Text
        'eM.CLASIFICACIONMOVIMIENTO = 
        'eM.RESPONSABLEDISTRIBUCION = 
        eM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        eM.AUFECHACREACION = Now()
        eM.AUUSUARIOMODIFICACION = Nothing
        eM.AUFECHAMODIFICACION = Nothing
        eM.ESTASINCRONIZADA = 0

        cM.ActualizarMOVIMIENTOS(eM)

        Me.IDMOVIMIENTO = eM.IDMOVIMIENTO

        For Each row As GridViewRow In gvRenglones.Rows

            If CType(row.FindControl("cbSeleccionado"), CheckBox).Checked() Then

                Dim eDM As New DETALLEMOVIMIENTOS

                eDM.IDESTABLECIMIENTO = eM.IDESTABLECIMIENTO
                eDM.IDTIPOTRANSACCION = eM.IDTIPOTRANSACCION
                eDM.IDMOVIMIENTO = eM.IDMOVIMIENTO
                eDM.IDDETALLEMOVIMIENTO = 0
                eDM.IDALMACEN = eM.IDALMACEN
                eDM.IDPRODUCTO = Me.gvRenglones.DataKeys(row.RowIndex).Values.Item("IDPRODUCTO")
                eDM.CANTIDAD = 0

                eDM.IDTIPODOCUMENTO = Me.ddlTIPODOCUMENTORECEPCION1.SelectedValue
                eDM.NUMEROFACTURA = Me.txtDocumento.Text
                eDM.FECHAFACTURA = Me.cpFechaDocumento.SelectedDate

                eDM.MONTO = 0
                eDM.RENGLON = Me.gvRenglones.DataKeys(row.RowIndex).Values.Item("RENGLON")
                eDM.IDLOTE = Nothing

                eDM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                eDM.AUFECHACREACION = Now()
                eDM.AUUSUARIOMODIFICACION = Nothing
                eDM.AUFECHAMODIFICACION = Nothing
                eDM.ESTASINCRONIZADA = 0

                cDM.ActualizarDETALLEMOVIMIENTOS(eDM)
            End If

        Next

        Me.btnGuardar.Enabled = False
        Me.btnImprimir.Enabled = True

        Me.MsgBox1.ShowAlert("Los datos se han guardado satisfactoriamente. Puede imprimir el informe de no aceptación.", "a", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)

    End Sub

    Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'>window.open('" + Request.ApplicationPath + "/Reportes/FrmRptInformeNoAceptacion.aspx?IdEMov=" + Session.Item("IdEstablecimiento").ToString + "&IdMov=" + Me.IDMOVIMIENTO.ToString + "&IdE=" & Me.IDESTABLECIMIENTO.ToString & "&IdP=" & Me.IDPROVEEDOR.ToString & "&IdC=" & Me.IDCONTRATO.ToString & "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600'); </script>")
    End Sub

End Class
