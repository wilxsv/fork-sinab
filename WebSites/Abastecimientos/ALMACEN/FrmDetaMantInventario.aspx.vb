'INVENTARIO FISICO
'CU-ALMACEN012
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario para EL MANTENIMIENTO DEL INVENTARIO FISICO DEL ESTABLECIMIENTO
'Consiste en recuento de las existencias de productos dentro del almacen para la comparacion 
'de los valores realies y fisicos
Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports eWorld.UI
Imports SINAB_Entidades.EnumHelpers

Partial Class FrmDetaMantInventario
    Inherits System.Web.UI.Page

    'declarar e inicializar variables
    Private _IDALMACEN As Int32
    Private _IDINVENTARIO As Int32

    Private mEntidad As INVENTARIO
    Private mComponente As New cINVENTARIO

#Region " Propiedades "

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

    Public Property IDINVENTARIO() As Int32 'identificador de inventario
        Get
            Return Me._IDINVENTARIO
        End Get
        Set(ByVal value As Int32)
            Me._IDINVENTARIO = value
            If Not Me.ViewState("IDINVENTARIO") Is Nothing Then Me.ViewState.Remove("IDINVENTARIO")
            Me.ViewState.Add("IDINVENTARIO", value)
            Dim cad = String.Format("/Reportes/FrmRptInventarioFisico.aspx?IdA={0}&IdI={1}", Me.IDALMACEN, Me.IDINVENTARIO)
            ucBarraNavegacion1.ibtnImprimirOnClientClick = SINAB_Utils.Utils.ReferirVentana(cad)
            'ucBarraNavegacion1.ibtnImprimirOnClientClick = "window.open('" + Request.ApplicationPath + "/Reportes/FrmRptInventarioFisico.aspx?IdA=" + Me.IDALMACEN.ToString + "&IdI=" + Me.IDINVENTARIO.ToString + "', 'popup', 'scrollbars=1, resizable=1, width=800, height=600'); return;" 'al momento de imprimir inventario
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al cargar la pagina

        If Not Page.IsPostBack Then 'al cargar por primera vez

            Me.Master.ControlMenu.Visible = False 'oculta menu

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = True
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = True

            Me.cpInicio.UpperBoundDate = Now.Date
            Me.cvInicio.ValueToCompare = Now.Date
            Me.cpFechaCierre.UpperBoundDate = Now.Date
            Me.cvFechaCierre.ValueToCompare = Now.Date

            CargarDDLs()

            DeshabilitarDobleClickBotones()

            Me.IDALMACEN = Session.Item("IdAlmacen")
            Me.IDINVENTARIO = Request.QueryString("id") 'identificador de inventario

            If Me.IDINVENTARIO = 0 Then
                Nuevo()
            Else
                CargarDatos()
            End If

        Else
            If Not Me.ViewState("IDALMACEN") Is Nothing Then Me._IDALMACEN = Me.ViewState("IDALMACEN")
            If Not Me.ViewState("IDINVENTARIO") Is Nothing Then Me._IDINVENTARIO = Me.ViewState("IDINVENTARIO")
        End If

    End Sub

    Private Sub ucBarraNavegacion1_Cancelar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucBarraNavegacion1.Cancelar
        'al momento de cancelar
        Response.Redirect("~/ALMACEN/FrmInventarioFisico.aspx", False)
    End Sub

    Private Sub CargarDatos()
        'al cargar datos una vez que exista
        mEntidad = New INVENTARIO
        mEntidad.IDALMACEN = Me.IDALMACEN
        mEntidad.IDINVENTARIO = Me.IDINVENTARIO

        mComponente.ObtenerINVENTARIO(mEntidad)

        Me.cpInicio.SelectedDate = mEntidad.FECHAINICIO

        Me.ddlSUMINISTROS1.SelectedValue = mEntidad.IDSUMINISTRO
        Me.ddlSUMINISTROS1.Enabled = False

        Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Enabled = False

        Dim cFF As New cFUENTEFINANCIAMIENTOS
        Dim eFF As New FUENTEFINANCIAMIENTOS

        eFF.IDFUENTEFINANCIAMIENTO = mEntidad.IDFUENTEFINANCIAMIENTO
        cFF.ObtenerFUENTEFINANCIAMIENTOS(eFF)

        Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue = eFF.IDGRUPO

        If Me.ddlFUENTEFINANCIAMIENTOS1.Items.FindByValue(mEntidad.IDFUENTEFINANCIAMIENTO) Is Nothing Then
            Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue)
        End If

        Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue = mEntidad.IDFUENTEFINANCIAMIENTO
        Me.ddlFUENTEFINANCIAMIENTOS1.Enabled = False

        Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue = mEntidad.IDRESPONSABLEDISTRIBUCION
        Me.ddlRESPONSABLEDISTRIBUCION1.Enabled = False

        Me.cbDisponibles.Checked = IIf(mEntidad.CONSIDERARDISPONIBLES = 1, True, False)
        Me.cbDisponibles.Enabled = False

        Me.cbNoDisponibles.Checked = IIf(mEntidad.CONSIDERARNODISPONIBLES = 1, True, False)
        Me.cbNoDisponibles.Enabled = False

        Me.cbVencidos.Checked = IIf(mEntidad.CONSIDERARVENCIDOS = 1, True, False)
        Me.cbVencidos.Enabled = False

        Me.cbTodos.Enabled = False

        If mEntidad.ESTACERRADO = 1 Then
            Me.cpFechaCierre.SelectedValue = mEntidad.FECHACIERRE
            Me.cbCerrado.Checked = True
        End If

        HabilitarCamposCierre(Me.cbCerrado.Checked)

        ObtenerDetalleInventario()

        Me.btnGenerar.Visible = False

    End Sub

    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGenerar.Click

        'al momento de generar el inventario

        If Not (Me.cbDisponibles.Checked Or Me.cbNoDisponibles.Checked Or Me.cbVencidos.Checked Or Me.cbTodos.Checked) Then
            MsgBox1.ShowAlert("Debe seleccionar al menos un tipo de producto.", "i", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Else
            GenerarInventario()
            ObtenerDetalleInventario()

            Me.cpInicio.Enabled = False
            Me.ddlSUMINISTROS1.Enabled = False

            Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Enabled = False
            Me.ddlFUENTEFINANCIAMIENTOS1.Enabled = False
            Me.ddlRESPONSABLEDISTRIBUCION1.Enabled = False

            Me.cbDisponibles.Enabled = False
            Me.cbNoDisponibles.Enabled = False
            Me.cbVencidos.Enabled = False
            Me.cbTodos.Enabled = False

            Me.btnGenerar.Visible = False
            Me.lblFECHACIERRE.Visible = True
            Me.cpFechaCierre.Visible = True
            Me.btnCerrar.Visible = True
        End If

    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        'al momento de cerrar inventario
        Me.CerrarInventario()
        Me.HabilitarCamposCierre(True)
        Me.btnGenerar.Visible = False
        Me.btnCerrar.Visible = False
    End Sub

    Protected Sub DeshabilitarDobleClickBotones()
        'btnGenerar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnGenerar, Nothing) + ";"
        btnCerrar.OnClientClick = "if(typeof(Page_ClientValidate)=='function'){if(Page_ClientValidate()==false){return;}}this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(btnCerrar, Nothing) + ";"
    End Sub

    Public Sub HabilitarCamposCierre(ByVal Cerrado As Boolean)
        'habilitar campos de cierre
        Me.lblFECHACIERRE.Visible = True
        Me.cpFechaCierre.Enabled = Not Cerrado
        Me.cpFechaCierre.Visible = True
        Me.lblESTACERRADO.Visible = Cerrado
        Me.cbCerrado.Visible = Cerrado
        Me.btnCerrar.Visible = Not Cerrado
        Me.gvLista.Columns(10).Visible = Not Cerrado
    End Sub

    Private Sub Nuevo() 'inventario nuevo
        Me.cbDisponibles.Checked = True

        Me.btnGenerar.Visible = True
        Me.btnCerrar.Visible = False
    End Sub

    Private Sub GenerarInventario()

        mEntidad = New INVENTARIO

        mEntidad.IDALMACEN = Me.IDALMACEN
        mEntidad.IDINVENTARIO = Me.IDINVENTARIO

        mEntidad.FECHAINICIO = Me.cpInicio.SelectedDate
        mEntidad.FECHACIERRE = Nothing
        mEntidad.IDSUMINISTRO = Me.ddlSUMINISTROS1.SelectedValue
        mEntidad.FECHACIERREEXISTENCIA = Nothing
        mEntidad.ESTACERRADO = 0

        mEntidad.CONSIDERARFUENTE = IIf(Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue = 0, 0, 1)
        mEntidad.IDFUENTEFINANCIAMIENTO = Me.ddlFUENTEFINANCIAMIENTOS1.SelectedValue

        mEntidad.CONSIDERARRESPONSABLE = IIf(Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue = 0, 0, 1)
        mEntidad.IDRESPONSABLEDISTRIBUCION = Me.ddlRESPONSABLEDISTRIBUCION1.SelectedValue

        If Me.cbTodos.Checked Then
            mEntidad.CONSIDERARDISPONIBLES = 1
            mEntidad.CONSIDERARNODISPONIBLES = 1
            mEntidad.CONSIDERARVENCIDOS = 1
        Else
            mEntidad.CONSIDERARDISPONIBLES = IIf(Me.cbDisponibles.Checked, 1, 0)
            mEntidad.CONSIDERARNODISPONIBLES = IIf(Me.cbNoDisponibles.Checked, 1, 0)
            mEntidad.CONSIDERARVENCIDOS = IIf(Me.cbVencidos.Checked, 1, 0)
        End If

        mEntidad.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHACREACION = Now()

        mEntidad.ESTASINCRONIZADA = 0

        If mComponente.ActualizarINVENTARIO(mEntidad) = 1 Then

            Me.IDINVENTARIO = mEntidad.IDINVENTARIO

            mComponente.CopiarDetalleInventario(mEntidad.IDALMACEN, mEntidad.IDINVENTARIO, HttpContext.Current.User.Identity.Name, ddlSUMINISTROS1.SelectedValue, mEntidad.IDFUENTEFINANCIAMIENTO, mEntidad.IDRESPONSABLEDISTRIBUCION, mEntidad.CONSIDERARDISPONIBLES, mEntidad.CONSIDERARNODISPONIBLES, mEntidad.CONSIDERARVENCIDOS)

            ObtenerDetalleInventario()

        Else
            'error
        End If

    End Sub

    Public Sub CerrarInventario()
        'al momento de cerrar inventario

        mEntidad = New INVENTARIO

        mEntidad.IDALMACEN = Me.IDALMACEN
        mEntidad.IDINVENTARIO = Me.IDINVENTARIO
        mComponente.ObtenerINVENTARIO(mEntidad)

        mEntidad.FECHACIERRE = Me.cpFechaCierre.SelectedDate
        mEntidad.ESTACERRADO = 1 'cerrado

        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()

        If mComponente.ActualizarINVENTARIO(mEntidad) = 1 Then
            Me.cbCerrado.Checked = True
        Else
            'error
        End If

    End Sub

    Public Sub CerrarConteo()
        'al momento de cerrar conteo
        mEntidad = New INVENTARIO

        mEntidad.IDINVENTARIO = Me.IDINVENTARIO
        mEntidad.IDALMACEN = Me.IDALMACEN
        mComponente.ObtenerINVENTARIO(mEntidad)

        mEntidad.ESTACERRADO = 2 'cerrar conteo
        mEntidad.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntidad.AUFECHAMODIFICACION = Now()

        mComponente.ActualizarINVENTARIO(mEntidad)
    End Sub

    Private Sub CargarDDLs()
        Me.ddlSUMINISTROS1.RecuperarOrdenadaPorCorrelativo()
        Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.Recuperar()
        Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue)
        Me.ddlRESPONSABLEDISTRIBUCION1.RecuperarNombreCorto()

        Dim item As New ListItem("(Todos)", 0)
        Me.ddlFUENTEFINANCIAMIENTOS1.Items.Insert(0, item)
        Me.ddlRESPONSABLEDISTRIBUCION1.Items.Insert(0, item)
    End Sub

    Private Sub ObtenerDetalleInventario()
        'carga grid con detalle de inventario
        Dim cDI As New cINVENTARIO
        Me.gvLista.DataSource = cDI.ObtenerDsReporteInventarioFisico(Me.IDALMACEN, Me.IDINVENTARIO)

        Try
            Me.gvLista.DataBind()
        Catch ex As Exception
            Me.gvLista.PageIndex = 0
            Me.gvLista.DataBind()
        End Try

        Me.gvLista.SelectedIndex = -1
    End Sub

    Protected Sub gvLista_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvLista.SelectedIndexChanging

        If Me.cbDisponibles.Checked And CType(gvLista.Rows(e.NewSelectedIndex).FindControl("txtDisponibleCaptura"), NumericBox).Text = String.Empty Then
            Exit Sub
        End If

        If Me.cbNoDisponibles.Checked And CType(gvLista.Rows(e.NewSelectedIndex).FindControl("txtNoDisponibleCaptura"), NumericBox).Text = String.Empty Then
            Exit Sub
        End If

        If Me.cbVencidos.Checked And CType(gvLista.Rows(e.NewSelectedIndex).FindControl("txtVencidaCaptura"), NumericBox).Text = String.Empty Then
            Exit Sub
        End If

        Me.txtMotivo.Text = String.Empty
        Me.txtObservacion.Text = String.Empty
        Me.plAjuste.Visible = True
        Me.txtMotivo.Focus()

    End Sub

    Protected Sub gvLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvLista.PageIndexChanging
        'al momento de cambiar de indice de pagina
        Me.gvLista.PageIndex = e.NewPageIndex
        Me.ObtenerDetalleInventario()
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim eL As New LOTES
        Dim eDMDisponibles As New DETALLEMOVIMIENTOS
        Dim eDMNoDisponibles As New DETALLEMOVIMIENTOS
        Dim eDMVencidos As New DETALLEMOVIMIENTOS

        If CType(gvLista.Rows(gvLista.SelectedIndex).FindControl("txtDisponibleCaptura"), NumericBox).Text <> String.Empty Then

            Dim CantidadDisponibleSistema As Decimal = gvLista.DataKeys.Item(gvLista.SelectedIndex).Values.Item("CANTIDADDISPONIBLESISTEMA")
            Dim CantidadDisponibleCapturaAnterior As Decimal = gvLista.DataKeys.Item(gvLista.SelectedIndex).Values.Item("CANTIDADDISPONIBLECAPTURA")
            Dim CantidadDisponibleCaptura As Decimal = CType(gvLista.Rows(gvLista.SelectedIndex).FindControl("txtDisponibleCaptura"), NumericBox).Text
            Dim CantidadDisponibleDiferencia As Decimal = gvLista.DataKeys.Item(gvLista.SelectedIndex).Values.Item("CANTIDADDISPONIBLEDIFERENCIA")
            Dim Diferencia As Decimal = CantidadDisponibleCaptura - CantidadDisponibleSistema

            If CantidadDisponibleCaptura <> CantidadDisponibleCapturaAnterior Then

                Select Case Diferencia
                    Case 0
                        eL.CANTIDADDISPONIBLE = CantidadDisponibleCaptura
                        eDMDisponibles.CANTIDAD = CantidadDisponibleCaptura
                        eDMDisponibles.CANTIDADANTERIOR = CantidadDisponibleCapturaAnterior
                        eDMDisponibles.IDTIPOTRANSACCION = TiposTransaccion.AjusteInventarioMas
                    Case Is > 0
                        eL.CANTIDADDISPONIBLE = CantidadDisponibleCaptura
                        eDMDisponibles.CANTIDAD = CantidadDisponibleCaptura - CantidadDisponibleSistema - CantidadDisponibleDiferencia
                        If eDMDisponibles.CANTIDAD < 0 Then eDMDisponibles.CANTIDAD = Decimal.Negate(eDMDisponibles.CANTIDAD)
                        eDMDisponibles.CANTIDADANTERIOR = CantidadDisponibleCapturaAnterior
                        eDMDisponibles.IDTIPOTRANSACCION = TiposTransaccion.AjusteInventarioMas
                    Case Is < 0
                        eL.CANTIDADDISPONIBLE = CantidadDisponibleCaptura
                        eDMDisponibles.CANTIDAD = CantidadDisponibleCaptura - CantidadDisponibleSistema - CantidadDisponibleDiferencia
                        If eDMDisponibles.CANTIDAD < 0 Then eDMDisponibles.CANTIDAD = Decimal.Negate(eDMDisponibles.CANTIDAD)
                        eDMDisponibles.CANTIDADANTERIOR = CantidadDisponibleCapturaAnterior
                        eDMDisponibles.IDTIPOTRANSACCION = TiposTransaccion.AjusteInventarioMenos
                End Select

            End If

        End If

        If CType(gvLista.Rows(gvLista.SelectedIndex).FindControl("txtNoDisponibleCaptura"), NumericBox).Text <> String.Empty Then

            Dim CantidadNoDisponibleSistema As Decimal = gvLista.DataKeys.Item(gvLista.SelectedIndex).Values.Item("CANTIDADNODISPONIBLESISTEMA")
            Dim CantidadNoDisponibleCaptura As Decimal = CType(gvLista.Rows(gvLista.SelectedIndex).FindControl("txtNoDisponibleCaptura"), NumericBox).Text
            Dim CantidadNoDisponibleDiferencia As Decimal = CantidadNoDisponibleSistema - CantidadNoDisponibleCaptura

            Select Case CantidadNoDisponibleDiferencia
                Case 0
                    'no hay diferencia
                Case Is > 0
                    eL.CANTIDADNODISPONIBLE = CantidadNoDisponibleCaptura
                    eDMNoDisponibles.CANTIDAD = CantidadNoDisponibleDiferencia
                    eDMNoDisponibles.IDTIPOTRANSACCION = TiposTransaccion.AjusteInventarioMas
                Case Is < 0
                    eL.CANTIDADNODISPONIBLE = CantidadNoDisponibleCaptura
                    eDMNoDisponibles.CANTIDAD = Decimal.Negate(CantidadNoDisponibleDiferencia)
                    eDMNoDisponibles.IDTIPOTRANSACCION = TiposTransaccion.AjusteInventarioMenos
            End Select

        End If

        If CType(gvLista.Rows(gvLista.SelectedIndex).FindControl("txtVencidaCaptura"), NumericBox).Text <> String.Empty Then

            Dim CantidadVencidaSistema As Decimal = gvLista.DataKeys.Item(gvLista.SelectedIndex).Values.Item("CANTIDADVENCIDASISTEMA")
            Dim CantidadVencidaCaptura As Decimal = CType(gvLista.Rows(gvLista.SelectedIndex).FindControl("txtVencidaCaptura"), NumericBox).Text
            Dim CantidadVencidaDiferencia As Decimal = CantidadVencidaSistema - CantidadVencidaCaptura

            Select Case CantidadVencidaDiferencia
                Case 0
                    'no hay diferencia
                Case Is > 0
                    eL.CANTIDADVENCIDA = CantidadVencidaCaptura
                    eDMVencidos.CANTIDAD = CantidadVencidaDiferencia
                    eDMVencidos.IDTIPOTRANSACCION = TiposTransaccion.AjusteInventarioMas
                Case Is < 0
                    eL.CANTIDADVENCIDA = CantidadVencidaCaptura
                    eDMVencidos.CANTIDAD = Decimal.Negate(CantidadVencidaDiferencia)
                    eDMVencidos.IDTIPOTRANSACCION = TiposTransaccion.AjusteInventarioMenos
            End Select
        End If


        If eDMDisponibles.CANTIDAD = 0 And eDMNoDisponibles.CANTIDAD = 0 And eDMVencidos.CANTIDAD = 0 Then
            'no hay cambios
        Else
            Dim eM As New MOVIMIENTOS
            eM.IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
            eM.IDESTADO = eESTADOSMOVIMIENTOS.Cerrado
            eM.IDALMACEN = Me.IDALMACEN
            eM.ANIO = Now.Year
            eM.IDEMPLEADOALMACEN = Session.Item("IdEmpleado")
            eM.FECHAMOVIMIENTO = Now.Date
            eM.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
            eM.AUFECHACREACION = Now()

            eL.IDALMACEN = Me.IDALMACEN
            eL.IDLOTE = gvLista.DataKeys.Item(gvLista.SelectedIndex).Values.Item("IDLOTE")
            eL.AUUSUARIOMODIFICACION = eM.AUUSUARIOCREACION
            eL.AUFECHAMODIFICACION = eM.AUFECHACREACION

            Dim eCA As New CORRECCIONESALMACENES
            eCA.IDALMACEN = Me.IDALMACEN
            eCA.ANIO = Now.Year
            eCA.MOTIVO = txtMotivo.Text
            eCA.OBSERVACION = Me.txtObservacion.Text
            eCA.AUUSUARIOCREACION = eM.AUUSUARIOCREACION
            eCA.AUFECHACREACION = eM.AUFECHACREACION

            Dim eDI As New DETALLEINVENTARIO
            eDI.IDALMACEN = Me.IDALMACEN
            eDI.IDINVENTARIO = Me.IDINVENTARIO
            eDI.IDDETALLE = gvLista.DataKeys.Item(gvLista.SelectedIndex).Values.Item("IDDETALLE")
            eDI.AUUSUARIOMODIFICACION = eM.AUUSUARIOCREACION
            eDI.AUFECHAMODIFICACION = eM.AUFECHACREACION

            eDMDisponibles.IDLOTE = eL.IDLOTE
            eDMDisponibles.IDPRODUCTO = gvLista.DataKeys.Item(gvLista.SelectedIndex).Values.Item("IDPRODUCTO")
            eDMDisponibles.AUUSUARIOMODIFICACION = eM.AUUSUARIOCREACION
            eDMDisponibles.AUFECHAMODIFICACION = eM.AUFECHACREACION
            eDMNoDisponibles.AUUSUARIOMODIFICACION = eM.AUUSUARIOCREACION
            eDMNoDisponibles.AUFECHAMODIFICACION = eM.AUFECHACREACION
            eDMVencidos.AUUSUARIOMODIFICACION = eM.AUUSUARIOCREACION
            eDMVencidos.AUFECHAMODIFICACION = eM.AUFECHACREACION

            Dim cDI As New cDETALLEINVENTARIO
            cDI.AjusteInventario(eCA, eM, eDMDisponibles, eDMNoDisponibles, eDMVencidos, eL, eDI)

        End If

        Me.plAjuste.Visible = False

        ObtenerDetalleInventario()

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ddlGRUPOSFUENTEFINANCIAMIENTO1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedIndexChanged
        Me.ddlFUENTEFINANCIAMIENTOS1.RecuperarPorGrupo(Me.ddlGRUPOSFUENTEFINANCIAMIENTO1.SelectedValue)
    End Sub

End Class
