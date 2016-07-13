'INFORMACION DE USUARIO EN SESION
'CU-SEGURIDAD
'Ing. Yessenia Pennelope Henriquez Duran
'Formulario con los datos del usuario que se encuentra en sesion
Partial Class FrmInformacionSesion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'al momento de cargar la pagina

        'muestra el contenido de las variables de sesion en la pagina
        Me.lblCargo.Text = Session.Item("UsuarioCargo") 'cargo
        Me.lblCodigoUsuario.Text = Session.Item("CodUsuario") 'codigo de usuario
        Me.lblDependencia.Text = Session.Item("UsuarioDependencia") 'dependencia
        Me.lblEstablecimientos.Text = Session.Item("UsuarioEstablecimiento") 'establecimiento
        Me.lblNivel.Text = Session.Item("Nivel") 'nivel del establecimiento al que pertenece

        Me.lblNombreUsuario.Text = Session.Item("NombreUsuario") 'nombre de usuario
        Me.lblRolUsuario.Text = Session.Item("UsuarioRol") 'rol del usuario
        Me.lblTipoEstablecimiento.Text = Session.Item("NombreTipoEstablecimiento") 'tipo establecimiento
        Me.lblZona.Text = Session.Item("NombreZona") ' region a la que pertenece

        Me.lblAlmacen.Text = Session.Item("NombreAlmacen")
        Me.lblSuministro.Text = Session.Item("Suministro")

    End Sub

End Class
