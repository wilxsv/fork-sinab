Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports CrystalDecisions.Web.Services
Imports SINAB_Utils.MessageBox
Imports SINAB_Utils.Utils

Partial Class FrmPublicarBases
    Inherits System.Web.UI.Page

    Private cPC As New cPROCESOCOMPRAS
    Private cOPC As New cOBSERVACIONPROCESOSCOMPRAS
    Private ePC As PROCESOCOMPRAS
    Private eOPC As OBSERVACIONPROCESOSCOMPRAS

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            CargarDatos()
        Else
            If ConfirmTarget = "Confirmar" Then
                GuardarBase()
            End If

            If ConfirmTarget = "Publicar" Then
                PublicarBases()
            End If

        End If
    End Sub

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub CargarDatos()
        ePC = New PROCESOCOMPRAS
        ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")
        ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        If cPC.ObtenerPROCESOCOMPRAS(ePC) <> 1 Then
            'Dim e As EventArgs
            'RaiseEvent ErrorEvent("Error al obtener Registro.")
            ' Return
        End If
        'Me.lblNoProcesoCompra.Text = Request.QueryString("idProc")

        'Me.lblFechaRecibidaSolCompra.Text = mEntidadProcesoCompra.FECHARECEPCIONSOLICITUDCOMPRA

        Dim dso As New Data.DataSet
        cPC.ObtenerCodigoyTipoLicitacion(Session("IdEstablecimiento"), Request.QueryString("idProc"), dso)

        Me.Label18.Text = dso.Tables(0).Rows(0).Item(1)

        Me.FechaInicioProcCompra.Text = ePC.FECHAINICIOPROCESOCOMPRA
        Me.FechaElaboracionBases.Text = CDate(ePC.FECHAELABORACIONBASE).ToShortDateString
        Me.lblFechaAprobacionBase.Text = CDate(ePC.FECHAAPROBACIONBASE).ToShortDateString

        Me.CPFechaEnvioNota.Text = ePC.FECHAENVIONOTA.ToShortDateString()
        Me.CPFechaPublicacion.Text = ePC.FECHAPUBLICACION.ToShortDateString()
        Me.NBCostoBases.Text = ePC.COSTOBASE

        Me.txtLugarRetirobases.Text = ePC.LUGARRETIROBASE
        Me.CPFechaInicioBase.SelectedDate = ePC.FECHAHORAINICIORETIRO
        Me.tpHoraInicioBase.SelectedTime = ePC.FECHAHORAINICIORETIRO
        Me.cpFechaFinRetiroBase.SelectedDate = ePC.FECHAHORAFINRETIRO
        Me.tpHoraFinBase.SelectedTime = ePC.FECHAHORAFINRETIRO

        Me.lblLugarRecepcion.Text = ePC.LUGARRECEPCIONOFERTA
        Me.lblFechaHoraInicioRecepcion.Text = ePC.FECHAHORAINICIORECEPCION
        Me.CompareValidator2.ValueToCompare = ePC.FECHAHORAINICIORECEPCION.Date
        Me.CompareValidator4.ValueToCompare = ePC.FECHAHORAINICIORECEPCION.Date
        Me.lblFechaHoraFinRecepcion.Text = ePC.FECHAHORAFINRECEPCION

        Me.lblLugarAperturaBase.Text = ePC.LUGARAPERTURABASE
        Me.lblFechaHoraInicioApertura.Text = ePC.FECHAHORAINICIOAPERTURA
        Me.lblFechaHoraFinApertura.Text = ePC.FECHAHORAFINAPERTURA.Date

        eOPC = New OBSERVACIONPROCESOSCOMPRAS
        eOPC.IDPROCESO = Request.QueryString("idProc")
        eOPC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        eOPC.IDESTADO = 2

        cOPC.ObtenerOBSERVACIONPROCESOSCOMPRAS(eOPC)

        Me.txtObservaciones.Text = eOPC.OBSERVACION

        Me.UcVistaDetalleSolicProcesCompra1.IDPROCESOCOMPRA = Request.QueryString("idProc")
        Me.UcVistaDetalleSolicProcesCompra1.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        Me.UcVistaDetalleSolicProcesCompra1.Consultar()
        Me.UcVistaDetalleSolicProcesCompra1.BtnQuitarSolicitudEnabled = False
        Me.UcVistaDetalleSolicProcesCompra1.BtnAnularProcesoEnabled = False
    End Sub


    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If Me.NBCostoBases.Text = "" Or Me.txtLugarRetirobases.Text = "" Then
            Alert("Falta completar información requerida.", "Alerta")
            'Me.MsgBox1.ShowAlert("Falta completar información requerida.", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
            Exit Sub
        End If
        Confirm("Esta seguro de guardar esta información para la publicación de las bases?", "Confirmar", OptionPostBack.YesPostBack)
        'Me.MsgBox1.ShowConfirm("Esta seguro de guardar esta información para la publicación de las bases?", "X", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_CallBackOnNo)

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If cPC.ChequearEstadosSolicitudes(Request.QueryString("idProc"), Session("IdEstablecimiento")) = False Then
            'Me.MsgBox1.ShowAlert("Las bases no pueden ser publicadas, ya que existen solicitudes que no han sido aprobadas por la UFI.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            'Me.MsgBox2.ShowConfirm("Existen solicitudes que no han sido aprobadas para este proceso, desea continuar", "B", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_CallBackOnNo)
            'Me.MsgBox2.ShowConfirm("Existen solicitudes para este proceso de compra que no han sido aprobadas por la Unidad Financiera, desea continuar con el proceso?", "B", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.No)
            Confirm("Existen solicitudes para este proceso de compra que no han sido aprobadas por la Unidad Financiera, desea continuar con el proceso?", "Publicar", OptionPostBack.YesPostBack)
        Else
            'mComponenteProcesoCompra.ActualizarEstado(mEntidadProcesoCompra)
            '            Me.MsgBox1.ShowAlert("Las bases han sido publicadas.", "B", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
            'Me.MsgBox2.ShowConfirm("Las solicitudes de este proceso de compra ya han sido aprobadas por la Unidad Financiera, desea continuar lo proceso?", "B", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.No)
            Confirm("Las solicitudes de este proceso de compra ya han sido aprobadas por la Unidad Financiera, desea continuar lo proceso?", "Publicar", OptionPostBack.YesPostBack)
        End If

    End Sub


    Protected Sub GuardarBase()
        ePC = New PROCESOCOMPRAS
        ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")
        ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")

        ePC.FECHAENVIONOTA = Convert.ToDateTime(Me.CPFechaEnvioNota.Text)
        ePC.FECHAPUBLICACION = Convert.ToDateTime(Me.CPFechaPublicacion.Text)
        ePC.COSTOBASE = Me.NBCostoBases.Text

        ePC.LUGARRETIROBASE = Me.txtLugarRetirobases.Text
        ePC.FECHAHORAINICIORETIRO = Me.CPFechaInicioBase.SelectedDate & " " & Me.tpHoraInicioBase.SelectedTime.TimeOfDay.ToString
        ePC.FECHAHORAFINRETIRO = Me.cpFechaFinRetiroBase.SelectedDate & " " & Me.tpHoraFinBase.SelectedTime.TimeOfDay.ToString


        cPC.ActualizarPROCESOCOMPRASpublicarBase(ePC)


        Me.Button1.Enabled = True
        Me.Button2.Visible = True
        'Me.MsgBox1.ShowAlert("Los datos han sido almacenados satisfactoriamente.", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)

        Alert("Los datos han sido almacenados satisfactoriamente.", "Guardado")
        Me.btnGuardar.Enabled = False
    End Sub

    Protected Sub PublicarBases()


        ePC = New PROCESOCOMPRAS
        ePC.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        ePC.IDPROCESOCOMPRA = Request.QueryString("idProc")
        ePC.IDESTADOPROCESOCOMPRA = eESTADOPROCESOSCOMPRAS.BASEPUBLICADA

        cPC.ActualizarEstado(ePC, 0)
        Alert("Las bases han sido publicadas.", "Publicada")
        Me.Button1.Enabled = False
        'Me.MsgBox1.ShowAlert("Las bases han sido publicadas.", "B", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk)
        Me.Button2.Enabled = True

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Session("IdProcesoCompra") = Request.QueryString("idProc")
        Dim cad = String.Format("/Reportes/frmrptAviso.aspx?id={0}", Session("IdProcesoCompra"))
        MostrarVentana(cad)
    End Sub

End Class
