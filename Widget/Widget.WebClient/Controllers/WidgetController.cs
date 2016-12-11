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
        public ActionResult Calculate(int state, List<int> widgetQuantity) {
            WidgetIndexViewModel indexModel = WidgetIndexViewModel.Create(stateRepository, widgetRepository, state, widgetQuantity);
            int widgetCount = indexModel.Widgets.Count();

            if (widgetQuantity.Count != widgetCount) {
                AddErrorMessage("Quantity amounts were not provided for all Widgets.");
            }
            else {
                for (int q = 0; q < widgetQuantity.Count; q++) {
                    int quantity = widgetQuantity[q];

                    if (quantity < 0) {
                        AddErrorMessage($"Quantity for Widget '{indexModel.Widgets[q].Widget.Name}' cannot be negative.");
                    }
                }

                indexModel.FormModel.WidgetQuantities = widgetQuantity;
            }

            if (state < 1 || state > 50) {
                AddErrorMessage("Selected state is invalid.");
            }
            else {
                indexModel.FormModel.SelectedState = state;
            }

            MessageModel message = TempData["Message"] as MessageModel;

            if (message != null && message.Type == "danger") {
                return View("Index", indexModel);
            }
            else {
                TempData["Message"] = new SuccessMessageModel {
                    Message = "Calculation successful."
                };

                return View(WidgetCalculateViewModel.Create(indexModel));
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