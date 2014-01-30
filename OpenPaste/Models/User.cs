using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OpenPaste.Models
{
    public class User
    {
        protected static User anonymousUser = null;
        public static User getAnonymous()
        {
            if(anonymousUser == null)
                anonymousUser = new User
                {
                    mail = "mail@anonymoys.com",
                    name = "Anonym",
                    password = "",
                    surname = "Gall"
                };
            return anonymousUser;
        }
        
        //[ScaffoldColumn(false), Key]
        //public int UserID { get; set; }
        
        public string name { get; set; }

        public string surname { get; set; }

        public string status { get; set; }

        [Key]
        public string mail { get; set; }

        public string password { get; set; }

        //public virtual ICollection<Paste> pastes { get; set; }
    }
}