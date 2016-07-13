
Imports System.Linq
Imports System.Collections.Generic
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Utils.MessageBox

Partial Class Controles_Ctrl_Paso1_CrearSolicitudCompra
    Inherits System.Web.UI.UserControl
#Region "Propiedades"
    ''' <summary>
    ''' Asigna la solicitud actual (creada o no) para poder utilizarla y cargar los datos
    ''' </summary>
    ''' <value>sab_est_solicitud</value>
    ''' <returns>el valor de viewstate de tipo sab_est_solicitud</returns>
    ''' <remarks>al asignar la solicitud este mismo valor de solicitud lo asigna a administradores de contrato OJO!</remarks>
    Public Property Solicitud As SAB_EST_SOLICITUDES
        Get
            Return CType(ViewState("_solicitud"), SAB_EST_SOLICITUDES)
        End Get
        Set(value As SAB_EST_SOLICITUDES)
            ViewState("_solicitud") = value
            Administradores.Solicitud = value
        End Set
    End Property
    Public ReadOnly Property ValidationGroup() As String
        Get
            Return vfMonto.ValidationGroup
        End Get
    End Property

    Public Property Dependencia As String
        Get
            Return LblDependencia.Text
        End Get
        Set(value As String)
            LblDependencia.Text = value
        End Set
    End Property

    Public Property UnidadSolicitante As String
        Get
            Return ddlUnidadSolicitante.SelectedValue
        End Get
        Set(value As String)
            If String.IsNullOrEmpty(value) Then
                cddSuministros.SelectedValue = Membresia.ObtenerUsuario().Dependencia.IDDEPENDENCIA.ToString()
            Else
                cddSuministros.SelectedValue = value
            End If
        End Set
    End Property
#End Region

#Region "Handlers"
    Public Event AsignarSolicitud As EventHandler
#End Region

#Region "Eventos"
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim usr = Membresia.ObtenerUsuario()

            Solicitud = New SAB_EST_SOLICITUDES()
            With Solicitud
                .IDESTABLECIMIENTO = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
                .IdDependenciaCrea = usr.Dependencia.IDDEPENDENCIA
                .IDSOLICITUDEPENDENCIA = usr.Dependencia.IDDEPENDENCIA

                .IDESTADO = 1
                .IDDEPENDENCIASOLICITANTE = CType(ddlUnidadSolicitante.SelectedValue, Integer)
                .IDUNIDADTECNICA = CType(DdlDEPENDENCIAS1.SelectedValue, Integer?)

            End With
            
            Dim ministro = CatalogoHelpers.Empleados.ObtenerMinistro()
            If Not ministro Is Nothing Then
                Solicitud.EMPLEADOAUTORIZA = ministro.NOMBRE + " " + ministro.APELLIDO
                Solicitud.AutorizaCargo = ministro.SAB_CAT_CARGOS.DESCRIPCION
            End If

            Dim jefe = CatalogoHelpers.Empleados.ObtenerJefeUFI(usr.ESTABLECIMIENTO.IDESTABLECIMIENTO)
            If Not jefe Is Nothing Then
                Solicitud.FondosCargo = jefe.SAB_CAT_CARGOS.DESCRIPCION
                Solicitud.FondosNombre = jefe.NOMBRE + " " + jefe.APELLIDO
            End If

            If Solicitud.IDCLASESUMINISTRO = 0 Then
                Alert(" La dependencia " & DdlDEPENDENCIAS1.SelectedItem.Text & "(" & DdlDEPENDENCIAS1.SelectedValue & "), no posee suministros favor de comunicarse con el personal responsable")
                Exit Sub
            End If

            With Solicitud
                .IDSOLICITUD = EstablecimientoHelpers.Solicitudes.ObtenerMaximoId(Solicitud.IDESTABLECIMIENTO) + 1
                .CORRELATIVO = usr.Dependencia.CODIGO & "-" & .IDSOLICITUD & "/" & DateTime.Now.Year
                .COMPRACONJUNTA = 0
                .AUUSUARIOCREACION = usr.NombreUsuario
                .AUFECHACREACION = DateTime.Now
            End With

            EstablecimientoHelpers.Solicitudes.Agregar(Solicitud)

            tbCargoCF.Text = Solicitud.FondosCargo
            tbNombreCF.Text = Solicitud.FondosNombre

            tbAutorizaNombre.Text = Solicitud.EMPLEADOAUTORIZA
            tbAutorizaCargo.Text = Solicitud.AutorizaCargo

            Label2.Text = Solicitud.CORRELATIVO + "-" + CType(Solicitud.CorrelativoGeneral, String)
            If String.IsNullOrEmpty(Solicitud.FECHASOLICITUD.ToString()) Then
                CalendarPopup1.Text = DateTime.Now.ToShortDateString()
            Else : CalendarPopup1.Text = CType(Solicitud.FECHASOLICITUD, DateTime).ToShortDateString()
            End If

            CargarAdministradores()

            moreStep1.Visible = True
            Button1.Visible = False

            RaiseEvent AsignarSolicitud(sender, e)

        Catch ex As Exception
            Alert("un error a ocurrido al guardar solicitud: " + ex.Message)
        End Try

    End Sub
