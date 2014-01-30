using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenPaste.Models;

namespace OpenPaste
{
    public partial class Paste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PostPaste(object sender, EventArgs e)
        {
            using(var ctx = new DatabaseContext())
            {
                User user;
                if (Session["user"] == null)
                    user = (from us in ctx.Users where us.mail == "anonymous@example.com" select us).First();
                else
                    user = (User)Session["user"];

                ctx.Pastes.Add(new Models.Paste
                {
                    mail = user.mail,
                    codeType = lang.Text,
                    content = code.Text,
                    paste_time = DateTime.Now
                });
                ctx.SaveChanges();
                Response.Redirect("Pastes.aspx");
            }
        }
    }
}