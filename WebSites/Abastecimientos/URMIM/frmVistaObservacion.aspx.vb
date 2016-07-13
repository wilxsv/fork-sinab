Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES

Partial Class URMIM_frmVistaObservacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session.Item("UsuarioRol") Is Nothing Then
            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado
        End If

        If Request.QueryString("idProceso") Is Nothing Or Request.QueryString("idEstablecimiento") Is Nothing Or _
           Request.QueryString("idProducto") Is Nothing Or Request.QueryString("tipo") Is Nothing Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        If (Not IsNumeric(Request.QueryString("idProceso"))) Or (Not IsNumeric(Request.QueryString("idEstablecimiento"))) Or _
           (Not IsNumeric(Request.QueryString("idProducto"))) Or (Not IsNumeric(Request.QueryString("tipo"))) Then

            Response.Redirect("~/SEGURIDAD/FrmError.aspx", False) ' pagina cuando se ha generado un error de autenticacion o de tiempo expirado

        End If

        Dim idProceso As Integer = Request.QueryString("idProceso")
        Dim idEstablecimiento As Integer = Request.QueryString("idEstablecimiento")
        Dim idProducto As Integer = Request.QueryString("idProducto")
        Dim tipo As Integer = Request.QueryString("tipo")

        If tipo = 1 Then
            Me.lblTipo.Text = "Observaciones a la captura de datos"
        Else
            Me.lblTipo.Text = "Observaciones al ajuste de datos"
        End If


        'Datos del producto
        Dim bEntidad1 As New cCATALOGOPRODUCTOS
        Dim eEntidad As CATALOGOPRODUCTOS = bEntidad1.devolverEntidadVista(idProducto)

        Me.lblCodProd.Text = eEntidad.CODIGO
        Me.lblUM.Text = eEntidad.CONCENTRACION
        Me.lblNomProd.Text = eEntidad.NOMBRE

        'Datos del establecimiento
        Dim bEntidad2 As New cESTABLECIMIENTOS
        Me.lblNomEst.Text = bEntidad2.ObtenerNomEstablecimiento(idEstablecimiento)


        Dim Entidad As New PROGRAMACIONPRODUCTO
        Dim cEntidad As New cPROGRAMACION
        Entidad.IDESTABLECIMIENTO = idEstablecimiento
        Entidad.IDPROGRAMACION = idProceso
        Entidad.IDPRODUCTO = idProducto
        Entidad.TIPOOBSERVACION = tipo

        Me.gvLista.DataSource = cEntidad.obtenerListaObservaciones(Entidad)
        Me.gvLista.DataBind()

    End Sub

End Class
