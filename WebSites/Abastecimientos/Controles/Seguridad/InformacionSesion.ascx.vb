Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases
Imports SINAB_Entidades.Tipos
Imports System.Linq

Partial Class Controles_Seguridad_InformacionSesion
    Inherits System.Web.UI.UserControl

    Public Sub CargarDatos(ByVal usuario As Usuario)
        lblCargo.Text = usuario.CARGO.DESCRIPCION 'Session.Item("UsuarioCargo") 'cargo
        lblCodigoUsuario.Text = usuario.EMPLEADO.NOMBRECORTO 'Session.Item("CodUsuario") 'codigo de usuario
        lblDependencia.Text = usuario.Dependencia.NOMBRE 'Session.Item("UsuarioDependencia") 'dependencia
        lblEstablecimientos.Text = usuario.ESTABLECIMIENTO.NOMBRE 'Session.Item("UsuarioEstablecimiento") 'establecimiento
        lblNivel.Text = usuario.ESTABLECIMIENTO.NIVEL.ToString() 'Session.Item("Nivel") 'nivel del establecimiento al que pertenece

        lblNombreUsuario.Text = String.Format("{0} {1}", usuario.EMPLEADO.NOMBRE, usuario.EMPLEADO.APELLIDO) 'Session.Item("NombreUsuario") 'nombre de usuario
        lblRolUsuario.Text = String.Join(",", Membresia.ObtenerRoles()) 'Session.Item("UsuarioRol") 'rol del usuario
        lblTipoEstablecimiento.Text = usuario.TIPOESTABLECIMIENTO.DESCRIPCION 'Session.Item("NombreTipoEstablecimiento") 'tipo establecimiento
        lblZona.Text = usuario.ZONA.DESCRIPCION 'Session.Item("NombreZona") ' region a la que pertenece

        If usuario.ALMACEN IsNot Nothing Then
            lblAlmacen.Text = String.Join(",", usuario.Almacenes.Select(Function(al) al.NOMBRE)) 'Session.Item("NombreAlmacen")
        Else : lblAlmacen.Text = "--"
        End If
        If usuario.SUMINISTRO IsNot Nothing Then
            lblSuministro.Text = usuario.SUMINISTRO.DESCRIPCION 'Session.Item("Suministro")
        Else : lblSuministro.Text = "--"
        End If

    End Sub
End Class
