Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports System.Data.OleDb
Imports System.IO

Partial Class CargarSolicitudes
    Inherits System.Web.UI.Page

    Dim T As New Data.DataTable

    Dim TComisionEvaluadora As Data.DataTable

#Region " Propiedades "

    Private _IDSOLICITUD As Integer
    Public Property IDSOLICITUD() As Integer
        Get
            Return Me._IDSOLICITUD
        End Get
        Set(ByVal VALUE As Integer)
            Me._IDSOLICITUD = VALUE
            If Not Me.ViewState("IDSOLICITUD") Is Nothing Then Me.ViewState.Remove("IDSOLICITUD")
            Me.ViewState.Add("IDSOLICITUD", VALUE)
        End Set
    End Property

#End Region

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

        Else
            If Not Me.ViewState("IDSOLICITUD") Is Nothing Then Me.IDSOLICITUD = Me.ViewState("IDSOLICITUD")
        End If
    End Sub
 
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try

            Dim cS As New cSOLICITUDES
            Dim s As New SOLICITUDES

            'AGREGA SOLICITUD

            If Me.NumericBox1.Text = "" Or Me.TextBox1.Text = "" Or Me.TextBox6.Text = "" Or Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Then

                Me.MsgBox1.ShowAlert("Existen campos vacíos. Favor completar la información.", "Error", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
                Exit Sub
            End If

            s.IDESTABLECIMIENTO = Session("IdEstablecimiento")
            s.IDSOLICITUD = IDSOLICITUD
            s.FECHASOLICITUD = Me.CalendarPopup2.SelectedDate
            s.PERIODOUTILIZACION = Me.NumericBox1.Text
            s.EMPLEADOSOLICITANTE = Me.TextBox1.Text
            s.CARGOSOLICITANTE = Me.TextBox6.Text
            s.EMPLEADOAUTORIZA = Me.TextBox1.Text
            s.OBSERVACION = Me.TextBox3.Text
            s.CORRELATIVO = Me.Label16.Text
            s.IDESPECIFICACION = s.IDESPECIFICACION


            'DATOS A CAMBIAR CUANDO SE INGRESE UNA SOLICITUD POR TEMP2
            s.IDDEPENDENCIASOLICITANTE = 29 'dependencia solicitante
            s.ENTREGAS = 1 ' CHEQUEAR
            s.IDCLASESUMINISTRO = 12 'Me.gvLista.SelectedDataKey(2)
            s.COMPRACONJUNTA = 1 'Me.RadioButtonList2.SelectedValue
            s.IDESTADO = 6
            s.MONTOSOLICITADO = 0 'CDec(Me.Label1.Text)
            s.PLAZOENTREGA = Me.TextBox4.Text
            s.AUFECHACREACION = DateTime.Now
            s.AUUSUARIOCREACION = User.Identity.Name


            cS.ActualizarSOLICITUDES(s)


            ' EJECUTAR EL SP DE PROGRAMACION PARA LLENAR TEMP2
            'cS.CopiarProgramacionATemp2(Label3.Text)


            ' ejecutar el SP para llenar tablas detallesolic, entregasolic y almacenesentregasolic.
            Dim ce As New cESTABLECIMIENTOS
            If ce.CrearDetalleSolicitudDiscoURMIM(Session("IdEstablecimiento"), Me.IDSOLICITUD, User.Identity.Name, 0, s.IDESPECIFICACION) = 0 Then
                Me.Label4.Text = "Solicitud creada satisfactoriamente."
            Else
                Me.Label4.Text = "Error al generar la solicitud."
            End If
            Me.Button4.Visible = True
            Me.Button2.Visible = True

        Catch ex As Exception
            Me.MsgBox1.ShowAlert(ex.ToString, "s", Cooperator.Framework.Web.Controls.AlertOption.NoAction)
        End Try

    End Sub


    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim s As New SOLICITUDES
        Dim cs As New cSOLICITUDES

        'CAMBIAR CUANDO SE DESEE INGRESAR UNA SOLICITUD POR TEMP2
        s.IDESTABLECIMIENTO = Session("IdEstablecimiento")
        s.IDDEPENDENCIASOLICITANTE = 113 ' URMIM
        s.IDCLASESUMINISTRO = 11 'Me.gvLista.SelectedDataKey(2)

        Dim c As String

        Dim idsoldepe As Integer
        idsoldepe = cs.obtenerIdSolicitud2(Session("IdEstablecimiento"), 113) ' urmim
        s.IDSOLICITUDEPENDENCIA = idsoldepe

        Dim cd As New cDEPENDENCIAS
        Dim coddependencia As String = cd.ObtenerCodDependencia(113) ' urmim

        s.CORRELATIVO = coddependencia & "-" & idsoldepe & "/" & DateTime.Now.Year

        c = s.CORRELATIVO

        s.COMPRACONJUNTA = 1
        s.IDESTADO = 6
        cs.ActualizarSOLICITUDES(s)

        IDSOLICITUD = cs.obtenerIdSolicitud(Session("IdEstablecimiento"), c)

        Me.Label16.Text = c


    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        'reporte de solicitud
        Response.Redirect("~/uaci/FrmConsultarSolicitudUaci.aspx?ids=" & IDSOLICITUD, False)


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' reporte de distribucion


    End Sub
End Class
