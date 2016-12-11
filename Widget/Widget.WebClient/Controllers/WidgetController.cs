using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widget.Domain.Abstract;

namespace Widget.WebClient.Controllers {
    /// <summary>
    /// The main controller for the application.
    /// </summary>
    public class WidgetController : Controller {
        private IStateRepository stateRepository;
        private IWidgetRepository widgetRepository;

        public WidgetController(IStateRepository stateRepository, IWidgetRepository widgetRepository) {
            this.stateRepository = stateRepository;
            this.widgetRepository = widgetRepository;
        }

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