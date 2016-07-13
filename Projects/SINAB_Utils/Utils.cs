using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SINAB_Utils
{
    public static class Utils
    {
        /// <summary>
        /// Retorna el tipo de control que ha disparado el postback en la pagina
        /// </summary>
        /// <param name="pagina">pagina que ha hecho postback</param>
        /// <returns>El control que disparo el postback</returns>
        public static Control ObtenerControlesOnPostBack(Page pagina)
        {
            Control res = null;
            var ctrlName = pagina.Request.Params.Get("__EVENTTARGET"); //si no funciona probar con: Page.Request.Form.Get(0)
            if (!string.IsNullOrEmpty(ctrlName))
            {
                res = pagina.FindControl(ctrlName);
            }
            else
            {
                foreach (string ctl in pagina.Request.Form)
                {

                    var c = pagina.FindControl(ctl);
                    if (c == null) continue;
                    if (c.GetType() == typeof(LinkButton)) continue;
                    res = c;
                    break;
                }
            }
            return res;
        }

        /// <summary>
        /// Concantena la ruta especificada en una popup y la devuelve como cadena.
        /// </summary>
        /// <param name="ruta">Ruta a mostrar en la ventana</param>
        /// <returns>Cadena que puede referirse a un link href</returns>
        public static string ReferirVentana(string ruta)
        {
            var page = HttpContext.Current.CurrentHandler as Page;

            var url = page.ResolveUrl(CheckUrl(ruta));
            var cad = string.Format("window.open('{0}', 'popup', 'menubar=0,titlebar=0,location=0,toolbar=0,resizable=0,scrollbars=1, width=1110, height=784');return false;",url);
            return cad;
        }

        /// <summary>
        /// Muestra una ventana PopUp con la ruta proporcionada
        /// </summary>
        /// <param name="ruta">Ruta a mostrar en la ventana</param>
        public static void MostrarVentana(string ruta)
        {
            var page = HttpContext.Current.CurrentHandler as Page;

            var url = page.ResolveUrl(CheckUrl(ruta));

            var cuerpo = string.Format("window.open('{0}', 'popup', 'menubar=0,titlebar=0,location=0,toolbar=0,resizable=0,scrollbars=1, width=1110, height=784');", url);

            page.ClientScript.RegisterStartupScript(page.GetType(), "Startup", cuerpo, true);

        }

      
        public static int DistribuirCantidad(decimal cantidad, decimal porcentaje)
        {
            return (int)Math.Round(cantidad * (porcentaje / 100), 0, MidpointRounding.AwayFromZero);
        }

        public static ArrayList DistribuirDias(int DiasMaximos, int divisiones)
        {
            var slice = DiasMaximos / divisiones;
            var slices = new ArrayList();
            for (var i = 0; i < divisiones; i++)
            {
                slices.Add(slice);
            }

            var slicesar = (Int32[])slices.ToArray(typeof(Int32));


            while (slicesar.Sum() > DiasMaximos)
            {
                var last = slicesar.Last();
                last -= 1;
                slicesar[slicesar.Length - 1] = last;
                slices.RemoveAt(slices.Count - 1);
                slices.Add(last);
            }

            while (slicesar.Sum() < DiasMaximos)
            {
                var last = slicesar.Last();
                last += 1;
                slicesar[slicesar.Length - 1] = last;
                slices.RemoveAt(slices.Count - 1);
                slices.Add(last);
            }


            return slices;


        }

        public static ArrayList DistribuirPorcentajes(int divisiones)
        {
            const int total = 100;
            var porcentajes = new ArrayList();
            var op = total / (decimal)divisiones;
            var slice = Math.Round(op, 2, MidpointRounding.AwayFromZero);


            for (var i = 0; i < divisiones; i++)
            {
                porcentajes.Add(slice);
            }


            if ((divisiones % 2) == 0) return porcentajes;
            var arr = (decimal[])porcentajes.ToArray(typeof(decimal));
            while (arr.Sum() != 100)
            {
                var ultimo = arr.Last();
                ultimo += (decimal).01;
                arr[arr.Length - 1] = ultimo;
                porcentajes.RemoveAt(porcentajes.Count - 1);
                porcentajes.Add(ultimo);
            }

            return porcentajes;

        }

        public static ArrayList DistribuirProducto(decimal cantidadTotal, ArrayList distribucionProducto)
        {
            var count = 1;
            decimal sumaDistribuicion = 0;
            var distribucionEntrega = new ArrayList();

            foreach (decimal t in distribucionProducto)
            {
                if ((cantidadTotal - sumaDistribuicion) > 0)
                {
                    decimal valorEntrega;
                    if (count == distribucionProducto.Count)
                    {
                        valorEntrega = cantidadTotal - sumaDistribuicion;
                        distribucionEntrega.Add(valorEntrega);
                    }
                    else
                    {
                        valorEntrega = DistribuirCantidad(cantidadTotal, t);
                        distribucionEntrega.Add(valorEntrega);
                        sumaDistribuicion += valorEntrega;
                    }
                }
                else
                {
                    distribucionEntrega.Add(0);
                }
                count++;
            }
            return distribucionEntrega;
        }
        

        private static string CheckUrl(string ruta)
        {
            return (ruta.IndexOf('~') != -1) ? ruta : (ruta.StartsWith("/") ? ("~" + ruta) : ("~/" + ruta));
        }
    }
}
