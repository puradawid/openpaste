using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenPaste
{
    public partial class admin_abuses : System.Web.UI.Page
    {

        List<Models.Abuse> abuses_list;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Session["user"] == null || (Session["user"] as Models.User).status != "admin")
                Response.Redirect("Pastes.aspx");
            RestoreData();
        }

        protected void RestoreData()
        {
            using (var ctx = new Models.DatabaseContext())
            {
                abuses_list = ctx.Abuses.ToList();
                abuses.DataSource = abuses_list;
                abuses.DataBind();
            }
        }

        protected void Delete_Paste(object sender, CommandEventArgs args)
        {
            using (var ctx = new Models.DatabaseContext())
            {
                int id = int.Parse((String)args.CommandArgument);
                Models.Abuse a =
                    (from abuse in ctx.Abuses where abuse.id == id select abuse).First();
                ctx.Pastes.Remove(a.Paste);
                ctx.SaveChanges();
                RestoreData();
            }
        }

        protected void Cancel_Abuse(object sender, CommandEventArgs args)
        {
            using(var ctx = new Models.DatabaseContext())
            {
                int id = int.Parse((String)args.CommandArgument);
                Models.Abuse a = 
                    (from abuse in ctx.Abuses where abuse.id == id select abuse).First();
                ctx.Abuses.Remove(a);
                ctx.SaveChanges();
                RestoreData();
            }
        }
    }
}