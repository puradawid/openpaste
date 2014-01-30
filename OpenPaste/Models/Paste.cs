using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenPaste.Models
{
    public class Paste
    {
        [ScaffoldColumn(true), Key]
        public int pasteId { get; set; }

        public string title { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string content { get; set; }
        
        
        
        public DateTime paste_time { get; set; }

        public string codeType { get; set; }
        
        public String mail { get; set; }
        [ForeignKey("mail")]
        public virtual User User { get; set; }

        public string getAsHtml()
        {
            String result = "";
            foreach(char s in this.content)
            {
                if (s == '\n')
                    result += "<br/>";
                else
                    result += s;
            }
            return result;
        }
    }
}