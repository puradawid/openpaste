using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenPaste.Models;
namespace OpenPaste
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginUser(object sender, EventArgs e)
        {
            DatabaseContext dc = new DatabaseContext();
            IEnumerable<User> getUser = from user in dc.Users
                          where ( user.mail == username.Text ) && (user.password == password.Text)
                          select user;
            if(getUser.Count() > 0)
                Session["user"] = getUser.First();
            if (Session["user"] != null)
                Form.InnerText = "You are logged!";
            if (Session["user"] != null && still_logged.Checked)
            {
                Random r = new Random();
                Models.User _user = Session["user"] as Models.User;
                string id = r.NextDouble().ToString();
                Response.Cookies.Add(new HttpCookie("OpenPasteLogin", id));
                Response.Cookies["OpenPasteLogin"].Expires = DateTime.Now.AddDays(int.Parse(time.Text));
                using(var ctx = new Models.DatabaseContext())
                {
                    Models.LoggedByCookie lbc = new Models.LoggedByCookie()
                    {
                        mail = _user.mail,
                        session_id = id,
                    };
                    ctx.LoggedUsers.Add(lbc);
                    ctx.SaveChanges();
                }
            }
            
        }

        protected void still_logged_CheckedChanged(object sender, EventArgs e)
        {
            if (still_logged.Checked)
            {
                time.Visible = true;
            }
            else
                time.Visible = false;
        }
    }
}