using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;

namespace SINAB_Utils
{
    public static class Config
    {
        public static string LogoUrl
        {
            get
            {
                 try
                {
                return WebConfigurationManager.AppSettings["LogoUrl"];
                }
                 catch
                 {
                     return string.Empty;
                 }
            }
            //set
            //{
            //    WebConfigurationManager.AppSettings["LogoUrl"] = value;
            //}
        }

        public static string ObtenerRutaSICO 
        {
            get
            {
                try
                {
                    return WebConfigurationManager.AppSettings["RutaSICO"];
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
    }
}
