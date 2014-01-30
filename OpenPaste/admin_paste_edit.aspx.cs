using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenPaste
{
    public partial class admin_paste_edit : System.Web.UI.Page
    {
        protected Models.Paste _current;
        protected Models.Paste current { get { return _current; } set { _current = value; } }
        protected Models.DatabaseContext context = new Models.DatabaseContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || (Session["user"] as Models.User).status != "admin")
                Response.Redirect("Pastes.aspx");
            current = (Models.Paste)Session["current_paste"];
            if (current == null) current = new Models.Paste();
            if (!Page.IsPostBack)
            {
                this.DataBind();
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Session["current"] = null;
            Response.Redirect("admin_pastes.aspx");
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            current = (from paste in context.Pastes where (current.pasteId == paste.pasteId) select paste).First();
            current.content = code.Text;
            context.SaveChanges();
            Response.Redirect("admin_pastes.aspx");
        }
    }
}