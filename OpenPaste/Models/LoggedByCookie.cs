using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OpenPaste.Models
{
    public class LoggedByCookie
    {
        [ScaffoldColumn(true), Key]
        public int id { get; set; }

        public string session_id { get; set; }

        public String mail { get; set; }

        [ForeignKey("mail")]
        public virtual User User { get; set; }
    }
}