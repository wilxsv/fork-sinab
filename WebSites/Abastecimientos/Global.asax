<%@ Application Language="VB" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Threading" %>

<script RunAt="server">

  Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
    ' Código que se ejecuta al iniciarse la aplicación
    application("UsersOnline")=0
  End Sub

  Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
    ' Código que se ejecuta durante el cierre de aplicaciones
  End Sub

  Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    ' Código que se ejecuta al producirse un error no controlado
    ' Código que se ejecuta al producirse un error no controlado
        'Dim pathFile As String = Server.MapPath("~/Log")
        'Dim envioEmail As New sv.gob.minsal.intranet.ARTHUR_Services
        'Dim res As String = String.Empty
    
    
        'Dim objErr As Exception = Server.GetLastError().GetBaseException()
        '  Dim err As String = "<b>Error Caught in Page_Error event</b><hr><br><br><b>Error in: </b>" + Request.Url.ToString() + "<br><b>Error Message: </b>" + objErr.Message.ToString() + "<br><b>Stack Trace:</b><br>" + objErr.StackTrace.ToString()

        ''Response.Write(e.ToString())
        ' Dim hostEntry As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(Request.UserHostAddress)

        'Dim err = html_msj.HTML_CSS_Error(objErr, Request.Url.ToString, Request.UserHostAddress, hostEntry.HostName, User.Identity.Name)
        'My.Computer.FileSystem.WriteAllText(pathFile & "\E" & Now.ToString("yyyyMMdd") & ".html", "<h1>" & Now & "</h1>" & vbCrLf & "Error inesperado: " & vbCrLf & err.ToString(), True)
     
        
    
        'Try
        'dim subject as String
        'subject="Error en " & Request.ApplicationPath.Replace("/","") & "-" & objErr.Message
        'res = envioEmail.EnvioMensajeAPP(1, subject, err)
        '        res = res
        'Catch ex As Exception
        '  My.Computer.FileSystem.WriteAllText(pathFile & "\EX" & Now.ToString("yyyyMMdd") & ".html", "<h1>" & Now & "</h1>" & vbCrLf & "Error inesperado: " & vbCrLf & ex.ToString, True)
        'End Try
    End Sub

  Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
    ' Código que se ejecuta cuando se inicia una nueva sesión
    application("UsersOnline")+=1
     
  End Sub

  Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
    ' Se desencadena al intentar autenticar el uso
        Dim cultura = New CultureInfo("es-SV", False)
        cultura.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday
        cultura.DateTimeFormat.FullDateTimePattern = "dd/mm/yyyy hh:mm tt"
        cultura.DateTimeFormat.ShortTimePattern = "hh:mm tt"
        cultura.DateTimeFormat.AMDesignator = "AM"
        cultura.DateTimeFormat.PMDesignator = "PM"
        Thread.CurrentThread.CurrentCulture = cultura
         
  End Sub

  Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
    ' Código que se ejecuta cuando finaliza una sesión. 
    ' Nota: El evento Session_End se desencadena sólo con el modo sessionstate
    ' se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
    ' o SQLServer, el evento no se genera.
    application("UsersOnline")-=1
  End Sub
  

  </script>
