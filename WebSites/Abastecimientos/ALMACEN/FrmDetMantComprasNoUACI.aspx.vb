
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Linq
Imports System.Collections.Generic
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Clases
Imports SINAB_Utils
Imports SINAB_Entidades.Tipos
Imports SINAB_Entidades.Clases.UACI
Imports SINAB_Entidades.Helpers.UACIHelpers
Imports Proveedores = SINAB_Entidades.Helpers.CatalogoHelpers.Proveedores

Partial Class FrmDetMantComprasNoUACI
    Inherits System.Web.UI.Page

    Private _Operacion As String
    Private _IDPROVEEDOR As Integer
    Private _IDCONTRATO As Integer
    Private _IDPRODUCTO As Integer

#Region " Propiedades "

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
            If value > 0 Then btnImprimir.OnClientClick = SINAB_Utils.Utils.ReferirVentana(String.Format("/Reportes/FrmRptContratoNoUaci.aspx?IdProveedor={0}&IdContrato={1}", Me.IDPROVEEDOR, Me.IDCONTRATO))
            'btnImprimir.OnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptContratoNoUaci.aspx?IdProveedor=" + Me.IDPROVEEDOR.ToString + "&IdContrato=" + Me.IDCONTRATO.ToString + "', 'popup' ,'scrollbars=1, resizable=1, width=800, height= 600'); return;"
        End Set
    End Property

    Public Property IDPRODUCTO() As Integer
        Get
            Return _IDPRODUCTO
        End Get
        Set(ByVal value As Integer)
            _IDPRODUCTO = value
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me.ViewState.Remove("IDPRODUCTO")
            Me.ViewState.Add("IDPRODUCTO", value)
        End Set
    End Property

    Public Property Operacion() As String
        Get
            Return _Operacion
        End Get
        Set(ByVal value As String)
            _Operacion = value
            If value = "Edicion" Then
                ucDetFuenteFinanciamientoContratos1.Consulta = False
                btnContinuar.Visible = False
            Else
                plFuentes.Visible = False
                ucDetFuenteFinanciamientoContratos1.Consulta = False
                plResponsables.Visible = False
                ucDetResDistribucionContrato1.Consulta = False

                plProductos.Visible = False

                ImgbCerrar.Visible = False
                btnImprimir.Visible = False
                ImgbGuardar.Visible = False
                btnContinuar.Visible = True
            End If
            If Not Me.ViewState("Operacion") Is Nothing Then Me.ViewState.Remove("Operacion")
            Me.ViewState.Add("Operacion", value)
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim usr = Membresia.ObtenerUsuario()

            Master.ControlMenu.Visible = False

            ' txtNombreAlmacen.Text = usr.ALMACEN.NOMBRE ' Session.Item("NombreAlmacen")

            Using db As New SinabEntities
                TiposDocumentoContrato.CargarALista(ddlTIPODOCUMENTOCONTRATO1, 1, db)
                UACIHelpers.ModalidadesCompra.CargarALista(ddlMODALIDADESCOMPRA1, db)
            End Using

            cpFechaDocumento.Text = Now.Date.ToShortDateString()
            cvFechaDocumento.ValueToCompare = CType(Now.Date, String)

            IDPROVEEDOR = CType(Request.QueryString("IdProv"), Integer)
            IDCONTRATO = CType(Request.QueryString("IdContrato"), Integer)


            If IDCONTRATO = 0 Then
                Operacion = "Nuevo"
                ImgbCerrar.Visible = False
                Proveedores.CargarALista(ddlPROVEEDORES1)
                lblProveedor.Visible = False
                txtDocumento.Focus()

            Else
                Operacion = "Edicion"

                Dim eP = Proveedores.Proveedor(IDPROVEEDOR)

                lblProveedor.Text = eP.NOMBRE
                ddlPROVEEDORES1.Visible = False

                CargarDatos()

                ProductosDocumentos.AgregarProducto()

            End If

        Else
            If Not Me.ViewState("Operacion") Is Nothing Then Me._Operacion = Me.ViewState("Operacion")
            If Not Me.ViewState("IDPROVEEDOR") Is Nothing Then Me._IDPROVEEDOR = Me.ViewState("IDPROVEEDOR")
            If Not Me.ViewState("IDCONTRATO") Is Nothing Then Me._IDCONTRATO = Me.ViewState("IDCONTRATO")
            If Not Me.ViewState("IDPRODUCTO") Is Nothing Then Me._IDPRODUCTO = Me.ViewState("IDPRODUCTO")

            If MessageBox.ConfirmTarget = "ConfirmationMethod" Then
                MessageBoxConfirm()
            End If


        End If

    End Sub

    Private Sub CargarDatos()
        Dim contrato As SAB_UACI_CONTRATOS = Obtener()
        Dim baseContrato As New SAB_UACI_CONTRATOS

        With baseContrato
            .IDPROVEEDOR = contrato.IDPROVEEDOR
            .IDESTABLECIMIENTO = contrato.IDESTABLECIMIENTO
            .IDCONTRATO = contrato.IDCONTRATO
        End With

        ddlTIPODOCUMENTOCONTRATO1.SelectedValue = CType(contrato.IDTIPODOCUMENTO, String)
        ddlTIPODOCUMENTOCONTRATO1.Enabled = False

        txtDocumento.Text = contrato.NUMEROCONTRATO
        cpFechaDocumento.Text = CType(contrato.FECHAGENERACION, Date).ToShortDateString()

        If Not contrato.IDMODALIDADCOMPRA Is Nothing Then ddlMODALIDADESCOMPRA1.SelectedValue = CType(contrato.IDMODALIDADCOMPRA, String)
        txtModalidad.Text = contrato.NUMEROMODALIDADCOMPRA
        txtResolucion.Text = contrato.RESOLUCION
        txtModificativa.Text = contrato.MODIFICATIVA

        With ucDetFuenteFinanciamientoContratos1
            .IDPROVEEDOR = contrato.IDPROVEEDOR
            .IDCONTRATO = CType(contrato.IDCONTRATO, Integer)
            .CargarDatos()
        End With

        With ucDetResDistribucionContrato1
            .IDPROVEEDOR = contrato.IDPROVEEDOR
            .IDCONTRATO = contrato.IDCONTRATO
            .CargarDatos()
        End With

        With ProductosDocumentos
            If Not IsPostBack Then
                .Base = baseContrato
            End If
            .CargarDatos()
        End With
    End Sub

    Private Function Obtener() As SAB_UACI_CONTRATOS
        Dim usr = Membresia.ObtenerUsuario()
        Dim baseContrato As New SAB_UACI_CONTRATOS

        With baseContrato
            .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDCONTRATO = IDCONTRATO
        End With

        Return UACIHelpers.Contratos.Obtener(baseContrato)
    End Function

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinuar.Click

        If Me.cpFechaDocumento.Text = Date.MinValue.ToShortDateString() Then

            MessageBox.Alert("Debe ingresar la fecha del documento.")
            '                  MsgBox1.ShowAlert("Debe ingresar la fecha del documento.", "i", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Stop)
            Exit Sub
        End If

        Me.btnContinuar.Visible = False

        Me.ddlTIPODOCUMENTOCONTRATO1.Enabled = False

        Me.IDPROVEEDOR = Me.ddlPROVEEDORES1.SelectedValue

        GuardarMovimiento()

        Me.ucDetFuenteFinanciamientoContratos1.IDPROVEEDOR = Me.IDPROVEEDOR
        Me.ucDetFuenteFinanciamientoContratos1.IDCONTRATO = Me.IDCONTRATO
        Me.ucDetFuenteFinanciamientoContratos1.CargarDatos()

        Me.ucDetResDistribucionContrato1.IDPROVEEDOR = Me.IDPROVEEDOR
        Me.ucDetResDistribucionContrato1.IDCONTRATO = Me.IDCONTRATO
        Me.ucDetResDistribucionContrato1.CargarDatos()

        Me.lblProveedor.Text = Me.ddlPROVEEDORES1.SelectedItem.Text
        Me.ddlPROVEEDORES1.DataSource = Nothing
        Me.ddlPROVEEDORES1.DataBind()

        Me.ddlPROVEEDORES1.Visible = False
        Me.lblProveedor.Visible = True

        Me.ImgbGuardar.Visible = True
        Me.ImgbCerrar.Visible = True
        Me.btnImprimir.Visible = True
        Me.plFuentes.Visible = True
        plProductos.Visible = True
        Me.plResponsables.Visible = True



        ProductosDocumentos.AgregarProducto()

    End Sub


    Protected Sub ImgbGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgbGuardar.Click
        GuardarMovimiento()
        MessageBox.Alert("Los datos se guardaron satisfactoriamente.")
    End Sub

    Protected Sub ImgbCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgbCerrar.Click
        If ucDetFuenteFinanciamientoContratos1.Count = 0 Then
            MessageBox.Alert("Debe definir al menos una fuente de financiamiento.")
        ElseIf ucDetResDistribucionContrato1.Count = 0 Then
            MessageBox.Alert("Debe definir al menos un responsable de distribución.")
        ElseIf ProductosDocumentos.ConteoProductos = 0 Then
            MessageBox.Alert("Debe definir al menos un producto.")
        Else
            MessageBox.Confirm("Si cierra el documento, este ya no podrá ser modificado, ¿desea continuar?.", "ConfirmationMethod", MessageBox.OptionPostBack.YesPostBack)
        End If
    End Sub

    Protected Sub MessageBoxConfirm()

        Try
            Using db As New SinabEntities
                Dim contrato = Obtener()
                With contrato
                    .IDESTADOCONTRATO = 3
                    .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    .AUFECHAMODIFICACION = Now
                    .ESTASINCRONIZADA = 0
                End With

                contrato = UACIHelpers.Contratos.Guardar(contrato, db)

                Dim productos = contrato.SAB_UACI_PRODUCTOSCONTRATO.ToList()

                If productos.Any() Then

                    Dim idAlmacen = Membresia.ObtenerUsuario().Almacen.IDALMACEN

                    For Each producto As SAB_UACI_PRODUCTOSCONTRATO In productos

                        Dim arrEntregas As New ArrayList
                        Dim listEntregas As New List(Of SAB_UACI_ALMACENESENTREGACONTRATOS)
                        producto.SAB_UACI_ENTREGACONTRATO.ToList().ForEach(Function(en) arrEntregas.Add(en.PORCENTAJEENTREGA))

                        Dim arrCantEntrega = Utils.DistribuirProducto(producto.CANTIDAD, arrEntregas) 'cU.DistribuirProducto(ds.Tables(0).Rows(i).Item("CANTIDAD"), arrEntregas)

                        Dim contEntrega = 0
                        For Each entrega In producto.SAB_UACI_ENTREGACONTRATO
                            Dim entregaContrato As New SAB_UACI_ALMACENESENTREGACONTRATOS
                            With entregaContrato
                                .IDESTABLECIMIENTO = producto.IDESTABLECIMIENTO
                                .IDPROVEEDOR = producto.IDPROVEEDOR
                                .IDCONTRATO = producto.IDCONTRATO
                                .AUUSUARIOCREACION = User.Identity.Name
                                .AUFECHACREACION = Now
                                If (producto.IDALMACENENTREGA Is Nothing) Then .IDALMACENENTREGA = idAlmacen Else .IDALMACENENTREGA = CType(producto.IDALMACENENTREGA, Integer)
                                .RENGLON = producto.RENGLON
                                .IDDETALLE = entrega.IDDETALLE
                                .CANTIDAD = CType(arrCantEntrega.Item(contEntrega), Decimal)
                                .CANTIDADENTREGADA = 0
                                .IDFUENTEFINANCIAMIENTO = ucDetFuenteFinanciamientoContratos1.IdfuenteFinanciamiento
                            End With
                            listEntregas.Add(entregaContrato)
                            contEntrega += 1
                        Next

                        AlmacenesEntregaContrato.Guardar(listEntregas)
                    Next

                End If

                Response.Redirect("~/ALMACEN/FrmMantIngresoComprasNoUACI.aspx", False)
            End Using
        Catch ex As Exception
            MessageBox.Alert("Error al guardar contrato. Póngase en contácto con el área técnica. Error: " + ex.Message)

        End Try





        'Dim dsEntregas As Data.DataSet
        'Dim cU As New cUTILERIAS
        'Dim cEC As New cENTREGACONTRATO
        'Dim cAEC As New cALMACENESENTREGACONTRATOS
        ' eAEC.RENGLON = CType(ds.Tables(0).Rows(i).Item("RENGLON"), Long)
        'dsEntregas = cEC.ObtenerEntregas(eAEC.IDESTABLECIMIENTO, eAEC.IDPROVEEDOR, eAEC.IDCONTRATO, eAEC.RENGLON)
        'For j As Integer = 0 To dsEntregas.Tables(0).Rows.Count - 1
        '    arrEntregas.Add(dsEntregas.Tables(0).Rows(j).Item("PORCENTAJEENTREGA"))
        'Next
        'For j As Integer = 0 To dsEntregas.Tables(0).Rows.Count - 1
        '    eAEC.IDDETALLE = dsEntregas.Tables(0).Rows(j).Item("IDDETALLE")
        '    eAEC.CANTIDAD = arrCantEntrega.Item(j)
        '    eAEC.CANTIDADENTREGADA = 0
        '    eAEC.IDFUENTEFINANCIAMIENTO = Me.ucDetFuenteFinanciamientoContratos1.IdfuenteFinanciamiento
        '    cAEC.AgregarALMACENESENTREGACONTRATOS(eAEC)
        'Next
    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Private Sub GuardarMovimiento()

        Dim contrato As New SAB_UACI_CONTRATOS

        With contrato
            .IDESTABLECIMIENTO = Membresia.ObtenerUsuario().ESTABLECIMIENTO.IDESTABLECIMIENTO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDCONTRATO = IDCONTRATO
        End With


        If IDCONTRATO = 0 Then
            contrato.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            contrato.AUFECHACREACION = Now
        Else
            Dim base = New SAB_UACI_CONTRATOS()
            With base
                .IDESTABLECIMIENTO = contrato.IDESTABLECIMIENTO
                .IDCONTRATO = contrato.IDCONTRATO
                .IDPROVEEDOR = contrato.IDPROVEEDOR
            End With
            contrato = UACIHelpers.Contratos.Obtener(base)
            contrato.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
            contrato.AUFECHAMODIFICACION = Now()
            contrato.ESTASINCRONIZADA = 0
        End If

        With contrato
            .NUMEROCONTRATO = txtDocumento.Text
            .IDTIPODOCUMENTO = CType(ddlTIPODOCUMENTOCONTRATO1.SelectedValue, Short)
            .TIPOPERSONA = "J"
            .REPRESENTANTELEGAL = "N/A"
            .FECHAGENERACION = CType(cpFechaDocumento.Text, Date)
            .FECHAAPROBACION = CType(cpFechaDocumento.Text, Date)
            .FECHADISTRIBUCION = CType(cpFechaDocumento.Text, Date)
            .IDESTADOCONTRATO = 1
            If Not String.IsNullOrEmpty(txtModalidad.Text) Then .IDMODALIDADCOMPRA = CType(ddlMODALIDADESCOMPRA1.SelectedValue, Byte)
            .NUMEROMODALIDADCOMPRA = txtModalidad.Text
            .CODIGOLICITACION = txtModalidad.Text
            .RESOLUCION = txtResolucion.Text
            .MODIFICATIVA = txtModificativa.Text
        End With


        UACIHelpers.Contratos.Guardar(contrato)

        IDCONTRATO = CType(contrato.IDCONTRATO, Integer)

        Dim baseContrato As New SAB_UACI_CONTRATOS

        With baseContrato
            .IDPROVEEDOR = contrato.IDPROVEEDOR
            .IDESTABLECIMIENTO = contrato.IDESTABLECIMIENTO
            .IDCONTRATO = contrato.IDCONTRATO
        End With
        ProductosDocumentos.Base = baseContrato


    End Sub



End Class
