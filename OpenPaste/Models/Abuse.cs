using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OpenPaste.Models
{
    public class Abuse
    {
        [ScaffoldColumn(true), Key]
        public int id { get; set; }

        public String mail { get; set; }
        
        [ForeignKey("mail")]
        public virtual User User { get; set; }

        public int pasteId { get; set; }

        [ForeignKey("pasteId")]
        public virtual Paste Paste { get; set; }


        public String meaning { get; set; }
        public String reason {get; set;}
    }
}