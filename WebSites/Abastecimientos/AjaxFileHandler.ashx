<%@ WebHandler Language="VB" Class="AjaxFileHandler" %>

Imports System
Imports System.Web
Imports System.IO
Imports System.Linq
Imports SINAB_Entidades.Helpers
Imports SINAB_Entidades.Clases
Imports SINAB_Entidades

Public Class AjaxFileHandler : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest 
        If context.Request.Files.Count > 0 Then
            Dim pProducto = context.Request.Params("producto")
            Dim pSolicitud = context.Request.Params("solicitud")
            Dim pRenglon = context.Request.Params("renglon")
            Dim pEstablecimiento = context.Request.Params("establecimiento")
            
            Dim path As String = context.Server.MapPath("~/Especificaciones")
            If Not Directory.Exists(path) Then
                Directory.CreateDirectory(path)
            End If

            Dim file As HttpPostedFile = context.Request.Files(0)
            Dim ext = IO.Path.GetExtension(file.FileName)
            Dim filename As String = pEstablecimiento + "_" + pSolicitud + "_" + pRenglon + "_" + pProducto + ext
            file.SaveAs(IO.Path.Combine(path, filename))

            Dim detalle = New SAB_EST_DETALLESOLICITUDES()
            With detalle
                .IDSOLICITUD = pSolicitud
                .IDESTABLECIMIENTO = pEstablecimiento
                .IDPRODUCTO = pProducto
                .RENGLON = pRenglon
                .ESPECIFICACIONTECNICA = "/Especificaciones/" + filename
            End With
            EstablecimientoHelpers.Solicitud.AgregarEspecificacionTecnica(detalle)
            
            context.Response.ContentType = "text/plain"
            Dim serializer As New Script.Serialization.JavaScriptSerializer()
            Dim result = New With {Key .name = filename}
            context.Response.Write(serializer.Serialize(result))

        End If
        
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property

End Class