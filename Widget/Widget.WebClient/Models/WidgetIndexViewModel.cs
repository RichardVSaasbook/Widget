using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widget.Domain.Abstract;
using Widget.Domain.Models;

namespace Widget.WebClient.Models {
    public class WidgetIndexViewModel {
        public static WidgetIndexViewModel Create(IStateRepository stateRepository, IWidgetRepository widgetRepository) {
            return Create(stateRepository, widgetRepository, 1, new List<int>());
        }

        public static WidgetIndexViewModel Create(IStateRepository stateRepository, IWidgetRepository widgetRepository, int selectedState, List<int> widgetQuantities) {
            List<State> states = stateRepository.ListStates();
            List<SelectListItem> stateSelectItems = new List<SelectListItem>();

            foreach (State state in states) {
                stateSelectItems.Add(new SelectListItem {
                    Text = state.Name,
                    Value = state.Id.ToString(),
                    Selected = state.Id == selectedState
                });
            }

            List<Domain.Models.Widget> widgets = widgetRepository.ListWidgets();
            List<WidgetViewModel> widgetViewModels = new List<WidgetViewModel>();
            for (int w = 0; w < widgets.Count; w++) {
                widgetViewModels.Add(new WidgetViewModel {
                    Widget = widgets[w],
                    Quantity = widgetQuantities.ElementAtOrDefault(w)
                });
            }

            return new WidgetIndexViewModel {
                States = states,
                StateItems = stateSelectItems,
                Widgets = widgetViewModels,
                FormModel = new WidgetFormModel()
            };
        }

        public List<State> States { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<WidgetViewModel> Widgets { get; set; }
        public WidgetFormModel FormModel { get; set; }
    }
}