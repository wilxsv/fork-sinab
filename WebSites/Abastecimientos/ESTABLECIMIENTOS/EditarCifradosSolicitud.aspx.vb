Imports System.Linq
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Tipos

Partial Class ESTABLECIMIENTOS_EditarCifradosSolicitud
    Inherits System.Web.UI.Page

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

   



    Public Property Solicitud() As SAB_EST_SOLICITUDES
        Private Get
            Return CType(ViewState("solicitud"), SAB_EST_SOLICITUDES)
        End Get
        Set(ByVal value As SAB_EST_SOLICITUDES)
            ViewState("solicitud") = value
        End Set
    End Property

    Public Property ProductoSeleccionado() As ProductosSolicitudCorrelativo
        Get
            Return CType(Session("seleccionado"), ProductosSolicitudCorrelativo)
        End Get
        Set(value As ProductosSolicitudCorrelativo)
            Session("seleccionado") = value
            If Not IsNothing(value) Then ltProducto.Text = "Renglón: " + value.DescripcionCompleta + " - " + value.Descripcion
        End Set
    End Property



   

    ''' <summary>
    ''' Muestra u Oculta el boton "Agrregar" de la Grid gvProdcutosDistribucion.
    ''' </summary>
    ''' <value>booleano</value>
    ''' <returns>booleano</returns>
    ''' <remarks>
    ''' Determina si se pueden agregar mas items del tipo AlmacenesProductoDistribucion a la distribucion
    ''' PASO 6
    ''' </remarks>
    Public Property SeAgrega As Boolean
        Private Get
            Return pnlAgregar.Visible
        End Get
        Set(ByVal value As Boolean)
            pnlAgregar.Visible = value


        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim usr = Membresia.ObtenerUsuario()
            Master.ControlMenu.Visible = False
            If Request.QueryString("id") IsNot Nothing Then
                Solicitud = Solicitudes.Obtener(usr.Establecimiento.IDESTABLECIMIENTO, CType(Request.QueryString("id"), Long), usr.NombreUsuario)
                Label2.Text = Solicitud.CORRELATIVO + "-" + CType(Solicitud.CorrelativoGeneral, String)

                ProductoSeleccionado = ProductoSolicitud.Obtener(CType(Solicitud.IDSOLICITUD, Integer), Solicitud.IDESTABLECIMIENTO, CType(Request.QueryString("r"), Integer), CType(Request.QueryString("idp"), Integer))

                Try
                Catch ex As Exception
                    Throw New Exception("Error en Solicitud, No se encontró la solicitud : " & ex.Message)
                End Try

                Try
                    SeAgrega = True

                    ltCantidad.Text = ProductoSeleccionado.Cantidad.ToString()
                    ltPrecio.Text = String.Format("{0:N2}", ProductoSeleccionado.PrecioActual)
                    ltMonto.Text = String.Format("{0:N2}", (ProductoSeleccionado.PrecioActual * ProductoSeleccionado.Cantidad))

                    CifradosPresupuestarios.ProductoSeleccionado = ProductoSeleccionado

                    If ProductoSeleccionado.Cifrados.Any() Then


                        CifradosPresupuestarios.LeerCifrados()

                    Else

                        '    LimpiarCifrado()
                    End If


                Catch ex As Exception
                    SINAB_Utils.MessageBox.Alert("No se ha podido cargar la información de la distribución.", "Error al editar")
                End Try
            End If
        End If
    End Sub

    Protected Sub lnkBack_Click(sender As Object, e As EventArgs) Handles lnkBack.Click
        Response.Redirect(String.Format("~/ESTABLECIMIENTOS/AsignarCifradosSolicitud.aspx?id={0}", Solicitud.IDSOLICITUD))
    End Sub
End Class
