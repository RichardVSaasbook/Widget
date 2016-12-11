using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Widget.WebClient.Models {
    public class WidgetViewModel {
        public Domain.Models.Widget Widget { get; set; }
        public int Quantity { get; set; }

        public WidgetViewModel() {
            Quantity = 0;
        }
    }
}