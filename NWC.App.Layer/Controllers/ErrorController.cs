using log4net;
using System.Web.Mvc;

namespace NWC.Application.Layer.Controllers
{
    /// <summary>
    /// Controller to handle 404 condition
    /// </summary>
    public class ErrorController : Controller
    {
        private ILog Logger;

        public ErrorController( ILog logger)
        {
            this.Logger = logger;
        }
        public ActionResult NotFound()
        {
            var url = Request.Url.ToString();
            //Log the url which was not found and then show the 404 page
            Logger.Error(url + "not found");
            return View();
        }

    }
}