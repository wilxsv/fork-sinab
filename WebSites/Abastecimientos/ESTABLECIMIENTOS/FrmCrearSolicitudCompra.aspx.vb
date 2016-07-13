Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades
Imports SINAB_Utils.MessageBox
Imports System.Linq
Imports SINAB_Entidades.Tipos


Partial Class UACI_FrmCrearSolicitudCompra
    Inherits System.Web.UI.Page
#Region "Propiedades"
    Public Property IdSolicitud as Long
        Get
            Return CType(Session("solicitud"), integer)
        End Get
        Set(ByVal value As Long)
            Session("solicitud") = value
        End Set
    End Property

    Public Property IdEstablecimiento as Integer
    get
            Return CType(Session("establecimiento"), Integer)
    End Get
    Set(value As Integer)
            Session("establecimiento") = value
    End Set
    End Property
    ''' <summary>
    ''' Lleva el conteo de los items agregados a la Grid gvProdcutosDistribucion.
    ''' </summary>
    ''' <value>int</value>
    ''' <returns>el número de los items agregados</returns>
    ''' <remarks>
    ''' PASO 6
    ''' </remarks>
    Public Property CountAgregados As Integer
        Get
            Return CType(ViewState("cAgregados"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("cAgregados") = value
        End Set
    End Property
#End Region


    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim usr = Membresia.ObtenerUsuario()
                Master.ControlMenu.Visible = False

                Dim solicitud = New SAB_EST_SOLICITUDES()
                DatosGenerales.Solicitud = solicitud
                DatosGenerales.Dependencia = Membresia.ObtenerUsuario().Dependencia.NOMBRE
                DatosGenerales.UnidadSolicitante = String.Empty
                IdEstablecimiento = usr.ESTABLECIMIENTO.IDESTABLECIMIENTO
                If Request.QueryString("id") IsNot Nothing Then
                    IdSolicitud = CType(Request.QueryString("id"), Long)
                    solicitud = Solicitudes.Obtener(IdEstablecimiento, IdSolicitud, usr.NombreUsuario)
                    DatosGenerales.CargarDatos(solicitud)
                End If

                MostrarOcultarNavegacion(False)
                If Not solicitud.IDSOLICITUD = 0 Then
                    lnkNext.ValidationGroup = DatosGenerales.ValidationGroup
                    lnkNext.Visible = True
                End If
                
                Wizard1.ActiveViewIndex = 0

                If Not solicitud.CORRELATIVO = "" Then ltSolicitud.Text = "SOLICITUD : " + solicitud.CORRELATIVO
            Catch ex As Exception
                AlertSubmit("Error en Solicitud, No se encontró la solicitud : " & ex.Message, "Error Solicitud")
            End Try

            
        Else
            If ConfirmTarget = "Error Solicitud" Then
                Response.Redirect("~/ESTABLECIMIENTOS/FrmConsultarSolicitudes.aspx")
            End If
            If IdSolicitud = 0 And Wizard1.ActiveViewIndex > 0 Then
                If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
                    Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompra.aspx?id=" & Request.QueryString("id"))
                Else : Response.Redirect("~/ESTABLECIMIENTOS/FrmConsultarSolicitudes.aspx")
                End If

            End If

            If Wizard1.ActiveViewIndex = 0 Then
                If IdSolicitud > 0 Then DatosGenerales.CargarAdministradores()
            End If

        End If

    End Sub


#Region "PASO 1 - Datos Generales"
    Protected Sub DatosGenerales_AsignarSolicitud(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatosGenerales.AsignarSolicitud
        MostrarOcultarNavegacion(False)
        lnkNext.ValidationGroup = DatosGenerales.ValidationGroup
        lnkNext.Visible = True
        IdSolicitud = DatosGenerales.Solicitud.IDSOLICITUD
        IdEstablecimiento = DatosGenerales.Solicitud.IDESTABLECIMIENTO
    End Sub

    ''' <summary>
    ''' Actualiza la solicitud con los datos del paso 1 y carga los datos de entrega del paso 2
    ''' </summary>
    ''' <param name="e"> evento de navegacion</param>
    ''' <remarks>Si el formulario no es valido interrumpe navegacion</remarks>
    Private Sub ProcesarPaso1(ByVal e As EventArgs)
        'Page.Validate("datos")
        'If Not Page.IsValid Then
        '    e.Cancel = True
        'End If

       
        If DatosGenerales.Solicitud IsNot Nothing Then
            Try
                 Dim sol = DatosGenerales.SolicitudCargarDatos()
                Solicitud.ModificarDatosGenerales(sol)

                HabilitarSiguiente(True)
            Catch ex As Exception
                Alert("Error al actualizar solicitud. Error:" & ex.Message)
            End Try
        End If
    End Sub
#End Region

#Region "PASO 2 - Fuentes de Finanaciamiento"
    Protected Sub FuentesFinanciamiento_ActualizarEstado(ByVal sender As Object, ByVal e As System.EventArgs) Handles FuentesFinanciamiento.ActualizarEstado
        HabilitarSiguiente(CType(sender, Boolean))
    End Sub
#End Region

#Region "PASO 3 - Lugares de Entrega"
    ''' <summary>
    ''' Obtiene los productos de la solicitud y los carga en la grid correspondiete y luego habilita siguiente
    ''' </summary>
    Private Sub CargarProductos()
        'actualiza los datos de solicitud
        
        With ProductosSolicitados
            .Solicitud = Solicitudes.Obtener(IdEstablecimiento, IdSolicitud)
            .CargarDatos()
        End With

        'Suministros.CargarAListaEditable(eddlProductos)
        If ProductosSolicitados.Solicitud.SAB_EST_PRODUCTOSSOLICITUD.Any() Then HabilitarSiguiente(True) Else HabilitarSiguiente(False)
    End Sub

    Protected Sub LugaresEntrega_ActualizarEstado(ByVal sender As Object, ByVal e As System.EventArgs) Handles LugaresEntrega.ActualizarEstado
        HabilitarSiguiente(CType(sender, Boolean))
    End Sub
#End Region

#Region "PASO 4 - Productos"
    Protected Sub ProductosSolicitados_ActualizarEstado(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductosSolicitados.ActualizarEstado
        HabilitarSiguiente(CType(sender, Boolean))
    End Sub

    Private Sub ProcesarProductosCargarEntregas()
        'evento guardar
        Dim sol = Solicitudes.Obtener(IdEstablecimiento, IdSolicitud)
        If sol.SAB_EST_PRODUCTOSSOLICITUD.Any() Then
            ProductosSolicitados.ProcesarProductos()

            FormaEntregas.Solicitud = sol
            'pasos para entrega (PASO 5)
            If sol.EntregaUniforme Then

                FormaEntregas.EntregaUniforme = True
            Else
                FormaEntregas.EntregaUniforme = False
            End If
        Else
            Exit Sub
        End If
    End Sub
#End Region

#Region "PASO 5 - Entregas"
    Protected Sub FormaEntregas_ActualizarEstado(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormaEntregas.ActualizarEstado
        HabilitarSiguiente(CType(sender, Boolean))
    End Sub
#End Region

#Region "PASO 6"
    Protected Sub DistribucionProductos_ActualizarEstado(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductosDistribucion.ActualizarEstado
        _excedido = CType(sender, Boolean)
        lnkEnd.Enabled = CType(sender, Boolean)
    End Sub

    Protected Sub Distribucion(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductosDistribucion.VerDistribucionProducto
       CargarDatosDistribucionPorProducto(CType(sender, BaseProductos))
    End Sub

    Private Sub CargarDistribucion()
        Try
            Dim recs = ProductoSolicitud.ObtenerTodos(CType(IdSolicitud, Integer), IdEstablecimiento)
            If recs.Any() Then
                ProductosDistribucion.CargarDatos(recs)
            End If
        Catch ex As Exception
            If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
                Response.Redirect("~/ESTABLECIMIENTOS/FrmCrearSolicitudCompra.aspx?id=" & Request.QueryString("id"), True)
            End If
        End Try
    End Sub
#End Region

#Region "PASO 7"
    Private Sub CargarDatosDistribucionPorProducto(ByVal productoseleccionado As BaseProductos)
         Dim sol = Solicitudes.Obtener(IdEstablecimiento, IdSolicitud)
        With DistribucionPorProducto
            .Solicitud = sol
            .Producto = ProductoSolicitud.Obtener(CType(sol.IDSOLICITUD, Integer), sol.IDESTABLECIMIENTO, CType(productoseleccionado.Renglon, Integer), CType(productoseleccionado.IdProducto, Integer))
            .CargarDatos()
        End With

        'navegacion
        MostrarOcultarNavegacion(False)
        lnkEnd.Visible = False
        lnkEnd.Enabled = False
        lnkBack.Visible = True
        Wizard1.ActiveViewIndex = 6
        lnkBack.ValidationGroup ="ventregas"
    End Sub

#End Region

#Region "Navegacion"
    Protected Sub lnkNext_Click(sender As Object, e As EventArgs) Handles lnkNext.Click
        Dim sol = Solicitudes.Obtener(IdEstablecimiento, IdSolicitud)
        Select Case Wizard1.ActiveViewIndex
            Case 0
                ProcesarPaso1(e)
                'carga datos para el paso 2
                FuentesFinanciamiento.Solicitud = sol
                FuentesFinanciamiento.CargarDatos()
                Wizard1.ActiveViewIndex = 1
                'navegacion
                MostrarOcultarNavegacion(False)
                lnkNext.Visible = True
                lnkPrev.Visible = True
            Case 1
                With LugaresEntrega
                    .Solicitud = sol
                    .CargarLugaresEntrega()
                End With
                Wizard1.ActiveViewIndex = 2
            Case 2
                CargarProductos()
                Wizard1.ActiveViewIndex = 3
            Case 3
                ProcesarProductosCargarEntregas()
                 lnkNext.ValidationGroup ="ventregas"
                Wizard1.ActiveViewIndex = 4
            Case 4
                FormaEntregas.ProcesarEntregas(e)
                sol = FormaEntregas.Solicitud
                'inicializa los listados de fuentes y de almacenes
                Solicitud.CargarFuentesFinanciamientoAlmacenes(sol)
                ProductosDistribucion.Solicitud = sol
                CargarDistribucion()

                'navegacion
                MostrarOcultarNavegacion(False)
                lnkPrev.Visible = True
                lnkEnd.Visible = True
                Wizard1.ActiveViewIndex = 5

                lnkEnd.Enabled = ProductosDistribucion.EstaCompleto And Not _excedido
        End Select
    End Sub

    Protected Sub lnkPrev_Click(sender As Object, e As EventArgs) Handles lnkPrev.Click
        Dim sol = Solicitudes.Obtener(IdEstablecimiento, IdSolicitud)        
        Select Case Wizard1.ActiveViewIndex
            Case 1
                DatosGenerales.Solicitud = sol
                DatosGenerales.CargarAdministradores()

                'navegacion
                MostrarOcultarNavegacion(False)
                lnkNext.Visible = True
                lnkNext.Enabled = True
                Wizard1.ActiveViewIndex = 0
            Case 2
                Wizard1.ActiveViewIndex = 1
                lnkNext.Enabled = True
            Case 3
                ProductosSolicitados.ActualizarProductos()
                LugaresEntrega.Solicitud = sol
                LugaresEntrega.CargarLugaresEntrega()
                Wizard1.ActiveViewIndex = 2
               
            Case 4
                FormaEntregas.ProcesarEntregas(e)
                CargarProductos()
                Wizard1.ActiveViewIndex = 3

            Case 5
                With FormaEntregas
                    .Solicitud = sol
                    If sol.EntregaUniforme Then
                        .EntregaUniforme = True
                    Else
                        .EntregaUniforme = False
                    End If
                End With

                MostrarOcultarNavegacion(False)
                lnkNext.Visible = True
                lnkNext.Enabled = True
                lnkPrev.Visible = True
                Wizard1.ActiveViewIndex = 4
                lnkNext.ValidationGroup ="ventregas"
        End Select
    End Sub

    Protected Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        DistribucionPorProducto.GuardarDistribucion()
        ProductosDistribucion.Solicitud = DistribucionPorProducto.Solicitud

        CargarDistribucion()

        MostrarOcultarNavegacion(False)
        lnkPrev.Visible = True
        lnkEnd.Visible = True
        lnkEnd.Enabled = ProductosDistribucion.EstaCompleto And Not _excedido
        Wizard1.ActiveViewIndex = 5
    End Sub

    Protected Sub lnkEnd_Click(sender As Object, e As EventArgs) Handles lnkEnd.Click
        Dim completo As Boolean = ProductosDistribucion.EstaCompleto
        If Not completo Then
            Alert("No se han procesado todos los productos, por favor verifique que todos los productos tengan distribución para finalizar.")
            Exit Sub
        End If

        Try
             Dim sol = Solicitudes.Obtener(IdEstablecimiento, IdSolicitud)
            Dim dsmontofuente = Solicitud.ObtenerMontosPorFuente(sol)

            Dim total As Decimal = 0
            For Each fuente In dsmontofuente
                Dim ffs As New SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES
                With ffs
                    .IDESTABLECIMIENTO = sol.IDESTABLECIMIENTO
                    .IDSOLICITUD = sol.IDSOLICITUD
                    .IDFUENTEFINANCIAMIENTO = fuente.IdFuente
                    .MONTOPARTICIPACION = fuente.Monto
                    .PORCENTAJEPARTICIPACION = fuente.Porcentaje
                    EstablecimientoHelpers.Solicitud.ActualizarFuenteFinanciamiento(ffs)
                End With
                total += fuente.Monto
            Next

            sol.MONTOSOLICITADO = Solicitud.ObtenerMonto(sol)
            If (sol.ENTREGAS = 0 Or sol.ENTREGAS Is Nothing) Then sol.ENTREGAS = sol.SAB_EST_ENTREGAS.Max(Function(en) en.NUMEROENTREGA)
            Solicitud.Modificar(sol)

            Response.Redirect("~/ESTABLECIMIENTOS/FrmConsultarSolicitudes.aspx", True)


        Catch ex As Exception
            Alert(ex.Message)
        End Try
    End Sub

    Private Sub MostrarOcultarNavegacion(ByVal activar As Boolean)
        lnkNext.Visible = activar
        lnkPrev.Visible = activar
        lnkEnd.Visible = activar
        lnkBack.Visible = activar
    End Sub

    Private Sub HabilitarSiguiente(ByVal activar As Boolean)
        lnkNext.Enabled = activar
    End Sub

    Private _excedido As Boolean

#End Region
End Class
