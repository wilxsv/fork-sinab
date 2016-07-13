Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmCancelarRecepciones
    Inherits System.Web.UI.Page

    Private _CancelarRenglon As Boolean = False
    Private _Anular As Boolean = False

#Region " Propiedades "

    Public Property CancelarRenglon() As Boolean
        Get
            Return Me._CancelarRenglon
        End Get
        Set(ByVal Value As Boolean)
            Me._CancelarRenglon = Value
            If Not Me.ViewState("CancelarRenglon") Is Nothing Then Me.ViewState.Remove("CancelarRenglon")
            Me.ViewState.Add("CancelarRenglon", Value)
        End Set
    End Property

    Public Property Anular() As Boolean
        Get
            Return Me._Anular
        End Get
        Set(ByVal Value As Boolean)
            Me._Anular = Value
            If Not Me.ViewState("Anular") Is Nothing Then Me.ViewState.Remove("Anular")
            Me.ViewState.Add("Anular", Value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            Me.ucContratosProcesoCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            Me.ucContratosProcesoCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")

            Me.ucContratosProcesoCompra1.CargarDatos()

            Me.ucRenglonesContrato1.Visible = False
        Else
            If Not Me.ViewState("CancelarRenglon") Is Nothing Then Me._CancelarRenglon = Me.ViewState("CancelarRenglon")
            If Not Me.ViewState("Anular") Is Nothing Then Me._Anular = Me.ViewState("Anular")
        End If

    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucContratosProcesoCompra1_SelectedIndexChanged() Handles ucContratosProcesoCompra1.SelectedIndexChanged

        Me.ucContratosProcesoCompra1.CargarDatos()

        If Me.ucContratosProcesoCompra1.IDCONTRATO = 0 Then
            Me.ucRenglonesContrato1.LimpiarRenglones()
            Me.ucRenglonesContrato1.Visible = False

            Me.plLotes.Visible = False
            Me.plMotivo.Visible = False
            Me.plConsultas.Visible = False
        Else
            CargarRenglones()
        End If
    End Sub

    Protected Sub ucRenglonesContrato1_SelectedIndexChanged() Handles ucRenglonesContrato1.SelectedIndexChanged

        Me.plLotes.Visible = False
        Me.plMotivo.Visible = False
        Me.plConsultas.Visible = False

        If Me.ucRenglonesContrato1.RENGLON = 0 Then
            MostrarBotones(False, False, False, False, False, False)
        Else
            If Me.ucRenglonesContrato1.ESTAHABILITADO = 1 Then
                Me.lblMOTIVOCANCELACION.Visible = False
                Me.txtMOTIVOCANCELACION.Visible = False

                Me.txtMOTIVO.Text = String.Empty

                MostrarBotones(False, True, True, False, False, True)
            Else
                Dim cCP As New cCANCELACIONPRODUCTO
                Dim eCP As New CANCELACIONPRODUCTO

                eCP = cCP.ObtenerCANCELACIONPRODUCTO(ucRenglonesContrato1.IDESTABLECIMIENTO, ucRenglonesContrato1.IDPROVEEDOR, ucRenglonesContrato1.IDCONTRATO, ucRenglonesContrato1.RENGLON, ucRenglonesContrato1.IDCANCELACION)

                Me.txtMOTIVOCANCELACION.Text = eCP.MOTIVOCANCELACION
                Me.lblMOTIVOCANCELACION.Visible = True
                Me.txtMOTIVOCANCELACION.Visible = True

                Me.txtMOTIVO.Text = String.Empty

                Me.plMotivo.Visible = True

                MostrarBotones(True, False, False, False, True, True)
            End If
        End If

        Me.ucRenglonesContrato1.CargarDatos()

    End Sub

    Private Sub CargarRenglones()
        Me.ucRenglonesContrato1.IDESTABLECIMIENTO = ucContratosProcesoCompra1.IDESTABLECIMIENTO
        Me.ucRenglonesContrato1.IDPROVEEDOR = ucContratosProcesoCompra1.IDPROVEEDOR
        Me.ucRenglonesContrato1.IDCONTRATO = ucContratosProcesoCompra1.IDCONTRATO

        Me.ucRenglonesContrato1.Visible = True
        Me.ucRenglonesContrato1.CargarDatos()
    End Sub

    Private Sub CargarLotes()

        Dim cIM As New cINFORMEMUESTRAS

        Dim ds As Data.DataSet
        ds = cIM.ObtenerLotesCancelacion(ucRenglonesContrato1.IDESTABLECIMIENTO, ucRenglonesContrato1.IDPROVEEDOR, ucRenglonesContrato1.IDCONTRATO, ucRenglonesContrato1.RENGLON)

        gvLotes.DataSource = ds
        gvLotes.DataBind()

        Me.plLotes.Visible = True

    End Sub

    Protected Sub btnCancelarRenglon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarRenglon.Click
        CancelarRenglon = True
        Me.plMotivo.Visible = True
        MostrarBotones(False, False, False, True, True, False)
    End Sub

    Protected Sub btnCancelarLotes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarLotes.Click

        CancelarRenglon = False

        CargarLotes()

        Me.plLotes.Visible = True

        If Me.gvLotes.Rows.Count = 0 Then
            Me.plMotivo.Visible = False
            MostrarBotones(False, False, False, False, True, False)
        Else
            Me.plMotivo.Visible = True
            MostrarBotones(False, False, False, True, True, False)
        End If

    End Sub

    Public Sub Actualizar(ByVal ESTAHABILITADO As Integer)

        Dim cCP As New cCANCELACIONPRODUCTO
        Dim eCP As New CANCELACIONPRODUCTO

        eCP.IDESTABLECIMIENTO = ucRenglonesContrato1.IDESTABLECIMIENTO
        eCP.IDPROVEEDOR = ucRenglonesContrato1.IDPROVEEDOR
        eCP.IDCONTRATO = ucRenglonesContrato1.IDCONTRATO
        eCP.RENGLON = ucRenglonesContrato1.RENGLON

        Dim lDCP As New listaDETALLECANCELACIONPRODUCTO

        If ESTAHABILITADO = 1 And Not gvLotes.Visible Then
            'habilita un renglón, se actualiza el registro existente
            eCP.IDCANCELACION = ucRenglonesContrato1.IDCANCELACION
            cCP.ObtenerCANCELACIONPRODUCTO(eCP)

            eCP.FECHAANULACION = Now
            eCP.MOTIVOANULACION = Me.txtMOTIVO.Text

            eCP.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eCP.AUFECHAMODIFICACION = Now
        Else
            'nuevo registro
            eCP.FECHACANCELACION = Now
            eCP.MOTIVOCANCELACION = Me.txtMOTIVO.Text

            eCP.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eCP.AUFECHACREACION = Now

            'detalle por lote
            If gvLotes.Visible Then

                For Each row As GridViewRow In Me.gvLotes.Rows()

                    If row.RowType = DataControlRowType.DataRow Then

                        Dim eDCP As New DETALLECANCELACIONPRODUCTO

                        Dim cb As CheckBox = row.FindControl("cbHabilitado")

                        eDCP.IDESTABLECIMIENTO = eCP.IDESTABLECIMIENTO
                        eDCP.IDPROVEEDOR = eCP.IDPROVEEDOR
                        eDCP.IDCONTRATO = eCP.IDCONTRATO
                        eDCP.RENGLON = eCP.RENGLON
                        eDCP.LOTE = Me.gvLotes.DataKeys(row.RowIndex).Values(0)
                        eDCP.ESTAHABILITADO = IIf(cb.Checked, 1, 0)
                        eDCP.AUUSUARIOCREACION = eCP.AUUSUARIOCREACION
                        eDCP.AUFECHACREACION = eCP.AUFECHACREACION
                        eDCP.AUUSUARIOMODIFICACION = eCP.AUUSUARIOMODIFICACION
                        eDCP.AUFECHAMODIFICACION = eCP.AUFECHAMODIFICACION
                        eDCP.ESTASINCRONIZADA = 0

                        lDCP.Add(eDCP)

                    End If
                Next
            End If

        End If

        eCP.ESTASINCRONIZADA = 0

        cCP.ActualizarCancelacionDetalleLote(eCP, lDCP, ESTAHABILITADO)

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.plLotes.Visible = False
        Me.plMotivo.Visible = False
        Me.plConsultas.Visible = False
        MostrarBotones(False, False, False, False, False, False)

        Me.ucRenglonesContrato1.LimpiarRenglones()
        CargarRenglones()
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If CancelarRenglon Then
            Actualizar(0)
        Else
            Actualizar(ucRenglonesContrato1.ESTAHABILITADO)
        End If

        Me.plLotes.Visible = False
        Me.plMotivo.Visible = False
        Me.plConsultas.Visible = False
        MostrarBotones(False, False, False, False, False, False)

        Me.ucRenglonesContrato1.LimpiarRenglones()
        CargarRenglones()
    End Sub

    Private Sub MostrarBotones(ByVal AnularCancelacion As Boolean, ByVal CancelarRenglon As Boolean, ByVal CancelarLotes As Boolean, ByVal Guardar As Boolean, ByVal Cancelar As Boolean, ByVal Consultar As Boolean)
        Me.btnAnularCancelacion.Visible = AnularCancelacion
        Me.btnCancelarRenglon.Visible = CancelarRenglon
        Me.btnCancelarLotes.Visible = CancelarLotes
        Me.btnGuardar.Visible = Guardar
        Me.btnCancelar.Visible = Cancelar

        Me.btnConsultar.Visible = Consultar
        Me.btnImprimirCancelaciones.Visible = False
    End Sub

    Protected Sub btnAnularCancelacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnularCancelacion.Click
        Actualizar(1)

        Me.plLotes.Visible = False
        Me.plMotivo.Visible = False
        Me.plConsultas.Visible = False
        MostrarBotones(False, False, False, False, False, False)

        Me.ucRenglonesContrato1.LimpiarRenglones()
        CargarRenglones()
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        Me.plLotes.Visible = False
        Me.plMotivo.Visible = False
        Me.plConsultas.Visible = False

        MostrarBotones(False, False, False, False, True, False)

        Dim cCP As New cCANCELACIONPRODUCTO
        Dim ds As Data.DataSet
        ds = cCP.ObtenerDataSetPorId(ucRenglonesContrato1.IDESTABLECIMIENTO, ucRenglonesContrato1.IDPROVEEDOR, ucRenglonesContrato1.IDCONTRATO, ucRenglonesContrato1.RENGLON)
        Me.gvCancelaciones.DataSource = ds
        Me.gvCancelaciones.DataBind()

        If ds.Tables(0).Rows.Count = 0 Then
            Me.btnImprimirCancelaciones.OnClientClick = ""
        Else
            Dim cad = "/Reportes/FrmRptCancelacionesPorRenglon.aspx?idE=" + ucRenglonesContrato1.IDESTABLECIMIENTO.ToString + "&idP=" + ucRenglonesContrato1.IDPROVEEDOR.ToString + "&idC=" + ucRenglonesContrato1.IDCONTRATO.ToString + "&idR=" + ucRenglonesContrato1.RENGLON.ToString
            Me.btnImprimirCancelaciones.OnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
            '"window.open('" + Request.ApplicationPath + "/Reportes/FrmRptCancelacionesPorRenglon.aspx?idE=" + ucRenglonesContrato1.IDESTABLECIMIENTO.ToString + "&idP=" + ucRenglonesContrato1.IDPROVEEDOR.ToString + "&idC=" + ucRenglonesContrato1.IDCONTRATO.ToString + "&idR=" + ucRenglonesContrato1.RENGLON.ToString + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600');return;"
            Me.btnImprimirCancelaciones.Visible = True
        End If

        Me.plConsultas.Visible = True
    End Sub

    Protected Sub gvCancelaciones_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCancelaciones.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim IDCANCELACION As Integer = Me.gvCancelaciones.DataKeys(e.Row.RowIndex).Values(0)

            Dim cDCP As New cDETALLECANCELACIONPRODUCTO
            Dim ds As Data.DataSet
            ds = cDCP.ObtenerDataSetPorId(ucRenglonesContrato1.IDESTABLECIMIENTO, ucRenglonesContrato1.IDPROVEEDOR, ucRenglonesContrato1.IDCONTRATO, ucRenglonesContrato1.RENGLON, IDCANCELACION)

            Dim gv As GridView = CType(e.Row.Cells(4).Controls(1), GridView)
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

End Class
