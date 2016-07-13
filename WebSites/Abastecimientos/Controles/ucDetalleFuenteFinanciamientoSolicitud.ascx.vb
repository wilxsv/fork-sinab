'INGRESO DE SOLICITUD DE COMPRAS
'CU-ESTA0001
'Ing. Yessenia Pennelope Henriquez Duran
'control de usaurio para detalle de fuentes de solicitudes de compra
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data

Partial Class ucDetalleFuenteFinanciamientoSolicitud
    Inherits System.Web.UI.UserControl
    'declaracion e incializacion de variables y eventos

    Public Event Eliminado(ByVal CODIGOENZABEZADODOCUMENTO As Int32)
    Public Event GuardoFuente()
    Private _Enabled As Boolean
    Private _PermitirEliminar As Boolean = True
    Private _PermitirGuardar As Boolean = True
    Private _PermitirAgregar As Boolean = True
    Dim mComponente As New cFUENTEFINANCIAMIENTOSOLICITUDES
    Dim mCompDetalleSolicitud As New cDETALLESOLICITUDES

    Private eFF As New FUENTEFINANCIAMIENTOSOLICITUDES

    Public Sub ObtenerDetalleDocumento(ByVal CODIGOENCABEZADODOCUMENTO As Int32)
        'llenar grid con detalle de fuente de financiamiento
        Me.Label_CODIGOENZABEZADODOCUMENTO.Text = CODIGOENCABEZADODOCUMENTO.ToString
        Me.gvLista.DataSource = mComponente.ObtenerListaXSolicitud(Session.Item("IdEstablecimiento"), CODIGOENCABEZADODOCUMENTO)

        Me.TxtMontoTotal.Text = Me.mComponente.CalcularMontoTotalFuenteSolicitud(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))
        Me.LblPT.Text = Me.mComponente.CalcularPorcentajeTotalFuenteSolicitud(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

    End Sub

    Public Property Enabled() As Boolean 'habilitar
        Get
            Return Me._Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._Enabled = Value
            Me.HabilitarEdicion(Me._Enabled)
        End Set
    End Property

    Protected Sub dgLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvLista.RowDataBound
        'al momento cargar registros en el grid
        If e.Row.RowType = DataControlRowType.DataRow Then

            'carga listado de fuentes
            Dim mDdlFUENTES As ABASTECIMIENTOS.WUC.ddlFUENTEFINANCIAMIENTOS
            mDdlFUENTES = e.Row.FindControl("DdlFUENTEFINANCIAMIENTOS1")
            mDdlFUENTES.Recuperar()

            Dim IDFUENTEFINANCIAMIENTO As Integer = gvLista.DataKeys(e.Row.RowIndex).Values.Item("IDFUENTEFINANCIAMIENTO")
            mDdlFUENTES.SelectedValue = IDFUENTEFINANCIAMIENTO
        End If
    End Sub

    Protected Sub dgLista_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvLista.RowDeleting
        'al momento de eliminar fuente
        Dim IDFUENTEFINANCIAMIENTO As Integer = gvLista.DataKeys(e.RowIndex).Values.Item("IDFUENTEFINANCIAMIENTO")
        If mComponente.EliminarFUENTEFINANCIAMIENTOSOLICITUDES(Session.Item("IdEstablecimiento"), CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), IDFUENTEFINANCIAMIENTO) = 0 Then
            MsgBox1.ShowAlert(" Errores al momento de eliminar la fuente de financiamiento", "error2", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
        Else
            Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
            RaiseEvent Eliminado(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        End If
    End Sub

    Public Sub Agregar()
        'al presionar agregar 
        Me.Label_CODIGOENZABEZADODOCUMENTO.Text = Session.Item("idDoc")
        Session.Item("estado") = "nuevo"
        Session.Item("IdEncabezado") = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        Me.LblMonto.Text = mCompDetalleSolicitud.CalcularMontoTotalSolicitud(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
        Me.UcAgregarFuente1.asignarmonto(Me.LblMonto.Text)
        Me.UcAgregarFuente1.Visible = True
        Me.gvLista.Visible = True
        RecalcularPorcentaje()
        'Me.ImgbAgregar.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar control
        Session.Item("IdEncabezado") = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        RecalcularPorcentaje()
        Me.UcAgregarFuente1.Visible = False
        Me.LblMonto.Text = mCompDetalleSolicitud.CalcularMontoTotalSolicitud(Me.Label_CODIGOENZABEZADODOCUMENTO.Text, Session.Item("IdEstablecimiento"))
        Me.UcAgregarFuente1.ObtenerMonto(Me.LblMonto.Text)
        Me.TxtMontoTotal.Text = Me.mComponente.CalcularMontoTotalFuenteSolicitud(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))
        Me.LblPT.Text = Me.mComponente.CalcularPorcentajeTotalFuenteSolicitud(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))
    End Sub

    Protected Sub ImgbAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbAgregar.Click
        'al momento de agregar
        Session.Item("estado") = "nuevo"
        Session.Item("IdEncabezado") = Me.Label_CODIGOENZABEZADODOCUMENTO.Text
        Me.UcAgregarFuente1.Visible = True
    End Sub

    Public Sub asignarmonto(ByVal monto As Double)
        Me.LblMonto.Text = monto
        Me.UcAgregarFuente1.asignarmonto(monto)
    End Sub

    Private Sub HabilitarEdicion(ByVal edicion As Boolean)
        'habilita los campos a edicion
        Me.HabilitarGrid(edicion)
        Me.PermitirAgregar = edicion
        Me.PermitirEliminar = edicion
        Me.PermitirGuardar = edicion
    End Sub

    Public Property PermitirEliminar() As Boolean
        'permite eliminar
        Get
            Return _PermitirEliminar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirEliminar = Value
            'Me.gvLista.Columns(Me.gvLista.Columns.Count - 1).Visible = Value
            Me.gvLista.AutoGenerateDeleteButton = False
            Dim j As Integer
            For j = 0 To gvLista.Rows.Count - 1
                CType(gvLista.Rows(j).FindControl("TxtMonto"), TextBox).Enabled = False
            Next
        End Set
    End Property

    Public Property PermitirGuardar() As Boolean
        'permite guardar
        Get
            Return _PermitirGuardar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirGuardar = Value
            'Me.gvLista.Columns(Me.gvLista.Columns.Count - 2).Visible = Value
        End Set
    End Property

    Public Property PermitirAgregar() As Boolean
        'permite agregar
        Get
            Return _PermitirAgregar
        End Get
        Set(ByVal Value As Boolean)
            _PermitirAgregar = Value
            Me.ImgbAgregar.Visible = _PermitirAgregar
        End Set
    End Property

    Private Sub HabilitarGrid(ByVal edicion As Boolean)
        'habilitar campos a editar en grid
        Dim j As Integer
        For j = 0 To gvLista.Rows.Count - 1
            CType(gvLista.Rows(j).FindControl("TxtMontoParticipacion"), TextBox).Enabled = edicion
            CType(gvLista.Rows(j).FindControl("DdlFUENTEFINANCIAMIENTOS1"), DropDownList).Enabled = edicion
        Next
    End Sub

    Protected Sub dgLista_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvLista.RowUpdating
        'al momento de actualizar registro en el grid

        Dim total As Double
        Dim montoTemporal As Double
        total = 0
        Dim porcentajeactual As Double
        Dim porcentajereal As Double
        Dim porcentajeTemporal As Double
        porcentajeactual = 0

        porcentajereal = Me.mComponente.CalcularPorcentajeTotalFuenteSolicitud(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))

        If Right(CType(gvLista.Rows(e.RowIndex).FindControl("TxtMontoParticipacion"), TextBox).Text, Len(CType(gvLista.Rows(e.RowIndex).FindControl("TxtMontoParticipacion"), TextBox).Text) - 1) >= 1 Then

            eFF.IDSOLICITUD = (CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
            eFF.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            eFF.IDFUENTEFINANCIAMIENTO = CType(gvLista.Rows(e.RowIndex).FindControl("DdlFUENTEFINANCIAMIENTOS1"), DropDownList).SelectedValue
            mComponente.ObtenerFUENTEFINANCIAMIENTOSOLICITUDES(eFF)
            porcentajeTemporal = eFF.PORCENTAJEPARTICIPACION
            porcentajereal = porcentajereal - porcentajeTemporal

            montoTemporal = Right(CType(gvLista.Rows(e.RowIndex).FindControl("TxtMontoParticipacion"), TextBox).Text, Len(CType(gvLista.Rows(e.RowIndex).FindControl("TxtMontoParticipacion"), TextBox).Text) - 1)

            eFF.MONTOPARTICIPACION = montoTemporal
            total = total + montoTemporal

            Dim porcentaje As TextBox = CType(gvLista.Rows(e.RowIndex).FindControl("TxtPorcentaje"), TextBox)
            Dim MontoParticipacion As TextBox = CType(gvLista.Rows(e.RowIndex).FindControl("TxtMontoParticipacion"), TextBox)

            porcentaje.Text = (MontoParticipacion.Text / Me.LblMonto.Text) * 100
            porcentajeactual = porcentajereal + (porcentaje.Text)

            eFF.PORCENTAJEPARTICIPACION = (porcentaje.Text)
            eFF.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            eFF.AUFECHAMODIFICACION = Now()
            eFF.ESTASINCRONIZADA = 0

            If porcentajeactual > 100 Then
                MsgBox1.ShowAlert("El porcentaje de participacion supera el 100 %", "B", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Else
                If mComponente.ActualizarFUENTEFINANCIAMIENTOSOLICITUDES(eFF) Then

                    Me.TxtMontoTotal.Text = Me.mComponente.CalcularMontoTotalFuenteSolicitud(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))
                    Me.LblPT.Text = Me.mComponente.CalcularPorcentajeTotalFuenteSolicitud(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))

                    RaiseEvent GuardoFuente()

                Else
                    MsgBox1.ShowAlert(" Errores al momento de guardar las modificaciones de la solitud", "error1", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Exclamation)
                End If
            End If
        Else
            MsgBox1.ShowAlert("El monto no puede ser 0", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End If

        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))

    End Sub

    Protected Sub UcAgregarFuente1_Agregar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcAgregarFuente1.Agregar
        'al momento de agregar fuente
        Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        Me.gvLista.Visible = True
        Me.ImgbAgregar.Visible = True
        Me.UcAgregarFuente1.asignarmonto(Me.LblMonto.Text)
    End Sub

    Protected Sub UcAgregarFuente1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcAgregarFuente1.Cancelar
        'al momento de cancelar
        Me.gvLista.Visible = True
        Me.ImgbAgregar.Visible = True
        Me.UcAgregarFuente1.asignarmonto(Me.LblMonto.Text)
    End Sub

    Protected Sub UcAgregarFuente1_ErrorEvent(ByVal errorMessage As String) Handles UcAgregarFuente1.ErrorEvent
        'evento error
        MsgBox1.ShowAlert(errorMessage, "D", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Me.ImgbAgregar.Visible = True
    End Sub

    Public Sub RecalcularPorcentaje()
        If mComponente.ExisteFuentesAsociadasSolicitud(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento")) Then

            Dim r As DataRow
            Me.LblMonto.Text = mCompDetalleSolicitud.CalcularMontoTotalSolicitud(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))
            Me.UcAgregarFuente1.asignarmonto(Me.LblMonto.Text)
            Me.TxtMontoTotal.Text = Me.mComponente.CalcularMontoTotalFuenteSolicitud(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text), Session.Item("IdEstablecimiento"))

            Dim ds As DataSet
            ds = mComponente.ObtenerDatasetFuentesPorSolicitud(Session.Item("IdEstablecimiento"), CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))

            For Each r In ds.Tables(0).Rows
                eFF.IDSOLICITUD = (CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
                eFF.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                eFF.IDFUENTEFINANCIAMIENTO = r("IDFUENTEFINANCIAMIENTO")
                mComponente.ObtenerFUENTEFINANCIAMIENTOSOLICITUDES(eFF)
                eFF.PORCENTAJEPARTICIPACION = Math.Round(((eFF.MONTOPARTICIPACION / Me.LblMonto.Text) * 100), 2)
                eFF.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                eFF.AUFECHAMODIFICACION = Now()
                eFF.ESTASINCRONIZADA = 0
                mComponente.ActualizarFUENTEFINANCIAMIENTOSOLICITUDES(eFF)
            Next r
            Me.ObtenerDetalleDocumento(CInt(Me.Label_CODIGOENZABEZADODOCUMENTO.Text))
        End If
    End Sub

End Class
