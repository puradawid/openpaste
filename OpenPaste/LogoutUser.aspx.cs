using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenPaste.Apperance
{
    public partial class LogoutUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            string key = Response.Cookies["OpenPasteLogin"].Value;
            Response.Cookies["OpenPasteLogin"].Expires = DateTime.MinValue;
            Response.Redirect("Pastes.aspx");

            using (var ctx = new Models.DatabaseContext())
            {
                Models.LoggedByCookie lbc = (from logging in ctx.LoggedUsers where logging.session_id == key select logging).First();
                ctx.LoggedUsers.Remove(lbc);
                ctx.SaveChanges();
            }
        }
    }
}