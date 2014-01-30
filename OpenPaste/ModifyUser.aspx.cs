using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenPaste
{
    public partial class ModifyUser : System.Web.UI.Page
    {
        protected Models.User logged_user;
        protected Models.User user { get { return logged_user; } set { logged_user = value; } }
        protected Models.DatabaseContext context = new Models.DatabaseContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (Models.User)Session["user"];
            if(user == null)
            {
                Response.Redirect("Login.aspx");
            }
            if(!IsPostBack)
            {
                DataBind();
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pastes.aspx");
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void user_formview_UpdateItem(String id)
        {
            OpenPaste.Models.User item = null;
            item = (from _user in context.Users where user.mail == _user.mail select _user).First();
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            String password = item.password;
            TryUpdateModel(item);
            if (item.password == "")
                item.password = password;
            if (ModelState.IsValid)
            {
                context.SaveChanges();
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public OpenPaste.Models.User user_formview_GetItem(String id)
        {
            return (from _user in context.Users where user.mail == _user.mail select _user).First();
        }
    }
}