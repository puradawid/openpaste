using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OpenPaste.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("OpenPaste")
        { }

        public DbSet<Paste> Pastes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Abuse> Abuses { get; set; }

        public DbSet<LoggedByCookie> LoggedUsers { get; set; }


    }
}