using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrankPatata
{
    internal class ClassComment
    {
        public string comment_text { get; set; }
        public string hora { get; set; }
        public string username { get; set; }

        public ClassComment(string comment_text, string hora, string username){
            this.comment_text = comment_text;
            this.hora = hora;
            this.username = username;
        }
        
    }
}
