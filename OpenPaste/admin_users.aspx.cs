using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenPaste
{
    public partial class admin_users : System.Web.UI.Page
    {
        protected Models.DatabaseContext context = new Models.DatabaseContext();
        protected List<Models.User> users;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || (Session["user"] as Models.User).status != "admin")
                Response.Redirect("Pastes.aspx");
        }

        protected void updateModel(object sender, ListViewUpdateEventArgs e)
        {

        }
        
        protected void Delete_User(object sender, CommandEventArgs e)
        {

        }

        public IQueryable<OpenPaste.Models.User> users_listview_GetData()
        {
            IQueryable<Models.User> users;
            users = (from user in context.Users select user).ToList().AsQueryable();
            return users;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void users_listview_UpdateItem(String mail)
        {
            OpenPaste.Models.User item = null;
            item = (from user in context.Users where user.mail == mail select user).First();
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", mail));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                context.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void users_listview_DeleteItem(String mail)
        {
            context.Users.Remove((from user in context.Users where user.mail == mail select user).First());
            context.SaveChanges();
        }
    }
}