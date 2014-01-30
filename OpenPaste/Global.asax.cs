using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using OpenPaste.Models;
using System.Web.UI;

namespace OpenPaste
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer<DatabaseContext>(new PastesDatabaseInitializer());
            ScriptResourceDefinition jQuery = new ScriptResourceDefinition();
            jQuery.Path = "~/scripts/jquery-1.7.2.min.js";
            jQuery.DebugPath = "~/scripts/jquery-1.7.2.js";
            jQuery.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.7.2.min.js";
            jQuery.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.7.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQuery); 
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                using (var ctx = new Models.DatabaseContext())
                    if (Session["user"] == null && Request.Cookies["OpenPasteLogin"] != null)
                    {
                        string id = Request.Cookies["OpenPasteLogin"].Value;
                        var db = (from cookie in ctx.LoggedUsers where cookie.session_id == id select cookie);
                        if (db.Count() == 0) return;
                        Models.User user = db.First().User;
                        Session["user"] = user;
                        Response.Redirect("Pastes.aspx");
                    }
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}