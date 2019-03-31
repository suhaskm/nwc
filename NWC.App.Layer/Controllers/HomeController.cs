using log4net;
using NWC.App.Layer.Models;
using NWC.Helper.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NWC.App.Layer.Controllers
{
    public class HomeController : Controller
    {
        private ILog Logger;

        public HomeController(ILog logger)
        {
            this.Logger = logger;
        }
        public ActionResult Index()
        {
            URL url = new URL();
            url.AppURI = ConfigurationHelper.GetConfigurations(Constants.ApiUrl);
            return View(url);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}