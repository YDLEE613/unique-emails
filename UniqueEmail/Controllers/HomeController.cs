using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniqueEmail.Models;
using UniqueEmailContext;

namespace UniqueEmail.Controllers
{
    public class HomeController : Controller
    {
        private MainContext _context = new MainContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(EmailsUtil emails)
        {
            if (ModelState.IsValid)
            {
                // get unique ones
                emails.uniqueEmails = _context.GetUniqueEmails(emails.emailList);
            }

            return View(emails);
        }
    }
}