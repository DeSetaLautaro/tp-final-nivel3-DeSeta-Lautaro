using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using Negocio;

namespace KioscoBabio_
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string JQueryVer = "1.11.3";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/js/jquery-" + JQueryVer + ".min.js",
                DebugPath = "~/js/jquery-" + JQueryVer + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Verificar si la sesión está disponible
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                Exception exc = Server.GetLastError();
                Session["Error"] = exc;
                Seguridad.ManejarError(exc);
                Server.Transfer("Error.aspx");
            }
            else
            {
                

            }
        }

    }

}