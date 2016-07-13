Imports System.Data
Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class frmConsolidarProgramaCompras
    Inherits System.Web.UI.Page
    Private mComponente As New cNECESIDADESTABLECIMIENTOS
    Private mCompEstablecimientos As New cESTABLECIMIENTOS
    Private mCompEstimacionNecesidades As New cNECESIDADESTABLECIMIENTOS
    Private mCompSolicitudes As New cSOLICITUDES
    Private mEntSolicitudes As SOLICITUDES
    Private mCompDetalleSolicitud As New cDETALLESOLICITUDES
    Private mEntDetalleSolicitudes As New DETALLESOLICITUDES
    Private bEstimacionesXEstablecimientos As Boolean = False
    Private IPeriodo As Int16 = Year(Now)
    Friend iLimiteEntrega As New Int16
    Private bCargado As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Master.ControlMenu.Visible = False
        If Not Page.IsPostBack Then
            Me.TxtAnio.Text = Year(Now)
            Me.DdlSUMINISTROS1.Visible = True
            Me.DdlPROPUESTASDISPONIBLES1.RecuperarListaFiltrada(IPeriodo)
            Me.DdlSUMINISTROS1.RecuperarListaFiltrada(1)

        End If
    End Sub

    Private Sub CargarDatos()
        Me.DdlSUMINISTROS1.Recuperar()
    End Sub

    Protected Sub BtnVerifica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVerifica.Click
        mEntSolicitudes = New SOLICITUDES
        mEntSolicitudes.IDESTABLECIMIENTO = Session.Item("idestablecimiento")
        mEntSolicitudes.IDSOLICITUD = 0
        mEntSolicitudes.CORRELATIVO = mCompSolicitudes.Correlativo_Solicitud(mEntSolicitudes) & "/" & DateTime.Now.ToString("yy")
        mEntSolicitudes.FECHASOLICITUD = Now()
        mEntSolicitudes.PLAZOENTREGA = 1 'Acordate de sacar el mayor de los plazos de entrega
        mEntSolicitudes.IDCLASESUMINISTRO = 1
        mEntSolicitudes.PERIODOUTILIZACION = 12
        mEntSolicitudes.MONTOSOLICITADO = 0
        mEntSolicitudes.MONTODISPONIBLE = 0
        mEntSolicitudes.OBSERVACION = "Solicituda elaborada para la compra conjunta del MSPAS"
        mEntSolicitudes.IDSOLICITANTE = Session.Item("IdEmpleado")
        mEntSolicitudes.IDAREATECNICA = Session.Item("IdEmpleado")
        mEntSolicitudes.CIFRADOPRESUPUESTARIO = "1"
        mEntSolicitudes.RESERVAFONDO = 1
        mEntSolicitudes.FECHAAUTORIZACION = Now()
        mEntSolicitudes.MONTOAUTORIZADO = 0
        mEntSolicitudes.CODRESERVAFONDO = ""
        mEntSolicitudes.IDCERTIFICA = Session.Item("IdEmpleado")
        mEntSolicitudes.IDAUTORIZA = Session.Item("IdEmpleado")
        mEntSolicitudes.IDESTADO = 1
        mEntSolicitudes.IDDEPENDENCIASOLICITANTE = Session.Item("IdDependencia")
        mEntSolicitudes.IDTIPOCOMPRASOLICITADO = 5
        mEntSolicitudes.IDTIPOCOMPRASUGERIDO = 5
        mEntSolicitudes.IDTIPOCOMPRAEJECUTAR = 5
        mEntSolicitudes.IDALMACENENTREGA = 1
        mEntSolicitudes.COMPRACONJUNTA = 1
        mEntSolicitudes.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
        mEntSolicitudes.AUFECHACREACION = Now()
        mEntSolicitudes.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
        mEntSolicitudes.AUFECHAMODIFICACION = Now()
        mEntSolicitudes.NUMCORR = mCompSolicitudes.Correlativo_Solicitud(mEntSolicitudes)
        mEntSolicitudes.ESTASINCRONIZADA = 0

        Me.LblDocumento.Text = mCompSolicitudes.id_Solicitud(mEntSolicitudes)
        If mCompSolicitudes.ActualizarSOLICITUDES(mEntSolicitudes) <> 1 Then
            MsgBox1.ShowAlert("El proceso no puede ser completado favor reinicie el proceso de consolidacion del programa de compras", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If
        Me.bEstimacionesXEstablecimientos = True

        Me.BtnPlazosEntregas.Visible = True
        Me.UcPlazosEntrega1.IDSOLICITUD = Me.LblDocumento.Text
        Me.PnlPlazosEntrega.Visible = True
        Me.BtnVerifica.Visible = False
        Me.BtnCancelar.Visible = True
        Me.LblOrden.Text = "Paso No 3"

    End Sub

    Protected Sub BtnPlazosEntregas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPlazosEntregas.Click
        If Me.UcPlazosEntrega1.DEFINIDO = True Then
            Me.PnlPlazosEntrega.Visible = False
            Me.BtnPlazosEntregas.Visible = False
            Me.BtnObtenerConsolidado.Visible = True
            Me.BtnCancelar.Visible = True
            Me.LblOrden.Text = "Paso No 4"
        Else
            MsgBox1.ShowAlert("Debe definir al menos un plazo de entrega para poder continuar", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)

        End If

    End Sub

    Protected Sub BtnObtenerConsolidado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnObtenerConsolidado.Click
        CargarConsolidado()
        Me.BtnObtenerConsolidado.Visible = False
        Me.BtnGuardarConsolidado.Visible = True
        Me.BtnGuardarConsolidado2.Visible = True
        Me.BtnGuardarTodo.Visible = True
        Me.BtnCancelar.Visible = True
        Me.LblOrden.Text = "Paso No 5"

    End Sub

    Private Sub CargarConsolidado()
        Dim mCompDetalleEstimacionNecesidades As New cDETALLENECESIDADESTABLECIMIENTOS
        Dim mCompNecesidadesXsolicitud As New cNECESIDADESSOLICITUD
        Dim mEntNecesidadesxsolicitud As New NECESIDADESSOLICITUD
        Dim mCompAlternativasProductos As New cALTERNATIVASPRODUCTO
        Dim mCompDetalleSolicitud2 As New cDETALLESOLICITUDES
        Dim dsConsolidado As DataSet
        Dim dsConsolidadoProducto As DataSet
        Dim dsAlternativasProductos As DataSet
        Dim dsNecesidadesXsolicitud As DataSet
        Dim iNuevaCantidad As Decimal
        Dim iFila As Int64
        Dim iFila2 As Int64
        Dim iContinuar As Int16

        If mCompDetalleEstimacionNecesidades.ConsolidarEstimaciones(Me.TxtAnio.Text, Me.DdlPROPUESTASDISPONIBLES1.SelectedValue, Me.LblDocumento.Text, Session.Item("idestablecimiento")) = 1 Then
            MsgBox1.ShowAlert("La transaccion no pudo ser realizada favor consulte con el departamente de soporte técnico", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            dsConsolidado = mCompDetalleSolicitud.ObtenerDsConsolidado(Me.LblDocumento.Text, Session.Item("idestablecimiento"))
            If IsNothing(dsConsolidado) Then
                MsgBox1.ShowAlert("El proceso no puede ser realizado por inconsistencias a nivel de datos favor consulte con el departamentamento de soporte técnico", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                For iFila = 0 To (dsConsolidado.Tables(0).Rows.Count - 1)
                    dsAlternativasProductos = mCompAlternativasProductos.ObtenerDsAlternativas(dsConsolidado.Tables(0).Rows(iFila).Item("IDPRODUCTO"))
                    If dsAlternativasProductos.Tables(0).Rows.Count > 0 Then
                        dsConsolidadoProducto = mCompDetalleSolicitud2.ObtenerDsConsolidadoPorProducto(Me.LblDocumento.Text, Session.Item("idestablecimiento"), dsConsolidado.Tables(0).Rows(iFila).Item("IDPRODUCTO"))
                        iNuevaCantidad = dsConsolidadoProducto.Tables(0).Rows(0).Item("CANTIDAD")
                        For iFila2 = 0 To (dsAlternativasProductos.Tables(0).Rows.Count - 1)
                            dsConsolidadoProducto = mCompDetalleSolicitud2.ObtenerDsConsolidadoPorProducto(Me.LblDocumento.Text, Session.Item("idestablecimiento"), dsAlternativasProductos.Tables(0).Rows(iFila2).Item("IDALTERNATIVA"))
                            If dsConsolidadoProducto.Tables(0).Rows.Count > 0 Then
                                iNuevaCantidad = iNuevaCantidad + dsConsolidadoProducto.Tables(0).Rows(0).Item("CANTIDAD")
                            End If
                        Next
                    Else
                        Dim IDPRODUCTO2 As Int64 = 0
                        IDPRODUCTO2 = mCompAlternativasProductos.ObtenerDsAlternativasDe(dsConsolidado.Tables(0).Rows(iFila).Item("IDPRODUCTO"))
                        dsAlternativasProductos = mCompAlternativasProductos.ObtenerDsAlternativas(IDPRODUCTO2)
                        If dsAlternativasProductos.Tables(0).Rows.Count > 0 Then
                            dsConsolidadoProducto = mCompDetalleSolicitud2.ObtenerDsConsolidadoPorProducto(Me.LblDocumento.Text, Session.Item("idestablecimiento"), IDPRODUCTO2)
                            If dsConsolidadoProducto.Tables(0).Rows.Count = 0 Then
                                iContinuar = 1
                                iNuevaCantidad = 0
                            Else
                                iContinuar = 0
                                iNuevaCantidad = dsConsolidadoProducto.Tables(0).Rows(0).Item("CANTIDAD")
                            End If
                            For iFila2 = 0 To (dsAlternativasProductos.Tables(0).Rows.Count - 1)
                                dsConsolidadoProducto = mCompDetalleSolicitud2.ObtenerDsConsolidadoPorProducto(Me.LblDocumento.Text, Session.Item("idestablecimiento"), dsAlternativasProductos.Tables(0).Rows(iFila2).Item("IDALTERNATIVA"))
                                If dsConsolidadoProducto.Tables(0).Rows.Count > 0 And iContinuar = 1 Then
                                    iNuevaCantidad = iNuevaCantidad + dsConsolidadoProducto.Tables(0).Rows(0).Item("CANTIDAD")
                                End If
                            Next
                        End If
                    End If
                    'Actualizando el detalle de la solicitud
                    mEntDetalleSolicitudes.IDDETALLE = dsConsolidado.Tables(0).Rows(iFila).Item("IDDETALLE")
                    mEntDetalleSolicitudes.IDSOLICITUD = dsConsolidado.Tables(0).Rows(iFila).Item("IDSOLICITUD")
                    mEntDetalleSolicitudes.IDESTABLECIMIENTO = dsConsolidado.Tables(0).Rows(iFila).Item("IDESTABLECIMIENTO")
                    mCompDetalleSolicitud.ObtenerDETALLESOLICITUDES(mEntDetalleSolicitudes)
                    mEntDetalleSolicitudes.CANTIDAD = iNuevaCantidad
                    If iNuevaCantidad > 0 Then
                        mCompDetalleSolicitud.ActualizarDETALLESOLICITUDES(mEntDetalleSolicitudes)
                    End If
                    iNuevaCantidad = 0
                Next
                Me.PnlConsolidado.Visible = True
                Me.PnlPlazosEntrega.Visible = False

                dsConsolidado = mCompDetalleSolicitud.ObtenerDsConsolidado(Me.LblDocumento.Text, Session.Item("idestablecimiento"))
                Me.dgConsolidado.DataSource = dsConsolidado
                Me.dgConsolidado.DataBind()
            End If
            dsNecesidadesXsolicitud = mComponente.FiltrarEstimacionNecesidades(Me.TxtAnio.Text, Me.DdlPROPUESTASDISPONIBLES1.SelectedValue)
            If IsNothing(dsNecesidadesXsolicitud) Then
                MsgBox1.ShowAlert("La consolidación de las necesidades fue llevada a cabo pero con errores el reporte de distribucion no podra ser generado, reporte el problema al departamento de soporte", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Else
                For iFila = 0 To (dsNecesidadesXsolicitud.Tables(0).Rows.Count - 1)
                    mEntNecesidadesxsolicitud.IDESTABLECIMIENTONECESIDAD = dsNecesidadesXsolicitud.Tables(0).Rows(iFila).Item("IDESTABLECIMIENTO")
                    mEntNecesidadesxsolicitud.IDESTABLECIMIENTOSOLICITUD = Session.Item("idestablecimiento")
                    mEntNecesidadesxsolicitud.IDNECESIDAD = dsNecesidadesXsolicitud.Tables(0).Rows(iFila).Item("IDNECESIDAD")
                    mEntNecesidadesxsolicitud.IDSOLICITUD = Me.LblDocumento.Text
                    mEntNecesidadesxsolicitud.AUUSUARIOCREACION = HttpContext.Current.User.Identity.Name
                    mEntNecesidadesxsolicitud.AUFECHACREACION = Now()
                    mEntNecesidadesxsolicitud.AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    mEntNecesidadesxsolicitud.AUFECHAMODIFICACION = Now()
                    mEntNecesidadesxsolicitud.ESTASINCRONIZADA = 0

                    mCompNecesidadesXsolicitud.AgregarNECESIDADESSOLICITUD(mEntNecesidadesxsolicitud)

                Next iFila
            End If
        End If
    End Sub

    Private Sub CargarConsolidado2()
        Dim mCompDetalleEstimacionNecesidades As New cDETALLENECESIDADESTABLECIMIENTOS

        Dim dsConsolidado As DataSet
        dsConsolidado = mCompDetalleSolicitud.ObtenerDsConsolidado(Me.LblDocumento.Text, Session.Item("idestablecimiento"))

        If IsNothing(dsConsolidado) Then
            MsgBox1.ShowAlert("El proceso no puede ser realizado por inconsistencias a nivel de datos favor consulte con el departamentamento de soporte técnico", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            Me.dgConsolidado.DataSource = dsConsolidado
            Me.dgConsolidado.DataBind()
        End If
    End Sub

    Private Sub ActualizarNecesidadesSolicitudes()
        Dim dsNecesidades As DataSet
        dsNecesidades = mCompEstimacionNecesidades.FiltrarEstimacionNecesidades(Me.TxtAnio.Text, Me.DdlPROPUESTASDISPONIBLES1.SelectedValue)
        If IsNothing(dsNecesidades) Then
            MsgBox1.ShowAlert("El proceso no puede ser completado se han encontrado errores en la información procesada", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else

        End If
    End Sub

    Protected Sub dgConsolidado_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgConsolidado.PageIndexChanged
        Me.dgConsolidado.CurrentPageIndex = e.NewPageIndex
        Me.CargarConsolidado2()
    End Sub

    Protected Sub BtnImprimirConsolidado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimirConsolidado.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptConsolidadoEstimaciones.aspx?id=" + Me.LblDocumento.Text + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub BtnImprimirDistribucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimirDistribucion.Click
        Page.ClientScript.RegisterStartupScript(Me.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/FrmRptConsolidadoDistribucion0.aspx?id=" + Me.LblDocumento.Text + "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub dgConsolidado_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgConsolidado.UpdateCommand
        Dim iLimite As Int16 = 0
        iLimite = ValidarLimiteEntrega()
        If iLimite = 0 Then
            GuardarTodo()
        Else
            MsgBox1.ShowAlert("Se ha excedido el limite de las entregas favor corregirlo para poder continuar con el proceso de actualización", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If
    End Sub

    Private Sub GuardarTodo()
        Dim mCompDetalleSolicitud2 As New cDETALLESOLICITUDES
        Dim lEntidad As New DETALLESOLICITUDES
        Dim text As New TextBox

        For Each a As DataGridItem In Me.dgConsolidado.Items
            text = a.FindControl("txtEntregas")
            With lEntidad
                .IDSOLICITUD = Me.dgConsolidado.Items(a.ItemIndex).Cells(1).Text
                .IDDETALLE = Me.dgConsolidado.Items(a.ItemIndex).Cells(2).Text
                .IDESTABLECIMIENTO = Session.Item("IdEstablecimiento")
                mCompDetalleSolicitud2.ObtenerDETALLESOLICITUDES(lEntidad)
                .NUMEROENTREGAS = text.Text
                .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                .AUFECHAMODIFICACION = Now()
                .ESTASINCRONIZADA = 0

            End With
            mCompDetalleSolicitud2.ActualizarDETALLESOLICITUDES(lEntidad)
        Next
    End Sub

    Private Function ValidarLimiteEntrega() As Int16
        Dim mCompDetalleEntregas As New cDETALLEENTREGAS
        Dim iLimite As Int16 = 0
        Dim text As New TextBox

        iLimite = mCompDetalleEntregas.ObtenerLimiteEntrega(Session.Item("IdEstablecimiento"), Me.LblDocumento.Text)

        For Each a As DataGridItem In Me.dgConsolidado.Items
            text = a.FindControl("txtEntregas")
            If Val(text.Text) > iLimite Then
                Return 1
            End If
        Next
        Return 0
    End Function

    Protected Sub BtnGuardarConsolidado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardarConsolidado.Click
        Dim iLimite As Int16 = 0
        iLimiteEntrega = ValidarLimiteEntrega()
        If iLimiteEntrega = 0 Then
            GuardarTodo()
            MsgBox1.ShowAlert("Las entregas por renglon han sido almacenadas correctamente", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            MsgBox1.ShowAlert("Se ha excedido el limite de las entregas favor corregirlo para poder continuar con el proceso de actualización", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If

    End Sub


    Protected Sub BtnGuardarConsolidado2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardarConsolidado2.Click
        iLimiteEntrega = ValidarLimiteEntrega()
        If iLimiteEntrega = 0 Then
            GuardarTodo()
            MsgBox1.ShowAlert("Las entregas por renglon han sido almacenadas correctamente", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        Else
            MsgBox1.ShowAlert("Se ha excedido el limite de las entregas favor corregirlo para poder continuar con el proceso de actualización", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
        End If
    End Sub

    Protected Sub BtnValidar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnValidar.Click
        Dim dsEstablecimientos As DataSet
        Dim dsEstimacionNecesidades As DataSet
        Dim iTotalEsta As Int32 = 0
        Dim iTotalEstNece As Int32 = 0

        If Me.TxtAnio.Text = "" Then
            MsgBox1.ShowAlert("Falta definir el año de trabajo", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Return
        End If

        If IsNumeric(Me.TxtAnio.Text) And Val(Me.TxtAnio.Text) > 0 Then

        Else
            MsgBox1.ShowAlert("El año de trabajo es incorrecto favor verificarlo", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtAnio.Focus()

        End If
        'Me.DdlPROPUESTASDISPONIBLES1.RecuperarListaFiltrada(Me.TxtAnio.Text)

        If Me.DdlPROPUESTASDISPONIBLES1.SelectedIndex = -1 Then
            MsgBox1.ShowAlert("No se encontraro ninguna información necesidad para el año seleccionado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
            Me.TxtAnio.Focus()
        Else
            dsEstablecimientos = mCompEstablecimientos.FiltrarEstabParaConsolidado()
            iTotalEsta = dsEstablecimientos.Tables(0).Rows.Count

            dsEstimacionNecesidades = mCompEstimacionNecesidades.FiltrarEstimacionNecesidades(Val(Me.TxtAnio.Text), Me.DdlPROPUESTASDISPONIBLES1.SelectedItem.Value)
            iTotalEstNece = dsEstimacionNecesidades.Tables(0).Rows.Count

            '==========================
            iTotalEsta = 1
            iTotalEstNece = 1
            '==========================

            If iTotalEsta > iTotalEstNece Then
                MsgBox1.ShowAlert("La consolidación no puede ser realizada porque no todos los establecimientos han completado el proceso", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
                Me.bEstimacionesXEstablecimientos = False
                Me.BtnPlazosEntregas.Enabled = False
            Else
                Me.BtnValidar.Visible = False
                Me.BtnVerifica.Visible = True
                Me.TxtAnio.Enabled = False
                Me.DdlPROPUESTASDISPONIBLES1.Enabled = False
                Me.DdlSUMINISTROS1.Enabled = False
                Me.btnObtenerPropuestas.Visible = False
                Me.LblOrden.Text = "Paso No 2"
            End If
        End If
    End Sub

    Protected Sub BtnGuardarTodo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardarTodo.Click
        Me.BtnImprimirConsolidado.Visible = True
        Me.BtnImprimirDistribucion.Visible = True
        Me.BtnGuardarConsolidado.Visible = False
        Me.BtnGuardarConsolidado2.Visible = False
        Me.BtnGuardarTodo.Visible = False
        Me.BtnCancelar.Visible = False
        Me.ImgbSalir.Visible = True
        Me.LblOrden.Text = "Proceso finalizado"
        MsgBox1.ShowAlert("El proceso de consolidación ha finalizado de forma correcta cualquier modificación debera realizarla desde la opción de mantenimiento de solicitudes", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction, Cooperator.Framework.Web.Controls.AlertType.Information)
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim mCompDetalleEntregas As New cDETALLEENTREGAS
        Dim mCompEntregas As New cENTREGASOLICITUDES
        Dim mCompNecesidadesSolicitud As New cNECESIDADESSOLICITUD


        mCompDetalleEntregas.EliminarDETALLEENTREGASxSolicitud(Me.LblDocumento.Text, Session("IdEstablecimiento"))
        mCompEntregas.EliminarENTREGASXSolicitud(Me.LblDocumento.Text, Session("IdEstablecimiento"))

        mCompDetalleSolicitud.EliminarDetallesSolicitud(Me.LblDocumento.Text, Session("IdEstablecimiento"))
        mCompNecesidadesSolicitud.EliminarSolicitud(Me.LblDocumento.Text, Session("IdEstablecimiento"))
        mCompSolicitudes.EliminarSOLICITUDES(Session("IdEstablecimiento"), Me.LblDocumento.Text)

        MsgBox1.ShowAlert("El proceso de consolidación fue cancelado", "A", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub btnObtenerPropuestas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnObtenerPropuestas.Click
        Me.DdlPROPUESTASDISPONIBLES1.RecuperarListaFiltrada(Me.TxtAnio.Text)
    End Sub

    Protected Sub ImgbSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbSalir.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
End Class

