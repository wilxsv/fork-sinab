'Comunicar incumplimientos de contrato
'CU-UACI023
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario con los datos del contrato seleccionado en el proceso anterior
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports System.Data
Imports Cooperator.Framework.Web.Controls
Partial Class FrmComunicarIncumplimientos2
    Inherits System.Web.UI.Page
    'declarar e inicializar variables
    Private mCompProceso As New cPROCESOCOMPRAS
    Private mEntProceso As New PROCESOCOMPRAS
    Private mEntidadContrato As New CONTRATOS
    Private mCompContrato As New cCONTRATOS
    Private mEntidad As New NOTASINCUMPLIMIENTOCONTRATO
    Private mComponente As New cNOTASINCUMPLIMIENTOCONTRATO
    Private mEntEmpleado As New EMPLEADOS
    Private mcompEmpleado As New cEMPLEADOS
    Private mEntCargo As New CARGOS
    Private mCompCargo As New cCARGOS
    Private tEntidad As New INCUMPLIMIENTOCONTRATO 'entidad temporal

    Dim ds As DataSet
    Private _IDPROVEEDOR As Int32
    Private _IDPROCESO As Int32
    Private _IDCONTRATO As Integer

    Dim opc As Integer
    Public Property IDPROCESO() As Int32 'identificador de proceso de compra
        Get
            Return Me._IDPROCESO
        End Get
        Set(ByVal Value As Int32)
            Me._IDPROCESO = Value
            Me.idproces.Text = Value
        End Set
    End Property

    Public Property IDPROVEEDOR() As Int32 'identificador de proveedor
        Get
            Return Me._IDPROVEEDOR
        End Get
        Set(ByVal Value As Int32)
            Me._IDPROVEEDOR = Value
            Me.idprov.Text = Value
        End Set
    End Property
    Public Property IDCONTRATO() As Integer 'identificador de contrato
        Get
            Return Me._IDCONTRATO
        End Get
        Set(ByVal Value As Integer)
            Me._IDCONTRATO = Value
            Me.idcontrat.Text = Value
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina

        If Not Page.IsPostBack Then 'al cargar la primera vez
            Me.Master.ControlMenu.Visible = False 'oculta menu
            CargaInicial()
            'valida existencia de nota
            If mComponente.ValidarExistenciaNotaContrato(Session.Item("IdEstablecimiento"), Me.idcontrat.Text, Me.idprov.Text) Then
                CargarDatosNota() 'existe nota

            Else ' no existe
                mEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                Me.Lblidnota.Text = mComponente.ObtenerIdNota(mEntidad)
            End If
        End If
    End Sub

    Public Sub CargaInicial()
        'carga inicial de datos a mostrar del contrato
        Me.UcBarraNavegacion1.Navegacion = False
        Me.UcBarraNavegacion1.PermitirAgregar = False
        Me.UcBarraNavegacion1.PermitirEditar = True
        Me.UcBarraNavegacion1.PermitirConsultar = False
        Me.UcBarraNavegacion1.HabilitarEdicion(True)
        Me.UcBarraNavegacion1.PermitirImprimir = False
        Me.UcBarraNavegacion1.PermitirGuardar = True

        IDPROVEEDOR = Request.QueryString("proveedor")
        IDCONTRATO = Request.QueryString("contrato")
        IDPROCESO = Request.QueryString("id")


        Me.LblFecha.Text = Now.ToString("dd/MM/yyyy")

        mEntidadContrato.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mEntidadContrato.IDPROVEEDOR = Me.idprov.Text
        mEntidadContrato.IDCONTRATO = Me.idcontrat.Text
        mCompContrato.ObtenerCONTRATOS(mEntidadContrato)

        Me.LblContrato.Text = mEntidadContrato.NUMEROCONTRATO
        Me.Txtmonto.Text = mEntidadContrato.MONTOCONTRATO.ToString("C2")

        mEntProceso.IDPROCESOCOMPRA = Me.idproces.Text
        mEntProceso.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        mCompProceso.ObtenerPROCESOCOMPRAS(mEntProceso)
        Me.lblLicitacion.Text = mEntProceso.TITULOLICITACION
        Me.LblProcesoCompra.Text = mEntProceso.CODIGOLICITACION
        Me.descproc.Text = mEntProceso.DESCRIPCIONLICITACION
        Me.DdlTIPOCOMPRAS1.Recuperar()
        Me.DdlTIPOCOMPRAS1.SelectedValue = mEntProceso.IDTIPOCOMPRAEJECUTAR

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

        CargarRenglonesContrato()

    End Sub

    Private Sub CargarRenglonesContrato()
        'carga los renglones del contrato
        Me.dgLista1.Visible = True
        Me.dgLista1.DataSource = Me.mComponente.DatasetRenglonesContrato(Session.Item("IdEstablecimiento"), Me.idcontrat.Text, Me.DdlPROVEEDORES1.SelectedValue)
        'carga lista
        Try
            Me.dgLista1.DataBind()
        Catch ex As Exception 'error en pagineo
            Me.dgLista1.CurrentPageIndex = 0
            Me.dgLista1.DataBind()
        End Try
    End Sub

    Protected Sub dgLista1_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgLista1.EditCommand
        'al selecionar consultar o generar nota de incumplimiento
        Dim lbldgproveedor As Label = CType(dgLista1.Items(e.Item.ItemIndex).FindControl("lblidproveedor"), Label)
        Dim lbldgestablecimiento As Label = CType(dgLista1.Items(e.Item.ItemIndex).FindControl("lblidestablecimiento"), Label)
        Dim lbldgcontrato As Label = CType(dgLista1.Items(e.Item.ItemIndex).FindControl("lblidcontrato"), Label)
        Dim lbldgrenglon As Label = CType(dgLista1.Items(e.Item.ItemIndex).FindControl("lblidrenglon"), Label)
        Response.Redirect("~/UACI/FrmNotaIncumplimientoContrato.aspx?idproveedor= " + lbldgproveedor.Text & "&idestablecimiento= " + lbldgestablecimiento.Text & "&idcontrato= " + lbldgcontrato.Text & "&idrenglon= " + lbldgrenglon.Text & "&idproceso= " + Me.idproces.Text)
    End Sub

    Protected Sub UcBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Cancelar
        'al seleccionar cancelar
        MsgBox1.ShowConfirm("Con esta operacion, si no ha guardado los cambios realizados, los perdera, desea seguir con la operación ?", "C", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
    End Sub

    Public Sub CargarDatosNota()
        'al cargar datos de la nota de incumplimiento si existe
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
        Me.TxtNUMEROINFORME.Text = mEntidad.NUMEROINFORME


        mEntEmpleado.IDEMPLEADO = mEntidad.IDEMPLEADOENVIA
        Me.mcompEmpleado.ObtenerEMPLEADOS(mEntEmpleado)

        mEntCargo.IDCARGO = mEntEmpleado.IDCARGO
        Me.mCompCargo.ObtenerCARGOS(mEntCargo)


        Me.DdlCARGOS1.Recuperar()
        Me.DdlCARGOS1.SelectedValue = mEntCargo.DESCRIPCION
        Me.LblCargoEntrega.Text = Me.DdlCARGOS1.SelectedItem.Text
        Session.Item("EntidadEncabezadoRep") = EncabezadoReporte()

    End Sub

    Public Function Agregar() As String
        'al agregar o actualizar nota de incumplimiento


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
        mEntidad.NUMEROINFORME = Me.TxtNUMEROINFORME.Text


        If mEntidad.AUUSUARIOCREACION = Nothing Then
            mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        End If
        If mEntidad.AUFECHACREACION = Nothing Then
            mEntidad.AUFECHACREACION = Now()
        End If
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()
        mEntidad.ESTASINCRONIZADA = 0

        If Me.TxtNUMEROINFORME.Text = "" Then
            Me.lblerror.Visible = True
        Else
            If mComponente.ValidarNumeroInforme(Me.TxtNUMEROINFORME.Text, CInt(Session.Item("IdEstablecimiento"))) Then
                MsgBox1.ShowAlert("Ya existe el número de informe ingresado, favor corregir", "x", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, AlertType.Exclamation)
            Else
                Select Case opc
                    Case Is = 1 'nueva
                        If mComponente.AgregarNOTAINCUMPLIMIENTOCONTRATO(mEntidad) <> 1 Then
                            Return "Error al Guardar registro."
                        Else
                            MsgBox1.ShowAlert("La nota de incumplimiento ha sido creada", "A", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, AlertType.Exclamation)
                            Session.Item("EntidadEncabezadoRep") = EncabezadoReporte()
                        End If
                    Case Is = 2 'existente
                        If mComponente.ActualizarNOTASINCUMPLIMIENTOCONTRATO(mEntidad) <> 1 Then
                            Return "Error al Guardar registro."
                        Else
                            MsgBox1.ShowAlert("Los cambios a la nota de incumplimiento han sido guardados satisfactoriamente", "B", Cooperator.Framework.Web.Controls.AlertOption.PostBackOnOk, AlertType.Exclamation)
                            Session.Item("EntidadEncabezadoRep") = EncabezadoReporte()
                        End If
                End Select
            End If
        End If
    End Function

    Protected Sub UcBarraNavegacion1_Guardar(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcBarraNavegacion1.Guardar
        'al guardar nota

        If mComponente.ValidarExistenciaNotaContrato(Session.Item("IdEstablecimiento"), Me.idcontrat.Text, Me.idprov.Text) Then
            opc = 2 'actualizar
        Else
            opc = 1 'agregar
        End If
        Agregar()

    End Sub

    Protected Sub MsgBox1_OkChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.OkChosen
        'al selecionar ok en los mensajes desplegados
        If e.Key = "A" Then
            MsgBox1.ShowConfirm("desea salir de la opción?", "D", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        End If

        If e.Key = "B" Then
            MsgBox1.ShowConfirm("desea salir de la opción?", "D", Cooperator.Framework.Web.Controls.ConfirmOption.PostBackOnYes_NoActionOnNo, Cooperator.Framework.Web.Controls.DefaultButton.Yes)
        End If
    End Sub

    Protected Sub MsgBox1_YesChosen(ByVal sender As Object, ByVal e As Cooperator.Framework.Web.Controls.MsgBoxEventArgs) Handles MsgBox1.YesChosen
        'al seleccionar yes en los contratos desplegados

        If e.Key = "C" Then
            Response.Redirect("~/UACI/FrmComunicarIncumplimientos.aspx")
        End If

        If e.Key = "D" Then
            Response.Redirect("~/UACI/FrmComunicarIncumplimientos.aspx")
        End If

    End Sub

    Protected Sub dgLista1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLista1.PageIndexChanged
        Me.dgLista1.CurrentPageIndex = e.NewPageIndex
        CargarRenglonesContrato()
    End Sub

    Protected Function EncabezadoReporte() As INCUMPLIMIENTOCONTRATO
        Dim dsti As DataSet
        Dim dtti As DataTable

        dsti = mComponente.CreacionDataSetIncumplimientoContrato()
        dtti = dsti.Tables("INCUMPLIMIENTOCONTRATO")

        'llenar dataset reporte
        tEntidad.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
        tEntidad.IDCONTRATO = Me.idcontrat.Text
        tEntidad.IDPROVEEDOR = Me.idprov.Text
        tEntidad.IDPROCESO = Me.idproces.Text
        tEntidad.TITULONOTA = Me.TxtTitulo.Text
        tEntidad.NOMBREDIRIGIDO = Me.txtNombreDirigido.Text
        tEntidad.CARGODIRIGIDO = Me.TxtCargoDirigido.Text
        tEntidad.NOMBREENVIA = Me.LblNombreEntrega.Text
        tEntidad.CARGOENVIA = Me.LblCargoEntrega.Text
        tEntidad.FECHAENTREGA = Me.LblFecha.Text
        tEntidad.IDNOTA = Me.Lblidnota.Text
        tEntidad.NUMEROCONTRATO = Me.LblContrato.Text
        tEntidad.TIPOLICITACION = Me.DdlTIPOCOMPRAS1.SelectedItem.Text
        tEntidad.MONTOCONTRATO = Me.Txtmonto.Text
        tEntidad.CODIGOLICITACION = Me.LblProcesoCompra.Text
        tEntidad.DESCRIPCIONLICITACION = Me.descproc.Text
        tEntidad.PROVEEDOR = Me.LblProveedor.Text
        Return tEntidad
    End Function
End Class
