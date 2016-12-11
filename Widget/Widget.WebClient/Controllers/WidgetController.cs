using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widget.Domain.Abstract;
using Widget.Domain.Models;
using Widget.WebClient.Models;

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
            List<SelectListItem> states = new List<SelectListItem>();

            foreach (State state in stateRepository.ListStates()) {
                states.Add(new SelectListItem {
                    Text = state.Name,
                    Value = state.Id.ToString()
                });
            }

            return View(new WidgetIndexViewModel {
                States = states,
                Widgets = widgetRepository.ListWidgets()
            });
        }

        // POST /calculate
        public ActionResult Calculate() {
            return View();
        }
    }
}