Imports Microsoft.VisualBasic
Imports System.Web

Public Class html_msj
    Public Shared Function HTMLError(ByVal Mensaje As String, ByVal fuente As String, ByVal target As String, ByVal toString As String, ByVal PageUrl As String, ByVal ipAdd As String, ByVal host As String, ByVal usuario As String) As String
        Dim tablaHTML As String
        tablaHTML = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'> " & _
    "<html xmlns='http://www.w3.org/1999/xhtml' > " & _
    "<head> " & _
        "<title>Envio de error</title> " & _
    "</head> " & _
    "<body>" & _
      "<p class='label'> " & _
        "<strong>Descripcion del Error</strong></p> " & _
      "<div class='tablediv'> " & _
        "<table border='0' class='dtTABLE'> " & _
          "<tr> " & _
            "<th style='font-weight: bold; text-transform: uppercase; color: white; background-color: #3366ff'> " & _
              "propiedad</th>" & _
            "<th style='font-weight: bold; text-transform: uppercase; width: 781px; color: white; " & _
              "background-color: #3366ff'> " & _
              "Descripcion</th>" & _
          "</tr> " & _
          "<tr> " & _
            "<td style='background-color: #ff0033'> " & _
              "<strong style='font-weight: bold; color: white'>Message</strong></td> " & _
            "<td style='width: 781px; color: white; background-color: #ff0033'> " & _
              "" & Mensaje & "</td> " & _
          "</tr> " & _
          "<tr> " & _
            "<td style='font-weight: normal; color: white; background-color: gray'> " & _
              "<strong>Source</strong></td> " & _
            "<td style='width: 781px; color: silver; background-color: gray'> " & _
              "" & fuente & "</td> " & _
          "</tr> " & _
          "<tr> " & _
            "<td style='font-weight: normal; color: white; background-color: gray'> " & _
              "<strong>TargetSite</strong></td> " & _
            "<td style='width: 781px; color: silver; background-color: gray'> " & _
              "" & target & " </td> " & _
          "</tr> " & _
          "<tr> " & _
            "<td style='font-weight: normal; color: white; background-color: gray'>  " & _
              "<strong>ToString()</strong></td> " & _
            "<td style='width: 781px; color: silver; background-color: gray'> " & _
              "" & toString & " </td> " & _
          "</tr> " & _
          "<tr> " & _
          "  <td style='font-weight: bold; color: white; background-color: gray'> " & _
          "    Pagina Error</td> " & _
          "  <td style='width: 781px; color: silver; background-color: gray'> " & _
          "    " & PageUrl & " </td> " & _
          "</tr> " & _
          "<tr> " & _
          "  <td style='font-weight: bold; color: white; background-color: gray'> " & _
          "    Direccion IP</td> " & _
          "  <td style='width: 781px; color: silver; background-color: gray'> " & _
          "   " & ipAdd & "</td> " & _
          "</tr> " & _
          "<tr> " & _
          "  <td style='font-weight: bold; color: white; background-color: gray'> " & _
          "    Host</td> " & _
          "  <td style='width: 781px; color: silver; background-color: gray'> " & _
          "    " & host & "</td> " & _
          "</tr> " & _
          " <tr> " & _
          "  <td style='font-weight: bold; color: white; background-color: gray'>" & _
          "   Usuario</td>" & _
          "  <td style='width: 781px; color: silver; background-color: gray'>" & _
          "    " & usuario & "</td>" & _
          " </tr>" & _
          "</table> " & _
          "</div> " & _
            "<p> " & _
              "Seguimiento de Error</p> " & _
        "</body> " & _
      "</html>"
        Return tablaHTML
    End Function

    Public Shared Function HTML_CSS_Error(ByVal objError As Exception, ByVal PageUrl As String, ByVal ipAdd As String, ByVal host As String, ByVal usuario As String) As String
        Dim tablaHTML As New StringBuilder
        tablaHTML.Append(" <html> ")
        tablaHTML.Append(" <head> ")
        tablaHTML.Append(" <title>" & objError.Message & "</title> ")
        tablaHTML.Append(" <style> ")
        tablaHTML.Append(" body {font-family:'Verdana';font-weight:normal;font-size: .7em;color:black;} ")
        tablaHTML.Append(" p {font-family:'Verdana';font-weight:normal;color:black;margin-top: -5px} ")
        tablaHTML.Append("     b {font-family:'Verdana';font-weight:bold;color:black;margin-top: -5px}")
        tablaHTML.Append(" H1 { font-family:'Verdana';font-weight:normal;font-size:18pt;color:red }")
        tablaHTML.Append(" H2 { font-family:'Verdana';font-weight:normal;font-size:14pt;color:maroon }")
        tablaHTML.Append("  pre {font-family:'Lucida Console';font-size: .9em}")
        tablaHTML.Append(" .marker {font-weight: bold; color: black;text-decoration: none;}")
        tablaHTML.Append(" .version {color: gray;}")
        tablaHTML.Append(" .error {margin-bottom: 10px;}")
        tablaHTML.Append(" .expandable { text-decoration:underline; font-weight:bold; color:navy; cursor:hand; }")
        tablaHTML.Append(" </style>")
        tablaHTML.Append(" </head>")
        tablaHTML.Append(" <body bgcolor='white'>")
        tablaHTML.Append(" <span><H1>Error de servidor (" & My.Computer.Name & ")  en la aplicación '" & My.Request.ApplicationPath & "'.<hr width=100% size=1 color=silver></H1>")
        tablaHTML.Append(" <h2> <i>" & objError.Message & "</i> </h2></span> ")
        tablaHTML.Append(" <font face='Arial, Helvetica, Geneva, SunSans-Regular, sans-serif '> ")
        tablaHTML.Append(" <b> Descripción: </b>Excepción no controlada al ejecutar la solicitud Web actual. Revise el seguimiento de la pila para obtener más información acerca del error y dónde se originó en el código. ")
        tablaHTML.Append(" <br><br> ")
        tablaHTML.Append(" <b> Detalles de la excepción: </b>" & objError.GetType.FullName & ": " & objError.Message & "<br><br> ")
        tablaHTML.Append(" <b>Error de código fuente:</b> <br><br> ")
        tablaHTML.Append(" <table width=100% bgcolor='#ffffcc'>  ")
        tablaHTML.Append(" <tr> ")
        tablaHTML.Append(" <td> ")
        tablaHTML.Append(" <code><pre>  ")
        tablaHTML.Append("<br><font color=red>Usuario: " & usuario)
        tablaHTML.Append("<br></font>IP :     " & ipAdd)
        tablaHTML.Append("<br>Host :  " & host)
        If Not My.Request.QueryString.Count = 0 Then
            tablaHTML.Append("<br>QueryString :  " & My.Request.Url.Query)
        End If
        tablaHTML.Append(" </pre></code> ")
        tablaHTML.Append(" </td> ")
        tablaHTML.Append(" </tr> ")
        tablaHTML.Append(" </table> ")
        tablaHTML.Append(" <br> ")
        tablaHTML.Append(" <b> Archivo de origen: </b> " & My.Request.PhysicalPath & "<b>  ")
        tablaHTML.Append(" <br><br> ")
        tablaHTML.Append(" <b>Seguimiento de la pila:</b> <br><br> ")
        tablaHTML.Append(" <table width=100% bgcolor='#ffffcc'> ")
        tablaHTML.Append(" <tr> ")
        tablaHTML.Append(" <td> ")
        tablaHTML.Append(" <code><pre> ")
        tablaHTML.Append(" [" & objError.GetType.Name & ": " & objError.Message & "] <br>")
        tablaHTML.Append(objError.StackTrace)
        'tablaHTML.Append(" System.Web.Util.CalliHelper.EventArgFunctionCaller(IntPtr fp, Object o, Object t, EventArgs e) +14 ")
        'tablaHTML.Append(" System.Web.Util.CalliEventHandlerDelegateProxy.Callback(Object sender, EventArgs e) +35 ")
        'tablaHTML.Append(" System.Web.UI.Control.OnLoad(EventArgs e) +99 ")
        'tablaHTML.Append(" System.Web.UI.Control.LoadRecursive(+50) ")
        'tablaHTML.Append(" System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) +627 ")
        tablaHTML.Append(" </pre></code> ")
        tablaHTML.Append(" </td> ")
        tablaHTML.Append(" </tr> ")
        tablaHTML.Append(" </table> ")
        tablaHTML.Append(" <br> ")
        tablaHTML.Append(" <hr width=100% size=1 color=silver>  ")
        tablaHTML.Append(" <b>Información de browser:</b>&nbsp;" & My.Request.Browser.Browser & "; Versión:" & My.Request.Browser.Id & "<br> ")
        tablaHTML.Append(" <b>Agente Browser:</b>&nbsp;" & My.Request.UserAgent.ToString & "")
        tablaHTML.Append(" </font> ")
        tablaHTML.Append(" </body> ")
        tablaHTML.Append(" </html> ")
        tablaHTML.Append(" <!--  ")
        tablaHTML.Append(objError.ToString) '" [Exception]: Error controlado  ")
        'tablaHTML.Append(" en ASP.ejemplo_aspx.Page_Load(Object sender, EventArgs e) en C:\Desarrollo\Desarrollo\DESA_ABASTECIMIENTO\ABASTECIMIENTO\WebSites\ABASTECIMIENTOS\Ejemplo.aspx:línea 43  ")
        'tablaHTML.Append(" en System.Web.Util.CalliHelper.EventArgFunctionCaller(IntPtr fp, Object o, Object t, EventArgs e) ")
        'tablaHTML.Append(" en System.Web.Util.CalliEventHandlerDelegateProxy.Callback(Object sender, EventArgs e) ")
        'tablaHTML.Append(" en System.Web.UI.Control.OnLoad(EventArgs e) ")
        'tablaHTML.Append(" en(System.Web.UI.Control.LoadRecursive()) ")
        'tablaHTML.Append(" en System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) ")
        'tablaHTML.Append(" [HttpUnhandledException]: Se produjo una excepci&#243;n de tipo 'System.Web.HttpUnhandledException'. ")
        'tablaHTML.Append(" en System.Web.UI.Page.HandleError(Exception e)")
        'tablaHTML.Append(" en System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) ")
        'tablaHTML.Append(" en System.Web.UI.Page.ProcessRequest(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) ")
        'tablaHTML.Append(" en(System.Web.UI.Page.ProcessRequest())")
        'tablaHTML.Append(" en System.Web.UI.Page.ProcessRequestWithNoAssert(HttpContext context) ")
        'tablaHTML.Append(" en System.Web.UI.Page.ProcessRequest(HttpContext context) ")
        'tablaHTML.Append(" en ASP.ejemplo_aspx.ProcessRequest(HttpContext context) ")
        'tablaHTML.Append(" en(System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()) ")
        'tablaHTML.Append(" en System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously) ")
        tablaHTML.Append(" --> ")
        Return tablaHTML.ToString
    End Function

   
End Class
