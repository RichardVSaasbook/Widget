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
            List<SelectListItem> states = new List<SelectListItem>();

            foreach (State state in stateRepository.ListStates()) {
                states.Add(new SelectListItem {
                    Text = state.Name,
                    Value = state.Id.ToString()
                });
            }

            return new WidgetIndexViewModel {
                States = states,
                Widgets = widgetRepository.ListWidgets(),
                FormModel = new WidgetFormModel()
            };
        }

        public List<SelectListItem> States { get; set; }
        public List<Domain.Models.Widget> Widgets { get; set; }
        public WidgetFormModel FormModel { get; set; }
    }
}