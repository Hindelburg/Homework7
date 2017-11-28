using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HW7_3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string search)
        {
            return View();
        }
        public ActionResult Find(string search)
        {
            string s = "https://api.giphy.com/v1/gifs/search?api_key=" + System.Web.Configuration.WebConfigurationManager.AppSettings["test"] + "&q=" + search + "&limit=25&offset=0&rating=G&lang=en";
            Debug.WriteLine(s);


            WebRequest request = WebRequest.Create(s);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string response2 = reader.ReadToEnd();

            Debug.WriteLine(response2);

            //JObject result = JObject.Parse(response2);

            //Debug.WriteLine(result);


            var test = new JavaScriptSerializer().DeserializeObject(response2);

            Debug.WriteLine(test);

            reader.Close();
            response.Close();

            JsonResult errorMessage = Json(test, JsonRequestBehavior.AllowGet);

            Debug.WriteLine(errorMessage);

            return Json(test, JsonRequestBehavior.AllowGet);
        }
    }
}