using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniqueEmail.Models
{
    public class Email
    {
        public string emailAddress { get; set; }
    }
}