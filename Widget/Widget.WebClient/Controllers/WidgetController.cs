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
            return View(WidgetIndexViewModel.Create(stateRepository, widgetRepository));
        }

        // POST /calculate
        public ActionResult Calculate(WidgetFormModel formModel) {
            WidgetIndexViewModel indexModel = WidgetIndexViewModel.Create(stateRepository, widgetRepository);
            int widgetCount = indexModel.Widgets.Count();

            if (formModel.WidgetQuantities.Count != widgetCount) {
                AddErrorMessage("Quantity amounts were not provided for all Widgets.");
            }
            else {
                for (int q = 0; q < formModel.WidgetQuantities.Count; q++) {
                    int quantity = formModel.WidgetQuantities[q];

                    if (quantity < 0) {
                        AddErrorMessage($"Quantity for Widget '{indexModel.Widgets[q].Name}' cannot be negative.");
                    }
                }

                indexModel.FormModel.WidgetQuantities = formModel.WidgetQuantities;
            }

            if (formModel.SelectedState < 1 || formModel.SelectedState > 50) {
                AddErrorMessage("Selected state is invalid.");
            }
            else {
                indexModel.FormModel.SelectedState = formModel.SelectedState;
            }

            if (TempData["Message"] == null) {
                return View("Index", indexModel);
            }
            else {
                TempData["Message"] = new SuccessMessageModel {
                    Message = "Calculation successful."
                };

                return View();
            }
        }

        private void AddErrorMessage(string message) {
            if (TempData["Message"] == null) {
                TempData["Message"] = new ErrorMessageModel();
            }

            (TempData["Message"] as ErrorMessageModel).AddError(message);
        }
    }
}