using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OpenPaste.Models
{
    public class PastesDatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            getUsers().ForEach(x => { context.Users.Add(x); });
            getPastes().ForEach(x => { context.Pastes.Add(x); });
            getAbuses().ForEach(x => { context.Abuses.Add(x); });
        }

        public List<Paste> getPastes()
        {
            return new List<Paste>
            {
                new Paste
                {
                    pasteId = 1,
                    paste_time = DateTime.Now,
                    content = "This is plaintext paste for users",
                    title = "Plaintext paste",
                    mail = "user@example.com"
                },
                new Paste
                {
                    pasteId = 2,
                    paste_time = DateTime.Today,
                    content = "Java code makes me happy \n but unfortunately it is not working this time",
                    title = "Hey i just write my first code!",
                    mail = "user@example.com"
                }
            };
        }

        public List<User> getUsers()
        {
            return new List<User>
            {
                new User 
                {
                    mail = "user@example.com",
                    name = "User",
                    password = "password",
                    surname = "Surname",
                    status = "admin"
                },
                new User 
                {
                    mail = "anonymous@example.com",
                    name = "Gall",
                    password = "",
                    surname = "Anomim",
                    status = "anonymous"
                }
            };
        }

        public List<Abuse> getAbuses()
        {
            return new List<Abuse>
            {
             new Abuse
             {
                 pasteId = 1,
                 mail = "user@example.com",
                 id = 1,
                 reason = "vulagrisms"
             }
            };
        }
    }
}