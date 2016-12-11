using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Widget.WebClient.Controllers {
    /// <summary>
    /// The main controller for the application.
    /// </summary>
    public class WidgetController : Controller {
        // GET /
        public ActionResult Index() {
            return View();
        }

        // POST /calculate
        public ActionResult Calculate() {
            return View();
        }
    }
}