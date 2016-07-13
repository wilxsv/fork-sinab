
Imports System.Linq
Imports System.Collections.Generic
Imports System.IO
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Helpers.EstablecimientoHelpers
Imports SINAB_Entidades.Tipos
Imports SINAB_Utils.MessageBox

Partial Class Controles_Ctrl_Paso4_CrearSolicitudCompra
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
        End Set
    End Property

   
#End Region

#Region "Handlers"
    Public Event ActualizarEstado As EventHandler
#End Region

    Public Sub ProcesarProductos()
        'evento guardar
        If Solicitud.SAB_EST_PRODUCTOSSOLICITUD.Any() Then

            'validar dos productos iguales sin especificacion tecnica
            Dim tProducto As Integer
            Dim tEspecificacion As String

            Dim idProducto As Integer = 0


            For Each row As GridViewRow In gvProductosSolicitud.Rows
                tProducto = CType(gvProductosSolicitud.DataKeys(row.RowIndex).Values(0), Integer)
                tEspecificacion = CType(gvProductosSolicitud.DataKeys(row.RowIndex).Values(2), String)

                If idProducto = tProducto And String.IsNullOrEmpty(tEspecificacion) Then
                    Alert("Existen dos productos iguales sin especificaciones técnicas")
                    Exit Sub
                End If
                idProducto = tProducto
            Next

            Try
                ActualizarProductos()
            Catch ex As Exception
                Alert("Error al procesar datos. Error: " & ex.Message)
                Return
            End Try
        End If
    End Sub

    Public Sub ActualizarProductos()
        Dim arr As New List(Of BaseProductoSolicitud)
        Dim usr = Membresia.ObtenerUsuario()
        Dim err = False
        Try
            For Each row As GridViewRow In gvProductosSolicitud.Rows
                Dim tbprecio As TextBox = CType(row.FindControl("txtPrecioUnitario"), TextBox)
                Dim eComponente As New BaseProductoSolicitud
                With eComponente.Productossolicitud
                    .IDESTABLECIMIENTO = usr.Establecimiento.IDESTABLECIMIENTO
                    .IDSOLICITUD = Solicitud.IDSOLICITUD
                    .IDPRODUCTO = CType(gvProductosSolicitud.DataKeys(row.RowIndex).Values(0), Long)
                    '.IDENTREGA = CType(CType(row.Cells(5).Controls(1), DropDownList).SelectedItem.Text, Short?)
                    .IDDEPENDENCIA = usr.Dependencia.IDDEPENDENCIA
                    '.CANTIDAD = CInt(CType(row.Cells(5).Controls(1), eWorld.UI.NumericBox).Text)
                    .RENGLON = CType(gvProductosSolicitud.DataKeys(row.RowIndex).Values(3), Integer)
                    .AUUSUARIOMODIFICACION = HttpContext.Current.User.Identity.Name
                    .AUFECHAMODIFICACION = Now
                    .preciounitario = CType(tbprecio.Text, Decimal?)
                    .ESPECIFICACIONTECNICA = CType(gvProductosSolicitud.DataKeys(row.RowIndex).Values(2), String)

                End With
                eComponente.Codigo = CType(gvProductosSolicitud.DataKeys(row.RowIndex).Values(5), String)

                arr.Add(eComponente)
            Next

        Catch ex As Exception

            Alert("Revise que todos los campos tengan valores válidos: " + ex.Message)
        End Try

        'si no continua.
        Try
            If arr.Any() Then
                For Each i As BaseProductoSolicitud In arr
                    Diagnostics.Debug.WriteLine(i.Productossolicitud.IDPRODUCTO.ToString() + ", " + i.Productossolicitud.RENGLON.ToString() + ", " + i.Codigo)
                Next

                ' System.Diagnostics.Debug.WriteLine(String.Join(", ", arr))
                EstablecimientoHelpers.Solicitud.ActualizarProductos(arr)
                'Dim suministro = SuministroDependencias.Obtener(CType(DdlDEPENDENCIAS1.SelectedValue, Integer))
                '.IDCLASESUMINISTRO = suministro.IDSUMINISTRO
              

                Solicitud = Solicitudes.Obtener(Solicitud.IDESTABLECIMIENTO, Solicitud.IDSOLICITUD)
                CargarDatos()
            End If
        Catch ex As Exception
            Alert("Problemas al guardar el registro. Intente nuevamente")
        End Try
    End Sub

    Public Sub CargarDatos()
        Dim recs = EstablecimientoHelpers.Solicitud.ObtenerProductos(CType(Solicitud.IDSOLICITUD, Integer), Solicitud.IDESTABLECIMIENTO)
        gvProductosSolicitud.DataSource = recs
        gvProductosSolicitud.DataBind()
        RaiseEvent ActualizarEstado(recs.Any(), New EventArgs())
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs)
        CargarDatos()
    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As System.EventArgs) Handles BtnGuardar.Click

        If String.IsNullOrEmpty(BuscarProducto.SearchingText) Then
            Alert("Error en selección de producto, verifique que ha seleccionado un producto del listado emergente")
            Exit Sub
        End If

        Dim usr = Membresia.ObtenerUsuario()
        Dim prodSol As New SAB_EST_PRODUCTOSSOLICITUD

        With prodSol
            .IDESTABLECIMIENTO = Solicitud.IDESTABLECIMIENTO
            .IDSOLICITUD = Solicitud.IDSOLICITUD
            .IDPRODUCTO = CType(BuscarProducto.ProductId, Long)
            '.IDENTREGA = 1
            .OBSERVACION = String.Empty
            .AUUSUARIOCREACION = usr.NombreUsuario
            .AUFECHACREACION = Now
            .CANTIDAD = 0
            .IDDEPENDENCIA = usr.Dependencia.IDDEPENDENCIA
        End With

        Try
            If EstablecimientoHelpers.Solicitud.AgregarProducto(prodSol) Then
                Solicitud = Solicitudes.Obtener(Solicitud.IDESTABLECIMIENTO, Solicitud.IDSOLICITUD)
            Else
                Alert("El producto ya existe")
            End If
        Catch ex As Exception
            Alert("Error al guardar el registro.  Verifique que el producto seleccionado no exista en la solicitud.")
        End Try

        CargarDatos()

        BuscarProducto.SearchingText = String.Empty

    End Sub

    'Protected Sub gvProductosSolicitud_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvProductosSolicitud.PageIndexChanging
    '    ActualizarProductos()
    '    gvProductosSolicitud.PageIndex = e.NewPageIndex
    '    CargarDatos()
    'End Sub

    Protected Sub gvProductosSolicitud_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvProductosSolicitud.RowUpdating
        ActualizarProductos()
    End Sub

    Protected Sub gvProductosSolicitud_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProductosSolicitud.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim dataRow = CType(e.Row.DataItem, ProductoSolicitudVistaProductos)


            Dim btnAdd As LinkButton = CType(e.Row.FindControl("lbAdd"), LinkButton)
            Dim btnDown As HyperLink = CType(e.Row.FindControl("lbDown"), HyperLink)

            Dim existeEspecificacion = Not String.IsNullOrEmpty(dataRow.RutaEspecificacion) ' Establecimiento.Solicitud.ExisteEspecificacion(Solicitud.IDESTABLECIMIENTO, CType(dataRow.IdProducto, Integer)) ', dataRow.IDESPECIFICACION)

            If existeEspecificacion Then
                btnAdd.CssClass = "GridAgregar lnkCerrar"
                btnDown.CssClass = "GridGuardar"

                Dim serverURL As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "") + HttpContext.Current.Request.ApplicationPath
                Dim fileURL As String = dataRow.RutaEspecificacion
                Dim totalURL As String = serverURL + fileURL
                btnDown.NavigateUrl = totalURL
                btnDown.Target = "blanck"
                'btnDown.Attributes.Add("urlFile", dataRow.RutaEspecificacion)
            Else
                btnAdd.CssClass = "GridAgregar"
                btnDown.CssClass = "GridGuardar lnkCerrar"

            End If
        End If
    End Sub

    Protected Sub gvProductosSolicitud_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvProductosSolicitud.RowDeleting

        Dim idproducto As Integer = CType(gvProductosSolicitud.DataKeys(e.RowIndex).Values(0), Integer)
        Dim especificacion As String = CType(gvProductosSolicitud.DataKeys(e.RowIndex).Values(2), String)
        Dim habilitar = False
        Try
            EstablecimientoHelpers.Solicitud.EliminarProducto(Solicitud, idproducto, especificacion)
            Solicitud = Solicitudes.Obtener(New SinabEntities(), Solicitud)
            If Solicitud.SAB_EST_PRODUCTOSSOLICITUD.Any() Then habilitar = True Else habilitar = False
            RaiseEvent ActualizarEstado(habilitar, New EventArgs())
            CargarDatos()
        Catch ex As Exception
            Alert("Se produjo un error al eliminar el producto. Error: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' Redirige a el formulario de especificaciones
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub lbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim btnDetails = CType(sender, LinkButton)

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)
        Dim hf As Label = CType(row.FindControl("LnkTarget"), Label)

        If Not IsNothing(hf) Then hf.CssClass = "lnktarget"

        With UploaderEspecificacion
            .IdProducto = CType(gvProductosSolicitud.DataKeys(row.RowIndex).Values(0), Integer)
            .Renglon = CType(gvProductosSolicitud.DataKeys(row.RowIndex).Values(3), Integer)
            .IdSolicitud = CType(Solicitud.IDSOLICITUD, Integer)
            .IdEstablecimiento = Solicitud.IDESTABLECIMIENTO
        End With

        MpeUploader.Show()
    End Sub


    Protected Sub lbDown_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnDetails = CType(sender, LinkButton)

        Dim row As GridViewRow = CType(btnDetails.NamingContainer, GridViewRow)

        'Response.Redirect("~/ESTABLECIMIENTOS/FrmAdicionarEspecificacion.aspx?idprod=" & gvProductosSolicitud.DataKeys(row.RowIndex).Values(0) & "&renglon=" & gvProductosSolicitud.DataKeys(row.RowIndex).Values(4) & "&idesp=" & gvProductosSolicitud.DataKeys(row.RowIndex).Values(2) & "&btndet=" & btnDetails.Text & "&idsol=" & Solicitud.IDSOLICITUD & "&idesp=" & Solicitud.IDUNIDADTECNICA)

        Dim filePath As String = CType(gvProductosSolicitud.DataKeys(row.RowIndex).Values(2), String)

        If File.Exists(Server.MapPath(filePath)) Then
            Response.ContentType = Page.ContentType
            Response.AppendHeader("Content-Disposition", ("attachment; filename=" + Path.GetFileName(filePath)))
            Response.WriteFile(filePath)
            Response.End()
        Else
            Alert("El archivo no existe, se procederá a actualizar el registro")
            Dim detalle = New SAB_EST_DETALLESOLICITUDES()
            With detalle
                .IDPRODUCTO = CType(gvProductosSolicitud.DataKeys(row.RowIndex).Values(0), Integer)
                .RENGLON = CType(gvProductosSolicitud.DataKeys(row.RowIndex).Values(3), Integer)
                .IDSOLICITUD = CType(Solicitud.IDSOLICITUD, Integer)
                .IDESTABLECIMIENTO = Solicitud.IDESTABLECIMIENTO
                .ESPECIFICACIONTECNICA = Nothing
            End With
            EstablecimientoHelpers.Solicitud.AgregarEspecificacionTecnica(detalle)
            CargarDatos()
        End If

    End Sub

End Class
