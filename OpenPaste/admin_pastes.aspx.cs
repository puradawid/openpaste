using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenPaste
{
    public partial class admin_pastes : System.Web.UI.Page
    {
        protected OpenPaste.Models.DatabaseContext context;

        protected DbSet<OpenPaste.Models.Paste> pastes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || (Session["user"] as Models.User).status != "admin")
                Response.Redirect("Pastes.aspx");
            loadModel();
        }

        protected void loadModel()
        {
            context = new OpenPaste.Models.DatabaseContext();
            pastes = context.Pastes;
            pastes.Load();
            listViewPastes.DataSource = pastes.ToList<Models.Paste>();
            listViewPastes.DataBind();
        }

        protected void EditButton_Command(object sender, CommandEventArgs e)
        {
            int paste_id = int.Parse((String)e.CommandArgument);
            Models.Paste result = (from paste in pastes where (paste.pasteId == paste_id) select paste).First();
            Session["current_paste"] = result;
            Response.Redirect("admin_paste_edit.aspx");
        }

        protected void RemoveButton_Command(object sender, CommandEventArgs e)
        {
            int paste_id = int.Parse((String)e.CommandArgument);
            Models.Paste to_delete = (from paste in pastes where (paste.pasteId == paste_id) select paste).First();
            pastes.Remove(to_delete);
            context.SaveChanges();
            loadModel();
        }
    }
}