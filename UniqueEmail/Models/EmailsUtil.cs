using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniqueEmail.Models
{
    public class EmailsUtil
    {
        public HashSet<string> uniqueEmails { get; set; }
        public List<Email> emailList { get; set; }

    }
}