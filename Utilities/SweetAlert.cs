using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Transportes3Capas.utilidades
{
    public class SweetAlert
    {
        public static void Sweet_Alert(string title, string msg, string type, Page pg, Object obj)
        {
            string sa = "<script language='javascript'>" +
                "Swal.fire({" +
                "title: '" + title + "'," +
                "text: '" + msg + "'," +
                "icon: '" + type + "'" +
                "})" +
                "</script>";

            //type hace referencia al tipo de objeto que voy a trabajar
            Type csType = obj.GetType();
            //ClientScriptManager me ayuda a incrustar bloques de codigo de JS en tiempo real dentro de formulario web fuera de ASP
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(csType, sa, sa);
        }
        public static void Sweet_Alert(string title, string msg, string type, Page pg, Object obj, string dir)
        {
            string sa = "<script language='javascript'>" +
                           "Swal.fire({" +
                           "title: '" + title + "'," +
                           "text: '" + msg + "'," +
                           "icon: '" + type + "'" +
                           "}).then((result)=>{" +
                           "if(result.isConfirmed){" +
                           "window.location.href = '" + dir + "'" +
                           "}" +
                           "});" +
                           "</script>";

            //type hace referencia al tipo de objeto que voy a trabajar
            Type csType = obj.GetType();
            //ClientScriptManager me ayuda a incrustar bloques de codigo de JS en tiempo real dentro de formulario web fuera de ASP
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(csType, sa, sa);
        }
    }
}