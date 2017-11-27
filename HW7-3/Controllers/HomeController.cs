using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace HW7_3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string test = WebConfigurationManager.AppSettings["test"];
            System.Diagnostics.Debug.WriteLine(test);
            return View();
        }
    }
}