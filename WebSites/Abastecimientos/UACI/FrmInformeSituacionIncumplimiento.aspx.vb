Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Imports Cooperator.Framework.Web.Controls
Partial Class FrmInformeSituacionIncumplimiento
    Inherits System.Web.UI.Page
    Private mEntidadContrato As New CONTRATOS
    Private mCompContrato As New cCONTRATOS
    Private mEntidad As New NOTASINCUMPLIMIENTOCONTRATO
    Private mComponente As New cNOTASINCUMPLIMIENTOCONTRATO
    Private mCompProceso As New cPROCESOCOMPRAS
    Private mEntProceso As New PROCESOCOMPRAS
    Private mEntEmpleado As New EMPLEADOS
    Private mcompEmpleado As New cEMPLEADOS
    Private mEntCargo As New CARGOS
    Private mCompCargo As New cCARGOS

    Private _IDPROVEEDOR As Int32
    Private _IDPROCESO As Int32
    Private _IDCONTRATO As Integer

    Dim ds As DataSet
    Dim opc As Integer
    Public Property IDPROCESO() As Int32
        Get
            Return Me._IDPROCESO
        End Get
        Set(ByVal Value As Int32)
            Me._IDPROCESO = Value
            Me.idproces.Text = Value
        End Set
    End Property

    Public Property IDPROVEEDOR() As Int32
        Get
            Return Me._IDPROVEEDOR
        End Get
        Set(ByVal Value As Int32)
            Me._IDPROVEEDOR = Value
            Me.idprov.Text = Value
        End Set
    End Property
    Public Property IDCONTRATO() As Integer
        Get
            Return Me._IDCONTRATO
        End Get
        Set(ByVal Value As Integer)
            Me._IDCONTRATO = Value
            Me.idcontrat.Text = Value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargaInicial()
            If mComponente.ValidarExistenciaNotaContrato(Session.Item("IdEstablecimiento"), Me.idcontrat.Text, Me.idprov.Text) Then
                CargarDatosNota() 'existe
                Me.UcBarraNavegacion1.PermitirImprimir = True
            Else
                mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                Me.Lblidnota.Text = mComponente.ObtenerIdNota(mEntidad)
            End If
        End If
    End Sub

    Public Sub CargaInicial()
        Me.UcBarraNavegacion1.Navegacion = False
        Me.UcBarraNavegacion1.PermitirAgregar = False
        Me.UcBarraNavegacion1.PermitirEditar = True
        Me.UcBarraNavegacion1.PermitirConsultar = False
        Me.UcBarraNavegacion1.HabilitarEdicion(True)
        Me.UcBarraNavegacion1.PermitirImprimir = False
        Me.UcBarraNavegacion1.PermitirGuardar = True

        IDPROVEEDOR = Request.QueryString("idproveedor")
        IDCONTRATO = Request.QueryString("idcontrato")
        IDPROCESO = Request.QueryString("idproceso")

        Me.LblFecha.Text = Now.ToString("dd/MM/yyyy")

        mEntidadContrato.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntidadContrato.IDPROVEEDOR = Me.idprov.Text
        mEntidadContrato.IDCONTRATO = Me.idcontrat.Text
        mCompContrato.ObtenerCONTRATOS(mEntidadContrato)

        Me.LblContrato.Text = mEntidadContrato.NUMEROCONTRATO
        Me.Txtmonto.Text = mEntidadContrato.MONTOCONTRATO

        mEntProceso.IDPROCESOCOMPRA = Me.idproces.Text
        mEntProceso.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mCompProceso.ObtenerPROCESOCOMPRAS(mEntProceso)
        Me.lblLicitacion.Text = mEntProceso.TITULOLICITACION
        Me.LblProcesoCompra.Text = mEntProceso.CODIGOLICITACION

        Me.DdlPROVEEDORES1.Recuperar()
        Me.DdlEMPLEADOS1.RecuperarNombreCompleto()
        Me.DdlPROVEEDORES1.SelectedValue = Me.idprov.Text
        Me.LblProveedor.Text = Me.DdlPROVEEDORES1.SelectedItem.Text
        Me.DdlEMPLEADOS1.SelectedValue = Session.Item("IdEmpleado")
        Me.LblNombreEntrega.Text = Me.DdlEMPLEADOS1.SelectedItem.Text

        mEntEmpleado.IDEMPLEADO = mEntidad.IDEMPLEADOENVIA
        Me.mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)

        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        Me.mCompCargo.ObtenerCARGOS(mEntCargo)


        Me.DdlCARGOS1.Recuperar()
        Me.DdlCARGOS1.SelectedValue = mEntCargo.DESCRIPCION
        Me.LblCargoEntrega.Text = Me.DdlCARGOS1.SelectedItem.Text

    End Sub

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar
        MsgBox1.ShowConfirm("Con esta operacion, si no ha guardado los cambios realizados, los perdera, desea seguir con la operación ?", "C", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Public Sub CargarDatosNota()
        mEntidad.IDESTABLECIMIENTO = CInt(Session.Item("IdEstablecimiento"))
        mEntidad.IDPROVEEDOR = Me.idprov.Text
        mEntidad.IDCONTRATO = Me.idcontrat.Text

        mComponente.RecuperarInformacionNotas(mEntidad)

        Me.Lblidnota.Text = mEntidad.IDNOTA
        Me.LblFecha.Text = mEntidad.FECHAENTREGA
        Me.TxtTitulo.Text = mEntidad.TITULONOTA
        Me.txtNombreDirigido.Text = mEntidad.NOMBREPERSONADIRIGIDA
        Me.TxtCargoDirigido.Text = mEntidad.CARGOPERSONADIRIGIDA
        Me.DdlEMPLEADOS1.RecuperarNombreCompleto()
        Me.DdlEMPLEADOS1.SelectedValue = mEntidad.IDEMPLEADOENVIA
        Me.LblNombreEntrega.Text = Me.DdlEMPLEADOS1.SelectedItem.Text


        mEntEmpleado.IDEMPLEADO = mEntidad.IDEMPLEADOENVIA
        Me.mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)

        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        Me.mCompCargo.ObtenerCARGOS(mEntCargo)


        Me.DdlCARGOS1.Recuperar()
        Me.DdlCARGOS1.SelectedValue = mEntCargo.DESCRIPCION
        Me.LblCargoEntrega.Text = Me.DdlCARGOS1.SelectedItem.Text


    End Sub

    Public Function Agregar() As String


        mEntidad = New NOTASINCUMPLIMIENTOCONTRATO

        mEntidad.IDESTABLECIMIENTO = CInt(Session.Item("IdEstablecimiento"))
        mEntidad.IDPROVEEDOR = Me.idprov.Text
        mEntidad.IDCONTRATO = Me.idcontrat.Text
        mEntidad.IDNOTA = Me.Lblidnota.Text
        mEntidad.IDEMPLEADOENVIA = Me.DdlEMPLEADOS1.SelectedValue
        mEntidad.FECHAENTREGA = Me.LblFecha.Text
        mEntidad.NOMBREPERSONADIRIGIDA = Me.txtNombreDirigido.Text
        mEntidad.CARGOPERSONADIRIGIDA = Me.TxtCargoDirigido.Text
        mEntidad.TITULONOTA = Me.TxtTitulo.Text


        If mEntidad.AUUSUARIOCREACION = Nothing Then
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntidad.AUFECHACREACION = Nothing Then
            mEntidad.AUFECHACREACION = Now()
        End If
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0


        Select Case opc
            Case Is = 1
                If mComponente.AgregarNOTAINCUMPLIMIENTOCONTRATO(mEntidad) <> 1 Then
                    Return "Error al Guardar registro."
                Else
                    MsgBox1.ShowAlert("La nota de incumplimiento ha sido creada", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, AlertType.Exclamation)
                    Me.UcBarraNavegacion1.PermitirImprimir = True
                End If
            Case Is = 2
                If mComponente.ActualizarNOTASINCUMPLIMIENTOCONTRATO(mEntidad) <> 1 Then
                    Return "Error al Guardar registro."
                Else
                    MsgBox1.ShowAlert("Los cambios a la nota de incumplimiento han sido guardados satisfactoriamente", "B", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, AlertType.Exclamation)

                End If
        End Select
    End Function

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar
        If mComponente.ValidarExistenciaNotaContrato(Session.Item("IdEstablecimiento"), Me.idcontrat.Text, Me.idprov.Text) Then
            opc = 2 'actualizar
        Else
            opc = 1 'agregar
        End If
        Agregar()

    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        If e.Key = "A" Then
            MsgBox1.ShowConfirm("desea salir de la opción?", "D", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        End If

        If e.Key = "B" Then
            MsgBox1.ShowConfirm("desea salir de la opción?", "D", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen

        If e.Key = "C" Then
            Response.Redirect("~/UACI/FrmComunicarIncumplimientos2.aspx?id= " + Me.idproces.Text & "&contrato= " + Me.idcontrat.Text & "&proveedor= " + Me.idprov.Text)
        End If

        If e.Key = "D" Then
            Response.Redirect("~/UACI/FrmComunicarIncumplimientos2.aspx?id= " + Me.idproces.Text & "&contrato= " + Me.idcontrat.Text & "&proveedor= " + Me.idprov.Text)
        End If

    End Sub

End Class
