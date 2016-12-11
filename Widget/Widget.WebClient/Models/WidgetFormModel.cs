using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Widget.WebClient.Models {
    public class WidgetFormModel {
        public int SelectedState { get; set; }
        public List<int> WidgetQuantities { get; set; }
    }
}