using HW7_3.Models;
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
using System.Web.Mvc.Routing;
using System.Web.Script.Serialization;

namespace HW7_3.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Find(string search, string rating, string userAgent)
        {
            string s = "https://api.giphy.com/v1/gifs/search?api_key=" + System.Web.Configuration.WebConfigurationManager.AppSettings["test"] + "&q=" + search + "&limit=25&offset=0&rating=" + rating + "&lang=en";
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


            string searched = search;
            DateTime dateSearched = DateTime.Now;
            string requestorIP = Request.UserHostAddress.ToString();
            string requestorAgent = userAgent;

            if(requestorIP == null)
            {
                requestorIP = "Not Available.";
            }
            if (requestorAgent == null)
            {
                requestorAgent = "Not Available.";
            }

            Debug.WriteLine(requestorAgent);

            var logEntry = new Log();
            logEntry.searched = searched;
            logEntry.dateSearched = dateSearched;
            logEntry.requestorIP = requestorIP;
            logEntry.requestorAgent = requestorAgent;

            db.Logs.Add(logEntry);
            db.SaveChanges();


            return Json(test, JsonRequestBehavior.AllowGet);
        }
    }
}