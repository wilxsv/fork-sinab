Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO


Partial Class FrmAnularTransaccionesDetalle
    Inherits System.Web.UI.Page

    Private mCompMovimientos As New cMOVIMIENTOS
    Private mEntMovimientos As New MOVIMIENTOS
    Private mCompDetalleMovimiento As New cDETALLEMOVIMIENTOS
    Private mEntDetalleMovimiento As New DETALLEMOVIMIENTOS
    Private mCompUtilerias As New cUTILERIAS
    Private mCompLote As New cLOTES
    Private mCompVale As New cVALESSALIDA
    Private mEntVale As New VALESSALIDA

    Private _Operacion As String
    Private _IDMOVIMIENTO As Int64
    Private _IDTIPOTRANSACCION As Int64

#Region " Propiedades "

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

    Public Property IDTIPOTRANSACCION() As Integer
        Get
            Return _IDTIPOTRANSACCION
        End Get
        Set(ByVal value As Integer)
            _IDTIPOTRANSACCION = value
            If Not Me.ViewState("IDTIPOTRANSACCION") Is Nothing Then Me.ViewState.Remove("IDTIPOTRANSACCION")
            Me.ViewState.Add("IDTIPOTRANSACCION", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Me.Master.ControlMenu.Visible = False

            IDMOVIMIENTO = Request.QueryString("IdMovimiento")
            IDTIPOTRANSACCION = Request.QueryString("IdTipo")

            Me.ddlTIPOTRANSACCIONES1.Recuperar()
            Me.ddlTIPOTRANSACCIONES1.SelectedValue = IDTIPOTRANSACCION
            Me.ddlTIPOTRANSACCIONES1.Enabled = False
            Me.ddlESTABLECIMIENTOS1.Recuperar()

            Me.IDMOVIMIENTO = IDMOVIMIENTO
            CargarDatos()

        Else
            If Not Me.ViewState("IDMOVIMIENTO") Is Nothing Then Me._IDMOVIMIENTO = Me.ViewState("IDMOVIMIENTO")
            If Not Me.ViewState("IDTIPOTRANSACCION") Is Nothing Then Me._IDTIPOTRANSACCION = Me.ViewState("IDTIPOTRANSACCION")
        End If

    End Sub

    Private Function CargarDatos() As Int16

        'Recuperando la información del movimiento a editar
        mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntMovimientos.IDTIPOTRANSACCION = Me.IDTIPOTRANSACCION
        mEntMovimientos.IDMOVIMIENTO = Me.IDMOVIMIENTO
        mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)

        Me.ddlTIPOTRANSACCIONES1.SelectedValue = mEntMovimientos.IDTIPOTRANSACCION
        Me.txtDocumento.Text = mEntMovimientos.IDDOCUMENTO
        Me.CalendarFechaDespacho.SelectedDate = mEntMovimientos.FECHAMOVIMIENTO
        Me.ddlALMACENES1.SelectedValue = mEntMovimientos.IDALMACEN
        Me.ddlALMACENES2.SelectedValue = mEntMovimientos.IDALMACENDESTINO

        'Carga de la información del vale de salida asociado
        mEntVale.IDALMACEN = mEntMovimientos.IDALMACEN
        mEntVale.IDVALE = mEntMovimientos.IDDOCUMENTO
        mCompVale.ObtenerVALESSALIDA(mEntVale)
        Me.txtObservacion.Text = mEntVale.OBSERVACION

        'Carga del detalle del movimiento en el datagrid
        Me.dgLista.DataSource = mCompDetalleMovimiento.ObtenerDetalleMovimientosDS(mEntMovimientos.IDESTABLECIMIENTO, mEntMovimientos.IDTIPOTRANSACCION, mEntMovimientos.IDMOVIMIENTO)
        Me.dgLista.DataBind()

    End Function

    Protected Sub ImgbCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbCerrar.Click
        Try
            If mCompMovimientos.AnularDocumentoValidacion(Session.Item("IdEstablecimiento"), IDTIPOTRANSACCION, IDMOVIMIENTO) = 1 Then
                MsgBox1.ShowConfirm("¿Confirma que desea anular el documento actual?", "Q1", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo)
            Else
                MsgBox1.ShowAlert("El documento no puede ser anulado porque tiene documentos enlazados activos, para poder anular este documento primero debe eliminarse el documento enlazado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
            End If
        Catch ex As Exception
            MsgBox1.ShowAlert("El documento no pueder ser anulado ya que no fue generado correctamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
        End Try

        Me.plEncabezado.Visible = False
        Me.dgLista.Visible = False
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

        If e.Key = "Q1" Then 'Verifica si el usuario desea anular el documento

            'Recuperando la información del documento a ser anulado
            mEntMovimientos.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            mEntMovimientos.IDTIPOTRANSACCION = IDTIPOTRANSACCION
            mEntMovimientos.IDMOVIMIENTO = Me.IDMOVIMIENTO
            mCompMovimientos.ObtenerMOVIMIENTOS(mEntMovimientos)

            mEntMovimientos.IDESTADO = eESTADOSMOVIMIENTOS.Anulado 'Cambio del estado del documento

            mEntMovimientos.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            mEntMovimientos.AUFECHAMODIFICACION = Now()
            mEntMovimientos.ESTASINCRONIZADA = 0
            mCompMovimientos.ActualizarMOVIMIENTOS(mEntMovimientos) 'Invoca el metodo de actualización de datos

            Dim ITIPOOPERACION As Int16

            Dim ds As Data.DataSet
            ds = mCompDetalleMovimiento.ObtenerDataSetPorId(mEntMovimientos.IDESTABLECIMIENTO, mEntMovimientos.IDTIPOTRANSACCION, mEntMovimientos.IDMOVIMIENTO)
            ITIPOOPERACION = mCompUtilerias.ObtenerTipoOperacion(mEntMovimientos.IDTIPOTRANSACCION)

            For iFila As Int16 = 0 To ds.Tables(0).Rows.Count - 1
                mCompUtilerias.ActualizarCantidadDisponible(mEntMovimientos.IDALMACEN, ds.Tables(0).Rows(iFila).Item("IDLOTE"), ITIPOOPERACION, ds.Tables(0).Rows(iFila).Item("CANTIDAD"))
            Next

            MsgBox1.ShowAlert("El documento ha sido anulado satisfactoriamente", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)

        End If
    End Sub

    Protected Sub ImgbImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbImprimir.Click
        Select Case Me.ddlTIPOTRANSACCIONES1.SelectedValue
            Case Is = 1
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptRequisicion.aspx?IdMovimiento=" + Me.IDMOVIMIENTO + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
            Case Is = 2
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptValeSalida.aspx?IdMovimiento=" + Me.IDMOVIMIENTO + "&" + Me.ddlALMACENES1.SelectedValue.ToString + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
            Case Is = 3
                Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptDevolucionProductos.aspx?IdMovimiento=" + Me.IDMOVIMIENTO + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
        End Select
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

End Class
