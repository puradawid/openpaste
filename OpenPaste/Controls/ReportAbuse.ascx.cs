using OpenPaste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenPaste.Controls
{
    public partial class ReportAbuse : System.Web.UI.UserControl
    {

        protected int pasteId { get; set; }

        public string PasteId
        {
            get { return pasteId.ToString(); }
            set { pasteId = int.Parse(value); }
        }

        protected Boolean start_abusing_v;
        protected Boolean report_button_v;
        protected Boolean abuse_text_v;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected override void OnPreRender(EventArgs e)
        {
            start_abusing.Visible = start_abusing_v;
            report_button.Visible = report_button_v;
            abuse_text.Visible = abuse_text_v;
            base.OnPreRender(e);
        }

        protected void Report(object sender, EventArgs e)
        {
            if (Session["user"] == null) return;
            using (var context = new DatabaseContext())
            {
                Models.Paste p = (from paste in context.Pastes where paste.pasteId == pasteId select paste).First();
                Abuse a = new Abuse() {
                    Paste = p,
                    mail = (Session["user"] as Models.User).mail,
                    reason = abuse_text.Text
                };
                context.Abuses.Add(a);
                context.SaveChanges();
                sendMessage("Abuse deposed on " + abuse_text.Text);
            }
        }

        protected void sendMessage(string text)
        {
            MailMessage mailObj = new MailMessage(
            "system@mail.com", "puradawid@gmail.com", "Abuse Report", text);
            SmtpClient SMTPServer = new SmtpClient("smtp.google.com:465");
            SMTPServer.Credentials = new System.Net.NetworkCredential("puradawid@gmail.com", "zse4321!@#$");
            try
            {
                SMTPServer.Send(mailObj);
            }
            catch (Exception ex)
            {
                container.InnerHtml = "Woops, abuse sended but there is problem with email to admin " + ex.Message;
            }
        }

        protected ReportAbuse()
        {
            start_abusing_v = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Open_Form(object sender, EventArgs e)
        {
            start_abusing_v = false;
            report_button_v = true;
            abuse_text_v = true;
        }

        protected override object SaveControlState()
        {
            object[] controlState = new object[5];
            controlState[0] = base.SaveControlState();
            controlState[1] = start_abusing_v;
            controlState[2] = report_button_v;
            controlState[3] = abuse_text_v;
            controlState[4] = pasteId;
            return controlState;
        }

        protected override void LoadControlState(object savedState)
        {
            object[] controlState = (object[])savedState;
            if(controlState[0] != null)
                base.LoadControlState(controlState[0]);
            start_abusing_v = (bool)controlState[1];
            report_button_v = (bool)controlState[2];
            abuse_text_v = (bool)controlState[3];
            pasteId = (int)controlState[4];
        }
    }
}