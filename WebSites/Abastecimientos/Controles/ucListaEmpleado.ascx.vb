Imports ABASTECIMIENTOS.ENTIDADES
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades


Partial Class Controles_ucListaEmpleado
    Inherits System.Web.UI.UserControl

    Public Sub ObtenerDatos()

        Dim mComponente As New cEMPLEADOS

        Me.ddlEmpleados.DataSource = mComponente.ObtenerListaEmpleadosNA(Session("IdEstablecimiento"), 2) 'UACI = 2 (DEPENDENCIA)
        Me.ddlEmpleados.DataTextField = "NOMBRE"
        Me.ddlEmpleados.DataValueField = "IDEMPLEADO"
        Me.ddlEmpleados.DataBind()
    End Sub
    Public Sub CargarDatos()
        Dim usr = Membresia.ObtenerUsuario()
        ' Dim mComponente As New cEMPLEADOS
        Using db As New SinabEntities
            Me.ddlEmpleados.DataSource = db.prc_usuariosSuministros(usr.Establecimiento.IDESTABLECIMIENTO, 2, usr.IDEMPLEADO) 'mComponente.ObtenerListaEmpleadosNA(Session("IdEstablecimiento"), 2) 'UACI = 2 (DEPENDENCIA)
            Me.ddlEmpleados.DataTextField = "NOMBRE"
            Me.ddlEmpleados.DataValueField = "IDEMPLEADO"
            Me.ddlEmpleados.DataBind()
        End Using

    End Sub


    Public Function ObtenerEmpleado() As Int64
        Return Me.ddlEmpleados.SelectedValue
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    'Public Sub ObtenerDatos()

    '    Dim mComponente As New cEMPLEADOS

    '    Me.ddlEmpleados.DataSource = mComponente.ObtenerListaRecuperarEmpleadosPorDependenciaAnalistaSuministros(Session("IdEstablecimiento"), 2) 'UACI = 2 (DEPENDENCIA)
    '    Me.ddlEmpleados.DataTextField = "NOMBRE"
    '    Me.ddlEmpleados.DataValueField = "IDEMPLEADO"
    '    Me.ddlEmpleados.DataBind()
    'End Sub




End Class
