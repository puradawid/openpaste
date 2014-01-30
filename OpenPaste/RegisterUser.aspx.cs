using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenPaste.Models;

namespace OpenPaste
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void form_submit_Click(object sender, EventArgs e)
        {
            Validate();
            if(!Page.IsValid)
            {
                return;
            }
            
            //here will load data
            string name = this.register_name.Text;
            string surname = this.register_surname.Text;
            string email = this.register_mail.Text;
            string password = this.register_password.Text;
            string birthdate = this.register_birth_date.ToString();

            using (var ctx = new DatabaseContext())
            {
                ctx.Users.Add(
                    new User
                    {
                        mail = email,
                        surname = surname,
                        password = password,
                        name = name
                    });
                try
                {
                    ctx.SaveChanges();
                } catch (System.Data.SqlClient.SqlException exception)
                {
                    Form.InnerText = "User is existing";
                }
                    List<User> users = ctx.Users.ToList<User>();
            }

            Form.InnerText = "User was registered, thank you for it!";
            Response.Redirect("Pastes.aspx");
        }

        protected void onTextChanged_validate(object sender, EventArgs e)
        {
            Validate();
        }
    }
}