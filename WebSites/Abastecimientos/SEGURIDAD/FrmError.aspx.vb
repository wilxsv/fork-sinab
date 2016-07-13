'ERROR DE INTENTO DE ACCEDER A PAGINA SIN ESTAR AUTENTICADO
'O SI HA EXPIRADO EL TIEMPO INACTIVO DE LA SESION
'CU SEGURIDAD
'Ing. Yessenia Pennelope Henriquez Duran
'solicita usuario y clave para ingreso al sistema de abstedimiento
Partial Class FrmError
    Inherits System.Web.UI.Page

    Protected Sub LnkbLoguin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkbLoguin.Click
        'REDIRECCIONA A LA PAGINA PRINCIPAL
        Response.Redirect("~/FrmLogin.aspx", False)
    End Sub

End Class
