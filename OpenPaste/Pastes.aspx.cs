using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using OpenPaste.Models;

namespace OpenPaste.Apperance
{
    public partial class Pastes : System.Web.UI.Page
    {

        protected List<Models.Paste> pastes = new List<Models.Paste>();
        protected Models.DatabaseContext ctx = new DatabaseContext();


        protected void Page_Load(object sender, EventArgs e)
        {

            int pasteId = 0;
            String pasteName = Request.Params["paste"];
            String myOwn = Request.Params["myOwn"];
            ReportControl.Visible = false;
            if(pasteName != null)
            {
                pasteId = int.Parse(pasteName);
                pastes = (from paste in ctx.Pastes where paste.pasteId == pasteId select paste).ToList();
                ReportControl.Visible = true;
                ReportControl.PasteId = pasteId.ToString();

            } else
            if(Session["user"] != null && myOwn != null)
            {
                String email = ((Models.User)Session["user"]).mail;
                pastes = (from paste in ctx.Pastes where paste.mail == email select paste).ToList();
            }
            else
            if (Request.Params["search"] != null)
            {
                String search = ((String)Request.Params["search"]);
                pastes = (from paste in ctx.Pastes where paste.content.Contains(search) select paste).ToList();
                header.InnerText = "Search results for: " + search; 
            }
            else 
            {
                //load content for pastes
                pastes = ctx.Pastes.ToList<Models.Paste>();
            }
            pastes_list.DataSource = pastes;
            pastes_list.DataBind();
        }

        protected List<Models.Paste> getPastes()
        {
            List<Models.Paste> pastes;
            using (var ctx = new DatabaseContext())
            {
                pastes = ctx.Pastes.ToList<Models.Paste>();
            }
            return pastes;
        }

        public IQueryable<OpenPaste.Models.Paste> GetLastPastes()
        {
            var ctx = new DatabaseContext();
            return ctx.Pastes;
        }
    }
}