Imports ABASTECIMIENTOS.NEGOCIO
Partial Class SEGURIDAD_frmViewLogo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As String = Session("idEstablecimiento")
        'Dim id As String = Request.QueryString("IDE")
        Dim logo As New cLogo
        Dim dtlogo As New Data.DataTable
        If Session("ImgLogo") Is Nothing OrElse CType(Session("ImgLogo"), Data.DataTable).Rows.Count = 0 Then
            Session("ImgLogo") = logo.ObtenerDataSetPorId(id).Tables(0)
        End If

        'dtlogo = logo.ObtenerDataSetPorId(id).Tables(0)
        dtlogo = CType(Session("ImgLogo"), Data.DataTable)
        '  Dim Img As Image = dtlogo.Rows(0)("logo")
        'Img.Response.OutputStream, ImageFormat.Jpeg)

        ' Session("DTLOGO") = dtlogo
        Response.ContentType = "image/bmp"
        Try
            Session("IDEstablecimientoRAIZ") = dtlogo.Rows(0)("IDEstablecimiento")
            Response.BinaryWrite(DirectCast(dtlogo.Rows(0)("logo"), Byte()))
        Catch ex As Exception
            'todo
        End Try


    End Sub
End Class
