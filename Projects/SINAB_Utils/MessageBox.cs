using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace SINAB_Utils
{
    /// <summary>
    /// Despliega jqDialogs en reemplazo de alertas y confirmaciones Javascript
    /// <example>Este ejemplo muestra como debe lanzarce las confirmaciones y alertas con postback
    /// <code>
    /// ... 
    ///  Confirm("Mensaje a mostrar", "Titulo", OptionPostBack.YesPostBack)
    /// ...
    /// If IsPostBack Then
    ///     If ConfirmTarget = "Titulo" Then ProcesarConfirmacion(ConfirmArgument)
    /// ...
    /// Protected Sub ProcesarConfirmacion(ByVal eventArgument As Object)
    /// 'Si se necesita evaluar el argumento
    ///    If ConfirmArgument Then
    ///        If Req.Almacen IsNot Nothing Then
    ///            'Hacer algo
    ///        Else
    ///            'Hacer algo
    ///        End If
    /// End Sub
    /// </code>
    /// </example>
    /// </summary>
    public static class MessageBox
    {
        #region PROPIEDADES
        
        /// <summary>
        /// String generado al desplegar diálogos que identifica el desencadenante
        /// </summary>
        public static string ConfirmTarget
        {
            get
            {
                var page = (Page)HttpContext.Current.CurrentHandler;
                page.ClientScript.GetPostBackEventReference(page, String.Empty);
                return string.IsNullOrEmpty(page.Request.Params.Get("__EVENTTARGET"))
                           ? string.Empty
                           : page.Request.Params.Get("__EVENTTARGET");
            }
        }
        
        /// <summary>
        /// String argumento del target generado al desplegar diálogos
        /// </summary>
        public static string ConfirmArgument
        {
            get
            {
                var page = (Page)HttpContext.Current.CurrentHandler;
                page.ClientScript.GetPostBackEventReference(page, String.Empty);
                return string.IsNullOrEmpty(page.Request.Params.Get("__EVENTARGUMENT"))
                           ? string.Empty
                           : page.Request.Params.Get("__EVENTARGUMENT");
            }
        }

        #endregion PROPIEDADES

        #region MÉTODOS
        
        /// <summary>
        /// Muestra el diálogo de Aviso sin posibilidad de postback y título "Alerta"
        /// </summary>
        /// <param name="message">Mensaje que muestra en el diálogo</param>
        public static void Alert(string message)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            var cleanMessage = message.Replace("'", @"\'");
            cleanMessage = cleanMessage.Replace(@"""", @"\'");
            cleanMessage = cleanMessage.Replace("\r\n", "<br />");
            var sb = "AlertDialog('Aceptar', '" + cleanMessage + "', " + (Int32)OptionPostBack.WithoutPostBack + ", 'Alerta');";
            if (page != null) page.ClientScript.RegisterStartupScript(page.GetType(), "ConfirmKey", sb, true);

            //var cleanMessage = message.Replace("'", "\'");
            //var script = "<script type='text/javascript'>alert('" + cleanMessage + "');</script>";
            //var page = (Page)HttpContext.Current.CurrentHandler;

            //if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            //{
            //    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script); //typeof(MessageBox)??
            //}
        }

        /// <summary>
        /// Muestra un diálogo de Alerta
        /// </summary>
        /// <param name="message">Mensaje a mostrar</param>
        /// <param name="key">Título</param>
        public static void Alert(string message, string key)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            var cleanMessage = message.Replace("'", "\'");
            var sb = "AlertDialog('Aceptar', '" + cleanMessage + "', " + (Int32)OptionPostBack.WithoutPostBack + ", '" + key + "');";
            if (page != null) page.ClientScript.RegisterStartupScript(page.GetType(), "ConfirmKey", sb, true);
        }

        /// <summary>
        ///  Muestra el diálogo de Aviso con postback en aceptar y título variable
        /// </summary>
        /// <param name="message">Mensaje que muestra en el diálogo</param>
        /// <param name="key">Título</param>
        public static void AlertSubmit(string message, string key)
        {
            var page = HttpContext.Current.CurrentHandler as Page;

            
            var cleanMessage = message.Replace("'", "\'");
            var sb = "AlertDialog('Aceptar', '" + cleanMessage + "', " + (Int32)OptionPostBack.YesPostBack + ", '" + key + "');";
            if (page != null) page.ClientScript.RegisterStartupScript(page.GetType(), "ConfirmKey", sb, true);
        }

        /// <summary>
        /// Muestra diálogo de Confirmacion con postback y título variable
        /// </summary>
        /// <param name="message">Mensaje que muestra en el diálogo</param>
        /// <param name="key">Título</param>
        /// <param name="type">Opció de postback</param>
        public static void Confirm(string message, string key, OptionPostBack type)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            var cleanMessage = message.Replace("'", "\'");
            var sb = "ConfirmDialog('Si', 'No', '" + cleanMessage + "', " + (Int32)type + ", '"+key+"');";
            if (page != null) page.ClientScript.RegisterStartupScript(page.GetType(), "ConfirmKey", sb, true);
           
        }

        #endregion MÉTODOS

        /// <summary>
        /// Tipos de acciones que desencadenan los botones de comando de los diálogos
        /// <list type="bullet">
        /// <item><description>YesPostBack = 1, Hace postback en el boton Aceptar</description></item>
        /// <item><description>NotPostBack = 2, Hace postback en el boton Cancelar</description></item>
        /// <item><description>YesNotPostBack = 3, Hace postback tanto en Aceptar como en Cancelar (diferente acción)</description></item>
        /// <item><description>WithoutPostBack = 4, No hace postback</description></item>
        /// </list>
        /// </summary>
        public enum OptionPostBack
        {
            YesPostBack = 1,
            NotPostBack = 2,
            YesNotPostBack = 3,
            WithoutPostBack = 4
        }

        
    }


    
}