#End Region

#Region "Métodos Públicos"
    ''' <summary>
    ''' Utiliza la solicitud previamente encontrada para cargar los datos necesarios para generar el encabezado
    ''' </summary>
    ''' <param name="solicitudEncontrada">solicitud previamente encontrada</param>
    ''' <remarks></remarks>
    Public Sub CargarDatos(solicitudEncontrada As SAB_EST_SOLICITUDES)
        Solicitud = solicitudEncontrada
        cddUnidadTecnica.SelectedValue = CType(Solicitud.IDDEPENDENCIASOLICITANTE, String)
        UnidadSolicitante = CType(Solicitud.IDUNIDADTECNICA, String)

        If Solicitud.CorrelativoGeneral > 0 Then
            Label2.Text = Solicitud.CORRELATIVO + "-" + CType(Solicitud.CorrelativoGeneral, String)
        Else
            Label2.Text = Solicitud.CORRELATIVO
        End If

        If String.IsNullOrEmpty(Solicitud.FECHASOLICITUD.ToString()) Then
            CalendarPopup1.Text = DateTime.Now.ToShortDateString()
        Else : CalendarPopup1.Text = CType(Solicitud.FECHASOLICITUD, DateTime).ToShortDateString()
        End If

        TextBox1.Text = EvaluarAString(Solicitud.EMPLEADOSOLICITANTE)
        TextBox6.Text = EvaluarAString(Solicitud.CARGOSOLICITANTE)
        TextBox10.Text = EvaluarAString(Solicitud.OBSERVACION)
        tbMontoAutorizado.Text = Solicitud.MONTOAUTORIZADO.ToString()

        tbCargoCF.Text = Solicitud.FondosCargo
        tbNombreCF.Text = Solicitud.FondosNombre

        ' tbCifrado.Text = Solicitud.CIFRADOPRESUPUESTARIO
        tbAutorizaNombre.Text = Solicitud.EMPLEADOAUTORIZA
        tbAutorizaCargo.Text = Solicitud.AutorizaCargo

        tbATNombre.Text = Solicitud.EMPLEADOAREATECNICA
        tbATCargo.Text = Solicitud.AreaTecnicaCargo
        
        CargarAdministradores()

        Button1.Visible = False
        moreStep1.Visible = True
    End Sub

    ''' <summary>
    ''' Agrega o Elimina Administradores de contrato dependiendo de la acción que desencadene el usuario
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CargarAdministradores()
        Administradores.Solicitud = Solicitud
        Administradores.CargarAdministradoresNoSolicitud()
    End Sub
    
    Public Function SolicitudCargarDatos() As SAB_EST_SOLICITUDES
        With Solicitud
            .FECHASOLICITUD = CType(CalendarPopup1.Text, Date)
            ' .PERIODOUTILIZACION = CType(tbPeriodo.Text, Short?)
            .EMPLEADOSOLICITANTE = TextBox1.Text
            .CARGOSOLICITANTE = TextBox6.Text
            .OBSERVACION = TextBox10.Text
            .IDSOLICITUDEPENDENCIA = Membresia.ObtenerUsuario().Dependencia.IDDEPENDENCIA
            .IDUNIDADTECNICA = CType(DdlDEPENDENCIAS1.SelectedValue, Integer?)
            .MONTOAUTORIZADO = CType(tbMontoAutorizado.Text, Decimal?)
            .IDDEPENDENCIASOLICITANTE = CType(ddlUnidadSolicitante.SelectedValue, Integer)
            .FondosCargo = tbCargoCF.Text
            .FondosNombre = tbNombreCF.Text

            .EMPLEADOAUTORIZA = tbAutorizaNombre.Text
            .AutorizaCargo = tbAutorizaCargo.Text

            .EMPLEADOAREATECNICA = tbATNombre.Text
            .AreaTecnicaCargo = tbATCargo.Text

            '     .CIFRADOPRESUPUESTARIO = tbCifrado.Text

        End With
        Return Solicitud
    End Function
#End Region

#Region "Métodos Privados"
    Private Shared Function EvaluarAString(ByVal cadena As Object) As String
        If String.IsNullOrEmpty(cadena) Then Return String.Empty
        Return cadena.ToString()
    End Function
#End Region
End Class
